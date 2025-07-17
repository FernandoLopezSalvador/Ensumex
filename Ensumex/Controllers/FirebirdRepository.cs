using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace Ensumex.Controllers
{
    public static class FirebirdRepository
    {
        private static readonly string connFirebird = "User=SYSDBA;Password=masterkey;" +
        "Database=192.168.1.232:C:\\Program Files (x86)\\Common Files\\Aspel\\Sistemas Aspel\\SAE9.00\\Empresa01\\Datos\\SAE90EMPRE01.FDB;" +
        "Port=3050;Dialect=3;Charset=NONE;ServerType=0;";

        public static DataTable GetProductos()
        {
            var productos = new DataTable();
            using (FbConnection conn = new FbConnection(connFirebird))
            {
                conn.Open();
                using (FbCommand cmd = new FbCommand("SELECT CVE_ART, DESCR, UNI_MED, COSTO_PROM, ULT_COSTO, EXIST FROM INVE01", conn))
                using (FbDataAdapter adapter = new FbDataAdapter(cmd))
                {
                    adapter.Fill(productos);
                }
            }
            return productos;
        }

        public static DataTable GetClientes()
        {
            var clientes = new DataTable();
            using (FbConnection conn = new FbConnection(connFirebird))
            {
                conn.Open();
                using (FbCommand cmd = new FbCommand("SELECT CLAVE, STATUS, NOMBRE, CALLE, COLONIA, MUNICIPIO, EMAILPRED FROM CLIE01", conn))
                using (FbDataAdapter adapter = new FbDataAdapter(cmd))
                {
                    adapter.Fill(clientes);
                }
            }
            return clientes;
        }

        public static DataTable GetPrecios()
        {
            var precios = new DataTable();
            using (FbConnection conn = new FbConnection(connFirebird))
            {
                conn.Open();
                using (FbCommand cmd = new FbCommand("SELECT CVE_ART, CVE_PRECIO, PRECIO FROM PRECIO_X_PROD01", conn))
                using (FbDataAdapter adapter = new FbDataAdapter(cmd))
                {
                    adapter.Fill(precios);
                }
            }
            return precios;
        }
    }
}
