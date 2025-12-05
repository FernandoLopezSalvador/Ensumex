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
            if (File.Exists(rutaFondo))
            {
                try
                {
                    var fondo = iTextSharp.text.Image.GetInstance(rutaFondo);
                    fondo.ScaleAbsolute(400f, 370f);
                    float x = document.PageSize.Width - document.RightMargin - fondo.ScaledWidth;
                    float y = document.BottomMargin;
                    fondo.SetAbsolutePosition(x, y);

                    var under = writer.DirectContentUnder;
                    var gs = new PdfGState { FillOpacity = 0.4f, StrokeOpacity = 0.4f };
                    under.SaveState();
                    under.SetGState(gs);
                    under.AddImage(fondo);
                    under.RestoreState();
                }
                catch { }
            }

            PdfPTable tablaPie = new PdfPTable(2)
            {
                TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin
            };
            tablaPie.SetWidths(new float[] { 1.35f, 1.35f });

            PdfPTable tablaBanco = new PdfPTable(1);
            tablaBanco.WidthPercentage = 100;

            // Helper para filas horizontales
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

            // Datos
            tablaBanco.AddCell(Fila("Nombre:", "HV Energías Sustentables de México, S.A. de C.V."));
            tablaBanco.AddCell(Fila("RFC:", "HES150616639"));
            tablaBanco.AddCell(Fila("Banco:", "BBVA Bancomer"));
            tablaBanco.AddCell(Fila("Cuenta:", "0199948457"));
            tablaBanco.AddCell(Fila("Clave:", "012610001999484570"));

            // Cuadro exterior
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

            tablaDireccion.AddCell(CeldaRightGrande("Av. Lázaro Cárdenas 104-B."));
            tablaDireccion.AddCell(CeldaRightGrande("Sta. Lucía del Camino, Oaxaca."));
            tablaDireccion.AddCell(CeldaRightGrande("Tels: 951-206-6895 y 951-399-7777"));

            PdfPCell celdaDireccion = new PdfPCell(tablaDireccion)
            {
                Border = Rectangle.NO_BORDER,
                Padding = 2f,
                HorizontalAlignment = Element.ALIGN_RIGHT
            };
            tablaPie.AddCell(celdaBanco);
            tablaPie.AddCell(celdaDireccion);
            float yPie = document.BottomMargin + 105f; 
            tablaPie.WriteSelectedRows(0, -1, document.LeftMargin, yPie, writer.DirectContent);
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
