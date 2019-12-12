using System;
using System.Net;
using System.Net.Sockets;

namespace ChatRoomClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Client is running");
            TcpClient client = new TcpClient();

            try
            {
                client.Connect("localhost", 8500);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            var lEP = client.Client.LocalEndPoint;
            // 显示的是IPV6的地址，::ffff:127.0.0.1
            // 怎么让他显示IPV4的呢？
            Console.WriteLine($"Connected! Client-{lEP}\tServer-{client.Client.RemoteEndPoint}");

            Console.ReadKey();
        }
    }
}
