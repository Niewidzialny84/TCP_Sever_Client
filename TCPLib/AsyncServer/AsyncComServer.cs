using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TCPLib.Response;

namespace TCPLib.AsyncServer
{
    public class AsyncComServer : AsyncAbstractServer
    {
        private CommandHandler handler;

        public AsyncComServer(IPAddress ipAddress,int port) : base(ipAddress,port)
        {
            Server = new TcpListener(ipAddress, port);
            handler = new CommandHandler();
        }

        public override async Task Start()
        {
            Server.Start();

            while(true)
            {
                await Server.AcceptTcpClientAsync().ContinueWith(
                    async (t) =>
                    {
                        TcpClient client = t.Result;
                        await handleClient(client);
                    }
                );
            }
        }

        private async Task handleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            ActiveUser user = null;
            while (client.Connected)
            {
                byte[] buffer = new byte[Buffer_size];
                int i = await stream.ReadAsync(buffer, 0, buffer.Length);

                Packet packet = new Packet(buffer, i);

                if (user == null)
                {
                    String[] parsed = packet.Message.Split(' ');
                    packet = handler.CheckLogin(parsed);

                    if (packet.Success)
                    {
                        user = new ActiveUser(parsed[0], parsed[1]);
                    }
                } else
                {
                    //String response = responses.GetResponse(packet.Message);
                    //StringBuilder s = new StringBuilder("");
                    //StringWriter writer = new StringWriter(s);
                    //await writer.WriteAsync(packet.Message);
                    //System.Console.Write(s.ToString());
                    //packet = new Packet(response);
                    packet = handler.Handle(packet.Message);
                }
                await stream.WriteAsync(packet.Buffer, 0, packet.Size);
            }
        }
    }
}
