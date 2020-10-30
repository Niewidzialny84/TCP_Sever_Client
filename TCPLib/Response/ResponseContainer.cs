using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace TCPLib.Response
{
    public class ResponseContainer
    {
        private List<Response> responses;

        public ResponseContainer()
        {
            responses = new List<Response>();
            LoadFromDB();
        }

        public void Add(Response response)
        {
            responses.Add(response);
        }

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

        public void PrintUsers()
        {
            foreach (Response x in responses)
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
