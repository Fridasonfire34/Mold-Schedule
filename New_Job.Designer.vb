<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class New_Job
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(New_Job))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MSKD_Txt_JOB = New System.Windows.Forms.MaskedTextBox()
        Me.BTN_ADDJOB = New System.Windows.Forms.Button()
        Me.DGV_Jobs = New System.Windows.Forms.DataGridView()
        Me.Job_Number = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Ext = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Width = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HGT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Int = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Thickness = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lst_Bx_Jobs = New System.Windows.Forms.ListBox()
        Me.Btn_Save_Jobs = New System.Windows.Forms.Button()
        Me.Lnk_lbl_Back = New System.Windows.Forms.LinkLabel()
        Me.CheckBox_Thick = New System.Windows.Forms.CheckBox()
        Me.Txt_Bx_Thick = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Lbl_ThickError = New System.Windows.Forms.Label()
        CType(Me.DGV_Jobs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(112, 28)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Job Number:"
        '
        'MSKD_Txt_JOB
        '
        Me.MSKD_Txt_JOB.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MSKD_Txt_JOB.Location = New System.Drawing.Point(139, 15)
        Me.MSKD_Txt_JOB.Mask = "000-0000-AA-AA"
        Me.MSKD_Txt_JOB.Name = "MSKD_Txt_JOB"
        Me.MSKD_Txt_JOB.Size = New System.Drawing.Size(206, 31)
        Me.MSKD_Txt_JOB.TabIndex = 1
        '
        'BTN_ADDJOB
        '
        Me.BTN_ADDJOB.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ADDJOB.Location = New System.Drawing.Point(958, 138)
        Me.BTN_ADDJOB.Name = "BTN_ADDJOB"
        Me.BTN_ADDJOB.Size = New System.Drawing.Size(107, 66)
        Me.BTN_ADDJOB.TabIndex = 2
        Me.BTN_ADDJOB.Text = "Add Panels"
        Me.BTN_ADDJOB.UseVisualStyleBackColor = True
        '
        'DGV_Jobs
        '
        Me.DGV_Jobs.BackgroundColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Poppins", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGV_Jobs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_Jobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Jobs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Job_Number, Me.Qty, Me.Ext, Me.Width, Me.HGT, Me.Int, Me.Description, Me.Thickness})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Jobs.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGV_Jobs.GridColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.DGV_Jobs.Location = New System.Drawing.Point(12, 282)
        Me.DGV_Jobs.Name = "DGV_Jobs"
        Me.DGV_Jobs.Size = New System.Drawing.Size(940, 273)
        Me.DGV_Jobs.TabIndex = 3
        '
        'Job_Number
        '
        Me.Job_Number.HeaderText = "Job Number"
        Me.Job_Number.Name = "Job_Number"
        Me.Job_Number.Width = 135
        '
        'Qty
        '
        Me.Qty.HeaderText = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.Width = 50
        '
        'Ext
        '
        Me.Ext.HeaderText = "Ext."
        Me.Ext.Name = "Ext"
        Me.Ext.Width = 70
        '
        'Width
        '
        Me.Width.HeaderText = "Width"
        Me.Width.Name = "Width"
        Me.Width.Width = 70
        '
        'HGT
        '
        Me.HGT.HeaderText = "HGT"
        Me.HGT.Name = "HGT"
        Me.HGT.Width = 70
        '
        'Int
        '
        Me.Int.HeaderText = "INT"
        Me.Int.Name = "Int"
        Me.Int.Width = 70
        '
        'Description
        '
        Me.Description.HeaderText = "Description"
        Me.Description.Name = "Description"
        Me.Description.Width = 335
        '
        'Thickness
        '
        Me.Thickness.HeaderText = "Thickness"
        Me.Thickness.Name = "Thickness"
        Me.Thickness.Width = 80
        '
        'Lst_Bx_Jobs
        '
        Me.Lst_Bx_Jobs.Font = New System.Drawing.Font("Poppins", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lst_Bx_Jobs.FormattingEnabled = True
        Me.Lst_Bx_Jobs.ItemHeight = 26
        Me.Lst_Bx_Jobs.Location = New System.Drawing.Point(13, 70)
        Me.Lst_Bx_Jobs.Name = "Lst_Bx_Jobs"
        Me.Lst_Bx_Jobs.Size = New System.Drawing.Size(939, 186)
        Me.Lst_Bx_Jobs.TabIndex = 4
        '
        'Btn_Save_Jobs
        '
        Me.Btn_Save_Jobs.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Save_Jobs.Location = New System.Drawing.Point(958, 385)
        Me.Btn_Save_Jobs.Name = "Btn_Save_Jobs"
        Me.Btn_Save_Jobs.Size = New System.Drawing.Size(107, 43)
        Me.Btn_Save_Jobs.TabIndex = 5
        Me.Btn_Save_Jobs.Text = "Save Job"
        Me.Btn_Save_Jobs.UseVisualStyleBackColor = True
        '
        'Lnk_lbl_Back
        '
        Me.Lnk_lbl_Back.AutoSize = True
        Me.Lnk_lbl_Back.BackColor = System.Drawing.Color.Transparent
        Me.Lnk_lbl_Back.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lnk_lbl_Back.Location = New System.Drawing.Point(986, 9)
        Me.Lnk_lbl_Back.Name = "Lnk_lbl_Back"
        Me.Lnk_lbl_Back.Size = New System.Drawing.Size(84, 23)
        Me.Lnk_lbl_Back.TabIndex = 6
        Me.Lnk_lbl_Back.TabStop = True
        Me.Lnk_lbl_Back.Text = "Go To Menu"
        '
        'CheckBox_Thick
        '
        Me.CheckBox_Thick.AutoSize = True
        Me.CheckBox_Thick.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox_Thick.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox_Thick.Location = New System.Drawing.Point(422, 19)
        Me.CheckBox_Thick.Name = "CheckBox_Thick"
        Me.CheckBox_Thick.Size = New System.Drawing.Size(145, 32)
        Me.CheckBox_Thick.TabIndex = 7
        Me.CheckBox_Thick.Text = "Add Thickness"
        Me.CheckBox_Thick.UseVisualStyleBackColor = False
        '
        'Txt_Bx_Thick
        '
        Me.Txt_Bx_Thick.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Txt_Bx_Thick.Location = New System.Drawing.Point(573, 15)
        Me.Txt_Bx_Thick.Name = "Txt_Bx_Thick"
        Me.Txt_Bx_Thick.Size = New System.Drawing.Size(100, 31)
        Me.Txt_Bx_Thick.TabIndex = 8
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.Mold_Schedule.My.Resources.Resources.Warning_icon__The_attention_icon
        Me.PictureBox1.Location = New System.Drawing.Point(676, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'Lbl_ThickError
        '
        Me.Lbl_ThickError.AutoSize = True
        Me.Lbl_ThickError.BackColor = System.Drawing.Color.Transparent
        Me.Lbl_ThickError.Font = New System.Drawing.Font("Poppins", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_ThickError.Location = New System.Drawing.Point(711, 20)
        Me.Lbl_ThickError.Name = "Lbl_ThickError"
        Me.Lbl_ThickError.Size = New System.Drawing.Size(109, 23)
        Me.Lbl_ThickError.TabIndex = 10
        Me.Lbl_ThickError.Text = "Enter Thickness"
        '
        'New_Job
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackgroundImage = Global.Mold_Schedule.My.Resources.Resources.elegante_fondo_flujo_lineas_onduladas_suaves___Copy2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1077, 567)
        Me.Controls.Add(Me.Lbl_ThickError)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Txt_Bx_Thick)
        Me.Controls.Add(Me.CheckBox_Thick)
        Me.Controls.Add(Me.Lnk_lbl_Back)
        Me.Controls.Add(Me.Btn_Save_Jobs)
        Me.Controls.Add(Me.Lst_Bx_Jobs)
        Me.Controls.Add(Me.DGV_Jobs)
        Me.Controls.Add(Me.BTN_ADDJOB)
        Me.Controls.Add(Me.MSKD_Txt_JOB)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "New_Job"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "New Job"
        CType(Me.DGV_Jobs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents MSKD_Txt_JOB As MaskedTextBox
    Friend WithEvents BTN_ADDJOB As Button
    Friend WithEvents DGV_Jobs As DataGridView
    Friend WithEvents Lst_Bx_Jobs As ListBox
    Friend WithEvents Btn_Save_Jobs As Button
    Friend WithEvents Lnk_lbl_Back As LinkLabel
    Friend WithEvents CheckBox_Thick As CheckBox
    Friend WithEvents Txt_Bx_Thick As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Lbl_ThickError As Label
    Friend WithEvents Job_Number As DataGridViewTextBoxColumn
    Friend WithEvents Qty As DataGridViewTextBoxColumn
    Friend WithEvents Ext As DataGridViewTextBoxColumn
    Friend WithEvents Width As DataGridViewTextBoxColumn
    Friend WithEvents HGT As DataGridViewTextBoxColumn
    Friend WithEvents Int As DataGridViewTextBoxColumn
    Friend WithEvents Description As DataGridViewTextBoxColumn
    Friend WithEvents Thickness As DataGridViewTextBoxColumn
End Class
