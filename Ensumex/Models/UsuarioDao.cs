using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Ensumex.Clases;
using static Ensumex.Clases.DataAccess;
using System.Security.Cryptography.X509Certificates;



namespace Ensumex.Models
{
    public class UsuarioDao : ConnectionToSql
    {
        public bool Login(string usuario, string contraseña)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())  
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @usuario AND Contraseña = @contraseña";
                    command.Parameters.AddWithValue("@usuario", usuario);
                    command.Parameters.AddWithValue("@contraseña", contraseña);
                    command.CommandType = CommandType.Text;
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    //MessageBox.Show($"Usuario: {usuario}, Contraseña: {contraseña}, Resultado: {count}", "Depuración");
                    return count > 0;
                }
            }
        }

        public (string Nombre, string Posicion) ObtenerDatosUsuario(string usuario)
        {
            if (string.IsNullOrEmpty(usuario))
            {
                throw new ArgumentException("El parámetro 'usuario' no puede ser nulo o vacío.", nameof(usuario));
            }
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT nombre, Posision FROM Usuarios WHERE Usuario = @Usuario", connection))
                {
                    command.Parameters.AddWithValue("@Usuario", usuario);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            
                            return (reader.GetString(0), reader.GetString(1));
                        }
                    }
                }
            }
            return (null, null);
        }
    }
}
