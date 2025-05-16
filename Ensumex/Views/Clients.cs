using Ensumex.Services;
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
        }

        private void InicializarComboClientes()
        {
            var opciones = new object[] { "Todos", 5, 10, 20, 50, 100 };
            cmb_clientes.Items.AddRange(opciones);
            cmb_clientes.SelectedIndex = 0;
        }

        private void CargarClientes(int? limite = 100)
        {
            try
            {
                var clienteService = new ClienteServices1();
                var clientes = clienteService.ObtenerClientes(limite);
                // Si algunos de los valores son nulos, asigna valores predeterminados
                var clientesConValoresSeguros = clientes.Select(c => new
                {
                    Clave = c.CLAVE,// Si CLAVE es null, asigna un valor predeterminado
                    Estatus = c.Estatus ?? "No disponible",
                    Nombre = c.Nombre ?? "Sin descripción",
                    Calle = c.Calle ?? "No disponible",
                    Telefono = c.Telefono ?? "No disponible",
                    Saldo = c.Saldo,  // Si Saldo es null, asigna 0
                    EstadoDatosTimbrado = c.EstadoDatosTimbrado ?? "No disponible",
                    NombreComercial = c.NombreComercial ?? "No disponible"
                }).ToList();
                // Configura el DataGridView
                tabla_clientes.DataSource = clientesConValoresSeguros;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar clientes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
