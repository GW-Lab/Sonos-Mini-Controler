' Program..: SpeechEngine.vb
' Author...: G. Wassink
' Design...: 
' Date.....: 11/03/2019 Last revised:11/03/2019
' Notice...: Copyright 1994-2016 All Rights Reserved
' Notes....: VB16.0.2 .NET Framework 4.8
' Files....: None
' Programs.:
' Reserved.: 

Public Class SpeechEngine : Inherits SpeechEngineBase
   Private ReadOnly ParseSpeech As SpeechParse
   Public Event Command_Changed(cmd As Command)

   Public Sub New()
      Sp.SelectVoice("Microsoft Zira Desktop")
      Me.ParseSpeech = New SpeechParse(Me)
   End Sub

   Private Sub BDSMEngine_SpeechRecognized(sender As Object, e As Speech.Recognition.SpeechRecognizedEventArgs) Handles Me.SpeechRecognized
      Select Case Me.ParseSpeech.Parse(e)
         Case Status.understand  ' Stay quiet
         Case Else
            Sp.SpeakAsync("don't understand")
      End Select
   End Sub

   Public Sub Cmd_Changed(cmd As Command)
      RaiseEvent Command_Changed(cmd)
   End Sub
End Class
