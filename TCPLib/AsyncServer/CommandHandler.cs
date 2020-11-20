using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPLib.PacketLib;
using TCPLib.Response;

namespace TCPLib.AsyncServer
{
    public class CommandHandler : Handler<String>
    {
        private UserContainer users;
        private ResponseContainer responses;


        public CommandHandler() : base()
        {
            responses = new ResponseContainer();
            users = new UserContainer();
        }

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
                            case "useradd":
                                users.AddUserToDB(args[1], args[2]);
                                return new PacketSend("Added");
                            case "usermod":
                                users.UpdateUserInDB(args[1], args[2]);
                                return new PacketSend("Modified");

                        }
                        break;
                    default:
                        return new PacketSend("Invalid data");
                }
            }
            String response = responses.GetResponse(s);
            return new PacketSend(response);
        }

        public Packet CheckLogin(String[] parsed)
        {
            if (parsed.Length <= 1)
            {
                return new PacketSend("Invalid credentials");
            }
            else
            {
                if (users.CheckCredentials(parsed[0], parsed[1]))
                {
                    PacketLogin packet = new PacketLogin("Succesfully logged in");
                    packet.Success = true;
                    return packet;
                }
                else
                {
                    return new PacketSend("Invalid login");
                }
            }
        }
    }
}
