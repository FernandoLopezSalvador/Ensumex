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
        private static readonly string connectionString = "Server=localhost; Database=Ensumex; Integrated Security=True";

        // Método estático para obtener la cadena de conexión
        public static string GetConnectionString()
        {
            return connectionString;
        }
        // Método estático para obtener una conexión lista para usar
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}