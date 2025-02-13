<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GuillotineM
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GuillotineM))
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.DGV_Guillotine_2 = New System.Windows.Forms.DataGridView()
        Me.ID_M2_GM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel_M2_GM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty_M2_GM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CutDate_M2_GM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGV_Guillotine1 = New System.Windows.Forms.DataGridView()
        Me.ID_M1_GM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pane_M1_GM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.QTY_M1_GM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CutDate_M1_GM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGV_Panels_Guillotine = New System.Windows.Forms.DataGridView()
        Me.ID_GM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel_GM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty_GM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CutDate_GM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DTP_GU = New System.Windows.Forms.DateTimePicker()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.GM_Opt = New System.Windows.Forms.ToolStripMenuItem()
        Me.Clear_GM = New System.Windows.Forms.ToolStripMenuItem()
        Me.Print_Molds = New System.Windows.Forms.ToolStripMenuItem()
        Me.Print_M1_GM = New System.Windows.Forms.ToolStripMenuItem()
        Me.Print_M2_GM = New System.Windows.Forms.ToolStripMenuItem()
        Me.Print_GM = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilterPanelsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Lnk_lbl_Wall = New System.Windows.Forms.LinkLabel()
        Me.Btn_Save_Guillotine = New System.Windows.Forms.Button()
        Me.Btn_Menu = New System.Windows.Forms.Button()
        Me.Lnk_lbl_Tee = New System.Windows.Forms.LinkLabel()
        Me.Lnk_lbl_FC = New System.Windows.Forms.LinkLabel()
        Me.Lnk_lbl_TG = New System.Windows.Forms.LinkLabel()
        Me.Lnk_Lbl_Corn = New System.Windows.Forms.LinkLabel()
        Me.Panel_Guillotine = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Chckd_lst_GM = New System.Windows.Forms.CheckedListBox()
        Me.Txt_Bx_Jobs = New System.Windows.Forms.TextBox()
        Me.Lnk_FCTM = New System.Windows.Forms.LinkLabel()
        CType(Me.DGV_Guillotine_2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_Guillotine1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_Panels_Guillotine, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip2.SuspendLayout()
        Me.Panel_Guillotine.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.BackColor = System.Drawing.Color.Transparent
        Me.Label42.Font = New System.Drawing.Font("Poppins SemiBold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label42.Location = New System.Drawing.Point(1248, 72)
        Me.Label42.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(98, 42)
        Me.Label42.TabIndex = 67
        Me.Label42.Text = "Mold 2"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.Font = New System.Drawing.Font("Poppins SemiBold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label43.Location = New System.Drawing.Point(729, 72)
        Me.Label43.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(93, 42)
        Me.Label43.TabIndex = 66
        Me.Label43.Text = "Mold 1"
        '
        'DGV_Guillotine_2
        '
        Me.DGV_Guillotine_2.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_Guillotine_2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_Guillotine_2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Guillotine_2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID_M2_GM, Me.Panel_M2_GM, Me.Qty_M2_GM, Me.CutDate_M2_GM})
        Me.DGV_Guillotine_2.Location = New System.Drawing.Point(1039, 115)
        Me.DGV_Guillotine_2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DGV_Guillotine_2.Name = "DGV_Guillotine_2"
        Me.DGV_Guillotine_2.Size = New System.Drawing.Size(476, 519)
        Me.DGV_Guillotine_2.TabIndex = 65
        '
        'ID_M2_GM
        '
        Me.ID_M2_GM.HeaderText = "ID"
        Me.ID_M2_GM.Name = "ID_M2_GM"
        Me.ID_M2_GM.ReadOnly = True
        Me.ID_M2_GM.Visible = False
        '
        'Panel_M2_GM
        '
        Me.Panel_M2_GM.HeaderText = "Panel"
        Me.Panel_M2_GM.Name = "Panel_M2_GM"
        Me.Panel_M2_GM.ReadOnly = True
        Me.Panel_M2_GM.Width = 220
        '
        'Qty_M2_GM
        '
        Me.Qty_M2_GM.HeaderText = "Qty"
        Me.Qty_M2_GM.Name = "Qty_M2_GM"
        Me.Qty_M2_GM.ReadOnly = True
        Me.Qty_M2_GM.Width = 50
        '
        'CutDate_M2_GM
        '
        Me.CutDate_M2_GM.HeaderText = "Date"
        Me.CutDate_M2_GM.Name = "CutDate_M2_GM"
        Me.CutDate_M2_GM.ReadOnly = True
        Me.CutDate_M2_GM.Width = 150
        '
        'DGV_Guillotine1
        '
        Me.DGV_Guillotine1.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_Guillotine1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_Guillotine1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Guillotine1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID_M1_GM, Me.Pane_M1_GM, Me.QTY_M1_GM, Me.CutDate_M1_GM})
        Me.DGV_Guillotine1.Location = New System.Drawing.Point(540, 115)
        Me.DGV_Guillotine1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DGV_Guillotine1.Name = "DGV_Guillotine1"
        Me.DGV_Guillotine1.Size = New System.Drawing.Size(476, 519)
        Me.DGV_Guillotine1.TabIndex = 64
        '
        'ID_M1_GM
        '
        Me.ID_M1_GM.HeaderText = "ID"
        Me.ID_M1_GM.Name = "ID_M1_GM"
        Me.ID_M1_GM.ReadOnly = True
        Me.ID_M1_GM.Visible = False
        '
        'Pane_M1_GM
        '
        Me.Pane_M1_GM.HeaderText = "Panel"
        Me.Pane_M1_GM.Name = "Pane_M1_GM"
        Me.Pane_M1_GM.ReadOnly = True
        Me.Pane_M1_GM.Width = 225
        '
        'QTY_M1_GM
        '
        Me.QTY_M1_GM.HeaderText = "Qty"
        Me.QTY_M1_GM.Name = "QTY_M1_GM"
        Me.QTY_M1_GM.ReadOnly = True
        Me.QTY_M1_GM.Width = 50
        '
        'CutDate_M1_GM
        '
        Me.CutDate_M1_GM.HeaderText = "Date"
        Me.CutDate_M1_GM.Name = "CutDate_M1_GM"
        Me.CutDate_M1_GM.ReadOnly = True
        Me.CutDate_M1_GM.Width = 150
        '
        'DGV_Panels_Guillotine
        '
        Me.DGV_Panels_Guillotine.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_Panels_Guillotine.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGV_Panels_Guillotine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Panels_Guillotine.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID_GM, Me.Panel_GM, Me.Qty_GM, Me.CutDate_GM})
        Me.DGV_Panels_Guillotine.Location = New System.Drawing.Point(13, 97)
        Me.DGV_Panels_Guillotine.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DGV_Panels_Guillotine.Name = "DGV_Panels_Guillotine"
        Me.DGV_Panels_Guillotine.Size = New System.Drawing.Size(476, 537)
        Me.DGV_Panels_Guillotine.TabIndex = 63
        '
        'ID_GM
        '
        Me.ID_GM.HeaderText = "ID"
        Me.ID_GM.Name = "ID_GM"
        Me.ID_GM.ReadOnly = True
        Me.ID_GM.Visible = False
        '
        'Panel_GM
        '
        Me.Panel_GM.HeaderText = "Panel"
        Me.Panel_GM.Name = "Panel_GM"
        Me.Panel_GM.ReadOnly = True
        Me.Panel_GM.Width = 225
        '
        'Qty_GM
        '
        Me.Qty_GM.HeaderText = "Qty"
        Me.Qty_GM.Name = "Qty_GM"
        Me.Qty_GM.ReadOnly = True
        Me.Qty_GM.Width = 50
        '
        'CutDate_GM
        '
        Me.CutDate_GM.HeaderText = "Date"
        Me.CutDate_GM.Name = "CutDate_GM"
        Me.CutDate_GM.ReadOnly = True
        Me.CutDate_GM.Width = 150
        '
        'DTP_GU
        '
        Me.DTP_GU.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_GU.Location = New System.Drawing.Point(203, 10)
        Me.DTP_GU.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.DTP_GU.Name = "DTP_GU"
        Me.DTP_GU.Size = New System.Drawing.Size(261, 30)
        Me.DTP_GU.TabIndex = 62
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(142, 12)
        Me.Label44.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(53, 28)
        Me.Label44.TabIndex = 68
        Me.Label44.Text = "Date:"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.BackColor = System.Drawing.Color.Transparent
        Me.Label50.Font = New System.Drawing.Font("Poppins", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label50.Location = New System.Drawing.Point(162, 50)
        Me.Label50.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(130, 42)
        Me.Label50.TabIndex = 69
        Me.Label50.Text = "Guillotine"
        '
        'MenuStrip2
        '
        Me.MenuStrip2.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip2.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GM_Opt})
        Me.MenuStrip2.Location = New System.Drawing.Point(9, 9)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Padding = New System.Windows.Forms.Padding(8, 3, 0, 3)
        Me.MenuStrip2.Size = New System.Drawing.Size(96, 38)
        Me.MenuStrip2.TabIndex = 70
        Me.MenuStrip2.Text = "MenuStrip_Wall"
        '
        'GM_Opt
        '
        Me.GM_Opt.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Clear_GM, Me.Print_Molds, Me.FilterPanelsToolStripMenuItem})
        Me.GM_Opt.Name = "GM_Opt"
        Me.GM_Opt.Size = New System.Drawing.Size(86, 32)
        Me.GM_Opt.Text = "Options"
        '
        'Clear_GM
        '
        Me.Clear_GM.Name = "Clear_GM"
        Me.Clear_GM.Size = New System.Drawing.Size(178, 32)
        Me.Clear_GM.Text = "Clear Molds"
        '
        'Print_Molds
        '
        Me.Print_Molds.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Print_M1_GM, Me.Print_M2_GM, Me.Print_GM})
        Me.Print_Molds.Name = "Print_Molds"
        Me.Print_Molds.Size = New System.Drawing.Size(178, 32)
        Me.Print_Molds.Text = "Print Molds"
        '
        'Print_M1_GM
        '
        Me.Print_M1_GM.Name = "Print_M1_GM"
        Me.Print_M1_GM.Size = New System.Drawing.Size(193, 32)
        Me.Print_M1_GM.Text = "Print Mold 1"
        '
        'Print_M2_GM
        '
        Me.Print_M2_GM.Name = "Print_M2_GM"
        Me.Print_M2_GM.Size = New System.Drawing.Size(193, 32)
        Me.Print_M2_GM.Text = "Print Mold 2"
        '
        'Print_GM
        '
        Me.Print_GM.Name = "Print_GM"
        Me.Print_GM.Size = New System.Drawing.Size(193, 32)
        Me.Print_GM.Text = "Print All Molds"
        '
        'FilterPanelsToolStripMenuItem
        '
        Me.FilterPanelsToolStripMenuItem.Name = "FilterPanelsToolStripMenuItem"
        Me.FilterPanelsToolStripMenuItem.Size = New System.Drawing.Size(178, 32)
        Me.FilterPanelsToolStripMenuItem.Text = "Filter Panels"
        '
        'Lnk_lbl_Wall
        '
        Me.Lnk_lbl_Wall.AutoSize = True
        Me.Lnk_lbl_Wall.BackColor = System.Drawing.Color.Transparent
        Me.Lnk_lbl_Wall.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnk_lbl_Wall.Location = New System.Drawing.Point(558, 9)
        Me.Lnk_lbl_Wall.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lnk_lbl_Wall.Name = "Lnk_lbl_Wall"
        Me.Lnk_lbl_Wall.Size = New System.Drawing.Size(53, 26)
        Me.Lnk_lbl_Wall.TabIndex = 81
        Me.Lnk_lbl_Wall.TabStop = True
        Me.Lnk_lbl_Wall.Text = "Walls"
        '
        'Btn_Save_Guillotine
        '
        Me.Btn_Save_Guillotine.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Save_Guillotine.Location = New System.Drawing.Point(1392, 57)
        Me.Btn_Save_Guillotine.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Save_Guillotine.Name = "Btn_Save_Guillotine"
        Me.Btn_Save_Guillotine.Size = New System.Drawing.Size(123, 35)
        Me.Btn_Save_Guillotine.TabIndex = 80
        Me.Btn_Save_Guillotine.Text = "Save changes"
        Me.Btn_Save_Guillotine.UseVisualStyleBackColor = True
        '
        'Btn_Menu
        '
        Me.Btn_Menu.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Menu.Location = New System.Drawing.Point(1392, 9)
        Me.Btn_Menu.Margin = New System.Windows.Forms.Padding(4)
        Me.Btn_Menu.Name = "Btn_Menu"
        Me.Btn_Menu.Size = New System.Drawing.Size(123, 37)
        Me.Btn_Menu.TabIndex = 79
        Me.Btn_Menu.Text = "Go To Menu"
        Me.Btn_Menu.UseVisualStyleBackColor = True
        '
        'Lnk_lbl_Tee
        '
        Me.Lnk_lbl_Tee.AutoSize = True
        Me.Lnk_lbl_Tee.BackColor = System.Drawing.Color.Transparent
        Me.Lnk_lbl_Tee.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnk_lbl_Tee.Location = New System.Drawing.Point(1267, 14)
        Me.Lnk_lbl_Tee.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lnk_lbl_Tee.Name = "Lnk_lbl_Tee"
        Me.Lnk_lbl_Tee.Size = New System.Drawing.Size(61, 26)
        Me.Lnk_lbl_Tee.TabIndex = 78
        Me.Lnk_lbl_Tee.TabStop = True
        Me.Lnk_lbl_Tee.Text = "T Mold"
        '
        'Lnk_lbl_FC
        '
        Me.Lnk_lbl_FC.AutoSize = True
        Me.Lnk_lbl_FC.BackColor = System.Drawing.Color.Transparent
        Me.Lnk_lbl_FC.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnk_lbl_FC.Location = New System.Drawing.Point(1117, 14)
        Me.Lnk_lbl_FC.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lnk_lbl_FC.Name = "Lnk_lbl_FC"
        Me.Lnk_lbl_FC.Size = New System.Drawing.Size(111, 26)
        Me.Lnk_lbl_FC.TabIndex = 77
        Me.Lnk_lbl_FC.TabStop = True
        Me.Lnk_lbl_FC.Text = "Floor-Ceiling"
        '
        'Lnk_lbl_TG
        '
        Me.Lnk_lbl_TG.AutoSize = True
        Me.Lnk_lbl_TG.BackColor = System.Drawing.Color.Transparent
        Me.Lnk_lbl_TG.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnk_lbl_TG.Location = New System.Drawing.Point(800, 13)
        Me.Lnk_lbl_TG.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lnk_lbl_TG.Name = "Lnk_lbl_TG"
        Me.Lnk_lbl_TG.Size = New System.Drawing.Size(64, 26)
        Me.Lnk_lbl_TG.TabIndex = 76
        Me.Lnk_lbl_TG.TabStop = True
        Me.Lnk_lbl_TG.Text = "35's TG"
        '
        'Lnk_Lbl_Corn
        '
        Me.Lnk_Lbl_Corn.AutoSize = True
        Me.Lnk_Lbl_Corn.BackColor = System.Drawing.Color.Transparent
        Me.Lnk_Lbl_Corn.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnk_Lbl_Corn.Location = New System.Drawing.Point(676, 14)
        Me.Lnk_Lbl_Corn.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lnk_Lbl_Corn.Name = "Lnk_Lbl_Corn"
        Me.Lnk_Lbl_Corn.Size = New System.Drawing.Size(73, 26)
        Me.Lnk_Lbl_Corn.TabIndex = 75
        Me.Lnk_Lbl_Corn.TabStop = True
        Me.Lnk_Lbl_Corn.Text = "Corners"
        '
        'Panel_Guillotine
        '
        Me.Panel_Guillotine.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel_Guillotine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_Guillotine.Controls.Add(Me.Button1)
        Me.Panel_Guillotine.Controls.Add(Me.Label1)
        Me.Panel_Guillotine.Controls.Add(Me.Button2)
        Me.Panel_Guillotine.Controls.Add(Me.Button3)
        Me.Panel_Guillotine.Controls.Add(Me.Chckd_lst_GM)
        Me.Panel_Guillotine.Controls.Add(Me.Txt_Bx_Jobs)
        Me.Panel_Guillotine.Location = New System.Drawing.Point(12, 43)
        Me.Panel_Guillotine.Name = "Panel_Guillotine"
        Me.Panel_Guillotine.Size = New System.Drawing.Size(168, 248)
        Me.Panel_Guillotine.TabIndex = 82
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(33, 214)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(97, 29)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Clear Filter"
        Me.Button1.UseVisualStyleBackColor = True
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
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(81, 181)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 29)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Cancel"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(12, 181)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(63, 29)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "OK"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Chckd_lst_GM
        '
        Me.Chckd_lst_GM.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chckd_lst_GM.FormattingEnabled = True
        Me.Chckd_lst_GM.Location = New System.Drawing.Point(12, 71)
        Me.Chckd_lst_GM.Name = "Chckd_lst_GM"
        Me.Chckd_lst_GM.Size = New System.Drawing.Size(143, 104)
        Me.Chckd_lst_GM.TabIndex = 1
        '
        'Txt_Bx_Jobs
        '
        Me.Txt_Bx_Jobs.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Bx_Jobs.Location = New System.Drawing.Point(12, 35)
        Me.Txt_Bx_Jobs.Name = "Txt_Bx_Jobs"
        Me.Txt_Bx_Jobs.Size = New System.Drawing.Size(143, 30)
        Me.Txt_Bx_Jobs.TabIndex = 0
        '
        'Lnk_FCTM
        '
        Me.Lnk_FCTM.AutoSize = True
        Me.Lnk_FCTM.BackColor = System.Drawing.Color.Transparent
        Me.Lnk_FCTM.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnk_FCTM.Location = New System.Drawing.Point(900, 14)
        Me.Lnk_FCTM.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Lnk_FCTM.Name = "Lnk_FCTM"
        Me.Lnk_FCTM.Size = New System.Drawing.Size(164, 26)
        Me.Lnk_FCTM.TabIndex = 83
        Me.Lnk_FCTM.TabStop = True
        Me.Lnk_FCTM.Text = "Floor-Ceiling T Mold"
        '
        'GuillotineM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 26.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackgroundImage = Global.Mold_Schedule.My.Resources.Resources.backgroung_init
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1528, 648)
        Me.Controls.Add(Me.Lnk_FCTM)
        Me.Controls.Add(Me.Panel_Guillotine)
        Me.Controls.Add(Me.Lnk_lbl_Wall)
        Me.Controls.Add(Me.Btn_Save_Guillotine)
        Me.Controls.Add(Me.Btn_Menu)
        Me.Controls.Add(Me.Lnk_lbl_Tee)
        Me.Controls.Add(Me.Lnk_lbl_FC)
        Me.Controls.Add(Me.Lnk_lbl_TG)
        Me.Controls.Add(Me.Lnk_Lbl_Corn)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Controls.Add(Me.Label50)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.DGV_Guillotine_2)
        Me.Controls.Add(Me.DGV_Guillotine1)
        Me.Controls.Add(Me.DGV_Panels_Guillotine)
        Me.Controls.Add(Me.DTP_GU)
        Me.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.Name = "GuillotineM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Guillotine Mold"
        CType(Me.DGV_Guillotine_2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_Guillotine1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_Panels_Guillotine, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.Panel_Guillotine.ResumeLayout(False)
        Me.Panel_Guillotine.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label42 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents DGV_Guillotine_2 As DataGridView
    Friend WithEvents DGV_Guillotine1 As DataGridView
    Friend WithEvents DGV_Panels_Guillotine As DataGridView
    Friend WithEvents DTP_GU As DateTimePicker
    Friend WithEvents Label44 As Label
    Friend WithEvents Label50 As Label
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents GM_Opt As ToolStripMenuItem
    Friend WithEvents Clear_GM As ToolStripMenuItem
    Friend WithEvents Print_Molds As ToolStripMenuItem
    Friend WithEvents Print_M1_GM As ToolStripMenuItem
    Friend WithEvents Print_M2_GM As ToolStripMenuItem
    Friend WithEvents Print_GM As ToolStripMenuItem
    Friend WithEvents Lnk_lbl_Wall As LinkLabel
    Friend WithEvents Btn_Save_Guillotine As Button
    Friend WithEvents Btn_Menu As Button
    Friend WithEvents Lnk_lbl_Tee As LinkLabel
    Friend WithEvents Lnk_lbl_FC As LinkLabel
    Friend WithEvents Lnk_lbl_TG As LinkLabel
    Friend WithEvents Lnk_Lbl_Corn As LinkLabel
    Friend WithEvents ID_M2_GM As DataGridViewTextBoxColumn
    Friend WithEvents Panel_M2_GM As DataGridViewTextBoxColumn
    Friend WithEvents Qty_M2_GM As DataGridViewTextBoxColumn
    Friend WithEvents CutDate_M2_GM As DataGridViewTextBoxColumn
    Friend WithEvents ID_M1_GM As DataGridViewTextBoxColumn
    Friend WithEvents Pane_M1_GM As DataGridViewTextBoxColumn
    Friend WithEvents QTY_M1_GM As DataGridViewTextBoxColumn
    Friend WithEvents CutDate_M1_GM As DataGridViewTextBoxColumn
    Friend WithEvents ID_GM As DataGridViewTextBoxColumn
    Friend WithEvents Panel_GM As DataGridViewTextBoxColumn
    Friend WithEvents Qty_GM As DataGridViewTextBoxColumn
    Friend WithEvents CutDate_GM As DataGridViewTextBoxColumn
    Friend WithEvents FilterPanelsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel_Guillotine As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Chckd_lst_GM As CheckedListBox
    Friend WithEvents Txt_Bx_Jobs As TextBox
    Friend WithEvents Lnk_FCTM As LinkLabel
End Class
