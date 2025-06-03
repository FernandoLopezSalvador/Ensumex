using Ensumex.Clases;
using Ensumex.Models;
using Ensumex.Utils;
using Ensumex.Views;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ensumex.Forms
{
    public partial class ENSUMEX : MaterialForm
    {
        [Obsolete]
        public ENSUMEX()
        {
            InitializeComponent();
            InicializarFormulario();
            ConfigurarTema();
            ConfigurarMenu();
            CargarDatosUsuario();
        }
        private void InicializarFormulario()
        {
            this.WindowState = FormWindowState.Maximized;
            panel1.Cursor = Cursors.Hand;
        }
        private void ConfigurarTema()
        {
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            skinManager.ColorScheme = new ColorScheme(
                Primary.Green600,   // Color base
                Primary.Green700,   // Tono oscuro
                Primary.Green400,   // Tono claro
                Accent.LightGreen200, // Acento
                TextShade.WHITE);   // Tono del texto
        }
        private void ConfigurarMenu()
        {
            menu_usuario.Renderer = new CustomMenuRenderer();
        }
        private void CargarDatosUsuario()
        {
            CargaUsuario.CargarDatosUsuario(lbl_usuario, lbl_posicion);
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
        private void btn_cerrarsesion_MouseEnter(object sender, EventArgs e)
        {
            btn_cerrarsesion.BackColor = Color.FromArgb(25, 239, 22);
        }
        private void btn_cerrarsesion_MouseLeave(object sender, EventArgs e)
        {
            btn_cerrarsesion.BackColor = Color.FromArgb(0, 104, 56);
        }
        [Obsolete]
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarUserControl(new Users());
        }
        private void materialButton1_MouseEnter(object sender, EventArgs e)
        {
            btn_inventarioP.BackColor = Color.FromArgb(25, 239, 22);
        }
        private void btn_inventarioP_MouseLeave(object sender, EventArgs e)
        {
            btn_inventarioP.BackColor = Color.FromArgb(0, 104, 56);
        }
        private void btn_inventarioP_Click(object sender, EventArgs e)
        {
            CargarUserControl(new Product());
        }
        private void materialButton2_Click(object sender, EventArgs e)
        {
            CargarUserControl(new Cotiza());
        }
        private void btn_clientes_Click(object sender, EventArgs e)
        {
        }
        private void ENSUMEX_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!VentanaHelper.ConfirmarCerrarFormulario())
            {
                e.Cancel = true;
            }
        }
        private void materialSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            var manager = MaterialSkin.MaterialSkinManager.Instance;
            manager.Theme = manager.Theme == MaterialSkinManager.Themes.LIGHT
                ? MaterialSkinManager.Themes.DARK
                : MaterialSkinManager.Themes.LIGHT;
        }
        private void CargarUserControl(UserControl control)
        {
            panelContenedor.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panelContenedor.Controls.Add(control);
        }
        private void administrarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void materialButton3_Click(object sender, EventArgs e)
        {
            CargarUserControl(new Clients());
        }
        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
} 
