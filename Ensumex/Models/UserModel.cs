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
        public bool RegistrarUsuario(string usuario, string contraseña)
        {
            try
            {
                // Generar el hash de la contraseña
                var hashedPassword = ObtenerHashSHA256(contraseña);

                // Usar la conexión proporcionada por ConnectionToSql
                using (var connection = GetConnection())
                {
                    connection.Open();

                    // Comando SQL para insertar el nuevo usuario
                    var command = new SqlCommand("INSERT INTO Usuarios (Usuario, Contraseña) VALUES (@Usuario, @Contraseña)", connection);
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Contraseña", hashedPassword);

                    // Ejecutar el comando
                    int rowsAffected = command.ExecuteNonQuery();

                    // Retornar true si se insertó correctamente
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                // Manejar errores (puedes registrar el error en un archivo de log)
                Console.WriteLine($"Error al registrar usuario: {ex.Message}");
                return false;
            }
        }

        // Método para generar el hash de la contraseña
       /* private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }*/

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
                    return count > 0; // true si existe
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
