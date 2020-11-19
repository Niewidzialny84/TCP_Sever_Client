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
        private ResponseContainer responses;

        public CommandHandler()
        {
            responses = new ResponseContainer();
        }

        public Packet handle(String s)
        {
            String response = responses.GetResponse(s);
            return new Packet(response);
        }
    }
}
