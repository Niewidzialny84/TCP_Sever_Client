using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TCPLib.PacketLib;
using TCPLib.Response;

namespace TCPLib.AsyncServer
{
    /// <summary>
    /// Asynchronous server for communication.
    /// </summary>
    public class AsyncComServer : AsyncAbstractServer
    {
        /// <summary>
        /// Instance of the command handler.
        /// </summary>
        private CommandHandler handler;

        /// <summary>
        /// User container used to verify user permissions.
        /// </summary>
        private UserContainer userCont;

        private ActiveUserContainer activeUserContainer;

        /// <summary>
        /// Creates a instance of the server.
        /// </summary>
        /// <param name="ipAddress">Server IP adress.</param>
        /// <param name="port">Server port number.</param>
        public AsyncComServer(IPAddress ipAddress,int port) : base(ipAddress,port)
        {
            Server = new TcpListener(ipAddress, port);
            handler = new CommandHandler();
            userCont = new UserContainer();
            activeUserContainer = new ActiveUserContainer();
        }

        /// <summary>
        /// Funktion to accept and handle clients.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Allows a client to sign in as a user and further interact with the server.
        /// </summary>
        /// <param name="client">The connected client to interact with.</param>
        /// <returns></returns>
        private async Task handleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            ActiveUser user = null;
            try
            {
                while (client.Connected)
                {
                    byte[] buffer = new byte[Buffer_size];
                    int i = await stream.ReadAsync(buffer, 0, buffer.Length);

                    Packet packet = new PacketRecive(buffer, i);

                    if (user == null)
                    {
                        String[] parsed = packet.Message.Split(' ');
                        packet = handler.CheckLogin(parsed);
                        userCont = new UserContainer();

                        if (packet is PacketLogin)
                        {
                            if (!activeUserContainer.Find(parsed[0]))
                            {
                                user = new ActiveUser(parsed[0], parsed[1], userCont.GetPermission(parsed[0]));
                                activeUserContainer.Create(user);
                            }
                            else
                            {
                                packet = new PacketSend("NAK");
                            }
                        }

                    }
                    else if (user != null)
                    {
                        //String response = responses.GetResponse(packet.Message);
                        //StringBuilder s = new StringBuilder("");
                        //StringWriter writer = new StringWriter(s);
                        //await writer.WriteAsync(packet.Message);
                        //System.Console.Write(s.ToString());
                        //packet = new Packet(response);

                        if (user.Admin == true)
                        {
                            packet = handler.Handle(packet.Message);
                        }
                        else
                        {
                            packet = handler.HandleNormal(packet.Message, user.Login);
                        }

                    }
                    await stream.WriteAsync(packet.Buffer, 0, packet.Size);
                }            
            }
            catch(Exception e)
            {
                
            }
            finally
            {
                activeUserContainer.Delete(user.Login);
            }
        }
    }
}
