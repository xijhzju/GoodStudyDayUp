using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace SocketSample
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress localIP = new IPAddress(new byte[] { 127, 0, 0, 1 });
            IPEndPoint localIPEP = new IPEndPoint(localIP, 8500);
            Socket mySocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            mySocket.Bind(localIPEP);
        
            Console.WriteLine(mySocket.LocalEndPoint);
            mySocket.Close();
            Console.ReadKey();
        }
    }
}
