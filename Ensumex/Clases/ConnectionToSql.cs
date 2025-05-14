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
        // Funcion para la conexion con la base de datos
        private readonly string connectionString;
        public ConnectionToSql()
        {
            connectionString = "Server=ENSUMEX; Database=Ensumex; Integrated Security=True";
        }

        [Obsolete]
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString); 
        }
    }
}
