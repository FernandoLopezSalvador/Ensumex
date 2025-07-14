using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Office2013.Word;
using DocumentFormat.OpenXml.Wordprocessing;
using Ensumex.Forms;
using Ensumex.Models;
using Ensumex.PDFtemplates;
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
using System.Data.SqlClient;
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
        private readonly string usuarioActual;
        private List<List<object[]>> tablasGuardadas = new();
        private Panel panelBusqueda;
        private DataGridView dgvBusqueda;
        private List<dynamic> productosCache = new(); 

        public Cotiza(string usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            InicializarFormulario();
            InicializarPanelBusqueda();
            CargarProductosCache();
            Txt_Buscar.TextChanged += textBox1_TextChanged;
        }
        private void InicializarFormulario()
        {
            
            AplicarConfiguracionesGenerales();
            ConfigurarControles();
            ConfigurarEventos();
        }

        private void AplicarConfiguracionesGenerales()
        {
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void ConfigurarControles()
        {
            TablaFormat.AplicarEstilosTabla(tbl_Cotizacion);
            AgregarDescuentos(Enumerable.Range(0, 51).Select(i => $"{i}%").ToArray());
            AgregarColumnasCotizacion();
        }

        private void ConfigurarEventos()
        {
            tbl_Cotizacion.CellValueChanged += tbl_Cotizacion_CellValueChanged;
            tbl_Cotizacion.CurrentCellDirtyStateChanged += tbl_Cotizacion_CurrentCellDirtyStateChanged;
            tbl_Cotizacion.CellBeginEdit += tbl_Cotizacion_CellBeginEdit;
            tbl_Cotizacion.ReadOnly = true;
        }
        private void AgregarDescuentos(string[] descuentos)
        {
            cmb_Descuento.Items.AddRange(descuentos);
        }
        private void AgregarColumnasCotizacion()
        {
            try
            {
                string[,] columnas = {
                    { "CLAVE", "Clave" },
                    { "DESCRIPCIÓN", "Descripción" },
                    { "UNIDAD", "Unidad" },
                    { "PRECIO", "Precio" },
                    { "Subtotal", "Subtotal"},
                    {"Total","Total - Descuento" },
                };

                for (int i = 0; i < columnas.GetLength(0); i++)
                {
                    string nombreInterno = columnas[i, 0];
                    string encabezado = columnas[i, 1];
                    if (!tbl_Cotizacion.Columns.Contains(nombreInterno))
                    {
                        tbl_Cotizacion.Columns.Add(nombreInterno, encabezado);
                    }
                }

                if (!tbl_Cotizacion.Columns.Contains("CANTIDAD"))
                {
                    var colCantidad = new DataGridViewComboBoxColumn
                    {
                        Name = "CANTIDAD",
                        HeaderText = "Cantidad",
                        DataSource = Enumerable.Range(1, 100).ToList(), 
                        ValueType = typeof(int),
                        FlatStyle = FlatStyle.Flat
                    };
                    tbl_Cotizacion.Columns.Add(colCantidad);
                }

                if (!tbl_Cotizacion.Columns.Contains("AplicarDescuento"))
                {
                    var colSeleccion = new DataGridViewCheckBoxColumn();
                    colSeleccion.Name = "AplicarDescuento";
                    colSeleccion.HeaderText = "Descuento";
                    colSeleccion.Width = 70;
                    tbl_Cotizacion.Columns.Insert(0, colSeleccion);
                }
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
                tbl_Cotizacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al agregar las columnas de la cotización:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void GuardarCotizacionTablas()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo PDF|*.pdf";
                sfd.FileName = $"CotizacionTablas_{DateTime.Now:yyyyMMdd}.pdf";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // 1. Copia la lista de tablas guardadas
                    var tablasParaGuardar = new List<List<object[]>>(tablasGuardadas);

                    // 2. Agrega la tabla actual si tiene productos
                    List<object[]> tablaActual = new();
                    foreach (DataGridViewRow row in tbl_Cotizacion.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            object[] valores = new object[row.Cells.Count];
                            for (int i = 0; i < row.Cells.Count; i++)
                                valores[i] = row.Cells[i].Value;
                            tablaActual.Add(valores);
                        }
                    }
                    if (tablaActual.Count > 0)
                        tablasParaGuardar.Add(tablaActual);

                    List<string> encabezados = new List<string>();
                    foreach (DataGridViewColumn col in tbl_Cotizacion.Columns)
                        encabezados.Add(col.HeaderText);

                    string descuentoTexto = cmb_Descuento.SelectedItem?.ToString()?.Replace("%", "").Trim() ?? "0";
                    decimal.TryParse(descuentoTexto, out decimal porcentajeDescuento);

                    // --- GUARDAR EN BASE DE DATOS ---
                    CotizacionRepository.GuardarCotizacionTablas(
                        //numeroCotizacion: txt_Nocotizacion.Text,
                        numeroCotizacion: lbl_NoCotiza.Text,
                        fecha: DateTime.Now,
                        nombreCliente: txt_Nombrecliente.Text,
                        numeroCliente: txt_NumeroCliente.Text,
                        costoInstalacion: decimal.TryParse(txt_Costoinstalacion.Text, out var inst) ? inst : 0,
                        costoFlete: decimal.TryParse(txt_Costoflete.Text, out var flt) ? flt : 0,
                        subtotal: decimal.TryParse(lbl_Subtotal.Text.Replace("$", ""), out var sub) ? sub : 0,
                        descuento: decimal.TryParse(lbl_costoDescuento.Text.Replace("$", "").Replace("-", ""), out var desc) ? desc : 0,
                        total: decimal.TryParse(lbl_TotalNeto.Text.Replace("$", ""), out var tot) ? tot : 0,
                        notas: Txt_observaciones.Text,
                        tablas: tablasParaGuardar
                    );

                    // --- GENERAR PDF ---
                    GeneraPDFTablas.GenerarPDFConTablas(
                        rutaArchivo: sfd.FileName,
                        tablas: tablasParaGuardar,
                        encabezados: encabezados,
                        numeroCotizacion: lbl_NoCotiza.Text,
                        nombreCliente: txt_Nombrecliente.Text,
                        costoInstalacion: txt_Costoinstalacion.Text,
                        costoFlete: txt_Costoflete.Text,
                        subtotal: lbl_Subtotal.Text,
                        total: lbl_TotalNeto.Text,
                        descuento: lbl_costoDescuento.Text,
                        porcentajeDescuento: porcentajeDescuento,
                        notas: Txt_observaciones.Text,
                        usuario: usuarioActual
                    );

                    // Preguntar si desea enviar por WhatsApp
                    var enviarWhats = MessageBox.Show("¿Desea enviar la cotización por WhatsApp al cliente?", "Enviar por WhatsApp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (enviarWhats == DialogResult.Yes)
                    {
                        string numeroCliente = txt_NumeroCliente.Text?.Trim();
                        numeroCliente = NormalizarNumeroWhatsApp(numeroCliente);
                        if (string.IsNullOrWhiteSpace(numeroCliente))
                        {
                            numeroCliente = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el número de WhatsApp del cliente (ejemplo: 9511234567):", "WhatsApp", "");
                            numeroCliente = NormalizarNumeroWhatsApp(numeroCliente);
                        }
                        if (!string.IsNullOrWhiteSpace(numeroCliente))
                        {
                            // Abre WhatsApp Web
                            string mensaje = $"Hola, le comparto la cotización {lbl_NoCotiza.Text}. Adjunto el PDF.";
                            EnviarCotizacionPorWhatsApp(numeroCliente, mensaje);
                            // Abre la carpeta del PDF en modo ventana y selecciona el archivo
                            string carpeta = System.IO.Path.GetDirectoryName(sfd.FileName);
                            if (!string.IsNullOrEmpty(carpeta) && System.IO.Directory.Exists(carpeta))
                            {
                                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                                {
                                    FileName = "explorer.exe",
                                    Arguments = $"/select,\"{sfd.FileName}\"",
                                    WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
                                });
                            }
                            MessageBox.Show("Se abrió WhatsApp Web y la carpeta de la cotización. Adjunte el PDF manualmente en el chat.", "WhatsApp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se proporcionó un número válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    tablasGuardadas.Clear();
                    limpiaCampos();
                }
            }
        }
        private void GuardarCotizacion()
        {
            try
            {
                CotizacionRepository.GuardarSiNoExisteCliente(txt_NumeroCliente.Text, txt_Nombrecliente.Text);
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    if (tbl_Cotizacion.Rows.Count == 1)
                    {
                        MessageBox.Show("No hay productos en la cotización.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    sfd.Filter = "Archivo PDF|*.pdf";
                    sfd.FileName = $"Cotizacion_{DateTime.Now:yyyyMMdd}.pdf";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        // GUARDAR EN BASE DE DATOS
                        CotizacionRepository.GuardarCotizacion(
                            numeroCotizacion: lbl_NoCotiza.Text,
                            fecha: DateTime.Now,
                            nombreCliente: txt_Nombrecliente.Text,
                            numeroCliente: txt_NumeroCliente.Text,
                            costoInstalacion: decimal.TryParse(txt_Costoinstalacion.Text, out var inst) ? inst : 0,
                            costoFlete: decimal.TryParse(txt_Costoflete.Text, out var flt) ? flt : 0,
                            subtotal: decimal.TryParse(lbl_Subtotal.Text.Replace("$", ""), out var sub) ? sub : 0,
                            descuento: decimal.TryParse(lbl_costoDescuento.Text.Replace("$", "").Replace("-", ""), out var desc) ? desc : 0,
                            total: decimal.TryParse(lbl_TotalNeto.Text.Replace("$", ""), out var tot) ? tot : 0,
                            notas: Txt_observaciones.Text,
                            tablaCotizacion: tbl_Cotizacion
                        );
                        // GENERAR EL PDF
                        string descuentoTexto = cmb_Descuento.SelectedItem?.ToString()?.Replace("%", "").Trim() ?? "0";
                        decimal.TryParse(descuentoTexto, out decimal porcentajeDescuento);

                        PDFGenerator.GenerarPDFCotizacion(
                            rutaArchivo: sfd.FileName,
                            numeroCotizacion: lbl_NoCotiza.Text,
                            nombreCliente: txt_Nombrecliente.Text,
                            costoInstalacion: txt_Costoinstalacion.Text,
                            costoFlete: txt_Costoflete.Text,
                            subtotal: lbl_Subtotal.Text,
                            total: lbl_TotalNeto.Text,
                            descuento: lbl_costoDescuento.Text,
                            porcentajeDescuento: porcentajeDescuento,
                            notas: Txt_observaciones.Text,
                            tablaCotizacion: tbl_Cotizacion,
                            usuario: usuarioActual
                        );

                        // PREGUNTAR SI DESEA ENVIAR POR WHATSAPP
                        var enviarWhats = MessageBox.Show("¿Desea enviar la cotización por WhatsApp al cliente?", "Enviar por WhatsApp", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (enviarWhats == DialogResult.Yes)
                        {
                            string numeroCliente = txt_NumeroCliente.Text?.Trim();
                            numeroCliente = NormalizarNumeroWhatsApp(numeroCliente);
                            if (string.IsNullOrWhiteSpace(numeroCliente))
                            {
                                numeroCliente = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el número de WhatsApp del cliente (ejemplo: 9511234567):", "WhatsApp", "");
                                numeroCliente = NormalizarNumeroWhatsApp(numeroCliente);
                            }
                            if (!string.IsNullOrWhiteSpace(numeroCliente))
                            {
                                string mensaje = $"Hola, le comparto la cotización {lbl_NoCotiza.Text}. Adjunto el PDF.";
                                EnviarCotizacionPorWhatsApp(numeroCliente, mensaje);

                                string carpeta = System.IO.Path.GetDirectoryName(sfd.FileName);
                                if (!string.IsNullOrEmpty(carpeta) && System.IO.Directory.Exists(carpeta))
                                {
                                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                                    {
                                        FileName = "explorer.exe",
                                        Arguments = $"/select,\"{sfd.FileName}\"",
                                        WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal
                                    });
                                }

                                MessageBox.Show("Se abrió WhatsApp Web y la carpeta de la cotización. Adjunte el PDF manualmente en el chat.", "WhatsApp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No se proporcionó un número válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }

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

            Validarmoneda(sender, e);
        }
        private void Validarmoneda(object sender, KeyPressEventArgs e)
        {
            if (sender is not TextBox txt)
                return;
            if (char.IsControl(e.KeyChar))
                return;
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == '.' && txt.Text.Contains('.'))
            {
                e.Handled = true;
                return;
            }
            if (e.KeyChar == '.' && txt.SelectionStart == 0)
            {
                e.Handled = true;
            }
        }
        private void txt_Costoflete_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validarmoneda(sender, e);
        }
        private void tbl_Cotizacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Evitar errores al hacer clic en encabezados o filas nuevas
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= tbl_Cotizacion.Rows.Count) return;
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
                MessageBox.Show("No existen productos a eliminar.");

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
        // Método para actualizar los totales de la cotización
        private void ActualizarTotales()
        {
            decimal subtotalGeneral = 0;
            decimal totalDescuento = 0;
            decimal instalacion = 0;
            decimal flete = 0;

            try
            {
                // 1️⃣ Extraer el porcentaje del ComboBox
                decimal porcentajeDescuento = 0;
                string descuentoTexto = cmb_Descuento.SelectedItem?.ToString()?.Replace("%", "").Trim() ?? "0";
                decimal.TryParse(descuentoTexto, out porcentajeDescuento);
                porcentajeDescuento /= 100m; // Convierte 10 -> 0.10

                // 2️⃣ Recorre todas las filas para calcular subtotal y descuentos
                foreach (DataGridViewRow row in tbl_Cotizacion.Rows)
                {
                    if (row.IsNewRow) continue;

                    decimal precio = 0, cantidad = 0, subtotalOriginal = 0;
                    bool aplicarDescuento = Convert.ToBoolean(row.Cells["AplicarDescuento"].Value ?? false);

                    // Obtener precio y cantidad
                    decimal.TryParse(row.Cells["PRECIO"].Value?.ToString(), out precio);
                    decimal.TryParse(row.Cells["CANTIDAD"].Value?.ToString(), out cantidad);

                    subtotalOriginal = precio * cantidad;

                    // Suma al subtotal general (total sin descuento)
                    subtotalGeneral += subtotalOriginal;
                    row.Cells["Subtotal"].Value = subtotalOriginal;

                    // Aplica descuento solo si la casilla está marcada
                    if (aplicarDescuento && porcentajeDescuento > 0)
                    {
                        decimal descuentoFila = subtotalOriginal * porcentajeDescuento;
                        totalDescuento += descuentoFila;
                        row.Cells["Total"].Value = subtotalOriginal - descuentoFila;
                    }
                    else
                    {
                        row.Cells["Total"].Value = subtotalOriginal;
                    }
                }
                lbl_Subtotal.Text = subtotalGeneral.ToString("C");                 
                lbl_costoDescuento.Text = $"-{totalDescuento:C}";                 
                decimal.TryParse(txt_Costoinstalacion.Text, out instalacion);
                decimal.TryParse(txt_Costoflete.Text, out flete);
                decimal totalNeto = (subtotalGeneral - totalDescuento) + instalacion + flete;
                lbl_TotalNeto.Text = totalNeto.ToString("C");
            }
            catch (Exception ex)
            {
                lbl_TotalNeto.Text = "Error";
                MessageBox.Show($"Se produjo un error al calcular el total: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void limpiaCampos()
        {
            txt_Costoflete.Text = string.Empty;
            txt_Costoinstalacion.Text = string.Empty;
            txt_NumeroCliente.Text = string.Empty;
            lbl_NoCotiza.Text = string.Empty;
            txt_Nombrecliente.Text = string.Empty;
            lbl_Subtotal.Text = "$0.00";
            lbl_costoDescuento.Text = "$0.00";
            lbl_TotalNeto.Text = "$0.00";
            tbl_Cotizacion.Rows.Clear();
            cmb_Descuento.SelectedIndex = 0;
            Txt_observaciones.Text = string.Empty;
            tbl_Cotizacion.ReadOnly = true;
        }
        // Evento para manejar la busqueda para seleccionar cliente
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var clientesForm = new Form())
                {
                    var clientsControl = new Clients
                    {
                        Dock = DockStyle.Fill,
                        EsLlamadoDesdeCotiza = true // 👈 Aquí indicas que viene de Cotiza
                    };

                    clientesForm.Controls.Add(clientsControl);
                    clientesForm.StartPosition = FormStartPosition.CenterParent;
                    clientesForm.Size = new Size(800, 600);

                    if (clientesForm.ShowDialog() == DialogResult.OK)
                    {
                        txt_Nombrecliente.Text = clientsControl.ClienteSeleccionadoNombre ?? "N/A";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al abrir el formulario de clientes:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void materialButton1_Click(object sender, EventArgs e)
        {
            // Abre el formulario de selección de productos
            using (var productosForm = new Form())
            {
                var productControl = new Product
                {
                    Dock = DockStyle.Fill
                };
                productosForm.Controls.Add(productControl);
                productosForm.StartPosition = FormStartPosition.CenterParent;
                productosForm.WindowState = FormWindowState.Maximized;
                productosForm.Text = "Seleccionar Producto";
                productControl.ProductoSeleccionado += (clave, descripcion, unidad, precio, cantidad) =>
                {
                    // Validar que los datos no sean nulos o vacíos
                    try
                    {
                        decimal precioFinal = precio;
                        int cantidadFinal = 1;
                        cantidad = cantidadFinal;
                        decimal subtotal = precioFinal * cantidad;
                        decimal total = subtotal; 
                        // Verificar si el producto ya está en la tabla
                        foreach (DataGridViewRow row in tbl_Cotizacion.Rows)
                        {
                            if (row.Cells[0].Value?.ToString() == clave)
                            {
                                decimal cantidadExistente = Convert.ToDecimal(row.Cells[8].Value);
                                cantidad += cantidadExistente;
                                row.Cells[8].Value = cantidad;
                                row.Cells[6].Value = precioFinal * cantidad;
                                ActualizarTotales();
                                productosForm.Close();
                                return;
                            }
                        }
                        //tbl_Cotizacion.Rows.Add(false, clave, descripcion, unidad, precioFinal, subtotal, cantidad);
                        tbl_Cotizacion.Rows.Add(false, clave, descripcion, unidad, precio, precio * cantidadFinal, total, cantidadFinal);
                        ActualizarNumeroCotizacionEnLabel();
                        ActualizarTotales();
                        HabilitarEdicionParcial();
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
        private void tbl_Cotizacion_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var colName = tbl_Cotizacion.Columns[e.ColumnIndex].Name;

                // Nombres de columna consistentes
                string colPrecio = "PRECIO";
                string colCantidad = "CANTIDAD";
                string colSubtotal = "Subtotal";
                string colAplicarDescuento = "AplicarDescuento"; // Tu columna de checkbox
                // Siempre actualiza los totales si cambia algo relevante
                if (colName == colAplicarDescuento || colName == colPrecio || colName == colCantidad || colName == colSubtotal)
                {
                    ActualizarTotales();
                }
            }
        }
        private void tbl_Cotizacion_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (tbl_Cotizacion.IsCurrentCellDirty && tbl_Cotizacion.CurrentCell.OwningColumn.Name == "CANTIDAD")
            {
                tbl_Cotizacion.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
            if (tbl_Cotizacion.IsCurrentCellDirty &&
                tbl_Cotizacion.CurrentCell is DataGridViewCheckBoxCell &&
                tbl_Cotizacion.CurrentCell.OwningColumn.Name == "AplicarDescuento")
            {
                tbl_Cotizacion.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void tbl_Cotizacion_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (tbl_Cotizacion.Columns[e.ColumnIndex].Name == "AplicarDescuento")
            {
                // Solo permitir si hay al menos un producto
                int productos = tbl_Cotizacion.Rows.Cast<DataGridViewRow>().Count(r => !r.IsNewRow);
                if (productos == 0)
                {
                    MessageBox.Show("Debe agregar al menos un producto antes de aplicar descuento.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
            }
        }
        private void ValidarYFormatearMoneda_Leave(object sender, EventArgs e)
        {
            if (sender is not TextBox txt)
                return;
            if (string.IsNullOrWhiteSpace(txt.Text))
                return;
            if (decimal.TryParse(txt.Text, out decimal valor))
            {
                // Formatear como moneda sin símbolo
                txt.Text = valor.ToString("N2");
            }
            else
            {
                MessageBox.Show("Por favor ingresa un valor numérico válido.", "Formato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt.Focus();
                txt.SelectAll();
            }
        }
        private void txt_Costoinstalacion_Leave(object sender, EventArgs e)
        {
            ValidarYFormatearMoneda_Leave(sender, e);
        }
        private void txt_Costoflete_Leave(object sender, EventArgs e)
        {
            ValidarYFormatearMoneda_Leave(sender, e);
        }
        private void EnviarCotizacionPorWhatsApp(string numeroCliente, string mensaje)
        {
            try
            {
                string url = $"https://wa.me/{numeroCliente}?text={Uri.EscapeDataString(mensaje)}";
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = url,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir WhatsApp Web: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string NormalizarNumeroWhatsApp(string numero)
        {
            // Elimina espacios y guiones
            numero = numero.Replace(" ", "").Replace("-", "");
            // Si ya tiene el prefijo internacional, lo deja igual
            if (numero.StartsWith("521") && numero.Length == 13)
                return numero;
            if (numero.StartsWith("52") && numero.Length == 12)
                return numero;
            // Si es celular (10 dígitos), antepone 521
            if (numero.Length == 10 && numero.StartsWith("9"))
                return "521" + numero;
            // Si es fijo (10 dígitos), antepone 52
            if (numero.Length == 10)
                return "52" + numero;
            // Si no cumple, regresa vacío
            return "";
        }
        private void txt_NumeroCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo dígitos y teclas de control (como Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void AgrgarTabla_Click(object sender, EventArgs e)
        {
            // Guarda toda la tabla actual
            List<object[]> tablaActual = new();
            foreach (DataGridViewRow row in tbl_Cotizacion.Rows)
            {
                if (!row.IsNewRow)
                {
                    object[] valores = new object[row.Cells.Count];
                    for (int i = 0; i < row.Cells.Count; i++)
                        valores[i] = row.Cells[i].Value;
                    tablaActual.Add(valores);
                }
            }
            if (tablaActual.Count > 0)
            {
                tablasGuardadas.Add(tablaActual);
                tbl_Cotizacion.Rows.Clear(); 
                MessageBox.Show("Tabla guardada y lista para capturar una nueva.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No hay productos para guardar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ActualizarNumeroCotizacionEnLabel()
        {
            if (tbl_Cotizacion.Rows.Count == 0)
            {
                lbl_NoCotiza.Text = "";
                return;
            }

            // Busca el último producto agregado (última fila no nueva)
            DataGridViewRow ultimaFila = null;
            for (int i = tbl_Cotizacion.Rows.Count - 1; i >= 0; i--)
            {
                if (!tbl_Cotizacion.Rows[i].IsNewRow)
                {
                    ultimaFila = tbl_Cotizacion.Rows[i];
                    break;
                }
            }
            if (ultimaFila == null)
            {
                lbl_NoCotiza.Text = "";
                return;
            }

            string descripcion = ultimaFila.Cells["DESCRIPCIÓN"].Value?.ToString()?.ToUpper() ?? "";
            string prefijo = "";

            if (descripcion.Contains("CALENT"))
                prefijo = "CAL";
            else if (descripcion.Contains("AIRE"))
                prefijo = "AIE";
            else if ((descripcion.Contains("BOMBA DE") || descripcion.Contains("BOMBA TIPO")) && !descripcion.Contains("MOT"))
                prefijo = "BOM";
            else if (descripcion.Contains("MOTOBOMBA") || descripcion.Contains("MOTB") || descripcion.Contains("MOT."))
                prefijo = "MOTB";
            else if (descripcion.Contains("MANTENIMIENTO") || descripcion.Contains("SERVICIO DE MANTENIM"))
                prefijo = "MAN";

            // Tomar la fecha del label lblFecha (formato dd/MM/yyyy)
            string fecha = lblFecha.Text.Replace("/", "");

            // Obtener siguiente IdCotizacion desde la base de datos
            int siguienteIdCotizacion = CotizacionRepository.GetSiguienteIdCotizacion();

            // Armar número de cotización
            if (!string.IsNullOrWhiteSpace(prefijo))
                lbl_NoCotiza.Text = $"{prefijo}{fecha}{siguienteIdCotizacion}";
            else
                lbl_NoCotiza.Text = $"{fecha}{siguienteIdCotizacion}";
        }

        private void lbl_NoCotiza_Click(object sender, EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string texto = Txt_Buscar.Text.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(texto))
            {
                panelBusqueda.Visible = false;
                return;
            }
            var resultados = productosCache
                .Where(p =>
                    p.CLAVE.ToLower().Contains(texto) ||
                    p.DESCRIPCIÓN.ToLower().Contains(texto))
                .ToList();

            if (resultados.Any())
            {
                dgvBusqueda.DataSource = resultados;
                panelBusqueda.Visible = true;
                panelBusqueda.BringToFront();
            }
            else
            {
                panelBusqueda.Visible = false;
            }
        }
        private void InicializarPanelBusqueda()
        {
            panelBusqueda = new Panel
            {
                Visible = false,
                BorderStyle = BorderStyle.FixedSingle,
                Width = 600,
                Height = 280
            };

            dgvBusqueda = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false
            };
            // Aplica el mismo estilo que a las otras tablas
            TablaFormat.AplicarEstilosTabla(dgvBusqueda);
            panelBusqueda.Controls.Add(dgvBusqueda);
            this.Controls.Add(panelBusqueda);
            // Posiciona el panel justo debajo del Txt_Buscar
            panelBusqueda.Location = new Point(Txt_Buscar.Left, Txt_Buscar.Bottom + 2);
            dgvBusqueda.CellDoubleClick += DgvBusqueda_CellDoubleClick;
            // Opcional: Oculta el panel si pierde el foco
            dgvBusqueda.LostFocus += (s, e) => panelBusqueda.Visible = false;
            Txt_Buscar.LostFocus += (s, e) => { if (!panelBusqueda.Focused && !dgvBusqueda.Focused) panelBusqueda.Visible = false; };
        }
        private void CargarProductosCache()
        {
            // Puedes obtener los productos desde tu servicio o base de datos
            var productoService = new ProductoServices1();
            var productos = productoService.ObtenerProductos(); // null para traer todos
            productosCache = productos.Select(p => new
            {
                CLAVE = p.CVE_ART ?? "N/A",
                DESCRIPCIÓN = p.DESCR ?? "N/A",
                UNIDAD = p.UNI_MED ?? "N/A" ,
                PRECIO = p.PRECIO != 0 ? (p.PRECIO * 1.16m).ToString("C2") : "$0.00" 
            }).ToList<dynamic>();
        }
            
        private void DgvBusqueda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvBusqueda.Rows[e.RowIndex];
                string clave = row.Cells["CLAVE"].Value?.ToString();
                string descripcion = row.Cells["DESCRIPCIÓN"].Value?.ToString();
                decimal precio = Convert.ToDecimal(row.Cells["PRECIO"].Value?.ToString().Replace("$", "").Trim() ?? "0");
                int cantidad = 1;
                string unidad = row.Cells["UNIDAD"].Value?.ToString();
                decimal total = precio * cantidad;
                tbl_Cotizacion.Rows.Add(false, clave, descripcion, unidad, precio, precio * cantidad,total, cantidad);
                ActualizarNumeroCotizacionEnLabel();
                ActualizarTotales();
                HabilitarEdicionParcial();
                panelBusqueda.Visible = false;
                Txt_Buscar.Clear();
                int lastRow = tbl_Cotizacion.Rows.Count - 1;
                tbl_Cotizacion.CurrentCell = tbl_Cotizacion.Rows[lastRow].Cells["CANTIDAD"];
                tbl_Cotizacion.BeginEdit(true);
            }
        }
        private void HabilitarEdicionParcial()
        {
            tbl_Cotizacion.ReadOnly = false;
            foreach (DataGridViewColumn col in tbl_Cotizacion.Columns)
            {
                col.ReadOnly = !(col.Name == "PRECIO" || col.Name == "AplicarDescuento"|| col.Name== "CANTIDAD");
            }
        }

        private void btn_Cancelarcotizacion_Click(object sender, EventArgs e)
        {
            limpiaCampos();
        }
        private void Btn_guardarCotizacion_Click_1(object sender, EventArgs e)
        {
            // Si hay una o más de una tabla guardada y tambien una cotizacion en tabla
            if (tablasGuardadas.Count > 0 && tbl_Cotizacion.Rows.Count > 1)
            {
                GuardarCotizacionTablas();
            }
            else if (tbl_Cotizacion.Rows.Count > 1 && tablasGuardadas.Count == 0)
            {
                GuardarCotizacion();
            }
        }
        private void btn_AgregarProducto_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Crear el formulario contenedor
                using (Form formWrapper = new Form())
                {
                    formWrapper.Text = "Agregar Producto";
                    formWrapper.Size = new Size(400, 300); // Ajusta el tamaño según tu UserControl
                    formWrapper.StartPosition = FormStartPosition.CenterParent;

                    // Crear instancia del UserControl
                    var prodControl = new ProdTemporal
                    {
                        Dock = DockStyle.Fill
                    };
                    // Botón para aceptar
                    Button btnAceptar = new Button
                    {
                        Text = "Aceptar",
                        Dock = DockStyle.Bottom,
                        DialogResult = DialogResult.OK
                    };
                    // Botón para cancelar
                    Button btnCancelar = new Button
                    {
                        Text = "Cancelar",
                        Dock = DockStyle.Bottom,
                        DialogResult = DialogResult.Cancel
                    };
                    // Agregar controles al formulario
                    formWrapper.Controls.Add(prodControl);
                    formWrapper.Controls.Add(btnAceptar);
                    formWrapper.Controls.Add(btnCancelar);
                    formWrapper.AcceptButton = btnAceptar;
                    formWrapper.CancelButton = btnCancelar;

                    // Mostrar formulario como modal
                    if (formWrapper.ShowDialog() == DialogResult.OK)
                    {
                        // Validación de datos
                        if (string.IsNullOrWhiteSpace(prodControl.Clave) || string.IsNullOrWhiteSpace(prodControl.Descripcion))
                        {
                            MessageBox.Show("El producto debe tener clave y descripción.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        string clave = prodControl.Clave;
                        string descripcion = prodControl.Descripcion;
                        string unidad = prodControl.Unidentrada;
                        decimal precioUnitario = prodControl.PrecioUnitarioTemp;
                        int cantidad = (int)prodControl.cantidad;
                        decimal subtotal = precioUnitario * cantidad;
                        decimal total = subtotal; // Aquí puedes aplicar lógica de descuento si es necesario

                        tbl_Cotizacion.Rows.Add(false, clave, descripcion, unidad, precioUnitario, subtotal,total, cantidad);
                        ActualizarNumeroCotizacionEnLabel();
                        ActualizarTotales();
                        HabilitarEdicionParcial();

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
            }
            //Manejo de excepciones para errores comunes
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
    }
}