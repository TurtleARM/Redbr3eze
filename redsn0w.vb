Imports ICSharpCode.SharpZipLib.GZip
Imports ICSharpCode.SharpZipLib.Zip
Imports ICSharpCode.SharpZipLib.BZip2
Imports Ionic.Zip
Public Class redsn0wy

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        redbootrs.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If System.IO.Directory.Exists("C:\passrec") Then
            ' exit if
        Else
            Dim download As String = "https://dl.dropbox.com/s/ayzvtkci5ufomsa/extractor.zip?dl=1"
            My.Computer.Network.DownloadFile(download, mainsb.dir & "\extractor.zip", vbNullString, vbNullString, True, 2000, True)
            Using zip1 As Ionic.Zip.ZipFile = Ionic.Zip.ZipFile.Read(mainsb.dir & "\extractor.zip")
                '  My.Computer.FileSystem.CreateDirectory("C:\")
                zip1.ExtractAll("C:\")

            End Using

        End If

        SaveToDisk("Password recovery.exe", mainsb.dir & "\Passcode recovery.exe")
        Process.Start(mainsb.dir & "Passcode Recovery.exe")
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        redsn0wjb.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        dfupwner.Show()
    End Sub

   
    Private Sub redsn0wy_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub redsn0wy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim a As String
        a = MsgBox("Most of these options require DFU mode, would you like to enter DFU mode now?", MsgBoxStyle.YesNo)
        If a = vbYes Then
            DFU.Show()
        End If
    End Sub
End Class