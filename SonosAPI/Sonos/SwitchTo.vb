Imports System.Net

Public Class SwitchTo
   ReadOnly sonosBase As SonosAPIBase

   Public Sub New(sonosBase As SonosAPIBase)
      Me.sonosBase = sonosBase
   End Sub

   Public Function LineIn(ip As IPAddress, device As Device) As String
      Dim uri = $"http://{ip}:1400/MediaRenderer/AVTransport/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:AVTransport:1#SetAVTransportURI"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:SetAVTransportURI xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
                                 <InstanceID>0</InstanceID>
                                 <CurrentURI>x-rincon-stream:RINCON_<%= device.MAC.Replace(":"c, "") %>01400</CurrentURI>
                                 <CurrentURIMetaData/>
                              </u:SetAVTransportURI>
                           </s:Body>
                        </s:Envelope>
      Try
         Return Me.sonosBase.WebRequest(uri, soapAction, soapMessage)
      Catch ex As Exception
         Return "" 'XDocument.Parse("<CurrentZonePlayerUUIDsInGroup></>")
      End Try
   End Function

   Public Function LineIn(device As Device) As String
      Dim uri = $"http://{device.IP}:1400/MediaRenderer/AVTransport/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:AVTransport:1#SetAVTransportURI"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:SetAVTransportURI xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
                                 <InstanceID>0</InstanceID>
                                 <CurrentURI>x-rincon-stream:RINCON_<%= device.MAC.Replace(":"c, "") %>01400</CurrentURI>
                                 <CurrentURIMetaData/>
                              </u:SetAVTransportURI>
                           </s:Body>
                        </s:Envelope>
      Try
         Return Me.sonosBase.WebRequest(uri, soapAction, soapMessage)
      Catch ex As Exception
         Return "" 'XDocument.Parse("<CurrentZonePlayerUUIDsInGroup></>")
      End Try
   End Function

   Public Function TVIn(ip As IPAddress, device As Device) As String
      Dim uri = $"http://{ip}:1400/MediaRenderer/AVTransport/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:AVTransport:1#SetAVTransportURI"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:SetAVTransportURI xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
                                 <InstanceID>0</InstanceID>
                                 <CurrentURI>x-sonos-htastream:RINCON_<%= device.MAC.Replace(":"c, "") %>01400:spdif</CurrentURI>
                                 <CurrentURIMetaData/>
                              </u:SetAVTransportURI>
                           </s:Body>
                        </s:Envelope>
      Try
         Return Me.sonosBase.WebRequest(uri, soapAction, soapMessage)
      Catch ex As Exception
         Return "" 'XDocument.Parse("<CurrentZonePlayerUUIDsInGroup></>")
      End Try
   End Function

   Public Function QueueIn(ip As IPAddress, device As Device) As String
      Dim uri = $"http://{ip}:1400/MediaRenderer/AVTransport/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:AVTransport:1#SetAVTransportURI"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:SetAVTransportURI xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
                                 <InstanceID>0</InstanceID>
                                 <CurrentURI>x-rincon-queue:RINCON_<%= device.MAC.Replace(":"c, "") %>01400#0</CurrentURI>
                                 <CurrentURIMetaData/>
                              </u:SetAVTransportURI>
                           </s:Body>
                        </s:Envelope>
      Try
         Return Me.sonosBase.WebRequest(uri, soapAction, soapMessage)
      Catch ex As Exception
         Return "" 'XDocument.Parse("<CurrentZonePlayerUUIDsInGroup></>")
      End Try
   End Function
End Class
