using Ensumex.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Ensumex.Models
{
    internal class ClientesDao: ConnectionToSql
    {
        [Obsolete]
        public List<(int CLAVE, string Estatus, string Nombre, string Calle, string Telefono, decimal Saldo, string EstadoDatosTimbrado, string NombreComercial)> ObtenerClientes()
        {
            var clientes = new List<(int CLAVE, string Estatus, string Nombre, string Calle, string Telefono, decimal Saldo, string EstadoDatosTimbrado, string NombreComercial)>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT CLAVE, Estatus, Nombre, Calle, Telefono, Saldo, EstadoDatosTimbrado, NombreComercial FROM Clientes1", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clientes.Add((
                                reader.GetInt32(0),  // CLAVE
                                reader.GetString(1),  // Estatus
                                reader.GetString(2),  // Nombre
                                reader.IsDBNull(3) ? string.Empty : reader.GetString(3),  // Calle
                                reader.IsDBNull(4) ? string.Empty : reader.GetString(4),  // Telefono
                                reader.GetDecimal(5), // Saldo
                                reader.IsDBNull(6) ? string.Empty : reader.GetString(6),  // EstadoDatosTimbrado
                                reader.IsDBNull(7) ? string.Empty : reader.GetString(7)   // NombreComercial
                            ));
                        }
                    }
                }
            }
            return clientes;
        }
    }
}
