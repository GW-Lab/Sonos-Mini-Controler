' Program..: FrmSonosTest.vb
' Author...: G. Wassink
' Design...: 
' Date.....: 11/03/2019 Last revised:11/03/2019
' Notice...: Copyright 1994-2016 All Rights Reserved
' Notes....: VB 16.0 RC4 .Net Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: 

Imports GWSonos.Device
Imports GWSonos.SpeechEngineBase
Imports System.Windows.Forms

Public Class FrmSonos
   WithEvents CallBackHandler As CallBackHandler
   WithEvents Sonos As Sonos
   WithEvents SpeechEngine As New SpeechEngine

   Private favorites As New Favorites
   Private ReadOnly frm As Form
   Private frmFilter As FrmFilter
   Private frmSettings As FrmSettings
   Private ip As Net.IPAddress
   Private playMode As PlayMode

#Region "Constructor"
   Public Sub New(selectedRoom As String, frm As Form, sonos As Sonos)
      InitializeComponent() ' This call is required by the designer.
      TxtSelectedRoom.Text = selectedRoom
      Me.Sonos = sonos ' Add any initialization after the InitializeComponent() call.
      Me.frm = frm

      ProcessCallBack(Nothing, Nothing)
   End Sub
#End Region

   Private Sub BtnNextSong_Click(sender As Object, e As EventArgs) Handles BtnNextSong.Click
      Sonos.Queue.NextTrack(Me.ip)
      Text = Sonos.Queue.TrackPositionInfo(Me.ip).TitleAndArtist
   End Sub

   Private Sub BtnPreviousSong_Click(sender As Object, e As EventArgs) Handles BtnPreviousSong.Click
      Sonos.Queue.PreviousTrack(Me.ip)
      Text = Sonos.Queue.TrackPositionInfo(Me.ip).TitleAndArtist
   End Sub

   Private Sub BtnTrackRewind_Click(sender As Object, e As EventArgs) Handles BtnTrackRewind.Click
      Sonos.Queue.Seek(Me.ip, Unit.REL_TIME) ' Rewind track
   End Sub

   Private Sub BtrFilter_Click(sender As Object, e As EventArgs) Handles BtnFilter.Click
      Me.frmFilter = New FrmFilter(Me.Sonos, Me.ip, Me)
      Me.frmFilter.Show(Me)
   End Sub

   Private Sub CallBackHandler_Data_Recieved(msg As String) Handles CallBackHandler.Data_Recieved
      BeginInvoke(Sub()
                     ProcessCallBack(Nothing, Nothing)
                  End Sub)
   End Sub

   Private Sub CmbFavorites_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbFavorites.SelectedIndexChanged
      With DirectCast(DirectCast(sender, ComboBox).SelectedItem, Favorite)
         Sonos.Queue.Clear(Me.ip)
         Sonos.Queue.AddTrack(Me.ip, .StreamURI.ToString, .Ordinal)                                           ' Favorite.Ordinal Add track/radio to then current playlist 
         Sonos.Queue.Seek(Me.ip, Unit.TRACK_NR, .Ordinal.ToString)
         Sonos.Sound.Play(Me.ip)
      End With
   End Sub

   Private Sub FrmSonosTest_Closed(sender As Object, e As EventArgs) Handles Me.Closed
      Me.Sonos.Configuration.X = Location.X
      Me.Sonos.Configuration.Y = Location.Y
   End Sub

   Private Async Sub FrmSonosTest_Load(sender As Object, e As EventArgs) Handles Me.Load
      ' Dim I = From d In Me.sonos.SSDP.rooms("Hobby room").Values Where d.isCoordinator Select d.IP
      ' TmrMain.Interval = My.Settings.Interval

      ' ****** Testing ********
      ' Dim d = Me.sonos.Subscribe(Me.IP, "<http://192.168.2.160:3400/notify>")        ' TODO werkt nog niet
      ' Me.ip = IPAddress.Parse("192.168.2.164")                                       ' Set IP address
      ' Dim a = Me.sonos.Led
      ' Dim b = Me.sonos.Pause
      ' Dim c = Me.sonos.GetZoneAttributes
      ' Dim d = Me.sonos.Play
      ' Dim e = Me.sonos.AddTrackToQueue(Me.ip, b(10).URI)                             ' Add track/radio to then current playlist 
      ' Dim f = Me.sonos.CurrentPlaylist
      ' Dim g = Me.sonos.GetFavorites("", "BrowseDirectChildren", "", 0, 1000, "")
      ' Dim h = Me.sonos.GetMediaInfo(Me.ip)
      ' Dim favoriten = Me.sonos.GetSonosFavorites(IPAddress.Parse("192.168.2.164"))   ' Get ALL Sonos favorites
      ' Dim j = Me.sonos.GetZoneAttributes                           ' bv 'Hobby Room'
      ' Dim k = Me.sonos.GetZoneInfo
      ' Dim l = Me.sonos.GetZoneGroupAttributes(Me.IP)
      ' Me.sonos.playmode = PlayMode.Shuffle_NoRepeat
      ' Dim m = Me.sonos.PlayMP3(Me.ip, "//nas-01/music/1973.mp3")                     ' Play mp3 file
      ' Dim n = Me.sonos.Radio(Me.ip, "Radio", b(10).URI)
      ' Dim o = Me.sonos.Seek(Me.ip, Unit.TRACK_NR, "1")                               ' Select first Track  
      ' Dim p = Me.sonos.Seek(Unit.REL_TIME)                                           ' Rewind current track
      ' Dim q = Me.sonos.SwitchToLineIn1(Me.ip, "x-rincon-stream:RINCON_B8E9379A01C001400")
      ' Dim r = Me.sonos.TTSpeech(Me.ip)
      ' set group vulume https://forum.logicmachine.net/printthread.php?tid=339

      ' Dim s = Me.Sonos.GetZoneAttributes(IPAddress.Parse("192.168.2.184"))
      ' Dim t = Me.Sonos.GetZoneGroupAttributes(IPAddress.Parse("192.168.2.184"))
      ' Dim z = Me.sonos.Play(Me.ip)

      Dim a = Sonos.Rooms(TxtSelectedRoom.Text).Values.Where(Function(x) x.isZonePlayer).Single.IP


      Await Sonos.Subscribe({New Uri("http://" +
                                     Sonos.Rooms(TxtSelectedRoom.Text).Values.Where(Function(x) x.isZonePlayer).Single.IP.ToString +
                                     ":1400/MediaRenderer/RenderingControl/Event")}, New Uri("http://" + Network.GetLocalIPAddress.ToString + ":3445/notify/"))
      CallBackHandler = New CallBackHandler({"http://" + Network.GetLocalIPAddress.ToString + ":3445/notify/"})

      ' CallBackHandler = New CallBackHandler({"http://192.168.2.31:3445/notify/"})

      Location = Me.frm.Location
   End Sub

   Private Sub GetRadioFavorites()
      Dim insertPointer = 0

      Me.favorites.Clear()
      CmbFavorites.Items.Clear()
      Me.favorites = Sonos.SonosFavorites(Me.ip)                                                         ' Get ALL Sonos favorites

      For Each favorite In Me.favorites
         If Not favorite.StreamURI.Contains(".mp3") Then
            CmbFavorites.Items.Insert(insertPointer, favorite)
            insertPointer = 1
         End If
      Next

      CmbFavorites.SelectedIndex = 0                                                                     ' + activate CmbFavorites.SelectedIndexChanged
   End Sub

   Private Sub GetTrackFavorites()
      Dim insertPointer = 0

      Me.favorites.Clear()
      CmbFavorites.Items.Clear()
      Dim favorites = Sonos.SonosFavorites(Me.ip)                                                        ' Get ALL Sonos favorites

      For Each favorite In favorites
         If favorite.StreamURI.Contains(".mp3") Then
            CmbFavorites.Items.Insert(insertPointer, favorite)
            insertPointer = 1
         End If
      Next

      CmbFavorites.SelectedIndex = 0                                                                     ' + activate CmbFavorites.SelectedIndexChanged
   End Sub

   Private Sub GetTracksFromNAS()
      CmbFavorites.Items.Clear()

      Dim ordinal = 0
      For Each track In Sonos.NASTracks
         CmbFavorites.Items.Add(New Favorite With {.Title = track.Substring(15), .StreamURI = "x-file-cifs:" + track.Replace("\", "/"), .RemoteURI = track, .Ordinal = ordinal})
         ordinal += 1
      Next

      CmbFavorites.SelectedIndex = 0                                                                     ' + activate CmbFavorites.SelectedIndexChanged
   End Sub

   Private Sub MnuExit_Click(sender As Object, e As EventArgs) Handles MnuExit.Click
      Close()
   End Sub

   Private Sub MnuScan_Click(sender As Object, e As EventArgs) Handles MnuScan.Click
      Sonos.ScanNetworkForSonos()
   End Sub

   Private Sub MnuSettings_Click(sender As Object, e As EventArgs) Handles MnuSettings.Click
      Me.frmSettings = New FrmSettings(Sonos, Me.ip, Me)
      Me.frmSettings.Show(Me)
   End Sub

   Private Sub PicSpeaker_Click(sender As Object, e As EventArgs) Handles PicSpeaker.Click
      Sonos.Sound.GroupMute(Me.ip) = Not Sonos.Sound.GroupMute(Me.ip)
   End Sub

   Private Sub RbtRadioFavorits_CheckedChanged(sender As Object, e As EventArgs) Handles RbtRadioFavorits.CheckedChanged,
                                                                                         RbtTrackFavorits.CheckedChanged,
                                                                                         RbtTrackNasFavorits.CheckedChanged
      If DirectCast(sender, RadioButton).Checked Then
         Select Case DirectCast(sender, RadioButton).Name
            Case NameOf(RbtRadioFavorits)
               BtnNextSong.Enabled = False
               BtnPreviousSong.Enabled = False
               BtnTrackRewind.Enabled = False
               BtnFilter.Enabled = False

               GetRadioFavorites()
            Case NameOf(RbtTrackFavorits)
               BtnNextSong.Enabled = False
               BtnPreviousSong.Enabled = False
               BtnTrackRewind.Enabled = False
               BtnFilter.Enabled = False

               GetTrackFavorites()
            Case NameOf(RbtTrackNasFavorits)
               GetTracksFromNAS()

               If CmbFavorites.Items.Count > 0 Then
                  BtnNextSong.Enabled = True
                  BtnPreviousSong.Enabled = True
                  BtnTrackRewind.Enabled = True
                  BtnFilter.Enabled = True

                  CmbFavorites_SelectedIndexChanged(CmbFavorites, Nothing)
               End If
         End Select
      End If
   End Sub

   Private Sub RbtSelect_Source_Click(sender As Object, e As EventArgs) Handles RbtConnect.CheckedChanged,
                                                                                RbtLineIn.CheckedChanged,
                                                                                RbtQueue.CheckedChanged,
                                                                                RbtTV.CheckedChanged
      Try
         If DirectCast(sender, RadioButton).Checked Then
            Select Case DirectCast(sender, RadioButton).Name
               Case NameOf(RbtConnect)
                  GrpQueue.Enabled = False
                  CmbFavorites.Enabled = False
                  Sonos.SwitchTo.LineIn(Me.ip, Sonos.Rooms.devices.Where(Function(x) x.Value.Type = Device_Type.Connect).Single.Value)
               Case NameOf(RbtTV)
                  GrpQueue.Enabled = False
                  CmbFavorites.Enabled = False
                  Sonos.SwitchTo.TVIn(Me.ip, Sonos.Rooms.devices.Where(Function(x) x.Value.Type = Device_Type.Beam OrElse x.Value.Type = Device_Type.PlayBar OrElse x.Value.Type = Device_Type.SoundBar).Single.Value)
               Case NameOf(RbtLineIn)
                  GrpQueue.Enabled = False
                  CmbFavorites.Enabled = False
                  Sonos.SwitchTo.LineIn(Sonos.Rooms.devices(Me.ip.ToString))
               Case NameOf(RbtQueue)
                  GrpQueue.Enabled = True
                  CmbFavorites.Enabled = True

                  RbtTrackFavorits.Enabled = If(Sonos.NASTracks.Count > 0, True, False)
                  RbtTrackNasFavorits.Enabled = If(Sonos.NASTracks.Count > 0, True, False)
                  Sonos.SwitchTo.QueueIn(Me.ip, Sonos.Rooms.devices(Me.ip.ToString))

                  If RbtRadioFavorits.Checked Then
                     GetRadioFavorites()
                  ElseIf RbtTrackFavorits.Checked Then
                     GetTrackFavorites()
                  ElseIf RbtTrackNasFavorits.Checked Then
                     GetTracksFromNAS()
                  End If
            End Select

            Sonos.Sound.Play(Me.ip)
         End If
      Catch ex As Exception
      End Try
   End Sub

   Private Sub SetSonosFunctionsRadioButtons()
      Dim TV = Sonos.Rooms(TxtSelectedRoom.Text).Values.Any(Function(x) x.Type = Device_Type.Beam OrElse x.Type = Device_Type.PlayBar OrElse x.Type = Device_Type.SoundBar)

      RbtConnect.Enabled = Sonos.Rooms.devices.Values.Any(Function(x) x.Type = Device_Type.Connect)
      RbtLineIn.Enabled = Sonos.Rooms(TxtSelectedRoom.Text).Values.Any(Function(x) x.Type = Device_Type.Play5)
      RbtTV.Enabled = TV

      If TV Then
         RbtTV.Checked = True
      Else
         RbtQueue.Checked = True
      End If
   End Sub

   Private Sub Sonos_Device_Search(msg As String) Handles Sonos.Device_Search
      Text = msg
   End Sub

   Private Sub SpeechEngine_Command_Changed(cmd As Command) Handles SpeechEngine.Command_Changed
      Select Case cmd
         Case Command.Next_Track
            Sonos.Queue.NextTrack(Me.ip)
         Case Command.Pause
            Sonos.Sound.Pause(Me.ip)
         Case Command.Previous_Track
            Sonos.Queue.PreviousTrack(Me.ip)
         Case Command.Mute_Off
            Sonos.Sound.GroupMute(Me.ip) = False
         Case Command.Mute_On
            Sonos.Sound.GroupMute(Me.ip) = True
         Case Command.Rewind_Track
            Sonos.Queue.Seek(Me.ip, Unit.REL_TIME)
         Case Command.Repeat_Off
            If Me.playMode = PlayMode.SHUFFLE Then
               Sonos.Sound.PlayMode(Me.ip) = PlayMode.NORMAL
            ElseIf Me.playMode = PlayMode.REPEAT_ALL Then
               Sonos.Sound.PlayMode(Me.ip) = PlayMode.SHUFFLE_NOREPEAT
            End If
         Case Command.Repeat_On
            If Me.playMode = PlayMode.NORMAL Then
               Sonos.Sound.PlayMode(Me.ip) = PlayMode.REPEAT_ALL
            ElseIf Me.playMode = PlayMode.SHUFFLE_NOREPEAT Then
               Sonos.Sound.PlayMode(Me.ip) = PlayMode.SHUFFLE
            End If
         Case Command.Resume
            Sonos.Sound.Play(Me.ip)
         Case Command.Shuffle_Off
            If Me.playMode = PlayMode.REPEAT_ALL Then
               Sonos.Sound.PlayMode(Me.ip) = PlayMode.SHUFFLE_NOREPEAT
            ElseIf Me.playMode = PlayMode.SHUFFLE Then
               Sonos.Sound.PlayMode(Me.ip) = PlayMode.NORMAL
            End If
         Case Command.Shuffle_On
            If Me.playMode = PlayMode.NORMAL Then
               Sonos.Sound.PlayMode(Me.ip) = PlayMode.SHUFFLE
            ElseIf Me.playMode = PlayMode.SHUFFLE_NOREPEAT Then
               Sonos.Sound.PlayMode(Me.ip) = PlayMode.SHUFFLE
            End If
         Case Command.Volume_Down
            Sonos.Sound.SetReleativeVolume(Me.ip, -5)
         Case Command.Volume_Up
            Sonos.Sound.SetReleativeVolume(Me.ip, 5)
         Case Command.Bass_Down
            Sonos.Sound.Bass(Me.ip) -= 1
         Case Command.Bass_Up
            Sonos.Sound.Bass(Me.ip) += 1
      End Select
   End Sub

   Private Sub ProcessCallBack(sender As Object, e As EventArgs) ' Handles TmrMain.Tick
      Try
         If Me.ip Is Nothing Then
            ContextMenuStrip = CmsMain
            LblNasTracksCount.Text = Sonos.NASTracks.Count.ToString

            Me.ip = Sonos.Rooms(TxtSelectedRoom.Text).Values.Where(Function(x) x.isZonePlayer).Single.IP

            GrpSource.Enabled = True
            Enabled = True

            SetSonosFunctionsRadioButtons()
         Else
            PicSpeaker.Image = If(Sonos.Sound.GroupMute(Me.ip), My.Resources.speaker_off, My.Resources.speaker_on)
            TrkSonosVolume.Value = Sonos.Sound.GroupVolume(Me.ip)
            Me.playMode = Sonos.Sound.PlayMode(Me.ip)

            If RbtConnect.Checked Then
               Text = "Source: Sonos connect"
            ElseIf RbtLineIn.Checked Then
               Text = $"Source: {Sonos.Rooms.devices(Me.ip.ToString).Type} lineIn"
            ElseIf RbtQueue.Checked Then
               Text = Sonos.Queue.TrackPositionInfo(Me.ip).TitleAndArtist
            ElseIf RbtTV.Checked Then
               Text = $"Source: {Sonos.Rooms.devices(Me.ip.ToString).Type} TV"
            End If
         End If
      Catch ex As Exception
         Text = ex.Message
      End Try
   End Sub

   Private Sub TrkSonosVolume_Scroll(sender As Object, e As EventArgs) Handles TrkSonosVolume.Scroll
      Sonos.Sound.GroupVolume(Me.ip) = TrkSonosVolume.Value
   End Sub
End Class

