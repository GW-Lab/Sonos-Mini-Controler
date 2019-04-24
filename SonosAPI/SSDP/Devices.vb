' Program..: Devices.vb
' Author...: G. Wassink
' Design...: 
' Date.....: 11/03/2019 Last revised:11/03/2019
' Notice...: Copyright 1994-2016 All Rights Reserved
' Notes....: VB16.0.2 .NET Framework 4.8
' Files....: None
' Programs.:
' Reserved.: 

Public Class Devices : Inherits Dictionary(Of String, Device)  ' Key is IPAddress
End Class

Public Class Device
   Public [Type] As Device_Type
   Public IP As Net.IPAddress
   Public isCoordinator As Boolean = False
   Public isZonePlayer As Boolean = False
   Public LocationXML As String = ""
   Public MAC As String
   Public Name As String = ""
   Public Server As String = ""
   Public ST As String = ""
   Public XHoushold As String = ""

   Private _USN As String

   Public Enum Device_Type
      Beam
      Boost
      Connect
      PlayOne
      Play1
      Play5
      PlayBar
      SoundBar
      [Sub]
      Unknown
   End Enum

   Public Property USN As String
      Get
         Return Me._USN
      End Get
      Set(value As String)
         Me._USN = value
         Me.MAC = value.Substring(17, 12)
      End Set
   End Property
End Class
