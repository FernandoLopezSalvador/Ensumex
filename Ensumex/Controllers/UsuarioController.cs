using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ensumex.Clases;
using Ensumex.Models;
using Ensumex.Forms;

namespace Ensumex.Controllers
{
    internal class UsuarioController : ConnectionToSql
    {

        // Método para iniciar sesión y encriptar la contraseña
        [Obsolete]
        public bool GuardarUsuario(Usuarios usuario)
        {
            // 1) Encriptamos la contraseña.
            usuario.Contraseña = ObtenerHashSHA256(usuario.Contraseña);

            using (var connection = GetConnection())
            {
                connection.Open();

                // 2) Primero, verificamos si ya existe ese nombre de usuario:
                using (var checkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario", connection))
                {
                    checkCmd.Parameters.AddWithValue("@Usuario", usuario.Usuario);
                    int existente = (int)checkCmd.ExecuteScalar();
                    if (existente > 0)
                    {
                        // Ya existe ese usuario
                        return false;
                    }
                }

                // 3) Si no existe, insertamos con todos los parámetros correctamente:
                using (var insertCmd = new SqlCommand(
                    @"INSERT INTO Usuarios 
                    (Usuario, Contraseña, Nombre, Posision, Correo) 
                    VALUES (@Usuario, @Contraseña, @Nombre, @Posision, @Correo)",
                    connection))
                {
                    insertCmd.Parameters.AddWithValue("@Usuario", usuario.Usuario);
                    insertCmd.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                    insertCmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    insertCmd.Parameters.AddWithValue("@Posision", usuario.Posision); 
                    insertCmd.Parameters.AddWithValue("@Correo", usuario.Correo);

                    int filasAfectadas = insertCmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
                }
            }
        }

        // Método para iniciar sesión Y Obtener el Hash de la contraseña
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
