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
    /// <summary>
    /// Basic client service used to interact with the server.
    /// </summary>
    public class Client 
    {
        /// <summary>
        /// Server IP adress to connect to.
        /// </summary>
        private IPAddress address;
        /// <summary>
        /// Server port number to connecto to.
        /// </summary>
        private int port;
        /// <summary>
        /// Maximal buffer size for received messages.
        /// </summary>
        private int Buffer_size = 1024;

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

        /// <summary>
        /// Method used to run all client functions.
        /// </summary>
        public void Start()
        {
            TcpClient client = new TcpClient();
            client.Connect(address, port);
            byte[] buffer = new byte[Buffer_size];
            NetworkStream stream = client.GetStream();
            try
            {
                //Login to server.
                System.Console.Write("Enter login credentials separated by space (eq. [admin admin])");
                string input = System.Console.ReadLine();
                Packet send = new PacketSend(input);
                stream.Write(send.Buffer, 0, send.Size);
                int messageSize = stream.Read(buffer, 0, Buffer_size);
                Packet recive = new PacketRecive(buffer, messageSize);
                System.Console.WriteLine(recive.Message);

                while(true)
                {
                    buffer = new byte[Buffer_size];
                    input = System.Console.ReadLine();
                    send = new PacketSend(input);
                    stream.Write(send.Buffer, 0, send.Size);
                    messageSize = stream.Read(buffer, 0, Buffer_size);
                    recive = new PacketRecive(buffer, messageSize);
                    System.Console.WriteLine(recive.Message);
                }
            } catch (Exception e)
            {
                System.Console.Write(e.Message);
            }
        }
    }
}
