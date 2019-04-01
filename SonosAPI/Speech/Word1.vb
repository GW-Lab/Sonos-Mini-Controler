' Program..: Word1.vb
' Author...: G. Wassink
' Design...: 
' Date.....: 11/03/2019 Last revised:11/03/2019
' Notice...: Copyright 1994-2016 All Rights Reserved
' Notes....: VB 16.0 RC4 .Net Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: Parse Speech one Word 

Imports GWSonos.SpeechEngineBase

Public Class Word1
   ReadOnly SpeechEngine As SpeechEngine

   Public Sub New(speechEngine As SpeechEngine)
      Me.SpeechEngine = speechEngine
   End Sub

   Public Function Parse(w1 As String) As Status
      Select Case w1
         Case ""
            Return Status.notUnderStand
      End Select

      Return Status.understand
   End Function
End Class

