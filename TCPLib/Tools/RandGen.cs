using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPLib.Tools
{
    class RandGen
    {
        public RandGen() { }

        public int randInt(int min, int max)
        {
          Random random = new Random();
          return random.Next(min, max + 1);

        }
    }
}
