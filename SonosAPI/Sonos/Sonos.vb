' Program..: Sonos.vb
' Author...: G. Wassink
' Design...: 
' Date.....: 11/03/2019 Last revised:11/03/2019
' Notice...: Copyright 1994-2016 All Rights Reserved
' Notes....: VB16.0.2 .NET Framework 4.8
' Files....: None
' Programs.:
' Reserved.: 

Imports System.IO

Public Class Sonos : Inherits SonosAPI
   Public NASTracks As String() = {}               ' Declare the NASTracks array with 0 elements

   Public Sub New(configuration As Configuration)
      MyBase.New(configuration)

      Try
         If Me.Configuration.NAS_UNC <> "" Then
            Using uncTmp = New UNC(Me.Configuration.NAS_UNC, New Net.NetworkCredential(Me.Configuration.Account, Me.Configuration.Password))
               Me.NASTracks = Directory.GetFiles(uncTmp.remoteName)
            End Using
         End If
      Catch ex As Exception
      End Try
   End Sub
End Class
