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
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            txt_Costoflete = new MaterialSkin.Controls.MaterialTextBox2();
            txt_Nombrecliente = new MaterialSkin.Controls.MaterialTextBox2();
            materialLabel7 = new MaterialSkin.Controls.MaterialLabel();
            txt_Costoinstalacion = new MaterialSkin.Controls.MaterialTextBox2();
            materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            lblFecha = new Label();
            Buscarcliente = new PictureBox();
            txt_NumeroCliente = new MaterialSkin.Controls.MaterialTextBox2();
            materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            lbl_NoCotiza = new Label();
            Buscar = new Label();
            Txt_Buscar = new TextBox();
            Btn_Cancelar = new FontAwesome.Sharp.IconButton();
            Btn_Guardar = new FontAwesome.Sharp.IconButton();
            Btn_NuevoProd = new FontAwesome.Sharp.IconButton();
            lbl_costoDescuento = new MaterialSkin.Controls.MaterialLabel();
            lbl_TotalNeto = new MaterialSkin.Controls.MaterialLabel();
            lbl_Subtotal = new MaterialSkin.Controls.MaterialLabel();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lbl_observaciones = new MaterialSkin.Controls.MaterialLabel();
            Txt_observaciones = new TextBox();
            Btn_AñadirTabla = new FontAwesome.Sharp.IconButton();
            Btn_Añadprod = new FontAwesome.Sharp.IconButton();
            tbl_Cotizacion = new DataGridView();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Buscarcliente).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbl_Cotizacion).BeginInit();
            tableLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.Control;
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.99564F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.5899715F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.2508192F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.7938938F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6848431F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.6848431F));
            tableLayoutPanel1.Controls.Add(materialLabel2, 0, 0);
            tableLayoutPanel1.Controls.Add(materialLabel4, 0, 1);
            tableLayoutPanel1.Controls.Add(txt_Costoflete, 3, 2);
            tableLayoutPanel1.Controls.Add(txt_Nombrecliente, 1, 1);
            tableLayoutPanel1.Controls.Add(materialLabel7, 2, 2);
            tableLayoutPanel1.Controls.Add(txt_Costoinstalacion, 1, 2);
            tableLayoutPanel1.Controls.Add(materialLabel6, 0, 2);
            tableLayoutPanel1.Controls.Add(materialLabel3, 2, 0);
            tableLayoutPanel1.Controls.Add(lblFecha, 3, 0);
            tableLayoutPanel1.Controls.Add(Buscarcliente, 2, 1);
            tableLayoutPanel1.Controls.Add(txt_NumeroCliente, 5, 1);
            tableLayoutPanel1.Controls.Add(materialLabel5, 4, 1);
            tableLayoutPanel1.Controls.Add(lbl_NoCotiza, 1, 0);
            tableLayoutPanel1.Controls.Add(Buscar, 0, 4);
            tableLayoutPanel1.Controls.Add(Txt_Buscar, 1, 4);
            tableLayoutPanel1.Controls.Add(Btn_Cancelar, 3, 3);
            tableLayoutPanel1.Controls.Add(Btn_Guardar, 4, 3);
            tableLayoutPanel1.Controls.Add(Btn_NuevoProd, 5, 3);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.5923519F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 23.7664719F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 23.45647F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.5923519F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 17.5923519F));
            tableLayoutPanel1.Size = new Size(918, 223);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // materialLabel2
            // 
            materialLabel2.Anchor = AnchorStyles.Right;
            materialLabel2.AutoSize = true;
            materialLabel2.Depth = 0;
            materialLabel2.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel2.Location = new Point(7, 10);
            materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel2.Name = "materialLabel2";
            materialLabel2.Size = new Size(100, 19);
            materialLabel2.TabIndex = 0;
            materialLabel2.Text = "No.Cotización";
            // 
            // materialLabel4
            // 
            materialLabel4.Anchor = AnchorStyles.Right;
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(54, 55);
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
            txt_Costoflete.TabIndex = 3;
            txt_Costoflete.TabStop = false;
            txt_Costoflete.TextAlign = HorizontalAlignment.Left;
            txt_Costoflete.TrailingIcon = null;
            txt_Costoflete.UseSystemPasswordChar = false;
            txt_Costoflete.KeyPress += txt_Costoflete_KeyPress;
            txt_Costoflete.Leave += txt_Costoflete_Leave;
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
            txt_Nombrecliente.Location = new Point(113, 41);
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
            txt_Nombrecliente.TabIndex = 1;
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
            materialLabel7.Location = new Point(415, 107);
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
            txt_Costoinstalacion.TabIndex = 2;
            txt_Costoinstalacion.TabStop = false;
            txt_Costoinstalacion.TextAlign = HorizontalAlignment.Left;
            txt_Costoinstalacion.TrailingIcon = null;
            txt_Costoinstalacion.UseSystemPasswordChar = false;
            txt_Costoinstalacion.KeyPress += txt_Costoinstalacion_KeyPress;
            txt_Costoinstalacion.Leave += txt_Costoinstalacion_Leave;
            txt_Costoinstalacion.TextChanged += txt_Costoinstalacion_TextChanged;
            // 
            // materialLabel6
            // 
            materialLabel6.Anchor = AnchorStyles.Right;
            materialLabel6.AutoSize = true;
            materialLabel6.Depth = 0;
            materialLabel6.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel6.Location = new Point(24, 107);
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
            materialLabel3.Location = new Point(410, 10);
            materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel3.Name = "materialLabel3";
            materialLabel3.Size = new Size(44, 19);
            materialLabel3.TabIndex = 2;
            materialLabel3.Text = "Fecha";
            // 
            // lblFecha
            // 
            lblFecha.Anchor = AnchorStyles.None;
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblFecha.Location = new Point(503, 9);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(62, 20);
            lblFecha.TabIndex = 25;
            lblFecha.Text = "Fecha...";
            // 
            // Buscarcliente
            // 
            Buscarcliente.Anchor = AnchorStyles.Left;
            Buscarcliente.Image = (Image)resources.GetObject("Buscarcliente.Image");
            Buscarcliente.Location = new Point(366, 45);
            Buscarcliente.Margin = new Padding(3, 2, 3, 2);
            Buscarcliente.Name = "Buscarcliente";
            Buscarcliente.Size = new Size(41, 39);
            Buscarcliente.SizeMode = PictureBoxSizeMode.Zoom;
            Buscarcliente.TabIndex = 11;
            Buscarcliente.TabStop = false;
            Buscarcliente.Click += pictureBox1_Click;
            // 
            // txt_NumeroCliente
            // 
            txt_NumeroCliente.AnimateReadOnly = false;
            txt_NumeroCliente.BackgroundImageLayout = ImageLayout.None;
            txt_NumeroCliente.CharacterCasing = CharacterCasing.Normal;
            txt_NumeroCliente.Depth = 0;
            txt_NumeroCliente.Dock = DockStyle.Fill;
            txt_NumeroCliente.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txt_NumeroCliente.HideSelection = true;
            txt_NumeroCliente.LeadingIcon = null;
            txt_NumeroCliente.Location = new Point(767, 41);
            txt_NumeroCliente.Margin = new Padding(3, 2, 3, 2);
            txt_NumeroCliente.MaxLength = 32767;
            txt_NumeroCliente.MouseState = MaterialSkin.MouseState.OUT;
            txt_NumeroCliente.Name = "txt_NumeroCliente";
            txt_NumeroCliente.PasswordChar = '\0';
            txt_NumeroCliente.PrefixSuffixText = null;
            txt_NumeroCliente.ReadOnly = false;
            txt_NumeroCliente.RightToLeft = RightToLeft.No;
            txt_NumeroCliente.SelectedText = "";
            txt_NumeroCliente.SelectionLength = 0;
            txt_NumeroCliente.SelectionStart = 0;
            txt_NumeroCliente.ShortcutsEnabled = true;
            txt_NumeroCliente.Size = new Size(148, 48);
            txt_NumeroCliente.TabIndex = 4;
            txt_NumeroCliente.TabStop = false;
            txt_NumeroCliente.TextAlign = HorizontalAlignment.Left;
            txt_NumeroCliente.TrailingIcon = null;
            txt_NumeroCliente.UseSystemPasswordChar = false;
            txt_NumeroCliente.KeyPress += txt_NumeroCliente_KeyPress;
            // 
            // materialLabel5
            // 
            materialLabel5.Anchor = AnchorStyles.Right;
            materialLabel5.AutoSize = true;
            materialLabel5.Depth = 0;
            materialLabel5.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel5.Location = new Point(627, 55);
            materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel5.Name = "materialLabel5";
            materialLabel5.Size = new Size(134, 19);
            materialLabel5.TabIndex = 7;
            materialLabel5.Text = "Celular/WhatsApp:";
            // 
            // lbl_NoCotiza
            // 
            lbl_NoCotiza.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbl_NoCotiza.AutoSize = true;
            lbl_NoCotiza.Font = new Font("Segoe UI", 12F);
            lbl_NoCotiza.Location = new Point(113, 9);
            lbl_NoCotiza.Name = "lbl_NoCotiza";
            lbl_NoCotiza.Size = new Size(247, 21);
            lbl_NoCotiza.TabIndex = 29;
            lbl_NoCotiza.Text = "cotizacion";
            // 
            // Buscar
            // 
            Buscar.Anchor = AnchorStyles.Right;
            Buscar.AutoSize = true;
            Buscar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Buscar.Location = new Point(46, 192);
            Buscar.Name = "Buscar";
            Buscar.Size = new Size(61, 20);
            Buscar.TabIndex = 31;
            Buscar.Text = "Buscar:";
            Buscar.TextAlign = ContentAlignment.BottomLeft;
            // 
            // Txt_Buscar
            // 
            Txt_Buscar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Txt_Buscar.Location = new Point(113, 191);
            Txt_Buscar.Name = "Txt_Buscar";
            Txt_Buscar.Size = new Size(247, 23);
            Txt_Buscar.TabIndex = 7;
            Txt_Buscar.TextChanged += textBox1_TextChanged;
            // 
            // Btn_Cancelar
            // 
            Btn_Cancelar.Dock = DockStyle.Fill;
            Btn_Cancelar.IconChar = FontAwesome.Sharp.IconChar.None;
            Btn_Cancelar.IconColor = Color.Black;
            Btn_Cancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Btn_Cancelar.Location = new Point(460, 146);
            Btn_Cancelar.Name = "Btn_Cancelar";
            Btn_Cancelar.Size = new Size(148, 33);
            Btn_Cancelar.TabIndex = 32;
            Btn_Cancelar.Text = "CANCELAR";
            Btn_Cancelar.UseVisualStyleBackColor = true;
            Btn_Cancelar.Click += Btn_Cancelar_Click;
            // 
            // Btn_Guardar
            // 
            Btn_Guardar.Dock = DockStyle.Fill;
            Btn_Guardar.IconChar = FontAwesome.Sharp.IconChar.None;
            Btn_Guardar.IconColor = Color.Black;
            Btn_Guardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Btn_Guardar.Location = new Point(614, 146);
            Btn_Guardar.Name = "Btn_Guardar";
            Btn_Guardar.Size = new Size(147, 33);
            Btn_Guardar.TabIndex = 33;
            Btn_Guardar.Text = "GUARDAR";
            Btn_Guardar.UseVisualStyleBackColor = true;
            Btn_Guardar.Click += Btn_Guardar_Click;
            // 
            // Btn_NuevoProd
            // 
            Btn_NuevoProd.Dock = DockStyle.Fill;
            Btn_NuevoProd.IconChar = FontAwesome.Sharp.IconChar.None;
            Btn_NuevoProd.IconColor = Color.Black;
            Btn_NuevoProd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Btn_NuevoProd.Location = new Point(767, 146);
            Btn_NuevoProd.Name = "Btn_NuevoProd";
            Btn_NuevoProd.Size = new Size(148, 33);
            Btn_NuevoProd.TabIndex = 34;
            Btn_NuevoProd.Text = "PRODUCTO";
            Btn_NuevoProd.UseVisualStyleBackColor = true;
            Btn_NuevoProd.Click += Btn_NuevoProd_Click;
            // 
            // lbl_costoDescuento
            // 
            lbl_costoDescuento.Anchor = AnchorStyles.None;
            lbl_costoDescuento.AutoSize = true;
            lbl_costoDescuento.BackColor = SystemColors.Control;
            lbl_costoDescuento.Cursor = Cursors.IBeam;
            lbl_costoDescuento.Depth = 0;
            lbl_costoDescuento.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lbl_costoDescuento.ForeColor = SystemColors.ControlText;
            lbl_costoDescuento.Location = new Point(302, 65);
            lbl_costoDescuento.MouseState = MaterialSkin.MouseState.HOVER;
            lbl_costoDescuento.Name = "lbl_costoDescuento";
            lbl_costoDescuento.Size = new Size(41, 19);
            lbl_costoDescuento.TabIndex = 23;
            lbl_costoDescuento.Text = "$0.00";
            lbl_costoDescuento.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_TotalNeto
            // 
            lbl_TotalNeto.Anchor = AnchorStyles.None;
            lbl_TotalNeto.AutoSize = true;
            lbl_TotalNeto.Cursor = Cursors.IBeam;
            lbl_TotalNeto.Depth = 0;
            lbl_TotalNeto.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lbl_TotalNeto.Location = new Point(302, 115);
            lbl_TotalNeto.MouseState = MaterialSkin.MouseState.HOVER;
            lbl_TotalNeto.Name = "lbl_TotalNeto";
            lbl_TotalNeto.Size = new Size(41, 19);
            lbl_TotalNeto.TabIndex = 27;
            lbl_TotalNeto.Text = "$0.00";
            lbl_TotalNeto.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Subtotal
            // 
            lbl_Subtotal.Anchor = AnchorStyles.None;
            lbl_Subtotal.AutoSize = true;
            lbl_Subtotal.Depth = 0;
            lbl_Subtotal.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lbl_Subtotal.Location = new Point(302, 15);
            lbl_Subtotal.MouseState = MaterialSkin.MouseState.HOVER;
            lbl_Subtotal.Name = "lbl_Subtotal";
            lbl_Subtotal.Size = new Size(41, 19);
            lbl_Subtotal.TabIndex = 24;
            lbl_Subtotal.Text = "$0.00";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = SystemColors.Control;
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.40624F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38.7799568F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.87146F));
            tableLayoutPanel3.Controls.Add(tableLayoutPanel2, 2, 0);
            tableLayoutPanel3.Controls.Add(lbl_observaciones, 0, 0);
            tableLayoutPanel3.Controls.Add(Txt_observaciones, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Bottom;
            tableLayoutPanel3.Location = new Point(0, 369);
            tableLayoutPanel3.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(918, 206);
            tableLayoutPanel3.TabIndex = 10;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel2.Controls.Add(lbl_Subtotal, 1, 0);
            tableLayoutPanel2.Controls.Add(lbl_costoDescuento, 1, 1);
            tableLayoutPanel2.Controls.Add(lbl_TotalNeto, 1, 2);
            tableLayoutPanel2.Controls.Add(label1, 0, 0);
            tableLayoutPanel2.Controls.Add(label2, 0, 1);
            tableLayoutPanel2.Controls.Add(label3, 0, 2);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(453, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Size = new Size(462, 200);
            tableLayoutPanel2.TabIndex = 10;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(105, 14);
            label1.Name = "label1";
            label1.Size = new Size(76, 21);
            label1.TabIndex = 28;
            label1.Text = "Sub Total:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(86, 64);
            label2.Name = "label2";
            label2.Size = new Size(95, 21);
            label2.TabIndex = 29;
            label2.Text = "Descuento:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(59, 110);
            label3.Name = "label3";
            label3.Size = new Size(122, 30);
            label3.TabIndex = 30;
            label3.Text = "Total Neto:";
            // 
            // lbl_observaciones
            // 
            lbl_observaciones.Anchor = AnchorStyles.Right;
            lbl_observaciones.AutoSize = true;
            lbl_observaciones.Depth = 0;
            lbl_observaciones.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lbl_observaciones.Location = new Point(35, 93);
            lbl_observaciones.MouseState = MaterialSkin.MouseState.HOVER;
            lbl_observaciones.Name = "lbl_observaciones";
            lbl_observaciones.Size = new Size(57, 19);
            lbl_observaciones.TabIndex = 9;
            lbl_observaciones.Text = "NOTAS:";
            // 
            // Txt_observaciones
            // 
            Txt_observaciones.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Txt_observaciones.BackColor = SystemColors.ScrollBar;
            Txt_observaciones.Location = new Point(98, 34);
            Txt_observaciones.Multiline = true;
            Txt_observaciones.Name = "Txt_observaciones";
            Txt_observaciones.Size = new Size(349, 137);
            Txt_observaciones.TabIndex = 34;
            // 
            // Btn_AñadirTabla
            // 
            Btn_AñadirTabla.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Btn_AñadirTabla.IconChar = FontAwesome.Sharp.IconChar.None;
            Btn_AñadirTabla.IconColor = Color.Black;
            Btn_AñadirTabla.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Btn_AñadirTabla.Location = new Point(3, 48);
            Btn_AñadirTabla.Name = "Btn_AñadirTabla";
            Btn_AñadirTabla.Size = new Size(85, 49);
            Btn_AñadirTabla.TabIndex = 31;
            Btn_AñadirTabla.Text = "AGREGAR TABLA";
            Btn_AñadirTabla.UseVisualStyleBackColor = true;
            Btn_AñadirTabla.Click += iconButton1_Click;
            // 
            // Btn_Añadprod
            // 
            Btn_Añadprod.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Btn_Añadprod.IconChar = FontAwesome.Sharp.IconChar.None;
            Btn_Añadprod.IconColor = Color.Black;
            Btn_Añadprod.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Btn_Añadprod.Location = new Point(828, 43);
            Btn_Añadprod.Name = "Btn_Añadprod";
            Btn_Añadprod.Size = new Size(87, 59);
            Btn_Añadprod.TabIndex = 32;
            Btn_Añadprod.Text = "AÑADIR PRODUCTO";
            Btn_Añadprod.UseVisualStyleBackColor = true;
            Btn_Añadprod.Click += Btn_Añadprod_Click;
            // 
            // tbl_Cotizacion
            // 
            tbl_Cotizacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tbl_Cotizacion.Dock = DockStyle.Fill;
            tbl_Cotizacion.Location = new Point(94, 2);
            tbl_Cotizacion.Margin = new Padding(3, 2, 3, 2);
            tbl_Cotizacion.Name = "tbl_Cotizacion";
            tbl_Cotizacion.RowHeadersWidth = 51;
            tbl_Cotizacion.Size = new Size(728, 142);
            tbl_Cotizacion.TabIndex = 8;
            tbl_Cotizacion.CellBeginEdit += tbl_Cotizacion_CellBeginEdit_1;
            tbl_Cotizacion.CellClick += tbl_Cotizacion_CellClick;
            tbl_Cotizacion.CellValueChanged += tbl_Cotizacion_CellValueChanged;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel4.Controls.Add(tbl_Cotizacion, 1, 0);
            tableLayoutPanel4.Controls.Add(Btn_AñadirTabla, 0, 0);
            tableLayoutPanel4.Controls.Add(Btn_Añadprod, 2, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 223);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(918, 146);
            tableLayoutPanel4.TabIndex = 11;
            // 
            // Cotiza
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel4);
            Controls.Add(tableLayoutPanel3);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Cotiza";
            Size = new Size(918, 575);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Buscarcliente).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbl_Cotizacion).EndInit();
            tableLayoutPanel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private MaterialSkin.Controls.MaterialTextBox2 txt_Costoflete;
        private MaterialSkin.Controls.MaterialTextBox2 txt_Nombrecliente;
        private MaterialSkin.Controls.MaterialLabel materialLabel7;
        private MaterialSkin.Controls.MaterialTextBox2 txt_Costoinstalacion;
        private PictureBox Buscarcliente;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private MaterialSkin.Controls.MaterialTextBox2 txt_NumeroCliente;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel lbl_Subtotal;
        private MaterialSkin.Controls.MaterialLabel lbl_costoDescuento;
        private TableLayoutPanel tableLayoutPanel3;
        private DataGridView tbl_Cotizacion;
        private Label lblFecha;
        private MaterialSkin.Controls.MaterialLabel lbl_TotalNeto;
        private MaterialSkin.Controls.MaterialLabel lbl_observaciones;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox Txt_observaciones;
        private Label lbl_NoCotiza;
        private TextBox Txt_Buscar;
        private Label Buscar;
        private TableLayoutPanel tableLayoutPanel4;
        private Label label1;
        private Label label2;
        private Label label3;
        private FontAwesome.Sharp.IconButton Btn_AñadirTabla;
        private FontAwesome.Sharp.IconButton Btn_Añadprod;
        private FontAwesome.Sharp.IconButton Btn_Cancelar;
        private FontAwesome.Sharp.IconButton Btn_Guardar;
        private FontAwesome.Sharp.IconButton Btn_NuevoProd;
    }
}
