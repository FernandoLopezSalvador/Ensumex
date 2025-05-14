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
                                reader.GetString(0),  // CLAVE
                                reader.GetString(1),  // Descripcion
                                reader.IsDBNull(2) ? string.Empty : reader.GetString(2),  // UnidadEntrada
                                reader.GetDecimal(3), // PU
                                reader.GetDecimal(4), // PrecioPublico
                                reader.GetDecimal(5), // PUMinimo
                                reader.GetString(6)   // TipoProducto
                            ));
                        }
                    }
                }
            }
            return productos;
        }
    }
}
