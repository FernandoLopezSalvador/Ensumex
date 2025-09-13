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
            var datos = SqlServerRepository.GetMantenimientos();
            dgvMantenimiento.DataSource = datos;
            ConfigurarGrid();
            if (dgvMantenimiento.Columns["BtnDetalles"] == null)
            {
                var btnDetalles = new DataGridViewButtonColumn
                {
                    Name = "BtnDetalles",
                    HeaderText = "Detalles",
                    Text = "Ver Detalles",
                    UseColumnTextForButtonValue = true
                };
                dgvMantenimiento.Columns.Add(btnDetalles);
            }
        }

        private void ConfigurarGrid()
        {
            if (dgvMantenimiento.Columns["EstatusCombo"] != null) return;

            if (dgvMantenimiento.Columns["NumeroServicios"] == null)
            {
                dgvMantenimiento.Columns["NumeroServicios"].HeaderText = "Servicios Realizados";
                dgvMantenimiento.Columns["NumeroServicios"].ReadOnly = true;
            }

            DataGridViewComboBoxColumn comboEstatus = new DataGridViewComboBoxColumn
            {
                HeaderText = "Estatus",
                Name = "EstatusCombo",
                DataPropertyName = "Estatus", 
                Items = { "Pendiente", "Enviado", "Realizado" }
            };

            dgvMantenimiento.Columns.Add(comboEstatus);
            dgvMantenimiento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMantenimiento.CellFormatting += dgvMantenimiento_CellFormatting;
            dgvMantenimiento.CellValueChanged += dgvMantenimiento_CellValueChanged;
            dgvMantenimiento.CellClick += dgvMantenimiento_CellClick;
        }

        private void dgvMantenimiento_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvMantenimiento.Columns[e.ColumnIndex].Name == "EstatusCombo")
            {
                var estatus = e.Value?.ToString();

                if (estatus == "Pendiente")
                    dgvMantenimiento.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
                else if (estatus == "Enviado")
                    dgvMantenimiento.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
                else if (estatus == "Realizado")
                    dgvMantenimiento.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
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
                                SqlServerRepository.InsertarDetalleMantenimiento(id, fechaServicio, "Realizado", obsForm.Observaciones);

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
        }

        private void dgvMantenimiento_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var row = dgvMantenimiento.Rows[e.RowIndex];

            if (dgvMantenimiento.Columns[e.ColumnIndex].Name == "BtnDetalles")
            {
                int mantenimientoId = Convert.ToInt32(row.Cells["MantenimientoId"].Value);
                //var detalleForm = new DetalleMantenimientoForm(mantenimientoId);
                //detalleForm.ShowDialog();
            }

            if (dgvMantenimiento.Columns[e.ColumnIndex].Name == "BtnEstatus")
            {
                var estatusActual = row.Cells["Estatus"].Value?.ToString();
                var nuevoEstatus = Microsoft.VisualBasic.Interaction.InputBox(
                    $"Estatus actual: {estatusActual}\nIngrese nuevo estatus (Pendiente, Enviado, Realizado):",
                    "Cambiar Estatus", estatusActual);
                if (!string.IsNullOrWhiteSpace(nuevoEstatus))
                {
                    int id = Convert.ToInt32(row.Cells["Id"].Value);
                    int numeroServicios = Convert.ToInt32(row.Cells["NumeroServicios"].Value);
                    DateTime fechaServicio = DateTime.MinValue; 
                    SqlServerRepository.ActualizarMantenimiento(id, nuevoEstatus, numeroServicios, fechaServicio);
                    row.Cells["Estatus"].Value = nuevoEstatus;
                }
            }
        }
    }

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
