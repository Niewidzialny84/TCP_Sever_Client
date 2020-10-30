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
        private String login;
        private String password;

        public User(String login, String password)
        {
            this.login = login;
            this.password = password;
        }

        /// <summary>
        /// Login getter and setter
        /// </summary>
        public String Login { get => login; set => login = value; }

        /// <summary>
        /// Password getter and setter
        /// </summary>
        public String Password { get => password; set => password = value; }
    }
}
