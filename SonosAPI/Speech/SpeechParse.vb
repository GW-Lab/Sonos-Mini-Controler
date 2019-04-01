' Program..: SpeechParse.vb
' Author...: G. Wassink
' Design...: 
' Date.....: 11/03/2019 Last revised:11/03/2019
' Notice...: Copyright 1994-2016 All Rights Reserved
' Notes....: VB 16.0 RC4 .Net Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: ParseSpeech

Imports System.Speech.Recognition
Imports GWSonos.SpeechEngineBase

Public Class SpeechParse
   ReadOnly Word1 As Word1
   ReadOnly Word2 As Word2
   ReadOnly Word3 As Word3
   ReadOnly Word4 As Word4
   ReadOnly Word5 As Word5

   Public Sub New(speechEngine As SpeechEngine)
      Me.Word1 = New Word1(speechEngine)
      Me.Word2 = New Word2(speechEngine)
      Me.Word3 = New Word3(speechEngine)
      Me.Word4 = New Word4(speechEngine)
      Me.Word5 = New Word5(speechEngine)
   End Sub

   Public Function Parse(e As SpeechRecognizedEventArgs) As Status
      Dim words = e.Result.Text.Split(" "c)

      Select Case e.Result.Grammar.Name
         Case "1Word"
            Return Me.Word1.Parse(words(0))
         Case "2Words"                                                                                                                                               ' Get 3 levels of the command
            Return Me.Word2.Parse(words(0), words(1))
         Case "3Words"
            Return Me.Word3.Parse(words(0), words(1), words(2))
         Case "4Words"
            Return Me.Word4.Parse(words(0), words(1), words(2), words(3))
         Case "5Words"
            Return Me.Word5.Parse(words(0), words(1), words(2), words(3), words(4))
         Case Else
            Return Status.notUnderStand
      End Select
   End Function
End Class

