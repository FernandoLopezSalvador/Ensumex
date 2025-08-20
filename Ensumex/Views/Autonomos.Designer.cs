namespace Ensumex.Views
{
    partial class Autonomos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Autonomos));
            tableLayoutPanel1 = new TableLayoutPanel();
            materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            Buscarcliente = new PictureBox();
            lbl_NoCotiza = new Label();
            Buscar = new Label();
            Btn_Cancelar = new FontAwesome.Sharp.IconButton();
            Btn_Guardar = new FontAwesome.Sharp.IconButton();
            Btn_NuevoProd = new FontAwesome.Sharp.IconButton();
            lblFecha = new Label();
            Lbl_tablaconectados = new Label();
            Lbl_Cotiza = new Label();
            Lbl_Fechas = new Label();
            Btn_Añadprod = new FontAwesome.Sharp.IconButton();
            Txt_Buscar = new TextBox();
            Lbl_Cel = new Label();
            txt_NumeroCliente = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            Tbl_conectados = new DataGridView();
            Tbl_Cotizacion = new DataGridView();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel4 = new TableLayoutPanel();
            lbl_Subtotal = new MaterialSkin.Controls.MaterialLabel();
            lbl_costoDescuento = new MaterialSkin.Controls.MaterialLabel();
            lbl_TotalNeto = new MaterialSkin.Controls.MaterialLabel();
            Lbl_sub = new Label();
            Lbl_desc = new Label();
            Lbl_tot = new Label();
            lbl_observaciones = new MaterialSkin.Controls.MaterialLabel();
            Txt_observaciones = new TextBox();
            txt_Nombrecliente = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Buscarcliente).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Tbl_conectados).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Tbl_Cotizacion).BeginInit();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.Control;
            tableLayoutPanel1.ColumnCount = 6;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 11.9956379F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 27.5899658F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.2508173F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.7938919F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.68484F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16.68484F));
            tableLayoutPanel1.Controls.Add(materialLabel4, 0, 1);
            tableLayoutPanel1.Controls.Add(Buscarcliente, 2, 1);
            tableLayoutPanel1.Controls.Add(lbl_NoCotiza, 1, 0);
            tableLayoutPanel1.Controls.Add(Buscar, 0, 2);
            tableLayoutPanel1.Controls.Add(Btn_Cancelar, 3, 2);
            tableLayoutPanel1.Controls.Add(Btn_Guardar, 4, 2);
            tableLayoutPanel1.Controls.Add(Btn_NuevoProd, 5, 2);
            tableLayoutPanel1.Controls.Add(lblFecha, 3, 0);
            tableLayoutPanel1.Controls.Add(Lbl_tablaconectados, 1, 3);
            tableLayoutPanel1.Controls.Add(Lbl_Cotiza, 0, 0);
            tableLayoutPanel1.Controls.Add(Lbl_Fechas, 2, 0);
            tableLayoutPanel1.Controls.Add(Btn_Añadprod, 5, 3);
            tableLayoutPanel1.Controls.Add(Txt_Buscar, 1, 2);
            tableLayoutPanel1.Controls.Add(Lbl_Cel, 4, 1);
            tableLayoutPanel1.Controls.Add(txt_NumeroCliente, 5, 1);
            tableLayoutPanel1.Controls.Add(txt_Nombrecliente, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Size = new Size(902, 166);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // materialLabel4
            // 
            materialLabel4.Anchor = AnchorStyles.Right;
            materialLabel4.AutoSize = true;
            materialLabel4.Depth = 0;
            materialLabel4.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel4.Location = new Point(52, 52);
            materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel4.Name = "materialLabel4";
            materialLabel4.Size = new Size(53, 19);
            materialLabel4.TabIndex = 5;
            materialLabel4.Text = "Cliente:";
            // 
            // Buscarcliente
            // 
            Buscarcliente.Anchor = AnchorStyles.Left;
            Buscarcliente.Image = (Image)resources.GetObject("Buscarcliente.Image");
            Buscarcliente.Location = new Point(359, 43);
            Buscarcliente.Margin = new Padding(3, 2, 3, 2);
            Buscarcliente.Name = "Buscarcliente";
            Buscarcliente.Size = new Size(41, 37);
            Buscarcliente.SizeMode = PictureBoxSizeMode.Zoom;
            Buscarcliente.TabIndex = 11;
            Buscarcliente.TabStop = false;
            Buscarcliente.Click += Buscarcliente_Click;
            // 
            // lbl_NoCotiza
            // 
            lbl_NoCotiza.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbl_NoCotiza.AutoSize = true;
            lbl_NoCotiza.Font = new Font("Segoe UI", 12F);
            lbl_NoCotiza.Location = new Point(111, 10);
            lbl_NoCotiza.Name = "lbl_NoCotiza";
            lbl_NoCotiza.Size = new Size(242, 21);
            lbl_NoCotiza.TabIndex = 29;
            lbl_NoCotiza.Text = "cotizacion";
            // 
            // Buscar
            // 
            Buscar.Anchor = AnchorStyles.Right;
            Buscar.AutoSize = true;
            Buscar.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Buscar.Location = new Point(44, 92);
            Buscar.Name = "Buscar";
            Buscar.Size = new Size(61, 20);
            Buscar.TabIndex = 31;
            Buscar.Text = "Buscar:";
            Buscar.TextAlign = ContentAlignment.BottomLeft;
            // 
            // Btn_Cancelar
            // 
            Btn_Cancelar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Btn_Cancelar.IconChar = FontAwesome.Sharp.IconChar.None;
            Btn_Cancelar.IconColor = Color.Black;
            Btn_Cancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Btn_Cancelar.Location = new Point(451, 86);
            Btn_Cancelar.Name = "Btn_Cancelar";
            Btn_Cancelar.Size = new Size(145, 33);
            Btn_Cancelar.TabIndex = 32;
            Btn_Cancelar.Text = "CANCELAR";
            Btn_Cancelar.UseVisualStyleBackColor = true;
            Btn_Cancelar.Click += Btn_Cancelar_Click;
            // 
            // Btn_Guardar
            // 
            Btn_Guardar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Btn_Guardar.IconChar = FontAwesome.Sharp.IconChar.None;
            Btn_Guardar.IconColor = Color.Black;
            Btn_Guardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Btn_Guardar.Location = new Point(602, 86);
            Btn_Guardar.Name = "Btn_Guardar";
            Btn_Guardar.Size = new Size(144, 33);
            Btn_Guardar.TabIndex = 33;
            Btn_Guardar.Text = "GUARDAR";
            Btn_Guardar.UseVisualStyleBackColor = true;
            Btn_Guardar.Click += Btn_Guardar_Click;
            // 
            // Btn_NuevoProd
            // 
            Btn_NuevoProd.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Btn_NuevoProd.IconChar = FontAwesome.Sharp.IconChar.None;
            Btn_NuevoProd.IconColor = Color.Black;
            Btn_NuevoProd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Btn_NuevoProd.Location = new Point(752, 86);
            Btn_NuevoProd.Name = "Btn_NuevoProd";
            Btn_NuevoProd.Size = new Size(147, 33);
            Btn_NuevoProd.TabIndex = 34;
            Btn_NuevoProd.Text = "PRODUCTO";
            Btn_NuevoProd.UseVisualStyleBackColor = true;
            Btn_NuevoProd.Click += Btn_NuevoProd_Click;
            // 
            // lblFecha
            // 
            lblFecha.Anchor = AnchorStyles.None;
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lblFecha.Location = new Point(492, 10);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(62, 20);
            lblFecha.TabIndex = 25;
            lblFecha.Text = "Fecha...";
            // 
            // Lbl_tablaconectados
            // 
            Lbl_tablaconectados.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Lbl_tablaconectados.AutoSize = true;
            Lbl_tablaconectados.Location = new Point(111, 137);
            Lbl_tablaconectados.Name = "Lbl_tablaconectados";
            Lbl_tablaconectados.Size = new Size(242, 15);
            Lbl_tablaconectados.TabIndex = 35;
            Lbl_tablaconectados.Text = "EQUIPOS QUE SE PUEDEN CONECTAR:";
            // 
            // Lbl_Cotiza
            // 
            Lbl_Cotiza.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Lbl_Cotiza.AutoSize = true;
            Lbl_Cotiza.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_Cotiza.Location = new Point(3, 0);
            Lbl_Cotiza.Name = "Lbl_Cotiza";
            Lbl_Cotiza.Size = new Size(102, 41);
            Lbl_Cotiza.TabIndex = 37;
            Lbl_Cotiza.Text = "No.Cotización";
            Lbl_Cotiza.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Lbl_Fechas
            // 
            Lbl_Fechas.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Lbl_Fechas.AutoSize = true;
            Lbl_Fechas.Location = new Point(359, 13);
            Lbl_Fechas.Name = "Lbl_Fechas";
            Lbl_Fechas.Size = new Size(86, 15);
            Lbl_Fechas.TabIndex = 38;
            Lbl_Fechas.Text = "Fecha:";
            // 
            // Btn_Añadprod
            // 
            Btn_Añadprod.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Btn_Añadprod.IconChar = FontAwesome.Sharp.IconChar.None;
            Btn_Añadprod.IconColor = Color.Black;
            Btn_Añadprod.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Btn_Añadprod.Location = new Point(752, 126);
            Btn_Añadprod.Name = "Btn_Añadprod";
            Btn_Añadprod.Size = new Size(147, 37);
            Btn_Añadprod.TabIndex = 36;
            Btn_Añadprod.Text = "AÑADIR PRODUCTO";
            Btn_Añadprod.UseVisualStyleBackColor = true;
            Btn_Añadprod.Click += Btn_Añadprod_Click;
            // 
            // Txt_Buscar
            // 
            Txt_Buscar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Txt_Buscar.Location = new Point(111, 91);
            Txt_Buscar.Name = "Txt_Buscar";
            Txt_Buscar.Size = new Size(242, 23);
            Txt_Buscar.TabIndex = 3;
            Txt_Buscar.TextChanged += Txt_Buscar_TextChanged;
            // 
            // Lbl_Cel
            // 
            Lbl_Cel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Lbl_Cel.AutoSize = true;
            Lbl_Cel.Location = new Point(602, 54);
            Lbl_Cel.Name = "Lbl_Cel";
            Lbl_Cel.Size = new Size(144, 15);
            Lbl_Cel.TabIndex = 39;
            Lbl_Cel.Text = "Celular/WhatsApp:";
            // 
            // txt_NumeroCliente
            // 
            txt_NumeroCliente.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txt_NumeroCliente.AutoSize = true;
            txt_NumeroCliente.Location = new Point(752, 54);
            txt_NumeroCliente.Name = "txt_NumeroCliente";
            txt_NumeroCliente.Size = new Size(147, 15);
            txt_NumeroCliente.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(Tbl_conectados, 0, 0);
            tableLayoutPanel2.Controls.Add(Tbl_Cotizacion, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 166);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(902, 386);
            tableLayoutPanel2.TabIndex = 9;
            // 
            // Tbl_conectados
            // 
            Tbl_conectados.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Tbl_conectados.Dock = DockStyle.Fill;
            Tbl_conectados.Location = new Point(3, 3);
            Tbl_conectados.Name = "Tbl_conectados";
            Tbl_conectados.Size = new Size(445, 380);
            Tbl_conectados.TabIndex = 0;
            // 
            // Tbl_Cotizacion
            // 
            Tbl_Cotizacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Tbl_Cotizacion.Dock = DockStyle.Fill;
            Tbl_Cotizacion.Location = new Point(454, 3);
            Tbl_Cotizacion.Name = "Tbl_Cotizacion";
            Tbl_Cotizacion.Size = new Size(445, 380);
            Tbl_Cotizacion.TabIndex = 1;
            Tbl_Cotizacion.CellBeginEdit += Tbl_Cotizacion_CellBeginEdit;
            Tbl_Cotizacion.CellClick += Tbl_Cotizacion_CellClick;
            Tbl_Cotizacion.CellValueChanged += Tbl_Cotizacion_CellValueChanged;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.BackColor = SystemColors.Control;
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10.40624F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 38.7799568F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.87146F));
            tableLayoutPanel3.Controls.Add(tableLayoutPanel4, 2, 0);
            tableLayoutPanel3.Controls.Add(lbl_observaciones, 0, 0);
            tableLayoutPanel3.Controls.Add(Txt_observaciones, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Bottom;
            tableLayoutPanel3.Location = new Point(0, 375);
            tableLayoutPanel3.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(902, 177);
            tableLayoutPanel3.TabIndex = 11;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 2;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel4.Controls.Add(lbl_Subtotal, 1, 0);
            tableLayoutPanel4.Controls.Add(lbl_costoDescuento, 1, 1);
            tableLayoutPanel4.Controls.Add(lbl_TotalNeto, 1, 2);
            tableLayoutPanel4.Controls.Add(Lbl_sub, 0, 0);
            tableLayoutPanel4.Controls.Add(Lbl_desc, 0, 1);
            tableLayoutPanel4.Controls.Add(Lbl_tot, 0, 2);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(445, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 4;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel4.Size = new Size(454, 171);
            tableLayoutPanel4.TabIndex = 10;
            // 
            // lbl_Subtotal
            // 
            lbl_Subtotal.Anchor = AnchorStyles.None;
            lbl_Subtotal.AutoSize = true;
            lbl_Subtotal.Depth = 0;
            lbl_Subtotal.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lbl_Subtotal.Location = new Point(297, 11);
            lbl_Subtotal.MouseState = MaterialSkin.MouseState.HOVER;
            lbl_Subtotal.Name = "lbl_Subtotal";
            lbl_Subtotal.Size = new Size(41, 19);
            lbl_Subtotal.TabIndex = 24;
            lbl_Subtotal.Text = "$0.00";
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
            lbl_costoDescuento.Location = new Point(297, 53);
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
            lbl_TotalNeto.Location = new Point(297, 95);
            lbl_TotalNeto.MouseState = MaterialSkin.MouseState.HOVER;
            lbl_TotalNeto.Name = "lbl_TotalNeto";
            lbl_TotalNeto.Size = new Size(41, 19);
            lbl_TotalNeto.TabIndex = 27;
            lbl_TotalNeto.Text = "$0.00";
            lbl_TotalNeto.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Lbl_sub
            // 
            Lbl_sub.Anchor = AnchorStyles.Right;
            Lbl_sub.AutoSize = true;
            Lbl_sub.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_sub.Location = new Point(102, 10);
            Lbl_sub.Name = "Lbl_sub";
            Lbl_sub.Size = new Size(76, 21);
            Lbl_sub.TabIndex = 28;
            Lbl_sub.Text = "Sub Total:";
            // 
            // Lbl_desc
            // 
            Lbl_desc.Anchor = AnchorStyles.Right;
            Lbl_desc.AutoSize = true;
            Lbl_desc.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Lbl_desc.ForeColor = Color.Red;
            Lbl_desc.Location = new Point(83, 52);
            Lbl_desc.Name = "Lbl_desc";
            Lbl_desc.Size = new Size(95, 21);
            Lbl_desc.TabIndex = 29;
            Lbl_desc.Text = "Descuento:";
            // 
            // Lbl_tot
            // 
            Lbl_tot.Anchor = AnchorStyles.Right;
            Lbl_tot.AutoSize = true;
            Lbl_tot.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Lbl_tot.Location = new Point(56, 90);
            Lbl_tot.Name = "Lbl_tot";
            Lbl_tot.Size = new Size(122, 30);
            Lbl_tot.TabIndex = 30;
            Lbl_tot.Text = "Total Neto:";
            // 
            // lbl_observaciones
            // 
            lbl_observaciones.Anchor = AnchorStyles.Right;
            lbl_observaciones.AutoSize = true;
            lbl_observaciones.Depth = 0;
            lbl_observaciones.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lbl_observaciones.Location = new Point(33, 79);
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
            Txt_observaciones.Location = new Point(96, 21);
            Txt_observaciones.Multiline = true;
            Txt_observaciones.Name = "Txt_observaciones";
            Txt_observaciones.Size = new Size(343, 134);
            Txt_observaciones.TabIndex = 34;
            // 
            // txt_Nombrecliente
            // 
            txt_Nombrecliente.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txt_Nombrecliente.Location = new Point(111, 50);
            txt_Nombrecliente.Name = "txt_Nombrecliente";
            txt_Nombrecliente.Size = new Size(242, 23);
            txt_Nombrecliente.TabIndex = 40;
            // 
            // Autonomos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel3);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            Name = "Autonomos";
            Size = new Size(902, 552);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Buscarcliente).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Tbl_conectados).EndInit();
            ((System.ComponentModel.ISupportInitialize)Tbl_Cotizacion).EndInit();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private PictureBox Buscarcliente;
        private Label lbl_NoCotiza;
        private Label Buscar;
        private TextBox Txt_Buscar;
        private FontAwesome.Sharp.IconButton Btn_Cancelar;
        private FontAwesome.Sharp.IconButton Btn_Guardar;
        private FontAwesome.Sharp.IconButton Btn_NuevoProd;
        private Label txt_NumeroCliente;
        private TableLayoutPanel tableLayoutPanel2;
        private DataGridView Tbl_conectados;
        private DataGridView Tbl_Cotizacion;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private MaterialSkin.Controls.MaterialLabel lbl_Subtotal;
        private MaterialSkin.Controls.MaterialLabel lbl_costoDescuento;
        private MaterialSkin.Controls.MaterialLabel lbl_TotalNeto;
        private Label Lbl_sub;
        private Label Lbl_desc;
        private Label Lbl_tot;
        private MaterialSkin.Controls.MaterialLabel lbl_observaciones;
        private TextBox Txt_observaciones;
        private Label Lbl_tablaconectados;
        private FontAwesome.Sharp.IconButton Btn_Añadprod;
        private Label lblFecha;
        private Label Lbl_Cotiza;
        private Label Lbl_Fechas;
        private Label Lbl_Cel;
        private TextBox txt_Nombrecliente;
    }
}
