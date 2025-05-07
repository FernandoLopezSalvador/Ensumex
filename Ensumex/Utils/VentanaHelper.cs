using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensumex.Utils
{
    internal class VentanaHelper
    {
        public static void Minimizar(Form form)
        {
            form.WindowState = FormWindowState.Minimized;
        }

        public static void Maximizar(Form form)
        {
            if (form.WindowState == FormWindowState.Maximized)
            {
                form.WindowState = FormWindowState.Normal;
            }
            else
            {
                form.WindowState = FormWindowState.Maximized;
            }
        }

        public static void Cerrar(Form form)
        {
            if (MessageBox.Show("¿Está seguro que desea sali?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
