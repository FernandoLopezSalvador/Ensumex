using Ensumex.Services;
using Ensumex.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ensumex.Views
{
    public partial class Product : UserControl
    {
        public event Action<string, string, string, decimal, decimal> ProductoSeleccionado;

        // Variable de clase para cachear todos los productos
        private List<dynamic> productosCache = new();

        public Product()
        {
            InitializeComponent();
            InicializarFormulario();
            CargarTodosLosProductos();
        }
        private void InicializarFormulario()
        {
            TablaFormat.AplicarEstilosTabla(tabla_productos);
            InicializarComboProductos();
            tabla_productos.CellDoubleClick += tabla_productos_CellDoubleClick;
            tabla_productos.ReadOnly = true; // Hacer la tabla de productos de solo lectura
        }
        private void InicializarComboProductos()
        {
            object[] opciones = { "Todos", 5, 10, 20, 50, 100 };
            cmb_productos.Items.AddRange(opciones);
            cmb_productos.SelectedIndex = 0;
        }

        private void CargarTodosLosProductos()
        {
            try
            {
                var productoService = new ProductoServices1();
                var productos = productoService.ObtenerProductos(); // traer todos

                productosCache = productos.Select(p => new
                {
                    CLAVE = p.CVE_ART ?? "N/A",
                    DESCRIPCIÓN = p.DESCR ?? "N/A",
                    UNDMED = p.UNI_MED ?? "N/A",
                    COSTO_PROM = p.COSTO_PROM != 0 ? p.COSTO_PROM.ToString("C2") : "$0.00",
                    ULT_COSTO = p.PRECIO != 0 ? (p.PRECIO * 1.16m).ToString("C2") : "$0.00",
                    EXIST = p.EXIST > 0 ? p.EXIST.ToString() : "0"
                }).ToList<dynamic>();

                tabla_productos.DataSource = productosCache;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProductoss(int? limite = 100000)
        {
            // Limpia la tabla antes de cargar nuevos datos y carga los productos
            try
            {
                var productosFiltrados = productosCache.Take(limite ?? productosCache.Count).ToList();
                tabla_productos.DataSource = productosFiltrados;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarEnProductos(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                tabla_productos.DataSource = productosCache;
                return;
            }

            string textoBusqueda = texto.ToLower();
            var filtrados = productosCache.Where(p =>
                p.CLAVE.ToLower().Contains(textoBusqueda) ||
                p.DESCRIPCIÓN.ToLower().Contains(textoBusqueda)
            ).ToList();

            tabla_productos.DataSource = filtrados;
        }

        // Método para buscar en el DataGridView
        private void BuscarEnGrid(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                foreach (DataGridViewRow row in tabla_productos.Rows)
                {
                    if (!row.IsNewRow)
                        row.Visible = true;
                }
                return;
            }
            // Suspende el layout y el enlace de datos para mejorar el rendimiento
            tabla_productos.SuspendLayout();
            CurrencyManager cm = (CurrencyManager)BindingContext[tabla_productos.DataSource];
            cm.SuspendBinding();
            string textoBusqueda = texto.ToLower();
            foreach (DataGridViewRow row in tabla_productos.Rows)
            {
                if (row.IsNewRow) continue;

                bool visible = false;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        visible = true;
                        break;
                    }
                }
                row.Visible = visible;
            }
            cm.ResumeBinding();
            tabla_productos.ResumeLayout();
        }
        // Evento para manejar el cambio de selección en el ComboBox de productos
        private void cmb_productos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmb_productos.SelectedItem is int limite)
                {
                    CargarProductoss(limite);
                }
                else if (cmb_productos.SelectedItem.ToString() == "Todos")
                {
                    CargarProductoss(null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ImprimirProd_Click(object sender, EventArgs e)
        {
            PDFClients.ExportarClientes(tabla_productos, "Productos.xlsx");
        }
        // Evento para manejar el doble clic en una celda del DataGridView y seleccionar un producto
        private void tabla_productos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = tabla_productos.Rows[e.RowIndex];
                string clave = row.Cells["CLAVE"].Value?.ToString();
                string descripcion = row.Cells["DESCRIPCIÓN"].Value?.ToString();
                string unidad = row.Cells["UNDMED"].Value?.ToString();
                decimal precio = Convert.ToDecimal(row.Cells["ULT_COSTO"].Value?.ToString().Replace("$", "").Trim() ?? "0"); decimal cantidad = 1;
                ProductoSeleccionado?.Invoke(clave, descripcion, unidad, precio, cantidad);
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (btn_existencias.Checked)
                {
                    var productosFiltrados = productosCache
                        .Where(p =>
                        {
                            try
                            {
                                return decimal.TryParse(p.EXIST.ToString(), out decimal exist) && exist > 0;
                            }
                            catch
                            {
                                return false;
                            }
                        })
                        .ToList();

                    tabla_productos.DataSource = productosFiltrados;
                }
                else
                {
                    CargarProductoss();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al filtrar los productos por existencia:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BuscarEnProductos(text_buscar.Text.Trim());
        }
        private void tabla_productos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tabla_productos.CurrentRow != null)
            {
                e.Handled = true; // Evita que el Enter haga sonar un beep
                e.SuppressKeyPress = true; // No pase a la siguiente celda

                // Obtener la fila seleccionada
                var row = tabla_productos.CurrentRow;

                string clave = row.Cells["CLAVE"].Value?.ToString();
                string descripcion = row.Cells["DESCRIPCIÓN"].Value?.ToString();
                string unidad = row.Cells["UNDMED"].Value?.ToString();
                decimal precio = Convert.ToDecimal(
                    row.Cells["ULT_COSTO"].Value?.ToString().Replace("$", "").Trim() ?? "0"
                );
                decimal cantidad = 1;
                // Invocar el evento para notificar al formulario padre
                ProductoSeleccionado?.Invoke(clave, descripcion, unidad, precio, cantidad);
            }
        }
    }
}