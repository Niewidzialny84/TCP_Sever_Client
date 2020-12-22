using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TCPLib.PacketLib;

namespace TCPLib
{
    public abstract class Client 
    {
        /// <summary>
        /// Server IP adress to connect to.
        /// </summary>
        protected IPAddress address;
        /// <summary>
        /// Server port number to connecto to.
        /// </summary>
        protected int port;
        /// <summary>
        /// Maximal buffer size for received messages.
        /// </summary>
        protected int Buffer_size = 1024;

        /// <summary>
        /// Creates a instance of client.
        /// </summary>
        /// <param name="address">IP adress of the server to connect to.</param>
        /// <param name="port">Port number of the server to connect to.</param>
        public Client(IPAddress address, int port)
        {
            this.address = address;
            this.port = port;
        }

        public abstract void Start();
    }
}
