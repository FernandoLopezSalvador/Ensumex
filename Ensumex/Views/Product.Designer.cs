namespace Ensumex.Views
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
            txt_buscar = new MaterialSkin.Controls.MaterialTextBox2();
            label2 = new Label();
            label1 = new Label();
            cmb_productos = new ComboBox();
            tabla_productos = new DataGridView();
            btn_nuevoProducto = new MaterialSkin.Controls.MaterialButton();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tabla_productos).BeginInit();
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
            tableLayoutPanel1.Controls.Add(cmb_productos, 1, 1);
            tableLayoutPanel1.Controls.Add(btn_nuevoProducto, 1, 0);
            tableLayoutPanel1.Controls.Add(materialButton1, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(986, 170);
            tableLayoutPanel1.TabIndex = 17;
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
            txt_buscar.Location = new Point(755, 103);
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
            txt_buscar.Size = new Size(214, 48);
            txt_buscar.TabIndex = 14;
            txt_buscar.TabStop = false;
            txt_buscar.TextAlign = HorizontalAlignment.Left;
            txt_buscar.TrailingIcon = null;
            txt_buscar.UseSystemPasswordChar = false;
            txt_buscar.TextChanged += txt_buscar_TextChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(665, 117);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 13;
            label2.Text = "Registros";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(180, 117);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 11;
            label1.Text = "Mostrar:";
            // 
            // cmb_productos
            // 
            cmb_productos.Anchor = AnchorStyles.None;
            cmb_productos.FormattingEnabled = true;
            cmb_productos.Location = new Point(266, 113);
            cmb_productos.Name = "cmb_productos";
            cmb_productos.Size = new Size(205, 28);
            cmb_productos.TabIndex = 12;
            cmb_productos.SelectedIndexChanged += cmb_productos_SelectedIndexChanged;
            // 
            // tabla_productos
            // 
            tabla_productos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabla_productos.ColumnHeadersHeight = 29;
            tabla_productos.Dock = DockStyle.Fill;
            tabla_productos.Location = new Point(0, 170);
            tabla_productos.Name = "tabla_productos";
            tabla_productos.RowHeadersWidth = 51;
            tabla_productos.Size = new Size(986, 322);
            tabla_productos.TabIndex = 18;
            // 
            // btn_nuevoProducto
            // 
            btn_nuevoProducto.Anchor = AnchorStyles.None;
            btn_nuevoProducto.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_nuevoProducto.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_nuevoProducto.Depth = 0;
            btn_nuevoProducto.HighEmphasis = true;
            btn_nuevoProducto.Icon = null;
            btn_nuevoProducto.Location = new Point(325, 24);
            btn_nuevoProducto.Margin = new Padding(4, 6, 4, 6);
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
            materialButton1.Location = new Point(571, 24);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
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
            // Product
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabla_productos);
            Controls.Add(tableLayoutPanel1);
            Name = "Product";
            Size = new Size(986, 492);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tabla_productos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialTextBox2 txt_buscar;
        private Label label2;
        private Label label1;
        private ComboBox cmb_productos;
        private DataGridView tabla_productos;
        private MaterialSkin.Controls.MaterialButton btn_nuevoProducto;
        private MaterialSkin.Controls.MaterialButton materialButton1;
    }
}
