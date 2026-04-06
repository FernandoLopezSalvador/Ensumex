using System.Configuration;
using System.Data.SqlClient;

namespace Ensumex.Clases
{
    public abstract class ConnectionToSql
    {
        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["EnsumexDB"].ConnectionString;

        public static string GetConnectionString()
        {
            return connectionString;
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}