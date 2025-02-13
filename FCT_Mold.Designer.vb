<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FCT_Mold
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FCT_Mold))
        Me.Panel_FCTM = New System.Windows.Forms.Panel()
        Me.BTN_CLEAR_FILTER = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BTN_CANCEL_FILTER = New System.Windows.Forms.Button()
        Me.BTN_FILTER_FCTM = New System.Windows.Forms.Button()
        Me.Chckd_lst_FCTM = New System.Windows.Forms.CheckedListBox()
        Me.Txt_Bx_Jobs = New System.Windows.Forms.TextBox()
        Me.Lnk_lbl_Corners = New System.Windows.Forms.LinkLabel()
        Me.Lnk_lbl_GTL = New System.Windows.Forms.LinkLabel()
        Me.Lnk_Lbl_FC = New System.Windows.Forms.LinkLabel()
        Me.Lnk_lbl_TG = New System.Windows.Forms.LinkLabel()
        Me.Btn_Save_FCTM = New System.Windows.Forms.Button()
        Me.Btn_Menu = New System.Windows.Forms.Button()
        Me.Lnk_Lbl_Walls = New System.Windows.Forms.LinkLabel()
        Me.DTP_FCTM = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FCTMMold = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Options_FCTM = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearMolds_FCTM = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintMold = New System.Windows.Forms.ToolStripMenuItem()
        Me.Filter_FCTM = New System.Windows.Forms.ToolStripMenuItem()
        Me.DGV_FCTM = New System.Windows.Forms.DataGridView()
        Me.ID_TEEM1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panels_TeeM1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty_TeeM1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Date_TeeM1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGV_FCTM_Panels = New System.Windows.Forms.DataGridView()
        Me.ID_PANELS_TEEM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PANELS_TEEM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty_TeeM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Date_TeeM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LNK_LBL_TM = New System.Windows.Forms.LinkLabel()
        Me.Panel_FCTM.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.DGV_FCTM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_FCTM_Panels, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel_FCTM
        '
        Me.Panel_FCTM.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel_FCTM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_FCTM.Controls.Add(Me.BTN_CLEAR_FILTER)
        Me.Panel_FCTM.Controls.Add(Me.Label1)
        Me.Panel_FCTM.Controls.Add(Me.BTN_CANCEL_FILTER)
        Me.Panel_FCTM.Controls.Add(Me.BTN_FILTER_FCTM)
        Me.Panel_FCTM.Controls.Add(Me.Chckd_lst_FCTM)
        Me.Panel_FCTM.Controls.Add(Me.Txt_Bx_Jobs)
        Me.Panel_FCTM.Location = New System.Drawing.Point(12, 47)
        Me.Panel_FCTM.Name = "Panel_FCTM"
        Me.Panel_FCTM.Size = New System.Drawing.Size(168, 248)
        Me.Panel_FCTM.TabIndex = 98
        '
        'BTN_CLEAR_FILTER
        '
        Me.BTN_CLEAR_FILTER.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_CLEAR_FILTER.Location = New System.Drawing.Point(33, 214)
        Me.BTN_CLEAR_FILTER.Name = "BTN_CLEAR_FILTER"
        Me.BTN_CLEAR_FILTER.Size = New System.Drawing.Size(97, 29)
        Me.BTN_CLEAR_FILTER.TabIndex = 5
        Me.BTN_CLEAR_FILTER.Text = "Clear Filter"
        Me.BTN_CLEAR_FILTER.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Poppins SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(28, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(113, 28)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Job Number"
        '
        'BTN_CANCEL_FILTER
        '
        Me.BTN_CANCEL_FILTER.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_CANCEL_FILTER.Location = New System.Drawing.Point(81, 181)
        Me.BTN_CANCEL_FILTER.Name = "BTN_CANCEL_FILTER"
        Me.BTN_CANCEL_FILTER.Size = New System.Drawing.Size(75, 29)
        Me.BTN_CANCEL_FILTER.TabIndex = 3
        Me.BTN_CANCEL_FILTER.Text = "Cancel"
        Me.BTN_CANCEL_FILTER.UseVisualStyleBackColor = True
        '
        'BTN_FILTER_FCTM
        '
        Me.BTN_FILTER_FCTM.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_FILTER_FCTM.Location = New System.Drawing.Point(12, 181)
        Me.BTN_FILTER_FCTM.Name = "BTN_FILTER_FCTM"
        Me.BTN_FILTER_FCTM.Size = New System.Drawing.Size(63, 29)
        Me.BTN_FILTER_FCTM.TabIndex = 2
        Me.BTN_FILTER_FCTM.Text = "OK"
        Me.BTN_FILTER_FCTM.UseVisualStyleBackColor = True
        '
        'Chckd_lst_FCTM
        '
        Me.Chckd_lst_FCTM.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chckd_lst_FCTM.FormattingEnabled = True
        Me.Chckd_lst_FCTM.Location = New System.Drawing.Point(12, 71)
        Me.Chckd_lst_FCTM.Name = "Chckd_lst_FCTM"
        Me.Chckd_lst_FCTM.Size = New System.Drawing.Size(143, 104)
        Me.Chckd_lst_FCTM.TabIndex = 1
        '
        'Txt_Bx_Jobs
        '
        Me.Txt_Bx_Jobs.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Bx_Jobs.Location = New System.Drawing.Point(12, 35)
        Me.Txt_Bx_Jobs.Name = "Txt_Bx_Jobs"
        Me.Txt_Bx_Jobs.Size = New System.Drawing.Size(143, 30)
        Me.Txt_Bx_Jobs.TabIndex = 0
        '
        'Lnk_lbl_Corners
        '
        Me.Lnk_lbl_Corners.AutoSize = True
        Me.Lnk_lbl_Corners.BackColor = System.Drawing.Color.Transparent
        Me.Lnk_lbl_Corners.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnk_lbl_Corners.Location = New System.Drawing.Point(503, 47)
        Me.Lnk_lbl_Corners.Name = "Lnk_lbl_Corners"
        Me.Lnk_lbl_Corners.Size = New System.Drawing.Size(73, 26)
        Me.Lnk_lbl_Corners.TabIndex = 97
        Me.Lnk_lbl_Corners.TabStop = True
        Me.Lnk_lbl_Corners.Text = "Corners"
        '
        'Lnk_lbl_GTL
        '
        Me.Lnk_lbl_GTL.AutoSize = True
        Me.Lnk_lbl_GTL.BackColor = System.Drawing.Color.Transparent
        Me.Lnk_lbl_GTL.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnk_lbl_GTL.Location = New System.Drawing.Point(623, 47)
        Me.Lnk_lbl_GTL.Name = "Lnk_lbl_GTL"
        Me.Lnk_lbl_GTL.Size = New System.Drawing.Size(84, 26)
        Me.Lnk_lbl_GTL.TabIndex = 96
        Me.Lnk_lbl_GTL.TabStop = True
        Me.Lnk_lbl_GTL.Text = "Guillotine"
        '
        'Lnk_Lbl_FC
        '
        Me.Lnk_Lbl_FC.AutoSize = True
        Me.Lnk_Lbl_FC.BackColor = System.Drawing.Color.Transparent
        Me.Lnk_Lbl_FC.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnk_Lbl_FC.Location = New System.Drawing.Point(758, 14)
        Me.Lnk_Lbl_FC.Name = "Lnk_Lbl_FC"
        Me.Lnk_Lbl_FC.Size = New System.Drawing.Size(111, 26)
        Me.Lnk_Lbl_FC.TabIndex = 95
        Me.Lnk_Lbl_FC.TabStop = True
        Me.Lnk_Lbl_FC.Text = "Floor-Ceiling"
        '
        'Lnk_lbl_TG
        '
        Me.Lnk_lbl_TG.AutoSize = True
        Me.Lnk_lbl_TG.BackColor = System.Drawing.Color.Transparent
        Me.Lnk_lbl_TG.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnk_lbl_TG.Location = New System.Drawing.Point(623, 14)
        Me.Lnk_lbl_TG.Name = "Lnk_lbl_TG"
        Me.Lnk_lbl_TG.Size = New System.Drawing.Size(64, 26)
        Me.Lnk_lbl_TG.TabIndex = 94
        Me.Lnk_lbl_TG.TabStop = True
        Me.Lnk_lbl_TG.Text = "35's TG"
        '
        'Btn_Save_FCTM
        '
        Me.Btn_Save_FCTM.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Save_FCTM.Location = New System.Drawing.Point(903, 8)
        Me.Btn_Save_FCTM.Name = "Btn_Save_FCTM"
        Me.Btn_Save_FCTM.Size = New System.Drawing.Size(96, 33)
        Me.Btn_Save_FCTM.TabIndex = 93
        Me.Btn_Save_FCTM.Text = "Save changes"
        Me.Btn_Save_FCTM.UseVisualStyleBackColor = True
        '
        'Btn_Menu
        '
        Me.Btn_Menu.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Menu.Location = New System.Drawing.Point(903, 50)
        Me.Btn_Menu.Name = "Btn_Menu"
        Me.Btn_Menu.Size = New System.Drawing.Size(96, 33)
        Me.Btn_Menu.TabIndex = 92
        Me.Btn_Menu.Text = "Go To Menu"
        Me.Btn_Menu.UseVisualStyleBackColor = True
        '
        'Lnk_Lbl_Walls
        '
        Me.Lnk_Lbl_Walls.AutoSize = True
        Me.Lnk_Lbl_Walls.BackColor = System.Drawing.Color.Transparent
        Me.Lnk_Lbl_Walls.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnk_Lbl_Walls.Location = New System.Drawing.Point(503, 11)
        Me.Lnk_Lbl_Walls.Name = "Lnk_Lbl_Walls"
        Me.Lnk_Lbl_Walls.Size = New System.Drawing.Size(53, 26)
        Me.Lnk_Lbl_Walls.TabIndex = 91
        Me.Lnk_Lbl_Walls.TabStop = True
        Me.Lnk_Lbl_Walls.Text = "Walls"
        '
        'DTP_FCTM
        '
        Me.DTP_FCTM.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_FCTM.Location = New System.Drawing.Point(183, 10)
        Me.DTP_FCTM.Name = "DTP_FCTM"
        Me.DTP_FCTM.Size = New System.Drawing.Size(267, 30)
        Me.DTP_FCTM.TabIndex = 90
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(127, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 26)
        Me.Label2.TabIndex = 89
        Me.Label2.Text = "Date:"
        '
        'FCTMMold
        '
        Me.FCTMMold.AutoSize = True
        Me.FCTMMold.BackColor = System.Drawing.Color.Transparent
        Me.FCTMMold.Font = New System.Drawing.Font("Poppins", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FCTMMold.Location = New System.Drawing.Point(125, 53)
        Me.FCTMMold.Name = "FCTMMold"
        Me.FCTMMold.Size = New System.Drawing.Size(254, 42)
        Me.FCTMMold.TabIndex = 87
        Me.FCTMMold.Text = "Floor-Ceiling T Mold"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Options_FCTM})
        Me.MenuStrip1.Location = New System.Drawing.Point(12, 11)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(94, 36)
        Me.MenuStrip1.TabIndex = 88
        Me.MenuStrip1.Text = "MenuStrip_Wall"
        '
        'Options_FCTM
        '
        Me.Options_FCTM.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearMolds_FCTM, Me.PrintMold, Me.Filter_FCTM})
        Me.Options_FCTM.Name = "Options_FCTM"
        Me.Options_FCTM.Size = New System.Drawing.Size(86, 32)
        Me.Options_FCTM.Text = "Options"
        '
        'ClearMolds_FCTM
        '
        Me.ClearMolds_FCTM.Name = "ClearMolds_FCTM"
        Me.ClearMolds_FCTM.Size = New System.Drawing.Size(178, 32)
        Me.ClearMolds_FCTM.Text = "Clear Molds"
        '
        'PrintMold
        '
        Me.PrintMold.Name = "PrintMold"
        Me.PrintMold.Size = New System.Drawing.Size(178, 32)
        Me.PrintMold.Text = "Print Mold"
        '
        'Filter_FCTM
        '
        Me.Filter_FCTM.Name = "Filter_FCTM"
        Me.Filter_FCTM.Size = New System.Drawing.Size(178, 32)
        Me.Filter_FCTM.Text = "Filter Panels"
        '
        'DGV_FCTM
        '
        Me.DGV_FCTM.BackgroundColor = System.Drawing.Color.Linen
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.MistyRose
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_FCTM.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_FCTM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_FCTM.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID_TEEM1, Me.Panels_TeeM1, Me.Qty_TeeM1, Me.Date_TeeM1})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_FCTM.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_FCTM.Location = New System.Drawing.Point(535, 98)
        Me.DGV_FCTM.Name = "DGV_FCTM"
        Me.DGV_FCTM.Size = New System.Drawing.Size(464, 574)
        Me.DGV_FCTM.TabIndex = 86
        '
        'ID_TEEM1
        '
        Me.ID_TEEM1.HeaderText = "ID"
        Me.ID_TEEM1.Name = "ID_TEEM1"
        Me.ID_TEEM1.ReadOnly = True
        Me.ID_TEEM1.Visible = False
        '
        'Panels_TeeM1
        '
        Me.Panels_TeeM1.HeaderText = "Panels"
        Me.Panels_TeeM1.Name = "Panels_TeeM1"
        Me.Panels_TeeM1.ReadOnly = True
        Me.Panels_TeeM1.Width = 220
        '
        'Qty_TeeM1
        '
        Me.Qty_TeeM1.HeaderText = "Qty"
        Me.Qty_TeeM1.Name = "Qty_TeeM1"
        Me.Qty_TeeM1.ReadOnly = True
        Me.Qty_TeeM1.Width = 40
        '
        'Date_TeeM1
        '
        Me.Date_TeeM1.HeaderText = "Date"
        Me.Date_TeeM1.Name = "Date_TeeM1"
        Me.Date_TeeM1.ReadOnly = True
        Me.Date_TeeM1.Width = 150
        '
        'DGV_FCTM_Panels
        '
        Me.DGV_FCTM_Panels.BackgroundColor = System.Drawing.Color.Linen
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_FCTM_Panels.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGV_FCTM_Panels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_FCTM_Panels.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID_PANELS_TEEM, Me.PANELS_TEEM, Me.Qty_TeeM, Me.Date_TeeM})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_FCTM_Panels.DefaultCellStyle = DataGridViewCellStyle4
        Me.DGV_FCTM_Panels.Location = New System.Drawing.Point(12, 98)
        Me.DGV_FCTM_Panels.Name = "DGV_FCTM_Panels"
        Me.DGV_FCTM_Panels.Size = New System.Drawing.Size(464, 574)
        Me.DGV_FCTM_Panels.TabIndex = 85
        '
        'ID_PANELS_TEEM
        '
        Me.ID_PANELS_TEEM.HeaderText = "ID"
        Me.ID_PANELS_TEEM.Name = "ID_PANELS_TEEM"
        Me.ID_PANELS_TEEM.ReadOnly = True
        Me.ID_PANELS_TEEM.Visible = False
        '
        'PANELS_TEEM
        '
        Me.PANELS_TEEM.HeaderText = "Panels"
        Me.PANELS_TEEM.Name = "PANELS_TEEM"
        Me.PANELS_TEEM.ReadOnly = True
        Me.PANELS_TEEM.Width = 220
        '
        'Qty_TeeM
        '
        Me.Qty_TeeM.HeaderText = "Qty"
        Me.Qty_TeeM.Name = "Qty_TeeM"
        Me.Qty_TeeM.ReadOnly = True
        Me.Qty_TeeM.Width = 50
        '
        'Date_TeeM
        '
        Me.Date_TeeM.HeaderText = "Date"
        Me.Date_TeeM.Name = "Date_TeeM"
        Me.Date_TeeM.ReadOnly = True
        Me.Date_TeeM.Width = 150
        '
        'LNK_LBL_TM
        '
        Me.LNK_LBL_TM.AutoSize = True
        Me.LNK_LBL_TM.BackColor = System.Drawing.Color.Transparent
        Me.LNK_LBL_TM.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LNK_LBL_TM.Location = New System.Drawing.Point(758, 47)
        Me.LNK_LBL_TM.Name = "LNK_LBL_TM"
        Me.LNK_LBL_TM.Size = New System.Drawing.Size(61, 26)
        Me.LNK_LBL_TM.TabIndex = 99
        Me.LNK_LBL_TM.TabStop = True
        Me.LNK_LBL_TM.Text = "T Mold"
        '
        'FCT_Mold
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(1011, 680)
        Me.Controls.Add(Me.LNK_LBL_TM)
        Me.Controls.Add(Me.Panel_FCTM)
        Me.Controls.Add(Me.Lnk_lbl_Corners)
        Me.Controls.Add(Me.Lnk_lbl_GTL)
        Me.Controls.Add(Me.Lnk_Lbl_FC)
        Me.Controls.Add(Me.Lnk_lbl_TG)
        Me.Controls.Add(Me.Btn_Save_FCTM)
        Me.Controls.Add(Me.Btn_Menu)
        Me.Controls.Add(Me.Lnk_Lbl_Walls)
        Me.Controls.Add(Me.DTP_FCTM)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.FCTMMold)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.DGV_FCTM)
        Me.Controls.Add(Me.DGV_FCTM_Panels)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FCT_Mold"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Floor-Ceiling T Mold"
        Me.Panel_FCTM.ResumeLayout(False)
        Me.Panel_FCTM.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.DGV_FCTM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_FCTM_Panels, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel_FCTM As Panel
    Friend WithEvents BTN_CLEAR_FILTER As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents BTN_CANCEL_FILTER As Button
    Friend WithEvents BTN_FILTER_FCTM As Button
    Friend WithEvents Chckd_lst_FCTM As CheckedListBox
    Friend WithEvents Txt_Bx_Jobs As TextBox
    Friend WithEvents Lnk_lbl_Corners As LinkLabel
    Friend WithEvents Lnk_lbl_GTL As LinkLabel
    Friend WithEvents Lnk_Lbl_FC As LinkLabel
    Friend WithEvents Lnk_lbl_TG As LinkLabel
    Friend WithEvents Btn_Save_FCTM As Button
    Friend WithEvents Btn_Menu As Button
    Friend WithEvents Lnk_Lbl_Walls As LinkLabel
    Friend WithEvents DTP_FCTM As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents FCTMMold As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents Options_FCTM As ToolStripMenuItem
    Friend WithEvents ClearMolds_FCTM As ToolStripMenuItem
    Friend WithEvents PrintMold As ToolStripMenuItem
    Friend WithEvents Filter_FCTM As ToolStripMenuItem
    Friend WithEvents DGV_FCTM As DataGridView
    Friend WithEvents ID_TEEM1 As DataGridViewTextBoxColumn
    Friend WithEvents Panels_TeeM1 As DataGridViewTextBoxColumn
    Friend WithEvents Qty_TeeM1 As DataGridViewTextBoxColumn
    Friend WithEvents Date_TeeM1 As DataGridViewTextBoxColumn
    Friend WithEvents DGV_FCTM_Panels As DataGridView
    Friend WithEvents ID_PANELS_TEEM As DataGridViewTextBoxColumn
    Friend WithEvents PANELS_TEEM As DataGridViewTextBoxColumn
    Friend WithEvents Qty_TeeM As DataGridViewTextBoxColumn
    Friend WithEvents Date_TeeM As DataGridViewTextBoxColumn
    Friend WithEvents LNK_LBL_TM As LinkLabel
End Class
