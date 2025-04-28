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
            if (textcontrase�a.Text == "Contrase�a")
            {
                textcontrase�a.Text = "";
                textcontrase�a.ForeColor = Color.LimeGreen;
                textcontrase�a.UseSystemPasswordChar = true;
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
            if (textcontrase�a.Text == "")
            {
                textcontrase�a.Text = "Contrase�a";
                textcontrase�a.ForeColor = Color.White;
                textcontrase�a.UseSystemPasswordChar = false;
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
