using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ensumex.Clases;

namespace Ensumex.Models
{
    internal class ProductoDao : ConnectionToSql
    {
        public List<(string Clave, string Descripcion, decimal PrecioCosto, string NumeroSerie, string TipoProducto)> ObtenerProductos()
        {
            var productos = new List<(string Clave, string Descripcion, decimal PrecioCosto, string NumeroSerie, string TipoProducto)>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT Clave, Descripcion, PrecioCosto, NumeroSerie, TipoProducto FROM Producto", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productos.Add((
                                reader.GetString(0),  // Clave
                                reader.GetString(1),  // Descripcion
                                reader.GetDecimal(2), // PrecioCosto
                                reader.IsDBNull(3) ? string.Empty : reader.GetString(3), // NumeroSerie
                                reader.GetString(4)   // TipoProducto
                            ));
                        }
                    }
                }
            }

            return productos;
        }
    }
}
