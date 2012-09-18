Imports System.Threading
Imports System.Management
Public Class redbootrs
    Private Sub ready2go()
        CheckForIllegalCrossThreadCalls = False
        SaveToDisk("s-irecovery.exe", mainsb.dir & "\s-irecovery.exe")
        SaveToDisk("bspatch.exe", mainsb.dir & "\bspatch.exe")
        Form1.killItunes()
        dfupwner.check4dfu()
        Label1.Text = "Exploiting with Limera1n..."
        ExecCmd(mainsb.dir & "\s-irecovery.exe -e", False)
        Thread.Sleep(3000)
        ProgressBar1.Value = 20
        SaveToDisk("iBSS.n81ap.RELEASE.dfu", mainsb.dir & "\iBSS.n81ap.RELEASE.dfu")
        SaveToDisk("iBEC.n81ap.RELEASE.dfu", mainsb.dir & "\iBEC.n81ap.RELEASE.dfu")
        SaveToDisk("kernelcache.release.n81", mainsb.dir & "\kernelcache.release.n81")

        Label1.Text = "Uploading iBSS..."

        ExecCmd(mainsb.dir & "\s-irecovery.exe -f " & mainsb.dir & "\iBSS.n81ap.RELEASE.dfu", False)
        Thread.Sleep(6000)

        ProgressBar1.Value = 40
        Label1.Text = "Uploading iBEC..."
        If System.IO.File.Exists(mainsb.dir & "\iBEC.n81ap.RELEASE.dfu") Then
            ExecCmd(mainsb.dir & "\s-irecovery.exe -f " & mainsb.dir & "\iBEC.n81ap.RELEASE.dfu", False)
            Thread.Sleep(4000)
        Else
            MsgBox("err")
        End If
        ExecCmd(mainsb.dir & "\s-irecovery.exe -c " & Chr(34) & "bgcolor i 300 i" & Chr(34), False)
        ProgressBar1.Value = 60
        Label1.Text = "Uploading Kernel..."
        ExecCmd(mainsb.dir & "\s-irecovery.exe -c " & Chr(34) & "bgcolor i 200 i" & Chr(34), False)
        ExecCmd(mainsb.dir & "\s-irecovery.exe -f " & mainsb.dir & "\DeviceTree.n81ap.img3", False)
        Thread.Sleep(3000)
        My.Computer.FileSystem.CreateDirectory(mainsb.dir & "\Kernel")
        SaveToDisk("bootkernel5.1.1.n81", mainsb.dir & "\Kernel\kernelcache(b).release.n81")
        ExecCmd(mainsb.dir & "\s-irecovery.exe -c " & Chr(34) & "bgcolor i 100 i" & Chr(34), False)
        ExecCmd(mainsb.dir & "\s-irecovery.exe -f " & mainsb.dir & "\Kernel\kernelcache(b).release.n81", False)
        ExecCmd(mainsb.dir & "\s-irecovery.exe -c " & Chr(34) & "bgcolor i 20 i" & Chr(34), False)
        Thread.Sleep(6000)
        ProgressBar1.Value = 80
        Label1.Text = "Booting kernel..."
        ExecCmd(mainsb.dir & "\s-irecovery.exe -c " & Chr(34) & "bootx" & Chr(34), False)
        ExecCmd(mainsb.dir & "\s-irecovery.exe -c " & Chr(34) & "bgcolor i 15 i" & Chr(34), False)
        ProgressBar1.Value = 100
        Label1.Text = "Done!"
        ExecCmd(mainsb.dir & "\s-irecovery.exe -c " & Chr(34) & "bgcolor i 0 i" & Chr(34), False)
        MsgBox("Done!", MsgBoxStyle.Information)
        File_Delete(mainsb.dir & "\s-irecovery.exe")
        File_Delete(mainsb.dir & "\bspatch.exe")
        File_Delete(mainsb.dir & "\iBSS.n81ap.RELEASE.dfu")
        File_Delete(mainsb.dir & "\iBEC.n81ap.RELEASE.dfu")
        File_Delete(mainsb.dir & "\kernelcache.release.n81")
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Label1.Text = "Waiting for DFU device..."
        BackgroundWorker2.RunWorkerAsync()
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Label1.Text = ""
        ready2go()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        redsn0wy.Show()
    End Sub

    Private Sub redbootrs_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Try
            System.IO.File.Delete(mainsb.dir & "\DFU.True")
        Catch ex As Exception
        End Try
        Application.Exit()
    End Sub

    Private Sub redbootrs_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Form1.killItunes()
    End Sub
    Private Sub check4dfu()
        CheckForIllegalCrossThreadCalls = False
        Label1.Text = "Waiting for DFU..."
        Do Until File_Exists(mainsb.dir & "\DFU.True")
            'Searching for DFU...
            Console.Text = " "
            Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_PnPEntity WHERE Description = 'Apple Recovery (DFU) USB Driver'")
            For Each queryObj As ManagementObject In searcher.Get()

                Console.Text += (queryObj("Description"))
            Next
            If Console.Text.Contains("DFU") Then
                SaveToDisk("sn0w.img3", mainsb.dir & "\DFU.True")
            End If
        Loop
    End Sub
    Private Sub BackgroundWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        check4dfu()
    End Sub
End Class