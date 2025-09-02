using Ensumex.Utils;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Image = iTextSharp.text.Image;
using Rectangle = iTextSharp.text.Rectangle;

namespace Ensumex.PDFtemplates
{
    internal class PDFaislados
    {
        public static void GenerarPDFCotizacion(
            string rutaArchivo,
            string numeroCotizacion,
            string nombreCliente,
            string subtotal,
            string total,
            string descuento,
            decimal porcentajeDescuento,
            string notas,
            DataGridView tablaCotizacion,
            DataGridView tablaConectados,
            string usuario
        )
        {
            try
            {
                Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
                string rutaFondo = Path.Combine(Application.StartupPath, "IMG", "Logo.png");
                string rutaPie = Path.Combine(Application.StartupPath, "IMG", "Pie.png");
                writer.PageEvent = new FondoPiePDF(rutaFondo, rutaPie, usuario);
                doc.Open();

                var fontNegrita = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                var fontheader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8);
                var fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                var fontNotas = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                var fontRojo = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.RED);
                var fontCursiva = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 10);
                var fontGris = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.GRAY);

                string rutaLogo = Path.Combine(Application.StartupPath, "IMG", "Logo.png");
                if (File.Exists(rutaLogo))
                {
                    Image logo = Image.GetInstance(rutaLogo);
                    logo.ScaleAbsolute(100f, 100f);
                    logo.SetAbsolutePosition(doc.LeftMargin, doc.PageSize.Height - doc.TopMargin - 70f);
                    doc.Add(logo);
                }
                Paragraph titulo = new Paragraph("Cotización: " + numeroCotizacion, fontNegrita)
                {
                    Alignment = Element.ALIGN_RIGHT
                };
                doc.Add(titulo);

                Paragraph fecha = new Paragraph(
                    "\nOaxaca de Juárez, Oaxaca a " + DateTime.Now.ToString("d 'de' MMMM 'de' yyyy") + "\n\n", fontGris)
                {
                    Alignment = Element.ALIGN_RIGHT
                };
                doc.Add(fecha);

                if (!string.IsNullOrWhiteSpace(nombreCliente))
                {
                    doc.Add(new Paragraph("\nEstimado(a): " + nombreCliente + ".", fontNegrita));
                }
                else
                {
                    
                    doc.Add(new Paragraph("\nEstimado(a) Cliente:", fontNegrita));
                }

                doc.Add(new Paragraph("Presente", fontNegrita));
                doc.Add(new Paragraph("\nEn atención a su amable solicitud, me permito presentarle esta cotización para el suministro y/o instalación de acuerdo a lo siguiente:\n\n", fontNormal));

                PdfPTable tabla = new PdfPTable(8)
                {
                    WidthPercentage = 100
                };

                tabla.SetWidths(new float[] { 0.5f, 0.6f, 0.8f, 2.8f, 1f, 1.2f, 1f, 1.2f });

                string[] headers = { "#", "CANT", "UNID", "DESCRIPCIÓN", "PRECIO UNIT", "DESCUENTO  ($)", "IMPORTE", "TOTAL" };

               
                foreach (string header in headers)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(header, fontheader))
                    {
                        BackgroundColor = new BaseColor(141, 198, 63), 
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        Padding = 5f
                    };
                    tabla.AddCell(celda);
                }
                //se muestra la tabla de conectados si hay datos
                if (tablaConectados.Rows.Count > 0)
                {
                    doc.Add(new Paragraph("\nDispositivos que se pueden conectar:\n\n", fontNegrita));
                    PdfPTable tablaConectadosPDF = new PdfPTable(4)
                    {
                        WidthPercentage = 100
                    };
                    tablaConectadosPDF.SetWidths(new float[] { 1f, 2.5f,2f,2f });
                    tablaConectadosPDF.AddCell(new PdfPCell(new Phrase("CANTIDAD", fontheader)) { BackgroundColor = new BaseColor(141, 198, 63), HorizontalAlignment = Element.ALIGN_CENTER });
                    tablaConectadosPDF.AddCell(new PdfPCell(new Phrase("EQUIPOS", fontheader)) { BackgroundColor = new BaseColor(141, 198, 63), HorizontalAlignment = Element.ALIGN_CENTER });
                    tablaConectadosPDF.AddCell(new PdfPCell(new Phrase("POTENCIA", fontheader)) { BackgroundColor = new BaseColor(141, 198, 63), HorizontalAlignment = Element.ALIGN_CENTER });
                    tablaConectadosPDF.AddCell(new PdfPCell(new Phrase("HORAS DE USO", fontheader)) { BackgroundColor = new BaseColor(141, 198, 63), HorizontalAlignment = Element.ALIGN_CENTER });

                    foreach (DataGridViewRow row in tablaConectados.Rows)
                    {
                        if (row.IsNewRow) continue; 
                        string cantidad = row.Cells["CANTIDAD"].Value?.ToString() ?? "0";
                        string eqiopos = row.Cells["EQUIPOS"].Value?.ToString() ?? "";
                        string potencia = row.Cells["POTENCIA"].Value?.ToString() ?? "0.0 kW";
                        string horasUso = row.Cells["HORAS DE USO"].Value?.ToString() ?? "0 horas";
                        tablaConectadosPDF.AddCell(new PdfPCell(new Phrase(cantidad, fontNormal)) { HorizontalAlignment = Element.ALIGN_CENTER });
                        tablaConectadosPDF.AddCell(new PdfPCell(new Phrase(eqiopos, fontNormal)) { NoWrap = false });
                        tablaConectadosPDF.AddCell(new PdfPCell(new Phrase(potencia, fontNormal)) { HorizontalAlignment = Element.ALIGN_CENTER });
                        tablaConectadosPDF.AddCell(new PdfPCell(new Phrase(horasUso, fontNormal)) { HorizontalAlignment = Element.ALIGN_CENTER });
                    }
                    doc.Add(tablaConectadosPDF);
                }
                int pos = 1;
                BaseColor colorFilaPar = BaseColor.WHITE;
                BaseColor colorFilaImpar = new BaseColor(245, 245, 245);

                doc.Add(new Paragraph("\nPropuesta:\n\n", fontNegrita));
                foreach (DataGridViewRow row in tablaCotizacion.Rows)
                {   
                    if (row.IsNewRow) continue; 
                    // Datos de la fila
                    string cantidadStr = row.Cells["CANTIDAD"].Value?.ToString() ?? "0";
                    decimal.TryParse(cantidadStr, out decimal cantidad);
                    string unidad = row.Cells["UNIDAD"].Value?.ToString() ?? "";
                    string descripcion = row.Cells["DESCRIPCIÓN"].Value?.ToString() ?? "";
                    string precioStr = row.Cells["PRECIO"].Value?.ToString() ?? "0";
                    decimal.TryParse(precioStr, out decimal precioUnitario);
                    int.TryParse(row.Cells["Descuento"].Value?.ToString() ?? "0", out int porcentajeDescuentoFila);
                    decimal importe = precioUnitario * cantidad;
                    decimal descuentoFila = importe * (porcentajeDescuentoFila / 100m);
                    decimal total1 = importe - descuentoFila;

                    // Formatear en moneda
                    string precioFormateado = precioUnitario.ToString("C2", new CultureInfo("es-MX"));
                    string descuentoFormateado = descuentoFila.ToString("C2", new CultureInfo("es-MX"));
                    string importeFormateado = importe.ToString("C2", new CultureInfo("es-MX"));
                    string totalFormateado = total1.ToString("C2", new CultureInfo("es-MX"));

                    BaseColor fondoFila = (pos % 2 == 0) ? colorFilaPar : colorFilaImpar;
                    // Añadir celdas
                    tabla.AddCell(new PdfPCell(new Phrase(pos.ToString(), fontNormal)) { BackgroundColor = fondoFila, HorizontalAlignment = Element.ALIGN_CENTER });
                    tabla.AddCell(new PdfPCell(new Phrase(cantidadStr, fontNormal)) { BackgroundColor = fondoFila, HorizontalAlignment = Element.ALIGN_CENTER });
                    tabla.AddCell(new PdfPCell(new Phrase(unidad, fontNormal)) { BackgroundColor = fondoFila, HorizontalAlignment = Element.ALIGN_CENTER });
                    tabla.AddCell(new PdfPCell(new Phrase(descripcion, fontNormal)) { BackgroundColor = fondoFila, NoWrap = false });
                    tabla.AddCell(new PdfPCell(new Phrase(precioFormateado, fontNormal)) { BackgroundColor = fondoFila, HorizontalAlignment = Element.ALIGN_RIGHT });
                    tabla.AddCell(new PdfPCell(new Phrase("-" + descuentoFormateado, fontRojo)) { BackgroundColor = fondoFila, HorizontalAlignment = Element.ALIGN_RIGHT });
                    tabla.AddCell(new PdfPCell(new Phrase(importeFormateado, fontNormal)) { BackgroundColor = fondoFila, HorizontalAlignment = Element.ALIGN_RIGHT });
                    tabla.AddCell(new PdfPCell(new Phrase(totalFormateado, fontNormal)) { BackgroundColor = fondoFila, HorizontalAlignment = Element.ALIGN_RIGHT });
                    pos++;
                }

                doc.Add(tabla);

                // Totales
                doc.Add(new Paragraph("\n"));   
                PdfPTable tablaTotales = new PdfPTable(2)
                {
                    WidthPercentage = 50,
                    HorizontalAlignment = Element.ALIGN_RIGHT
                };
                tablaTotales.SetWidths(new float[] { 2f, 1f }); 
                tablaTotales.WidthPercentage = 50;  
                tablaTotales.HorizontalAlignment = Element.ALIGN_RIGHT;
                BaseColor colorFila = new BaseColor(223, 240, 216); 
                BaseColor colorTotal = new BaseColor(169, 208, 142); 
                PdfPCell celdaTotalLabel = new PdfPCell(new Phrase("Total:", fontNegrita)) { Border = 0, BackgroundColor = colorTotal };
                PdfPCell celdaTotalValor = new PdfPCell(new Phrase(
                Convert.ToDecimal(total).ToString("C", new CultureInfo("es-MX")), fontNegrita))
                { Border = 0, BackgroundColor = colorTotal, HorizontalAlignment = Element.ALIGN_RIGHT };
                tablaTotales.AddCell(celdaTotalLabel);
                tablaTotales.AddCell(celdaTotalValor);
                decimal valorNumerico = decimal.Parse(total, System.Globalization.NumberStyles.Any);
                tablaTotales.AddCell(new PdfPCell(new Phrase("")) { Border = 0, Colspan = 2 });
                tablaTotales.AddCell(new PdfPCell(new Phrase(Numerosaletras.Convertir(valorNumerico), fontNormal))

                {
                    Border = 0,
                    Colspan = 2,
                    HorizontalAlignment = Element.ALIGN_CENTER
                });

                doc.Add(tablaTotales);
                doc.Add(new Paragraph("\nNOTAS:", fontNegrita));
                doc.Add(new Paragraph(notas, fontNotas));
                doc.Add(new Paragraph("- Sin otro particular, quedo a sus órdenes\n- Agradecemos su preferencia.\n\n", fontNotas));

                PdfPTable tablaFirma = new PdfPTable(1)
                {
                    WidthPercentage = 100
                };

                PdfPCell celdaTexto = new PdfPCell(new Phrase("Atentamente,\n" + usuario + "\nGerente de Ventas", fontCursiva))
                {
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Border = Rectangle.NO_BORDER,
                    PaddingTop = 15f,
                    PaddingBottom = 5f
                };

                tablaFirma.AddCell(celdaTexto);
                doc.Add(tablaFirma);

                doc.Close();
                MessageBox.Show("📄 PDF generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException)
            {
                MessageBox.Show("Archivo en uso. Ciérralo e inténtalo de nuevo.", "Archivo en uso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("No tienes permisos para guardar aquí.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
