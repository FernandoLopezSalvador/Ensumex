using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensumex.Controllers
{
    public static class FirebirdRepository
    {
        private static readonly string connFirebird = "User=SYSDBA;Password=masterkey;" +
        "Database=192.168.1.206:C:\\Program Files (x86)\\Common Files\\Aspel\\Sistemas Aspel\\SAE9.00\\Empresa01\\Datos\\SAE90EMPRE01.FDB;" +
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
        // Consulta para obtener los productos que tienen 1 año de antigüedad en el mes actual
        public static DataTable GetCalentadoresParaMantenimiento()
        {
            var dt = new DataTable();

            string query = @"
                SELECT 
                F.CVE_DOC AS FOLIO,
                F.FECHA_DOC AS FECHA_VENTA,
                C.NOMBRE AS CLIENTE,
                C.TELEFONO,
                P.CVE_ART,
                P.DESCR AS PRODUCTO
            FROM FACTF01 F
            JOIN PAR_FACTF01 PF 
                ON F.CVE_DOC = PF.CVE_DOC
            JOIN INVE01 P 
                ON PF.CVE_ART = P.CVE_ART
            JOIN CLIE01 C 
                ON F.CVE_CLPV = C.CLAVE
            WHERE 
                (
                    P.CVE_ART STARTING WITH 'SCCAL'
                    OR P.CVE_ART STARTING WITH 'THCAL'
                    OR P.CVE_ART STARTING WITH 'ESCAL'
                )
                AND F.FECHA_DOC <= DATEADD(YEAR, -1, CURRENT_DATE)
            ORDER BY 
                F.FECHA_DOC DESC;
            ";


            using (FbConnection conn = new FbConnection(connFirebird))
            {
                conn.Open();
                using (FbCommand cmd = new FbCommand(query, conn))
                using (FbDataAdapter adapter = new FbDataAdapter(cmd))
                {
                    adapter.Fill(dt);
                }
            }

            return dt;
        }

        public static void GuardarMantenimientosLocal(DataTable dt)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=MiBDLocal;Integrated Security=True"))
            {
                conn.Open();

                foreach (DataRow row in dt.Rows)
                {
                    string folio = row["FOLIO"].ToString();

                    // Evita duplicados
                    string checkQuery = "SELECT COUNT(*) FROM Mantenimientos WHERE FolioVenta = @folio";
                    using (SqlCommand checkCmd = new SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@folio", folio);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count == 0)
                        {
                            string insertQuery = @"
                            INSERT INTO Mantenimientos 
                            (FolioVenta, Cliente, Telefono, Producto, FechaVenta, NumeroServicios, Estatus)
                            VALUES (@folio, @cliente, @telefono, @producto, @fecha, @servicios, @estatus)";

                            using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                            {
                                insertCmd.Parameters.AddWithValue("@folio", folio);
                                insertCmd.Parameters.AddWithValue("@cliente", row["CLIENTE"].ToString());
                                insertCmd.Parameters.AddWithValue("@telefono", row["TELEFONO"].ToString());
                                insertCmd.Parameters.AddWithValue("@producto", row["PRODUCTO"].ToString());
                                insertCmd.Parameters.AddWithValue("@fecha", Convert.ToDateTime(row["FECHA_VENTA"]));
                                insertCmd.Parameters.AddWithValue("@servicios", 0); // siempre inicia en 0
                                insertCmd.Parameters.AddWithValue("@estatus", "Pendiente");
                                insertCmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }
    }
}
