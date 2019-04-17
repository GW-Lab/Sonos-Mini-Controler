' Program..: SSDPLocator.vb
' Author...: G. Wassink
' Design...: 
' Date.....: 11/03/2019 Last revised:11/03/2019
' Notice...: Copyright 1994-2016 All Rights Reserved
' Notes....: VB 16.0 RC4 .Net Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: 

Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers
Imports System.Net.Sockets
Imports System.Text
Imports System.Threading

' https://en.wikipedia.org/wiki/Simple_Service_Discovery_Protocol

' M-SEARCH response
' The response MUST be sent In the following format. Values In italics are placeholders For actual values.
' HTTP/1.1 200 OK CACHE-CONTROL
' max-age = seconds until advertisement expires 
' Date:              When response was generated EXT:
' LOCATION:          URL for UPnP description for root device
' SERVER:            OS/version UPnP/1.1 product/version
' ST:                Search target
' USN:               Composite identifier For the advertisement
' BOOTID.UPNP.ORG:   Number increased Each time device sends an initial announce Or an update message 

Public Class SSDPLocator : Inherits SonosAPIBase
   Public ReadOnly Rooms As Rooms = New Rooms

   Const DeviceScanInterval As Integer = 300 ' Ms
   ' XML tags
   Const LOCATION = "LOCATION"
   ' UDP message
   Const msgHeader = "M-SEARCH * HTTP/1.1" + vbCrLf

   Const msgHost = "HOST: 239.255.255.250:1900" + vbCrLf
   Const msgMAN = "MAN: ssdp:discover" + vbCrLf
   Const msgMX = "MX: 3" + vbCrLf
   ' Respons window in seconds (devices may ramdomly respond with in de delay window)
   Const msgST = "ST: urn:schemas-upnp-org:device:ZonePlayer:1" + vbCrLf

   Const SERVER = "SERVER"
   Const ST = "ST"
   Const USN = "USN"
   Const XHoushold = "X-RINCON-HOUSEHOLD"
   ReadOnly broadcastMessage As Byte() = Encoding.UTF8.GetBytes(msgHeader + msgHost + msgMAN + msgMX + msgST)

   ReadOnly multiCastEndPoint As IPEndPoint = New IPEndPoint(IPAddress.Parse("239.255.255.250"), 1900)

   ' Create UDP broadcast socket 
   ReadOnly TmrSSDPGetRespons As New Timer(AddressOf ProcessRespons, Nothing, 0, DeviceScanInterval)

   ' search target USER-AGENT: OS/version UPnP/1.1 product/version 
   ' Const msgSt = "ST: urn:schemas-upnp-org:device:ssdp:all" + vbCrLf        ' is not used by Sonos devices
   ReadOnly udpSocket As Socket = New Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp)
   Private DevicesToScan As Integer = 20

   Public Sub ScanNetworkForSonos()
      Try
         Me.udpSocket.SendTo(Me.broadcastMessage, 0, Me.broadcastMessage.Length, SocketFlags.None, Me.multiCastEndPoint)
         MyBase.OnDevice_Search("Search for Sonos...")
      Catch
      End Try
   End Sub

   Public Async Function Subscribe(subscribeURI As IEnumerable(Of Uri), callbackUri As Uri, Optional timeOutInSeconds As Integer = 3600) As Task(Of Boolean)
      Try
         For Each uri In subscribeURI
            Using req = New HttpRequestMessage With {.RequestUri = uri, .Version = HttpVersion.Version11}
               req.Method = New HttpMethod("SUBSCRIBE")
               req.Headers.UserAgent.Add(New ProductInfoHeaderValue("Sonos", "1.0"))
               req.Headers.Add("CALLBACK", $"<{callbackUri.AbsoluteUri}>")
               req.Headers.Add("NT", "upnp:event")
               req.Headers.Add("TIMEOUT", $"Second-{timeOutInSeconds}")
               req.Headers.ConnectionClose = True
               req.Headers.CacheControl = New CacheControlHeaderValue With {.NoCache = True}

               Using httpClient = New HttpClient()
                  Await httpClient.SendAsync(req)
               End Using

               ' Dim response = Await httpClient.SendAsync(req)
               ' Dim status = $"from {subscriptionUri.Host}. StatusCode: {response.StatusCode}"
               ' Dim sid = $"SID: {response.Headers.GetValues("SID").First()}"
               ' Dim timeOut = $"TIMEOUT: {response.Headers.GetValues("TIMEOUT").First}"
               ' Dim server = $"Server: {response.Headers.GetValues("Server").First}"
            End Using
         Next

         Return True
      Catch e As Exception
         Return False ' Console.WriteLine("ERROR TRYING TO SUBSCRIBE " & e)
      End Try
   End Function

   ' Get Sonos-Device-type
   Private Function Get_Type(line As String) As Device.Device_Type
      Select Case line.Substring(line.IndexOf("(") + 1, line.LastIndexOf(")") - line.IndexOf("(") - 1)
         Case "ANVIL" : Return Device.Device_Type.Sub
         Case "ZPS1" : Return Device.Device_Type.Play1
         Case "ZPS13" : Return Device.Device_Type.PlayOne
         Case "ZPS6" : Return Device.Device_Type.Play5
         Case "ZPS11" : Return Device.Device_Type.PlayBar
         Case "ZPS14" : Return Device.Device_Type.Beam
         Case "BR200" : Return Device.Device_Type.Boost
         Case "ZPS9" : Return Device.Device_Type.SoundBar
         Case "ZP90" : Return Device.Device_Type.Connect
         Case Else : Return Device.Device_Type.Unknown
      End Select
   End Function

   Private Sub ProcessRespons(obj As Object)
      Try
         If Me.udpSocket.Available > 0 Then
            Dim receiveBuffer(700) As Byte
            Dim bytesReceived = Me.udpSocket.Receive(receiveBuffer, SocketFlags.None)

            If bytesReceived > 0 Then
               Dim lines = Encoding.UTF8.GetString(receiveBuffer, 0, bytesReceived).Split(CType(vbCrLf, Char())).Where(Function(x) x <> "")
               Dim currIP = ""
               Dim currRoomName = ""
               Dim newDevice = False

               For Each line In lines
                  If line.StartsWith(LOCATION) Then
                     currIP = line.Substring(17, line.LastIndexOf(":"c) - 17)

                     If Not Me.Rooms.devices.ContainsKey(currIP) Then
                        currRoomName = GetZoneAttributes(IPAddress.Parse(currIP)).Descendants("CurrentZoneName").Value '-> "Room xxxxxx"
                        Dim isZonePlayer = GetZoneGroupAttributes(IPAddress.Parse(currIP)).Descendants("CurrentZonePlayerUUIDsInGroup").Value <> ""

                        If Me.Rooms.ContainsKey(currRoomName) Then
                           Me.Rooms(currRoomName).Add(currIP, New Device() With {.IP = IPAddress.Parse(currIP), .LocationXML = line, .Name = currRoomName, .isZonePlayer = isZonePlayer})
                        Else
                           Me.Rooms.Add(currRoomName, New Room With {.Name = currRoomName})
                           Me.Rooms(currRoomName).Add(currIP, New Device() With {.IP = IPAddress.Parse(currIP), .LocationXML = line, .Name = currRoomName, .isZonePlayer = isZonePlayer})
                        End If

                        Me.Rooms.devices.Add(currIP, Me.Rooms(currRoomName)(currIP))

                        newDevice = True
                     End If
                  ElseIf line.StartsWith(SERVER) Then
                     Me.Rooms(currRoomName)(currIP).Server = line
                     Me.Rooms(currRoomName)(currIP).Type = Get_Type(line)

                     If Me.Rooms(currRoomName)(currIP).Type = Device.Device_Type.Connect Then ' A connect can't be a zone player
                        Me.Rooms(currRoomName)(currIP).isZonePlayer = False
                     End If
                  ElseIf line.StartsWith(XHoushold) Then
                     Me.Rooms(currRoomName)(currIP).XHoushold = line
                  ElseIf line.StartsWith(USN) Then
                     Me.Rooms(currRoomName)(currIP).USN = line
                  ElseIf line.StartsWith(ST) Then
                     Me.Rooms(currRoomName)(currIP).ST = line
                  End If
               Next

               If newDevice Then
                  MyBase.OnDevice_Changed(Me.Rooms(currRoomName)(currIP))
               End If
            End If

         End If

         Me.DevicesToScan -= 1

         If Me.DevicesToScan = 0 Then
            Me.TmrSSDPGetRespons.Change(0, 0)
            MyBase.OnSearch_Completed(Me.Rooms.Count)
         End If
      Catch
      End Try
   End Sub
End Class

