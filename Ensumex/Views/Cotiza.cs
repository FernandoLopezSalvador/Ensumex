using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Office2013.Word;
using DocumentFormat.OpenXml.Wordprocessing;
using Ensumex.Forms;
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
            TablaFormat.AplicarEstilosTabla(tbl_Cotizacion);
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            AgregarDescuentos(new[] { "0%", "5%", "10%", "15%", "20%", "25%", "30" });
            AgregarColumnasCotizacion();
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
                tbl_Cotizacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            // Verifica si la columna "TasaCambio" fue creada exitosamente
            if (tbl_Cotizacion.Columns.Contains("TasaCambio"))
            {
                tbl_Cotizacion.Columns["TasaCambio"].ReadOnly = false; // Permitir edición
            }
            else
            {
                MessageBox.Show("La columna 'TasaCambio' no fue creada correctamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Verifica si la columna "Eliminar" fue creada exitosamente
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
                        tablaCotizacion: tbl_Cotizacion,
                        notas: Txt_observaciones.Text
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
                if (e.RowIndex < 0 || e.RowIndex >= tbl_Cotizacion.Rows.Count) return; // Evitar errores de índice
                if (tbl_Cotizacion.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    // Confirmar eliminación
                    var confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar este producto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        tbl_Cotizacion.Rows.RemoveAt(e.RowIndex);
                        ActualizarTotales();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
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
            Txt_observaciones.Text = "Ingrese notas adicionales .....";
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
        private void materialLabel11_Click(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            using (var productosForm = new Form())
            {
                var productControl = new Product
                {
                    Dock = DockStyle.Fill
                };

                productosForm.Controls.Add(productControl);
                productosForm.StartPosition = FormStartPosition.CenterParent;
                productosForm.Size = new Size(800, 600);
                productosForm.Text = "Seleccionar Producto";
                productControl.ProductoSeleccionado += (clave, descripcion, unidad, precio, cantidad) =>
                {
                    try
                    {
                        decimal tasaCambio = 1;

                        var result = MessageBox.Show(
                            "¿Desea ingresar una tasa de cambio personalizada?",
                            "Tasa de cambio",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (result == DialogResult.Yes)
                        {
                            string input = Microsoft.VisualBasic.Interaction.InputBox(
                                "Ingrese la tasa de cambio:",
                                "Tasa de cambio",
                                "1"
                            );

                            if (!decimal.TryParse(input, out decimal tasaInput) || tasaInput <= 0)
                            {
                                MessageBox.Show("Tasa inválida. Se usará 1 por defecto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                tasaCambio = tasaInput;
                            }
                        }

                        decimal cantidadFinal = 1;
                        var resultCantidad = MessageBox.Show("¿Requiere más de 1 unidad?", "Cantidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (resultCantidad == DialogResult.Yes)
                        {
                            string inputCantidad = Microsoft.VisualBasic.Interaction.InputBox("¿Cuántos requiere?", "Cantidad", "1");

                            if (!decimal.TryParse(inputCantidad, out decimal cantidadInput) || cantidadInput <= 0)
                            {
                                MessageBox.Show("Cantidad inválida. Se usará 1 por defecto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                cantidadFinal = cantidadInput;
                            }
                        }

                        cantidad = cantidadFinal;
                        decimal subtotal = precio * cantidad * tasaCambio;

                        // Verificar si el producto ya está en la tabla
                        foreach (DataGridViewRow row in tbl_Cotizacion.Rows)
                        {
                            if (row.Cells[0].Value?.ToString() == clave)
                            {
                                // Ya existe: sumar cantidades
                                decimal cantidadExistente = Convert.ToDecimal(row.Cells[4].Value);
                                cantidad += cantidadExistente;

                                row.Cells[4].Value = cantidad;
                                row.Cells[6].Value = precio * cantidad * tasaCambio; // Recalcular subtotal
                                ActualizarTotales();
                                productosForm.Close();
                                return;
                            }
                        }

                        // Si no existe, agregar nuevo
                        tbl_Cotizacion.Rows.Add(clave, descripcion, unidad, precio, cantidad, tasaCambio, subtotal);
                        ActualizarTotales();
                        productosForm.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al agregar el producto:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                productosForm.ShowDialog();
            }
        }
        private void Txt_observaciones_MouseEnter(object sender, EventArgs e)
        {
            if (Txt_observaciones.Text == "Ingrese notas adicionales .....")
            {
                Txt_observaciones.Text = "";
            }
        }
        private void tbl_Cotizacion_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && tbl_Cotizacion.Columns[e.ColumnIndex].Name == "TasaCambio")
            {
                var row = tbl_Cotizacion.Rows[e.RowIndex];
                if (decimal.TryParse(row.Cells["PRECIO"].Value?.ToString(), out decimal precio) &&
                    decimal.TryParse(row.Cells["CANTIDAD"].Value?.ToString(), out decimal cantidad) &&
                    decimal.TryParse(row.Cells["TasaCambio"].Value?.ToString(), out decimal tasaCambio))
                {
                    row.Cells["Subtotal"].Value = precio * cantidad * tasaCambio;
                    ActualizarTotales();
                }
            }
        }
    }
}
