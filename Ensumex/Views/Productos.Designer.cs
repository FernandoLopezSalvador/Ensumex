namespace Ensumex.Forms
{
    partial class Productos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Productos));
            panel1 = new Panel();
            btn_cerrarsesion = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            btn_clientes = new Button();
            btn_cotizacion = new Button();
            btn_inventario = new Button();
            panel2 = new Panel();
            lbl_usuario = new Label();
            lbl_posicion = new Label();
            txt_usuario = new TextBox();
            pictureBox3 = new PictureBox();
            menu_usuario = new MenuStrip();
            administrarUsuarioToolStripMenuItem = new ToolStripMenuItem();
            nuevoToolStripMenuItem = new ToolStripMenuItem();
            editarToolStripMenuItem = new ToolStripMenuItem();
            panel3 = new Panel();
            btn_cerrar = new PictureBox();
            btn_maximizar = new PictureBox();
            btn_minimizar = new PictureBox();
            text_buscar = new TextBox();
            pictureBox1 = new PictureBox();
            btn_newProducto = new Button();
            btn_imprimir = new Button();
            label1 = new Label();
            cmb_productos = new ComboBox();
            label2 = new Label();
            tabla_productos = new DataGridView();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            menu_usuario.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btn_cerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabla_productos).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 81, 46);
            panel1.Controls.Add(btn_cerrarsesion);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(panel2);
            panel1.Cursor = Cursors.IBeam;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 450);
            panel1.TabIndex = 3;
            // 
            // btn_cerrarsesion
            // 
            btn_cerrarsesion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_cerrarsesion.BackColor = Color.LightGray;
            btn_cerrarsesion.FlatStyle = FlatStyle.Popup;
            btn_cerrarsesion.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_cerrarsesion.ForeColor = Color.Black;
            btn_cerrarsesion.Image = (Image)resources.GetObject("btn_cerrarsesion.Image");
            btn_cerrarsesion.ImageAlign = ContentAlignment.MiddleLeft;
            btn_cerrarsesion.Location = new Point(0, 409);
            btn_cerrarsesion.Name = "btn_cerrarsesion";
            btn_cerrarsesion.Size = new Size(247, 38);
            btn_cerrarsesion.TabIndex = 8;
            btn_cerrarsesion.Text = "  Cerrar sesión";
            btn_cerrarsesion.UseVisualStyleBackColor = false;
            btn_cerrarsesion.Click += btn_cerrarsesion_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(btn_clientes, 0, 2);
            tableLayoutPanel1.Controls.Add(btn_cotizacion, 0, 1);
            tableLayoutPanel1.Controls.Add(btn_inventario, 0, 0);
            tableLayoutPanel1.Location = new Point(3, 104);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(247, 295);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // btn_clientes
            // 
            btn_clientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btn_clientes.BackColor = Color.Transparent;
            btn_clientes.FlatStyle = FlatStyle.Popup;
            btn_clientes.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_clientes.ForeColor = Color.Black;
            btn_clientes.Image = (Image)resources.GetObject("btn_clientes.Image");
            btn_clientes.ImageAlign = ContentAlignment.MiddleLeft;
            btn_clientes.Location = new Point(3, 199);
            btn_clientes.Name = "btn_clientes";
            btn_clientes.Size = new Size(241, 93);
            btn_clientes.TabIndex = 3;
            btn_clientes.Text = "Clientes";
            btn_clientes.UseVisualStyleBackColor = false;
            btn_clientes.MouseEnter += btn_clientes_MouseEnter;
            btn_clientes.MouseLeave += btn_clientes_MouseLeave;
            // 
            // btn_cotizacion
            // 
            btn_cotizacion.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btn_cotizacion.BackColor = Color.Transparent;
            btn_cotizacion.FlatStyle = FlatStyle.Popup;
            btn_cotizacion.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_cotizacion.ForeColor = Color.Black;
            btn_cotizacion.Image = (Image)resources.GetObject("btn_cotizacion.Image");
            btn_cotizacion.ImageAlign = ContentAlignment.MiddleLeft;
            btn_cotizacion.Location = new Point(3, 101);
            btn_cotizacion.Name = "btn_cotizacion";
            btn_cotizacion.Size = new Size(241, 92);
            btn_cotizacion.TabIndex = 2;
            btn_cotizacion.Text = "Cotización";
            btn_cotizacion.UseVisualStyleBackColor = false;
            btn_cotizacion.MouseEnter += btn_cotizacion_MouseEnter;
            btn_cotizacion.MouseLeave += btn_cotizacion_MouseLeave;
            // 
            // btn_inventario
            // 
            btn_inventario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            btn_inventario.BackColor = Color.Transparent;
            btn_inventario.FlatStyle = FlatStyle.Popup;
            btn_inventario.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_inventario.ForeColor = Color.Black;
            btn_inventario.Image = (Image)resources.GetObject("btn_inventario.Image");
            btn_inventario.ImageAlign = ContentAlignment.MiddleLeft;
            btn_inventario.Location = new Point(3, 3);
            btn_inventario.Name = "btn_inventario";
            btn_inventario.Size = new Size(241, 92);
            btn_inventario.TabIndex = 1;
            btn_inventario.Text = "Inventario";
            btn_inventario.UseVisualStyleBackColor = false;
            btn_inventario.MouseEnter += btn_inventario_MouseEnter;
            btn_inventario.MouseLeave += btn_inventario_MouseLeave;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 81, 46);
            panel2.Controls.Add(lbl_usuario);
            panel2.Controls.Add(lbl_posicion);
            panel2.Controls.Add(txt_usuario);
            panel2.Controls.Add(pictureBox3);
            panel2.Controls.Add(menu_usuario);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 105);
            panel2.TabIndex = 1;
            // 
            // lbl_usuario
            // 
            lbl_usuario.AutoSize = true;
            lbl_usuario.ForeColor = Color.White;
            lbl_usuario.Location = new Point(135, 65);
            lbl_usuario.Name = "lbl_usuario";
            lbl_usuario.Size = new Size(115, 20);
            lbl_usuario.TabIndex = 5;
            lbl_usuario.Text = "nombre Usuario";
            // 
            // lbl_posicion
            // 
            lbl_posicion.AutoSize = true;
            lbl_posicion.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_posicion.Location = new Point(74, 40);
            lbl_posicion.Name = "lbl_posicion";
            lbl_posicion.Size = new Size(79, 21);
            lbl_posicion.TabIndex = 3;
            lbl_posicion.Text = "Cuenta:";
            // 
            // txt_usuario
            // 
            txt_usuario.BackColor = Color.FromArgb(0, 81, 46);
            txt_usuario.BorderStyle = BorderStyle.None;
            txt_usuario.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_usuario.ForeColor = Color.Black;
            txt_usuario.Location = new Point(74, 64);
            txt_usuario.Name = "txt_usuario";
            txt_usuario.Size = new Size(70, 21);
            txt_usuario.TabIndex = 2;
            txt_usuario.Text = "Usuario:";
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(3, 40);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(65, 62);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            // 
            // menu_usuario
            // 
            menu_usuario.BackColor = Color.Transparent;
            menu_usuario.BackgroundImageLayout = ImageLayout.None;
            menu_usuario.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menu_usuario.ImageScalingSize = new Size(20, 20);
            menu_usuario.Items.AddRange(new ToolStripItem[] { administrarUsuarioToolStripMenuItem });
            menu_usuario.Location = new Point(0, 0);
            menu_usuario.Name = "menu_usuario";
            menu_usuario.RenderMode = ToolStripRenderMode.System;
            menu_usuario.Size = new Size(250, 28);
            menu_usuario.TabIndex = 4;
            menu_usuario.Text = "Usuarios";
            // 
            // administrarUsuarioToolStripMenuItem
            // 
            administrarUsuarioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nuevoToolStripMenuItem, editarToolStripMenuItem });
            administrarUsuarioToolStripMenuItem.Name = "administrarUsuarioToolStripMenuItem";
            administrarUsuarioToolStripMenuItem.Size = new Size(161, 24);
            administrarUsuarioToolStripMenuItem.Text = "Administrar Usuario";
            // 
            // nuevoToolStripMenuItem
            // 
            nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            nuevoToolStripMenuItem.Size = new Size(142, 26);
            nuevoToolStripMenuItem.Text = "Nuevo";
            // 
            // editarToolStripMenuItem
            // 
            editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            editarToolStripMenuItem.Size = new Size(142, 26);
            editarToolStripMenuItem.Text = "Editar";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 81, 46);
            panel3.Controls.Add(btn_cerrar);
            panel3.Controls.Add(btn_maximizar);
            panel3.Controls.Add(btn_minimizar);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(250, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(550, 25);
            panel3.TabIndex = 5;
            // 
            // btn_cerrar
            // 
            btn_cerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_cerrar.Image = (Image)resources.GetObject("btn_cerrar.Image");
            btn_cerrar.Location = new Point(527, 3);
            btn_cerrar.Name = "btn_cerrar";
            btn_cerrar.Size = new Size(20, 20);
            btn_cerrar.SizeMode = PictureBoxSizeMode.Zoom;
            btn_cerrar.TabIndex = 4;
            btn_cerrar.TabStop = false;
            btn_cerrar.Click += btn_cerrar_Click;
            // 
            // btn_maximizar
            // 
            btn_maximizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_maximizar.Image = (Image)resources.GetObject("btn_maximizar.Image");
            btn_maximizar.Location = new Point(501, 3);
            btn_maximizar.Name = "btn_maximizar";
            btn_maximizar.Size = new Size(20, 20);
            btn_maximizar.SizeMode = PictureBoxSizeMode.Zoom;
            btn_maximizar.TabIndex = 6;
            btn_maximizar.TabStop = false;
            btn_maximizar.Click += btn_maximizar_Click;
            // 
            // btn_minimizar
            // 
            btn_minimizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_minimizar.Image = (Image)resources.GetObject("btn_minimizar.Image");
            btn_minimizar.Location = new Point(475, 3);
            btn_minimizar.Name = "btn_minimizar";
            btn_minimizar.Size = new Size(20, 20);
            btn_minimizar.SizeMode = PictureBoxSizeMode.Zoom;
            btn_minimizar.TabIndex = 5;
            btn_minimizar.TabStop = false;
            btn_minimizar.Click += btn_minimizar_Click;
            // 
            // text_buscar
            // 
            text_buscar.Location = new Point(628, 103);
            text_buscar.Name = "text_buscar";
            text_buscar.Size = new Size(126, 27);
            text_buscar.TabIndex = 7;
            text_buscar.TextChanged += text_buscar_TextChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(760, 104);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(28, 26);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // btn_newProducto
            // 
            btn_newProducto.Location = new Point(256, 40);
            btn_newProducto.Name = "btn_newProducto";
            btn_newProducto.Size = new Size(150, 29);
            btn_newProducto.TabIndex = 9;
            btn_newProducto.Text = "Agregar Producto";
            btn_newProducto.UseVisualStyleBackColor = true;
            // 
            // btn_imprimir
            // 
            btn_imprimir.Location = new Point(433, 40);
            btn_imprimir.Name = "btn_imprimir";
            btn_imprimir.Size = new Size(150, 29);
            btn_imprimir.TabIndex = 10;
            btn_imprimir.Text = "Imprimir PDF";
            btn_imprimir.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(256, 108);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 11;
            label1.Text = "Mostrar:";
            // 
            // cmb_productos
            // 
            cmb_productos.FormattingEnabled = true;
            cmb_productos.Location = new Point(316, 103);
            cmb_productos.Name = "cmb_productos";
            cmb_productos.Size = new Size(86, 28);
            cmb_productos.TabIndex = 12;
            cmb_productos.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(408, 106);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 13;
            label2.Text = "Registros";
            // 
            // tabla_productos
            // 
            tabla_productos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabla_productos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabla_productos.ColumnHeadersHeight = 29;
            tabla_productos.Location = new Point(256, 161);
            tabla_productos.Name = "tabla_productos";
            tabla_productos.RowHeadersWidth = 51;
            tabla_productos.Size = new Size(532, 277);
            tabla_productos.TabIndex = 6;
            tabla_productos.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Productos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabla_productos);
            Controls.Add(label2);
            Controls.Add(cmb_productos);
            Controls.Add(label1);
            Controls.Add(btn_imprimir);
            Controls.Add(btn_newProducto);
            Controls.Add(pictureBox1);
            Controls.Add(text_buscar);
            Controls.Add(panel3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Productos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Productos";
            Load += Productos_Load;
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            menu_usuario.ResumeLayout(false);
            menu_usuario.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btn_cerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)tabla_productos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label lbl_usuario;
        private Label lbl_posicion;
        private TextBox txt_usuario;
        private PictureBox pictureBox3;
        private MenuStrip menu_usuario;
        private ToolStripMenuItem administrarUsuarioToolStripMenuItem;
        private ToolStripMenuItem nuevoToolStripMenuItem;
        private ToolStripMenuItem editarToolStripMenuItem;
        private Panel panel3;
        private PictureBox btn_cerrar;
        private PictureBox btn_maximizar;
        private PictureBox btn_minimizar;
        private TextBox text_buscar;
        private PictureBox pictureBox1;
        private Button btn_newProducto;
        private Button btn_imprimir;
        private Label label1;
        private ComboBox cmb_productos;
        private Label label2;
        private DataGridView tabla_productos;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btn_clientes;
        private Button btn_cotizacion;
        private Button btn_inventario;
        private Button btn_cerrarsesion;
    }
}