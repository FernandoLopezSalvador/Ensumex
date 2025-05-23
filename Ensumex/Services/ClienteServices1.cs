using Ensumex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensumex.Services
{
    internal class ClienteServices1
    {
        private readonly ClientesDao _clienteDao = new();

        [Obsolete]
        public List<(int CLAVE, string Estatus,string Nombre,string Calle, string Telefono,decimal Saldo,string EstadoDatosTimbrado,string NombreComercial)> ObtenerClientes(int? limite = null)
        {
            var clientes = _clienteDao.ObtenerClientes();
            return limite.HasValue ? clientes.Take(limite.Value).ToList() : clientes;
        }
    }
}
