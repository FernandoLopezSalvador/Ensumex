using Ensumex.Forms;
using Ensumex.Views;

namespace Ensumex
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Habilita soporte DPI para monitores de diferentes resoluciones
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);

            // Estilos visuales modernos
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Inicia la app con Login y splash screen
            using (Login login = new Login())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    using (Cargando carga = new Cargando())
                    {
                        carga.ShowDialog();
                    }

                    Application.Run(new ENSUMEX());
                }
                else
                {
                    Application.Exit();
                }
            }
        }
    }
}