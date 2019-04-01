Imports GWSonos

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmSonos
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
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSonos))
      Me.CmbFavorites = New System.Windows.Forms.ComboBox()
      Me.GrpSource = New System.Windows.Forms.GroupBox()
      Me.GrpQueue = New System.Windows.Forms.GroupBox()
      Me.LblNasTracksCount = New System.Windows.Forms.Label()
      Me.BtnFilter = New System.Windows.Forms.Button()
      Me.RbtTrackNasFavorits = New System.Windows.Forms.RadioButton()
      Me.RbtRadioFavorits = New System.Windows.Forms.RadioButton()
      Me.RbtTrackFavorits = New System.Windows.Forms.RadioButton()
      Me.RbtConnect = New System.Windows.Forms.RadioButton()
      Me.RbtLineIn = New System.Windows.Forms.RadioButton()
      Me.RbtTV = New System.Windows.Forms.RadioButton()
      Me.RbtQueue = New System.Windows.Forms.RadioButton()
      Me.TmrMain = New System.Windows.Forms.Timer(Me.components)
      Me.MnuScan = New System.Windows.Forms.ToolStripMenuItem()
      Me.CmsMain = New System.Windows.Forms.ContextMenuStrip(Me.components)
      Me.MnuSettings = New System.Windows.Forms.ToolStripMenuItem()
      Me.MnuExit = New System.Windows.Forms.ToolStripMenuItem()
      Me.TrkSonosVolume = New System.Windows.Forms.TrackBar()
      Me.BtnTrackRewind = New System.Windows.Forms.Button()
      Me.PicSpeaker = New System.Windows.Forms.PictureBox()
      Me.BtnNextSong = New System.Windows.Forms.Button()
      Me.BtnPreviousSong = New System.Windows.Forms.Button()
      Me.TxtSelectedRoom = New System.Windows.Forms.TextBox()
      Me.LblIp = New System.Windows.Forms.Label()
      Me.GrpSource.SuspendLayout()
      Me.GrpQueue.SuspendLayout()
      Me.CmsMain.SuspendLayout()
      CType(Me.TrkSonosVolume, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PicSpeaker, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'CmbFavorites
      '
      Me.CmbFavorites.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.CmbFavorites.FormattingEnabled = True
      Me.CmbFavorites.Location = New System.Drawing.Point(2, 169)
      Me.CmbFavorites.Name = "CmbFavorites"
      Me.CmbFavorites.Size = New System.Drawing.Size(220, 21)
      Me.CmbFavorites.TabIndex = 23
      '
      'GrpSource
      '
      Me.GrpSource.Controls.Add(Me.GrpQueue)
      Me.GrpSource.Controls.Add(Me.RbtConnect)
      Me.GrpSource.Controls.Add(Me.RbtLineIn)
      Me.GrpSource.Controls.Add(Me.RbtTV)
      Me.GrpSource.Controls.Add(Me.RbtQueue)
      Me.GrpSource.Enabled = False
      Me.GrpSource.Location = New System.Drawing.Point(2, 64)
      Me.GrpSource.Name = "GrpSource"
      Me.GrpSource.Size = New System.Drawing.Size(220, 103)
      Me.GrpSource.TabIndex = 22
      Me.GrpSource.TabStop = False
      Me.GrpSource.Text = "Source"
      '
      'GrpQueue
      '
      Me.GrpQueue.Controls.Add(Me.LblNasTracksCount)
      Me.GrpQueue.Controls.Add(Me.BtnFilter)
      Me.GrpQueue.Controls.Add(Me.RbtTrackNasFavorits)
      Me.GrpQueue.Controls.Add(Me.RbtRadioFavorits)
      Me.GrpQueue.Controls.Add(Me.RbtTrackFavorits)
      Me.GrpQueue.Enabled = False
      Me.GrpQueue.Location = New System.Drawing.Point(67, 10)
      Me.GrpQueue.Name = "GrpQueue"
      Me.GrpQueue.Size = New System.Drawing.Size(150, 85)
      Me.GrpQueue.TabIndex = 13
      Me.GrpQueue.TabStop = False
      Me.GrpQueue.Text = "Queue"
      '
      'LblNasTracksCount
      '
      Me.LblNasTracksCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.LblNasTracksCount.Location = New System.Drawing.Point(55, 58)
      Me.LblNasTracksCount.Name = "LblNasTracksCount"
      Me.LblNasTracksCount.Size = New System.Drawing.Size(48, 18)
      Me.LblNasTracksCount.TabIndex = 15
      Me.LblNasTracksCount.Text = "0"
      Me.LblNasTracksCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'BtnFilter
      '
      Me.BtnFilter.Enabled = False
      Me.BtnFilter.Location = New System.Drawing.Point(106, 57)
      Me.BtnFilter.Name = "BtnFilter"
      Me.BtnFilter.Size = New System.Drawing.Size(37, 20)
      Me.BtnFilter.TabIndex = 14
      Me.BtnFilter.Text = "Filter"
      Me.BtnFilter.UseVisualStyleBackColor = True
      '
      'RbtTrackNasFavorits
      '
      Me.RbtTrackNasFavorits.AutoSize = True
      Me.RbtTrackNasFavorits.Location = New System.Drawing.Point(5, 58)
      Me.RbtTrackNasFavorits.Name = "RbtTrackNasFavorits"
      Me.RbtTrackNasFavorits.Size = New System.Drawing.Size(58, 17)
      Me.RbtTrackNasFavorits.TabIndex = 13
      Me.RbtTrackNasFavorits.Text = "Tracks"
      Me.RbtTrackNasFavorits.UseVisualStyleBackColor = True
      '
      'RbtRadioFavorits
      '
      Me.RbtRadioFavorits.AutoSize = True
      Me.RbtRadioFavorits.Checked = True
      Me.RbtRadioFavorits.Location = New System.Drawing.Point(5, 16)
      Me.RbtRadioFavorits.Name = "RbtRadioFavorits"
      Me.RbtRadioFavorits.Size = New System.Drawing.Size(90, 17)
      Me.RbtRadioFavorits.TabIndex = 12
      Me.RbtRadioFavorits.TabStop = True
      Me.RbtRadioFavorits.Text = "Radio favorits"
      Me.RbtRadioFavorits.UseVisualStyleBackColor = True
      '
      'RbtTrackFavorits
      '
      Me.RbtTrackFavorits.AutoSize = True
      Me.RbtTrackFavorits.Location = New System.Drawing.Point(5, 37)
      Me.RbtTrackFavorits.Name = "RbtTrackFavorits"
      Me.RbtTrackFavorits.Size = New System.Drawing.Size(90, 17)
      Me.RbtTrackFavorits.TabIndex = 11
      Me.RbtTrackFavorits.Text = "Track favorits"
      Me.RbtTrackFavorits.UseVisualStyleBackColor = True
      '
      'RbtConnect
      '
      Me.RbtConnect.AutoSize = True
      Me.RbtConnect.Location = New System.Drawing.Point(5, 18)
      Me.RbtConnect.Name = "RbtConnect"
      Me.RbtConnect.Size = New System.Drawing.Size(65, 17)
      Me.RbtConnect.TabIndex = 11
      Me.RbtConnect.Text = "Connect"
      Me.RbtConnect.UseVisualStyleBackColor = True
      '
      'RbtLineIn
      '
      Me.RbtLineIn.AutoSize = True
      Me.RbtLineIn.Location = New System.Drawing.Point(5, 39)
      Me.RbtLineIn.Name = "RbtLineIn"
      Me.RbtLineIn.Size = New System.Drawing.Size(54, 17)
      Me.RbtLineIn.TabIndex = 9
      Me.RbtLineIn.Text = "LineIn"
      Me.RbtLineIn.UseVisualStyleBackColor = True
      '
      'RbtTV
      '
      Me.RbtTV.AutoSize = True
      Me.RbtTV.Location = New System.Drawing.Point(5, 60)
      Me.RbtTV.Name = "RbtTV"
      Me.RbtTV.Size = New System.Drawing.Size(39, 17)
      Me.RbtTV.TabIndex = 12
      Me.RbtTV.Text = "TV"
      Me.RbtTV.UseVisualStyleBackColor = True
      '
      'RbtQueue
      '
      Me.RbtQueue.AutoSize = True
      Me.RbtQueue.Location = New System.Drawing.Point(5, 81)
      Me.RbtQueue.Name = "RbtQueue"
      Me.RbtQueue.Size = New System.Drawing.Size(57, 17)
      Me.RbtQueue.TabIndex = 10
      Me.RbtQueue.Text = "Queue"
      Me.RbtQueue.UseVisualStyleBackColor = True
      '
      'TmrMain
      '
      Me.TmrMain.Enabled = True
      Me.TmrMain.Interval = 10000
      '
      'MnuScan
      '
      Me.MnuScan.Name = "MnuScan"
      Me.MnuScan.Size = New System.Drawing.Size(116, 22)
      Me.MnuScan.Text = "Scan"
      '
      'CmsMain
      '
      Me.CmsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuScan, Me.MnuSettings, Me.MnuExit})
      Me.CmsMain.Name = "CmsMain"
      Me.CmsMain.Size = New System.Drawing.Size(117, 70)
      '
      'MnuSettings
      '
      Me.MnuSettings.Image = CType(resources.GetObject("MnuSettings.Image"), System.Drawing.Image)
      Me.MnuSettings.Name = "MnuSettings"
      Me.MnuSettings.Size = New System.Drawing.Size(116, 22)
      Me.MnuSettings.Text = "Settings"
      '
      'MnuExit
      '
      Me.MnuExit.Image = CType(resources.GetObject("MnuExit.Image"), System.Drawing.Image)
      Me.MnuExit.Name = "MnuExit"
      Me.MnuExit.Size = New System.Drawing.Size(116, 22)
      Me.MnuExit.Text = "Exit"
      '
      'TrkSonosVolume
      '
      Me.TrkSonosVolume.Location = New System.Drawing.Point(31, 28)
      Me.TrkSonosVolume.Maximum = 100
      Me.TrkSonosVolume.Name = "TrkSonosVolume"
      Me.TrkSonosVolume.Size = New System.Drawing.Size(107, 45)
      Me.TrkSonosVolume.TabIndex = 16
      '
      'BtnTrackRewind
      '
      Me.BtnTrackRewind.Enabled = False
      Me.BtnTrackRewind.Image = CType(resources.GetObject("BtnTrackRewind.Image"), System.Drawing.Image)
      Me.BtnTrackRewind.Location = New System.Drawing.Point(164, 30)
      Me.BtnTrackRewind.Name = "BtnTrackRewind"
      Me.BtnTrackRewind.Size = New System.Drawing.Size(29, 30)
      Me.BtnTrackRewind.TabIndex = 21
      Me.BtnTrackRewind.UseVisualStyleBackColor = True
      '
      'PicSpeaker
      '
      Me.PicSpeaker.Image = Global.GWSonos.My.Resources.Resources.speaker_off
      Me.PicSpeaker.Location = New System.Drawing.Point(5, 32)
      Me.PicSpeaker.Name = "PicSpeaker"
      Me.PicSpeaker.Size = New System.Drawing.Size(27, 21)
      Me.PicSpeaker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.PicSpeaker.TabIndex = 19
      Me.PicSpeaker.TabStop = False
      '
      'BtnNextSong
      '
      Me.BtnNextSong.Enabled = False
      Me.BtnNextSong.Image = CType(resources.GetObject("BtnNextSong.Image"), System.Drawing.Image)
      Me.BtnNextSong.Location = New System.Drawing.Point(192, 30)
      Me.BtnNextSong.Name = "BtnNextSong"
      Me.BtnNextSong.Size = New System.Drawing.Size(29, 30)
      Me.BtnNextSong.TabIndex = 18
      Me.BtnNextSong.UseVisualStyleBackColor = True
      '
      'BtnPreviousSong
      '
      Me.BtnPreviousSong.Enabled = False
      Me.BtnPreviousSong.Image = CType(resources.GetObject("BtnPreviousSong.Image"), System.Drawing.Image)
      Me.BtnPreviousSong.Location = New System.Drawing.Point(136, 30)
      Me.BtnPreviousSong.Name = "BtnPreviousSong"
      Me.BtnPreviousSong.Size = New System.Drawing.Size(29, 30)
      Me.BtnPreviousSong.TabIndex = 17
      Me.BtnPreviousSong.UseVisualStyleBackColor = True
      '
      'TxtSelectedRoom
      '
      Me.TxtSelectedRoom.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.TxtSelectedRoom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.TxtSelectedRoom.Location = New System.Drawing.Point(2, 2)
      Me.TxtSelectedRoom.Name = "TxtSelectedRoom"
      Me.TxtSelectedRoom.ReadOnly = True
      Me.TxtSelectedRoom.Size = New System.Drawing.Size(255, 13)
      Me.TxtSelectedRoom.TabIndex = 24
      Me.TxtSelectedRoom.Text = "Room Name"
      '
      'LblIp
      '
      Me.LblIp.AutoSize = True
      Me.LblIp.Location = New System.Drawing.Point(7, 196)
      Me.LblIp.Name = "LblIp"
      Me.LblIp.Size = New System.Drawing.Size(39, 13)
      Me.LblIp.TabIndex = 25
      Me.LblIp.Text = "Label1"
      '
      'FrmSonos
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.ClientSize = New System.Drawing.Size(223, 215)
      Me.Controls.Add(Me.LblIp)
      Me.Controls.Add(Me.TxtSelectedRoom)
      Me.Controls.Add(Me.CmbFavorites)
      Me.Controls.Add(Me.GrpSource)
      Me.Controls.Add(Me.BtnTrackRewind)
      Me.Controls.Add(Me.PicSpeaker)
      Me.Controls.Add(Me.BtnNextSong)
      Me.Controls.Add(Me.TrkSonosVolume)
      Me.Controls.Add(Me.BtnPreviousSong)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
      Me.Name = "FrmSonos"
      Me.Text = "Initialize.... "
      Me.TopMost = True
      Me.GrpSource.ResumeLayout(False)
      Me.GrpSource.PerformLayout()
      Me.GrpQueue.ResumeLayout(False)
      Me.GrpQueue.PerformLayout()
      Me.CmsMain.ResumeLayout(False)
      CType(Me.TrkSonosVolume, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PicSpeaker, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents CmbFavorites As Windows.Forms.ComboBox
   Friend WithEvents GrpSource As Windows.Forms.GroupBox
   Friend WithEvents GrpQueue As Windows.Forms.GroupBox
   Friend WithEvents LblNasTracksCount As Windows.Forms.Label
   Friend WithEvents BtnFilter As Windows.Forms.Button
   Friend WithEvents RbtTrackNasFavorits As Windows.Forms.RadioButton
   Friend WithEvents RbtRadioFavorits As Windows.Forms.RadioButton
   Friend WithEvents RbtTrackFavorits As Windows.Forms.RadioButton
   Friend WithEvents RbtConnect As Windows.Forms.RadioButton
   Friend WithEvents RbtLineIn As Windows.Forms.RadioButton
   Friend WithEvents RbtTV As Windows.Forms.RadioButton
   Friend WithEvents RbtQueue As Windows.Forms.RadioButton
   Friend WithEvents BtnTrackRewind As Windows.Forms.Button
   Friend WithEvents PicSpeaker As Windows.Forms.PictureBox
   Friend WithEvents BtnNextSong As Windows.Forms.Button
   Friend WithEvents TmrMain As Windows.Forms.Timer
   Friend WithEvents MnuExit As Windows.Forms.ToolStripMenuItem
   Friend WithEvents MnuSettings As Windows.Forms.ToolStripMenuItem
   Friend WithEvents MnuScan As Windows.Forms.ToolStripMenuItem
   Friend WithEvents CmsMain As Windows.Forms.ContextMenuStrip
   Friend WithEvents TrkSonosVolume As Windows.Forms.TrackBar
   Friend WithEvents BtnPreviousSong As Windows.Forms.Button
   Public WithEvents TxtSelectedRoom As Windows.Forms.TextBox
   Friend WithEvents LblIp As Windows.Forms.Label
End Class
