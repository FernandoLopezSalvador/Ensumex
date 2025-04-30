using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Ensumex.Clases;
using static Ensumex.Clases.DataAccess;


namespace Ensumex.Clases
{
    public class UsuarioDao : ConnectionToSql
    {
        public bool Login(string usuario, string contraseña)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand()) // Fixed incorrect type 'GetConnextion' to 'SqlCommand'
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @usuario AND Contraseña = @contraseña";
                    command.Parameters.AddWithValue("@usuario", usuario);
                    command.Parameters.AddWithValue("@contraseña", contraseña);
                    command.CommandType = CommandType.Text;

                    int count = Convert.ToInt32(command.ExecuteScalar()); // Removed redundant SqlDataReader
                    return count > 0;
                }
            }
        }
    }
}
