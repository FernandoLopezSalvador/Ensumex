using DocumentFormat.OpenXml.Drawing.Diagrams;
using DocumentFormat.OpenXml.Office2013.Word;
using Ensumex.Utils;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Image = iTextSharp.text.Image;
using Rectangle = iTextSharp.text.Rectangle;

namespace Ensumex.PDFtemplates
{
    public static class PDFGenerator
    {
        public static void GenerarPDFCotizacion(
            string rutaArchivo,
            string numeroCotizacion,
            string nombreCliente,
            string costoInstalacion,
            string costoFlete,
            string subtotal,
            string total,
            string descuento,
            decimal porcentajeDescuento,
            string notas,
            DataGridView tablaCotizacion,
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

                // Fuentes
                var fontNegrita = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                var fontheader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8);
                var fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                var fontNotas = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                var fontRojo = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.RED);
                var fontCursiva = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 10);
                var fontGris = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.GRAY);

                // Logo
                string rutaLogo = Path.Combine(Application.StartupPath, "IMG", "Logo.png");
                if (File.Exists(rutaLogo))
                {
                    Image logo = Image.GetInstance(rutaLogo);
                    logo.ScaleAbsolute(100f, 100f);
                    logo.SetAbsolutePosition(doc.LeftMargin, doc.PageSize.Height - doc.TopMargin - 70f);
                    doc.Add(logo);
                }

                // Encabezado
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
                    doc.Add(new Paragraph("\nEstimado(a): " + nombreCliente+".", fontNegrita));
                }
                else
                {
                    doc.Add(new Paragraph("\nEstimado(a) Cliente:", fontNegrita));
                }

                doc.Add(new Paragraph("\nPresente", fontNegrita));
                doc.Add(new Paragraph("\nEn atención a su amable solicitud, me permito presentarle esta cotización para los siguientes productos:\n\n", fontNormal));

                // Tabla de productos
                PdfPTable tabla = new PdfPTable(8)
                {
                    WidthPercentage = 100
                };

                tabla.SetWidths(new float[] { 0.5f, 0.6f, 0.8f, 2.8f, 1f, 1f, 1.2f, 1.2f });

                // Encabezados de tabla
                string[] headers = { "#","CANT","UNID","DESCRIPCIÓN","PRECIO UNIT","IMPORTE","DESCUENTO  ($)", "TOTAL"};

                // Añadir encabezados con fondo verde
                foreach (string header in headers)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(header, fontheader))
                    {
                        BackgroundColor = new BaseColor(141, 198, 63), // Verde #8DC63F
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        Padding = 5f
                    };
                    tabla.AddCell(celda);
                }

                int pos = 1;
                BaseColor colorFilaPar = BaseColor.WHITE;              
                BaseColor colorFilaImpar = new BaseColor(245, 245, 245); 

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

                    // Cálculos corregidos
                    decimal importe = precioUnitario * cantidad;
                    decimal descuentoFila = importe * (porcentajeDescuentoFila / 100m);
                    decimal total1 = importe - descuentoFila;

                    // Formatear en moneda
                    string precioFormateado = precioUnitario.ToString("C2", new CultureInfo("es-MX"));
                    string descuentoFormateado = descuentoFila.ToString("C2", new CultureInfo("es-MX"));
                    string importeFormateado = importe.ToString("C2", new CultureInfo("es-MX"));
                    string totalFormateado = total1.ToString("C2", new CultureInfo("es-MX"));

                    // Alternar color de fondo
                    BaseColor fondoFila = (pos % 2 == 0) ? colorFilaPar : colorFilaImpar;

                    // Añadir celdas
                    tabla.AddCell(new PdfPCell(new Phrase(pos.ToString(), fontNormal)) { BackgroundColor = fondoFila, HorizontalAlignment = Element.ALIGN_CENTER });
                    tabla.AddCell(new PdfPCell(new Phrase(cantidadStr, fontNormal)) { BackgroundColor = fondoFila, HorizontalAlignment = Element.ALIGN_CENTER });
                    tabla.AddCell(new PdfPCell(new Phrase(unidad, fontNormal)) { BackgroundColor = fondoFila, HorizontalAlignment = Element.ALIGN_CENTER });
                    tabla.AddCell(new PdfPCell(new Phrase(descripcion, fontNormal)) { BackgroundColor = fondoFila, NoWrap = false });
                    tabla.AddCell(new PdfPCell(new Phrase(precioFormateado, fontNormal)) { BackgroundColor = fondoFila, HorizontalAlignment = Element.ALIGN_RIGHT });
                    tabla.AddCell(new PdfPCell(new Phrase(importeFormateado, fontNormal)) { BackgroundColor = fondoFila, HorizontalAlignment = Element.ALIGN_RIGHT });
                    tabla.AddCell(new PdfPCell(new Phrase("-" + descuentoFormateado, fontRojo)) { BackgroundColor = fondoFila, HorizontalAlignment = Element.ALIGN_RIGHT });
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
                    // añadir costo de instalación, flete y total
                    tablaTotales.SetWidths(new float[] { 2f, 1f });
                    tablaTotales.WidthPercentage = 50; // ancho de la tabla
                    tablaTotales.HorizontalAlignment = Element.ALIGN_RIGHT; 

                    // Color de fondo para las filas normales
                    BaseColor colorFila = new BaseColor(223, 240, 216); // verde claro
                                                                        // Color de fondo para la fila de total
                    BaseColor colorTotal = new BaseColor(169, 208, 142); // verde más fuerte

                    // Mano de obra
                    PdfPCell celdaManoObra = new PdfPCell(new Phrase("Mano de obra por instalación:", fontNormal)) { Border = 0, BackgroundColor = colorFila };
                    PdfPCell celdaCostoInstalacion = new PdfPCell(new Phrase("$" + costoInstalacion, fontNormal)) { Border = 0, BackgroundColor = colorFila, HorizontalAlignment = Element.ALIGN_RIGHT };
                    tablaTotales.AddCell(celdaManoObra);
                    tablaTotales.AddCell(celdaCostoInstalacion);

                    // Flete
                    PdfPCell celdaFlete = new PdfPCell(new Phrase("Costo por Envío/Flete:", fontNormal)) { Border = 0, BackgroundColor = colorFila };
                    PdfPCell celdaCostoFlete = new PdfPCell(new Phrase("$" + costoFlete, fontNormal)) { Border = 0, BackgroundColor = colorFila, HorizontalAlignment = Element.ALIGN_RIGHT };
                    tablaTotales.AddCell(celdaFlete);
                    tablaTotales.AddCell(celdaCostoFlete);

                    // Total
                    PdfPCell celdaTotalLabel = new PdfPCell(new Phrase("Total:", fontNegrita)) { Border = 0, BackgroundColor = colorTotal };
                    PdfPCell celdaTotalValor = new PdfPCell(new Phrase(
                        Convert.ToDecimal(total).ToString("C", new CultureInfo("es-MX")), fontNegrita))
                    { Border = 0, BackgroundColor = colorTotal, HorizontalAlignment = Element.ALIGN_RIGHT };
                    tablaTotales.AddCell(celdaTotalLabel);
                    tablaTotales.AddCell(celdaTotalValor);

                    // Convertir número a letras y agregar fila
                    decimal valorNumerico = decimal.Parse(total, System.Globalization.NumberStyles.Any);
                    tablaTotales.AddCell(new PdfPCell(new Phrase("")) { Border = 0, Colspan = 2 });
                    tablaTotales.AddCell(new PdfPCell(new Phrase(Numerosaletras.Convertir(valorNumerico), fontNormal))

                    {
                        Border = 0,
                        Colspan = 2,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    });

                    // Ahora SÍ agregar la tabla al documento
                    doc.Add(tablaTotales);

                // Notas generales
                doc.Add(new Paragraph("\nNOTAS:", fontNegrita));
                doc.Add(new Paragraph(notas, fontNotas));
                doc.Add(new Paragraph("- Sin otro particular, quedo a sus órdenes\n- Agradecemos su preferencia.\n\n", fontNotas));

                // Firma
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