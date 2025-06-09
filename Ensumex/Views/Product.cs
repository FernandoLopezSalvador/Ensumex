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
            // Suscribe el evento de doble clic
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
                // Si algunos de los valores son nulos, asigna valores predeterminados
                var productosConValoresSeguros = productos.Select(p => new
                {
                    CLAVE = p.CVE_ART ?? "N/A",
                    DESCRIPCIÓN = p.DESCR ?? "N/A",
                    UNDMED = p.UNI_MED ?? "N/A",
                    COSTO_PROM = p.COSTO_PROM != 0 ? p.COSTO_PROM.ToString("C2") : "$0.00",
                    ULT_COSTO = p.ULT_COSTO != 0 ? p.ULT_COSTO.ToString("C2") : "$0.00",
                    EXIST = p.EXIST ?? "N/A"
                }).ToList();

                // Configura el DataGridView
                tabla_productos.DataSource = productosConValoresSeguros;
                //tabla_productos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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
            // Si el texto está vacío, muestra todas las filas rápidamente
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
            try
            {
                if (cmb_productos.SelectedItem == null)
                {
                    MessageBox.Show("No se ha seleccionado ningún valor.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedValue = cmb_productos.SelectedItem.ToString();

                if (selectedValue == "Todos")
                {
                    CargarProductoss(); // Carga todos los productos
                }
                else if (int.TryParse(selectedValue, out int limite))
                {
                    CargarProductoss(limite); // Carga productos con el límite seleccionado
                }
                else
                {
                    MessageBox.Show("El valor seleccionado no es válido.", "Error de selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cambiar la selección de productos:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImprimirProd_Click(object sender, EventArgs e)
        {
            PDFClients.ExportarClientes(tabla_productos, "Productos.xlsx");
        }

        private void btn_Existencia_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (btn_Existencia.Checked)
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
                                // Si una fila da error, se omite del filtro
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
                                // Si alguna fila causa error al proyectar, se omite
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
    }
}