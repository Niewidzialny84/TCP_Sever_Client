using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPLib.PacketLib
{
    /// <summary>
    /// A packet used to send messages.
    /// </summary>
    public class PacketSend : Packet
    {
        /// <summary>
        /// Creates a instance of a packet which is to be send.
        /// </summary>
        /// <param name="message">Message to be send.</param>
        public PacketSend(String message)
        {
            this.message = message + "\n\r";
            this.size = this.message.Length;
            this.buffer = Encoding.ASCII.GetBytes(this.message);
        }
    }
}
