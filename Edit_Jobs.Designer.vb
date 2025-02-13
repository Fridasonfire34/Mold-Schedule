<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Edit_Jobs
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Edit_Jobs))
        Me.DGV_Edit_Panel = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txt_Job = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Txt_Job_Id = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Txt_Qty = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Txt_EXT = New System.Windows.Forms.TextBox()
        Me.Txt_Width = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Txt_HGT = New System.Windows.Forms.TextBox()
        Me.Txt_INT = New System.Windows.Forms.TextBox()
        Me.Txt_Description = New System.Windows.Forms.TextBox()
        Me.Txt_Thik = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Maskd_Date = New System.Windows.Forms.MaskedTextBox()
        Me.Check_Bx_SelectAll = New System.Windows.Forms.CheckBox()
        Me.Btn_Save_Changes = New System.Windows.Forms.Button()
        Me.Btn_Delete_Panels = New System.Windows.Forms.Button()
        Me.ToolTip_Delete = New System.Windows.Forms.ToolTip(Me.components)
        Me.Lnk_Lbl_Jobs = New System.Windows.Forms.LinkLabel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Btn_Incomplete = New System.Windows.Forms.Button()
        CType(Me.DGV_Edit_Panel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DGV_Edit_Panel
        '
        Me.DGV_Edit_Panel.BackgroundColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Poppins SemiBold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_Edit_Panel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_Edit_Panel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Edit_Panel.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_Edit_Panel.Location = New System.Drawing.Point(12, 12)
        Me.DGV_Edit_Panel.Name = "DGV_Edit_Panel"
        Me.DGV_Edit_Panel.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DGV_Edit_Panel.Size = New System.Drawing.Size(1003, 188)
        Me.DGV_Edit_Panel.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(42, 215)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 28)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Job Number:"
        '
        'Txt_Job
        '
        Me.Txt_Job.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Job.Location = New System.Drawing.Point(160, 212)
        Me.Txt_Job.Name = "Txt_Job"
        Me.Txt_Job.Size = New System.Drawing.Size(166, 31)
        Me.Txt_Job.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(91, 251)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 28)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Job ID:"
        '
        'Txt_Job_Id
        '
        Me.Txt_Job_Id.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Job_Id.Location = New System.Drawing.Point(160, 249)
        Me.Txt_Job_Id.Name = "Txt_Job_Id"
        Me.Txt_Job_Id.Size = New System.Drawing.Size(75, 31)
        Me.Txt_Job_Id.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(111, 289)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 28)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Qty:"
        '
        'Txt_Qty
        '
        Me.Txt_Qty.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Qty.Location = New System.Drawing.Point(160, 286)
        Me.Txt_Qty.Name = "Txt_Qty"
        Me.Txt_Qty.Size = New System.Drawing.Size(75, 31)
        Me.Txt_Qty.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(111, 329)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 28)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "EXT."
        '
        'Txt_EXT
        '
        Me.Txt_EXT.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_EXT.Location = New System.Drawing.Point(159, 323)
        Me.Txt_EXT.Name = "Txt_EXT"
        Me.Txt_EXT.Size = New System.Drawing.Size(76, 31)
        Me.Txt_EXT.TabIndex = 8
        '
        'Txt_Width
        '
        Me.Txt_Width.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Width.Location = New System.Drawing.Point(159, 360)
        Me.Txt_Width.Name = "Txt_Width"
        Me.Txt_Width.Size = New System.Drawing.Size(76, 31)
        Me.Txt_Width.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(94, 362)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 28)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Width"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(332, 215)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 28)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "HGT."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(340, 251)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 28)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "INT."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(279, 289)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 28)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Description:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(482, 215)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 28)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Thickness:"
        '
        'Txt_HGT
        '
        Me.Txt_HGT.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_HGT.Location = New System.Drawing.Point(385, 212)
        Me.Txt_HGT.Name = "Txt_HGT"
        Me.Txt_HGT.Size = New System.Drawing.Size(76, 31)
        Me.Txt_HGT.TabIndex = 15
        '
        'Txt_INT
        '
        Me.Txt_INT.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_INT.Location = New System.Drawing.Point(385, 249)
        Me.Txt_INT.Name = "Txt_INT"
        Me.Txt_INT.Size = New System.Drawing.Size(76, 31)
        Me.Txt_INT.TabIndex = 16
        '
        'Txt_Description
        '
        Me.Txt_Description.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Description.Location = New System.Drawing.Point(385, 286)
        Me.Txt_Description.Multiline = True
        Me.Txt_Description.Name = "Txt_Description"
        Me.Txt_Description.Size = New System.Drawing.Size(373, 105)
        Me.Txt_Description.TabIndex = 17
        '
        'Txt_Thik
        '
        Me.Txt_Thik.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Thik.Location = New System.Drawing.Point(580, 212)
        Me.Txt_Thik.Name = "Txt_Thik"
        Me.Txt_Thik.Size = New System.Drawing.Size(75, 31)
        Me.Txt_Thik.TabIndex = 18
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(489, 251)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(85, 28)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "Cut Date:"
        '
        'Maskd_Date
        '
        Me.Maskd_Date.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Maskd_Date.Location = New System.Drawing.Point(580, 248)
        Me.Maskd_Date.Mask = "00/00/0000 90:00"
        Me.Maskd_Date.Name = "Maskd_Date"
        Me.Maskd_Date.Size = New System.Drawing.Size(178, 31)
        Me.Maskd_Date.TabIndex = 20
        Me.Maskd_Date.ValidatingType = GetType(Date)
        '
        'Check_Bx_SelectAll
        '
        Me.Check_Bx_SelectAll.AutoSize = True
        Me.Check_Bx_SelectAll.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_Bx_SelectAll.Location = New System.Drawing.Point(860, 283)
        Me.Check_Bx_SelectAll.Name = "Check_Bx_SelectAll"
        Me.Check_Bx_SelectAll.Size = New System.Drawing.Size(103, 32)
        Me.Check_Bx_SelectAll.TabIndex = 21
        Me.Check_Bx_SelectAll.Text = "Select All"
        Me.Check_Bx_SelectAll.UseVisualStyleBackColor = True
        '
        'Btn_Save_Changes
        '
        Me.Btn_Save_Changes.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Save_Changes.Location = New System.Drawing.Point(846, 215)
        Me.Btn_Save_Changes.Name = "Btn_Save_Changes"
        Me.Btn_Save_Changes.Size = New System.Drawing.Size(128, 48)
        Me.Btn_Save_Changes.TabIndex = 22
        Me.Btn_Save_Changes.Text = "Save"
        Me.Btn_Save_Changes.UseVisualStyleBackColor = True
        '
        'Btn_Delete_Panels
        '
        Me.Btn_Delete_Panels.BackColor = System.Drawing.Color.Transparent
        Me.Btn_Delete_Panels.BackgroundImage = Global.Mold_Schedule.My.Resources.Resources._14090243
        Me.Btn_Delete_Panels.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Btn_Delete_Panels.Location = New System.Drawing.Point(835, 372)
        Me.Btn_Delete_Panels.Name = "Btn_Delete_Panels"
        Me.Btn_Delete_Panels.Size = New System.Drawing.Size(35, 31)
        Me.Btn_Delete_Panels.TabIndex = 23
        Me.Btn_Delete_Panels.UseVisualStyleBackColor = False
        '
        'Lnk_Lbl_Jobs
        '
        Me.Lnk_Lbl_Jobs.AutoSize = True
        Me.Lnk_Lbl_Jobs.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnk_Lbl_Jobs.Location = New System.Drawing.Point(8, 380)
        Me.Lnk_Lbl_Jobs.Name = "Lnk_Lbl_Jobs"
        Me.Lnk_Lbl_Jobs.Size = New System.Drawing.Size(92, 23)
        Me.Lnk_Lbl_Jobs.TabIndex = 24
        Me.Lnk_Lbl_Jobs.TabStop = True
        Me.Lnk_Lbl_Jobs.Text = "Back to Jobs"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(876, 377)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(98, 23)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Delete panels"
        '
        'Btn_Incomplete
        '
        Me.Btn_Incomplete.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Incomplete.Location = New System.Drawing.Point(835, 321)
        Me.Btn_Incomplete.Name = "Btn_Incomplete"
        Me.Btn_Incomplete.Size = New System.Drawing.Size(159, 33)
        Me.Btn_Incomplete.TabIndex = 27
        Me.Btn_Incomplete.Text = "Unmark as 'Complete'"
        Me.Btn_Incomplete.UseVisualStyleBackColor = True
        '
        'Edit_Jobs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1027, 410)
        Me.Controls.Add(Me.Btn_Incomplete)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Lnk_Lbl_Jobs)
        Me.Controls.Add(Me.Btn_Delete_Panels)
        Me.Controls.Add(Me.Btn_Save_Changes)
        Me.Controls.Add(Me.Check_Bx_SelectAll)
        Me.Controls.Add(Me.Maskd_Date)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Txt_Thik)
        Me.Controls.Add(Me.Txt_Description)
        Me.Controls.Add(Me.Txt_INT)
        Me.Controls.Add(Me.Txt_HGT)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Txt_Width)
        Me.Controls.Add(Me.Txt_EXT)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Txt_Qty)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Txt_Job_Id)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Txt_Job)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DGV_Edit_Panel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Edit_Jobs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Jobs"
        CType(Me.DGV_Edit_Panel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DGV_Edit_Panel As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Txt_Job As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Txt_Job_Id As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Txt_Qty As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Txt_EXT As TextBox
    Friend WithEvents Txt_Width As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Txt_HGT As TextBox
    Friend WithEvents Txt_INT As TextBox
    Friend WithEvents Txt_Description As TextBox
    Friend WithEvents Txt_Thik As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Maskd_Date As MaskedTextBox
    Friend WithEvents Check_Bx_SelectAll As CheckBox
    Friend WithEvents Btn_Save_Changes As Button
    Friend WithEvents Btn_Delete_Panels As Button
    Friend WithEvents ToolTip_Delete As ToolTip
    Friend WithEvents Lnk_Lbl_Jobs As LinkLabel
    Friend WithEvents Label11 As Label
    Friend WithEvents Btn_Incomplete As Button
End Class
