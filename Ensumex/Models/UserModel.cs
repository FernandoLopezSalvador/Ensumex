using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Ensumex.Clases;
using Ensumex.Controllers;

namespace Ensumex.Models
{
    internal class UserModel: ConnectionToSql
    {
        [Obsolete]
        public bool RegistrarUsuario(string usuario, string contraseña)
        {
            try
            {
                var hashedPassword = ObtenerHashSHA256(contraseña);

                using (var connection = GetConnection())
                {
                    connection.Open();

                    var command = new SqlCommand("INSERT INTO Usuarios (Usuario, Contraseña) VALUES (@Usuario, @Contraseña)", connection);
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Contraseña", hashedPassword);

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar usuario: {ex.Message}");
                return false;
            }
        }

        [Obsolete]
        public bool LoginUser(string usuario, string contraseña)
        {
            string hash = ObtenerHashSHA256(contraseña);

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand(
                    "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario AND Contraseña = @Contraseña", connection))
                {
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Contraseña", hash);

                    int count = (int)command.ExecuteScalar();
                    return count > 0; 
                }
            }
        }
        private string ObtenerHashSHA256(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(texto);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }
    }
}
