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
        private readonly string connectionString;
        public ConnectionToSql()
        {
            connectionString = "Server=ENSUMEX; Database=Ensumex; Integrated Security=True";
        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString); // No changes needed here as the correct namespace is now used
        }
    }
}
