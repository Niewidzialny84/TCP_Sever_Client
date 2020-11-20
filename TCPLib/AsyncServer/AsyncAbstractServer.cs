using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPLib.AsyncServer
{
    /// <summary>
    /// Abstract server can be inherited.
    /// </summary>
    public abstract class AsyncAbstractServer
    {
        #region Fields
        IPAddress iPAddress;
        int port;
        int buffer_size = 1024;
        bool running;
        TcpListener server;
        #endregion
        #region Properties
        /// <summary>
        /// This property gives access to the IP address of a server instance. Property can't be changed when the Server is running. 
        /// </summary>
        public IPAddress IPAddress { get => iPAddress; set { if (!running) iPAddress = value; else throw new Exception("Cannot change IP while running"); } }

        /// <summary>
        /// This property gives access to the port of a server instance. Property can't be changed when the Server is running. Setting invalid port numbers will cause an exception. 
        /// </summary>
        public int Port
        {
            get => port; set
            {
                int tmp = port;
                if (!running) port = value; else throw new Exception("Cannot change port while running");
                if (!checkPort())
                {
                    port = tmp;
                    throw new Exception("Invalid port number");
                }
            }
        }

        /// <summary>
        /// This property gives access to the buffer size of a server instance. Property can't be changed when the Server is running. Setting invalid size numbers will cause an exception. 
        /// </summary>
        public int Buffer_size
        {
            get => buffer_size; set
            {
                if (value < 0 || value > 1024 * 1024 * 64) throw new Exception("Invalid packet size");
                if (!running) buffer_size = value; else throw new Exception("Cannot change packet size while runnning");
            }
        }
        /// <summary>
        /// Gives access to running variable that informe if instance is running
        /// </summary>
        protected bool Running { get => running; set => running = value; }
        protected TcpListener Server { get => server; set => server = value; }
        #endregion
        #region Constructors
        /// <summary>
        /// A default constructor. It doesn't start the server. Invalid port numbers will thrown an exception.
        /// </summary>
        /// <param name="IP">IP address of the server instance.</param>
        /// <param name="port">Port number of the server instance.</param>
        public AsyncAbstractServer(IPAddress IP, int port)
        {
            running = false;
            IPAddress = IP;
            Port = port;
            if (!checkPort())
            {
                Port = 8000;
                throw new Exception("Invalid port. Setting to default 8000");
            }
        }
        #endregion
        #region Functions
        /// <summary>
        /// This function will return false if Port is set to a value lower than 1024 or higher than 49151.
        /// </summary>
        /// <returns>An information wether the set Port value is valid.</returns>
        protected bool checkPort()
        {
            if (port < 1024 || port > 49151) return false;
            return true;
        }

        /// <summary>
        /// This function fires off the default server behaviour. It interrupts the program.
        /// </summary>
        public abstract Task Start();
        #endregion
    }
}
