using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebirdSql.Data.FirebirdClient;


namespace Ensumex.Clases
{
    internal class Conectiondbeaver
    {
        private string connectionString = "User=SYSDBA;" +
                                      "Password=masterkey;" +
                                      "Database=192.168.1.100:C:\\FirebirdDB\\mi_base.fdb;" +
                                      "DataSource=192.168.1.100;" +
                                      "Port=3050;" +
                                      "Dialect=3;" +
                                      "Charset=NONE;" +
                                      "ServerType=0;";

        public DataTable GetProductos()
        {
            return EjecutarConsulta("SELECT CLAVE, DESCR, EXIST FROM INVE01");
        }

        public DataTable GetClientes()
        {
            return EjecutarConsulta("SELECT * FROM CLIE01");
        }

        private DataTable EjecutarConsulta(string query)
        {
            DataTable tabla = new DataTable();

            using (FbConnection conn = new FbConnection(connectionString))
            {
                conn.Open();
                FbCommand cmd = new FbCommand(query, conn);
                FbDataAdapter adapter = new FbDataAdapter(cmd);
                adapter.Fill(tabla);
                conn.Close();
            }

            return tabla;
        }
    }
}
