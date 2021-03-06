﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPLib.PacketLib;
using TCPLib.Response;

namespace TCPLib.AsyncServer
{
    /// <summary>
    /// Command handler used by the communications server.
    /// </summary>
    public class CommandHandler : Handler<String>
    {
        /// <summary>
        /// Contains users.
        /// </summary>
        private UserContainer users;
        /// <summary>
        /// Contains responses.
        /// </summary>
        private ResponseContainer responses;
        /// <summary>
        /// Used to respond with random numbers.
        /// </summary>
        NumResponse numResponse = new NumResponse();

        /// <summary>
        /// Creates a instance of the command handler.
        /// </summary>
        public CommandHandler() : base()
        {
            responses = new ResponseContainer();
            users = new UserContainer();
        }

        /// <summary>
        /// Funktion used to handle client requests. Admin only.
        /// </summary>
        /// <param name="s">Received message.</param>
        /// <returns>Response packet.</returns>
        public override Packet Handle(String s)
        {
            String[] args = s.Split(' ');
            if (args[0] != null)
            {
                switch (args.Length)
                {
                    case 1:
                        switch (args[0])
                        {
                            case "getall":
                                return new PacketSend(users.ToString());
                        }
                        break;
                    case 2:
                        switch (args[0])
                        {
                            case "userdel":
                                users.RemoveUserFromDB(args[1]);
                                return new PacketSend("Removed");
                        }
                        break;
                    case 3:
                        switch (args[0])
                        {                     
                            case "usermod":
                                users.UpdateUserInDB(args[1], args[2]);
                                return new PacketSend("Modified");

                            case "random":
                                return new PacketSend(numResponse.getRand(args[1],args[2]));
                        }
                        break;
                    case 4:
                        switch (args[0])
                        {
                            case "useradd":
                                users.AddUserToDB(args[1], args[2], Convert.ToBoolean(args[3]));
                                return new PacketSend("Added");
                        }
                        break;
                    default:
                        break;
                }
            }
            String response = responses.GetResponse(s);
            return new PacketSend(response);
        }

        /// <summary>
        /// Funktion used to handle client requests. No admin.
        /// </summary>
        /// <param name="s">Received message.</param>
        /// <param name="login">The login of the active user.</param>
        /// <returns>Response packet.</returns>
        public override Packet HandleNormal(String s, String login)
        {
            String[] args = s.Split(' ');
            if (args[0] != null)
            {
                switch (args.Length)
                {
                    case 3:
                        if (args[0].Equals("usermod") && args[1].Equals(login))
                        {
                            users.UpdateUserInDB(args[1], args[2]);
                            return new PacketSend("Modified");
                        }
                        else if (args[0].Equals("random"))
                        {
                            return new PacketSend(numResponse.getRand(args[1], args[2]));
                        }
                        break;                  
                    default:
                        break;
                }
            }
            String response = responses.GetResponse(s);
            return new PacketSend(response);
        }

        /// <summary>
        /// Funktion used to validate user login and password and allow him to sign in.
        /// </summary>
        /// <param name="parsed">Array of parsed words. Should contain login and password.</param>
        /// <returns>Response packet.</returns>
        public Packet CheckLogin(String[] parsed)
        {
            if (parsed.Length <= 1)
            {
                return new PacketSend("NAK");
            }
            else
            {
                if (users.CheckCredentials(parsed[0], parsed[1]))
                {
                    PacketLogin packet = new PacketLogin("ACK");
                    packet.Success = true;
                    return packet;
                }
                else
                {
                    return new PacketSend("NAK");
                }
            }
        }
    }
}
