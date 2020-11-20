using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace TCPLib.Response
{
    /// <summary>
    /// Contains and operates on posible server responses.
    /// </summary>
    public class ResponseContainer
    {
        /// <summary>
        /// A list of possible responses.
        /// </summary>
        private List<Response> responses;

        /// <summary>
        /// Creates a instance of the response container.
        /// </summary>
        public ResponseContainer()
        {
            responses = new List<Response>();
            LoadFromDB();
        }
        
        /// <summary>
        /// Adds a new respons to the list.
        /// </summary>
        /// <param name="response">The response with input and output.</param>
        public void Add(Response response)
        {
            responses.Add(response);
        }
        
        /// <summary>
        /// Returns a response text to the given input or "Sorry i dont understand" by default.
        /// </summary>
        /// <param name="input">Input used to receive a response.</param>
        /// <returns>Output appropriate to the input.</returns>
        public String GetResponse(String input)
        {
            String output = "Sorry i dont understand";
            foreach (Response x in responses)
            {
                if (x.Input.Equals(input))
                {
                    return x.Output;
                }
            }
            return output;
        }

        /// <summary>
        /// Prints a list of all users.
        /// </summary>
        public void PrintUsers()
        {
            foreach (Response x in responses)
            {
                System.Console.WriteLine(x);
            }
        }

        /// <summary>
        /// Loads all responses saved in a data base to use them later.
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
                    String request = "SELECT Input,Output FROM Responses";

                    using (SqlCommand command = new SqlCommand(request, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                responses.Add(new Response(reader.GetString(0), reader.GetString(1)));
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
    }
}
