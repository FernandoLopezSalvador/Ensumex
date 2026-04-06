using System.Configuration;
using FirebirdSql.Data.FirebirdClient;

namespace Ensumex.Clases
{
    public abstract class ConnectionToFirebird
    {
        private static readonly string connectionString =
            ConfigurationManager.ConnectionStrings["FirebirdDB"].ConnectionString;

        public static FbConnection GetConnection()
        {
            return new FbConnection(connectionString);
        }
    }
}