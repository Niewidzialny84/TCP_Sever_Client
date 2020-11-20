using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPLib.PacketLib
{
    /// <summary>
    /// Class for received packets.
    /// </summary>
    public class PacketRecive : Packet
    {
        /// <summary>
        /// Creates a instance of a received packed containing all important informations.
        /// </summary>
        /// <param name="buffer">Buffer containing received message.</param>
        /// <param name="size">Packet size.</param>
        public PacketRecive(byte[] buffer, int size) : base()
        {
            this.message = Encoding.ASCII.GetString(buffer).Trim(trim);
            this.size = size;
            this.buffer = buffer;
        }
    }
}
