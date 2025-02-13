Imports System.Data.SqlClient

Public Class Edit_Jobs
    Public Sub MostrarIDsSeleccionados(idsSeleccionados As List(Of String))
        Try
            Dim connectionString As String = DatabaseConnection.ConnectionString
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Dim selQuery As String = "SELECT * FROM [Jobs] WHERE ID IN (" & String.Join(",", idsSeleccionados.Select(Function(id) "'" & id & "'")) & ")"
                Dim adapter As New SqlDataAdapter(selQuery, connection)
                Dim dataTable As New DataTable()

                adapter.Fill(dataTable)

                Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
                checkBoxColumn.HeaderText = ""
                checkBoxColumn.Name = "CheckBoxColumn"
                checkBoxColumn.Width = 5
                checkBoxColumn.ReadOnly = False
                checkBoxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGV_Edit_Panel.Columns.Insert(0, checkBoxColumn)


                DGV_Edit_Panel.DataSource = dataTable

                DGV_Edit_Panel.AutoSizeColumnsMode = DataGridViewAutoSizeColumnMode.Fill

                If DGV_Edit_Panel.Columns.Contains("ID") Then
                    DGV_Edit_Panel.Columns("ID").Visible = False
                End If

                If DGV_Edit_Panel.Columns.Contains("Panel Identifier") Then
                    DGV_Edit_Panel.Columns("Panel Identifier").Visible = False
                End If

            End Using
        Catch ex As Exception
            MessageBox.Show("Error al cargar los datos: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Edit_Jobs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ToolTip_Delete As New ToolTip()

        ToolTip_Delete.SetToolTip(Btn_Delete_Panels, "Delete all panels")
        ToolTip_Delete.SetToolTip(Check_Bx_SelectAll, "Select all panels to delete")
        ToolTip_Delete.ToolTipIcon = ToolTipIcon.Info

        ToolTip_Delete.InitialDelay = 100
        ToolTip_Delete.ReshowDelay = 200

    End Sub

    Private Sub DGV_Edit_Panel_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGV_Edit_Panel.CellContentClick
        ' Verificar que se haga clic en una celda de checkbox
        If e.ColumnIndex = 0 AndAlso e.RowIndex >= 0 Then ' 0 es el índice de la columna de checkboxes
            Dim dgv As DataGridView = DirectCast(sender, DataGridView)

            For Each row As DataGridViewRow In dgv.Rows
                If row.Index <> e.RowIndex Then
                    row.Cells(0).Value = False ' Desmarcar el checkbox en la fila
                End If
            Next

            ' Alternar el estado del checkbox
            Dim isChecked As Boolean = CBool(dgv.Rows(e.RowIndex).Cells(0).Value)
            dgv.Rows(e.RowIndex).Cells(0).Value = Not isChecked

            ' Si el checkbox se marca, extraer los valores
            If Not isChecked Then
                Dim selectedRow As DataGridViewRow = dgv.Rows(e.RowIndex) ' Obtener la fila seleccionada

                ' Extraer valores de la fila
                Txt_Job.Text = selectedRow.Cells("Job Number").Value.ToString()
                Txt_Job_Id.Text = selectedRow.Cells("Job Identifier").Value.ToString() ' Columna oculta
                Txt_Qty.Text = selectedRow.Cells("Qty").Value.ToString()
                Txt_EXT.Text = selectedRow.Cells("EXT.").Value.ToString()
                Txt_Width.Text = selectedRow.Cells("Width").Value.ToString()
                Txt_HGT.Text = selectedRow.Cells("HGT").Value.ToString()
                Txt_INT.Text = selectedRow.Cells("INT").Value.ToString()
                Txt_Description.Text = selectedRow.Cells("Description").Value.ToString()
                Txt_Thik.Text = selectedRow.Cells("Thickness").Value.ToString()
                Maskd_Date.Text = selectedRow.Cells("ASGM Date").Value.ToString()
            Else
                ' Si se desmarca, limpiar los controles
                Txt_Job.Clear()
                Txt_Job_Id.Clear()
                Txt_Qty.Clear()
                Txt_EXT.Clear()
                Txt_Width.Clear()
                Txt_HGT.Clear()
                Txt_INT.Clear()
                Txt_Description.Clear()
                Txt_Thik.Clear()
                Maskd_Date.Clear()
            End If
        End If
    End Sub

    Private Sub Lnk_Lbl_Jobs_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Lnk_Lbl_Jobs.LinkClicked
        Me.Hide()
        Dim JobsForm As New Jobs()
        JobsForm.ShowDialog()
        Me.Close()
    End Sub

    Private Sub Check_Bx_SelectAll_CheckedChanged(sender As Object, e As EventArgs) Handles Check_Bx_SelectAll.CheckedChanged
        Dim isChecked As Boolean = Check_Bx_SelectAll.Checked

        ' Iterar sobre cada fila del DataGridView y establecer el valor del checkbox
        For Each row As DataGridViewRow In DGV_Edit_Panel.Rows
            row.Cells(0).Value = isChecked ' 0 es el índice de la columna de checkboxes
        Next
    End Sub

    Private Sub Btn_Delete_Panels_Click(sender As Object, e As EventArgs) Handles Btn_Delete_Panels.Click
        Dim idsToDelete As New List(Of String)

        For Each row As DataGridViewRow In DGV_Edit_Panel.Rows
            Dim isSelected As Boolean = Convert.ToBoolean(row.Cells(0).Value)
            If isSelected Then
                Dim cellValue As Object = row.Cells("ID").Value

                If cellValue IsNot Nothing Then
                    Dim jobId As String = cellValue.ToString()
                    idsToDelete.Add(jobId)
                End If
            End If
        Next

        If idsToDelete.Count > 0 Then
            Dim passwordForm As New PasswordForm()
            If passwordForm.ShowDialog() = DialogResult.OK Then
                Dim password As String = passwordForm.Password

                If password = "yourpassword" Then
                    Try
                        Dim connectionString As String = DatabaseConnection.ConnectionString

                        Using connection As New SqlConnection(connectionString)
                            connection.Open()

                            For Each jobId As String In idsToDelete
                                Dim deleteQuery As String = "DELETE FROM [Jobs] WHERE ID = @ID"
                                Using command As New SqlCommand(deleteQuery, connection)
                                    command.Parameters.AddWithValue("@ID", jobId)
                                    command.ExecuteNonQuery()
                                End Using
                            Next
                        End Using

                        MessageBox.Show("Selected jobs were successfully deleted.", "Delete Jobs", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                        ReloadJobsData()
                        Jobs.Show()
                    Catch ex As SqlException
                        MessageBox.Show("Database error when deleting jobs: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Catch ex As Exception
                        MessageBox.Show("Error when deleting jobs: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Else
                    MessageBox.Show("Incorrect password. Deletion canceled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                MessageBox.Show("Password entry canceled.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("No jobs selected to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
    Private Async Sub ReloadJobsData()
        Try
            Dim connectionString As String = DatabaseConnection.ConnectionString
            Dim JobsQuery As String = "SELECT * FROM [Jobs]"

            Dim dataTable As DataTable = Await Task.Run(Function()
                                                            Using connection As New SqlConnection(connectionString)
                                                                Using adapter As New SqlDataAdapter(JobsQuery, connection)
                                                                    Dim tempTable As New DataTable()
                                                                    adapter.Fill(tempTable)
                                                                    Return tempTable
                                                                End Using
                                                            End Using
                                                        End Function)

            Jobs.DGV_Jobs.DataSource = dataTable

            If Jobs.DGV_Jobs.Columns.Contains("ID") Then
                Jobs.DGV_Jobs.Columns("ID").Visible = False
            End If
            If Jobs.DGV_Jobs.Columns.Contains("Job Identifier") Then
                Jobs.DGV_Jobs.Columns("Job Identifier").Visible = False
            End If
            If Jobs.DGV_Jobs.Columns.Contains("Part Number") Then
                Jobs.DGV_Jobs.Columns("Part Number").Visible = False
            End If
            If Jobs.DGV_Jobs.Columns.Contains("Panel") Then
                Jobs.DGV_Jobs.Columns("Panel").Visible = False
            End If


        Catch ex As Exception
            MessageBox.Show("Error when reloading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Btn_Save_Changes_Click(sender As Object, e As EventArgs) Handles Btn_Save_Changes.Click
        ' Variable para almacenar la fila seleccionada
        Dim selectedRow As DataGridViewRow = Nothing

        ' Iterar sobre las filas del DataGridView para buscar una fila con checkbox marcado
        For Each row As DataGridViewRow In DGV_Edit_Panel.Rows
            Dim isChecked As Boolean = Convert.ToBoolean(row.Cells(0).Value) ' 0 es el índice de la columna de checkboxes
            If isChecked Then
                selectedRow = row
                Exit For ' Detener el bucle al encontrar la primera fila marcada
            End If
        Next

        ' Si no se encontró ninguna fila con checkbox marcado, mostrar mensaje de error
        If selectedRow Is Nothing Then
            MessageBox.Show("No job selected. Please select a job to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Obtener el valor del ID desde la columna oculta
        Dim jobId As String = selectedRow.Cells("ID").Value.ToString()

        ' Asignar valores a variables desde los controles
        Dim jobNumber As String = Txt_Job.Text
        Dim panelIdentifier As String = Txt_Job_Id.Text ' Panel Identifier
        Dim qty As Double = Convert.ToDouble(Txt_Qty.Text) ' Float value
        Dim ext As String = Txt_EXT.Text
        Dim width As String = Txt_Width.Text
        Dim hgt As String = Txt_HGT.Text
        Dim intValue As String = Txt_INT.Text
        Dim description As String = Txt_Description.Text
        Dim thickness As String = Txt_Thik.Text
        Dim cutDate As Object = DBNull.Value ' Por defecto NULL para la fecha

        ' Verificar si el MaskedTextBox está lleno (todos los caracteres requeridos)
        If Maskd_Date.MaskFull Then
            Dim parsedDate As DateTime
            ' Intentar convertir el texto del MaskedTextBox a DateTime
            If DateTime.TryParseExact(Maskd_Date.Text, "MM/dd/yyyy HH:mm", Nothing, Globalization.DateTimeStyles.None, parsedDate) Then
                cutDate = parsedDate ' Si la conversión es exitosa, asignar la fecha
            Else
                MessageBox.Show("Invalid date format. Please enter a valid date in the format MM/dd/yyyy HH:mm.", "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return ' Detener el proceso si el formato es incorrecto
            End If
        End If

        Try
            ' Conexión a la base de datos
            Using connection As New SqlConnection(ConnectionString)
                connection.Open()

                ' Consulta SQL para actualizar el registro basado en el ID
                Dim query As String = "UPDATE Jobs SET [Job Number] = @JobNumber, [Job Identifier] = @JobIdentifier, Qty = @Qty, [EXT.] = @EXT, Width = @Width, HGT = @HGT, [INT] = @INT, Description = @Description, Thickness = @Thickness, [Cut Date] = @CutDate WHERE ID = @JobId"

                ' Crear comando SQL
                Using command As New SqlCommand(query, connection)
                    ' Asignar parámetros al comando
                    command.Parameters.AddWithValue("@JobId", jobId)
                    command.Parameters.AddWithValue("@JobNumber", jobNumber)
                    command.Parameters.AddWithValue("@JobIdentifier", panelIdentifier)
                    command.Parameters.AddWithValue("@Qty", qty)
                    command.Parameters.AddWithValue("@EXT", ext)
                    command.Parameters.AddWithValue("@Width", width)
                    command.Parameters.AddWithValue("@HGT", hgt)
                    command.Parameters.AddWithValue("@INT", intValue)
                    command.Parameters.AddWithValue("@Description", description)
                    command.Parameters.AddWithValue("@Thickness", thickness)

                    ' Asignar DBNull si el MaskedTextBox estaba vacío o la fecha si es válida
                    command.Parameters.AddWithValue("@CutDate", cutDate)

                    ' Ejecutar el comando
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()

                    If rowsAffected > 0 Then
                        MessageBox.Show("Job details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        UpdateJobID()

                        ' Eliminar la fila del DataGridView
                        DGV_Edit_Panel.Rows.Remove(selectedRow)

                        ' Limpiar los controles
                        ClearControls()
                    Else
                        MessageBox.Show("No job was updated. Please check the ID.", "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End Using
            End Using
        Catch ex As SqlException
            MessageBox.Show("Database error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ClearControls()
        ' Limpiar los controles del formulario
        Txt_Job.Clear()
        Txt_Job_Id.Clear()
        Txt_Qty.Clear()
        Txt_EXT.Clear()
        Txt_Width.Clear()
        Txt_HGT.Clear()
        Txt_INT.Clear()
        Txt_Description.Clear()
        Txt_Thik.Clear()
        Maskd_Date.Clear() ' Limpiar el MaskedTextBox
    End Sub
    Private Sub UpdateJobID()
        Try
            Dim connectionString As String = DatabaseConnection.ConnectionString

            Dim updateJobs As String = "UPDATE [Jobs] " &
                                       "SET [Job Number] = LEFT([Job Number], LEN([Job Number]) - 1) " &
                                       "WHERE [Job Number] LIKE '%-TB-'"

            Dim updateJobID As String = "UPDATE [Jobs] " &
                                    "SET [Job Identifier] = CASE " &
                                    "WHEN LEN([Job Number]) > CHARINDEX('-TB-', [Job Number]) + 3 THEN " &
                                    "SUBSTRING([Job Number], CHARINDEX('-TB-', [Job Number]) + 4, LEN([Job Number]) - CHARINDEX('-TB-', [Job Number]) - 3) " &
                                    "ELSE NULL END " &
                                    "WHERE [Job Number] LIKE '%-TB-%'"

            Dim updatePartN As String = "UPDATE [Jobs] " &
                            "SET [Part Number] = LEFT([Description], 3) " &
                            "WHERE LEN([Description]) >= 3"

            Dim updatePanel As String = "UPDATE [Jobs] " &
                            "SET [Panel] = LEFT([Job Number], CHARINDEX('-TB', [Job Number]) - 1) + " &
                            "CASE WHEN [Job Identifier] IS NOT NULL THEN '-' + [Job Identifier] ELSE '' END + '-' + " &
                            "[Part Number] + '-' + " &
                            "CASE WHEN [Thickness] IS NOT NULL THEN [Thickness] ELSE '5' END + '-' + " &
                            "[WIDTH] + 'x' + [HGT] " &
                            "WHERE [Job Number] LIKE '%-TB%'"

            Dim updatePanelID As String = "UPDATE [Jobs] " &
                             "SET [Panel Identifier] = CASE " &
                             "WHEN [WIDTH] LIKE '%/%' THEN 'Corner' " &
                             "WHEN [WIDTH] LIKE '%T%' OR [WIDTH] LIKE '%G%' OR [WIDTH] LIKE '%TG%' THEN 'T&G' " &
                             "WHEN LEFT([Part Number], 1) = 'F' THEN 'Floor' " &
                             "WHEN LEFT([Part Number], 1) = 'C' THEN 'Ceiling' " &
                             "WHEN LEFT([Part Number], 1) = 'W' THEN 'Wall' " &
                             "ELSE [Panel Identifier] " &
                             "END"



            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using cmd As New SqlCommand(updateJobs, connection)
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    'MessageBox.Show(rowsAffected.ToString() & " rows were updated successfully.", "Update Jobs Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using

                Using cmd As New SqlCommand(updateJobID, connection)
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    ' MessageBox.Show(rowsAffected.ToString() & " rows were updated successfully.", "Update Job ID Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using

                Using cmd As New SqlCommand(updatePartN, connection)
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    'MessageBox.Show(rowsAffected.ToString() & " rows were updated successfully.", "Update  Part Number Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using

                Using cmd As New SqlCommand(updatePanel, connection)
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    'MessageBox.Show(rowsAffected.ToString() & " rows were updated successfully.", "Update Panel Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using

                Using cmd As New SqlCommand(updatePanelID, connection)
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    'MessageBox.Show(rowsAffected.ToString() & " rows were updated successfully.", "Update Panel ID Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using

            End Using
            CeilingIDW()
        Catch ex As Exception
            MessageBox.Show("Error while updating Job Number: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub CeilingIDW()
        Try
            Dim connectionstring As String = DatabaseConnection.ConnectionString

            Dim updateIDPanelC As String = "UPDATE [Jobs] " &
                                           "SET [Panel Identifier] = 'Wall' " &
                                           "WHERE [Panel Identifier] = 'Ceiling' " &
                                           "AND CAST([HGT] AS FLOAT) > 150"

            Using connection As New SqlConnection(connectionstring)
                connection.Open()

                Using cmd As New SqlCommand(updateIDPanelC, connection)
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    'MessageBox.Show(rowsAffected.ToString() & " rows were updated successfully.", "Update 2nd Panel ID Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using

            End Using
        Catch ex As Exception
            MessageBox.Show("Error " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Btn_Incomplete_Click(sender As Object, e As EventArgs) Handles Btn_Incomplete.Click
        Dim idsSeleccionados As New List(Of String)

        For Each fila As DataGridViewRow In DGV_Edit_Panel.Rows
            Dim isChecked As Boolean = Convert.ToBoolean(fila.Cells("CheckboxColumn").Value)

            ' Check if the row is selected
            If isChecked Then
                Dim moldValue As Object = fila.Cells("Mold").Value

                ' Ensure "Mold" column is not empty
                If moldValue IsNot Nothing AndAlso Not String.IsNullOrEmpty(moldValue.ToString()) Then
                    ' Add ID if "Mold" has values
                    Dim id As String = fila.Cells("ID").Value.ToString()
                    idsSeleccionados.Add(id)
                End If
            End If
        Next

        ' Check if there are no selected rows with valid values
        If idsSeleccionados.Count = 0 Then
            MessageBox.Show("No rows selected or 'Mold' column is empty.")
            Return
        End If

        Dim connectionString As String = DatabaseConnection.ConnectionString

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim query As String = "UPDATE Jobs SET Status = @Status, [Completed Date] = @CompletedDate WHERE ID IN (" & String.Join(",", idsSeleccionados.Select(Function(id) "'" & id & "'")) & ")"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Status", DBNull.Value)
                command.Parameters.AddWithValue("@CompletedDate", DBNull.Value)

                Try
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    MessageBox.Show(rowsAffected.ToString() & " rows updated to Incomplete.")
                    Me.Close()
                    UpdateJobs()
                Catch ex As SqlException
                    MessageBox.Show("Error updating rows: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Public Sub UpdateJobs()
        Me.Hide()
        Dim JobsForm As New Jobs()
        JobsForm.ShowDialog()
        Me.Show()
        Me.Close()
    End Sub

End Class
