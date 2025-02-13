Imports System.Data.SqlClient

Public Class Jobs

    Private Async Sub Jobs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Panel_Filters.Visible = False

        Try
            Dim connectionString As String = DatabaseConnection.ConnectionString

            Dim JobsQuery As String = "SELECT [ID], [Job Number], [Panel], [QTY], [Description], [ASGM Date], [Status], [Mold], [Completed Date] FROM [Jobs]"

            Dim dataTable As DataTable = Await Task.Run(Function()
                                                            Using connection As New SqlConnection(connectionString)
                                                                Using adapter As New SqlDataAdapter(JobsQuery, connection)
                                                                    Dim tempTable As New DataTable()
                                                                    adapter.Fill(tempTable)
                                                                    Return tempTable
                                                                End Using
                                                            End Using
                                                        End Function)

            Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
            checkBoxColumn.HeaderText = ""
            checkBoxColumn.Name = "CheckBoxColumn"
            checkBoxColumn.Width = 30
            checkBoxColumn.ReadOnly = False
            checkBoxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGV_Jobs.Columns.Insert(0, checkBoxColumn)

            DGV_Jobs.DataSource = dataTable

            If DGV_Jobs.Columns.Contains("ASGM Date") Then
                DGV_Jobs.Columns("ASGM Date").DefaultCellStyle.Format = "MM/dd/yyyy"
            End If

            DGV_Jobs.SelectionMode = DataGridViewSelectionMode.FullRowSelect


            For Each colName As String In {"ID"}
                If DGV_Jobs.Columns.Contains(colName) Then
                    DGV_Jobs.Columns(colName).Visible = False
                End If
            Next

            AdjustColumns(DGV_Jobs)

            DGV_Jobs.EnableHeadersVisualStyles = False
            DGV_Jobs.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 153, 255)
            DGV_Jobs.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            UpdateMolds()

        Catch ex As Exception
            MessageBox.Show("Error when uploading unique values: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DGV_Jobs_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DGV_Jobs.CellFormatting
        Dim StatusColumnIndex As Integer = 7 ' Ajusta el índice según la posición real de la columna "Status"
        Dim CompleteColor As Color = Color.FromArgb(0, 176, 80)

        If e.RowIndex >= 0 AndAlso StatusColumnIndex < DGV_Jobs.Columns.Count Then
            Dim statusCellValue As Object = DGV_Jobs.Rows(e.RowIndex).Cells(StatusColumnIndex).Value

            If statusCellValue IsNot Nothing Then
                Dim status As String = statusCellValue.ToString().Trim()
                If status = "Complete" Then
                    DGV_Jobs.Rows(e.RowIndex).DefaultCellStyle.BackColor = CompleteColor
                Else
                    ' Resetear el color de las filas que no cumplen la condición
                    DGV_Jobs.Rows(e.RowIndex).DefaultCellStyle.BackColor = Color.White
                End If
            End If
        End If
    End Sub
    Private Sub CargarDatosDGV_Jobs()
        Dim connectionString As String = DatabaseConnection.ConnectionString

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim query As String = "SELECT [ID], [Job Number], [Panel], [QTY], [Description], [ASGM Date], [Status], [Mold], [Completed Date] FROM [Jobs]"
            Dim adapter As New SqlDataAdapter(query, connection)
            Dim table As New DataTable()
            adapter.Fill(table)

            DGV_Jobs.DataSource = table

            If DGV_Jobs.Columns.Contains("ASGM Date") Then
                DGV_Jobs.Columns("ASGM Date").DefaultCellStyle.Format = "MM/dd/yyyy"
            End If

            DGV_Jobs.SelectionMode = DataGridViewSelectionMode.FullRowSelect

            For Each colName As String In {"ID"}
                If DGV_Jobs.Columns.Contains(colName) Then
                    DGV_Jobs.Columns(colName).Visible = False
                End If
            Next

            AdjustColumns(DGV_Jobs)

            DGV_Jobs.EnableHeadersVisualStyles = False
            DGV_Jobs.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 153, 255)
            DGV_Jobs.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        End Using
        UpdateMoldName()
    End Sub
    Public Sub UpdateMolds()
        Dim connectionString As String = DatabaseConnection.ConnectionString

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim moldsDictionary As New Dictionary(Of String, String)
            Dim selectMoldsQuery As String = "SELECT ID, Mold FROM Molds"

            Using selectCommand As New SqlCommand(selectMoldsQuery, connection)
                Using reader As SqlDataReader = selectCommand.ExecuteReader()
                    While reader.Read()
                        Dim id As String = reader("ID").ToString()
                        Dim mold As String = reader("Mold").ToString()
                        moldsDictionary(id) = mold
                    End While
                End Using
            End Using

            Dim updateQuery As String = "UPDATE Jobs SET Mold = @Mold WHERE ID = @ID"

            Using updateCommand As New SqlCommand(updateQuery, connection)
                updateCommand.Parameters.Add("@Mold", SqlDbType.VarChar)
                updateCommand.Parameters.Add("@ID", SqlDbType.VarChar)

                For Each id In moldsDictionary.Keys
                    updateCommand.Parameters("@Mold").Value = moldsDictionary(id)
                    updateCommand.Parameters("@ID").Value = id

                    updateCommand.ExecuteNonQuery()
                Next
            End Using
        End Using
        UpdateMoldName()
    End Sub
    Private Sub UpdateMoldName()
        Dim columnName As String = "Mold"
        Dim dataGridView As DataGridView = DGV_Jobs

        For Each row As DataGridViewRow In dataGridView.Rows
            If Not row.IsNewRow Then
                Dim moldValue As String = row.Cells(columnName).Value.ToString()

                Select Case moldValue
                    Case "DGV_M1AB_W"
                        row.Cells(columnName).Value = "Mold 1 A&B"
                    Case "DGV_M1CD_W"
                        row.Cells(columnName).Value = "Mold 1 C&D"
                    Case "DGV_M2AB_W"
                        row.Cells(columnName).Value = "Mold 2 A&B"
                    Case "DGV_M2CD_W"
                        row.Cells(columnName).Value = "Mold 2 C&D"
                    Case "DGV_M3AB_W"
                        row.Cells(columnName).Value = "Mold 3 A&B"
                    Case "DGV_M3CD_W"
                        row.Cells(columnName).Value = "Mold 3 C&D"
                    Case "DGV_M4AB_W"
                        row.Cells(columnName).Value = "Mold 4 A&B"
                    Case "DGV_M4CD_W"
                        row.Cells(columnName).Value = "Mold 4 C&D"
                    Case "DGV_M5AB_W"
                        row.Cells(columnName).Value = "Mold 5 A&B"
                    Case "DGV_M5CD_W"
                        row.Cells(columnName).Value = "Mold 5 C&D"
                    Case "DGV_M6AB_W"
                        row.Cells(columnName).Value = "Mold 6 A&B"
                    Case "DGV_M6CD_W"
                        row.Cells(columnName).Value = "Mold 6 C&D"
                    Case "DGV_OM1_W"
                        row.Cells(columnName).Value = "Old Mold 1"
                    Case "DGV_OM2_W"
                        row.Cells(columnName).Value = "Old Mold 2"
                    Case "DGV_OM3_W"
                        row.Cells(columnName).Value = "Old Mold 3"
                    Case "DGV_M1_CO"
                        row.Cells(columnName).Value = "Mold 1 Corner"
                    Case "DGV_M3_CO"
                        row.Cells(columnName).Value = "Mold 3 Corner"
                    Case "DGV_M15_FL"
                        row.Cells(columnName).Value = "Mold 15 Floors"
                    Case "DGV_M17_FL"
                        row.Cells(columnName).Value = "Mold 17 Floors"
                    Case "DGV_M1_TG"
                        row.Cells(columnName).Value = "Mold 1 T&G"
                    Case "DGV_MB_TG"
                        row.Cells(columnName).Value = "Mold B T&G"
                    Case "DGV_TG_M5"
                        row.Cells(columnName).Value = "Mold 5 T&G"
                    Case "DGV_Guillotine1"
                        row.Cells(columnName).Value = "Mold 1 Guillotine"
                    Case "DGV_Guillotine_2"
                        row.Cells(columnName).Value = "Mold 2 Guillotine"
                    Case "DGV_TeeM"
                        row.Cells(columnName).Value = "Tee Mold"
                End Select
            End If
        Next
    End Sub
    Public SelectedIDs As New List(Of String)
    Private Sub DGV_Jobs_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Jobs.CellClick
        ' Asegúrate de que la columna clicada sea una columna de datos y no de encabezado
        If e.RowIndex >= 0 Then
            ' Si se hace clic en la primera columna (CheckBoxColumn)
            If e.ColumnIndex = 0 Then
                ' Alternar el estado del checkbox de la fila clicada
                Dim checkBoxCell As DataGridViewCheckBoxCell = CType(DGV_Jobs.Rows(e.RowIndex).Cells("CheckBoxColumn"), DataGridViewCheckBoxCell)
                checkBoxCell.Value = Not CType(checkBoxCell.Value, Boolean)
            Else
                ' Si se hace clic en cualquier otra celda, marcar el checkbox correspondiente
                Dim checkBoxCell As DataGridViewCheckBoxCell = CType(DGV_Jobs.Rows(e.RowIndex).Cells("CheckBoxColumn"), DataGridViewCheckBoxCell)
                checkBoxCell.Value = True
            End If
        End If
    End Sub
    Private Sub DGV_Jobs_SelectionChanged(sender As Object, e As EventArgs) Handles DGV_Jobs.SelectionChanged
        ' Marcar checkboxes en las filas seleccionadas sin desmarcar las demás
        For Each row As DataGridViewRow In DGV_Jobs.SelectedRows
            Dim checkBoxCell As DataGridViewCheckBoxCell = CType(row.Cells("CheckBoxColumn"), DataGridViewCheckBoxCell)
            checkBoxCell.Value = True
        Next
        UpdateCheckedCount()
    End Sub
    Private Sub UpdateCheckedCount()
        ' Contar y mostrar el total de checkboxes marcados
        Dim checkedCount As Integer = DGV_Jobs.Rows.Cast(Of DataGridViewRow)().Count(Function(row) CType(row.Cells("CheckBoxColumn"), DataGridViewCheckBoxCell).Value = True)
        Lbl_Qty_Sel.Text = checkedCount.ToString()
    End Sub
    Private Sub AdjustColumns(dataGridView As DataGridView)
        For Each column As DataGridViewColumn In dataGridView.Columns
            column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        Next
    End Sub
    Private Sub Txt_Bx_Jobs_TextChanged(sender As Object, e As EventArgs) Handles Txt_Bx_Jobs.TextChanged
        Dim searchJob As String = Txt_Bx_Jobs.Text.ToLower()

        For i As Integer = 0 To Checked_Lst_Bx_Jobs.Items.Count - 1
            Dim itemText As String = Checked_Lst_Bx_Jobs.Items(i).ToString().ToLower()

            If itemText.Contains(searchJob) Then
                Checked_Lst_Bx_Jobs.SetItemChecked(i, True)
            Else
                Checked_Lst_Bx_Jobs.SetItemChecked(i, False)
            End If
        Next
    End Sub
    Private Sub Btn_Cancel_Filter_Job_Click(sender As Object, e As EventArgs) Handles Btn_Cancel_Filter_Job.Click
        Panel_Filters.Visible = False
    End Sub
    Private currentFilters As String = ""
    Private Async Sub Btn_Filter_Job_Click(sender As Object, e As EventArgs) Handles Btn_Filter.Click
        Dim moldMappings As New Dictionary(Of String, String) From {
        {"Mold 1 A&B (Wall)", "DGV_M1AB_W"},
        {"Mold 1 C&D (Wall)", "DGV_M1CD_W"},
        {"Mold 2 A&B (Wall)", "DGV_M2AB_W"},
        {"Mold 2 C&D (Wall)", "DGV_M2CD_W"},
        {"Mold 3 A&B (Wall)", "DGV_M3AB_W"},
        {"Mold 3 C&D (Wall)", "DGV_M3CD_W"},
        {"Mold 4 A&B (Wall)", "DGV_M4AB_W"},
        {"Mold 4 C&D (Wall)", "DGV_M4CD_W"},
        {"Mold 5 A&B (Wall)", "DGV_M5AB_W"},
        {"Mold 5 C&D (Wall)", "DGV_M5CD_W"},
        {"Mold 6 A&B (Wall)", "DGV_M6AB_W"},
        {"Mold 6 C&D (Wall)", "DGV_M6CD_W"},
        {"Old Mold 1 (Wall)", "DGV_OM1_W"},
        {"Old Mold 2 (Wall)", "DGV_OM2_W"},
        {"Old Mold 3 (Wall)", "DGV_OM3_W"},
        {"Mold 1 (Corner)", "DGV_M1_CO"},
        {"Mold 3 (Corner)", "DGV_M3_CO"},
        {"Mold 1 (35's TG)", "DGV_M1_TG"},
        {"Mold B (35's TG)", "DGV_MB_TG"},
        {"Mold 5"" (35's TG)", "DGV_TG_M5"},
        {"Mold 15 (Floor-Ceiling)", "DGV_M15_FL"},
        {"Mold 17 (Floor-Ceiling)", "DGV_M17_FL"},
        {"Mold 1 (Guillotine)", "DGV_Guillotine1"},
        {"Mold 2 (Guillotine)", "DGV_Guillotine_2"},
        {"Mold 1 (Tee Mold)", "DGV_TeeM"}
    }

        ' Crear listas de moldes, trabajos, fechas y paneles seleccionados
        Dim selectedMolds As New List(Of String)
        For Each item In Checked_Lst_Bx_Molds.CheckedItems
            If moldMappings.ContainsKey(item.ToString()) Then
                selectedMolds.Add(moldMappings(item.ToString()))
            End If
        Next

        Dim selectedJobs As New List(Of String)
        For Each item In Checked_Lst_Bx_Jobs.CheckedItems
            selectedJobs.Add(item.ToString())
        Next

        Dim selectedDates As New List(Of String)
        For Each item In Checked_Lst_Bx_Dates.CheckedItems
            selectedDates.Add(item.ToString())
        Next

        Dim selectedPanels As New List(Of String)
        For Each item In Checked_Lst_Box_Panels.CheckedItems
            selectedPanels.Add(item.ToString())
        Next

        ' Si no hay ningún molde seleccionado y no hay otras opciones seleccionadas, no hacer nada
        If selectedMolds.Count = 0 AndAlso selectedJobs.Count = 0 AndAlso selectedDates.Count = 0 AndAlso selectedPanels.Count = 0 Then
            MessageBox.Show("Please select at least one filter option.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Construir las condiciones de filtrado dinámicamente
        Dim conditions As New List(Of String)

        If selectedMolds.Count > 0 Then
            Dim moldConditions As String = String.Join(" OR ", selectedMolds.Select(Function(m) $"[Mold] = '{m}'"))
            conditions.Add($"({moldConditions})")
        End If

        If selectedJobs.Count > 0 Then
            Dim jobConditions As String = String.Join(" OR ", selectedJobs.Select(Function(j) $"[Job Number] = '{j}'"))
            conditions.Add($"({jobConditions})")
        End If

        If selectedDates.Count > 0 Then
            Dim dateConditions As String = String.Join(" OR ", selectedDates.Select(Function(d) $"CONVERT(VARCHAR, [ASGM Date], 101) = '{d}'"))
            conditions.Add($"({dateConditions})")
        End If

        If selectedPanels.Count > 0 Then
            Dim panelConditions As String = String.Join(" OR ", selectedPanels.Select(Function(p) $"[Panel Identifier] = '{p}'"))
            conditions.Add($"({panelConditions})")
        End If

        Dim filterConditions As String = String.Join(" AND ", conditions)
        Dim JobsQuery As String = $"SELECT [ID], [Job Number], [Panel], [QTY], [Description], [ASGM Date], [Status], [Mold], [Completed Date] FROM [Jobs] WHERE {filterConditions}"

        ' Cargar los datos en el DataGridView usando el query
        Try
            Dim connectionString As String = DatabaseConnection.ConnectionString

            Dim dataTable As DataTable = Await Task.Run(Function()
                                                            Using connection As New SqlConnection(connectionString)
                                                                Using adapter As New SqlDataAdapter(JobsQuery, connection)
                                                                    Dim tempTable As New DataTable()
                                                                    adapter.Fill(tempTable)
                                                                    Return tempTable
                                                                End Using
                                                            End Using
                                                        End Function)

            ' Asignar el resultado al DataGridView
            DGV_Jobs.DataSource = dataTable

            Panel_Molds.Visible = False
            Panel_Filters.Visible = False
            UpdateMoldName()
        Catch ex As Exception
            MessageBox.Show("Error filtering jobs: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Txt_Bx_Dates_TextChanged(sender As Object, e As EventArgs) Handles Txt_Bx_Dates.TextChanged
        Dim searchDate As String = Txt_Bx_Dates.Text.ToLower()

        For i As Integer = 0 To Checked_Lst_Bx_Dates.Items.Count - 1
            Dim itemText As String = Checked_Lst_Bx_Dates.Items(i).ToString().ToLower()

            If itemText.Contains(searchDate) Then
                Checked_Lst_Bx_Dates.SetItemChecked(i, True)
            Else
                Checked_Lst_Bx_Dates.SetItemChecked(i, False)
            End If
        Next
    End Sub
    Private Sub Txt_Bx_Panel_TextChanged(sender As Object, e As EventArgs) Handles Txt_Bx_Panel.TextChanged
        Dim searchDate As String = Txt_Bx_Panel.Text.ToLower()

        For i As Integer = 0 To Checked_Lst_Box_Panels.Items.Count - 1
            Dim itemText As String = Checked_Lst_Box_Panels.Items(i).ToString().ToLower()

            If itemText.Contains(searchDate) Then
                Checked_Lst_Box_Panels.SetItemChecked(i, True)
            Else
                Checked_Lst_Box_Panels.SetItemChecked(i, False)
            End If
        Next
    End Sub
    Private Sub Btn_Filter_Panel_Click(sender As Object, e As EventArgs)
        Dim connectionString As String = DatabaseConnection.ConnectionString
        Dim query As String = "SELECT * FROM [Jobs] WHERE 1=1"
        Dim filters As New List(Of String)
        Dim parameters As New List(Of SqlParameter)

        If Checked_Lst_Box_Panels.CheckedItems.Count > 0 Then
            Dim JobFilter As New List(Of String)
            Dim index As Integer = 0
            For Each item As String In Checked_Lst_Box_Panels.CheckedItems
                Dim paramName As String = "@PanelIdentifier_" & index.ToString()
                JobFilter.Add("[Panel Identifier] = " & paramName)
                parameters.Add(New SqlParameter(paramName, item))
                index += 1
            Next
            filters.Add("(" & String.Join(" OR ", JobFilter) & ")")
        End If

        If filters.Count > 0 Then
            currentFilters = String.Join(" AND ", filters)
            query &= " AND " & currentFilters
        End If

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim dataTable As New DataTable()
                Using adapter As New SqlDataAdapter(query, connection)
                    For Each param As SqlParameter In parameters
                        adapter.SelectCommand.Parameters.Add(param)
                    Next
                    adapter.Fill(dataTable)
                End Using

                DGV_Jobs.DataSource = dataTable

                If DGV_Jobs.Columns.Count > 0 Then
                    DGV_Jobs.Columns(DGV_Jobs.Columns.Count - 1).Width = 150
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error when filter data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Btn_Filters_Click(sender As Object, e As EventArgs) Handles Btn_Filters.Click
        If Panel_Filters.Visible = False Then
            Panel_Filters.Visible = True
        Else
            Panel_Filters.Visible = False
        End If
        Panel_Jobs.Visible = False
        Panel_Dates_Filter.Visible = False
        Panel_TypePanels.Visible = False
        Panel_Molds.Visible = False
    End Sub
    Private Sub Btn_Cancel_Filter_Panel_Click(sender As Object, e As EventArgs)
        Panel_TypePanels.Visible = False
    End Sub
    Private Sub Check_Bx_Select_All_Jobs_CheckedChanged(sender As Object, e As EventArgs) Handles Check_Bx_Select_All_Jobs.CheckedChanged
        For i As Integer = 0 To Checked_Lst_Bx_Jobs.Items.Count - 1
            Checked_Lst_Bx_Jobs.SetItemChecked(i, Check_Bx_Select_All_Jobs.Checked)
        Next
    End Sub
    Private Sub Check_Bx_Select_All_Dates_CheckedChanged(sender As Object, e As EventArgs) Handles Check_Bx_Select_All_Dates.CheckedChanged
        For i As Integer = 0 To Checked_Lst_Bx_Dates.Items.Count - 1
            Checked_Lst_Bx_Dates.SetItemChecked(i, Check_Bx_Select_All_Dates.Checked)
        Next
    End Sub
    Private Sub Check_Bx_Select_All_Panels_CheckedChanged(sender As Object, e As EventArgs) Handles Check_Bx_Select_All_Panels.CheckedChanged
        For i As Integer = 0 To Checked_Lst_Box_Panels.Items.Count - 1
            Checked_Lst_Box_Panels.SetItemChecked(i, Check_Bx_Select_All_Panels.Checked)
        Next
    End Sub
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Hide()
        Dim Menu As New Form1()
        Menu.ShowDialog()
        Me.Show()
        Me.Close()
    End Sub
    Private Sub Lnk_Lbl_Molds_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Lnk_Lbl_Molds.LinkClicked


    End Sub
    Private Sub Btn_Edit_Rows_Click(sender As Object, e As EventArgs) Handles Btn_Edit_Rows.Click
        Dim idsSeleccionados As New List(Of String)

        For Each fila As DataGridViewRow In DGV_Jobs.Rows
            Dim ischecked As Boolean = Convert.ToBoolean(fila.Cells("CheckboxColumn").Value)
            If ischecked Then
                Dim id As String = fila.Cells("ID").Value.ToString()
                idsSeleccionados.Add(id)
            End If
        Next

        If idsSeleccionados.Count = 0 Then
            MessageBox.Show("Select at least one Row")
            Return
        End If
        Me.Hide()
        Dim EditJobs As New Edit_Jobs()
        EditJobs.MostrarIDsSeleccionados(idsSeleccionados)
        EditJobs.ShowDialog()

    End Sub
    Public Sub LoadUniqueValuesJobs()
        Dim uniqueValues As New HashSet(Of String)()
        Dim columnName As String = "Job Number"
        Dim connectionString As String = DatabaseConnection.ConnectionString

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim query As String = $"SELECT DISTINCT [{columnName}] FROM Jobs WHERE [{columnName}] IS NOT NULL"
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

            Checked_Lst_Bx_Jobs.Items.Clear()
            Dim sortedValues = uniqueValues.OrderBy(Function(dateValue) dateValue).ToList()

            For Each value As String In sortedValues
                Checked_Lst_Bx_Jobs.Items.Add(value)
            Next

        Catch ex As Exception
            MessageBox.Show("Error loading unique dates: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub LoadUniqueValuesDates()
        Dim uniqueValues As New HashSet(Of DateTime)()
        Dim columnName As String = "ASGM Date"
        Dim connectionString As String = DatabaseConnection.ConnectionString

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim query As String = $"SELECT DISTINCT [{columnName}] FROM Jobs WHERE [{columnName}] IS NOT NULL"
                Using command As New SqlCommand(query, connection)
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim dateValue As Object = reader(columnName)
                            If dateValue IsNot Nothing AndAlso TypeOf dateValue Is DateTime Then
                                uniqueValues.Add(DirectCast(dateValue, DateTime))
                            End If
                        End While
                    End Using
                End Using
            End Using

            Checked_Lst_Bx_Dates.Items.Clear()
            Dim sortedValues = uniqueValues.OrderBy(Function(dateValue) dateValue).ToList()

            For Each dateValue As DateTime In sortedValues
                Checked_Lst_Bx_Dates.Items.Add(dateValue.ToString("MM/dd/yyyy"))
            Next

        Catch ex As Exception
            MessageBox.Show("Error loading unique dates: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub LoadUniqueValuesPanels()
        Dim uniqueValues As New HashSet(Of String)()
        Dim columnName As String = "Panel Identifier"
        Dim connectionString As String = DatabaseConnection.ConnectionString

        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim query As String = $"SELECT DISTINCT [{columnName}] FROM Jobs WHERE [{columnName}] IS NOT NULL"
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

            Checked_Lst_Box_Panels.Items.Clear()
            Dim sortedValues = uniqueValues.OrderBy(Function(dateValue) dateValue).ToList()

            For Each value As String In sortedValues
                Checked_Lst_Box_Panels.Items.Add(value)
            Next

        Catch ex As Exception
            MessageBox.Show("Error loading unique dates: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Btn_Molds_Click(sender As Object, e As EventArgs) Handles Btn_Molds.Click
        If Panel_Molds.Visible = False Then
            Panel_Molds.Visible = True
            Panel_Filters.Size = New Size(778, 331)
        Else
            Panel_Molds.Visible = False
            Panel_Filters.Size = New Size(778, 53)
        End If
    End Sub
    Private Sub Txt_Bx_Mold_TextChanged(sender As Object, e As EventArgs) Handles Txt_Bx_Mold.TextChanged
        Dim searchMold As String = Txt_Bx_Mold.Text.ToLower()

        For i As Integer = 0 To Checked_Lst_Bx_Molds.Items.Count - 1
            Dim itemText As String = Checked_Lst_Bx_Molds.Items(i).ToString().ToLower()

            If itemText.Contains(searchMold) Then
                Checked_Lst_Bx_Molds.SetItemChecked(i, True)
            Else
                Checked_Lst_Bx_Molds.SetItemChecked(i, False)
            End If
        Next
    End Sub

    Private currentSearchIndex As Integer = -1
    Private searchResults As New List(Of DataGridViewRow)
    Private Const JobNumberColumnName As String = "Job Number"
    Private Sub Txt_Bx_Job_Fnd_KeyDown(sender As Object, e As KeyEventArgs) Handles Txt_Bx_Job_Fnd.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True  ' Prevents the ding sound when pressing Enter

            ' Reset the search if the search text has changed or if this is a new search
            If Txt_Bx_Job_Fnd.Text.Trim() <> "" AndAlso (currentSearchIndex = -1 OrElse searchResults.Count = 0) Then
                searchResults.Clear()
                Dim searchText As String = Txt_Bx_Job_Fnd.Text.Trim().ToLower()

                ' Find rows where the "Job Number" column contains the search text
                For Each row As DataGridViewRow In DGV_Jobs.Rows
                    Dim cell As DataGridViewCell = row.Cells(JobNumberColumnName)
                    If cell.Value IsNot Nothing AndAlso cell.Value.ToString().Trim().ToLower().Contains(searchText) Then
                        searchResults.Add(row)
                    End If
                Next

                currentSearchIndex = 0  ' Start at the first result
            End If

            ' Check if there are any results
            If searchResults.Count > 0 Then
                If currentSearchIndex >= searchResults.Count Then
                    MessageBox.Show("No more results")
                    currentSearchIndex = 0  ' Reset to the beginning of the search results
                Else
                    ' Select and scroll to the next matching row
                    Dim row As DataGridViewRow = searchResults(currentSearchIndex)
                    DGV_Jobs.ClearSelection()
                    row.Selected = True
                    DGV_Jobs.FirstDisplayedScrollingRowIndex = Math.Max(row.Index - 2, 0)  ' Scroll to show the row

                    currentSearchIndex += 1  ' Move to the next result
                End If
            Else
                MessageBox.Show("No results found")
            End If
        End If
    End Sub
    Private Sub Btn_Complete_Panels_Click(sender As Object, e As EventArgs) Handles Btn_Complete_Panels.Click
        Dim idsSeleccionados As New List(Of String)

        For Each fila As DataGridViewRow In DGV_Jobs.Rows
            Dim isChecked As Boolean = Convert.ToBoolean(fila.Cells("CheckboxColumn").Value)

            ' Check if the row is selected
            If isChecked Then
                Dim moldValue As Object = fila.Cells("Mold").Value
                Dim asgmDateValue As Object = fila.Cells("ASGM Date").Value

                ' Ensure "Mold" and "ASGM Date" columns are not empty
                If moldValue IsNot Nothing AndAlso Not String.IsNullOrEmpty(moldValue.ToString()) AndAlso
               asgmDateValue IsNot Nothing AndAlso Not String.IsNullOrEmpty(asgmDateValue.ToString()) Then

                    ' Add ID if both "Mold" and "ASGM Date" have values
                    Dim id As String = fila.Cells("ID").Value.ToString()
                    idsSeleccionados.Add(id)
                End If
            End If
        Next

        ' Check if there are no selected rows with valid values
        If idsSeleccionados.Count = 0 Then
            MessageBox.Show("Panel(s) have not been assigned to a mold")
            Return
        End If

        Dim fechaCompleto As DateTime = DateTime.Now
        Dim connectionString As String = DatabaseConnection.ConnectionString

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim query As String = "UPDATE Jobs SET Status = @Status, [Completed Date] = @CompletedDate WHERE ID IN (" & String.Join(",", idsSeleccionados.Select(Function(id) "'" & id & "'")) & ")"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Status", "Complete")
                command.Parameters.AddWithValue("@CompletedDate", fechaCompleto)

                Dim rowsAffected As Integer = command.ExecuteNonQuery()
                MessageBox.Show(rowsAffected.ToString() & " rows updated to Complete.")
            End Using
        End Using

        ' Actualizar estado de moldes
        UpdateMoldEstatus()

        ' Recargar datos del DataGridView
        CargarDatosDGV_Jobs()
    End Sub
    Private Async Sub UpdateMold()
        Panel_Filters.Visible = False

        Try
            Dim connectionString As String = DatabaseConnection.ConnectionString

            Dim JobsQuery As String = "SELECT [ID], [Job Number], [Panel], [QTY], [Description], [ASGM Date], [Status], [Mold], [Completed Date] FROM [Jobs]"

            Dim dataTable As DataTable = Await Task.Run(Function()
                                                            Using connection As New SqlConnection(connectionString)
                                                                Using adapter As New SqlDataAdapter(JobsQuery, connection)
                                                                    Dim tempTable As New DataTable()
                                                                    adapter.Fill(tempTable)
                                                                    Return tempTable
                                                                End Using
                                                            End Using
                                                        End Function)

            DGV_Jobs.DataSource = dataTable

            If DGV_Jobs.Columns.Contains("ASGM Date") Then
                DGV_Jobs.Columns("ASGM Date").DefaultCellStyle.Format = "MM/dd/yyyy"
            End If

            DGV_Jobs.SelectionMode = DataGridViewSelectionMode.FullRowSelect


            For Each colName As String In {"ID"}
                If DGV_Jobs.Columns.Contains(colName) Then
                    DGV_Jobs.Columns(colName).Visible = False
                End If
            Next

            AdjustColumns(DGV_Jobs)

            DGV_Jobs.EnableHeadersVisualStyles = False
            DGV_Jobs.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 153, 255)
            DGV_Jobs.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            UpdateMolds()

        Catch ex As Exception
            MessageBox.Show("Error when uploading unique values: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub UpdateMoldEstatus()
        ' Definir la cadena de conexión
        Dim connectionString As String = DatabaseConnection.ConnectionString

        ' Crear la conexión a la base de datos
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            ' Paso 2: Obtener los IDs de la tabla Jobs donde el Status sea 'Complete'
            Dim getCompletedJobsQuery As String = "SELECT ID FROM Jobs WHERE Status = 'Complete'"
            Dim completedJobs As New List(Of String)()

            Using getCompletedJobsCommand As New SqlCommand(getCompletedJobsQuery, connection)
                Using reader As SqlDataReader = getCompletedJobsCommand.ExecuteReader()
                    While reader.Read()
                        completedJobs.Add(reader.GetString(0)) ' Suponiendo que la columna ID es de tipo nvarchar
                    End While
                End Using
            End Using

            ' Paso 3 y 4: Buscar estos IDs en la tabla Molds y eliminar los registros coincidentes
            If completedJobs.Count > 0 Then
                ' Crear una cadena de IDs separados por comas, cada uno entre comillas simples
                Dim ids As String = String.Join(",", completedJobs.Select(Function(id) $"'{id.Replace("'", "''")}'"))

                ' Crear la consulta para eliminar los registros en la tabla Molds
                Dim deleteMoldsQuery As String = $"DELETE FROM Molds WHERE ID IN ({ids})"

                Using deleteMoldsCommand As New SqlCommand(deleteMoldsQuery, connection)
                    Dim rowsAffected As Integer = deleteMoldsCommand.ExecuteNonQuery()
                    ' Opcional: Puedes manejar el resultado, por ejemplo, mostrar un mensaje con el número de filas afectadas
                    'MessageBox.Show($"{rowsAffected} registros eliminados de la tabla Molds.")
                End Using
            End If
        End Using
    End Sub
    Private Async Sub Lnk_lbl_Filters_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Lnk_lbl_Filters.LinkClicked
        Panel_Filters.Visible = False

        Try
            Dim connectionString As String = DatabaseConnection.ConnectionString

            Dim JobsQuery As String = "SELECT [ID], [Job Number], [Panel], [QTY], [Description], [ASGM Date], [Status], [Mold], [Completed Date] FROM [Jobs]"

            Dim dataTable As DataTable = Await Task.Run(Function()
                                                            Using connection As New SqlConnection(connectionString)
                                                                Using adapter As New SqlDataAdapter(JobsQuery, connection)
                                                                    Dim tempTable As New DataTable()
                                                                    adapter.Fill(tempTable)
                                                                    Return tempTable
                                                                End Using
                                                            End Using
                                                        End Function)

            DGV_Jobs.DataSource = dataTable

            If DGV_Jobs.Columns.Contains("ASGM Date") Then
                DGV_Jobs.Columns("ASGM Date").DefaultCellStyle.Format = "MM/dd/yyyy"
            End If

            DGV_Jobs.SelectionMode = DataGridViewSelectionMode.FullRowSelect


            For Each colName As String In {"ID"}
                If DGV_Jobs.Columns.Contains(colName) Then
                    DGV_Jobs.Columns(colName).Visible = False
                End If
            Next

            AdjustColumns(DGV_Jobs)

            DGV_Jobs.EnableHeadersVisualStyles = False
            DGV_Jobs.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 153, 255)
            DGV_Jobs.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            UpdateMolds()

        Catch ex As Exception
            MessageBox.Show("Error when uploading unique values: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Btn_Jobs_Filter_Click(sender As Object, e As EventArgs) Handles Btn_Jobs_Filter.Click
        If Panel_Jobs.Visible = False Then
            Panel_Jobs.Visible = True
            Panel_Filters.Size = New Size(778, 331)
        Else
            Panel_Jobs.Visible = False
            Panel_Filters.Size = New Size(778, 53)
        End If

        LoadUniqueValuesJobs()
    End Sub
    Private Sub Btn_CutDate_Filter_Click(sender As Object, e As EventArgs) Handles Btn_CutDate_Filter.Click
        If Panel_Dates_Filter.Visible = False Then
            Panel_Dates_Filter.Visible = True
            Panel_Filters.Size = New Size(778, 331)
        Else
            Panel_Dates_Filter.Visible = False
            Panel_Filters.Size = New Size(778, 53)
        End If

        LoadUniqueValuesDates()
    End Sub
    Private Sub Btn_Panel_Filter_Click(sender As Object, e As EventArgs) Handles Btn_Panel_Filter.Click
        If Panel_TypePanels.Visible = False Then
            Panel_TypePanels.Visible = True
            Panel_Filters.Size = New Size(778, 331)
        Else
            Panel_TypePanels.Visible = False
            Panel_Filters.Size = New Size(778, 53)
        End If

        LoadUniqueValuesPanels()
    End Sub
    Private Sub Lnk_Info_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Lnk_Info.LinkClicked
        MessageBox.Show("Assignment Date: Panel inserted into a Mold but not Completed", "Information")
    End Sub

End Class