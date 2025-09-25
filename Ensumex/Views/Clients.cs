using DocumentFormat.OpenXml.Drawing.Diagrams;
using Ensumex.Services;
using Ensumex.Utils;
using FontAwesome.Sharp;
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
    public partial class Clients : UserControl
    {
        private List<dynamic> clientesCache;

        public Clients()
        {
            InitializeComponent();
            TablaFormat.AplicarEstilosTabla(tabla_clientes);
            InicializarComboClientes();
            CargarClientes();
        }

        private void Configurarboton()
        {
            // BtnInve - Inventario
            Btn_DescargarClients.IconChar = IconChar.Download; // cajas para inventario
            Btn_DescargarClients.IconColor = Color.FromArgb(33, 150, 243); // azul
            Btn_DescargarClients.IconSize = 32;
            Btn_DescargarClients.TextImageRelation = TextImageRelation.ImageBeforeText;
            Btn_DescargarClients.ImageAlign = ContentAlignment.MiddleLeft;
            Btn_DescargarClients.Padding = new Padding(10, 0, 20, 0);
            Btn_DescargarClients.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            Btn_DescargarClients.ForeColor = Color.FromArgb(33, 33, 33);
        }
        private void InicializarComboClientes()
        {
            var opciones = new object[] { "Todos", 5, 10, 20, 50, 100 };
            cmb_clientes.Items.AddRange(opciones);
            cmb_clientes.SelectedIndex = 0;
            tabla_clientes.ReadOnly = true; // Hacer la tabla de clientes de solo lectura
        }
        private void CargarClientes()
        {
            try
            {
                var clienteService = new ClienteServices1();
                var clientes = clienteService.ObtenerClientes(); // traer todos

                // Guardar en cache
                clientesCache = clientes.Select(c => new
                {
                    CLAVE = c.CLAVE ?? "N/A",
                    STATUS = c.STATUS ?? "N/A",
                    NOMBRE = c.NOMBRE ?? "N/A",
                    CALLE = c.CALLE ?? "N/A",
                    COLONIA = c.COLONIA ?? "N/A",
                    MUNICIPIO = c.MUNICIPIO ?? "N/A",
                    EMAIL = c.EMAILPRED ?? "N/A"
                }).ToList<dynamic>();

                // Mostrar todos en la tabla
                tabla_clientes.DataSource = clientesCache;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmb_clientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedValue = cmb_clientes.SelectedItem.ToString();

                if (selectedValue == "Todos")
                {
                    tabla_clientes.DataSource = clientesCache;
                }
                else
                {
                    int count = int.Parse(selectedValue);
                    var clientesLimitados = clientesCache.Take(count).ToList();
                    tabla_clientes.DataSource = clientesLimitados;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al filtrar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var searchText = text_buscar.Text.Trim().ToLower();

                if (string.IsNullOrWhiteSpace(searchText))
                {
                    tabla_clientes.DataSource = clientesCache;
                }
                else
                {
                    var clientesFiltrados = clientesCache
                        .Where(c =>
                            (c.NOMBRE != null && c.NOMBRE.ToLower().Contains(searchText)) ||
                            (c.CLAVE != null && c.CLAVE.ToLower().Contains(searchText))
                        )
                        .ToList();

                    tabla_clientes.DataSource = clientesFiltrados;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            PDFClients.ExportarClientes(tabla_clientes, "Clientes.xlsx");
        }

        private void tabla_clientes_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && EsLlamadoDesdeCotiza)
            {
                var row = tabla_clientes.Rows[e.RowIndex];
                string nombre = row.Cells["NOMBRE"].Value?.ToString();

                var result = MessageBox.Show(
                    $"¿Desea agregar el cliente '{nombre}'?",
                    "Agregar cliente",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ClienteSeleccionadoNombre = nombre;
                    var parentForm = this.FindForm();
                    if (parentForm != null)
                    {
                        parentForm.DialogResult = DialogResult.OK;
                        parentForm.Close();
                    }
                }
            }
        }

        private void Btn_DescargarClients_Click(object sender, EventArgs e)
        {
            PDFClients.ExportarClientes(tabla_clientes, "Clientes.xlsx");
        }

        public bool EsLlamadoDesdeCotiza { get; set; } = false;
        public string ClienteSeleccionadoNombre { get; private set; }
        public string ClienteSeleccionadoCalle { get; private set; }
    }
}