using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensumex.Models
{
    public class Usuarios
    {
        public int UsuarioID { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Nombre { get; set; }
        public string Posicion { get; set; } 
        public string Correo { get; set; }
    }
}
