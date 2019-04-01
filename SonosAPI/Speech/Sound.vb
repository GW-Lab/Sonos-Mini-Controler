Imports System.Net

Public Class Sound
   ReadOnly sonosBase As SonosAPIBase

   Public Sub New(sonosBase As SonosAPIBase)
      Me.sonosBase = sonosBase
   End Sub

   ' Bass level -10 t/m +10
   Public Property Bass(ip As IPAddress) As Integer
      Get
         Dim uri = $"http://{ip}:1400/MediaRenderer/RenderingControl/Control"
         Dim soapAction = "urn:schemas-upnp-org:service:RenderingControl:1#GetBass"
         Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                              <s:Body>
                                 <u:GetBass xmlns:u="urn:schemas-upnp-org:service:RenderingControl:1">
                                    <InstanceID>0</InstanceID>
                                    <Channel>Master</Channel>
                                 </u:GetBass>
                              </s:Body>
                           </s:Envelope>
         Return CInt(XDocument.Parse(Me.sonosBase.WebRequest(uri, soapAction, soapMessage)).Root.Value)
      End Get
      Set(value As Integer)
         Dim uri = $"http://{ip}:1400/MediaRenderer/RenderingControl/Control"
         Dim soapAction = "urn:schemas-upnp-org:service:RenderingControl:1#SetBass"
         Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                              <s:Body>
                                 <u:SetBass xmlns:u="urn:schemas-upnp-org:service:RenderingControl:1">
                                    <InstanceID>0</InstanceID>
                                    <DesiredBass><%= If(value < -10, -10, If(value > 10, 10, value)) %></DesiredBass>
                                 </u:SetBass>
                              </s:Body>
                           </s:Envelope>

         Me.sonosBase.WebRequest(uri, soapAction, soapMessage)
      End Set
   End Property

   Public Property CrossFade(ip As IPAddress) As Integer
      Get
         Dim uri = $"http://{ip}:1400/MediaRenderer/AVTransport/Control"
         Dim soapAction = "urn:schemas-upnp-org:service:AVTransport:1#GetCrossfadeMode"
         Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                              <s:Body>
                                 <u:CrossfadeMode xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
                                    <InstanceID>0</InstanceID>
                                 </u:CrossfadeMode>
                              </s:Body>
                           </s:Envelope>
         Return CInt(XDocument.Parse(Me.sonosBase.WebRequest(uri, soapAction, soapMessage)).Root.Value)
      End Get
      Set(value As Integer)
         Dim uri = $"http://{ip}:1400/MediaRenderer/AVTransport/Control"
         Dim soapAction = "urn:schemas-upnp-org:service:AVTransport:1#SetCrossfadeMode"
         Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                              <s:Body>
                                 <u:SetCrossfadeMode xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
                                    <InstanceID>0</InstanceID>
                                    <CrossfadeMode><%= If(value < 0, 0, If(value > 1, 1, value)) %></CrossfadeMode>
                                 </u:SetCrossfadeMode>
                              </s:Body>
                           </s:Envelope>

         Me.sonosBase.WebRequest(uri, soapAction, soapMessage)
      End Set
   End Property

   Public Property Mute(ip As IPAddress) As Boolean
      Get
         Dim uri = $"http://{ip}:1400/MediaRenderer/RenderingControl/Control"
         Dim soapAction = "urn:schemas-upnp-org:service:RenderingControl:1#GetMute"
         Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                              <s:Body>
                                 <u:GetMute xmlns:u="urn:schemas-upnp-org:service:RenderingControl:1">
                                    <InstanceID>0</InstanceID>
                                    <Channel>Master</Channel>
                                 </u:GetMute>
                              </s:Body>
                           </s:Envelope>
         Try
            Return If(CInt(XDocument.Parse(Me.sonosBase.WebRequest(uri, soapAction, soapMessage)).Root.Value) = 1, True, False)
         Catch ex As Exception
            Return True
         End Try
      End Get
      Set(value As Boolean)
         Dim uri = $"http://{ip}:1400/MediaRenderer/RenderingControl/Control"
         Dim soapAction = "urn:schemas-upnp-org:service:RenderingControl:1#SetMute"
         Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                              <s:Body>
                                 <u:SetMute xmlns:u="urn:schemas-upnp-org:service:RenderingControl:1">
                                    <InstanceID>0</InstanceID>
                                    <Channel>Master</Channel>
                                    <DesiredMute><%= If(value, "1", "0") %></DesiredMute>
                                 </u:SetMute>
                              </s:Body>
                           </s:Envelope>

         Me.sonosBase.WebRequest(uri, soapAction, soapMessage)
      End Set
   End Property

   Public Property GroupMute(ip As IPAddress) As Boolean
      Get
         Dim uri = $"http://{ip}:1400/MediaRenderer/GroupRenderingControl/Control"
         Dim soapAction = "urn:schemas-upnp-org:service:GroupRenderingControl:1#GetGroupMute"
         Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                              <s:Body>
                                 <u:GetGroupMute xmlns:u="urn:schemas-upnp-org:service:GroupRenderingControl:1">
                                    <InstanceID>0</InstanceID>
                                    <Channel>Master</Channel>
                                 </u:GetGroupMute>
                              </s:Body>
                           </s:Envelope>
         Try
            Return If(CInt(XDocument.Parse(Me.sonosBase.WebRequest(uri, soapAction, soapMessage)).Root.Value) = 1, True, False)
         Catch ex As Exception
            Return True
         End Try
      End Get
      Set(value As Boolean)
         Dim uri = $"http://{ip}:1400/MediaRenderer/GroupRenderingControl/Control"
         Dim soapAction = "urn:schemas-upnp-org:service:GroupRenderingControl:1#SetGroupMute"
         Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                              <s:Body>
                                 <u:SetGroupMute xmlns:u="urn:schemas-upnp-org:service:GroupRenderingControl:1">
                                    <InstanceID>0</InstanceID>
                                    <Channel>Master</Channel>
                                    <DesiredMute><%= If(value, "1", "0") %></DesiredMute>
                                 </u:SetGroupMute>
                              </s:Body>
                           </s:Envelope>

         Me.sonosBase.WebRequest(uri, soapAction, soapMessage)
      End Set
   End Property

   Public Property Loudness(ip As IPAddress) As Integer
      Get
         Dim uri = $"http://{ip}:1400/MediaRenderer/RenderingControl/Control"
         Dim soapAction = "urn:schemas-upnp-org:service:RenderingControl:1#GetLoudness"
         Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                              <s:Body>
                                 <u:GetLoudness xmlns:u="urn:schemas-upnp-org:service:RenderingControl:1">
                                    <InstanceID>0</InstanceID>
                                    <Channel>Master</Channel>
                                 </u:GetLoudness>
                              </s:Body>
                           </s:Envelope>
         Return CInt(XDocument.Parse(Me.sonosBase.WebRequest(uri, soapAction, soapMessage)).Root.Value)
      End Get
      Set(value As Integer)
         Dim uri = $"http://{ip}:1400/MediaRenderer/RenderingControl/Control"
         Dim soapAction = "urn:schemas-upnp-org:service:RenderingControl:1#SetLoudness"
         Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                              <s:Body>
                                 <u:SetLoudness xmlns:u="urn:schemas-upnp-org:service:RenderingControl:1">
                                    <InstanceID>0</InstanceID>
                                    <Channel>Master</Channel>
                                    <DesiredLoudness><%= If(value < 0, 0, If(value > 1, 1, value)) %></DesiredLoudness>
                                 </u:SetLoudness>
                              </s:Body>
                           </s:Envelope>

         Me.sonosBase.WebRequest(uri, soapAction, soapMessage)
      End Set
   End Property

   Public Function Pause(ip As IPAddress) As String
      Dim uri = $"http://{ip}:1400/MediaRenderer/AVTransport/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:AVTransport:1#Pause"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:Pause xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
                                 <InstanceID>0</InstanceID>
                                 <Speed>1</Speed>
                              </u:Pause>
                           </s:Body>
                        </s:Envelope>

      Return Me.sonosBase.WebRequest(uri, soapAction, soapMessage)
   End Function

   Public Function Play(ip As IPAddress) As String
      Dim uri = $"http://{ip}:1400/MediaRenderer/AVTransport/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:AVTransport:1#Play"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:Play xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
                                 <InstanceID>0</InstanceID>
                                 <Speed>1</Speed>
                              </u:Play>
                           </s:Body>
                        </s:Envelope>

      Return Me.sonosBase.WebRequest(uri, soapAction, soapMessage)
   End Function

   Public Property PlayMode(ip As IPAddress) As PlayMode
      Get
         Dim uri = $"http://{ip}:1400/MediaRenderer/AVTransport/Control"
         Dim soapAction = "urn:schemas-upnp-org:service:AVTransport:1#GetTransportSettings"
         Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                              <s:Body>
                                 <u:GetTransportSettings xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
                                    <InstanceID>0</InstanceID>
                                 </u:GetTransportSettings>
                              </s:Body>
                           </s:Envelope>
         Try
            Return DirectCast([Enum].Parse(GetType(PlayMode), XDocument.Parse(Me.sonosBase.WebRequest(uri, soapAction, soapMessage)).Descendants("PlayMode").Value), PlayMode)
         Catch ex As Exception
            Return PlayMode.NORMAL
         End Try
      End Get
      Set(value As PlayMode)
         Dim uri = $"http://{ip}:1400/MediaRenderer/AVTransport/Control"
         Dim soapAction = "urn:schemas-upnp-org:service:AVTransport:1#SetPlayMode"
         Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                              <s:Body>
                                 <u:SetPlayMode xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
                                    <InstanceID>0</InstanceID>
                                    <NewPlayMode><%= value.ToString.ToUpper %></NewPlayMode>
                                 </u:SetPlayMode>
                              </s:Body>
                           </s:Envelope>

         Me.sonosBase.WebRequest(uri, soapAction, soapMessage)
      End Set
   End Property

   Public Function [Stop](ip As IPAddress) As String
      Dim uri = $"http://{ip}:1400/MediaRenderer/AVTransport/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:AVTransport:1#Stop"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:Stop xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
                                 <InstanceID>0</InstanceID>
                                 <Speed>1</Speed>
                              </u:Stop>
                           </s:Body>
                        </s:Envelope>

      Return Me.sonosBase.WebRequest(uri, soapAction, soapMessage)
   End Function

   Public Function SetReleativeVolume(ip As IPAddress, adjustment As Integer) As Integer
      Dim uri = $"http://{ip}:1400/MediaRenderer/RenderingControl/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:RenderingControl:1#SetRelativeVolume"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:SetRelativeVolume xmlns:u="urn:schemas-upnp-org:service:RenderingControl:1">
                                 <InstanceID>0</InstanceID>
                                 <Channel>Master</Channel>
                                 <Adjustment><%= adjustment %></Adjustment>
                              </u:SetRelativeVolume>
                           </s:Body>
                        </s:Envelope>

      Return CInt(XDocument.Parse(Me.sonosBase.WebRequest(uri, soapAction, soapMessage)).Root.Value)
   End Function

   Public Function SetReleativeGroupVolume(ip As IPAddress, adjustment As Integer) As Integer
      Dim uri = $"http://{ip}:1400/MediaRenderer/GroupRenderingControl/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:RenderingControl:1#SetRelativeGroupVolume"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:SetRelativeGroupVolume xmlns:u="urn:schemas-upnp-org:service:GroupRenderingControl:1">
                                 <InstanceID>0</InstanceID>
                                 <Adjustment><%= adjustment %></Adjustment>
                              </u:SetRelativeGroupVolume>
                           </s:Body>
                        </s:Envelope>

      Return CInt(XDocument.Parse(Me.sonosBase.WebRequest(uri, soapAction, soapMessage)).Root.Value)
   End Function

   Public Property GroupVolume(ip As IPAddress) As Integer
      Get
         Dim uri = $"http://{ip}:1400/MediaRenderer/GroupRenderingControl/Control"
         Dim soapAction = "urn:schemas-upnp-org:service:GroupRenderingControl:1#GetGroupVolume"
         Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                              <s:Body>
                                 <u:GetGroupVolume xmlns:u="urn:schemas-upnp-org:service:GroupRenderingControl:1">
                                    <InstanceID>0</InstanceID>
                                 </u:GetGroupVolume>
                              </s:Body>
                           </s:Envelope>
         Try

            Return CInt(XDocument.Parse(Me.sonosBase.WebRequest(uri, soapAction, soapMessage)).Root.Value)
         Catch ex As Exception
            Return 0
         End Try
      End Get
      Set(value As Integer)
         value = If(value < 0, 0, If(value > 100, 100, value))
         Dim uri = $"http://{ip}:1400/MediaRenderer/GroupRenderingControl/Control"
         Dim soapAction = "urn:schemas-upnp-org:service:GroupRenderingControl:1#SetGroupVolume"
         Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                              <s:Body>
                                 <u:SetGroupVolume xmlns:u="urn:schemas-upnp-org:service:GroupRenderingControl:1">
                                    <InstanceID>0</InstanceID>
                                    <DesiredVolume><%= value %></DesiredVolume>
                                 </u:SetGroupVolume>
                              </s:Body>
                           </s:Envelope>
         Me.sonosBase.WebRequest(uri, soapAction, soapMessage)
      End Set
   End Property

   Public Property Volume(ip As IPAddress) As Integer
      Get
         Dim uri = $"http://{ip}:1400/MediaRenderer/RenderingControl/Control"
         Dim soapAction = "urn:schemas-upnp-org:service:RenderingControl:1#GetVolume"
         Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                              <s:Body>
                                 <u:GetVolume xmlns:u="urn:schemas-upnp-org:service:RenderingControl:1">
                                    <InstanceID>0</InstanceID>
                                    <Channel>Master</Channel>
                                 </u:GetVolume>
                              </s:Body>
                           </s:Envelope>
         Try

            Return CInt(XDocument.Parse(Me.sonosBase.WebRequest(uri, soapAction, soapMessage)).Root.Value)
         Catch ex As Exception
            Return 0
         End Try
      End Get
      Set(value As Integer)
         value = If(value < 0, 0, If(value > 100, 100, value))
         Dim uri = $"http://{ip}:1400/MediaRenderer/RenderingControl/Control"
         Dim soapAction = "urn:schemas-upnp-org:service:RenderingControl:1#SetVolume"
         Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                              <s:Body>
                                 <u:SetVolume xmlns:u="urn:schemas-upnp-org:service:RenderingControl:1">
                                    <InstanceID>0</InstanceID>
                                    <Channel>Master</Channel>
                                    <DesiredVolume><%= value %></DesiredVolume>
                                 </u:SetVolume>
                              </s:Body>
                           </s:Envelope>

         Me.sonosBase.WebRequest(uri, soapAction, soapMessage)
      End Set
   End Property
End Class
