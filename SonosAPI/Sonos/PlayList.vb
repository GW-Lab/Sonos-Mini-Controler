Imports System.Net

Public Class PlayList
   ReadOnly sonosBase As SonosAPIBase

   Public Sub New(sonosBase As SonosAPIBase)
      Me.sonosBase = sonosBase
   End Sub
   ' restart queue "TRACK_NR","1"    is the first track
   ' restart track "REL_TIME","00:00:00"
   Public Function Seek(ip As IPAddress, unit As Unit, Optional target As String = "00:00:00") As String
      Dim uri = $"http://{ip}:1400/MediaRenderer/AVTransport/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:AVTransport:1#Seek"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:Seek xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
                                 <InstanceID>0</InstanceID>
                                 <Unit><%= unit.ToString %></Unit>
                                 <Target><%= target %></Target>
                              </u:Seek>
                           </s:Body>
                        </s:Envelope>
      Return Me.sonosBase.WebRequest(uri, soapAction, soapMessage)
   End Function

   Public Function StartAutoPlay(ip As IPAddress, volume As Integer) As XDocument
      Dim uri = $"http://{ip}:1400/MediaServer/AVTransport/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:ContentDirectory:1#StartAutoplay"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:StartAutoplay xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
                                 <ObjectID>Q:0</ObjectID>
                                 <ProgramURI> file : ///jffs/settings/savedqueues.rsq#2</ProgramURI>
                                 <ProgramMetaData>
                                    <DIDL-Lite xmlns:dc="http://purl.org/dc/elements/1.1/" xmlns:upup="urn:schemas-upnp.org:metadata-1-0/upnp/" xmlns:r="urn:schemas-rinconnetworks-com:metadata-1-0/" xmlns="urn:schemas-upnp-org:metadata-1-0/DIDL-Lite/">
                                       <item id="SD:2" parentID="SD"/>
                                    </DIDL-Lite>
                                 </ProgramMetaData>
                                 <Volume><%= volume %></Volume>
                                 <IncludeLinkedZones>0</IncludeLinkedZones>
                                 <ResetVolumeAfter>8</ResetVolumeAfter>
                              </u:StartAutoplay>
                           </s:Body>
                        </s:Envelope>
      Try
         Return XDocument.Parse(Me.sonosBase.WebRequest(uri, soapAction, soapMessage))
      Catch ex As Exception
         Return XDocument.Parse("")
      End Try
   End Function

   Public Function TrackPositionInfo(ip As IPAddress) As Track
      Dim uri = $"http://{ip}:1400/MediaRenderer/AVTransport/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:AVTransport:1#GetPositionInfo"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:GetPositionInfo xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
                                 <InstanceID>0</InstanceID>
                              </u:GetPositionInfo>
                           </s:Body>
                        </s:Envelope>
      Try
         Return New Track(XDocument.Parse(Me.sonosBase.WebRequest(uri, soapAction, soapMessage)))
      Catch ex As Exception
         Return New Track()
      End Try
   End Function

   Public Function Brows(ip As IPAddress, startingIndex As Integer, count As Integer) As XDocument
      Dim uri = $"http://{ip}:1400/MediaServer/ContentDirectory/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:ContentDirectory:1#Browse"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:Browse xmlns:u="urn:schemas-upnp-org:service:ContentDirectory:1">
                                 <ObjectID>Q:0</ObjectID>
                                 <BrowseFlag>BrowseDirectChildren</BrowseFlag>
                                 <Filter></Filter>
                                 <StartingIndex><%= startingIndex %></StartingIndex>
                                 <RequestedCount><%= count %></RequestedCount>
                                 <SortCriteria></SortCriteria>
                              </u:Browse>
                           </s:Body>
                        </s:Envelope>
      Try
         Return XDocument.Parse(Me.sonosBase.WebRequest(uri, soapAction, soapMessage))
      Catch ex As Exception
         Return XDocument.Parse("")
      End Try
   End Function
   ' https://translate.google.com/translate_tts?ie=UTF-8&client=tw-ob&tl=en&q=Hello+World
   ' https://translate.google.com/translate_tts?ie=UTF-8&client=tw-ob&tl=nl&q=er+is+iemand+aan+de-deur

   '1=next (=1) or end queue (=0)
   Public Function AddTrack(ip As IPAddress, item As String, Optional [next] As Integer = 1) As String
      Dim uri = $"http://{ip}:1400/MediaRenderer/AVTransport/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:AVTransport:1#AddURIToQueue"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:AddURIToQueue xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
                                 <InstanceID>0</InstanceID>
                                 <EnqueuedURI><%= item %></EnqueuedURI>
                                 <DesiredFirstTrackNumberEnqueued>0</DesiredFirstTrackNumberEnqueued>
                                 <EnqueuedURIMetaData/>
                                 <EnqueueAsNext><%= [next] %></EnqueueAsNext>
                              </u:AddURIToQueue>
                           </s:Body>
                        </s:Envelope>

      ' <FirstTrackNumberEnqueued>1</FirstTrackNumberEnqueued> 
      ' <NumTracksAdded>1</NumTracksAdded> 
      ' <NewQueueLength>1</NewQueueLength> 
      ' <CurrentURIMetaData/></u:GetZoneGroupAttributes> Then

      Try
         Return Me.sonosBase.WebRequest(uri, soapAction, soapMessage)
      Catch ex As Exception
         Return ""
      End Try
   End Function

   Public Function Clear(ip As IPAddress) As String
      Dim uri = $"http://{ip}:1400/MediaRenderer/AVTransport/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:AVTransport:1#RemoveAllTracksFromQueue"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:RemoveAllTracksFromQueue xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
                                 <InstanceID>0</InstanceID>
                              </u:RemoveAllTracksFromQueue>
                           </s:Body>
                        </s:Envelope>
      Try
         Return Me.sonosBase.WebRequest(uri, soapAction, soapMessage)
      Catch ex As Exception
         Return ""
      End Try
   End Function

   Public Function RemoveTrack(ip As IPAddress, item As String) As String
      Dim uri = $"http://{ip}:1400/MediaRenderer/AVTransport/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:AVTransport:1#RemoveTrackFromQueue"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:RemoveTrackFromQueue xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
                                 <InstanceID>0</InstanceID>
                                 <ObjectID>Q:0/<%= item %></ObjectID>
                              </u:RemoveTrackFromQueue>
                           </s:Body>
                        </s:Envelope>
      Try
         Return Me.sonosBase.WebRequest(uri, soapAction, soapMessage)
      Catch ex As Exception
         Return ""
      End Try
   End Function

   Public Function NextTrack(ip As IPAddress) As String
      Dim uri = $"http://{ip}:1400/MediaRenderer/AVTransport/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:AVTransport:1#Next"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:Next xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
                                 <InstanceID>0</InstanceID>
                              </u:Next>
                           </s:Body>
                        </s:Envelope>

      Return Me.sonosBase.WebRequest(uri, soapAction, soapMessage)
   End Function

   Public Function PreviousTrack(ip As IPAddress) As String
      Dim uri = $"http://{ip}:1400/MediaRenderer/AVTransport/Control"
      Dim soapAction = "urn:schemas-upnp-org:service:AVTransport:1#Previous"
      Dim soapMessage = <s:Envelope xmlns:s="http://schemas.xmlsoap.org/soap/envelope/" s:encodingStyle="http://schemas.xmlsoap.org/soap/encoding/">
                           <s:Body>
                              <u:Previous xmlns:u="urn:schemas-upnp-org:service:AVTransport:1">
                                 <InstanceID>0</InstanceID>
                              </u:Previous>
                           </s:Body>
                        </s:Envelope>

      Return Me.sonosBase.WebRequest(uri, soapAction, soapMessage)
   End Function
End Class
