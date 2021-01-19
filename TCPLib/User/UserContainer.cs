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
    public class UserContainer : Container<User>
    {
        /// <summary>
        /// Creates a instance of the user container.
        /// </summary>
        public UserContainer()
        {
            LoadFromDB();
        }

        /// <summary>
        /// Removes a user with the given login.
        /// </summary>
        /// <param name="login">User login.</param>
        public override void Delete(String login)
        {
            if(Find(login) == true)
            {
                User tmp = new User();

                foreach (User u in contentList)
                {
                    if(u.Login.Equals(login))
                    {
                        tmp = u;
                    }
                }
                contentList.Remove(tmp);
            }
        }

        /// <summary>
        /// Updates the password of all users with the given login.
        /// </summary>
        /// <param name="login">User login.</param>
        /// <param name="password">New user password.</param>
        public override void Update(String login, String password)
        {
            if (Find(login) == true)
            {
              
                foreach (User u in contentList)
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
            foreach(User x in contentList)
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
        public new void Read()
        {
            foreach (User x in contentList)
            {
                System.Console.WriteLine(x);
            }
        }

        /// <summary>
        /// Loads all users from the data base to use them in later operations.
        /// </summary>
        public override void LoadFromDB()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                {
                    String request = "SELECT Login,Password,Admin FROM Users";

                    using (SqlCommand command = new SqlCommand(request,connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                contentList.Add(new User(reader.GetString(0), reader.GetString(1), reader.GetBoolean(2)));
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
        public void AddUserToDB(String login, String password, Boolean admin)
        {
           if(Find(login) == false)
           {
                User user = new User(login, password, admin);
                int userID = contentList.Count + 1;

                Create(user);

                try
                {
                    using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                    {
                        String request = "INSERT INTO Users(UserID, Login, Password, Admin) VALUES(@id, @login, @password, @admin)";               
                        using (SqlCommand command = new SqlCommand(request, connection))
                        {
                            connection.Open();
                            command.Parameters.Add("@id", SqlDbType.Int).Value = userID;
                            command.Parameters.Add("@login", SqlDbType.VarChar, 255).Value = login;
                            command.Parameters.Add("@password", SqlDbType.VarChar, 255).Value = password;
                            command.Parameters.Add("@admin", SqlDbType.Bit).Value = admin;
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
            if (Find(login) == true)
            {                 
                Delete(login);
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
            if (Find(login) == true)
            {

                Update(login, password);

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
            foreach(User u in contentList)
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
        public override bool Find(String login)
        {
            foreach(User u in contentList)
            {
                if(u.Login.Equals(login))
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean GetPermission(String login)
        {
            foreach(User u in contentList)
            {
                if(u.Login.Equals(login))
                {
                    return u.Admin;
                }        
            }
            return false;
        }
    }
}
