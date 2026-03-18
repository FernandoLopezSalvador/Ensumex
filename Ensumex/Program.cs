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
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

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