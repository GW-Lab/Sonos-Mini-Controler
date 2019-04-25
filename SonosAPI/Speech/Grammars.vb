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
   End Sub

   Public Sub Grammer1Word()
      Dim gb As New GrammarBuilder With {.Culture = New Globalization.CultureInfo("en-US")}
      gb.Append(New Choices(""))                                         ' part 1 of the command 

      Add(New Grammar(gb) With {.Name = "1Word"})
   End Sub

   Private Sub Grammer2Words()
      Dim gb As New GrammarBuilder With {.Culture = New Globalization.CultureInfo("en-US")}
      gb.Append(New Choices("sonos mute",
                            "sonos next",
                            "sonos previous",
                            "sonos pause",
                            "sonos resume",
                            "sonos rewind",
                            "sonos stop"))

      Add(New Grammar(gb) With {.Name = "2Word"})
   End Sub

   Private Sub Grammer3Words()
      Dim gb As New GrammarBuilder With {.Culture = New Globalization.CultureInfo("en-US")}
      gb.Append(New Choices("sonos bass down",
                            "sonos bass up",
                            "sonos mute off",
                            "sonos mute on",
                            "sonos rewind song",
                            "sonos rewind track",
                            "sonos next song",
                            "sonos next track",
                            "sonos previous song",
                            "sonos previous track",
                            "sonos volume down",
                            "sonos volume up",
                            "sonos repeat off",
                            "sonos repeat on",
                            "sonos shuffle off",
                            "sonos shuffle on"))

      Add(New Grammar(gb) With {.Name = "3Word"})
   End Sub

   Private Sub Grammer4Words()
      Dim gb As New GrammarBuilder With {.Culture = New Globalization.CultureInfo("en-US")}
      gb.Append(New Choices("sonos rewind current song", "sonos rewind current track"))

      Add(New Grammar(gb) With {.Name = "4Word"})
   End Sub
End Class

