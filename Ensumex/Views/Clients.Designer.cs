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
            txt_buscar = new MaterialSkin.Controls.MaterialTextBox2();
            label2 = new Label();
            label1 = new Label();
            cmb_clientes = new ComboBox();
            btn_nuevoProducto = new MaterialSkin.Controls.MaterialButton();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            tabla_clientes = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tabla_clientes).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(txt_buscar, 3, 1);
            tableLayoutPanel1.Controls.Add(label2, 2, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 1);
            tableLayoutPanel1.Controls.Add(cmb_clientes, 1, 1);
            tableLayoutPanel1.Controls.Add(btn_nuevoProducto, 1, 0);
            tableLayoutPanel1.Controls.Add(materialButton1, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(863, 128);
            tableLayoutPanel1.TabIndex = 18;
            // 
            // txt_buscar
            // 
            txt_buscar.Anchor = AnchorStyles.None;
            txt_buscar.AnimateReadOnly = false;
            txt_buscar.BackgroundImageLayout = ImageLayout.None;
            txt_buscar.CharacterCasing = CharacterCasing.Normal;
            txt_buscar.Depth = 0;
            txt_buscar.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txt_buscar.HideSelection = true;
            txt_buscar.LeadingIcon = null;
            txt_buscar.Location = new Point(732, 72);
            txt_buscar.Margin = new Padding(3, 2, 3, 2);
            txt_buscar.MaxLength = 32767;
            txt_buscar.MouseState = MaterialSkin.MouseState.OUT;
            txt_buscar.Name = "txt_buscar";
            txt_buscar.PasswordChar = '\0';
            txt_buscar.PrefixSuffixText = null;
            txt_buscar.ReadOnly = false;
            txt_buscar.RightToLeft = RightToLeft.No;
            txt_buscar.SelectedText = "";
            txt_buscar.SelectionLength = 0;
            txt_buscar.SelectionStart = 0;
            txt_buscar.ShortcutsEnabled = true;
            txt_buscar.Size = new Size(44, 48);
            txt_buscar.TabIndex = 14;
            txt_buscar.TabStop = false;
            txt_buscar.TextAlign = HorizontalAlignment.Left;
            txt_buscar.TrailingIcon = null;
            txt_buscar.UseSystemPasswordChar = false;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(587, 88);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 13;
            label2.Text = "Registros";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(161, 88);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 11;
            label1.Text = "Mostrar:";
            // 
            // cmb_clientes
            // 
            cmb_clientes.Anchor = AnchorStyles.None;
            cmb_clientes.FormattingEnabled = true;
            cmb_clientes.Location = new Point(232, 84);
            cmb_clientes.Margin = new Padding(3, 2, 3, 2);
            cmb_clientes.Name = "cmb_clientes";
            cmb_clientes.Size = new Size(180, 23);
            cmb_clientes.TabIndex = 12;
            // 
            // btn_nuevoProducto
            // 
            btn_nuevoProducto.Anchor = AnchorStyles.None;
            btn_nuevoProducto.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_nuevoProducto.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_nuevoProducto.Depth = 0;
            btn_nuevoProducto.HighEmphasis = true;
            btn_nuevoProducto.Icon = null;
            btn_nuevoProducto.Location = new Point(278, 14);
            btn_nuevoProducto.Margin = new Padding(4);
            btn_nuevoProducto.MouseState = MaterialSkin.MouseState.HOVER;
            btn_nuevoProducto.Name = "btn_nuevoProducto";
            btn_nuevoProducto.NoAccentTextColor = Color.Empty;
            btn_nuevoProducto.Size = new Size(88, 36);
            btn_nuevoProducto.TabIndex = 15;
            btn_nuevoProducto.Text = "Agregar";
            btn_nuevoProducto.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_nuevoProducto.UseAccentColor = false;
            btn_nuevoProducto.UseVisualStyleBackColor = true;
            // 
            // materialButton1
            // 
            materialButton1.Anchor = AnchorStyles.None;
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(494, 14);
            materialButton1.Margin = new Padding(4);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(87, 36);
            materialButton1.TabIndex = 16;
            materialButton1.Text = "Imprimir";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
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
        private MaterialSkin.Controls.MaterialTextBox2 txt_buscar;
        private Label label2;
        private Label label1;
        private ComboBox cmb_clientes;
        private MaterialSkin.Controls.MaterialButton btn_nuevoProducto;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private DataGridView tabla_clientes;
    }
}
