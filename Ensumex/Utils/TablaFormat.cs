using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensumex.Utils
{
    public static class TablaFormat
    {
        public static void AplicarEstilosTabla(DataGridView tabla)
        {
            tabla.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(64, 64, 64);
            tabla.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            tabla.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);
            tabla.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            tabla.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            tabla.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            tabla.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            tabla.RowTemplate.Height = 30;
            tabla.GridColor = System.Drawing.Color.LightGray;
            tabla.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
        }
    }
}
