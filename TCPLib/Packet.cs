using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPLib
{ 
    public class Packet
    {
        private int size;
        private String message;
        private byte[] buffer;

        public int Size { get => size; }
        public String Message { get => message; }
        public byte[] Buffer { get => buffer; }

        public Packet(byte[] buffer, int size)
        {
            this.message = Encoding.ASCII.GetString(buffer);
            this.size = size;
            this.buffer = buffer;
        }

        public Packet(String message)
        {
            this.message = message+"\n\r";
            this.size = this.message.Length;
            this.buffer = Encoding.ASCII.GetBytes(this.message);
        }
    }
}
