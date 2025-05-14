using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensumex.Utils
{
    internal class VentanaHelper
    {
        public static bool ConfirmarCerrarFormulario(string mensaje = "¿Está seguro que desea salir?")
        {
            var result = MessageBox.Show(
                   mensaje,
                   "Confirmar salida",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question);

            return result == DialogResult.Yes;
        }
    }
}
