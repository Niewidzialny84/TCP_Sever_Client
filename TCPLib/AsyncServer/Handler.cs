using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPLib.PacketLib;

namespace TCPLib.AsyncServer
{
   
    public abstract class Handler<T>
    {
        public Handler() { }

        public abstract Packet Handle(T s);
    }
}
