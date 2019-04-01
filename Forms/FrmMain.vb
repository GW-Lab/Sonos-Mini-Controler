' Program..: FrmMain.vb
' Author...: G. Wassink
' Design...: 
' Date.....: 11/03/2019 Last revised:11/03/2019
' Notice...: Copyright 1994-2016 All Rights Reserved
' Notes....: VB 16.0 RC4 .Net Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: 

Imports System.Linq
Imports GWSonos
Imports GWSonos.Device

Public Class FrmMain
   Private ReadOnly configuration As Configuration
   Private WithEvents Sonos As GWSonos.Sonos

   Public Sub New()
      InitializeComponent() ' This call is required by the designer.
      ' Add any initialization after the InitializeComponent() call.

      Me.configuration = New Configuration With {.X = My.Settings.X,
                                                 .Y = My.Settings.Y,
                                                 .Account = My.Settings.Account,
                                                 .Password = My.Settings.Password,
                                                 .NAS_UNC = My.Settings.NAS_UNC,
                                                 .Interval = My.Settings.Interval,
                                                 .TopMost = My.Settings.TopMost}
      Sonos = New GWSonos.Sonos(Me.configuration)
   End Sub

   Private Sub CmbRooms_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbRooms.SelectedIndexChanged
      If Sonos.Rooms(CmbRooms.Text).Frm Is Nothing Then
         Sonos.Rooms(CmbRooms.Text).Frm = New FrmSonos(CmbRooms.Text, Me, Sonos)
         Sonos.Rooms(CmbRooms.Text).Frm.Show()

         AddHandler Sonos.Rooms(CmbRooms.Text).Frm.FormClosed, AddressOf FrmClosed
      End If
   End Sub

   Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
      Location = New Point(My.Settings.X, My.Settings.Y)
   End Sub

   Private Sub FrmMain_Closed(sender As Object, e As EventArgs) Handles Me.Closed
      My.Settings.X = Location.X
      My.Settings.Y = Location.Y

      My.Settings.Account = Me.configuration.Account
      My.Settings.Password = Me.configuration.Password
      My.Settings.NAS_UNC = Me.configuration.NAS_UNC
      My.Settings.Interval = Me.configuration.Interval
      My.Settings.TopMost = Me.configuration.TopMost
   End Sub

   Private Sub FrmClosed(sender As Object, e As EventArgs)
      RemoveHandler DirectCast(sender, FrmSonos).FormClosed, AddressOf FrmClosed
      Sonos.Rooms(DirectCast(sender, FrmSonos).TxtSelectedRoom.Text).Frm = Nothing
   End Sub

   Private Sub Sonos_Search_Completed(roomCount As Integer) Handles Sonos.Search_Completed
      Invoke(Sub()
                For Each room In Sonos.Rooms.devices.Values.Where(Function(x) x.isZonePlayer AndAlso x.Type <> Device_Type.Boost)
                   CmbRooms.Items.Add(room.Name)
                Next

                If CmbRooms.Items.Count > 0 Then
                   CmbRooms.SelectedIndex = 0
                   Text = $"Select a room"
                Else
                   Text = $"Sonos not found!!!"
                End If
             End Sub)
   End Sub
End Class