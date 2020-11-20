using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPLib.PacketLib
{
    public class PacketLogin : PacketSend
    {
        protected bool success;
        public bool Success { get => success; set => success = value; }

        public PacketLogin(String message) : base(message)
        {
            
        }
    }
}
