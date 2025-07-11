using Ensumex.Controllers;
using Ensumex.Models;
using Ensumex.Utils;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Ensumex.Views
{
    public partial class Users : UserControl
    {
        private bool editando = false;
        private string usuarioOriginal = "";

        public Users()
        {
            InitializeComponent();
            Panel_Nuevousuario.Visible = false;
            TablaFormat.AplicarEstilosTabla(Tabla_usuarios);
            ConfigurarTablaUsuarios();
            CargarUsuariosEnTabla();
        }

        private void ConfigurarTablaUsuarios()
        {
            Tabla_usuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Tabla_usuarios.MultiSelect = false;
            Tabla_usuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Tabla_usuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            if (!Tabla_usuarios.Columns.Contains("Editar"))
            {
                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn
                {
                    Name = "Editar",
                    HeaderText = "Editar",
                    Text = "Editar",
                    UseColumnTextForButtonValue = true
                };
                Tabla_usuarios.Columns.Add(btnEditar);
            }

            Tabla_usuarios.CellClick += Tabla_usuarios_CellClick;
        }

        private void CargarUsuariosEnTabla()
        {
            try
            {
                UsuarioDao modelo = new UsuarioDao();
                DataTable dt = modelo.ObtenerUsuarios();
                Tabla_usuarios.DataSource = dt;
            }
            catch (Exception ex)
            {
                MostrarError("Ocurrió un error al cargar los usuarios.", ex);
            }
        }

        private void btn_nuevoUsuario_Click(object sender, EventArgs e)
        {
            editando = false;
            LimpiarFormulario();
            Panel_Nuevousuario.Visible = true;
            btn_GuardarUsuario.Text = "Guardar";
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            ResetearFormulario();
        }

        private void btn_GuardarUsuario_Click(object sender, EventArgs e)
        {
            if (!CamposCompletos())
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCorreo(textNewCorreo.Text))
            {
                MessageBox.Show("Correo inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GuardarOActualizarUsuario();
        }

        private void GuardarOActualizarUsuario()
        {
            try
            {
                Usuarios usuario = new Usuarios
                {
                    Usuario = textnewUsuario.Text.Trim(),
                    Contraseña = textNewContraseña.Text.Trim(),
                    Nombre = textNewNombre.Text.Trim(),
                    Posicion = cmb_NewPosicion.SelectedItem?.ToString() ?? string.Empty, 
                    Correo = textNewCorreo.Text.Trim()
                };

                UsuarioController controller = new UsuarioController();
                bool resultado = editando
                    ? controller.ActualizarUsuario(usuarioOriginal, usuario)
                    : controller.GuardarUsuario(usuario);

                string mensaje = editando ? "Usuario actualizado correctamente." : "Usuario guardado correctamente.";

                if (resultado)
                {
                    MessageBox.Show(mensaje, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuariosEnTabla();
                    ResetearFormulario();
                }
                else
                {
                    MessageBox.Show("No se pudo guardar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MostrarError("Error de base de datos.", ex);
            }
            catch (FormatException ex)
            {
                MostrarError("Error de formato en los datos.", ex);
            }
            catch (Exception ex)
            {
                MostrarError("Ocurrió un error inesperado.", ex);
            }
        }

        private void Tabla_usuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || Tabla_usuarios.Columns[e.ColumnIndex].Name != "Editar")
                return;

            try
            {
                DataGridViewRow fila = Tabla_usuarios.Rows[e.RowIndex];

                textnewUsuario.Text = fila.Cells["Usuario"]?.Value?.ToString() ?? "";
                textNewNombre.Text = fila.Cells["Nombre"]?.Value?.ToString() ?? "";
                textNewCorreo.Text = fila.Cells["Correo"]?.Value?.ToString() ?? "";
                cmb_NewPosicion.SelectedItem = fila.Cells["Posicion"]?.Value?.ToString();
                textNewContraseña.Text ="";

                usuarioOriginal = textnewUsuario.Text;
                editando = true;
                btn_GuardarUsuario.Text = "Actualizar";
                Panel_Nuevousuario.Visible = true;
            }
            catch (Exception ex)
            {
                MostrarError("Error al cargar datos del usuario seleccionado.", ex);
            }
        }

        private bool CamposCompletos()
        {
            return !string.IsNullOrWhiteSpace(textnewUsuario.Text)
                && !string.IsNullOrWhiteSpace(textNewContraseña.Text)
                && !string.IsNullOrWhiteSpace(textNewNombre.Text)
                && !string.IsNullOrWhiteSpace(textNewCorreo.Text)
                && !string.IsNullOrWhiteSpace(cmb_NewPosicion.Text);
        }

        private bool ValidarCorreo(string correo)
        {
            string patronCorreo = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(correo, patronCorreo);
        }

        private void ResetearFormulario()
        {
            LimpiarFormulario();
            Panel_Nuevousuario.Visible = false;
            editando = false;
            usuarioOriginal = "";
            btn_GuardarUsuario.Text = "Guardar";
        }

        private void LimpiarFormulario()
        {
            textnewUsuario.Clear();
            textNewContraseña.Clear();
            textNewNombre.Clear();
            textNewCorreo.Clear();
            cmb_NewPosicion.SelectedIndex = -1;
            Panel_Nuevousuario.Visible = false;
        }

        private void MostrarError(string mensaje, Exception ex)
        {
            MessageBox.Show($"{mensaje}\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_Cancelar_Click_1(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }
    }
}

