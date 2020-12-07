using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPLib.Tools;
using System.Text.RegularExpressions;

namespace TCPLib.Response
{
    /// <summary>
    /// Random integer responses.
    /// </summary>
    public class NumResponse
    {
        /// <summary>
        /// Needs a instance of the RandGen object.
        /// </summary>
        RandGen randGen = new RandGen();

        /// <summary>
        /// Constructor.
        /// </summary>
        public NumResponse() { }

        /// <summary>
        /// Returns a response containing a random value.
        /// </summary>
        /// <param name="minS">Minimal value.</param>
        /// <param name="maxS">Maximal value.</param>
        /// <returns>Response string.</returns>
        public string getRand(string minS, string maxS)
        {
            if(Regex.IsMatch(minS, @"^\d+$") && Regex.IsMatch(maxS, @"^\d+$"))
            {
                return randGen.randInt(int.Parse(minS), int.Parse(maxS)).ToString();
            }
            return "Sry, wrong input";
        }
    }
}
