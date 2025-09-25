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
using FontAwesome.Sharp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using Timer = System.Windows.Forms.Timer;

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
            ConfigurarBotones();
            ConfigurarMenu();
            CargarDatosUsuario();
            CargarUserControl(new Cotizaciones());
        }
        private void ConfigurarBotones()
        {
            ConfigurarBoton(BtnInve, IconChar.Boxes, Color.FromArgb(30, 136, 229), "Inventario", new Font("Segoe UI", 10, FontStyle.Bold), Color.FromArgb(33, 33, 33));

            ConfigurarBoton(BtnCotiza, IconChar.FileInvoiceDollar, Color.FromArgb(0, 200, 165), "Cotizaciones", new Font("Segoe UI", 10, FontStyle.Bold), Color.FromArgb(33, 33, 33));

            ConfigurarBoton(Btn_Autonom, IconChar.UsersCog, Color.FromArgb(255, 112, 67), "Autónomos", new Font("Segoe UI", 10, FontStyle.Bold), Color.FromArgb(33, 33, 33));

            ConfigurarBoton(BtnClient, IconChar.Users, Color.FromArgb(255, 193, 7), "Clientes", new Font("Segoe UI", 10, FontStyle.Bold), Color.FromArgb(33, 33, 33));

            ConfigurarBoton(BtnSincroniza, IconChar.SyncAlt, Color.FromArgb(186, 104, 200), "Sincronización", new Font("Segoe UI", 10, FontStyle.Bold), Color.FromArgb(33, 33, 33));

            ConfigurarBoton(BtnInicio, IconChar.Home, Color.FromArgb(41, 182, 246), "Inicio", new Font("Segoe UI", 10, FontStyle.Bold), Color.FromArgb(33, 33, 33));

            ConfigurarBoton(Btn_Mantenimientos, IconChar.Tools, Color.FromArgb(0, 150, 136), "Mantenimiento", new Font("Segoe UI", 10, FontStyle.Bold), Color.FromArgb(33, 33, 33));

            ConfigurarBoton(BtnCerrar, IconChar.SignOutAlt, Color.FromArgb(229, 57, 53), "Cerrar Sesión", new Font("Segoe UI", 10, FontStyle.Bold), Color.FromArgb(33, 33, 33));
        }
        private void InicializarFormulario()
        {

            progressBar1.Visible = false; 
            this.WindowState = FormWindowState.Maximized;
            panel1.Cursor = Cursors.Hand;
            BtnInicio.MouseLeave += Button_MouseLeave;
            this.AutoScaleMode = AutoScaleMode.Dpi;
        }
        private void ConfigurarMenu()
        {
            menu_usuario.Renderer = new CustomMenuRenderer();
        }
        private void CargarDatosUsuario()
        {
            CargaUsuario.CargarDatosUsuario(lbl_UsuarioInicio, lbl_posicion);
            ConfigurarVisibilidadPorRol(lbl_posicion.Text.Trim());
        }
        private void ConfigurarVisibilidadPorRol(string rol)
        {
            menu_usuario.Visible = rol == "Administrador";
            BtnSincroniza.Visible = rol != "Vendedor";
        }
        private void AnimateButtonBackColor(Button btn, Color targetColor, int duration = 200)
        {
            Color startColor = btn.BackColor;
            int steps = 20;
            int delay = duration / steps;

            float stepR = (targetColor.R - startColor.R) / (float)steps;
            float stepG = (targetColor.G - startColor.G) / (float)steps;
            float stepB = (targetColor.B - startColor.B) / (float)steps;

            Task.Run(async () =>
            {
                for (int i = 0; i <= steps; i++)
                {
                    int r = (int)(startColor.R + stepR * i);
                    int g = (int)(startColor.G + stepG * i);
                    int b = (int)(startColor.B + stepB * i);

                    Color intermediateColor = Color.FromArgb(r, g, b);

                    btn.Invoke((Action)(() =>
                    {
                        btn.BackColor = intermediateColor;
                    }));

                    await Task.Delay(delay);
                }
            });
        }
        private void AnimateButtonScale(Button btn, float scaleTo, int duration = 200)
        {
            if (btn.Tag == null)
            {
                btn.Tag = btn.Size;
            }

            Size originalSize = (Size)btn.Tag;
            Size startSize = btn.Size;
            Size targetSize = new Size(
                (int)(originalSize.Width * scaleTo),
                (int)(originalSize.Height * scaleTo)
            );

            int steps = 10;
            int delay = duration / steps;
            float stepW = (targetSize.Width - startSize.Width) / (float)steps;
            float stepH = (targetSize.Height - startSize.Height) / (float)steps;

            Task.Run(async () =>
            {
                for (int i = 0; i <= steps; i++)
                {
                    int w = (int)(startSize.Width + stepW * i);
                    int h = (int)(startSize.Height + stepH * i);

                    btn.Invoke((Action)(() =>
                    {
                        btn.Size = new Size(w, h);
                    }));

                    await Task.Delay(delay);
                }
            });
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
        [Obsolete]
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargarUserControl(new Users());
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
            AnimateAllButtonsThemeChange();
        }
        private void AnimateAllButtonsThemeChange()
        {
            var isDark = MaterialSkin.MaterialSkinManager.Instance.Theme == MaterialSkinManager.Themes.DARK;

            List<Button> buttons = new List<Button>
            {
                BtnInve, BtnCotiza, BtnClient, BtnSincroniza, BtnCerrar, BtnInicio
            };

            foreach (var btn in buttons)
            {
                Color baseColor = isDark
                    ? Color.FromArgb(45, 45, 48)
                    : Color.Transparent;

                AnimateButtonBackColor(btn, baseColor, 300);
                AnimateButtonScale(btn, 1.0f, 300);
            }
        }
        private void CargarUserControl(UserControl control)
        {
            panelContenedor.SuspendLayout(); 
            panelContenedor.Controls.Clear();
            control.Dock = DockStyle.Fill;
            control.Margin = Padding.Empty;
            control.Padding = Padding.Empty;

            panelContenedor.Controls.Add(control);
            control.BringToFront();

            panelContenedor.ResumeLayout();
        }

        private void BtnInicio_Click(object sender, EventArgs e)
        {
            CargarUserControl(new Cotizaciones());
        }

        private void BtnInve_Click(object sender, EventArgs e)
        {
            CargarUserControl(new Product());
        }

        private void BtnCotiza_Click(object sender, EventArgs e)
        {
            CargarUserControl(new Cotiza(lbl_UsuarioInicio.Text));
        }

        private void BtnClient_Click(object sender, EventArgs e)
        {
            CargarUserControl(new Clients());
        }

        private async void BtnSincroniza_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            BtnSincroniza.Enabled = false;
            progressBar1.Value = 0;

            try
            {
                await Task.Run(() => SincronizacionService.SincronizarDatos ((progreso, total) =>
                {
                    this.Invoke((Action)(() =>
                    {
                        progressBar1.Maximum = total;
                        progressBar1.Value = progreso;
                    }));
                }));

                progressBar1.Visible = false;
                MessageBox.Show("Sincronización completada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al sincronizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                BtnSincroniza.Enabled = true;
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show(
                "¿Estás seguro de que quieres cerrar sesión?",
                "Confirmar cierre de sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                UsuarioLoginCache.Limpiar();
                Application.Restart();
            }
        }

        private Dictionary<Button, Timer> hoverTimers = new();
        private Dictionary<Button, CancellationTokenSource> animationTokens = new();

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            var manager = MaterialSkin.MaterialSkinManager.Instance;
            var isDark = manager.Theme == MaterialSkinManager.Themes.DARK;

            if (sender is not Button btn) return;

            if (hoverTimers.ContainsKey(btn))
            {
                hoverTimers[btn].Stop();
                hoverTimers[btn].Dispose();
                hoverTimers.Remove(btn);
            }

            Timer delayTimer = new Timer { Interval = 120 };
            delayTimer.Tick += (s, args) =>
            {
                delayTimer.Stop();
                delayTimer.Dispose();
                hoverTimers.Remove(btn);
                if (btn.ClientRectangle.Contains(btn.PointToClient(Cursor.Position)))
                {
                    Color targetColor = GetHoverColor(btn, isDark);
                    StartButtonAnimation(btn, targetColor, 1.1f); 
                }
            };

            hoverTimers[btn] = delayTimer;
            delayTimer.Start();
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            var manager = MaterialSkin.MaterialSkinManager.Instance;
            var isDark = manager.Theme == MaterialSkinManager.Themes.DARK;

            if (sender is not Button btn) return;
            if (hoverTimers.ContainsKey(btn))
            {
                hoverTimers[btn].Stop();
                hoverTimers[btn].Dispose();
                hoverTimers.Remove(btn);
            }

            Color baseColor = isDark
                ? Color.FromArgb(45, 45, 48)
                : Color.Transparent;

            StartButtonAnimation(btn, baseColor, 1.0f); 
        }
        private Color GetHoverColor(Button btn, bool isDark)
        {
            return btn.Name switch
            {
                "BtnInve" => isDark ? Color.FromArgb(103, 58, 183) : Color.FromArgb(230, 230, 250),
                "BtnCotiza" => isDark ? Color.FromArgb(76, 175, 80) : Color.FromArgb(200, 230, 201),
                "BtnClient" => isDark ? Color.FromArgb(255, 179, 0) : Color.FromArgb(255, 253, 230),
                "BtnSincroniza" => isDark ? Color.FromArgb(41, 182, 246) : Color.FromArgb(187, 222, 251),
                "BtnCerrar" => isDark ? Color.FromArgb(229, 57, 53) : Color.FromArgb(255, 205, 210),
                "BtnInicio" => isDark ? Color.FromArgb(255, 193, 7) : Color.FromArgb(255, 241, 118),
                "Btn_Autonom" => isDark ? Color.FromArgb(255, 112, 67) : Color.FromArgb(255, 204, 188),
                "Btn_Mantenimientos" => isDark ? Color.FromArgb(0, 150, 136) : Color.FromArgb(178, 223, 219),
                _=> isDark ? Color.FromArgb(97, 97, 97) : Color.LightGray
            };
        }

        private void StartButtonAnimation(Button btn, Color targetColor, float scaleTo)
        {
            if (animationTokens.ContainsKey(btn))
            {
                animationTokens[btn].Cancel();
                animationTokens[btn].Dispose();
                animationTokens.Remove(btn);
            }

            var cts = new CancellationTokenSource();
            animationTokens[btn] = cts;

            AnimateButtonBackColor(btn, targetColor, 200, cts.Token);
        }
        private async void AnimateButtonBackColor(Button btn, Color targetColor, int duration, CancellationToken token)
        {
            Color startColor = btn.BackColor;
            int steps = 15;
            int delay = duration / steps;

            for (int i = 1; i <= steps; i++)
            {
                if (token.IsCancellationRequested) return;

                float t = i / (float)steps;
                btn.BackColor = Color.FromArgb(
                    (int)(startColor.R + (targetColor.R - startColor.R) * t),
                    (int)(startColor.G + (targetColor.G - startColor.G) * t),
                    (int)(startColor.B + (targetColor.B - startColor.B) * t)
                );

                await Task.Delay(delay);
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            CargarUserControl(new Autonomos(lbl_UsuarioInicio.Text));
        }

        private void Btn_Autonom_MouseLeave(object sender, EventArgs e)
        {
            var manager = MaterialSkin.MaterialSkinManager.Instance;
            var isDark = manager.Theme == MaterialSkinManager.Themes.DARK;

            if (sender is not Button btn) return;
            if (hoverTimers.ContainsKey(btn))
            {
                hoverTimers[btn].Stop();
                hoverTimers[btn].Dispose();
                hoverTimers.Remove(btn);
            }

            Color baseColor = isDark
                ? Color.FromArgb(45, 45, 48)
                : Color.Transparent;

            StartButtonAnimation(btn, baseColor, 1.0f); 
        }

        private void Btn_Autonom_MouseEnter(object sender, EventArgs e)
        {
            var manager = MaterialSkin.MaterialSkinManager.Instance;
            var isDark = manager.Theme == MaterialSkinManager.Themes.DARK;

            if (sender is not Button btn) return;

            if (hoverTimers.ContainsKey(btn))
            {
                hoverTimers[btn].Stop();
                hoverTimers[btn].Dispose();
                hoverTimers.Remove(btn);
            }

            Timer delayTimer = new Timer { Interval = 120 }; 
            delayTimer.Tick += (s, args) =>
            {
                delayTimer.Stop();
                delayTimer.Dispose();
                hoverTimers.Remove(btn);
                    
                if (btn.ClientRectangle.Contains(btn.PointToClient(Cursor.Position)))
                {
                    Color targetColor = GetHoverColor(btn, isDark);
                    StartButtonAnimation(btn, targetColor, 1.1f); 
                }
            };
            hoverTimers[btn] = delayTimer;
            delayTimer.Start();
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            CargarUserControl(new Mantenimiento());
        }

        private void Btn_Mantenimientos_MouseEnter(object sender, EventArgs e)
        {
            var manager = MaterialSkin.MaterialSkinManager.Instance;
            var isDark = manager.Theme == MaterialSkinManager.Themes.DARK;

            if (sender is not Button btn) return;
            if (hoverTimers.ContainsKey(btn))
            {
                hoverTimers[btn].Stop();
                hoverTimers[btn].Dispose();
                hoverTimers.Remove(btn);
            }

            Timer delayTimer = new Timer { Interval = 120 }; 
            delayTimer.Tick += (s, args) =>
            {
                delayTimer.Stop();
                delayTimer.Dispose();
                hoverTimers.Remove(btn);

                if (btn.ClientRectangle.Contains(btn.PointToClient(Cursor.Position)))
                {
                    Color targetColor = GetHoverColor(btn, isDark);
                    StartButtonAnimation(btn, targetColor, 1.1f); 
                }
            };

            hoverTimers[btn] = delayTimer;
            delayTimer.Start();
        }

        private void Btn_Mantenimientos_MouseLeave(object sender, EventArgs e)
        {
            var manager = MaterialSkin.MaterialSkinManager.Instance;
            var isDark = manager.Theme == MaterialSkinManager.Themes.DARK;

            if (sender is not Button btn) return;

            if (hoverTimers.ContainsKey(btn))
            {
                hoverTimers[btn].Stop();
                hoverTimers[btn].Dispose();
                hoverTimers.Remove(btn);
            }

            Color baseColor = isDark
                ? Color.FromArgb(45, 45, 48)
                : Color.Transparent;

            StartButtonAnimation(btn, baseColor, 1.0f); 
        }

        private void ConfigurarBoton(Button btn, IconChar icon, Color iconColor, string texto, Font font, Color foreColor)
        {
            if (btn is IconButton iconBtn)
            {
                iconBtn.IconChar = icon;
                iconBtn.IconColor = iconColor;
                iconBtn.IconSize = 32;
            }
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn.ImageAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(10, 0, 20, 0);
            btn.Font = font;
            btn.ForeColor = foreColor;
        }
    }
} 
