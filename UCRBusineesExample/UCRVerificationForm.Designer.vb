<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCRVerificationForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.isLoadingEligableCheckBox = New System.Windows.Forms.CheckBox()
        Me.isBookingEligableCheckBox = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtShipperTaxID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtUCRVerification = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(304, 156)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'isLoadingEligableCheckBox
        '
        Me.isLoadingEligableCheckBox.AutoSize = True
        Me.isLoadingEligableCheckBox.Enabled = False
        Me.isLoadingEligableCheckBox.Location = New System.Drawing.Point(263, 110)
        Me.isLoadingEligableCheckBox.Name = "isLoadingEligableCheckBox"
        Me.isLoadingEligableCheckBox.Size = New System.Drawing.Size(115, 17)
        Me.isLoadingEligableCheckBox.TabIndex = 12
        Me.isLoadingEligableCheckBox.Text = "Is Loading Eligable"
        Me.isLoadingEligableCheckBox.UseVisualStyleBackColor = True
        '
        'isBookingEligableCheckBox
        '
        Me.isBookingEligableCheckBox.AutoSize = True
        Me.isBookingEligableCheckBox.Enabled = False
        Me.isBookingEligableCheckBox.Location = New System.Drawing.Point(12, 110)
        Me.isBookingEligableCheckBox.Name = "isBookingEligableCheckBox"
        Me.isBookingEligableCheckBox.Size = New System.Drawing.Size(116, 17)
        Me.isBookingEligableCheckBox.TabIndex = 11
        Me.isBookingEligableCheckBox.Text = "Is Booking Eligable"
        Me.isBookingEligableCheckBox.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Shipper Tax ID:"
        '
        'txtShipperTaxID
        '
        Me.txtShipperTaxID.Enabled = False
        Me.txtShipperTaxID.Location = New System.Drawing.Point(12, 83)
        Me.txtShipperTaxID.Name = "txtShipperTaxID"
        Me.txtShipperTaxID.Size = New System.Drawing.Size(367, 20)
        Me.txtShipperTaxID.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "UCR"
        '
        'txtUCRVerification
        '
        Me.txtUCRVerification.Enabled = False
        Me.txtUCRVerification.Location = New System.Drawing.Point(12, 35)
        Me.txtUCRVerification.Name = "txtUCRVerification"
        Me.txtUCRVerification.Size = New System.Drawing.Size(367, 20)
        Me.txtUCRVerification.TabIndex = 7
        '
        'UCRVerificationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 192)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.isLoadingEligableCheckBox)
        Me.Controls.Add(Me.isBookingEligableCheckBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtShipperTaxID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtUCRVerification)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UCRVerificationForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "UCRVerificationForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSave As Button
    Friend WithEvents isLoadingEligableCheckBox As CheckBox
    Friend WithEvents isBookingEligableCheckBox As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtShipperTaxID As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtUCRVerification As TextBox
End Class
