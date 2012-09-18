Public Class sn0wbreezy

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        redboot.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Hide()
        mainsb.Show()
    End Sub

    Private Sub sn0wbreezy_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub sn0wbreezy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub
End Class