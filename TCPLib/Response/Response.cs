using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPLib.Response
{
    /// <summary>
    /// The response class used to respond to the client with some text.
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Input variable.
        /// </summary>
        private String input;
        /// <summary>
        /// Output variable.
        /// </summary>
        private String output;

        /// <summary>
        /// Creates a instance of response with input and appropriate output.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="output"></param>
        public Response(string input, string output)
        {
            this.input = input;
            this.output = output;
        }

        /// <summary>
        /// Input setter and getter.
        /// </summary>
        public String Input{ get => input; set => input = value; }
        /// <summary>
        /// Output setter and getter.
        /// </summary>
        public String Output{ get => output; set => output = value; }

        /// <summary>
        /// Returns a string containing both: input and output.
        /// </summary>
        /// <returns>String containing input and output.</returns>
        public override string ToString()
        {
            return "input=[" + input + "] output=[" + output + "]";
        }
    }
}
