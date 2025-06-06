﻿using Ensumex.Forms;
using Ensumex.Models;
using Ensumex.Services;
using Ensumex.Utils;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.VisualBasic;
using OfficeOpenXml.Drawing.Chart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ensumex.Views
{
    public partial class Cotiza : UserControl
    {
        public Cotiza()
        {
            InitializeComponent();
            AplicarEstilosTabla(tbl_Productos);
            AplicarEstilosTabla(tbl_Cotizacion);
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            CargarProductoss();
            AgregarDescuentos(new[] { "0%", "5%", "10%", "15%", "20%", "25%", "30" });
            AgregarColumnasCotizacion();
        }
        // Método para aplicar estilos
        private void AplicarEstilosTabla(DataGridView tabla)
        {
            tabla.EnableHeadersVisualStyles = false;
            tabla.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(64, 64, 64);
            tabla.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            tabla.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            tabla.DefaultCellStyle.BackColor = Color.White;
            tabla.DefaultCellStyle.ForeColor = Color.Black;
            tabla.DefaultCellStyle.SelectionBackColor = Color.LightSkyBlue;
            tabla.DefaultCellStyle.SelectionForeColor = Color.Black;
            tabla.RowTemplate.Height = 30;
            tabla.GridColor = Color.LightGray;
            tabla.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
        }
        // Método para agregar descuentos
        private void AgregarDescuentos(string[] descuentos)
        {
            cmb_Descuento.Items.AddRange(descuentos);
        }
        // Método para agregar columnas
        private void AgregarColumnasCotizacion()
        {
            try
            {
                string[,] columnas = {
            { "CLAVE", "Clave" },
            { "DESCRIPCIÓN", "Descripción" },
            { "UNIDAD", "Unidad" },
            { "PRECIO", "precio" },
            { "CANTIDAD", "Cantidad" },
            { "TasaCambio", "Tasa Cambio" },
            { "Subtotal", "Subtotal" }
        };

                for (int i = 0; i < columnas.GetLength(0); i++)
                {
                    string nombreInterno = columnas[i, 0];
                    string encabezado = columnas[i, 1];

                    // Verifica si la columna ya existe antes de agregar
                    if (!tbl_Cotizacion.Columns.Contains(nombreInterno))
                    {
                        tbl_Cotizacion.Columns.Add(nombreInterno, encabezado);
                    }
                }
                tbl_Cotizacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


                // Verifica si la columna "TasaCambio" fue creada exitosamente
                if (tbl_Cotizacion.Columns.Contains("TasaCambio"))
                {
                    tbl_Cotizacion.Columns["TasaCambio"].ReadOnly = true;
                }
                else
                {
                    MessageBox.Show("La columna 'TasaCambio' no fue creada correctamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al agregar las columnas de la cotización:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Btn_guardarCotizacion_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Archivo PDF|*.pdf";
                    sfd.FileName = $"Cotizacion_{DateTime.Now:yyyyMMdd}.pdf";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        // Validaciones mínimas
                        if (string.IsNullOrWhiteSpace(txt_Nombrecliente.Text))
                        {
                            MessageBox.Show("El nombre del cliente es obligatorio.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        if (tbl_Cotizacion.Rows.Count == 1)
                        {
                            MessageBox.Show("No hay productos en la cotización.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        // Generar el PDF
                        PDFGenerator.GenerarPDFCotizacion(
                            rutaArchivo: sfd.FileName,
                            numeroCotizacion: txt_Nocotizacion.Text,
                            nombreCliente: txt_Nombrecliente.Text,
                            costoInstalacion: txt_Costoinstalacion.Text,
                            costoFlete: txt_Costoflete.Text,
                            subtotal: lbl_Subtotal.Text,
                            total: lbl_TotalNeto.Text,
                            descuento: lbl_costoDescuento.Text,
                            tablaCotizacion: tbl_Cotizacion
                        );
                        MessageBox.Show("Cotización guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiaCampos();
                    }
                }
            }
            catch (IOException ioEx)
            {
                MessageBox.Show($"Error al guardar el archivo. Verifica que no esté en uso.\n\n{ioEx.Message}", "Error de archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar la cotización.\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarProductoss(int? limite = 100)
        {
            try
            {
                var productoService = new ProductoServices1();
                var productos = productoService.ObtenerProductos(limite)
                    .Where(p => int.TryParse(p.EXIST, out var existencias) && existencias > 0)
                    .Select(p => new
                    {
                        CLAVE = p.CVE_ART,
                        DESCRIPCIÓN = p.DESCR,
                        UNIDAD = p.UNI_MED,
                        PRECIO = p.COSTO_PROM,
                        EXISTENCIAS = int.TryParse(p.EXIST, out var existencias) ? existencias : 0
                    })
                    .ToList();

                tbl_Productos.DataSource = productos;

                // Evitar columnas duplicadas
                if (!tbl_Productos.Columns.Contains("Agregar"))
                {
                    DataGridViewButtonColumn btnAgregar = new DataGridViewButtonColumn();
                    btnAgregar.Name = "Agregar";
                    btnAgregar.HeaderText = "Acción";
                    btnAgregar.Text = "Agregar";
                    btnAgregar.UseColumnTextForButtonValue = true;
                    tbl_Productos.Columns.Add(btnAgregar);
                }

                // Estilo del botón "Agregar"
                foreach (DataGridViewRow fila in tbl_Productos.Rows)
                {
                    DataGridViewButtonCell btn = fila.Cells["Agregar"] as DataGridViewButtonCell;
                    if (btn != null)
                    {
                        btn.Style.BackColor = Color.SeaGreen;
                        btn.Style.ForeColor = Color.White;
                        btn.Style.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                        btn.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
                // Ajustar columnas automáticamente
                tbl_Productos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tbl_Productos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == tbl_Productos.Columns["Agregar"].Index && e.RowIndex >= 0)
                {
                    var fila = tbl_Productos.Rows[e.RowIndex];
                    // Validación previa por seguridad
                    if (fila.Cells["CLAVE"].Value == null ||
                        fila.Cells["DESCRIPCIÓN"].Value == null ||
                        fila.Cells["PRECIO"].Value == null)
                    {
                        MessageBox.Show("Uno o más datos del producto están vacíos o no disponibles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    string clave = fila.Cells["CLAVE"].Value.ToString();
                    string descripcion = fila.Cells["DESCRIPCIÓN"].Value.ToString();
                    string unidad = fila.Cells["UNIDAD"].Value.ToString();
                    if (!decimal.TryParse(fila.Cells["PRECIO"].Value.ToString(), out decimal precio))
                    {
                        MessageBox.Show("El precio no es válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Solicita la tasa de cambio
                    string input = Interaction.InputBox("Ingrese la tasa de cambio para este producto (si aplica):", "Tasa de Cambio", "1");
                    decimal tasaCambio;
                    bool esValido = decimal.TryParse(input, out tasaCambio);
                    if (!esValido || tasaCambio <= 0)
                    {
                        //MessageBox.Show("La tasa ingresada no es válida o es 0. Se usará el valor por defecto (1).", "Tasa inválida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tasaCambio = 1;
                    }
                    decimal precioConvertido = precio * tasaCambio;
                    // Agrega la fila con la tasa de cambio (campo 6)
                    tbl_Cotizacion.Rows.Add(clave, descripcion, unidad, precio, 1, tasaCambio, precioConvertido);
                    ActualizarTotales();
                }
                // Asegura que la columna de "Eliminar" solo se agregue una vez
                if (!tbl_Cotizacion.Columns.Contains("Eliminar"))
                {
                    DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                    btnEliminar.Name = "Eliminar";
                    btnEliminar.HeaderText = "Acción";
                    btnEliminar.Text = "Eliminar";
                    btnEliminar.UseColumnTextForButtonValue = true;
                    tbl_Cotizacion.Columns.Add(btnEliminar);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al agregar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tbl_Cotizacion_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Solo validar si se edita la columna de cantidad
                if (e.ColumnIndex == tbl_Cotizacion.Columns["CANTIDAD"].Index)
                {
                    var row = tbl_Cotizacion.Rows[e.RowIndex];
                    string clave = row.Cells["CLAVE"].Value?.ToString();
                    // Buscar existencias en tbl_Productos
                    int existencias = 0;
                    foreach (DataGridViewRow prodRow in tbl_Productos.Rows)
                    {
                        if (prodRow.IsNewRow) continue;
                        if (prodRow.Cells["CLAVE"].Value?.ToString() == clave)
                        {
                            int.TryParse(prodRow.Cells["EXISTENCIAS"].Value?.ToString(), out existencias);
                            break;
                        }
                    }
                    if (decimal.TryParse(row.Cells["CANTIDAD"].Value?.ToString(), out decimal cantidad))
                    {
                        if (cantidad > existencias)
                        {
                            MessageBox.Show($"No hay suficientes existencias. Solo hay {existencias} disponibles.", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            row.Cells["CANTIDAD"].Value = existencias > 0 ? existencias : 1;
                        }
                    }
                }
                // Recalcular subtotal y totales si corresponde
                if (e.ColumnIndex == tbl_Cotizacion.Columns["CANTIDAD"].Index ||
                    e.ColumnIndex == tbl_Cotizacion.Columns["TasaCambio"].Index)
                {
                    var row = tbl_Cotizacion.Rows[e.RowIndex];
                    if (decimal.TryParse(row.Cells["PRECIO"].Value?.ToString(), out decimal precio) &&
                        decimal.TryParse(row.Cells["CANTIDAD"].Value?.ToString(), out decimal cantidad) &&
                        decimal.TryParse(row.Cells["TasaCambio"].Value?.ToString(), out decimal tasa))
                    {
                        decimal subtotal = precio * cantidad * tasa;
                        row.Cells["Subtotal"].Value = subtotal;
                        ActualizarTotales();
                    }
                    else
                    {
                        MessageBox.Show("Por favor, asegúrate de que los campos Precio, Cantidad y Tasa de Cambio contengan valores numéricos válidos.",
                                        "Valores inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al calcular el subtotal o validar existencias:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmb_Descuento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTotales();
        }
        private void txt_Costoinstalacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) // 8 es el código ASCII para la tecla 'Backspace'
            {
                e.Handled = true;  // Bloquea la entrada de caracteres no numéricos
            }
        }
        private void txt_Costoflete_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) // 8 es el código ASCII para la tecla 'Backspace'
            {
                e.Handled = true;  // Bloquea la entrada de caracteres no numéricos
            }
        }
        private void btn_AgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                using (var formProducto = new ProdTemp())
                {
                    if (formProducto.ShowDialog() == DialogResult.OK)
                    {
                        // Validación de datos nulos o inconsistentes
                        if (string.IsNullOrWhiteSpace(formProducto.Clave) || string.IsNullOrWhiteSpace(formProducto.Descripcion))
                        {
                            MessageBox.Show("El producto debe tener clave y descripción.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        string clave = formProducto.Clave;
                        string descripcion = formProducto.Descripcion;
                        string unidad = formProducto.Unidentrada;
                        decimal precioUnitario = formProducto.PrecioUnitarioTemp;
                        decimal Cantidad = formProducto.cantidad;
                        decimal tasaCambio = 1;
                        decimal subtotal = (precioUnitario * Cantidad);
                        tbl_Cotizacion.Rows.Add(clave, descripcion, unidad, precioUnitario, Cantidad, tasaCambio, subtotal);
                        ActualizarTotales();
                    }
                    // Asegura que la columna de "Eliminar" solo se agregue una vez
                    if (!tbl_Cotizacion.Columns.Contains("Eliminar"))
                    {
                        DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn
                        {
                            Name = "Eliminar",
                            HeaderText = "Acción",
                            Text = "Eliminar",
                            UseColumnTextForButtonValue = true
                        };
                        tbl_Cotizacion.Columns.Add(btnEliminar);
                    }
                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Error en el formato de los valores numéricos: " + fe.Message,
                                "Formato incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (NullReferenceException ne)
            {
                MessageBox.Show("Uno de los valores requeridos no fue proporcionado: " + ne.Message,
                                "Dato faltante", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al agregar el producto:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void tbl_Cotizacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    if (tbl_Cotizacion.Columns[e.ColumnIndex].Name == "Eliminar")
                    {
                        // Confirmar eliminación
                        DialogResult resultado = MessageBox.Show(
                            "¿Deseas eliminar este producto de la cotización?",
                            "Confirmar eliminación",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                        if (resultado == DialogResult.Yes)
                        {
                            tbl_Cotizacion.Rows.RemoveAt(e.RowIndex);
                            ActualizarTotales();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al intentar eliminar el producto:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txt_Costoinstalacion_TextChanged(object sender, EventArgs e)
        {
            ActualizarTotales();
        }
        private void txt_Costoflete_TextChanged(object sender, EventArgs e)
        {
            ActualizarTotales();
        }
        private void ActualizarTotales()
        {
            decimal instalacion = 0;
            decimal flete = 0;
            decimal subtotal = 0;
            decimal descuento = 0;
            try
            {
                // 1. Calcular Subtotal
                subtotal = 0; 
                foreach (DataGridViewRow row in tbl_Cotizacion.Rows)
                {
                    if (row.Cells["Subtotal"].Value != null &&
                        decimal.TryParse(row.Cells["Subtotal"].Value.ToString(), out decimal valor))
                    {
                        subtotal += valor;
                    }
                }
                lbl_Subtotal.Text = $"${subtotal:F2}";
                // 2. Calcular Descuento
                descuento = 0; 
                if (cmb_Descuento.SelectedItem != null)
                {
                    string descuentoTexto = cmb_Descuento.SelectedItem.ToString().Replace("%", "").Trim();
                    if (decimal.TryParse(descuentoTexto, out decimal porcentaje))
                    {
                        descuento = subtotal * (porcentaje / 100m);
                    }
                }
                lbl_costoDescuento.Text = $"-${descuento:F2}";
                // 3. Leer costos adicionales
                instalacion = decimal.TryParse(txt_Costoinstalacion.Text, out var inst) ? inst : 0;
                flete = decimal.TryParse(txt_Costoflete.Text, out var flt) ? flt : 0;
                // 4. Calcular Total Neto
                decimal totalNeto = (subtotal - descuento) + instalacion + flete;
                lbl_TotalNeto.Text = totalNeto.ToString("C");
            }
            catch (Exception ex)
            {
                lbl_TotalNeto.Text = "Error";
                MessageBox.Show($"Se produjo un error al calcular el total: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_Cancelarcotizacion_Click_1(object sender, EventArgs e)
        {
            limpiaCampos();
        }
        private void limpiaCampos()
        {
            txt_Costoflete.Text = string.Empty;
            txt_Costoinstalacion.Text = string.Empty;
            txt_Direccioncliente.Text = string.Empty;
            txt_Nocotizacion.Text = string.Empty;
            txt_Nombrecliente.Text = string.Empty;
            lbl_Subtotal.Text = "$0.00";
            lbl_costoDescuento.Text = "$0.00";
            lbl_TotalNeto.Text = "$0.00";
            tbl_Cotizacion.Rows.Clear();
            cmb_Descuento.SelectedIndex = 0; // Limpiar selección de descuento
        }
        private void txt_Buscarentabla_TextChanged(object sender, EventArgs e)
        {
            BuscarEnGrid(txt_Buscarentabla.Text.Trim());
        }
        private void BuscarEnGrid(string texto)
        {
            // Si el texto está vacío, muestra todas las filas rápidamente
            if (string.IsNullOrWhiteSpace(texto))
            {
                foreach (DataGridViewRow row in tbl_Productos.Rows)
                {
                    if (!row.IsNewRow)
                        row.Visible = true;
                }
                return;
            }

            // Suspende el layout y el enlace de datos para mejorar el rendimiento
            tbl_Productos.SuspendLayout();
            CurrencyManager cm = (CurrencyManager)BindingContext[tbl_Productos.DataSource];
            cm.SuspendBinding();
            string textoBusqueda = texto.ToLower();
            foreach (DataGridViewRow row in tbl_Productos.Rows)
            {
                if (row.IsNewRow) continue;

                bool visible = false;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().IndexOf(textoBusqueda, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        visible = true;
                        break;
                    }
                }
                row.Visible = visible;
            }
            cm.ResumeBinding();
            tbl_Productos.ResumeLayout();
        }
        private void txt_Buscarentabla_MouseEnter(object sender, EventArgs e)
        {
            if (txt_Buscarentabla.Text == "Buscar:")
            {
                txt_Buscarentabla.Text = "";
            }
        }
        private void txt_Buscarentabla_MouseLeave(object sender, EventArgs e)
        {
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var clientesForm = new Form())
                {
                    var clientsControl = new Clients();
                    clientsControl.Dock = DockStyle.Fill;
                    clientesForm.Controls.Add(clientsControl);
                    clientesForm.StartPosition = FormStartPosition.CenterParent;
                    clientesForm.Size = new Size(800, 600);

                    if (clientesForm.ShowDialog() == DialogResult.OK)
                    {
                        // Asegúrate de que no sean nulos antes de asignarlos
                        txt_Nombrecliente.Text = clientsControl.ClienteSeleccionadoNombre ?? "N/A";
                        txt_Direccioncliente.Text = clientsControl.ClienteSeleccionadoCalle ?? "N/A";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al abrir el formulario de clientes:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
