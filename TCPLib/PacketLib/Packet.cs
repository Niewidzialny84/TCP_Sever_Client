using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPLib.PacketLib
{ 
    public abstract class Packet
    {
        protected int size;
        protected String message;
        protected byte[] buffer;
        protected char[] trim = { (char)0x0 , '\n' , '\r' };

        public int Size { get => size; }
        public String Message { get => message; }
        public byte[] Buffer { get => buffer; }

        public Packet() { }
    }
}
