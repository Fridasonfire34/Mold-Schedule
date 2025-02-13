Imports System.Data.SqlClient
Imports System.Drawing.Printing

Public Class Mold_Walls
    Private Sub Mold_Walls_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel_Walls.Visible = False
        LoadWallPanels()
        DTP_Walls.Value = DateTime.Now
        DGV_M1AB_W.AllowDrop = True
        DGV_M1CD_W.AllowDrop = True
        DGV_Walls.AllowDrop = True
        DGV_M2AB_W.AllowDrop = True
        DGV_M2CD_W.AllowDrop = True
        DGV_M3AB_W.AllowDrop = True
        DGV_M3CD_W.AllowDrop = True
        DGV_M4AB_W.AllowDrop = True
        DGV_M4CD_W.AllowDrop = True
        DGV_M5AB_W.AllowDrop = True
        DGV_M5CD_W.AllowDrop = True
        DGV_M6AB_W.AllowDrop = True
        DGV_M6CD_W.AllowDrop = True
        DGV_OM1_W.AllowDrop = True
        DGV_OM2_W.AllowDrop = True
        DGV_OM3_W.AllowDrop = True


    End Sub
    Private Sub LoadWallPanels()
        DGV_Walls.Rows.Clear()

        Try
            Using connection As New SqlConnection(ConnectionString)
                connection.Open()

                Dim query As String = "SELECT [ID], [Panel], [QTY], [ASGM Date] " &
                                  "FROM [Jobs] " &
                                  "WHERE [Panel Identifier] = 'Wall' AND [Status] IS NULL"

                Using command As New SqlCommand(query, connection)
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim panelID As String = reader("ID").ToString()
                            Dim panel As String = reader("Panel").ToString()
                            Dim qty As Integer = Convert.ToInt32(reader("QTY"))
                            Dim DateSGM As String = If(IsDBNull(reader("ASGM Date")), String.Empty, CType(reader("ASGM Date"), DateTime).ToString("MM/dd/yyyy HH:mm"))

                            DGV_Walls.Rows.Add(panelID, panel, qty, DateSGM)
                        End While
                    End Using
                End Using

                If DGV_Walls.Columns.Count > 0 Then
                    DGV_Walls.Columns(0).HeaderText = "ID"
                    DGV_Walls.Columns(1).HeaderText = "Panel"
                    DGV_Walls.Columns(2).HeaderText = "Qty"
                    DGV_Walls.Columns(3).HeaderText = "Date"
                End If
            End Using
        Catch ex As SqlException
            MessageBox.Show("Error uploading the panels: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private OriginalQuantities As New Dictionary(Of String, Integer)
    Private draggingValue As String = String.Empty
    Private tooltip As New ToolTip()
    Private Sub DGV_Walls_DragDrop(sender As Object, e As DragEventArgs) Handles DGV_Walls.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            Dim panel As String = CType(e.Data.GetData(DataFormats.Text), String)
            Dim panelID As String = String.Empty

            ' Buscar en DGV_M1AB_W y DGV_M1CD_W si el panel existe
            Dim rowToUpdate As DataGridViewRow = FindPanelRow(panel, DGV_M1AB_W, DGV_M1CD_W, DGV_M2AB_W, DGV_M2CD_W, DGV_M3AB_W, DGV_M3CD_W, DGV_M4AB_W, DGV_M4CD_W, DGV_M5AB_W, DGV_M5CD_W, DGV_M6AB_W, DGV_M6CD_W, DGV_OM1_W, DGV_OM2_W, DGV_OM3_W)
            Dim originalQty As Integer = 1

            ' Si el panel se encontró, manejar la cantidad
            If rowToUpdate IsNot Nothing Then
                If originalQty > 1 Then
                    Dim panelsQtyForm As New PanelsQty()
                    panelsQtyForm.PanelsQuantity = originalQty ' Pasar el valor de Qty al formulario
                    If panelsQtyForm.ShowDialog() = DialogResult.OK Then
                        Dim selectedQty As Integer = panelsQtyForm.SelectedQty ' Cantidad seleccionada por el usuario

                        ' Crear y agregar la nueva fila en DGV_Walls con la cantidad seleccionada
                        Dim newRow As DataGridViewRow = New DataGridViewRow()
                        newRow.CreateCells(DGV_Walls)
                        newRow.Cells(0).Value = panelID
                        newRow.Cells(1).Value = panel
                        newRow.Cells(2).Value = selectedQty ' Usar la cantidad seleccionada
                        newRow.Cells(3).Value = DateTime.Now ' Usar la fecha actual
                        DGV_Walls.Rows.Add(newRow)

                        ' Actualizar la cantidad restante en DGV_M1AB_W o DGV_M1CD_W
                        Dim remainingQty As Integer = originalQty - selectedQty
                        If remainingQty > 0 Then
                            rowToUpdate.Cells(1).Value = remainingQty ' Actualizar con la cantidad restante
                        Else
                            If DGV_M1AB_W.Rows.Contains(rowToUpdate) Then
                                DGV_M1AB_W.Rows.Remove(rowToUpdate) ' Eliminar si la cantidad restante es 0
                            ElseIf DGV_M1CD_W.Rows.Contains(rowToUpdate) Then
                                DGV_M1CD_W.Rows.Remove(rowToUpdate) ' Eliminar si la cantidad restante es 0
                            ElseIf DGV_M2AB_W.Rows.Contains(rowToUpdate) Then
                                DGV_M2AB_W.Rows.Remove(rowToUpdate)
                            ElseIf DGV_M3AB_W.Rows.Contains(rowToUpdate) Then
                                DGV_M3AB_W.Rows.Remove(rowToUpdate)
                            ElseIf DGV_M4AB_W.Rows.Contains(rowToUpdate) Then
                                DGV_M4AB_W.Rows.Remove(rowToUpdate)
                            ElseIf DGV_M5AB_W.Rows.Contains(rowToUpdate) Then
                                DGV_M5AB_W.Rows.Remove(rowToUpdate)
                            ElseIf DGV_M6AB_W.Rows.Contains(rowToUpdate) Then
                                DGV_M6AB_W.Rows.Remove(rowToUpdate)
                            ElseIf DGV_OM1_W.Rows.Contains(rowToUpdate) Then
                                DGV_OM1_W.Rows.Remove(rowToUpdate)
                            ElseIf DGV_OM2_W.Rows.Contains(rowToUpdate) Then
                                DGV_OM2_W.Rows.Remove(rowToUpdate)
                            ElseIf DGV_OM3_W.Rows.Contains(rowToUpdate) Then
                                DGV_OM3_W.Rows.Remove(rowToUpdate)
                            End If

                        End If
                    End If
                Else
                    ' Si el Qty es 1 o menor, simplemente mover el panel
                    Dim newRow As DataGridViewRow = New DataGridViewRow()
                    newRow.CreateCells(DGV_Walls)
                    newRow.Cells(0).Value = panelID
                    newRow.Cells(1).Value = panel
                    newRow.Cells(2).Value = originalQty ' Usar el qty original
                    DGV_Walls.Rows.Add(newRow)
                    RemoveRowFromSource(panel, DGV_M1AB_W, DGV_M1CD_W, DGV_M2AB_W, DGV_M2CD_W, DGV_M3AB_W, DGV_M3CD_W, DGV_M4AB_W, DGV_M4CD_W, DGV_M5CD_W, DGV_M6AB_W, DGV_M6CD_W, DGV_OM1_W, DGV_OM2_W, DGV_OM3_W)
                End If
            Else
                MessageBox.Show("No se encontró el panel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Function FindPanelRow(panel As String, ParamArray gridViews() As DataGridView) As DataGridViewRow
        For Each gridView As DataGridView In gridViews
            For Each row As DataGridViewRow In gridView.Rows
                If row.Cells(0).Value IsNot Nothing AndAlso row.Cells(0).Value.ToString() = panel Then
                    Return row
                End If
            Next
        Next
        Return Nothing
    End Function
    Private Sub DGV_Walls_MouseDown(sender As Object, e As MouseEventArgs) Handles DGV_Walls.MouseDown
        If e.Button = MouseButtons.Left Then
            Dim hitTestInfo As DataGridView.HitTestInfo = DGV_Walls.HitTest(e.X, e.Y)
            If hitTestInfo.RowIndex >= 0 Then
                Dim panel As String = DGV_Walls.Rows(hitTestInfo.RowIndex).Cells(1).Value.ToString()
                ' Iniciar el arrastre con el panel como dato
                DGV_Walls.DoDragDrop(panel, DragDropEffects.Move)
            End If
        End If
    End Sub
    'mold 1
    Private Sub DGV_M1AB_W_DragEnter(sender As Object, e As DragEventArgs) Handles DGV_M1AB_W.DragEnter
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub DGV_M1AB_W_DragDrop(sender As Object, e As DragEventArgs) Handles DGV_M1AB_W.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            Dim panel As String = CType(e.Data.GetData(DataFormats.Text), String)

            Dim rowToUpdate As DataGridViewRow = Nothing
            Dim originalQty As Integer = 1
            Dim selectedQty As Integer = 1

            For Each row As DataGridViewRow In DGV_Walls.Rows
                If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString().Trim() = panel.Trim() Then
                    rowToUpdate = row
                    originalQty = Integer.Parse(row.Cells(2).Value.ToString())
                    Exit For
                End If
            Next

            If rowToUpdate IsNot Nothing Then
                If originalQty > 1 Then
                    Using qtyForm As New PanelsQty()
                        qtyForm.PanelsQuantity = originalQty
                        If qtyForm.ShowDialog() = DialogResult.OK Then
                            selectedQty = qtyForm.SelectedQty
                        Else
                            Exit Sub
                        End If
                    End Using
                Else
                    selectedQty = originalQty
                End If

                Dim newRow As DataGridViewRow = New DataGridViewRow()
                newRow.CreateCells(DGV_M1AB_W)
                newRow.Cells(0).Value = rowToUpdate.Cells(0).Value
                newRow.Cells(1).Value = panel
                newRow.Cells(2).Value = selectedQty
                newRow.Cells(3).Value = DTP_Walls.Value
                DGV_M1AB_W.Rows.Add(newRow)

                Dim remainingQty As Integer = originalQty - selectedQty
                If remainingQty > 0 Then
                    rowToUpdate.Cells(2).Value = remainingQty
                Else
                    DGV_Walls.Rows.Remove(rowToUpdate)
                End If
            Else
                MessageBox.Show("No se encontró el panel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub DGV_M1AB_W_DragOver(sender As Object, e As DragEventArgs) Handles DGV_M1AB_W.DragOver
        e.Effect = DragDropEffects.Move
    End Sub
    Private Sub DGV_M1AB_W_KeyDown(sender As Object, e As KeyEventArgs) Handles DGV_M1AB_W.KeyDown
        If e.KeyCode = Keys.Delete Then
            HandlePanelDeletion(DGV_M1AB_W)
        End If
    End Sub
    Private Sub DGV_M1AB_W_MouseDown(sender As Object, e As MouseEventArgs) Handles DGV_M1AB_W.MouseDown
        Dim hit As DataGridView.HitTestInfo = DGV_M1AB_W.HitTest(e.X, e.Y)
        If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 Then
            Dim cell As DataGridViewCell = DGV_M1AB_W.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
            If cell.Selected Then
                Dim dragValue As String = DGV_M1AB_W.Rows(hit.RowIndex).Cells(0).Value.ToString()
                DGV_M1AB_W.DoDragDrop(dragValue, DragDropEffects.Move)
            End If
        End If
    End Sub
    Private Sub DGV_M1CD_W_DragEnter(sender As Object, e As DragEventArgs) Handles DGV_M1CD_W.DragEnter
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub DGV_M1CD_W_DragDrop(sender As Object, e As DragEventArgs) Handles DGV_M1CD_W.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            Dim panel As String = CType(e.Data.GetData(DataFormats.Text), String)

            Dim rowToUpdate As DataGridViewRow = Nothing
            Dim originalQty As Integer = 1
            Dim selectedQty As Integer = 1

            For Each row As DataGridViewRow In DGV_Walls.Rows
                If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString().Trim() = panel.Trim() Then
                    rowToUpdate = row
                    originalQty = Integer.Parse(row.Cells(2).Value.ToString())
                    Exit For
                End If
            Next

            If rowToUpdate IsNot Nothing Then
                If originalQty > 1 Then
                    Using qtyForm As New PanelsQty()
                        qtyForm.PanelsQuantity = originalQty
                        If qtyForm.ShowDialog() = DialogResult.OK Then
                            selectedQty = qtyForm.SelectedQty
                        Else
                            Exit Sub
                        End If
                    End Using
                Else
                    selectedQty = originalQty
                End If

                Dim newRow As DataGridViewRow = New DataGridViewRow()
                newRow.CreateCells(DGV_M1CD_W)
                newRow.Cells(0).Value = rowToUpdate.Cells(0).Value
                newRow.Cells(1).Value = panel
                newRow.Cells(2).Value = selectedQty
                newRow.Cells(3).Value = DTP_Walls.Value
                DGV_M1CD_W.Rows.Add(newRow)

                Dim remainingQty As Integer = originalQty - selectedQty
                If remainingQty > 0 Then
                    rowToUpdate.Cells(2).Value = remainingQty
                Else
                    DGV_Walls.Rows.Remove(rowToUpdate)
                End If
            Else
                MessageBox.Show("No se encontró el panel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub DGV_M1CD_W_MouseDown(sender As Object, e As MouseEventArgs) Handles DGV_M1CD_W.MouseDown
        Dim hit As DataGridView.HitTestInfo = DGV_M1CD_W.HitTest(e.X, e.Y)
        If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 Then
            Dim cell As DataGridViewCell = DGV_M1CD_W.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
            If cell.Selected Then
                Dim dragValue As String = DGV_M1CD_W.Rows(hit.RowIndex).Cells(0).Value.ToString()
                DGV_M1CD_W.DoDragDrop(dragValue, DragDropEffects.Move)
            End If
        End If
    End Sub
    Private Sub DGV_M1CD_W_KeyDown(sender As Object, e As KeyEventArgs) Handles DGV_M1CD_W.KeyDown
        If e.KeyCode = Keys.Delete Then
            HandlePanelDeletion(DGV_M1CD_W)
        End If
    End Sub
    Private Sub DGV_M1CD_W_DragOver(sender As Object, e As DragEventArgs) Handles DGV_M1CD_W.DragOver
        e.Effect = DragDropEffects.Move
    End Sub

    'functions
    Private Function PanelAlreadyExists(panel As String, dgv As DataGridView) As Boolean
        For Each row As DataGridViewRow In dgv.Rows
            If row.Cells(0).Value IsNot Nothing AndAlso row.Cells(0).Value.ToString() = panel Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Sub HandlePanelDeletion(dgv As DataGridView)
        If dgv.SelectedRows.Count > 0 Then
            Dim selectedRow As DataGridViewRow = dgv.SelectedRows(0)
            Dim panelID As String = selectedRow.Cells(0).Value.ToString()
            Dim panel As String = selectedRow.Cells(1).Value.ToString() ' Nombre del panel
            Dim qty As Integer = Integer.Parse(selectedRow.Cells(2).Value.ToString()) ' Cantidad

            MovePanelBackToDGVWalls(panelID, panel, qty)
            dgv.Rows.Remove(selectedRow)
            dgv.ClearSelection()
        Else
            'MessageBox.Show("Seleccione un panel para eliminar.", "Eliminar Panel", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub MovePanelBackToDGVWalls(panelID As String, panel As String, qty As Integer)
        Dim existsInWalls As Boolean = False

        ' Busca si el panel ya existe en DGV_Walls
        For Each wallRow As DataGridViewRow In DGV_Walls.Rows
            If wallRow.Cells(1).Value IsNot Nothing AndAlso wallRow.Cells(1).Value.ToString() = panel Then
                ' Si existe, suma la cantidad
                Dim wallQty As Integer = Integer.Parse(wallRow.Cells(2).Value.ToString())
                wallRow.Cells(2).Value = wallQty + qty ' Sumar la cantidad del panel eliminado
                existsInWalls = True

                ' Asegura que OriginalQuantities tiene el valor original
                If Not OriginalQuantities.ContainsKey(panel) Then
                    OriginalQuantities(panel) = wallQty + qty
                End If
                Exit For
            End If
        Next

        ' Si el panel no existe en DGV_Walls, crea una nueva fila
        If Not existsInWalls Then
            Dim newRow As DataGridViewRow = CType(DGV_Walls.Rows(0).Clone(), DataGridViewRow)
            newRow.Cells(0).Value = panelID ' ID
            newRow.Cells(1).Value = panel ' Nombre del panel
            newRow.Cells(2).Value = qty ' Cantidad
            newRow.Cells(3).Value = Nothing ' Puedes ajustar el valor para la fecha si es necesario

            ' Almacena el valor original de la cantidad en OriginalQuantities
            If Not OriginalQuantities.ContainsKey(panel) Then
                OriginalQuantities(panel) = qty
            End If

            DGV_Walls.Rows.Add(newRow)
        End If
    End Sub
    Private Sub RemoveRowFromSource(panel As String, ParamArray grids() As DataGridView)
        For Each grid As DataGridView In grids
            For i As Integer = grid.Rows.Count - 1 To 0 Step -1 ' Iterar hacia atrás para evitar errores al eliminar
                Dim row As DataGridViewRow = grid.Rows(i)
                If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString() = panel Then
                    grid.Rows.Remove(row)
                    Exit For
                End If
            Next
        Next
    End Sub
    'MOLD 2
    Private Sub DGV_M2AB_W_DragEnter(sender As Object, e As DragEventArgs) Handles DGV_M2AB_W.DragEnter
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub DGV_M2AB_W_DragDrop(sender As Object, e As DragEventArgs) Handles DGV_M2AB_W.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            Dim panel As String = CType(e.Data.GetData(DataFormats.Text), String)

            Dim rowToUpdate As DataGridViewRow = Nothing
            Dim originalQty As Integer = 1
            Dim selectedQty As Integer = 1

            For Each row As DataGridViewRow In DGV_Walls.Rows
                If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString().Trim() = panel.Trim() Then
                    rowToUpdate = row
                    originalQty = Integer.Parse(row.Cells(2).Value.ToString())
                    Exit For
                End If
            Next

            If rowToUpdate IsNot Nothing Then
                If originalQty > 1 Then
                    Using qtyForm As New PanelsQty()
                        qtyForm.PanelsQuantity = originalQty
                        If qtyForm.ShowDialog() = DialogResult.OK Then
                            selectedQty = qtyForm.SelectedQty
                        Else
                            Exit Sub
                        End If
                    End Using
                Else
                    selectedQty = originalQty
                End If

                Dim newRow As DataGridViewRow = New DataGridViewRow()
                newRow.CreateCells(DGV_M2AB_W)
                newRow.Cells(0).Value = rowToUpdate.Cells(0).Value
                newRow.Cells(1).Value = panel
                newRow.Cells(2).Value = selectedQty
                newRow.Cells(3).Value = DTP_Walls.Value
                DGV_M2AB_W.Rows.Add(newRow)

                Dim remainingQty As Integer = originalQty - selectedQty
                If remainingQty > 0 Then
                    rowToUpdate.Cells(2).Value = remainingQty
                Else
                    DGV_Walls.Rows.Remove(rowToUpdate)
                End If
            Else
                MessageBox.Show("No se encontró el panel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub DGV_M2AB_W_DragOver(sender As Object, e As DragEventArgs) Handles DGV_M2AB_W.DragOver
        e.Effect = DragDropEffects.Move
    End Sub
    Private Sub DGV_M2AB_W_KeyDown(sender As Object, e As KeyEventArgs) Handles DGV_M2AB_W.KeyDown
        If e.KeyCode = Keys.Delete Then
            HandlePanelDeletion(DGV_M2AB_W)
        End If
    End Sub
    Private Sub DGV_M2AB_W_MouseDown(sender As Object, e As MouseEventArgs) Handles DGV_M2AB_W.MouseDown
        Dim hit As DataGridView.HitTestInfo = DGV_M2AB_W.HitTest(e.X, e.Y)
        If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 Then
            Dim cell As DataGridViewCell = DGV_M2AB_W.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
            If cell.Selected Then
                Dim dragValue As String = DGV_M2AB_W.Rows(hit.RowIndex).Cells(0).Value.ToString()
                DGV_M2AB_W.DoDragDrop(dragValue, DragDropEffects.Move)
            End If
        End If
    End Sub
    Private Sub DGV_M2CD_W_DragEnter(sender As Object, e As DragEventArgs) Handles DGV_M2CD_W.DragEnter
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub DGV_M2CD_W_DragDrop(sender As Object, e As DragEventArgs) Handles DGV_M2CD_W.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            Dim panel As String = CType(e.Data.GetData(DataFormats.Text), String)

            Dim rowToUpdate As DataGridViewRow = Nothing
            Dim originalQty As Integer = 1
            Dim selectedQty As Integer = 1

            For Each row As DataGridViewRow In DGV_Walls.Rows
                If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString().Trim() = panel.Trim() Then
                    rowToUpdate = row
                    originalQty = Integer.Parse(row.Cells(2).Value.ToString())
                    Exit For
                End If
            Next

            If rowToUpdate IsNot Nothing Then
                If originalQty > 1 Then
                    Using qtyForm As New PanelsQty()
                        qtyForm.PanelsQuantity = originalQty
                        If qtyForm.ShowDialog() = DialogResult.OK Then
                            selectedQty = qtyForm.SelectedQty
                        Else
                            Exit Sub
                        End If
                    End Using
                Else
                    selectedQty = originalQty
                End If

                Dim newRow As DataGridViewRow = New DataGridViewRow()
                newRow.CreateCells(DGV_M2CD_W)
                newRow.Cells(0).Value = rowToUpdate.Cells(0).Value
                newRow.Cells(1).Value = panel
                newRow.Cells(2).Value = selectedQty
                newRow.Cells(3).Value = DTP_Walls.Value
                DGV_M2CD_W.Rows.Add(newRow)

                Dim remainingQty As Integer = originalQty - selectedQty
                If remainingQty > 0 Then
                    rowToUpdate.Cells(2).Value = remainingQty
                Else
                    DGV_Walls.Rows.Remove(rowToUpdate)
                End If
            Else
                MessageBox.Show("No se encontró el panel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub DGV_M2CD_W_MouseDown(sender As Object, e As MouseEventArgs) Handles DGV_M2CD_W.MouseDown
        Dim hit As DataGridView.HitTestInfo = DGV_M2CD_W.HitTest(e.X, e.Y)
        If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 Then
            Dim cell As DataGridViewCell = DGV_M2CD_W.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
            If cell.Selected Then
                Dim dragValue As String = DGV_M2CD_W.Rows(hit.RowIndex).Cells(0).Value.ToString()
                DGV_M2CD_W.DoDragDrop(dragValue, DragDropEffects.Move)
            End If
        End If
    End Sub
    Private Sub DGV_M2CD_W_KeyDown(sender As Object, e As KeyEventArgs) Handles DGV_M2CD_W.KeyDown
        If e.KeyCode = Keys.Delete Then
            HandlePanelDeletion(DGV_M2CD_W)
        End If
    End Sub
    Private Sub DGV_M2CD_W_DragOver(sender As Object, e As DragEventArgs) Handles DGV_M2CD_W.DragOver
        e.Effect = DragDropEffects.Move
    End Sub

    'mold 3
    Private Sub DGV_M3AB_W_DragEnter(sender As Object, e As DragEventArgs) Handles DGV_M3AB_W.DragEnter
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub DGV_M3AB_W_DragDrop(sender As Object, e As DragEventArgs) Handles DGV_M3AB_W.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            Dim panel As String = CType(e.Data.GetData(DataFormats.Text), String)

            Dim rowToUpdate As DataGridViewRow = Nothing
            Dim originalQty As Integer = 1
            Dim selectedQty As Integer = 1

            For Each row As DataGridViewRow In DGV_Walls.Rows
                If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString().Trim() = panel.Trim() Then
                    rowToUpdate = row
                    originalQty = Integer.Parse(row.Cells(2).Value.ToString())
                    Exit For
                End If
            Next

            If rowToUpdate IsNot Nothing Then
                If originalQty > 1 Then
                    Using qtyForm As New PanelsQty()
                        qtyForm.PanelsQuantity = originalQty
                        If qtyForm.ShowDialog() = DialogResult.OK Then
                            selectedQty = qtyForm.SelectedQty
                        Else
                            Exit Sub
                        End If
                    End Using
                Else
                    selectedQty = originalQty
                End If

                Dim newRow As DataGridViewRow = New DataGridViewRow()
                newRow.CreateCells(DGV_M3AB_W)
                newRow.Cells(0).Value = rowToUpdate.Cells(0).Value
                newRow.Cells(1).Value = panel
                newRow.Cells(2).Value = selectedQty
                newRow.Cells(3).Value = DTP_Walls.Value
                DGV_M3AB_W.Rows.Add(newRow)

                Dim remainingQty As Integer = originalQty - selectedQty
                If remainingQty > 0 Then
                    rowToUpdate.Cells(2).Value = remainingQty
                Else
                    DGV_Walls.Rows.Remove(rowToUpdate)
                End If
            Else
                MessageBox.Show("No se encontró el panel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub DGV_M3AB_W_DragOver(sender As Object, e As DragEventArgs) Handles DGV_M3AB_W.DragOver
        e.Effect = DragDropEffects.Move
    End Sub
    Private Sub DGV_M3AB_W_KeyDown(sender As Object, e As KeyEventArgs) Handles DGV_M3AB_W.KeyDown
        If e.KeyCode = Keys.Delete Then
            HandlePanelDeletion(DGV_M3AB_W)
        End If
    End Sub
    Private Sub DGV_M3AB_W_MouseDown(sender As Object, e As MouseEventArgs) Handles DGV_M3AB_W.MouseDown
        Dim hit As DataGridView.HitTestInfo = DGV_M3AB_W.HitTest(e.X, e.Y)
        If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 Then
            Dim cell As DataGridViewCell = DGV_M3AB_W.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
            If cell.Selected Then
                Dim dragValue As String = DGV_M3AB_W.Rows(hit.RowIndex).Cells(0).Value.ToString()
                DGV_M3AB_W.DoDragDrop(dragValue, DragDropEffects.Move)
            End If
        End If
    End Sub
    Private Sub DGV_M3CD_W_DragEnter(sender As Object, e As DragEventArgs) Handles DGV_M3CD_W.DragEnter
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub DGV_M3CD_W_DragDrop(sender As Object, e As DragEventArgs) Handles DGV_M3CD_W.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            Dim panel As String = CType(e.Data.GetData(DataFormats.Text), String)

            Dim rowToUpdate As DataGridViewRow = Nothing
            Dim originalQty As Integer = 1
            Dim selectedQty As Integer = 1

            For Each row As DataGridViewRow In DGV_Walls.Rows
                If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString().Trim() = panel.Trim() Then
                    rowToUpdate = row
                    originalQty = Integer.Parse(row.Cells(2).Value.ToString())
                    Exit For
                End If
            Next

            If rowToUpdate IsNot Nothing Then
                If originalQty > 1 Then
                    Using qtyForm As New PanelsQty()
                        qtyForm.PanelsQuantity = originalQty
                        If qtyForm.ShowDialog() = DialogResult.OK Then
                            selectedQty = qtyForm.SelectedQty
                        Else
                            Exit Sub
                        End If
                    End Using
                Else
                    selectedQty = originalQty
                End If

                Dim newRow As DataGridViewRow = New DataGridViewRow()
                newRow.CreateCells(DGV_M3CD_W)
                newRow.Cells(0).Value = rowToUpdate.Cells(0).Value
                newRow.Cells(1).Value = panel
                newRow.Cells(2).Value = selectedQty
                newRow.Cells(3).Value = DTP_Walls.Value
                DGV_M3CD_W.Rows.Add(newRow)

                Dim remainingQty As Integer = originalQty - selectedQty
                If remainingQty > 0 Then
                    rowToUpdate.Cells(2).Value = remainingQty
                Else
                    DGV_Walls.Rows.Remove(rowToUpdate)
                End If
            Else
                MessageBox.Show("No se encontró el panel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub DGV_M3CD_W_MouseDown(sender As Object, e As MouseEventArgs) Handles DGV_M3CD_W.MouseDown
        Dim hit As DataGridView.HitTestInfo = DGV_M3CD_W.HitTest(e.X, e.Y)
        If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 Then
            Dim cell As DataGridViewCell = DGV_M3CD_W.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
            If cell.Selected Then
                Dim dragValue As String = DGV_M3CD_W.Rows(hit.RowIndex).Cells(0).Value.ToString()
                DGV_M3CD_W.DoDragDrop(dragValue, DragDropEffects.Move)
            End If
        End If
    End Sub
    Private Sub DGV_M3CD_W_KeyDown(sender As Object, e As KeyEventArgs) Handles DGV_M3CD_W.KeyDown
        If e.KeyCode = Keys.Delete Then
            HandlePanelDeletion(DGV_M3CD_W)
        End If
    End Sub
    Private Sub DGV_M3CD_W_DragOver(sender As Object, e As DragEventArgs) Handles DGV_M3CD_W.DragOver
        e.Effect = DragDropEffects.Move
    End Sub

    ' mold 4
    Private Sub DGV_M4AB_W_DragEnter(sender As Object, e As DragEventArgs) Handles DGV_M4AB_W.DragEnter
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub DGV_M4AB_W_DragDrop(sender As Object, e As DragEventArgs) Handles DGV_M4AB_W.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            Dim panel As String = CType(e.Data.GetData(DataFormats.Text), String)

            Dim rowToUpdate As DataGridViewRow = Nothing
            Dim originalQty As Integer = 1
            Dim selectedQty As Integer = 1

            For Each row As DataGridViewRow In DGV_Walls.Rows
                If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString().Trim() = panel.Trim() Then
                    rowToUpdate = row
                    originalQty = Integer.Parse(row.Cells(2).Value.ToString())
                    Exit For
                End If
            Next

            If rowToUpdate IsNot Nothing Then
                If originalQty > 1 Then
                    Using qtyForm As New PanelsQty()
                        qtyForm.PanelsQuantity = originalQty
                        If qtyForm.ShowDialog() = DialogResult.OK Then
                            selectedQty = qtyForm.SelectedQty
                        Else
                            Exit Sub
                        End If
                    End Using
                Else
                    selectedQty = originalQty
                End If

                Dim newRow As DataGridViewRow = New DataGridViewRow()
                newRow.CreateCells(DGV_M4AB_W)
                newRow.Cells(0).Value = rowToUpdate.Cells(0).Value
                newRow.Cells(1).Value = panel
                newRow.Cells(2).Value = selectedQty
                newRow.Cells(3).Value = DTP_Walls.Value
                DGV_M4AB_W.Rows.Add(newRow)

                Dim remainingQty As Integer = originalQty - selectedQty
                If remainingQty > 0 Then
                    rowToUpdate.Cells(2).Value = remainingQty
                Else
                    DGV_Walls.Rows.Remove(rowToUpdate)
                End If
            Else
                MessageBox.Show("No se encontró el panel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub DGV_M4AB_W_DragOver(sender As Object, e As DragEventArgs) Handles DGV_M4AB_W.DragOver
        e.Effect = DragDropEffects.Move
    End Sub
    Private Sub DGV_M4AB_W_KeyDown(sender As Object, e As KeyEventArgs) Handles DGV_M4AB_W.KeyDown
        If e.KeyCode = Keys.Delete Then
            HandlePanelDeletion(DGV_M4AB_W)
        End If
    End Sub
    Private Sub DGV_M4AB_W_MouseDown(sender As Object, e As MouseEventArgs) Handles DGV_M4AB_W.MouseDown
        Dim hit As DataGridView.HitTestInfo = DGV_M2AB_W.HitTest(e.X, e.Y)
        If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 Then
            Dim cell As DataGridViewCell = DGV_M4AB_W.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
            If cell.Selected Then
                Dim dragValue As String = DGV_M4AB_W.Rows(hit.RowIndex).Cells(0).Value.ToString()
                DGV_M4AB_W.DoDragDrop(dragValue, DragDropEffects.Move)
            End If
        End If
    End Sub
    Private Sub DGV_M4CD_W_DragEnter(sender As Object, e As DragEventArgs) Handles DGV_M4CD_W.DragEnter
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub DGV_M4CD_W_DragDrop(sender As Object, e As DragEventArgs) Handles DGV_M4CD_W.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            Dim panel As String = CType(e.Data.GetData(DataFormats.Text), String)

            Dim rowToUpdate As DataGridViewRow = Nothing
            Dim originalQty As Integer = 1
            Dim selectedQty As Integer = 1

            For Each row As DataGridViewRow In DGV_Walls.Rows
                If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString().Trim() = panel.Trim() Then
                    rowToUpdate = row
                    originalQty = Integer.Parse(row.Cells(2).Value.ToString())
                    Exit For
                End If
            Next

            If rowToUpdate IsNot Nothing Then
                If originalQty > 1 Then
                    Using qtyForm As New PanelsQty()
                        qtyForm.PanelsQuantity = originalQty
                        If qtyForm.ShowDialog() = DialogResult.OK Then
                            selectedQty = qtyForm.SelectedQty
                        Else
                            Exit Sub
                        End If
                    End Using
                Else
                    selectedQty = originalQty
                End If

                Dim newRow As DataGridViewRow = New DataGridViewRow()
                newRow.CreateCells(DGV_M4CD_W)
                newRow.Cells(0).Value = rowToUpdate.Cells(0).Value
                newRow.Cells(1).Value = panel
                newRow.Cells(2).Value = selectedQty
                newRow.Cells(3).Value = DTP_Walls.Value
                DGV_M4CD_W.Rows.Add(newRow)

                Dim remainingQty As Integer = originalQty - selectedQty
                If remainingQty > 0 Then
                    rowToUpdate.Cells(2).Value = remainingQty
                Else
                    DGV_Walls.Rows.Remove(rowToUpdate)
                End If
            Else
                MessageBox.Show("No se encontró el panel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub DGV_M4CD_W_MouseDown(sender As Object, e As MouseEventArgs) Handles DGV_M4CD_W.MouseDown
        Dim hit As DataGridView.HitTestInfo = DGV_M4CD_W.HitTest(e.X, e.Y)
        If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 Then
            Dim cell As DataGridViewCell = DGV_M4CD_W.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
            If cell.Selected Then
                Dim dragValue As String = DGV_M4CD_W.Rows(hit.RowIndex).Cells(0).Value.ToString()
                DGV_M4CD_W.DoDragDrop(dragValue, DragDropEffects.Move)
            End If
        End If
    End Sub
    Private Sub DGV_M4CD_W_KeyDown(sender As Object, e As KeyEventArgs) Handles DGV_M4CD_W.KeyDown
        If e.KeyCode = Keys.Delete Then
            HandlePanelDeletion(DGV_M4CD_W)
        End If
    End Sub
    Private Sub DGV_M4CD_W_DragOver(sender As Object, e As DragEventArgs) Handles DGV_M4CD_W.DragOver
        e.Effect = DragDropEffects.Move
    End Sub

    'mold 5
    Private Sub DGV_M5AB_W_DragEnter(sender As Object, e As DragEventArgs) Handles DGV_M5AB_W.DragEnter
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub DGV_M5AB_W_DragDrop(sender As Object, e As DragEventArgs) Handles DGV_M5AB_W.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            Dim panel As String = CType(e.Data.GetData(DataFormats.Text), String)

            Dim rowToUpdate As DataGridViewRow = Nothing
            Dim originalQty As Integer = 1
            Dim selectedQty As Integer = 1

            For Each row As DataGridViewRow In DGV_Walls.Rows
                If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString().Trim() = panel.Trim() Then
                    rowToUpdate = row
                    originalQty = Integer.Parse(row.Cells(2).Value.ToString())
                    Exit For
                End If
            Next

            If rowToUpdate IsNot Nothing Then
                If originalQty > 1 Then
                    Using qtyForm As New PanelsQty()
                        qtyForm.PanelsQuantity = originalQty
                        If qtyForm.ShowDialog() = DialogResult.OK Then
                            selectedQty = qtyForm.SelectedQty
                        Else
                            Exit Sub
                        End If
                    End Using
                Else
                    selectedQty = originalQty
                End If

                Dim newRow As DataGridViewRow = New DataGridViewRow()
                newRow.CreateCells(DGV_M5AB_W)
                newRow.Cells(0).Value = rowToUpdate.Cells(0).Value
                newRow.Cells(1).Value = panel
                newRow.Cells(2).Value = selectedQty
                newRow.Cells(3).Value = DTP_Walls.Value
                DGV_M5AB_W.Rows.Add(newRow)

                Dim remainingQty As Integer = originalQty - selectedQty
                If remainingQty > 0 Then
                    rowToUpdate.Cells(2).Value = remainingQty
                Else
                    DGV_Walls.Rows.Remove(rowToUpdate)
                End If
            Else
                MessageBox.Show("No se encontró el panel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub DGV_M5AB_W_DragOver(sender As Object, e As DragEventArgs) Handles DGV_M5AB_W.DragOver
        e.Effect = DragDropEffects.Move
    End Sub
    Private Sub DGV_M5AB_W_KeyDown(sender As Object, e As KeyEventArgs) Handles DGV_M5AB_W.KeyDown
        If e.KeyCode = Keys.Delete Then
            HandlePanelDeletion(DGV_M5AB_W)
        End If
    End Sub
    Private Sub DGV_M5AB_W_MouseDown(sender As Object, e As MouseEventArgs) Handles DGV_M5AB_W.MouseDown
        Dim hit As DataGridView.HitTestInfo = DGV_M5AB_W.HitTest(e.X, e.Y)
        If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 Then
            Dim cell As DataGridViewCell = DGV_M5AB_W.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
            If cell.Selected Then
                Dim dragValue As String = DGV_M5AB_W.Rows(hit.RowIndex).Cells(0).Value.ToString()
                DGV_M5AB_W.DoDragDrop(dragValue, DragDropEffects.Move)
            End If
        End If
    End Sub
    Private Sub DGV_M5CD_W_DragEnter(sender As Object, e As DragEventArgs) Handles DGV_M5CD_W.DragEnter
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub DGV_M5CD_W_DragDrop(sender As Object, e As DragEventArgs) Handles DGV_M5CD_W.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            Dim panel As String = CType(e.Data.GetData(DataFormats.Text), String)

            Dim rowToUpdate As DataGridViewRow = Nothing
            Dim originalQty As Integer = 1
            Dim selectedQty As Integer = 1

            For Each row As DataGridViewRow In DGV_Walls.Rows
                If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString().Trim() = panel.Trim() Then
                    rowToUpdate = row
                    originalQty = Integer.Parse(row.Cells(2).Value.ToString())
                    Exit For
                End If
            Next

            If rowToUpdate IsNot Nothing Then
                If originalQty > 1 Then
                    Using qtyForm As New PanelsQty()
                        qtyForm.PanelsQuantity = originalQty
                        If qtyForm.ShowDialog() = DialogResult.OK Then
                            selectedQty = qtyForm.SelectedQty
                        Else
                            Exit Sub
                        End If
                    End Using
                Else
                    selectedQty = originalQty
                End If

                Dim newRow As DataGridViewRow = New DataGridViewRow()
                newRow.CreateCells(DGV_M5CD_W)
                newRow.Cells(0).Value = rowToUpdate.Cells(0).Value
                newRow.Cells(1).Value = panel
                newRow.Cells(2).Value = selectedQty
                newRow.Cells(3).Value = DTP_Walls.Value
                DGV_M5CD_W.Rows.Add(newRow)

                Dim remainingQty As Integer = originalQty - selectedQty
                If remainingQty > 0 Then
                    rowToUpdate.Cells(2).Value = remainingQty
                Else
                    DGV_Walls.Rows.Remove(rowToUpdate)
                End If
            Else
                MessageBox.Show("No se encontró el panel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub DGV_M5CD_W_MouseDown(sender As Object, e As MouseEventArgs) Handles DGV_M5CD_W.MouseDown
        Dim hit As DataGridView.HitTestInfo = DGV_M5CD_W.HitTest(e.X, e.Y)
        If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 Then
            Dim cell As DataGridViewCell = DGV_M5CD_W.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
            If cell.Selected Then
                Dim dragValue As String = DGV_M5CD_W.Rows(hit.RowIndex).Cells(0).Value.ToString()
                DGV_M5CD_W.DoDragDrop(dragValue, DragDropEffects.Move)
            End If
        End If
    End Sub
    Private Sub DGV_M5CD_W_KeyDown(sender As Object, e As KeyEventArgs) Handles DGV_M5CD_W.KeyDown
        If e.KeyCode = Keys.Delete Then
            HandlePanelDeletion(DGV_M5CD_W)
        End If
    End Sub
    Private Sub DGV_M5CD_W_DragOver(sender As Object, e As DragEventArgs) Handles DGV_M5CD_W.DragOver
        e.Effect = DragDropEffects.Move
    End Sub
    'mold 6
    Private Sub DGV_M6AB_W_DragEnter(sender As Object, e As DragEventArgs) Handles DGV_M6AB_W.DragEnter
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub DGV_M6AB_W_DragDrop(sender As Object, e As DragEventArgs) Handles DGV_M6AB_W.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            Dim panel As String = CType(e.Data.GetData(DataFormats.Text), String)

            Dim rowToUpdate As DataGridViewRow = Nothing
            Dim originalQty As Integer = 1
            Dim selectedQty As Integer = 1

            For Each row As DataGridViewRow In DGV_Walls.Rows
                If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString().Trim() = panel.Trim() Then
                    rowToUpdate = row
                    originalQty = Integer.Parse(row.Cells(2).Value.ToString())
                    Exit For
                End If
            Next

            If rowToUpdate IsNot Nothing Then
                If originalQty > 1 Then
                    Using qtyForm As New PanelsQty()
                        qtyForm.PanelsQuantity = originalQty
                        If qtyForm.ShowDialog() = DialogResult.OK Then
                            selectedQty = qtyForm.SelectedQty
                        Else
                            Exit Sub
                        End If
                    End Using
                Else
                    selectedQty = originalQty
                End If

                Dim newRow As DataGridViewRow = New DataGridViewRow()
                newRow.CreateCells(DGV_M6AB_W)
                newRow.Cells(0).Value = rowToUpdate.Cells(0).Value
                newRow.Cells(1).Value = panel
                newRow.Cells(2).Value = selectedQty
                newRow.Cells(3).Value = DTP_Walls.Value
                DGV_M6AB_W.Rows.Add(newRow)

                Dim remainingQty As Integer = originalQty - selectedQty
                If remainingQty > 0 Then
                    rowToUpdate.Cells(2).Value = remainingQty
                Else
                    DGV_Walls.Rows.Remove(rowToUpdate)
                End If
            Else
                MessageBox.Show("No se encontró el panel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub DGV_M6AB_W_DragOver(sender As Object, e As DragEventArgs) Handles DGV_M6AB_W.DragOver
        e.Effect = DragDropEffects.Move
    End Sub
    Private Sub DGV_M6AB_W_KeyDown(sender As Object, e As KeyEventArgs) Handles DGV_M6AB_W.KeyDown
        If e.KeyCode = Keys.Delete Then
            HandlePanelDeletion(DGV_M6AB_W)
        End If
    End Sub
    Private Sub DGV_M6AB_W_MouseDown(sender As Object, e As MouseEventArgs) Handles DGV_M6AB_W.MouseDown
        Dim hit As DataGridView.HitTestInfo = DGV_M6AB_W.HitTest(e.X, e.Y)
        If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 Then
            Dim cell As DataGridViewCell = DGV_M6AB_W.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
            If cell.Selected Then
                Dim dragValue As String = DGV_M6AB_W.Rows(hit.RowIndex).Cells(0).Value.ToString()
                DGV_M6AB_W.DoDragDrop(dragValue, DragDropEffects.Move)
            End If
        End If
    End Sub
    Private Sub DGV_M6CD_W_DragEnter(sender As Object, e As DragEventArgs) Handles DGV_M6CD_W.DragEnter
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub DGV_M6CD_W_DragDrop(sender As Object, e As DragEventArgs) Handles DGV_M6CD_W.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            Dim panel As String = CType(e.Data.GetData(DataFormats.Text), String)

            Dim rowToUpdate As DataGridViewRow = Nothing
            Dim originalQty As Integer = 1
            Dim selectedQty As Integer = 1

            For Each row As DataGridViewRow In DGV_Walls.Rows
                If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString().Trim() = panel.Trim() Then
                    rowToUpdate = row
                    originalQty = Integer.Parse(row.Cells(2).Value.ToString())
                    Exit For
                End If
            Next

            If rowToUpdate IsNot Nothing Then
                If originalQty > 1 Then
                    Using qtyForm As New PanelsQty()
                        qtyForm.PanelsQuantity = originalQty
                        If qtyForm.ShowDialog() = DialogResult.OK Then
                            selectedQty = qtyForm.SelectedQty
                        Else
                            Exit Sub
                        End If
                    End Using
                Else
                    selectedQty = originalQty
                End If

                Dim newRow As DataGridViewRow = New DataGridViewRow()
                newRow.CreateCells(DGV_M6CD_W)
                newRow.Cells(0).Value = rowToUpdate.Cells(0).Value
                newRow.Cells(1).Value = panel
                newRow.Cells(2).Value = selectedQty
                newRow.Cells(3).Value = DTP_Walls.Value
                DGV_M6CD_W.Rows.Add(newRow)

                Dim remainingQty As Integer = originalQty - selectedQty
                If remainingQty > 0 Then
                    rowToUpdate.Cells(2).Value = remainingQty
                Else
                    DGV_Walls.Rows.Remove(rowToUpdate)
                End If
            Else
                MessageBox.Show("No se encontró el panel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub DGV_M6CD_W_MouseDown(sender As Object, e As MouseEventArgs) Handles DGV_M6CD_W.MouseDown
        Dim hit As DataGridView.HitTestInfo = DGV_M6CD_W.HitTest(e.X, e.Y)
        If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 Then
            Dim cell As DataGridViewCell = DGV_M6CD_W.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
            If cell.Selected Then
                Dim dragValue As String = DGV_M6CD_W.Rows(hit.RowIndex).Cells(0).Value.ToString()
                DGV_M6CD_W.DoDragDrop(dragValue, DragDropEffects.Move)
            End If
        End If
    End Sub
    Private Sub DGV_M6CD_W_KeyDown(sender As Object, e As KeyEventArgs) Handles DGV_M6CD_W.KeyDown
        If e.KeyCode = Keys.Delete Then
            HandlePanelDeletion(DGV_M6CD_W)
        End If
    End Sub
    Private Sub DGV_M6CD_W_DragOver(sender As Object, e As DragEventArgs) Handles DGV_M6CD_W.DragOver
        e.Effect = DragDropEffects.Move
    End Sub
    'old mold 1
    Private Sub DGV_OM1_W_DragEnter(sender As Object, e As DragEventArgs) Handles DGV_OM1_W.DragEnter
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub DGV_OM1_W_DragDrop(sender As Object, e As DragEventArgs) Handles DGV_OM1_W.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            Dim panel As String = CType(e.Data.GetData(DataFormats.Text), String)

            Dim rowToUpdate As DataGridViewRow = Nothing
            Dim originalQty As Integer = 1
            Dim selectedQty As Integer = 1

            For Each row As DataGridViewRow In DGV_Walls.Rows
                If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString().Trim() = panel.Trim() Then
                    rowToUpdate = row
                    originalQty = Integer.Parse(row.Cells(2).Value.ToString())
                    Exit For
                End If
            Next
            If rowToUpdate IsNot Nothing Then
                If originalQty > 1 Then
                    Using qtyForm As New PanelsQty()
                        qtyForm.PanelsQuantity = originalQty
                        If qtyForm.ShowDialog() = DialogResult.OK Then
                            selectedQty = qtyForm.SelectedQty
                        Else
                            Exit Sub
                        End If
                    End Using
                Else
                    selectedQty = originalQty
                End If

                Dim newRow As DataGridViewRow = New DataGridViewRow()
                newRow.CreateCells(DGV_OM1_W)
                newRow.Cells(0).Value = rowToUpdate.Cells(0).Value
                newRow.Cells(1).Value = panel
                newRow.Cells(2).Value = selectedQty
                newRow.Cells(3).Value = DTP_Walls.Value

                DGV_OM1_W.Rows.Add(newRow)

                Dim remainingQty As Integer = originalQty - selectedQty
                If remainingQty > 0 Then
                    rowToUpdate.Cells(2).Value = remainingQty
                Else
                    DGV_Walls.Rows.Remove(rowToUpdate)
                End If
            Else
                MessageBox.Show("Couldn't find panel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub DGV_OM1_W_DragOver(sender As Object, e As DragEventArgs) Handles DGV_OM1_W.DragOver
        e.Effect = DragDropEffects.Move
    End Sub
    Private Sub DGV_OM1_W_KeyDown(sender As Object, e As KeyEventArgs) Handles DGV_OM1_W.KeyDown
        If e.KeyCode = Keys.Delete Then
            HandlePanelDeletion(DGV_OM1_W)
        End If
    End Sub
    Private Sub DGV_OM1_W_MouseDown(sender As Object, e As MouseEventArgs) Handles DGV_OM1_W.MouseDown
        Dim hit As DataGridView.HitTestInfo = DGV_OM1_W.HitTest(e.X, e.Y)
        If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 Then
            Dim cell As DataGridViewCell = DGV_OM1_W.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
            If cell.Selected Then
                Dim dragValue As String = DGV_OM1_W.Rows(hit.RowIndex).Cells(0).Value.ToString()
                DGV_OM1_W.DoDragDrop(dragValue, DragDropEffects.Move)
            End If
        End If
    End Sub

    'old mold 2
    Private Sub DGV_OM2_W_DragEnter(sender As Object, e As DragEventArgs) Handles DGV_OM2_W.DragEnter
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub DGV_OM2_W_DragDrop(sender As Object, e As DragEventArgs) Handles DGV_OM2_W.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            Dim panel As String = CType(e.Data.GetData(DataFormats.Text), String)

            Dim rowToUpdate As DataGridViewRow = Nothing
            Dim originalQty As Integer = 1
            Dim selectedQty As Integer = 1

            For Each row As DataGridViewRow In DGV_Walls.Rows
                If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString().Trim() = panel.Trim() Then
                    rowToUpdate = row
                    originalQty = Integer.Parse(row.Cells(2).Value.ToString())
                    Exit For
                End If
            Next
            If rowToUpdate IsNot Nothing Then
                If originalQty > 1 Then
                    Using qtyForm As New PanelsQty()
                        qtyForm.PanelsQuantity = originalQty
                        If qtyForm.ShowDialog() = DialogResult.OK Then
                            selectedQty = qtyForm.SelectedQty
                        Else
                            Exit Sub
                        End If
                    End Using
                Else
                    selectedQty = originalQty
                End If

                Dim newRow As DataGridViewRow = New DataGridViewRow()
                newRow.CreateCells(DGV_OM2_W)
                newRow.Cells(0).Value = rowToUpdate.Cells(0).Value
                newRow.Cells(1).Value = panel
                newRow.Cells(2).Value = selectedQty
                newRow.Cells(3).Value = DTP_Walls.Value

                DGV_OM2_W.Rows.Add(newRow)

                Dim remainingQty As Integer = originalQty - selectedQty
                If remainingQty > 0 Then
                    rowToUpdate.Cells(2).Value = remainingQty
                Else
                    DGV_Walls.Rows.Remove(rowToUpdate)
                End If
            Else
                MessageBox.Show("Couldn't find panel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub DGV_OM2_W_DragOver(sender As Object, e As DragEventArgs) Handles DGV_OM2_W.DragOver
        e.Effect = DragDropEffects.Move
    End Sub
    Private Sub DGV_OM2_W_KeyDown(sender As Object, e As KeyEventArgs) Handles DGV_OM2_W.KeyDown
        If e.KeyCode = Keys.Delete Then
            HandlePanelDeletion(DGV_OM2_W)
        End If
    End Sub
    Private Sub DGV_OM2_W_MouseDown(sender As Object, e As MouseEventArgs) Handles DGV_OM2_W.MouseDown
        Dim hit As DataGridView.HitTestInfo = DGV_OM2_W.HitTest(e.X, e.Y)
        If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 Then
            Dim cell As DataGridViewCell = DGV_OM2_W.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
            If cell.Selected Then
                Dim dragValue As String = DGV_OM2_W.Rows(hit.RowIndex).Cells(0).Value.ToString()
                DGV_OM2_W.DoDragDrop(dragValue, DragDropEffects.Move)
            End If
        End If
    End Sub

    'Old mold 3
    Private Sub DGV_OM3_W_DragEnter(sender As Object, e As DragEventArgs) Handles DGV_OM3_W.DragEnter
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub DGV_OM3_W_DragDrop(sender As Object, e As DragEventArgs) Handles DGV_OM3_W.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            Dim panel As String = CType(e.Data.GetData(DataFormats.Text), String)

            Dim rowToUpdate As DataGridViewRow = Nothing
            Dim originalQty As Integer = 1
            Dim selectedQty As Integer = 1

            For Each row As DataGridViewRow In DGV_Walls.Rows
                If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString().Trim() = panel.Trim() Then
                    rowToUpdate = row
                    originalQty = Integer.Parse(row.Cells(2).Value.ToString())
                    Exit For
                End If
            Next
            If rowToUpdate IsNot Nothing Then
                If originalQty > 1 Then
                    Using qtyForm As New PanelsQty()
                        qtyForm.PanelsQuantity = originalQty
                        If qtyForm.ShowDialog() = DialogResult.OK Then
                            selectedQty = qtyForm.SelectedQty
                        Else
                            Exit Sub
                        End If
                    End Using
                Else
                    selectedQty = originalQty
                End If

                Dim newRow As DataGridViewRow = New DataGridViewRow()
                newRow.CreateCells(DGV_OM3_W)
                newRow.Cells(0).Value = rowToUpdate.Cells(0).Value
                newRow.Cells(1).Value = panel
                newRow.Cells(2).Value = selectedQty
                newRow.Cells(3).Value = DTP_Walls.Value

                DGV_OM3_W.Rows.Add(newRow)

                Dim remainingQty As Integer = originalQty - selectedQty
                If remainingQty > 0 Then
                    rowToUpdate.Cells(2).Value = remainingQty
                Else
                    DGV_Walls.Rows.Remove(rowToUpdate)
                End If
            Else
                MessageBox.Show("Couldn't find panel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub DGV_OM3_W_DragOver(sender As Object, e As DragEventArgs) Handles DGV_OM3_W.DragOver
        e.Effect = DragDropEffects.Move
    End Sub
    Private Sub DGV_OM3_W_KeyDown(sender As Object, e As KeyEventArgs) Handles DGV_OM3_W.KeyDown
        If e.KeyCode = Keys.Delete Then
            HandlePanelDeletion(DGV_OM3_W)
        End If
    End Sub
    Private Sub DGV_OM3_W_MouseDown(sender As Object, e As MouseEventArgs) Handles DGV_OM3_W.MouseDown
        Dim hit As DataGridView.HitTestInfo = DGV_OM3_W.HitTest(e.X, e.Y)
        If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 Then
            Dim cell As DataGridViewCell = DGV_OM3_W.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
            If cell.Selected Then
                Dim dragValue As String = DGV_OM3_W.Rows(hit.RowIndex).Cells(0).Value.ToString()
                DGV_OM3_W.DoDragDrop(dragValue, DragDropEffects.Move)
            End If
        End If
    End Sub

    'other functions
    Private Sub Lnk_Lbl_Corn_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Lnk_Lbl_Corn.LinkClicked
        Me.Close()
        Dim Corners As New Molds_Corners()
        Corners.ShowDialog()
    End Sub
    Private Sub ClearMoldsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearMoldsToolStripMenuItem.Click
        ' Lista de todos los DataGridView a limpiar
        Dim dgvList As List(Of DataGridView) = New List(Of DataGridView) From {
        DGV_M1AB_W, DGV_M1CD_W, DGV_M2AB_W, DGV_M2CD_W, DGV_M3AB_W, DGV_M3CD_W,
        DGV_M4AB_W, DGV_M4CD_W, DGV_M5AB_W, DGV_M5CD_W, DGV_M6AB_W, DGV_M6CD_W,
        DGV_OM1_W, DGV_OM2_W, DGV_OM3_W
    }

        ' Limpiar todas las filas en cada DataGridView
        For Each dgv As DataGridView In dgvList
            dgv.Rows.Clear()
        Next
    End Sub
    Private Sub PrintMold1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintMold1ToolStripMenuItem.Click
        SavePanels()

        Dim queryAB As String = "SELECT [ASGMT Date], [Panel], [Qty] FROM [Molds] WHERE [Mold] = 'DGV_M1AB_W' AND [Estatus] = 'NUEVO' ORDER BY [ASGMT Date] ASC"
        Dim queryCD As String = "SELECT [ASGMT Date], [Panel], [Qty] FROM [Molds] WHERE [Mold] = 'DGV_M1CD_W' AND [Estatus] = 'NUEVO' ORDER BY [ASGMT Date] ASC"

        Dim dtAB As New DataTable()
        Dim dtCD As New DataTable()

        Using connection As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(queryAB, connection)
                connection.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dtAB.Load(reader)
                End Using
            End Using
        End Using

        Using connection As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(queryCD, connection)
                connection.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dtCD.Load(reader)
                End Using
            End Using
        End Using

        Dim printDoc As New Printing.PrintDocument()
        AddHandler printDoc.PrintPage, Sub(s, ev)

                                           Dim leftMargin As Single = 50
                                           Dim rightMargin As Single = 50
                                           Dim topMargin As Single = 5
                                           Dim bottomMargin As Single = 20

                                           Dim effectiveWidth As Single = ev.PageBounds.Width - leftMargin - rightMargin
                                           Dim effectiveHeight As Single = ev.PageBounds.Height - topMargin - bottomMargin

                                           Dim recordFont As New Font("Arial", 12)
                                           Dim yPos As Single = ev.MarginBounds.Top
                                           Dim lineHeight As Single = ev.Graphics.MeasureString("Sample Text", recordFont).Height

                                           Dim headerFont As New Font("Arial", 20, FontStyle.Bold)
                                           Dim headerText As String = "Walls"
                                           Dim headerWidth As Single = ev.Graphics.MeasureString(headerText, headerFont).Width
                                           Dim centerX As Single = (ev.PageBounds.Width - headerWidth) / 2
                                           ev.Graphics.DrawString(headerText, headerFont, Brushes.Black, centerX, yPos)
                                           yPos += headerFont.GetHeight(ev.Graphics) + 20

                                           Dim columnHeaderFont As New Font("Arial", 14, FontStyle.Bold)
                                           Dim columnHeaderYPos As Single = yPos

                                           Dim moldColumn1X As Single = leftMargin
                                           Dim moldColumn2X As Single = moldColumn1X + 125
                                           Dim qtyColumn1X As Single = moldColumn2X + 227
                                           Dim moldColumn3X As Single = qtyColumn1X + 62
                                           Dim qtyColumn2X As Single = moldColumn3X + 225
                                           Dim tableWidth As Single = qtyColumn2X + 75 - leftMargin

                                           ev.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + tableWidth, yPos)

                                           ev.Graphics.DrawString("Date", columnHeaderFont, Brushes.Black, leftMargin, yPos)
                                           ev.Graphics.DrawString("Mold 1 A&B", columnHeaderFont, Brushes.Black, leftMargin + 160, yPos)
                                           ev.Graphics.DrawString("Qty", columnHeaderFont, Brushes.Black, leftMargin + 347, yPos)
                                           ev.Graphics.DrawString("Mold 1 C&D", columnHeaderFont, Brushes.Black, leftMargin + 443, yPos)
                                           ev.Graphics.DrawString("Qty", columnHeaderFont, Brushes.Black, leftMargin + 635, yPos)
                                           yPos += lineHeight

                                           yPos += 2

                                           ev.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + tableWidth, yPos)


                                           Dim maxRows As Integer = Math.Max(dtAB.Rows.Count, dtCD.Rows.Count)
                                           For i As Integer = 0 To maxRows - 1
                                               Dim cutDateAB As String = If(i < dtAB.Rows.Count, Convert.ToDateTime(dtAB.Rows(i)("ASGMT Date")).ToString("MM/dd/yyyy"), "")
                                               Dim panelAB As String = If(i < dtAB.Rows.Count, dtAB.Rows(i)("Panel").ToString(), "")
                                               Dim qtyAB As String = If(i < dtAB.Rows.Count, dtAB.Rows(i)("Qty").ToString(), "")

                                               Dim cutDateCD As String = If(i < dtCD.Rows.Count, Convert.ToDateTime(dtCD.Rows(i)("ASGMT Date")).ToString("MM/dd/yyyy"), "")
                                               Dim panelCD As String = If(i < dtCD.Rows.Count, dtCD.Rows(i)("Panel").ToString(), "")
                                               Dim qtyCD As String = If(i < dtCD.Rows.Count, dtCD.Rows(i)("Qty").ToString(), "")

                                               ev.Graphics.DrawString(cutDateAB, recordFont, Brushes.Black, moldColumn1X, yPos) 'fechas
                                               ev.Graphics.DrawString(panelAB, recordFont, Brushes.Black, moldColumn2X, yPos) 'paneles de a&b
                                               ev.Graphics.DrawString(qtyAB, recordFont, Brushes.Black, qtyColumn1X, yPos) 'qty de a&b
                                               ev.Graphics.DrawString(panelCD, recordFont, Brushes.Black, moldColumn3X, yPos) 'paneles de c&d
                                               ev.Graphics.DrawString(qtyCD, recordFont, Brushes.Black, qtyColumn2X, yPos) 'qty de c&d
                                               ev.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + tableWidth, yPos) 'separadores de renglones


                                               ev.Graphics.DrawLine(Pens.Black, moldColumn1X, yPos - 2 - lineHeight, moldColumn1X, yPos) 'primer linea parada a partir de Date
                                               ev.Graphics.DrawLine(Pens.Black, moldColumn2X, yPos - 2 - lineHeight, moldColumn2X, yPos)
                                               ev.Graphics.DrawLine(Pens.Black, qtyColumn1X - 5, yPos - 2 - lineHeight, qtyColumn1X - 5, yPos)
                                               ev.Graphics.DrawLine(Pens.Black, moldColumn3X - 3, yPos - 2 - lineHeight, moldColumn3X - 3, yPos)
                                               ev.Graphics.DrawLine(Pens.Black, qtyColumn2X - 5, yPos - 2 - lineHeight, qtyColumn2X - 5, yPos)
                                               ev.Graphics.DrawLine(Pens.Black, moldColumn1X + 714, yPos - 2 - lineHeight, moldColumn1X + 714, yPos) 'ultima linea para cerrar la tabla

                                               yPos += lineHeight
                                           Next
                                           ev.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + tableWidth, yPos) 'la ultima linea acostada de la tabla
                                           ev.Graphics.DrawLine(Pens.Black, moldColumn1X, yPos - 2 - lineHeight, moldColumn1X, yPos) 'ultima linea de lado izq de date
                                           ev.Graphics.DrawLine(Pens.Black, moldColumn2X, yPos - 2 - lineHeight, moldColumn2X, yPos) ' ultima linea de lado izq de a&b
                                           ev.Graphics.DrawLine(Pens.Black, qtyColumn1X - 5, yPos - 2 - lineHeight, qtyColumn1X - 5, yPos) 'ultima linea de lado de a&b
                                           ev.Graphics.DrawLine(Pens.Black, moldColumn3X - 3, yPos - 2 - lineHeight, moldColumn3X - 3, yPos) 'ultima linea de lado de qty de a&b
                                           ev.Graphics.DrawLine(Pens.Black, qtyColumn2X - 5, yPos - 2 - lineHeight, qtyColumn2X - 5, yPos) 'ultima linea de lado derecho de c&d
                                           ev.Graphics.DrawLine(Pens.Black, qtyColumn2X + 75, yPos - 2 - lineHeight, qtyColumn2X + 75, yPos)


                                       End Sub

        Dim printPreviewDialog As New PrintPreviewDialog()
        printPreviewDialog.Document = printDoc
        printPreviewDialog.ShowDialog()
    End Sub
    Private Sub PrintMold2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintMold2ToolStripMenuItem.Click
        SavePanels()
        Dim query2AB As String = "SELECT [ASGMT Date], [Panel], [Qty] FROM [Molds] WHERE [Mold] = 'DGV_M2AB_W' AND [Estatus] = 'NUEVO' ORDER BY [ASGMT Date] ASC"
        Dim query2CD As String = "SELECT [ASGMT Date], [Panel], [Qty] FROM [Molds] WHERE [Mold] = 'DGV_M2CD_W' AND [Estatus] = 'NUEVO' ORDER BY [ASGMT Date] ASC"

        Dim dtAB As New DataTable()
        Dim dtCD As New DataTable()

        Using connection As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(query2AB, connection)
                connection.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dtAB.Load(reader)
                End Using
            End Using
        End Using

        Using connection As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(query2CD, connection)
                connection.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dtCD.Load(reader)
                End Using
            End Using
        End Using

        Dim printDoc As New Printing.PrintDocument()
        AddHandler printDoc.PrintPage, Sub(s, ev)

                                           Dim leftMargin As Single = 50
                                           Dim rightMargin As Single = 50
                                           Dim topMargin As Single = 10
                                           Dim bottomMargin As Single = 20

                                           Dim effectiveWidth As Single = ev.PageBounds.Width - leftMargin - rightMargin
                                           Dim effectiveHeight As Single = ev.PageBounds.Height - topMargin - bottomMargin

                                           Dim recordFont As New Font("Arial", 12)
                                           Dim yPos As Single = ev.MarginBounds.Top
                                           Dim lineHeight As Single = ev.Graphics.MeasureString("Sample Text", recordFont).Height

                                           Dim headerFont As New Font("Arial", 20, FontStyle.Bold)
                                           Dim headerText As String = "Walls"
                                           Dim headerWidth As Single = ev.Graphics.MeasureString(headerText, headerFont).Width
                                           Dim centerX As Single = (ev.PageBounds.Width - headerWidth) / 2
                                           ev.Graphics.DrawString(headerText, headerFont, Brushes.Black, centerX, yPos)
                                           yPos += headerFont.GetHeight(ev.Graphics) + 20

                                           Dim columnHeaderFont As New Font("Arial", 14, FontStyle.Bold)
                                           Dim columnHeaderYPos As Single = yPos

                                           Dim moldColumn1X As Single = leftMargin
                                           Dim moldColumn2X As Single = moldColumn1X + 125
                                           Dim qtyColumn1X As Single = moldColumn2X + 227
                                           Dim moldColumn3X As Single = qtyColumn1X + 62
                                           Dim qtyColumn2X As Single = moldColumn3X + 225
                                           Dim tableWidth As Single = qtyColumn2X + 75 - leftMargin

                                           ev.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + tableWidth, yPos)

                                           ev.Graphics.DrawString("Date", columnHeaderFont, Brushes.Black, leftMargin, yPos)
                                           ev.Graphics.DrawString("Mold 1 A&B", columnHeaderFont, Brushes.Black, leftMargin + 160, yPos)
                                           ev.Graphics.DrawString("Qty", columnHeaderFont, Brushes.Black, leftMargin + 347, yPos)
                                           ev.Graphics.DrawString("Mold 1 C&D", columnHeaderFont, Brushes.Black, leftMargin + 443, yPos)
                                           ev.Graphics.DrawString("Qty", columnHeaderFont, Brushes.Black, leftMargin + 635, yPos)
                                           yPos += lineHeight

                                           yPos += 2

                                           ev.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + tableWidth, yPos)


                                           Dim maxRows As Integer = Math.Max(dtAB.Rows.Count, dtCD.Rows.Count)
                                           For i As Integer = 0 To maxRows - 1
                                               Dim cutDateAB As String = If(i < dtAB.Rows.Count, Convert.ToDateTime(dtAB.Rows(i)("ASGMT Date")).ToString("MM/dd/yyyy"), "")
                                               Dim panelAB As String = If(i < dtAB.Rows.Count, dtAB.Rows(i)("Panel").ToString(), "")
                                               Dim qtyAB As String = If(i < dtAB.Rows.Count, dtAB.Rows(i)("Qty").ToString(), "")

                                               Dim cutDateCD As String = If(i < dtCD.Rows.Count, Convert.ToDateTime(dtCD.Rows(i)("ASGMT Date")).ToString("MM/dd/yyyy"), "")
                                               Dim panelCD As String = If(i < dtCD.Rows.Count, dtCD.Rows(i)("Panel").ToString(), "")
                                               Dim qtyCD As String = If(i < dtCD.Rows.Count, dtCD.Rows(i)("Qty").ToString(), "")

                                               ev.Graphics.DrawString(cutDateAB, recordFont, Brushes.Black, moldColumn1X, yPos) 'fechas
                                               ev.Graphics.DrawString(panelAB, recordFont, Brushes.Black, moldColumn2X, yPos) 'paneles de a&b
                                               ev.Graphics.DrawString(qtyAB, recordFont, Brushes.Black, qtyColumn1X, yPos) 'qty de a&b
                                               ev.Graphics.DrawString(panelCD, recordFont, Brushes.Black, moldColumn3X, yPos) 'paneles de c&d
                                               ev.Graphics.DrawString(qtyCD, recordFont, Brushes.Black, qtyColumn2X, yPos) 'qty de c&d
                                               ev.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + tableWidth, yPos) 'separadores de renglones


                                               ev.Graphics.DrawLine(Pens.Black, moldColumn1X, yPos - 2 - lineHeight, moldColumn1X, yPos) 'primer linea parada a partir de Date
                                               ev.Graphics.DrawLine(Pens.Black, moldColumn2X, yPos - 2 - lineHeight, moldColumn2X, yPos)
                                               ev.Graphics.DrawLine(Pens.Black, qtyColumn1X - 5, yPos - 2 - lineHeight, qtyColumn1X - 5, yPos)
                                               ev.Graphics.DrawLine(Pens.Black, moldColumn3X - 3, yPos - 2 - lineHeight, moldColumn3X - 3, yPos)
                                               ev.Graphics.DrawLine(Pens.Black, qtyColumn2X - 5, yPos - 2 - lineHeight, qtyColumn2X - 5, yPos)
                                               ev.Graphics.DrawLine(Pens.Black, moldColumn1X + 714, yPos - 2 - lineHeight, moldColumn1X + 714, yPos) 'ultima linea para cerrar la tabla

                                               yPos += lineHeight
                                           Next
                                           ev.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + tableWidth, yPos) 'la ultima linea acostada de la tabla
                                           ev.Graphics.DrawLine(Pens.Black, moldColumn1X, yPos - 2 - lineHeight, moldColumn1X, yPos) 'ultima linea de lado izq de date
                                           ev.Graphics.DrawLine(Pens.Black, moldColumn2X, yPos - 2 - lineHeight, moldColumn2X, yPos) ' ultima linea de lado izq de a&b
                                           ev.Graphics.DrawLine(Pens.Black, qtyColumn1X - 5, yPos - 2 - lineHeight, qtyColumn1X - 5, yPos) 'ultima linea de lado de a&b
                                           ev.Graphics.DrawLine(Pens.Black, moldColumn3X - 3, yPos - 2 - lineHeight, moldColumn3X - 3, yPos) 'ultima linea de lado de qty de a&b
                                           ev.Graphics.DrawLine(Pens.Black, qtyColumn2X - 5, yPos - 2 - lineHeight, qtyColumn2X - 5, yPos) 'ultima linea de lado derecho de c&d
                                           ev.Graphics.DrawLine(Pens.Black, qtyColumn2X + 75, yPos - 2 - lineHeight, qtyColumn2X + 75, yPos)


                                       End Sub

        Dim printPreviewDialog As New PrintPreviewDialog()
        printPreviewDialog.Document = printDoc
        printPreviewDialog.ShowDialog()
    End Sub
    Private Sub PrintMold3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintMold3ToolStripMenuItem.Click
        SavePanels()
        Dim query3AB As String = "SELECT [ASGMT Date], [Panel], [Qty] FROM [Molds] WHERE [Mold] = 'DGV_M3AB_W' AND [Estatus] = 'NUEVO' ORDER BY [ASGMT Date] ASC"
        Dim query3CD As String = "SELECT [ASGMT Date], [Panel], [Qty] FROM [Molds] WHERE [Mold] = 'DGV_M3CD_W' AND [Estatus] = 'NUEVO' ORDER BY [ASGMT Date] ASC"

        Dim dtAB As New DataTable()
        Dim dtCD As New DataTable()

        Using connection As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(query3AB, connection)
                connection.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dtAB.Load(reader)
                End Using
            End Using
        End Using

        Using connection As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(query3CD, connection)
                connection.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dtCD.Load(reader)
                End Using
            End Using
        End Using

        Dim printDoc As New Printing.PrintDocument()
        AddHandler printDoc.PrintPage, Sub(s, ev)

                                           Dim leftMargin As Single = 50
                                           Dim rightMargin As Single = 50
                                           Dim topMargin As Single = 10
                                           Dim bottomMargin As Single = 20

                                           Dim effectiveWidth As Single = ev.PageBounds.Width - leftMargin - rightMargin
                                           Dim effectiveHeight As Single = ev.PageBounds.Height - topMargin - bottomMargin

                                           Dim recordFont As New Font("Arial", 12)
                                           Dim yPos As Single = ev.MarginBounds.Top
                                           Dim lineHeight As Single = ev.Graphics.MeasureString("Sample Text", recordFont).Height

                                           Dim headerFont As New Font("Arial", 20, FontStyle.Bold)
                                           Dim headerText As String = "Walls"
                                           Dim headerWidth As Single = ev.Graphics.MeasureString(headerText, headerFont).Width
                                           Dim centerX As Single = (ev.PageBounds.Width - headerWidth) / 2
                                           ev.Graphics.DrawString(headerText, headerFont, Brushes.Black, centerX, yPos)
                                           yPos += headerFont.GetHeight(ev.Graphics) + 20

                                           Dim columnHeaderFont As New Font("Arial", 14, FontStyle.Bold)
                                           Dim columnHeaderYPos As Single = yPos

                                           Dim moldColumn1X As Single = leftMargin
                                           Dim moldColumn2X As Single = moldColumn1X + 125
                                           Dim qtyColumn1X As Single = moldColumn2X + 227
                                           Dim moldColumn3X As Single = qtyColumn1X + 62
                                           Dim qtyColumn2X As Single = moldColumn3X + 225
                                           Dim tableWidth As Single = qtyColumn2X + 75 - leftMargin

                                           ev.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + tableWidth, yPos)

                                           ev.Graphics.DrawString("Date", columnHeaderFont, Brushes.Black, leftMargin, yPos)
                                           ev.Graphics.DrawString("Mold 1 A&B", columnHeaderFont, Brushes.Black, leftMargin + 160, yPos)
                                           ev.Graphics.DrawString("Qty", columnHeaderFont, Brushes.Black, leftMargin + 347, yPos)
                                           ev.Graphics.DrawString("Mold 1 C&D", columnHeaderFont, Brushes.Black, leftMargin + 443, yPos)
                                           ev.Graphics.DrawString("Qty", columnHeaderFont, Brushes.Black, leftMargin + 635, yPos)
                                           yPos += lineHeight

                                           yPos += 2

                                           ev.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + tableWidth, yPos)


                                           Dim maxRows As Integer = Math.Max(dtAB.Rows.Count, dtCD.Rows.Count)
                                           For i As Integer = 0 To maxRows - 1
                                               Dim cutDateAB As String = If(i < dtAB.Rows.Count, Convert.ToDateTime(dtAB.Rows(i)("ASGMT Date")).ToString("MM/dd/yyyy"), "")
                                               Dim panelAB As String = If(i < dtAB.Rows.Count, dtAB.Rows(i)("Panel").ToString(), "")
                                               Dim qtyAB As String = If(i < dtAB.Rows.Count, dtAB.Rows(i)("Qty").ToString(), "")

                                               Dim cutDateCD As String = If(i < dtCD.Rows.Count, Convert.ToDateTime(dtCD.Rows(i)("ASGMT Date")).ToString("MM/dd/yyyy"), "")
                                               Dim panelCD As String = If(i < dtCD.Rows.Count, dtCD.Rows(i)("Panel").ToString(), "")
                                               Dim qtyCD As String = If(i < dtCD.Rows.Count, dtCD.Rows(i)("Qty").ToString(), "")

                                               ev.Graphics.DrawString(cutDateAB, recordFont, Brushes.Black, moldColumn1X, yPos) 'fechas
                                               ev.Graphics.DrawString(panelAB, recordFont, Brushes.Black, moldColumn2X, yPos) 'paneles de a&b
                                               ev.Graphics.DrawString(qtyAB, recordFont, Brushes.Black, qtyColumn1X, yPos) 'qty de a&b
                                               ev.Graphics.DrawString(panelCD, recordFont, Brushes.Black, moldColumn3X, yPos) 'paneles de c&d
                                               ev.Graphics.DrawString(qtyCD, recordFont, Brushes.Black, qtyColumn2X, yPos) 'qty de c&d
                                               ev.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + tableWidth, yPos) 'separadores de renglones


                                               ev.Graphics.DrawLine(Pens.Black, moldColumn1X, yPos - 2 - lineHeight, moldColumn1X, yPos) 'primer linea parada a partir de Date
                                               ev.Graphics.DrawLine(Pens.Black, moldColumn2X, yPos - 2 - lineHeight, moldColumn2X, yPos)
                                               ev.Graphics.DrawLine(Pens.Black, qtyColumn1X - 5, yPos - 2 - lineHeight, qtyColumn1X - 5, yPos)
                                               ev.Graphics.DrawLine(Pens.Black, moldColumn3X - 3, yPos - 2 - lineHeight, moldColumn3X - 3, yPos)
                                               ev.Graphics.DrawLine(Pens.Black, qtyColumn2X - 5, yPos - 2 - lineHeight, qtyColumn2X - 5, yPos)
                                               ev.Graphics.DrawLine(Pens.Black, moldColumn1X + 714, yPos - 2 - lineHeight, moldColumn1X + 714, yPos) 'ultima linea para cerrar la tabla

                                               yPos += lineHeight
                                           Next
                                           ev.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + tableWidth, yPos) 'la ultima linea acostada de la tabla
                                           ev.Graphics.DrawLine(Pens.Black, moldColumn1X, yPos - 2 - lineHeight, moldColumn1X, yPos) 'ultima linea de lado izq de date
                                           ev.Graphics.DrawLine(Pens.Black, moldColumn2X, yPos - 2 - lineHeight, moldColumn2X, yPos) ' ultima linea de lado izq de a&b
                                           ev.Graphics.DrawLine(Pens.Black, qtyColumn1X - 5, yPos - 2 - lineHeight, qtyColumn1X - 5, yPos) 'ultima linea de lado de a&b
                                           ev.Graphics.DrawLine(Pens.Black, moldColumn3X - 3, yPos - 2 - lineHeight, moldColumn3X - 3, yPos) 'ultima linea de lado de qty de a&b
                                           ev.Graphics.DrawLine(Pens.Black, qtyColumn2X - 5, yPos - 2 - lineHeight, qtyColumn2X - 5, yPos) 'ultima linea de lado derecho de c&d
                                           ev.Graphics.DrawLine(Pens.Black, qtyColumn2X + 75, yPos - 2 - lineHeight, qtyColumn2X + 75, yPos)


                                       End Sub

        Dim printPreviewDialog As New PrintPreviewDialog()
        printPreviewDialog.Document = printDoc
        printPreviewDialog.ShowDialog()
    End Sub
    Private Sub PrintMold4ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintMold4ToolStripMenuItem.Click
        SavePanels()
        Dim query4AB As String = "SELECT [ASGMT Date], [Panel], [Qty] FROM [Molds] WHERE [Mold] = 'DGV_M4AB_W' AND [Estatus] = 'NUEVO' ORDER BY [ASGMT Date] ASC"
        Dim query4CD As String = "SELECT [ASGMT Date], [Panel], [Qty] FROM [Molds] WHERE [Mold] = 'DGV_M4CD_W' AND [Estatus] = 'NUEVO' ORDER BY [ASGMT Date] ASC"

        Dim dtAB As New DataTable()
        Dim dtCD As New DataTable()

        Using connection As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(query4AB, connection)
                connection.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dtAB.Load(reader)
                End Using
            End Using
        End Using

        Using connection As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(query4CD, connection)
                connection.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dtCD.Load(reader)
                End Using
            End Using
        End Using

        Dim printDoc As New Printing.PrintDocument()
        AddHandler printDoc.PrintPage, Sub(s, ev)

                                           Dim leftMargin As Single = 50
                                           Dim rightMargin As Single = 50
                                           Dim topMargin As Single = 10
                                           Dim bottomMargin As Single = 20

                                           Dim effectiveWidth As Single = ev.PageBounds.Width - leftMargin - rightMargin
                                           Dim effectiveHeight As Single = ev.PageBounds.Height - topMargin - bottomMargin

                                           Dim recordFont As New Font("Arial", 12)
                                           Dim yPos As Single = ev.MarginBounds.Top
                                           Dim lineHeight As Single = ev.Graphics.MeasureString("Sample Text", recordFont).Height

                                           Dim headerFont As New Font("Arial", 20, FontStyle.Bold)
                                           Dim headerText As String = "Walls"
                                           Dim headerWidth As Single = ev.Graphics.MeasureString(headerText, headerFont).Width
                                           Dim centerX As Single = (ev.PageBounds.Width - headerWidth) / 2
                                           ev.Graphics.DrawString(headerText, headerFont, Brushes.Black, centerX, yPos)
                                           yPos += headerFont.GetHeight(ev.Graphics) + 20

                                           Dim columnHeaderFont As New Font("Arial", 14, FontStyle.Bold)
                                           Dim columnHeaderYPos As Single = yPos

                                           Dim moldColumn1X As Single = leftMargin
                                           Dim moldColumn2X As Single = moldColumn1X + 125
                                           Dim qtyColumn1X As Single = moldColumn2X + 227
                                           Dim moldColumn3X As Single = qtyColumn1X + 62
                                           Dim qtyColumn2X As Single = moldColumn3X + 225
                                           Dim tableWidth As Single = qtyColumn2X + 75 - leftMargin

                                           ev.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + tableWidth, yPos)

                                           ev.Graphics.DrawString("Date", columnHeaderFont, Brushes.Black, leftMargin, yPos)
                                           ev.Graphics.DrawString("Mold 1 A&B", columnHeaderFont, Brushes.Black, leftMargin + 160, yPos)
                                           ev.Graphics.DrawString("Qty", columnHeaderFont, Brushes.Black, leftMargin + 347, yPos)
                                           ev.Graphics.DrawString("Mold 1 C&D", columnHeaderFont, Brushes.Black, leftMargin + 443, yPos)
                                           ev.Graphics.DrawString("Qty", columnHeaderFont, Brushes.Black, leftMargin + 635, yPos)
                                           yPos += lineHeight

                                           yPos += 2

                                           ev.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + tableWidth, yPos)


                                           Dim maxRows As Integer = Math.Max(dtAB.Rows.Count, dtCD.Rows.Count)
                                           For i As Integer = 0 To maxRows - 1
                                               Dim cutDateAB As String = If(i < dtAB.Rows.Count, Convert.ToDateTime(dtAB.Rows(i)("ASGMT Date")).ToString("MM/dd/yyyy"), "")
                                               Dim panelAB As String = If(i < dtAB.Rows.Count, dtAB.Rows(i)("Panel").ToString(), "")
                                               Dim qtyAB As String = If(i < dtAB.Rows.Count, dtAB.Rows(i)("Qty").ToString(), "")

                                               Dim cutDateCD As String = If(i < dtCD.Rows.Count, Convert.ToDateTime(dtCD.Rows(i)("ASGMT Date")).ToString("MM/dd/yyyy"), "")
                                               Dim panelCD As String = If(i < dtCD.Rows.Count, dtCD.Rows(i)("Panel").ToString(), "")
                                               Dim qtyCD As String = If(i < dtCD.Rows.Count, dtCD.Rows(i)("Qty").ToString(), "")

                                               ev.Graphics.DrawString(cutDateAB, recordFont, Brushes.Black, moldColumn1X, yPos) 'fechas
                                               ev.Graphics.DrawString(panelAB, recordFont, Brushes.Black, moldColumn2X, yPos) 'paneles de a&b
                                               ev.Graphics.DrawString(qtyAB, recordFont, Brushes.Black, qtyColumn1X, yPos) 'qty de a&b
                                               ev.Graphics.DrawString(panelCD, recordFont, Brushes.Black, moldColumn3X, yPos) 'paneles de c&d
                                               ev.Graphics.DrawString(qtyCD, recordFont, Brushes.Black, qtyColumn2X, yPos) 'qty de c&d
                                               ev.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + tableWidth, yPos) 'separadores de renglones


                                               ev.Graphics.DrawLine(Pens.Black, moldColumn1X, yPos - 2 - lineHeight, moldColumn1X, yPos) 'primer linea parada a partir de Date
                                               ev.Graphics.DrawLine(Pens.Black, moldColumn2X, yPos - 2 - lineHeight, moldColumn2X, yPos)
                                               ev.Graphics.DrawLine(Pens.Black, qtyColumn1X - 5, yPos - 2 - lineHeight, qtyColumn1X - 5, yPos)
                                               ev.Graphics.DrawLine(Pens.Black, moldColumn3X - 3, yPos - 2 - lineHeight, moldColumn3X - 3, yPos)
                                               ev.Graphics.DrawLine(Pens.Black, qtyColumn2X - 5, yPos - 2 - lineHeight, qtyColumn2X - 5, yPos)
                                               ev.Graphics.DrawLine(Pens.Black, moldColumn1X + 714, yPos - 2 - lineHeight, moldColumn1X + 714, yPos) 'ultima linea para cerrar la tabla

                                               yPos += lineHeight
                                           Next
                                           ev.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + tableWidth, yPos) 'la ultima linea acostada de la tabla
                                           ev.Graphics.DrawLine(Pens.Black, moldColumn1X, yPos - 2 - lineHeight, moldColumn1X, yPos) 'ultima linea de lado izq de date
                                           ev.Graphics.DrawLine(Pens.Black, moldColumn2X, yPos - 2 - lineHeight, moldColumn2X, yPos) ' ultima linea de lado izq de a&b
                                           ev.Graphics.DrawLine(Pens.Black, qtyColumn1X - 5, yPos - 2 - lineHeight, qtyColumn1X - 5, yPos) 'ultima linea de lado de a&b
                                           ev.Graphics.DrawLine(Pens.Black, moldColumn3X - 3, yPos - 2 - lineHeight, moldColumn3X - 3, yPos) 'ultima linea de lado de qty de a&b
                                           ev.Graphics.DrawLine(Pens.Black, qtyColumn2X - 5, yPos - 2 - lineHeight, qtyColumn2X - 5, yPos) 'ultima linea de lado derecho de c&d
                                           ev.Graphics.DrawLine(Pens.Black, qtyColumn2X + 75, yPos - 2 - lineHeight, qtyColumn2X + 75, yPos)


                                       End Sub

        Dim printPreviewDialog As New PrintPreviewDialog()
        printPreviewDialog.Document = printDoc
        printPreviewDialog.ShowDialog()
    End Sub
    Private Sub PrintMold5ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintMold5ToolStripMenuItem.Click
        SavePanels()
        Dim query5AB As String = "SELECT [ASGMT Date], [Panel], [Qty] FROM [Molds] WHERE [Mold] = 'DGV_M5AB_W' AND [Estatus] = 'NUEVO' ORDER BY [ASGMT Date] ASC"
        Dim query5CD As String = "SELECT [ASGMT Date], [Panel], [Qty] FROM [Molds] WHERE [Mold] = 'DGV_M5CD_W' AND [Estatus] = 'NUEVO' ORDER BY [ASGMT Date] ASC"

        Dim dtAB As New DataTable()
        Dim dtCD As New DataTable()

        Using connection As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(query5AB, connection)
                connection.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dtAB.Load(reader)
                End Using
            End Using
        End Using

        Using connection As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(query5CD, connection)
                connection.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dtCD.Load(reader)
                End Using
            End Using
        End Using

        Dim printDoc As New Printing.PrintDocument()
        AddHandler printDoc.PrintPage, Sub(s, ev)

                                           Dim leftMargin As Single = 50
                                           Dim rightMargin As Single = 50
                                           Dim topMargin As Single = 10
                                           Dim bottomMargin As Single = 20

                                           Dim effectiveWidth As Single = ev.PageBounds.Width - leftMargin - rightMargin
                                           Dim effectiveHeight As Single = ev.PageBounds.Height - topMargin - bottomMargin

                                           Dim recordFont As New Font("Arial", 12)
                                           Dim yPos As Single = ev.MarginBounds.Top
                                           Dim lineHeight As Single = ev.Graphics.MeasureString("Sample Text", recordFont).Height

                                           Dim headerFont As New Font("Arial", 20, FontStyle.Bold)
                                           Dim headerText As String = "Walls"
                                           Dim headerWidth As Single = ev.Graphics.MeasureString(headerText, headerFont).Width
                                           Dim centerX As Single = (ev.PageBounds.Width - headerWidth) / 2
                                           ev.Graphics.DrawString(headerText, headerFont, Brushes.Black, centerX, yPos)
                                           yPos += headerFont.GetHeight(ev.Graphics) + 20

                                           Dim columnHeaderFont As New Font("Arial", 14, FontStyle.Bold)
                                           Dim columnHeaderYPos As Single = yPos

                                           Dim moldColumn1X As Single = leftMargin
                                           Dim moldColumn2X As Single = moldColumn1X + 125
                                           Dim qtyColumn1X As Single = moldColumn2X + 227
                                           Dim moldColumn3X As Single = qtyColumn1X + 62
                                           Dim qtyColumn2X As Single = moldColumn3X + 225
                                           Dim tableWidth As Single = qtyColumn2X + 75 - leftMargin

                                           ev.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + tableWidth, yPos)

                                           ev.Graphics.DrawString("Date", columnHeaderFont, Brushes.Black, leftMargin, yPos)
                                           ev.Graphics.DrawString("Mold 1 A&B", columnHeaderFont, Brushes.Black, leftMargin + 160, yPos)
                                           ev.Graphics.DrawString("Qty", columnHeaderFont, Brushes.Black, leftMargin + 347, yPos)
                                           ev.Graphics.DrawString("Mold 1 C&D", columnHeaderFont, Brushes.Black, leftMargin + 443, yPos)
                                           ev.Graphics.DrawString("Qty", columnHeaderFont, Brushes.Black, leftMargin + 635, yPos)
                                           yPos += lineHeight

                                           yPos += 2

                                           ev.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + tableWidth, yPos)


                                           Dim maxRows As Integer = Math.Max(dtAB.Rows.Count, dtCD.Rows.Count)
                                           For i As Integer = 0 To maxRows - 1
                                               Dim cutDateAB As String = If(i < dtAB.Rows.Count, Convert.ToDateTime(dtAB.Rows(i)("ASGMT Date")).ToString("MM/dd/yyyy"), "")
                                               Dim panelAB As String = If(i < dtAB.Rows.Count, dtAB.Rows(i)("Panel").ToString(), "")
                                               Dim qtyAB As String = If(i < dtAB.Rows.Count, dtAB.Rows(i)("Qty").ToString(), "")

                                               Dim cutDateCD As String = If(i < dtCD.Rows.Count, Convert.ToDateTime(dtCD.Rows(i)("ASGMT Date")).ToString("MM/dd/yyyy"), "")
                                               Dim panelCD As String = If(i < dtCD.Rows.Count, dtCD.Rows(i)("Panel").ToString(), "")
                                               Dim qtyCD As String = If(i < dtCD.Rows.Count, dtCD.Rows(i)("Qty").ToString(), "")

                                               ev.Graphics.DrawString(cutDateAB, recordFont, Brushes.Black, moldColumn1X, yPos) 'fechas
                                               ev.Graphics.DrawString(panelAB, recordFont, Brushes.Black, moldColumn2X, yPos) 'paneles de a&b
                                               ev.Graphics.DrawString(qtyAB, recordFont, Brushes.Black, qtyColumn1X, yPos) 'qty de a&b
                                               ev.Graphics.DrawString(panelCD, recordFont, Brushes.Black, moldColumn3X, yPos) 'paneles de c&d
                                               ev.Graphics.DrawString(qtyCD, recordFont, Brushes.Black, qtyColumn2X, yPos) 'qty de c&d
                                               ev.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + tableWidth, yPos) 'separadores de renglones


                                               ev.Graphics.DrawLine(Pens.Black, moldColumn1X, yPos - 2 - lineHeight, moldColumn1X, yPos) 'primer linea parada a partir de Date
                                               ev.Graphics.DrawLine(Pens.Black, moldColumn2X, yPos - 2 - lineHeight, moldColumn2X, yPos)
                                               ev.Graphics.DrawLine(Pens.Black, qtyColumn1X - 5, yPos - 2 - lineHeight, qtyColumn1X - 5, yPos)
                                               ev.Graphics.DrawLine(Pens.Black, moldColumn3X - 3, yPos - 2 - lineHeight, moldColumn3X - 3, yPos)
                                               ev.Graphics.DrawLine(Pens.Black, qtyColumn2X - 5, yPos - 2 - lineHeight, qtyColumn2X - 5, yPos)
                                               ev.Graphics.DrawLine(Pens.Black, moldColumn1X + 714, yPos - 2 - lineHeight, moldColumn1X + 714, yPos) 'ultima linea para cerrar la tabla

                                               yPos += lineHeight
                                           Next
                                           ev.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + tableWidth, yPos) 'la ultima linea acostada de la tabla
                                           ev.Graphics.DrawLine(Pens.Black, moldColumn1X, yPos - 2 - lineHeight, moldColumn1X, yPos) 'ultima linea de lado izq de date
                                           ev.Graphics.DrawLine(Pens.Black, moldColumn2X, yPos - 2 - lineHeight, moldColumn2X, yPos) ' ultima linea de lado izq de a&b
                                           ev.Graphics.DrawLine(Pens.Black, qtyColumn1X - 5, yPos - 2 - lineHeight, qtyColumn1X - 5, yPos) 'ultima linea de lado de a&b
                                           ev.Graphics.DrawLine(Pens.Black, moldColumn3X - 3, yPos - 2 - lineHeight, moldColumn3X - 3, yPos) 'ultima linea de lado de qty de a&b
                                           ev.Graphics.DrawLine(Pens.Black, qtyColumn2X - 5, yPos - 2 - lineHeight, qtyColumn2X - 5, yPos) 'ultima linea de lado derecho de c&d
                                           ev.Graphics.DrawLine(Pens.Black, qtyColumn2X + 75, yPos - 2 - lineHeight, qtyColumn2X + 75, yPos)


                                       End Sub

        Dim printPreviewDialog As New PrintPreviewDialog()
        printPreviewDialog.Document = printDoc
        printPreviewDialog.ShowDialog()
    End Sub
    Private Sub PrintMold6ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintMold6ToolStripMenuItem.Click
        SavePanels()
        Dim query6AB As String = "SELECT [ASGMT Date], [Panel], [Qty] FROM [Molds] WHERE [Mold] = 'DGV_M6AB_W' AND [Estatus] = 'NUEVO' ORDER BY [ASGMT Date] ASC"
        Dim query6CD As String = "SELECT [ASGMT Date], [Panel], [Qty] FROM [Molds] WHERE [Mold] = 'DGV_M6CD_W' AND [Estatus] = 'NUEVO' ORDER BY [ASGMT Date] ASC"

        Dim dtAB As New DataTable()
        Dim dtCD As New DataTable()

        Using connection As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(query6AB, connection)
                connection.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dtAB.Load(reader)
                End Using
            End Using
        End Using

        Using connection As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(query6CD, connection)
                connection.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dtCD.Load(reader)
                End Using
            End Using
        End Using

        Dim printDoc As New Printing.PrintDocument()
        AddHandler printDoc.PrintPage, Sub(s, ev)

                                           Dim leftMargin As Single = 50
                                           Dim rightMargin As Single = 50
                                           Dim topMargin As Single = 10
                                           Dim bottomMargin As Single = 20

                                           Dim effectiveWidth As Single = ev.PageBounds.Width - leftMargin - rightMargin
                                           Dim effectiveHeight As Single = ev.PageBounds.Height - topMargin - bottomMargin

                                           Dim recordFont As New Font("Arial", 12)
                                           Dim yPos As Single = ev.MarginBounds.Top
                                           Dim lineHeight As Single = ev.Graphics.MeasureString("Sample Text", recordFont).Height

                                           Dim headerFont As New Font("Arial", 20, FontStyle.Bold)
                                           Dim headerText As String = "Walls"
                                           Dim headerWidth As Single = ev.Graphics.MeasureString(headerText, headerFont).Width
                                           Dim centerX As Single = (ev.PageBounds.Width - headerWidth) / 2
                                           ev.Graphics.DrawString(headerText, headerFont, Brushes.Black, centerX, yPos)
                                           yPos += headerFont.GetHeight(ev.Graphics) + 20

                                           Dim columnHeaderFont As New Font("Arial", 14, FontStyle.Bold)
                                           Dim columnHeaderYPos As Single = yPos

                                           Dim moldColumn1X As Single = leftMargin
                                           Dim moldColumn2X As Single = moldColumn1X + 125
                                           Dim qtyColumn1X As Single = moldColumn2X + 227
                                           Dim moldColumn3X As Single = qtyColumn1X + 62
                                           Dim qtyColumn2X As Single = moldColumn3X + 225
                                           Dim tableWidth As Single = qtyColumn2X + 75 - leftMargin

                                           ev.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + tableWidth, yPos)

                                           ev.Graphics.DrawString("Date", columnHeaderFont, Brushes.Black, leftMargin, yPos)
                                           ev.Graphics.DrawString("Mold 1 A&B", columnHeaderFont, Brushes.Black, leftMargin + 160, yPos)
                                           ev.Graphics.DrawString("Qty", columnHeaderFont, Brushes.Black, leftMargin + 347, yPos)
                                           ev.Graphics.DrawString("Mold 1 C&D", columnHeaderFont, Brushes.Black, leftMargin + 443, yPos)
                                           ev.Graphics.DrawString("Qty", columnHeaderFont, Brushes.Black, leftMargin + 635, yPos)
                                           yPos += lineHeight

                                           yPos += 2

                                           ev.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + tableWidth, yPos)


                                           Dim maxRows As Integer = Math.Max(dtAB.Rows.Count, dtCD.Rows.Count)
                                           For i As Integer = 0 To maxRows - 1
                                               Dim cutDateAB As String = If(i < dtAB.Rows.Count, Convert.ToDateTime(dtAB.Rows(i)("ASGMT Date")).ToString("MM/dd/yyyy"), "")
                                               Dim panelAB As String = If(i < dtAB.Rows.Count, dtAB.Rows(i)("Panel").ToString(), "")
                                               Dim qtyAB As String = If(i < dtAB.Rows.Count, dtAB.Rows(i)("Qty").ToString(), "")

                                               Dim cutDateCD As String = If(i < dtCD.Rows.Count, Convert.ToDateTime(dtCD.Rows(i)("ASGMT Date")).ToString("MM/dd/yyyy"), "")
                                               Dim panelCD As String = If(i < dtCD.Rows.Count, dtCD.Rows(i)("Panel").ToString(), "")
                                               Dim qtyCD As String = If(i < dtCD.Rows.Count, dtCD.Rows(i)("Qty").ToString(), "")

                                               ev.Graphics.DrawString(cutDateAB, recordFont, Brushes.Black, moldColumn1X, yPos) 'fechas
                                               ev.Graphics.DrawString(panelAB, recordFont, Brushes.Black, moldColumn2X, yPos) 'paneles de a&b
                                               ev.Graphics.DrawString(qtyAB, recordFont, Brushes.Black, qtyColumn1X, yPos) 'qty de a&b
                                               ev.Graphics.DrawString(panelCD, recordFont, Brushes.Black, moldColumn3X, yPos) 'paneles de c&d
                                               ev.Graphics.DrawString(qtyCD, recordFont, Brushes.Black, qtyColumn2X, yPos) 'qty de c&d
                                               ev.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + tableWidth, yPos) 'separadores de renglones


                                               ev.Graphics.DrawLine(Pens.Black, moldColumn1X, yPos - 2 - lineHeight, moldColumn1X, yPos) 'primer linea parada a partir de Date
                                               ev.Graphics.DrawLine(Pens.Black, moldColumn2X, yPos - 2 - lineHeight, moldColumn2X, yPos)
                                               ev.Graphics.DrawLine(Pens.Black, qtyColumn1X - 5, yPos - 2 - lineHeight, qtyColumn1X - 5, yPos)
                                               ev.Graphics.DrawLine(Pens.Black, moldColumn3X - 3, yPos - 2 - lineHeight, moldColumn3X - 3, yPos)
                                               ev.Graphics.DrawLine(Pens.Black, qtyColumn2X - 5, yPos - 2 - lineHeight, qtyColumn2X - 5, yPos)
                                               ev.Graphics.DrawLine(Pens.Black, moldColumn1X + 714, yPos - 2 - lineHeight, moldColumn1X + 714, yPos) 'ultima linea para cerrar la tabla

                                               yPos += lineHeight
                                           Next
                                           ev.Graphics.DrawLine(Pens.Black, leftMargin, yPos, leftMargin + tableWidth, yPos) 'la ultima linea acostada de la tabla
                                           ev.Graphics.DrawLine(Pens.Black, moldColumn1X, yPos - 2 - lineHeight, moldColumn1X, yPos) 'ultima linea de lado izq de date
                                           ev.Graphics.DrawLine(Pens.Black, moldColumn2X, yPos - 2 - lineHeight, moldColumn2X, yPos) ' ultima linea de lado izq de a&b
                                           ev.Graphics.DrawLine(Pens.Black, qtyColumn1X - 5, yPos - 2 - lineHeight, qtyColumn1X - 5, yPos) 'ultima linea de lado de a&b
                                           ev.Graphics.DrawLine(Pens.Black, moldColumn3X - 3, yPos - 2 - lineHeight, moldColumn3X - 3, yPos) 'ultima linea de lado de qty de a&b
                                           ev.Graphics.DrawLine(Pens.Black, qtyColumn2X - 5, yPos - 2 - lineHeight, qtyColumn2X - 5, yPos) 'ultima linea de lado derecho de c&d
                                           ev.Graphics.DrawLine(Pens.Black, qtyColumn2X + 75, yPos - 2 - lineHeight, qtyColumn2X + 75, yPos)


                                       End Sub

        Dim printPreviewDialog As New PrintPreviewDialog()
        printPreviewDialog.Document = printDoc
        printPreviewDialog.ShowDialog()
    End Sub
    Private Sub PrintOldMold1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintOldMold1ToolStripMenuItem.Click
        SavePanels()
        Dim queryAB As String = "SELECT [ASGMT Date], [Panel], [Qty] FROM [Molds] WHERE [Mold] = 'DGV_OM1_W' AND [Estatus] = 'NUEVO' ORDER BY [ASGMT Date] ASC"
        Dim dtAB As New DataTable()

        Using connection As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(queryAB, connection)
                connection.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dtAB.Load(reader)
                End Using
            End Using
        End Using

        Dim printDoc As New Printing.PrintDocument()
        AddHandler printDoc.PrintPage, Sub(s, ev)

                                           Dim leftMargin As Single = 50
                                           Dim rightMargin As Single = 50
                                           Dim topMargin As Single = 10
                                           Dim bottomMargin As Single = 20

                                           Dim effectiveWidth As Single = ev.PageBounds.Width - leftMargin - rightMargin
                                           Dim effectiveHeight As Single = ev.PageBounds.Height - topMargin - bottomMargin

                                           Dim recordFont As New Font("Arial", 12)
                                           Dim yPos As Single = ev.MarginBounds.Top
                                           Dim lineHeight As Single = ev.Graphics.MeasureString("Sample Text", recordFont).Height

                                           Dim headerFont As New Font("Arial", 20, FontStyle.Bold)
                                           Dim headerText As String = "Walls"
                                           Dim headerWidth As Single = ev.Graphics.MeasureString(headerText, headerFont).Width
                                           Dim centerX As Single = (ev.PageBounds.Width - headerWidth) / 2
                                           ev.Graphics.DrawString(headerText, headerFont, Brushes.Black, centerX, yPos)
                                           yPos += headerFont.GetHeight(ev.Graphics) + 20

                                           Dim columnHeaderFont As New Font("Arial", 14, FontStyle.Bold)
                                           Dim columnHeaderYPos As Single = yPos

                                           ' Ancho de las columnas
                                           Dim dateColumnWidth As Single = 160
                                           Dim panelColumnWidth As Single = 380
                                           Dim qtyColumnWidth As Single = 160
                                           Dim tableWidth As Single = dateColumnWidth + panelColumnWidth + qtyColumnWidth

                                           ' Calcula la posición inicial de la tabla para centrarla
                                           Dim tableStartX As Single = (ev.PageBounds.Width - tableWidth) / 2

                                           ' Dibuja la línea superior de la tabla
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX + tableWidth, yPos)

                                           ' Encabezados de las columnas
                                           ev.Graphics.DrawString("Date", columnHeaderFont, Brushes.Black, tableStartX, yPos)
                                           ev.Graphics.DrawString("Old Mold 1", columnHeaderFont, Brushes.Black, tableStartX + dateColumnWidth, yPos)
                                           ev.Graphics.DrawString("Qty", columnHeaderFont, Brushes.Black, tableStartX + dateColumnWidth + panelColumnWidth, yPos)
                                           yPos += lineHeight

                                           yPos += 2

                                           ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX + tableWidth, yPos)

                                           Dim maxRows As Integer = dtAB.Rows.Count
                                           For i As Integer = 0 To maxRows - 1
                                               Dim cutDateAB As String = If(i < dtAB.Rows.Count, Convert.ToDateTime(dtAB.Rows(i)("ASGMT Date")).ToString("MM/dd/yyyy"), "")
                                               Dim panelAB As String = If(i < dtAB.Rows.Count, dtAB.Rows(i)("Panel").ToString(), "")
                                               Dim qtyAB As String = If(i < dtAB.Rows.Count, dtAB.Rows(i)("Qty").ToString(), "")

                                               ev.Graphics.DrawString(cutDateAB, recordFont, Brushes.Black, tableStartX, yPos) 'fechas
                                               ev.Graphics.DrawString(panelAB, recordFont, Brushes.Black, tableStartX + dateColumnWidth, yPos) 'paneles de a&b
                                               ev.Graphics.DrawString(qtyAB, recordFont, Brushes.Black, tableStartX + dateColumnWidth + panelColumnWidth, yPos) 'qty de a&b

                                               ' Línea horizontal bajo la fila actual
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos + lineHeight, tableStartX + tableWidth, yPos + lineHeight)

                                               ' Líneas verticales
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX, yPos + lineHeight) ' borde izquierdo de "Date"
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth, yPos, tableStartX + dateColumnWidth, yPos + lineHeight) ' borde izquierdo de "Old Mold 1"
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth + panelColumnWidth, yPos, tableStartX + dateColumnWidth + panelColumnWidth, yPos + lineHeight) ' borde izquierdo de "Qty"
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX + tableWidth, yPos, tableStartX + tableWidth, yPos + lineHeight) ' borde derecho final

                                               yPos += lineHeight
                                           Next

                                           ' Líneas de cierre final
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX + tableWidth, yPos) ' última línea horizontal
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX, columnHeaderYPos, tableStartX, yPos) ' línea vertical izquierda
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth, columnHeaderYPos, tableStartX + dateColumnWidth, yPos) ' línea entre columnas
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth + panelColumnWidth, columnHeaderYPos, tableStartX + dateColumnWidth + panelColumnWidth, yPos) ' línea entre columnas
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX + tableWidth, columnHeaderYPos, tableStartX + tableWidth, yPos) ' línea derecha

                                       End Sub

        Dim printPreviewDialog As New PrintPreviewDialog()
        printPreviewDialog.Document = printDoc
        printPreviewDialog.ShowDialog()
    End Sub
    Private Sub PrintOldMold2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintOldMold2ToolStripMenuItem.Click
        SavePanels()
        Dim queryAB As String = "SELECT [ASGMT Date], [Panel], [Qty] FROM [Molds] WHERE [Mold] = 'DGV_OM2_W' AND [Estatus] = 'NUEVO' ORDER BY [ASGMT Date] ASC"
        Dim dtAB As New DataTable()

        Using connection As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(queryAB, connection)
                connection.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dtAB.Load(reader)
                End Using
            End Using
        End Using

        Dim printDoc As New Printing.PrintDocument()
        AddHandler printDoc.PrintPage, Sub(s, ev)

                                           Dim leftMargin As Single = 50
                                           Dim rightMargin As Single = 50
                                           Dim topMargin As Single = 10
                                           Dim bottomMargin As Single = 20

                                           Dim effectiveWidth As Single = ev.PageBounds.Width - leftMargin - rightMargin
                                           Dim effectiveHeight As Single = ev.PageBounds.Height - topMargin - bottomMargin

                                           Dim recordFont As New Font("Arial", 12)
                                           Dim yPos As Single = ev.MarginBounds.Top
                                           Dim lineHeight As Single = ev.Graphics.MeasureString("Sample Text", recordFont).Height

                                           Dim headerFont As New Font("Arial", 20, FontStyle.Bold)
                                           Dim headerText As String = "Walls"
                                           Dim headerWidth As Single = ev.Graphics.MeasureString(headerText, headerFont).Width
                                           Dim centerX As Single = (ev.PageBounds.Width - headerWidth) / 2
                                           ev.Graphics.DrawString(headerText, headerFont, Brushes.Black, centerX, yPos)
                                           yPos += headerFont.GetHeight(ev.Graphics) + 20

                                           Dim columnHeaderFont As New Font("Arial", 14, FontStyle.Bold)
                                           Dim columnHeaderYPos As Single = yPos

                                           ' Ancho de las columnas
                                           Dim dateColumnWidth As Single = 160
                                           Dim panelColumnWidth As Single = 380
                                           Dim qtyColumnWidth As Single = 160
                                           Dim tableWidth As Single = dateColumnWidth + panelColumnWidth + qtyColumnWidth

                                           ' Calcula la posición inicial de la tabla para centrarla
                                           Dim tableStartX As Single = (ev.PageBounds.Width - tableWidth) / 2

                                           ' Dibuja la línea superior de la tabla
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX + tableWidth, yPos)

                                           ' Encabezados de las columnas
                                           ev.Graphics.DrawString("Date", columnHeaderFont, Brushes.Black, tableStartX, yPos)
                                           ev.Graphics.DrawString("Old Mold 1", columnHeaderFont, Brushes.Black, tableStartX + dateColumnWidth, yPos)
                                           ev.Graphics.DrawString("Qty", columnHeaderFont, Brushes.Black, tableStartX + dateColumnWidth + panelColumnWidth, yPos)
                                           yPos += lineHeight

                                           yPos += 2

                                           ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX + tableWidth, yPos)

                                           Dim maxRows As Integer = dtAB.Rows.Count
                                           For i As Integer = 0 To maxRows - 1
                                               Dim cutDateAB As String = If(i < dtAB.Rows.Count, Convert.ToDateTime(dtAB.Rows(i)("ASGMT Date")).ToString("MM/dd/yyyy"), "")
                                               Dim panelAB As String = If(i < dtAB.Rows.Count, dtAB.Rows(i)("Panel").ToString(), "")
                                               Dim qtyAB As String = If(i < dtAB.Rows.Count, dtAB.Rows(i)("Qty").ToString(), "")

                                               ev.Graphics.DrawString(cutDateAB, recordFont, Brushes.Black, tableStartX, yPos) 'fechas
                                               ev.Graphics.DrawString(panelAB, recordFont, Brushes.Black, tableStartX + dateColumnWidth, yPos) 'paneles de a&b
                                               ev.Graphics.DrawString(qtyAB, recordFont, Brushes.Black, tableStartX + dateColumnWidth + panelColumnWidth, yPos) 'qty de a&b

                                               ' Línea horizontal bajo la fila actual
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos + lineHeight, tableStartX + tableWidth, yPos + lineHeight)

                                               ' Líneas verticales
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX, yPos + lineHeight) ' borde izquierdo de "Date"
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth, yPos, tableStartX + dateColumnWidth, yPos + lineHeight) ' borde izquierdo de "Old Mold 1"
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth + panelColumnWidth, yPos, tableStartX + dateColumnWidth + panelColumnWidth, yPos + lineHeight) ' borde izquierdo de "Qty"
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX + tableWidth, yPos, tableStartX + tableWidth, yPos + lineHeight) ' borde derecho final

                                               yPos += lineHeight
                                           Next

                                           ' Líneas de cierre final
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX + tableWidth, yPos) ' última línea horizontal
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX, columnHeaderYPos, tableStartX, yPos) ' línea vertical izquierda
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth, columnHeaderYPos, tableStartX + dateColumnWidth, yPos) ' línea entre columnas
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth + panelColumnWidth, columnHeaderYPos, tableStartX + dateColumnWidth + panelColumnWidth, yPos) ' línea entre columnas
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX + tableWidth, columnHeaderYPos, tableStartX + tableWidth, yPos) ' línea derecha

                                       End Sub

        Dim printPreviewDialog As New PrintPreviewDialog()
        printPreviewDialog.Document = printDoc
        printPreviewDialog.ShowDialog()
    End Sub
    Private Sub PrintOldMold3ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintOldMold3ToolStripMenuItem.Click
        SavePanels()
        Dim queryAB As String = "SELECT [ASGMT Date], [Panel], [Qty] FROM [Molds] WHERE [Mold] = 'DGV_OM3_W' AND [Estatus] = 'NUEVO' ORDER BY [ASGMT Date] ASC"
        Dim dtAB As New DataTable()

        Using connection As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(queryAB, connection)
                connection.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dtAB.Load(reader)
                End Using
            End Using
        End Using

        Dim printDoc As New Printing.PrintDocument()
        AddHandler printDoc.PrintPage, Sub(s, ev)

                                           Dim leftMargin As Single = 50
                                           Dim rightMargin As Single = 50
                                           Dim topMargin As Single = 10
                                           Dim bottomMargin As Single = 20

                                           Dim effectiveWidth As Single = ev.PageBounds.Width - leftMargin - rightMargin
                                           Dim effectiveHeight As Single = ev.PageBounds.Height - topMargin - bottomMargin

                                           Dim recordFont As New Font("Arial", 12)
                                           Dim yPos As Single = ev.MarginBounds.Top
                                           Dim lineHeight As Single = ev.Graphics.MeasureString("Sample Text", recordFont).Height

                                           Dim headerFont As New Font("Arial", 20, FontStyle.Bold)
                                           Dim headerText As String = "Walls"
                                           Dim headerWidth As Single = ev.Graphics.MeasureString(headerText, headerFont).Width
                                           Dim centerX As Single = (ev.PageBounds.Width - headerWidth) / 2
                                           ev.Graphics.DrawString(headerText, headerFont, Brushes.Black, centerX, yPos)
                                           yPos += headerFont.GetHeight(ev.Graphics) + 20

                                           Dim columnHeaderFont As New Font("Arial", 14, FontStyle.Bold)
                                           Dim columnHeaderYPos As Single = yPos

                                           ' Ancho de las columnas
                                           Dim dateColumnWidth As Single = 160
                                           Dim panelColumnWidth As Single = 380
                                           Dim qtyColumnWidth As Single = 160
                                           Dim tableWidth As Single = dateColumnWidth + panelColumnWidth + qtyColumnWidth

                                           ' Calcula la posición inicial de la tabla para centrarla
                                           Dim tableStartX As Single = (ev.PageBounds.Width - tableWidth) / 2

                                           ' Dibuja la línea superior de la tabla
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX + tableWidth, yPos)

                                           ' Encabezados de las columnas
                                           ev.Graphics.DrawString("Date", columnHeaderFont, Brushes.Black, tableStartX, yPos)
                                           ev.Graphics.DrawString("Old Mold 1", columnHeaderFont, Brushes.Black, tableStartX + dateColumnWidth, yPos)
                                           ev.Graphics.DrawString("Qty", columnHeaderFont, Brushes.Black, tableStartX + dateColumnWidth + panelColumnWidth, yPos)
                                           yPos += lineHeight

                                           yPos += 2

                                           ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX + tableWidth, yPos)

                                           Dim maxRows As Integer = dtAB.Rows.Count
                                           For i As Integer = 0 To maxRows - 1
                                               Dim cutDateAB As String = If(i < dtAB.Rows.Count, Convert.ToDateTime(dtAB.Rows(i)("ASGMT Date")).ToString("MM/dd/yyyy"), "")
                                               Dim panelAB As String = If(i < dtAB.Rows.Count, dtAB.Rows(i)("Panel").ToString(), "")
                                               Dim qtyAB As String = If(i < dtAB.Rows.Count, dtAB.Rows(i)("Qty").ToString(), "")

                                               ev.Graphics.DrawString(cutDateAB, recordFont, Brushes.Black, tableStartX, yPos) 'fechas
                                               ev.Graphics.DrawString(panelAB, recordFont, Brushes.Black, tableStartX + dateColumnWidth, yPos) 'paneles de a&b
                                               ev.Graphics.DrawString(qtyAB, recordFont, Brushes.Black, tableStartX + dateColumnWidth + panelColumnWidth, yPos) 'qty de a&b

                                               ' Línea horizontal bajo la fila actual
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos + lineHeight, tableStartX + tableWidth, yPos + lineHeight)

                                               ' Líneas verticales
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX, yPos + lineHeight) ' borde izquierdo de "Date"
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth, yPos, tableStartX + dateColumnWidth, yPos + lineHeight) ' borde izquierdo de "Old Mold 1"
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth + panelColumnWidth, yPos, tableStartX + dateColumnWidth + panelColumnWidth, yPos + lineHeight) ' borde izquierdo de "Qty"
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX + tableWidth, yPos, tableStartX + tableWidth, yPos + lineHeight) ' borde derecho final

                                               yPos += lineHeight
                                           Next

                                           ' Líneas de cierre final
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX + tableWidth, yPos) ' última línea horizontal
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX, columnHeaderYPos, tableStartX, yPos) ' línea vertical izquierda
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth, columnHeaderYPos, tableStartX + dateColumnWidth, yPos) ' línea entre columnas
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth + panelColumnWidth, columnHeaderYPos, tableStartX + dateColumnWidth + panelColumnWidth, yPos) ' línea entre columnas
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX + tableWidth, columnHeaderYPos, tableStartX + tableWidth, yPos) ' línea derecha

                                       End Sub

        Dim printPreviewDialog As New PrintPreviewDialog()
        printPreviewDialog.Document = printDoc
        printPreviewDialog.ShowDialog()
    End Sub
    Private Sub PrintAllMoldsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrintAllMoldsToolStripMenuItem.Click
        SavePanels()

        Dim queryAB As String = "SELECT [ASGMT Date], [Mold], [Panel], [Qty] " &
                        "FROM [Molds] " &
                        "WHERE ([Mold] = 'DGV_M1AB_W' OR [Mold] = 'DGV_M1CD_W' OR [Mold] = 'DGV_M2AB_W' OR [Mold] = 'DGV_M2CD_W' OR [Mold] = 'DGV_M3AB_W' OR [Mold] = 'DGV_M3CD_W' OR [Mold] = 'DGV_M4AB_W' OR [Mold] = 'DGV_M4CD_W' OR [Mold] = 'DGV_M5AB_W' OR [Mold] = 'DGV_M5CD_W' OR [Mold] = 'DGV_M6AB_W' OR [Mold] = 'DGV_M6CD_W' OR [Mold] = 'DGV_OM1_W' OR [Mold] = 'DGV_OM2_W' OR [Mold] = 'DGV_OM3_W') " &
                        "AND [Estatus] = 'NUEVO' " &
                        "ORDER BY CONVERT(date, [ASGMT Date]) ASC, [Mold] ASC"

        Dim dtAB As New DataTable()

        Using connection As New SqlConnection(ConnectionString)
            Using cmd As New SqlCommand(queryAB, connection)
                connection.Open()
                Using reader As SqlDataReader = cmd.ExecuteReader()
                    dtAB.Load(reader)
                End Using
            End Using
        End Using

        Dim printDoc As New Printing.PrintDocument()
        AddHandler printDoc.PrintPage, Sub(s, ev)

                                           Dim leftMargin As Single = 50
                                           Dim rightMargin As Single = 50
                                           Dim topMargin As Single = 10
                                           Dim bottomMargin As Single = 20

                                           Dim effectiveWidth As Single = ev.PageBounds.Width - leftMargin - rightMargin
                                           Dim effectiveHeight As Single = ev.PageBounds.Height - topMargin - bottomMargin

                                           Dim recordFont As New Font("Arial", 12)
                                           Dim yPos As Single = ev.MarginBounds.Top
                                           Dim lineHeight As Single = ev.Graphics.MeasureString("Sample Text", recordFont).Height

                                           Dim headerFont As New Font("Arial", 20, FontStyle.Bold)
                                           Dim headerText As String = "Walls"
                                           Dim headerWidth As Single = ev.Graphics.MeasureString(headerText, headerFont).Width
                                           Dim centerX As Single = (ev.PageBounds.Width - headerWidth) / 2
                                           ev.Graphics.DrawString(headerText, headerFont, Brushes.Black, centerX, yPos)
                                           yPos += headerFont.GetHeight(ev.Graphics) + 20

                                           Dim columnHeaderFont As New Font("Arial", 14, FontStyle.Bold)
                                           Dim columnHeaderYPos As Single = yPos

                                           ' Ancho de las columnas
                                           Dim dateColumnWidth As Single = 130
                                           Dim moldColumnWidth As Single = 160
                                           Dim panelColumnWidth As Single = 310
                                           Dim qtyColumnWidth As Single = 100
                                           Dim tableWidth As Single = dateColumnWidth + moldColumnWidth + panelColumnWidth + qtyColumnWidth

                                           ' Calcula la posición inicial de la tabla para centrarla
                                           Dim tableStartX As Single = (ev.PageBounds.Width - tableWidth) / 2

                                           ' Dibuja la línea superior de la tabla
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX + tableWidth, yPos)

                                           ' Encabezados de las columnas
                                           ev.Graphics.DrawString("Date", columnHeaderFont, Brushes.Black, tableStartX, yPos)
                                           ev.Graphics.DrawString("Mold", columnHeaderFont, Brushes.Black, tableStartX + dateColumnWidth, yPos)
                                           ev.Graphics.DrawString("Panel", columnHeaderFont, Brushes.Black, tableStartX + dateColumnWidth + moldColumnWidth, yPos)
                                           ev.Graphics.DrawString("Qty", columnHeaderFont, Brushes.Black, tableStartX + dateColumnWidth + moldColumnWidth + panelColumnWidth, yPos)
                                           yPos += lineHeight

                                           yPos += 2

                                           ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX + tableWidth, yPos)

                                           Dim maxRows As Integer = dtAB.Rows.Count
                                           For i As Integer = 0 To maxRows - 1
                                               Dim cutDateAB As String = If(i < dtAB.Rows.Count, Convert.ToDateTime(dtAB.Rows(i)("ASGMT Date")).ToString("MM/dd/yyyy"), "")
                                               Dim mold As String = If(i < dtAB.Rows.Count, dtAB.Rows(i)("Mold").ToString(), "")
                                               Dim panel As String = If(i < dtAB.Rows.Count, dtAB.Rows(i)("Panel").ToString(), "")
                                               Dim qty As String = If(i < dtAB.Rows.Count, dtAB.Rows(i)("Qty").ToString(), "")

                                               Select Case mold
                                                   Case "DGV_M1AB_W"
                                                       mold = "Mold 1 A&B"
                                                   Case "DGV_M1CD_W"
                                                       mold = "Mold 1 C&D"
                                                   Case "DGV_M2AB_W"
                                                       mold = "Mold 2 A&B"
                                                   Case "DGV_M2CD_W"
                                                       mold = "Mold 2 C&D"
                                                   Case "DGV_M3AB_W"
                                                       mold = "Mold 3 A&B"
                                                   Case "DGV_M3CD_W"
                                                       mold = "Mold 3 C&D"
                                                   Case "DGV_M4AB_W"
                                                       mold = "Mold 4 A&B"
                                                   Case "DGV_M4CD_W"
                                                       mold = "Mold 4 C&D"
                                                   Case "DGV_M5AB_W"
                                                       mold = "Mold 5 A&B"
                                                   Case "DGV_M5CD_W"
                                                       mold = "Mold 5 C&D"
                                                   Case "DGV_M6AB_W"
                                                       mold = "Mold 6 A&B"
                                                   Case "DGV_M6CD_W"
                                                       mold = "Mold 6 C&D"
                                                   Case "DGV_OM1_W"
                                                       mold = "Old Mold 1"
                                                   Case "DGV_OM2_W"
                                                       mold = "Old Mold 2"
                                                   Case "DGV_OM3_W"
                                                       mold = "Old Mold 3"
                                               End Select

                                               ev.Graphics.DrawString(cutDateAB, recordFont, Brushes.Black, tableStartX, yPos) ' Fecha
                                               ev.Graphics.DrawString(mold, recordFont, Brushes.Black, tableStartX + dateColumnWidth, yPos) ' Molde
                                               ev.Graphics.DrawString(panel, recordFont, Brushes.Black, tableStartX + dateColumnWidth + moldColumnWidth, yPos) ' Panel
                                               ev.Graphics.DrawString(qty, recordFont, Brushes.Black, tableStartX + dateColumnWidth + moldColumnWidth + panelColumnWidth, yPos) ' Cantidad

                                               ' Línea horizontal bajo la fila actual
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos + lineHeight, tableStartX + tableWidth, yPos + lineHeight)

                                               ' Líneas verticales
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX, yPos + lineHeight) ' borde izquierdo de "Date"
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth, yPos, tableStartX + dateColumnWidth, yPos + lineHeight) ' borde de "Mold"
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth + moldColumnWidth, yPos, tableStartX + dateColumnWidth + moldColumnWidth, yPos + lineHeight) ' borde de "Panel"
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth + moldColumnWidth + panelColumnWidth, yPos, tableStartX + dateColumnWidth + moldColumnWidth + panelColumnWidth, yPos + lineHeight) ' borde de "Qty"
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX + tableWidth, yPos, tableStartX + tableWidth, yPos + lineHeight) ' borde derecho final

                                               yPos += lineHeight
                                           Next

                                           ' Líneas de cierre final
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX + tableWidth, yPos) ' última línea horizontal
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX, columnHeaderYPos, tableStartX, yPos) ' línea vertical izquierda
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth, columnHeaderYPos, tableStartX + dateColumnWidth, yPos) ' línea entre columnas
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth + moldColumnWidth, columnHeaderYPos, tableStartX + dateColumnWidth + moldColumnWidth, yPos) ' línea entre columnas
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth + moldColumnWidth + panelColumnWidth, columnHeaderYPos, tableStartX + dateColumnWidth + moldColumnWidth + panelColumnWidth, yPos) ' línea entre columnas
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX + tableWidth, columnHeaderYPos, tableStartX + tableWidth, yPos) ' línea derecha

                                       End Sub

        Dim printPreviewDialog As New PrintPreviewDialog()
        printPreviewDialog.Document = printDoc
        printPreviewDialog.ShowDialog()
    End Sub
    Private Sub Btn_Save_Walls_Click(sender As Object, e As EventArgs) Handles Btn_Save_Walls.Click
        SavePanels()
    End Sub
    Private Sub SavePanels()
        Dim dgvList As List(Of DataGridView) = New List(Of DataGridView) From {
        DGV_M1AB_W, DGV_M1CD_W, DGV_M2AB_W, DGV_M2CD_W, DGV_M3AB_W, DGV_M3CD_W,
        DGV_M4AB_W, DGV_M4CD_W, DGV_M5AB_W, DGV_M5CD_W, DGV_M6AB_W, DGV_M6CD_W,
        DGV_OM1_W, DGV_OM2_W, DGV_OM3_W
    }

        Using connection As New SqlConnection(ConnectionString)
            connection.Open()

            ' Dim UpdateEstatusMold As String = "UPDATE [Molds] SET [Estatus] = NULL WHERE [Estatus] = 'NUEVO'"

            ' Using commandUpdate As New SqlCommand(UpdateEstatusMold, connection)
            'commandUpdate.ExecuteNonQuery()
            'End Using

            For Each dgv As DataGridView In dgvList
                For Each row As DataGridViewRow In dgv.Rows
                    If Not row.IsNewRow AndAlso row.Cells(0).Value IsNot Nothing Then
                        Dim panelID As String = row.Cells(0).Value.ToString()
                        Dim panelName As String = row.Cells(1).Value.ToString()
                        Dim qty As Integer = Integer.Parse(row.Cells(2).Value.ToString())
                        Dim cutDate As DateTime = DateTime.Parse(row.Cells(3).Value.ToString())
                        Dim dgvName As String = dgv.Name

                        Dim insertCommand As String = "INSERT INTO Molds (ID, Panel, Qty, [ASGMT Date], Mold, Estatus) " &
                                                  "VALUES (@ID, @Panel, @Qty, @ASGMTDate, @Mold, @Estatus)"

                        Using command As New SqlCommand(insertCommand, connection)
                            command.Parameters.AddWithValue("@ID", panelID)
                            command.Parameters.AddWithValue("@Panel", panelName)
                            command.Parameters.AddWithValue("@Qty", qty)
                            command.Parameters.AddWithValue("@ASGMTDate", cutDate)
                            command.Parameters.AddWithValue("@Mold", dgvName)
                            command.Parameters.AddWithValue("@Estatus", "NUEVO")

                            command.ExecuteNonQuery()
                        End Using
                    End If
                Next
            Next
        End Using

        MessageBox.Show("Data successfully saved.", "Save Panels", MessageBoxButtons.OK, MessageBoxIcon.Information)
        UpdateCutDate()
    End Sub
    Private Sub UpdateCutDate()
        Try
            Using connection As New SqlConnection(ConnectionString)
                connection.Open()

                Dim updateCommand As String = "
            UPDATE Jobs
            SET [ASGM Date] = Molds.[ASGMT Date]
            FROM Jobs
            INNER JOIN Molds ON Jobs.ID = Molds.ID
        "

                Using command As New SqlCommand(updateCommand, connection)
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    'MessageBox.Show($"{rowsAffected} rows updated in the 'Jobs' table.", "Update Cut Date", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Lnk_lbl_TG_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Lnk_lbl_TG.LinkClicked
        Me.Hide()
        Dim TGM As New TGMold()
        TGM.ShowDialog()
        Me.Show()
        Me.Close()
    End Sub
    Private Sub Lnk_Lbl_FC_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Lnk_Lbl_FC.LinkClicked
        Me.Hide()
        Dim FCM As New FCMold()
        FCM.ShowDialog()
        Me.Show()
        Me.Close()
    End Sub
    Private Sub Lnk_lbl_GTL_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Lnk_lbl_GTL.LinkClicked
        Me.Hide()
        Dim GM As New GuillotineM()
        GM.ShowDialog()
        Me.Show()
        Me.Close()
    End Sub
    Private Sub Lnk_lbl_Tee_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Lnk_lbl_Tee.LinkClicked
        Me.Hide()
        Dim TeeM As New FCTMold()
        TeeM.ShowDialog()
        Me.Show()
        Me.Close()
    End Sub
    Private Sub Btn_Menu_Click(sender As Object, e As EventArgs) Handles Btn_Menu.Click
        Me.Hide()
        Dim Menu As New Form1()
        Menu.ShowDialog()
        Me.Show()
        Me.Close()
    End Sub
    Private Sub Filter_Walls_Click(sender As Object, e As EventArgs) Handles Filter_Walls.Click
        Panel_Walls.Visible = True
        LoadJobsWalls()
    End Sub
    Private Sub LoadJobsWalls()
        Dim uniqueValues As New HashSet(Of String)()
        Dim columnName As String = "Job Number"
        Dim connectionString As String = DatabaseConnection.ConnectionString

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim query As String = $"SELECT DISTINCT [Job Number] FROM Jobs WHERE [Panel Identifier] = 'Wall'"
                Using command As New SqlCommand(query, connection)
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim value As Object = reader(columnName)
                            If value IsNot Nothing AndAlso TypeOf value Is String Then
                                uniqueValues.Add(value)
                            End If
                        End While
                    End Using
                End Using
            End Using

            Chckd_Lst_Bx_Jobs.Items.Clear()
            Dim sortedValues = uniqueValues.OrderBy(Function(dateValue) dateValue).ToList()

            For Each value As String In sortedValues
                Chckd_Lst_Bx_Jobs.Items.Add(value)
            Next

        Catch ex As Exception
            MessageBox.Show("Error loading unique dates: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click
        Panel_Walls.Visible = False
    End Sub
    Private Sub Btn_Filter_Click(sender As Object, e As EventArgs) Handles Btn_Filter.Click
        Dim connectionString As String = DatabaseConnection.ConnectionString
        Dim query As String = "SELECT [ID], [Panel], [QTY], [ASGM Date] FROM [Jobs] WHERE [Panel Identifier] = 'Wall' AND [Status] IS NULL"
        Dim filters As New List(Of String)
        Dim parameters As New List(Of SqlParameter)

        If Chckd_Lst_Bx_Jobs.CheckedItems.Count > 0 Then
            Dim JobFilter As New List(Of String)
            Dim index As Integer = 0
            For Each item As String In Chckd_Lst_Bx_Jobs.CheckedItems
                Dim paramName As String = "@JobNumber_" & index.ToString()
                JobFilter.Add("[Job Number] = " & paramName)
                parameters.Add(New SqlParameter(paramName, item))
                index += 1
            Next
            filters.Add("(" & String.Join(" OR ", JobFilter) & ")")
        End If

        If filters.Count > 0 Then
            query &= " AND " & String.Join(" AND ", filters)
        Else
            MessageBox.Show("Por favor, seleccione al menos un Job Number para filtrar.", "Filtro Requerido", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim command As New SqlCommand(query, connection)
                For Each param As SqlParameter In parameters
                    command.Parameters.Add(param)
                Next

                Using reader As SqlDataReader = command.ExecuteReader()
                    DGV_Walls.Rows.Clear()
                    While reader.Read()
                        Dim panelID As String = reader("ID").ToString()
                        Dim panel As String = reader("Panel").ToString()
                        Dim qty As Integer = Convert.ToInt32(reader("QTY"))
                        Dim DateSGM As String = If(IsDBNull(reader("ASGM Date")), String.Empty, CType(reader("ASGM Date"), DateTime).ToString("MM/dd/yyyy HH:mm"))

                        DGV_Walls.Rows.Add(panelID, panel, qty, DateSGM)
                    End While
                End Using
            End Using

            If DGV_Walls.Columns.Count > 0 Then
                DGV_Walls.Columns(0).HeaderText = "ID"
                DGV_Walls.Columns(1).HeaderText = "Panel"
                DGV_Walls.Columns(2).HeaderText = "Qty"
                DGV_Walls.Columns(3).HeaderText = "Date"
            End If

        Catch ex As Exception
            MessageBox.Show("Error al filtrar los datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Panel_Walls.Visible = False
    End Sub
    Private Sub Txt_Bx_Jobs_TextChanged(sender As Object, e As EventArgs) Handles Txt_Bx_Jobs.TextChanged
        Dim searchJob As String = Txt_Bx_Jobs.Text.ToLower()

        For i As Integer = 0 To Chckd_Lst_Bx_Jobs.Items.Count - 1
            Dim itemText As String = Chckd_Lst_Bx_Jobs.Items(i).ToString().ToLower()

            If itemText.Contains(searchJob) Then
                Chckd_Lst_Bx_Jobs.SetItemChecked(i, True)
            Else
                Chckd_Lst_Bx_Jobs.SetItemChecked(i, False)
            End If
        Next
    End Sub
    Private Sub Btn_Clear_Filter_Click(sender As Object, e As EventArgs) Handles Btn_Clear_Filter.Click
        LoadWallPanels()
        Panel_Walls.Visible = False
    End Sub
    Private Sub Lnk_FCT_M_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Lnk_FCT_M.LinkClicked
        Me.Hide()
        Dim FCTM As New FCT_Mold()
        FCTM.ShowDialog()
        Me.Show()
        Me.Close()
    End Sub
End Class