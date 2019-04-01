' Program..: Track.vb
' Author...: G. Wassink
' Design...: 
' Date.....: 11/03/2019 Last revised:11/03/2019
' Notice...: Copyright 1994-2016 All Rights Reserved
' Notes....: VB 16.0 RC4 .Net Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: 

Public Class Track
   Public ReadOnly Album As String = ""
   ' Public ReadOnly AlbumArtist As String = ""
   Public ReadOnly Creator As String = ""
   '   Public ReadOnly OriginalTrackNumber As String = ""
   Public ReadOnly Title As String = "No music selected"
   Public ReadOnly TrackDuration As String = ""
   Public ReadOnly URI As String = ""

   Public ReadOnly Property TitleAndArtist As String
      Get
         Return If(Me.URI.StartsWith("x-file-cifs:"), Me.Title + ", " + Me.Creator, "Source: internet stream")
      End Get
   End Property

   Public Sub New()
   End Sub

   Public Sub New(xDoc As XDocument)
      Try
         If xDoc.Descendants("TrackMetaData").Single.Value <> "" AndAlso xDoc.Descendants("TrackMetaData").Single.Value <> "NOT_IMPLEMENTED" Then
            Me.URI = xDoc.Descendants("TrackURI").Value
            ' TODO port to XDocument
            'Dim responseXML = New Xml.XmlDocument
            'responseXML.LoadXml(xDoc.Descendants("TrackMetaData").Single.Value)

            'Me.Album = responseXML.GetElementsByTagName("upnp:album").Item(0)?.InnerText
            'Me.AlbumArtist = responseXML.GetElementsByTagName("r:albumArtist").Item(0)?.InnerText
            'Me.Creator = responseXML.GetElementsByTagName("dc:creator").Item(0)?.InnerText
            'Me.OriginalTrackNumber = responseXML.GetElementsByTagName("upnp:originalTrackNumber").Item(0)?.InnerText
            'Me.Title = responseXML.GetElementsByTagName("dc:title").Item(0)?.InnerText
            'Me.TrackDuration = responseXML.GetElementsByTagName("res").Item(0).Attributes("duration")?.InnerText

            ' Port to XDocument
            Dim xElement = XDocument.Parse(xDoc.Descendants("TrackMetaData").Single.Value)
            Dim ns As XNamespace = xElement.Root.GetDefaultNamespace()
            Dim upnp As XNamespace = "urn:schemas-upnp-org:metadata-1-0/upnp/"
            Dim r As XNamespace = "urn:schemas-rinconnetworks-com:metadata-1-0/"
            Dim dc As XNamespace = "http://purl.org/dc/elements/1.1/"

            Me.Album = xElement.Descendants(upnp + "album").Single?.Value
            'Me.AlbumArtist = xElement.Descendants(r + "albumArtist").Single?.Value
            Me.Creator = xElement.Descendants(dc + "creator").Single?.Value
            'Me.OriginalTrackNumber = xElement.Descendants(upnp + "originalTrackNumber").Single?.Value
            Me.Title = xElement.Descendants(dc + "title").Single?.Value
            Me.TrackDuration = xElement.Root.Descendants(ns + "res").Single.Attribute("duration")?.Value
         End If
      Catch ex As Exception
      End Try
   End Sub
End Class

