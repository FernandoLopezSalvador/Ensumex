﻿using Ensumex.Utils;
using MaterialSkin;
using MaterialSkin.Controls;
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
    public partial class ProdTemp : MaterialForm
    {
        public ProdTemp()
        {
            InitializeComponent();
            Tema.ConfigurarTema(this);
            
            cmb_Unidentrada.Items.AddRange(new object[] { "PZA", "PRODUCTO", "SERVICIO"});
        }
        private void txb_PrecioUnitarioTemp_TabIndexChanged(object sender, EventArgs e)
        {
        }
        private void txb_PrecioUnitarioTemp_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txt = sender as TextBox;
            // Permitir teclas de control (Backspace, etc.)
            if (char.IsControl(e.KeyChar))
                return;
            // Permitir solo dígitos y un punto
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Bloquear tecla
                return;
            }
            // No permitir más de un punto decimal
            if (e.KeyChar == '.' && txt.Text.Contains('.'))
            {
                e.Handled = true;
            }
        }
        private void txb_PrecioPublicoTemp_KeyPress(object sender, KeyPressEventArgs e)
        { 
        }
        private void materialButton1_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra el formulario actual
        }
        private void materialButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txb_ClaveTemp.Text) ||
                 string.IsNullOrWhiteSpace(txb_cantidadTemp.Text) ||
                 string.IsNullOrWhiteSpace(txb_PrecioUnitarioTemp.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Producto Agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        public string Clave => txb_ClaveTemp.Text.Trim();
        public string Descripcion => txb_Descripcion.Text.Trim();
        public string Unidentrada => cmb_Unidentrada.Text.Trim();
        public decimal PrecioUnitarioTemp => decimal.TryParse(txb_PrecioUnitarioTemp.Text, out decimal p) ? p : 0;
        public decimal cantidad => decimal.TryParse(txb_cantidadTemp.Text, out decimal p) ? p : 0;
        
    }
}
