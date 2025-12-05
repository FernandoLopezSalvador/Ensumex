using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Ensumex.Clases
{
    public abstract class ConnectionToSql
    {
        private static readonly string connectionString = "Server=192.168.1.244;Database=Ensumex;User Id=appuser;Password=ensumex;";

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