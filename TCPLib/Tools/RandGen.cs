using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPLib.Tools
{
    /// <summary>
    /// Can be used to generate random integers.
    /// </summary>
    public class RandGen
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public RandGen() { }

        /// <summary>
        /// This function allows to get a random integer.
        /// </summary>
        /// <param name="min">Minimal value.</param>
        /// <param name="max">Maximal value.</param>
        /// <returns>The random integer.</returns>
        public int randInt(int min, int max)
        {
          Random random = new Random();
          return random.Next(min, max + 1);
        }
    }
}
