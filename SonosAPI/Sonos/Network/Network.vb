Imports System.Net
Imports System.Net.NetworkInformation

Public Class Network
   Public Shared Function GetLocalIPAddress(Optional networkInterfaceType As NetworkInterfaceType = NetworkInterfaceType.Ethernet) As IPAddress
      Dim ipAddress As IPAddress = Nothing

      For Each ni In NetworkInterface.GetAllNetworkInterfaces
         If ni.NetworkInterfaceType = networkInterfaceType AndAlso
            ni.OperationalStatus = OperationalStatus.Up AndAlso
            Not ni.NetworkInterfaceType = NetworkInterfaceType.Loopback Then

            For Each ip In ni.GetIPProperties.UnicastAddresses
               If ip.Address.AddressFamily = Sockets.AddressFamily.InterNetwork Then
                  ipAddress = ip.Address
                  Exit For                                                          ' if IPAddress found then exit
               End If
            Next
         End If
      Next

      Return If(ipAddress, New IPAddress({127, 0, 0, 1}))
   End Function
End Class
