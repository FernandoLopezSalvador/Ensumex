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

        private void textcontraseña_Enter(object sender, EventArgs e)
        {
            if (textcontraseña.Text == "Contraseña")
            {
                textcontraseña.Text = "";
                textcontraseña.ForeColor = Color.LimeGreen;
                textcontraseña.UseSystemPasswordChar = true;
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

        private void textcontraseña_Leave(object sender, EventArgs e)
        {
            if (textcontraseña.Text == "")
            {
                textcontraseña.Text = "Contraseña";
                textcontraseña.ForeColor = Color.White;
                textcontraseña.UseSystemPasswordChar = false;
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
    }
}
