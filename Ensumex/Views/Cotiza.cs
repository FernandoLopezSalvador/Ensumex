using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Office2013.Word;
using DocumentFormat.OpenXml.Wordprocessing;
using Ensumex.Clases;
using Ensumex.Forms;
using Ensumex.Models;
using Ensumex.PDFtemplates;
using Ensumex.Services;
using Ensumex.Utils;
using FontAwesome.Sharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MaterialSkin;
using Microsoft.VisualBasic;
using OfficeOpenXml.Drawing.Chart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = System.Drawing.Color;
using Font = System.Drawing.Font;

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
            InicializarTabla();
            ConfigurarBotones();
            InicializarPanelBusqueda();
            CargarProductosCache();
        }
        private void InicializarTabla()
        {
            tbl_Cotizacion.AllowUserToAddRows = true; 
            tbl_Cotizacion.CellBeginEdit += tbl_Cotizacion_CellBeginEdit;
        }
        private void InicializarFormulario()
        {
            AgregarColumnasCotizacion();
            AplicarConfiguracionesGenerales();
            ConfigurarControles();
            ConfigurarEventos();
        }

        private void AplicarConfiguracionesGenerales()
        {

            Txt_Buscar.TextChanged += textBox1_TextChanged;
            Txt_observaciones.Multiline = true;
            Txt_observaciones.ScrollBars = ScrollBars.Vertical;
            Txt_observaciones.WordWrap = true;
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");    
            
        }

        private void ConfigurarControles()
        {
            TablaFormat.AplicarEstilosTabla(tbl_Cotizacion);
        }

        private void ConfigurarEventos()
        {
            tbl_Cotizacion.CellValueChanged += tbl_Cotizacion_CellValueChanged;
            tbl_Cotizacion.CurrentCellDirtyStateChanged += tbl_Cotizacion_CurrentCellDirtyStateChanged;
            tbl_Cotizacion.CellBeginEdit += tbl_Cotizacion_CellBeginEdit;
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

                if (!tbl_Cotizacion.Columns.Contains("Descuento"))
                {
                    var colDescuento = new DataGridViewComboBoxColumn
                    {
                        Name = "Descuento",
                        HeaderText = "Descuento (%)",
                        DataSource = Enumerable.Range(0, 51).ToList(), // Valores de 0 a 50
                        ValueType = typeof(int),
                        FlatStyle = FlatStyle.Flat,
                        Width = 80
                    };
                    tbl_Cotizacion.Columns.Insert(0, colDescuento);
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
                sfd.FileName = $"{lbl_NoCotiza.Text}_{DateTime.Now:yyyyMMdd}.pdf"; 
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

                    // --- GUARDAR EN BASE DE DATOS ---
                    CotizacionRepository.GuardarCotizacionTablas(
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
                    // Abrir el PDF generado
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = sfd.FileName,
                        UseShellExecute = true
                    });
                }
            }
        }
        private void GuardarCotizacion()
        {
            try
            {
                // Guardar cliente si no existe
                CotizacionRepository.GuardarSiNoExisteCliente(txt_NumeroCliente.Text, txt_Nombrecliente.Text);
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    if (tbl_Cotizacion.Rows.Count <= 1)
                    {
                        MessageBox.Show("No hay productos en la cotización.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    sfd.Filter = "Archivo PDF|*.pdf";
                    sfd.FileName = $"{lbl_NoCotiza.Text}_{DateTime.Now:yyyyMMdd}.pdf";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        decimal totalDescuentoCalculado = 0m;

                        // Calcular descuento total de la cotización
                        foreach (DataGridViewRow row in tbl_Cotizacion.Rows)
                        {
                            if (row.IsNewRow) continue;
                            decimal precio = 0m, cantidad = 0m;
                            int porcentajeDescuento = 0;
                            decimal.TryParse(row.Cells["PRECIO"]?.Value?.ToString(), out precio);
                            decimal.TryParse(row.Cells["CANTIDAD"]?.Value?.ToString(), out cantidad);
                            int.TryParse(row.Cells["Descuento"]?.Value?.ToString(), out porcentajeDescuento);
                            decimal descuentoFila = (precio * cantidad) * (porcentajeDescuento / 100m);
                            totalDescuentoCalculado += descuentoFila;
                        }

                        // Guardar cotización en base de datos
                        CotizacionRepository.GuardarCotizacion(
                            numeroCotizacion: lbl_NoCotiza.Text,
                            fecha: DateTime.Now,
                            nombreCliente: txt_Nombrecliente.Text,
                            numeroCliente: txt_NumeroCliente.Text,
                            costoInstalacion: decimal.TryParse(txt_Costoinstalacion.Text, out var inst) ? inst : 0,
                            costoFlete: decimal.TryParse(txt_Costoflete.Text, out var flt) ? flt : 0,
                            subtotal: decimal.TryParse(lbl_Subtotal.Text.Replace("$", ""), out var sub) ? sub : 0,
                            descuento: totalDescuentoCalculado, // Descuento calculado
                            total: decimal.TryParse(lbl_TotalNeto.Text.Replace("$", ""), out var tot) ? tot : 0,
                            notas: Txt_observaciones.Text,
                            tablaCotizacion: tbl_Cotizacion
                        );

                        // Generar PDF
                        PDFGenerator.GenerarPDFCotizacion(
                            rutaArchivo: sfd.FileName,
                            numeroCotizacion: lbl_NoCotiza.Text,
                            nombreCliente: txt_Nombrecliente.Text,
                            costoInstalacion: txt_Costoinstalacion.Text,
                            costoFlete: txt_Costoflete.Text,
                            subtotal: lbl_Subtotal.Text.Replace("$", "").Trim(),   // O mejor decimal
                            total: lbl_TotalNeto.Text.Replace("$", "").Trim(),     // Igual aquí
                            descuento: lbl_costoDescuento.Text.Replace("$", "").Trim(),
                            porcentajeDescuento: totalDescuentoCalculado,
                            notas: Txt_observaciones.Text,
                            tablaCotizacion: tbl_Cotizacion,
                            usuario: usuarioActual
                        );

                        // Preguntar si quiere enviar por WhatsApp
                        if (MessageBox.Show("¿Desea enviar la cotización por WhatsApp al cliente?", "Enviar por WhatsApp", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            string numeroCliente = NormalizarNumeroWhatsApp(txt_NumeroCliente.Text);
                            if (string.IsNullOrWhiteSpace(numeroCliente))
                            {
                                numeroCliente = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el número de WhatsApp del cliente (ejemplo: 9511234567):", "WhatsApp", "");
                                numeroCliente = NormalizarNumeroWhatsApp(numeroCliente);
                            }
                            if (!string.IsNullOrWhiteSpace(numeroCliente))
                            {
                                string mensaje = $"Hola, le comparto la cotización {lbl_NoCotiza.Text}. Adjunto el PDF.";
                                EnviarCotizacionPorWhatsApp(numeroCliente, mensaje);

                                // Abrir carpeta donde se guardó el PDF
                                string carpeta = Path.GetDirectoryName(sfd.FileName);
                                if (!string.IsNullOrEmpty(carpeta) && Directory.Exists(carpeta))
                                {
                                    Process.Start(new ProcessStartInfo
                                    {
                                        FileName = "explorer.exe",
                                        Arguments = $"/select,\"{sfd.FileName}\"",
                                        WindowStyle = ProcessWindowStyle.Normal
                                    });
                                }

                                MessageBox.Show("Se abrió WhatsApp Web y la carpeta de la cotización. Adjunte el PDF manualmente en el chat.", "WhatsApp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No se proporcionó un número válido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }

                        // Abrir el PDF generado
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = sfd.FileName,
                            UseShellExecute = true
                        });
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
                foreach (DataGridViewRow row in tbl_Cotizacion.Rows)
                {
                    if (row.IsNewRow) continue;

                    decimal precio = 0, cantidad = 0, subtotalOriginal = 0;

                    // Obtener precio y cantidad
                    decimal.TryParse(row.Cells["PRECIO"].Value?.ToString(), out precio);
                    decimal.TryParse(row.Cells["CANTIDAD"].Value?.ToString(), out cantidad);
                    subtotalOriginal = precio * cantidad;
                    // Suma al subtotal general (total sin descuento)
                    subtotalGeneral += subtotalOriginal;
                    row.Cells["Subtotal"].Value = subtotalOriginal;
                    // Obtener porcentaje de descuento del ComboBox
                    int porcentajeDescuento = 0;
                    int.TryParse(row.Cells["Descuento"].Value?.ToString(), out porcentajeDescuento);

                    if (porcentajeDescuento > 0)
                    {
                        decimal descuentoFila = subtotalOriginal * (porcentajeDescuento / 100m);
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
            Txt_observaciones.Text = string.Empty;
            tbl_Cotizacion.ReadOnly = true;
            tablasGuardadas.Clear();
            ActualizarNumeroCotizacionEnLabel(); // <-- Añade esta línea
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
                        EsLlamadoDesdeCotiza = true
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

        private void ActualizarObservacionesPorProducto(string descripcion, bool reemplazar = true)
        {
            var notas = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["CALENTADOR"] = "-Garantía: 5 años contra defectos de fabricación. Solo para el termo tanque...\n" +
                "-Precios sujetos a cambios sin previo aviso.\n",
                ["CALENT"] = "-Garantía: 5 años contra defectos de fabricación. Solo para el termo tanque...\n" +
                "-Precios sujetos a cambios sin previo aviso.\n",

                ["AIRE ACONDICIONADO"] = "-Garantía: 5 años contra defectos de fabricación.\n" +
                    "-El Aire Acondicionado lo puede pagar a 6 MSI con tarjetas BBVA pero sería precio sin descuento.\n" +
                    "-Precios sujetos a cambios sin previo aviso.\n",

                ["MOTOBOMBA"] = "-Garantía: 1 año contra defectos de fabricación.\n" +
                    "-Equipos sobre pedido, es necesario el 60% de anticipo. Entrega de 5 a 10 días hábiles.\n" +
                    "-Precios sujetos a cambios sin previo aviso.\n",

                ["MOT:BOMB"] = "-Garantía: 1 año contra defectos de fabricación.\n" +
                    "-Equipos sobre pedido, es necesario el 60% de anticipo. Entrega de 5 a 10 días hábiles.\n" +
                    "-Precios sujetos a cambios sin previo aviso.\n",

                ["BOMBA"] = "-Garantía: 2 años en bomba motor y arrancador.\n" +
                    "-Equipos sobre pedido. Es necesario un anticipo del 60%.\n" +
                    "-Entrega de 3 a 5 días hábiles.\n" +
                    "-Precios sujetos a cambios sin previo aviso.\n",

                ["MANTENIMIENTO"] = "-Mantenimiento correctivo de unidad tipo paquete incluye:\nLocalización de fugas, vacío del sistema de refrigeración y recarga de gas refrigerante.\n" +
                    "Mantenimiento preventivo de unidad tipo paquete incluye:\n" +
                    "Limpieza de serpentín evaporador y condensador, turbinas de la unidad y carcasas de la misma.\n" +
                    "Limpieza de la charola de condensados.\n" +
                    "Limpieza y lavado de filtros de aire del retorno de la unidad evaporadora.\n" +
                    "Ajuste de banda de turbina del evaporador.\n" +
                    "Engrasado de chumaceras.\n" +
                    "Revisión y ajuste de terminales eléctricas.\n" +
                    "Revisión y ajuste de la carga de gas refrigerante.\n" +
                    "-Se requiere anticipo del 50% para comenzar el trabajo.\n" +
                    "-Los trabajos tardan de 3 a 4 días en quedar terminados.\n" +
                    "-Precios sujetos a cambios sin previo aviso.\n",

                ["MANTEMIN"] = "-Mantenimiento correctivo de unidad tipo paquete incluye:\nLocalización de fugas, vacío del sistema de refrigeración y recarga de gas refrigerante.\n" +
                    "Mantenimiento preventivo de unidad tipo paquete incluye:\n" +
                    "Limpieza de serpentín evaporador y condensador, turbinas de la unidad y carcasas de la misma.\n" +
                    "Limpieza de la charola de condensados.\n" +
                    "Limpieza y lavado de filtros de aire del retorno de la unidad evaporadora.\n" +
                    "Ajuste de banda de turbina del evaporador.\n" +
                    "Engrasado de chumaceras.\n" +
                    "Revisión y ajuste de terminales eléctricas.\n" +
                    "Revisión y ajuste de la carga de gas refrigerante.\n" +
                    "-Se requiere anticipo del 50% para comenzar el trabajo.\n" +
                    "-Los trabajos tardan de 3 a 4 días en quedar terminados.\n" +
                    "-Precios sujetos a cambios sin previo aviso.\n"
            };
            foreach (var nota in notas)
            {
                if (descripcion.IndexOf(nota.Key, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    if (reemplazar)
                    {
                        // Reemplaza todo el texto anterior
                        Txt_observaciones.Text = nota.Value;
                    }
                    else if (!Txt_observaciones.Text.Contains(nota.Value))
                    {
                        // Concatena solo si la nota aún no está
                        Txt_observaciones.Text += "\n" + nota.Value;
                    }
                    return; // Termina en cuanto encuentra una coincidencia
                }
            }
        }
        private void tbl_Cotizacion_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var colName = tbl_Cotizacion.Columns[e.ColumnIndex].Name;

                string colPrecio = "PRECIO";
                string colCantidad = "CANTIDAD";
                string colSubtotal = "Subtotal";
                string colDescuento = "Descuento";

                if (colName == colDescuento || colName == colPrecio || colName == colCantidad || colName == colSubtotal)
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
            tbl_Cotizacion.CurrentCell is DataGridViewComboBoxCell &&
            tbl_Cotizacion.CurrentCell.OwningColumn.Name == "Descuento")
            {
                tbl_Cotizacion.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
        private void tbl_Cotizacion_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (tbl_Cotizacion.Columns[e.ColumnIndex].Name == "Descuento")
            {
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
            if (numero.StartsWith("521") && numero.Length == 13)
                return numero;
            if (numero.StartsWith("52") && numero.Length == 12)
                return numero;
            if (numero.Length == 10 && numero.StartsWith("9"))
                return "521" + numero;
            if (numero.Length == 10)
                return "52" + numero;
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
        private void ActualizarNumeroCotizacionEnLabel()
        {
            if (tbl_Cotizacion.Rows.Count == 0)
            {
                lbl_NoCotiza.Text = "";
                return;
            }

            string prefijo = "G"; 
            int prioridadActual = int.MaxValue;

            // Detectar el prefijo en base a las descripciones
            for (int i = tbl_Cotizacion.Rows.Count - 1; i >= 0; i--)
            {
                if (tbl_Cotizacion.Rows[i].IsNewRow)
                    continue;

                string descripcion = tbl_Cotizacion.Rows[i].Cells["DESCRIPCIÓN"].Value?.ToString()?.ToUpper() ?? "";

                if ((descripcion.Contains("CALENT") || descripcion.Contains("CALENTADOR") || descripcion.Contains("CALENT.")) && prioridadActual > 1)
                {
                    prefijo = "E";
                    prioridadActual = 1;
                }
                else if (descripcion.Contains("AIRE") && prioridadActual > 2)
                {
                    prefijo = "D";
                    prioridadActual = 2;
                }
                else if ((descripcion.Contains("BOMBA DE") || descripcion.Contains("BOMBA TIPO") ||
                          descripcion.Contains("MOTOBOMBA") || descripcion.Contains("MOTB") || descripcion.Contains("MOT.")) && prioridadActual > 3)
                {
                    prefijo = "C";
                    prioridadActual = 3;
                }
                else if ((descripcion.Contains("LUMINARIO") || descripcion.Contains("LUM SUM")) && prioridadActual > 4)
                {
                    prefijo = "F";
                    prioridadActual = 4;
                }
            }
            string ultimoFolio = CotizacionRepository.ObtenerUltimoFolioPorPrefijo(prefijo);
            int consecutivo = 1;

            if (!string.IsNullOrEmpty(ultimoFolio) && ultimoFolio.StartsWith(prefijo))
            {
                string numStr = ultimoFolio.Substring(prefijo.Length);
                if (int.TryParse(numStr, out int ultimoNum))
                    consecutivo = ultimoNum + 1;
            }

            string nuevoFolio = $"{prefijo}{consecutivo.ToString("D4")}";
            lbl_NoCotiza.Text = nuevoFolio;
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
            panelBusqueda.Location = new Point(Txt_Buscar.Left, Txt_Buscar.Bottom + 2);
            dgvBusqueda.CellDoubleClick += DgvBusqueda_CellDoubleClick;

            dgvBusqueda.LostFocus += (s, e) => panelBusqueda.Visible = false;
            Txt_Buscar.LostFocus += (s, e) => { if (!panelBusqueda.Focused && !dgvBusqueda.Focused) panelBusqueda.Visible = false; };
        }
        private void CargarProductosCache()
        {
            // Puedes obtener los productos desde tu servicio o base de datos
            var productoService = new ProductoServices1();
            var productos = productoService.ObtenerProductos();
            productosCache = productos.Select(p => new
            {
                CLAVE = p.CVE_ART ?? "N/A",
                DESCRIPCIÓN = p.DESCR ?? "N/A",
                UNIDAD = p.UNI_MED ?? "N/A",
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
                tbl_Cotizacion.Rows.Add(0, clave, descripcion, unidad, precio, precio * cantidad, total, cantidad);
                ActualizarNumeroCotizacionEnLabel();
                ActualizarTotales();
                ActualizarObservacionesPorProducto(descripcion, reemplazar: true);
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
                col.ReadOnly = !(col.Name == "PRECIO" || col.Name == "Descuento" || col.Name == "CANTIDAD");
            }
        }
        private void ConfigurarBotones()
        {

            // ===== Btn_Cancelar =====
            Btn_Cancelar.IconChar = IconChar.TimesCircle; // Ícono de cancelar (X)
            Btn_Cancelar.IconColor = Color.FromArgb(244, 67, 54); // Rojo elegante
            Btn_Cancelar.IconSize = 32;
            Btn_Cancelar.TextImageRelation = TextImageRelation.ImageBeforeText;
            Btn_Cancelar.ImageAlign = ContentAlignment.MiddleLeft;
            Btn_Cancelar.Padding = new Padding(10, 0, 20, 0);
            Btn_Cancelar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            Btn_Cancelar.ForeColor = Color.FromArgb(33, 33, 33);

            // ===== Btn_Guardar =====
            Btn_Guardar.IconChar = IconChar.Save; // Ícono de guardar
            Btn_Guardar.IconColor = Color.FromArgb(76, 175, 80); // Verde Material
            Btn_Guardar.IconSize = 32;
            Btn_Guardar.TextImageRelation = TextImageRelation.ImageBeforeText;
            Btn_Guardar.ImageAlign = ContentAlignment.MiddleLeft;
            Btn_Guardar.Padding = new Padding(10, 0, 20, 0);
            Btn_Guardar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            Btn_Guardar.ForeColor = Color.FromArgb(33, 33, 33);

            // ===== Btn_NuevoProd =====
            Btn_NuevoProd.IconChar = IconChar.Plus; // Ícono de agregar nuevo
            Btn_NuevoProd.IconColor = Color.FromArgb(33, 150, 243); // Azul elegante
            Btn_NuevoProd.IconSize = 32;
            Btn_NuevoProd.TextImageRelation = TextImageRelation.ImageBeforeText;
            Btn_NuevoProd.ImageAlign = ContentAlignment.MiddleLeft;
            Btn_NuevoProd.Padding = new Padding(10, 0, 20, 0);
            Btn_NuevoProd.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            Btn_NuevoProd.ForeColor = Color.FromArgb(33, 33, 33);

            // ===== Btn_NuevaTabla =====
            Btn_AñadirTabla.IconChar = IconChar.Table; // ícono de tabla
            Btn_AñadirTabla.IconColor = Color.FromArgb(0, 150, 136); // Verde azulado
            Btn_AñadirTabla.IconSize = 32;
            Btn_AñadirTabla.TextImageRelation = TextImageRelation.ImageBeforeText;
            Btn_AñadirTabla.ImageAlign = ContentAlignment.MiddleLeft;
            Btn_AñadirTabla.Padding = new Padding(10, 0, 20, 0);
            Btn_AñadirTabla.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            Btn_AñadirTabla.ForeColor = Color.FromArgb(33, 33, 33);

            // ===== Btn_AgregaProd =====
            Btn_Añadprod.IconChar = IconChar.PlusSquare; // ícono agregar producto
            Btn_Añadprod.IconColor = Color.FromArgb(33, 150, 243); // Azul Material
            Btn_Añadprod.IconSize = 32;
            Btn_Añadprod.TextImageRelation = TextImageRelation.ImageBeforeText;
            Btn_Añadprod.ImageAlign = ContentAlignment.MiddleLeft;
            Btn_Añadprod.Padding = new Padding(10, 0, 20, 0);
            Btn_Añadprod.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            Btn_Añadprod.ForeColor = Color.FromArgb(33, 33, 33);
        }

        private void iconButton1_Click(object sender, EventArgs e)
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

        private void Btn_Añadprod_Click(object sender, EventArgs e)
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
                        tbl_Cotizacion.Rows.Add(0, clave, descripcion, unidad, precio, precio * cantidadFinal, total, cantidadFinal);
                        ActualizarNumeroCotizacionEnLabel();
                        ActualizarTotales();
                        ActualizarObservacionesPorProducto(descripcion, reemplazar: true);
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

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            limpiaCampos();
        }

        private void Btn_Guardar_Click(object sender, EventArgs e)
        {
            ClientesDao clientesDao = new ClientesDao();
            string nombreCliente = txt_Nombrecliente.Text;

            // Verificar si el cliente existe
            if (!clientesDao.ClienteExiste(nombreCliente))
            {
                // Si no existe, guardar cliente solo con clave y nombre
                clientesDao.GuardarCliente(nombreCliente);
            }

            // Continuar con la lógica de guardar cotización
            if (tablasGuardadas.Count > 0 && tbl_Cotizacion.Rows.Count >= 1)
            {
                GuardarCotizacionTablas();
            }
            else if (tbl_Cotizacion.Rows.Count > 1 && tablasGuardadas.Count == 0)
            {
                GuardarCotizacion();
            }
        }

        private void Btn_NuevoProd_Click(object sender, EventArgs e)
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
                        Dock = DockStyle.Bottom
                        // NO asignar DialogResult aquí
                    };

                    // Botón para cancelar
                    Button btnCancelar = new Button
                    {
                        Text = "Cancelar",
                        Dock = DockStyle.Bottom,
                        DialogResult = DialogResult.Cancel // Solo el cancelar mantiene DialogResult
                    };

                    // Evento Click para el botón Aceptar
                    btnAceptar.Click += (s, e) =>
                    {
                        // Validar datos antes de cerrar el formulario
                        if (string.IsNullOrWhiteSpace(prodControl.Descripcion))
                        {
                            MessageBox.Show("El producto debe tener descripción.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return; // NO cerrar el formulario
                        }

                        // Si los datos son válidos, cerrar el formulario con DialogResult.OK
                        formWrapper.DialogResult = DialogResult.OK;
                        formWrapper.Close();
                    };

                    // Agregar controles al formulario
                    formWrapper.Controls.Add(prodControl);
                    formWrapper.Controls.Add(btnAceptar);
                    formWrapper.Controls.Add(btnCancelar);
                    formWrapper.CancelButton = btnCancelar;

                    // Mostrar formulario como modal
                    if (formWrapper.ShowDialog() == DialogResult.OK)
                    {
                        string clave = prodControl.Clave;
                        string descripcion = prodControl.Descripcion;
                        string unidad = prodControl.Unidentrada;
                        decimal precioUnitario = prodControl.PrecioUnitarioTemp;
                        int cantidad = (int)prodControl.cantidad;
                        decimal subtotal = precioUnitario * cantidad;
                        decimal total = subtotal; // Aquí puedes aplicar lógica de descuento si es necesario

                        tbl_Cotizacion.Rows.Add(0, clave, descripcion, unidad, precioUnitario, subtotal, total, cantidad);
                        ActualizarNumeroCotizacionEnLabel();
                        ActualizarTotales();
                        ActualizarObservacionesPorProducto(descripcion, reemplazar: true);
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
        private void tbl_Cotizacion_CellBeginEdit_1(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = tbl_Cotizacion.Rows[e.RowIndex];
            // Evita edición en filas vacías
            if (row.IsNewRow || string.IsNullOrWhiteSpace(row.Cells["Descripción"].Value?.ToString()))
            {
                e.Cancel = true;
            }
        }
    }
}