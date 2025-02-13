<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Jobs
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Jobs))
        Me.DGV_Jobs = New System.Windows.Forms.DataGridView()
        Me.Txt_Bx_Job_Fnd = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Lnk_Lbl_Molds = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Lbl_Qty_Sel = New System.Windows.Forms.Label()
        Me.Panel_Filters = New System.Windows.Forms.Panel()
        Me.Lnk_Info = New System.Windows.Forms.LinkLabel()
        Me.Lnk_lbl_Filters = New System.Windows.Forms.LinkLabel()
        Me.Panel_Molds = New System.Windows.Forms.Panel()
        Me.CheckBox_Molds = New System.Windows.Forms.CheckBox()
        Me.Checked_Lst_Bx_Molds = New System.Windows.Forms.CheckedListBox()
        Me.Txt_Bx_Mold = New System.Windows.Forms.TextBox()
        Me.Btn_Molds = New System.Windows.Forms.Button()
        Me.Btn_Cancel_Filter_Job = New System.Windows.Forms.Button()
        Me.Panel_TypePanels = New System.Windows.Forms.Panel()
        Me.Check_Bx_Select_All_Panels = New System.Windows.Forms.CheckBox()
        Me.Checked_Lst_Box_Panels = New System.Windows.Forms.CheckedListBox()
        Me.Txt_Bx_Panel = New System.Windows.Forms.TextBox()
        Me.Btn_Filter = New System.Windows.Forms.Button()
        Me.Btn_Panel_Filter = New System.Windows.Forms.Button()
        Me.Panel_Dates_Filter = New System.Windows.Forms.Panel()
        Me.Check_Bx_Select_All_Dates = New System.Windows.Forms.CheckBox()
        Me.Checked_Lst_Bx_Dates = New System.Windows.Forms.CheckedListBox()
        Me.Txt_Bx_Dates = New System.Windows.Forms.TextBox()
        Me.Btn_CutDate_Filter = New System.Windows.Forms.Button()
        Me.Panel_Jobs = New System.Windows.Forms.Panel()
        Me.Check_Bx_Select_All_Jobs = New System.Windows.Forms.CheckBox()
        Me.Checked_Lst_Bx_Jobs = New System.Windows.Forms.CheckedListBox()
        Me.Txt_Bx_Jobs = New System.Windows.Forms.TextBox()
        Me.Btn_Jobs_Filter = New System.Windows.Forms.Button()
        Me.Btn_Filters = New System.Windows.Forms.Button()
        Me.Btn_Edit_Rows = New System.Windows.Forms.Button()
        Me.Btn_Complete_Panels = New System.Windows.Forms.Button()
        CType(Me.DGV_Jobs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_Filters.SuspendLayout()
        Me.Panel_Molds.SuspendLayout()
        Me.Panel_TypePanels.SuspendLayout()
        Me.Panel_Dates_Filter.SuspendLayout()
        Me.Panel_Jobs.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGV_Jobs
        '
        Me.DGV_Jobs.BackgroundColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Jobs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_Jobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Jobs.Cursor = System.Windows.Forms.Cursors.Default
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Jobs.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_Jobs.GridColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.DGV_Jobs.Location = New System.Drawing.Point(16, 52)
        Me.DGV_Jobs.Name = "DGV_Jobs"
        Me.DGV_Jobs.ReadOnly = True
        Me.DGV_Jobs.ShowEditingIcon = False
        Me.DGV_Jobs.Size = New System.Drawing.Size(1560, 569)
        Me.DGV_Jobs.TabIndex = 0
        '
        'Txt_Bx_Job_Fnd
        '
        Me.Txt_Bx_Job_Fnd.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Bx_Job_Fnd.Location = New System.Drawing.Point(297, 15)
        Me.Txt_Bx_Job_Fnd.Multiline = True
        Me.Txt_Bx_Job_Fnd.Name = "Txt_Bx_Job_Fnd"
        Me.Txt_Bx_Job_Fnd.Size = New System.Drawing.Size(149, 26)
        Me.Txt_Bx_Job_Fnd.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(210, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 28)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Find Job:"
        '
        'Lnk_Lbl_Molds
        '
        Me.Lnk_Lbl_Molds.AutoSize = True
        Me.Lnk_Lbl_Molds.BackColor = System.Drawing.Color.Transparent
        Me.Lnk_Lbl_Molds.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnk_Lbl_Molds.Location = New System.Drawing.Point(1268, 15)
        Me.Lnk_Lbl_Molds.Name = "Lnk_Lbl_Molds"
        Me.Lnk_Lbl_Molds.Size = New System.Drawing.Size(171, 26)
        Me.Lnk_Lbl_Molds.TabIndex = 3
        Me.Lnk_Lbl_Molds.TabStop = True
        Me.Lnk_Lbl_Molds.Text = "Go To Mold Schedule"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(1470, 15)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(102, 26)
        Me.LinkLabel1.TabIndex = 4
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Go To Menu"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(549, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(130, 28)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Selected Rows:"
        '
        'Lbl_Qty_Sel
        '
        Me.Lbl_Qty_Sel.AutoSize = True
        Me.Lbl_Qty_Sel.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_Qty_Sel.Font = New System.Drawing.Font("Poppins SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_Qty_Sel.Location = New System.Drawing.Point(698, 12)
        Me.Lbl_Qty_Sel.Name = "Lbl_Qty_Sel"
        Me.Lbl_Qty_Sel.Size = New System.Drawing.Size(21, 28)
        Me.Lbl_Qty_Sel.TabIndex = 6
        Me.Lbl_Qty_Sel.Text = "-"
        '
        'Panel_Filters
        '
        Me.Panel_Filters.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Panel_Filters.BackColor = System.Drawing.Color.White
        Me.Panel_Filters.BackgroundImage = Global.Mold_Schedule.My.Resources.Resources.backgroung_init
        Me.Panel_Filters.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel_Filters.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_Filters.Controls.Add(Me.Lnk_Info)
        Me.Panel_Filters.Controls.Add(Me.Lnk_lbl_Filters)
        Me.Panel_Filters.Controls.Add(Me.Panel_Molds)
        Me.Panel_Filters.Controls.Add(Me.Btn_Molds)
        Me.Panel_Filters.Controls.Add(Me.Btn_Cancel_Filter_Job)
        Me.Panel_Filters.Controls.Add(Me.Panel_TypePanels)
        Me.Panel_Filters.Controls.Add(Me.Btn_Filter)
        Me.Panel_Filters.Controls.Add(Me.Btn_Panel_Filter)
        Me.Panel_Filters.Controls.Add(Me.Panel_Dates_Filter)
        Me.Panel_Filters.Controls.Add(Me.Btn_CutDate_Filter)
        Me.Panel_Filters.Controls.Add(Me.Panel_Jobs)
        Me.Panel_Filters.Controls.Add(Me.Btn_Jobs_Filter)
        Me.Panel_Filters.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel_Filters.Location = New System.Drawing.Point(16, 52)
        Me.Panel_Filters.Name = "Panel_Filters"
        Me.Panel_Filters.Size = New System.Drawing.Size(778, 331)
        Me.Panel_Filters.TabIndex = 7
        '
        'Lnk_Info
        '
        Me.Lnk_Info.AutoSize = True
        Me.Lnk_Info.BackColor = System.Drawing.Color.Transparent
        Me.Lnk_Info.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnk_Info.Location = New System.Drawing.Point(245, 256)
        Me.Lnk_Info.Name = "Lnk_Info"
        Me.Lnk_Info.Size = New System.Drawing.Size(77, 23)
        Me.Lnk_Info.TabIndex = 10
        Me.Lnk_Info.TabStop = True
        Me.Lnk_Info.Text = "More info..."
        '
        'Lnk_lbl_Filters
        '
        Me.Lnk_lbl_Filters.AutoSize = True
        Me.Lnk_lbl_Filters.BackColor = System.Drawing.Color.Transparent
        Me.Lnk_lbl_Filters.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnk_lbl_Filters.Location = New System.Drawing.Point(656, 281)
        Me.Lnk_lbl_Filters.Name = "Lnk_lbl_Filters"
        Me.Lnk_lbl_Filters.Size = New System.Drawing.Size(101, 26)
        Me.Lnk_lbl_Filters.TabIndex = 9
        Me.Lnk_lbl_Filters.TabStop = True
        Me.Lnk_lbl_Filters.Text = "Clear Filters"
        '
        'Panel_Molds
        '
        Me.Panel_Molds.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.Panel_Molds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_Molds.Controls.Add(Me.CheckBox_Molds)
        Me.Panel_Molds.Controls.Add(Me.Checked_Lst_Bx_Molds)
        Me.Panel_Molds.Controls.Add(Me.Txt_Bx_Mold)
        Me.Panel_Molds.Location = New System.Drawing.Point(576, 50)
        Me.Panel_Molds.Name = "Panel_Molds"
        Me.Panel_Molds.Size = New System.Drawing.Size(185, 203)
        Me.Panel_Molds.TabIndex = 8
        '
        'CheckBox_Molds
        '
        Me.CheckBox_Molds.AutoSize = True
        Me.CheckBox_Molds.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox_Molds.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_Molds.Location = New System.Drawing.Point(14, 39)
        Me.CheckBox_Molds.Name = "CheckBox_Molds"
        Me.CheckBox_Molds.Size = New System.Drawing.Size(87, 27)
        Me.CheckBox_Molds.TabIndex = 7
        Me.CheckBox_Molds.Text = "Select All"
        Me.CheckBox_Molds.UseVisualStyleBackColor = False
        '
        'Checked_Lst_Bx_Molds
        '
        Me.Checked_Lst_Bx_Molds.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Checked_Lst_Bx_Molds.FormattingEnabled = True
        Me.Checked_Lst_Bx_Molds.Items.AddRange(New Object() {"Mold 1 A&B (Wall)", "Mold 1 C&D (Wall)", "Mold 2 A&B (Wall)", "Mold 2 C&D (Wall)", "Mold 3 A&B (Wall)", "Mold 3 C&D (Wall)", "Mold 4 A&B (Wall)", "Mold 4 C&D (Wall)", "Mold 5 A&B (Wall)", "Mold 5 C&D (Wall)", "Mold 6 A&B (Wall)", "Mold 6 C&D (Wall)", "Old Mold 1 (Wall)", "Old Mold 2 (Wall)", "Old Mold 3 (Wall)", "Mold 1 (Corner)", "Mold 3 (Corner)", "Mold 1 (35's TG)", "Mold B (35's TG)", "Mold 5"" (35's TG)", "Mold 15 (Floor-Ceiling)", "Mold 17 (Floor-Ceiling)", "Mold 1 (Guillotine)", "Mold 2 (Guillotine)", "Mold 1 (Tee Mold)"})
        Me.Checked_Lst_Bx_Molds.Location = New System.Drawing.Point(14, 72)
        Me.Checked_Lst_Bx_Molds.Name = "Checked_Lst_Bx_Molds"
        Me.Checked_Lst_Bx_Molds.Size = New System.Drawing.Size(156, 114)
        Me.Checked_Lst_Bx_Molds.TabIndex = 4
        '
        'Txt_Bx_Mold
        '
        Me.Txt_Bx_Mold.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Bx_Mold.Location = New System.Drawing.Point(12, 6)
        Me.Txt_Bx_Mold.Name = "Txt_Bx_Mold"
        Me.Txt_Bx_Mold.Size = New System.Drawing.Size(158, 27)
        Me.Txt_Bx_Mold.TabIndex = 0
        '
        'Btn_Molds
        '
        Me.Btn_Molds.BackColor = System.Drawing.SystemColors.Control
        Me.Btn_Molds.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Molds.Location = New System.Drawing.Point(605, 9)
        Me.Btn_Molds.Name = "Btn_Molds"
        Me.Btn_Molds.Size = New System.Drawing.Size(122, 35)
        Me.Btn_Molds.TabIndex = 7
        Me.Btn_Molds.Text = "Mold"
        Me.Btn_Molds.UseVisualStyleBackColor = False
        '
        'Btn_Cancel_Filter_Job
        '
        Me.Btn_Cancel_Filter_Job.BackColor = System.Drawing.SystemColors.Control
        Me.Btn_Cancel_Filter_Job.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancel_Filter_Job.Location = New System.Drawing.Point(430, 277)
        Me.Btn_Cancel_Filter_Job.Name = "Btn_Cancel_Filter_Job"
        Me.Btn_Cancel_Filter_Job.Size = New System.Drawing.Size(102, 35)
        Me.Btn_Cancel_Filter_Job.TabIndex = 3
        Me.Btn_Cancel_Filter_Job.Text = "Cancel"
        Me.Btn_Cancel_Filter_Job.UseVisualStyleBackColor = False
        '
        'Panel_TypePanels
        '
        Me.Panel_TypePanels.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.Panel_TypePanels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_TypePanels.Controls.Add(Me.Check_Bx_Select_All_Panels)
        Me.Panel_TypePanels.Controls.Add(Me.Checked_Lst_Box_Panels)
        Me.Panel_TypePanels.Controls.Add(Me.Txt_Bx_Panel)
        Me.Panel_TypePanels.Location = New System.Drawing.Point(381, 50)
        Me.Panel_TypePanels.Name = "Panel_TypePanels"
        Me.Panel_TypePanels.Size = New System.Drawing.Size(175, 203)
        Me.Panel_TypePanels.TabIndex = 6
        '
        'Check_Bx_Select_All_Panels
        '
        Me.Check_Bx_Select_All_Panels.AutoSize = True
        Me.Check_Bx_Select_All_Panels.BackColor = System.Drawing.Color.Transparent
        Me.Check_Bx_Select_All_Panels.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_Bx_Select_All_Panels.Location = New System.Drawing.Point(14, 39)
        Me.Check_Bx_Select_All_Panels.Name = "Check_Bx_Select_All_Panels"
        Me.Check_Bx_Select_All_Panels.Size = New System.Drawing.Size(87, 27)
        Me.Check_Bx_Select_All_Panels.TabIndex = 7
        Me.Check_Bx_Select_All_Panels.Text = "Select All"
        Me.Check_Bx_Select_All_Panels.UseVisualStyleBackColor = False
        '
        'Checked_Lst_Box_Panels
        '
        Me.Checked_Lst_Box_Panels.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Checked_Lst_Box_Panels.FormattingEnabled = True
        Me.Checked_Lst_Box_Panels.Location = New System.Drawing.Point(14, 72)
        Me.Checked_Lst_Box_Panels.Name = "Checked_Lst_Box_Panels"
        Me.Checked_Lst_Box_Panels.Size = New System.Drawing.Size(146, 114)
        Me.Checked_Lst_Box_Panels.TabIndex = 4
        '
        'Txt_Bx_Panel
        '
        Me.Txt_Bx_Panel.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Bx_Panel.Location = New System.Drawing.Point(12, 6)
        Me.Txt_Bx_Panel.Name = "Txt_Bx_Panel"
        Me.Txt_Bx_Panel.Size = New System.Drawing.Size(148, 27)
        Me.Txt_Bx_Panel.TabIndex = 0
        '
        'Btn_Filter
        '
        Me.Btn_Filter.BackColor = System.Drawing.SystemColors.Control
        Me.Btn_Filter.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Filter.Location = New System.Drawing.Point(137, 281)
        Me.Btn_Filter.Name = "Btn_Filter"
        Me.Btn_Filter.Size = New System.Drawing.Size(102, 35)
        Me.Btn_Filter.TabIndex = 2
        Me.Btn_Filter.Text = "OK"
        Me.Btn_Filter.UseVisualStyleBackColor = False
        '
        'Btn_Panel_Filter
        '
        Me.Btn_Panel_Filter.BackColor = System.Drawing.SystemColors.Control
        Me.Btn_Panel_Filter.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Panel_Filter.Location = New System.Drawing.Point(418, 9)
        Me.Btn_Panel_Filter.Name = "Btn_Panel_Filter"
        Me.Btn_Panel_Filter.Size = New System.Drawing.Size(99, 35)
        Me.Btn_Panel_Filter.TabIndex = 6
        Me.Btn_Panel_Filter.Text = "Panel"
        Me.Btn_Panel_Filter.UseVisualStyleBackColor = False
        '
        'Panel_Dates_Filter
        '
        Me.Panel_Dates_Filter.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.Panel_Dates_Filter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_Dates_Filter.Controls.Add(Me.Check_Bx_Select_All_Dates)
        Me.Panel_Dates_Filter.Controls.Add(Me.Checked_Lst_Bx_Dates)
        Me.Panel_Dates_Filter.Controls.Add(Me.Txt_Bx_Dates)
        Me.Panel_Dates_Filter.Location = New System.Drawing.Point(191, 50)
        Me.Panel_Dates_Filter.Name = "Panel_Dates_Filter"
        Me.Panel_Dates_Filter.Size = New System.Drawing.Size(173, 203)
        Me.Panel_Dates_Filter.TabIndex = 5
        '
        'Check_Bx_Select_All_Dates
        '
        Me.Check_Bx_Select_All_Dates.AutoSize = True
        Me.Check_Bx_Select_All_Dates.BackColor = System.Drawing.Color.Transparent
        Me.Check_Bx_Select_All_Dates.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_Bx_Select_All_Dates.Location = New System.Drawing.Point(14, 39)
        Me.Check_Bx_Select_All_Dates.Name = "Check_Bx_Select_All_Dates"
        Me.Check_Bx_Select_All_Dates.Size = New System.Drawing.Size(87, 27)
        Me.Check_Bx_Select_All_Dates.TabIndex = 6
        Me.Check_Bx_Select_All_Dates.Text = "Select All"
        Me.Check_Bx_Select_All_Dates.UseVisualStyleBackColor = False
        '
        'Checked_Lst_Bx_Dates
        '
        Me.Checked_Lst_Bx_Dates.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Checked_Lst_Bx_Dates.FormattingEnabled = True
        Me.Checked_Lst_Bx_Dates.Location = New System.Drawing.Point(12, 72)
        Me.Checked_Lst_Bx_Dates.Name = "Checked_Lst_Bx_Dates"
        Me.Checked_Lst_Bx_Dates.Size = New System.Drawing.Size(147, 114)
        Me.Checked_Lst_Bx_Dates.TabIndex = 4
        '
        'Txt_Bx_Dates
        '
        Me.Txt_Bx_Dates.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Bx_Dates.Location = New System.Drawing.Point(12, 6)
        Me.Txt_Bx_Dates.Name = "Txt_Bx_Dates"
        Me.Txt_Bx_Dates.Size = New System.Drawing.Size(147, 27)
        Me.Txt_Bx_Dates.TabIndex = 0
        '
        'Btn_CutDate_Filter
        '
        Me.Btn_CutDate_Filter.BackColor = System.Drawing.SystemColors.Control
        Me.Btn_CutDate_Filter.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_CutDate_Filter.Location = New System.Drawing.Point(210, 9)
        Me.Btn_CutDate_Filter.Name = "Btn_CutDate_Filter"
        Me.Btn_CutDate_Filter.Size = New System.Drawing.Size(138, 35)
        Me.Btn_CutDate_Filter.TabIndex = 2
        Me.Btn_CutDate_Filter.Text = "Assignment Date"
        Me.Btn_CutDate_Filter.UseVisualStyleBackColor = False
        '
        'Panel_Jobs
        '
        Me.Panel_Jobs.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.Panel_Jobs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_Jobs.Controls.Add(Me.Check_Bx_Select_All_Jobs)
        Me.Panel_Jobs.Controls.Add(Me.Checked_Lst_Bx_Jobs)
        Me.Panel_Jobs.Controls.Add(Me.Txt_Bx_Jobs)
        Me.Panel_Jobs.Location = New System.Drawing.Point(13, 50)
        Me.Panel_Jobs.Name = "Panel_Jobs"
        Me.Panel_Jobs.Size = New System.Drawing.Size(164, 203)
        Me.Panel_Jobs.TabIndex = 1
        '
        'Check_Bx_Select_All_Jobs
        '
        Me.Check_Bx_Select_All_Jobs.AutoSize = True
        Me.Check_Bx_Select_All_Jobs.BackColor = System.Drawing.Color.Transparent
        Me.Check_Bx_Select_All_Jobs.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Check_Bx_Select_All_Jobs.Location = New System.Drawing.Point(14, 39)
        Me.Check_Bx_Select_All_Jobs.Name = "Check_Bx_Select_All_Jobs"
        Me.Check_Bx_Select_All_Jobs.Size = New System.Drawing.Size(87, 27)
        Me.Check_Bx_Select_All_Jobs.TabIndex = 5
        Me.Check_Bx_Select_All_Jobs.Text = "Select All"
        Me.Check_Bx_Select_All_Jobs.UseVisualStyleBackColor = False
        '
        'Checked_Lst_Bx_Jobs
        '
        Me.Checked_Lst_Bx_Jobs.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Checked_Lst_Bx_Jobs.FormattingEnabled = True
        Me.Checked_Lst_Bx_Jobs.Location = New System.Drawing.Point(12, 72)
        Me.Checked_Lst_Bx_Jobs.Name = "Checked_Lst_Bx_Jobs"
        Me.Checked_Lst_Bx_Jobs.Size = New System.Drawing.Size(135, 114)
        Me.Checked_Lst_Bx_Jobs.TabIndex = 4
        '
        'Txt_Bx_Jobs
        '
        Me.Txt_Bx_Jobs.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Bx_Jobs.Location = New System.Drawing.Point(12, 6)
        Me.Txt_Bx_Jobs.Name = "Txt_Bx_Jobs"
        Me.Txt_Bx_Jobs.Size = New System.Drawing.Size(135, 27)
        Me.Txt_Bx_Jobs.TabIndex = 0
        '
        'Btn_Jobs_Filter
        '
        Me.Btn_Jobs_Filter.BackColor = System.Drawing.SystemColors.Control
        Me.Btn_Jobs_Filter.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Jobs_Filter.Location = New System.Drawing.Point(39, 9)
        Me.Btn_Jobs_Filter.Name = "Btn_Jobs_Filter"
        Me.Btn_Jobs_Filter.Size = New System.Drawing.Size(116, 35)
        Me.Btn_Jobs_Filter.TabIndex = 0
        Me.Btn_Jobs_Filter.Text = "Job Number"
        Me.Btn_Jobs_Filter.UseVisualStyleBackColor = False
        '
        'Btn_Filters
        '
        Me.Btn_Filters.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Filters.Location = New System.Drawing.Point(16, 8)
        Me.Btn_Filters.Name = "Btn_Filters"
        Me.Btn_Filters.Size = New System.Drawing.Size(98, 35)
        Me.Btn_Filters.TabIndex = 8
        Me.Btn_Filters.Text = "Filters"
        Me.Btn_Filters.UseVisualStyleBackColor = True
        '
        'Btn_Edit_Rows
        '
        Me.Btn_Edit_Rows.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Edit_Rows.Location = New System.Drawing.Point(1044, 13)
        Me.Btn_Edit_Rows.Name = "Btn_Edit_Rows"
        Me.Btn_Edit_Rows.Size = New System.Drawing.Size(148, 33)
        Me.Btn_Edit_Rows.TabIndex = 9
        Me.Btn_Edit_Rows.Text = "Edit Selected Rows"
        Me.Btn_Edit_Rows.UseVisualStyleBackColor = True
        '
        'Btn_Complete_Panels
        '
        Me.Btn_Complete_Panels.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Complete_Panels.Location = New System.Drawing.Point(803, 12)
        Me.Btn_Complete_Panels.Name = "Btn_Complete_Panels"
        Me.Btn_Complete_Panels.Size = New System.Drawing.Size(143, 33)
        Me.Btn_Complete_Panels.TabIndex = 10
        Me.Btn_Complete_Panels.Text = "Mark as Complete"
        Me.Btn_Complete_Panels.UseVisualStyleBackColor = True
        '
        'Jobs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackgroundImage = Global.Mold_Schedule.My.Resources.Resources.backgroung_init
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1584, 633)
        Me.Controls.Add(Me.Btn_Complete_Panels)
        Me.Controls.Add(Me.Btn_Edit_Rows)
        Me.Controls.Add(Me.Btn_Filters)
        Me.Controls.Add(Me.Panel_Filters)
        Me.Controls.Add(Me.Lbl_Qty_Sel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Lnk_Lbl_Molds)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Txt_Bx_Job_Fnd)
        Me.Controls.Add(Me.DGV_Jobs)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Jobs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Jobs"
        CType(Me.DGV_Jobs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_Filters.ResumeLayout(False)
        Me.Panel_Filters.PerformLayout()
        Me.Panel_Molds.ResumeLayout(False)
        Me.Panel_Molds.PerformLayout()
        Me.Panel_TypePanels.ResumeLayout(False)
        Me.Panel_TypePanels.PerformLayout()
        Me.Panel_Dates_Filter.ResumeLayout(False)
        Me.Panel_Dates_Filter.PerformLayout()
        Me.Panel_Jobs.ResumeLayout(False)
        Me.Panel_Jobs.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DGV_Jobs As DataGridView
    Friend WithEvents Txt_Bx_Job_Fnd As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Lnk_Lbl_Molds As LinkLabel
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Label2 As Label
    Friend WithEvents Lbl_Qty_Sel As Label
    Friend WithEvents Panel_Filters As Panel
    Friend WithEvents Panel_Jobs As Panel
    Friend WithEvents Btn_Cancel_Filter_Job As Button
    Friend WithEvents Btn_Filter As Button
    Friend WithEvents Txt_Bx_Jobs As TextBox
    Friend WithEvents Btn_Jobs_Filter As Button
    Friend WithEvents Checked_Lst_Bx_Jobs As CheckedListBox
    Friend WithEvents Panel_Dates_Filter As Panel
    Friend WithEvents Checked_Lst_Bx_Dates As CheckedListBox
    Friend WithEvents Txt_Bx_Dates As TextBox
    Friend WithEvents Btn_CutDate_Filter As Button
    Friend WithEvents Btn_Panel_Filter As Button
    Friend WithEvents Panel_TypePanels As Panel
    Friend WithEvents Checked_Lst_Box_Panels As CheckedListBox
    Friend WithEvents Txt_Bx_Panel As TextBox
    Friend WithEvents Btn_Filters As Button
    Friend WithEvents Check_Bx_Select_All_Panels As CheckBox
    Friend WithEvents Check_Bx_Select_All_Dates As CheckBox
    Friend WithEvents Check_Bx_Select_All_Jobs As CheckBox
    Friend WithEvents Btn_Edit_Rows As Button
    Friend WithEvents Btn_Complete_Panels As Button
    Friend WithEvents Panel_Molds As Panel
    Friend WithEvents CheckBox_Molds As CheckBox
    Friend WithEvents Checked_Lst_Bx_Molds As CheckedListBox
    Friend WithEvents Txt_Bx_Mold As TextBox
    Friend WithEvents Btn_Molds As Button
    Friend WithEvents Lnk_lbl_Filters As LinkLabel
    Friend WithEvents Lnk_Info As LinkLabel
End Class
