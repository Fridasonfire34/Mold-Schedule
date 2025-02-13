<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Btn_New_Job = New System.Windows.Forms.Button()
        Me.Btn_Molds = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Btn_Jobs = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Btn_New_Job
        '
        Me.Btn_New_Job.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_New_Job.Location = New System.Drawing.Point(36, 156)
        Me.Btn_New_Job.Name = "Btn_New_Job"
        Me.Btn_New_Job.Size = New System.Drawing.Size(148, 66)
        Me.Btn_New_Job.TabIndex = 1
        Me.Btn_New_Job.Text = "Add New Job"
        Me.Btn_New_Job.UseVisualStyleBackColor = True
        '
        'Btn_Molds
        '
        Me.Btn_Molds.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Molds.Location = New System.Drawing.Point(245, 156)
        Me.Btn_Molds.Name = "Btn_Molds"
        Me.Btn_Molds.Size = New System.Drawing.Size(148, 66)
        Me.Btn_Molds.TabIndex = 2
        Me.Btn_Molds.Text = "Molds"
        Me.Btn_Molds.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Image = Global.Mold_Schedule.My.Resources.Resources.Bitmap_1__1_
        Me.PictureBox1.Location = New System.Drawing.Point(202, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(240, 99)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Btn_Jobs
        '
        Me.Btn_Jobs.Font = New System.Drawing.Font("Poppins", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Btn_Jobs.Location = New System.Drawing.Point(452, 156)
        Me.Btn_Jobs.Name = "Btn_Jobs"
        Me.Btn_Jobs.Size = New System.Drawing.Size(148, 66)
        Me.Btn_Jobs.TabIndex = 3
        Me.Btn_Jobs.Text = "See jobs"
        Me.Btn_Jobs.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackgroundImage = Global.Mold_Schedule.My.Resources.Resources.backgroung_init2
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(648, 302)
        Me.Controls.Add(Me.Btn_Jobs)
        Me.Controls.Add(Me.Btn_Molds)
        Me.Controls.Add(Me.Btn_New_Job)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mold Schedule"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Btn_New_Job As Button
    Friend WithEvents Btn_Molds As Button
    Friend WithEvents Btn_Jobs As Button
End Class
