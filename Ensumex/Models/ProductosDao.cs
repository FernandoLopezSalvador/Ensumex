using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Ensumex.Clases;
using Ensumex.Forms;

namespace Ensumex.Models
{
    internal class ProductosDao: ConnectionToSql
    {
        [Obsolete]
        public List<(string CVE_ART, string DESCR, string UNI_MED, decimal COSTO_PROM, decimal ULT_COSTO, string EXIST)>ObtenerProductoss()
        {
            List<(string CVE_ART, string DESCR, string UNI_MED, decimal COSTO_PROM, decimal ULT_COSTO, string EXIST)> productos = new List<(string CLAVECVE_ART, string DESCR, string UNI_MED, decimal COSTO_PROM, decimal ULT_COSTO, string EXIST)>();
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT CVE_ART, DESCR, UNI_MED, COSTO_PROM, ULT_COSTO, EXIST FROM INVE01", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    productos.Add((
                        reader["CVE_ART"].ToString(),
                        reader["DESCR"].ToString(),
                        reader["UNI_MED"].ToString(),
                        Convert.ToDecimal(reader["COSTO_PROM"]),
                        Convert.ToDecimal(reader["ULT_COSTO"]),
                        reader["EXIST"].ToString()
                    ));
                }
            }
            return productos;
        }
    }
}