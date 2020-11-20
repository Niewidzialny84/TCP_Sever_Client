using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPLib
{
    /// <summary>
    /// Expanded user with logged in status and id.
    /// </summary>
    public class ActiveUser : User
    {
        /// <summary>
        /// State of the user.
        /// </summary>
        private bool logged;
        /// <summary>
        /// The unique ID the user has.
        /// </summary>
        private int id;

        /// <summary>
        /// Creates a instance of the active user.
        /// </summary>
        /// <param name="username">User login.</param>
        /// <param name="password">User password.</param>
        public ActiveUser(String username, String password) : base(username,password)
        {
            logged = true;
        }

        /// <summary>
        /// Get/Set current state of the user.
        /// </summary>
        public bool Logged { get => logged; set => logged = value; }

        /// <summary>
        /// Get/Set session id of the active user.
        /// </summary>
        public int Id { get => id; set => id = value; }
    }
}
