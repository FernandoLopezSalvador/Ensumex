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
            // Traemos los datos de Firebird
            var datos = FirebirdRepository.GetCalentadoresParaMantenimiento();

            // Si tu método GetCalentadoresParaMantenimiento NO trae el campo "Estatus", lo agregamos aquí:
            if (!datos.Columns.Contains("Estatus"))
                datos.Columns.Add("Estatus", typeof(string));

            // Asignamos estatus inicial a Pendiente
            foreach (DataRow row in datos.Rows)
            {
                if (row["Estatus"] == DBNull.Value || string.IsNullOrEmpty(row["Estatus"].ToString()))
                    row["Estatus"] = "Pendiente";
            }

            dgvMantenimiento.DataSource = datos;

            // Configurar columnas
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            // Evitar duplicar columnas
            if (dgvMantenimiento.Columns["EstatusCombo"] != null) return;

            // Crear ComboBox para el estatus
            DataGridViewComboBoxColumn comboEstatus = new DataGridViewComboBoxColumn();
            comboEstatus.HeaderText = "Estatus";
            comboEstatus.Name = "EstatusCombo";
            comboEstatus.DataPropertyName = "Estatus"; // Vinculado al campo
            comboEstatus.Items.AddRange("Pendiente", "Enviado", "Realizado");

            dgvMantenimiento.Columns.Add(comboEstatus);

            dgvMantenimiento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Evento para colorear las filas según estatus
            dgvMantenimiento.CellFormatting += dgvMantenimiento_CellFormatting;
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
    }
}
