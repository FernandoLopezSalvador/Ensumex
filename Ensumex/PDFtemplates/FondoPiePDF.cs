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
        private readonly iTextSharp.text.Font fontPie = FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.DARK_GRAY);

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
                    fondo.ScaleAbsolute(300f, 270f);
                    float x = document.PageSize.Width - document.RightMargin - fondo.ScaledWidth;
                    float y = document.BottomMargin;
                    fondo.SetAbsolutePosition(x, y);

                    var under = writer.DirectContentUnder;
                    var gs = new PdfGState
                    {
                        FillOpacity = 0.3f,
                        StrokeOpacity = 0.3f
                    };
                    under.SaveState();
                    under.SetGState(gs);
                    under.AddImage(fondo);
                    under.RestoreState();
                }
                catch (Exception ex)
                {
                }
            }

            // Pie de página
            PdfPTable pie = new PdfPTable(1)
            {
                TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin
            };
            pie.DefaultCell.Border = Rectangle.NO_BORDER;

            // Texto con usuario
            var fontCursiva = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 13, BaseColor.DARK_GRAY);
            PdfPCell celdaTexto = new PdfPCell(new Phrase("Atentamente,\n" + usuario + "\nVendedor", fontCursiva))
            {
                HorizontalAlignment = Element.ALIGN_CENTER,
                Border = Rectangle.NO_BORDER,
                PaddingTop = 15f, // Espacio superior
                PaddingBottom = 5f
            };
            pie.AddCell(celdaTexto);

            // Firma (si existe)
            if (File.Exists(rutaFirma))
            {
                try
                {
                    var firma = iTextSharp.text.Image.GetInstance(rutaFirma);
                    firma.ScaleAbsolute(120f, 60f);
                    PdfPCell celdaImagen = new PdfPCell(firma)
                    {
                        Border = Rectangle.NO_BORDER,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        PaddingTop = 2f,
                        PaddingBottom = 2f
                    };
                    pie.AddCell(celdaImagen);
                }
                catch (Exception ex)
                {
                    // Puedes loggear el error
                    // MessageBox.Show("Error cargando firma: " + ex.Message);
                }
            }

            // Dirección y teléfonos
            pie.AddCell(new PdfPCell(new Phrase("Av. Lázaro Cárdenas 104-B.", fontPie))
            {
                Border = Rectangle.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_CENTER,
                PaddingTop = 2f,
                PaddingBottom = 0f
            });
            pie.AddCell(new PdfPCell(new Phrase("Sta. Lucía del Camino, Oaxaca. Tels: 951-206-6895 y 951-206-0293", fontPie))
            {
                Border = Rectangle.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_CENTER,
                PaddingTop = 0f,
                PaddingBottom = 2f
            });

            // Dibuja el pie a 30 puntos del borde inferior
            float yPie = document.BottomMargin + 100f; // Sube el pie más
            pie.WriteSelectedRows(0, -1, document.LeftMargin, yPie, writer.DirectContent);
        }
    }
}