using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ensumex.Clases;
using Ensumex.Models;
using Ensumex.Services;
using Ensumex.Utils;

namespace Ensumex.Forms
{
    public partial class Productos : Form
    {
        public Productos()
        {
            InitializeComponent();
            cmb_productos.Items.AddRange(new object[] { "Todos", 5, 10, 20, 50, 100 });
            cmb_productos.SelectedIndex = 0; // Selecciona "Todos" por defecto
            // Carga todos los productos al inicio  
            CargarProductoss();
            CargaUsuario.CargarDatosUsuario(lbl_usuario, lbl_posicion);
        }
        private void Productos_Load(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void CargarProductoss(int? limite = 100)
        {
            try
            {
                var productoService = new ProductoServices1();
                var productos = productoService.ObtenerProductos(limite);
                // Configura el DataGridView
                tabla_productos.DataSource = productos.Select(p => new
                {
                    Clave = p.CLAVE,
                    Descripcion = p.Descripcion,
                    UnidadEntrada=p.UnidadEntrada,
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
        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            VentanaHelper.Minimizar(this);
        }

        private void btn_maximizar_Click(object sender, EventArgs e)
        {
            VentanaHelper.Maximizar(this);
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            VentanaHelper.Cerrar(this);
        }

        private void text_buscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
        private void CargarDatosUsuario()
        {
            CargaUsuario.CargarDatosUsuario(lbl_usuario, lbl_posicion);
        }

        private void btn_inventario_Click(object sender, EventArgs e)
        {
           

        }

        private void btn_cerrarsesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Cerrar sesion?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_inventario_MouseEnter(object sender, EventArgs e)
        {
            btn_inventario.BackColor = Color.FromArgb(25, 239, 22);
        }

        private void btn_inventario_MouseLeave(object sender, EventArgs e)
        {
            btn_inventario.BackColor = Color.FromArgb(0, 81, 46);
        }

        private void btn_cotizacion_MouseEnter(object sender, EventArgs e)
        {
            btn_cotizacion.BackColor = Color.FromArgb(25, 239, 22);
        }

        private void btn_cotizacion_MouseLeave(object sender, EventArgs e)
        {
            btn_inventario.BackColor = Color.FromArgb(0, 81, 46);
        }

        private void btn_clientes_MouseEnter(object sender, EventArgs e)
        {
            btn_clientes.BackColor = Color.FromArgb(25, 239, 22);
        }

        private void btn_clientes_MouseLeave(object sender, EventArgs e)
        {
            btn_clientes.BackColor = Color.FromArgb(0, 81, 46);
        }
    }
}
