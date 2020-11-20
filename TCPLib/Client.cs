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
    public class Client 
    {
        private IPAddress address;
        private int port;
        private int Buffer_size = 1024;

        public Client(IPAddress address, int port)
        {
            this.address = address;
            this.port = port;
        }

        public void Start()
        {
            TcpClient client = new TcpClient();
            client.Connect(address, port);
            byte[] buffer = new byte[Buffer_size];
            NetworkStream stream = client.GetStream();
            try
            {
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
