using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPLib
{
    public abstract class Container<T>
    {
        protected List<T> list;
        public Container()
        {
            list = new List<T>();
        }

        /// <summary>
        /// Adds a new respons to the list.
        /// </summary>
        /// <param name="response">The response with input and output.</param>
        public void Add(T value)
        {
            list.Add(value);
        }

        /// <summary>
        /// Prints a list.
        /// </summary>
        public void Print()
        {
            foreach (T x in list)
            {
                System.Console.WriteLine(x);
            }
        }
    }
}
