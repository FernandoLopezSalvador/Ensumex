using Ensumex.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ensumex.Views
{
    public partial class Mantenimiento : UserControl
    {
        public Mantenimiento()
        {

            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            DataTable datos = SqlServerRepository.GetMantenimientosConDetalles();
            dgvMantenimiento.DataSource = datos;
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            dgvMantenimiento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMantenimiento.CellFormatting += dgvMantenimiento_CellFormatting;
            dgvMantenimiento.CellDoubleClick += dgvMantenimiento_CellDoubleClick;

            
            if (!dgvMantenimiento.Columns.Contains("FrecuenciaCombo"))
            {
                var comboCol = new DataGridViewComboBoxColumn
                {
                    Name = "FrecuenciaCombo",
                    HeaderText = "Frecuencia (meses)",
                    DataPropertyName = "Frecuencia", // Debe coincidir con el nombre de la columna en tu DataTable
                    Width = 120,
                    DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
                };
                comboCol.Items.AddRange(6, 12, 18, 24, 36); // Puedes agregar más opciones si lo deseas
                dgvMantenimiento.Columns.Insert(dgvMantenimiento.Columns["Frecuencia"].Index, comboCol);
            }
            // Agregar columna de botón solo si no existe
            if (!dgvMantenimiento.Columns.Contains("VerDetalles"))
            {
                var btnCol = new DataGridViewButtonColumn
                {
                    Name = "VerDetalles",
                    HeaderText = "Detalles",
                    Text = "Ver Detalles",
                    UseColumnTextForButtonValue = true,
                    Width = 100
                };
                dgvMantenimiento.Columns.Insert(0, btnCol);
            }
        }

        private void dgvMantenimiento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMantenimiento.Columns[e.ColumnIndex].Name == "Estatus")
            {
                string estatus = e.Value?.ToString();
                if (estatus == "Pendiente")
                    dgvMantenimiento.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                else if (estatus == "Enviado")
                    dgvMantenimiento.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
                else if (estatus == "Realizado")
                    dgvMantenimiento.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }
        private void dgvMantenimiento_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int id = Convert.ToInt32(dgvMantenimiento.Rows[e.RowIndex].Cells["Id"].Value);
            string estatus = dgvMantenimiento.Rows[e.RowIndex].Cells["Estatus"].Value.ToString();

            if (estatus == "Realizado")
            {
                MessageBox.Show("Este mantenimiento ya fue realizado.");
                return;
            }
            using (var form = new DetalleMantenimientoForm(id))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Mantenimiento registrado correctamente.");
                    CargarDatos();
                }
            }
        }
        private void dgvMantenimiento_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMantenimiento.Columns[e.ColumnIndex].Name == "FrecuenciaCombo")
            {
                var row = dgvMantenimiento.Rows[e.RowIndex];
                int id = Convert.ToInt32(row.Cells["Id"].Value);
                int nuevaFrecuencia = Convert.ToInt32(row.Cells["FrecuenciaCombo"].Value);
                SqlServerRepository.ActualizarFrecuenciaMantenimiento(id, nuevaFrecuencia);
                row.Cells["Frecuencia"].Value = nuevaFrecuencia;
                DateTime fechaVenta = Convert.ToDateTime(row.Cells["FechaVenta"].Value);
                DateTime proximoMantenimiento = fechaVenta.AddMonths(nuevaFrecuencia);
                row.Cells["ProximoMantenimiento"].Value = proximoMantenimiento;
            }
        }
        private void dgvMantenimiento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvMantenimiento.Columns[e.ColumnIndex].Name == "VerDetalles")
            {
                int id = Convert.ToInt32(dgvMantenimiento.Rows[e.RowIndex].Cells["Id"].Value);

                using (var detallesForm = new DetallesMantForm(id))
                {
                    detallesForm.ShowDialog();
                }
            }
        }

        private void dgvMantenimiento_CellDoubleClick_2(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvMantenimiento.Columns[e.ColumnIndex].Name == "VerDetalles")
                return;

            int id = Convert.ToInt32(dgvMantenimiento.Rows[e.RowIndex].Cells["Id"].Value);
            string estatus = dgvMantenimiento.Rows[e.RowIndex].Cells["Estatus"].Value.ToString();

            if (estatus == "Realizado")
            {
                MessageBox.Show("Este mantenimiento ya fue realizado.");
                return;
            }
            using (var form = new DetalleMantenimientoForm(id))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Mantenimiento registrado correctamente.");
                    CargarDatos();
                }
            }
        }

        private void dgvMantenimiento_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvMantenimiento.IsCurrentCellDirty)
        dgvMantenimiento.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
    }
    /*
    public class ObservacionesForm : Form
    {
        public string Observaciones { get; private set; }
        private TextBox txtObservaciones;
        private Button btnAceptar;

        public ObservacionesForm()
        {
            txtObservaciones = new TextBox { Multiline = true, Dock = DockStyle.Top, Height = 100 };
            btnAceptar = new Button { Text = "Guardar", Dock = DockStyle.Bottom };
            btnAceptar.Click += (s, e) => { Observaciones = txtObservaciones.Text; DialogResult = DialogResult.OK; };
            Controls.Add(txtObservaciones);
            Controls.Add(btnAceptar);
            Text = "Observaciones de Mantenimiento";
            Size = new Size(300, 200);
        }
    }*/
}
