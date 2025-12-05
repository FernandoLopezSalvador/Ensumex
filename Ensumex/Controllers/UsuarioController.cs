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
                usuario.Contraseña = ObtenerHashSHA256(usuario.Contraseña);

            using (var connection = GetConnection())
            {
                connection.Open();

                using (var checkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario", connection))
                {
                    checkCmd.Parameters.AddWithValue("@Usuario", usuario.Usuario);
                    int existente = (int)checkCmd.ExecuteScalar();
                    if (existente > 0)
                    {
                        return false;
                    }
                }

                using (var insertCmd = new SqlCommand(
                    @"INSERT INTO Usuarios 
                    (Usuario, Contraseña, Nombre, Posicion, Correo) 
                    VALUES (@Usuario, @Contraseña, @Nombre, @Posicion, @Correo)",
                    connection))
                {
                    insertCmd.Parameters.AddWithValue("@Usuario", usuario.Usuario);
                    insertCmd.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                    insertCmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    insertCmd.Parameters.AddWithValue("@Posicion", usuario.Posicion); 
                    insertCmd.Parameters.AddWithValue("@Correo", usuario.Correo);

                    int filasAfectadas = insertCmd.ExecuteNonQuery();
                    return filasAfectadas > 0;
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

        public bool ActualizarUsuario(string usuarioOriginal, Usuarios usuarioEditado, bool actualizarContraseña)
        {
            if (actualizarContraseña)
            {
                usuarioEditado.Contraseña = ObtenerHashSHA256(usuarioEditado.Contraseña);
            }

            return new UsuarioDao().ActualizarUsuario(usuarioOriginal, usuarioEditado, actualizarContraseña);
        }

        public Usuarios ObtenerUsuarioPorNombre(string nombreUsuario)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT Usuario, Contraseña, Nombre, Posicion, Correo FROM Usuarios WHERE Usuario = @Usuario", connection))
                {
                    command.Parameters.AddWithValue("@Usuario", nombreUsuario);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuarios
                            {
                                Usuario = reader["Usuario"].ToString(),
                                Contraseña = reader["Contraseña"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Posicion = reader["Posicion"].ToString(),
                                Correo = reader["Correo"].ToString()
                            };
                        }
                    }
                }
            }
            return null;
        }
    }
}
