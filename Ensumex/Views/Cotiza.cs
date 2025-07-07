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

        public Cotiza(string usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;

            InicializarFormulario();
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
            AgregarDescuentos(Enumerable.Range(0, 11).Select(i => $"{i * 5}%").ToArray());
            AgregarColumnasCotizacion();
        }

        private void ConfigurarEventos()
        {
            tbl_Cotizacion.CellValueChanged += tbl_Cotizacion_CellValueChanged;
            tbl_Cotizacion.CurrentCellDirtyStateChanged += tbl_Cotizacion_CurrentCellDirtyStateChanged;
            tbl_Cotizacion.CellBeginEdit += tbl_Cotizacion_CellBeginEdit;
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
                    { "PRECIO", "precio" },
                    { "CANTIDAD", "Cantidad" },
                    { "TasaCambio", "Tasa Cambio" },
                    { "Subtotal", "Subtotal" }
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

                if (!tbl_Cotizacion.Columns.Contains("AplicarDescuento"))
                {
                    var colSeleccion = new DataGridViewCheckBoxColumn();
                    colSeleccion.Name = "AplicarDescuento";
                    colSeleccion.HeaderText = "Descuento";
                    colSeleccion.Width = 70;
                    tbl_Cotizacion.Columns.Insert(0, colSeleccion);
                }

                if (tbl_Cotizacion.Columns.Contains("TasaCambio"))
                {
                    tbl_Cotizacion.Columns["TasaCambio"].ReadOnly = false;
                }
                else
                {
                    MessageBox.Show("La columna 'TasaCambio' no fue creada correctamente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        /// Evento para manejar el botón de guardar cotización
        private void Btn_guardarCotizacion_Click(object sender, EventArgs e)
        {
            // Si hay una o más de una tabla guardada y tambien una cotizacion en tabla
            if (tablasGuardadas.Count > 0 && tbl_Cotizacion.Rows.Count > 1)
            {
                GuardarCotizacionTablas();
            }
            else if (tbl_Cotizacion.Rows.Count > 1 && tablasGuardadas.Count == 0)
            {
                // Si hay una tabla, guarda la cotización normal
                GuardarCotizacion();
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
                        //numeroCotizacion: txt_Nocotizacion.Text,
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
                    tablasGuardadas.Clear(); // Limpia la lista después de guardar
                    limpiaCampos();
                }
            }
        }
        private void GuardarCotizacion()
        {
            try
            {
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
                            tablaCotizacion: tbl_Cotizacion
                        );
                        // Generar el PDF
                        string descuentoTexto = cmb_Descuento.SelectedItem?.ToString()?.Replace("%", "").Trim() ?? "0";
                        decimal.TryParse(descuentoTexto, out decimal porcentajeDescuento);

                        PDFGenerator.GenerarPDFCotizacion(
                            rutaArchivo: sfd.FileName,
                            //numeroCotizacion: txt_Nocotizacion.Text,
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
        // Evento para manejar el botón de agregar producto
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
                        // --- Fin del código para generar y mostrar el número de cotización automático ---

                        tbl_Cotizacion.Rows.Add(false, clave, descripcion, unidad, precioUnitario, Cantidad, tasaCambio, subtotal);
                        ActualizarNumeroCotizacionEnLabel();
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
        // Método para actualizar los totales de la cotización
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
                    if (row.IsNewRow) continue;
                    if (row.Cells["Subtotal"].Value != null &&
                        decimal.TryParse(row.Cells["Subtotal"].Value.ToString(), out decimal valor))
                    {
                        subtotal += valor;
                    }
                }
                lbl_Subtotal.Text = $"${subtotal:F2}";
                // 2. Calcular Descuento solo en productos seleccionados
                descuento = 0;
                // Extraer el porcentaje del ComboBox
                string descuentoTexto = cmb_Descuento.SelectedItem?.ToString()?.Replace("%", "").Trim() ?? "0";
                decimal.TryParse(descuentoTexto, out decimal porcentajeDescuento);

                if (porcentajeDescuento > 0)
                {
                    foreach (DataGridViewRow row in tbl_Cotizacion.Rows)
                    {
                        if (row.IsNewRow) continue;
                        bool aplicar = row.Cells["AplicarDescuento"].Value is bool b && b;
                        if (aplicar && row.Cells["Subtotal"].Value != null &&
                            decimal.TryParse(row.Cells["Subtotal"].Value.ToString(), out decimal valor))
                        {
                            descuento += valor * (porcentajeDescuento / 100m);
                        }
                    }
                }
                // 3. Actualizar etiquetas de totales
                lbl_costoDescuento.Text = $"-${descuento:F2}";
                instalacion = decimal.TryParse(txt_Costoinstalacion.Text, out var inst) ? inst : 0;
                flete = decimal.TryParse(txt_Costoflete.Text, out var flt) ? flt : 0;
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
            txt_NumeroCliente.Text = string.Empty;
            lbl_NoCotiza.Text = string.Empty;
            txt_Nombrecliente.Text = string.Empty;
            txt_Bases.Text = string.Empty;
            lbl_Subtotal.Text = "$0.00";
            lbl_costoDescuento.Text = "$0.00";
            lbl_TotalNeto.Text = "$0.00";
            tbl_Cotizacion.Rows.Clear();
            cmb_Descuento.SelectedIndex = 0;
            Txt_observaciones.Text = string.Empty;
        }
        // Evento para manejar la busqueda para seleccionar cliente
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
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones al abrir el formulario de clientes
                MessageBox.Show("Ocurrió un error al abrir el formulario de clientes:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void materialLabel11_Click(object sender, EventArgs e)
        {
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
                //pantalla completa del formulario
                productosForm.WindowState = FormWindowState.Maximized;
                productosForm.Text = "Seleccionar Producto";
                productControl.ProductoSeleccionado += (clave, descripcion, unidad, precio, cantidad) =>
                {
                    // Validar que los datos no sean nulos o vacíos
                    try
                    {
                        decimal precioFinal = precio;
                        var result = MessageBox.Show(
                            "¿Desea cambiar el precio del producto?",
                            "Modificar precio",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );
                        if (result == DialogResult.Yes)
                        {
                            string input = Microsoft.VisualBasic.Interaction.InputBox(
                                "Ingrese el nuevo precio:",
                                "Modificar precio",
                                precio.ToString("0.00")
                            );
                            if (!decimal.TryParse(input, out decimal precioInput) || precioInput <= 0)
                            {
                                MessageBox.Show("Precio inválido. Se usará el precio original.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                precioFinal = precioInput;
                            }
                        }

                        decimal tasaCambio = 1;
                        var resultTasa = MessageBox.Show(
                            "¿Desea ingresar una tasa de cambio personalizada?",
                            "Tasa de cambio",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );
                        if (resultTasa == DialogResult.Yes)
                        {
                            string inputTasa = Microsoft.VisualBasic.Interaction.InputBox(
                                "Ingrese la tasa de cambio:",
                                "Tasa de cambio",
                                "1"
                            );
                            if (!decimal.TryParse(inputTasa, out decimal tasaInput) || tasaInput <= 0)
                            {
                                MessageBox.Show("Tasa inválida. Se usará 1 por defecto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else
                            {
                                tasaCambio = tasaInput;
                            }
                        }
                        // Validar la cantidad que desesea agregar
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
                        decimal subtotal = precioFinal * cantidad * tasaCambio;
                        // Verificar si el producto ya está en la tabla
                        foreach (DataGridViewRow row in tbl_Cotizacion.Rows)
                        {
                            if (row.Cells[0].Value?.ToString() == clave)
                            {
                                decimal cantidadExistente = Convert.ToDecimal(row.Cells[4].Value);
                                cantidad += cantidadExistente;
                                row.Cells[4].Value = cantidad;
                                row.Cells[6].Value = precioFinal * cantidad * tasaCambio;
                                ActualizarTotales();
                                productosForm.Close();
                                return;
                            }
                        }
                        tbl_Cotizacion.Rows.Add(false, clave, descripcion, unidad, precioFinal, cantidad, tasaCambio, subtotal);
                        ActualizarNumeroCotizacionEnLabel();
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
        private void tbl_Cotizacion_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que la fila sea válida y no sea la fila nueva
            if (e.RowIndex >= 0)
            {
                var colName = tbl_Cotizacion.Columns[e.ColumnIndex].Name;
                if (colName == "AplicarDescuento" || colName == "TasaCambio")
                {
                    ActualizarTotales();
                }
            }
        }
        private void tbl_Cotizacion_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
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

            // Si está vacío, no hacer nada
            if (string.IsNullOrWhiteSpace(txt.Text))
                return;

            // Validar que el texto sea un decimal válido
            if (decimal.TryParse(txt.Text, out decimal valor))
            {
                // Formatear como moneda sin símbolo
                txt.Text = valor.ToString("N2"); // "1,234.56"
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
            ValidarYFormatearMoneda_Leave(sender, e); // Llama al método para validar y formatear
        }
        private void txt_Costoflete_Leave(object sender, EventArgs e)
        {
            ValidarYFormatearMoneda_Leave(sender, e); // Llama al método para validar y formatear
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
                tbl_Cotizacion.Rows.Clear(); // Limpia la tabla para la siguiente
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
                prefijo = "C";
            else if (descripcion.Contains("AIRE"))
                prefijo = "A";
            else if ((descripcion.Contains("BOMBA DE") || descripcion.Contains("BOMBA TIPO")) && !descripcion.Contains("MOT"))
                prefijo = "B";
            else if (descripcion.Contains("MOTOBOMBA") || descripcion.Contains("MOTB") || descripcion.Contains("MOT."))
                prefijo = "MB";
            else if (descripcion.Contains("MANTENIMIENTO") || descripcion.Contains("SERVICIO DE MANTENIM"))
                prefijo = "M";

            // Tomar la fecha del label lblFecha (formato dd/MM/yyyy)
            string fecha = lblFecha.Text.Replace("/", ""); // Ejemplo: "03072025"

            lbl_NoCotiza.Text = !string.IsNullOrWhiteSpace(prefijo) ? prefijo + fecha : fecha;
        }

        private void lbl_NoCotiza_Click(object sender, EventArgs e)
        {

        }
    }
}