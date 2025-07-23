using Ensumex.Clases;
using Ensumex.Forms;
using Ensumex.Models;
using Ensumex.Utils;
using Ensumex.Views;
using MaterialSkin;
using System.Threading.Tasks;
using MaterialSkin.Controls;
using System.Data.SqlClient;

namespace Ensumex
{
    public partial class Login : MaterialForm
    {
        //private PictureBox pic_MostrarContraseña1;
        private string pathOpen;
        private string pathClosed;
        private bool contraseñaVisible = false;
        public Login()
        {
            InitializeComponent();
            Vercontraseña();
            Tema.ConfigurarTema(this);
            ConfigurarTextosPorDefecto();
            ConfigurarVentana();
        }
        private void Vercontraseña()
        {
            pathOpen = Path.Combine(Application.StartupPath, "IMG", "eye_open.png");
            pathClosed = Path.Combine(Application.StartupPath, "IMG", "eye_closed.png");

            pic_MostrarContraseña = new PictureBox();
            pic_MostrarContraseña.Image = Image.FromFile(pathClosed);
            pic_MostrarContraseña.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_MostrarContraseña.Width = 40;  // Aumenta el tamaño aquí
            pic_MostrarContraseña.Height = 40;
            pic_MostrarContraseña.Cursor = Cursors.Hand;
            pic_MostrarContraseña.Location = new Point(
                txt_contraseñalogin.Right + 3,
                txt_contraseñalogin.Top + (txt_contraseñalogin.Height - pic_MostrarContraseña.Height)/2
            );
            pic_MostrarContraseña.Click += pic_MostrarContraseña_Click;
            this.Controls.Add(pic_MostrarContraseña);
        }
        private void ConfigurarTextosPorDefecto()
        {
            txt_Usuariologin.Text = "Usuario";
            txt_contraseñalogin.Text = "Contraseña";
            txt_contraseñalogin.PasswordChar = '\0'; // Mostrar texto como normal
        }
        private void ConfigurarVentana()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
        private async void msgError(string mensaje)
        {
            lbl_error.Text = mensaje;
            lbl_error.Visible = true;

            // Rojo Material Design con alpha inicial 0
            Color baseColor = Color.FromArgb(244, 67, 54);

            // Fade in (de alpha 0 a 255)
            for (int alpha = 0; alpha <= 255; alpha += 15)
            {
                lbl_error.ForeColor = Color.FromArgb(alpha, baseColor.R, baseColor.G, baseColor.B);
                await Task.Delay(30);
            }

            // Esperar 3 segundos
            await Task.Delay(3000);

            // Fade out (de alpha 255 a 0)
            for (int alpha = 255; alpha >= 0; alpha -= 15)
            {
                lbl_error.ForeColor = Color.FromArgb(alpha, baseColor.R, baseColor.G, baseColor.B);
                await Task.Delay(30);
            }

            lbl_error.Visible = false;
        }
        // Funcion para validar los campos de inicio de sesion
        private bool ValidarEntrada(string usuario, string contraseña)
        {
            if (string.IsNullOrWhiteSpace(usuario))
            {
                msgError("⚠️ El campo usuario no puede estar vacío.");
                return false;
            }
            if (usuario.Length < 3)
            {
                msgError("⚠️ El usuario debe tener al menos 3 caracteres.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(contraseña))
            {
                msgError("⚠️ El campo contraseña no puede estar vacío.");
                return false;
            }
            if (contraseña.Length < 6)
            {
                msgError("⚠️ La contraseña debe tener al menos 6 caracteres.");
                return false;
            }
            return true;
        }
        [Obsolete]
        private void materialButton1_Click(object sender, EventArgs e)
        {
            IntentarLogin();
        }
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        private void txt_contraseñalogin_Enter(object sender, EventArgs e)
        {
            if (txt_contraseñalogin.Text == "Contraseña")
            {
                txt_contraseñalogin.Text = "";
                txt_contraseñalogin.PasswordChar = '*'; // Activa ocultar
            }
        }
        private void txt_contraseñalogin_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_contraseñalogin.Text))
            {
                txt_contraseñalogin.Text = "Contraseña";
                txt_contraseñalogin.PasswordChar = '\0'; // Muestra el texto plano
            }
        }
        private void txt_Usuariologin_Enter(object sender, EventArgs e)
        {
            if (txt_Usuariologin.Text == "Usuario")
                txt_Usuariologin.Text = "";
        }
        private void txt_Usuariologin_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Usuariologin.Text))
                txt_Usuariologin.Text = "Usuario";
        }
        private void txt_contraseñalogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                IntentarLogin();
        }
        private void IntentarLogin()
        {
            if (!ValidarEntrada(txt_Usuariologin.Text, txt_contraseñalogin.Text))
                return;

            if (txt_Usuariologin.Text == "Usuario")
            {
                msgError("Ingrese su usuario");
                txt_Usuariologin.Focus();
                return;
            }

            if (txt_contraseñalogin.Text == "Contraseña")
            {
                msgError("Ingrese su contraseña");
                txt_contraseñalogin.Focus();
                return;
            }

            Models.UserModel userModel = new Models.UserModel();
            bool validar = false;

            try
            {
                validar = userModel.LoginUser(txt_Usuariologin.Text, txt_contraseñalogin.Text);
            }
            catch (Exception ex)
            {
                msgError("Conexión al servidor no disponible.\nDetalles: " + ex.Message);
                return;
            }

            if (validar)
            {
                UsuarioLoginCache.Usuario = txt_Usuariologin.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                msgError("Usuario o contraseña incorrectos");
                txt_contraseñalogin.Text = "";
                txt_contraseñalogin.PasswordChar = '*';
                txt_contraseñalogin.Focus();
            }
        }
        private void pic_MostrarContraseña_Click(object sender, EventArgs e)
        {

            if (contraseñaVisible)
            {
                txt_contraseñalogin.PasswordChar = '*';
                pic_MostrarContraseña.Image = Image.FromFile(pathClosed);
                contraseñaVisible = false;
            }
            else
            {
                txt_contraseñalogin.PasswordChar = '\0';
                pic_MostrarContraseña.Image = Image.FromFile(pathOpen);
                contraseñaVisible = true;
            }
        }
    }
}
