<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FCTMold
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FCTMold))
        Me.DGV_Tee_Panels = New System.Windows.Forms.DataGridView()
        Me.ID_PANELS_TEEM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PANELS_TEEM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty_TeeM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Date_TeeM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGV_TeeM = New System.Windows.Forms.DataGridView()
        Me.ID_TEEM1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panels_TeeM1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty_TeeM1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Date_TeeM1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DTP_TeeM = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Tee_Mold = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Options_TeeM = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClearMolds_TM = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintMold = New System.Windows.Forms.ToolStripMenuItem()
        Me.FilterPanelsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Lnk_lbl_Corners = New System.Windows.Forms.LinkLabel()
        Me.Lnk_lbl_GTL = New System.Windows.Forms.LinkLabel()
        Me.Lnk_Lbl_FC = New System.Windows.Forms.LinkLabel()
        Me.Lnk_lbl_TG = New System.Windows.Forms.LinkLabel()
        Me.Btn_Save_Tee = New System.Windows.Forms.Button()
        Me.Btn_Menu = New System.Windows.Forms.Button()
        Me.Lnk_Lbl_Walls = New System.Windows.Forms.LinkLabel()
        Me.Panel_TM = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Chckd_lst_TM = New System.Windows.Forms.CheckedListBox()
        Me.Txt_Bx_Jobs = New System.Windows.Forms.TextBox()
        Me.Lnk_FCTM = New System.Windows.Forms.LinkLabel()
        CType(Me.DGV_Tee_Panels, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_TeeM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel_TM.SuspendLayout()
        Me.SuspendLayout()
        '
        'DGV_Tee_Panels
        '
        Me.DGV_Tee_Panels.BackgroundColor = System.Drawing.Color.SeaShell
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_Tee_Panels.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_Tee_Panels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Tee_Panels.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID_PANELS_TEEM, Me.PANELS_TEEM, Me.Qty_TeeM, Me.Date_TeeM})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Tee_Panels.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_Tee_Panels.Location = New System.Drawing.Point(12, 96)
        Me.DGV_Tee_Panels.Name = "DGV_Tee_Panels"
        Me.DGV_Tee_Panels.Size = New System.Drawing.Size(464, 574)
        Me.DGV_Tee_Panels.TabIndex = 0
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
        'DGV_TeeM
        '
        Me.DGV_TeeM.BackgroundColor = System.Drawing.Color.SeaShell
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.MistyRose
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_TeeM.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGV_TeeM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_TeeM.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID_TEEM1, Me.Panels_TeeM1, Me.Qty_TeeM1, Me.Date_TeeM1})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_TeeM.DefaultCellStyle = DataGridViewCellStyle4
        Me.DGV_TeeM.Location = New System.Drawing.Point(535, 96)
        Me.DGV_TeeM.Name = "DGV_TeeM"
        Me.DGV_TeeM.Size = New System.Drawing.Size(464, 574)
        Me.DGV_TeeM.TabIndex = 1
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
        'DTP_TeeM
        '
        Me.DTP_TeeM.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_TeeM.Location = New System.Drawing.Point(183, 8)
        Me.DTP_TeeM.Name = "DTP_TeeM"
        Me.DTP_TeeM.Size = New System.Drawing.Size(267, 30)
        Me.DTP_TeeM.TabIndex = 35
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(127, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 26)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Date:"
        '
        'Tee_Mold
        '
        Me.Tee_Mold.AutoSize = True
        Me.Tee_Mold.BackColor = System.Drawing.Color.Transparent
        Me.Tee_Mold.Font = New System.Drawing.Font("Poppins", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tee_Mold.Location = New System.Drawing.Point(163, 51)
        Me.Tee_Mold.Name = "Tee_Mold"
        Me.Tee_Mold.Size = New System.Drawing.Size(95, 42)
        Me.Tee_Mold.TabIndex = 32
        Me.Tee_Mold.Text = "T Mold"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Options_TeeM})
        Me.MenuStrip1.Location = New System.Drawing.Point(12, 9)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(94, 36)
        Me.MenuStrip1.TabIndex = 33
        Me.MenuStrip1.Text = "MenuStrip_Wall"
        '
        'Options_TeeM
        '
        Me.Options_TeeM.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearMolds_TM, Me.PrintMold, Me.FilterPanelsToolStripMenuItem})
        Me.Options_TeeM.Name = "Options_TeeM"
        Me.Options_TeeM.Size = New System.Drawing.Size(86, 32)
        Me.Options_TeeM.Text = "Options"
        '
        'ClearMolds_TM
        '
        Me.ClearMolds_TM.Name = "ClearMolds_TM"
        Me.ClearMolds_TM.Size = New System.Drawing.Size(178, 32)
        Me.ClearMolds_TM.Text = "Clear Molds"
        '
        'PrintMold
        '
        Me.PrintMold.Name = "PrintMold"
        Me.PrintMold.Size = New System.Drawing.Size(178, 32)
        Me.PrintMold.Text = "Print Mold"
        '
        'FilterPanelsToolStripMenuItem
        '
        Me.FilterPanelsToolStripMenuItem.Name = "FilterPanelsToolStripMenuItem"
        Me.FilterPanelsToolStripMenuItem.Size = New System.Drawing.Size(178, 32)
        Me.FilterPanelsToolStripMenuItem.Text = "Filter Panels"
        '
        'Lnk_lbl_Corners
        '
        Me.Lnk_lbl_Corners.AutoSize = True
        Me.Lnk_lbl_Corners.BackColor = System.Drawing.Color.Transparent
        Me.Lnk_lbl_Corners.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnk_lbl_Corners.Location = New System.Drawing.Point(476, 45)
        Me.Lnk_lbl_Corners.Name = "Lnk_lbl_Corners"
        Me.Lnk_lbl_Corners.Size = New System.Drawing.Size(73, 26)
        Me.Lnk_lbl_Corners.TabIndex = 59
        Me.Lnk_lbl_Corners.TabStop = True
        Me.Lnk_lbl_Corners.Text = "Corners"
        '
        'Lnk_lbl_GTL
        '
        Me.Lnk_lbl_GTL.AutoSize = True
        Me.Lnk_lbl_GTL.BackColor = System.Drawing.Color.Transparent
        Me.Lnk_lbl_GTL.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnk_lbl_GTL.Location = New System.Drawing.Point(585, 45)
        Me.Lnk_lbl_GTL.Name = "Lnk_lbl_GTL"
        Me.Lnk_lbl_GTL.Size = New System.Drawing.Size(84, 26)
        Me.Lnk_lbl_GTL.TabIndex = 58
        Me.Lnk_lbl_GTL.TabStop = True
        Me.Lnk_lbl_GTL.Text = "Guillotine"
        '
        'Lnk_Lbl_FC
        '
        Me.Lnk_Lbl_FC.AutoSize = True
        Me.Lnk_Lbl_FC.BackColor = System.Drawing.Color.Transparent
        Me.Lnk_Lbl_FC.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnk_Lbl_FC.Location = New System.Drawing.Point(732, 13)
        Me.Lnk_Lbl_FC.Name = "Lnk_Lbl_FC"
        Me.Lnk_Lbl_FC.Size = New System.Drawing.Size(111, 26)
        Me.Lnk_Lbl_FC.TabIndex = 57
        Me.Lnk_Lbl_FC.TabStop = True
        Me.Lnk_Lbl_FC.Text = "Floor-Ceiling"
        '
        'Lnk_lbl_TG
        '
        Me.Lnk_lbl_TG.AutoSize = True
        Me.Lnk_lbl_TG.BackColor = System.Drawing.Color.Transparent
        Me.Lnk_lbl_TG.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnk_lbl_TG.Location = New System.Drawing.Point(585, 12)
        Me.Lnk_lbl_TG.Name = "Lnk_lbl_TG"
        Me.Lnk_lbl_TG.Size = New System.Drawing.Size(64, 26)
        Me.Lnk_lbl_TG.TabIndex = 56
        Me.Lnk_lbl_TG.TabStop = True
        Me.Lnk_lbl_TG.Text = "35's TG"
        '
        'Btn_Save_Tee
        '
        Me.Btn_Save_Tee.Font = New System.Drawing.Font("Poppins", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Save_Tee.Location = New System.Drawing.Point(903, 6)
        Me.Btn_Save_Tee.Name = "Btn_Save_Tee"
        Me.Btn_Save_Tee.Size = New System.Drawing.Size(96, 33)
        Me.Btn_Save_Tee.TabIndex = 55
        Me.Btn_Save_Tee.Text = "Save changes"
        Me.Btn_Save_Tee.UseVisualStyleBackColor = True
        '
        'Btn_Menu
        '
        Me.Btn_Menu.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Menu.Location = New System.Drawing.Point(903, 48)
        Me.Btn_Menu.Name = "Btn_Menu"
        Me.Btn_Menu.Size = New System.Drawing.Size(96, 33)
        Me.Btn_Menu.TabIndex = 54
        Me.Btn_Menu.Text = "Go To Menu"
        Me.Btn_Menu.UseVisualStyleBackColor = True
        '
        'Lnk_Lbl_Walls
        '
        Me.Lnk_Lbl_Walls.AutoSize = True
        Me.Lnk_Lbl_Walls.BackColor = System.Drawing.Color.Transparent
        Me.Lnk_Lbl_Walls.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnk_Lbl_Walls.Location = New System.Drawing.Point(476, 9)
        Me.Lnk_Lbl_Walls.Name = "Lnk_Lbl_Walls"
        Me.Lnk_Lbl_Walls.Size = New System.Drawing.Size(53, 26)
        Me.Lnk_Lbl_Walls.TabIndex = 53
        Me.Lnk_Lbl_Walls.TabStop = True
        Me.Lnk_Lbl_Walls.Text = "Walls"
        '
        'Panel_TM
        '
        Me.Panel_TM.BackColor = System.Drawing.SystemColors.ControlDark
        Me.Panel_TM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_TM.Controls.Add(Me.Button1)
        Me.Panel_TM.Controls.Add(Me.Label1)
        Me.Panel_TM.Controls.Add(Me.Button2)
        Me.Panel_TM.Controls.Add(Me.Button3)
        Me.Panel_TM.Controls.Add(Me.Chckd_lst_TM)
        Me.Panel_TM.Controls.Add(Me.Txt_Bx_Jobs)
        Me.Panel_TM.Location = New System.Drawing.Point(12, 45)
        Me.Panel_TM.Name = "Panel_TM"
        Me.Panel_TM.Size = New System.Drawing.Size(168, 248)
        Me.Panel_TM.TabIndex = 84
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
        'Chckd_lst_TM
        '
        Me.Chckd_lst_TM.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Chckd_lst_TM.FormattingEnabled = True
        Me.Chckd_lst_TM.Location = New System.Drawing.Point(12, 71)
        Me.Chckd_lst_TM.Name = "Chckd_lst_TM"
        Me.Chckd_lst_TM.Size = New System.Drawing.Size(143, 104)
        Me.Chckd_lst_TM.TabIndex = 1
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
        Me.Lnk_FCTM.Location = New System.Drawing.Point(704, 45)
        Me.Lnk_FCTM.Name = "Lnk_FCTM"
        Me.Lnk_FCTM.Size = New System.Drawing.Size(164, 26)
        Me.Lnk_FCTM.TabIndex = 85
        Me.Lnk_FCTM.TabStop = True
        Me.Lnk_FCTM.Text = "Floor-Ceiling T Mold"
        '
        'FCTMold
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Mold_Schedule.My.Resources.Resources.backgroung_init
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1011, 680)
        Me.Controls.Add(Me.Lnk_FCTM)
        Me.Controls.Add(Me.Panel_TM)
        Me.Controls.Add(Me.Lnk_lbl_Corners)
        Me.Controls.Add(Me.Lnk_lbl_GTL)
        Me.Controls.Add(Me.Lnk_Lbl_FC)
        Me.Controls.Add(Me.Lnk_lbl_TG)
        Me.Controls.Add(Me.Btn_Save_Tee)
        Me.Controls.Add(Me.Btn_Menu)
        Me.Controls.Add(Me.Lnk_Lbl_Walls)
        Me.Controls.Add(Me.DTP_TeeM)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Tee_Mold)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.DGV_TeeM)
        Me.Controls.Add(Me.DGV_Tee_Panels)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FCTMold"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tee Mold"
        CType(Me.DGV_Tee_Panels, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_TeeM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel_TM.ResumeLayout(False)
        Me.Panel_TM.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DGV_Tee_Panels As DataGridView
    Friend WithEvents DGV_TeeM As DataGridView
    Friend WithEvents ID_PANELS_TEEM As DataGridViewTextBoxColumn
    Friend WithEvents PANELS_TEEM As DataGridViewTextBoxColumn
    Friend WithEvents Qty_TeeM As DataGridViewTextBoxColumn
    Friend WithEvents Date_TeeM As DataGridViewTextBoxColumn
    Friend WithEvents ID_TEEM1 As DataGridViewTextBoxColumn
    Friend WithEvents Panels_TeeM1 As DataGridViewTextBoxColumn
    Friend WithEvents Qty_TeeM1 As DataGridViewTextBoxColumn
    Friend WithEvents Date_TeeM1 As DataGridViewTextBoxColumn
    Friend WithEvents DTP_TeeM As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Tee_Mold As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents Options_TeeM As ToolStripMenuItem
    Friend WithEvents ClearMolds_TM As ToolStripMenuItem
    Friend WithEvents PrintMold As ToolStripMenuItem
    Friend WithEvents Lnk_lbl_Corners As LinkLabel
    Friend WithEvents Lnk_lbl_GTL As LinkLabel
    Friend WithEvents Lnk_Lbl_FC As LinkLabel
    Friend WithEvents Lnk_lbl_TG As LinkLabel
    Friend WithEvents Btn_Save_Tee As Button
    Friend WithEvents Btn_Menu As Button
    Friend WithEvents Lnk_Lbl_Walls As LinkLabel
    Friend WithEvents FilterPanelsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel_TM As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Chckd_lst_TM As CheckedListBox
    Friend WithEvents Txt_Bx_Jobs As TextBox
    Friend WithEvents Lnk_FCTM As LinkLabel
End Class
