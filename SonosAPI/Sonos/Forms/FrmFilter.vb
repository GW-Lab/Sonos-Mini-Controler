Imports System.Net
Imports MP3ID3v1.MP3ID3v1

Public Class FrmFilter
   ReadOnly frm As FrmSonos
   ReadOnly ip As IPAddress
   Public NASTracks As String() = {}               ' Declare the NASTracks array with 0 elements

   Private WithEvents Sonos As SonosAPI

   Public Sub New(sonos As SonosAPI, ip As IPAddress, frm As FrmSonos)
      InitializeComponent() ' This call is required by the designer.
      ' Add any initialization after the InitializeComponent() call.
      Me.frm = frm
      Me.ip = ip
      Me.Sonos = sonos
   End Sub

   'Public Sub New(configuration As Configuration)
   '   MyBase.New(configuration)

   '   Try
   '      If Me.Configuration.NAS_UNC <> "" Then
   '         Using uncTmp = New UNC(Me.Configuration.NAS_UNC, New Net.NetworkCredential(Me.Configuration.Account, Me.Configuration.Password))
   '            Me.NASTracks = Directory.GetFiles(uncTmp.remoteName)
   '         End Using
   '      End If
   '   Catch ex As Exception
   '   End Try
   'End Sub



   Private Sub FrmFilter_Load(sender As Object, e As EventArgs) Handles Me.Load
      Location = Me.frm.Location
   End Sub

   Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
      Dim mp3 = New MP3ID3v1.MP3ID3v1
      Sonos.Queue.Clear(Me.ip)

      If Me.Sonos.Configuration.NAS_UNC <> "" Then
         Using uncTmp = New UNC(Me.Sonos.Configuration.NAS_UNC, New Net.NetworkCredential(Me.Sonos.Configuration.Account, Me.Sonos.Configuration.Password))

            For Each track As Favorite In Me.frm.CmbFavorites.Items
               If ChkInstrumental.Checked AndAlso mp3.GetTrack(track.RemoteURI) = Genres.Instrumental Then
                  Sonos.Queue.AddTrack(Me.ip, track.StreamURI)                                        ' Favorite.Ordinal Add track/radio to then current playlist 
               ElseIf ChkClassical.Checked AndAlso mp3.GetTrack(track.StreamURI) = Genres.Classical Then
                  Sonos.Queue.AddTrack(Me.ip, track.StreamURI)                                        ' Favorite.Ordinal Add track/radio to then current playlist 
               ElseIf ChkPop.Checked AndAlso mp3.GetTrack(track.StreamURI) = Genres.Pop Then
                  Sonos.Queue.AddTrack(Me.ip, track.StreamURI)                                        ' Favorite.Ordinal Add track/radio to then current playlist 
               ElseIf ChkALLGenres.Checked Then
                  Sonos.Queue.AddTrack(Me.ip, track.StreamURI)                                        ' Favorite.Ordinal Add track/radio to then current playlist 
               End If
            Next

         End Using
      End If

      Sonos.Queue.Seek(Me.ip, Unit.TRACK_NR, "1")
      Sonos.Sound.Play(Me.ip)

      Me.Close()
   End Sub
End Class

'Class MusicID3Tag
'   Public Function ReadID3v2Tag(sFile As String) As Track

'      Try ' --------------------------------------------------  

'         ' MP3 Spec:  
'         ' --------------------------------------------------  
'         ' Field Name        ID3v1   ID3v1.1 ID3v2.2 ID3v2.3     ID3v2.4     Lyrics3v1   Lyrics3v2  
'         ' Song Title        title   title   TT2     TIT2        TIT2        --          ETT   
'         ' Lead Artist       artist  artist  TP1     TPE1        TPE1        --          EAR  
'         ' Album Title       album   album   TAL     TALB        TALB        --          EAL  
'         ' Year Released     year    year    TYE     TYER        TDRC        --          --  
'         ' Comment           comment comment COM     COMM        COMM        --          INF  
'         ' Song Genre        genre   genre   TCO     TCON        TCON        --          --  
'         ' Track number      --      track   TRK     TRCK        TRCK        --          --  
'         ' Lyrics            --      --      SYL/ULT SYLT/USLT   SYLT/USLT   lyric       LYR  
'         ' Auth/Composer     --      --      TCM     TCOM        TCOM        --          AUT  
'         ' Popularimeter                             POPM  

'         ' POPM frame in the ID3v2 specification - most software all map roughly the same ranges of 0–255 to a 0–5 stars value for display.  
'         'This chart details how windows explorer reads and writes the POPM frame:  
'         '    224-255 = 5 stars when READ with windows explorer, writes 255  
'         '    160-223 = 4 stars when READ with windows explorer, writes 196  
'         '    096-159 = 3 stars when READ with windows explorer, writes 128  
'         '    032-095 = 2 stars when READ with windows explorer, writes 64  
'         '    001-031 = 1 stars when READ with windows explorer, writes 1  
'         ' --------------------------------------------------  
'         Dim oFS As FileStream
'         Dim baHeader As Byte()
'         Dim oTrack As New Track

'         ' Load object with file path  
'         oTrack.Filename = sFile
'         oTrack.Title = sFile.Substring(sFile.LastIndexOf("\"c) + 1) ' Default Track to file name, in case nothing is picked up below.  

'         oFS = New FileStream(sFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)

'         ' Get first 10 bytes, which holds the header tag, size and version.  
'         ' The ID3v2 tag header, which should be the first information in the file, is 10 bytes as follows:  
'         ' ID3v2/file identifier   "ID3"             - 3 bytes  
'         ' ID3v2 version           $03 00            - 2 bytes  
'         ' ID3v2 flags             %abc00000         - 1 byte  
'         ' ID3v2 size              4 * %0xxxxxxx     - 4 bytes  
'         ReDim baHeader(2)
'         oFS.Read(baHeader, 0, 3) ' Read MP3 header info  
'         If (baHeader(0) = &H49) And (baHeader(1) = &H44) And (baHeader(2) = &H33) Then ' It's a proper MP3  

'            ReDim baHeader(1)
'            oFS.Read(baHeader, 0, 2)

'            If baHeader(0) = 2 And baHeader(1) = 3 Then ' ID3v2.3.0  

'            End If

'            ReDim baHeader(5)
'            oFS.Read(baHeader, 0, 5) ' Not currently using flags or size.  

'            Dim oFrame As Frame

'            ' Start reading tags.  
'            oFrame = GetFrame(oFS)
'            If oFrame.Data2.Length > 255 Then oFrame.Data2 = oFrame.Data2.Substring(0, 255)

'            Do While Not IsNothing(oFrame.Tag)
'               Select Case oFrame.Tag
'                  Case "TIT2", "TT2" : oTrack.Title = oFrame.Data2    ' Song Title  
'                  Case "TPE1", "TP1" : oTrack.Artist = oFrame.Data2   ' Artist  
'                  Case "TALB", "TAL" : oTrack.Album = oFrame.Data2    ' Album  
'                  Case "TRCK", "TRK"
'                     Dim sCD As String = oFrame.Data2
'                     sCD = sCD.Replace("/", "").Replace("?", "")
'                     If sCD.Length > 2 Then sCD = sCD.Substring(0, sCD.Length - 2)
'                     If IsNumeric(sCD) Then oTrack.TrackNumber = CInt(sCD) ' CD Track number  
'                  Case "TCON", "TCO" : oTrack.Genre = oFrame.Data2    ' Genre Description  
'                  Case "POPM"
'               End Select

'               oFrame = GetFrame(oFS)
'               If IsNothing(oFrame) Then goLog.Post("Frame Clip", sFile)
'            Loop
'         End If

'         oFS.Close()

'         Return oTrack
'         ' --------------------------------------------------  
'      Catch oError As Exception ' Only log on Errors  
'         goLog.StartProc("Metallisoft.MP3Player.Audio.ReadID3v2Tag(" & sFile & ")") : goLog.StopProc("", True, oError, False) ': If gbIsIDE Then Stop  
'         Return Nothing
'      End Try

'   End Function

'   <DebuggerStepThrough()>
'   Private Function GetFrame(ByVal oFile As Stream) As Frame

'      Try ' --------------------------------------------------  

'         Dim oFrame As New Frame
'         Dim baFrame As Byte()
'         Dim oEncoding As New System.Text.ASCIIEncoding()

'         ReDim baFrame(4)

'         ' Pull frame name  
'         oFile.Read(baFrame, 0, 4)
'         oFrame.Tag = oEncoding.GetString(baFrame)

'         If baFrame(0) <> 0 Then
'            oFrame.Tag = oFrame.Tag.Substring(0, 4).Trim.Replace(Chr(0), "")
'            If Not oFrame.Tag.Contains("?") Then
'               ' Get 4 bytes for frame size  
'               oFile.Read(baFrame, 0, 4)
'               oFrame.Size = (65536 * (baFrame(0) * 256 + baFrame(1))) + (baFrame(2) * 256 + baFrame(3))

'               ' Skip padding  
'               oFile.Read(baFrame, 0, 3)

'               If oFrame.Size > 0 Then
'                  ReDim baFrame(oFrame.Size + 1)
'                  oFile.Read(baFrame, 0, oFrame.Size - 1)

'                  If oFrame.Tag.Substring(0, 1) = "T" Then
'                     oFrame.Data1 = baFrame
'                     oFrame.Data2 = oEncoding.GetString(baFrame).Trim.Replace(Chr(0), "")
'                  End If
'               End If
'            End If
'            Return oFrame
'         Else
'            Return Nothing
'         End If

'         ' --------------------------------------------------  
'      Catch oError As Exception ' Only log on Errors  
'         goLog.StartProc("Metallisoft.MP3Player.Audio.GetFrame()") : goLog.StopProc("", True, oError, False) ': If gbIsIDE Then Stop  
'         Return Nothing
'      End Try
'   End Function
'End Class