namespace Ensumex.Forms
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            btn_cerrar = new PictureBox();
            btn_minimizar = new PictureBox();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            btn_clientes = new Button();
            btn_cotizacion = new Button();
            btn_inventario = new Button();
            btn_cerrarsesion = new Button();
            panel2 = new Panel();
            lbl_usuario = new Label();
            lbl_posicion = new Label();
            txt_usuario = new TextBox();
            pictureBox3 = new PictureBox();
            menu_usuario = new MenuStrip();
            administrarUsuarioToolStripMenuItem = new ToolStripMenuItem();
            nuevoToolStripMenuItem = new ToolStripMenuItem();
            editarToolStripMenuItem = new ToolStripMenuItem();
            btn_maximizar = new PictureBox();
            panel3 = new Panel();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)btn_cerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).BeginInit();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            menu_usuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btn_cerrar
            // 
            btn_cerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_cerrar.Image = (Image)resources.GetObject("btn_cerrar.Image");
            btn_cerrar.Location = new Point(529, 3);
            btn_cerrar.Name = "btn_cerrar";
            btn_cerrar.Size = new Size(20, 20);
            btn_cerrar.SizeMode = PictureBoxSizeMode.Zoom;
            btn_cerrar.TabIndex = 0;
            btn_cerrar.TabStop = false;
            btn_cerrar.Click += pictureBox1_Click;
            // 
            // btn_minimizar
            // 
            btn_minimizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_minimizar.Image = (Image)resources.GetObject("btn_minimizar.Image");
            btn_minimizar.Location = new Point(477, 3);
            btn_minimizar.Name = "btn_minimizar";
            btn_minimizar.Size = new Size(20, 20);
            btn_minimizar.SizeMode = PictureBoxSizeMode.Zoom;
            btn_minimizar.TabIndex = 1;
            btn_minimizar.TabStop = false;
            btn_minimizar.Click += pictureBox2_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 81, 46);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(btn_cerrarsesion);
            panel1.Controls.Add(panel2);
            panel1.Cursor = Cursors.IBeam;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 450);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(btn_clientes, 0, 2);
            tableLayoutPanel1.Controls.Add(btn_cotizacion, 0, 1);
            tableLayoutPanel1.Controls.Add(btn_inventario, 0, 0);
            tableLayoutPanel1.Location = new Point(3, 111);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Size = new Size(247, 295);
            tableLayoutPanel1.TabIndex = 5;
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
            btn_cotizacion.Click += btn_cotizacion_Click;
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
            btn_inventario.Click += btn_inventario_Click;
            btn_inventario.MouseEnter += btn_inventario_MouseEnter;
            btn_inventario.MouseLeave += btn_inventario_MouseLeave;
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
            btn_cerrarsesion.Location = new Point(3, 412);
            btn_cerrarsesion.Name = "btn_cerrarsesion";
            btn_cerrarsesion.Size = new Size(247, 38);
            btn_cerrarsesion.TabIndex = 4;
            btn_cerrarsesion.Text = "  Cerrar sesión";
            btn_cerrarsesion.UseVisualStyleBackColor = false;
            btn_cerrarsesion.Click += btn_cerrarsesion_Click;
            btn_cerrarsesion.MouseEnter += btn_cerrarsesion_MouseEnter;
            btn_cerrarsesion.MouseLeave += btn_cerrarsesion_MouseLeave;
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
            lbl_posicion.Click += lbl_cuenta_Click;
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
            txt_usuario.TextChanged += txt_usuario_TextChanged;
            txt_usuario.Enter += txt_usuario_Enter;
            txt_usuario.Leave += txt_usuario_Leave;
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
            nuevoToolStripMenuItem.Click += nuevoToolStripMenuItem_Click;
            // 
            // editarToolStripMenuItem
            // 
            editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            editarToolStripMenuItem.Size = new Size(142, 26);
            editarToolStripMenuItem.Text = "Editar";
            // 
            // btn_maximizar
            // 
            btn_maximizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_maximizar.Image = (Image)resources.GetObject("btn_maximizar.Image");
            btn_maximizar.Location = new Point(503, 3);
            btn_maximizar.Name = "btn_maximizar";
            btn_maximizar.Size = new Size(20, 20);
            btn_maximizar.SizeMode = PictureBoxSizeMode.Zoom;
            btn_maximizar.TabIndex = 3;
            btn_maximizar.TabStop = false;
            btn_maximizar.Click += pictureBox7_Click;
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
            panel3.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(250, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(550, 425);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // Principal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(panel3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Principal";
            Opacity = 0.9D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Principal";
            ((System.ComponentModel.ISupportInitialize)btn_cerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).EndInit();
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            menu_usuario.ResumeLayout(false);
            menu_usuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).EndInit();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox btn_cerrar;
        private PictureBox btn_minimizar;
        private Panel panel1;
        private Panel panel2;
        private TextBox txt_usuario;
        private PictureBox pictureBox3;
        private Label lbl_posicion;
        private Button btn_inventario;
        private Button btn_cotizacion;
        private Button btn_clientes;
        private PictureBox btn_maximizar;
        private Panel panel3;
        private PictureBox pictureBox1;
        private Button btn_cerrarsesion;
        private MenuStrip menu_usuario;
        private ToolStripMenuItem administrarUsuarioToolStripMenuItem;
        private ToolStripMenuItem nuevoToolStripMenuItem;
        private ToolStripMenuItem editarToolStripMenuItem;
        private Label lbl_usuario;
        private TableLayoutPanel tableLayoutPanel1;
    }
}