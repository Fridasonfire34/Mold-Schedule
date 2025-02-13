Public Class PanelsQty
    Public Property PanelsQuantity As Integer
    Public Property SelectedQty As Integer
    Private Sub PanelsQty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Al cargar el formulario, mostrar el valor de Qty en el TextBox
        Txt_Panels_Qty.Text = PanelsQuantity.ToString()
    End Sub
    Private Sub Btn_OK_Click(sender As Object, e As EventArgs) Handles Btn_OK.Click
        ' Validar la cantidad ingresada
        Dim qtyInput As Integer
        If Integer.TryParse(Txt_Panels_Qty.Text, qtyInput) AndAlso qtyInput > 0 AndAlso qtyInput <= PanelsQuantity Then
            SelectedQty = qtyInput ' Asignar la cantidad seleccionada
            Me.DialogResult = DialogResult.OK
        Else
            MessageBox.Show("Please enter a valid quantity less than or equal to " & PanelsQuantity.ToString())
        End If
    End Sub

    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click
        Me.Close()
    End Sub
End Class