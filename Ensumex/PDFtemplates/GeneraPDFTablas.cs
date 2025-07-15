using Ensumex.Utils;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
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
                string rutaFondo = Path.Combine(Application.StartupPath, "IMG", "Fondologo.png");
                string rutaFirma = Path.Combine(Application.StartupPath, "IMG", "Pie.png");

                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
                writer.PageEvent = new FondoPiePDF(rutaFondo, rutaFirma, usuario);
                doc.Open();

                var fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                var fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                var fontNotas = FontFactory.GetFont(FontFactory.HELVETICA, 9);
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
                    doc.Add(new Paragraph("\nEstimado(a): " + nombreCliente, fontNegrita));
                else
                    doc.Add(new Paragraph("\nEstimado(a) Cliente:", fontNegrita));

                doc.Add(new Paragraph("\nPresente"));
                doc.Add(new Paragraph("En atención a su amable solicitud, me permito presentarle esta cotización para los siguientes productos:\n", fontNormal));

                int tablaNum = 1;
                foreach (var tabla in tablas)
                {
                    doc.Add(new Paragraph($"\nOpción #{tablaNum}", fontNegrita));

                    PdfPTable pdfTable = new PdfPTable(6);
                    pdfTable.WidthPercentage = 100;
                    pdfTable.SetWidths(new float[] { 0.5f, 0.8f, 3f, 1f, 1f, 1f });

                    string[] headers = { "#", "Canti", "Descripción", "Precio", "Descuento", "Importe" };
                    foreach (string header in headers)
                    {
                        PdfPCell celda = new PdfPCell(new Phrase(header, fontNegrita))
                        {
                            BackgroundColor = new BaseColor(144, 238, 144),
                            HorizontalAlignment = Element.ALIGN_CENTER
                        };
                        pdfTable.AddCell(celda);
                    }

                    int pos = 1;
                    foreach (var row in tabla)
                    {
                        pdfTable.AddCell(new PdfPCell(new Phrase(pos.ToString(), fontNormal)) { HorizontalAlignment = Element.ALIGN_CENTER });
                        pdfTable.AddCell(new PdfPCell(new Phrase(row[7]?.ToString() ?? "0", fontNormal)) { HorizontalAlignment = Element.ALIGN_CENTER });
                        pdfTable.AddCell(new PdfPCell(new Phrase(row[2]?.ToString() ?? "", fontNormal)));
                        pdfTable.AddCell(new PdfPCell(new Phrase("$" + row[4]?.ToString() ?? "0", fontNormal)) { HorizontalAlignment = Element.ALIGN_RIGHT });

                        decimal precio = Convert.ToDecimal(row[4] ?? 0);
                        decimal cantidad = Convert.ToDecimal(row[7] ?? 0);
                        decimal descProd = 0;
                        pdfTable.AddCell(new PdfPCell(new Phrase("$" + descProd.ToString("0.00"), fontRojo)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                        decimal importe = (precio * cantidad) - descProd;
                        pdfTable.AddCell(new PdfPCell(new Phrase("$" + importe.ToString("0.00"), fontNormal)) { HorizontalAlignment = Element.ALIGN_RIGHT });

                        pos++;
                    }

                    doc.Add(pdfTable);
                    doc.Add(new Paragraph("\nOpción: " + tablaNum, fontGris));
                    tablaNum++;
                }

                // 📌 NOTAS GENERALES
                doc.Add(new Paragraph("\nNotas Generales:", fontNegrita));
                doc.Add(new Paragraph("- Garantía  según producto.\n- Precios sujetos a cambios sin previo aviso.\n- Sin otro particular, quedo a sus órdenes.\n- Agradecemos su preferencia.", fontNotas));

                // NOTAS LIBRES
                if (!string.IsNullOrWhiteSpace(notas))
                    doc.Add(new Paragraph("\n" + notas, fontNotas));

                // Texto con usuario
                PdfPCell celdaTexto = new PdfPCell(new Phrase("Atentamente,\n" + usuario + "\nVendedor", fontGris))
                {
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Border = Rectangle.NO_BORDER,
                    PaddingTop = 15f, // Espacio superior
                    PaddingBottom = 5f
                };
                doc.Add(celdaTexto);
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

        private static string ObtenerNotasPorProductos(List<string> descripciones)
        {
            var notas = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["CALENTADOR"] = "-Garantía: 5 años contra defectos de fabricación. Solo para el termo tanque...\n-Precios sujetos a cambios sin previo aviso.\n",
                ["CALENT"] = "-Garantía: 5 años contra defectos de fabricación. Solo para el termo tanque...\n-Precios sujetos a cambios sin previo aviso.\n",


                ["AIRE ACONDICIONADO"] = "-Garantía: 5 años contra defectos de fabricación.\n" +
                    "-El Aire Acondicionado lo puede pagar a 6 MSI con tarjetas BBVA pero sería precio sin descuento.\n" +
                    "-Precios sujetos a cambios sin previo aviso.\n",

                ["MOTOBOMBA"] = "-Garantía: 1 año contra defectos de fabricación." +
                    "-Equipos sobre pedido, es necesario el 60% de anticipo. Entrega de 5 a 10 días hábiles.\n" +
                    "\n-Precios sujetos a cambios sin previo aviso.\n",

                ["MOT:BOMB"] = "-Garantía: 1 año contra defectos de fabricación." +
                    "-Equipos sobre pedido, es necesario el 60% de anticipo. Entrega de 5 a 10 días hábiles.\n" +
                    "\n-Precios sujetos a cambios sin previo aviso.\n",


                ["BOMBA"] = "-Garantía: 2 años en bomba motor y arrancador\n" +
                    "- Equipos sobre pedido. Es necesario un anticipo del 60%\n" +
                    "- Entrega de 3 a 5 dias hábiles\n" +
                    "-Precios sujetos a cambios sin previo aviso.\n",

                ["MANTENIMIENTO"] = "- Mantenimiento correctivo de unidad tipo paquete incluye:\nLocalización de fugas, vacío del sistema de refrigeración y recarga de gas refrigerante\n" +
                    "Mantenimiento preventivo de unidad tipo paquete incluye:\n" +
                    "Limpieza de serpentín evaporador y serpentín condensador, turbinas de la unidad y carcasas de" +
                    "la misma. \n   Limpieza de la charola de condensados. \n   Limpieza y lavado de los filtros de aire del retorno" +
                    "de la unidad evaporadora. \n   Ajuste de la banda de turbina del evaporador. \n    Engrasado de chumaceras." +
                    "\n Revisión y ajuste de terminales eléctricas del equipo. Revisión y ajuste de la carga de gas refrigerante.\n" +
                    "- Se requiere anticipo del 50% para comenzar el trabajo.\n" +
                    "- Los trabajos tardan de 3 a 4 días en quedar terminados.\n" +
                    "- Precios sujetos a cambios sin previo aviso.\n",

                ["MANTEMIN"] = "- Mantenimiento correctivo de unidad tipo paquete incluye:\nLocalización de fugas, vacío del sistema de refrigeración y recarga de gas refrigerante\n" +
                    "Mantenimiento preventivo de unidad tipo paquete incluye:\n" +
                    "Limpieza de serpentín evaporador y serpentín condensador, turbinas de la unidad y carcasas de" +
                    "la misma. \n   Limpieza de la charola de condensados. \n   Limpieza y lavado de los filtros de aire del retorno" +
                    "de la unidad evaporadora. \n   Ajuste de la banda de turbina del evaporador. \n    Engrasado de chumaceras." +
                    "\n Revisión y ajuste de terminales eléctricas del equipo. Revisión y ajuste de la carga de gas refrigerante.\n" +
                    "- Se requiere anticipo del 50% para comenzar el trabajo.\n" +
                    "- Los trabajos tardan de 3 a 4 días en quedar terminados.\n" +
                    "- Precios sujetos a cambios sin previo aviso.\n"
            };

            foreach (var desc in descripciones)
            {
                foreach (var clave in notas.Keys)
                {
                    if (desc.ToUpper().Contains(clave))
                        return notas[clave];
                }
            }
            return "- Garantía estándar y precios sujetos a cambios.\n";
        }
    }
}