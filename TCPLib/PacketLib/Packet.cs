using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPLib.PacketLib
{ 
    /// <summary>
    /// Abstract packet can be inherited.
    /// </summary>
    public abstract class Packet
    {
        protected int size;
        protected String message;
        protected byte[] buffer;
        protected char[] trim = { (char)0x0 , '\n' , '\r' };

        /// <summary>
        /// Size getter.
        /// </summary>
        public int Size { get => size; }
        /// <summary>
        /// Message getter.
        /// </summary>
        public String Message { get => message; }
        /// <summary>
        /// Buffer getter.
        /// </summary>
        public byte[] Buffer { get => buffer; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Packet() { }
    }
}
