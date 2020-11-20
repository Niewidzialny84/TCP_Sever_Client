using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace TCPLib
{
    /// <summary>
    /// Used to perform operations on the users data base as well as users.
    /// </summary>
    public class UserContainer
    {
        /// <summary>
        /// A list containing all given users.
        /// </summary>
        private List<User> users;

        /// <summary>
        /// Creates a instance of the user container.
        /// </summary>
        public UserContainer()
        {
            users = new List<User>();
            LoadFromDB();
        }

        /// <summary>
        /// Adds user to the container.
        /// </summary>
        /// <param name="user">A user that will be added to a container.</param>
        public void Add(User user)
        {
            users.Add(user);
        }

        /// <summary>
        /// Removes a user with the given login.
        /// </summary>
        /// <param name="login">User login.</param>
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

        /// <summary>
        /// Updates the password of all users with the given login.
        /// </summary>
        /// <param name="login">User login.</param>
        /// <param name="password">New user password.</param>
        public void Update(String login, String password)
        {
            if (FindUser(login) == true)
            {
              
                foreach (User u in users)
                {
                    if (u.Login.Equals(login))
                    {
                        u.Password = password;
                    }
                }
            }
        }

        /// <summary>
        /// Checks if a user with the given login and password already exists.
        /// </summary>
        /// <param name="login">User login.</param>
        /// <param name="password">User password.</param>
        /// <returns>If user with login and password was found.</returns>
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

        /// <summary>
        /// Prints a list of all users.
        /// </summary>
        public void PrintUsers()
        {
            foreach (User x in users)
            {
                System.Console.WriteLine(x);
            }
        }

        /// <summary>
        /// Loads all users from the data base to use them in later operations.
        /// </summary>
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
        
        /// <summary>
        /// Adds a new user to the data base.
        /// </summary>
        /// <param name="login">User login.</param>
        /// <param name="password">User password.</param>
        public void AddUserToDB(String login, String password)
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

        /// <summary>
        /// Deletes a user with the given login.
        /// </summary>
        /// <param name="login">User login to be removed.</param>
        public void RemoveUserFromDB(String login)
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
                        String request = "DELETE FROM Users WHERE login = @login";
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

        /// <summary>
        /// Updates user data in the data base.
        /// </summary>
        /// <param name="login">User login.</param>
        /// <param name="password">User password.</param>
        public void UpdateUserInDB(String login, String password)
        {
            if (FindUser(login) == true)
            {

                Update(login, password);

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "(local)";
                builder.InitialCatalog = "Communication";
                builder.IntegratedSecurity = true;
                try
                {
                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        String request = "UPDATE Users SET password = @password WHERE login = @login";
                        using (SqlCommand command = new SqlCommand(request, connection))
                        {
                            connection.Open();
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

        /// <summary>
        /// Used to print all users line by line.
        /// </summary>
        /// <returns>List of users as text.</returns>
        public override string ToString()
        {
            String s = "";
            foreach(User u in users)
            {
                s += u.ToString() + "\r\n";
            }
            return s;
        }

        /// <summary>
        /// Searches if user exists.
        /// </summary>
        /// <param name="login">User login to search for.</param>
        /// <returns>Returns if user exists.</returns>
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
