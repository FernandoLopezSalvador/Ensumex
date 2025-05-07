using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ensumex.Models;

namespace Ensumex.Services
{
    internal class ProductoServices
    {
        private readonly ProductoDao _productoDao = new ProductoDao();

        public List<(string Clave, string Descripcion, decimal PrecioCosto, string NumeroSerie, string TipoProducto)> ObtenerProductos(int? limite = null)
        {
            var productos = _productoDao.ObtenerProductos();
            return limite.HasValue ? productos.Take(limite.Value).ToList() : productos;
        }
    }
}
