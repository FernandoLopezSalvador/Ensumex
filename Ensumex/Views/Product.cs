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

namespace Ensumex.Views
{
    public partial class Product : UserControl
    {
        public Product()
        {
            InitializeComponent();
            ConfigurarTablaProductos();
            InicializarComboProductos();
            CargarProductoss();
        }
        private void ConfigurarTablaProductos()
        {
            tabla_productos.DefaultCellStyle.ForeColor = Color.Black;
            tabla_productos.BackgroundColor = Color.FromArgb(45, 45, 48);
        }
        private void InicializarComboProductos()
        {
            object[] opciones = { "Todos", 5, 10, 20, 50, 100 };
            cmb_productos.Items.AddRange(opciones);
            cmb_productos.SelectedIndex = 0;
        }
        private void CargarProductoss(int? limite = 100)
        {
            try
            {
                var productoService = new ProductoServices1();
                var productos = productoService.ObtenerProductos(limite);
                // Si algunos de los valores son nulos, asigna valores predeterminados
                var productosConValoresSeguros = productos.Select(p => new
                {
                    CLAVECVE_ART = p.CVE_ART ?? "N/A",
                    DESCR = p.DESCR ?? "N/A",
                    UNI_MED = p.UNI_MED ?? "N/A",
                    COSTO_PROM = p.COSTO_PROM != 0 ? p.COSTO_PROM.ToString("C2") : "$0.00",
                    ULT_COSTO = p.ULT_COSTO != 0 ? p.ULT_COSTO.ToString("C2") : "$0.00",
                    EXIST = p.EXIST ?? "N/A"
                }).ToList();

                // Configura el DataGridView
                tabla_productos.DataSource = productosConValoresSeguros;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            BuscarEnGrid(txt_buscar.Text.Trim());
        }
        private void BuscarEnGrid(string texto)
        {
            try
            {
                tabla_productos.CurrentCell = null; // <- desactiva la celda seleccionada
                tabla_productos.ClearSelection();
                foreach (DataGridViewRow row in tabla_productos.Rows)
                {
                    if (row.IsNewRow) continue;
                    bool visible = false;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && Convert.ToString(cell.Value).IndexOf(texto, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            visible = true;
                            break;
                        }
                    }
                    row.Visible = visible;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al buscar: " + ex.Message);
            }
        }
        private void cmb_productos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_productos.SelectedItem != null && cmb_productos.SelectedItem.ToString() == "Todos")
            {
                CargarProductoss(); //Carga todos los productos
            }
            else if (cmb_productos.SelectedItem != null && int.TryParse(cmb_productos.SelectedItem.ToString(), out int limite))
            {
                CargarProductoss(limite); //Carga los productos según el límite seleccionado
            }
        }
    }
}