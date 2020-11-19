using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //TCPLib.Server server = new TCPLib.Server(IPAddress.Parse("127.0.0.1"), 40000);
            TCPLib.AsyncComServer server = new TCPLib.AsyncComServer(IPAddress.Parse("127.0.0.1"), 40000);
            await server.Start();
        }
    }
}
