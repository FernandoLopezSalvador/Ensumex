﻿using System;
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
        public List <(string CVE_ART, string DESCR, string UNI_MED, decimal COSTO_PROM, decimal ULT_COSTO, string EXIST)> ObtenerProductos(int? limite = null)
        {
            var productos = _productoDao.ObtenerProductoss();
            return productos;
        }
    }
}
