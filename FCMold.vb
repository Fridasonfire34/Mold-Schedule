Imports System.Data.SqlClient

Public Class FCMold
    Private Sub Lnk_lbl_Wall_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Lnk_lbl_Wall.LinkClicked
        Me.Hide()
        Dim Walls As New Mold_Walls()
        Walls.ShowDialog()
        Me.Close()
    End Sub
    Private Sub Lnk_Lbl_Corn_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Lnk_Lbl_Corn.LinkClicked

        Me.Hide()
        Dim Corners As New Molds_Corners()
        Corners.ShowDialog()
        Me.Close()

    End Sub
    Private Sub Lnk_lbl_TG_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Lnk_lbl_TG.LinkClicked
        Me.Hide()
        Dim TG As New TGMold()
        TG.ShowDialog()
        Me.Close()
    End Sub
    Private Sub Lnk_lbl_GTL_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Lnk_lbl_GTL.LinkClicked
        Me.Hide()
        Dim GTM As New GuillotineM()
        GTM.ShowDialog()
        Me.Close()
    End Sub
    Private Sub Lnk_lbl_Tee_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Lnk_lbl_Tee.LinkClicked
        Me.Hide()
        Dim TM As New FCTMold()
        TM.ShowDialog()
        Me.Close()
    End Sub
    Private Sub Btn_Save_FC_Click(sender As Object, e As EventArgs) Handles Btn_Save_FC.Click
        SavePanels()
    End Sub
    Private Sub SavePanels()
        Dim dgvList As List(Of DataGridView) = New List(Of DataGridView) From {
        DGV_M15_FL, DGV_M17_FL
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
                                                  "VALUES (@ID, @Panel, @Qty, @ASGMT, @Mold, @Estatus)"

                        Using command As New SqlCommand(insertCommand, connection)
                            command.Parameters.AddWithValue("@ID", panelID)
                            command.Parameters.AddWithValue("@Panel", panelName)
                            command.Parameters.AddWithValue("@Qty", qty)
                            command.Parameters.AddWithValue("@ASGMT", cutDate)
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
    Private Sub FCMold_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadFCPanels()

        DTP_FL.Value = DateTime.Now
        DGV_M15_FL.AllowDrop = True
        DGV_M17_FL.AllowDrop = True

        Panel_FC.Visible = False
    End Sub
    Private Sub LoadFCPanels()
        DGV_Floors.Rows.Clear()

        Try
            Using connection As New SqlConnection(ConnectionString)
                connection.Open()

                Dim query As String = "SELECT [ID], [Panel], [QTY], [ASGM Date] " &
                      "FROM [Jobs] " &
                      "WHERE ([Panel Identifier] = 'Floor' OR [Panel Identifier] = 'Ceiling') " &
                      "AND [Status] IS NULL"

                Using command As New SqlCommand(query, connection)
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim panelID As String = reader("ID").ToString()
                            Dim panel As String = reader("Panel").ToString()
                            Dim qty As Integer = Convert.ToInt32(reader("QTY"))
                            Dim cutDate As String = If(IsDBNull(reader("ASGM Date")), String.Empty, CType(reader("ASGM Date"), DateTime).ToString("MM/dd/yyyy HH:mm"))

                            DGV_Floors.Rows.Add(panelID, panel, qty, cutDate)
                        End While
                    End Using
                End Using

                If DGV_Floors.Columns.Count > 0 Then
                    DGV_Floors.Columns(0).HeaderText = "ID"
                    DGV_Floors.Columns(1).HeaderText = "Panel"
                    DGV_Floors.Columns(2).HeaderText = "Qty"
                    DGV_Floors.Columns(3).HeaderText = "Date"
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
    Private Sub DGV_Floors_DragDrop(sender As Object, e As DragEventArgs) Handles DGV_Floors.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            Dim panel As String = CType(e.Data.GetData(DataFormats.Text), String)
            Dim panelID As String = String.Empty

            Dim rowToUpdate As DataGridViewRow = FindPanelRow(panel, DGV_M15_FL, DGV_M17_FL)
            Dim originalQty As Integer = 1

            If rowToUpdate IsNot Nothing Then
                If originalQty > 1 Then
                    Dim panelsQtyForm As New PanelsQty()
                    panelsQtyForm.PanelsQuantity = originalQty
                    If panelsQtyForm.ShowDialog() = DialogResult.OK Then
                        Dim selectedQty As Integer = panelsQtyForm.SelectedQty

                        Dim newRow As DataGridViewRow = New DataGridViewRow()
                        newRow.CreateCells(DGV_Floors)
                        newRow.Cells(0).Value = panelID
                        newRow.Cells(1).Value = panel
                        newRow.Cells(2).Value = selectedQty
                        newRow.Cells(3).Value = DateTime.Now
                        DGV_Floors.Rows.Add(newRow)

                        Dim remainingQty As Integer = originalQty - selectedQty
                        If remainingQty > 0 Then
                            rowToUpdate.Cells(1).Value = remainingQty
                        Else
                            If DGV_M15_FL.Rows.Contains(rowToUpdate) Then
                                DGV_M15_FL.Rows.Remove(rowToUpdate)
                            ElseIf DGV_M17_FL.Rows.Contains(rowToUpdate) Then
                                DGV_M17_FL.Rows.Remove(rowToUpdate)
                            End If

                        End If
                    End If
                Else
                    Dim newRow As DataGridViewRow = New DataGridViewRow()
                    newRow.CreateCells(DGV_Floors)
                    newRow.Cells(0).Value = panelID
                    newRow.Cells(1).Value = panel
                    newRow.Cells(2).Value = originalQty
                    DGV_Floors.Rows.Add(newRow)
                    RemoveRowFromSource(panel, DGV_M15_FL, DGV_M17_FL)
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
    Private Sub DGV_Floors_MouseDown(sender As Object, e As MouseEventArgs) Handles DGV_Floors.MouseDown
        If e.Button = MouseButtons.Left Then
            Dim hitTestInfo As DataGridView.HitTestInfo = DGV_Floors.HitTest(e.X, e.Y)
            If hitTestInfo.RowIndex >= 0 Then
                Dim panel As String = DGV_Floors.Rows(hitTestInfo.RowIndex).Cells(1).Value.ToString()
                DGV_Floors.DoDragDrop(panel, DragDropEffects.Move)
            End If
        End If
    End Sub
    Private Sub DGV_M15_FL_DragEnter(sender As Object, e As DragEventArgs) Handles DGV_M15_FL.DragEnter
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub DGV_M15_FL_DragDrop(sender As Object, e As DragEventArgs) Handles DGV_M15_FL.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            Dim panel As String = CType(e.Data.GetData(DataFormats.Text), String)

            Dim rowToUpdate As DataGridViewRow = Nothing
            Dim originalQty As Integer = 1
            Dim selectedQty As Integer = 1

            For Each row As DataGridViewRow In DGV_Floors.Rows
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
                newRow.CreateCells(DGV_M15_FL)
                newRow.Cells(0).Value = rowToUpdate.Cells(0).Value
                newRow.Cells(1).Value = panel
                newRow.Cells(2).Value = selectedQty
                newRow.Cells(3).Value = DTP_FL.Value
                DGV_M15_FL.Rows.Add(newRow)

                Dim remainingQty As Integer = originalQty - selectedQty
                If remainingQty > 0 Then
                    rowToUpdate.Cells(2).Value = remainingQty
                Else
                    DGV_Floors.Rows.Remove(rowToUpdate)
                End If
            Else
                MessageBox.Show("No se encontró el panel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub DGV_M15_FL_DragOver(sender As Object, e As DragEventArgs) Handles DGV_M15_FL.DragOver
        e.Effect = DragDropEffects.Move
    End Sub
    Private Sub DGV_M15_FL_KeyDown(sender As Object, e As KeyEventArgs) Handles DGV_M15_FL.KeyDown
        If e.KeyCode = Keys.Delete Then
            HandlePanelDeletion(DGV_M15_FL)
        End If
    End Sub
    Private Sub DGV_M15_FL_MouseDown(sender As Object, e As MouseEventArgs) Handles DGV_M15_FL.MouseDown
        Dim hit As DataGridView.HitTestInfo = DGV_M15_FL.HitTest(e.X, e.Y)
        If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 Then
            Dim cell As DataGridViewCell = DGV_M15_FL.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
            If cell.Selected Then
                Dim dragValue As String = DGV_M15_FL.Rows(hit.RowIndex).Cells(0).Value.ToString()
                DGV_M15_FL.DoDragDrop(dragValue, DragDropEffects.Move)
            End If
        End If
    End Sub
    Private Sub DGV_M17_FL_DragEnter(sender As Object, e As DragEventArgs) Handles DGV_M17_FL.DragEnter
        If e.Data.GetDataPresent(DataFormats.Text) Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    Private Sub DGV_M17_FL_DragDrop(sender As Object, e As DragEventArgs) Handles DGV_M17_FL.DragDrop
        If e.Data.GetDataPresent(DataFormats.Text) Then
            Dim panel As String = CType(e.Data.GetData(DataFormats.Text), String)

            Dim rowToUpdate As DataGridViewRow = Nothing
            Dim originalQty As Integer = 1
            Dim selectedQty As Integer = 1

            For Each row As DataGridViewRow In DGV_Floors.Rows
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
                newRow.CreateCells(DGV_M17_FL)
                newRow.Cells(0).Value = rowToUpdate.Cells(0).Value
                newRow.Cells(1).Value = panel
                newRow.Cells(2).Value = selectedQty
                newRow.Cells(3).Value = DTP_FL.Value
                DGV_M17_FL.Rows.Add(newRow)

                Dim remainingQty As Integer = originalQty - selectedQty
                If remainingQty > 0 Then
                    rowToUpdate.Cells(2).Value = remainingQty
                Else
                    DGV_Floors.Rows.Remove(rowToUpdate)
                End If
            Else
                MessageBox.Show("No se encontró el panel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub
    Private Sub DGV_M17_FL_MouseDown(sender As Object, e As MouseEventArgs) Handles DGV_M17_FL.MouseDown
        Dim hit As DataGridView.HitTestInfo = DGV_M17_FL.HitTest(e.X, e.Y)
        If hit.RowIndex >= 0 AndAlso hit.ColumnIndex >= 0 Then
            Dim cell As DataGridViewCell = DGV_M17_FL.Rows(hit.RowIndex).Cells(hit.ColumnIndex)
            If cell.Selected Then
                Dim dragValue As String = DGV_M17_FL.Rows(hit.RowIndex).Cells(0).Value.ToString()
                DGV_M17_FL.DoDragDrop(dragValue, DragDropEffects.Move)
            End If
        End If
    End Sub
    Private Sub DGV_M17_FL_KeyDown(sender As Object, e As KeyEventArgs) Handles DGV_M17_FL.KeyDown
        If e.KeyCode = Keys.Delete Then
            HandlePanelDeletion(DGV_M17_FL)
        End If
    End Sub
    Private Sub DGV_M17_FL_DragOver(sender As Object, e As DragEventArgs) Handles DGV_M17_FL.DragOver
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
            Dim panel As String = selectedRow.Cells(1).Value.ToString()
            Dim qty As Integer = Integer.Parse(selectedRow.Cells(2).Value.ToString())

            MovePanelBackToDGVWalls(panelID, panel, qty)
            dgv.Rows.Remove(selectedRow)
            dgv.ClearSelection()
        Else
            'MessageBox.Show("Seleccione un panel para eliminar.", "Eliminar Panel", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Sub MovePanelBackToDGVWalls(panelID As String, panel As String, qty As Integer)
        Dim existsInWalls As Boolean = False

        For Each wallRow As DataGridViewRow In DGV_Floors.Rows
            If wallRow.Cells(1).Value IsNot Nothing AndAlso wallRow.Cells(1).Value.ToString() = panel Then
                Dim wallQty As Integer = Integer.Parse(wallRow.Cells(2).Value.ToString())
                wallRow.Cells(2).Value = wallQty + qty
                existsInWalls = True

                If Not OriginalQuantities.ContainsKey(panel) Then
                    OriginalQuantities(panel) = wallQty + qty
                End If
                Exit For
            End If
        Next

        If Not existsInWalls Then
            Dim newRow As DataGridViewRow = CType(DGV_Floors.Rows(0).Clone(), DataGridViewRow)
            newRow.Cells(0).Value = panelID
            newRow.Cells(1).Value = panel
            newRow.Cells(2).Value = qty
            newRow.Cells(3).Value = Nothing

            If Not OriginalQuantities.ContainsKey(panel) Then
                OriginalQuantities(panel) = qty
            End If

            DGV_Floors.Rows.Add(newRow)
        End If
    End Sub
    Private Sub RemoveRowFromSource(panel As String, ParamArray grids() As DataGridView)
        For Each grid As DataGridView In grids
            For i As Integer = grid.Rows.Count - 1 To 0 Step -1
                Dim row As DataGridViewRow = grid.Rows(i)
                If row.Cells(1).Value IsNot Nothing AndAlso row.Cells(1).Value.ToString() = panel Then
                    grid.Rows.Remove(row)
                    Exit For
                End If
            Next
        Next
    End Sub
    Private Sub Btn_Menu_Click(sender As Object, e As EventArgs) Handles Btn_Menu.Click
        Me.Close()
    End Sub
    Private Sub Clear_Molds_Click(sender As Object, e As EventArgs) Handles Clear_Molds.Click
        Dim dgvList As List(Of DataGridView) = New List(Of DataGridView) From {
        DGV_M15_FL, DGV_M17_FL
    }

        For Each dgv As DataGridView In dgvList
            dgv.Rows.Clear()
        Next
    End Sub
    Private Sub Print_Mold15_Click(sender As Object, e As EventArgs) Handles Print_Mold15.Click
        SavePanels()
        Dim queryAB As String = "SELECT [ASGMT Date], [Panel], [Qty] FROM [Molds] WHERE [Mold] = 'DGV_M15_FL' AND [Estatus] = 'NUEVO' ORDER BY [ASGMT Date] ASC"
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
                                           Dim headerText As String = "Floor-Ceiling"
                                           Dim headerWidth As Single = ev.Graphics.MeasureString(headerText, headerFont).Width
                                           Dim centerX As Single = (ev.PageBounds.Width - headerWidth) / 2
                                           ev.Graphics.DrawString(headerText, headerFont, Brushes.Black, centerX, yPos)
                                           yPos += headerFont.GetHeight(ev.Graphics) + 20

                                           Dim columnHeaderFont As New Font("Arial", 14, FontStyle.Bold)
                                           Dim columnHeaderYPos As Single = yPos

                                           Dim dateColumnWidth As Single = 160
                                           Dim panelColumnWidth As Single = 380
                                           Dim qtyColumnWidth As Single = 160
                                           Dim tableWidth As Single = dateColumnWidth + panelColumnWidth + qtyColumnWidth

                                           Dim tableStartX As Single = (ev.PageBounds.Width - tableWidth) / 2

                                           ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX + tableWidth, yPos)

                                           ev.Graphics.DrawString("Date", columnHeaderFont, Brushes.Black, tableStartX, yPos)
                                           ev.Graphics.DrawString("Mold 15", columnHeaderFont, Brushes.Black, tableStartX + dateColumnWidth, yPos)
                                           ev.Graphics.DrawString("Qty", columnHeaderFont, Brushes.Black, tableStartX + dateColumnWidth + panelColumnWidth, yPos)
                                           yPos += lineHeight

                                           yPos += 2

                                           ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX + tableWidth, yPos)

                                           Dim maxRows As Integer = dtAB.Rows.Count
                                           For i As Integer = 0 To maxRows - 1
                                               Dim cutDateAB As String = If(i < dtAB.Rows.Count, Convert.ToDateTime(dtAB.Rows(i)("ASGMT Date")).ToString("MM/dd/yyyy"), "")
                                               Dim panelAB As String = If(i < dtAB.Rows.Count, dtAB.Rows(i)("Panel").ToString(), "")
                                               Dim qtyAB As String = If(i < dtAB.Rows.Count, dtAB.Rows(i)("Qty").ToString(), "")

                                               ev.Graphics.DrawString(cutDateAB, recordFont, Brushes.Black, tableStartX, yPos)
                                               ev.Graphics.DrawString(panelAB, recordFont, Brushes.Black, tableStartX + dateColumnWidth, yPos)
                                               ev.Graphics.DrawString(qtyAB, recordFont, Brushes.Black, tableStartX + dateColumnWidth + panelColumnWidth, yPos) 'qty de a&b

                                               ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos + lineHeight, tableStartX + tableWidth, yPos + lineHeight)

                                               ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX, yPos + lineHeight)
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth, yPos, tableStartX + dateColumnWidth, yPos + lineHeight) ' borde izquierdo de "Old Mold 1"
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth + panelColumnWidth, yPos, tableStartX + dateColumnWidth + panelColumnWidth, yPos + lineHeight) ' borde izquierdo de "Qty"
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX + tableWidth, yPos, tableStartX + tableWidth, yPos + lineHeight) ' borde derecho final

                                               yPos += lineHeight
                                           Next

                                           ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX + tableWidth, yPos)
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX, columnHeaderYPos, tableStartX, yPos)
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth, columnHeaderYPos, tableStartX + dateColumnWidth, yPos) ' línea entre columnas
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth + panelColumnWidth, columnHeaderYPos, tableStartX + dateColumnWidth + panelColumnWidth, yPos) ' línea entre columnas
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX + tableWidth, columnHeaderYPos, tableStartX + tableWidth, yPos) ' línea derecha

                                       End Sub

        Dim printPreviewDialog As New PrintPreviewDialog()
        printPreviewDialog.Document = printDoc
        printPreviewDialog.ShowDialog()
    End Sub
    Private Sub Print_Mold17_Click(sender As Object, e As EventArgs) Handles Print_Mold17.Click
        SavePanels()
        Dim queryAB As String = "SELECT [ASGMT Date], [Panel], [Qty] FROM [Molds] WHERE [Mold] = 'DGV_M17_FL' AND [Estatus] = 'NUEVO' ORDER BY [ASGMT Date] ASC"
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
                                           Dim headerText As String = "Floor-Ceiling"
                                           Dim headerWidth As Single = ev.Graphics.MeasureString(headerText, headerFont).Width
                                           Dim centerX As Single = (ev.PageBounds.Width - headerWidth) / 2
                                           ev.Graphics.DrawString(headerText, headerFont, Brushes.Black, centerX, yPos)
                                           yPos += headerFont.GetHeight(ev.Graphics) + 20

                                           Dim columnHeaderFont As New Font("Arial", 14, FontStyle.Bold)
                                           Dim columnHeaderYPos As Single = yPos

                                           Dim dateColumnWidth As Single = 160
                                           Dim panelColumnWidth As Single = 380
                                           Dim qtyColumnWidth As Single = 160
                                           Dim tableWidth As Single = dateColumnWidth + panelColumnWidth + qtyColumnWidth

                                           Dim tableStartX As Single = (ev.PageBounds.Width - tableWidth) / 2

                                           ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX + tableWidth, yPos)

                                           ev.Graphics.DrawString("Date", columnHeaderFont, Brushes.Black, tableStartX, yPos)
                                           ev.Graphics.DrawString("Mold 17", columnHeaderFont, Brushes.Black, tableStartX + dateColumnWidth, yPos)
                                           ev.Graphics.DrawString("Qty", columnHeaderFont, Brushes.Black, tableStartX + dateColumnWidth + panelColumnWidth, yPos)
                                           yPos += lineHeight

                                           yPos += 2

                                           ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX + tableWidth, yPos)

                                           Dim maxRows As Integer = dtAB.Rows.Count
                                           For i As Integer = 0 To maxRows - 1
                                               Dim cutDateAB As String = If(i < dtAB.Rows.Count, Convert.ToDateTime(dtAB.Rows(i)("ASGMT Date")).ToString("MM/dd/yyyy"), "")
                                               Dim panelAB As String = If(i < dtAB.Rows.Count, dtAB.Rows(i)("Panel").ToString(), "")
                                               Dim qtyAB As String = If(i < dtAB.Rows.Count, dtAB.Rows(i)("Qty").ToString(), "")

                                               ev.Graphics.DrawString(cutDateAB, recordFont, Brushes.Black, tableStartX, yPos)
                                               ev.Graphics.DrawString(panelAB, recordFont, Brushes.Black, tableStartX + dateColumnWidth, yPos)
                                               ev.Graphics.DrawString(qtyAB, recordFont, Brushes.Black, tableStartX + dateColumnWidth + panelColumnWidth, yPos)

                                               ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos + lineHeight, tableStartX + tableWidth, yPos + lineHeight)

                                               ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX, yPos + lineHeight)
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth, yPos, tableStartX + dateColumnWidth, yPos + lineHeight)
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth + panelColumnWidth, yPos, tableStartX + dateColumnWidth + panelColumnWidth, yPos + lineHeight)
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX + tableWidth, yPos, tableStartX + tableWidth, yPos + lineHeight)

                                               yPos += lineHeight
                                           Next

                                           ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX + tableWidth, yPos)
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX, columnHeaderYPos, tableStartX, yPos)
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth, columnHeaderYPos, tableStartX + dateColumnWidth, yPos)
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth + panelColumnWidth, columnHeaderYPos, tableStartX + dateColumnWidth + panelColumnWidth, yPos)
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX + tableWidth, columnHeaderYPos, tableStartX + tableWidth, yPos)

                                       End Sub

        Dim printPreviewDialog As New PrintPreviewDialog()
        printPreviewDialog.Document = printDoc
        printPreviewDialog.ShowDialog()
    End Sub
    Private Sub Print_All_Molds_Click(sender As Object, e As EventArgs) Handles Print_All_Molds.Click
        SavePanels()

        Dim queryAB As String = "SELECT [ASGMT Date], [Mold], [Panel], [Qty] " &
                        "FROM [Molds] " &
                        "WHERE ([Mold] = 'DGV_M15_FL' OR [Mold] = 'DGV_M17_FL'  " &
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

                                           Dim dateColumnWidth As Single = 130
                                           Dim moldColumnWidth As Single = 160
                                           Dim panelColumnWidth As Single = 310
                                           Dim qtyColumnWidth As Single = 100
                                           Dim tableWidth As Single = dateColumnWidth + moldColumnWidth + panelColumnWidth + qtyColumnWidth

                                           Dim tableStartX As Single = (ev.PageBounds.Width - tableWidth) / 2

                                           ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX + tableWidth, yPos)

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
                                                   Case "DGV_M15_FL"
                                                       mold = "Mold 15"
                                                   Case "DGV_M17_FL"
                                                       mold = "Mold 17"
                                               End Select

                                               ev.Graphics.DrawString(cutDateAB, recordFont, Brushes.Black, tableStartX, yPos)
                                               ev.Graphics.DrawString(mold, recordFont, Brushes.Black, tableStartX + dateColumnWidth, yPos)
                                               ev.Graphics.DrawString(panel, recordFont, Brushes.Black, tableStartX + dateColumnWidth + moldColumnWidth, yPos)
                                               ev.Graphics.DrawString(qty, recordFont, Brushes.Black, tableStartX + dateColumnWidth + moldColumnWidth + panelColumnWidth, yPos)

                                               ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos + lineHeight, tableStartX + tableWidth, yPos + lineHeight)

                                               ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX, yPos + lineHeight)
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth, yPos, tableStartX + dateColumnWidth, yPos + lineHeight)
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth + moldColumnWidth, yPos, tableStartX + dateColumnWidth + moldColumnWidth, yPos + lineHeight) ' borde de "Panel"
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth + moldColumnWidth + panelColumnWidth, yPos, tableStartX + dateColumnWidth + moldColumnWidth + panelColumnWidth, yPos + lineHeight) ' borde de "Qty"
                                               ev.Graphics.DrawLine(Pens.Black, tableStartX + tableWidth, yPos, tableStartX + tableWidth, yPos + lineHeight)

                                               yPos += lineHeight
                                           Next

                                           ev.Graphics.DrawLine(Pens.Black, tableStartX, yPos, tableStartX + tableWidth, yPos)
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX, columnHeaderYPos, tableStartX, yPos)
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth, columnHeaderYPos, tableStartX + dateColumnWidth, yPos)
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth + moldColumnWidth, columnHeaderYPos, tableStartX + dateColumnWidth + moldColumnWidth, yPos) ' línea entre columnas
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX + dateColumnWidth + moldColumnWidth + panelColumnWidth, columnHeaderYPos, tableStartX + dateColumnWidth + moldColumnWidth + panelColumnWidth, yPos) ' línea entre columnas
                                           ev.Graphics.DrawLine(Pens.Black, tableStartX + tableWidth, columnHeaderYPos, tableStartX + tableWidth, yPos)

                                       End Sub

        Dim printPreviewDialog As New PrintPreviewDialog()
        printPreviewDialog.Document = printDoc
        printPreviewDialog.ShowDialog()
    End Sub
    Private Sub FilterToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FilterToolStripMenuItem.Click
        Panel_FC.Visible = True
        LoadJobsFC()
    End Sub
    Private Sub LoadJobsFC()
        Dim uniqueValues As New HashSet(Of String)()
        Dim columnName As String = "Job Number"
        Dim connectionString As String = DatabaseConnection.ConnectionString

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim query As String = $"SELECT DISTINCT [Job Number] FROM Jobs WHERE ([Panel Identifier] = 'Floor' OR [Panel Identifier] = 'Ceiling')"
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
    Private Sub Btn_Filter_Click(sender As Object, e As EventArgs) Handles Btn_Filter.Click
        Dim connectionString As String = DatabaseConnection.ConnectionString
        Dim query As String = "SELECT [ID], [Panel], [QTY], [ASGM Date] FROM [Jobs] WHERE ([Panel Identifier] = 'Floor' OR [Panel Identifier] = 'Ceiling') AND [Status] IS NULL"
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
                    DGV_Floors.Rows.Clear() ' Limpiar filas existentes
                    While reader.Read()
                        Dim panelID As String = reader("ID").ToString()
                        Dim panel As String = reader("Panel").ToString()
                        Dim qty As Integer = Convert.ToInt32(reader("QTY"))
                        Dim DateSGM As String = If(IsDBNull(reader("ASGM Date")), String.Empty, CType(reader("ASGM Date"), DateTime).ToString("MM/dd/yyyy HH:mm"))

                        DGV_Floors.Rows.Add(panelID, panel, qty, DateSGM)
                    End While
                End Using
            End Using

            If DGV_Floors.Columns.Count > 0 Then
                DGV_Floors.Columns(0).HeaderText = "ID"
                DGV_Floors.Columns(1).HeaderText = "Panel"
                DGV_Floors.Columns(2).HeaderText = "Qty"
                DGV_Floors.Columns(3).HeaderText = "Date"
            End If

        Catch ex As Exception
            MessageBox.Show("Error al filtrar los datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Panel_FC.Visible = False
    End Sub
    Private Sub Btn_Cancel_Click(sender As Object, e As EventArgs) Handles Btn_Cancel.Click
        Panel_FC.Visible = False
    End Sub
    Private Sub Btn_Clear_Filter_Click(sender As Object, e As EventArgs) Handles Btn_Clear_Filter.Click
        LoadFCPanels()
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
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
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LNK_FCTM.LinkClicked
        Me.Hide()
        Dim FCTM As New FCT_Mold()
        FCTM.ShowDialog()
        Me.Close()
    End Sub
End Class