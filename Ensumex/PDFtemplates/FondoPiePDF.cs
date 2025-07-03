using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Forms;

namespace Ensumex.PDFtemplates
{
    public class FondoPiePDF : PdfPageEventHelper
    {
        private readonly string rutaFondo;
        private readonly string rutaFirma;
        private readonly iTextSharp.text.Font fontPie = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.DARK_GRAY);

        public FondoPiePDF(string rutaFondo, string rutaFirma)
        {
            this.rutaFondo = rutaFondo;
            this.rutaFirma = rutaFirma;
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            // Fondo transparente en la esquina inferior izquierda
            if (File.Exists(rutaFondo))
            {
                try
                {
                    iTextSharp.text.Image fondo = iTextSharp.text.Image.GetInstance(rutaFondo);
                    float ancho = 400f; // ancho en puntos
                    float alto = 400f;  // alto en puntos
                    fondo.ScaleAbsolute(ancho, alto);

                    float x = document.PageSize.Width - document.RightMargin - ancho;
                    float y = document.BottomMargin;
                    fondo.SetAbsolutePosition(x, y);

                    PdfContentByte under = writer.DirectContentUnder;
                    PdfGState gs = new PdfGState
                    {
                        FillOpacity = 0.4f,
                        StrokeOpacity = 0.4f
                    };
                    under.SaveState();
                    under.SetGState(gs);
                    under.AddImage(fondo);
                    under.RestoreState();
                }
                catch { /* Si hay error en la imagen, ignora el fondo */ }
            }

            // Pie de página
            PdfPTable pie = new PdfPTable(1);
            pie.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
            pie.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

            // Firma (si existe)
            if (File.Exists(rutaFirma))
            {
                try
                {
                    iTextSharp.text.Image firma = iTextSharp.text.Image.GetInstance(rutaFirma);
                    firma.ScaleAbsolute(120f, 60f);
                    firma.Alignment = Element.ALIGN_CENTER;
                    PdfPCell celdaImagen = new PdfPCell(firma)
                    {
                        Border = iTextSharp.text.Rectangle.NO_BORDER,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        PaddingTop = 2f,
                        PaddingBottom = 2f
                    };
                    pie.AddCell(celdaImagen);
                }
                catch { /* Si hay error en la imagen, ignora la firma */ }
            }

            // Dirección y teléfonos
            pie.AddCell(new PdfPCell(new Phrase("Av. Lázaro Cárdenas 104-B.", fontPie))
            {
                Border = iTextSharp.text.Rectangle.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_CENTER,
                PaddingTop = 2f,
                PaddingBottom = 0f
            });
            pie.AddCell(new PdfPCell(new Phrase("Sta. Lucía del Camino, Oaxaca. Tels: 951-206-6895 y 951-206-0293", fontPie))
            {
                Border = iTextSharp.text.Rectangle.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_CENTER,
                PaddingTop = 0f,
                PaddingBottom = 2f
            });

            // Dibuja el pie a 30 puntos del borde inferior
            pie.WriteSelectedRows(0, -1, document.LeftMargin, document.BottomMargin + 60, writer.DirectContent);
        }
    }
}