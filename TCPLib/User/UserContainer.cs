using System;
using System.Collections.Generic;
using System.Data;
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

        public void Remove(String login)
        {
            if(FindUser(login) == true)
            {
                User tmp = new User();

                foreach (User u in users)
                {
                    if(u.Login.Equals(login))
                    {
                        tmp = u;
                    }
                }

                users.Remove(tmp);
            }
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

        private void AddUserToDB(String login, String password)
        {
           if(FindUser(login) == false)
           {
                User user = new User(login, password);
                int userID = users.Count + 1;

                Add(user);
              
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "(local)";
                builder.InitialCatalog = "Communication";
                builder.IntegratedSecurity = true;
                try
                {
                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        String request = "INSERT INTO Users(UserID, Login, Password) VALUES(@id, @login, @password)";               
                        using (SqlCommand command = new SqlCommand(request, connection))
                        {
                            connection.Open();
                            command.Parameters.Add("@id", SqlDbType.Int).Value = userID;
                            command.Parameters.Add("@login", SqlDbType.VarChar, 255).Value = login;
                            command.Parameters.Add("@password", SqlDbType.VarChar, 255).Value = password;
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
            }
        }

        private void RemoveUserFromDB(String login)
        {
            if (FindUser(login) == true)
            {
                        
                Remove(login);

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "(local)";
                builder.InitialCatalog = "Communication";
                builder.IntegratedSecurity = true;
                try
                {
                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        String request = "DELETE FROM Users WHERE login= @login";
                        using (SqlCommand command = new SqlCommand(request, connection))
                        {
                            connection.Open();
                            command.Parameters.Add("@login", SqlDbType.VarChar, 255).Value = login;
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
            }
        }

        private Boolean FindUser(String login)
        {
            foreach(User u in users)
            {
                if(u.Login.Equals(login))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
