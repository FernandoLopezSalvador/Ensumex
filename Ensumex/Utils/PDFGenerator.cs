using DocumentFormat.OpenXml.Office2013.Word;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Rectangle = iTextSharp.text.Rectangle;

namespace Ensumex.Utils
{
    internal class PDFGenerator
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
            string notas,
            DataGridView tablaCotizacion){
            try
            {
                Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
                PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
                doc.Open();
                var fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                var fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                var fontNegrita = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                var fontCursiva = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 10);
                string rutaLogo = Path.Combine(Application.StartupPath, "IMG", "Logo.png");
                string rutaFirma = Path.Combine(Application.StartupPath, "IMG", "nombre.jpg");
                // Agregar logo
                if (File.Exists(rutaLogo))
                {
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(rutaLogo);
                    logo.ScaleAbsolute(100f, 100f); 
                    logo.SetAbsolutePosition(doc.LeftMargin, doc.PageSize.Height - doc.TopMargin -70f);
                    doc.Add(logo);
                }
                Paragraph titulo = new Paragraph("Cotización: " + numeroCotizacion, fontNegrita);
                titulo.Alignment = Element.ALIGN_RIGHT;
                doc.Add(titulo);
                Paragraph encabezado = new Paragraph("\nOaxaca de Juárez, Oaxaca a " + DateTime.Now.ToString("d 'de' MMMM 'de' yyyy") + "\n\n", fontNormal);
                encabezado.Alignment = Element.ALIGN_RIGHT;
                doc.Add(encabezado);

                if (!string.IsNullOrWhiteSpace(nombreCliente))
                {
                    doc.Add(new Paragraph("\n\nEstimado Cliente: ", fontNormal));
                    doc.Add(new Paragraph(nombreCliente, fontNegrita));
                    
                }
                else
                {
                    doc.Add(new Paragraph("\nEstimado Cliente:", fontNegrita));
                }
                doc.Add(new Paragraph("\nPresente"));
                doc.Add(new Paragraph("En atención a su amable solicitud, me permito presentarle esta cotización para la venta e instalación del siguiente producto:", fontNormal));
                doc.Add(new Paragraph("\n", fontNormal));

                    // Agregar descripciones de los productos
                foreach (DataGridViewRow fila in tablaCotizacion.Rows)
                {
                    if (fila.IsNewRow) continue; // Ignora la fila nueva vacía
                    string descripcion = fila.Cells["DESCRIPCIÓN"].Value?.ToString() ?? "Sin descripción";
                    doc.Add(new Paragraph(descripcion, fontNegrita));
                }
                doc.Add(new Paragraph("\n", fontNormal));
                // Tabla
                PdfPTable tabla = new PdfPTable(5);
                tabla.WidthPercentage = 100;
                tabla.SetWidths(new float[] {1f, 3f, 1.5f, .8f, 1f});
                string[] headers = {"CLAVE", "DESCRICIÓN", "PRECIO", "Cantidad", "Tasa de cambio"};
                foreach (string header in headers)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(header, fontNormal));
                    celda.BackgroundColor = BaseColor.LIGHT_GRAY;
                    celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabla.AddCell(celda);
                }
                foreach (DataGridViewRow row in tablaCotizacion.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        tabla.AddCell(new Phrase(row.Cells["CLAVE"].Value?.ToString() ?? "", fontNormal));
                        tabla.AddCell(new Phrase(row.Cells["DESCRIPCIÓN"].Value?.ToString() ?? "", fontNormal));
                        tabla.AddCell(new Phrase(row.Cells["PRECIO"].Value?.ToString() ?? "", fontNormal));
                        tabla.AddCell(new Phrase(row.Cells["Cantidad"].Value?.ToString() ?? "", fontNormal));
                        tabla.AddCell(new Phrase(row.Cells["TasaCambio"].Value?.ToString() ?? "", fontNormal));
                    }
                }
                    // Ajustando lo que se muestra en la tabla 
                tabla.AddCell(new PdfPCell(new Phrase("Subtotal:", fontNegrita)) { Colspan = 4, HorizontalAlignment = Element.ALIGN_LEFT });
                tabla.AddCell(new Phrase(subtotal, fontNormal));
                tabla.AddCell(new PdfPCell(new Phrase("Descuento:", fontNormal)) { Colspan = 4, HorizontalAlignment = Element.ALIGN_LEFT });
                tabla.AddCell(new Phrase(descuento, fontNormal));
                tabla.AddCell(new PdfPCell(new Phrase("Mano de obra por instalción:", fontNormal)) { Colspan = 4, HorizontalAlignment = Element.ALIGN_LEFT });
                tabla.AddCell(new Phrase(costoInstalacion, fontNormal));
                tabla.AddCell(new PdfPCell(new Phrase("Costo por Envio/Flete:", fontNormal)) { Colspan = 4, HorizontalAlignment = Element.ALIGN_LEFT });
                tabla.AddCell(new Phrase(costoFlete, fontNormal));
                tabla.AddCell(new PdfPCell(new Phrase("Total:", fontNegrita)) { Colspan = 4, HorizontalAlignment = Element.ALIGN_LEFT });
                tabla.AddCell(new Phrase(total, fontNormal));
                doc.Add(tabla);
                doc.Add(new Paragraph("\n"));

                // Verifica si alguna descripción contiene la palabra "CALENTADOR" para mostrar notas adicionales o notas personalizadas dependiendo de lo que se quiera vender
                bool contieneCalentador = false;
                foreach (DataGridViewRow fila in tablaCotizacion.Rows)
                {
                    if (fila.IsNewRow) continue;
                    string descripcion = fila.Cells["DESCRIPCIÓN"].Value?.ToString()?.ToUpper() ?? "";
                    if (descripcion.Contains("CALENTADOR"))
                    {
                        contieneCalentador = true;
                        break;
                    }
                }
                doc.Add(new Paragraph("NOTAS:\n", fontNegrita));
                if (contieneCalentador)
                {
                    doc.Add(new Paragraph(
                        "- Garantía: 5 años contra defectos de fabricación. La garantía aplica únicamente para el termo tanque. No aplica la garantía " +
                        "por omisión en los cuidados que requiere el equipo, de acuerdo al manual de instalación y garantía que se entrega.\n" +
                        "- Garantía de la mano de obra: 6 meses contra fugas de agua.\n" +
                        "- Equipos en existencia para entrega inmediata.\n" +
                        "- No incluye material de plomería.\n" +
                        "- Si necesita factura, la mano de obra se agrega más I.V.A.\n" +
                        "- Precios sujetos a cambios sin previo aviso.\n" +
                        "Sin otro particular, quedo a sus órdenes.\n\n", fontNormal));
                }
                else
                {
                    doc.Add(new Paragraph(
                    "- Si necesita factura, la mano de obra se agrega más I.V.A.\n" +
                    "- Precios sujetos a cambios sin previo aviso.\n" +
                    "Sin otro particular, quedo a sus órdenes.\n\n", fontNormal));
                }
               
                doc.Add(new Paragraph(notas, fontNormal));

                // Crear una tabla de una columna centrada
                PdfPTable tablaFirma = new PdfPTable(1);  
                tablaFirma.WidthPercentage = 100;
                    // Celda con texto
                PdfPCell celdaTexto = new PdfPCell(new Phrase("\n\n\n\n\nAtentamente,\nCarlos Valdez\nRepresentante de Ventas", fontCursiva));
                celdaTexto.HorizontalAlignment = Element.ALIGN_CENTER;
                celdaTexto.Border = Rectangle.NO_BORDER;
                celdaTexto.PaddingBottom = 10f; 
                tablaFirma.AddCell(celdaTexto);
                // Celda con imagen (si existe)
                if (File.Exists(rutaFirma))
                {
                    iTextSharp.text.Image firma = iTextSharp.text.Image.GetInstance(rutaFirma);
                    firma.ScaleAbsolute(120f, 60f);
                    firma.Alignment = Element.ALIGN_CENTER;
                    PdfPCell celdaImagen = new PdfPCell(firma);
                    celdaImagen.HorizontalAlignment = Element.ALIGN_CENTER;
                    celdaImagen.Border = Rectangle.NO_BORDER;
                    tablaFirma.AddCell(celdaImagen);
                }
                // Agregar la tabla al documento
                doc.Add(tablaFirma);
                doc.Add(new Paragraph("Av. Lázaro Cárdenas 104-B. ", fontNormal) { Alignment = Element.ALIGN_CENTER });
                doc.Add(new Paragraph("Sta. Lucía del Camino, Oaxaca. Tels: 951-206-6895 y 951-206-0293", fontNormal) { Alignment = Element.ALIGN_CENTER });
                doc.Close();

                MessageBox.Show("📄 PDF generado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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