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
        public void Create(T value)  // This is something like Create in CRUD 
        {
            list.Add(value);
        }

        /// <summary>
        /// Prints a list.
        /// </summary>
        public void Read() // This is something like Read in CRUD 
        {
            foreach (T x in list)
            {
                System.Console.WriteLine(x);
            }
        }

        public virtual void LoadFromDB() { }

        public virtual void Delete(String arg) { }  // This is something like Delete in CRUD 

        public virtual void Update(String arg1, String arg2) { }


    }
}
