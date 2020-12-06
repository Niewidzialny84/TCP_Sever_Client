using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCPLib.Tools;
using System.Text.RegularExpressions;

namespace TCPLib.Response
{
    class NumResponse
    {
        RandGen randGen = new RandGen();

        public NumResponse() { }

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
