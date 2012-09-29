Imports System.Threading
Public Class redsn0wjb

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        redsn0wy.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        BackgroundWorker1.RunWorkerAsync()
        Button2.Visible = True
        Button1.Hide()
        ProgressBar1.Visible = True
    End Sub
    Private Sub ready2go()
        Control.CheckForIllegalCrossThreadCalls = False
        SaveToDisk("s-irecovery.exe", mainsb.dir & "\s-irecovery.exe")
        SaveToDisk("bspatch.exe", mainsb.dir & "\bspatch.exe")
        Form1.killItunes()
        dfupwner.check4dfu()
        Label1.Text = "Exploiting with Limera1n..."
        ExecCmd(mainsb.dir & "\s-irecovery.exe -e", True)
        Thread.Sleep(3000)
        ProgressBar1.Value = 20
        Label1.Text = "Uploading iBSS..."
        ExecCmd(mainsb.dir & "\s-irecovery.exe -f " & mainsb.dir & "\iBSS.n81ap.RELEASE.dfu", True)
        Thread.Sleep(5000)
        ProgressBar1.Value = 30
        Label1.Text = "Uploading iBEC..."
        ExecCmd(mainsb.dir & "\s-irecovery.exe -f " & mainsb.dir & "\iBEC.n81ap.RELEASE.dfu", True)
        Thread.Sleep(4000)
        ProgressBar1.Value = 50
        Label1.Text = "Uploading Ramdisk..."
        ExecCmd(mainsb.dir & "\s-irecovery.exe -f " & mainsb.dir & "\cstramdisk.dmg", True)
        Thread.Sleep(5000)
        ExecCmd(mainsb.dir & "\s-irecovery.exe -c " & Chr(34) & "ramdisk" & Chr(34), True)
        Thread.Sleep(2000)
        ProgressBar1.Value = 70
        Label1.Text = "Uploading Kernel..."
        ExecCmd(mainsb.dir & "\s-irecovery.exe -f " & mainsb.dir & "\DeviceTree.n81ap.img3", True)
        Thread.Sleep(3000)
        ExecCmd(mainsb.dir & "\s-irecovery.exe -f " & mainsb.dir & "\kernelcache.release.n81", True)
        Thread.Sleep(6000)
        ProgressBar1.Value = 80
        Label1.Text = "Booting kernel..."
        ExecCmd(mainsb.dir & "\s-irecovery.exe -c " & Chr(34) & "bootx" & Chr(34), True)
        ProgressBar1.Value = 100
        MsgBox("Done!", MsgBoxStyle.Information)
        File_Delete(mainsb.dir & "\s-irecovery.exe")
        File_Delete(mainsb.dir & "\bspatch.exe")

    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        ready2go()
    End Sub

    Private Sub redsn0wjb_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub redsn0wjb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Form1.killItunes()
    End Sub

    

    Private Sub DoNotInstallUntetherHacksToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DoNotInstallUntetherHacksToolStripMenuItem.Click

    End Sub

    Private Sub UseCustomRamdiskToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UseCustomRamdiskToolStripMenuItem.Click

    End Sub

    Private Sub BootACustomKernelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BootACustomKernelToolStripMenuItem.Click

    End Sub

    Private Sub InjectFileafc2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InjectFileafc2ToolStripMenuItem.Click

    End Sub

    Private Sub CustomBootlogoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomBootlogoToolStripMenuItem.Click

    End Sub
End Class