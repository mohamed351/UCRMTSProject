Imports UCRMTS.dll

Public Class UCRVerificationForm

    Public Property UCR As String
    Public Property ShipperID As String

    Public Property IsValidBooking As Boolean = False

    Public Property IsValidLoading As Boolean = False
    Public Sub New(UCR As String, ShipperID As String)
        Me.UCR = UCR
        Me.ShipperID = ShipperID
        InitializeComponent()

    End Sub

    Public Async Function GetData() As Task
        Try
            Dim result = Await UCRMTS.dll.MTSRequests.UCRVerification(UCR, ShipperID)
            Dim AdditionalNote = result.ExchangedDeclaration.AdditionalStatementNote.FirstOrDefault()
            txtShipperTaxID.Text = ShipperID
            txtUCRVerification.Text = UCR
            IsValidBooking = (AdditionalNote.Subject.Content = "bookingEligible" AndAlso AdditionalNote.Content(0).Content = "true")
            IsValidLoading = (AdditionalNote.Subject.Content = "loadingEligible" AndAlso AdditionalNote.Content(0).Content = "true")
            isBookingEligableCheckBox.Checked = IsValidBooking
            isLoadingEligableCheckBox.Checked = IsValidLoading
        Catch ex As UCRException
            If (ex.HttpStatusCode = Net.HttpStatusCode.NotFound) Then
                MessageBox.Show("UCR is not valid", "UCR", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try



    End Function

    Private Async Sub UCRVerificationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Await GetData()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If (IsValidBooking Or IsValidLoading) Then
            Me.DialogResult = DialogResult.OK
        Else
            Me.DialogResult = DialogResult.No
        End If

        Me.Close()
    End Sub
End Class