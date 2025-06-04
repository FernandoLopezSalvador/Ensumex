using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ensumex.Clases;

namespace Ensumex.Models
{
    internal class CargaUsuario
    {
        [Obsolete]
        public static void CargarDatosUsuario(Label lblUsuario, Label lblPosicion)
        {
            try
            {
                // Verifica que el usuario esté definido
                if (string.IsNullOrEmpty(UsuarioLoginCache.Usuario))
                {
                    MessageBox.Show("El usuario no está definido. Por favor, inicie sesión nuevamente.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Instancia de UsuarioDao para obtener los datos
                var usuarioDao = new UsuarioDao();
                var datosUsuario = usuarioDao.ObtenerDatosUsuario(UsuarioLoginCache.Usuario);

                // Verifica si datosUsuario es un valor predeterminado (tupla vacía)
                if (datosUsuario.Equals(default((string Nombre, string Posicion))))
                {
                    MessageBox.Show("No se encontraron datos para el usuario especificado.",
                                    "Información no disponible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblUsuario.Text = "N/A";
                    lblPosicion.Text = "N/A";
                    return;
                }

                // Asigna los datos a los labels
                lblUsuario.Text = datosUsuario.Nombre ?? "N/A";
                lblPosicion.Text = datosUsuario.Posicion ?? "N/A";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los datos del usuario:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                lblUsuario.Text = "N/A";
                lblPosicion.Text = "N/A";
            }
        }
    }
}
