using System.Configuration;

namespace sql_connectivity_tester
{
    public static class AppConfig
    {
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["DatabaseConnectionString"].ConnectionString;
    }
}
