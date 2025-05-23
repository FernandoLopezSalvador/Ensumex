using Ensumex.Controllers;
using Ensumex.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ensumex.Views
{
    public partial class Users : UserControl
    {
        public Users()
        {
            InitializeComponent();
            Panel_Nuevousuario.Visible = false;
            ConfigurarTablaUsuarios();
            CargarUsuariosEnTabla();
        }
        private void ConfigurarTablaUsuarios()
        {
            Tabla_usuarios.DefaultCellStyle.ForeColor = Color.Black; // Color de texto blanco
            Tabla_usuarios.BackgroundColor = Color.FromArgb(45, 45, 48); // Fondo oscuro
        }
        private void btn_nuevoUsuario_Click(object sender, EventArgs e)
        {
            Panel_Nuevousuario.Visible = true;
        }

        [Obsolete]
        private void btn_GuardarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                string correo = textNewCorreo.Text;

                if (ValidarCorreo(correo))
                {
                    if (string.IsNullOrEmpty(textnewUsuario.Text) || string.IsNullOrEmpty(textNewContraseña.Text) || string.IsNullOrEmpty(textNewNombre.Text) || string.IsNullOrEmpty(cmb_NewPosicion.Text) || string.IsNullOrEmpty(textNewCorreo.Text))
                    {
                        MessageBox.Show("Por favor, complete todos los campos.");
                        return;
                    }
                    else
                    {
                        // Crear un nuevo objeto de Usuarios y asignar los valores de los campos de texto
                        Usuarios usuarios = new Usuarios()
                        {
                            Usuario = textnewUsuario.Text.Trim(),
                            Contraseña = textNewContraseña.Text.Trim(),
                            Nombre = textNewNombre.Text.Trim(),
                            Posision = cmb_NewPosicion.SelectedItem.ToString(),
                            Correo = textNewCorreo.Text.Trim()
                        };

                        // Crear una instancia del controlador de usuarios y guardar el nuevo usuario
                        UsuarioController controller = new UsuarioController();
                        bool guardado = controller.GuardarUsuario(usuarios);
                        if (guardado)
                        {
                            MessageBox.Show("Usuario guardado correctamente.");
                            CargarUsuariosEnTabla();
                            this.Panel_Nuevousuario.Visible = false;
                            textnewUsuario.Clear();
                            textNewContraseña.Clear();
                            textNewCorreo.Clear();
                            textNewNombre.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Error al guardar el usuario.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Correo inválido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textNewContraseña.Text = "";
                }
            }
            catch (FormatException ex)
            {
                // Manejar errores de formato, como una conversión incorrecta
                MessageBox.Show($"Error de formato: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                // Manejar errores específicos de la base de datos
                MessageBox.Show($"Error de base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Capturar cualquier otra excepción no prevista
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCorreo(string correo)
        {
            // Expresión regular para validar un correo electrónico
            string patronCorreo = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Verifica si el correo coincide con el patrón
            return Regex.IsMatch(correo, patronCorreo);
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            Panel_Nuevousuario.Visible = false;
        }

        private void Tabla_usuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Evitar errores al hacer clic en encabezados
            if (e.RowIndex < 0)
                return;
            string usuario = Tabla_usuarios.Rows[e.RowIndex].Cells["Usuario"].Value.ToString();

            if (Tabla_usuarios.Columns[e.ColumnIndex].Name == "Editar")
            {
                MessageBox.Show("Editar usuario: " + usuario);
                // Aquí puedes abrir un nuevo formulario para editar los datos
            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void CargarUsuariosEnTabla()
        {
            try
            {
                UsuarioDao modelo = new UsuarioDao();
                DataTable dt = modelo.ObtenerUsuarios();
                Tabla_usuarios.DataSource = dt;

                if (Tabla_usuarios.Columns["Editar"] == null)
                {
                    DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                    btnEditar.Name = "Editar";
                    btnEditar.HeaderText = "Editar";
                    btnEditar.Text = "Editar";
                    btnEditar.UseColumnTextForButtonValue = true;
                    Tabla_usuarios.Columns.Add(btnEditar);
                }
            }
            
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los usuarios:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_GuardarUsuario_Click_1(object sender, EventArgs e)
        {

        }
    }
}
        