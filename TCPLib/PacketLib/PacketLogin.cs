using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPLib.PacketLib
{
    /// <summary>
    /// Packet used to verify login request.
    /// </summary>
    public class PacketLogin : PacketSend
    {
        protected bool success;
        public bool Success { get => success; set => success = value; }

        /// <summary>
        /// Creates a login packet containing the send login and password.
        /// </summary>
        /// <param name="message">Contained message (login and password).</param>
        public PacketLogin(String message) : base(message)
        {
            
        }
    }
}
