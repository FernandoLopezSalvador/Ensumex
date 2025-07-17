using Ensumex.Clases;
using Ensumex.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensumex.Models
{
    internal class ClientesDao : ConnectionToSql
    {
        [Obsolete]
        // metodo para obtener los clientes de la base de datos
        public List<(string CLAVE, string STATUS, string NOMBRE, string CALLE, string COLONIA, string MUNICIPIO, string EMAILPRED, string NOMBRECOMERCIAL)> ObtenerClientes()
        {
            var clientes = new List<(string CLAVE, string STATUS, string NOMBRE, string CALLE, string COLONIA, string MUNICIPIO, string EMAILPRED, string NOMBRECOMERCIAL)>();
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT CLAVE, STATUS, NOMBRE, CALLE, COLONIA, MUNICIPIO, EMAILPRED, NOMBRECOMERCIAL FROM CLIE01", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            clientes.Add((
                                reader["CLAVE"].ToString(),
                                reader["STATUS"].ToString(),
                                reader["NOMBRE"].ToString(),
                                reader["CALLE"].ToString(),
                                reader["COLONIA"].ToString(),
                                reader["MUNICIPIO"].ToString(),
                                reader["EMAILPRED"].ToString(),
                                reader["NOMBRECOMERCIAL"].ToString()
                            ));
                        }
                    }
                }
            }
            return clientes;
        }
        public bool ClienteExiste(string claveCliente)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT COUNT(*) FROM CLIE01 WHERE CLAVE = @clave", connection))
                {
                    command.Parameters.AddWithValue("@clave", claveCliente);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        public void GuardarCliente(string clave, string nombre)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(@"
            INSERT INTO CLIE01 
            (CLAVE, NOMBRE, CALLE, COLONIA, MUNICIPIO, EMAILPRED, NOMBRECOMERCIAL, STATUS)
            VALUES
            (@clave, @nombre, '', '', '', '', '', 'A')", connection))
                {
                    command.Parameters.AddWithValue("@clave", clave);
                    command.Parameters.AddWithValue("@nombre", nombre);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
