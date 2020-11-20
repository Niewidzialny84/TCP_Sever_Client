using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPLib.PacketLib
{
    public class PacketRecive : Packet
    {
        public PacketRecive(byte[] buffer, int size) : base()
        {
            this.message = Encoding.ASCII.GetString(buffer).Trim(trim);
            this.size = size;
            this.buffer = buffer;
        }
    }
}
