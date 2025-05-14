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
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = new ColorScheme(
            Primary.Green600,  // color base (verde Ensumex)
            Primary.Green700,  // tono oscuro
            Primary.Green400,  // tono claro
            Accent.LightGreen200, // acento
            TextShade.BLACK);
            txt_Usuariologin.Text = "Usuario";
            txt_contrase�alogin.Text = "Contrase�a";
            txt_contrase�alogin.PasswordChar = '\0';
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
        private void bn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //Funcion para validar el usuario y contrase�a

        private void msgError(string mensaje)
        {
            lbl_error.Text = mensaje;
            lbl_error.Visible = true;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        // Funcion para cerrar la sesion
        private void logout(object? sender, FormClosedEventArgs e)
        {
            txt_contrase�alogin.Text = "Contrase�a";
            txt_contrase�alogin.PasswordChar = '\0';
            txt_Usuariologin.Text = "Usuario";
            lbl_error.Visible = false;
            this.Show();
        }

        // Funcion para validar los campos de inicio de sesion
        private bool ValidarEntrada(string usuario, string contrase�a)
        {
            if (string.IsNullOrWhiteSpace(usuario) || usuario.Length < 3)
            {
                msgError("El usuario debe tener al menos 3 caracteres.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(contrase�a) || contrase�a.Length < 6)
            {
                msgError("La contrase�a debe tener al menos 6 caracteres.");
                return false;
            }
            return true;
        }

        [Obsolete]
        private void materialButton1_Click(object sender, EventArgs e)
        {

            if (!ValidarEntrada(txt_Usuariologin.Text, txt_contrase�alogin.Text)) return;

            if (txt_Usuariologin.Text != "Usuario")
            {
                if (txt_contrase�alogin.Text != "Contrase�a")
                {
                    UserModel userModel = new UserModel();
                    bool validar = userModel.LoginUser(txt_Usuariologin.Text, txt_contrase�alogin.Text);
                    // Si la validaci�n es correcta, se cargan los datos del usuario
                    if (validar)
                    {
                        UsuarioLoginCache.Usuario = txt_Usuariologin.Text;
                        ENSUMEX principal = new ENSUMEX();
                        principal.Show();
                        principal.FormClosed += logout;
                        this.Hide();
                    }
                    // Si la validaci�n falla, se muestra un mensaje de error
                    else
                    {
                        msgError("Usuario o contrase�a incorrectos");
                        txt_contrase�alogin.Text = ""; // Limpia la contrase�a sin usar propiedades inv�lidas
                        txt_contrase�alogin.PasswordChar = '*'; // Aseg�rate de seguir ocultando
                        txt_Usuariologin.Focus();
                    }
                }
                else msgError("Ingrese su contrase�a");
            }
            else msgError("Ingrese su usuario");
        }

        private void txt_Usuariologin_MouseEnter(object sender, EventArgs e)
        {
            if (txt_Usuariologin.Text == "Usuario")
                txt_Usuariologin.Text = "";
        }

        private void txt_Usuariologin_MouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Usuariologin.Text))
                txt_Usuariologin.Text = "Usuario";
        }

        private void txt_contrase�alogin_MouseEnter(object sender, EventArgs e)
        {
            if (txt_contrase�alogin.Text == "Contrase�a")
            {
                txt_contrase�alogin.Text = "";
                txt_contrase�alogin.PasswordChar = '*'; // Activa ocultar
            }
        }

        private void txt_contrase�alogin_MouseLeave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_contrase�alogin.Text))
            {
                txt_contrase�alogin.Text = "Contrase�a";
                txt_contrase�alogin.PasswordChar = '\0'; // Muestra el texto plano
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
