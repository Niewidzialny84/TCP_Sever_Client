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
        private char[] trim = { (char)0x0 , '\n' , '\r' };
        private bool success;

        public int Size { get => size; }
        public String Message { get => message; }
        public byte[] Buffer { get => buffer; }
        public bool Success { get => success; set => success = value; }

        public Packet(byte[] buffer, int size)
        {
            this.message = Encoding.ASCII.GetString(buffer).Trim(trim);
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
