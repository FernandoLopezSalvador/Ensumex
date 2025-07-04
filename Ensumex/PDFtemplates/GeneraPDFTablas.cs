using Ensumex.Utils;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
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
            decimal porcentajeDescuento,
            string notas,
            string usuario
        )
        {
            try
            {
                Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
                string rutaFondo = Path.Combine(Application.StartupPath, "IMG", "Logo.png");
                string rutaFirma = Path.Combine(Application.StartupPath, "IMG", "nombre.jpg");
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
                writer.PageEvent = new FondoPiePDF(rutaFondo, rutaFirma);

                doc.Open();

                var fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                var fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                var fontnotas = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                var fontrojo = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.RED);
                var fontgris = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.GRAY);
                var fontNegrita = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                var fontCursiva = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 10);
                string rutaLogo = Path.Combine(Application.StartupPath, "IMG", "Logo.png");
                // Agregar logo
                if (File.Exists(rutaLogo))
                {
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(rutaLogo);
                    logo.ScaleAbsolute(100f, 100f);
                    logo.SetAbsolutePosition(doc.LeftMargin, doc.PageSize.Height - doc.TopMargin - 70f);
                    doc.Add(logo);
                }
                Paragraph titulo = new Paragraph("Cotización: " + numeroCotizacion, fontNegrita);
                titulo.Alignment = Element.ALIGN_RIGHT;
                doc.Add(titulo);
                Paragraph encabezado = new Paragraph("\nOaxaca de Juárez, Oaxaca a " + DateTime.Now.ToString("d 'de' MMMM 'de' yyyy") + "\n\n", fontgris);
                encabezado.Alignment = Element.ALIGN_RIGHT;
                doc.Add(encabezado);

                if (!string.IsNullOrWhiteSpace(nombreCliente))
                {
                    doc.Add(new Paragraph("\n\nEstimado(a) Cliente: ", fontNormal));
                    doc.Add(new Paragraph(nombreCliente, fontNegrita));
                }
                else
                {
                    doc.Add(new Paragraph("\nEstimado(a) Cliente:", fontNegrita));
                }
                doc.Add(new Paragraph("\nPresente"));
                doc.Add(new Paragraph("En atención a su amable solicitud, me permito presentarle esta cotización " +
                    "para la venta y/o la instalación del siguiente producto:", fontNormal));

                int tablaNum = 1;
                // Variables para notas generales
                bool contieneCalentador = false;
                bool contieneMotobomba = false;
                bool contieneAire = false;
                bool contieneBomba = false;
                bool contieneMantenimiento = false;
                bool contienePlomeria = false;

                foreach (var tabla in tablas)
                {
                    doc.Add(new Paragraph($"Opcion:#{tablaNum}", fontgris));
                    doc.Add(new Paragraph("\n"));

                    // --- DESCRIPCIÓN PRINCIPAL DEL PRODUCTO ---
                    string descripcionPrincipal = "";
                    foreach (var row in tabla)
                    {
                        string descripcion = row[2]?.ToString()?.ToUpper() ?? "";
                        if (descripcion.Contains("CALENT") ||
                            descripcion.Contains("MOTOBOMBA") || descripcion.Contains("MOTB") ||
                            descripcion.Contains("BOMBA DE") || descripcion.Contains("BOMBA TIPO") ||
                            descripcion.Contains("AIRE") ||
                            descripcion.Contains("MANTENIMIENTO") || descripcion.Contains("SERVICIO DE MANTENIM"))
                        {
                            descripcionPrincipal = descripcion;
                            break;
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(descripcionPrincipal))
                    {
                        doc.Add(new Paragraph("-" + descripcionPrincipal, fontNormal));
                        doc.Add(new Paragraph("\n", fontNormal));
                    }

                    PdfPTable pdfTable = new PdfPTable(6);
                    pdfTable.WidthPercentage = 100;
                    pdfTable.SetWidths(new float[] { 0.5f, 0.8f, 3f, 1f, 1f, 1f });

                    string[] headers = { "#", "Canti", "Descripción", "Precio", "Descuento", "Importe" };
                    foreach (string header in headers)
                    {
                        PdfPCell celda = new PdfPCell(new Phrase(header, fontNegrita));
                        celda.BackgroundColor = BaseColor.LIGHT_GRAY;
                        celda.HorizontalAlignment = Element.ALIGN_CENTER;
                        pdfTable.AddCell(celda);
                    }

                    int pos = 1;
                    decimal totalImporte = 0;

                    foreach (var row in tabla)
                    {
                        // # (posición)
                        pdfTable.AddCell(new PdfPCell(new Phrase(pos.ToString(), fontNormal)) { HorizontalAlignment = Element.ALIGN_CENTER });

                        // Canti (cantidad)
                        string cantidadStr = row[5]?.ToString() ?? "0";
                        decimal.TryParse(cantidadStr, out decimal cantidad);
                        pdfTable.AddCell(new PdfPCell(new Phrase(cantidadStr, fontNormal)) { HorizontalAlignment = Element.ALIGN_CENTER });

                        // Descripción
                        string descripcion = row[2]?.ToString() ?? "";
                        pdfTable.AddCell(new PdfPCell(new Phrase(descripcion, fontNormal)));

                        // Precio
                        string precioStr = row[4]?.ToString() ?? "0";
                        decimal.TryParse(precioStr, out decimal precioUnitario);
                        pdfTable.AddCell(new PdfPCell(new Phrase("$" + precioStr, fontNormal)) { HorizontalAlignment = Element.ALIGN_RIGHT });

                        // Descuento (por producto)
                        decimal descuentoProd = 0;
                        bool aplicarDescuento = row[0] is bool b && b;
                        if (aplicarDescuento && porcentajeDescuento > 0)
                        {
                            descuentoProd = (precioUnitario * cantidad) * (porcentajeDescuento / 100m);
                        }
                        PdfPCell celdaDescuento = new PdfPCell(new Phrase("$" + descuentoProd.ToString("0.00"), fontrojo))
                        {
                            HorizontalAlignment = Element.ALIGN_RIGHT
                        };
                        pdfTable.AddCell(celdaDescuento);

                        // Importe
                        decimal importe = (precioUnitario * cantidad) - descuentoProd;
                        pdfTable.AddCell(new PdfPCell(new Phrase(importe.ToString("0.00"), fontNormal)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                        totalImporte += importe;

                        // Analizar descripción para notas generales
                        string descMayus = descripcion.ToUpper();
                        if (descMayus.Contains("CALENT")) contieneCalentador = true;
                        if (descMayus.Contains("MOT") || descMayus.Contains("MOTB")) contieneMotobomba = true;
                        if (descMayus.Contains("BOMBA DE") || descMayus.Contains("BOMBA TIPO")) contieneBomba = true;
                        if (descMayus.Contains("AIRE ACONDICIONADO")) contieneAire = true;
                        if (descMayus.Contains("MANTENIMIENTO") || descMayus.Contains("SERVICIO DE MANTENIM")) contieneMantenimiento = true;
                        if (descMayus.Contains("KIT DE MATERIAL") || descMayus.Contains("PLOMERIA") || descMayus.Contains("PLOMERÍA")) contienePlomeria = true;

                        pos++;
                    }
                    doc.Add(pdfTable);
                    // --- TOTALES ---
                    doc.Add(new Paragraph("\n"));
                    PdfPTable tablaTotales = new PdfPTable(2);
                    tablaTotales.WidthPercentage = 50;
                    tablaTotales.HorizontalAlignment = Element.ALIGN_RIGHT;
                    tablaTotales.SetWidths(new float[] { 2f, 1f });
                    tablaTotales.AddCell(new PdfPCell(new Phrase("Mano de obra por instalación:", fontNormal)) { Border = 0 });
                    tablaTotales.AddCell(new PdfPCell(new Phrase("$" + costoInstalacion, fontNormal)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                    tablaTotales.AddCell(new PdfPCell(new Phrase("Costo por Envío/Flete:", fontNormal)) { Border = 0 });
                    tablaTotales.AddCell(new PdfPCell(new Phrase("$" + costoFlete, fontNormal)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });
                    tablaTotales.AddCell(new PdfPCell(new Phrase("Total:", fontNegrita)) { Border = 0 });
                    tablaTotales.AddCell(new PdfPCell(new Phrase(totalImporte.ToString("C", new CultureInfo("es-MX")), fontNegrita)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });

                    // Fila vacía
                    tablaTotales.AddCell(new PdfPCell(new Phrase("")) { Border = 0, Colspan = 2 });

                    // Total en letra
                    tablaTotales.AddCell(new PdfPCell(new Phrase(Numerosaletras.Convertir(totalImporte), fontNormal))
                    {
                        Border = 0,
                        Colspan = 2,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    });
                    doc.Add(tablaTotales);
                    tablaNum++;
                }

                // --- NOTAS GENERALES ---
                doc.Add(new Paragraph("NOTAS:\n", fontNegrita));

                // Selecciona la nota según el tipo de producto detectado en todas las tablas
                switch (true)
                {
                    case true when contieneMantenimiento:
                        doc.Add(new Paragraph(
                        "- Mantenimiento correctivo de unidad tipo paquete incluye:\n" +
                        "   Localización de fugas, vacío del sistema de refrigeración y recarga de gas refrigerante\n" +
                        "-  Mantenimiento preventivo de unidad tipo paquete incluye:\n" +
                        "   Limpieza de serpentín evaporador y serpentín condensador, turbinas de la unidad y carcasas de " +
                        "la misma. \n   Limpieza de la charola de condensados. \n   Limpieza y lavado de los filtros de aire del retorno " +
                        "de la unidad evaporadora. \n   Ajuste de la banda de turbina del evaporador. \n    Engrasado de chumaceras. " +
                        "\n Revisión y ajuste de terminales eléctricas del equipo. Revisión y ajuste de la carga de gas refrigerante.\n" +
                        "- Se requiere anticipo del 50% para comenzar el trabajo.\n" +
                        "- Los trabajos tardan de 3 a 4 días en quedar terminados.\n" +
                        "- Precios sujetos a cambios sin previo aviso.\n" +
                        "Sin otro particular quedo a sus órdenes.", fontnotas));
                        break;
                    case true when contieneMotobomba:
                        doc.Add(new Paragraph(
                         //"- La Motobomba incluye: Bomba, motor, controlador, 2m de cable plano sumergible, kit de instalación y ganchos de seguridad(mosquetón).\n" +
                         "- Garantía: 1 año contra defectos de fabricación.\n" +
                         //"- Garantía de la instalación: 6 meses contra fallos.\n" +
                         //"- No incluye material hidráulico (tubo de columna, tubería ni conexiones).\n" +
                         //"- El equipo se dimensionó en función de los datos proporcionados en el esquema entregado.\n" +
                         //"- Equipos sobre pedido, es necesario el 60% de anticipo. Entrega de 5 a 10 días hábiles.\n" +
                         "- Precios sujetos a cambios sin previo aviso\n", fontnotas));
                        break;

                    case true when contieneBomba:
                        doc.Add(new Paragraph(
                        "- Garantía: 2 años en bomba motor y arrancador.\n" +
                        "- Equipos sobre pedido. Es necesario un anticipo del 60%\n" +
                        "- Entrega de 3 a 5 dias hábiles\n" +
                        "- No incluye instalación\n" +
                        "- Precios sujetos a cambios sin previo aviso\n" +
                        "Sin otro particular, quedo a sus órdenes.\n\n", fontnotas));
                        break;
                    case true when contieneCalentador:
                        switch (true)
                        {
                            case true when contienePlomeria:
                                doc.Add(new Paragraph(
                             "-Garantía: 5 años contra defectos de fabricación. La garantía aplica únicamente para el termo tanque. No aplica la garantía " +
                             "por omisión en los cuidados que requiere el equipo, de acuerdo al manual de instalación y garantía que se entrega.\n" +
                             "-Garantía de la mano de obra: 6 meses contra fugas de agua.\n" +
                             "-Si necesita factura, la mano de obra se agrega más I.V.A.\n" +
                             "-Precios sujetos a cambios sin previo aviso.\n" +
                             "Sin otro particular, quedo a sus órdenes.\n\n", fontnotas));
                                break;
                            default:
                                doc.Add(new Paragraph(
                             "-Garantía: 5 años contra defectos de fabricación. La garantía aplica únicamente para el termo tanque. No aplica la garantía " +
                             "por omisión en los cuidados que requiere el equipo, de acuerdo al manual de instalación y garantía que se entrega.\n" +
                             "-Garantía de la mano de obra: 6 meses contra fugas de agua.\n" +
                             "-No incluye material de plomería.\n" +
                             "-Si necesita factura, la mano de obra se agrega más I.V.A.\n" +
                             "-Precios sujetos a cambios sin previo aviso.\n" +
                             "Sin otro particular, quedo a sus órdenes.\n\n", fontnotas));
                                break;
                        }
                        break;
                    default:
                        doc.Add(new Paragraph(
                        "-Si necesita factura, la mano de obra se agrega más I.V.A.\n" +
                        "-Precios sujetos a cambios sin previo aviso.\n" +
                        "Sin otro particular, quedo a sus órdenes.\n\n", fontnotas));
                        break;
                }

                // Si quieres agregar las notas libres del usuario:
                if (!string.IsNullOrWhiteSpace(notas))
                {
                    doc.Add(new Paragraph(notas, fontnotas));
                    doc.Add(new Paragraph("\n\n"));
                }
                // Firma y pie
                PdfPTable tablaFirma = new PdfPTable(1);
                tablaFirma.WidthPercentage = 100;
                PdfPCell celdaTexto = new PdfPCell(new Phrase("\n\n\n\nAtentamente,\n" + usuario + "\nRepresentante de la Cotización", fontCursiva));
                celdaTexto.HorizontalAlignment = Element.ALIGN_CENTER;
                celdaTexto.Border = Rectangle.NO_BORDER;
                celdaTexto.PaddingBottom = 10f;
                tablaFirma.AddCell(celdaTexto);
                doc.Add(tablaFirma);
                doc.Close();
                MessageBox.Show("PDF de tablas generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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