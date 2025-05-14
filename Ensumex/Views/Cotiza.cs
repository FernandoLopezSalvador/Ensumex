using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Ensumex.Models;
using Ensumex.Services;
using System.Globalization;

namespace Ensumex.Views
{
    public partial class Cotiza : UserControl
    {
        public Cotiza()
        {
            InitializeComponent();
            tbl_Productos.DefaultCellStyle.ForeColor = Color.Black; // Color de texto blanco
            tbl_Productos.BackgroundColor = Color.FromArgb(45, 45, 48); // Fondo oscuro
            tbl_Cotizacion.DefaultCellStyle.ForeColor = Color.Black; // Color de texto blanco
            tbl_Cotizacion.BackgroundColor = Color.FromArgb(45, 45, 48); // Fondo oscuro    
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            CargarProductoss();
            cmb_Descuento.Items.Add("0%");
            cmb_Descuento.Items.Add("5%");
            cmb_Descuento.Items.Add("10%");
            cmb_Descuento.Items.Add("15%");
            tbl_Cotizacion.Columns.Add("Clave", "Clave");
            tbl_Cotizacion.Columns.Add("Descripcion", "Descripción");
            tbl_Cotizacion.Columns.Add("UnidadEntrada", "Unidad de Entrada");
            tbl_Cotizacion.Columns.Add("PrecioUnitario", "Precio Unitario");
            tbl_Cotizacion.Columns.Add("Cantidad", "Cantidad");
            tbl_Cotizacion.Columns.Add("TasaCambio", "Tasa de Cambio");
            tbl_Cotizacion.Columns.Add("Subtotal", "Subtotal");
            tbl_Cotizacion.Columns["TasaCambio"].ReadOnly = false;
            // Obtener instalación

        }

        private void Btn_guardarCotizacion_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo PDF|*.pdf";
                sfd.FileName = $"Cotizacion_{DateTime.Now:yyyyMMdd}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    GenerarPDFCotizacion(sfd.FileName);
                    txt_Costoflete.Text = "";
                    txt_Costoinstalacion.Text = "";
                    txt_Direccioncliente.Text = "";
                    txt_Nocotizacion.Text = "";
                    txt_Nombrecliente.Text = "";
                }
            }
        }

        private void GenerarPDFCotizacion(string rutaArchivo)
        {
            try
            {
                Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
                PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
                doc.Open();

                string rutaLogo = Path.Combine(Application.StartupPath, "IMG", "Logo.png");


                if (File.Exists(rutaLogo))
                {
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(rutaLogo);
                    logo.ScaleAbsolute(100f, 100f); // Ajusta tamaño (ancho x alto en puntos)
                    logo.SetAbsolutePosition(doc.LeftMargin, doc.PageSize.Height - doc.TopMargin - 50f); // Esquina superior izquierda
                    doc.Add(logo);
                }

                // Fuente personalizada
                var fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                var fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                var fontNegrita = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);

                // Encabezado
                Paragraph encabezado = new Paragraph(new Paragraph("\nOaxaca de Juárez, Oaxaca a " + DateTime.Now.ToString("d 'de' MMMM 'de' yyyy") + "\n\n", fontNormal));
                encabezado.Alignment = Element.ALIGN_RIGHT;
                doc.Add(encabezado);

                // saludos 
                //doc.Add(new Paragraph("\nEstimado Cliente:" + txt_Nombrecliente.Text, fontNegrita));
                if (!string.IsNullOrWhiteSpace(txt_Nombrecliente.Text))
                {
                    doc.Add(new Paragraph("\nEstimado Cliente: " + txt_Nombrecliente.Text, fontNegrita));
                }
                else
                {
                    doc.Add(new Paragraph("\nEstimado Cliente:", fontNegrita));
                }
                doc.Add(new Paragraph("\nPresente"));
                doc.Add(new Paragraph("En atención a su amable solicitud, me permito presentarle esta cotización para la venta e instalación del siguiente producto:", fontNormal));
                doc.Add(new Paragraph("\n", fontNormal));

                // Crear tabla con columnas
                PdfPTable tabla = new PdfPTable(4); // Ajusta columnas según tus datos
                tabla.WidthPercentage = 100;
                tabla.SetWidths(new float[] { 1f, 3f, 1.5f, 1f });

                // Encabezados de tabla
                string[] headers = { "Clave", "Descripción", "Precio Unitario", "Cantidad", };

                foreach (string header in headers)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(header, fontNormal));
                    celda.BackgroundColor = BaseColor.LIGHT_GRAY;
                    celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabla.AddCell(celda);
                }
                // Agregar filas desde el DataGridView
                foreach (DataGridViewRow row in tbl_Cotizacion.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        tabla.AddCell(new Phrase(row.Cells["Clave"].Value?.ToString() ?? "", fontNormal));
                        tabla.AddCell(new Phrase(row.Cells["Descripcion"].Value?.ToString() ?? "", fontNormal));
                        tabla.AddCell(new Phrase(row.Cells["PrecioUnitario"].Value?.ToString() ?? "", fontNormal));
                        tabla.AddCell(new Phrase(row.Cells["Cantidad"].Value?.ToString() ?? "", fontNormal));
                    }
                }

                PdfPCell celdaInstalacion = new PdfPCell(new Phrase("MANO DE OBRA POR INSTALACIÓN", fontNormal));
                celdaInstalacion.Colspan = 3;
                celdaInstalacion.HorizontalAlignment = Element.ALIGN_RIGHT;
                tabla.AddCell(celdaInstalacion);
                tabla.AddCell(new Phrase(txt_Costoinstalacion.Text, fontNormal)); // Usando TextBox

                // Costo de flete
                PdfPCell celdaFlete = new PdfPCell(new Phrase("Costo por Envio/Flete", fontNormal));
                celdaFlete.Colspan = 3;
                celdaFlete.HorizontalAlignment = Element.ALIGN_RIGHT;
                tabla.AddCell(celdaFlete);
                tabla.AddCell(new Phrase(txt_Costoflete.Text, fontNormal)); // Usando TextBox

                // Descuento
                PdfPCell celdaDescuento = new PdfPCell(new Phrase("Descuento", fontNormal));
                celdaDescuento.Colspan = 3;
                celdaDescuento.HorizontalAlignment = Element.ALIGN_RIGHT;
                tabla.AddCell(celdaDescuento);
                tabla.AddCell(new Phrase(lbl_costoDescuento.Text, fontNormal));

                // Subtotal
                PdfPCell celdaSubtotal = new PdfPCell(new Phrase("Subtotal", fontNegrita));
                celdaSubtotal.Colspan = 3;
                celdaSubtotal.HorizontalAlignment = Element.ALIGN_RIGHT;
                tabla.AddCell(celdaSubtotal);
                tabla.AddCell(new Phrase(lbl_Subtotal.Text, fontNormal));

                // Total
                PdfPCell celdaTotal = new PdfPCell(new Phrase("Total", fontNegrita));
                celdaTotal.Colspan = 3;
                celdaTotal.HorizontalAlignment = Element.ALIGN_RIGHT;
                tabla.AddCell(celdaTotal);
                tabla.AddCell(new Phrase(lbl_TotalNeto.Text, fontNormal));

                doc.Add(tabla);
                doc.Add(new Paragraph("\n"));

                doc.Add(new Paragraph("Nota: Se requiere depósito del 50% para confirmar pedido. Instalación el mismo día o siguiente día hábil. Garantía: 3 años contra defectos de fabricación.", fontNormal));
                doc.Add(new Paragraph("\n"));


                doc.Add(new Paragraph("NOTAS:\n", fontNegrita));
                doc.Add(new Paragraph(
                "- Garantía: 5 años contra defectos de fabricación. La garantía aplica únicamente para el termo tanque. No aplica la garantía por omisión en los cuidados que requiere el equipo, de acuerdo al manual de instalación y garantía que se entrega.\n" +
                "- Garantía de la mano de obra: 6 meses contra fugas de agua.\n\n" +
                "- Equipos en existencia para entrega inmediata.\n\n" +
                "- No incluye material de plomería.\n\n" +
                "- Si necesita factura, la mano de obra se agrega más I.V.A.\n\n" +
                "- Precios sujetos a cambios sin previo aviso.\n\n" +
                "Sin otro particular, quedo a sus órdenes.\n\n\n\n\n\n\n\n", fontNormal));

                Paragraph saludo = new Paragraph("Atentamente,\n", fontNormal);
                saludo.Alignment = Element.ALIGN_CENTER;
                doc.Add(saludo);

                Paragraph nombre = new Paragraph("Mario Valdez", fontNormal);
                nombre.Alignment = Element.ALIGN_CENTER;
                doc.Add(nombre);

                Paragraph cargo = new Paragraph("Representante de Ventas", fontNormal);
                cargo.Alignment = Element.ALIGN_CENTER;
                doc.Add(cargo);

                string rutaFirma = Path.Combine(Application.StartupPath, "IMG", "nombre.jpg");

                if (File.Exists(rutaFirma))
                {
                    iTextSharp.text.Image firma = iTextSharp.text.Image.GetInstance(rutaFirma);
                    firma.ScaleAbsolute(120f, 60f); // Tamaño fijo

                    // Esta línea centra la imagen sin usar coordenadas absolutas
                    firma.Alignment = Element.ALIGN_CENTER;

                    doc.Add(firma); // Se insertará justo debajo del texto anterior
                }


                Paragraph direc = new Paragraph("Av. Lázaro Cárdenas 104-B. ", fontNormal);
                direc.Alignment = Element.ALIGN_CENTER;
                doc.Add(direc);

                Paragraph ubi = new Paragraph("Sta. Lucía del Camino, Oaxaca. Tels: 951-206-6895 y 951-206-0293", fontNormal);
                ubi.Alignment = Element.ALIGN_CENTER;
                doc.Add(ubi);

                doc.Close();

                MessageBox.Show("📄 PDF generado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (IOException ex)
            {
                MessageBox.Show("No se puede guardar el archivo porque está abierto en otro programa. Por favor, ciérralo e inténtalo de nuevo.", "Archivo en uso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("No tienes permisos para guardar el archivo en esta ubicación. Por favor, elige otra carpeta o verifica tus permisos.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al generar el PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void CargarProductoss(int? limite = 100)
        {
            try
            {
                var productoService = new ProductoServices1();
                var productos = productoService.ObtenerProductos(limite);
                // Configura el DataGridView
                tbl_Productos.DataSource = productos.Select(p => new
                {
                    Clave = p.CLAVE,
                    Descripcion = p.Descripcion,
                    UnidadEntrada = p.UnidadEntrada,
                    PrecioUnitario = p.PU,
                }).ToList();
                if (!tbl_Productos.Columns.Contains("Agregar"))
                {
                    DataGridViewButtonColumn btnAgregar = new DataGridViewButtonColumn();
                    btnAgregar.Name = "Agregar";
                    btnAgregar.HeaderText = "Acción";
                    btnAgregar.Text = "Agregar";
                    btnAgregar.UseColumnTextForButtonValue = true;
                    tbl_Productos.Columns.Add(btnAgregar);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_Cancelarcotizacion_Click(object sender, EventArgs e)
        {
            txt_Costoflete.Text = "";
            txt_Costoinstalacion.Text = "";
            txt_Direccioncliente.Text = "";
            txt_Nocotizacion.Text = "";
            txt_Nombrecliente.Text = "";
        }

        private void tbl_Productos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == tbl_Productos.Columns["Agregar"].Index && e.RowIndex >= 0)
            {
                // Obtén los datos de la fila seleccionada
                var fila = tbl_Productos.Rows[e.RowIndex];
                string clave = fila.Cells["Clave"].Value.ToString();
                string descripcion = fila.Cells["Descripcion"].Value.ToString();
                string unidad = fila.Cells["UnidadEntrada"].Value.ToString();
                decimal precio = Convert.ToDecimal(fila.Cells["PrecioUnitario"].Value);
                // Agrega una nueva fila a tbl_Cotizacion con los datos
                tbl_Cotizacion.Rows.Add(clave, descripcion, unidad, precio, 1, 1, precio); // 1 cantidad por default
                ActualizarTotales();

            }
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
        private void CalcularSubtotal()
        {
            decimal subtotal = 0;
            foreach (DataGridViewRow row in tbl_Cotizacion.Rows)
            {
                if (row.Cells["Subtotal"].Value != null)
                {
                    decimal precio;
                    if (decimal.TryParse(row.Cells["Subtotal"].Value.ToString(), out precio))
                    {
                        subtotal += precio;
                    }
                }
            }
            lbl_Subtotal.Text = $"Subtotal: ${subtotal:F2}";
            ActualizarTotalNeto();

        }

        private void tbl_Cotizacion_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == tbl_Cotizacion.Columns["Cantidad"].Index ||
        e.ColumnIndex == tbl_Cotizacion.Columns["TasaCambio"].Index)
            {
                var row = tbl_Cotizacion.Rows[e.RowIndex];

                if (decimal.TryParse(row.Cells["PrecioUnitario"].Value?.ToString(), out decimal precio) &&
                    decimal.TryParse(row.Cells["Cantidad"].Value?.ToString(), out decimal cantidad) &&
                    decimal.TryParse(row.Cells["TasaCambio"].Value?.ToString(), out decimal tasa))
                {
                    decimal subtotal = precio * cantidad * tasa;
                    row.Cells["Subtotal"].Value = subtotal;

                    ActualizarTotales();
                }
            }
        }

        private void cmb_Descuento_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*AplicarDescuento();
            ActualizarTotalNeto();*/
            ActualizarTotales();
        }
        private void AplicarDescuento()
        {
            if (decimal.TryParse(lbl_Subtotal.Text.Replace("Subtotal: $", ""), out decimal subtotal))
            {
                decimal descuento = 0;
                switch (cmb_Descuento.SelectedItem.ToString())
                {
                    case "0%":
                        descuento = 0;
                        break;
                    case "5%":
                        descuento = subtotal * 0.05m;
                        break;
                    case "10%":
                        descuento = subtotal * 0.10m;
                        break;
                    case "15%":
                        descuento = subtotal * 0.15m;
                        break;
                }

                // Mostrar solo el valor del descuento
                lbl_costoDescuento.Text = $"{descuento:F2}";
                ActualizarTotales();
            }
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

        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbl_Cotizacion_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegúrate de no estar en encabezado ni fuera de rango
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

        private void ActualizarTotalNeto()
        {
            try
            {
                // Obtener valores de los labels y textbox, con manejo de errores si están vacíos
                decimal subtotal = decimal.TryParse(lbl_Subtotal.Text, out var sub) ? sub : 0;
                decimal descuento = decimal.TryParse(lbl_costoDescuento.Text, out var desc) ? desc : 0;
                decimal instalacion = decimal.TryParse(txt_Costoinstalacion.Text, out var inst) ? inst : 0;
                decimal flete = decimal.TryParse(txt_Costoflete.Text, out var flt) ? flt : 0;

                // Calcular total neto
                decimal totalNeto = subtotal - descuento + instalacion + flete;

                // Mostrar resultado con formato
                lbl_TotalNeto.Text = totalNeto.ToString("C"); // Ej: $1,200.00
            }
            catch
            {
                lbl_TotalNeto.Text = "Error";
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
                subtotal = 0; // Reiniciar subtotal para evitar acumulaciones previas
                foreach (DataGridViewRow row in tbl_Cotizacion.Rows)
                {
                    if (row.Cells["Subtotal"].Value != null &&
                        decimal.TryParse(row.Cells["Subtotal"].Value.ToString(), out decimal valor))
                    {
                        subtotal += valor;
                    }
                }
                lbl_Subtotal.Text = $"Subtotal: ${subtotal:F2}";

                // 2. Calcular Descuento
                descuento = 0; // Reiniciar descuento
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
                lbl_TotalNeto.Text = totalNeto.ToString("C"); // Ej: $1,200.00
            }
            catch (Exception ex)
            {
                lbl_TotalNeto.Text = "Error";
                // Opcional: mostrar mensaje de error detallado
                MessageBox.Show($"Se produjo un error al calcular el total: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
