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
        public static void CargarDatosUsuario(Label lblUsuario, Label lblPosicion)
        {
            // Verifica que el usuario esté definido
            if (string.IsNullOrEmpty(UsuarioLoginCache.Usuario))
            {
                MessageBox.Show("El usuario no está definido. Por favor, inicie sesión nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Instancia de UsuarioDao para obtener los datos
            var usuarioDao = new UsuarioDao();
            var datosUsuario = usuarioDao.ObtenerDatosUsuario(UsuarioLoginCache.Usuario);

            // Asigna los datos a los labels
            lblUsuario.Text = datosUsuario.Nombre ?? "N/A";
            lblPosicion.Text = datosUsuario.Posicion ?? "N/A";
        }
    }
}
