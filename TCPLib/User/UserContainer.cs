﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace TCPLib
{
    public class UserContainer
    {
        private List<User> users;

        public UserContainer()
        {
            users = new List<User>();
            LoadFromDB();
        }

        /// <summary>
        /// Adds user to a container
        /// </summary>
        /// <param name="user">A user that will be added to a container</param>
        public void Add(User user)
        {
            users.Add(user);
        }

        public bool CheckCredentials(String login,String password)
        {
            foreach(User x in users)
            {
                if(x.Login.Equals(login) && x.Password.Equals(password)) {
                    return true;
                }
            }
            return false;
        }

        public void PrintUsers()
        {
            foreach (User x in users)
            {
                System.Console.WriteLine(x);
            }
        }

        private void LoadFromDB()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "(local)";
            builder.InitialCatalog = "Communication";
            builder.IntegratedSecurity = true;
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    String request = "SELECT Login,Password FROM Users";

                    using (SqlCommand command = new SqlCommand(request,connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                users.Add(new User(reader.GetString(0), reader.GetString(1)));
                            }
                        }
                    }
                }
            } catch (Exception e)
            {
                System.Console.Write(e.Message);
            }
        }
    }
}