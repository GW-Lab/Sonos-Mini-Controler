' Program..: SonosAPI.vb
' Author...: G. Wassink
' Design...: 
' Date.....: 11/03/2019 Last revised:11/03/2019
' Notice...: Copyright 1994-2016 All Rights Reserved
' Notes....: VB 16.0 RC4 .Net Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: 

Public Enum PlayMode ' 
   NORMAL = 0
   REPEAT_ALL = 1
   SHUFFLE = 2
   SHUFFLE_NOREPEAT = 3
End Enum

Public Enum Unit ' 
   NONE = 0
   TRACK_NR = 1
   REL_TIME = 2
   SECTION = 3
End Enum

Public Class SonosAPI : Inherits SSDPLocator
   Public Configuration As Configuration
   Public Sound As New Sound(Me)
   Public Queue As New Queue(Me)
   Public SwitchTo As New SwitchTo(Me)

   Public Sub New(configuration As Configuration)
      Me.Configuration = configuration
      ScanNetworkForSonos()
   End Sub
End Class
