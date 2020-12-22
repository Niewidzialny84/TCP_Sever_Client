using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TCPLib.PacketLib;

namespace TCPLib
{
    /// <summary>
    /// Method used to run all client functions.
    /// </summary>
    public class GuiClient : Client
    {
        private NetworkStream stream;
        TcpClient client = new TcpClient();
        /// <summary>
        /// Creates a instance of client.
        /// </summary>
        /// <param name="address">IP adress of the server to connect to.</param>
        /// <param name="port">Port number of the server to connect to.</param>
        public GuiClient(IPAddress address, int port) : base(address,port)
        {

        }

        /// <summary>
        /// Method used to run all client functions.
        /// </summary>
        public override void Start()
        {

            client.Connect(address, port);
            byte[] buffer = new byte[Buffer_size];
            stream = client.GetStream();
            try
            {

            }
            catch (Exception e)
            {
                System.Console.Write(e.Message);
            }
        }
        public bool LoginUser(String login, String passwd)
        {
            Packet send = new PacketSend(login + " " + passwd);
            if (stream == null)
            {

                return false;
            }
            else
            {
                stream.Write(send.Buffer, 0, send.Size);
                byte[] buffer = new byte[Buffer_size];
                int messageSize = stream.Read(buffer, 0, Buffer_size);
                Packet recive = new PacketRecive(buffer, messageSize);
                System.Console.WriteLine(recive.Message);
                if (Equals(recive.Message, "ACK"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


        }
        public String Communicate(String msg)
        {
            Packet send = new PacketSend(msg);
            stream.Write(send.Buffer, 0, send.Size);
            byte[] buffer = new byte[Buffer_size];
            int messageSize = stream.Read(buffer, 0, Buffer_size);
            Packet recive = new PacketRecive(buffer, messageSize);
            return recive.Message;
        }
    }
}
