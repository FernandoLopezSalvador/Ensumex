using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ensumex.Controllers;
using Ensumex.Models;
using Ensumex.Utils;

namespace Ensumex.Views
{
    public partial class panel23 : Form
    {
        public panel23()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Usuarios_Load(object sender, EventArgs e)
        {

        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            VentanaHelper.Minimizar(this);
        }

        private void btn_maximizar_Click(object sender, EventArgs e)
        {
            VentanaHelper.Maximizar(this);
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            VentanaHelper.Cerrar(this);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btn_editarUsuario_Click(object sender, EventArgs e)
        {

        }

        private void btn_cerrarsesion_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Cerrar sesion?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_inventario_MouseEnter(object sender, EventArgs e)
        {
            btn_inventario.BackColor = Color.FromArgb(25, 239, 22);
        }

        private void btn_inventario_MouseLeave(object sender, EventArgs e)
        {
            btn_inventario.BackColor = Color.FromArgb(0, 81, 46);
        }

        private void btn_cotizacion_MouseEnter(object sender, EventArgs e)
        {
            btn_cotizacion.BackColor = Color.FromArgb(25, 239, 22);
        }

        private void btn_cotizacion_MouseLeave(object sender, EventArgs e)
        {
            btn_cotizacion.BackColor = Color.FromArgb(0, 81, 46);
        }

        private void btn_clientes_MouseEnter(object sender, EventArgs e)
        {
            btn_clientes.BackColor = Color.FromArgb(25, 239, 22);
        }

        private void btn_clientes_MouseLeave(object sender, EventArgs e)
        {
            btn_clientes.BackColor = Color.FromArgb(0, 81, 46);
        }

        private void btn_nuevoUsuario_Click(object sender, EventArgs e)
        {  
            if(string.IsNullOrEmpty(textnewUsuario.Text) || string.IsNullOrEmpty(textNewContraseña.Text) || string.IsNullOrEmpty(textNewNombre.Text) || string.IsNullOrEmpty(cmb_NewPosicion.Text) || string.IsNullOrEmpty(textNewCorreo.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.");
                return;
            }
            else
            {
                Usuarios usuarios = new Usuarios()
                {
                    Usuario = textnewUsuario.Text.Trim(),
                    Contraseña = textNewContraseña.Text.Trim(),
                    Nombre = textNewNombre.Text.Trim(),
                    Posision = cmb_NewPosicion.SelectedItem.ToString(),
                    Correo = textNewCorreo.Text.Trim()
                };
                UsuarioController controller = new UsuarioController();
                bool guardado = controller.GuardarUsuario(usuarios);
                if (guardado)
                    MessageBox.Show("Usuario guardado correctamente.");
                else
                    MessageBox.Show("Error al guardar el usuario.");
            }
            
            
        }
    }
}
