using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPLib
{
    public class AsyncComServer : AsyncAbstractServer
    {
        public AsyncComServer(IPAddress ipAddress,int port) : base(ipAddress,port)
        {
            Server = new TcpListener(ipAddress, port);
        }

        public override async Task Start()
        {
            Server.Start();

            while(true)
            {
                TcpClient client = await Server.AcceptTcpClientAsync();

                byte[] buffer = new byte[Buffer_size];
                await client.GetStream().ReadAsync(buffer, 0, buffer.Length).ContinueWith(
                    async(t) =>
                    {
                        int i = t.Result;
                        while(true)
                        {
                            await client.GetStream().WriteAsync(buffer,0,i);
                            i = await client.GetStream().ReadAsync(buffer, 0, buffer.Length);
                        }
                    }
                );
            }
        }
    }
}
