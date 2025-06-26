using Ensumex.Controllers;
using Ensumex.Models;
using Ensumex.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
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
            TablaFormat.AplicarEstilosTabla(Tabla_usuarios);
            CargarUsuariosEnTabla();
        }
        private void btn_nuevoUsuario_Click(object sender, EventArgs e)
        {
            Panel_Nuevousuario.Visible = true;
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
        // Método para cargar los usuarios en la tabla
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
        private void btn_GuardarUsuario_Click_2(object sender, EventArgs e)
        {
            // Validar el corre  electrónico antes de guardar el usuaio.
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
                MessageBox.Show($"Error de formato: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error de base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

