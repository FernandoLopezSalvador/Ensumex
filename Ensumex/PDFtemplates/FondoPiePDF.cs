using Ensumex.Models;
using Ensumex.Utils;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Forms;
using Rectangle = iTextSharp.text.Rectangle;

namespace Ensumex.PDFtemplates
{
    public class FondoPiePDF : PdfPageEventHelper
    {
        private readonly string rutaFondo;
        private readonly string rutaFirma;
        private readonly string usuario;

        private readonly iTextSharp.text.Font fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.DARK_GRAY);
        private readonly iTextSharp.text.Font fontBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.BLACK);
        private readonly iTextSharp.text.Font fontNormalGrande = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.DARK_GRAY);
        private readonly iTextSharp.text.Font fontBoldGrande = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.BLACK);

        public FondoPiePDF(string rutaFondo, string rutaFirma, string usuario)
        {
            this.rutaFondo = rutaFondo;
            this.rutaFirma = rutaFirma;
            this.usuario = usuario;
        }
        public override void OnEndPage(PdfWriter writer, Document document)
        {
        }

        public static void StampFooterToLastPage(string pdfPath, string rutaFondo, string rutaFirma, string usuario)
        {
            if (!File.Exists(pdfPath)) return;

            string tempPath = Path.GetTempFileName();
            try
            {
                using (var reader = new PdfReader(pdfPath))
                {
                    int lastPage = reader.NumberOfPages;
                    var pageSize = reader.GetPageSize(lastPage);

                    // márgenes y posición estimada del pie (coincide con la lógica previa)
                    float leftMargin = 40f;
                    float rightMargin = 40f;
                    float totalWidth = pageSize.Width - leftMargin - rightMargin;
                    float yPieDefault = leftMargin + 105f; // valor usado anteriormente

                    // Extraer la posición más baja de texto en la última página
                    float minTextY = float.MaxValue;
                    try
                    {
                        var parser = new iTextSharp.text.pdf.parser.PdfReaderContentParser(reader);
                        var listener = new TextPositionRenderListener();
                        parser.ProcessContent(lastPage, listener);
                        if (listener.MinY != float.MaxValue) minTextY = listener.MinY;
                        else minTextY = 0; // sin texto detectado
                    }
                    catch
                    {
                        // si falla extracción, forzar comportamiento conservador (insertar página nueva)
                        minTextY = 0;
                    }

                    bool requierePaginaNueva = false;
                    // Si el contenido más bajo está por debajo (o muy cerca) de la posición del pie,
                    // consideramos que hay riesgo de solapamiento y añadimos página nueva.
                    float margenSeguridad = 10f; // ajuste fino
                    if (minTextY <= yPieDefault + margenSeguridad)
                        requierePaginaNueva = true;

                    using (var fs = new FileStream(tempPath, FileMode.Create, FileAccess.Write))
                    using (var stamper = new PdfStamper(reader, fs))
                    {
                        int targetPage = lastPage;
                        if (requierePaginaNueva)
                        {
                            // Insertar página nueva al final con mismo tamaño
                            int footerPageIndex = lastPage + 1;
                            stamper.InsertPage(footerPageIndex, pageSize);
                            targetPage = footerPageIndex;
                        }

                        var fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.DARK_GRAY);
                        var fontBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.BLACK);
                        var fontNormalGrande = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.DARK_GRAY);
                        var fontBoldGrande = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.BLACK);

                        PdfPTable tablaPie = new PdfPTable(2) { TotalWidth = totalWidth };
                        tablaPie.SetWidths(new float[] { 1.35f, 1.35f });

                        PdfPTable tablaBanco = new PdfPTable(1) { WidthPercentage = 100 };

                        PdfPCell Fila(string label, string dato)
                        {
                            PdfPTable fila = new PdfPTable(2);
                            fila.WidthPercentage = 100;
                            fila.SetWidths(new float[] { 1.2f, 3.0f });

                            PdfPCell c1 = new PdfPCell(new Phrase(label, fontBold))
                            {
                                Border = Rectangle.NO_BORDER,
                                PaddingBottom = 2f,
                                PaddingTop = 2f
                            };

                            PdfPCell c2 = new PdfPCell(new Phrase(dato, fontNormal))
                            {
                                Border = Rectangle.NO_BORDER,
                                PaddingBottom = 2f,
                                PaddingTop = 2f 
                            };

                            fila.AddCell(c1);
                            fila.AddCell(c2);

                            return new PdfPCell(fila)
                            {
                                Border = Rectangle.NO_BORDER,
                                PaddingBottom = 3f
                            };
                        }

                        PdfPCell tituloBanco = new PdfPCell(new Phrase("Datos Bancarios", fontBold))
                        {
                            Border = Rectangle.NO_BORDER,
                            PaddingBottom = 6f
                        };
                        tablaBanco.AddCell(tituloBanco);

                        tablaBanco.AddCell(Fila("Nombre:", "HV Energías Sustentables de México, S.A. de C.V."));
                        tablaBanco.AddCell(Fila("RFC:", "HES150616639"));
                        tablaBanco.AddCell(Fila("Banco:", "BBVA Bancomer"));
                        tablaBanco.AddCell(Fila("Cuenta:", "0199948457"));
                        tablaBanco.AddCell(Fila("Clave:", "012610001999484570"));

                        PdfPCell celdaBanco = new PdfPCell(tablaBanco)
                        {
                            Border = Rectangle.BOX,
                            BorderWidth = 1.5f,
                            Padding = 8f
                        };

                        PdfPTable tablaDireccion = new PdfPTable(1);
                        tablaDireccion.WidthPercentage = 100;
                        tablaDireccion.DefaultCell.Border = Rectangle.NO_BORDER;

                        PdfPCell tituloDireccion = new PdfPCell(new Phrase("Datos de Contacto", fontBoldGrande))
                        {
                            Border = Rectangle.NO_BORDER,
                            PaddingBottom = 6f,
                            HorizontalAlignment = Element.ALIGN_RIGHT
                        };
                        tablaDireccion.AddCell(tituloDireccion);

                        tablaDireccion.AddCell(new PdfPCell(new Phrase("Av. Lázaro Cárdenas 104-B.", FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.DARK_GRAY))) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 3f, PaddingTop = 2f });
                        tablaDireccion.AddCell(new PdfPCell(new Phrase("Sta. Lucía del Camino, Oaxaca.", FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.DARK_GRAY))) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 3f, PaddingTop = 2f });
                        tablaDireccion.AddCell(new PdfPCell(new Phrase("Tels: 951-206-6895 y 951-399-7777", FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.DARK_GRAY))) { Border = Rectangle.NO_BORDER, HorizontalAlignment = Element.ALIGN_RIGHT, PaddingBottom = 3f, PaddingTop = 2f });

                        PdfPCell celdaDireccion = new PdfPCell(tablaDireccion)
                        {
                            Border = Rectangle.NO_BORDER,
                            Padding = 2f,
                            HorizontalAlignment = Element.ALIGN_RIGHT
                        };

                        tablaPie.AddCell(celdaBanco);
                        tablaPie.AddCell(celdaDireccion);

                        // Estampa fondo (si existe) y tabla pie en la página objetivo
                        float pageWidth = pageSize.Width;
                        float pageHeight = pageSize.Height;

                        if (File.Exists(rutaFondo))
                        {
                            PdfContentByte fondo = stamper.GetUnderContent(targetPage);
                            iTextSharp.text.Image imgFondo = iTextSharp.text.Image.GetInstance(rutaFondo);

                            float desiredHeight = pageHeight * 0.40f;
                            float proportion = desiredHeight / imgFondo.Height;
                            float newWidth = imgFondo.Width * proportion;
                            imgFondo.ScaleAbsolute(newWidth, desiredHeight);

                            float xPos = (pageWidth - newWidth) / 2;
                            float yPos;
                            if (requierePaginaNueva)
                            {
                                // centrar verticalmente en la nueva página
                                yPos = (pageHeight - desiredHeight) / 2;
                            }
                            else
                            {
                                // colocación similar a la original
                                yPos = yPieDefault + 20f;
                            }

                            imgFondo.SetAbsolutePosition(xPos, yPos);

                            PdfGState transparencia = new PdfGState { FillOpacity = 0.30f, StrokeOpacity = 0.30f };

                            fondo.SaveState();
                            fondo.SetGState(transparencia);
                            fondo.AddImage(imgFondo);
                            fondo.RestoreState();
                        }

                        PdfContentByte over = stamper.GetOverContent(targetPage);
                        float yPieToUse = requierePaginaNueva ? 140f : yPieDefault;
                        tablaPie.WriteSelectedRows(0, -1, leftMargin, yPieToUse, over);

                        stamper.Close();
                    }
                    reader.Close();
                }
                File.Copy(tempPath, pdfPath, true);
            }
            catch
            {
                MessageBox.Show("Error al estampar el pie de página en el PDF.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (File.Exists(tempPath))
                    File.Delete(tempPath);
            }
        }

        private PdfPCell CeldaRightGrande(string texto)
        {
            return new PdfPCell(new Phrase(texto, FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.DARK_GRAY)))
            {
                Border = Rectangle.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_RIGHT,
                PaddingBottom = 3f,
                PaddingTop = 2f
            };
        }

        // Listener para obtener coordenadas Y del texto en una página
        private class TextPositionRenderListener : iTextSharp.text.pdf.parser.IRenderListener
        {
            public float MinY { get; private set; } = float.MaxValue;

            public void BeginTextBlock() { }
            public void EndTextBlock() { }
            public void RenderImage(iTextSharp.text.pdf.parser.ImageRenderInfo renderInfo) { }

            public void RenderText(iTextSharp.text.pdf.parser.TextRenderInfo renderInfo)
            {
                try
                {
                    var descentLine = renderInfo.GetDescentLine();
                    var start = descentLine.GetStartPoint();
                    // start es Vector; el índice 1 es la coordenada Y
                    float y = start[1];
                    if (y < MinY) MinY = y;
                }
                catch
                {
                    // ignorar errores de extracción de posición
                }
            }
        }
    }
}
