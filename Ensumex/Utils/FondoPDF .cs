using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensumex.Utils
{
    public class FondoPDF : PdfPageEventHelper
    {
        private readonly string _rutaImagen;
        private iTextSharp.text.Image _imagen;

        public FondoPDF(string rutaImagen)
        {
            _rutaImagen = rutaImagen;
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            if (_imagen == null && File.Exists(_rutaImagen))
            {
                _imagen = iTextSharp.text.Image.GetInstance(_rutaImagen);

                // Escalamos la imagen 
                _imagen.ScaleToFit(400f, 400f);

                float x = document.PageSize.Width - _imagen.ScaledWidth;
                float y = 0; // parte inferior

                _imagen.SetAbsolutePosition(x, y);
            }
            if (_imagen != null)
            {
                PdfContentByte canvas = writer.DirectContentUnder;

                // Aplicar opacidad
                PdfGState gState = new PdfGState
                {
                    FillOpacity = 0.3f, 
                    StrokeOpacity = 0.3f
                };
                canvas.SaveState();
                canvas.SetGState(gState);
                canvas.AddImage(_imagen);
                canvas.RestoreState();
            }
        }
    }
}
