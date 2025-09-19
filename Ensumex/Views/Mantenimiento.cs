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

            // Si ya está realizado, no abrir modal
            if (estatus == "Realizado")
            {
                MessageBox.Show("Este mantenimiento ya fue realizado.");
                return;
            }

            // Abrir modal para capturar detalle
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
            if (dgvMantenimiento.Columns[e.ColumnIndex].Name == "EstatusCombo")
            {
                var row = dgvMantenimiento.Rows[e.RowIndex];
                int id = Convert.ToInt32(row.Cells["Id"].Value);
                string nuevoEstatus = row.Cells["EstatusCombo"].Value?.ToString();
                int numeroServicios = Convert.ToInt32(row.Cells["NumeroServicios"].Value);

                if (nuevoEstatus == "Realizado")
                {
                    var confirm = MessageBox.Show(
                        "¿Está seguro de marcar este mantenimiento como 'Realizado'? Se aumentará el número de servicios y se guardará la fecha.",
                        "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (confirm == DialogResult.Yes)
                    {
                        using (var obsForm = new ObservacionesForm())
                        {
                            if (obsForm.ShowDialog() == DialogResult.OK)
                            {
                                numeroServicios += 1;
                                DateTime fechaServicio = DateTime.Now;
                                SqlServerRepository.ActualizarMantenimiento(id, "Pendiente", numeroServicios, fechaServicio);
                                SqlServerRepository.InsertarDetalleMantenimiento(id, "Usuario", obsForm.Observaciones);
                                row.Cells["NumeroServicios"].Value = numeroServicios;
                                row.Cells["EstatusCombo"].Value = "Pendiente";
                                row.Cells["Estatus"].Value = "Pendiente";
                            }
                            else
                            {
                                row.Cells["EstatusCombo"].Value = "Pendiente";
                            }
                        }
                    }
                    else
                    {
                        row.Cells["EstatusCombo"].Value = "Pendiente";
                    }
                }
                else
                {
                    DateTime fechaServicio = DateTime.MinValue;
                    SqlServerRepository.ActualizarMantenimiento(id, nuevoEstatus, numeroServicios, fechaServicio);
                    row.Cells["Estatus"].Value = nuevoEstatus; 
                }
            }
        }    }

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
    }
}
