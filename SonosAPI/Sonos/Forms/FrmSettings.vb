' Program..: FrmSonosTest.vb
' Author...: G. Wassink
' Design...: 
' Date.....: 11/03/2019 Last revised:11/03/2019
' Notice...: Copyright 1994-2016 All Rights Reserved
' Notes....: VB16.0.2 .NET Framework 4.8
' Files....: None
' Programs.:
' Reserved.: 

Imports System.Net

Public Class FrmSettings
   ReadOnly frm As FrmSonos
   ReadOnly sonos As Sonos
   ReadOnly ip As IPAddress

   Public Sub New(sonos As Sonos, IP As IPAddress, frm As FrmSonos)
      InitializeComponent() ' This call is required by the designer.
      ' Add any initialization after the InitializeComponent() call.
      Me.frm = frm
      Me.sonos = sonos
      Me.ip = IP
   End Sub

   Private Sub FrmSettings_Load(sender As Object, e As EventArgs) Handles Me.Load
      TxtAccount.Text = Me.sonos.Configuration.Account
      TxtPassword.Text = Me.sonos.Configuration.Password
      TxtNAS_UNC.Text = Me.sonos.Configuration.NAS_UNC
      NudInverval.Value = Me.sonos.Configuration.Interval
      ChkTopMost.Checked = Me.sonos.Configuration.TopMost
      NudBass.Value = Me.sonos.Sound.Bass(Me.ip)

      Select Case Me.sonos.Sound.PlayMode(Me.ip)
         Case PlayMode.NORMAL : ChkRepeat.Checked = False : ChkShuffle.Checked = False
         Case PlayMode.REPEAT_ALL : ChkRepeat.Checked = True : ChkShuffle.Checked = False
         Case PlayMode.SHUFFLE : ChkRepeat.Checked = True : ChkShuffle.Checked = True
         Case PlayMode.SHUFFLE_NOREPEAT : ChkRepeat.Checked = False : ChkShuffle.Checked = True
      End Select

      Location = Me.frm.Location
   End Sub

   Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
      Me.sonos.Configuration.Account = TxtAccount.Text
      Me.sonos.configuration.Password = TxtPassword.Text
      Me.sonos.Configuration.NAS_UNC = TxtNAS_UNC.Text
      Me.sonos.Configuration.Interval = NudInverval.Value
      Me.sonos.Configuration.TopMost = ChkTopMost.Checked

      Me.frm.TopMost = ChkTopMost.Checked
      Close()
   End Sub

   Private Sub NudBass_ValueChanged(sender As Object, e As EventArgs) Handles NudBass.ValueChanged
      Me.sonos.Sound.Bass(Me.ip) = CInt(NudBass.Value)
   End Sub

   Private Sub ChkRepeatShuffle_CheckedChanged(sender As Object, e As EventArgs) Handles ChkShuffle.CheckedChanged, ChkRepeat.CheckedChanged
      Me.sonos.Sound.PlayMode(Me.ip) = If(ChkRepeat.Checked, If(ChkShuffle.Checked, PlayMode.SHUFFLE, PlayMode.REPEAT_ALL), If(ChkShuffle.Checked, PlayMode.SHUFFLE_NOREPEAT, PlayMode.NORMAL))
   End Sub
End Class