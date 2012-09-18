Imports System.Threading
Public Class redboot
    Public dir As String = System.IO.Directory.GetCurrentDirectory()
    Private Sub ready2boot()
        SaveToDisk("s-irecovery.exe", mainsb.dir & "\s-irecovery.exe")
        SaveToDisk("bspatch.exe", mainsb.dir & "\bspatch.exe")
        CheckForIllegalCrossThreadCalls = False
        Form1.killItunes()
        dfupwner.check4dfu()
        uploadingsb.Text = "Exploiting with Limera1n..."
        Shell(dir & "\s-irecovery.exe -e")
        progressbootsb.Value += 60
        Thread.Sleep(3500)
        uploadingsb.Text = "Uploading custom LLB..."
        SaveToDisk("llb.n81ap.dfu", mainsb.dir & "llb.n81ap.dfu")
        Shell(dir & "\s-irecovery.exe -f " & mainsb.dir & "llb.n81ap.dfu")

        progressbootsb.Value = 100
        MsgBox("Done!", MsgBoxStyle.Information)
        File_Delete(mainsb.dir & "\s-irecovery.exe")
        File_Delete(mainsb.dir & "\bspatch.exe")
        File_Delete(mainsb.dir & "\DFU.True")
    End Sub

    Private Sub bootsb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bootsb.Click
        uploadingsb.Text = "Waiting for DFU device..."
        BackgroundWorker2.RunWorkerAsync()
        BackgroundWorker2.WorkerReportsProgress = True
        BackgroundWorker2.WorkerSupportsCancellation = True
        BackgroundWorker1.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        ready2boot()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub redboot_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub redboot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Form1.killItunes()
        Me.BackColor = Color.Black
        uploadingsb.ForeColor = Color.White
    End Sub

    Private Sub BackgroundWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        dfupwner.check4dfu()
    End Sub
End Class