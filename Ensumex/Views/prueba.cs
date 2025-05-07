using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ensumex.Services;
using Ensumex.Models;
using Ensumex.Clases;

namespace Ensumex.Views
{
    public partial class prueba : Form
    {
        public prueba()
        {
            InitializeComponent();
            CargarProductoss();
        }

        private void CargarProductoss(int? limite = 100)
        {
            try
            {
                var productoService = new ProductoServices1();
                var productos = productoService.ObtenerProductos(limite);
                // Configura el DataGridView
                Tabla_Productos1.DataSource = productos.Select(p => new
                {
                    Clave = p.CLAVE,
                    Descripcion = p.Descripcion,
                    PrecioCosto = p.PU,
                    NumeroSerie = p.PrecioPublico,
                    TipoProducto = p.TipoProducto
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
