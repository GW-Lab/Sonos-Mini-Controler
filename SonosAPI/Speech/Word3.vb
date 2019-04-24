' Program..: Word3.vb
' Author...: G. Wassink
' Design...: 
' Date.....: 11/03/2019 Last revised:11/03/2019
' Notice...: Copyright 1994-2016 All Rights Reserved
' Notes....: VB16.0.2 .NET Framework 4.8
' Files....: None
' Programs.: Parse Speech three Words

Imports GWSonos.SpeechEngineBase

Public Class Word3
   ReadOnly SpeechEngine As SpeechEngine

   Public Sub New(speechEngine As SpeechEngine)
      Me.SpeechEngine = speechEngine
   End Sub

   Public Function Parse(w1 As String, w2 As String, w3 As String) As Status
      Select Case w1
         Case "sonos"
            Select Case w2
               Case "mute"
                  Select Case w3
                     Case "off"
                        Me.SpeechEngine.Cmd_Changed(Command.Mute_Off)
                        Return Status.understand
                     Case "on"
                        Me.SpeechEngine.Cmd_Changed(Command.Mute_On)
                        Return Status.understand
                  End Select
               Case "next"
                  Select Case w3
                     Case "song", "track"
                        Me.SpeechEngine.Cmd_Changed(Command.Next_Track)
                        Return Status.understand
                  End Select
               Case "previous"
                  Select Case w3
                     Case "song", "track"
                        Me.SpeechEngine.Cmd_Changed(Command.Previous_Track)
                        Return Status.understand
                  End Select
               Case "rewind"
                  Select Case w3
                     Case "song", "track"
                        Me.SpeechEngine.Cmd_Changed(Command.Rewind_Track)
                        Return Status.understand
                  End Select
               Case "volume"
                  Select Case w3
                     Case "down"
                        Me.SpeechEngine.Cmd_Changed(Command.Volume_Down)
                        Return Status.understand
                     Case "up"
                        Me.SpeechEngine.Cmd_Changed(Command.Volume_Up)
                        Return Status.understand
                  End Select
               Case "repeat"
                  Select Case w3
                     Case "off"
                        Me.SpeechEngine.Cmd_Changed(Command.Repeat_Off)
                        Return Status.understand
                     Case "on"
                        Me.SpeechEngine.Cmd_Changed(Command.Repeat_On)
                        Return Status.understand
                  End Select
               Case "shuffle"
                  Select Case w3
                     Case "off"
                        Me.SpeechEngine.Cmd_Changed(Command.Shuffle_Off)
                        Return Status.understand
                     Case "on"
                        Me.SpeechEngine.Cmd_Changed(Command.Shuffle_On)
                        Return Status.understand
                  End Select
            End Select
      End Select

      Return Status.notUnderStand
   End Function
End Class

