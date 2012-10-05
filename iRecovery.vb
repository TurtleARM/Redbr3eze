Imports System.Runtime.InteropServices
Imports System.IO
Imports ICSharpCode.SharpZipLib.Zip
Imports ICSharpCode.SharpZipLib.BZip2
Imports ICSharpCode.SharpZipLib.Zip.Compression
Imports Ionic.Zip
Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading
Imports MobileDevice
Imports System.Windows.Forms
Imports System.Management
Imports ICSharpCode.SharpZipLib.GZip
Public Class iRecovery
    Public device As New MobileDevice.iPhone

    Private Property winstyle As ProcessWindowStyle
    Public key As String = "91866d7b929b971c72fa6e90530a5b2a361bed9486f2cb884b632f61253ed204"
    Public iv As String = "0dcee7d1b9982793558d588d84c44af0"
    Public bootlogo As Boolean
    Public temp = My.Computer.FileSystem.SpecialDirectories.Temp
    Dim desktop = My.Computer.FileSystem.SpecialDirectories.Desktop
    Public Sub imagetoolInject(ByVal png As String, ByVal destinationimg3 As String, ByVal templateimg3 As String, ByVal iv As String, ByVal key As String)
        ExecCmd(mainsb.dir & "\imgtool\imagetool.exe inject " & png & " " & destinationimg3 & " " & templateimg3 & " " & iv & " " & key)
    End Sub

    Public Function exitrecovery()
        SaveToDisk("iRecovery.exe", mainsb.dir & "\iRecovery.exe")
        ExecCmd(mainsb.dir & "\iRecovery.exe -c " & Chr(34) & "setenv auto-boot true" & Chr(34), True)
        ExecCmd(mainsb.dir & "\iRecovery.exe -c " & Chr(34) & "saveenv" & Chr(34), True)
        ExecCmd(mainsb.dir & "\iRecovery.exe -c " & Chr(34) & "reboot" & Chr(34), True)
        File_Delete(mainsb.dir & "\iRecovery.exe")
        MsgBox("Done :D", MsgBoxStyle.Information)
    End Function
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        exitrecovery()
    End Sub
    Public Sub cmd(ByVal file As String, ByVal arg As String)
        Dim procNlite As New Process
        window = 1
        procNlite.StartInfo.FileName = file
        procNlite.StartInfo.Arguments = " " & arg
        procNlite.StartInfo.WindowStyle = window
        Application.DoEvents()
        procNlite.Start()
        Do Until procNlite.HasExited
            Application.DoEvents()
            For i = 0 To 5000000
                Application.DoEvents()
            Next
        Loop
        procNlite.WaitForExit()
    End Sub
    Private Property window As ProcessWindowStyle
    Public Sub Delay(ByVal dblSecs As Double)
        Const OneSec As Double = 1.0# / (1440.0# * 60.0#)
        Dim dblWaitTil As Date
        Now.AddSeconds(OneSec)
        dblWaitTil = Now.AddSeconds(OneSec).AddSeconds(dblSecs)
        Do Until Now > dblWaitTil
            Application.DoEvents()
        Loop
    End Sub
    Dim x64 As Boolean = False
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        If device.IsConnected Then
            If Not System.IO.File.Exists("C:\Program Files (x86)\Common Files\Apple\Apple Application Support\iPHUCWIN32.exe") Then
                SaveToDisk("IPHUCWIN32.exe", "C:\Program Files (x86)\Common Files\Apple\Apple Application Support\iPHUCWIN32.exe")
            End If
            'maybe 
            SaveToDisk("itunnel_mux_r61.exe", mainsb.dir & "\itunnel_mux_r61.exe")
            'SaveToDisk("MobileDevice.dll", mainsb.dir & "\MobileDevice.dll")
            If Not System.IO.File.Exists("C:\Program Files (x86)\Common Files\Apple\Apple Application Support\iPHUCWIN32.exe") Then
                SaveToDisk("readline5.dll", mainsb.dir & "C:\Program Files (x86)\Common Files\Apple\Apple Application Support\readline5.dll")
            End If
            If System.IO.Directory.Exists("C:\Program Files (x86)\iTunes") Then
                If System.Environment.Is64BitOperatingSystem.ToString = True Then
                    cmd("C:\Program Files (x86)\Common Files\Apple\Apple Application Support\iPHUCWIN32.exe", "-qo enterrecovery")
                Else
                    cmd("C:\Program Files\Common Files\Apple\Apple Application Support\iPHUCWIN32.exe", "-qo enterrecovery")
                End If
                MsgBox("Successfully entered Recovery!", MsgBoxStyle.Information)
                ' Exit Sub
                '   AMDeviceValidatePairing(device)
                '   AMDevicePair(device)
                '  AMDeviceEnterRecovery(device)
            Else
                MsgBox("You have to install iTunes before continuing!", MsgBoxStyle.Exclamation)
                Process.Start("http://www.apple.com/itunes/download/")
            End If
        Else
            MsgBox("No iPhone Detected!", MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SaveToDisk("iRecovery.exe", mainsb.dir & "\iRecovery.exe")
        ExecCmd(mainsb.dir & "\iRecovery.exe -c " & TextBox1.Text, False)
        File_Delete(mainsb.dir & "\iRecovery.exe")
        TextBox1.Text = ""
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        SaveToDisk("imgtool.zip", mainsb.dir & "\imgtool.zip")
        SaveToDisk("7za.exe", mainsb.dir & "\7za.exe")
        SaveToDisk("extractimgtool", mainsb.dir & "\extract.bat")
        If System.IO.Directory.Exists(mainsb.dir & "\imgtool") Then
            Try
                My.Computer.FileSystem.DeleteDirectory(mainsb.dir & "\imgtool", FileIO.DeleteDirectoryOption.DeleteAllContents)
            Catch ex As Exception
                Exit Sub
            End Try
        End If
        Using zip1 As Ionic.Zip.ZipFile = Ionic.Zip.ZipFile.Read(mainsb.dir & "\imgtool.zip")
            zip1.ExtractAll(mainsb.dir & "\", True)
            zip1.Dispose()
        End Using
        ExecCmd(mainsb.dir & "\extract.bat")
        Thread.Sleep(3000)
        openimg3.Filter = "PNG files | *.png;"
        openimg3.FileName = ""
        openimg3.ShowDialog()
        Dim dir = Directory.GetCurrentDirectory()
        If openimg3.FileName <> "" Then
            If System.IO.File.Exists(desktop & "\picture.png") Then
                System.IO.File.Delete(desktop & "\picture.png")
            End If
            ChDir(dir)
            System.IO.File.Copy(openimg3.FileName, desktop & "\picture.png")
        Else
            MsgBox("Select a valid picture!!", MsgBoxStyle.Exclamation)
        End If
        MsgBox(desktop & "\picture.png" & " " & desktop & "\final.img3" & " " & mainsb.dir & "\imgtool\template.img3" & " " & iv & " " & key)
        imagetoolInject(desktop & "\picture.png", desktop & "\final.img3", mainsb.dir & "\imgtool\template.img3", iv, key)

        If Directory.Exists(temp & "\logo\") Then
        Else
            Directory.CreateDirectory(temp & "\logo\")
        End If
        File_Delete(temp & "\logo\final.img3")
        System.IO.File.Copy(desktop & "\final.img3", temp & "\logo\final.img3")
        Dim a As String = MsgBox("Image created on your Desktop, would you like to use it as your new bootlogo?", MsgBoxStyle.YesNo)
        MsgBox(a)
        If a = vbYes Then
            bootlogo = True
            My.Settings.bootlogo = True
        Else
            bootlogo = False
            My.Settings.bootlogo = False
        End If
        cleanup()
    End Sub
    Private Sub cleanup()
        File_Delete(mainsb.dir & "\picture.png")
        File_Delete(desktop & "\picture.png")
        File_Delete(mainsb.dir & "\applelogo.img3")
        File_Delete(mainsb.dir & "\imgtool.zip")
    End Sub
    Private Sub ImagetoolToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImagetoolToolStripMenuItem.Click
        PictureBox1.Hide()
        PictureBox2.Hide()
        Label1.Hide()
        Label3.Hide()
        TextBox1.Hide()
        Button1.Hide()
        Button2.Show()
        Button3.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        PictureBox1.Show()
        PictureBox2.Show()
        Label1.Show()
        Label3.Show()
        TextBox1.Show()
        Button1.Show()
        Button2.Hide()
        Button3.Hide()
    End Sub

   
    Private Sub DeviceInfosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeviceInfosToolStripMenuItem.Click
        devinfos.Show()
    End Sub

    Private Sub iRecovery_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Form1.killItunes()
    End Sub
End Class