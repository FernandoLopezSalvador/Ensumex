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
            /*
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());*/
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