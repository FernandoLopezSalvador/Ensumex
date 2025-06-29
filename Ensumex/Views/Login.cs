using System.Data.SqlClient;
using Ensumex.Clases;
using Ensumex.Models;
using Ensumex.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Ensumex.Utils;

namespace Ensumex
{
    public partial class Login : MaterialForm
    {
        public Login()
        {
            InitializeComponent();
            ConfigurarMaterialSkin();
            ConfigurarTextosPorDefecto();
            ConfigurarVentana();
        }
        private void ConfigurarMaterialSkin()
        {
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.DARK;
            skinManager.ColorScheme = new ColorScheme(
                Primary.Green600,       // Color principal Ensumex
                Primary.Green700,       // Color oscuro
                Primary.Green400,       // Color claro
                Accent.LightGreen200,   // Color de acento
                TextShade.WHITE         // Sombra del texto
            );
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
        }
        private void msgError(string mensaje)
        {
            lbl_error.Text = mensaje;
            lbl_error.Visible = true;
        }
        // Funcion para cerrar la sesion
        private void logout(object? sender, FormClosedEventArgs e)
        {
            txt_contraseñalogin.Text = "Contraseña";
            txt_contraseñalogin.PasswordChar = '\0';
            txt_Usuariologin.Text = "Usuario";
            lbl_error.Visible = false;
            this.Show();
        }
        // Funcion para validar los campos de inicio de sesion
        private bool ValidarEntrada(string usuario, string contraseña)
        {
            if (string.IsNullOrWhiteSpace(usuario) || usuario.Length < 3)
            {
                msgError("El usuario debe tener al menos 3 caracteres.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(contraseña) || contraseña.Length < 6)
            {
                msgError("La contraseña debe tener al menos 6 caracteres.");
                return false;
            }
            return true;
        }
        [Obsolete]  
        private void materialButton1_Click(object sender, EventArgs e)
        {
            if (!ValidarEntrada(txt_Usuariologin.Text, txt_contraseñalogin.Text)) return;
            if (txt_Usuariologin.Text != "Usuario")
            {
                if (txt_contraseñalogin.Text != "Contraseña")
                {
                    Models.UserModel userModel = new Models.UserModel();
                    bool validar = userModel.LoginUser(txt_Usuariologin.Text, txt_contraseñalogin.Text);
                    // Si la validación es correcta, se cargan los datos del usuario
                    if (validar)
                    {
                        UsuarioLoginCache.Usuario = txt_Usuariologin.Text;
                        ENSUMEX principal = new ENSUMEX();
                        principal.Show();
                        principal.FormClosed += logout;
                        this.Hide();
                    }
                    // Si la validación falla, se muestra un mensaje de error
                    else
                    {
                        msgError("Usuario o contraseña incorrectos");
                        txt_contraseñalogin.Text = ""; // Limpia la contraseña sin usar propiedades inválidas
                        txt_contraseñalogin.PasswordChar = '*'; // Asegúrate de seguir ocultando
                        txt_Usuariologin.Focus();
                    } 
                }
                else msgError("Ingrese su contraseña");
                    txt_contraseñalogin.Focus(); // Mueve el foco al campo de contraseña
            }
            else msgError("Ingrese su usuario");
                txt_contraseñalogin.Focus(); // Mueve el foco al campo de contraseña
        }
        private void txt_Usuariologin_MouseEnter(object sender, EventArgs e)
        {
        }
        private void txt_Usuariologin_MouseLeave(object sender, EventArgs e)
        {
        }
        private void txt_contraseñalogin_MouseEnter(object sender, EventArgs e)
        {
        }
        private void txt_contraseñalogin_MouseLeave(object sender, EventArgs e)
        {
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
    }
}
