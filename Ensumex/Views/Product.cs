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
            tabla_productos.DefaultCellStyle.ForeColor = Color.Black; // Color de texto blanco
            tabla_productos.BackgroundColor = Color.FromArgb(45, 45, 48); // Fondo oscuro
            cmb_productos.Items.AddRange(new object[] { "Todos", 5, 10, 20, 50, 100 });
            cmb_productos.SelectedIndex = 0; // Selecciona "Todos" por defecto
            // Carga todos los productos al inicio  
            CargarProductoss();
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
                    Clave = p.CLAVE ?? "No disponible", // Si CLAVE es null, asigna un valor predeterminado
                    Descripcion = p.Descripcion ?? "Sin descripción",
                    UnidadEntrada = p.UnidadEntrada ?? "No disponible",
                    PrecioCosto = p.PU,  // Si Precio Costo es null, asigna 0
                    PrecioPublico = p.PrecioPublico,  // Si Precio Público es null, asigna 0
                    TipoProducto = p.TipoProducto ?? "No disponible"
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
                CargarProductoss(); // Carga todos los productos
            }
            else if (cmb_productos.SelectedItem != null && int.TryParse(cmb_productos.SelectedItem.ToString(), out int limite))
            {
                CargarProductoss(limite); // Carga los productos según el límite seleccionado
            }
        }
    }
}
