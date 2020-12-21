using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Client
{
    /// <summary>
    /// This program is used to start the client.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Creates and starts a client. Connects to IP 127.0.0.1:40000.
        /// </summary>
        /// <param name="args">Unused</param>
        static void Main(string[] args)
        {
            TCPLib.Client client = new TCPLib.ConsoleClient(IPAddress.Parse("127.0.0.1"), 40000);
            client.Start();
            System.Console.ReadKey();
        }
    }
}
