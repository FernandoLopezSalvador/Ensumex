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
            // Dejamos vacio si se usa la estrategia de "stampear" el pie solo en la última página.
        }

        // Método público para estampar el pie en la última página de un PDF ya existente.
        public static void StampFooterToLastPage(string pdfPath, string rutaFondo, string rutaFirma, string usuario)
        {
            if (!File.Exists(pdfPath)) return;

            string tempPath = Path.GetTempFileName();
            try
            {
                using (var reader = new PdfReader(pdfPath))
                {
                    int lastPage = reader.NumberOfPages;
                    using (var fs = new FileStream(tempPath, FileMode.Create, FileAccess.Write))
                    using (var stamper = new PdfStamper(reader, fs))
                    {
                        var pageSize = reader.GetPageSize(lastPage);
                        float leftMargin = 40f;
                        float rightMargin = 40f;
                        // total width para la tabla del pie (igual márgenes que usas al crear el documento)
                        float totalWidth = pageSize.Width - leftMargin - rightMargin;

                        // Fuentes locales (compatibles con las usadas al crear el PDF)
                        var fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.DARK_GRAY);
                        var fontBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.BLACK);
                        var fontNormalGrande = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.DARK_GRAY);
                        var fontBoldGrande = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.BLACK);

                        // construir tablaPie similar a la que tenías
                        PdfPTable tablaPie = new PdfPTable(2)
                        {
                            TotalWidth = totalWidth
                        };
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

                        
                        float yPie = leftMargin + 105f; 
                        
                        if (File.Exists(rutaFondo))
                        {
                            PdfContentByte fondo = stamper.GetUnderContent(lastPage);
                            iTextSharp.text.Image imgFondo = iTextSharp.text.Image.GetInstance(rutaFondo);

                            float pageWidth = pageSize.Width;
                            float pageHeight = pageSize.Height;

                            float desiredHeight = pageHeight * 0.40f;

                            float proportion = desiredHeight / imgFondo.Height;
                            float newWidth = imgFondo.Width * proportion;

                            imgFondo.ScaleAbsolute(newWidth, desiredHeight);

                            // --- Centrar imagen en la parte inferior ---
                            float xPos = (pageWidth - newWidth) / 2;
                            float yPos = yPie + 20f;

                            imgFondo.SetAbsolutePosition(xPos, yPos);

                            // Opacidad 50%
                            PdfGState transparencia = new PdfGState();
                            transparencia.FillOpacity = 0.30f;
                            transparencia.StrokeOpacity = 0.30f;

                            fondo.SaveState();
                            fondo.SetGState(transparencia);
                            fondo.AddImage(imgFondo);
                            fondo.RestoreState();
                        }

                        PdfContentByte over = stamper.GetOverContent(lastPage);
                        tablaPie.WriteSelectedRows(0, -1, leftMargin, yPie, over);

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
    }
}
