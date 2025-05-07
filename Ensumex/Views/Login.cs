using System.Data.SqlClient;
using Ensumex.Clases;
using Ensumex.Models;
using Ensumex.Forms; 

namespace Ensumex
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void text_usuario_Enter(object sender, EventArgs e)
        {
            if (text_usuario.Text == "Usuario")
            {
                text_usuario.Text = "";
                text_usuario.ForeColor = Color.LimeGreen;
            }
        }

        private void textcontrase�a_Enter(object sender, EventArgs e)
        {
            if (text_contrase�a.Text == "Contrase�a")
            {
                text_contrase�a.Text = "";
                text_contrase�a.ForeColor = Color.LimeGreen;
                text_contrase�a.UseSystemPasswordChar = true;
            }
        }

        private void text_usuario_Leave(object sender, EventArgs e)
        {
            if (text_usuario.Text == "")
            {
                text_usuario.Text = "Usuario";
                text_usuario.ForeColor = Color.White;
                text_contrase�a.UseSystemPasswordChar = false;
            }
        }

        private void textcontrase�a_Leave(object sender, EventArgs e)
        {
            if (text_contrase�a.Text == "")
            {
                text_contrase�a.Text = "Contrase�a";
                text_contrase�a.ForeColor = Color.White;
                text_contrase�a.UseSystemPasswordChar = false;
            }
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
        private void btn_login_Click(object sender, EventArgs e)
        {
            if (!ValidarEntrada(text_usuario.Text, text_contrase�a.Text)) return;

            if (text_usuario.Text != "Usuario")
            {
                if (text_contrase�a.Text != "Contrase�a")
                {
                    UserModel userModel = new UserModel();
                    bool validar = userModel.LoginUser(text_usuario.Text, text_contrase�a.Text);

                    if (validar)
                    {
                        UsuarioLoginCache.Usuario = text_usuario.Text;
                        Principal principal = new Principal();
                        principal.Show();
                        principal.FormClosed += logout;
                        this.Hide();
                    }
                    else
                    {
                        msgError("Usuario o contrase�a incorrectos");
                        text_contrase�a.UseSystemPasswordChar = false;
                        text_contrase�a.Text = "Contrase�a";
                        text_usuario.Focus();
                    }
                }
                else msgError("Ingrese su contrase�a");
            }
            else msgError("Ingrese su usuario");
        }
        private void msgError(string mensaje)
        {
            lbl_error.Text = mensaje;   
            lbl_error.Visible = true;
        }

        private void text_usuario_TextChanged(object sender, EventArgs e)
        {
            if (text_usuario.Text == "Usuario")
            {
                text_usuario.ForeColor = Color.White;
            }
            else
            {
                text_usuario.ForeColor = Color.LimeGreen;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
        private void logout(object? sender, FormClosedEventArgs e)
        {
            text_contrase�a.Text = "Contrase�a";
            text_contrase�a.UseSystemPasswordChar = false;
            text_usuario.Text = "Usuario";
            lbl_error.Visible = false;
            this.Show();
        }

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
    }
}
