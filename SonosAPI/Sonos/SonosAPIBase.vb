' Program..: SonosAPIBase.vb
' Author...: G. Wassink
' Design...:
' Date.....: 11/03/2019 Last revised:11/03/2019
' Notice...: Copyright 1994-2016 All Rights Reserved
' Notes....: VB16.0.2 .NET Framework 4.8
' Files....: None
' Programs.:
' Reserved.: SonosAPIBase.vb

' links to info/data on a Sonos device
' http://192.168.2.163:1400/status/topology  is broken
' http://192.168.2.164:1400/status/tracks_summary
' http://192.168.2.163:1400/support/review
' http://192.168.2.164:1400/tools.htm
' http://192.168.2.164:1400/xml/device_description.xml
' http://192.168.2.163:1400/xml/DeviceProperties1.xml
' http://192.168.2.163:1400/xml/ZoneGroupTopology1.xml

' String ANALOG_LINE_IN_URI = "x-rincon-stream:";
' String OPTICAL_LINE_IN_URI = "x-sonos-htastream:";
' String QUEUE_URI = "x-rincon-queue:";
' String GROUP_URI = "x-rincon:";
' String STREAM_URI = "x-sonosapi-stream:";
' String FILE_URI = "x-file-cifs:";
' String SPDIF = ":spdif";

'update, found some more:
' 00: no spdif input connected
' 02: Stereo
' 07: Dolby 2.0
' 18: Dolby 5.1
' 21: (not listening) playing another stream?
' 22: Silence

Imports System.IO
Imports System.Net

'def main_cli()
'41     num_args = len(argv)
'42
'43     if num_args < 2:
'44         print(usage_text)
'45         return
'46
'47     cmd = argv[1]
'48
'49     if cmd == "list":
'50         if num_args == 2:
'51             list_socos()
'52         elif num_args == 3:
'53             list_socos(argv[2])
'54         else:
'55             print("invalid arguments")
'56     elif cmd == "pair":
'57         if num_args == 4:
'58             pair_socos(argv[2], argv[3])
'59         else:
'60             print("invalid arguments")
'61     elif cmd == "unpair":
'62         if num_args == 3:
'63             unpair_socos(argv[2])
'64         else:
'65             print("invalid arguments")
'66     else:
'67         print(usage_text)
'68
'69 def list_socos(interface_addr=None):
'70     devs = soco.discover(interface_addr=interface_addr)
'71     for dev in devs:
'72         ip = dev.ip_address
'73         name = dev.player_name
'74         print("{:<15}  {}".format(ip, name))
'75
'76 def pair_socos(l_ip, r_ip):
'77     l_soco = soco.SoCo(l_ip)
'78     r_soco = soco.SoCo(r_ip)
'79
'80     l_uid = l_soco.uid
'81     r_uid = r_soco.uid
'82
'83     req_addr = request_address_format.format(l_ip)
'84     req_headers = {
'85         "Content-Type": "application/xml",
'86         "SOAPAction": pair_soap_action,
'87     }
'88     req_payload = pair_payload_format.format(l_uid, r_uid)
'89
'90     response = requests.post(req_addr, data=req_payload, headers=req_headers)
'91
'92     if response.status_code != 200:
'93         print("failed to pair")
'94
'95
'96 def unpair_socos(master_ip):
'97     req_addr = request_address_format.format(master_ip)
'98     req_headers = {
'99         "Content-Type": "application/xml",
'100         "SOAPAction": unpair_soap_action,
'101     }
'102     req_payload = unpair_payload_format
'103
'104     response = requests.post(req_addr, data=req_payload, headers=req_headers)
'105
'106     if response.status_code != 200:
'107         print("failed to unpair")
'108
'109 if __name__ == "__main__":
'110     main_cli()

Public MustInherit Class SonosAPIBase : Inherits WebRequest

#Region "Events"

   Public Event Device_Changed(dev As Device)

   Public Event Device_Search(msg As String)

   Public Event Search_Completed(roomsFound As Integer)

#End Region

   Public Property Led(ip As IPAddress) As Boolean
      Get
         Dim uri = $"http://{ip}:1400/DeviceProperties/Control"
         Dim soapAction = "urn:schemas-upnp-org:service:DeviceProperties:1#GetLEDState"
         Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                              <s:Body>
                                 <u:GetLEDState xmlns:u="urn:schemas-upnp-org:service:DeviceProperties:1">
                                    <InstanceID>0</InstanceID>
                                 </u:GetLEDState>
                              </s:Body>
                           </s:Envelope>

         Return If(XDocument.Parse(WebRequest(uri, soapAction, soapMessage)).Root.Value = "On", True, False)
      End Get
      Set(value As Boolean)
         Dim uri = $"http://{ip}:1400/DeviceProperties/Control"
         Dim soapAction = "urn:schemas-upnp-org:service:DeviceProperties:1#SetLEDState"
         Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                              <s:Body>
                                 <u:SetLEDState xmlns:u="urn:schemas-upnp-org:service:DeviceProperties:1">
                                    <DesiredLEDState><%= If(value, "On", "Off") %></DesiredLEDState>
                                 </u:SetLEDState>
                              </s:Body>
                           </s:Envelope>

         WebRequest(uri, soapAction, soapMessage)
      End Set
   End Property

   Public Function AddBondedZones(ip As IPAddress) As XElement
      Dim uri = $"http://{ip}:1400/DeviceProperties/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:DeviceProperties:1#AddBondedZones"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:AddBondedZones xmlns:u="urn:schemas-upnp-org:service:DeviceProperties:1">'
                                 <ChannelMapSet>{}:LF,LF;{}:RF,RF</ChannelMapSet>
                              </u:AddBondedZones>
                           </s:Body>
                        </s:Envelope>
      Try
         Dim xe = WebRequest(uri, soapAction, soapMessage)
         Return XElement.Parse(xe)
      Catch ex As Exception
         Return XElement.Parse("<CurrentZoneName/>")
      End Try
   End Function

   Public Function GetZoneAttributes(ip As IPAddress) As XElement
      Dim uri = $"http://{ip}:1400/DeviceProperties/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:DeviceProperties:1#GetZoneAttributes"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <InstanceID>0</InstanceID>
                              <u:GetZoneAttributes xmlns:u="urn:schemas-upnp-org:service:DeviceProperties:1"/>
                           </s:Body>
                        </s:Envelope>
      Try
         Dim xe = WebRequest(uri, soapAction, soapMessage)
         Return XElement.Parse(xe)
      Catch ex As Exception
         Return XElement.Parse("<CurrentZoneName/>")
      End Try
   End Function

   Public Function GetZoneGroupAttributes(ip As IPAddress) As XElement
      Dim uri = $"http://{ip}:1400/ZoneGroupTopology/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:ZoneGroupTopology:1#GetZoneGroupAttributes"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:GetZoneGroupAttributes xmlns:u="urn:schemas-upnp-org:service:ZoneGroupTopology:1"/>
                           </s:Body>
                        </s:Envelope>
      Try
         Return XElement.Parse(WebRequest(uri, soapAction, soapMessage))
      Catch ex As Exception
         Return XElement.Parse("<CurrentZonePlayerUUIDsInGroup/>")
      End Try
   End Function

   Public Function MediaInfo(ip As IPAddress) As String
      Dim uri = $"http://{ip}:1400/MediaRenderer/AVTransport/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:AVTransport:1#GetMediaInfo"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:GetMediaInfo xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
                                 <InstanceID>0</InstanceID>
                              </u:GetMediaInfo>
                           </s:Body>
                        </s:Envelope>
      Try
         Return WebRequest(uri, soapAction, soapMessage)
      Catch ex As Exception
         Return ""
      End Try
   End Function

   Public Function PlayMP3(ip As IPAddress, track As Track) As String
      Dim uri = $"http://{ip}:1400/MediaRenderer/AVTransport/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:AVTransport:1#SetAVTransportURI"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:SetAVTransportURI xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
                                 <InstanceID>0</InstanceID>
                                 <CurrentURI>x-file-cifs:<%= track.URI %></CurrentURI>
                                 <CurrentURIMetaData></CurrentURIMetaData>
                              </u:SetAVTransportURI>
                           </s:Body>
                        </s:Envelope>

      Return WebRequest(uri, soapAction, soapMessage)
   End Function

   Public Function Radio(ip As IPAddress, uri As String) As String
      Dim upnp_uri = $"http://{ip}:1400/MediaRenderer/AVTransport/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:AVTransport:1#SetAVTransportURI"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:SetAVTransportURI xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
                                 <InstanceID>0</InstanceID>
                                 <CurrentURI><%= uri %></CurrentURI>
                                 <CurrentURIMetaData></CurrentURIMetaData>
                              </u:SetAVTransportURI>
                           </s:Body>
                        </s:Envelope>

      'Dim upnp_uri = $"http://{ip}:1400/MediaRenderer/AVTransport/Control"
      'Dim soapAction = "urn:schemas-upnp-org:service:AVTransport:1#SetAVTransportURI"
      'Dim SoapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
      '                     <s:Body>
      '                        <u:SetAVTransportURI xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
      '                           <InstanceID>0</InstanceID>
      '                           <CurrentURI><%= uri %></CurrentURI>
      '                           <CurrentURIMetaData>
      '                              <DIDL-Lite xmlns:dc="http://purl.org/dc/elements/1.1/" xmlns:upnp="urn:schemas-upnp-org:metadata-1-0/upnp/" xmlns:r="urn:schemas-rinconnetworks-com:metadata-1-0/" xmlns="urn:schemas-upnp-org:metadata-1-0/DIDL-Lite/">
      '                                 <item id="0" parentID="0" restricted="true">
      '                                    <dc:title><%= title %></dc:title>
      '                                    <upnp:class>object.itemobject.item.sonos-favorite</upnp:class>
      '                                    <desc id="cdudn" nameSpace="urn:schemas-rinconnetworks-com:metadata-1-0/">SA_RINCON65031</desc>
      '                                 </item>
      '                              </DIDL-Lite>
      '                           </CurrentURIMetaData>
      '                        </u:SetAVTransportURI>
      '                     </s:Body>
      '                  </s:Envelope>

      ''<CurrentURI><%= uri.Replace("&", "&amp;") %></CurrentURI>
      '' <item id="F00092020s9483" parentID="F000c0008s9483" restricted="true">
      Try
         Return WebRequest(upnp_uri, soapAction, soapMessage)
      Catch ex As Exception
         Return ""
      End Try
   End Function

   Public Function RemoveBondedZones(ip As IPAddress) As XElement
      Dim uri = $"http://{ip}:1400/DeviceProperties/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:DeviceProperties:1#RemoveBondedZones"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:RemoveBondedZones xmlns:u="urn:schemas-upnp-org:service:DeviceProperties:1">
                                 <ChannelMapSet></ChannelMapSet>
                              </u:RemoveBondedZones>
                           </s:Body>
                        </s:Envelope>
      Try
         Dim xe = WebRequest(uri, soapAction, soapMessage)
         Return XElement.Parse(xe)
      Catch ex As Exception
         Return XElement.Parse("<CurrentZoneName/>")
      End Try
   End Function

   ' * @param string $arg1  Unit ("TRACK_NR" || "REL_TIME" || "SECTION")
   ' * @param string $arg2  Target (if this Arg Is Not set Arg1 Is considered to be "REL_TIME and the real arg1 value is set as arg2 value)
   Public Function SonosFavorites(ip As IPAddress) As Favorites
      Dim uri = $"http://{ip}:1400/MediaServer/ContentDirectory/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:ContentDirectory:1#Browse"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:Browse xmlns:u="urn:schemas-upnp-org:service:ContentDirectory:1">
                                 <ObjectID>FV:2</ObjectID>
                                 <BrowseFlag>BrowseDirectChildren</BrowseFlag>
                                 <Filter>dc:title,res,dc:creator,upnp:artist,upnp:album,upnp:albumArtURI</Filter>
                                 <StartingIndex>0</StartingIndex>
                                 <RequestedCount>100</RequestedCount>
                                 <SortCriteria/>
                              </u:Browse>
                           </s:Body>
                        </s:Envelope>

      Dim xmlDoc = New Xml.XmlDocument

      xmlDoc.LoadXml(WebRequest(uri, soapAction, soapMessage))
      xmlDoc.LoadXml(xmlDoc.SelectNodes("//Result").Item(0).InnerText)

      Dim Stations As New Favorites
      For Each station As Xml.XmlElement In xmlDoc.GetElementsByTagName("item")
         Stations.Add(New Favorite With {.AlbumArtURI = station.ChildNodes.Item(4).InnerText,
                                         .ClassObject = station.ChildNodes.Item(1).InnerText,
                                         .Description = station.ChildNodes.Item(6).InnerText,
                                         .Ordinal = CInt(station.ChildNodes.Item(2).InnerText),
                                         .Title = station.ChildNodes.Item(0).InnerText,
                                         .Type = station.ChildNodes.Item(5).InnerText,
                                         .StreamURI = station.ChildNodes.Item(3).InnerText})
      Next

      Return Stations
   End Function

   Public Function TTSpeech(ip As IPAddress) As String
      Dim uri = $"http://{ip}:1400/MediaRenderer/AVTransport/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:AVTransport:1#SetAVTransportURI"

      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:SetAVTransportURI xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
                                 <InstanceID>0</InstanceID>
                                 <CurrentURI>x-rincon-mp3radio:https:\\translate.google.com/translate_tts?ie=UTF-8&amp;client=twob&amp;tl=en&amp;q=There+Is+someone+at+the+door</CurrentURI>
                                 <CurrentURIMetaData></CurrentURIMetaData>
                              </u:SetAVTransportURI>
                           </s:Body>
                        </s:Envelope>

      Try
         Return WebRequest(uri, soapAction, soapMessage)
      Catch ex As Exception
         Return ""
      End Try
   End Function

   '   ' Dim uri = $"http://{ip}:1400/MediaServer/ContentDirectory/Event"
   '   Dim uri = $"http://{ip}:1400//MediaRenderer/AVTransport/Event"
   '   Dim soapAction = "urn:schemas-upnp-org:service:AVTransport:1#SUBSCRIBE"
   '   Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
   '                        <s:Body>
   '                           <CALLBACK><%= endPoint %></CALLBACK>
   '                           <NT>upnp:event</NT>
   '                           <TIMEOUT>Second-300</TIMEOUT>
   '                        </s:Body>
   '                     </s:Envelope>
   '   Return WebEventRequest(uri, soapAction, soapMessage)
   'End Function
   'Public Function PlayRadioStation(ByVal uri As String) As String
   '   '      Return DoWebRequest("/MediaRenderer/AVTransport/Control", """urn:schemas-upnp-org:service:AVTransport:1#SetAVTransportURI""", "<s:Envelope xmlns:s=""http://schemas.xmlsoap.org/soap/envelope/"" s:encodingStyle=""http://schemas.xmlsoap.org/soap/encoding/"">" & vbLf & "<s:Body>" & vbLf & "<u:SetAVTransportURI xmlns:u=""urn:schemas-upnp-org:service:AVTransport:1"">" & vbLf & "<InstanceID>0</InstanceID>" & vbLf & "<CurrentURI>" & uri.Replace("&", "&amp;") & "</CurrentURI>" & vbLf & "<CurrentURIMetaData>&lt;DIDL-Lite xmlns:dc=&quot;http://purl.org/dc/elements/1.1/&quot; xmlns:upnp=&quot;urn:schemas-upnp-org:metadata-1-0/upnp/&quot; xmlns:r=&quot;urn:schemas-rinconnetworks-com:metadata-1-0/&quot; xmlns=&quot;urn:schemas-upnp-org:metadata-1-0/DIDL-Lite/&quot;&gt;&lt;item id=&quot;F00092020s9483&quot; parentID=&quot;F000c0008s9483&quot; restricted=&quot;true&quot;&gt;&lt;dc:title&gt;NPO Radio 2&lt;/dc:title&gt;&lt;upnp:class&gt;object.item.audioItem.audioBroadcast.sonos-favorite&lt;/upnp:class&gt;&lt;desc id=&quot;cdudn&quot; nameSpace=&quot;urn:schemas-rinconnetworks-com:metadata-1-0/&quot;&gt;SA_RINCON65031_&lt;/desc&gt;&lt;/item&gt;&lt;/DIDL-Lite&gt;</CurrentURIMetaData>" & vbLf & "</u:SetAVTransportURI>" & vbLf & "</s:Body>" & vbLf & "</s:Envelope>")
   '   Dim DoWebRequest0 = "/MediaRenderer/AVTransport/Control"
   '   Dim doWebRequest1 = """urn:schemas-upnp-org:service:AVTransport:1#SetAVTransportURI"""
   '   Dim payLoad = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
   '                    <s:Body>
   '                       <u:SetAVTransportURI xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
   '                          <InstanceID>0</InstanceID>
   '                          <CurrentURI><%= uri.Replace("&", "&amp;") %></CurrentURI>
   '                          <CurrentURIMetaData>
   '                             <DIDL-Lite xmlns:dc="http://purl.org/dc/elements/1.1/" xmlns:upnp="urn:schemas-upnp-org:metadata-1-0/upnp/" xmlns:r="urn:schemas-rinconnetworks-com:metadata-1-0/" xmlns="urn:schemas-upnp-org:metadata-1-0/DIDL-Lite/">
   '                                <item id="F00092020s9483" parentID="F000c0008s9483" restricted="true">
   '                                   <dc:title>NPO Radio 2</dc:title>
   '                                   <upnp:class>object.item.audioItem.audioBroadcast.sonos-favorite</upnp:class>
   '                                   <desc id="cdudn" nameSpace="urn:schemas-rinconnetworks-com:metadata-1-0/">SA_RINCON65031_</desc>
   '                                </item></DIDL-Lite>
   '                          </CurrentURIMetaData>
   '                       </u:SetAVTransportURI>
   '                    </s:Body>
   '                 </s:Envelope>
   'End Function
   Function WebRequest(uri As String, soapAction As String, soapMessage As XElement) As String
      Try
         Dim webReq = CreateHttp(uri)
         webReq.Method = "POST"
         webReq.ContentType = "text/xml" ' ; charset=""utf-8"""
         webReq.KeepAlive = False
         webReq.Headers.Add("SOAPACTION", soapAction)

         Using sw = New StreamWriter(webReq.GetRequestStream)
            sw.Write(soapMessage)
            sw.Flush()

            Using sr = New StreamReader(webReq.GetResponse.GetResponseStream) ' , System.Text.Encoding.Unicode)
               Return sr.ReadToEnd
            End Using
         End Using
      Catch e As WebException
         Return e.Message
      End Try
   End Function

   Protected Function GetZoneGroupTopology(ip As IPAddress) As XDocument
      Dim uri = $"http://{ip}:1400/ZoneGroupTopology/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:ZoneGroupTopology:1#GetZoneGroupState"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:GetZoneGroupState xmlns:u="urn:schemas-upnp-org:service:ZoneGroupTopology:1"/>
                           </s:Body>
                        </s:Envelope>
      Try
         Return XDocument.Parse(WebRequest(uri, soapAction, soapMessage))
      Catch ex As Exception
         Return XDocument.Parse("<CurrentZoneName></>")
      End Try
   End Function

   Protected Function GetZoneInfo(ip As IPAddress) As String
      Dim uri = $"http://{ip}:1400/DeviceProperties/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:DeviceProperties:1#GetZoneInfo"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:GetZoneInfo xmlns:u="urn:schemas-upnp-org:service:DeviceProperties:1"/>
                           </s:Body>
                        </s:Envelope>

      Return WebRequest(uri, soapAction, soapMessage)
   End Function

   Protected Overridable Sub OnDevice_Changed(dev As Device)
      RaiseEvent Device_Changed(dev)
   End Sub

   Protected Overridable Sub OnDevice_Search(msg As String)
      RaiseEvent Device_Search(msg)
   End Sub

   Protected Overridable Sub OnSearch_Completed(roomCount As Integer)
      RaiseEvent Search_Completed(roomCount)
   End Sub
   '<u: GetZoneInfoResponse
   'xmlns:u="urn:schemas-upnp-org:service:DeviceProperties:1">
   '<SerialNumber>5C-AA-FD-xx-xx-xx:F</SerialNumber>
   '<SoftwareVersion>33.15-32291</SoftwareVersion>
   '<DisplaySoftwareVersion>6.4</DisplaySoftwareVersion>
   '<HardwareVersion>1.9.1.10-2</HardwareVersion>
   '<IPAddress>10.0.x.x</IPAddress>
   '<MACAddress>5C:AA:FD:xx:xx:xx</MACAddress>
   '<CopyrightInfo>.. 2004-2015 Sonos, Inc. All Rights Reserved.</CopyrightInfo>
   '<ExtraInfo> OTP :  </ExtraInfo>
   '<HTAudioIn>2</HTAudioIn>
   '</u:GetZoneInfoResponse>
   'Protected Function Subscribe(ip As IPAddress, endPoint As String) As String
   '   ' Dim uri = $"http://{ip}:1400/MediaServer/ContentDirectory/Event"
   '   ' Dim uri = $"http://{ip}:1400//MediaRenderer/AVTransport/Event"
   '   ' Dim soapAction = "urn:schemas-upnp-org:service:AVTransport:1#SUBSCRIBE"
   '   ' Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
   '   '                     <s:Body>
   '   '                        <u:SUBSCRIBE xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
   '   '                           <CALLBACK><%= endPoint %></CALLBACK>
   '   '                           <NT>upnp:event</NT>
   '   '                           <TIMEOUT>Second-300</TIMEOUT>
   '   '                        </u:SUBSCRIBE>
   '   '                     </s:Body>
   '   '                  </s:Envelope>

   '   ' If ($arg2=="NONE"){
   '   ' $Unit="REL_TIME"; $position=$arg1;
   '   ' else {$Unit=$arg1; $position=$arg2;}
   '   ' Return WebRequest(uri, soapAction, soapMessage)
End Class