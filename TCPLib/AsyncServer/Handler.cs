using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPLib.PacketLib;

namespace TCPLib.AsyncServer
{
   /// <summary>
   /// Abstract command handler can be inherited.
   /// </summary>
   /// <typeparam name="T"></typeparam>
    public abstract class Handler<T>
    {
        public Handler() { }

        public abstract Packet Handle(T s);
        public abstract Packet HandleNormal(T s);
    }
}
