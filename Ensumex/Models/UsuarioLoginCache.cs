using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensumex.Models
{
    public static class UsuarioLoginCache
    {
        public static int UsuarioID { get; set; }
        public static string Usuario { get; set; } = string.Empty; 
        public static string Contraseña { get; set; } = string.Empty; 
        public static string Nombre { get; set; } = string.Empty; 
        public static string Posicion { get; set; } = string.Empty; 
        public static string Correo { get; set; } = string.Empty; 
    }
}
