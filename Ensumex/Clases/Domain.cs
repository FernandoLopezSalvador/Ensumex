﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ensumex.Models;

namespace Ensumex.Clases
{
    
       public class UserModel
        {
            private UsuarioDao usuarioDao = new UsuarioDao();

        [Obsolete]
        public bool LoginUser(string usuario, string contraseña)
            {
                return usuarioDao.Login(usuario, contraseña);
            }
       }
    
}
