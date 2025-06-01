Imports System.Diagnostics
Imports System.Runtime.InteropServices

Public Class Shell95Taskbar
    Private startMenu As New ShellStart()

    Private Sub Shell95Taskbar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' hey, wait a minute! we're in debug mode! run anyway.
#If DEBUG Then
        If Debugger.IsAttached Then
            MessageBox.Show("Shell95 is in debugging mode.", "Shell95", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
#Else


        ' hello explorer :3
        If IsExplorerRunning() Then
            MessageBox.Show("Explorer.exe is currently running, and Shell95 will not run.", "Shell95", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Application.Exit()
            Return
        End If
#End If

        ' fix weird issue where clicking Start doesnt work
        Me.Focus()
        Me.BringToFront()

        ' glue taskbar to bottom, i guess?
        Dim scr = Screen.PrimaryScreen.Bounds
        Me.ShowInTaskbar = False
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.TopMost = True
        Me.Left = 0
        Me.Width = scr.Width
        Me.Height = 24
        Me.Top = scr.Height - Me.Height
    End Sub

    Private Function IsExplorerRunning() As Boolean
        Dim processes() As Process = Process.GetProcessesByName("explorer")
        Return processes.Length > 0
    End Function

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        If startMenu Is Nothing OrElse startMenu.IsDisposed Then
            startMenu = New ShellStart()
        End If

        If startMenu.Visible Then
            startMenu.Hide()
        Else
            ' hijhkhgfsfbgklajsgflka
            startMenu.Left = 0
            startMenu.Top = Screen.PrimaryScreen.WorkingArea.Height - startMenu.Height
            startMenu.Show()
            startMenu.Activate()
        End If
    End Sub

    Private Sub Shell95Taskbar_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.Activate()

    End Sub
End Class
