using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPLib.Response
{
    public class Response
    {
        private String input;
        private String output;

        public Response(string input, string output)
        {
            this.input = input;
            this.output = output;
        }

        public String Input{ get => input; set => input = value; }
        public String Output{ get => output; set => output = value; }

        public override string ToString()
        {
            return "input=[" + input + "] output=[" + output + "]";
        }
    }
}
