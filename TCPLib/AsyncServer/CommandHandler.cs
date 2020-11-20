using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPLib.Response;

namespace TCPLib.AsyncServer
{
    public class CommandHandler
    {
        private UserContainer users;
        private ResponseContainer responses;


        public CommandHandler()
        {
            responses = new ResponseContainer();
            users = new UserContainer();
        }

        public Packet Handle(String s)
        {
            String[] args = s.Split(' ');
            if(args[0] != null)
            {
                switch (args[0])
                {
                    case "useradd":
                        if (args.Length == 3)
                        {
                            users.AddUserToDB(args[1], args[2]);
                            return new Packet.Packet("Added");
                        } else
                        {
                            return new Packet("Invalid data");
                        }
                    case "userdel":
                        if(args.Length == 2)
                        {
                            users.RemoveUserFromDB(args[1]);
                            return new Packet("Removed");
                        } else
                        {
                            return new Packet("Invalid data");
                        }
                    case "usermod":
                        if (args.Length == 3)
                        {
                            users.UpdateUserInDB(args[1], args[2]);
                            return new Packet("Modified");
                        }
                        else
                        {
                            return new Packet("Invalid data");
                        }
                    case "getall":
                        return new Packet(users.ToString());
                }
            } 

            String response = responses.GetResponse(s);
            return new Packet(response);
        }

        public Packet CheckLogin(String[] parsed)
        {
            if (parsed.Length <= 1)
            {
                return new Packet("Invalid credentials");
            }
            else
            {
                if (users.CheckCredentials(parsed[0], parsed[1]))
                {
                    Packet packet = new Packet("Succesfully logged in");
                    packet.Success = true;
                    return packet;
                }
                else
                {
                    return new Packet("Invalid login");
                }
            }
        }
    }
}
