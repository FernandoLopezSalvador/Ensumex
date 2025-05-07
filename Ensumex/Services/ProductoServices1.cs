using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ensumex.Models;

namespace Ensumex.Services
{
    internal class ProductoServices1
    {
        private readonly ProductosDao _productoDao = new();
        
        public List <(string CLAVE, string Descripcion, string UnidadEntrada, decimal PU, decimal PrecioPublico, decimal PUMinimo, string TipoProducto)> ObtenerProductos(int? limite = null)
        {
            var productos = _productoDao.ObtenerProductoss();
            return limite.HasValue ? productos.Take(limite.Value).ToList() : productos;
        }
    }
}
