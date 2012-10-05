Public Class devinfos

    Private Sub devinfos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If iRecovery.device.IsConnected Then
            If iRecovery.device.DeviceProductType = "iPod3,1" Then
                device.Text = "iPod Touch 3g"
            ElseIf iRecovery.device.DeviceProductType = "iPod4,1" Then
                device.Text = "iPod Touch 4g"
            ElseIf iRecovery.device.DeviceProductType = "iPod2,1" Then
                device.Text = "iPod touch 2g"
            ElseIf iRecovery.device.DeviceProductType = "iPod1,1" Then
                device.Text = "iPod touch 1g"
            ElseIf iRecovery.device.DeviceProductType = "AppleTV2,1" Then
                device.Text = "Apple TV 2g"
            ElseIf iRecovery.device.DeviceProductType = "iPad1,1" Then
                device.Text = "iPad 1g"
            ElseIf iRecovery.device.DeviceProductType = "iPad2,1" Then
                device.Text = "iPad 2g (WiFi)"
            ElseIf iRecovery.device.DeviceProductType = "iPad2,2" Then
                device.Text = "iPad 2g (At&t)"
            ElseIf iRecovery.device.DeviceProductType = "iPad2,3" Then
                device.Text = "iPad 2g (Verison)"
            ElseIf iRecovery.device.DeviceProductType = "iPhone1,1" Then
                device.Text = "iPhone 2g"
            ElseIf iRecovery.device.DeviceProductType = "iPhone1,2" Then
                device.Text = "iPhone 3g"
            ElseIf iRecovery.device.DeviceProductType = "iPhone2,1" Then
                device.Text = "iPhone 3gs (At&t)"
            ElseIf iRecovery.device.DeviceProductType = "iPhone3,3" Then
                device.Text = "iPhone 4 (Verison)"
            ElseIf iRecovery.device.DeviceProductType = "iPhone3,1" Then
                device.Text = "iPhone 4 (At&t)"
            ElseIf iRecovery.device.DeviceProductType = "iPhone4,1" Then
                device.Text = "iPhone 4s"
            ElseIf iRecovery.device.DeviceProductType = "iPad3,1" Or iRecovery.device.DeviceProductType = "iPad3,2" Then
                device.Text = "iPad 3g"
            End If
            version.Text = iRecovery.device.DeviceFirmwareVersion
            ios.Text = iRecovery.device.DeviceVersion
            If ios.Text = "4.3.3" Then
                Label6.Text = "Untethered: Saffron"
            ElseIf ios.Text = "4.3.4" Or ios.Text = "4.3.5" Then
                Label6.Text = "Tethered: Redsn0w"
            ElseIf ios.Text = "5.0.1" Or ios.Text = "5.1.1" Then
                Label6.Text = "Untethered: Corona"
            ElseIf ios.Text = "6.0" And Not device.Text.Contains("iPad 2g") And Not device.Text.Contains("iPad 3g") Then
                Label6.Text = "Tethered: Redsn0w"
            ElseIf ios.Text = "4.2.1" Or ios.Text = "4.1" Then
                Label6.Text = "Untethered: Greenpois0n"
            Else
                Label6.Text = "No"
            End If
            If iRecovery.device.IsJailbreak Then
                Label7.Text = "Yes"
            Else
                Label7.Text = "No"
            End If
        Else
            MsgBox("iPhone not found!", MsgBoxStyle.Exclamation)
            Application.Restart()
        End If
    End Sub
End Class
