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
using Rectangle = iTextSharp.text.Rectangle;

namespace Ensumex.PDFtemplates
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
            decimal porcentajeDescuento, 
            string notas,
            DataGridView tablaCotizacion)
        {
            try
            {
                Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
                // Agregar fondo 
                string rutaFondo = Path.Combine(Application.StartupPath, "IMG", "Logo.png");
                writer.PageEvent = new FondoPDF(rutaFondo);
                doc.Open();
                var fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                var fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                var fontnotas = FontFactory.GetFont(FontFactory.HELVETICA, 9);
                var fontrojo = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.RED);
                var fontgris = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.GRAY);
                var fontNegrita = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                var fontCursiva = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 10);
                string rutaLogo = Path.Combine(Application.StartupPath, "IMG", "Logo.png");
                string rutaFirma = Path.Combine(Application.StartupPath, "IMG", "nombre.jpg");
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
                foreach (DataGridViewRow fila in tablaCotizacion.Rows)
                {
                    if (fila.IsNewRow) continue;
                    string descripcion = fila.Cells["DESCRIPCIÓN"].Value?.ToString()?.ToUpper() ?? "";
                    if (descripcion.Contains("CALENT"))
                    {
                        doc.Add(new Paragraph("-" + descripcion, fontNormal));
                        break;
                    }
                    else if (descripcion.Contains("MOTOBOMBA")|| descripcion.Contains("MOTB"))
                    {
                        doc.Add(new Paragraph("-" + descripcion, fontNormal));
                        break;
                    }
                    else if (descripcion.Contains("BOMBA DE") || descripcion.Contains("BOMBA TIPO"))
                    {
                        doc.Add(new Paragraph("-" + descripcion, fontNormal));
                        break;
                    }
                    else if (descripcion.Contains("AIRE"))
                    {
                        doc.Add(new Paragraph("-" + descripcion, fontNormal));
                        break;
                    }
                    else if (descripcion.Contains("MANTENIMIENTO") || descripcion.Contains("SERVICIO DE MANTENIM"))
                    {
                        doc.Add(new Paragraph("-" + descripcion, fontNormal));
                        break;
                    }
                }
                doc.Add(new Paragraph("\n", fontNormal));

                // --- TABLA DE PRODUCTOS ---
                PdfPTable tabla = new PdfPTable(6);
                tabla.WidthPercentage = 100;
                tabla.SetWidths(new float[] { 0.5f, 0.9f, 3f, 1f, 1f, 1.2f });

                string[] headers = { "#", "Canti", "Descripción", "Precio", "Descuento", "Importe" };
                foreach (string header in headers)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(header, fontNegrita));
                    celda.BackgroundColor = BaseColor.LIGHT_GRAY;
                    celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabla.AddCell(celda);
                }

                int pos = 1;
                foreach (DataGridViewRow row in tablaCotizacion.Rows)
                {   
                    if (row.IsNewRow) continue;

                    // # (posición)
                    tabla.AddCell(new PdfPCell(new Phrase(pos.ToString(), fontNormal)) { HorizontalAlignment = Element.ALIGN_CENTER });

                    // Canti (cantidad)
                    string cantidadStr = row.Cells["CANTIDAD"].Value?.ToString() ?? "0";
                    decimal.TryParse(cantidadStr, out decimal cantidad);
                    tabla.AddCell(new PdfPCell(new Phrase(cantidadStr, fontNormal)) { HorizontalAlignment = Element.ALIGN_CENTER });

                    // Descripción
                    string descripcion = row.Cells["DESCRIPCIÓN"].Value?.ToString() ?? "";
                    tabla.AddCell(new PdfPCell(new Phrase(descripcion, fontNormal)));

                    // Precio
                    string precioStr = row.Cells["PRECIO"].Value?.ToString() ?? "0";
                    decimal.TryParse(precioStr, out decimal precioUnitario);
                    tabla.AddCell(new PdfPCell(new Phrase("$"+precioStr, fontNormal)) { HorizontalAlignment = Element.ALIGN_RIGHT });

                    // Descuento (por producto)
                    decimal descuentoProd = 0;
                    if (row.Cells["AplicarDescuento"] != null && row.Cells["AplicarDescuento"].Value is bool aplicar && aplicar && porcentajeDescuento > 0)
                    {
                        descuentoProd = (precioUnitario * cantidad) * (porcentajeDescuento / 100m);
                    }
                    PdfPCell celdaDescuento = new PdfPCell(new Phrase("$"+descuentoProd.ToString("0.00"), fontrojo))
                    {
                        HorizontalAlignment = Element.ALIGN_RIGHT
                    };
                    tabla.AddCell(celdaDescuento);
                    decimal importe = (precioUnitario * cantidad) - descuentoProd;
                    tabla.AddCell(new PdfPCell(new Phrase(importe.ToString("0.00"), fontNormal)) { HorizontalAlignment = Element.ALIGN_RIGHT });
                    pos++;
                }
                doc.Add(tabla);
                // --- TOTALES Y COSTOS ADICIONALES ---
                doc.Add(new Paragraph("\n"));
                PdfPTable tablaTotales = new PdfPTable(2);
                tablaTotales.WidthPercentage = 50;
                tablaTotales.HorizontalAlignment = Element.ALIGN_RIGHT;
                tablaTotales.SetWidths(new float[] { 2f, 1f });

                tablaTotales.AddCell(new PdfPCell(new Phrase("Mano de obra por instalación:", fontNormal)) { Border = 0 });
                tablaTotales.AddCell(new PdfPCell(new Phrase("$" + costoInstalacion, fontNormal)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });

                tablaTotales.AddCell(new PdfPCell(new Phrase("Costo por Envío/Flete:", fontNormal)) { Border = 0 });
                tablaTotales.AddCell(new PdfPCell(new Phrase("$" + costoFlete, fontNormal)) { Border = 0, HorizontalAlignment = Element.ALIGN_RIGHT });

                decimal valorNumerico = decimal.Parse(total, System.Globalization.NumberStyles.Any);

                // Agregar fila con monto en número
                tablaTotales.AddCell(new PdfPCell(new Phrase("Total:", fontNegrita))
                {
                    Border = 0
                });
                tablaTotales.AddCell(new PdfPCell(new Phrase(valorNumerico.ToString("C", new CultureInfo("es-MX")), fontNegrita))
                {
                    Border = 0,
                    HorizontalAlignment = Element.ALIGN_RIGHT
                });

                // Agregar fila vacía
                tablaTotales.AddCell(new PdfPCell(new Phrase("")) { Border = 0, Colspan = 2 });

                tablaTotales.AddCell(new PdfPCell(new Phrase(Numerosaletras.Convertir(valorNumerico), fontNormal))
                {
                    Border = 0,
                    Colspan = 2,
                    HorizontalAlignment = Element.ALIGN_CENTER
                });
                doc.Add(tablaTotales);

                // Variables para verificar otros tipos de productos
                bool contieneCalentador = false;
                bool contieneMotobomba = false;
                bool contieneAire = false;
                bool contieneBomba = false;
                bool contieneMantenimiento = false;
                bool contienePlomeria = false;
                // Recorre las filas de la tabla para verificar los tipos de productos
                foreach (DataGridViewRow fila in tablaCotizacion.Rows)
                {
                    if (fila.IsNewRow) continue;
                    string descripcion = fila.Cells["DESCRIPCIÓN"].Value?.ToString()?.ToUpper() ?? "";
                    if (descripcion.Contains("CALENT"))
                    {
                        contieneCalentador = true;
                        break;

                    }
                    else if (descripcion.Contains("MOT")||descripcion.Contains("MOTB"))
                    {
                        contieneMotobomba = true;
                        break;
                    }
                    else if (descripcion.Contains("BOMBA DE") || descripcion.Contains("BOMBA TIPO"))
                    {
                        contieneBomba = true;
                        break;
                    }
                    else if (descripcion.Contains("AIRE"))
                    {
                        contieneAire = true;
                        break;
                    }
                    else if (descripcion.Contains("MANTENIMIENTO") || descripcion.Contains("SERVICIO DE MANTENIM"))
                    {
                        contieneMantenimiento = true;
                        break;
                    }
                    else if (descripcion.Contains("KIT DE MATERIAL"))
                    {
                        contienePlomeria = true;
                        break;
                    }
                }
                doc.Add(new Paragraph("NOTAS:\n", fontNegrita));
                // Agregar notas dependiendo del tipo de producto
                switch (true)
                {
                    case true when contieneMantenimiento:
                        doc.Add(new Paragraph(
                        "- Mantenimiento correctivo de unidad tipo paquete incluye:\n" +
                        "Localización de fugas, vacío del sistema de refrigeración y recarga de gas refrigerante\n" +
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
                        "- La Motobomba incluye: Bomba, motor, controlador, 2m de cable plano sumergible, kit de instalación y ganchos de seguridad(mosquetón).\n" +
                        "- Garantías: 12 años en Paneles Solares. 2 años en Bomba y Desconectador. 1 año en Accesorios.\n" +
                        "- Garantía de la instalación: 6 meses contra fallos.\n" +
                        "- No incluye material hidráulico (tubo de columna, tubería ni conexiones).\n" +
                        "- El equipo se dimensionó en función de los datos proporcionados en el esquema entregado.\n" +
                        "- Equipos sobre pedido, es necesario el 60% de anticipo. Entrega de 5 a 10 días hábiles.\n" +
                        "- Precios sujetos a cambios sin previo aviso\n" +
                        "Sin otro particular, quedo a sus órdenes.\n\n", fontnotas));
                        break;
                    case true when contieneAire:
                        doc.Add(new Paragraph(
                        "- Garantía del Aire Acondicionado: 5 años contra defectos de fabricación.\n" +
                        "- Garantía de la mano de obra: 6 meses.\n" +
                        "- Equipo en existencia para entrega inmediata.\n" +
                        "- El Aire Acondicionado lo puede pagar a 6 MSI con tarjetas BBVA pero sería precio sin descuento.\n" +
                        "- Si necesita factura, la mano de obra es más I.V.A.\n" +
                        "- Precios sujetos a cambios sin previo aviso.\n" +
                        "Sin otro particular quedo a sus órdenes.\n\n", fontnotas));
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
                        if (contienePlomeria == false)
                        {
                            doc.Add(new Paragraph(
                         "-Garantía: 5 años contra defectos de fabricación. La garantía aplica únicamente para el termo tanque. No aplica la garantía " +
                         "por omisión en los cuidados que requiere el equipo, de acuerdo al manual de instalación y garantía que se entrega.\n" +
                         "-Garantía de la mano de obra: 6 meses contra fugas de agua.\n" +
                         "-Si necesita factura, la mano de obra se agrega más I.V.A.\n" +
                         "-Precios sujetos a cambios sin previo aviso.\n" +
                         "Sin otro particular, quedo a sus órdenes.\n\n", fontnotas));
                            break;
                        }
                        else
                            doc.Add(new Paragraph(
                         "-Garantía: 5 años contra defectos de fabricación. La garantía aplica únicamente para el termo tanque. No aplica la garantía " +
                         "por omisión en los cuidados que requiere el equipo, de acuerdo al manual de instalación y garantía que se entrega.\n" +
                         "-Garantía de la mano de obra: 6 meses contra fugas de agua.\n" +
                         "-No incluye material de plomería.\n" +
                         "-Si necesita factura, la mano de obra se agrega más I.V.A.\n" +
                         "-Precios sujetos a cambios sin previo aviso.\n" +
                         "Sin otro particular, quedo a sus órdenes.\n\n", fontnotas));
                        break;
                    default:
                        doc.Add(new Paragraph(
                        "-Si necesita factura, la mano de obra se agrega más I.V.A.\n" +
                        "-Precios sujetos a cambios sin previo aviso.\n" +
                        "Sin otro particular, quedo a sus órdenes.\n\n", fontnotas));
                        break;
                }
                doc.Add(new Paragraph(notas, fontnotas));
                // Crear una tabla de una columna centrada
                PdfPTable tablaFirma = new PdfPTable(1);
                tablaFirma.WidthPercentage = 100;
                PdfPCell celdaTexto = new PdfPCell(new Phrase("\n\n\n\nAtentamente,\nCarlos Hernández Velasco\nRepresentante de Ventas", fontCursiva));
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
                doc.Add(new Paragraph("Av. Lázaro Cárdenas 104-B.", fontNormal) { Alignment = Element.ALIGN_CENTER });
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