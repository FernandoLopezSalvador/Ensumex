namespace Ensumex.Views
{
    partial class Clients
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
            label2 = new Label();
            ImprimirClientes = new MaterialSkin.Controls.MaterialButton();
            cmb_clientes = new ComboBox();
            text_buscar = new TextBox();
            tabla_clientes = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tabla_clientes).BeginInit();
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
            tableLayoutPanel1.Controls.Add(label2, 1, 1);
            tableLayoutPanel1.Controls.Add(ImprimirClientes, 0, 1);
            tableLayoutPanel1.Controls.Add(cmb_clientes, 2, 0);
            tableLayoutPanel1.Controls.Add(text_buscar, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.ForeColor = SystemColors.ControlText;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(863, 128);
            tableLayoutPanel1.TabIndex = 18;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(353, 21);
            label1.Name = "label1";
            label1.Size = new Size(74, 21);
            label1.TabIndex = 11;
            label1.Text = "Mostrar:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(362, 85);
            label2.Name = "label2";
            label2.Size = new Size(65, 21);
            label2.TabIndex = 13;
            label2.Text = "Buscar:";
            // 
            // ImprimirClientes
            // 
            ImprimirClientes.Anchor = AnchorStyles.None;
            ImprimirClientes.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ImprimirClientes.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            ImprimirClientes.Depth = 0;
            ImprimirClientes.HighEmphasis = true;
            ImprimirClientes.Icon = null;
            ImprimirClientes.Location = new Point(64, 78);
            ImprimirClientes.Margin = new Padding(4);
            ImprimirClientes.MouseState = MaterialSkin.MouseState.HOVER;
            ImprimirClientes.Name = "ImprimirClientes";
            ImprimirClientes.NoAccentTextColor = Color.Empty;
            ImprimirClientes.Size = new Size(87, 36);
            ImprimirClientes.TabIndex = 16;
            ImprimirClientes.Text = "Imprimir";
            ImprimirClientes.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            ImprimirClientes.UseAccentColor = false;
            ImprimirClientes.UseVisualStyleBackColor = true;
            ImprimirClientes.Click += materialButton1_Click;
            // 
            // cmb_clientes
            // 
            cmb_clientes.Anchor = AnchorStyles.None;
            cmb_clientes.FormattingEnabled = true;
            cmb_clientes.Location = new Point(447, 20);
            cmb_clientes.Margin = new Padding(3, 2, 3, 2);
            cmb_clientes.Name = "cmb_clientes";
            cmb_clientes.Size = new Size(180, 23);
            cmb_clientes.TabIndex = 12;
            cmb_clientes.SelectedIndexChanged += cmb_clientes_SelectedIndexChanged;
            // 
            // text_buscar
            // 
            text_buscar.Anchor = AnchorStyles.None;
            text_buscar.Location = new Point(450, 84);
            text_buscar.Name = "text_buscar";
            text_buscar.Size = new Size(175, 23);
            text_buscar.TabIndex = 1;
            text_buscar.TextChanged += textBox1_TextChanged;
            // 
            // tabla_clientes
            // 
            tabla_clientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabla_clientes.ColumnHeadersHeight = 29;
            tabla_clientes.Dock = DockStyle.Fill;
            tabla_clientes.Location = new Point(0, 128);
            tabla_clientes.Margin = new Padding(3, 2, 3, 2);
            tabla_clientes.Name = "tabla_clientes";
            tabla_clientes.RowHeadersWidth = 51;
            tabla_clientes.Size = new Size(863, 241);
            tabla_clientes.TabIndex = 19;
            tabla_clientes.CellDoubleClick += tabla_clientes_CellDoubleClick_1;
            // 
            // Clients
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabla_clientes);
            Controls.Add(tableLayoutPanel1);
            Name = "Clients";
            Size = new Size(863, 369);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tabla_clientes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private Label label1;
        private ComboBox cmb_clientes;
        private MaterialSkin.Controls.MaterialButton ImprimirClientes;
        private DataGridView tabla_clientes;
        private TextBox text_buscar;
    }
}
