' Program..: IPBox.vb
' Author...: G. Wassink
' Design...: 
' Date.....: 11/03/2019 Last revised:11/03/2019
' Notice...: Copyright 1994-2016 All Rights Reserved
' Notes....: VB 16.0 RC4 .Net Framework 4.7.2
' Files....: None
' Programs.:
' Reserved.: 

Imports System.Net
Imports System.Windows.Forms

Public Class IPBox
   Public Shadows Property Borderstyle As BorderStyle
      Get
         Return TxtIP1.BorderStyle
      End Get
      Set(value As BorderStyle)
         TxtIP1.BorderStyle = value
         TxtIP2.BorderStyle = value
         TxtIP3.BorderStyle = value
         TxtIP4.BorderStyle = value
      End Set
   End Property

   Public Property IPAdress As IPAddress
      Get
         Try
            Return IPAddress.Parse(Text)
         Catch ex As Exception
            Return New IPAddress({192, 168, 2, 1})
         End Try
      End Get
      Set(value As IPAddress)
         If value Is Nothing Then
            TxtIP1.Text = ""
            TxtIP2.Text = ""
            TxtIP3.Text = ""
            TxtIP4.Text = ""
         Else
            Dim Octets() = value.GetAddressBytes ' value.Split("."c)
            TxtIP1.Text = Octets(0).ToString
            TxtIP2.Text = Octets(1).ToString
            TxtIP3.Text = Octets(2).ToString
            TxtIP4.Text = Octets(3).ToString
         End If
      End Set
   End Property

   Public Overrides Property Text() As String
      Get
         Return $"{TxtIP1.Text}.{TxtIP2.Text}.{TxtIP3.Text}.{TxtIP4.Text}"
      End Get
      Set(value As String)
         If value = "" Then
            TxtIP1.Text = ""
            TxtIP2.Text = ""
            TxtIP3.Text = ""
            TxtIP4.Text = ""
         ElseIf System.Text.RegularExpressions.Regex.IsMatch(value, "((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)") Then
            Dim Octets() As String = value.Split("."c)
            TxtIP1.Text = Octets(0)
            TxtIP2.Text = Octets(1)
            TxtIP3.Text = Octets(2)
            TxtIP4.Text = Octets(3)
         Else
            MessageBox.Show("Invalid IP format in clipboard.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ' Throw New FormatException("Invalid IP format.")
         End If
      End Set
   End Property

   Private Sub TxtIP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtIP1.KeyPress, TxtIP2.KeyPress, TxtIP3.KeyPress, TxtIP4.KeyPress
      Dim txtBox = DirectCast(sender, TextBox)

      Select Case Char.GetUnicodeCategory(e.KeyChar)
         Case Globalization.UnicodeCategory.Control, Globalization.UnicodeCategory.DecimalDigitNumber
         Case Else
            e.Handled = True
      End Select

      If e.KeyChar = "." Then
         SelectNextControl(txtBox, True, True, False, False)
      ElseIf e.KeyChar = Environment.NewLine AndAlso txtBox.Text = "" Then
         SelectNextControl(txtBox, False, True, False, False)
      ElseIf e.KeyChar = Convert.ToChar(8) AndAlso txtBox.Text = "" Then
         SelectNextControl(txtBox, True, True, False, False)
      End If
   End Sub

   Private Sub TxtIP_LostFocus(sender As Object, e As EventArgs) Handles TxtIP1.LostFocus, TxtIP2.LostFocus, TxtIP3.LostFocus, TxtIP4.LostFocus
      Dim txtBox = DirectCast(sender, TextBox)

      If txtBox.Text = "" Then
         Return
      ElseIf Convert.ToInt32(txtBox.Text) > 255 Then
         MessageBox.Show("IP octet range:  0..255", "Invalid IP", MessageBoxButtons.OK, MessageBoxIcon.Error)
         txtBox.Focus()
      End If
   End Sub

   Private Sub TxtIP_MousDown(sender As Object, e As EventArgs) Handles TxtIP1.MouseDown, TxtIP2.MouseDown, TxtIP3.MouseDown, TxtIP4.MouseDown
      With DirectCast(sender, TextBox)
         .SelectAll()
         .Focus()
      End With
   End Sub
   Private Sub TxtIP_TextChanged(sender As Object, e As EventArgs) Handles TxtIP1.TextChanged, TxtIP2.TextChanged, TxtIP3.TextChanged, TxtIP4.TextChanged
      Dim txtBox = DirectCast(sender, TextBox)

      If Not Integer.TryParse(txtBox.Text, Nothing) Then ' This handles bad copy&past
         txtBox.Text = ""
         Return
      End If

      If txtBox.SelectionStart = 3 Then 'If we type 3 Digits, Select the next controll
         SelectNextControl(txtBox, True, True, False, False)
      End If
   End Sub
End Class
