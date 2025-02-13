Imports System.Data.SqlClient

Public Class FCTMold
    Private Sub TeeMold_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadTEEMPanels()
        DTP_TeeM.Value = DateTime.Now
        DGV_Tee_Panels.AllowDrop = True
        DGV_TeeM.AllowDrop = True
        Panel_TM.Visible = False
    End Sub
    Private Sub LoadTEEMPanels()
        DGV_Tee_Panels.Rows.Clear()

        Try
            Using connection As New SqlConnection(ConnectionString)
                connection.Open()

                Dim query As String = "SELECT [ID], [Panel], [QTY], [ASGM Date] " &
                                  "FROM [Jobs] " &
                                  "WHERE [Panel Identifier] = 'Tee' AND [Status] IS NULL"

                Using command As New SqlCommand(query, connection)
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim panelID As String = reader("ID").ToString()
                            Dim panel As String = reader("Panel").ToString()
                            Dim qty As Integer = Convert.ToInt32(reader("QTY"))
                            Dim DateSGM As String = If(IsDBNull(reader("ASGM Date")), String.Empty, CType(reader("ASGM Date"), DateTime).ToString("MM/dd/yyyy HH:mm"))

                            DGV_Tee_Panels.Rows.Add(panelID, panel, qty, DateSGM)
                        End While
                    End Using
                End Using

                If DGV_Tee_Panels.Columns.Count > 0 Then
                    DGV_Tee_Panels.Columns(0).HeaderText = "ID"
                    DGV_Tee_Panels.Columns(1).HeaderText = "Panel"
                    DGV_Tee_Panels.Columns(2).HeaderText = "Qty"
                    DGV_Tee_Panels.Columns(3).HeaderText = "Date"
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
    Private Sub DGV_Tee_Panels_DragDrop(sender As Object, e As DragEventArgs) Handles DGV_Tee_Panels.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            Dim panel As String = CType(e.Data.GetData(DataFormats.Text), String)
            Dim panelID As String = String.Empty

            ' Buscar en DGV_M1AB_W y DGV_M1CD_W si el panel existe
            Dim rowToUpdate As DataGridViewRow = FindPanelRow(panel, DGV_Tee_Panels)
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
                        newRow.CreateCells(DGV_Tee_Panels)
                        newRow.Cells(0).Value = panelID
                        newRow.Cells(1).Value = panel
                        newRow.Cells(2).Value = selectedQty ' Usar la cantidad seleccionada
                        newRow.Cells(3).Value = DateTime.Now ' Usar la fecha actual
                        DGV_Tee_Panels.Rows.Add(newRow)

                        ' Actualizar la cantidad restante en DGV_M1AB_W o DGV_M1CD_W
                        Dim remainingQty As Integer = originalQty - selectedQty
                        If remainingQty > 0 Then
                            rowToUpdate.Cells(1).Value = remainingQty ' Actualizar con la cantidad restante
                        Else
                            If DGV_TeeM.Rows.Contains(rowToUpdate) Then
                                DGV_TeeM.Rows.Remove(rowToUpdate) ' Eliminar si la cantidad restante es 0
                            End If

                        End If
                    End If
                Else
                    ' Si el Qty es 1 o menor, simplemente mover el panel
                    Dim newRow As DataGridViewRow = New DataGridViewRow()
                    newRow.CreateCells(DGV_Tee_Panels)
                    newRow.Cells(0).Value = panelID
                    newRow.Cells(1).Value = panel
                    newRow.Cells(2).Value = originalQty ' Usar el qty original
                    DGV_Tee_Panels.Rows.Add(newRow)
                    RemoveRowFromSource(panel, DGV_TeeM)
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
    Private Sub DGV_Tee_Panels_MouseDown(sender As Object, e As MouseEventArgs) Handles DGV_Tee_Panels.MouseDown
        If e.Button = MouseButtons.Left Then
            Dim hitTestInfo As DataGridView.HitTestInfo = DGV_Tee_Panels.HitTest(e.X, e.Y)
            If hitTestInfo.RowIndex >= 0 Then
                Dim panel As String = DGV_Tee_Panels.Rows(hitTestInfo.RowIndex).Cells(1).Value.ToString()
                ' Iniciar el arrastre con el panel como dato
                DGV_Tee_Panels.DoDragDrop(panel, DragDropEffects.Move)
            End If
        End If
    End Sub
    Private Sub DGV_TeeM_DragEnter(sender As Object, e As DragEventArgs) Handles DGV_TeeM.DragEnter
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub DGV_TeeM_DragDrop(sender As Object, e As DragEventArgs) Handles DGV_TeeM.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            Dim panel As String = CType(e.Data.GetData(DataFormats.Text), String)

            Dim rowToUpdate As DataGridViewRow = Nothing
            Dim originalQty As Integer = 1
            Dim selectedQty As Integer = 1

            For Each row As DataGridViewRow In DGV_Tee_Panels.Rows
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
                newRow.CreateCells(DGV_TeeM)
                newRow.Cells(0).Value = rowToUpdate.Cells(0).Value
                newRow.Cells(1).Value = panel
                newRow.Cells(2).Value = selectedQty
                newRow.Cells(3).Value = DTP_TeeM.Value
                DGV_TeeM.Rows.Add(newRow)

                Dim remainingQty As Integer = originalQty - selectedQty
                If remainingQty > 0 Then
                    rowToUpdate.Cells(2).Value = remainingQty
                Else
                    DGV_Tee_Panels.Rows.Remove(rowToUpdate)
                End If
            Else
                MessageBox.Show("No se encontró el panel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub DGV_TeeM_DragOver(sender As Object, e As DragEventArgs) Handles DGV_TeeM.DragOver
        e.Effect = DragDropEffects.Move
    End Sub
    Private Sub DGV_TeeM_KeyDown(sender As Object, e As KeyEventArgs) Handles DGV_TeeM.KeyDown
        If e.KeyCode = Keys.Delete Then
            HandlePanelDeletion(DGV_TeeM)
        End If
    End Sub
    Private Sub DGV_TeeM_MouseDown(sender As Object, e As MouseEventArgs) Handles DGV_TeeM.MouseDown
        Dim hit As DataGridView.HitTestInfo = DGV_TeeM.HitTest(e.X, e.Y)
        If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 Then
            Dim cell As DataGridViewCell = DGV_TeeM.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
            If cell.Selected Then
                Dim dragValue As String = DGV_TeeM.Rows(hit.RowIndex).Cells(0).Value.ToString()
                DGV_TeeM.DoDragDrop(dragValue, DragDropEffects.Move)
            End If
        End If
    End Sub
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

            MovePanelBackToDGVTee(panelID, panel, qty)
            dgv.Rows.Remove(selectedRow)
            dgv.ClearSelection()
        Else
            'MessageBox.Show("Seleccione un panel para eliminar.", "Eliminar Panel", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub MovePanelBackToDGVTee(panelID As String, panel As String, qty As Integer)
        Dim existsInWalls As Boolean = False

        ' Busca si el panel ya existe en DGV_Walls
        For Each wallRow As DataGridViewRow In DGV_Tee_Panels.Rows
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
            Dim newRow As DataGridViewRow = CType(DGV_Tee_Panels.Rows(0).Clone(), DataGridViewRow)
            newRow.Cells(0).Value = panelID ' ID
            newRow.Cells(1).Value = panel ' Nombre del panel
            newRow.Cells(2).Value = qty ' Cantidad
            newRow.Cells(3).Value = Nothing ' Puedes ajustar el valor para la fecha si es necesario

            ' Almacena el valor original de la cantidad en OriginalQuantities
            If Not OriginalQuantities.ContainsKey(panel) Then
                OriginalQuantities(panel) = qty
            End If

            DGV_Tee_Panels.Rows.Add(newRow)
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
    Private Sub Lnk_Lbl_Walls_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Lnk_Lbl_Walls.LinkClicked
        Me.Hide()
        Dim Walls As New Mold_Walls()
        Walls.ShowDialog()
        Me.Show()
        Me.Close()

    End Sub
    Private Sub Lnk_lbl_Corners_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Lnk_lbl_Corners.LinkClicked
        Me.Hide()
        Dim Corners As New Molds_Corners()
        Corners.ShowDialog()
        Me.Show()
        Me.Close()
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
    Private Sub Btn_Save_Tee_Click(sender As Object, e As EventArgs) Handles Btn_Save_Tee.Click
        SavePanels()
    End Sub
    Private Sub SavePanels()
        Dim dgvList As List(Of DataGridView) = New List(Of DataGridView) From {
        DGV_TeeM
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
    Private Sub Btn_Menu_Click(sender As Object, e As EventArgs) Handles Btn_Menu.Click
        Me.Hide()  ' Opcionalmente puedes usar Hide() en lugar de Close() si deseas ocultarlo.
        Dim form1 As New Form1()
        form1.ShowDialog()
        Me.Show()
        Me.Close()
    End Sub
    Private Sub PrintMold_Click(sender As Object, e As EventArgs) Handles PrintMold.Click
        SavePanels()
        Dim queryAB As String = "SELECT [ASGMT Date], [Panel], [Qty] FROM [Molds] WHERE [Mold] = 'DGV_TeeM' AND [Estatus] = 'NUEVO' ORDER BY [ASGMT Date] ASC"
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
                                           Dim headerText As String = "Tee Mold"
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

    Private Sub Txt_Bx_Jobs_TextChanged(sender As Object, e As EventArgs) Handles Txt_Bx_Jobs.TextChanged
        Dim searchJob As String = Txt_Bx_Jobs.Text.ToLower()

        For i As Integer = 0 To Chckd_lst_TM.Items.Count - 1
            Dim itemText As String = Chckd_lst_TM.Items(i).ToString().ToLower()

            If itemText.Contains(searchJob) Then
                Chckd_lst_TM.SetItemChecked(i, True)
            Else
                Chckd_lst_TM.SetItemChecked(i, False)
            End If
        Next
    End Sub
    Private Sub FilterPanelsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FilterPanelsToolStripMenuItem.Click
        Panel_TM.Visible = True
        LoadJobsTMP()
    End Sub

    Private Sub LoadJobsTMP()
        Dim uniqueValues As New HashSet(Of String)()
        Dim columnName As String = "Job Number"
        Dim connectionString As String = DatabaseConnection.ConnectionString

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim query As String = $"SELECT DISTINCT [Job Number] FROM Jobs WHERE [Panel Identifier] = 'Tee' AND [Status] IS NULL"
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

            Chckd_lst_TM.Items.Clear()
            Dim sortedValues = uniqueValues.OrderBy(Function(dateValue) dateValue).ToList()

            For Each value As String In sortedValues
                Chckd_lst_TM.Items.Add(value)
            Next

        Catch ex As Exception
            MessageBox.Show("Error loading unique dates: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim connectionString As String = DatabaseConnection.ConnectionString
        Dim query As String = "SELECT [ID], [Panel], [QTY], [ASGM Date] FROM [Jobs] WHERE [Panel Identifier] = 'Tee' AND [Status] IS NULL"
        Dim filters As New List(Of String)
        Dim parameters As New List(Of SqlParameter)

        If Chckd_lst_TM.CheckedItems.Count > 0 Then
            Dim JobFilter As New List(Of String)
            Dim index As Integer = 0
            For Each item As String In Chckd_lst_TM.CheckedItems
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
                    DGV_Tee_Panels.Rows.Clear() ' Limpiar filas existentes
                    While reader.Read()
                        Dim panelID As String = reader("ID").ToString()
                        Dim panel As String = reader("Panel").ToString()
                        Dim qty As Integer = Convert.ToInt32(reader("QTY"))
                        Dim DateSGM As String = If(IsDBNull(reader("ASGM Date")), String.Empty, CType(reader("ASGM Date"), DateTime).ToString("MM/dd/yyyy HH:mm"))

                        DGV_Tee_Panels.Rows.Add(panelID, panel, qty, DateSGM)
                    End While
                End Using
            End Using

            If DGV_Tee_Panels.Columns.Count > 0 Then
                DGV_Tee_Panels.Columns(0).HeaderText = "ID"
                DGV_Tee_Panels.Columns(1).HeaderText = "Panel"
                DGV_Tee_Panels.Columns(2).HeaderText = "Qty"
                DGV_Tee_Panels.Columns(3).HeaderText = "Date"
            End If

        Catch ex As Exception
            MessageBox.Show("Error al filtrar los datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Panel_TM.Visible = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Panel_TM.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadTEEMPanels()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Lnk_FCTM.LinkClicked
        Me.Hide()
        Dim TeeM As New FCTMold()
        TeeM.ShowDialog()
        Me.Show()
        Me.Close()
    End Sub
End Class