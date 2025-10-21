Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim form = New UCRVerificationForm("20500244720220400144", "123456789")
        If form.ShowDialog() = DialogResult.OK Then
            MessageBox.Show("Save it in database", "Hello", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("No Don't save it", "Hello", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


    End Sub
End Class
