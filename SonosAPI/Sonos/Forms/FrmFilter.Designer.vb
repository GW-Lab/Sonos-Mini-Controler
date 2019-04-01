<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFilter
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
      Me.ChkALLGenres = New System.Windows.Forms.CheckBox()
      Me.ChkPop = New System.Windows.Forms.CheckBox()
      Me.ChkInstrumental = New System.Windows.Forms.CheckBox()
      Me.ChkClassical = New System.Windows.Forms.CheckBox()
      Me.btnOK = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'ChkALLGenres
      '
      Me.ChkALLGenres.AutoSize = True
      Me.ChkALLGenres.Checked = True
      Me.ChkALLGenres.CheckState = System.Windows.Forms.CheckState.Checked
      Me.ChkALLGenres.Location = New System.Drawing.Point(2, 2)
      Me.ChkALLGenres.Name = "ChkALLGenres"
      Me.ChkALLGenres.Size = New System.Drawing.Size(45, 17)
      Me.ChkALLGenres.TabIndex = 17
      Me.ChkALLGenres.Text = "ALL"
      Me.ChkALLGenres.UseVisualStyleBackColor = True
      '
      'ChkPop
      '
      Me.ChkPop.AutoSize = True
      Me.ChkPop.Location = New System.Drawing.Point(1, 70)
      Me.ChkPop.Name = "ChkPop"
      Me.ChkPop.Size = New System.Drawing.Size(45, 17)
      Me.ChkPop.TabIndex = 16
      Me.ChkPop.Text = "Pop"
      Me.ChkPop.UseVisualStyleBackColor = True
      '
      'ChkInstrumental
      '
      Me.ChkInstrumental.AutoSize = True
      Me.ChkInstrumental.Location = New System.Drawing.Point(1, 47)
      Me.ChkInstrumental.Name = "ChkInstrumental"
      Me.ChkInstrumental.Size = New System.Drawing.Size(83, 17)
      Me.ChkInstrumental.TabIndex = 15
      Me.ChkInstrumental.Text = "Instrumental"
      Me.ChkInstrumental.UseVisualStyleBackColor = True
      '
      'ChkClassical
      '
      Me.ChkClassical.AutoSize = True
      Me.ChkClassical.Location = New System.Drawing.Point(1, 24)
      Me.ChkClassical.Name = "ChkClassical"
      Me.ChkClassical.Size = New System.Drawing.Size(62, 17)
      Me.ChkClassical.TabIndex = 14
      Me.ChkClassical.Text = "Clasical"
      Me.ChkClassical.UseVisualStyleBackColor = True
      '
      'btnOK
      '
      Me.btnOK.Location = New System.Drawing.Point(-4, 94)
      Me.btnOK.Name = "btnOK"
      Me.btnOK.Size = New System.Drawing.Size(85, 23)
      Me.btnOK.TabIndex = 13
      Me.btnOK.Text = "Update queue"
      Me.btnOK.UseVisualStyleBackColor = True
      '
      'FrmFilter
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(83, 117)
      Me.Controls.Add(Me.ChkALLGenres)
      Me.Controls.Add(Me.ChkPop)
      Me.Controls.Add(Me.ChkInstrumental)
      Me.Controls.Add(Me.ChkClassical)
      Me.Controls.Add(Me.btnOK)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Name = "FrmFilter"
      Me.Text = "Filter"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents ChkALLGenres As Windows.Forms.CheckBox
   Friend WithEvents ChkPop As Windows.Forms.CheckBox
   Friend WithEvents ChkInstrumental As Windows.Forms.CheckBox
   Friend WithEvents ChkClassical As Windows.Forms.CheckBox
   Friend WithEvents btnOK As Windows.Forms.Button
End Class
