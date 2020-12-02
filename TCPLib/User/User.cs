using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TCPLib
{
    /// <summary>
    /// User class
    /// </summary>
    public class User
    {
        /// <summary>
        /// The login variable.
        /// </summary>
        private String login;
        /// <summary>
        /// The password variable.
        /// </summary>
        private String password;

        private bool admin;

        /// <summary>
        /// Creates a instance of user.
        /// </summary>
        /// <param name="login">User login.</param>
        /// <param name="password">User password.</param>
        public User(String login, String password, bool admin)
        {
            this.login = login;
            this.password = password;
            this.admin = admin;
        }

        /// <summary>
        /// Creates an empty instance of user.
        /// </summary>
        public User() { }

        /// <summary>
        /// Login getter and setter.
        /// </summary>
        public String Login { get => login; set => login = value; }

        /// <summary>
        /// Password getter and setter.
        /// </summary>
        public String Password { get => password; set => password = value; }

        public bool Admin { get => admin; set => admin = value; }

        /// <summary>
        /// Used to return user login and password.
        /// </summary>
        /// <returns>String containing login and password.</returns>
        public override string ToString()
        {
            return "login=" + login + " password=" + password + " is admin=" + admin;
        }
    }
}
