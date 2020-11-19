using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPLib
{
    public class ActiveUser : User
    {
        private bool logged;
        private int id;

        public ActiveUser(String username, String password) : base(username,password)
        {
            logged = true;
        }

        /// <summary>
        /// Get/Set current state of the user
        /// </summary>
        public bool Logged { get => logged; set => logged = value; }

        /// <summary>
        /// Get/Set session id of the active user
        /// </summary>
        public int Id { get => id; set => id = value; }
    }
}
