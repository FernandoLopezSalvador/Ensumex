using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace Ensumex.Utils
{
    internal class PDFClients
    {
        public static void ExportarClientes(DataGridView tabla, string nombreArchivo = "Exportado.xlsx")
        {
            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.Title = "Guardar archivo Excel";
                sfd.FileName = "ejemplo.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var worksheet = workbook.Worksheets.Add("Clientes");

                            // Agregar encabezados
                            for (int i = 0; i < tabla.Columns.Count; i++)
                            {
                                worksheet.Cell(1, i + 1).Value = tabla.Columns[i].HeaderText;
                            }

                            // Agregar datos
                            for (int i = 0; i < tabla.Rows.Count; i++)
                            {
                                for (int j = 0; j < tabla.Columns.Count; j++)
                                {
                                    var valor = tabla.Rows[i].Cells[j].Value;
                                    worksheet.Cell(i + 2, j + 1).Value = valor?.ToString() ?? "";
                                }
                            }
                            worksheet.Columns().AdjustToContents();
                            workbook.SaveAs(sfd.FileName);
                        }
                        MessageBox.Show("Exportación completada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al exportar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
