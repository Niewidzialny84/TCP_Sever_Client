using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using TCPLib.Response;

namespace TCPLib 
{
    public class Server : TCPAsyncEcho
    {
        private UserContainer users;
        private ResponseContainer responses;
        private bool logged;

        public Server(IPAddress IP, int port) : base(IP, port)
        {
            users = new UserContainer();
            responses = new ResponseContainer();
            logged = false;
        }

        protected override void BeginDataTransmission(NetworkStream stream)
        {
            stream.ReadTimeout = 10000;
            byte[] buffer = new byte[Buffer_size];
            while (true)
            {
                try
                {
                    int message_size = stream.Read(buffer, 0, Buffer_size);
                    Packet packet = new Packet(buffer, message_size);
                    if (!logged)
                    {
                        String[] parsed = packet.Message.Split(' ');
                        if(parsed.Length <= 1)
                        {
                            packet = new Packet("Invalid credentials");
                            stream.Write(packet.Buffer, 0, packet.Size);

                        } else
                        {
                            if(users.CheckCredentials(parsed[0], parsed[1]))
                            {
                                logged = true;
                                packet = new Packet("Succesfully logged in");
                                stream.Write(packet.Buffer, 0, packet.Size);
                            } else
                            {
                                packet = new Packet("Invalid login");
                                stream.Write(packet.Buffer, 0, packet.Size);
                            }
                        }
                    } else
                    {
                        String response = responses.GetResponse(packet.Message);
                        packet = new Packet(response);
                        stream.Write(packet.Buffer, 0, packet.Size);
                    }

                }
                catch (IOException e)
                {
                    break;
                }
            }
        }
    }
}
