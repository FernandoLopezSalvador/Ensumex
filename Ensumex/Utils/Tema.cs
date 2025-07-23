using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensumex.Utils
{
    public static class Tema
    {
        public static void ConfigurarTema(MaterialForm form, MaterialSkinManager.Themes tema = MaterialSkinManager.Themes.LIGHT)
        {
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(form);
            skinManager.Theme = tema;
            skinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800,
                Primary.BlueGrey700,
                Primary.BlueGrey400,
                Accent.LightBlue100,
                tema == MaterialSkinManager.Themes.DARK ? TextShade.WHITE : TextShade.BLACK
            );
        }
    }
}
