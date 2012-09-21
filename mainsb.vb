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
Public Class mainsb
    Public MD51 As Boolean = False
    Public ipswhash As String
    Private WithEvents get_MD5 As System.ComponentModel.BackgroundWorker
    Public cont As Int16 = 0
    Public idevloaded As Boolean
    Public build As String
    Public a As Boolean = False
    Private Sub get_md5_RunWorkerCompleted()
        Control.CheckForIllegalCrossThreadCalls = False
        If ipswhash = "7c1c714f24a89c2f2c71e26d37cde3f0" Then
            ipswrecognizeion = "4.3.2"
            ipswrecognize.Text = "4.3.2 (8H7) IPSW Verified!"
            Devicename.Text = "iPhone 3GS"
            iPhoneModel = "iPhone 3GS"


            RootFSsize = 850
        ElseIf ipswhash = "8cb3a9964a2a99414030f662d3009deb" Then
            ipswrecognizeion = "4.3.2"
            ipswrecognize.Text = "4.3.2 (8H7) IPSW Verified!"
            Devicename.Text = "iPhone 4"
            ModelVar = "n90ap"
            iPhoneModel = "iPhone 4"
            Button1.Enabled = False
            Button1.Text = "Done!"
           
            RootFSsize = 950
        ElseIf ipswhash = "30fc03783453d23aaa0d13f89fd36c28" Then
            ipswrecognizeion = "4.2.7"
            ipswrecognize.Text = "4.2.7 (8E303) IPSW Verified!"
            Devicename.Text = "iPhone 4 (Verizon)"
            iPhoneModel = "iPhone 4"
            ModelVar = "n92ap"


            RootFSsize = 950
        ElseIf ipswhash = "7f831b30d33f80c7f92442cb041227ab" Then
            ipswrecognizeion = "4.3.2"
            ipswrecognize.Text = "4.3.2 (8H7) IPSW Verified!"
            Devicename.Text = "iPod Touch 3G"
            iPhoneModel = "iPod Touch 3G"
            RootFSsize = 850


        ElseIf ipswhash = "4a002a4596a681efd9cdbf6f2fd72e74" Then
            ipswrecognizeion = "4.3.2"
            ipswrecognize.Text = "4.3.2 (8H7) IPSW Verified!"
            Devicename.Text = "iPod Touch 4"
            iPhoneModel = "iPod Touch 4"
            build = "8H7"
            RootFSsize = 930
        ElseIf ipswhash = "24027c4381a6cdfdd8a03a17177d1d6c" Then
            ipswrecognizeion = "4.3.2"
            ipswrecognize.Text = "4.3.2 (8H7) IPSW Verified!"
            Devicename.Text = "iPad"
            iPhoneModel = "iPad"
          
            RootFSsize = 1100
        ElseIf ipswhash = "893cdf844a49ae2f7368e781b1ccf6d1" Then
            ipswrecognizeion = "4.3"
            ipswrecognize.Text = "4.3 (8F202) IPSW Verified!"
            Devicename.Text = "Apple TV 2"
            iPhoneModel = "Apple TV 2"
          
            RootFSsize = 800
            PartitionSize = 800
     
        ElseIf ipswhash = "4aadc473058136d1ea37ec3436eb28ef" Then
            ipswrecognizeion = "5.1.1"
            ipswrecognize.Text = "5.1.1 (9B206) IPSW Verified!"
            Devicename.Text = "iPod Touch 4"
            iPhoneModel = "iPod Touch 4"
            build = "9B206"
            RootFSsize = 930
        ElseIf ipswhash = "449dc57f61c44033695cd3ccfeef2b04" Then
            MsgBox("iPad 2 is currently NOT supported.", MsgBoxStyle.Critical)
        ElseIf ipswhash = "dfdc5e4c5844d4d6c56e05c3ce4e7258" Then
            MsgBox("iPad 2 is currently NOT supported.", MsgBoxStyle.Critical)
        ElseIf ipswhash = "b1bfc67402a6fcee09271d562666d7c4" Then
            MsgBox("iPad 2 is currently NOT supported.", MsgBoxStyle.Critical)
        ElseIf ipswhash = "a8592e53fdbaf2e1474cb58b80ac2a4d" Then
            MsgBox("iPad 2 is currently NOT supported.", MsgBoxStyle.Critical)
        ElseIf ipswhash = "a4f25b2af99580f1e69c8277d0208237" Then
            ipswrecognizeion = "5.1.1"
            ipswrecognize.Text = "5.1.1 (9B206) IPSW Verified!"
            Devicename.Text = "iPhone 4"
            iPhoneModel = "iPhone 4"

            RootFSsize = 1000
        ElseIf ipswhash = "ba36e09d830a088b10e4a342d372a6c7" Then
            ipswrecognizeion = "5.0.1"
            ipswrecognize.Text = "5.0.1 (9A405) IPSW Verified!"
            Devicename.Text = "iPod Touch 4"
            iPhoneModel = "iPod Touch 4"
            RootFSsize = 900
        ElseIf ipswhash = "366f1767dfc5a54f805ce02130ab4cc5" Then
            ipswrecognizeion = "6.0b4"
            ipswrecognize.Text = "6.0 beta4 (10A5376e) IPSW Verified!"
            Devicename.Text = "iPod Touch 4"
            iPhoneModel = "iPod Touch 4"

            RootFSsize = 900
        ElseIf ipswhash = "b7512fcc3c50ce22d9bd554b20756686" Then
            ipswrecognizeion = "6.0b3"
            ipswrecognize.Text = "6.0 beta3 (10A5355d) IPSW Verified!"
            Devicename.Text = "iPod Touch 4"
            iPhoneModel = "iPod Touch 4"
            RootFSsize = 900

        Else
            MsgBox("IPSW not supported!", MsgBoxStyle.Critical)
        End If
        Label2.Hide()
    End Sub

    Public Function getFilesMD5Hash(ByVal file As String) As String

        'MD5 hash provider for computing the hash of the file
        Dim md5 As New MD5CryptoServiceProvider()

        'open the file
        Dim stream As New FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read, 8192)

        'calculate the files hash
        md5.ComputeHash(stream)

        'close our stream
        stream.Close()

        'byte array of files hash
        Dim hash As Byte() = md5.Hash

        'string builder to hold the results
        Dim sb As New StringBuilder()

        'loop through each byte in the byte array
        For Each b As Byte In hash
            'format each byte into the proper value and append
            'current value to return value
            sb.Append(String.Format("{0:X2}", b))
        Next

        'return the MD5 hash of the file
        Return sb.ToString.ToLower()

        iDevLoaded = True
    End Function
    Public dir As String = System.IO.Directory.GetCurrentDirectory()

    Public FINALRESIZE As String = ""
    Public ipswrecognizeion As String = ""
    Public iPhoneModel As String = ""

    Public iDevice As String = ""
   
    Public ipsw As String = ""
   
    Public PartitionSize As Int32 = 800
    
    
    'build vars
    Public Bundle As String = ""
    Public Kernel As String = ""
    Public KernelPatched As String = ""
    Public ModelVar As String = "n81ap"
    Public RootFS As String = ""
    Public RootFSKey As String = ""
    Public Ramdisk As String = ""
    Public Board As String = ""
    Public RamdiskIV As String = ""
    Public RamdiskKey As String = ""
    Public iBootkIV As String = ""
    Public iBootKey As String = ""
    Public iBECIV As String = ""
    Public iBECKey As String = ""
    Public iBSSIV As String = ""
    Public iBSSKey As String = ""
    Public LLBIV As String = ""
    Public LLBKey As String = ""
    Public applelogoIV As String = ""
    Public applelogoKey As String = ""
    Public DeviceTreeIV As String = ""
    Public DeviceTreeKey As String = ""
    Public RecoveryModeIV As String = ""
    Public batfullIV As String = ""
    Public batfullKey As String = ""
    Public RecoveryModeKey As String = ""
    Public KernelCacheIV As String = ""
    Public KernelCacheKey As String = ""
    Public RootFSsize As Int32 = 1
    Public PatchWTF As Boolean = False
    Public Unwanted = ""
    Public cmdline As String = ""
    Public quotation As String = """"

    Public Sub GetIPSWVars()
        If iPhoneModel = "iPod Touch 4" And ipswrecognizeion = "5.1.1" Then
            Bundle = ""
            Kernel = "s5l8930x"
            ModelVar = "n81ap"
            Board = "n81"
            RootFS = "038-4290-006"
            RootFSKey = "f21b4cc1ae39ed3b36d33374f77e224b9e77f375f8722c551acdc7033ef16383c0b99b39"
            Ramdisk = "038-4361-021"
            RamdiskIV = "ce6b50a8351823e0f21857d58bfc1dd1"
            RamdiskKey = "da5438ed6938b3eeaca8a3b543bcf2e461e9d9cb4f327722b5f8c3c55b197ea1"
            iBootkIV = "16641c07fe97051c445d21258722f3d1"
            iBootKey = "d302a0ba7253453bce4431dd5a2a04fbf4da9868c340eae633a0202fe0995155"
            iBECIV = "33988ce5ffd958a0e00c5d54676f7ade"
            iBECKey = "7de9d624761bafc78b02c8dc67cf5daedeb91fbb80d9d733961488fb9ce68d45"
            iBSSIV = "bdae7d7788f40887b1d6cac3cdc13a1d"
            iBSSKey = "d28ad9653306f904f28bdd56de66a80add51fc953deeb09857fb119d739bf2de"
            LLBIV = ""
            LLBKey = ""
            batfullIV = ""
            batfullKey = ""
            applelogoIV = ""
            applelogoKey = ""
            RecoveryModeIV = ""
            RecoveryModeKey = ""
            KernelCacheIV = ""
            KernelCacheKey = ""
            Unwanted = "038-4304-027"
            Dim WeNeedDeviceTree As Boolean = False
        ElseIf iPhoneModel = "iPhone 4" And ipswrecognizeion = "5.1.1" Then
            Kernel = "s5l8930x"
            ModelVar = "n90ap"
            Board = "n90"
            RootFS = "038-4292-008"
            RootFSKey = "e897c2d0aaaea8f2752ff6e144c6efc3158a5dad13c6b95ebe8b99885fc6ad0f6b5448f7"
            Ramdisk = "038-4361-021"
            RamdiskIV = "3474F5208FC45AAE32734213171B95EE"
            iBootKey = "6377d34deddf26c9b464f927f18b222be75f1b5547e537742e7dfca305660fea"
            iBootkIV = "71fe96da25812ff341181ba43546ea4f"
            RamdiskKey = "4F1419111E1C66C2E597FA79ACFAD75CE501D043AF6EDA8A980B6CD4332823EC"
            Unwanted = "038-4304-027"

        ElseIf iPhoneModel = "iPod Touch 4" And ipswrecognizeion = "6.0b3" Then 'beta 3
            Bundle = "iPhone3,3_4.2.7_8E303.bundle"
            Kernel = "s5l8930x"
            ModelVar = "n81ap"
            Board = "n81"
            RootFS = "038-5869-004"
            RootFSKey = "acc00d2cbaaf01ff755dc23cf7cbfefae36ae003b1bdc3f5220aa352b5882aeec8aa2b42"
            Ramdisk = "038-5850-004"
            RamdiskIV = "b200932e4dd32e0280d4475948409fe8"
            RamdiskKey = "0b094b320dd6ea30a5b455d7bf8f227666d045f56afd57419fbc8b520c80c094"
            iBootkIV = ""
            iBootKey = ""
            iBECIV = "33988ce5ffd958a0e00c5d54676f7ade"
            iBECKey = "7de9d624761bafc78b02c8dc67cf5daedeb91fbb80d9d733961488fb9ce68d45"
            iBSSIV = "0353a26369cea648ee6243e4b36965b5"
            iBSSKey = "fa794a3d58fa39d6a883e4a6cc12e22146653967c19301abab4328306361dd8b"
            LLBIV = ""
            LLBKey = ""
            applelogoIV = ""
            applelogoKey = ""
            RecoveryModeIV = ""
            RecoveryModeKey = ""
            KernelCacheIV = "95e1f3ea5ed61a8c67cd96143a6145c5"
            KernelCacheKey = "19b624680a104b0ed8d1d90060c9979444c9db8ff21568640cce1444a13982d2"
            Unwanted = "038-5859-004"
       
        ElseIf iPhoneModel = "iPod Touch 4" And ipswrecognizeion = "6.0b4" Then 'beta 4
            Bundle = "iPhone3,3_4.2.7_8E303.bundle"
            Kernel = "s5l8930x"
            ModelVar = "n81ap"
            Board = "n81"
            RootFS = "038-4290-006"
            RootFSKey = "......"
            Ramdisk = "..."
            RamdiskIV = "b200932e4dd32e0280d4475948409fe8"
            RamdiskKey = "0b094b320dd6ea30a5b455d7bf8f227666d045f56afd57419fbc8b520c80c094"
            iBootkIV = ""
            iBootKey = ""
            iBECIV = "33988ce5ffd958a0e00c5d54676f7ade"
            iBECKey = "7de9d624761bafc78b02c8dc67cf5daedeb91fbb80d9d733961488fb9ce68d45"
            iBSSIV = "0353a26369cea648ee6243e4b36965b5"
            iBSSKey = "fa794a3d58fa39d6a883e4a6cc12e22146653967c19301abab4328306361dd8b"
            LLBIV = ""
            LLBKey = ""
            applelogoIV = ""
            applelogoKey = ""
            RecoveryModeIV = ""
            RecoveryModeKey = ""
            KernelCacheIV = "95e1f3ea5ed61a8c67cd96143a6145c5"
            KernelCacheKey = "19b624680a104b0ed8d1d90060c9979444c9db8ff21568640cce1444a13982d2"
            Unwanted = "038-5859-004"
        End If

    End Sub
    Public Sub iBoot2()
        SaveToDisk("iBoot." & ModelVar & ".patch", dir & "\iBoot." & ModelVar & ".RELEASE.patch")

        xpwntool(dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\iBoot." & ModelVar & ".RELEASE.img3", dir & "\iboot.d", iBootkIV, iBootKey)


        bspatch(dir & "\iboot.d", dir & "\iboot.pwned", dir & "\iBoot." & ModelVar & ".RELEASE.patch")

        xpwntool_template(dir & "\iboot.pwned", dir & "\iboot.img3", dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\iBoot." & ModelVar & ".RELEASE.img3", iBootkIV, iBootKey)

        SaveToDisk("iBoot." & ModelVar & ".RELEASE-iBooty.patch", dir & "\iBoot." & ModelVar & ".RELEASE-iBooty.patch")
        If iPhoneModel = "iPhone 3GS" Then
            Delete_File(dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\batteryfull.s5l8920x.img3")
            bspatch(dir & "\iboot.img3", dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\batteryfull.s5l8920x.img3", dir & "\iBoot." & ModelVar & ".RELEASE-iBooty.patch")
        ElseIf iPhoneModel = "iPhone 4" Or iPhoneModel = "iPod Touch 4" Then
            Delete_File(dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\batteryfull@2x.s5l8930x.img3")
            bspatch(dir & "\iboot.img3", dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\batteryfull@2x.s5l8930x.img3", dir & "\iBoot." & ModelVar & ".RELEASE-iBooty.patch")
            MsgBox("replaced iboot with batteryfull")
        ElseIf iPhoneModel = "iPod Touch 3G" Then
            Delete_File(dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\batteryfull.s5l8922x.img3")
            bspatch(dir & "\iboot.img3", dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\batteryfull.s5l8922x.img3", dir & "\iBoot." & ModelVar & ".RELEASE-iBooty.patch")
        ElseIf iPhoneModel = "iPad" Then
            Delete_File(dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\batteryfull.s5l8930x.img3")
            bspatch(dir & "\iboot.img3", dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\batteryfull.s5l8930x.img3", dir & "\iBoot." & ModelVar & ".RELEASE-iBooty.patch")
        End If
        Delete_File(dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\iBoot." & ModelVar & ".RELEASE.img3.orig")
        Delete_File(dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\iBoot." & ModelVar & ".RELEASE.img3.patched")
        Delete_File(dir & "\iBoot." & ModelVar & ".RELEASE.patch")
        Delete_File(dir & "\iboot.d")
        Delete_File(dir & "\iBoot." & ModelVar & ".RELEASE-iBooty.patch")
        Delete_File(dir & "\iboot.pwned")
        Delete_File(dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\iBoot." & ModelVar & ".RELEASE.img3.decrypted")
    End Sub
    Public Sub iBoot()



        Dim obj As Object
        obj = CreateObject("WScript.Shell")

        Shell("cmd /c taskkill /f /t /im iBooty.exe", AppWinStyle.Hide)



        'LLB patch to jump to ibec...


        SaveToDisk("iBoot." & ModelVar & ".RELEASE.patch", dir & "\iBoot." & ModelVar & ".RELEASE.patch")

        Rename_File(dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\iBoot." & ModelVar & ".RELEASE.img3", dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\iBoot." & ModelVar & ".RELEASE.orig")
        xpwntool(dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\iBoot." & ModelVar & ".RELEASE.img3.orig", dir & "\iboot.d", iBootkIV, iBootKey)
        MsgBox("dec")
        bspatch(dir & "\iboot.d", dir & "\iboot.pwned", dir & "\iBoot." & ModelVar & ".RELEASE.patch")
        MsgBox("patch")
        xpwntool_template(dir & "\iboot.pwned", dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\iBoot." & ModelVar & ".RELEASE.img3", dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\iBoot." & ModelVar & ".RELEASE.orig", iBootkIV, iBootKey)
        MsgBox("pwned")
        If iPhoneModel = "iPhone 3GS" Then
            Delete_File(dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\batteryfull.s5l8920x.img3")
            bspatch(dir & "\iboot.img3", dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\batteryfull.s5l8920x.img3", dir & "\iBoot." & ModelVar & ".RELEASE-iBooty.patch")
        ElseIf iPhoneModel = "iPhone 4" Or iPhoneModel = "iPod Touch 4" Then
            Delete_File(dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\batteryfull-640x960.s5l8930x.img3")
            bspatch(dir & "\iboot.img3", dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\batteryfull-640x960.s5l8930x.img3", dir & "\iBoot." & ModelVar & ".RELEASE-iBooty.patch")
        ElseIf iPhoneModel = "iPod Touch 3G" Then
            Delete_File(dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\batteryfull.s5l8922x.img3")
            bspatch(dir & "\iboot.img3", dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\batteryfull.s5l8922x.img3", dir & "\iBoot." & ModelVar & ".RELEASE-iBooty.patch")
        ElseIf iPhoneModel = "iPad" Then
            Delete_File(dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\batteryfull.s5l8930x.img3")
            bspatch(dir & "\iboot.img3", dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\batteryfull.s5l8930x.img3", dir & "\iBoot." & ModelVar & ".RELEASE-iBooty.patch")
        End If
        Delete_File(dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\iBoot." & ModelVar & ".RELEASE.img3.orig")
        Delete_File(dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\iBoot." & ModelVar & ".RELEASE.img3.patched")
        Delete_File(dir & "\iBoot." & ModelVar & ".RELEASE.patch")
        Delete_File(dir & "\iboot.d")
        Delete_File(dir & "\iboot.pwned")
        Delete_File(dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\iBoot." & ModelVar & ".RELEASE.img3.decrypted")
    End Sub
    Public Sub dfuipsw()    ' old method
        'My.Computer.FileSystem.RenameFile(dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\LLB." & ModelVar & ".RELEASE.img3", "LLB." & ModelVar & ".RELEASE.img3.old")
        'My.Computer.FileSystem.RenameFile(dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\applelogo@2x." & Kernel & ".img3", "LLB." & ModelVar & ".RELEASE.img3")
        ' System.IO.File.Delete(dir & "\IPSW\Firmware\all_flash\all_flash." & ModelVar & ".production\LLB." & ModelVar & ".RELEASE.img3.old")
        Delete_File(dir & "\IPSW\kernelcache.release.n81")
        SaveToDisk("bootkernel5.1.1.n81", dir & "\IPSW\kernelcache.release.n81")   ' sexy kernel <3
    End Sub
    Public Sub PatchServices()
        ' Exit Sub              
        '  hfsplus_extract(dir & "\IPSW\DECRYPTED.dmg", "/System/Library/Lockdown/Services.plist", dir & "\Services.plist.orig")
        hfsplus_mv(dir & "\IPSW\DECRYPTED.dmg", "/System/Library/Lockdown/Services.plist", "/System/Library/Lockdown/Services.plist.backup")
        'hfsplus_rm(dir & "\IPSW\DECRYPTED.dmg", "/System/Library/Lockdown/Services.plist")
        SaveToDisk("Services.plist", dir & "\Services.plist")
        ' bspatch(dir & "\Services.plist.orig", dir & "\Services.plist", dir & "\Services.patch")
        hfsplus_add(dir & "\IPSW\DECRYPTED.dmg", dir & "\Services.plist", "/System/Library/Lockdown/Services.plist")

    End Sub
    Public Sub PatchiBoot()
        ' not needed anymoar
       

            Call iBoot2()




    End Sub
    Public Sub PatchFSTAB()
        'hfsplus_grow(dir & "\IPSW\DECRYPTED.dmg", 1300000000)
        hfsplus_rm(dir & "\IPSW\DECRYPTED.dmg", "/etc/fstab")
        SaveToDisk("fstab", dir & "\fstab")
        ' hfsplus_extract(dir & "\IPSW\DECRYPTED.dmg", "/etc/fstab_orig", dir & "\fstab.orig")
        '    bspatch(dir & "\fstab.orig", dir & "\fstab.pwned", dir & "\fstab.patch")
        hfsplus_add(dir & "\IPSW\DECRYPTED.dmg", dir & "\fstab", "/etc/fstab")
    End Sub
    Public Sub ExtractIPSW()

        Using zip1 As Ionic.Zip.ZipFile = Ionic.Zip.ZipFile.Read(ipsw)

            zip1.ExtractAll(dir & "\IPSW\")
            zip1.Dispose()
        End Using
    End Sub

    Public Sub Rename_File(ByVal OriginalFilePath As String, ByVal NewFileNAME As String)
        cmdline = "cmd /c rename " & Quotation & OriginalFilePath & Quotation & " " & Quotation & NewFileNAME & Quotation
        ExecCmd(cmdline, True)
    End Sub
    Public Sub dmg_decrypt(ByVal EncryptedVolume As String, ByVal DecryptedVolumePath As String, ByVal vfdecryptKey As String)
        cmdline = quotation & dir & "\dmg.exe" & quotation & " extract " & quotation & EncryptedVolume & quotation & " " & quotation & DecryptedVolumePath & quotation & " -k " & vfdecryptKey
        ExecCmd(cmdline, True)
    End Sub
    Public Sub Delete_File(ByVal FilePath As String)
        cmdline = "cmd /c DEL " & Quotation & FilePath & Quotation
        ExecCmd(cmdline, True)
    End Sub
    Public Sub vfdecrypt(ByVal EncryptedVolume As String, ByVal DecryptedVolumePath As String, ByVal vfdecryptkey As String)
        cmdline = quotation & dir & "\vfdecrypt.exe" & quotation & " -i " & quotation & EncryptedVolume & quotation & " -k " & vfdecryptkey & " -o " & quotation & DecryptedVolumePath & quotation
        ExecCmd(cmdline, True)
    End Sub
    Public Sub vfdecrypt_rootfs()
        Rename_File(dir & "\IPSW\" & RootFS & ".dmg", RootFS & ".dmg.orig")

        vfdecrypt(dir & "\IPSW\" & RootFS & ".dmg.orig", dir & "\IPSW\" & RootFS & ".dmg", RootFSKey)

        Delete_File(dir & "\IPSW\" & RootFS & ".dmg.orig")
    End Sub
    Public Sub DecryptRoofFS()
        Rename_File(dir & "\IPSW\" & RootFS & ".dmg", RootFS & ".dmg.orig")

        dmg_decrypt(dir & "\IPSW\" & RootFS & ".dmg.orig", dir & "\IPSW\DECRYPTED.dmg", RootFSKey)

        Delete_File(dir & "\IPSW\" & RootFS & ".dmg.orig")
    End Sub
    Public Sub xpwntool_nokeys(ByVal infile As String, ByVal outfile As String)
        cmdline = quotation & dir & "\xpwntool.exe" & quotation & " " & quotation & infile & quotation & " " & quotation & outfile & quotation
        ExecCmd(cmdline, True)
    End Sub
    Public Sub DecryptRamdisk()
        Rename_File(dir & "\IPSW\" & Ramdisk & ".dmg", Ramdisk & ".dmg.orig")
        xpwntool(dir & "\IPSW\" & Ramdisk & ".dmg.orig", dir & "\IPSW\ramdisk_decrypted.dmg", RamdiskIV, RamdiskKey)
    End Sub
    Public Sub xpwntool_template(ByVal infile As String, ByVal outfile As String, ByVal Template As String, ByVal IVKey As String, ByVal Key As String)
        cmdline = quotation & dir & "\xpwntool.exe" & quotation & " " & quotation & infile & quotation & " " & quotation & outfile & quotation & " -t " & quotation & Template & quotation & " -iv " & IVKey & " -k " & Key
        ExecCmd(cmdline, True)
    End Sub
    Public Sub xpwntool_template_nokeys(ByVal infile As String, ByVal outfile As String, ByVal Template As String)
        cmdline = quotation & dir & "\xpwntool.exe" & quotation & " " & quotation & infile & quotation & " " & quotation & outfile & quotation & " -t " & quotation & Template & quotation
        ExecCmd(cmdline, True)
    End Sub
    Public Sub hfsplus_mkdir(ByVal Volume As String, ByVal DIRnameNpath As String)
        cmdline = quotation & dir & "\hfsplus.exe" & quotation & " " & quotation & Volume & quotation & " mkdir " & DIRnameNpath
        ExecCmd(cmdline, True)
    End Sub
    Public Sub hfsplus_symlink(ByVal Volume As String, ByVal PlaceofSymlink As String, ByVal Location2symlink As String)
        cmdline = quotation & dir & "\hfsplus.exe" & quotation & " " & quotation & Volume & quotation & " symlink " & PlaceofSymlink & " " & Location2symlink
        ExecCmd(cmdline, True)
    End Sub
    Public Sub Stash_Da_Shit()
        If ModelVar = "n92ap" Then
            'kjhgfds
            Exit Sub
        End If
        'Make Dirs
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/private/var/stash")

        'Move dirs
        hfsplus_mv(dir & "\IPSW\DECRYPTED.dmg", "/Applications", "/private/var/stash/Applications")
        hfsplus_mv(dir & "\IPSW\DECRYPTED.dmg", "/Library/Ringtones", "/private/var/stash/Ringtones")
        hfsplus_mv(dir & "\IPSW\DECRYPTED.dmg", "/Library/Wallpaper", "/private/var/stash/Wallpaper")
        ' hfsplus_mv(dir & "\IPSW\DECRYPTED.dmg", "/usr/bin", "/private/var/stash/bin")
        hfsplus_mv(dir & "\IPSW\DECRYPTED.dmg", "/usr/include", "/private/var/stash/include")
        hfsplus_mv(dir & "\IPSW\DECRYPTED.dmg", "/usr/libexec", "/private/var/stash/libexec")
        hfsplus_mv(dir & "\IPSW\DECRYPTED.dmg", "/usr/lib/pam", "/private/var/stash/pam")
        hfsplus_mv(dir & "\IPSW\DECRYPTED.dmg", "/usr/share", "/private/var/stash/share")

        'Making dem' symlinks...
        hfsplus_symlink(dir & "\IPSW\DECRYPTED.dmg", "/Applications", "/private/var/stash/Applications")
        hfsplus_symlink(dir & "\IPSW\DECRYPTED.dmg", "/Library/Ringtones", "/private/var/stash/Ringtones")
        hfsplus_symlink(dir & "\IPSW\DECRYPTED.dmg", "/Library/Wallpaper", "/private/var/stash/Wallpaper")
        'hfsplus_symlink(dir & "\IPSW\DECRYPTED.dmg", "/usr/bin", "/private/var/stash/bin")
        hfsplus_symlink(dir & "\IPSW\DECRYPTED.dmg", "/usr/include", "/private/var/stash/include")
        hfsplus_symlink(dir & "\IPSW\DECRYPTED.dmg", "/usr/lib/pam", "/private/var/stash/pam")
        hfsplus_symlink(dir & "\IPSW\DECRYPTED.dmg", "/usr/libexec", "/private/var/stash/libexec")
        hfsplus_symlink(dir & "\IPSW\DECRYPTED.dmg", "/usr/share", "/private/var/stash/share")
    End Sub
    Public Sub OTAbypass()
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/var/MobileSoftwareUpdate")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/var/MobileSoftwareUpdate/softwareupdate.132")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/var/MobileSoftwareUpdate/softwareupdate.132/Source")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/var/MobileSoftwareUpdate/softwareupdate.132/Source/boot")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/var/MobileSoftwareUpdate/softwareupdate.132/Source/payload")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/var/MobileSoftwareUpdate/softwareupdate.132/target")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/var/MobileSoftwareUpdate/softwareupdate.132/target/root")
        'My.Computer.Network.DownloadFile("ota.tar's db", dir & "\ota.tar", Nothing, Nothing, True, 5000, True)
        hfsplus_untar(dir & "\IPSW\DECRYPTED.dmg", "C:\Users\pad2g\Desktop\ota.tar")
        ' DO NOT STASH!!!!!!!!!!!!!

    End Sub
    Public Sub RebuildRamdisk()
        '  xpwntool_template(dir & "\IPSW\ramdisk_decrypted.dmg", dir & "\IPSW\" & Ramdisk & ".dmg", dir & "\IPSW\" & Ramdisk & ".dmg.orig", RamdiskIV, RamdiskKey)
        My.Computer.FileSystem.RenameFile(dir & "\IPSW\" & Ramdisk & ".dmg", Ramdisk & ".dmg.orig")

        '  xpwntool_template_nokeys(dir & "\IPSW\sn0wdec.dmg", dir & "\IPSW\" & Ramdisk & ".dmg", dir & "\IPSW\" & Ramdisk & ".dmg.orig")
        If iPhoneModel = "iPod Touch 4" Then
            xpwntool_template(dir & "\IPSW\sn0wdec.dmg", dir & "\IPSW\" & Ramdisk & ".dmg", dir & "\IPSW\" & Ramdisk & ".dmg.orig", RamdiskIV, RamdiskKey)
        ElseIf iPhoneModel = "iPhone 4" Then
            xpwntool_template(dir & "\IPSW\iPhone4ram.dmg", dir & "\IPSW\" & Ramdisk & ".dmg", dir & "\IPSW\" & Ramdisk & ".dmg.orig", RamdiskIV, RamdiskKey)
        End If
        Delete_File(dir & "\IPSW\" & Ramdisk & ".dmg.orig")
        Delete_File(dir & "\IPSW\iPhone4ram.dmg")
    End Sub
    Public Sub dmg_rebuild(ByVal DecryptedVolume As String, ByVal RebuiltVolumePath As String)
        cmdline = quotation & dir & "\dmg.exe" & quotation & " build " & quotation & DecryptedVolume & quotation & " " & quotation & RebuiltVolumePath & quotation
        ExecCmd(cmdline, True)
    End Sub
    Public Sub RebuildRootFS()
        dmg_rebuild(dir & "\IPSW\DECRYPTED.dmg", dir & "\IPSW\" & RootFS & ".dmg")

        Delete_File(dir & "\IPSW\DECRYPTED.dmg")
    End Sub
    Public Function File_Exists(ByVal strFile As String) As Boolean

        If strFile.Length <> 0 Then
            Dim oFile As New FileInfo(strFile)
            If oFile.Exists = True Then
                File_Exists = True
            Else
                File_Exists = False
            End If
        End If

    End Function
    Public Sub patchKernel()
        ' Rename_File(dir & "\IPSW\kernelcache." & "RELEASE." & Board, "kernelcache." & Board & ".orig")
        If iPhoneModel = "iPod Touch 4" Then
            'xpwntool(dir & "\IPSW\kernelcache." & Board & ".orig", dir & "\IPSW\kernelcache." & Board & ".decrypted", KernelCacheIV, KernelCacheKey)
            System.IO.File.Delete(dir & "\IPSW\kernelcache.release.n81")
            SaveToDisk("kernelcache.release.n81", dir & "\IPSW\kernelcache.release.n81")
        ElseIf iPhoneModel = "iPhone 4" Then
            System.IO.File.Delete(dir & "\IPSW\kernelcache.release.n90")
            SaveToDisk("iphonekernel", dir & "\IPSW\kernelcache.release.n90")
        End If
        'SaveToDisk("bootkernel5.1.1.n81", dir & "\IPSW\kernelcache.release.n81")
        ' bspatch(dir & "\IPSW\kernelcache." & Board & ".decrypted", dir & "\IPSW\kernelcache." & Board & ".patched", dir & "\" & Board & "." & build & ".patch")

        ' xpwntool_template(dir & "\IPSW\kernelcache." & Board & ".patched", dir & "\IPSW\kernelcache." & Board, dir & "\IPSW\kernelcache." & Board & ".orig", KernelCacheIV, KernelCacheKey)
        'Rename_File(dir & "\IPSW\kernelcache." & Board, dir & "\IPSW\kernelcache.RELEASE." & Board)
        'Delete_File(dir & "\IPSW\kernelcache." & Board & ".patched")
        'Delete_File(dir & "\IPSW\kernelcache." & Board & ".decrypted")
        'Delete_File(dir & "\IPSW\kernelcache." & Board & ".orig")
    End Sub
    Public Sub hfsplus_mv(ByVal Volume As String, ByVal File2Move As String, ByVal NewPath As String)
        cmdline = quotation & dir & "\hfsplus.exe" & quotation & " " & quotation & Volume & quotation & " mv " & File2Move & " " & NewPath
        ExecCmd(cmdline, True)
    End Sub
    Public Sub hfsplus_extract(ByVal Volume As String, ByVal File2ExtractNPath As String, ByVal LocalLocation As String)
        cmdline = quotation & dir & "\hfsplus.exe" & quotation & " " & quotation & Volume & quotation & " extract " & File2ExtractNPath & " " & quotation & LocalLocation & quotation
        ExecCmd(cmdline, True)
    End Sub
    Public Sub bspatch(ByVal oldfile As String, ByVal newfile As String, ByVal Patch As String)
        cmdline = quotation & dir & "\bspatch.exe" & quotation & " " & quotation & oldfile & quotation & " " & quotation & newfile & quotation & " " & quotation & Patch & quotation
        ExecCmd(cmdline, True)
    End Sub
    Public Sub hfsplus_add(ByVal Volume As String, ByVal File2Add As String, ByVal Path As String)
        cmdline = quotation & dir & "\hfsplus.exe" & quotation & " " & quotation & Volume & quotation & " add " & quotation & File2Add & quotation & " " & Path
        ExecCmd(cmdline, True)
    End Sub
    Public Sub saveramdisk()

        SaveToDisk("applelogox1.png", dir & "\applelogox1.png")
        SaveToDisk("applelogox2.png", dir & "\applelogox2.png")

        If iPhoneModel = "iPod Touch 4" Then
            SaveToDisk("sn0wdec.dmg", dir & "\IPSW\sn0wdec.dmg")

            hfsplus_rm(dir & "\IPSW\sn0wdec.dmg", "/usr/share/progressui/images-1x/applelogo.png")
            hfsplus_rm(dir & "\IPSW\sn0wdec.dmg", "/usr/share/progressui/images-2x/applelogo.png")
            hfsplus_add(dir & "\IPSW\sn0wdec.dmg", dir & "\applelogox1.png", "/usr/share/progressui/images-1x/applelogo.png")
            hfsplus_add(dir & "\IPSW\sn0wdec.dmg", dir & "\applelogox2.png", "/usr/share/progressui/images-2x/applelogo.png")
        ElseIf iPhoneModel = "iPhone 4" Then

            SaveToDisk("iPhone4ram.dmg", dir & "\IPSW\iPhone4ram.dmg")
            hfsplus_rm(dir & "\IPSW\iPhone4ram.dmg", "/usr/share/progressui/images-1x/applelogo.png")
            hfsplus_rm(dir & "\IPSW\iPhone4ram.dmg", "/usr/share/progressui/images-2x/applelogo.png")
            hfsplus_add(dir & "\IPSW\iPhone4ram.dmg", dir & "\applelogox1.png", "/usr/share/progressui/images-1x/applelogo.png")
            hfsplus_add(dir & "\IPSW\iPhone4ram.dmg", dir & "\applelogox2.png", "/usr/share/progressui/images-2x/applelogo.png")
            'to be continued...
        End If

    End Sub
    Public Sub hacktivate()
        SaveToDisk("lockdownd.patch", dir & "\lockdownd.patch")
        hfsplus_extract(dir & "\IPSW\DECRYPTED.dmg", "/usr/libexec/lockdownd", dir & "\lockdownd.orig")
        hfsplus_mv(dir & "\IPSW\DECRYPTED.dmg", "/usr/libexec/lockdownd", "/usr/libexec/lockdownd.orig")
        bspatch(dir & "\lockdownd.orig", dir & "\lockdownd", dir & "\lockdownd.patch")
        hfsplus_add(dir & "\IPSW\DECRYPTED.dmg", dir & "\lockdownd", "/usr/libexec/lockdownd")
        hfsplus_chmod(dir & "\IPSW\DECRYPTED.dmg", "/usr/libexec/lockdownd", "100755")
        Delete_File(dir & "\lockdownd.patch")
    End Sub
    Public Sub PatchSystemVersion()
        hfsplus_extract(dir & "\IPSW\DECRYPTED.dmg", "/System/Library/CoreServices/SystemVersion.plist", dir & "\SystemVersion.plist")
        ReplateText(dir & "\SystemVersion.plist", dir & "\SystemVersion.plist", "<string>Beta</string>", "")
        hfsplus_rm(dir & "\IPSW\DECRYPTED.dmg", "/System/Library/CoreServices/SystemVersion.plist")
        hfsplus_add(dir & "\IPSW\DECRYPTED.dmg", dir & "\SystemVersion.plist", "/System/Library/CoreServices/SystemVersion.plist")
        Delete_File(dir & "\SystemVersion.plist")

    End Sub
    Public Function File_Delete(ByVal strFilename As String, Optional ByRef strError As String = "") As Boolean

        If strFilename.Length <> 0 Then
            Try
                System.IO.File.Delete(strFilename)
                File_Delete = True
            Catch oExc As Exception
                strError = oExc.Message
                File_Delete = False
            End Try
        End If

    End Function
    Public Sub CreateIPSW()

        Dim obj As Object
        obj = CreateObject("WScript.Shell")
        If File_Exists(obj.SpecialFolders("desktop") & "\Redbr3eze_" & iPhoneModel & "-" & ipswrecognizeion & ".ipsw") = True Then
            File_Delete(obj.SpecialFolders("desktop") & "\Redbr3eze_" & iPhoneModel & "-" & ipswrecognizeion & ".ipsw")
        End If

        Using zip1 As Ionic.Zip.ZipFile = New Ionic.Zip.ZipFile
            zip1.AddDirectory(dir & "\ipsw\")
            zip1.Save(obj.SpecialFolders("desktop") & "\Redbr3eze_" & iPhoneModel & "-" & ipswrecognizeion & ".ipsw")
        End Using
    End Sub
    Private Function GenerateFileList(ByVal Dir As String) As ArrayList
        Dim fils As New ArrayList()
        Dim Empty As Boolean = True
        For Each file As String In Directory.GetFiles(Dir)
            fils.Add(file)
            Empty = False
        Next

        If Empty Then
            If Directory.GetDirectories(Dir).Length = 0 Then
                fils.Add(Dir)
            End If
        End If

        For Each dirs As String In Directory.GetDirectories(Dir)

            For Each obj As Object In GenerateFileList(dirs)
                fils.Add(obj)
            Next
        Next
        ' return file list
        Return fils
    End Function
    Public Sub Zip(ByVal inputFolderPath As String, ByVal outputPathAndFile As String, ByVal password As String)
        Dim ar As ArrayList = GenerateFileList(inputFolderPath)
        ' generate file list
        Dim TrimLength As Int32 = (Directory.GetParent(inputFolderPath)).ToString().Length
        ' find number of chars to remove // from orginal file path
        TrimLength += 1
        'remove '\'
        Dim ostream As FileStream
        Dim obuffer As Byte()
        Dim outPath As String = outputPathAndFile
        Dim oZipStream As New GZipOutputStream(File.Create(outPath))
        If password IsNot Nothing AndAlso password <> [String].Empty Then
            oZipStream.Password = password
        End If
        oZipStream.SetLevel(0)
        Dim oZipEntry As ICSharpCode.SharpZipLib.Zip.ZipEntry
        For Each Fil As String In ar
            oZipEntry = New ICSharpCode.SharpZipLib.Zip.ZipEntry(Fil.Remove(0, TrimLength))

            If Not Fil.EndsWith("/") Then
                ostream = File.OpenRead(Fil)
                obuffer = New Byte(ostream.Length - 1) {}
                ostream.Read(obuffer, 0, obuffer.Length)
                oZipStream.Write(obuffer, 0, obuffer.Length)
            End If
        Next
        oZipStream.Finish()
        oZipStream.Close()
    End Sub
    Public Sub addOptions()
        If iPhoneModel = "iPad" Then
            hfsplus_extract(dir & "\IPSW\DECRYPTED.dmg", "/Applications/Preferences.app/General.plist", dir & "\General.plist.orig")
            hfsplus_mv(dir & "\IPSW\DECRYPTED.dmg", "/Applications/Preferences.app/General.plist", "/Applications/Preferences.app/General_orig.plist")
            bspatch(dir & "\General.plist.orig", dir & "\General.plist", dir & "\General.patch")

            hfsplus_add(dir & "\IPSW\DECRYPTED.dmg", dir & "\General.plist", "/Applications/Preferences.app/General.plist")
            hfsplus_chmod(dir & "\IPSW\DECRYPTED.dmg", "/Applications/Preferences.app/General.plist", "100644")

            hfsplus_extract(dir & "\IPSW\DECRYPTED.dmg", "/System/Library/CoreServices/SpringBoard.app/K48AP.plist", dir & "\K48AP.plist.orig")
            hfsplus_mv(dir & "\IPSW\DECRYPTED.dmg", "/System/Library/CoreServices/SpringBoard.app/K48AP.plist", "/System/Library/CoreServices/SpringBoard.app/K48AP_orig.plist")
            bspatch(dir & "\K48AP.plist.orig", dir & "\K48AP.plist", dir & "\K48AP.patch")
            hfsplus_add(dir & "\IPSW\DECRYPTED.dmg", dir & "\K48AP.plist", "/System/Library/CoreServices/SpringBoard.app/K48AP.plist")
            hfsplus_chmod(dir & "\IPSW\DECRYPTED.dmg", "/System/Library/CoreServices/SpringBoard.app/K48AP.plist", "100644")

            Delete_File(dir & "\K48AP.plist.orig")
            Delete_File(dir & "\K48AP.plist")
        End If
        If iPhoneModel = "iPhone 3GS" Then
            hfsplus_extract(dir & "\IPSW\DECRYPTED.dmg", "/System/Library/CoreServices/SpringBoard.app/N88AP.plist", dir & "\N88AP.plist.orig")
            hfsplus_mv(dir & "\IPSW\DECRYPTED.dmg", "/System/Library/CoreServices/SpringBoard.app/N88AP.plist", "/System/Library/CoreServices/SpringBoard/N88AP_orig.plist")
            bspatch(dir & "\N88AP.plist.orig", dir & "\N88AP.plist.pwned", dir & "\N88AP.patch")

            'General.plist Patch
            hfsplus_extract(dir & "\IPSW\DECRYPTED.dmg", "/Applications/Preferences.app/General.plist", dir & "\General.plist.orig")
            hfsplus_mv(dir & "\IPSW\DECRYPTED.dmg", "/Applications/Preferences.app/General.plist", "/Applications/Preferences.app/General_orig.plist")
            bspatch(dir & "\General.plist.orig", dir & "\General.plist", dir & "\General.patch")

            hfsplus_add(dir & "\IPSW\DECRYPTED.dmg", dir & "\General.plist", "/Applications/Preferences.app/General.plist")
            hfsplus_add(dir & "\IPSW\DECRYPTED.dmg", dir & "\N88AP.plist.pwned", "/System/Library/CoreServices/SpringBoard.app/N88AP.plist")

            hfsplus_chmod(dir & "\IPSW\DECRYPTED.dmg", "/System/Library/CoreServices/SpringBoard.app/N88AP.plist", "100644")
            hfsplus_chmod(dir & "\IPSW\DECRYPTED.dmg", "/Applications/Preferences.app/General.plist", "100644")

            Delete_File(dir & "\N88AP.plist.orig")
            Delete_File(dir & "\N88AP.plist.pwned")
        End If
        If iPhoneModel = "iPhone 4" And ModelVar = "n90ap" Then
            'nah
            GoTo bye
            hfsplus_extract(dir & "\IPSW\DECRYPTED.dmg", "/System/Library/CoreServices/SpringBoard.app/N90AP.plist", dir & "\N90AP.plist.orig")
            hfsplus_mv(dir & "\IPSW\DECRYPTED.dmg", "/System/Library/CoreServices/SpringBoard.app/N90AP.plist", "/System/Library/CoreServices/SpringBoard/N90AP_orig.plist")
            bspatch(dir & "\N90AP.plist.orig", dir & "\N90AP.plist.pwned", dir & "\N90AP.patch")

            'General.plist Patch
            hfsplus_extract(dir & "\IPSW\DECRYPTED.dmg", "/Applications/Preferences.app/General.plist", dir & "\General.plist.orig")
            hfsplus_mv(dir & "\IPSW\DECRYPTED.dmg", "/Applications/Preferences.app/General.plist", "/Applications/Preferences.app/General_orig.plist")
            bspatch(dir & "\General.plist.orig", dir & "\General.plist", dir & "\General.patch")

            hfsplus_add(dir & "\IPSW\DECRYPTED.dmg", dir & "\General.plist", "/Applications/Preferences.app/General.plist")
            hfsplus_add(dir & "\IPSW\DECRYPTED.dmg", dir & "\N90AP.plist.pwned", "/System/Library/CoreServices/SpringBoard.app/N90AP.plist")

            hfsplus_chmod(dir & "\IPSW\DECRYPTED.dmg", "/System/Library/CoreServices/SpringBoard.app/N90AP.plist", "100644")
            hfsplus_chmod(dir & "\IPSW\DECRYPTED.dmg", "/Applications/Preferences.app/General.plist", "100644")

            Delete_File(dir & "\N90AP.plist.orig")
            Delete_File(dir & "\N90AP.plist.pwned")
        End If
bye:
        If iPhoneModel = "iPod Touch 3G" Then

            hfsplus_extract(dir & "\IPSW\DECRYPTED.dmg", "/Applications/Preferences.app/General.plist", dir & "\General.plist.orig")
            hfsplus_mv(dir & "\IPSW\DECRYPTED.dmg", "/Applications/Preferences.app/General.plist", "/Applications/Preferences.app/General_orig.plist")
            bspatch(dir & "\General.plist.orig", dir & "\General.plist", dir & "\General.patch")

            hfsplus_add(dir & "\IPSW\DECRYPTED.dmg", dir & "\General.plist", "/Applications/Preferences.app/General.plist")
            '   hfsplus_add(dir & "\IPSW\DECRYPTED.dmg", dir & "\N18AP.plist.pwned", "/System/Library/CoreServices/SpringBoard.app/N18AP.plist")

            ' hfsplus_chmod(dir & "\IPSW\DECRYPTED.dmg", "/System/Library/CoreServices/SpringBoard.app/N81AP.plist", "100644")
            hfsplus_chmod(dir & "\IPSW\DECRYPTED.dmg", "/Applications/Preferences.app/General.plist", "100644")

            ' Delete_File(dir & "\N18AP.plist.orig")
            'Delete_File(dir & "\N18AP.plist.pwned")

        End If
        If iPhoneModel = "iPod Touch 4" Then
            '  Battery(Percentage)
            hfsplus_rm(dir & "\IPSW\DECRYPTED.dmg", "/System/Library/CoreServices/SpringBoard.app/N81AP.plist")
            hfsplus_rm(dir & "\IPSW\DECRYPTED.dmg", "/Applications/Preferences.app/General.plist")
       
            'General.plist & n81ap Patch
            SaveToDisk("General.plist", dir & "\General.plist")
            '    bspatch(dir & "\General.plist.orig", dir & "\General.plist", dir & "\General.patch")
            SaveToDisk("N81AP.plist", dir & "\N81AP.plist")
            hfsplus_add(dir & "\IPSW\DECRYPTED.dmg", dir & "\N81AP.plist", "/System/Library/CoreServices/SpringBoard.app/N81AP.plist")
            hfsplus_add(dir & "\IPSW\DECRYPTED.dmg", dir & "\General.plist", "/Applications/Preferences.app/General.plist")

            hfsplus_chmod(dir & "\IPSW\DECRYPTED.dmg", "/System/Library/CoreServices/SpringBoard.app/N81AP.plist", "100644")
            hfsplus_chmod(dir & "\IPSW\DECRYPTED.dmg", "/Applications/Preferences.app/General.plist", "100644")


        End If
    End Sub
    Public Sub rmvexpiry()
        hfsplus_rm(dir & "\IPSW\DECRYPTED.dmg", "/usr/libexec/lockdownd")
    End Sub
    Private Sub mainsb_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Public Sub DragNDrop()
        If ListBox1.Items.Count = 1 Then
            ipsw = ""
            ipsw = ListBox1.Items.Item(0)
            PictureBox2.Visible = True

            Label2.Show()
            ListBox1.Items.Clear()
            BackgroundWorker1.RunWorkerAsync()
            GetIPSWVars()
        Else
            ListBox1.Items.Clear()
            MsgBox("Drag only one IPSW at a time!", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub dragtxt_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs)

        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim MyFiles() As String
            Dim i As Int32

            MyFiles = e.Data.GetData(DataFormats.FileDrop)
            For i = 0 To MyFiles.Length - 1
                ListBox1.Items.Add(MyFiles(i))
            Next
            Call DragNDrop()
        End If

    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dragtxt.ForeColor = Color.Silver
        dragtxt.BackColor = Color.Gray
        ListBox1.BackColor = Color.Gray
        Label3.ForeColor = Color.White
        Label2.ForeColor = Color.White
        ipswrecognize.ForeColor = Color.White
        Devicename.ForeColor = Color.White
        MenuStrip1.BackColor = Color.Black
        MenuStrip1.ForeColor = Color.White
        Me.BackColor = Color.Black
        Label1.ForeColor = Color.White
        Me.ListBox1.AllowDrop = True
        Me.dragtxt.AllowDrop = True
    End Sub


    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Public Sub hfsplus_rm(ByVal Volume As String, ByVal File2RemoveNpath As String)
        cmdline = quotation & dir & "\hfsplus.exe" & quotation & " " & quotation & Volume & quotation & " rm " & File2RemoveNpath
        ExecCmd(cmdline, True)
    End Sub
    Public Sub hfsplus_grow(ByVal Volume As String, ByVal SizeInBytes As String)
        cmdline = quotation & dir & "\hfsplus.exe" & quotation & " " & quotation & Volume & quotation & " grow " & SizeInBytes
        ExecCmd(cmdline, True)
    End Sub
    Public Sub hfsplus_chmod(ByVal Volume As String, ByVal File2Chmod As String, ByVal chmod As String)
        cmdline = quotation & dir & "\hfsplus.exe" & quotation & " " & quotation & Volume & quotation & " chmod " & chmod & " " & File2Chmod
        ExecCmd(cmdline, True)
    End Sub
    Public Sub ReplateText(ByVal inputPlist As String, ByVal outputPlist As String, ByVal whatToReplace As String, ByVal replaceWithThis As String)
        Dim fso, inputFile, outputFile
        Dim str As String

        fso = CreateObject("Scripting.FileSystemObject")


        inputFile = fso.OpenTextFile(inputPlist, 1)

        str = inputFile.ReadAll



        str = Replace(str, whatToReplace, replaceWithThis)

        outputFile = fso.CreateTextFile(outputPlist, True)

        outputFile.Write(str)
    End Sub
    Public Sub PatchRamdisk()
        hfsplus_grow(dir & "\IPSW\ramdisk_decrypted.dmg", "27500000")

        hfsplus_extract(dir & "\IPSW\ramdisk_decrypted.dmg", "/usr/sbin/asr", dir & "\asr.orig")
        hfsplus_mv(dir & "\IPSW\ramdisk_decrypted.dmg", "/usr/sbin/asr", "/usr/sbin/asr_orig")
        bspatch(dir & "\asr.orig", dir & "\asr", dir & "\asr.patch")
        hfsplus_add(dir & "\IPSW\ramdisk_decrypted.dmg", dir & "\asr", "/usr/sbin/asr")
        hfsplus_chmod(dir & "\IPSW\ramdisk_decrypted.dmg", "/usr/sbin/asr", "100755")


        'Sexiness -- START
        If iPhoneModel = "Apple TV 2" Then
            'Ignore meh...
        Else
            hfsplus_rm(dir & "\IPSW\ramdisk_decrypted.dmg", "/usr/share/progressui/images-1x/applelogo.png")
            hfsplus_rm(dir & "\IPSW\ramdisk_decrypted.dmg", "/usr/share/progressui/images-2x/applelogo.png")

            hfsplus_add(dir & "\IPSW\ramdisk_decrypted.dmg", dir & "\applelogox1.png", "/usr/share/progressui/images-1x/applelogo.png")
            hfsplus_add(dir & "\IPSW\ramdisk_decrypted.dmg", dir & "\applelogox2.png", "/usr/share/progressui/images-2x/applelogo.png")
        End If


        ReplateText(dir & "\options.plist", dir & "\options2.plist", "<--DO-I-FLASH-NOR1-->", "")
        ReplateText(dir & "\options2.plist", dir & "\options3.plist", "<--DO-I-FLASH-NOR2-->", "")


        ReplateText(dir & "\options3.plist", dir & "\options4.plist", "<integer>800</integer>", "<integer>" & PartitionSize & "</integer>")

       
            ReplateText(dir & "\options4.plist", dir & "\optionsCustom.plist", "<--DO-I-FLASH-BB-->", "<false/>")

        If iPhoneModel = "Apple TV 2" Then
            hfsplus_mv(dir & "\IPSW\ramdisk_decrypted.dmg", "/usr/local/share/restore/options.plist", "/usr/local/share/restore/options.plist.orig")
            hfsplus_mv(dir & "\IPSW\ramdisk_decrypted.dmg", "/usr/local/share/restore/options.k66.plist", "/usr/local/share/restore/options.k66.plist.orig")
            hfsplus_add(dir & "\IPSW\ramdisk_decrypted.dmg", dir & "\optionsCustom.plist", "/usr/local/share/restore/options.k66.plist")
        Else
            hfsplus_add(dir & "\IPSW\ramdisk_decrypted.dmg", dir & "\optionsCustom.plist", "/usr/local/share/restore/options.plist")
        End If
        Delete_File(dir & "\optionsCustom.plist")

    End Sub
    Public Sub cleanup()
        Delete_File(dir & "\hfsplus.exe")
        Delete_File(dir & "\xpwntool.exe")
        Delete_File(dir & "\dmg.exe")
        Delete_File(dir & "\bspatch.exe")
        Delete_File(dir & "\s-irecovery.exe")
        Delete_File(dir & "\applelogox2.png")
        Delete_File(dir & "\applelogox1.png")
        Delete_File(dir & "\payload5.1.1.zip")
        Delete_File(dir & "\Cydia.zip")
        Delete_File(dir & "\Cydia.tar")
        Delete_File(dir & "\" & ModelVar & ".plist")
        Delete_File(dir & "\fstab")
        Delete_File(dir & "\Ionic.Zip.dll")
        Delete_File(dir & "\ICSharpCode.SharpZipLib.dll")
        Delete_File(dir & "\Services.plist")
        Delete_File(dir & "\General.plist")
        Delete_File(dir & "\common.tar")
        Delete_File(dir & "\iPod4,1.tar")
        ExecCmd("del "& dir & "\debs\private\var\root\Media\Cydia\AutoInstall\package*")
    End Sub
    Private Function BuildFilter(ByVal strExtension As String) As String

        BuildFilter = ""

        If strExtension.PadLeft(1) <> "." Then
            BuildFilter = "(*." & strExtension & ")|" & "*." & strExtension
        ElseIf strExtension.PadLeft(1) = "." Then
            BuildFilter = "(*" & strExtension & ")|" & "*" & strExtension
        End If

    End Function
    Public Function FileOpenDialog2(ByVal strExtension As String, ByVal strInitDir As String) As String

        Dim oFileDialog As New System.Windows.Forms.OpenFileDialog()
        Dim strfilter As String = BuildFilter(strExtension)

        FileOpenDialog2 = ""

        With oFileDialog
            '   If Customoptions.cont3 <> 1 Then
            .Filter = "Debian Package (*.deb) |*.deb;"
            '  Else
            '      .Filter = "Debian Package (*.deb) |*.deb;"
            ' End If
            .DefaultExt = strExtension
            .InitialDirectory = strInitDir
            .ShowDialog()
            If Windows.Forms.DialogResult.OK Then
                FileOpenDialog2 = .FileName
            ElseIf Windows.Forms.DialogResult.Cancel Then
            End If
        End With

    End Function
    Public Function FileOpenDialog(ByVal strExtension As String, ByVal strInitDir As String) As String

        Dim oFileDialog As New System.Windows.Forms.OpenFileDialog()
        Dim strfilter As String = BuildFilter(strExtension)

        FileOpenDialog = ""

        With oFileDialog
            '   If Customoptions.cont3 <> 1 Then
            .Filter = "iPhone/iPod Software File (*.ipsw) |*.ipsw;"
            '  Else
            '      .Filter = "Debian Package (*.deb) |*.deb;"
            ' End If
            .DefaultExt = strExtension
            .InitialDirectory = strInitDir
            .ShowDialog()
            If Windows.Forms.DialogResult.OK Then
                FileOpenDialog = .FileName
            ElseIf Windows.Forms.DialogResult.Cancel Then
            End If
        End With

    End Function
    Public Sub xpwntool(ByVal infile As String, ByVal outfile As String, ByVal IVKey As String, ByVal Key As String)
        cmdline = quotation & dir & "\xpwntool.exe" & quotation & " " & quotation & infile & quotation & " " & quotation & outfile & quotation & " -iv " & IVKey & " -k " & Key
        ExecCmd(cmdline, True)
    End Sub
    Public Sub PatchiBEC()
        ' Rename_File(dir & "\IPSW\Firmware\dfu\iBEC." & ModelVar & ".RELEASE.dfu", "iBEC." & ModelVar & ".RELEASE.dfu.orig")

        ' xpwntool(dir & "\IPSW\Firmware\dfu\iBEC." & ModelVar & ".RELEASE.dfu.orig", dir & "\IPSW\Firmware\dfu\iBEC." & ModelVar & ".RELEASE.dfu.decrypted", iBSSIV, iBSSKey)
        If iPhoneModel = "iPod Touch 4" Then
            System.IO.File.Delete(dir & "\IPSW\Firmware\dfu\iBEC.n81ap.RELEASE.dfu")
            SaveToDisk("iBEC.n81ap.RELEASE.dfu", dir & "\IPSW\Firmware\dfu\iBEC.n81ap.RELEASE.dfu")
        ElseIf iPhoneModel = "iPhone 4" Then
            System.IO.File.Delete(dir & "\IPSW\Firmware\dfu\iBEC.n90ap.RELEASE.dfu")
            SaveToDisk("iphoneibec.dfu", dir & "\IPSW\Firmware\dfu\iBEC.n90ap.RELEASE.dfu")
            'to be continued...
        End If

        'bspatch(dir & "\IPSW\Firmware\dfu\iBEC." & ModelVar & ".RELEASE.dfu.decrypted", dir & "\IPSW\Firmware\dfu\iBEC." & ModelVar & ".RELEASE.dfu.patched", dir & "\iBEC." & ModelVar & ".RELEASE.patch")

        ' xpwntool_template(dir & "\IPSW\Firmware\dfu\iBEC." & ModelVar & ".RELEASE.dfu.patched", dir & "\IPSW\Firmware\dfu\iBEC." & ModelVar & ".RELEASE.dfu", dir & "\IPSW\Firmware\dfu\iBEC." & ModelVar & ".RELEASE.dfu.orig", iBECIV, iBECKey)

        ' Delete_File(dir & "\IPSW\Firmware\dfu\iBEC." & ModelVar & ".RELEASE.dfu.patched")
        ' Delete_File(dir & "\IPSW\Firmware\dfu\iBEC." & ModelVar & ".RELEASE.dfu.decrypted")
        'Delete_File(dir & "\IPSW\Firmware\dfu\iBEC." & ModelVar & ".RELEASE.dfu.orig")
    End Sub
    Public Sub awesmiDebStore()
        ' DEDPENDENCIES
        SaveToDisk("substrate.tar", dir & "\substrate.tar")
        SaveToDisk("apt-key.tar", dir & "\apt-key.tar")
        SaveToDisk("apt-lib.tar", dir & "\apt-lib.tar")
        SaveToDisk("apt-ssl.tar", dir & "\apt-ssl.tar")
        SaveToDisk("apt.tar", dir & "\apt.tar")
        SaveToDisk("corebin.tar", dir & "\corebin.tar")
        SaveToDisk("coreutils.tar", dir & "\coreutils.tar")
        SaveToDisk("erica.tar", dir & "\erica.tar")
        SaveToDisk("grep.tar", dir & "\grep.tar")
        SaveToDisk("ideb.tar", dir & "\ideb.tar")
        SaveToDisk("pref.tar", dir & "\pref.tar")
        SaveToDisk("sed.tar", dir & "\sed.tar")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/usr/include")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/usr/include/apt-pkg")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/usr/lib/apt")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/usr/lib/apt/methods")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/etc/profile.d")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/etc/apt")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/etc/apt/apt.conf.d")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/etc/apt/preferences.d")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/etc/apt/sources.list.d")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/etc/apt/trusted.gpg.d")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/Library/PreferenceLoader")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/Library/PreferenceLoader/Preferences")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/Library/MobileSubstrate")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/Library/Frameworks/")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/usr/lib/dpkg")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/Library/PreferenceBundles")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/Library/Frameworks/CydiaSubstrate.framework")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/var/cache")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/var/lib")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/var/lib/apt")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/var/lib/apt/list")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/var/lib/apt/list/partial")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/var/lib/apt/list/periodic")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/var/log")
        hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/var/log/apt")
        hfsplus_untar(dir & "\IPSW\DECRYPTED.dmg", dir & "\substrate.tar")
        hfsplus_untar(dir & "\IPSW\DECRYPTED.dmg", dir & "\apt-key.tar")
        hfsplus_untar(dir & "\IPSW\DECRYPTED.dmg", dir & "\apt-lib.tar")
        hfsplus_untar(dir & "\IPSW\DECRYPTED.dmg", dir & "\apt-ssl.tar")
        hfsplus_untar(dir & "\IPSW\DECRYPTED.dmg", dir & "\apt.tar")
        hfsplus_untar(dir & "\IPSW\DECRYPTED.dmg", dir & "\coreutils.tar")
        hfsplus_untar(dir & "\IPSW\DECRYPTED.dmg", dir & "\corebin.tar")
        hfsplus_untar(dir & "\IPSW\DECRYPTED.dmg", dir & "\erica.tar")
        hfsplus_untar(dir & "\IPSW\DECRYPTED.dmg", dir & "\grep.tar")
        hfsplus_untar(dir & "\IPSW\DECRYPTED.dmg", dir & "\pref.tar")
        hfsplus_untar(dir & "\IPSW\DECRYPTED.dmg", dir & "\sed.tar")
        hfsplus_untar(dir & "\IPSW\DECRYPTED.dmg", dir & "\ideb.tar")

        Delete_File(dir & "\substrate.tar")
        Delete_File(dir & "\apt-key.tar")
        Delete_File(dir & "\apt-lib.tar")
        Delete_File(dir & "\apt-ssl.tar")
        Delete_File(dir & "\apt-ssl.tar")
        Delete_File(dir & "\apt.tar")
        Delete_File(dir & "\corebin.tar")
        Delete_File(dir & "\coreutils.tar")
        Delete_File(dir & "\erica.tar")
        Delete_File(dir & "\grep.tar")
        Delete_File(dir & "\pref.tar")
        Delete_File(dir & "\sed.tar")
        Delete_File(dir & "\ideb.tar")

        ' SaveToDisk("apt_1-0-23_iphoneos-arm.deb", dir & "\apt_1-0-23_iphoneos-arm.deb")
        'hfsplus_add(dir & "\IPSW\DECRYPTED.dmg", dir & "\apt_1-0-23_iphoneos-arm.deb", "/var/root/Media/Cydia/AutoInstall/apt_1-0-23_iphoneos-arm.deb")
        'SaveToDisk("com.ericasadun.utilities_0.4.2_iphoneos-arm.deb", dir & "\com.ericasadun.utilities_0.4.2_iphoneos-arm.deb")
        ' hfsplus_add(dir & "\IPSW\DECRYPTED.dmg", dir & "\com.ericasadun.utilities_0.4.2_iphoneos-arm.deb", "/var/root/Media/Cydia/AutoInstall/com.ericasadun.utilities_0.4.2_iphoneos-arm.deb")
        'SaveToDisk("coreutils-bin_8.12-7_iphoneos-arm.deb", dir & "\coreutils-bin_8.12-7_iphoneos-arm.deb")
        'hfsplus_add(dir & "\IPSW\DECRYPTED.dmg", dir & "\coreutils-bin_8.12-7_iphoneos-arm.deb", "/var/root/Media/Cydia/AutoInstall/coreutils-bin_8.12-7_iphoneos-arm.deb")
        'SaveToDisk("coreutils_8.12-12_iphoneos-arm.deb", dir & "\coreutils_8.12-12_iphoneos-arm.deb")
        'hfsplus_add(dir & "\IPSW\DECRYPTED.dmg", dir & "\coreutils_8.12-12_iphoneos-arm.deb", "/var/root/Media/Cydia/AutoInstall/coreutils_8.12-12_iphoneos-arm.deb")
        ' SaveToDisk("grep_2.5.4-3_iphoneos-arm.deb", dir & "\grep_2.5.4-3_iphoneos-arm.deb")
        'fsplus_add(dir & "\IPSW\DECRYPTED.dmg", dir & "\grep_2.5.4-3_iphoneos-arm.deb", "/var/root/Media/Cydia/AutoInstall/grep_2.5.4-3_iphoneos-arm.deb")
        'SaveToDisk("mobilesubstrate_0.9.3998_iphoneos-arm.deb", dir & "\mobilesubstrate_0.9.3998_iphoneos-arm.deb")
        'hfsplus_add(dir & "\IPSW\DECRYPTED.dmg", dir & "\mobilesubstrate_0.9.3998_iphoneos-arm.deb", "/var/root/Media/Cydia/AutoInstall/mobilesubstrate_0.9.3998_iphoneos-arm.deb")
        'SaveToDisk("preferenceloader_2.0.4-1_iphoneos-arm.deb", dir & "\preferenceloader_2.0.4-1_iphoneos-arm.deb")
        'hfsplus_add(dir & "\IPSW\DECRYPTED.dmg", dir & "\preferenceloader_2.0.4-1_iphoneos-arm.deb", "/var/root/Media/Cydia/AutoInstall/preferenceloader_2.0.4-1_iphoneos-arm.deb")
        'SaveToDisk("sed_4.1.5-7_iphoneos-arm.deb", dir & "\sed_4.1.5-7_iphoneos-arm.deb")
        'hfsplus_add(dir & "\IPSW\DECRYPTED.dmg", dir & "\sed_4.1.5-7_iphoneos-arm.deb", "/var/root/Media/Cydia/AutoInstall/sed_4.1.5-7_iphoneos-arm.deb")
        'SaveToDisk("idebstore.deb", dir & "\idebstore.deb")
        'hfsplus_add(dir & "\IPSW\DECRYPTED.dmg", dir & "\idebstore.deb", "/var/root/Media/Cydia/AutoInstall/idebstore.deb")
        'Delete_File(dir & "\apt_1-0-23_iphoneos-arm.deb")
        'Delete_File(dir & "\com.ericasadun.utilities_0.4.2_iphoneos-arm.deb")
        'Delete_File(dir & "\coreutils-bin_8.12-7_iphoneos-arm.deb")
        'Delete_File(dir & "\coreutils_8.12-12_iphoneos-arm.deb")
        'Delete_File(dir & "\grep_2.5.4-3_iphoneos-arm.deb")
        'Delete_File(dir & "\mobilesubstrate_0.9.3998_iphoneos-arm.deb")
        'Delete_File(dir & "\preferenceloader_2.0.4-1_iphoneos-arm.deb")
        'Delete_File(dir & "\sed_4.1.5-7_iphoneos-arm.deb")
        'Delete_File(dir & "\idebstore.deb")
    End Sub
    Public Sub PatchiBSS()
        If iPhoneModel = "iPod Touch 4" Then
            System.IO.File.Delete(dir & "\IPSW\Firmware\dfu\iBSS.n81ap.RELEASE.dfu")
            SaveToDisk("iBSS.n81ap.RELEASE.dfu", dir & "\IPSW\Firmware\dfu\iBSS.n81ap.RELEASE.dfu")
        ElseIf iPhoneModel = "iPhone 4" Then
            System.IO.File.Delete(dir & "\IPSW\Firmware\dfu\iBSS.n90ap.RELEASE.dfu")
            SaveToDisk("iphoneibss.dfu", dir & "\IPSW\Firmware\dfu\iBSS.n90ap.RELEASE.dfu")
        End If

        ' don't have time for this shit
        '    Rename_File(dir & "\IPSW\Firmware\dfu\iBSS." & ModelVar & ".RELEASE.dfu", "iBSS." & ModelVar & ".RELEASE.dfu.orig")

        '  xpwntool(dir & "\IPSW\Firmware\dfu\iBSS." & ModelVar & ".RELEASE.dfu.orig", dir & "\IPSW\Firmware\dfu\iBSS." & ModelVar & ".RELEASE.dfu.decrypted", iBSSIV, iBSSKey)
        ' bspatch(dir & "\IPSW\Firmware\dfu\iBSS." & ModelVar & ".RELEASE.dfu.decrypted", dir & "\IPSW\Firmware\dfu\iBSS." & ModelVar & ".RELEASE.dfu.patched", dir & "\iBSS." & ModelVar & ".RELEASE.patch")
        ' MsgBox("patched")


        'xpwntool_template(dir & "\IPSW\Firmware\dfu\iBSS." & ModelVar & ".RELEASE.dfu.patched", dir & "\IPSW\Firmware\dfu\iBSS." & ModelVar & ".RELEASE.dfu", dir & "\IPSW\Firmware\dfu\iBSS." & ModelVar & ".RELEASE.dfu.orig", iBSSIV, iBSSKey)
        'Shell(dir & "\xpwntool.exe " & dir & "\IPSW\Firmware\dfu\iBSS." & ModelVar & ".RELEASE.dfu.patched " & dir & "\IPSW\Firmware\dfu\iBSS." & ModelVar & ".RELEASE.dfu -t " & dir & "\IPSW\Firmware\dfu\iBSS." & ModelVar & ".RELEASE.dfu.orig -iv " & iBSSIV & " -k " & iBSSKey)
        ' MsgBox("built")



        '  Delete_File(dir & "\IPSW\Firmware\dfu\iBSS." & ModelVar & ".RELEASE.dfu.patched")
        '   Delete_File(dir & "\IPSW\Firmware\dfu\iBSS." & ModelVar & ".RELEASE.dfu.decrypted")
        '  Delete_File(dir & "\IPSW\Firmware\dfu\iBSS." & ModelVar & ".RELEASE.dfu.orig")
    End Sub



    Public Sub DeleteUnrequiredFiles()

        Delete_File(dir & "\IPSW\" & Unwanted & ".dmg")
        Delete_File(dir & "\IPSW\sn0wdec.dmg")
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        cont = 1
        ' MsgBox("Select your iDevice version before continuing!", MsgBoxStyle.Exclamation)
        'Exit Sub


        Try
            ipsw = ""
            ipsw = FileOpenDialog("*.ipsw", "Desktop")
            If ipsw <> "" Then
                Label2.Show()

                BackgroundWorker1.RunWorkerAsync()
                GetIPSWVars()
            End If
        Catch Ex As Exception
            MsgBox(Err.Description)
        End Try

    End Sub
    Public cont2 As Int16
    Public Sub hfsplus_untar(ByVal Volume As String, ByVal Tar As String)
        cmdline = quotation & dir & "\hfsplus.exe" & quotation & " " & quotation & Volume & quotation & " untar " & quotation & Tar & quotation
        ExecCmd(cmdline, False)
    End Sub
    Public Function ConvertMegabytesToBytes(ByVal megabytes As Double) As Double
        FINALRESIZE = megabytes * 1048576
    End Function
    Dim b As String
    Public Sub untether()
        Delete_File(dir & "\iPod4,1.tar")
        Delete_File(dir & "\common.tar")
        ' OLD STUFF
        ' SaveToDisk("payload5.1.1.zip", dir & "\payload5.1.1.zip")
        ' Using zip1 As Ionic.Zip.ZipFile = Ionic.Zip.ZipFile.Read(dir & "\payload5.1.1.zip")
        'zip1.ExtractAll(dir & "\", True)
        ' zip1.Dispose()
        ' End Using
        'create dirs
        'hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/var/mobile/Media/jb-install")
        'hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/private/var/audit")
        'hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/private/var/audit/rocky-racoon")

        'If iPhoneModel = "iPod Touch 4" And ipswrecognizeion = "5.1.1" Then
        'add files
        'hfsplus_untar(dir & "\IPSW\DECRYPTED.dmg", dir & "\iPod4,1.tar")
        'hfsplus_untar(dir & "\IPSW\DECRYPTED.dmg", dir & "\common.tar")
        'done
        ' End If
        SaveToDisk("com.chronic-dev.greenpois0n.rocky-racoon_1.0-1_iphoneos-arm.deb", dir & "\com.chronic-dev.greenpois0n.rocky-racoon_1.0-1_iphoneos-arm.deb")
        hfsplus_add(dir & "\IPSW\DECRYPTED.dmg", dir & "\com.chronic-dev.greenpois0n.rocky-racoon_1.0-1_iphoneos-arm.deb", "/var/root/Media/Cydia/AutoInstall/com.chronic-dev.greenpois0n.rocky-racoon_1.0-1_iphoneos-arm.deb")
    End Sub
    Public Sub AddCydia()
        Delete_File(dir & "\Cydia.tar")
        Delete_File(dir & "\Cydia.zip")
        '  Delete_File(dir & "\Cydia_atv.zip")

        If iPhoneModel = "Apple TV 2" Then
            If File_Exists(dir & "\Cydia_atv.tar") = False Then
                SaveToDisk("Cydia_atv.zip", dir & "\Cydia_atv.zip")
                Using zip1 As Ionic.Zip.ZipFile = Ionic.Zip.ZipFile.Read(dir & "\Cydia_atv.zip")
                    zip1.ExtractAll(dir & "\", True)
                    zip1.Dispose()
                End Using
            End If
            hfsplus_untar(dir & "\IPSW\DECRYPTED.dmg", dir & "\Cydia.tar")
        Else
            ConvertMegabytesToBytes(PartitionSize)
            ' hfsplus_grow(dir & "\IPSW\DECRYPTED.dmg", FINALRESIZE)
            '
            If System.IO.File.Exists(dir & "\Cydia.tar") = False Then
                SaveToDisk("Cydia.zip", dir & "\Cydia.zip")
                Using zip1 As Ionic.Zip.ZipFile = Ionic.Zip.ZipFile.Read(dir & "\Cydia.zip")
                    zip1.ExtractAll(dir & "\", True)
                    zip1.Dispose()
                End Using

            End If
            hfsplus_untar(dir & "\IPSW\DECRYPTED.dmg", dir & "\Cydia.tar")
            hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/var/root/Media/Cydia")
            hfsplus_mkdir(dir & "\IPSW\DECRYPTED.dmg", "/var/root/Media/Cydia/AutoInstall")

        End If
    End Sub
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.Hide()
        Form1.Show()
    End Sub


    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        If cont2 = 1 Then
            ebuilding2.Show()
        Else
            MsgBox("Select a valid IPSW!", MsgBoxStyle.Exclamation)
        End If
        If cont2 <> 1 Then
            MsgBox("Wait for IPSW to be recognized!", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub PictureBox3_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseEnter
        PictureBox3.Image = My.Resources.redbreeze
    End Sub
    Private Sub PictureBox3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseLeave
        PictureBox3.Image = My.Resources.Flake
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionsToolStripMenuItem.Click
        CustomOptions.Show()

    End Sub
    Public Sub sshinstaller()
        SaveToDisk("openssh.deb", dir & "\debsCustom\openssh.deb")
        hfsplus_add(dir & "\IPSW\DECRYPTED.dmg", dir & "\debsCustom\openssh.deb", "/var/root/Media/Cydia/AutoInstall/openssh.deb")
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        ipswhash = getFilesMD5Hash(ipsw)
        get_md5_RunWorkerCompleted()
        PictureBox2.Enabled = True
        cont2 = 1
    End Sub

    Private Sub IPSWDownloaderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IPSWDownloaderToolStripMenuItem.Click
        Process.Start("http://www.felixbruns.de/iPod/firmware/")
    End Sub

    Private Sub ListBox1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListBox1.DragDrop
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            Dim MyFiles() As String
            Dim i As Int32
            MyFiles = e.Data.GetData(DataFormats.FileDrop)
            For i = 0 To MyFiles.Length - 1
                ListBox1.Items.Add(MyFiles(i))
            Next
            Call DragNDrop()
        End If
    End Sub

    Private Sub ListBox1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles ListBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.All
        End If
    End Sub

  
    Private Sub RestoreErrorsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestoreErrorsToolStripMenuItem.Click
        Process.Start("http://theiphonewiki.com/wiki/index.php?title=ITunes_Errors")
    End Sub

    
   
  
End Class
