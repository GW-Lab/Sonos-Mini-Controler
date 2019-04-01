' Program..: SpeechEngineBase.vb
' Author...: G. Wassink
' Design...: 
' Date.....: 11/03/2019 Last revised:11/03/2019
' Notice...: Copyright 1994-2016 All Rights Reserved
' Notes....: VB 16.0 RC4 .Net Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: SpeechEngine  

Imports System.Speech.Recognition

Public Class SpeechEngineBase : Inherits SpeechRecognitionEngine
   Public Enum Status
      understand = 1
      notUnderStand = 0
   End Enum

   Public Enum Command
      Bass_Down
      Bass_Up
      Mute_Off
      Mute_On
      Pause
      Previous_Track
      Next_Track
      Rewind_Track
      Repeat_Off
      Repeat_On
      [Resume]
      Shuffle_Off
      Shuffle_On
      Volume_Down
      Volume_Up
   End Enum

   Public Sub New()
      Try
         SetInputToDefaultAudioDevice()
         UnloadAllGrammars()

         For Each grammar As Grammar In New Grammars
            LoadGrammar(grammar)
         Next

         RecognizeAsync(RecognizeMode.Multiple)
      Catch ex As Exception
      End Try
   End Sub
End Class
