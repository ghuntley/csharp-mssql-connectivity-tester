using System;
using System.Data.SqlClient;

namespace sql_connectivity_tester
{
    class Program
    {
        public enum ExitCode : int
        {
            Success = 0,
            UnknownError = 1
        }

        static int Main(string[] args)
        {
            try
            {
                Console.WriteLine("Connecting to: {0}", AppConfig.ConnectionString);
                using (var connection = new SqlConnection(AppConfig.ConnectionString))
                {
                    var query = "select 1";
                    Console.WriteLine("Executing: {0}", query);

                    var command = new SqlCommand(query, connection);

                    connection.Open();
                    Console.WriteLine("SQL Connection successful.");

                    command.ExecuteScalar();
                    Console.WriteLine("SQL Query execution successful.");

                    return (int)ExitCode.Success;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failure: {0}", ex.Message);
                return (int)ExitCode.UnknownError;
            }
        }
    }
}
