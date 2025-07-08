namespace Ensumex.Views
{
    partial class ProdTemporal
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
            button2 = new Button();
            textBox4 = new TextBox();
            txb_PrecioUnitarioTemp = new TextBox();
            txb_cantidadTemp = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txb_ClaveTemp = new TextBox();
            button1 = new Button();
            comboBox1 = new ComboBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(button2, 1, 5);
            tableLayoutPanel1.Controls.Add(textBox4, 1, 3);
            tableLayoutPanel1.Controls.Add(txb_PrecioUnitarioTemp, 1, 2);
            tableLayoutPanel1.Controls.Add(txb_cantidadTemp, 1, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(label3, 0, 2);
            tableLayoutPanel1.Controls.Add(label4, 0, 3);
            tableLayoutPanel1.Controls.Add(label5, 0, 4);
            tableLayoutPanel1.Controls.Add(txb_ClaveTemp, 1, 0);
            tableLayoutPanel1.Controls.Add(button1, 0, 5);
            tableLayoutPanel1.Controls.Add(comboBox1, 1, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(279, 318);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // button2
            // 
            button2.Location = new Point(142, 268);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 11;
            button2.Text = "Agregar";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(142, 162);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(134, 23);
            textBox4.TabIndex = 4;
            // 
            // txb_PrecioUnitarioTemp
            // 
            txb_PrecioUnitarioTemp.Location = new Point(142, 109);
            txb_PrecioUnitarioTemp.Name = "txb_PrecioUnitarioTemp";
            txb_PrecioUnitarioTemp.Size = new Size(134, 23);
            txb_PrecioUnitarioTemp.TabIndex = 3;
            // 
            // txb_cantidadTemp
            // 
            txb_cantidadTemp.Location = new Point(142, 56);
            txb_cantidadTemp.Name = "txb_cantidadTemp";
            txb_cantidadTemp.Size = new Size(134, 23);
            txb_cantidadTemp.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 0;
            label1.Text = "CLAVE:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 53);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 1;
            label2.Text = "Descripción:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(3, 106);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 2;
            label3.Text = "Precio:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 159);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 3;
            label4.Text = "Cantidad:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(3, 212);
            label5.Name = "label5";
            label5.Size = new Size(91, 15);
            label5.TabIndex = 4;
            label5.Text = "Unidad Entrada:";
            // 
            // txb_ClaveTemp
            // 
            txb_ClaveTemp.Location = new Point(142, 3);
            txb_ClaveTemp.Name = "txb_ClaveTemp";
            txb_ClaveTemp.Size = new Size(134, 23);
            txb_ClaveTemp.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(3, 268);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 7;
            button1.Text = "Cancelar";
            button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(142, 215);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(134, 23);
            comboBox1.TabIndex = 12;
            // 
            // ProdTemporal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "ProdTemporal";
            Size = new Size(279, 318);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button2;
        private TextBox textBox4;
        private TextBox txb_PrecioUnitarioTemp;
        private TextBox txb_cantidadTemp;
        private TextBox txb_ClaveTemp;
        private Button button1;
        private ComboBox comboBox1;
    }
}
