using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ensumex.Models;
using Ensumex.Utils;
using Ensumex.Views;

namespace Ensumex.Forms
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
            menu_usuario.Renderer = new CustomMenuRenderer();
            panel1.Cursor = Cursors.Hand;
            //CargarDatosUsuario();
            CargaUsuario.CargarDatosUsuario(lbl_usuario, lbl_posicion);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            VentanaHelper.Cerrar(this);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            VentanaHelper.Minimizar(this);
        }

        private void txt_usuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_usuario_Enter(object sender, EventArgs e)
        {
            if (txt_usuario.Text == "Usuario")
            {
                txt_usuario.Text = "";
                txt_usuario.ForeColor = Color.Black;
            }
        }

        private void txt_usuario_Leave(object sender, EventArgs e)
        {
            if (txt_usuario.Text == "")
            {
                txt_usuario.Text = "Usuario";
                txt_usuario.ForeColor = Color.White;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void btn_inventario_Click(object sender, EventArgs e)
        {
            this.Hide();
            Productos productos = new();
            productos.Show();

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            VentanaHelper.Maximizar(this);
        }

        private void lbl_cuenta_Click(object sender, EventArgs e)
        {

        }
        public class CustomMenuRenderer : ToolStripProfessionalRenderer
        {
            public CustomMenuRenderer() : base(new CustomColorTable()) { }

            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {

            }
        }

        public class CustomColorTable : ProfessionalColorTable
        {
            public override Color MenuStripGradientBegin => Color.FromArgb(30, 30, 30);
            public override Color MenuStripGradientEnd => Color.FromArgb(30, 30, 30);
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
            btn_cotizacion.BackColor = Color.FromArgb(0, 81, 46);
        }

        private void btn_clientes_MouseEnter(object sender, EventArgs e)
        {
            btn_clientes.BackColor = Color.FromArgb(25, 239, 22);
        }

        private void btn_clientes_MouseLeave(object sender, EventArgs e)
        {
            btn_clientes.BackColor = Color.FromArgb(0, 81, 46);
        }

        private void btn_cerrarsesion_MouseEnter(object sender, EventArgs e)
        {
            btn_cerrarsesion.BackColor = Color.FromArgb(25, 239, 22);
        }

        private void btn_cerrarsesion_MouseLeave(object sender, EventArgs e)
        {
            btn_cerrarsesion.BackColor = Color.FromArgb(0, 104, 56);
        }

        private void btn_cotizacion_Click(object sender, EventArgs e)
        {
            this.Close();
            Cotizaciones cotizacion = new();
            cotizacion.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }
        private void CargarDatosUsuario()
        {
            CargaUsuario.CargarDatosUsuario(lbl_usuario, lbl_posicion);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            panel23 usiarios = new();
            usiarios.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            prueba prueba = new();
            prueba.Show();
        }
    }
} 
