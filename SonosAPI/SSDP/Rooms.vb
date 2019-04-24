' Program..: Rooms.vb
' Author...: G. Wassink
' Design...: 
' Date.....: 11/03/2019 Last revised:11/03/2019
' Notice...: Copyright 1994-2016 All Rights Reserved
' Notes....: VB16.0.2 .NET Framework 4.8
' Files....: None
' Programs.:
' Reserved.: 

Public Class Rooms : Inherits Dictionary(Of String, Room)
   Public devices As New Devices
End Class

Public Class Room : Inherits Devices
   Public Name As String
   Public Frm As FrmSonos
End Class