using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCPLib
{
    public abstract class Container<T>
    {
        protected List<T> contentList;
        public Container()
        {
            contentList = new List<T>();
        }

        /// <summary>
        /// Adds a new respons to the list.
        /// </summary>
        /// <param name="response">The response with input and output.</param> 
        public void Create(T value) 
        {
            contentList.Add(value);
        }

        /// <summary>
        /// Prints a list.
        /// </summary>
        public void Read() 
        {
            foreach (T x in contentList)
            {
                System.Console.WriteLine(x);
            }
        }

        public virtual void LoadFromDB() { }

        public virtual void Delete(String arg) { } 

        public virtual void Update(String arg1, String arg2) { }

        public virtual bool Find(String arg) { return true; }

    }
}
