using Ensumex.Utils;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Font = iTextSharp.text.Font;
using Image = iTextSharp.text.Image;
using Rectangle = iTextSharp.text.Rectangle;

namespace Ensumex.PDFtemplates
{
    public static class GeneraPDFTablas
    {
        public static void GenerarPDFConTablas(
            string rutaArchivo,
            List<List<object[]>> tablas,
            List<string> encabezados,
            string numeroCotizacion,
            string nombreCliente,
            string costoInstalacion,
            string costoFlete,
            string subtotal,
            string total,
            string descuento,
            //decimal porcentajeDescuento,
            string notas,
            string usuario
        )
        {
            try
            {
                Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
                string rutaFondo = Path.Combine(Application.StartupPath, "IMG", "Logo.png");
                string rutaFirma = Path.Combine(Application.StartupPath, "IMG", "Pie.png");

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
                writer.PageEvent = new FondoPiePDF(rutaFondo, rutaFirma, usuario);
                doc.Open();

                var fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                var fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                var fontNotas = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                var fontCursiva = FontFactory.GetFont(FontFactory.HELVETICA, 10, Font.ITALIC);
                var fontRojo = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.RED);
                var fontNegrita = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                var fontGris = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.GRAY);

                // LOGO
                string rutaLogo = Path.Combine(Application.StartupPath, "IMG", "Logo.png");
                if (File.Exists(rutaLogo))
                {
                    var logo = Image.GetInstance(rutaLogo);
                    logo.ScaleAbsolute(100f, 100f);
                    logo.SetAbsolutePosition(doc.LeftMargin, doc.PageSize.Height - doc.TopMargin - 70f);
                    doc.Add(logo);
                }

                // ENCABEZADO
                Paragraph titulo = new Paragraph("Cotización: " + numeroCotizacion, fontNegrita);
                titulo.Alignment = Element.ALIGN_RIGHT;
                doc.Add(titulo);

                Paragraph encabezado = new Paragraph(
                    "\nOaxaca de Juárez, Oaxaca a " + DateTime.Now.ToString("d 'de' MMMM 'de' yyyy") + "\n\n", fontGris);
                encabezado.Alignment = Element.ALIGN_RIGHT;
                doc.Add(encabezado);

                if (!string.IsNullOrWhiteSpace(nombreCliente))
                    doc.Add(new Paragraph("\nEstimado(a): " + nombreCliente+".", fontNegrita));
                else
                    doc.Add(new Paragraph("\nEstimado(a) Cliente:", fontNegrita));

                doc.Add(new Paragraph("\nPresente"));
                doc.Add(new Paragraph("En atención a su amable solicitud, me permito presentarle esta cotización para los siguientes productos:\n\n", fontNormal));

                int tablaNum = 1;
                foreach (var tabla in tablas)
                {
                    PdfPTable pdfTable = new PdfPTable(8)
                    {
                        WidthPercentage = 100
                    };
                    pdfTable.SetWidths(new float[] { 0.5f, 0.6f, 0.8f, 2.8f, 1.2f, 1.1f, 1.3f, 1.2f }); // Ajusta proporciones

                    // Encabezados
                    string[] headers = { "#", "CANT", "UNID", "DESCRIPCIÓN", "PRECIO UNIT", "IMPORTE", "DESCUENTO($)", "TOTAL" };
                    foreach (string header in headers)
                    {
                        PdfPCell celda = new PdfPCell(new Phrase(header, fontNegrita))
                        {
                            BackgroundColor = new BaseColor(141, 198, 63), // Verde #8DC63F
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            Padding = 5f
                        };
                        pdfTable.AddCell(celda);
                    }

                    int pos = 1;
                    BaseColor colorPar = BaseColor.WHITE;
                    BaseColor colorImpar = new BaseColor(245, 245, 245);

                    foreach (var row in tabla)
                    {
                        BaseColor bgColor = (pos % 2 == 0) ? colorPar : colorImpar;

                        // Datos del producto
                        string cantidadStr = row[7]?.ToString() ?? "0";
                        string unidad = row[3]?.ToString() ?? "";
                        string descripcion = row[2]?.ToString() ?? "";
                        decimal precioUnitario = Convert.ToDecimal(row[4] ?? 0);
                        decimal cantidad = Convert.ToDecimal(row[7] ?? 0);
                        decimal importe = precioUnitario * cantidad;

                        //Obtener porcentaje de descuento (ajusta el índice si viene en otra posición)
                        decimal porcentajeDescuento = Convert.ToDecimal(row[0] ?? 0);
                        decimal descuentoProd = importe * (porcentajeDescuento / 100m);
                        decimal totalProd = importe - descuentoProd;

                        pdfTable.AddCell(CeldaTexto(pos.ToString(), fontNormal, bgColor, Element.ALIGN_CENTER));
                        pdfTable.AddCell(CeldaTexto(cantidadStr, fontNormal, bgColor, Element.ALIGN_CENTER));
                        pdfTable.AddCell(CeldaTexto(unidad, fontNormal, bgColor, Element.ALIGN_CENTER));
                        pdfTable.AddCell(CeldaTexto(descripcion, fontNormal, bgColor, Element.ALIGN_LEFT, wrap: true)); 
                        pdfTable.AddCell(CeldaTexto(FormatMoneda(precioUnitario), fontNormal, bgColor, Element.ALIGN_RIGHT));
                        pdfTable.AddCell(CeldaTexto(FormatMoneda(importe), fontNormal, bgColor, Element.ALIGN_RIGHT));
                        pdfTable.AddCell(CeldaTexto("-" + FormatMoneda(descuentoProd), fontRojo, bgColor, Element.ALIGN_RIGHT));
                        pdfTable.AddCell(CeldaTexto(FormatMoneda(totalProd), fontNormal, bgColor, Element.ALIGN_RIGHT));
                        pos++;
                    }
                    tablaNum++;
                }

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
        private static PdfPCell CeldaTexto(string texto, Font fuente, BaseColor fondo, int align, bool wrap = true)
{
    return new PdfPCell(new Phrase(texto, fuente))
    {
        BackgroundColor = fondo,
        HorizontalAlignment = align,
        NoWrap = !wrap,              // ✅ Permite salto de línea
        MinimumHeight = 15f,         // ✅ Alto mínimo para evitar recorte
        Padding = 4f
    };
}

        private static string FormatMoneda(object valor)
        {
            if (decimal.TryParse(valor?.ToString(), out decimal result))
                return result.ToString("C2", new System.Globalization.CultureInfo("es-MX"));
            return "$0.00";
        }
    }
}