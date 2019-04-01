<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMain
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
      Me.CmbRooms = New System.Windows.Forms.ComboBox()
      Me.SuspendLayout()
      '
      'CmbRooms
      '
      Me.CmbRooms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.CmbRooms.FormattingEnabled = True
      Me.CmbRooms.Location = New System.Drawing.Point(1, 1)
      Me.CmbRooms.Name = "CmbRooms"
      Me.CmbRooms.Size = New System.Drawing.Size(220, 21)
      Me.CmbRooms.TabIndex = 8
      '
      'FrmMain
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(224, 24)
      Me.Controls.Add(Me.CmbRooms)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Name = "FrmMain"
      Me.Text = "Search for Sonos..."
      Me.TopMost = True
      Me.ResumeLayout(False)

   End Sub

   Friend WithEvents CmbRooms As ComboBox
End Class
