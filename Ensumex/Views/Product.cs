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

        public Product()
        {
            InitializeComponent();
            TablaFormat.AplicarEstilosTabla(tabla_productos);
            InicializarComboProductos();
            CargarProductoss();
            tabla_productos.CellDoubleClick += tabla_productos_CellDoubleClick;
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
                var productosConValoresSeguros = productos.Select(p => new
                {
                    CLAVE = p.CVE_ART ?? "N/A",
                    DESCRIPCIÓN = p.DESCR ?? "N/A",
                    UNDMED = p.UNI_MED ?? "N/A",
                    COSTO_PROM = p.COSTO_PROM != 0 ? p.COSTO_PROM.ToString("C2") : "$0.00",
                    ULT_COSTO = p.ULT_COSTO != 0 ? p.ULT_COSTO.ToString("C2") : "$0.00",
                    EXIST = p.EXIST ?? "N/A"
                }).ToList();
                tabla_productos.DataSource = productosConValoresSeguros;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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
        private void cmb_productos_SelectedIndexChanged(object sender, EventArgs e)
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

        private void ImprimirProd_Click(object sender, EventArgs e)
        {
            PDFClients.ExportarClientes(tabla_productos, "Productos.xlsx");
        }



        private void tabla_productos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = tabla_productos.Rows[e.RowIndex];
                string clave = row.Cells["CLAVE"].Value?.ToString();
                string descripcion = row.Cells["DESCRIPCIÓN"].Value?.ToString();
                string unidad = row.Cells["UNDMED"].Value?.ToString();
                decimal precio = Convert.ToDecimal(row.Cells["ULT_COSTO"].Value?.ToString().Replace("$", "").Trim() ?? "0"); decimal cantidad = 1; // Por defecto 1, puedes pedirlo en un input si lo deseas

                ProductoSeleccionado?.Invoke(clave, descripcion, unidad, precio, cantidad);
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (btn_existencias.Checked)
                {
                    var productosFiltrados = tabla_productos.Rows.Cast<DataGridViewRow>()
                        .Where(row =>
                        {
                            try
                            {
                                if (row.IsNewRow) return false;

                                var cellValue = row.Cells["EXIST"].Value;
                                return cellValue != null &&
                                       decimal.TryParse(cellValue.ToString(), out decimal exist) &&
                                       exist > 0;
                            }
                            catch
                            {
                                return false;
                            }
                        })
                        .Select(row =>
                        {
                            try
                            {
                                return new
                                {
                                    CLAVE = row.Cells["CLAVE"].Value?.ToString() ?? "N/A",
                                    DESCRIPCIÓN = row.Cells["DESCRIPCIÓN"].Value?.ToString() ?? "N/A",
                                    UNDMED = row.Cells["UNDMED"].Value?.ToString() ?? "N/A",
                                    COSTO_PROM = row.Cells["COSTO_PROM"].Value?.ToString() ?? "$0.00",
                                    ULT_COSTO = row.Cells["ULT_COSTO"].Value?.ToString() ?? "$0.00",
                                    EXIST = row.Cells["EXIST"].Value?.ToString() ?? "N/A"
                                };
                            }
                            catch
                            {
                                return null;
                            }
                        })
                        .Where(p => p != null)
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
            BuscarEnGrid(text_buscar.Text.Trim());
        }
    }
}