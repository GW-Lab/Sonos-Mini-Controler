' Program..: Grammars.vb
' Author...: G. Wassink
' Design...: 
' Date.....: 11/03/2019 Last revised:11/03/2019
' Notice...: Copyright 1994-2016 All Rights Reserved
' Notes....: VB16.0.2 .NET Framework 4.8
' Files....: None
' Programs.:
' Reserved.: Grammars

' B.V. => find album in the blues category
' Create lists Of alternative choices.
' Dim listTypes = New Choices({"albums", "artists"})
' Dim genres = New Choices({"blues", "classical", "gospel", "jazz", "rock"})
' Create a GrammarBuilder Object And assemble the grammar components.
' Dim mediaMenu = New GrammarBuilder("Find")
' mediaMenu.Append(listTypes)
' mediaMenu.Append("in the")
' mediaMenu.Append(genres)
' mediaMenu.Append("category.")
' Build a Grammar Object from the GrammarBuilder.
' Dim mediaMenuGrammar = New Grammar(mediaMenu)

Imports System.Speech.Recognition

Public Class Grammars : Inherits List(Of Grammar)
   Public Sub New()
      '   Grammer1Word()
      Grammer2Words()
      Grammer3Words()
      Grammer4Words()
      '  Grammer5Words()
   End Sub

   Public Sub Grammer1Word()
      Dim gb As New GrammarBuilder With {.Culture = New Globalization.CultureInfo("en-US")}
      gb.Append(New Choices(""))                                         ' part 1 of the command 

      Add(New Grammar(gb) With {.Name = "1Word"})
   End Sub

   Private Sub Grammer2Words()
      TwoWords("sonos", "mute")
      TwoWords("sonos", "next")
      TwoWords("sonos", "previous") ' Skip to previous track
      TwoWords("sonos", "pause")    ' Skip to next track
      TwoWords("sonos", "resume")
      TwoWords("sonos", "rewind")
      TwoWords("sonos", "stop")
   End Sub

   Private Sub Grammer3Words()
      ThreeWords("sonos", "bass", "down")
      ThreeWords("sonos", "bass", "up")
      ThreeWords("sonos", "mute", "off")
      ThreeWords("sonos", "mute", "on")
      ThreeWords("sonos", "rewind", "song")
      ThreeWords("sonos", "rewind", "track")
      ThreeWords("sonos", "next", "song")
      ThreeWords("sonos", "next", "track")
      ThreeWords("sonos", "previous", "song")
      ThreeWords("sonos", "previous", "track")
      ThreeWords("sonos", "volume", "down")
      ThreeWords("sonos", "volume", "up")
      ThreeWords("sonos", "repeat", "off")
      ThreeWords("sonos", "repeat", "on")
      ThreeWords("sonos", "shuffle", "off")
      ThreeWords("sonos", "shuffle", "on")
   End Sub

   Private Sub Grammer4Words()
      FourWords("sonos", "rewind", "current", "song")
      FourWords("sonos", "rewind", "current", "track")
   End Sub

   'Private Sub Grammer5Words()
   '   FiveWords("will", "she", "give", "a", "blowjob")
   'End Sub

   Private Sub TwoWords(word1 As String, word2 As String)
      Dim gb As New GrammarBuilder With {.Culture = New Globalization.CultureInfo("en-US")}

      gb.Append($"{word1} {word2}")
      Add(New Grammar(gb) With {.Name = "2Words"})
   End Sub

   Private Sub ThreeWords(word1 As String, word2 As String, word3 As String)
      Dim gb As New GrammarBuilder With {.Culture = New Globalization.CultureInfo("en-US")}

      gb.Append($"{word1} {word2} {word3}")
      Add(New Grammar(gb) With {.Name = "3Words"})
   End Sub

   Private Sub FourWords(word1 As String, word2 As String, word3 As String, word4 As String)
      Dim gb As New GrammarBuilder With {.Culture = New Globalization.CultureInfo("en-US")}

      gb.Append($"{word1} {word2} {word3} {word4}")
      Add(New Grammar(gb) With {.Name = "4Words"})
   End Sub

   'Private Sub FiveWords(word1 As String, word2 As String, word3 As String, word4 As String, word5 As String)
   '   Dim gb As New GrammarBuilder With {.Culture = New Globalization.CultureInfo("en-US")}

   '   gb.Append($"{word1} {word2} {word3} {word4} {word5}")
   '   Add(New Grammar(gb) With {.Name = "5Words"})
   'End Sub
End Class

