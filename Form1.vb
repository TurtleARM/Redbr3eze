Imports System.Net
Imports System.Net.Mail

Public Class Form1
    Private processo As Process
    Private alfa() As Process
    Private nome As String
    Public Sub killItunes()
        Shell("taskkill /f /t /im iTunes.exe", AppWinStyle.Hide)
        Shell("taskkill /f /t /im iTunesHelper.exe", AppWinStyle.Hide)
    End Sub
   

    Public Sub CheckForUpdates()
        CheckForIllegalCrossThreadCalls = False
        Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("https://dl.dropbox.com/u/60501515/Redbr3eze/Tool%20update.txt")

        Dim response As System.Net.HttpWebResponse = request.GetResponse()
        Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
        Dim newestversion As String = sr.ReadToEnd()
        Dim currentversion As String = Application.ProductVersion
        If newestversion.Contains(currentversion) Then
            ' ignore meh 
        Else
            Label1.Text = "Update available"
            MsgBox("There is a new update, Redbr3eze will download it for you.")
            System.Diagnostics.Process.Start("https://dl.dropbox.com/u/60501515/Redbr3eze/Redbr3eze.exe")
        End If

    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SaveToDisk("Ionic.Zip.dll", mainsb.dir & "\Ionic.Zip.dll")
        SaveToDisk("ICSharpCode.SharpZipLib.dll", mainsb.dir & "\ICSharpCode.SharpZipLib.dll")
        ' sendmail()
        MenuStrip1.BackColor = Color.Black
        MenuStrip1.ForeColor = Color.White
        Me.BackColor = Color.AliceBlue
        cred.BackColor = Color.Black
        cred.ForeColor = Color.White
        Label1.BackColor = Color.Black
        Label1.ForeColor = Color.White
        cred2.BackColor = Color.Black
        cred2.ForeColor = Color.White
        BackgroundWorker1.RunWorkerAsync()
    End Sub


    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
      
        Me.Hide()
        redsn0wy.Show()

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
     
        Me.Hide()
        sn0wbreezy.Show()
    End Sub

    Private Sub ReportAProblemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportAProblemToolStripMenuItem.Click
        report.Show()
    End Sub

    Private Sub PictureBox2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseEnter
        PictureBox2.Image = My.Resources.images__2_
    End Sub

    Private Sub PictureBox2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox2.MouseLeave
        PictureBox2.Image = My.Resources.images2
    End Sub

    Private Sub PictureBox1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseEnter
        PictureBox1.Image = My.Resources.images__3_
    End Sub

    Private Sub PictureBox1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.MouseLeave
        PictureBox1.Image = My.Resources.images1
    End Sub

    Private Sub DFUPwnerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DFUPwnerToolStripMenuItem.Click
        dfupwner.Show()
    End Sub

    Private Sub LaunchITunesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaunchITunesToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("iTunes.exe")
        Catch ex As Exception
            MsgBox("Looks like you have to install iTunes")
            Process.Start("http://www.apple.com/itunes/download/")
        End Try
    End Sub


    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        DFU.Show()
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        CheckForUpdates()
    End Sub

    Private Sub DFUInstructionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DFUInstructionsToolStripMenuItem.Click
        iRecovery.Show()

    End Sub
End Class
