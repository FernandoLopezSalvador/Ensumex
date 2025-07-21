using Ensumex.Clases;
using Ensumex.Models;
using Ensumex.Services;
using Ensumex.Utils;
using Ensumex.Views;
using FirebirdSql.Data.FirebirdClient;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ensumex.Forms
{
    public partial class ENSUMEX : MaterialForm
    {
        [Obsolete]
        public ENSUMEX()
        {
            InitializeComponent();
            Tema.ConfigurarTema(this);
            InicializarFormulario();
            ConfigurarMenu();
            CargarDatosUsuario();
            CargarUserControl(new Cotizaciones());
        }
        private void InicializarFormulario()
        {
            this.WindowState = FormWindowState.Maximized;
            panel1.Cursor = Cursors.Hand;
        }
        private void ConfigurarMenu()
        {
            menu_usuario.Renderer = new CustomMenuRenderer();
        }
        private void CargarDatosUsuario()
        {
            CargaUsuario.CargarDatosUsuario(lbl_UsuarioInicio, lbl_posicion);

            // Controlar visibilidad del menú principal según el rol
            if (lbl_posicion.Text.Trim().Equals("Vendedor", StringComparison.OrdinalIgnoreCase))
            {
                menu_usuario.Visible = false; // Oculta el menú principal
            }
            else if (lbl_posicion.Text.Trim().Equals("Administrador", StringComparison.OrdinalIgnoreCase))
            {
                menu_usuario.Visible = true; // Muestra el menú principal
            }
            else
            {
                // Puedes decidir si ocultar o mostrar por defecto para otros roles
                menu_usuario.Visible = false;
            }
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
            var confirmResult = MessageBox.Show(
                "¿Estás seguro de que quieres cerrar sesión?",
                "Confirmar cierre de sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                UsuarioLoginCache.Limpiar();
                // Reinicia la aplicación completa (Login -> Cargando -> ENSUMEX)
                Application.Restart();
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
            CargarUserControl(new Cotiza(lbl_UsuarioInicio.Text));
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
        private void materialButton3_Click(object sender, EventArgs e)
        {
            CargarUserControl(new Clients());
        }
        // Evento para el botón de sincronización
        private async void btn_sincronizar_Click(object sender, EventArgs e)
        {
            btn_sincronizar.Enabled = false;
            progressBar1.Value = 0;

            try
            {
                await Task.Run(() =>
                {
                    SincronizacionService.SincronizarDatos((progreso, total) =>
                    {
                        this.Invoke((Action)(() =>
                        {
                            progressBar1.Maximum = total;
                            progressBar1.Value = progreso;
                        }));
                    });
                });

                MessageBox.Show("Sincronización completada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al sincronizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btn_sincronizar.Enabled = true;
            }
        }
        private void Btn_Inicio_Click(object sender, EventArgs e)
        {
            CargarUserControl(new Cotizaciones());
        }
    }
} 
