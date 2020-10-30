using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TCPLib.UserContainer userContainer = new TCPLib.UserContainer();
            userContainer.PrintUsers();
            System.Console.ReadKey();
        }
    }
}
