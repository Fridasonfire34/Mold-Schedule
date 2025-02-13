Public Class MSGBOX_Molds
    Private form1 As Form1
    Public Sub New(form As Form1)
        InitializeComponent()
        form1 = form
    End Sub
    Private Sub Btn_Walls_Click(sender As Object, e As EventArgs) Handles Btn_Walls.Click
        Me.Hide()
        Dim Walls As New Mold_Walls()
        Walls.ShowDialog()
        Me.Show()
        Me.Close()
        form1.Close()
    End Sub
    Private Sub Btn_Corners_Click(sender As Object, e As EventArgs) Handles Btn_Corners.Click
        Me.Hide()
        Dim Corners As New Molds_Corners()
        Corners.ShowDialog()
        Me.Show()
        Me.Close()
        Form1.Close()
    End Sub
    Private Sub Btn_TG_Click(sender As Object, e As EventArgs) Handles Btn_TG.Click
        Me.Hide()
        Dim TGS As New TGMold()
        TGS.ShowDialog()
        Me.Show()
        Me.Close()
        Form1.Close()
    End Sub
    Private Sub Btn_FC_Click(sender As Object, e As EventArgs) Handles Btn_FC.Click
        Me.Hide()
        Dim FCM As New FCMold()
        FCM.ShowDialog()
        Me.Show()
        Me.Close()
        Form1.Close()
    End Sub
    Private Sub Btn_Guillotine_Click(sender As Object, e As EventArgs) Handles Btn_Guillotine.Click
        Me.Hide()
        Dim GM As New GuillotineM()
        GM.ShowDialog()
        Me.Show()
        Me.Close()
        Form1.Close()
    End Sub
    Private Sub Btn_Tee_Click(sender As Object, e As EventArgs) Handles Btn_Tee.Click
        Me.Hide()
        Dim TeeM As New FCTMold
        TeeM.ShowDialog()
        Me.Show()
        Me.Close()
        Form1.Close()
    End Sub

    Private Sub Btn_FCTM_Click(sender As Object, e As EventArgs) Handles Btn_FCTM.Click
        Me.Hide()
        Dim FCTM As New FCT_Mold()
        FCTM.ShowDialog()
        Me.Show()
        Form1.Close()
    End Sub
End Class