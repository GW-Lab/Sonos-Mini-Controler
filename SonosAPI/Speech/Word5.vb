' Program..: Word5.vb
' Author...: G. Wassink
' Design...: 
' Date.....: 11/03/2019 Last revised:11/03/2019
' Notice...: Copyright 1994-2016 All Rights Reserved
' Notes....: VB 16.0 RC4 .Net Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: Parse Speech five Words

Imports GWSonos.SpeechEngineBase

Public Class Word5
   ReadOnly SpeechEngine As SpeechEngine

   Public Sub New(speechEngine As SpeechEngine)
      Me.SpeechEngine = speechEngine
   End Sub

   Public Function Parse(w1 As String, w2 As String, w3 As String, w4 As String, w5 As String) As Status

      Select Case w1
         Case "is"
            Select Case w2
               Case "she"
                  Select Case w3
                     Case "giving", "wearing"
                        Select Case w4
                           Case "a"
                              Select Case w5
                                 Case "shirt", "skirt"
                                    '     RaiseEvent Command_Change()
                                    Return Status.understand
                              End Select
                        End Select
                  End Select
            End Select
      End Select

      Return Status.notUnderStand
   End Function
End Class
