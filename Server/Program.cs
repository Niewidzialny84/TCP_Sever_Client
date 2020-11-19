using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TCPLib.AsyncServer;

namespace Server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //TCPLib.Server server = new TCPLib.Server(IPAddress.Parse("127.0.0.1"), 40000);
            AsyncComServer server = new AsyncComServer(IPAddress.Parse("127.0.0.1"), 40000);
            await server.Start();
        }
    }
}
