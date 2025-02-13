Imports System.Data.SqlClient

Public Class Molds_Corners
    Private Sub Molds_Corners_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCornersPanels()
        DTP_Corners.Value = DateTime.Now
        DGV_M1_CO.AllowDrop = True
        DGV_M3_CO.AllowDrop = True
        Panel_Corners.Visible = False
    End Sub
    Private Sub LoadCornersPanels()
        DGV_Corners.Rows.Clear()

        Try
            Using connection As New SqlConnection(ConnectionString)
                connection.Open()

                Dim query As String = "SELECT [ID], [Panel], [QTY], [ASGM Date] " &
                                  "FROM [Jobs] " &
                                  "WHERE [Panel Identifier] = 'Corner' AND [Status] IS NULL"

                Using command As New SqlCommand(query, connection)
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim panelID As String = reader("ID").ToString()
                            Dim panel As String = reader("Panel").ToString()
                            Dim qty As Integer = Convert.ToInt32(reader("QTY"))
                            Dim cutDate As String = If(IsDBNull(reader("ASGM Date")), String.Empty, CType(reader("ASGM Date"), DateTime).ToString("MM/dd/yyyy HH:mm"))

                            DGV_Corners.Rows.Add(panelID, panel, qty, cutDate)
                        End While
                    End Using
                End Using

                If DGV_Corners.Columns.Count > 0 Then
                    DGV_Corners.Columns(0).HeaderText = "ID"
                    DGV_Corners.Columns(1).HeaderText = "Panel"
                    DGV_Corners.Columns(2).HeaderText = "Qty"
                    DGV_Corners.Columns(3).HeaderText = "Date"
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
    Private Sub DGV_Corners_DragDrop(sender As Object, e As DragEventArgs) Handles DGV_Corners.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            Dim panel As String = CType(e.Data.GetData(DataFormats.Text), String)
            Dim panelID As String = String.Empty

            ' Buscar en DGV_M1AB_W y DGV_M1CD_W si el panel existe
            Dim rowToUpdate As DataGridViewRow = FindPanelRow(panel, DGV_M1_CO, DGV_M3_CO)
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
                        newRow.CreateCells(DGV_Corners)
                        newRow.Cells(0).Value = panelID
                        newRow.Cells(1).Value = panel
                        newRow.Cells(2).Value = selectedQty ' Usar la cantidad seleccionada
                        newRow.Cells(3).Value = DateTime.Now ' Usar la fecha actual
                        DGV_Corners.Rows.Add(newRow)

                        ' Actualizar la cantidad restante en DGV_M1AB_W o DGV_M1CD_W
                        Dim remainingQty As Integer = originalQty - selectedQty
                        If remainingQty > 0 Then
                            rowToUpdate.Cells(1).Value = remainingQty ' Actualizar con la cantidad restante
                        Else
                            If DGV_M1_CO.Rows.Contains(rowToUpdate) Then
                                DGV_M1_CO.Rows.Remove(rowToUpdate) ' Eliminar si la cantidad restante es 0
                            ElseIf DGV_M3_CO.Rows.Contains(rowToUpdate) Then
                                DGV_M3_CO.Rows.Remove(rowToUpdate) ' Eliminar si la cantidad restante es 0
                            End If

                        End If
                    End If
                Else
                    ' Si el Qty es 1 o menor, simplemente mover el panel
                    Dim newRow As DataGridViewRow = New DataGridViewRow()
                    newRow.CreateCells(DGV_Corners)
                    newRow.Cells(0).Value = panelID
                    newRow.Cells(1).Value = panel
                    newRow.Cells(2).Value = originalQty ' Usar el qty original
                    DGV_Corners.Rows.Add(newRow)
                    RemoveRowFromSource(panel, DGV_M1_CO, DGV_M3_CO)
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
    Private Sub DGV_Corners_MouseDown(sender As Object, e As MouseEventArgs) Handles DGV_Corners.MouseDown
        If e.Button = MouseButtons.Left Then
            Dim hitTestInfo As DataGridView.HitTestInfo = DGV_Corners.HitTest(e.X, e.Y)
            If hitTestInfo.RowIndex >= 0 Then
                Dim panel As String = DGV_Corners.Rows(hitTestInfo.RowIndex).Cells(1).Value.ToString()
                ' Iniciar el arrastre con el panel como dato
                DGV_Corners.DoDragDrop(panel, DragDropEffects.Move)
            End If
        End If
    End Sub
    'mold 1
    Private Sub DGV_M1_CO_DragEnter(sender As Object, e As DragEventArgs) Handles DGV_M1_CO.DragEnter
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub DGV_M1_CO_DragDrop(sender As Object, e As DragEventArgs) Handles DGV_M1_CO.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            Dim panel As String = CType(e.Data.GetData(DataFormats.Text), String)

            Dim rowToUpdate As DataGridViewRow = Nothing
            Dim originalQty As Integer = 1
            Dim selectedQty As Integer = 1

            For Each row As DataGridViewRow In DGV_Corners.Rows
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
                newRow.CreateCells(DGV_M1_CO)
                newRow.Cells(0).Value = rowToUpdate.Cells(0).Value
                newRow.Cells(1).Value = panel
                newRow.Cells(2).Value = selectedQty
                newRow.Cells(3).Value = DTP_Corners.Value
                DGV_M1_CO.Rows.Add(newRow)

                Dim remainingQty As Integer = originalQty - selectedQty
                If remainingQty > 0 Then
                    rowToUpdate.Cells(2).Value = remainingQty
                Else
                    DGV_Corners.Rows.Remove(rowToUpdate)
                End If
            Else
                MessageBox.Show("No se encontró el panel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub DGV_M1_CO_DragOver(sender As Object, e As DragEventArgs) Handles DGV_M1_CO.DragOver
        e.Effect = DragDropEffects.Move
    End Sub
    Private Sub DGV_M1_CO_KeyDown(sender As Object, e As KeyEventArgs) Handles DGV_M1_CO.KeyDown
        If e.KeyCode = Keys.Delete Then
            HandlePanelDeletion(DGV_M1_CO)
        End If
    End Sub
    Private Sub DGV_M1_CO_MouseDown(sender As Object, e As MouseEventArgs) Handles DGV_M1_CO.MouseDown
        Dim hit As DataGridView.HitTestInfo = DGV_M1_CO.HitTest(e.X, e.Y)
        If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 Then
            Dim cell As DataGridViewCell = DGV_M1_CO.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
            If cell.Selected Then
                Dim dragValue As String = DGV_M1_CO.Rows(hit.RowIndex).Cells(0).Value.ToString()
                DGV_M1_CO.DoDragDrop(dragValue, DragDropEffects.Move)
            End If
        End If
    End Sub
    'mold 3
    Private Sub DGV_M3_CO_DragEnter(sender As Object, e As DragEventArgs) Handles DGV_M3_CO.DragEnter
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub DGV_M3_CO_DragDrop(sender As Object, e As DragEventArgs) Handles DGV_M3_CO.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            Dim panel As String = CType(e.Data.GetData(DataFormats.Text), String)

            Dim rowToUpdate As DataGridViewRow = Nothing
            Dim originalQty As Integer = 1
            Dim selectedQty As Integer = 1

            For Each row As DataGridViewRow In DGV_Corners.Rows
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
                newRow.CreateCells(DGV_M3_CO)
                newRow.Cells(0).Value = rowToUpdate.Cells(0).Value
                newRow.Cells(1).Value = panel
                newRow.Cells(2).Value = selectedQty
                newRow.Cells(3).Value = DTP_Corners.Value
                DGV_M3_CO.Rows.Add(newRow)

                Dim remainingQty As Integer = originalQty - selectedQty
                If remainingQty > 0 Then
                    rowToUpdate.Cells(2).Value = remainingQty
                Else
                    DGV_Corners.Rows.Remove(rowToUpdate)
                End If
            Else
                MessageBox.Show("No se encontró el panel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub DGV_M3_CO_DragOver(sender As Object, e As DragEventArgs) Handles DGV_M3_CO.DragOver
        e.Effect = DragDropEffects.Move
    End Sub
    Private Sub DGV_M3AB_W_KeyDown(sender As Object, e As KeyEventArgs) Handles DGV_M3_CO.KeyDown
        If e.KeyCode = Keys.Delete Then
            HandlePanelDeletion(DGV_M3_CO)
        End If
    End Sub
    Private Sub DGV_M3AB_W_MouseDown(sender As Object, e As MouseEventArgs) Handles DGV_M3_CO.MouseDown
        Dim hit As DataGridView.HitTestInfo = DGV_M3_CO.HitTest(e.X, e.Y)
        If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 Then
            Dim cell As DataGridViewCell = DGV_M3_CO.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
            If cell.Selected Then
                Dim dragValue As String = DGV_M3_CO.Rows(hit.RowIndex).Cells(0).Value.ToString()
                DGV_M3_CO.DoDragDrop(dragValue, DragDropEffects.Move)
            End If
        End If
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

            MovePanelBackToDGVCorners(panelID, panel, qty)
            dgv.Rows.Remove(selectedRow)
            dgv.ClearSelection()
        Else
            'MessageBox.Show("Seleccione un panel para eliminar.", "Eliminar Panel", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub MovePanelBackToDGVCorners(panelID As String, panel As String, qty As Integer)
        Dim existsInCorners As Boolean = False

        ' Busca si el panel ya existe en DGV_ s
        For Each CornerRow As DataGridViewRow In DGV_Corners.Rows
            If CornerRow.Cells(1).Value IsNot Nothing AndAlso CornerRow.Cells(1).Value.ToString() = panel Then
                ' Si existe, suma la cantidad
                Dim cornerQty As Integer = Integer.Parse(CornerRow.Cells(2).Value.ToString())
                CornerRow.Cells(2).Value = cornerQty + qty ' Sumar la cantidad del panel eliminado
                existsIncorners = True

                ' Asegura que OriginalQuantities tiene el valor original
                If Not OriginalQuantities.ContainsKey(panel) Then
                    OriginalQuantities(panel) = cornerQty + qty
                End If
                Exit For
            End If
        Next

        ' Si el panel no existe en DGV_corners, crea una nueva fila
        If Not existsIncorners Then
            Dim newRow As DataGridViewRow = CType(DGV_Corners.Rows(0).Clone(), DataGridViewRow)
            newRow.Cells(0).Value = panelID ' ID
            newRow.Cells(1).Value = panel ' Nombre del panel
            newRow.Cells(2).Value = qty ' Cantidad
            newRow.Cells(3).Value = Nothing ' Puedes ajustar el valor para la fecha si es necesario

            ' Almacena el valor original de la cantidad en OriginalQuantities
            If Not OriginalQuantities.ContainsKey(panel) Then
                OriginalQuantities(panel) = qty
            End If

            DGV_Corners.Rows.Add(newRow)
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
    Private Sub AllPanelsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        DGV_Corners.Rows.Clear()

        Try
            Using connection As New SqlConnection(ConnectionString)
                connection.Open()

                Dim query As String = "SELECT [ID], [Panel], [QTY], [ASGM Date] " &
                                  "FROM [Jobs] " &
                                  "WHERE [Panel Identifier] = 'Corner'"

                Using command As New SqlCommand(query, connection)
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim panelID As String = reader("ID").ToString()
                            Dim panel As String = reader("Panel").ToString()
                            Dim qty As Integer = Convert.ToInt32(reader("QTY"))
                            Dim cutDate As String = If(IsDBNull(reader("ASGM Date")), String.Empty, CType(reader("ASGM Date"), DateTime).ToString("MM/dd/yyyy"))

                            DGV_Corners.Rows.Add(panelID, panel, qty, cutDate)
                        End While
                    End Using
                End Using

                If DGV_Corners.Columns.Count > 0 Then
                    DGV_Corners.Columns(0).HeaderText = "ID"
                    DGV_Corners.Columns(1).HeaderText = "Panel"
                    DGV_Corners.Columns(2).HeaderText = "Qty"
                    DGV_Corners.Columns(3).HeaderText = "Date"
                End If
            End Using
        Catch ex As SqlException
            MessageBox.Show("Error uploading panels: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ClearMoldsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClearMolds_Corners.Click
        ' Lista de todos los DataGridView a limpiar
        Dim dgvList As List(Of DataGridView) = New List(Of DataGridView) From {
        DGV_M1_CO, DGV_M3_CO
    }

        ' Limpiar todas las filas en cada DataGridView
        For Each dgv As DataGridView In dgvList
            dgv.Rows.Clear()
        Next
    End Sub
    Private Sub Btn_Menu_Click(sender As Object, e As EventArgs) Handles Btn_Menu.Click
        Me.Hide()
        Dim Menu As New Form1()
        Menu.ShowDialog()
        Me.Show()
        Me.Close()
    End Sub
    Private Sub SavePanels()
        Dim dgvList As List(Of DataGridView) = New List(Of DataGridView) From {
        DGV_M1_CO, DGV_M3_CO
    }

        Using connection As New SqlConnection(ConnectionString)
            connection.Open()

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
    Private Sub Btn_Save_Corners_Click_1(sender As Object, e As EventArgs) Handles Btn_Save_Corners.Click
        SavePanels()
    End Sub
    Private Sub Lnk_Lbl_Walls_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Lnk_Lbl_Walls.LinkClicked
        Me.Hide()
        Dim Walls As New Mold_Walls()
        Walls.ShowDialog()
        Me.Show()
        Me.Close()
    End Sub

    Private Sub Lnk_lbl_TG_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Lnk_lbl_TG.LinkClicked
        Me.Hide()
        Dim TGS As New TGMold()
        TGS.ShowDialog()
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
        Dim Guillotine As New GuillotineM()
        Guillotine.ShowDialog()
        Me.Show()
        Me.Close()
    End Sub

    Private Sub Lnk_lbl_Tee_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Lnk_lbl_Tee.LinkClicked
        Me.Hide()
        Dim TM As New FCTMold()
        TM.ShowDialog()
        Me.Show()
        Me.Close()
    End Sub
    Private Sub Print_M1_CO_Click(sender As Object, e As EventArgs) Handles Print_M1_CO.Click
        SavePanels()
        Dim queryAB As String = "SELECT [ASGMT Date], [Panel], [Qty] FROM [Molds] WHERE [Mold] = 'DGV_M1_CO' AND [Estatus] = 'NUEVO' ORDER BY [ASGMT Date] ASC"
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
                                           Dim headerText As String = "Corners"
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
                                           ev.Graphics.DrawString("Mold 1", columnHeaderFont, Brushes.Black, tableStartX + dateColumnWidth, yPos)
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
    Private Sub Print_M3_CO_Click(sender As Object, e As EventArgs) Handles Print_M3_CO.Click
        SavePanels()
        Dim queryAB As String = "SELECT [ASGMT Date], [Panel], [Qty] FROM [Molds] WHERE [Mold] = 'DGV_M3_CO' AND [Estatus] = 'NUEVO' ORDER BY [ASGMT Date] ASC"
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
                                           Dim headerText As String = "Corners"
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
                                           ev.Graphics.DrawString("Mold 3", columnHeaderFont, Brushes.Black, tableStartX + dateColumnWidth, yPos)
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
    Private Sub Print_All_CO_Click(sender As Object, e As EventArgs) Handles Print_All_CO.Click
        SavePanels()

        Dim queryAB As String = "SELECT [ASGMT Date], [Mold], [Panel], [Qty] " &
                        "FROM [Molds] " &
                        "WHERE ([Mold] = 'DGV_M1_CO' OR [Mold] = 'DDGV_M3_CO'  " &
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
                                           Dim headerText As String = "Corners"
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
                                                   Case "DGV_M1_CO"
                                                       mold = "Mold 1"
                                                   Case "DGV_M3_CO"
                                                       mold = "Mold 3"
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
    Private Sub FilterPanelsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FilterPanelsToolStripMenuItem.Click
        Panel_Corners.Visible = True
        LoadJobsCO()
    End Sub
    Private Sub LoadJobsCO()
        Dim uniqueValues As New HashSet(Of String)()
        Dim columnName As String = "Job Number"
        Dim connectionString As String = DatabaseConnection.ConnectionString

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim query As String = $"SELECT DISTINCT [Job Number] FROM Jobs WHERE [Panel Identifier] = 'Corner' AND [Status] IS NULL"
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

            Chckd_lst_CO.Items.Clear()
            Dim sortedValues = uniqueValues.OrderBy(Function(dateValue) dateValue).ToList()

            For Each value As String In sortedValues
                Chckd_lst_CO.Items.Add(value)
            Next

        Catch ex As Exception
            MessageBox.Show("Error loading unique dates: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim connectionString As String = DatabaseConnection.ConnectionString
        Dim query As String = "SELECT [ID], [Panel], [QTY], [ASGM Date] FROM [Jobs] WHERE [Panel Identifier] = 'Corner' AND [Status] IS NULL"
        Dim filters As New List(Of String)
        Dim parameters As New List(Of SqlParameter)

        If Chckd_lst_CO.CheckedItems.Count > 0 Then
            Dim JobFilter As New List(Of String)
            Dim index As Integer = 0
            For Each item As String In Chckd_lst_CO.CheckedItems
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
                    DGV_Corners.Rows.Clear() ' Limpiar filas existentes
                    While reader.Read()
                        Dim panelID As String = reader("ID").ToString()
                        Dim panel As String = reader("Panel").ToString()
                        Dim qty As Integer = Convert.ToInt32(reader("QTY"))
                        Dim DateSGM As String = If(IsDBNull(reader("ASGM Date")), String.Empty, CType(reader("ASGM Date"), DateTime).ToString("MM/dd/yyyy HH:mm"))

                        DGV_Corners.Rows.Add(panelID, panel, qty, DateSGM)
                    End While
                End Using
            End Using

            If DGV_Corners.Columns.Count > 0 Then
                DGV_Corners.Columns(0).HeaderText = "ID"
                DGV_Corners.Columns(1).HeaderText = "Panel"
                DGV_Corners.Columns(2).HeaderText = "Qty"
                DGV_Corners.Columns(3).HeaderText = "Date"
            End If

        Catch ex As Exception
            MessageBox.Show("Error al filtrar los datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Panel_Corners.Visible = False
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel_Corners.Visible = False
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadCornersPanels()
    End Sub
    Private Sub Txt_Bx_Jobs_TextChanged(sender As Object, e As EventArgs) Handles Txt_Bx_Jobs.TextChanged
        Dim searchJob As String = Txt_Bx_Jobs.Text.ToLower()

        For i As Integer = 0 To Chckd_lst_CO.Items.Count - 1
            Dim itemText As String = Chckd_lst_CO.Items(i).ToString().ToLower()

            If itemText.Contains(searchJob) Then
                Chckd_lst_CO.SetItemChecked(i, True)
            Else
                Chckd_lst_CO.SetItemChecked(i, False)
            End If
        Next
    End Sub
    Private Sub Lnk_FCTM_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Lnk_FCTM.LinkClicked
        Me.Hide()
        Dim FCTM As New FCT_Mold()
        FCTM.ShowDialog()
        Me.Show()
        Me.Close()
    End Sub
End Class