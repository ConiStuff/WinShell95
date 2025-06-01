Public Class ShellStart

    Private Sub ShellStart_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' where do you want to go today? to HELL.
        Me.FormBorderStyle = FormBorderStyle.None
        Me.ControlBox = False
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.StartPosition = FormStartPosition.Manual
        Me.Width = 240
        Me.Height = 310
        Me.Left = 0
        Me.Top = Screen.PrimaryScreen.WorkingArea.Height
    End Sub

    Private Sub StartMenuForm_Deactivate(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Deactivate
        Me.Hide()

    End Sub
End Class