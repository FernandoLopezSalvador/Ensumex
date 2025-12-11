using Ensumex.Clases;
using Ensumex.Models;
using Ensumex.PDFtemplates;
using Ensumex.Services;
using Ensumex.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Ensumex.Views
{
    public partial class EditCotiza : UserControl
    {
        public int IdCotizacion { get; private set; }
        private readonly string usuarioActual;
        private List<List<object[]>> tablasGuardadas = new();
        private Panel panelBusqueda;
        private DataGridView dgvBusqueda;
        private List<dynamic> productosCache = new();

        public EditCotiza(string usuario)
        {
            InitializeComponent();
            usuarioActual = usuario;
            InicializarTabla();         
            CargarProductosCache();
            InicializarPanelBusqueda();
            HookCotizaBehavior();
        }

        // Carga todo desde la BD usando el id
        public void LoadFromId(int idCotizacion)
        {
            var row = CotizacionRepository.ObtenerCotizacionPorId(idCotizacion);
            if (row == null)
                throw new InvalidOperationException("Cotización no encontrada en la base de datos.");

            IdCotizacion = idCotizacion;

            Txt_Notaprincipal.Text = "En atención a su amable solicitud, me permito presentarle esta cotización para la venta y/o instalación de acuerdo a\r\nlo siguiente:";
            SetTextIfExists("lbl_NoCotiza", row["NumeroCotizacion"]?.ToString() ?? "");
            SetDateIfExists("dtpFecha", row["Fecha"]);
            SetTextIfExists("txt_Nombrecliente", row["NombreCliente"]?.ToString() ?? "");
            SetTextIfExists("txt_NumeroCliente", row["NumeroCliente"]?.ToString() ?? "");
            SetTextIfExists("txt_Costoinstalacion", (row["CostoInstalacion"] ?? 0).ToString());
            SetTextIfExists("txt_Costoflete", (row["CostoFlete"] ?? 0).ToString());
            SetTextIfExists("lbl_Subtotal", string.Format(CultureInfo.CurrentCulture, "{0:C}", row["Subtotal"] ?? 0));
            SetTextIfExists("lbl_costoDescuento", string.Format(CultureInfo.CurrentCulture, "{0:C}", row["Descuento"] ?? 0));
            SetTextIfExists("lbl_TotalNeto", string.Format(CultureInfo.CurrentCulture, "{0:C}", row["Total"] ?? 0));
            SetTextIfExists("Txt_observaciones", row["Notas"]?.ToString() ?? "");
            SetTextIfExists("txtEstado", row["Estado"]?.ToString() ?? "");

            // Cargar detalle de productos desde la BD
            var detalle = CotizacionRepository.ObtenerDetallePorId(idCotizacion);

            var tbl = GetTbl();
            if (tbl != null)
            {
                EnsureCotizacionTableSchema(tbl);

                try
                {
                    tbl.Rows.Clear();
                    tbl.AllowUserToAddRows = false;
                    tbl.ReadOnly = false;

                    foreach (DataRow dr in detalle.Rows)
                    {
                        object GetVal(params string[] names)
                        {
                            foreach (var n in names)
                            {
                                if (string.IsNullOrEmpty(n)) continue;
                                if (detalle.Columns.Contains(n) && dr[n] != DBNull.Value)
                                    return dr[n];
                            }
                            return DBNull.Value;
                        }

                        string clave = GetVal("ClaveProducto", "Clave", "CLAVE")?.ToString() ?? "";
                        string descripcion = GetVal("Descripcion", "DescripcionProducto", "DESCRIPCIÓN")?.ToString() ?? "";
                        string unidad = GetVal("Unidad", "UNIDAD")?.ToString() ?? "";
                        decimal precio = 0m;
                        decimal.TryParse(GetVal("PrecioUnitario", "Precio", "PRECIO")?.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out precio);
                        decimal cantidadDec = 1m;
                        decimal.TryParse(GetVal("Cantidad", "CANTIDAD")?.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out cantidadDec);
                        decimal subtotal = 0m;
                        decimal.TryParse(GetVal("Subtotal", "SUBTOTAL")?.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out subtotal);
                        int aplicaDescuento = 0;
                        int.TryParse(GetVal("AplicaDescuento", "AplicaDescuento", "Descuento")?.ToString(), out aplicaDescuento);

                        if (subtotal == 0m) subtotal = precio * cantidadDec;
                        decimal descuentoFila = subtotal * (aplicaDescuento / 100m);
                        decimal totalLinea = subtotal - descuentoFila;

                        int descuentoInt = Math.Clamp(aplicaDescuento, 0, 50);
                        int cantidadInt = (int)Math.Max(1, Math.Round(cantidadDec));
                        if (cantidadInt > 100) cantidadInt = 100;

                        var nuevaFila = new DataGridViewRow();
                        nuevaFila.CreateCells(tbl);

                        void SetCellValue(string colName, object value)
                        {
                            if (tbl.Columns.Contains(colName))
                            {
                                int idx = tbl.Columns[colName].Index;
                                nuevaFila.Cells[idx].Value = value;
                            }
                        }

                        SetCellValue("Descuento", descuentoInt);
                        SetCellValue("CLAVE", clave);
                        SetCellValue("DESCRIPCIÓN", descripcion);
                        SetCellValue("UNIDAD", unidad);
                        SetCellValue("PRECIO", precio);
                        SetCellValue("Subtotal", subtotal);
                        SetCellValue("TotalDescuento", totalLinea);
                        SetCellValue("CANTIDAD", cantidadInt);

                        bool anyAssigned = nuevaFila.Cells.Cast<DataGridViewCell>().Any(c => c.Value != null);
                        if (!anyAssigned)
                        {
                            object[] valoresFila = new object[]
                            {
                                descuentoInt, clave, descripcion, unidad, precio, subtotal, totalLinea, cantidadInt
                            };
                            for (int i = 0; i < Math.Min(nuevaFila.Cells.Count, valoresFila.Length); i++)
                                nuevaFila.Cells[i].Value = valoresFila[i];
                        }

                        tbl.Rows.Add(nuevaFila);
                    }

                    // Formatos
                    if (tbl.Columns.Contains("PRECIO"))
                        tbl.Columns["PRECIO"].DefaultCellStyle.Format = "C2";
                    if (tbl.Columns.Contains("Subtotal"))
                        tbl.Columns["Subtotal"].DefaultCellStyle.Format = "C2";
                    if (tbl.Columns.Contains("TotalDescuento"))
                        tbl.Columns["TotalDescuento"].DefaultCellStyle.Format = "C2";

                    tbl.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    tbl.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    tbl.RowHeadersVisible = false;

                    ActualizarTotales();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar detalle en la tabla: " + ex.Message + "\n\n" + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // ---- Comportamiento de Cotiza ----
        private void CargarProductosCache()
        {
            var productoService = new ProductoServices1();
            var productos = productoService.ObtenerProductos();
            productosCache = productos.Select(p => new
            {
                CLAVE = p.CVE_ART ?? "N/A",
                DESCRIPCIÓN = p.DESCR ?? "N/A",
                UNIDAD = p.UNI_MED ?? "N/A",
                PRECIO = p.PRECIO != 0 ? (p.PRECIO * 1.16m).ToString("C2") : "$0.00",
                EXIST= p.EXIST > 0 ? p.EXIST.ToString() : "0"
            }).ToList<dynamic>();
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
            TablaFormat.AplicarEstilosTabla(dgvBusqueda);
            panelBusqueda.Controls.Add(dgvBusqueda);
            this.Controls.Add(panelBusqueda);
            panelBusqueda.Location = new Point(Txt_Buscar.Left, Txt_Buscar.Bottom + 2);
            dgvBusqueda.CellDoubleClick += DgvBusqueda_CellDoubleClick;
            dgvBusqueda.LostFocus += (s, e) => panelBusqueda.Visible = false;
            Txt_Buscar.LostFocus += (s, e) => { if (!panelBusqueda.Focused && !dgvBusqueda.Focused) panelBusqueda.Visible = false; };
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

        private void HookCotizaBehavior()
        {
            var tbl = GetTbl();
            if (tbl != null)
            {
                tbl.CellValueChanged -= Tbl_CellValueChanged;
                tbl.CellValueChanged += Tbl_CellValueChanged;

                tbl.CurrentCellDirtyStateChanged -= Tbl_CurrentCellDirtyStateChanged;
                tbl.CurrentCellDirtyStateChanged += Tbl_CurrentCellDirtyStateChanged;

                tbl.CellClick -= Tbl_CellClick;
                tbl.CellClick += Tbl_CellClick;
            }

            // Usar Control en lugar de TextBox para encontrar MaterialTextBox2 del diseñador
            var txtInst = FindControlByName<Control>("txt_Costoinstalacion", "txtCostoinstalacion");
            if (txtInst != null)
            {
                txtInst.TextChanged -= TxtCosto_TextChanged;
                txtInst.TextChanged += TxtCosto_TextChanged;
            }

            var txtFlete = FindControlByName<Control>("txt_Costoflete", "txtCostoflete");
            if (txtFlete != null)
            {
                txtFlete.TextChanged -= TxtCosto_TextChanged;
                txtFlete.TextChanged += TxtCosto_TextChanged;
            }

            var btnGuardar = FindControlByName<Button>("Btn_Guardar", "btnGuardar");
            if (btnGuardar != null)
            {
                btnGuardar.Click -= Btn_Guardar_Click;
                btnGuardar.Click += Btn_Guardar_Click;
            }

            var btnCancelar = FindControlByName<Button>("Btn_Cancelar", "btnCancelar");
            if (btnCancelar != null)
            {
                btnCancelar.Click -= BtnCancelar_Click;
                btnCancelar.Click += BtnCancelar_Click;
            }
        }

        private void TxtCosto_TextChanged(object? sender, EventArgs e) => ActualizarTotales();

        private void Tbl_CurrentCellDirtyStateChanged(object? sender, EventArgs e)
        {
            if (sender is DataGridView tbl && tbl.IsCurrentCellDirty)
            {
                var colName = tbl.CurrentCell.OwningColumn?.Name;
                if (colName == "CANTIDAD" || colName == "Descuento")
                {
                    tbl.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
        }

        private void Tbl_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ActualizarTotales();
            }
        }

        private void Tbl_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            var tbl = GetTbl();
            if (tbl == null) return;
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var col = tbl.Columns[e.ColumnIndex];
            if (col.Name == "Accion")
            {
                var confirm = MessageBox.Show("¿Eliminar este producto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    tbl.Rows.RemoveAt(e.RowIndex);
                    ActualizarTotales();
                }
            }
        }

        private void ActualizarTotales()
        {
            var tbl = GetTbl();
            if (tbl == null) return;

            decimal subtotalGeneral = 0m;
            decimal totalDescuento = 0m;

            foreach (DataGridViewRow row in tbl.Rows)
            {
                if (row.IsNewRow) continue;

                decimal precio = 0m;
                decimal cantidad = 1m;
                int porcentajeDescuento = 0;

                object precioObj = GetCellValue(row, tbl, "PRECIO", 4);
                object cantidadObj = GetCellValue(row, tbl, "CANTIDAD", 7);
                object descObj = GetCellValue(row, tbl, "Descuento", 0);

                decimal.TryParse(precioObj?.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out precio);
                decimal.TryParse(cantidadObj?.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out cantidad);
                int.TryParse(descObj?.ToString(), out porcentajeDescuento);

                if (cantidad <= 0) cantidad = 1;

                decimal filaSubtotal = precio * cantidad;
                decimal descuentoFila = filaSubtotal * (porcentajeDescuento / 100m);
                decimal filaTotal = filaSubtotal - descuentoFila;

                SetCellIfExists(row, tbl, "Subtotal", filaSubtotal, 5);
                SetCellIfExists(row, tbl, "TotalDescuento", filaTotal, 6);

                subtotalGeneral += filaSubtotal;
                totalDescuento += descuentoFila;
            }

            decimal instalacion = ParseDecimalTextBox("txt_Costoinstalacion", "txtCostoinstalacion");
            decimal flete = ParseDecimalTextBox("txt_Costoflete", "txtCostoflete");

            SetTextIfExists("lbl_Subtotal", subtotalGeneral.ToString("C"));
            SetTextIfExists("lbl_costoDescuento", $"-{totalDescuento:C}");
            decimal totalNeto = (subtotalGeneral - totalDescuento) + instalacion + flete;
            SetTextIfExists("lbl_TotalNeto", totalNeto.ToString("C"));
        }

        private void Btn_Guardar_Click(object? sender, EventArgs e)
        {
            try
            {
                ClientesDao clientesDao = new ClientesDao();
                string nombreCliente = txt_Nombrecliente?.Text?.Trim() ?? "";

                if (!clientesDao.ClienteExiste(nombreCliente))
                    clientesDao.GuardarCliente(nombreCliente);

                var tbl = GetTbl();
                if (tbl == null)
                {
                    MessageBox.Show("No se encontró la tabla de cotización.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Recolectar datos comunes
                var lblNumero = FindControlByName<Label>("lbl_NoCotiza", "txtNumeroCotizacion");
                var txtNumeroCliente = FindControlByName<Control>("txt_NumeroCliente", "txtNumeroCliente");
                string numero = lblNumero?.Text ?? "";
                string numeroCliente = (txtNumeroCliente?.GetType().GetProperty("Text")?.GetValue(txtNumeroCliente)?.ToString()) ?? "";
                decimal costoInstalacion = ParseDecimalTextBox("txt_Costoinstalacion", "txtCostoinstalacion");
                decimal costoFlete = ParseDecimalTextBox("txt_Costoflete", "txtCostoflete");

                decimal subtotal = 0m, descuento = 0m, total = 0m;
                var lblSub = FindControlByName<Label>("lbl_Subtotal");
                if (lblSub != null) decimal.TryParse(lblSub.Text.Replace("$", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out subtotal);
                var lblDesc = FindControlByName<Label>("lbl_costoDescuento");
                if (lblDesc != null) decimal.TryParse(lblDesc.Text.Replace("$", "").Replace("-", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out descuento);
                var lblTotal = FindControlByName<Label>("lbl_TotalNeto");
                if (lblTotal != null) decimal.TryParse(lblTotal.Text.Replace("$", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out total);

                string notas = FindControlByName<TextBox>("Txt_observaciones", "txtNotas")?.Text ?? "";

                // Si hay tablas guardadas -> tablas múltiples
                if (tablasGuardadas.Count > 0 && tbl.Rows.Count >=1)
                {
                    var tablasParaGuardar = new List<List<object[]>>(tablasGuardadas);
                    List<object[]> tablaActual = new();
                    foreach (DataGridViewRow row in tbl.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            object[] valores = new object[row.Cells.Count];
                            for (int i = 0; i < row.Cells.Count; i++) valores[i] = row.Cells[i].Value;
                            tablaActual.Add(valores);
                        }
                    }
                    if (tablaActual.Count > 0) tablasParaGuardar.Add(tablaActual);

                    CotizacionRepository.GuardarSiNoExisteCliente(numeroCliente, nombreCliente);

                    if (this.IdCotizacion > 0)
                    {
                        using (SaveFileDialog sfd = new SaveFileDialog())
                        {
                            sfd.Filter = "Archivo PDF|*.pdf";
                            sfd.FileName = $"{numero}.pdf";
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                CotizacionRepository.ActualizarCotizacionTablas(
                                    idCotizacion: this.IdCotizacion,
                                    numeroCotizacion: numero,
                                    fecha: DateTime.Now,
                                    nombreCliente: nombreCliente,
                                    numeroCliente: numeroCliente,
                                    costoInstalacion: costoInstalacion,
                                    costoFlete: costoFlete,
                                    subtotal: subtotal,
                                    descuento: descuento,
                                    total: total,
                                    notas: notas,
                                    tablas: tablasParaGuardar
                                );

                                // Generar PDF con tablas
                                List<string> encabezados = new();
                                foreach (DataGridViewColumn col in tbl.Columns) encabezados.Add(col.HeaderText);

                                GeneraPDFTablas.GenerarPDFConTablas(
                                    rutaArchivo: sfd.FileName,
                                    tablas: tablasParaGuardar,
                                    encabezados: encabezados,
                                    numeroCotizacion: numero,
                                    nombreCliente: nombreCliente,
                                    costoInstalacion: txt_Costoinstalacion.Text,
                                    costoFlete: txt_Costoflete.Text,
                                    subtotal: lbl_Subtotal.Text,
                                    total: lbl_TotalNeto.Text,
                                    descuento: lbl_costoDescuento.Text,
                                    notas: Txt_observaciones.Text,
                                    usuario: usuarioActual
                                );

                                // Preguntar envío por WhatsApp (misma UX que en Cotiza)
                                if (MessageBox.Show("¿Desea enviar la cotización por WhatsApp al cliente?", "Enviar por WhatsApp", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    string noWhats = NormalizarNumeroWhatsApp(numeroCliente);
                                    if (string.IsNullOrWhiteSpace(noWhats))
                                    {
                                        noWhats = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el número de WhatsApp del cliente (ejemplo: 9511234567):", "WhatsApp", "");
                                        noWhats = NormalizarNumeroWhatsApp(noWhats);
                                    }
                                    if (!string.IsNullOrWhiteSpace(noWhats))
                                    {
                                        EnviarCotizacionPorWhatsApp(noWhats, $"Hola, le comparto la cotización {numero}. Adjunto el PDF.");
                                        string carpeta = Path.GetDirectoryName(sfd.FileName);
                                        if (!string.IsNullOrEmpty(carpeta) && Directory.Exists(carpeta))
                                            Process.Start(new ProcessStartInfo { FileName = "explorer.exe", Arguments = $"/select,\"{sfd.FileName}\"", WindowStyle = ProcessWindowStyle.Normal });
                                        MessageBox.Show("Se abrió WhatsApp Web y la carpeta de la cotización. Adjunte el PDF manualmente en el chat.", "WhatsApp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }

                                Process.Start(new ProcessStartInfo { FileName = sfd.FileName, UseShellExecute = true });
                                MessageBox.Show("Cotización actualizada y PDF generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                // Actualizar sin generar PDF
                                CotizacionRepository.ActualizarCotizacionTablas(
                                    idCotizacion: this.IdCotizacion,
                                    numeroCotizacion: numero,
                                    fecha: DateTime.Now,
                                    nombreCliente: nombreCliente,
                                    numeroCliente: numeroCliente,
                                    costoInstalacion: costoInstalacion,
                                    costoFlete: costoFlete,
                                    subtotal: subtotal,
                                    descuento: descuento,
                                    total: total,
                                    notas: notas,
                                    tablas: tablasParaGuardar
                                );
                                MessageBox.Show("Cotización actualizada correctamente (sin PDF).", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        // Crear nueva
                        GuardarCotizacionTablas();
                    }

                    return;
                }

                // Caso: una sola tabla (detalle)
                if (tbl.Rows.Count >= 1 && tablasGuardadas.Count == 0)
                {
                    CotizacionRepository.GuardarSiNoExisteCliente(numeroCliente, nombreCliente);

                    if (this.IdCotizacion > 0)
                    {
                        // Actualizar cotización existente
                        using (SaveFileDialog sfd = new SaveFileDialog())
                        {
                            sfd.Filter = "Archivo PDF|*.pdf";
                            sfd.FileName = $"{numero}.pdf";
                            if (sfd.ShowDialog() == DialogResult.OK)
                            {
                                // calcular descuento total
                                decimal totalDescuentoCalculado = 0m;
                                foreach (DataGridViewRow row in tbl.Rows)
                                {
                                    if (row.IsNewRow) continue;
                                    decimal precio = 0m, cantidad = 0m;
                                    int porcentajeDescuento = 0;
                                    decimal.TryParse(row.Cells["PRECIO"]?.Value?.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out precio);
                                    decimal.TryParse(row.Cells["CANTIDAD"]?.Value?.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out cantidad);
                                    int.TryParse(row.Cells["Descuento"]?.Value?.ToString(), out porcentajeDescuento);
                                    totalDescuentoCalculado += (precio * cantidad) * (porcentajeDescuento / 100m);
                                }

                                CotizacionRepository.ActualizarCotizacion(
                                    idCotizacion: this.IdCotizacion,
                                    numeroCotizacion: numero,
                                    fecha: DateTime.Now,
                                    nombreCliente: nombreCliente,
                                    numeroCliente: numeroCliente,
                                    costoInstalacion: costoInstalacion,
                                    costoFlete: costoFlete,
                                    subtotal: subtotal,
                                    descuento: totalDescuentoCalculado,
                                    total: total,
                                    notas: notas,
                                    tablaCotizacion: tbl
                                );

                                PDFGenerator.GenerarPDFCotizacion(
                                    rutaArchivo: sfd.FileName,
                                    numeroCotizacion: numero,
                                    nombreCliente: nombreCliente,
                                    costoInstalacion: txt_Costoinstalacion.Text,
                                    costoFlete: txt_Costoflete.Text,
                                    subtotal: lbl_Subtotal.Text.Replace("$", "").Trim(),
                                    total: lbl_TotalNeto.Text.Replace("$", "").Trim(),
                                    descuento: lbl_costoDescuento.Text.Replace("$", "").Trim(),
                                    porcentajeDescuento: totalDescuentoCalculado,
                                    notas: Txt_observaciones.Text,
                                    notaprincipal: Txt_Notaprincipal.Text,
                                    tablaCotizacion: tbl,
                                    usuario: usuarioActual
                                );

                                if (MessageBox.Show("¿Desea enviar la cotización por WhatsApp al cliente?", "Enviar por WhatsApp", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    string noWhats = NormalizarNumeroWhatsApp(numeroCliente);
                                    if (string.IsNullOrWhiteSpace(noWhats))
                                    {
                                        noWhats = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el número de WhatsApp del cliente (ejemplo: 9511234567):", "WhatsApp", "");
                                        noWhats = NormalizarNumeroWhatsApp(noWhats);
                                    }
                                    if (!string.IsNullOrWhiteSpace(noWhats))
                                    {
                                        EnviarCotizacionPorWhatsApp(noWhats, $"Hola, le comparto la cotización {numero}. Adjunto el PDF.");
                                        string carpeta = Path.GetDirectoryName(sfd.FileName);
                                        if (!string.IsNullOrEmpty(carpeta) && Directory.Exists(carpeta))
                                            Process.Start(new ProcessStartInfo { FileName = "explorer.exe", Arguments = $"/select,\"{sfd.FileName}\"", WindowStyle = ProcessWindowStyle.Normal });
                                        MessageBox.Show("Se abrió WhatsApp Web y la carpeta de la cotización. Adjunte el PDF manualmente en el chat.", "WhatsApp", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }

                                Process.Start(new ProcessStartInfo { FileName = sfd.FileName, UseShellExecute = true });
                                MessageBox.Show("Cotización actualizada y PDF generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                // Actualizar sin PDF
                                decimal totalDescuentoCalculado = 0m;
                                foreach (DataGridViewRow row in tbl.Rows)
                                {
                                    if (row.IsNewRow) continue;
                                    decimal precio = 0m, cantidad = 0m;
                                    int porcentajeDescuento = 0;
                                    decimal.TryParse(row.Cells["PRECIO"]?.Value?.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out precio);
                                    decimal.TryParse(row.Cells["CANTIDAD"]?.Value?.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out cantidad);
                                    int.TryParse(row.Cells["Descuento"]?.Value?.ToString(), out porcentajeDescuento);
                                    totalDescuentoCalculado += (precio * cantidad) * (porcentajeDescuento / 100m);
                                }

                                CotizacionRepository.ActualizarCotizacion(
                                    idCotizacion: this.IdCotizacion,
                                    numeroCotizacion: numero,
                                    fecha: DateTime.Now,
                                    nombreCliente: nombreCliente,
                                    numeroCliente: numeroCliente,
                                    costoInstalacion: costoInstalacion,
                                    costoFlete: costoFlete,
                                    subtotal: subtotal,
                                    descuento: totalDescuentoCalculado,
                                    total: total,
                                    notas: notas,
                                    tablaCotizacion: tbl
                                );
                                MessageBox.Show("Cotización actualizada correctamente (sin PDF).", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                    else
                    {
                        GuardarCotizacion();
                    }

                    return;
                }

                MessageBox.Show("No hay productos para guardar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar cotización: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarCotizacion()
        {
            try
            {
                CotizacionRepository.GuardarSiNoExisteCliente(txt_NumeroCliente.Text, txt_Nombrecliente.Text);
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    if (tbl_Cotizacion.Rows.Count <= 1)
                    {
                        MessageBox.Show("No hay productos en la cotización.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    sfd.Filter = "Archivo PDF|*.pdf";
                    sfd.FileName = $"{lbl_NoCotiza.Text}.pdf";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        decimal totalDescuentoCalculado = 0m;
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
                        CotizacionRepository.GuardarCotizacion(
                            numeroCotizacion: lbl_NoCotiza.Text,
                            fecha: DateTime.Now,
                            nombreCliente: txt_Nombrecliente.Text,
                            numeroCliente: txt_NumeroCliente.Text,
                            costoInstalacion: decimal.TryParse(txt_Costoinstalacion.Text, out var inst) ? inst : 0,
                            costoFlete: decimal.TryParse(txt_Costoflete.Text, out var flt) ? flt : 0,
                            subtotal: decimal.TryParse(lbl_Subtotal.Text.Replace("$", ""), out var sub) ? sub : 0,
                            descuento: totalDescuentoCalculado,
                            total: decimal.TryParse(lbl_TotalNeto.Text.Replace("$", ""), out var tot) ? tot : 0,
                            notas: Txt_observaciones.Text,
                            tablaCotizacion: tbl_Cotizacion
                        );
                        PDFGenerator.GenerarPDFCotizacion(
                            rutaArchivo: sfd.FileName,
                            numeroCotizacion: lbl_NoCotiza.Text,
                            nombreCliente: txt_Nombrecliente.Text,
                            costoInstalacion: txt_Costoinstalacion.Text,
                            costoFlete: txt_Costoflete.Text,
                            subtotal: lbl_Subtotal.Text.Replace("$", "").Trim(),
                            total: lbl_TotalNeto.Text.Replace("$", "").Trim(),
                            descuento: lbl_costoDescuento.Text.Replace("$", "").Trim(),
                            porcentajeDescuento: totalDescuentoCalculado,
                            notas: Txt_observaciones.Text,
                            notaprincipal: Txt_Notaprincipal.Text,
                            tablaCotizacion: tbl_Cotizacion,
                            usuario: usuarioActual
                        );

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

        private void GuardarCotizacionTablas()
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo PDF|*.pdf";
                sfd.FileName = $"{lbl_NoCotiza.Text}.pdf";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var tablasParaGuardar = new List<List<object[]>>(tablasGuardadas);
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
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = sfd.FileName,
                        UseShellExecute = true
                    });
                }
            }
        }

        private void BtnCancelar_Click(object? sender, EventArgs e)
        {
            SetTextIfExists("txt_Costoinstalacion", "");
            SetTextIfExists("txt_Costoflete", "");
            SetTextIfExists("txt_NumeroCliente", "");
            SetTextIfExists("txt_Nombrecliente", "");
            SetTextIfExists("lbl_NoCotiza", "");
            SetTextIfExists("lbl_Subtotal", "$0.00");
            SetTextIfExists("lbl_costoDescuento", "$0.00");
            SetTextIfExists("lbl_TotalNeto", "$0.00");
            SetTextIfExists("Txt_observaciones", "");
            var tbl = GetTbl();
            tbl?.Rows.Clear();
        }

        private void EnsureCotizacionTableSchema(DataGridView tbl)
        {
            if (tbl.Columns.Contains("Descuento") && tbl.Columns.Contains("CLAVE") && tbl.Columns.Contains("DESCRIPCIÓN"))
                return;

            tbl.Columns.Clear();

            var colDescuento = new DataGridViewComboBoxColumn
            {
                Name = "Descuento",
                HeaderText = "Descuento (%)",
                DataSource = Enumerable.Range(0, 51).ToList(),
                ValueType = typeof(int),
                FlatStyle = FlatStyle.Flat,
                Width = 80
            };
            tbl.Columns.Add(colDescuento);

            tbl.Columns.Add(new DataGridViewTextBoxColumn { Name = "CLAVE", HeaderText = "Clave" });
            tbl.Columns.Add(new DataGridViewTextBoxColumn { Name = "DESCRIPCIÓN", HeaderText = "Descripción" });
            tbl.Columns.Add(new DataGridViewTextBoxColumn { Name = "UNIDAD", HeaderText = "Unidad", Width = 60 });
            tbl.Columns.Add(new DataGridViewTextBoxColumn { Name = "PRECIO", HeaderText = "Precio" });
            tbl.Columns.Add(new DataGridViewTextBoxColumn { Name = "Subtotal", HeaderText = "Subtotal" });
            tbl.Columns.Add(new DataGridViewTextBoxColumn { Name = "TotalDescuento", HeaderText = "Total - Descuento" });

            var colCantidad = new DataGridViewComboBoxColumn
            {
                Name = "CANTIDAD",
                HeaderText = "Cantidad",
                DataSource = Enumerable.Range(1, 100).ToList(),
                ValueType = typeof(int),
                FlatStyle = FlatStyle.Flat,
                Width = 60
            };
            tbl.Columns.Add(colCantidad);

            var btnEliminar = new DataGridViewButtonColumn
            {
                Name = "Accion",
                HeaderText = "Acción",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true,
                Width = 80
            };
            tbl.Columns.Add(btnEliminar);
        }

        private void InicializarTabla()
        {
            var tbl = GetTbl();
            if (tbl != null)
            {
                EnsureCotizacionTableSchema(tbl);
                tbl.AllowUserToAddRows = true;
            }
        }

        private void HabilitarEdicionParcial()
        {
            var tbl = GetTbl();
            if (tbl == null) return;
            tbl.ReadOnly = false;
            foreach (DataGridViewColumn col in tbl.Columns)
            {
                col.ReadOnly = !(col.Name == "PRECIO" || col.Name == "Descuento" || col.Name == "CANTIDAD");
            }
        }

        private object GetCellValue(DataGridViewRow row, DataGridView tbl, string name, int fallbackIndex)
        {
            if (tbl.Columns.Contains(name))
                return row.Cells[tbl.Columns[name].Index].Value ?? DBNull.Value;
            if (fallbackIndex >= 0 && fallbackIndex < row.Cells.Count)
                return row.Cells[fallbackIndex].Value ?? DBNull.Value;
            return DBNull.Value;
        }

        private void SetCellIfExists(DataGridViewRow row, DataGridView tbl, string name, object value, int fallbackIndex)
        {
            if (tbl.Columns.Contains(name))
                row.Cells[tbl.Columns[name].Index].Value = value;
            else if (fallbackIndex >= 0 && fallbackIndex < row.Cells.Count)
                row.Cells[fallbackIndex].Value = value;
        }

        private decimal ParseDecimalTextBox(params string[] names)
        {
            foreach (var n in names)
            {
                if (string.IsNullOrWhiteSpace(n)) continue;
                var matches = this.Controls.Find(n, true);
                if (matches == null || matches.Length == 0) continue;

                var control = matches[0];
                string text = null;

                if (control is TextBox tb)
                {
                    text = tb.Text;
                }
                else
                {
                    var prop = control.GetType().GetProperty("Text");
                    if (prop != null)
                        text = prop.GetValue(control)?.ToString();
                }

                if (!string.IsNullOrWhiteSpace(text) && decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out var v))
                    return v;
            }
            return 0m;
        }
        private DataGridView? GetTbl() => FindControlByName<DataGridView>("tbl_Cotizacion", "tblCotizacion", "dgvCotizacion", "dgvDetalleProductos", "dgvDetalle");

        private void SetDateIfExists(string controlName, object value)
        {
            var matches = this.Controls.Find(controlName, true);
            if (matches == null || matches.Length == 0) return;
            if (matches[0] is DateTimePicker dtp && value != DBNull.Value)
            {
                try { dtp.Value = Convert.ToDateTime(value); } catch { }
            }
            else
            {
                SetTextIfExists(controlName, value?.ToString() ?? "");
            }
        }

        private T? FindControlByName<T>(params string[] names) where T : Control
        {
            foreach (var name in names)
            {
                if (string.IsNullOrEmpty(name)) continue;
                var matches = this.Controls.Find(name, true);
                if (matches != null && matches.Length > 0 && matches[0] is T t) return t;
            }
            return null;
        }

        private void SetTextIfExists(string controlName, string text)
        {
            var matches = this.Controls.Find(controlName, true);
            if (matches == null || matches.Length == 0) return;
            var c = matches[0];
            switch (c)
            {
                case TextBox tb: tb.Text = text; break;
                case Label lbl: lbl.Text = text; break;
                case RichTextBox rtb: rtb.Text = text; break;
                default:
                    var prop = c.GetType().GetProperty("Text");
                    if (prop != null && prop.CanWrite) prop.SetValue(c, text);
                    break;
            }
        }

        private string NormalizarNumeroWhatsApp(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero)) return "";
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

        private void EnviarCotizacionPorWhatsApp(string numeroCliente, string mensaje)
        {
            try
            {
                string url = $"https://wa.me/{numeroCliente}?text={Uri.EscapeDataString(mensaje)}";
                Process.Start(new ProcessStartInfo
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

        private void ActualizarNumeroCotizacionEnLabel()
        {
            var tbl = GetTbl();
            if (tbl == null || tbl.Rows.Count == 0)
            {
                SetTextIfExists("lbl_NoCotiza", "");
                return;
            }

            string prefijo = "G";
            int prioridadActual = int.MaxValue;

            for (int i = tbl.Rows.Count - 1; i >= 0; i--)
            {
                var r = tbl.Rows[i];
                if (r.IsNewRow) continue;
                string descripcion = r.Cells["DESCRIPCIÓN"].Value?.ToString()?.ToUpper() ?? "";

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
                var match = System.Text.RegularExpressions.Regex.Match(ultimoFolio, @"(\d+)$");
                if (match.Success && int.TryParse(match.Groups[1].Value, out int ultimoNum))
                {
                    consecutivo = ultimoNum + 1;
                }
            }

            string nuevoFolio = $"{prefijo}{consecutivo.ToString("D4")}";
            SetTextIfExists("lbl_NoCotiza", nuevoFolio);
        }

        private void ActualizarObservacionesPorProducto(string descripcion, bool reemplazar = true)
        {
            var notas = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["CALENTADOR"] = "-Garantía contra defectos de fabricación en calentador solar: 5 años, la garantía aplica en termo tanque únicamente. No aplica la garantía por omisión en los cuidados que requiere el equipo de acuerdo al manual de instalación y póliza de garantía que se le entrega.\n" +
                "-Se requiere un anticipo mínimo del 50% al confirmar el pedido.\n" +
                "-No incluye material de plomería ni mano de obra para instalación.\n" +
                "-Precios sujetos a cambios sin previo aviso.\n",

                ["CALENT"] = "-Garantía contra defectos de fabricación en calentador solar: 5 años, la garantía aplica en termo tanque únicamente. No aplica la garantía por omisión en los cuidados que requiere el equipo de acuerdo al manual de instalación y póliza de garantía que se le entrega.\n" +
                "-Se requiere un anticipo mínimo del 50% al confirmar el pedido.\n" +
                "-No incluye material de plomería ni mano de obra para instalación.\n" +
                "-Precios sujetos a cambios sin previo aviso.\n",

                ["AIRE ACONDICIONADO"] = "-Garantía: 3 años contra defectos de fabricación.\n" +
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
                    if (reemplazar) SetTextIfExists("Txt_observaciones", nota.Value);
                    else
                    {
                        var current = FindControlByName<TextBox>("Txt_observaciones")?.Text ?? "";
                        if (!current.Contains(nota.Value)) SetTextIfExists("Txt_observaciones", current + "\n" + nota.Value);
                    }
                    return;
                }
            }
        }

        private void Btn_AñadirTabla_Click(object sender, EventArgs e)
        {
            var tbl = GetTbl();
            if (tbl == null) return;
            List<object[]> tablaActual = new();
            foreach (DataGridViewRow row in tbl.Rows)
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
                tbl.Rows.Clear();
                MessageBox.Show("Tabla guardada y lista para capturar una nueva.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else MessageBox.Show("No hay productos para guardar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Btn_Añadprod_Click(object sender, EventArgs e) 
        {
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

                    try
                    {
                        decimal precioFinal = precio;
                        int cantidadFinal = 1;
                        cantidad = cantidadFinal;
                        decimal subtotal = precioFinal * cantidad;
                        decimal total = subtotal;
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

        private void Txt_Buscar_TextChanged(object sender, EventArgs e)
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
                    p.DESCRIPCIÓN.ToLower().Contains(texto)||
                    p.EXIST.ToLower().Contains(texto))
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
    }
}
