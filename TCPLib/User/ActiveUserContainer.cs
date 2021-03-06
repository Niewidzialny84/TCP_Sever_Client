﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace TCPLib
{
    class ActiveUserContainer : Container<ActiveUser>
    {
      
        public ActiveUserContainer() : base() { }
      
        public List<ActiveUser> ContentList { get => contentList; set => contentList = value; }

        public new void Create(ActiveUser activeUser)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    String request = "INSERT INTO ActiveUsers(Login, starttime) VALUES(@login, @starttime)";
                    using (SqlCommand command = new SqlCommand(request, connection))
                    {
                        connection.Open();
                        command.Parameters.Add("@login", SqlDbType.VarChar, 255).Value = activeUser.Login;
                        command.Parameters.Add("@starttime", SqlDbType.DateTime).Value = DateTime.Now;
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.Write(e.Message);
            }

            contentList.Add(activeUser);
        }

        public override bool Find(String login)
        {
            foreach(ActiveUser au in contentList)
            {
                if (au.Login.Equals(login))
                {
                    return true;
                }
            }
            return false;
        }

        public override void Delete(String login)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    String request = "UPDATE ActiveUsers SET endtime = @endtime WHERE (Login = @login AND endtime IS NULL)";
                    using (SqlCommand command = new SqlCommand(request, connection))
                    {
                        connection.Open();
                        command.Parameters.Add("@login", SqlDbType.VarChar, 255).Value = login;
                        command.Parameters.Add("@endtime", SqlDbType.DateTime).Value = DateTime.Now;
                        command.CommandType = CommandType.Text;
                        command.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.Write(e.Message);
            }

            contentList.RemoveAll(elem => elem.Login.Equals(login));
        }

        public String LastLogin(String login)
        {
            String r = "";
            if (Find(login) == true)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        String request = "SELECT TOP 1 starttime FROM ActiveUsers WHERE Login = @login AND endtime IS NOT NULL ORDER BY endtime desc;";

                        using (SqlCommand command = new SqlCommand(request, connection))
                        {
                            connection.Open();
                            command.Parameters.Add("@login", SqlDbType.VarChar, 255).Value = login;
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    r = reader.GetDateTime(0).ToShortDateString() + " " + reader.GetDateTime(0).ToShortTimeString();
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Console.Write(e.Message);
                }
            }
            return r;
        }
    }
}
