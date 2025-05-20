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
        public List<(string CLAVE, string Descripcion, string UnidadEntrada,decimal PU, decimal PrecioPublico, decimal PUMinimo,string TipoProducto)>ObtenerProductoss()
        {
            var productos = new List<(string CLAVE, string Descripcion, string UnidadEntrada, decimal PU, decimal PrecioPublico, decimal PUMinimo, string TipoProducto)>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT CLAVE, Descripcion, UnidadEntrada, PU, PrecioPublico, PUMinimo, TipoProducto FROM Productos1", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productos.Add((
                                reader.IsDBNull(0) ? string.Empty : reader.GetString(0), // CLAVE
                                reader.IsDBNull(1) ? string.Empty : reader.GetString(1), // Descripcion
                                reader.IsDBNull(2) ? string.Empty : reader.GetString(2), // UnidadEntrada
                                reader.IsDBNull(3) ? 0 : reader.GetDecimal(3),           // PU
                                reader.IsDBNull(4) ? 0 : reader.GetDecimal(4),           // PrecioPublico
                                reader.IsDBNull(5) ? 0 : reader.GetDecimal(5),           // PUMinimo
                                reader.IsDBNull(6) ? string.Empty : reader.GetString(6)  // TipoProducto
                            ));
                        }
                    }
                }
            }
            return productos;
        }
    }
}
