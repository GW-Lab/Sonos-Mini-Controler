<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSettings
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
      Me.LblVersion = New System.Windows.Forms.Label()
      Me.TxtAccount = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.TxtPassword = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.GrpNAS = New System.Windows.Forms.GroupBox()
      Me.TxtNAS_UNC = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.GrpMusic = New System.Windows.Forms.GroupBox()
      Me.NudBass = New System.Windows.Forms.NumericUpDown()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.ChkShuffle = New System.Windows.Forms.CheckBox()
      Me.ChkRepeat = New System.Windows.Forms.CheckBox()
      Me.NudInverval = New System.Windows.Forms.NumericUpDown()
      Me.LblIntervalSeconds = New System.Windows.Forms.Label()
      Me.ChkTopMost = New System.Windows.Forms.CheckBox()
      Me.btnOK = New System.Windows.Forms.Button()
      Me.LblInterval = New System.Windows.Forms.Label()
      Me.GrpGUI = New System.Windows.Forms.GroupBox()
      Me.GrpNAS.SuspendLayout()
      Me.GrpMusic.SuspendLayout()
      CType(Me.NudBass, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.GroupBox1.SuspendLayout()
      CType(Me.NudInverval, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.GrpGUI.SuspendLayout()
      Me.SuspendLayout()
      '
      'LblVersion
      '
      Me.LblVersion.AutoSize = True
      Me.LblVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.LblVersion.Location = New System.Drawing.Point(6, 250)
      Me.LblVersion.Name = "LblVersion"
      Me.LblVersion.Size = New System.Drawing.Size(75, 13)
      Me.LblVersion.TabIndex = 32
      Me.LblVersion.Text = "Version: 1.0"
      '
      'TxtAccount
      '
      Me.TxtAccount.Location = New System.Drawing.Point(62, 15)
      Me.TxtAccount.Name = "TxtAccount"
      Me.TxtAccount.Size = New System.Drawing.Size(263, 20)
      Me.TxtAccount.TabIndex = 24
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.Location = New System.Drawing.Point(4, 18)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(50, 13)
      Me.Label4.TabIndex = 23
      Me.Label4.Text = "Account:"
      '
      'TxtPassword
      '
      Me.TxtPassword.Location = New System.Drawing.Point(62, 37)
      Me.TxtPassword.Name = "TxtPassword"
      Me.TxtPassword.Size = New System.Drawing.Size(263, 20)
      Me.TxtPassword.TabIndex = 22
      Me.TxtPassword.UseSystemPasswordChar = True
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Location = New System.Drawing.Point(4, 40)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(56, 13)
      Me.Label1.TabIndex = 21
      Me.Label1.Text = "Password:"
      '
      'GrpNAS
      '
      Me.GrpNAS.Controls.Add(Me.TxtAccount)
      Me.GrpNAS.Controls.Add(Me.Label4)
      Me.GrpNAS.Controls.Add(Me.TxtPassword)
      Me.GrpNAS.Controls.Add(Me.Label1)
      Me.GrpNAS.Controls.Add(Me.TxtNAS_UNC)
      Me.GrpNAS.Controls.Add(Me.Label3)
      Me.GrpNAS.Location = New System.Drawing.Point(3, 150)
      Me.GrpNAS.Name = "GrpNAS"
      Me.GrpNAS.Size = New System.Drawing.Size(330, 91)
      Me.GrpNAS.TabIndex = 30
      Me.GrpNAS.TabStop = False
      Me.GrpNAS.Text = "NAS"
      '
      'TxtNAS_UNC
      '
      Me.TxtNAS_UNC.Location = New System.Drawing.Point(62, 60)
      Me.TxtNAS_UNC.Name = "TxtNAS_UNC"
      Me.TxtNAS_UNC.Size = New System.Drawing.Size(263, 20)
      Me.TxtNAS_UNC.TabIndex = 20
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Location = New System.Drawing.Point(4, 63)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(33, 13)
      Me.Label3.TabIndex = 19
      Me.Label3.Text = "UNC:"
      '
      'GrpMusic
      '
      Me.GrpMusic.Controls.Add(Me.NudBass)
      Me.GrpMusic.Controls.Add(Me.Label2)
      Me.GrpMusic.Controls.Add(Me.GroupBox1)
      Me.GrpMusic.Location = New System.Drawing.Point(3, 59)
      Me.GrpMusic.Name = "GrpMusic"
      Me.GrpMusic.Size = New System.Drawing.Size(330, 88)
      Me.GrpMusic.TabIndex = 31
      Me.GrpMusic.TabStop = False
      Me.GrpMusic.Text = "Music"
      '
      'NudBass
      '
      Me.NudBass.Location = New System.Drawing.Point(271, 22)
      Me.NudBass.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
      Me.NudBass.Minimum = New Decimal(New Integer() {10, 0, 0, -2147483648})
      Me.NudBass.Name = "NudBass"
      Me.NudBass.Size = New System.Drawing.Size(43, 20)
      Me.NudBass.TabIndex = 16
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Location = New System.Drawing.Point(206, 23)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(30, 13)
      Me.Label2.TabIndex = 17
      Me.Label2.Text = "Bass"
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.ChkShuffle)
      Me.GroupBox1.Controls.Add(Me.ChkRepeat)
      Me.GroupBox1.Location = New System.Drawing.Point(6, 14)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(129, 67)
      Me.GroupBox1.TabIndex = 29
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Track"
      '
      'ChkShuffle
      '
      Me.ChkShuffle.AutoSize = True
      Me.ChkShuffle.Location = New System.Drawing.Point(6, 42)
      Me.ChkShuffle.Name = "ChkShuffle"
      Me.ChkShuffle.Size = New System.Drawing.Size(59, 17)
      Me.ChkShuffle.TabIndex = 14
      Me.ChkShuffle.Text = "Shuffle"
      Me.ChkShuffle.UseVisualStyleBackColor = True
      '
      'ChkRepeat
      '
      Me.ChkRepeat.AutoSize = True
      Me.ChkRepeat.Location = New System.Drawing.Point(6, 19)
      Me.ChkRepeat.Name = "ChkRepeat"
      Me.ChkRepeat.Size = New System.Drawing.Size(61, 17)
      Me.ChkRepeat.TabIndex = 15
      Me.ChkRepeat.Text = "Repeat"
      Me.ChkRepeat.UseVisualStyleBackColor = True
      '
      'NudInverval
      '
      Me.NudInverval.Location = New System.Drawing.Point(56, 20)
      Me.NudInverval.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
      Me.NudInverval.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
      Me.NudInverval.Name = "NudInverval"
      Me.NudInverval.Size = New System.Drawing.Size(43, 20)
      Me.NudInverval.TabIndex = 28
      Me.NudInverval.Value = New Decimal(New Integer() {5, 0, 0, 0})
      '
      'LblIntervalSeconds
      '
      Me.LblIntervalSeconds.AutoSize = True
      Me.LblIntervalSeconds.Location = New System.Drawing.Point(105, 24)
      Me.LblIntervalSeconds.Name = "LblIntervalSeconds"
      Me.LblIntervalSeconds.Size = New System.Drawing.Size(49, 13)
      Me.LblIntervalSeconds.TabIndex = 27
      Me.LblIntervalSeconds.Text = "Seconds"
      '
      'ChkTopMost
      '
      Me.ChkTopMost.AutoSize = True
      Me.ChkTopMost.Location = New System.Drawing.Point(211, 21)
      Me.ChkTopMost.Name = "ChkTopMost"
      Me.ChkTopMost.Size = New System.Drawing.Size(70, 17)
      Me.ChkTopMost.TabIndex = 25
      Me.ChkTopMost.Text = "Top most"
      Me.ChkTopMost.UseVisualStyleBackColor = True
      '
      'btnOK
      '
      Me.btnOK.Location = New System.Drawing.Point(286, 247)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(43, 23)
      Me.btnOK.TabIndex = 24
      Me.btnOK.Text = "OK"
      Me.btnOK.UseVisualStyleBackColor = True
      '
      'LblInterval
      '
      Me.LblInterval.AutoSize = True
      Me.LblInterval.Location = New System.Drawing.Point(5, 23)
      Me.LblInterval.Name = "LblInterval"
      Me.LblInterval.Size = New System.Drawing.Size(45, 13)
      Me.LblInterval.TabIndex = 26
      Me.LblInterval.Text = "Update:"
      '
      'GrpGUI
      '
      Me.GrpGUI.Controls.Add(Me.LblIntervalSeconds)
      Me.GrpGUI.Controls.Add(Me.LblInterval)
      Me.GrpGUI.Controls.Add(Me.NudInverval)
      Me.GrpGUI.Controls.Add(Me.ChkTopMost)
      Me.GrpGUI.Location = New System.Drawing.Point(2, 0)
      Me.GrpGUI.Name = "GrpGUI"
      Me.GrpGUI.Size = New System.Drawing.Size(331, 58)
      Me.GrpGUI.TabIndex = 33
      Me.GrpGUI.TabStop = False
      Me.GrpGUI.Text = "GUI"
      '
      'FrmSettings
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(337, 276)
      Me.Controls.Add(Me.GrpGUI)
      Me.Controls.Add(Me.LblVersion)
      Me.Controls.Add(Me.GrpNAS)
      Me.Controls.Add(Me.GrpMusic)
      Me.Controls.Add(Me.btnOK)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Name = "FrmSettings"
      Me.Text = "Settings"
      Me.GrpNAS.ResumeLayout(False)
      Me.GrpNAS.PerformLayout()
      Me.GrpMusic.ResumeLayout(False)
      Me.GrpMusic.PerformLayout()
      CType(Me.NudBass, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      CType(Me.NudInverval, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GrpGUI.ResumeLayout(False)
      Me.GrpGUI.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents LblVersion As Windows.Forms.Label
   Friend WithEvents TxtAccount As Windows.Forms.TextBox
   Friend WithEvents Label4 As Windows.Forms.Label
   Friend WithEvents TxtPassword As Windows.Forms.TextBox
   Friend WithEvents Label1 As Windows.Forms.Label
   Friend WithEvents GrpNAS As Windows.Forms.GroupBox
   Friend WithEvents TxtNAS_UNC As Windows.Forms.TextBox
   Friend WithEvents Label3 As Windows.Forms.Label
   Friend WithEvents GrpMusic As Windows.Forms.GroupBox
   Friend WithEvents NudBass As Windows.Forms.NumericUpDown
   Friend WithEvents Label2 As Windows.Forms.Label
   Friend WithEvents GroupBox1 As Windows.Forms.GroupBox
   Friend WithEvents ChkShuffle As Windows.Forms.CheckBox
   Friend WithEvents ChkRepeat As Windows.Forms.CheckBox
   Friend WithEvents NudInverval As Windows.Forms.NumericUpDown
   Friend WithEvents LblIntervalSeconds As Windows.Forms.Label
   Friend WithEvents ChkTopMost As Windows.Forms.CheckBox
   Friend WithEvents btnOK As Windows.Forms.Button
   Friend WithEvents LblInterval As Windows.Forms.Label
   Friend WithEvents GrpGUI As Windows.Forms.GroupBox
End Class
