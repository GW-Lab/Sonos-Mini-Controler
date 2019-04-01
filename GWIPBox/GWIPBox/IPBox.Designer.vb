<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class IPBox
   Inherits System.Windows.Forms.UserControl

   'UserControl overrides dispose to clean up the component list.
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
      Me.TxtIP1 = New System.Windows.Forms.TextBox()
      Me.TxtIP2 = New System.Windows.Forms.TextBox()
      Me.TxtIP3 = New System.Windows.Forms.TextBox()
      Me.TxtIP4 = New System.Windows.Forms.TextBox()
      Me.SuspendLayout()
      '
      'TxtIP1
      '
      Me.TxtIP1.Location = New System.Drawing.Point(3, 4)
      Me.TxtIP1.Name = "TxtIP1"
      Me.TxtIP1.Size = New System.Drawing.Size(25, 20)
      Me.TxtIP1.TabIndex = 0
      Me.TxtIP1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'TxtIP2
      '
      Me.TxtIP2.Location = New System.Drawing.Point(31, 4)
      Me.TxtIP2.Name = "TxtIP2"
      Me.TxtIP2.Size = New System.Drawing.Size(25, 20)
      Me.TxtIP2.TabIndex = 1
      Me.TxtIP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'TxtIP3
      '
      Me.TxtIP3.Location = New System.Drawing.Point(60, 4)
      Me.TxtIP3.Name = "TxtIP3"
      Me.TxtIP3.Size = New System.Drawing.Size(25, 20)
      Me.TxtIP3.TabIndex = 2
      Me.TxtIP3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'TxtIP4
      '
      Me.TxtIP4.Location = New System.Drawing.Point(89, 4)
      Me.TxtIP4.Name = "TxtIP4"
      Me.TxtIP4.Size = New System.Drawing.Size(25, 20)
      Me.TxtIP4.TabIndex = 3
      Me.TxtIP4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'IPBox
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.Controls.Add(Me.TxtIP4)
      Me.Controls.Add(Me.TxtIP3)
      Me.Controls.Add(Me.TxtIP2)
      Me.Controls.Add(Me.TxtIP1)
      Me.Name = "IPBox"
      Me.Size = New System.Drawing.Size(116, 27)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents TxtIP1 As Windows.Forms.TextBox
   Friend WithEvents TxtIP2 As Windows.Forms.TextBox
   Friend WithEvents TxtIP3 As Windows.Forms.TextBox
   Friend WithEvents TxtIP4 As Windows.Forms.TextBox
End Class
