using Ensumex.Models;
using Ensumex.PDFtemplates;
using Ensumex.Services;
using Ensumex.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ensumex.Views
{
    public partial class Autonomos : UserControl
    {
        private readonly string usuarioActual;
        private Panel panelBusqueda;
        private DataGridView dgvBusqueda;
        private List<dynamic> productosCache = new();
        public Autonomos(string usuario)
        {
            InitializeComponent();
            ConfigurarTablas();
            CargarProductosCache();
            InicializarPanelBusqueda();
        }
        private void ConfigurarTablas()
        {
            AgregarColumnasCotizacion();
            AgregarColumnasConectados();
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
                    if (!Tbl_Cotizacion.Columns.Contains(nombreInterno))
                    {
                        Tbl_Cotizacion.Columns.Add(nombreInterno, encabezado);
                    }
                }

                if (!Tbl_Cotizacion.Columns.Contains("CANTIDAD"))
                {
                    var colCantidad = new DataGridViewComboBoxColumn
                    {
                        Name = "CANTIDAD",
                        HeaderText = "Cantidad",
                        DataSource = Enumerable.Range(1, 100).ToList(),
                        ValueType = typeof(int),
                        FlatStyle = FlatStyle.Flat
                    };
                    Tbl_Cotizacion.Columns.Add(colCantidad);
                }

                if (!Tbl_Cotizacion.Columns.Contains("Descuento"))
                {
                    var colDescuento = new DataGridViewComboBoxColumn
                    {
                        Name = "Descuento",
                        HeaderText = "Descuento (%)",
                        DataSource = Enumerable.Range(0, 51).ToList(), 
                        ValueType = typeof(int),
                        FlatStyle = FlatStyle.Flat,
                        Width = 80
                    };
                    Tbl_Cotizacion.Columns.Insert(0, colDescuento);
                }

                if (!Tbl_Cotizacion.Columns.Contains("Eliminar"))
                {
                    DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn
                    {
                        Name = "Eliminar",
                        HeaderText = "Acción",
                        Text = "Eliminar",
                        UseColumnTextForButtonValue = true
                    };
                    Tbl_Cotizacion.Columns.Add(btnEliminar);
                }
                Tbl_Cotizacion.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al agregar las columnas de la cotización:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AgregarColumnasConectados()
        {
            try
            {
                string[,] columnas = {
                    { "CANTIDAD", "CANTIDAD" },
                    { "EQUIPOS", "EQUIPOS" },
                    { "POTENCIA", "POTENCIA (WATTS)" },
                    { "HORAS DE USO", "HORAS DE USO" },
                };

                for (int i = 0; i < columnas.GetLength(0); i++)
                {
                    string nombreInterno = columnas[i, 0];
                    string encabezado = columnas[i, 1];
                    if (!Tbl_conectados.Columns.Contains(nombreInterno))
                    {
                        Tbl_conectados.Columns.Add(nombreInterno, encabezado);
                    }
                }

                if (!Tbl_conectados.Columns.Contains("CANTIDAD"))
                {
                    var colCantidad = new DataGridViewComboBoxColumn
                    {
                        Name = "CANTIDAD",
                        HeaderText = "Cantidad",
                        DataSource = Enumerable.Range(1, 100).ToList(),
                        ValueType = typeof(int),
                        FlatStyle = FlatStyle.Flat
                    };
                    Tbl_conectados.Columns.Add(colCantidad);
                }


                if (!Tbl_conectados.Columns.Contains("Eliminar"))
                {
                    DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn
                    {
                        Name = "Eliminar",
                        HeaderText = "Acción",
                        Text = "Eliminar",
                        UseColumnTextForButtonValue = true
                    };
                    Tbl_conectados.Columns.Add(btnEliminar);
                }
                Tbl_conectados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al agregar las columnas de la cotización:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    // Validar que los datos no sean nulos o vacíos
                    try
                    {
                        decimal precioFinal = precio;
                        int cantidadFinal = 1;
                        cantidad = cantidadFinal;
                        decimal subtotal = precioFinal * cantidad;
                        decimal total = subtotal;
                        foreach (DataGridViewRow row in Tbl_Cotizacion.Rows)
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
                        Tbl_Cotizacion.Rows.Add(0, clave, descripcion, unidad, precio, precio * cantidadFinal, total, cantidadFinal);
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
        private void ActualizarTotales()
        {
            decimal subtotalGeneral = 0;
            decimal totalDescuento = 0;

            try
            {
                foreach (DataGridViewRow row in Tbl_Cotizacion.Rows)
                {
                    if (row.IsNewRow) continue;

                    decimal precio = 0, cantidad = 0, subtotalOriginal = 0;

                    // Obtener precio y cantidad
                    decimal.TryParse(row.Cells["PRECIO"].Value?.ToString(), out precio);
                    decimal.TryParse(row.Cells["CANTIDAD"].Value?.ToString(), out cantidad);
                    subtotalOriginal = precio * cantidad;
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
                decimal totalNeto = (subtotalGeneral - totalDescuento);
                lbl_TotalNeto.Text = totalNeto.ToString("C");
            }
            catch (Exception ex)
            {
                lbl_TotalNeto.Text = "Error";
                MessageBox.Show($"Se produjo un error al calcular el total: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    if (reemplazar)
                    {
                        Txt_observaciones.Text = nota.Value;
                    }
                    else if (!Txt_observaciones.Text.Contains(nota.Value))
                    {
                        Txt_observaciones.Text += "\n" + nota.Value;
                    }
                    return; 
                }
            }
        }

        private void HabilitarEdicionParcial()
        {
            Tbl_Cotizacion.ReadOnly = false;
            foreach (DataGridViewColumn col in Tbl_Cotizacion.Columns)
            {
                col.ReadOnly = !(col.Name == "PRECIO" || col.Name == "Descuento" || col.Name == "CANTIDAD");
            }
        }

        private void Tbl_Cotizacion_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var colName = Tbl_Cotizacion.Columns[e.ColumnIndex].Name;

                // Nombres de columna consistentes
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

        private void Tbl_Cotizacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Evitar errores al hacer clic en encabezados o filas nuevas
            try
            {
                if (e.RowIndex < 0 || e.RowIndex >= Tbl_Cotizacion.Rows.Count) return;
                if (Tbl_Cotizacion.Columns[e.ColumnIndex].Name == "Eliminar")
                {
                    // Confirmar eliminación
                    var confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar este producto?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirmResult == DialogResult.Yes)
                    {
                        Tbl_Cotizacion.Rows.RemoveAt(e.RowIndex);
                        ActualizarTotales();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No existen productos a eliminar.");

            }
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
            GuardarCotizacion();
        }
        private void GuardarCotizacion()
        {
            try
            {
                // Guardar cliente si no existe
                CotizacionRepository.GuardarSiNoExisteCliente(txt_NumeroCliente.Text, txt_Nombrecliente.Text);
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    if (Tbl_Cotizacion.Rows.Count <= 1)
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
                        foreach (DataGridViewRow row in Tbl_Cotizacion.Rows)
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
                        // Generar PDF de la cotización
                        PDFaislados.GenerarPDFCotizacion(
                            rutaArchivo: sfd.FileName,
                            numeroCotizacion: lbl_NoCotiza.Text,
                            nombreCliente: txt_Nombrecliente.Text,
                            subtotal: lbl_Subtotal.Text.Replace("$", "").Trim(),
                            total: lbl_TotalNeto.Text.Replace("$", "").Trim(),
                            descuento: lbl_costoDescuento.Text.Replace("$", "").Trim(),
                            porcentajeDescuento: totalDescuentoCalculado,
                            notas: Txt_observaciones.Text,
                            tablaCotizacion: Tbl_Cotizacion,
                            tablaConectados: Tbl_conectados,
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

        private void Buscarcliente_Click(object sender, EventArgs e)
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

        private void Btn_Cancelar_Click(object sender, EventArgs e)
        {
            limpiaCampos();
        }
        private void limpiaCampos()
        {
            txt_NumeroCliente.Text = string.Empty;
            lbl_NoCotiza.Text = string.Empty;
            txt_Nombrecliente.Text = string.Empty;
            lbl_Subtotal.Text = "$0.00";
            lbl_costoDescuento.Text = "$0.00";
            lbl_TotalNeto.Text = "$0.00";
            Tbl_Cotizacion.Rows.Clear();
            Txt_observaciones.Text = string.Empty;
            Tbl_Cotizacion.ReadOnly = true;
            Tbl_conectados.Rows.Clear();
        }

        private void Btn_NuevoProd_Click(object sender, EventArgs e)
        {
            try
            {
                // Crear el formulario contenedor
                using (Form formWrapper = new Form())
                {
                    formWrapper.Text = "Agregar Producto";
                    formWrapper.Size = new Size(400, 300); 
                    formWrapper.StartPosition = FormStartPosition.CenterParent;

                    var prodControl = new ProdTemporal
                    {
                        Dock = DockStyle.Fill
                    };

                    Button btnAceptar = new Button
                    {
                        Text = "Aceptar",
                        Dock = DockStyle.Bottom
                    };

                    Button btnCancelar = new Button
                    {
                        Text = "Cancelar",
                        Dock = DockStyle.Bottom,
                        DialogResult = DialogResult.Cancel 
                    };

                    btnAceptar.Click += (s, e) =>
                    {
                        if (string.IsNullOrWhiteSpace(prodControl.Descripcion))
                        {
                            MessageBox.Show("El producto debe tener descripción.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
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

                        Tbl_Cotizacion.Rows.Add(0, clave, descripcion, unidad, precioUnitario, subtotal, total, cantidad);
                        ActualizarNumeroCotizacionEnLabel();
                        ActualizarTotales();
                        ActualizarObservacionesPorProducto(descripcion, reemplazar: true);
                        HabilitarEdicionParcial();

                        // Asegura que la columna de "Eliminar" solo se agregue una vez
                        if (!Tbl_Cotizacion.Columns.Contains("Eliminar"))
                        {
                            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn
                            {
                                Name = "Eliminar",
                                HeaderText = "Acción",
                                Text = "Eliminar",
                                UseColumnTextForButtonValue = true
                            };
                            Tbl_Cotizacion.Columns.Add(btnEliminar);
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
        private void ActualizarNumeroCotizacionEnLabel()
        {
            if (Tbl_Cotizacion.Rows.Count == 0)
            {
                lbl_NoCotiza.Text = "";
                return;
            }

            string prefijo = "G"; 
            int prioridadActual = int.MaxValue;

            for (int i = Tbl_Cotizacion.Rows.Count - 1; i >= 0; i--)
            {
                if (Tbl_Cotizacion.Rows[i].IsNewRow)
                    continue;

                string descripcion = Tbl_Cotizacion.Rows[i].Cells["DESCRIPCIÓN"].Value?.ToString()?.ToUpper() ?? "";

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
            string ultimoFolio = CotizacionRepository.ObtenerUltimoFolioPorPrefijo("E");
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
            if (e.RowIndex >= 1)
            {
                var row = dgvBusqueda.Rows[e.RowIndex];
                string clave = row.Cells["CLAVE"].Value?.ToString();
                string descripcion = row.Cells["DESCRIPCIÓN"].Value?.ToString();
                decimal precio = Convert.ToDecimal(row.Cells["PRECIO"].Value?.ToString().Replace("$", "").Trim() ?? "0");
                int cantidad = 1;
                string unidad = row.Cells["UNIDAD"].Value?.ToString();
                decimal total = precio * cantidad;
                Tbl_Cotizacion.Rows.Add(0, clave, descripcion, unidad, precio, precio * cantidad, total, cantidad);
                ActualizarNumeroCotizacionEnLabel();
                ActualizarTotales();
                ActualizarObservacionesPorProducto(descripcion, reemplazar: true);
                HabilitarEdicionParcial();
                panelBusqueda.Visible = false;
                Txt_Buscar.Clear();
                int lastRow = Tbl_Cotizacion.Rows.Count - 1;
                Tbl_Cotizacion.CurrentCell = Tbl_Cotizacion.Rows[lastRow].Cells["CANTIDAD"];
                Tbl_Cotizacion.BeginEdit(true);
            }
        }

        private void Tbl_Cotizacion_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var row = Tbl_Cotizacion.Rows[e.RowIndex];
            // Evita edición en filas vacías
            if (row.IsNewRow || string.IsNullOrWhiteSpace(row.Cells["Descripción"].Value?.ToString()))
            {
                e.Cancel = true;
            }
        }
    }
}
