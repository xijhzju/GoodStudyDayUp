using System;
using System.Net;
using System.Net.Sockets;

namespace ChatRoomServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Running");
            var ipAdress = new IPAddress(new byte[] { 127, 0, 0, 1 });
            TcpListener chatServer = new TcpListener(ipAdress, 8500);
            Console.WriteLine("Start Listen");
            chatServer.Start();
            int clientCount = 0;
           while (true)
            {
                TcpClient remoteClient = chatServer.AcceptTcpClient();
                clientCount++;
                Console.WriteLine($"Client {clientCount} Conneted: Server-{remoteClient.Client.LocalEndPoint}\tClient-{remoteClient.Client.RemoteEndPoint}" );
               // ConsoleKey key = Console.ReadKey(true).Key;
                // if (key == ConsoleKey.Q)
                // {
                //     return;
                // }
            } 
        }
    }
}
