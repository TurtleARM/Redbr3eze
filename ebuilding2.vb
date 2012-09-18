Imports System.Threading
Public Class ebuilding2
    Public stopdashit As Boolean = False
    Public Sub checkcancel()

        Label1.Text = "Cancelling..."
        ProgressBar1.Value = 0
        System.IO.Directory.Delete(mainsb.dir & "\IPSW\", FileIO.DeleteDirectoryOption.DeleteAllContents)
        System.IO.Directory.CreateDirectory(mainsb.dir & "\IPSW\")
        Application.Restart()
        Label1.Text = ""

    End Sub


    Public Sub savedll()
        SaveToDisk("libpng12.dll", mainsb.dir & "\libpng12.dll")
        SaveToDisk("libeay32.dll", mainsb.dir & "\libeay32.dll")
        SaveToDisk("libssl32.dll", mainsb.dir & "\libssl32.dll")
        SaveToDisk("cygcrypto-0.9.8.dll", mainsb.dir & "\cygcrypto-0.9.8.dll")
        SaveToDisk("cygwin1.dll", mainsb.dir & "\cygwin1.dll")

    End Sub
    Public Sub cleandll()
        File_Delete(mainsb.dir & "\libpng12.dll")
        File_Delete(mainsb.dir & "\libeay32.dll")
        File_Delete(mainsb.dir & "\libssl32.dll")
        File_Delete(mainsb.dir & "\cygcrypto-0.9.8.dll")
        File_Delete(mainsb.dir & "\cygwin1.dll")
    End Sub

    Public Sub ready2go()

        savedll()
        Label1.Text = "Getting data..."
        SaveToDisk("s-irecovery.exe", mainsb.dir & "\s-irecovery.exe")
        SaveToDisk("xpwntool.exe", mainsb.dir & "\xpwntool.exe")
        SaveToDisk("hfsplus.exe", mainsb.dir & "\hfsplus.exe")
        SaveToDisk("dmg.exe", mainsb.dir & "\dmg.exe")
        SaveToDisk("bspatch.exe", mainsb.dir & "\bspatch.exe")

        Call mainsb.GetIPSWVars()
        Label1.Text = "Extracting IPSW..."
        Call mainsb.ExtractIPSW()
        If stopdashit = True Then
            checkcancel()
        End If
        ProgressBar1.Value = 30

        If Customoptions.iwantzdfu = True Then
            ProgressBar1.Value = 70
            Label1.Text = "Patching files..."
            mainsb.dfuipsw()
            ProgressBar1.Value = 80
            Label1.Text = "Creating IPSW..."

            Call mainsb.CreateIPSW()
            ProgressBar1.Value = 100

            MsgBox("Done! Click the next arrow to enter pwned DFU mode.", MsgBoxStyle.Information)

            Label1.Text = ""
            Timer1.Stop()
            Button1.Enabled = True
            Button2.Enabled = False
            PictureBox2.Enabled = True
            Exit Sub
        End If

        Label1.Text = "Decrypting ramdisk..."
        ' mainsb.DecryptRamdisk()
        ' ProgressBar1.Value = 40
        If stopdashit = True Then
            checkcancel()
            Exit Sub
        End If

        Label1.Text = "Patching ramdisk..."
        'mainsb.PatchRamdisk()
        mainsb.saveramdisk()
        ProgressBar1.Value = 40
        If stopdashit = True Then
            checkcancel()
            Exit Sub
        End If


        Label1.Text = "Decrypting RootFS..."
        mainsb.DecryptRoofFS()


        ProgressBar1.Value = 55
        If stopdashit = True Then
            checkcancel()
            Exit Sub
        End If



        If Customoptions.add_deb = True Then

            mainsb.hfsplus_add(mainsb.dir & "\IPSW\DECRYPTED.dmg", mainsb.dir & "\debs\private\var\root\Media\Cydia\AutoInstall\package" & Customoptions.cont4 & ".deb", "/var/root/Media/Cydia/AutoInstall/" & Customoptions.cont4 & ".deb")

        End If
        ProgressBar1.Value = 65
        If stopdashit = True Then
            checkcancel()
            Exit Sub
        End If
        If Customoptions.justpreservebb = True Then
            Label1.Text = "Patching Services..."
            mainsb.PatchServices()
            If stopdashit = True Then
                checkcancel()
                Exit Sub
            End If
            Label1.Text = "Deleting unrequired files..."
            mainsb.DeleteUnrequiredFiles()
            Label1.Text = "Rebuilding RootFS..."
            mainsb.RebuildRootFS()
            If stopdashit = True Then
                checkcancel()
                Exit Sub
            End If

            ProgressBar1.Value = 75
            Label1.Text = "Rebuilding ramdisk..."
            mainsb.saveramdisk()

            Label1.Text = "Deleting unrequired files..."
            mainsb.DeleteUnrequiredFiles()

            ProgressBar1.Value = 90
            If stopdashit = True Then
                checkcancel()
                Exit Sub
            End If
            Label1.Text = "Creating IPSW..."
            'ending
            Call mainsb.CreateIPSW()
            ProgressBar1.Value = 100

            MsgBox("Done! Click the next arrow to enter pwned DFU mode.", MsgBoxStyle.Information)

            Label1.Text = ""
            Timer1.Stop()
            Button1.Enabled = True
            Button2.Enabled = False
            PictureBox2.Enabled = True
            cleandll()
            Exit Sub
        End If


        ProgressBar1.Value = 76
        ' fuck this shit
        mainsb.hfsplus_grow(mainsb.dir & "\IPSW\DECRYPTED.dmg", 1360000000)

        If Customoptions.nocydia = False Then
            Label1.Text = "Adding Cydia..."
            Call mainsb.AddCydia()
        End If
        If stopdashit = True Then
            checkcancel()
            Exit Sub
        End If
        If Customoptions.idebstore = True Then
            Label1.Text = "Adding iDebStore..."
            Call mainsb.awesmiDebStore()
        End If
        If Customoptions.fuckota = True Then
            Label1.Text = "Adding OTA filez (may take a bit)"
            Call mainsb.OTAbypass()
        End If

        If Customoptions.no_untether = False Then
            Label1.Text = "Adding Pod2G's gift..."
            Call mainsb.untether()
        End If

        If Customoptions.activate = True Then
            Label1.Text = "Patching IPSW..."
            Call mainsb.PatchSystemVersion()
        End If
        If Customoptions.activate = True Then
            Label1.Text = "Hacktivating..."
            Call mainsb.hacktivate()
        End If

        If stopdashit = True Then
            checkcancel()
            Exit Sub
        End If
        Label1.Text = "Patching FSTAB..."
        mainsb.PatchFSTAB()
        If stopdashit = True Then
            checkcancel()
            Exit Sub
        End If
        Label1.Text = "Patching Services..."
        mainsb.PatchServices()

        ' if to be checked !!
        Label1.Text = "Adding Custom Options..."
        mainsb.addOptions()
        ProgressBar1.Value = 78
        If stopdashit = True Then
            checkcancel()
            Exit Sub
        End If
        If Customoptions.iwantzssh = True Then
            Label1.Text = "Installing SSH..."
            Call mainsb.sshinstaller()
        End If

        ProgressBar1.Value = 79
        'Label1.Text = "Patching iBoot..."
        ' mainsb.PatchiBoot()

        If Customoptions.removeexpiry = True Then
            Label1.Text = "Removing expiry date..."
            Call mainsb.rmvexpiry()
        End If

        Label1.Text = "Patching iBSS..."
        Call mainsb.PatchiBSS()

        Label1.Text = "Patching iBEC..."
        Call mainsb.PatchiBEC()
        If stopdashit = True Then
            checkcancel()
            Exit Sub
        End If
        Label1.Text = "Patching iBoot..."
        '  Call mainsb.iBoot2()
        If stopdashit = True Then
            checkcancel()
            Exit Sub
        End If
        Label1.Text = "Patching Kernel..."
        Call mainsb.patchKernel()
        ProgressBar1.Value = 80


        Label1.Text = "Stashing..."
        Call mainsb.Stash_Da_Shit()
        ProgressBar1.Value = 83
        If stopdashit = True Then
            checkcancel()
            Exit Sub
        End If
        Label1.Text = "Rebuilding RootFS..."
        Call mainsb.RebuildRootFS()
        ProgressBar1.Value = 85

        Label1.Text = "Rebuilding ramdisk..."
        Call mainsb.RebuildRamdisk()
        ProgressBar1.Value = 90
        If stopdashit = True Then
            checkcancel()
            Exit Sub
        End If

        Label1.Text = "Deleting unrequired files..."
        Call mainsb.DeleteUnrequiredFiles()
        If stopdashit = True Then
            checkcancel()
            Exit Sub
        End If
        Label1.Text = "Creating IPSW..."
        'ending
        Call mainsb.CreateIPSW()
        Label1.Text = "Cleaning up..."
        Call mainsb.cleanup()
        cleandll()
        ProgressBar1.Value = 100

        MsgBox("Done! Click the next arrow to enter pwned DFU mode.", MsgBoxStyle.Information)

        Label1.Text = ""
        Timer1.Stop()
        Button1.Enabled = True
        Button2.Enabled = False
        PictureBox2.Enabled = True


    End Sub



    Private Sub ebuilding_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Button2.Enabled = True
        PictureBox3.Image = My.Resources.Flake
        Me.BackColor = Color.Black
        Label1.ForeColor = Color.White
        Label2.ForeColor = Color.White
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Button1.Enabled = False
        Timer1.Enabled = True

        Label2.Show()
        If System.IO.File.Exists(mainsb.dir & "\IPSW\" & "BuildManifest.plist") Then
            Label1.Text = "Deleting \IPSW\ content..."
            Try
                My.Computer.FileSystem.DeleteDirectory(mainsb.dir & "\IPSW\", FileIO.DeleteDirectoryOption.DeleteAllContents)
            Catch ex As Exception
                System.IO.Directory.Delete(mainsb.dir & "\IPSW\", FileIO.DeleteDirectoryOption.DeleteAllContents)
                System.IO.Directory.CreateDirectory(mainsb.dir & "\IPSW\")
            End Try
            'System.IO.Directory.Delete(mainsb.dir & "\IPSW\Firmware")

            ready2go()



        Else

            ' ThreadPool.QueueUserWorkItem(AddressOf ready2go)
            ready2go()

        End If
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label2.Text += "."
        If Label2.Text = "Building IPSW...." Then
            Label2.Text = "Building IPSW"
        End If
    End Sub




    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        Me.Hide()
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        dfupwner.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox3_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseEnter
        PictureBox3.Image = My.Resources.redbreeze
    End Sub

    Private Sub PictureBox3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.MouseLeave
        PictureBox3.Image = My.Resources.Flake
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Label1.Text = "Cancelling..."
        stopdashit = True

    End Sub
    Dim b As String





    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://www.idebstore.com/")
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        mainsb.GetIPSWVars()
        mainsb.RebuildRamdisk()
    End Sub

    Private Sub ebuilding2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label2.ForeColor = Color.White
    End Sub

End Class
