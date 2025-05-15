using OfficeOpenXml; // EPPlus
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Ensumex.Utils
{
    internal class ClienteImporter
    {
        public static void ImportarClientesDesdeExcel(string rutaArchivoExcel)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(new FileInfo(rutaArchivoExcel)))
            {
                ExcelWorksheet hoja = package.Workbook.Worksheets[0];
                int filaInicial = 2; // Suponemos que la fila 1 tiene encabezados
                int filas = hoja.Dimension.Rows;

                string connectionString = "Server=TU_SERVIDOR;Database=TU_BD;Trusted_Connection=True;";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    for (int fila = filaInicial; fila <= filas; fila++)
                    {
                        int clave = int.Parse(hoja.Cells[fila, 1].Text.Trim());
                        string estatus = hoja.Cells[fila, 2].Text.Trim();
                        string nombre = hoja.Cells[fila, 3].Text.Trim();
                        string calle = hoja.Cells[fila, 4].Text.Trim();
                        string telefono = hoja.Cells[fila, 5].Text.Trim();

                        decimal saldo = 0;
                        decimal.TryParse(hoja.Cells[fila, 6].Text.Trim().Replace(",", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out saldo);

                        string estadoTimbrado = hoja.Cells[fila, 7].Text.Trim();
                        string nombreComercial = hoja.Cells[fila, 8].Text.Trim();

                        string sql = @"
                    INSERT INTO Clientes (Clave, Estatus, Nombre, Calle, Telefono, Saldo, EstadoDatosTimbrado, NombreComercial)
                    VALUES (@Clave, @Estatus, @Nombre, @Calle, @Telefono, @Saldo, @EstadoDatosTimbrado, @NombreComercial)";

                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@Clave", clave);
                            cmd.Parameters.AddWithValue("@Estatus", estatus);
                            cmd.Parameters.AddWithValue("@Nombre", nombre);
                            cmd.Parameters.AddWithValue("@Calle", calle);
                            cmd.Parameters.AddWithValue("@Telefono", telefono);
                            cmd.Parameters.AddWithValue("@Saldo", saldo);
                            cmd.Parameters.AddWithValue("@EstadoDatosTimbrado", estadoTimbrado);
                            cmd.Parameters.AddWithValue("@NombreComercial", nombreComercial);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    conn.Close();
                }
            }
        }
    }
}
