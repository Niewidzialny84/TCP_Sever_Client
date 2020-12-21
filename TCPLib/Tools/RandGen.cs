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

        private Random random;

        /// <summary>
        /// Constructor.
        /// </summary>
        public RandGen() {
            random = new Random();
        }

        /// <summary>
        /// This function allows to get a random integer.
        /// </summary>
        /// <param name="min">Minimal value.</param>
        /// <param name="max">Maximal value.</param>
        /// <returns>The random integer.</returns>
        public int randInt(int min, int max)
        {
          return random.Next(min, max + 1);
        }
    }
}
