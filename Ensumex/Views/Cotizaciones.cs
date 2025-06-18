using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ensumex.Models;
using Ensumex.Utils;

namespace Ensumex.Views
{
    public partial class Cotizaciones : UserControl
    {
        public Cotizaciones()
        {
            InitializeComponent();
            TablaFormat.AplicarEstilosTabla(tabla_cotizaciones);
            CargarCotizaciones();
        }

        private void CargarCotizaciones()
        {
            DataTable dt = CotizacionRepository.ObtenerCotizaciones();
            tabla_cotizaciones.DataSource = dt;
        }
    }
}
