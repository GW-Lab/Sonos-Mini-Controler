' Program..: Word2.vb
' Author...: G. Wassink
' Design...: 
' Date.....: 11/03/2019 Last revised:11/03/2019
' Notice...: Copyright 1994-2016 All Rights Reserved
' Notes....: VB 16.0 RC4 .Net Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: Parse Speech two Words 

Imports GWSonos.SpeechEngineBase

Public Class Word2
   ReadOnly SpeechEngine As SpeechEngine

   Public Sub New(speechEngine As SpeechEngine)
      Me.SpeechEngine = speechEngine
   End Sub

   Public Function Parse(w1 As String, w2 As String) As Status
      Select Case w1
         Case "sonos"
            Select Case w2
               Case "previous"
                  Me.SpeechEngine.Cmd_Changed(Command.Previous_Track)
                  Return Status.understand
               Case "next"
                  Me.SpeechEngine.Cmd_Changed(Command.Next_Track)
                  Return Status.understand
               Case "mute"
                  Me.SpeechEngine.Cmd_Changed(Command.Mute_On)
                  Return Status.understand
               Case "pause", "stop"
                  Me.SpeechEngine.Cmd_Changed(Command.Pause)
                  Return Status.understand
               Case "resume"
                  Me.SpeechEngine.Cmd_Changed(Command.Resume)
                  Return Status.understand
               Case "rewind"
                  Me.SpeechEngine.Cmd_Changed(Command.Rewind_Track)
                  Return Status.understand
               Case "unmute"
                  Me.SpeechEngine.Cmd_Changed(Command.Mute_Off)
                  Return Status.understand
            End Select
      End Select

      Return Status.notUnderStand
   End Function
End Class

