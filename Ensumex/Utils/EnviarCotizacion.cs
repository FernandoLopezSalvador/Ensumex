using System;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Ensumex.Services
{
    public static class EnviarCotizacion
    {
        public static void EnviarCotizacionPorwhats(string destinatario, string asunto, string cuerpo)
        {
            string url = $"https://wa.me/{destinatario}?text={Uri.EscapeDataString(cuerpo)}";
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
    }
}