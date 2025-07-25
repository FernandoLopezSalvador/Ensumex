﻿namespace Ensumex.Views
{
    partial class Product
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            cmb_productos = new ComboBox();
            label2 = new Label();
            btn_existencias = new CheckBox();
            text_buscar = new TextBox();
            Btn_DescargarProd = new FontAwesome.Sharp.IconButton();
            tabla_productos = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tabla_productos).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.Control;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Controls.Add(cmb_productos, 2, 0);
            tableLayoutPanel1.Controls.Add(label2, 1, 1);
            tableLayoutPanel1.Controls.Add(btn_existencias, 3, 1);
            tableLayoutPanel1.Controls.Add(text_buscar, 2, 1);
            tableLayoutPanel1.Controls.Add(Btn_DescargarProd, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.ForeColor = SystemColors.ControlText;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(863, 128);
            tableLayoutPanel1.TabIndex = 17;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(353, 21);
            label1.Name = "label1";
            label1.Size = new Size(74, 21);
            label1.TabIndex = 11;
            label1.Text = "Mostrar:";
            // 
            // cmb_productos
            // 
            cmb_productos.Anchor = AnchorStyles.None;
            cmb_productos.FormattingEnabled = true;
            cmb_productos.Location = new Point(447, 20);
            cmb_productos.Margin = new Padding(3, 2, 3, 2);
            cmb_productos.Name = "cmb_productos";
            cmb_productos.Size = new Size(180, 23);
            cmb_productos.TabIndex = 12;
            cmb_productos.SelectedIndexChanged += cmb_productos_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(347, 85);
            label2.Name = "label2";
            label2.Size = new Size(80, 21);
            label2.TabIndex = 13;
            label2.Text = "Registros";
            // 
            // btn_existencias
            // 
            btn_existencias.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btn_existencias.AutoSize = true;
            btn_existencias.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_existencias.Location = new Point(648, 84);
            btn_existencias.Name = "btn_existencias";
            btn_existencias.Size = new Size(212, 24);
            btn_existencias.TabIndex = 18;
            btn_existencias.Text = "Mostrar solo en existencia";
            btn_existencias.UseVisualStyleBackColor = true;
            btn_existencias.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // text_buscar
            // 
            text_buscar.Anchor = AnchorStyles.None;
            text_buscar.Location = new Point(446, 84);
            text_buscar.Name = "text_buscar";
            text_buscar.Size = new Size(183, 23);
            text_buscar.TabIndex = 1;
            text_buscar.TextChanged += textBox1_TextChanged;
            // 
            // Btn_DescargarProd
            // 
            Btn_DescargarProd.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            Btn_DescargarProd.IconChar = FontAwesome.Sharp.IconChar.None;
            Btn_DescargarProd.IconColor = Color.Black;
            Btn_DescargarProd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Btn_DescargarProd.Location = new Point(3, 67);
            Btn_DescargarProd.Name = "Btn_DescargarProd";
            Btn_DescargarProd.Size = new Size(209, 58);
            Btn_DescargarProd.TabIndex = 19;
            Btn_DescargarProd.Text = "Descargar.";
            Btn_DescargarProd.UseVisualStyleBackColor = true;
            Btn_DescargarProd.Click += Btn_DescargarProd_Click;
            // 
            // tabla_productos
            // 
            tabla_productos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabla_productos.ColumnHeadersHeight = 29;
            tabla_productos.Dock = DockStyle.Fill;
            tabla_productos.Location = new Point(0, 128);
            tabla_productos.Margin = new Padding(3, 2, 3, 2);
            tabla_productos.Name = "tabla_productos";
            tabla_productos.RowHeadersWidth = 51;
            tabla_productos.Size = new Size(863, 241);
            tabla_productos.TabIndex = 18;
            tabla_productos.KeyDown += tabla_productos_KeyDown;
            // 
            // Product
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabla_productos);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Product";
            Size = new Size(863, 369);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tabla_productos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private Label label1;
        private ComboBox cmb_productos;
        private DataGridView tabla_productos;
        private CheckBox btn_existencias;
        private TextBox text_buscar;
        private FontAwesome.Sharp.IconButton Btn_DescargarProd;
    }
}
