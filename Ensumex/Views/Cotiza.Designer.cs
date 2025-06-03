namespace Ensumex.Views
{
    partial class Cotiza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cotiza));
            tableLayoutPanel1 = new TableLayoutPanel();
            materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            txt_Nocotizacion = new MaterialSkin.Controls.MaterialTextBox2();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            txt_Costoflete = new MaterialSkin.Controls.MaterialTextBox2();
            txt_Nombrecliente = new MaterialSkin.Controls.MaterialTextBox2();
            materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            txt_Costoinstalacion = new MaterialSkin.Controls.MaterialTextBox2();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            btn_Cancelarcotizacion = new MaterialSkin.Controls.MaterialButton();
            btn_AgregarProducto = new MaterialSkin.Controls.MaterialButton();
            Btn_guardarCotizacion = new MaterialSkin.Controls.MaterialButton();
            lblFecha = new Label();
            materialLabel10 = new MaterialSkin.Controls.MaterialLabel();
            cmb_Descuento = new MaterialSkin.Controls.MaterialComboBox();
            materialLabel11 = new MaterialSkin.Controls.MaterialLabel();
            lbl_costoDescuento = new MaterialSkin.Controls.MaterialLabel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            lbl_TotalNeto = new MaterialSkin.Controls.MaterialLabel();
            txt_Direccioncliente = new MaterialSkin.Controls.MaterialTextBox2();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            lbl_Subtotal = new MaterialSkin.Controls.MaterialLabel();
            materialLabel9 = new MaterialSkin.Controls.MaterialLabel();
            lbl_Bases = new MaterialSkin.Controls.MaterialLabel();
            txt_Bases = new MaterialSkin.Controls.MaterialMaskedTextBox();
            pictureBox1 = new PictureBox();
            txt_Buscarentabla = new MaterialSkin.Controls.MaterialMaskedTextBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            tbl_Productos = new DataGridView();
            tbl_Cotizacion = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbl_Productos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tbl_Cotizacion).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.9825706F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.5599136F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.2396517F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.7755985F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.Controls.Add(materialLabel2, 0, 0);
            tableLayoutPanel1.Controls.Add(txt_Nocotizacion, 1, 0);
            tableLayoutPanel1.Controls.Add(materialLabel4, 0, 1);
            tableLayoutPanel1.Controls.Add(txt_Costoflete, 3, 2);
            tableLayoutPanel1.Controls.Add(txt_Nombrecliente, 1, 1);
            tableLayoutPanel1.Controls.Add(materialLabel7, 2, 2);
            tableLayoutPanel1.Controls.Add(txt_Costoinstalacion, 1, 2);
            tableLayoutPanel1.Controls.Add(materialLabel6, 0, 2);
            tableLayoutPanel1.Controls.Add(materialLabel3, 2, 0);
            tableLayoutPanel1.Controls.Add(btn_Cancelarcotizacion, 3, 4);
            tableLayoutPanel1.Controls.Add(btn_AgregarProducto, 5, 4);
            tableLayoutPanel1.Controls.Add(Btn_guardarCotizacion, 4, 4);
            tableLayoutPanel1.Controls.Add(lblFecha, 3, 0);
            tableLayoutPanel1.Controls.Add(materialLabel10, 2, 3);
            tableLayoutPanel1.Controls.Add(cmb_Descuento, 3, 3);
            tableLayoutPanel1.Controls.Add(materialLabel11, 4, 2);
            tableLayoutPanel1.Controls.Add(lbl_costoDescuento, 5, 2);
            tableLayoutPanel1.Controls.Add(materialLabel1, 4, 3);
            tableLayoutPanel1.Controls.Add(lbl_TotalNeto, 5, 3);
            tableLayoutPanel1.Controls.Add(txt_Direccioncliente, 5, 1);
            tableLayoutPanel1.Controls.Add(materialLabel5, 4, 1);
            tableLayoutPanel1.Controls.Add(lbl_Subtotal, 1, 4);
            tableLayoutPanel1.Controls.Add(materialLabel9, 0, 4);
            tableLayoutPanel1.Controls.Add(lbl_Bases, 0, 3);
            tableLayoutPanel1.Controls.Add(txt_Bases, 1, 3);
            tableLayoutPanel1.Controls.Add(pictureBox1, 2, 1);
            tableLayoutPanel1.Controls.Add(txt_Buscarentabla, 2, 4);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20.2643166F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 19.38326F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Size = new Size(918, 227);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // materialLabel2
            // 
            materialLabel2.Anchor = AnchorStyles.Right;
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(7, 13);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(100, 19);
            materialLabel2.TabIndex = 0;
            materialLabel2.Text = "No.Cotización";
            // 
            // txt_Nocotizacion
            // 
            txt_Nocotizacion.AnimateReadOnly = false;
            txt_Nocotizacion.BackgroundImageLayout = ImageLayout.None;
            txt_Nocotizacion.CharacterCasing = CharacterCasing.Normal;
            txt_Nocotizacion.Depth = 0;
            txt_Nocotizacion.Dock = DockStyle.Fill;
            txt_Nocotizacion.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txt_Nocotizacion.HideSelection = true;
            txt_Nocotizacion.LeadingIcon = null;
            txt_Nocotizacion.Location = new Point(113, 2);
            txt_Nocotizacion.Margin = new Padding(3, 2, 3, 2);
            txt_Nocotizacion.MaxLength = 32767;
            txt_Nocotizacion.MouseState = MaterialSkin.MouseState.OUT;
            txt_Nocotizacion.Name = "txt_Nocotizacion";
            txt_Nocotizacion.PasswordChar = '\0';
            txt_Nocotizacion.PrefixSuffixText = null;
            txt_Nocotizacion.ReadOnly = false;
            txt_Nocotizacion.RightToLeft = RightToLeft.No;
            txt_Nocotizacion.SelectedText = "";
            txt_Nocotizacion.SelectionLength = 0;
            txt_Nocotizacion.SelectionStart = 0;
            txt_Nocotizacion.ShortcutsEnabled = true;
            txt_Nocotizacion.Size = new Size(247, 48);
            txt_Nocotizacion.TabIndex = 1;
            txt_Nocotizacion.TabStop = false;
            txt_Nocotizacion.TextAlign = HorizontalAlignment.Left;
            txt_Nocotizacion.TrailingIcon = null;
            txt_Nocotizacion.UseSystemPasswordChar = false;
            // 
            // materialLabel4
            // 
            materialLabel4.Anchor = AnchorStyles.Right;
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(54, 58);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(53, 19);
            materialLabel4.TabIndex = 5;
            materialLabel4.Text = "Cliente:";
            // 
            // txt_Costoflete
            // 
            txt_Costoflete.AnimateReadOnly = false;
            txt_Costoflete.BackgroundImageLayout = ImageLayout.None;
            txt_Costoflete.CharacterCasing = CharacterCasing.Normal;
            txt_Costoflete.Depth = 0;
            txt_Costoflete.Dock = DockStyle.Fill;
            txt_Costoflete.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txt_Costoflete.HideSelection = true;
            txt_Costoflete.LeadingIcon = null;
            txt_Costoflete.Location = new Point(460, 93);
            txt_Costoflete.Margin = new Padding(3, 2, 3, 2);
            txt_Costoflete.MaxLength = 32767;
            txt_Costoflete.MouseState = MaterialSkin.MouseState.OUT;
            txt_Costoflete.Name = "txt_Costoflete";
            txt_Costoflete.PasswordChar = '\0';
            txt_Costoflete.PrefixSuffixText = null;
            txt_Costoflete.ReadOnly = false;
            txt_Costoflete.RightToLeft = RightToLeft.No;
            txt_Costoflete.SelectedText = "";
            txt_Costoflete.SelectionLength = 0;
            txt_Costoflete.SelectionStart = 0;
            txt_Costoflete.ShortcutsEnabled = true;
            txt_Costoflete.Size = new Size(148, 48);
            txt_Costoflete.TabIndex = 5;
            txt_Costoflete.TabStop = false;
            txt_Costoflete.TextAlign = HorizontalAlignment.Left;
            txt_Costoflete.TrailingIcon = null;
            txt_Costoflete.UseSystemPasswordChar = false;
            txt_Costoflete.KeyPress += txt_Costoflete_KeyPress;
            txt_Costoflete.TextChanged += txt_Costoflete_TextChanged;
            // 
            // txt_Nombrecliente
            // 
            txt_Nombrecliente.AnimateReadOnly = false;
            txt_Nombrecliente.BackgroundImageLayout = ImageLayout.None;
            txt_Nombrecliente.CharacterCasing = CharacterCasing.Normal;
            txt_Nombrecliente.Depth = 0;
            txt_Nombrecliente.Dock = DockStyle.Fill;
            txt_Nombrecliente.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txt_Nombrecliente.HideSelection = true;
            txt_Nombrecliente.LeadingIcon = null;
            txt_Nombrecliente.Location = new Point(113, 47);
            txt_Nombrecliente.Margin = new Padding(3, 2, 3, 2);
            txt_Nombrecliente.MaxLength = 32767;
            txt_Nombrecliente.MouseState = MaterialSkin.MouseState.OUT;
            txt_Nombrecliente.Name = "txt_Nombrecliente";
            txt_Nombrecliente.PasswordChar = '\0';
            txt_Nombrecliente.PrefixSuffixText = null;
            txt_Nombrecliente.ReadOnly = false;
            txt_Nombrecliente.RightToLeft = RightToLeft.No;
            txt_Nombrecliente.SelectedText = "";
            txt_Nombrecliente.SelectionLength = 0;
            txt_Nombrecliente.SelectionStart = 0;
            txt_Nombrecliente.ShortcutsEnabled = true;
            txt_Nombrecliente.Size = new Size(247, 48);
            txt_Nombrecliente.TabIndex = 2;
            txt_Nombrecliente.TabStop = false;
            txt_Nombrecliente.TextAlign = HorizontalAlignment.Left;
            txt_Nombrecliente.TrailingIcon = null;
            txt_Nombrecliente.UseSystemPasswordChar = false;
            // 
            // materialLabel7
            // 
            materialLabel7.Anchor = AnchorStyles.Right;
            materialLabel7.AutoSize = true;
            materialLabel7.Depth = 0;
            materialLabel7.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel7.Location = new Point(415, 103);
            materialLabel7.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel7.Name = "materialLabel7";
            materialLabel7.Size = new Size(39, 19);
            materialLabel7.TabIndex = 12;
            materialLabel7.Text = "Flete:";
            // 
            // txt_Costoinstalacion
            // 
            txt_Costoinstalacion.AnimateReadOnly = false;
            txt_Costoinstalacion.BackgroundImageLayout = ImageLayout.None;
            txt_Costoinstalacion.CharacterCasing = CharacterCasing.Normal;
            txt_Costoinstalacion.Depth = 0;
            txt_Costoinstalacion.Dock = DockStyle.Fill;
            txt_Costoinstalacion.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txt_Costoinstalacion.HideSelection = true;
            txt_Costoinstalacion.LeadingIcon = null;
            txt_Costoinstalacion.Location = new Point(113, 93);
            txt_Costoinstalacion.Margin = new Padding(3, 2, 3, 2);
            txt_Costoinstalacion.MaxLength = 32767;
            txt_Costoinstalacion.MouseState = MaterialSkin.MouseState.OUT;
            txt_Costoinstalacion.Name = "txt_Costoinstalacion";
            txt_Costoinstalacion.PasswordChar = '\0';
            txt_Costoinstalacion.PrefixSuffixText = null;
            txt_Costoinstalacion.ReadOnly = false;
            txt_Costoinstalacion.RightToLeft = RightToLeft.No;
            txt_Costoinstalacion.SelectedText = "";
            txt_Costoinstalacion.SelectionLength = 0;
            txt_Costoinstalacion.SelectionStart = 0;
            txt_Costoinstalacion.ShortcutsEnabled = true;
            txt_Costoinstalacion.Size = new Size(247, 48);
            txt_Costoinstalacion.TabIndex = 4;
            txt_Costoinstalacion.TabStop = false;
            txt_Costoinstalacion.TextAlign = HorizontalAlignment.Left;
            txt_Costoinstalacion.TrailingIcon = null;
            txt_Costoinstalacion.UseSystemPasswordChar = false;
            txt_Costoinstalacion.KeyPress += txt_Costoinstalacion_KeyPress;
            txt_Costoinstalacion.TextChanged += txt_Costoinstalacion_TextChanged;
            // 
            // materialLabel6
            // 
            materialLabel6.Anchor = AnchorStyles.Right;
            materialLabel6.AutoSize = true;
            materialLabel6.Depth = 0;
            materialLabel6.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel6.Location = new Point(24, 103);
            materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel6.Name = "materialLabel6";
            materialLabel6.Size = new Size(83, 19);
            materialLabel6.TabIndex = 9;
            materialLabel6.Text = "Instalación:";
            // 
            // materialLabel3
            // 
            materialLabel3.Anchor = AnchorStyles.Right;
            materialLabel3.AutoSize = true;
            materialLabel3.Depth = 0;
            materialLabel3.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel3.Location = new Point(410, 13);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(44, 19);
            materialLabel3.TabIndex = 2;
            materialLabel3.Text = "Fecha";
            // 
            // btn_Cancelarcotizacion
            // 
            btn_Cancelarcotizacion.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_Cancelarcotizacion.BackColor = Color.Red;
            btn_Cancelarcotizacion.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_Cancelarcotizacion.Depth = 0;
            btn_Cancelarcotizacion.HighEmphasis = true;
            btn_Cancelarcotizacion.Icon = null;
            btn_Cancelarcotizacion.Location = new Point(461, 184);
            btn_Cancelarcotizacion.Margin = new Padding(4);
            btn_Cancelarcotizacion.MouseState = MaterialSkin.MouseState.HOVER;
            btn_Cancelarcotizacion.Name = "btn_Cancelarcotizacion";
            btn_Cancelarcotizacion.NoAccentTextColor = Color.Empty;
            btn_Cancelarcotizacion.Size = new Size(96, 36);
            btn_Cancelarcotizacion.TabIndex = 7;
            btn_Cancelarcotizacion.Text = "Cancelar";
            btn_Cancelarcotizacion.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_Cancelarcotizacion.UseAccentColor = false;
            btn_Cancelarcotizacion.UseVisualStyleBackColor = false;
            btn_Cancelarcotizacion.Click += btn_Cancelarcotizacion_Click_1;
            // 
            // btn_AgregarProducto
            // 
            btn_AgregarProducto.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_AgregarProducto.BackColor = Color.Cyan;
            btn_AgregarProducto.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_AgregarProducto.Depth = 0;
            btn_AgregarProducto.HighEmphasis = true;
            btn_AgregarProducto.Icon = null;
            btn_AgregarProducto.Location = new Point(768, 184);
            btn_AgregarProducto.Margin = new Padding(4);
            btn_AgregarProducto.MouseState = MaterialSkin.MouseState.HOVER;
            btn_AgregarProducto.Name = "btn_AgregarProducto";
            btn_AgregarProducto.NoAccentTextColor = Color.Empty;
            btn_AgregarProducto.Size = new Size(88, 36);
            btn_AgregarProducto.TabIndex = 9;
            btn_AgregarProducto.Text = "Agregar";
            btn_AgregarProducto.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_AgregarProducto.UseAccentColor = false;
            btn_AgregarProducto.UseVisualStyleBackColor = false;
            btn_AgregarProducto.Click += btn_AgregarProducto_Click;
            // 
            // Btn_guardarCotizacion
            // 
            Btn_guardarCotizacion.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Btn_guardarCotizacion.BackColor = Color.Green;
            Btn_guardarCotizacion.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            Btn_guardarCotizacion.Depth = 0;
            Btn_guardarCotizacion.HighEmphasis = true;
            Btn_guardarCotizacion.Icon = null;
            Btn_guardarCotizacion.Location = new Point(615, 184);
            Btn_guardarCotizacion.Margin = new Padding(4);
            Btn_guardarCotizacion.MouseState = MaterialSkin.MouseState.HOVER;
            Btn_guardarCotizacion.Name = "Btn_guardarCotizacion";
            Btn_guardarCotizacion.NoAccentTextColor = Color.Empty;
            Btn_guardarCotizacion.Size = new Size(88, 36);
            Btn_guardarCotizacion.TabIndex = 8;
            Btn_guardarCotizacion.Text = "Guardar";
            Btn_guardarCotizacion.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            Btn_guardarCotizacion.UseAccentColor = false;
            Btn_guardarCotizacion.UseVisualStyleBackColor = false;
            Btn_guardarCotizacion.Click += Btn_guardarCotizacion_Click;
            // 
            // lblFecha
            // 
            lblFecha.Anchor = AnchorStyles.None;
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(515, 15);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(38, 15);
            lblFecha.TabIndex = 25;
            lblFecha.Text = "label1";
            // 
            // materialLabel10
            // 
            materialLabel10.Anchor = AnchorStyles.Right;
            materialLabel10.AutoSize = true;
            materialLabel10.Depth = 0;
            materialLabel10.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel10.Location = new Point(374, 148);
            materialLabel10.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel10.Name = "materialLabel10";
            materialLabel10.Size = new Size(80, 19);
            materialLabel10.TabIndex = 18;
            materialLabel10.Text = "Descuento:";
            // 
            // cmb_Descuento
            // 
            cmb_Descuento.AutoResize = false;
            cmb_Descuento.BackColor = Color.FromArgb(255, 255, 255);
            cmb_Descuento.Depth = 0;
            cmb_Descuento.Dock = DockStyle.Fill;
            cmb_Descuento.DrawMode = DrawMode.OwnerDrawVariable;
            cmb_Descuento.DropDownHeight = 174;
            cmb_Descuento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_Descuento.DropDownWidth = 121;
            cmb_Descuento.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmb_Descuento.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmb_Descuento.FormattingEnabled = true;
            cmb_Descuento.IntegralHeight = false;
            cmb_Descuento.ItemHeight = 43;
            cmb_Descuento.Location = new Point(460, 137);
            cmb_Descuento.Margin = new Padding(3, 2, 3, 2);
            cmb_Descuento.MaxDropDownItems = 4;
            cmb_Descuento.MouseState = MaterialSkin.MouseState.OUT;
            cmb_Descuento.Name = "cmb_Descuento";
            cmb_Descuento.Size = new Size(148, 49);
            cmb_Descuento.StartIndex = 0;
            cmb_Descuento.TabIndex = 19;
            cmb_Descuento.SelectedIndexChanged += cmb_Descuento_SelectedIndexChanged;
            // 
            // materialLabel11
            // 
            materialLabel11.Anchor = AnchorStyles.Right;
            materialLabel11.AutoSize = true;
            materialLabel11.Depth = 0;
            materialLabel11.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel11.Location = new Point(640, 103);
            materialLabel11.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel11.Name = "materialLabel11";
            materialLabel11.Size = new Size(121, 19);
            materialLabel11.TabIndex = 22;
            materialLabel11.Text = "Total Descuento:";
            // 
            // lbl_costoDescuento
            // 
            lbl_costoDescuento.Anchor = AnchorStyles.None;
            lbl_costoDescuento.AutoSize = true;
            lbl_costoDescuento.Cursor = Cursors.IBeam;
            lbl_costoDescuento.Depth = 0;
            lbl_costoDescuento.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lbl_costoDescuento.Location = new Point(820, 103);
            lbl_costoDescuento.MouseState = MaterialSkin.MouseState.HOVER;
            lbl_costoDescuento.Name = "lbl_costoDescuento";
            lbl_costoDescuento.Size = new Size(41, 19);
            lbl_costoDescuento.TabIndex = 23;
            lbl_costoDescuento.Text = "$0.00";
            lbl_costoDescuento.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // materialLabel1
            // 
            materialLabel1.Anchor = AnchorStyles.Right;
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(682, 148);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(79, 19);
            materialLabel1.TabIndex = 26;
            materialLabel1.Text = "Total Neto:";
            // 
            // lbl_TotalNeto
            // 
            lbl_TotalNeto.Anchor = AnchorStyles.None;
            lbl_TotalNeto.AutoSize = true;
            lbl_TotalNeto.Cursor = Cursors.IBeam;
            lbl_TotalNeto.Depth = 0;
            lbl_TotalNeto.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lbl_TotalNeto.Location = new Point(820, 148);
            lbl_TotalNeto.MouseState = MaterialSkin.MouseState.HOVER;
            lbl_TotalNeto.Name = "lbl_TotalNeto";
            lbl_TotalNeto.Size = new Size(41, 19);
            lbl_TotalNeto.TabIndex = 27;
            lbl_TotalNeto.Text = "$0.00";
            lbl_TotalNeto.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txt_Direccioncliente
            // 
            txt_Direccioncliente.AnimateReadOnly = false;
            txt_Direccioncliente.BackgroundImageLayout = ImageLayout.None;
            txt_Direccioncliente.CharacterCasing = CharacterCasing.Normal;
            txt_Direccioncliente.Depth = 0;
            txt_Direccioncliente.Dock = DockStyle.Fill;
            txt_Direccioncliente.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txt_Direccioncliente.HideSelection = true;
            txt_Direccioncliente.LeadingIcon = null;
            txt_Direccioncliente.Location = new Point(767, 47);
            txt_Direccioncliente.Margin = new Padding(3, 2, 3, 2);
            txt_Direccioncliente.MaxLength = 32767;
            txt_Direccioncliente.MouseState = MaterialSkin.MouseState.OUT;
            txt_Direccioncliente.Name = "txt_Direccioncliente";
            txt_Direccioncliente.PasswordChar = '\0';
            txt_Direccioncliente.PrefixSuffixText = null;
            txt_Direccioncliente.ReadOnly = false;
            txt_Direccioncliente.RightToLeft = RightToLeft.No;
            txt_Direccioncliente.SelectedText = "";
            txt_Direccioncliente.SelectionLength = 0;
            txt_Direccioncliente.SelectionStart = 0;
            txt_Direccioncliente.ShortcutsEnabled = true;
            txt_Direccioncliente.Size = new Size(148, 48);
            txt_Direccioncliente.TabIndex = 3;
            txt_Direccioncliente.TabStop = false;
            txt_Direccioncliente.TextAlign = HorizontalAlignment.Left;
            txt_Direccioncliente.TrailingIcon = null;
            txt_Direccioncliente.UseSystemPasswordChar = false;
            // 
            // materialLabel5
            // 
            materialLabel5.Anchor = AnchorStyles.Right;
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(690, 58);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(71, 19);
            materialLabel5.TabIndex = 7;
            materialLabel5.Text = "Dirección:";
            // 
            // lbl_Subtotal
            // 
            lbl_Subtotal.Anchor = AnchorStyles.None;
            lbl_Subtotal.AutoSize = true;
            lbl_Subtotal.Depth = 0;
            lbl_Subtotal.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lbl_Subtotal.Location = new Point(216, 194);
            lbl_Subtotal.MouseState = MaterialSkin.MouseState.HOVER;
            lbl_Subtotal.Name = "lbl_Subtotal";
            lbl_Subtotal.Size = new Size(41, 19);
            lbl_Subtotal.TabIndex = 24;
            lbl_Subtotal.Text = "$0.00";
            // 
            // materialLabel9
            // 
            materialLabel9.Anchor = AnchorStyles.Right;
            materialLabel9.AutoSize = true;
            materialLabel9.Depth = 0;
            materialLabel9.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel9.Location = new Point(33, 194);
            materialLabel9.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel9.Name = "materialLabel9";
            materialLabel9.Size = new Size(74, 19);
            materialLabel9.TabIndex = 16;
            materialLabel9.Text = "Sub Total:";
            // 
            // lbl_Bases
            // 
            lbl_Bases.Anchor = AnchorStyles.Right;
            lbl_Bases.AutoSize = true;
            lbl_Bases.Depth = 0;
            lbl_Bases.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lbl_Bases.Location = new Point(59, 148);
            lbl_Bases.MouseState = MaterialSkin.MouseState.HOVER;
            lbl_Bases.Name = "lbl_Bases";
            lbl_Bases.Size = new Size(48, 19);
            lbl_Bases.TabIndex = 28;
            lbl_Bases.Text = "Bases:";
            // 
            // txt_Bases
            // 
            txt_Bases.AllowPromptAsInput = true;
            txt_Bases.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txt_Bases.AnimateReadOnly = false;
            txt_Bases.AsciiOnly = false;
            txt_Bases.BackgroundImageLayout = ImageLayout.None;
            txt_Bases.BeepOnError = false;
            txt_Bases.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txt_Bases.Depth = 0;
            txt_Bases.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txt_Bases.HidePromptOnLeave = false;
            txt_Bases.HideSelection = true;
            txt_Bases.InsertKeyMode = InsertKeyMode.Default;
            txt_Bases.LeadingIcon = null;
            txt_Bases.Location = new Point(113, 138);
            txt_Bases.Mask = "";
            txt_Bases.MaxLength = 32767;
            txt_Bases.MouseState = MaterialSkin.MouseState.OUT;
            txt_Bases.Name = "txt_Bases";
            txt_Bases.PasswordChar = '\0';
            txt_Bases.PrefixSuffixText = null;
            txt_Bases.PromptChar = '_';
            txt_Bases.ReadOnly = false;
            txt_Bases.RejectInputOnFirstFailure = false;
            txt_Bases.ResetOnPrompt = true;
            txt_Bases.ResetOnSpace = true;
            txt_Bases.RightToLeft = RightToLeft.No;
            txt_Bases.SelectedText = "";
            txt_Bases.SelectionLength = 0;
            txt_Bases.SelectionStart = 0;
            txt_Bases.ShortcutsEnabled = true;
            txt_Bases.Size = new Size(247, 48);
            txt_Bases.SkipLiterals = true;
            txt_Bases.TabIndex = 29;
            txt_Bases.TabStop = false;
            txt_Bases.TextAlign = HorizontalAlignment.Left;
            txt_Bases.TextMaskFormat = MaskFormat.IncludeLiterals;
            txt_Bases.TrailingIcon = null;
            txt_Bases.UseSystemPasswordChar = false;
            txt_Bases.ValidatingType = null;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Left;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(366, 53);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(37, 30);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // txt_Buscarentabla
            // 
            txt_Buscarentabla.AllowPromptAsInput = true;
            txt_Buscarentabla.AnimateReadOnly = false;
            txt_Buscarentabla.AsciiOnly = false;
            txt_Buscarentabla.BackgroundImageLayout = ImageLayout.None;
            txt_Buscarentabla.BeepOnError = false;
            txt_Buscarentabla.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txt_Buscarentabla.Depth = 0;
            txt_Buscarentabla.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txt_Buscarentabla.HidePromptOnLeave = false;
            txt_Buscarentabla.HideSelection = true;
            txt_Buscarentabla.InsertKeyMode = InsertKeyMode.Default;
            txt_Buscarentabla.LeadingIcon = null;
            txt_Buscarentabla.Location = new Point(366, 183);
            txt_Buscarentabla.Mask = "";
            txt_Buscarentabla.MaxLength = 32767;
            txt_Buscarentabla.MouseState = MaterialSkin.MouseState.OUT;
            txt_Buscarentabla.Name = "txt_Buscarentabla";
            txt_Buscarentabla.PasswordChar = '\0';
            txt_Buscarentabla.PrefixSuffixText = null;
            txt_Buscarentabla.PromptChar = '_';
            txt_Buscarentabla.ReadOnly = false;
            txt_Buscarentabla.RejectInputOnFirstFailure = false;
            txt_Buscarentabla.ResetOnPrompt = true;
            txt_Buscarentabla.ResetOnSpace = true;
            txt_Buscarentabla.RightToLeft = RightToLeft.No;
            txt_Buscarentabla.SelectedText = "";
            txt_Buscarentabla.SelectionLength = 0;
            txt_Buscarentabla.SelectionStart = 0;
            txt_Buscarentabla.ShortcutsEnabled = true;
            txt_Buscarentabla.Size = new Size(88, 48);
            txt_Buscarentabla.SkipLiterals = true;
            txt_Buscarentabla.TabIndex = 30;
            txt_Buscarentabla.TabStop = false;
            txt_Buscarentabla.Text = "Buscar:";
            txt_Buscarentabla.TextAlign = HorizontalAlignment.Left;
            txt_Buscarentabla.TextMaskFormat = MaskFormat.IncludeLiterals;
            txt_Buscarentabla.TrailingIcon = null;
            txt_Buscarentabla.UseSystemPasswordChar = false;
            txt_Buscarentabla.ValidatingType = null;
            txt_Buscarentabla.MouseEnter += txt_Buscarentabla_MouseEnter;
            txt_Buscarentabla.TextChanged += txt_Buscarentabla_TextChanged;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.3899784F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58.2788658F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.3311539F));
            tableLayoutPanel3.Controls.Add(tbl_Productos, 1, 0);
            tableLayoutPanel3.Controls.Add(tbl_Cotizacion, 1, 2);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(0, 227);
            tableLayoutPanel3.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 45.45454F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 9.09091F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 45.4545479F));
            tableLayoutPanel3.Size = new Size(918, 179);
            tableLayoutPanel3.TabIndex = 10;
            tableLayoutPanel3.Paint += tableLayoutPanel3_Paint;
            // 
            // tbl_Productos
            // 
            tbl_Productos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tbl_Productos.Dock = DockStyle.Fill;
            tbl_Productos.GridColor = Color.LightGray;
            tbl_Productos.Location = new Point(181, 2);
            tbl_Productos.Margin = new Padding(3, 2, 3, 2);
            tbl_Productos.Name = "tbl_Productos";
            tbl_Productos.RowHeadersWidth = 51;
            tbl_Productos.Size = new Size(529, 77);
            tbl_Productos.TabIndex = 7;
            tbl_Productos.CellClick += tbl_Productos_CellClick;
            // 
            // tbl_Cotizacion
            // 
            tbl_Cotizacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tbl_Cotizacion.Dock = DockStyle.Fill;
            tbl_Cotizacion.Location = new Point(181, 99);
            tbl_Cotizacion.Margin = new Padding(3, 2, 3, 2);
            tbl_Cotizacion.Name = "tbl_Cotizacion";
            tbl_Cotizacion.RowHeadersWidth = 51;
            tbl_Cotizacion.Size = new Size(529, 78);
            tbl_Cotizacion.TabIndex = 8;
            tbl_Cotizacion.CellClick += tbl_Cotizacion_CellClick;
            tbl_Cotizacion.CellEndEdit += tbl_Cotizacion_CellEndEdit;
            // 
            // Cotiza
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel3);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Cotiza";
            Size = new Size(918, 406);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tbl_Productos).EndInit();
            ((System.ComponentModel.ISupportInitialize)tbl_Cotizacion).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialTextBox2 txt_Nocotizacion;
        private MaterialSkin.Controls.MaterialLabel materialLabel9;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialTextBox2 txt_Costoflete;
        private MaterialSkin.Controls.MaterialTextBox2 txt_Nombrecliente;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialTextBox2 txt_Costoinstalacion;
        private PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialTextBox2 txt_Direccioncliente;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel10;
        private MaterialSkin.Controls.MaterialComboBox cmb_Descuento;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel11;
        private MaterialSkin.Controls.MaterialButton btn_Cancelarcotizacion;
        private MaterialSkin.Controls.MaterialButton btn_AgregarProducto;
        private MaterialSkin.Controls.MaterialButton Btn_guardarCotizacion;
        private MaterialSkin.Controls.MaterialLabel lbl_Subtotal;
        private MaterialSkin.Controls.MaterialLabel lbl_costoDescuento;
        private TableLayoutPanel tableLayoutPanel3;
        private DataGridView tbl_Productos;
        private DataGridView tbl_Cotizacion;
        private Label lblFecha;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel lbl_TotalNeto;
        private MaterialSkin.Controls.MaterialLabel lbl_Bases;
        private MaterialSkin.Controls.MaterialMaskedTextBox txt_Bases;
        private MaterialSkin.Controls.MaterialMaskedTextBox txt_Buscarentabla;
    }
}
