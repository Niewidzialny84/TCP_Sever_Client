using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TCPLib.AsyncServer;

namespace Server
{
    /// <summary>
    /// This program is used to start the server.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Creates a server running on IP 127.0.0.1:4000 and starts him asynchronously.
        /// </summary>
        /// <param name="args">Unused</param>
        /// <returns></returns>
        static async Task Main(string[] args)
        {
            //TCPLib.Server server = new TCPLib.Server(IPAddress.Parse("127.0.0.1"), 40000); //Version from previous lab.
            AsyncComServer server = new AsyncComServer(IPAddress.Parse("127.0.0.1"), 40000);
            await server.Start();
        }
    }
}
