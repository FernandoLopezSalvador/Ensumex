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
    public partial class Clients : UserControl
    {
        public Clients()
        {
            InitializeComponent();
            ConfigurarTablaClientes();
            InicializarComboClientes();
            CargarClientes();
        }
        private void ConfigurarTablaClientes()
        {
            tabla_clientes.DefaultCellStyle.ForeColor = Color.Black;
            tabla_clientes.BackgroundColor = Color.FromArgb(45, 45, 48);
            // Add column definitions
            tabla_clientes.Columns.Add("CLAVE", "Clave");
            tabla_clientes.Columns.Add("STATUS", "Status");
            tabla_clientes.Columns.Add("NOMBRE", "Nombre");
            tabla_clientes.Columns.Add("CALLE", "Calle");
            tabla_clientes.Columns.Add("COLONIA", "Colonia");
            tabla_clientes.Columns.Add("MUNICIPIO", "Municipio");
            tabla_clientes.Columns.Add("EMAILPRED", "Email");
        }
        private void InicializarComboClientes()
        {
            var opciones = new object[] { "Todos", 5, 10, 20, 50, 100 };
            cmb_clientes.Items.AddRange(opciones);
            cmb_clientes.SelectedIndex = 0;
        }
        private void CargarClientes()
        {
            var clienteService = new ClienteServices1();
            var clientes = clienteService.ObtenerClientes();
            tabla_clientes.Rows.Clear();
            foreach (var cliente in clientes)
            {
                tabla_clientes.Rows.Add(cliente.CLAVE, cliente.STATUS, cliente.NOMBRE, cliente.CALLE, cliente.COLONIA, cliente.MUNICIPIO, cliente.EMAILPRED);
            }
            //tabla_clientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void cmb_clientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Aquí puedes manejar el evento de cambio de selección del combo box si es necesario
            // Por ejemplo, podrías filtrar los clientes según la selección
            var selectedValue = cmb_clientes.SelectedItem.ToString();
            if (selectedValue == "Todos")
            {
                CargarClientes(); // Cargar todos los clientes
            }
            else
            {
                int count = int.Parse(selectedValue);
                var clienteService = new ClienteServices1();
                var clientes = clienteService.ObtenerClientes().Take(count).ToList();
                tabla_clientes.Rows.Clear();
                foreach (var cliente in clientes)
                {
                    tabla_clientes.Rows.Add(cliente.CLAVE, cliente.STATUS, cliente.NOMBRE, cliente.CALLE, cliente.COLONIA, cliente.MUNICIPIO, cliente.EMAILPRED);
                }
            }
        }
        private void txt_buscar_TextChanged(object sender, EventArgs e)
        {
            var searchText = txt_buscar.Text.ToLower();
            foreach (DataGridViewRow row in tabla_clientes.Rows)
            {
                if (!row.IsNewRow) // Skip uncommitted rows
                {
                    var nombreCell = row.Cells["NOMBRE"].Value?.ToString().ToLower();
                    var claveCell = row.Cells["CLAVE"].Value?.ToString().ToLower();
                    row.Visible = (nombreCell?.Contains(searchText) ?? false) ||
                                  (claveCell?.Contains(searchText) ?? false);
                }
            }
        }
        private void materialButton1_Click(object sender, EventArgs e)
        {
            PDFClients.ExportarClientes(tabla_clientes, "Clientes.xlsx");
        }
        private void tabla_clientes_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = tabla_clientes.Rows[e.RowIndex];
                string nombre = row.Cells["NOMBRE"].Value?.ToString();
                string calle = row.Cells["CALLE"].Value?.ToString();
                var result = MessageBox.Show(
                    $"¿Desea agregar el cliente '{nombre}'?",
                    "Agregar cliente",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Guarda los datos seleccionados en propiedades públicas
                    ClienteSeleccionadoNombre = nombre;
                    ClienteSeleccionadoCalle = calle;
                    // Cambiar la lógica para cerrar el formulario o manejar el evento de cierre
                    var parentForm = this.FindForm();
                    if (parentForm != null)
                    {
                        parentForm.DialogResult = DialogResult.OK;
                        parentForm.Close();
                    }
                }
            }

        }
        // Propiedades públicas para exponer los datos seleccionados
        public string ClienteSeleccionadoNombre { get; private set; }
        public string ClienteSeleccionadoCalle { get; private set; }
    }
}
