Imports System
Imports System.Management
Imports System.Threading
Imports System.IO
Imports System.IO.Ports

Public Class dfupwner

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SaveToDisk("s-irecovery.exe", mainsb.dir & "\s-irecovery.exe")
        Form1.killItunes()
        check4dfu()
        uploadstuff()
        File_Delete(mainsb.dir & "\DFU.True")

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value = ProgressBar1.Maximum Then
            ProgressBar1.Enabled = False
            Timer1.Enabled = False
            MsgBox("Your iDevice is now in a pwned DFU mode, You can now restore pointing to the IPSW on your Desktop, have fun!!", MsgBoxStyle.Information, "Done!")
            MsgBox("After iTunes restore, use Redbr3eze TetheredBoot function *Only for the First time!*", MsgBoxStyle.Exclamation)
            Application.Restart()
        ElseIf ProgressBar1.Value <> ProgressBar1.Maximum Then
            ProgressBar1.Value = ProgressBar1.Value + 20
        End If
    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackColor = Color.LightBlue
    End Sub
   


    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Hide()
    End Sub
    Public DFUConnected = False
    Public Sub check4dfu()
        Label1.Text = "Waiting for DFU..."
        Do Until File_Exists(mainsb.dir & "\DFU.True")
            'Searching for DFU...
            console.Text = " "
            Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_PnPEntity WHERE Description = 'Apple Recovery (DFU) USB Driver'")
            For Each queryObj As ManagementObject In searcher.Get()

                console.Text += (queryObj("Description"))
            Next
            If console.Text.Contains("DFU") Then
                SaveToDisk("sn0w.img3", mainsb.dir & "\DFU.True")
            End If
        Loop
    End Sub
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Do Until File_Exists(mainsb.dir & "\DFU.True")
            Label1.Text = "Waiting for DFU..."
            'Searching for DFU...
            console.Text = " "
            Dim searcher As New ManagementObjectSearcher( _
                      "root\CIMV2",
 "SELECT * FROM Win32_PnPEntity WHERE Description = 'Apple Recovery (DFU) USB Driver'")
            For Each queryObj As ManagementObject In searcher.Get()

                console.Text += (queryObj("Description"))
            Next
            If console.Text.Contains("DFU") Then
                SaveToDisk("sn0w.img3", mainsb.dir & "\DFU.True")
                Label1.Text = ""
            End If
        Loop
    End Sub

    Private Sub uploadstuff()
        Label1.Text = "Exploiting with Limera1n / Steak4uce..."
        ExecCmd(mainsb.dir & "\s-irecovery.exe -e", True)
        Timer1.Enabled = True
        File_Delete(mainsb.dir & "\s-irecovery.exe")
    End Sub
End Class
