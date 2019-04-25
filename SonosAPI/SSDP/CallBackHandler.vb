Imports System.Net
Imports System.Text
Imports System.Threading

' HttpListener Access Denied
' netsh http add urlacl url=http://192.168.2.31:3445/notify/ user=WS-01\gijsb
' netsh http delete urlacl url=http://192.168.2.31:3445/notify/ 
' netsh http show urlacl

Public Class CallBackHandler
   ReadOnly stopEvent As ManualResetEvent = New ManualResetEvent(False)

   Public Event Data_Recieved(msg As String, remoteIP As IPAddress)

   Public Sub New(eventURI As IEnumerable(Of String))
      Dim listener = New HttpListener()

      For Each uri In eventURI
         listener.Prefixes.Add(uri)
      Next

      listener.Start()
      ThreadPool.QueueUserWorkItem(AddressOf Listen, New HttpListenerCallbackState(listener))
   End Sub

   Public Sub StopListening()
      Me.stopEvent.Set()
   End Sub

   Private Sub Listen(state As Object)
      Dim callbackState = DirectCast(state, HttpListenerCallbackState)

      While callbackState.listener.IsListening
         callbackState.listener.BeginGetContext(New AsyncCallback(AddressOf ListenerCallback), callbackState)

         If WaitHandle.WaitAny(New WaitHandle() {callbackState.listenForNextRequest, Me.stopEvent}) = 1 Then
            callbackState.listener.Stop()
            Exit While
         End If
      End While
   End Sub

   Private Sub ListenerCallback(ar As IAsyncResult)
      Dim callbackState = DirectCast(ar.AsyncState, HttpListenerCallbackState)

      Try
         Dim context = callbackState.listener.EndGetContext(ar)

         If context IsNot Nothing Then
            If context.Request.HasEntityBody Then
               Using sr = New IO.StreamReader(context.Request.InputStream, context.Request.ContentEncoding)
                  RaiseEvent Data_Recieved(sr.ReadToEnd(), context.Request.RemoteEndPoint.Address)
               End Using
            End If

            Using response = context.Response
               Dim buffer = Encoding.UTF8.GetBytes("Ok")
               response.OutputStream.Write(buffer, 0, buffer.Length)
            End Using
         End If
      Catch ex As Exception
         Return
      Finally
         callbackState.listenForNextRequest.Set()
      End Try
   End Sub

   Private Class HttpListenerCallbackState
      Public ReadOnly listener As HttpListener
      Public ReadOnly listenForNextRequest As AutoResetEvent

      Public Sub New(listener As HttpListener)
         If listener IsNot Nothing Then
            Me.listener = listener
            Me.listenForNextRequest = New AutoResetEvent(False)
         Else
            Throw New ArgumentNullException("listener")
         End If
      End Sub
   End Class
End Class


