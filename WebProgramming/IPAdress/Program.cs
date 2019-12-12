using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
namespace LearnIPAdress
{
    class Program
    {
        static void Main(string[] args)
        {
            string hostname = Dns.GetHostName();
            Console.WriteLine(hostname);

            var ipHostEntry = Dns.GetHostEntry(hostname);
            var ipAddressList = ipHostEntry.AddressList;// 包含了IPv6和IPv4地址
            for (int i = 0; i < ipAddressList.Length; i++)
            {
                IPAddress ip = ipAddressList[i];
                Console.WriteLine(ip.ToString());
                Console.WriteLine(ip.AddressFamily.ToString());
            }
            Console.ReadKey();
        }
    }
}
