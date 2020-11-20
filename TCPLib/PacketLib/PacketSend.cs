using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPLib.PacketLib
{
    public class PacketSend : Packet
    {
        public PacketSend(String message)
        {
            this.message = message + "\n\r";
            this.size = this.message.Length;
            this.buffer = Encoding.ASCII.GetBytes(this.message);
        }
    }
}
