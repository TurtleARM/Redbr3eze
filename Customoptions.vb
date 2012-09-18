Public Class Customoptions
    Public iwantzdfu As Boolean = False
    Public iwantzssh As Boolean = False
    Public justpreservebb As Boolean = False
    Public cont4 As Int16 = 0
    Public removeexpiry As Boolean = False
    Public fuckota As Boolean = False
    Public unlock As Boolean = False
    Public add_deb As Boolean = False
    Public no_untether As Boolean = False
    Public nocydia As Boolean = False
    Public activate As Boolean = False
    Public idebstore As Boolean = False
    Public deb As String
    Public cont3 As Int16 = 0
    Private Sub Customoptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckBox6.ForeColor = Color.White()
        Label1.ForeColor = Color.White()
        Button1.Visible = False
        Me.BackColor = Color.Black
        CheckBox1.ForeColor = Color.White
        CheckBox2.ForeColor = Color.White
        CheckBox3.ForeColor = Color.White
        CheckBox4.ForeColor = Color.White
        GroupBox1.ForeColor = Color.White
        If mainsb.iPhoneModel <> "iPhone 4" Then
            CheckBox3.Enabled = False
            CheckBox3.Visible = False
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If CheckBox4.Checked = True Then
            Button1.Show()
        End If
       
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        If CheckBox9.Checked = True Then
            no_untether = True
        End If
        If CheckBox1.Checked = True Then
            iwantzssh = True
        End If
        If CheckBox2.Checked = True Then
            justpreservebb = True
        End If
        If CheckBox3.Checked = True Then
            unlock = True
        End If
        If CheckBox5.Checked = True Then
            iwantzdfu = True
        End If
        If CheckBox6.Checked = True Then
            removeexpiry = True
        End If
        If CheckBox7.Checked = True Then
            activate = True
        End If
        If CheckBox8.Checked = True Then
            nocydia = True
        End If
       
        If CheckBox10.Checked = True Then
            idebstore = True
        End If
        If CheckBox11.Checked = True Then
            fuckota = True
        End If
        Me.Hide()
        mainsb.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cont3 = 1
        cont4 += 1
        Try
            deb = ""
            deb = mainsb.FileOpenDialog("*.deb", "Desktop")
            add_deb = True
        Catch Ex As Exception
            MsgBox(Err.Description)
        End Try
        My.Computer.FileSystem.CopyFile(deb, mainsb.dir & "\debs\private\var\root\Media\Cydia\AutoInstall\package" & cont4 & ".deb")
    End Sub

  
    Private Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            PictureBox2.Show()
            iwantzssh = True
        Else
            PictureBox2.Hide()
        End If

    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            PictureBox3.Show()
            justpreservebb = True
        Else
            PictureBox3.Hide()
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            PictureBox4.Show()
            unlock = True
        Else
            PictureBox4.Hide()
        End If
    End Sub

    Private Sub CheckBox5_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox5.CheckedChanged
        If CheckBox5.Checked = True Then
            iwantzdfu = True
            PictureBox5.Show()
        Else
            PictureBox5.Hide()
        End If
    End Sub


    Private Sub CheckBox7_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox7.CheckedChanged
        If CheckBox7.Checked = True Then
            activate = True
            PictureBox6.Show()
        Else
            PictureBox6.Hide()
        End If
    End Sub

    Private Sub CheckBox6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox6.CheckedChanged
        If CheckBox6.Checked = True Then
            removeexpiry = True
            PictureBox7.Show()
        Else
            PictureBox7.Hide()
        End If
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub CheckBox8_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox8.CheckedChanged
        If CheckBox8.Checked = True Then
            PictureBox8.Show()
        Else
            PictureBox8.Hide()
        End If
    End Sub

   
    Private Sub CheckBox10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox10.CheckedChanged
        If CheckBox10.Checked = True Then
            PictureBox10.Show()
        Else
            PictureBox10.Hide()
        End If
    End Sub

    Private Sub CheckBox9_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox9.CheckedChanged
        If CheckBox9.Checked = True Then
            PictureBox9.Show()
        Else
            PictureBox9.Hide()
        End If
    End Sub

 
    Private Sub CheckBox11_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox11.CheckedChanged
        If CheckBox11.Checked = True Then
            PictureBox11.Show()
        Else
            PictureBox11.Hide()
        End If
    End Sub
End Class