using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using ExcelDataReader;

namespace Ensumex.Utils
{
    internal class Cargarproductos
    {

        public static void ImportarExcelAProductos1(string connectionString)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos Excel|*.xls;*.xlsx";
            openFileDialog.Title = "Selecciona archivo Excel";

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string filePath = openFileDialog.FileName;

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    DataTable dt = result.Tables[0];

                    List<string> errores = new List<string>();
                    int filasImportadas = 0;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        int filaNumero = 1; // Para reportar número de fila en Excel

                        foreach (DataRow row in dt.Rows)
                        {
                            try
                            {
                                filaNumero++;

                                var ADQ = row.Table.Columns.Contains("ADQ") ? row["ADQ"]?.ToString() : null;
                                var CLAVE = row.Table.Columns.Contains("CLAVE") ? row["CLAVE"]?.ToString() : null;
                                var Descripcion = row.Table.Columns.Contains("Descripcion") ? row["Descripcion"]?.ToString() : null;
                                var UnidadEntrada = row.Table.Columns.Contains("UnidadEntrada") ? row["UnidadEntrada"]?.ToString() : null;
                                var UnidadSalida = row.Table.Columns.Contains("UnidadSalida") ? row["UnidadSalida"]?.ToString() : null;
                                var PU = row.Table.Columns.Contains("PU") && !Convert.IsDBNull(row["PU"]) ? Convert.ToDecimal(row["PU"]) : 0m;
                                var PrecioPublico = row.Table.Columns.Contains("PrecioPublico") && !Convert.IsDBNull(row["PrecioPublico"]) ? Convert.ToDecimal(row["PrecioPublico"]) : 0m;
                                var PUMinimo = row.Table.Columns.Contains("PUMinimo") && !Convert.IsDBNull(row["PUMinimo"]) ? Convert.ToDecimal(row["PUMinimo"]) : 0m;
                                var PrecioMinimo = 0m; // valor fijo porque no viene del Excel
                                var ClaveSAT = row.Table.Columns.Contains("ClaveSAT") ? row["ClaveSAT"]?.ToString() : null;
                                var UnidadSAT = row.Table.Columns.Contains("UnidadSAT") ? row["UnidadSAT"]?.ToString() : null;
                                var PesoCartaporte = row.Table.Columns.Contains("PesoCartaporte") ? Convert.ToDecimal(row["PesoCartaporte"] ?? 0) : 0;
                                var TipoProducto = row.Table.Columns.Contains("TipoProducto") ? row["TipoProducto"]?.ToString() : null;

                                int? CARAC_C = null;
                                int? CARAC_E = null;

                                if (string.IsNullOrWhiteSpace(CLAVE))
                                {
                                    errores.Add($"Fila {filaNumero}: No tiene CLAVE, fila ignorada.");
                                    continue;
                                }

                                string queryExiste = "SELECT COUNT(*) FROM Productos1 WHERE CLAVE = @CLAVE";
                                using (SqlCommand cmdExiste = new SqlCommand(queryExiste, conn))
                                {
                                    cmdExiste.Parameters.AddWithValue("@CLAVE", CLAVE);
                                    int count = (int)cmdExiste.ExecuteScalar();

                                    if (count > 0)
                                    {
                                        // Actualizar
                                        string queryUpdate = @"UPDATE Productos1 SET 
                                    ADQ = @ADQ,
                                    CARAC_C = @CARAC_C,
                                    CARAC_E = @CARAC_E,
                                    Descripcion = @Descripcion,
                                    UnidadEntrada = @UnidadEntrada,
                                    UnidadSalida = @UnidadSalida,
                                    PU = @PU,
                                    PrecioPublico = @PrecioPublico,
                                    PUMinimo = @PUMinimo,
                                    PrecioMinimo = @PrecioMinimo,
                                    ClaveSAT = @ClaveSAT,
                                    UnidadSAT = @UnidadSAT,
                                    PesoCartaporte = @PesoCartaporte,
                                    TipoProducto = @TipoProducto
                                    WHERE CLAVE = @CLAVE";

                                        using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conn))
                                        {
                                            cmdUpdate.Parameters.AddWithValue("@ADQ", (object)ADQ ?? DBNull.Value);
                                            cmdUpdate.Parameters.AddWithValue("@CARAC_C", (object)CARAC_C ?? DBNull.Value);
                                            cmdUpdate.Parameters.AddWithValue("@CARAC_E", (object)CARAC_E ?? DBNull.Value);
                                            cmdUpdate.Parameters.AddWithValue("@Descripcion", (object)Descripcion ?? DBNull.Value);
                                            cmdUpdate.Parameters.AddWithValue("@UnidadEntrada", (object)UnidadEntrada ?? DBNull.Value);
                                            cmdUpdate.Parameters.AddWithValue("@UnidadSalida", (object)UnidadSalida ?? DBNull.Value);
                                            cmdUpdate.Parameters.AddWithValue("@PU", PU);
                                            cmdUpdate.Parameters.AddWithValue("@PrecioPublico", PrecioPublico);
                                            cmdUpdate.Parameters.AddWithValue("@PUMinimo", PUMinimo);
                                            cmdUpdate.Parameters.AddWithValue("@PrecioMinimo", PrecioMinimo);
                                            cmdUpdate.Parameters.AddWithValue("@ClaveSAT", (object)ClaveSAT ?? DBNull.Value);
                                            cmdUpdate.Parameters.AddWithValue("@UnidadSAT", (object)UnidadSAT ?? DBNull.Value);
                                            cmdUpdate.Parameters.AddWithValue("@PesoCartaporte", PesoCartaporte);
                                            cmdUpdate.Parameters.AddWithValue("@TipoProducto", (object)TipoProducto ?? DBNull.Value);
                                            cmdUpdate.Parameters.AddWithValue("@CLAVE", CLAVE);

                                            cmdUpdate.ExecuteNonQuery();
                                        }
                                    }
                                    else
                                    {
                                        // Insertar
                                        string queryInsert = @"INSERT INTO Productos1 
                                (ADQ, CARAC_C, CLAVE, CARAC_E, Descripcion, UnidadEntrada, UnidadSalida, PU, PrecioPublico, PUMinimo, PrecioMinimo, ClaveSAT, UnidadSAT, PesoCartaporte, TipoProducto)
                                VALUES
                                (@ADQ, @CARAC_C, @CLAVE, @CARAC_E, @Descripcion, @UnidadEntrada, @UnidadSalida, @PU, @PrecioPublico, @PUMinimo, @PrecioMinimo, @ClaveSAT, @UnidadSAT, @PesoCartaporte, @TipoProducto)";

                                        using (SqlCommand cmdInsert = new SqlCommand(queryInsert, conn))
                                        {
                                            cmdInsert.Parameters.AddWithValue("@ADQ", (object)ADQ ?? DBNull.Value);
                                            cmdInsert.Parameters.AddWithValue("@CARAC_C", (object)CARAC_C ?? DBNull.Value);
                                            cmdInsert.Parameters.AddWithValue("@CLAVE", (object)CLAVE ?? DBNull.Value);
                                            cmdInsert.Parameters.AddWithValue("@CARAC_E", (object)CARAC_E ?? DBNull.Value);
                                            cmdInsert.Parameters.AddWithValue("@Descripcion", (object)Descripcion ?? DBNull.Value);
                                            cmdInsert.Parameters.AddWithValue("@UnidadEntrada", (object)UnidadEntrada ?? DBNull.Value);
                                            cmdInsert.Parameters.AddWithValue("@UnidadSalida", (object)UnidadSalida ?? DBNull.Value);
                                            cmdInsert.Parameters.AddWithValue("@PU", PU);
                                            cmdInsert.Parameters.AddWithValue("@PrecioPublico", PrecioPublico);
                                            cmdInsert.Parameters.AddWithValue("@PUMinimo", PUMinimo);
                                            cmdInsert.Parameters.AddWithValue("@PrecioMinimo", PrecioMinimo);
                                            cmdInsert.Parameters.AddWithValue("@ClaveSAT", (object)ClaveSAT ?? DBNull.Value);
                                            cmdInsert.Parameters.AddWithValue("@UnidadSAT", (object)UnidadSAT ?? DBNull.Value);
                                            cmdInsert.Parameters.AddWithValue("@PesoCartaporte", PesoCartaporte);
                                            cmdInsert.Parameters.AddWithValue("@TipoProducto", (object)TipoProducto ?? DBNull.Value);

                                            cmdInsert.ExecuteNonQuery();
                                        }
                                    }
                                }

                                filasImportadas++;
                            }
                            catch (Exception ex)
                            {
                                errores.Add($"Fila {filaNumero}: Error -> {ex.Message}");
                            }
                        }
                    }

                    // Mostrar resumen
                    string mensaje = $"Filas importadas o actualizadas: {filasImportadas}\n";
                    if (errores.Count > 0)
                    {
                        mensaje += "Errores:\n" + string.Join("\n", errores);
                    }
                    else
                    {
                        mensaje += "No se encontraron errores.";
                    }

                    MessageBox.Show(mensaje);
                }
            }
        }
    }
}
