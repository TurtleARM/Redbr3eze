Imports System.Runtime.InteropServices

Public Class iRecovery
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
    <DllImport("C:\Users\pad2g\Desktop\iTunesMobileDevice.dll")> Public Shared Function AMDeviceEnterRecovery()

    End Function
    Private Sub iRecovery_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SaveToDisk("iRecovery.exe", mainsb.dir & "\iRecovery.exe")

    End Sub
 Public Function enterrecovery()
        Process.Start(mainsb.dir & "\Enter.exe")
        MsgBox("Done :D", MsgBoxStyle.Information)
    End Function
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
        Dim strRisultato As String = vbEmpty
        AMDeviceEnterRecovery()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SaveToDisk("s-irecovery.exe", mainsb.dir & "\s-irecovery.exe")
        ExecCmd(mainsb.dir & "\s-irecovery.exe -c " & TextBox1.Text, False)
        File_Delete(mainsb.dir & "\s-irecovery.exe")
        TextBox1.Text = ""
    End Sub
End Class