Imports System.Net
Imports System.Net.Mail
Public Class report
    Public Sub sendmail()
        Dim mail As New MailMessage()
        mail = New MailMessage
        mail.From = New MailAddress("Anonymous@report.com")
        mail.To.Add("pad2g.vb@gmail.com")
        mail.Body = TextBox1.Text
        mail.Priority = MailPriority.High
        mail.Subject = "Redbr3eze"
        Try
            Dim smtp As New SmtpClient("out.alice.it")
            smtp.Send(mail)
        Catch ex As Exception
            Try
                Dim smtp As New SmtpClient("smtp.gmail.com")
                smtp.Send(mail)
            Catch ex2 As Exception
                Try
                    Dim smtp As New SmtpClient("mail.libero.it")
                    smtp.Send(mail)
                Catch ex3 As Exception
                    Try
                        Dim smtp As New SmtpClient("smtp.live.com")
                        smtp.Send(mail)
                    Catch ex4 As Exception
                        Try
                            Dim smtp As New SmtpClient("smtp.live.com")
                            smtp.Send(mail)
                        Catch ex5 As Exception
                            Try
                                Dim smtp As New SmtpClient("smtp.fastwebnet.it")
                                smtp.Send(mail)
                            Catch ex6 As Exception
                                ' shit meh
                            End Try
                        End Try
                    End Try
                End Try
            End Try
        End Try
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" Then
            sendmail()
            MsgBox("Mail sent! We'll fix your issue ASAP", MsgBoxStyle.Information, "Thanks")
        Else
            MsgBox("Write something in the email field!", MsgBoxStyle.Exclamation)
        End If
    End Sub
End Class