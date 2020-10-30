using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TCPLib.Server server = new TCPLib.Server(IPAddress.Parse("127.0.0.1"), 40000);
            server.Start();
        }
    }
}
