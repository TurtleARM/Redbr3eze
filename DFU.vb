Imports System.Management

Public Class DFU
    Dim time As Int32 = 6
    Dim time2 As Int32 = 10
    Dim time3 As Int32 = 15

    Private Sub DFU_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        System.IO.File.Delete(mainsb.dir & "\DFU.True")
    End Sub
    Private Sub DFU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = "Make sure your iDevice is both off and plugged in to the computer." & vbCrLf & "If it's not off:" & vbCrLf & "Hold power button until 'Slde to power off' appears" & vbCrLf & "and then slide to power off."


    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        time -= 1
        Label6.Text = time
        If time = 0 Then
            Label6.Hide()
            Label2.Enabled = False
            Timer2.Start()
            Timer1.Stop()
            Label3.Enabled = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Label5.Text = "Error, try again." Then
            Application.Restart()
            
        End If
        Label2.Show()
        Label3.Show()
        Label4.Show()
        Label1.Hide()
        Label2.Enabled = True
        Timer1.Start()
        Label5.Show()
        Button1.Hide()
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        time2 -= 1
        Label7.Text = time2
        If time2 = 0 Then
            Label7.Hide()
            Label3.Enabled = False
            Timer3.Start()
            BackgroundWorker1.RunWorkerAsync()
            Timer2.Stop()
            Label4.Enabled = True
        End If
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        time3 -= 1
        Label8.Text = time3
        If time3 = 0 Then
            Label8.Hide()
            Label4.Enabled = False
            Timer3.Stop()
            If File_Exists(mainsb.dir & "\DFU.True") Then
                Label5.Enabled = True
                Threading.Thread.Sleep(2500)
                Me.Dispose()
            Else
                Label5.Enabled = True
                Label5.Text = "Error, try again."
                Button1.Text = "Close"
                Button1.Show()
            End If
        End If
    End Sub
    Private Sub check4dfu()
        CheckForIllegalCrossThreadCalls = False
        Label1.Text = "Waiting for DFU..."
        Do Until File_Exists(mainsb.dir & "\DFU.True")
            'Searching for DFU...
            console.Text = " "
            Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT * FROM Win32_PnPEntity WHERE Description = 'Apple Recovery (DFU) USB Driver'")
            For Each queryObj As ManagementObject In searcher.Get()

                console.Text += (queryObj("Description"))
            Next
            If console.Text.Contains("DFU") Then
                SaveToDisk("sn0w.img3", mainsb.dir & "\DFU.True")
            End If
        Loop
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        check4dfu()
    End Sub
End Class