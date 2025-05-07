using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ensumex.Utils;

namespace Ensumex.Forms
{
    public partial class Cotizaciones : Form
    {
        public Cotizaciones()
        {
            InitializeComponent();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            VentanaHelper.Minimizar(this);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            VentanaHelper.Maximizar(this);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            VentanaHelper.Cerrar(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Cerrar sesion?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_inventario_Click(object sender, EventArgs e)
        {
            this.Hide();
            Productos productos = new Productos();
            productos.Show();
        }

        private void btn_cotizacion_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cotizaciones cotizaciones = new Cotizaciones();
            cotizaciones.Show();
        }

        private void btn_clientes_Click(object sender, EventArgs e)
        {
            this.Hide();
            /*Clientes clientes = new Clientes();
            clientes.Show();*/
        }
    }
}
