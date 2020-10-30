using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPLib
{
    public class Client 
    {
        private IPAddress address;
        private int port;
        private bool active;
        private int Buffer_size = 1024;

        public Client(IPAddress address, int port)
        {
            this.address = address;
            this.port = port;
            active = false;
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
                Packet send = new Packet(input);
                stream.Write(send.Buffer, 0, send.Size);
                int messageSize = stream.Read(buffer, 0, Buffer_size);
                Packet recive = new Packet(buffer, messageSize);
                System.Console.Write(recive.Message);
                while(true)
                {
                    input = System.Console.ReadLine();
                    send = new Packet(input);
                    stream.Write(send.Buffer, 0, send.Size);
                    messageSize = stream.Read(buffer, 0, Buffer_size);
                    recive = new Packet(buffer, messageSize);
                    System.Console.Write(recive.Message);
                }
            } catch (Exception e)
            {
                System.Console.Write(e.Message);
            }
        }
    }
}
