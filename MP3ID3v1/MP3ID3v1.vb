' Program..: MP3ID3v1.vb
' Author...: G. Wassink
' Design...: 
' Date.....: 11/03/2019 Last revised:11/03/2019
' Notice...: Copyright 1994-2016 All Rights Reserved
' Notes....: VB 16.0 RC4 .Net Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: 

Imports System.IO
Imports System.Text.Encoding

Public Class MP3ID3v1
   Public TAGID As Byte() = New Byte(2) {}      ' 03
   Public Title As Byte() = New Byte(29) {}     ' 30
   Public Artist As Byte() = New Byte(29) {}    ' 30
   Public Album As Byte() = New Byte(29) {}     ' 30
   Public Year As Byte() = New Byte(3) {}       ' 04 
   Public Comment As Byte() = New Byte(29) {}   ' 30 
   Public Genre As Byte() = New Byte(0) {}      ' 01

   Public Enum Genres As Byte
      Blues = 0
      ClassicRock = 1
      Country = 2
      Dance = 3
      Disco = 4
      Funk = 5
      Grunge = 6
      HipHop = 7
      Jazz = 8
      Metal = 9
      NewAge = 10
      Oldies = 11
      Instrumental = 12
      Pop = 13
      RnB = 14
      Rap = 15
      Reggae = 16
      Rock = 17
      Techno = 18
      Industrial = 19
      Alternative = 20
      Ska = 21
      DeathMetal = 22
      Pranks = 23
      Soundtrack = 24
      EuroTechno = 25
      Ambient = 26
      TripHop = 27
      Vocal = 28
      JazzFunk = 29
      Fusion = 30
      Trance = 31
      Classical = 32
      Other = 33
      Acid = 34
      House = 35
      Game = 36
      SoundClip = 37
      Gospel = 38
      Noise = 39
      AlternRock = 40
      Bass = 41
      Soul = 42
      Punk = 43
      Space = 44
      Meditative = 45
      InstrumentalPop = 46
      InstrumentalRock = 47
      Ethnic = 48
      Gothic = 49
      Darkwave = 50
      TechnoIndustrial = 51
      Electronic = 52
      PopFolk = 53
      Eurodance = 54
      Dream = 55
      SouthernRock = 56
      Comedy = 57
      Cult = 58
      Gangsta = 59
      Top40 = 60
      ChristianRap = 61
      PopFunk = 62
      Jungle = 63
      NativeAmerican = 64
      Cabaret = 65
      NewWave = 66
      Psychadelic = 67
      Rave = 68
      Showtunes = 69
      Trailer = 70
      LoFi = 71
      Tribal = 72
      AcidPunk = 73
      AcidJazz = 74
      Polka = 75
      Retro = 76
      Musical = 77
      RocknRoll = 78
      HardRock = 79
      None = 255
   End Enum

   Public Function GetTrack(file As String) As Genres
      Try
         If IO.File.Exists(file) Then
            Using fs = IO.File.OpenRead(file)
               If fs.Length >= 128 Then
                  With New MP3ID3v1
                     fs.Seek(-128, SeekOrigin.End)
                     fs.Read(.TAGID, 0, .TAGID.Length)
                     fs.Read(.Title, 0, .Title.Length)
                     fs.Read(.Artist, 0, .Artist.Length)
                     fs.Read(.Album, 0, .Album.Length)
                     fs.Read(.Year, 0, .Year.Length)
                     fs.Read(.Comment, 0, .Comment.Length)
                     fs.Read(.Genre, 0, .Genre.Length)

                     If [Default].GetString(.TAGID).Equals("TAG") Then
                        Dim Title = [Default].GetString(.Title)
                        Dim Artist = [Default].GetString(.Artist)
                        Dim Album = [Default].GetString(.Album)
                        Dim Year = [Default].GetString(.Year)
                        Dim Comment = [Default].GetString(.Comment)
                        Return DirectCast(.Genre(0), Genres)
                     End If
                  End With
               End If
            End Using
         End If

         Return Genres.Other
      Catch ex As Exception
         Return Genres.Other
      End Try
   End Function
End Class
