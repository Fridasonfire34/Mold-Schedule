Imports System.Data.SqlClient

Public Class Form1

    Private Sub Btn_Molds_Click(sender As Object, e As EventArgs) Handles Btn_Molds.Click
        Me.Hide()
        Dim MSGM As New MSGBOX_Molds(Me)
        MSGM.ShowDialog()
    End Sub

    Private Sub Btn_New_Job_Click(sender As Object, e As EventArgs) Handles Btn_New_Job.Click
        Me.Hide()
        Dim newJob As New New_Job()
        newJob.ShowDialog()
        Me.Show()
        Me.Close()
    End Sub

    Private Sub Btn_Jobs_Click(sender As Object, e As EventArgs) Handles Btn_Jobs.Click
        Me.Hide()
        Dim JobsForm As New Jobs()
        JobsForm.ShowDialog()
        Me.Show()
        Me.Close()
    End Sub

End Class
