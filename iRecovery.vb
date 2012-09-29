Imports System.Runtime.InteropServices
Imports System.IO
Imports ICSharpCode.SharpZipLib.Zip
Imports ICSharpCode.SharpZipLib.BZip2
Imports ICSharpCode.SharpZipLib.Zip.Compression
Imports Ionic.Zip
Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports System.Management
Imports ICSharpCode.SharpZipLib.GZip
Public Class iRecovery
    Private Property winstyle As ProcessWindowStyle
    Public key As String = "91866d7b929b971c72fa6e90530a5b2a361bed9486f2cb884b632f61253ed204"
    Public iv As String = "0dcee7d1b9982793558d588d84c44af0"
    Public bootlogo As Boolean
    Public temp = My.Computer.FileSystem.SpecialDirectories.Temp
    Dim desktop = My.Computer.FileSystem.SpecialDirectories.Desktop
    Public Sub imagetoolInject(ByVal png As String, ByVal destinationimg3 As String, ByVal templateimg3 As String, ByVal iv As String, ByVal key As String)
        ExecCmd(mainsb.dir & "\imgtool\imagetool.exe inject " & png & " " & destinationimg3 & " " & templateimg3 & " " & iv & " " & key)
    End Sub
    Public Structure am_device
        Dim unknown0() As Char
        Dim device_id As Integer
        Dim product_id As Integer
        Dim serial As Char
        Dim unknown1 As Integer
        Dim unknown2 As Integer
        Dim lockdown_con As Integer
        Dim unknown() As Char
        Dim unknown4 As Integer
        Dim unknown5() As Char
    End Structure
    Dim device As am_device
    <DllImport("C:\Users\pad2g\Desktop\iTunesMobileDevice.dll")> Public Shared Function AMDeviceValidatePairing(ByVal device)

    End Function
    <DllImport("C:\Users\pad2g\Desktop\iTunesMobileDevice.dll")> Public Shared Function AMDevicePair(ByVal device)

    End Function
    <DllImport("C:\Users\pad2g\Desktop\iTunesMobileDevice.dll")> Public Shared Function AMDeviceEnterRecovery(ByVal device)

    End Function
    Private Sub iRecovery_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SaveToDisk("iRecovery.exe", mainsb.dir & "\iRecovery.exe")

    End Sub
    Public Function exitrecovery()
        SaveToDisk("s-irecovery.exe", mainsb.dir & "\s-irecovery.exe")
        ExecCmd(mainsb.dir & "\s-irecovery.exe -c " & Chr(34) & "setenv auto-boot true" & Chr(34), False)
        ExecCmd(mainsb.dir & "\s-irecovery.exe -c " & Chr(34) & "saveenv" & Chr(34), False)
        ExecCmd(mainsb.dir & "\s-irecovery.exe -c " & Chr(34) & "reboot" & Chr(34), False)
        File_Delete(mainsb.dir & "\s-irecovery.exe")
        MsgBox("Done :D", MsgBoxStyle.Information)
    End Function
    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        exitrecovery()
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

        MsgBox("Available from next update")
        Exit Sub
        AMDeviceValidatePairing(device)
        AMDevicePair(device)
        AMDeviceEnterRecovery(device)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SaveToDisk("s-irecovery.exe", mainsb.dir & "\s-irecovery.exe")
        ExecCmd(mainsb.dir & "\s-irecovery.exe -c " & TextBox1.Text, False)
        File_Delete(mainsb.dir & "\s-irecovery.exe")
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
End Class