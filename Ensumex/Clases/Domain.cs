using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ensumex.Clases.DataAccess;

namespace Ensumex.Clases.Domain
{
    
       public class UserModel
        {
            private UsuarioDao usuarioDao = new UsuarioDao();
            public bool LoginUser(string usuario, string contraseña)
            {
                return usuarioDao.Login(usuario, contraseña);
            }
        }
    
}
