<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FCMold
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FCMold))
        Me.DGV_Floors = New System.Windows.Forms.DataGridView()
        Me.ID_FC_M = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panels_FC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty_FC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CutDate_FC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DTP_FL = New System.Windows.Forms.DateTimePicker()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.DGV_M17_FL = New System.Windows.Forms.DataGridView()
        Me.ID_FC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel_M17_FC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty_M17_FC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CutDate_M17_FC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGV_M15_FL = New System.Windows.Forms.DataGridView()
        Me.ID_M15_FC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel_M15_FC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty_M15_FC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CutDate_M15_FC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Btn_Save_FC = New System.Windows.Forms.Button()
        Me.Btn_Menu = New System.Windows.Forms.Button()
        Me.Lnk_lbl_Tee = New System.Windows.Forms.LinkLabel()
        Me.Lnk_lbl_GTL = New System.Windows.Forms.LinkLabel()
        Me.Lnk_lbl_TG = New System.Windows.Forms.LinkLabel()
        Me.Lnk_Lbl_Corn = New System.Windows.Forms.LinkLabel()
        Me.Lnk_lbl_Wall = New System.Windows.Forms.LinkLabel()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.Options = New System.Windows.Forms.ToolStripMenuItem()
        Me.Clear_Molds = New System.Windows.Forms.ToolStripMenuItem()
        Me.Print_Molds = New System.Windows.Forms.ToolStripMenuItem()
        Me.Print_Mold15 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Print_Mold17 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Print_All_Molds = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel_FC = New System.Windows.Forms.Panel()
        Me.Btn_Clear_Filter = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Btn_Cancel = New System.Windows.Forms.Button()
        Me.Btn_Filter = New System.Windows.Forms.Button()
        Me.Chckd_Lst_Bx_Jobs = New System.Windows.Forms.CheckedListBox()
        Me.Txt_Bx_Jobs = New System.Windows.Forms.TextBox()
        Me.LNK_FCTM = New System.Windows.Forms.LinkLabel()
        CType(Me.DGV_Floors, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_M17_FL, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_M15_FL, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip2.SuspendLayout()
        Me.Panel_FC.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGV_Floors
        '
        Me.DGV_Floors.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_Floors.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_Floors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Floors.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID_FC_M, Me.Panels_FC, Me.Qty_FC, Me.CutDate_FC})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Floors.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_Floors.Location = New System.Drawing.Point(12, 104)
        Me.DGV_Floors.Name = "DGV_Floors"
        Me.DGV_Floors.Size = New System.Drawing.Size(450, 532)
        Me.DGV_Floors.TabIndex = 57
        '
        'ID_FC_M
        '
        Me.ID_FC_M.HeaderText = "ID"
        Me.ID_FC_M.Name = "ID_FC_M"
        Me.ID_FC_M.ReadOnly = True
        Me.ID_FC_M.Visible = False
        '
        'Panels_FC
        '
        Me.Panels_FC.HeaderText = "Panel"
        Me.Panels_FC.Name = "Panels_FC"
        Me.Panels_FC.ReadOnly = True
        Me.Panels_FC.Width = 220
        '
        'Qty_FC
        '
        Me.Qty_FC.HeaderText = "Qty"
        Me.Qty_FC.Name = "Qty_FC"
        Me.Qty_FC.ReadOnly = True
        Me.Qty_FC.Width = 40
        '
        'CutDate_FC
        '
        Me.CutDate_FC.HeaderText = "Date"
        Me.CutDate_FC.Name = "CutDate_FC"
        Me.CutDate_FC.ReadOnly = True
        Me.CutDate_FC.Width = 145
        '
        'DTP_FL
        '
        Me.DTP_FL.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_FL.Location = New System.Drawing.Point(189, 7)
        Me.DTP_FL.Name = "DTP_FL"
        Me.DTP_FL.Size = New System.Drawing.Size(273, 30)
        Me.DTP_FL.TabIndex = 59
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(133, 10)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(50, 26)
        Me.Label37.TabIndex = 58
        Me.Label37.Text = "Date:"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Poppins SemiBold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(1150, 67)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(106, 42)
        Me.Label38.TabIndex = 63
        Me.Label38.Text = "Mold 17"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Font = New System.Drawing.Font("Poppins SemiBold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(638, 67)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(108, 42)
        Me.Label39.TabIndex = 62
        Me.Label39.Text = "Mold 15"
        '
        'DGV_M17_FL
        '
        Me.DGV_M17_FL.BackgroundColor = System.Drawing.Color.LavenderBlush
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_M17_FL.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGV_M17_FL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_M17_FL.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID_FC, Me.Panel_M17_FC, Me.Qty_M17_FC, Me.CutDate_M17_FC})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_M17_FL.DefaultCellStyle = DataGridViewCellStyle4
        Me.DGV_M17_FL.Location = New System.Drawing.Point(954, 112)
        Me.DGV_M17_FL.Name = "DGV_M17_FL"
        Me.DGV_M17_FL.Size = New System.Drawing.Size(464, 524)
        Me.DGV_M17_FL.TabIndex = 61
        '
        'ID_FC
        '
        Me.ID_FC.HeaderText = "ID"
        Me.ID_FC.Name = "ID_FC"
        Me.ID_FC.ReadOnly = True
        Me.ID_FC.Visible = False
        '
        'Panel_M17_FC
        '
        Me.Panel_M17_FC.HeaderText = "Panel"
        Me.Panel_M17_FC.Name = "Panel_M17_FC"
        Me.Panel_M17_FC.ReadOnly = True
        Me.Panel_M17_FC.Width = 230
        '
        'Qty_M17_FC
        '
        Me.Qty_M17_FC.HeaderText = "Qty"
        Me.Qty_M17_FC.Name = "Qty_M17_FC"
        Me.Qty_M17_FC.ReadOnly = True
        Me.Qty_M17_FC.Width = 40
        '
        'CutDate_M17_FC
        '
        Me.CutDate_M17_FC.HeaderText = "Date"
        Me.CutDate_M17_FC.Name = "CutDate_M17_FC"
        Me.CutDate_M17_FC.ReadOnly = True
        Me.CutDate_M17_FC.Width = 150
        '
        'DGV_M15_FL
        '
        Me.DGV_M15_FL.BackgroundColor = System.Drawing.Color.LavenderBlush
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_M15_FL.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.DGV_M15_FL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_M15_FL.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID_M15_FC, Me.Panel_M15_FC, Me.Qty_M15_FC, Me.CutDate_M15_FC})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_M15_FL.DefaultCellStyle = DataGridViewCellStyle6
        Me.DGV_M15_FL.Location = New System.Drawing.Point(472, 112)
        Me.DGV_M15_FL.Name = "DGV_M15_FL"
        Me.DGV_M15_FL.Size = New System.Drawing.Size(464, 524)
        Me.DGV_M15_FL.TabIndex = 60
        '
        'ID_M15_FC
        '
        Me.ID_M15_FC.HeaderText = "ID"
        Me.ID_M15_FC.Name = "ID_M15_FC"
        Me.ID_M15_FC.ReadOnly = True
        Me.ID_M15_FC.Visible = False
        '
        'Panel_M15_FC
        '
        Me.Panel_M15_FC.HeaderText = "Panel"
        Me.Panel_M15_FC.Name = "Panel_M15_FC"
        Me.Panel_M15_FC.ReadOnly = True
        Me.Panel_M15_FC.Width = 230
        '
        'Qty_M15_FC
        '
        Me.Qty_M15_FC.HeaderText = "Qty"
        Me.Qty_M15_FC.Name = "Qty_M15_FC"
        Me.Qty_M15_FC.ReadOnly = True
        Me.Qty_M15_FC.Width = 40
        '
        'CutDate_M15_FC
        '
        Me.CutDate_M15_FC.HeaderText = "Date"
        Me.CutDate_M15_FC.Name = "CutDate_M15_FC"
        Me.CutDate_M15_FC.ReadOnly = True
        Me.CutDate_M15_FC.Width = 150
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.BackColor = System.Drawing.Color.Transparent
        Me.Label49.Font = New System.Drawing.Font("Poppins", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(131, 50)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(183, 42)
        Me.Label49.TabIndex = 66
        Me.Label49.Text = "Floor - Ceiling"
        '
        'Btn_Save_FC
        '
        Me.Btn_Save_FC.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Save_FC.Location = New System.Drawing.Point(1295, 7)
        Me.Btn_Save_FC.Name = "Btn_Save_FC"
        Me.Btn_Save_FC.Size = New System.Drawing.Size(123, 33)
        Me.Btn_Save_FC.TabIndex = 73
        Me.Btn_Save_FC.Text = "Save changes"
        Me.Btn_Save_FC.UseVisualStyleBackColor = True
        '
        'Btn_Menu
        '
        Me.Btn_Menu.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Menu.Location = New System.Drawing.Point(1318, 59)
        Me.Btn_Menu.Name = "Btn_Menu"
        Me.Btn_Menu.Size = New System.Drawing.Size(96, 33)
        Me.Btn_Menu.TabIndex = 72
        Me.Btn_Menu.Text = "Go To Menu"
        Me.Btn_Menu.UseVisualStyleBackColor = True
        '
        'Lnk_lbl_Tee
        '
        Me.Lnk_lbl_Tee.AutoSize = True
        Me.Lnk_lbl_Tee.BackColor = System.Drawing.Color.Transparent
        Me.Lnk_lbl_Tee.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnk_lbl_Tee.Location = New System.Drawing.Point(962, 17)
        Me.Lnk_lbl_Tee.Name = "Lnk_lbl_Tee"
        Me.Lnk_lbl_Tee.Size = New System.Drawing.Size(61, 26)
        Me.Lnk_lbl_Tee.TabIndex = 71
        Me.Lnk_lbl_Tee.TabStop = True
        Me.Lnk_lbl_Tee.Text = "T Mold"
        '
        'Lnk_lbl_GTL
        '
        Me.Lnk_lbl_GTL.AutoSize = True
        Me.Lnk_lbl_GTL.BackColor = System.Drawing.Color.Transparent
        Me.Lnk_lbl_GTL.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnk_lbl_GTL.Location = New System.Drawing.Point(828, 17)
        Me.Lnk_lbl_GTL.Name = "Lnk_lbl_GTL"
        Me.Lnk_lbl_GTL.Size = New System.Drawing.Size(84, 26)
        Me.Lnk_lbl_GTL.TabIndex = 70
        Me.Lnk_lbl_GTL.TabStop = True
        Me.Lnk_lbl_GTL.Text = "Guillotine"
        '
        'Lnk_lbl_TG
        '
        Me.Lnk_lbl_TG.AutoSize = True
        Me.Lnk_lbl_TG.BackColor = System.Drawing.Color.Transparent
        Me.Lnk_lbl_TG.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnk_lbl_TG.Location = New System.Drawing.Point(713, 17)
        Me.Lnk_lbl_TG.Name = "Lnk_lbl_TG"
        Me.Lnk_lbl_TG.Size = New System.Drawing.Size(64, 26)
        Me.Lnk_lbl_TG.TabIndex = 68
        Me.Lnk_lbl_TG.TabStop = True
        Me.Lnk_lbl_TG.Text = "35's TG"
        '
        'Lnk_Lbl_Corn
        '
        Me.Lnk_Lbl_Corn.AutoSize = True
        Me.Lnk_Lbl_Corn.BackColor = System.Drawing.Color.Transparent
        Me.Lnk_Lbl_Corn.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnk_Lbl_Corn.Location = New System.Drawing.Point(591, 17)
        Me.Lnk_Lbl_Corn.Name = "Lnk_Lbl_Corn"
        Me.Lnk_Lbl_Corn.Size = New System.Drawing.Size(73, 26)
        Me.Lnk_Lbl_Corn.TabIndex = 67
        Me.Lnk_Lbl_Corn.TabStop = True
        Me.Lnk_Lbl_Corn.Text = "Corners"
        '
        'Lnk_lbl_Wall
        '
        Me.Lnk_lbl_Wall.AutoSize = True
        Me.Lnk_lbl_Wall.BackColor = System.Drawing.Color.Transparent
        Me.Lnk_lbl_Wall.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnk_lbl_Wall.Location = New System.Drawing.Point(485, 17)
        Me.Lnk_lbl_Wall.Name = "Lnk_lbl_Wall"
        Me.Lnk_lbl_Wall.Size = New System.Drawing.Size(53, 26)
        Me.Lnk_lbl_Wall.TabIndex = 74
        Me.Lnk_lbl_Wall.TabStop = True
        Me.Lnk_lbl_Wall.Text = "Walls"
        '
        'MenuStrip2
        '
        Me.MenuStrip2.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip2.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Options})
        Me.MenuStrip2.Location = New System.Drawing.Point(12, 7)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(94, 36)
        Me.MenuStrip2.TabIndex = 75
        Me.MenuStrip2.Text = "MenuStrip_Wall"
        '
        'Options
        '
        Me.Options.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Clear_Molds, Me.Print_Molds, Me.FilterToolStripMenuItem})
        Me.Options.Name = "Options"
        Me.Options.Size = New System.Drawing.Size(86, 32)
        Me.Options.Text = "Options"
        '
        'Clear_Molds
        '
        Me.Clear_Molds.Name = "Clear_Molds"
        Me.Clear_Molds.Size = New System.Drawing.Size(178, 32)
        Me.Clear_Molds.Text = "Clear Molds"
        '
        'Print_Molds
        '
        Me.Print_Molds.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Print_Mold15, Me.Print_Mold17, Me.Print_All_Molds})
        Me.Print_Molds.Name = "Print_Molds"
        Me.Print_Molds.Size = New System.Drawing.Size(178, 32)
        Me.Print_Molds.Text = "Print Molds"
        '
        'Print_Mold15
        '
        Me.Print_Mold15.Name = "Print_Mold15"
        Me.Print_Mold15.Size = New System.Drawing.Size(193, 32)
        Me.Print_Mold15.Text = "Print Mold 15"
        '
        'Print_Mold17
        '
        Me.Print_Mold17.Name = "Print_Mold17"
        Me.Print_Mold17.Size = New System.Drawing.Size(193, 32)
        Me.Print_Mold17.Text = "Print Mold 17"
        '
        'Print_All_Molds
        '
        Me.Print_All_Molds.Name = "Print_All_Molds"
        Me.Print_All_Molds.Size = New System.Drawing.Size(193, 32)
        Me.Print_All_Molds.Text = "Print All Molds"
        '
        'FilterToolStripMenuItem
        '
        Me.FilterToolStripMenuItem.Name = "FilterToolStripMenuItem"
        Me.FilterToolStripMenuItem.Size = New System.Drawing.Size(178, 32)
        Me.FilterToolStripMenuItem.Text = "Filter Panels"
        '
        'Panel_FC
        '
        Me.Panel_FC.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel_FC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_FC.Controls.Add(Me.Btn_Clear_Filter)
        Me.Panel_FC.Controls.Add(Me.Label17)
        Me.Panel_FC.Controls.Add(Me.Btn_Cancel)
        Me.Panel_FC.Controls.Add(Me.Btn_Filter)
        Me.Panel_FC.Controls.Add(Me.Chckd_Lst_Bx_Jobs)
        Me.Panel_FC.Controls.Add(Me.Txt_Bx_Jobs)
        Me.Panel_FC.Location = New System.Drawing.Point(15, 46)
        Me.Panel_FC.Name = "Panel_FC"
        Me.Panel_FC.Size = New System.Drawing.Size(168, 248)
        Me.Panel_FC.TabIndex = 76
        '
        'Btn_Clear_Filter
        '
        Me.Btn_Clear_Filter.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Clear_Filter.Location = New System.Drawing.Point(33, 214)
        Me.Btn_Clear_Filter.Name = "Btn_Clear_Filter"
        Me.Btn_Clear_Filter.Size = New System.Drawing.Size(97, 29)
        Me.Btn_Clear_Filter.TabIndex = 5
        Me.Btn_Clear_Filter.Text = "Clear Filter"
        Me.Btn_Clear_Filter.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Poppins SemiBold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(28, 4)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(113, 28)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "Job Number"
        '
        'Btn_Cancel
        '
        Me.Btn_Cancel.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Cancel.Location = New System.Drawing.Point(81, 181)
        Me.Btn_Cancel.Name = "Btn_Cancel"
        Me.Btn_Cancel.Size = New System.Drawing.Size(75, 29)
        Me.Btn_Cancel.TabIndex = 3
        Me.Btn_Cancel.Text = "Cancel"
        Me.Btn_Cancel.UseVisualStyleBackColor = True
        '
        'Btn_Filter
        '
        Me.Btn_Filter.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Filter.Location = New System.Drawing.Point(12, 181)
        Me.Btn_Filter.Name = "Btn_Filter"
        Me.Btn_Filter.Size = New System.Drawing.Size(63, 29)
        Me.Btn_Filter.TabIndex = 2
        Me.Btn_Filter.Text = "OK"
        Me.Btn_Filter.UseVisualStyleBackColor = True
        '
        'Chckd_Lst_Bx_Jobs
        '
        Me.Chckd_Lst_Bx_Jobs.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chckd_Lst_Bx_Jobs.FormattingEnabled = True
        Me.Chckd_Lst_Bx_Jobs.Location = New System.Drawing.Point(12, 71)
        Me.Chckd_Lst_Bx_Jobs.Name = "Chckd_Lst_Bx_Jobs"
        Me.Chckd_Lst_Bx_Jobs.Size = New System.Drawing.Size(143, 104)
        Me.Chckd_Lst_Bx_Jobs.TabIndex = 1
        '
        'Txt_Bx_Jobs
        '
        Me.Txt_Bx_Jobs.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Bx_Jobs.Location = New System.Drawing.Point(12, 35)
        Me.Txt_Bx_Jobs.Name = "Txt_Bx_Jobs"
        Me.Txt_Bx_Jobs.Size = New System.Drawing.Size(143, 30)
        Me.Txt_Bx_Jobs.TabIndex = 0
        '
        'LNK_FCTM
        '
        Me.LNK_FCTM.AutoSize = True
        Me.LNK_FCTM.BackColor = System.Drawing.Color.Transparent
        Me.LNK_FCTM.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LNK_FCTM.Location = New System.Drawing.Point(1092, 17)
        Me.LNK_FCTM.Name = "LNK_FCTM"
        Me.LNK_FCTM.Size = New System.Drawing.Size(164, 26)
        Me.LNK_FCTM.TabIndex = 77
        Me.LNK_FCTM.TabStop = True
        Me.LNK_FCTM.Text = "Floor-Ceiling T Mold"
        '
        'FCMold
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackgroundImage = Global.Mold_Schedule.My.Resources.Resources.backgroung_init
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1426, 648)
        Me.Controls.Add(Me.LNK_FCTM)
        Me.Controls.Add(Me.Panel_FC)
        Me.Controls.Add(Me.MenuStrip2)
        Me.Controls.Add(Me.Lnk_lbl_Wall)
        Me.Controls.Add(Me.Btn_Save_FC)
        Me.Controls.Add(Me.Btn_Menu)
        Me.Controls.Add(Me.Lnk_lbl_Tee)
        Me.Controls.Add(Me.Lnk_lbl_GTL)
        Me.Controls.Add(Me.Lnk_lbl_TG)
        Me.Controls.Add(Me.Lnk_Lbl_Corn)
        Me.Controls.Add(Me.Label49)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.DGV_M17_FL)
        Me.Controls.Add(Me.DGV_M15_FL)
        Me.Controls.Add(Me.DTP_FL)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.DGV_Floors)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FCMold"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Floor-Ceiling Molds"
        CType(Me.DGV_Floors, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_M17_FL, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_M15_FL, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.Panel_FC.ResumeLayout(False)
        Me.Panel_FC.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DGV_Floors As DataGridView
    Friend WithEvents DTP_FL As DateTimePicker
    Friend WithEvents Label37 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents DGV_M17_FL As DataGridView
    Friend WithEvents DGV_M15_FL As DataGridView
    Friend WithEvents Label49 As Label
    Friend WithEvents Btn_Save_FC As Button
    Friend WithEvents Btn_Menu As Button
    Friend WithEvents Lnk_lbl_Tee As LinkLabel
    Friend WithEvents Lnk_lbl_GTL As LinkLabel
    Friend WithEvents Lnk_lbl_TG As LinkLabel
    Friend WithEvents Lnk_Lbl_Corn As LinkLabel
    Friend WithEvents Lnk_lbl_Wall As LinkLabel
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents Options As ToolStripMenuItem
    Friend WithEvents Clear_Molds As ToolStripMenuItem
    Friend WithEvents Print_Molds As ToolStripMenuItem
    Friend WithEvents Print_Mold15 As ToolStripMenuItem
    Friend WithEvents Print_Mold17 As ToolStripMenuItem
    Friend WithEvents Print_All_Molds As ToolStripMenuItem
    Friend WithEvents ID_FC_M As DataGridViewTextBoxColumn
    Friend WithEvents Panels_FC As DataGridViewTextBoxColumn
    Friend WithEvents Qty_FC As DataGridViewTextBoxColumn
    Friend WithEvents CutDate_FC As DataGridViewTextBoxColumn
    Friend WithEvents ID_FC As DataGridViewTextBoxColumn
    Friend WithEvents Panel_M17_FC As DataGridViewTextBoxColumn
    Friend WithEvents Qty_M17_FC As DataGridViewTextBoxColumn
    Friend WithEvents CutDate_M17_FC As DataGridViewTextBoxColumn
    Friend WithEvents ID_M15_FC As DataGridViewTextBoxColumn
    Friend WithEvents Panel_M15_FC As DataGridViewTextBoxColumn
    Friend WithEvents Qty_M15_FC As DataGridViewTextBoxColumn
    Friend WithEvents CutDate_M15_FC As DataGridViewTextBoxColumn
    Friend WithEvents FilterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel_FC As Panel
    Friend WithEvents Btn_Clear_Filter As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents Btn_Cancel As Button
    Friend WithEvents Btn_Filter As Button
    Friend WithEvents Chckd_Lst_Bx_Jobs As CheckedListBox
    Friend WithEvents Txt_Bx_Jobs As TextBox
    Friend WithEvents LNK_FCTM As LinkLabel
End Class
