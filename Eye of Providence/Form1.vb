Imports System.IO
Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim watched As String = "C:\"
        Dim fsw As New FileSystemWatcher(watched)
        fsw.IncludeSubdirectories = True
        fsw.NotifyFilter = NotifyFilters.FileName Or NotifyFilters.LastWrite

        AddHandler fsw.Changed, AddressOf fsw_changed
        AddHandler fsw.Created, AddressOf fsw_changed
        AddHandler fsw.Deleted, AddressOf fsw_changed
        AddHandler fsw.Renamed, AddressOf fsw_changed
        fsw.EnableRaisingEvents = True
    End Sub
    Private Sub fsw_changed(ByVal sender As Object, ByVal e As FileSystemEventArgs)

        setLabelTxt("Monitoring: " & e.FullPath, Label2)
    End Sub
    Public Shared Sub setLabelTxt(ByVal text As String, ByVal lbl As Label)
        If lbl.InvokeRequired Then
            lbl.Invoke(New setLabelTxtInvoker(AddressOf setLabelTxt), text, lbl)
        Else
            lbl.Text = text
        End If
    End Sub
    Public Delegate Sub setLabelTxtInvoker(ByVal text As String, ByVal lbl As Label)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Application.Exit()
    End Sub
End Class