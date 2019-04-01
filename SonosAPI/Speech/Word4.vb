' Program..: Word4.vb
' Author...: G. Wassink
' Design...: 
' Date.....: 11/03/2019 Last revised:11/03/2019
' Notice...: Copyright 1994-2016 All Rights Reserved
' Notes....: VB 16.0 RC4 .Net Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: Parse Speech four Words 

Imports GWSonos.SpeechEngineBase

Public Class Word4
   ReadOnly SpeechEngine As SpeechEngine

   Public Sub New(speechEngine As SpeechEngine)
      Me.SpeechEngine = speechEngine
   End Sub
   Public Function Parse(w1 As String, w2 As String, w3 As String, w4 As String) As Status
      Select Case w1
         Case ""
            Select Case w2
               Case ""
                  Select Case w3
                     Case ""
                        Return Status.understand
                     Case ""
                        Select Case w4
                           Case ""
                              Return Status.understand
                        End Select
                  End Select
            End Select
      End Select

      Return Status.notUnderStand
   End Function
End Class

