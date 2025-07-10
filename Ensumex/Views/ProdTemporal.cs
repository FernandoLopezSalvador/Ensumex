using DocumentFormat.OpenXml.Spreadsheet;
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
    public partial class ProdTemporal : UserControl
    {
        public ProdTemporal()
        {
            InitializeComponent();
            Cmb_Unidadentrada.Items.AddRange(new object[] { "PZA", "PRODUCTO", "SERVICIO" });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_ClaveTemp.Text) ||
                 string.IsNullOrWhiteSpace(txb_cantidadTemp.Text) ||
                 string.IsNullOrWhiteSpace(txb_PrecioUnitarioTemp.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Producto Agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txb_PrecioUnitarioTemp_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaemoneda(sender, e);
        }
        private void Validaemoneda(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, punto decimal y retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Ignorar la entrada
            }
            // Permitir solo un punto decimal
            if (e.KeyChar == '.' && sender is TextBox textBox && textBox.Text.Contains('.'))
            {
                e.Handled = true; // Ignorar la entrada
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
                txt.Text = valor.ToString("N2");
            }
            else
            {
                MessageBox.Show("Por favor ingresa un valor numérico válido.", "Formato inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt.Focus();
                txt.SelectAll();
            }
        }

        private void txb_PrecioUnitarioTemp_Leave(object sender, EventArgs e)
        {
            ValidarYFormatearMoneda_Leave(sender, e);
        }

        private void txb_cantidadTemp_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, punto decimal y retroceso
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignorar la entrada
            }
        }

        public string Clave => txb_ClaveTemp.Text.Trim();
        public string Descripcion => txb_Descripcion.Text.Trim();
        public string Unidentrada => Cmb_Unidadentrada.Text.Trim();
        public decimal PrecioUnitarioTemp => decimal.TryParse(txb_PrecioUnitarioTemp.Text, out decimal p) ? p : 0;
        public int cantidad => int.TryParse(txb_cantidadTemp.Text, out int p) ? p : 0;
    }
}
