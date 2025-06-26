using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ensumex.Models;
using Ensumex.Utils;

namespace Ensumex.Views
{
    public partial class Cotizaciones : UserControl
    {
        public Cotizaciones()
        {
            InitializeComponent();
            InicializarTabla();
            CargarCotizaciones();
        }
        private void InicializarTabla()
        {
            tabla_cotizaciones.CellClick += Tabla_cotizaciones_CellClick;
            TablaFormat.AplicarEstilosTabla(tabla_cotizaciones);

            if (!tabla_cotizaciones.Columns.Contains("Detalle"))
            {
                var btnDetalle = new DataGridViewButtonColumn
                {
                    Name = "Detalle",
                    HeaderText = "Acción",
                    Text = "Detalle",
                    UseColumnTextForButtonValue = true
                };
                tabla_cotizaciones.Columns.Add(btnDetalle);
            }
        }
        private void Tabla_cotizaciones_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
        }
        private void CargarCotizaciones()
        {
            DataTable dt = CotizacionRepository.ObtenerCotizaciones();
            tabla_cotizaciones.DataSource = dt;
        }
        private void cmb_clientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Limpiar la tabla antes de cargar nuevos datos
            var selectedValue = cmb_filtrarcotiza.SelectedItem.ToString();
            if (selectedValue == "Todos")
            {
                CargarCotizaciones();
            }
            else
            {
                int limite = int.Parse(selectedValue);
                DataTable dt = CotizacionRepository.ObtenerCotizacionesPorLimite(limite);
                tabla_cotizaciones.DataSource = dt;
            }
        }
        private void text_buscar_TextChanged(object sender, EventArgs e)
        {
            // Filtrar la tabla de cotizaciones según el texto ingresado
            var searchText = text_buscar.Text.ToLower();
            if (string.IsNullOrEmpty(searchText))
            {
                CargarCotizaciones();
            }
            else
            {
                DataTable dt = CotizacionRepository.ObtenerCotizacionesFiltradas(searchText);
                tabla_cotizaciones.DataSource = dt;
            }
        }
        private void tabla_cotizaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Validación básica de clic válido
                if (e.RowIndex < 0 || e.ColumnIndex < 0)
                    return;

                if (tabla_cotizaciones.Columns[e.ColumnIndex].Name == "Detalle")
                {
                    var idValor = tabla_cotizaciones.Rows[e.RowIndex].Cells["IdCotizacion"].Value;

                    if (idValor == null || !int.TryParse(idValor.ToString(), out int idCotizacion))
                    {
                        MessageBox.Show("No se pudo obtener el ID de la cotización.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Obtener detalle
                    DataTable detalle = CotizacionRepository.ObtenerDetallePorId(idCotizacion);

                    if (detalle == null || detalle.Rows.Count == 0)
                    {
                        MessageBox.Show("No hay detalles disponibles para esta cotización.", "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    // Mostrar formulario con detalle
                    using (var detalleForm = new Form())
                    {
                        detalleForm.Text = $"Detalle de Cotización #{idCotizacion}";
                        detalleForm.Size = new Size(980, 400);

                        var dgvDetalle = new DataGridView
                        {
                            DataSource = detalle,
                            Dock = DockStyle.Fill,
                            ReadOnly = true,
                            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

                        };
                        detalleForm.Controls.Add(dgvDetalle);
                        detalleForm.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al mostrar el detalle:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabla_cotizaciones_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
