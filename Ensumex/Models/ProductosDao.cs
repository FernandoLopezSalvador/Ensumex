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
        public List<(string CVE_ART, string DESCR, string UNI_MED, decimal COSTO_PROM, decimal ULT_COSTO, decimal EXIST, decimal PRECIO)> ObtenerProductoss(int listaPrecio = 1)
        {
            var productos = new List<(string, string, string, decimal, decimal, decimal, decimal)>();

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string query = @"
            SELECT 
                I.CVE_ART, I.DESCR, I.UNI_MED, I.COSTO_PROM, I.ULT_COSTO, I.EXIST, ISNULL(P.PRECIO, 0) AS PRECIO
            FROM 
                INVE01 I
            LEFT JOIN 
                PRECIO_X_PROD01 P ON I.CVE_ART = P.CVE_ART AND P.CVE_PRECIO = @CVE_PRECIO
            ORDER BY 
                I.CVE_ART";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CVE_PRECIO", listaPrecio);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productos.Add((
                                reader["CVE_ART"].ToString(),
                                reader["DESCR"].ToString(),
                                reader["UNI_MED"].ToString(),
                                Convert.ToDecimal(reader["COSTO_PROM"]),
                                Convert.ToDecimal(reader["ULT_COSTO"]),
                                Convert.ToDecimal(reader["EXIST"]),
                                Convert.ToDecimal(reader["PRECIO"])
                            ));
                        }
                    }
                }
            }
            return productos;
        }
    }
}