using FontAwesome.Sharp;
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ensumex.Utils
{
    public static class BotonesUI
    {
        public static void ConfigurarBoton(IconButton boton, IconChar icono, Color iconoColor)
        {
            boton.IconChar = icono;
            boton.IconColor = iconoColor;
            boton.IconSize = 32;
            boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            boton.ImageAlign = ContentAlignment.MiddleLeft;
            boton.Padding = new Padding(10, 0, 20, 0);
            boton.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            boton.ForeColor = iconoColor;
        }

        public static void ConfigurarHover(IconButton boton, Color hoverBackColor, Color hoverIconColor, Color iconNormalColor)
        {
            boton.MouseEnter += (s, e) =>
            {
                boton.BackColor = hoverBackColor;
                boton.IconColor = hoverIconColor;
                boton.ForeColor = hoverIconColor;  // cambia también el texto para que contraste con fondo hover
            };

            boton.MouseLeave += (s, e) =>
            {
                boton.BackColor = Color.Transparent; // o algún color base del tema si quieres
                boton.IconColor = iconNormalColor;
                boton.ForeColor = hoverIconColor; // restaurar color original del texto
            };
        }

        public static void ConfigurarTodos(IconButton BtnCerrar,
            IconButton BtnInve,
            IconButton BtnCotiza,
            IconButton BtnClient,
            IconButton BtnSincroniza,
            IconButton BtnInicio)
        {

            
            bool esTemaOscuro = MaterialSkinManager.Instance.Theme == MaterialSkinManager.Themes.DARK;

            Color iconColorNormal = esTemaOscuro ?
                ColoresBotones.IconoNormalOscuro :
                ColoresBotones.IconoNormalClaro;

            // Configura cada botón
            ConfigurarBoton(BtnCerrar, IconChar.SignOutAlt, Color.FromArgb(244, 67, 54));
            ConfigurarBoton(BtnInve, IconChar.Boxes, iconColorNormal);
            ConfigurarBoton(BtnCotiza, IconChar.FileInvoiceDollar, iconColorNormal);
            ConfigurarBoton(BtnClient, IconChar.Users, iconColorNormal);
            ConfigurarBoton(BtnSincroniza, IconChar.SyncAlt, iconColorNormal);
            ConfigurarBoton(BtnInicio, IconChar.Home, iconColorNormal);

            // Configura hover para cada botón
            ConfigurarHover(BtnInve,
                esTemaOscuro ? ColoresBotones.HoverInveOscuro : ColoresBotones.HoverInveClaro,
                Color.White,
                iconColorNormal);

            ConfigurarHover(BtnCotiza,
                esTemaOscuro ? ColoresBotones.HoverCotizaOscuro : ColoresBotones.HoverCotizaClaro,
                Color.White,
                iconColorNormal);

            ConfigurarHover(BtnClient,
                esTemaOscuro ? ColoresBotones.HoverClientOscuro : ColoresBotones.HoverClientClaro,
                Color.Black,
                iconColorNormal);

            ConfigurarHover(BtnSincroniza,
                esTemaOscuro ? ColoresBotones.HoverSyncOscuro : ColoresBotones.HoverSyncClaro,
                Color.White,
                iconColorNormal);

            ConfigurarHover(BtnInicio,
                esTemaOscuro ? ColoresBotones.HoverInicioOscuro : ColoresBotones.HoverInicioClaro,
                Color.White,
                iconColorNormal);

            ConfigurarHover(BtnCerrar,
                esTemaOscuro ? ColoresBotones.HoverCerrarOscuro : ColoresBotones.HoverCerrarClaro,
                Color.White,
                iconColorNormal);
        }
    }
}
