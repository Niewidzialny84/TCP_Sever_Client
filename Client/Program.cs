using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TCPLib.Client client = new TCPLib.Client(IPAddress.Parse("127.0.0.1"), 40000);
            client.Start();
        }
    }
}
