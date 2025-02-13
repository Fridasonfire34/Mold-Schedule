Imports System.Data.SqlClient

Public Class New_Job
    Private Sub BTN_ADDJOB_Click(sender As Object, e As EventArgs) Handles BTN_ADDJOB.Click
        ResetErrorStyles()

        If MSKD_Txt_JOB.Text = "___-____-__-__" OrElse String.IsNullOrWhiteSpace(MSKD_Txt_JOB.Text.Replace("-", "").Replace("_", "")) Then
            MessageBox.Show("Please enter the Job Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim thicknessValue As String = String.Empty
        If CheckBox_Thick.Checked Then
            Txt_Bx_Thick.Enabled = True
            thicknessValue = Txt_Bx_Thick.Text.Trim()
            If String.IsNullOrWhiteSpace(thicknessValue) OrElse Not IsNumeric(thicknessValue) Then
                MessageBox.Show("Please enter the thickness", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Txt_Bx_Thick.BackColor = Color.LightPink
                Lbl_ThickError.Visible = True
                PictureBox1.Visible = True
                Return
            End If
        Else
            Txt_Bx_Thick.Enabled = False
        End If

        If Lst_Bx_Jobs.Items.Count = 0 Then
            MessageBox.Show("No job data to add. Please paste the job information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        For Each jobItem As String In Lst_Bx_Jobs.Items
            Dim jobData As List(Of String) = New List(Of String)(jobItem.Split(New Char() {vbTab}, StringSplitOptions.None))

            Dim cantidad As String = If(jobData.Count > 0, jobData(0).Trim(), "")
            Dim modelo As String = If(jobData.Count > 1, jobData(1).Trim(), "")
            Dim medida As String = If(jobData.Count > 2, jobData(2).Trim(), "")
            Dim grado As String = If(jobData.Count > 3, jobData(3).Trim(), "")
            Dim serie As String = If(jobData.Count > 4, jobData(4).Trim(), "")
            Dim descripcion As String = If(jobData.Count > 5, jobData(5).Trim(), "")

            Dim thicknessCol As String = If(CheckBox_Thick.Checked, thicknessValue, "")

            DGV_Jobs.Rows.Add(MSKD_Txt_JOB.Text, cantidad, modelo, medida, grado, serie, descripcion, thicknessCol)
        Next

        Lst_Bx_Jobs.Items.Clear()
        Txt_Bx_Thick.Clear()
        CheckBox_Thick.Checked = False
        Txt_Bx_Thick.Enabled = False
    End Sub

    Private Sub Lst_Bx_Jobs_KeyDown(sender As Object, e As KeyEventArgs) Handles Lst_Bx_Jobs.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.V Then
            Dim clipboardText As String = Clipboard.GetText()

            If Not String.IsNullOrEmpty(clipboardText) Then
                Dim lines() As String = clipboardText.Split(New String() {Environment.NewLine}, StringSplitOptions.None)

                For Each line As String In lines
                    If Not String.IsNullOrWhiteSpace(line) Then
                        Lst_Bx_Jobs.Items.Add(line)
                    End If
                Next
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            If Lst_Bx_Jobs.SelectedItem IsNot Nothing Then
                Lst_Bx_Jobs.Items.Remove(Lst_Bx_Jobs.SelectedItem)
            End If
        End If
    End Sub

    Private Sub CheckBox_Thick_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_Thick.CheckedChanged
        Txt_Bx_Thick.Enabled = CheckBox_Thick.Checked
    End Sub

    Private Sub ResetErrorStyles()
        Txt_Bx_Thick.BackColor = Color.White
        MSKD_Txt_JOB.BackColor = Color.White
        Lbl_ThickError.Visible = False
    End Sub

    Private Sub New_Job_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'UpdateJobID()
        PictureBox1.Visible = False
        Lbl_ThickError.Visible = False
        If CheckBox_Thick.Checked Then
            Txt_Bx_Thick.Enabled = True
        Else
            Txt_Bx_Thick.Enabled = False
        End If
    End Sub
    Private Sub Lnk_lbl_Back_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles Lnk_lbl_Back.LinkClicked
        Me.Hide()
        Dim Menu As New Form1()
        Menu.ShowDialog()
        Me.Show()
        Me.Close()
    End Sub
    Private Sub Btn_Save_Jobs_Click(sender As Object, e As EventArgs) Handles Btn_Save_Jobs.Click
        Try
            Dim connectionString As String = DatabaseConnection.ConnectionString
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                For Each row As DataGridViewRow In DGV_Jobs.Rows
                    If Not row.IsNewRow Then
                        Dim jobNumber As String = row.Cells("Job_Number").Value.ToString()
                        Dim qty As Double = Convert.ToDouble(row.Cells("Qty").Value)
                        Dim ext As String = row.Cells("Ext").Value.ToString()
                        Dim width As String = row.Cells("Width").Value.ToString()
                        Dim hgt As String = row.Cells("HGT").Value.ToString()
                        Dim intVal As String = row.Cells("INT").Value.ToString()
                        Dim description As String = row.Cells("Description").Value.ToString()
                        Dim thickness As String = row.Cells("Thickness").Value?.ToString().Trim

                        Dim insertQuery As String

                        If String.IsNullOrEmpty(thickness) Then
                            insertQuery = "INSERT INTO [New Jobs] ([Job Number], QTY, [EXT.], WIDTH, HGT, INT, Description) " &
                                          "VALUES (@JobNumber, @Qty, @Ext, @Width, @HGT, @INT, @Description)"
                        Else
                            insertQuery = "INSERT INTO [New Jobs] ([Job Number], QTY, [EXT.], WIDTH, HGT, INT, Description, Thickness) " &
                                          "VALUES (@JobNumber, @Qty, @Ext, @Width, @HGT, @INT, @Description, @Thickness)"
                        End If

                        Using cmd As New SqlCommand(insertQuery, connection)

                            cmd.Parameters.AddWithValue("@JobNumber", jobNumber)
                            cmd.Parameters.AddWithValue("@Qty", qty)
                            cmd.Parameters.AddWithValue("@Ext", ext)
                            cmd.Parameters.AddWithValue("@Width", width)
                            cmd.Parameters.AddWithValue("@HGT", hgt)
                            cmd.Parameters.AddWithValue("@INT", intVal)
                            cmd.Parameters.AddWithValue("@Description", description)


                            If Not String.IsNullOrEmpty(thickness) Then
                                cmd.Parameters.AddWithValue("@Thickness", thickness)
                            End If

                            cmd.ExecuteNonQuery()
                        End Using
                    End If
                Next

                connection.Close()
            End Using

            ' MessageBox.Show("Job saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Lst_Bx_Jobs.Items.Clear()
            MSKD_Txt_JOB.Text = ""
            Txt_Bx_Thick.Text = ""
            DGV_Jobs.Rows.Clear()
            UpdateJobID()
        Catch ex As Exception
            MessageBox.Show("Error while inserting data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CheckJobNumber()
        Try
            Dim connectionString As String = DatabaseConnection.ConnectionString
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                ' Obtener los paneles de la tabla [New Jobs]
                Dim selectNewJobsPanelQuery As String = "SELECT [Panel] FROM [New Jobs]"
                Dim newJobsPanels As New List(Of String)()

                Using selectNewJobsCmd As New SqlCommand(selectNewJobsPanelQuery, connection)
                    Using reader As SqlDataReader = selectNewJobsCmd.ExecuteReader()
                        While reader.Read()
                            newJobsPanels.Add(reader("Panel").ToString())
                        End While
                    End Using
                End Using

                ' Obtener los paneles de la tabla [Jobs]
                Dim selectJobsPanelQuery As String = "SELECT [Panel] FROM [Jobs]"
                Dim jobsPanels As New List(Of String)()

                Using selectJobsCmd As New SqlCommand(selectJobsPanelQuery, connection)
                    Using reader As SqlDataReader = selectJobsCmd.ExecuteReader()
                        While reader.Read()
                            jobsPanels.Add(reader("Panel").ToString())
                        End While
                    End Using
                End Using

                ' Buscar paneles repetidos
                Dim duplicatePanels = newJobsPanels.Intersect(jobsPanels).ToList()

                If duplicatePanels.Any() Then
                    ' Si hay paneles repetidos
                    Dim duplicatePanelsText = String.Join(", ", duplicatePanels)
                    Dim result As DialogResult = MessageBox.Show($"These panels: {duplicatePanelsText} already exist. Do you want to replace them?",
                                               "Duplicate Panels", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                    If result = DialogResult.Yes Then
                        ' Eliminar los paneles repetidos de la tabla [Jobs]
                        Dim deleteDuplicatesQuery As String = "DELETE FROM [Jobs] WHERE [Panel] IN (@DuplicatePanels)"
                        Using deleteCmd As New SqlCommand(deleteDuplicatesQuery, connection)
                            deleteCmd.Parameters.AddWithValue("@DuplicatePanels", String.Join(",", duplicatePanels))
                            deleteCmd.ExecuteNonQuery()
                        End Using

                        ' Insertar los nuevos paneles en la tabla [Jobs]
                        Dim insertNewJobsQuery As String = "INSERT INTO [Jobs] ([ID], [Job Number], [Job Identifier], [QTY], [EXT.], [WIDTH], [HGT], [INT], [Description], [Thickness], [Part Number], [Panel], [Panel Identifier]) " &
                                                       "SELECT NEWID(), [Job Number], [Job ID], [QTY], [EXT.], [WIDTH], [HGT], [INT], [Description], [Thickness], [Part Number], [Panel], [Panel ID] " &
                                                       "FROM [New Jobs] WHERE [Panel] IN (@DuplicatePanels)"
                        Using insertCmd As New SqlCommand(insertNewJobsQuery, connection)
                            insertCmd.Parameters.AddWithValue("@DuplicatePanels", String.Join(",", duplicatePanels))
                            insertCmd.ExecuteNonQuery()
                        End Using

                    Else
                        ' Eliminar los paneles repetidos solo de la tabla [New Jobs]
                        Dim deleteNewJobsQuery As String = "DELETE FROM [New Jobs] WHERE [Panel] IN (@DuplicatePanels)"
                        Using deleteCmd As New SqlCommand(deleteNewJobsQuery, connection)
                            deleteCmd.Parameters.AddWithValue("@DuplicatePanels", String.Join(",", duplicatePanels))
                            deleteCmd.ExecuteNonQuery()
                        End Using

                        ' Insertar los paneles no repetidos en la tabla [Jobs]
                        Dim insertNonDuplicatesQuery As String = "INSERT INTO [Jobs] ([ID], [Job Number], [Job Identifier], [QTY], [EXT.], [WIDTH], [HGT], [INT], [Description], [Thickness], [Part Number], [Panel], [Panel Identifier]) " &
                                                              "SELECT NEWID(), [Job Number], [Job ID], [QTY], [EXT.], [WIDTH], [HGT], [INT], [Description], [Thickness], [Part Number], [Panel], [Panel ID] " &
                                                              "FROM [New Jobs] WHERE [Panel] NOT IN (@DuplicatePanels)"
                        Using insertCmd As New SqlCommand(insertNonDuplicatesQuery, connection)
                            insertCmd.Parameters.AddWithValue("@DuplicatePanels", String.Join(",", duplicatePanels))
                            insertCmd.ExecuteNonQuery()
                        End Using
                    End If
                Else
                    ' Si no hay paneles repetidos, insertar todos los paneles de [New Jobs] en [Jobs]
                    Dim insertAllQuery As String = "INSERT INTO [Jobs] ([ID], [Job Number], [Job Identifier], [QTY], [EXT.], [WIDTH], [HGT], [INT], [Description], [Thickness], [Part Number], [Panel], [Panel Identifier]) " &
                                               "SELECT NEWID(), [Job Number], [Job ID], [QTY], [EXT.], [WIDTH], [HGT], [INT], [Description], [Thickness], [Part Number], [Panel], [Panel ID] " &
                                               "FROM [New Jobs]"
                    Using insertCmd As New SqlCommand(insertAllQuery, connection)
                        insertCmd.ExecuteNonQuery()
                    End Using
                End If

                connection.Close()

            End Using
            MessageBox.Show("Job saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            DelNewJobs()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub UpdateJobID()
        Try
            Dim connectionString As String = DatabaseConnection.ConnectionString

            Dim updateJobs As String = "UPDATE [New Jobs] " &
                                       "SET [Job Number] = LEFT([Job Number], LEN([Job Number]) - 1) " &
                                       "WHERE [Job Number] LIKE '%-TB-'"

            Dim updateJobID As String = "UPDATE [New Jobs] " &
                                    "SET [Job ID] = CASE " &
                                    "WHEN LEN([Job Number]) > CHARINDEX('-TB-', [Job Number]) + 3 THEN " &
                                    "SUBSTRING([Job Number], CHARINDEX('-TB-', [Job Number]) + 4, LEN([Job Number]) - CHARINDEX('-TB-', [Job Number]) - 3) " &
                                    "ELSE NULL END " &
                                    "WHERE [Job Number] LIKE '%-TB-%'"

            Dim updatePartN As String = "UPDATE [New Jobs] " &
                            "SET [Part Number] = LEFT([Description], 3) " &
                            "WHERE LEN([Description]) >= 3"

            Dim updatePanel As String = "UPDATE [New Jobs] " &
                            "SET [Panel] = LEFT([Job Number], CHARINDEX('-TB', [Job Number]) - 1) + " &
                            "CASE WHEN [Job ID] IS NOT NULL THEN '-' + [Job ID] ELSE '' END + '-' + " &
                            "[Part Number] + '-' + " &
                            "CASE WHEN [Thickness] IS NOT NULL THEN [Thickness] ELSE '5' END + '-' + " &
                            "[WIDTH] + 'x' + [HGT] " &
                            "WHERE [Job Number] LIKE '%-TB%'"

            Dim updatePanelID As String = "UPDATE [New Jobs] " &
                              "SET [Panel ID] = CASE " &
                              "WHEN [WIDTH] LIKE '%/%' THEN 'Corner' " &
                              "WHEN LEFT([Part Number], 1) = 'F' THEN 'Floor' " &
                              "WHEN LEFT([Part Number], 1) = 'C' THEN 'Ceiling' " &
                              "WHEN LEFT([Part Number], 1) = 'W' THEN 'Wall' " &
                              "ELSE [Panel ID] " &
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
            CheckJobNumber()
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
        Identifiers()
    End Sub
    Private Sub Identifiers()
        Try
            Dim connectionstring As String = DatabaseConnection.ConnectionString

            Dim updateIDPanel As String = "UPDATE [New Jobs] " &
                                      "SET [Panel ID] = " &
                                      "CASE " &
                                          "WHEN [Panel ID] = 'Floor' AND [WIDTH] = '11.5T' THEN 'Floor T' " &
                                          "WHEN [Panel ID] = 'Floor' AND [WIDTH] = '23T' THEN 'Floor T' " &
                                          "WHEN [Panel ID] = 'Ceiling' AND [WIDTH] = '11.5T' THEN 'Ceiling T' " &
                                          "WHEN [Panel ID] = 'Ceiling' AND [WIDTH] = '23T' THEN 'Ceiling T' " &
                                          "ELSE [Panel ID] " &
                                      "END " &
                                      "WHERE [Panel ID] IN ('Floor', 'Ceiling')"

            Using connection As New SqlConnection(connectionstring)
                connection.Open()

                Using cmd As New SqlCommand(updateIDPanel, connection)
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    'MessageBox.Show(rowsAffected.ToString() & " rows were updated successfully.", "Update 2nd Panel ID Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using

            End Using
        Catch ex As Exception
            MessageBox.Show("Error " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DelNewJobs()
        Try
            Dim connectionString As String = DatabaseConnection.ConnectionString

            Dim updateJobs As String = "DELETE FROM [New Jobs]"
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                Using cmd As New SqlCommand(updateJobs, connection)
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    'MessageBox.Show(rowsAffected.ToString() & " rows were updated successfully.", "Update Jobs Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error while deleting Jobs: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class