using Ensumex.Models;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensumex.Services
{
    internal class ClienteServices1
    {
        private readonly ClientesDao _clientesDao;
        public ClienteServices1()
        {
            _clientesDao = new ClientesDao();
        }
        [Obsolete]
        public List<(string CLAVE, string STATUS, string NOMBRE, string CALLE, string COLONIA, string MUNICIPIO, string EMAILPRED, string NOMBRECOMERCIAL)> ObtenerClientes()
        {
            return _clientesDao.ObtenerClientes();
        }
    }
}
