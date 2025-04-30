using System.Data.SqlClient;
using Ensumex.Clases;
using Ensumex.Clases.Domain;
using Ensumex.Forms;
using Ensumex.Clases.Domain; // Changed from 'using static Ensumex.Clases.Domain;' to 'using Ensumex.Clases.Domain;'

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

        private void btn_login_Click(object sender, EventArgs e)
        {
            if (text_usuario.Text != "Usuario")
            {
                if (text_contrase�a.Text != "Contrase�a")
                {
                    UserModel userModel = new UserModel(); // Added this line to create an instance of UserModel.
                    var validar = userModel.LoginUser(text_usuario.Text, text_contrase�a.Text); // Updated to call LoginUser on UserModel.
                    if(validar == true)
                    {
                        Principal principal = new Principal();
                        principal.Show();
                        this.Hide();
                    }
                    else
                    {
                        msgError("Usuario o contrase�a incorrectos");
                        text_contrase�a.Clear();
                        text_usuario.Focus();
                    }
                }
                else msgError("Ingrese su contrase�a");
            }
            else msgError("Ingrese su usuario");
        }
        private void msgError(string mensaje)
        {
            lbl_error.Text = mensaje; // Corrected to use the 'mensaje' parameter instead of the method group 'msgError'.  
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
    }
}
