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

        [Obsolete]
        public List<(string CVE_ART, string DESCR, string UNI_MED, decimal COSTO_PROM, decimal ULT_COSTO, decimal EXIST, decimal PRECIO)> ObtenerProductos(int listaPrecio = 1, int? limite = null)
        {
            try
            {
                // Llama al DAO pasando la lista de precios
                var productos = _productoDao.ObtenerProductoss(listaPrecio);

                // Aplica el límite si se especifica
                if (limite.HasValue && limite.Value > 0)
                {
                    return productos.Take(limite.Value).ToList();
                }

                return productos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener productos: " + ex.Message);
            }
        }
    }
}
