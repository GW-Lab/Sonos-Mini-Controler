Public Class Favorites : Inherits List(Of Favorite)
End Class

Public Class Favorite
   Public AlbumArtURI As String = ""
   Public ClassObject As String = ""
   Public Description As String = ""
   Public Ordinal As Integer = 0
   Public Title As String = ""
   Public Type As String = ""
   Public RemoteURI As String = ""
   Public StreamURI As String = ""

   Public Overrides Function ToString() As String
      Return Me.Title
   End Function
End Class
