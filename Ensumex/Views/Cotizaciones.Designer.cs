namespace Ensumex.Forms
{
    partial class Cotizaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cotizaciones));
            panel1 = new Panel();
            button1 = new Button();
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
            pictureBox1 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            menu_usuario.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 81, 46);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(panel2);
            panel1.Cursor = Cursors.IBeam;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 450);
            panel1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.BackColor = Color.LightGray;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Black;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(0, 409);
            button1.Name = "button1";
            button1.Size = new Size(247, 38);
            button1.TabIndex = 8;
            button1.Text = "  Cerrar sesión";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(btn_clientes, 0, 2);
            tableLayoutPanel1.Controls.Add(btn_cotizacion, 0, 1);
            tableLayoutPanel1.Controls.Add(btn_inventario, 0, 0);
            tableLayoutPanel1.Location = new Point(0, 108);
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
            btn_clientes.Click += btn_clientes_Click;
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
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(pictureBox4);
            panel3.Controls.Add(pictureBox5);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(250, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(550, 25);
            panel3.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(527, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(20, 20);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(501, 2);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(20, 20);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 9;
            pictureBox4.TabStop = false;
            pictureBox4.Click += pictureBox4_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(475, 2);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(20, 20);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 8;
            pictureBox5.TabStop = false;
            pictureBox5.Click += pictureBox5_Click;
            // 
            // Cotizaciones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Cotizaciones";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Cotizaciones";
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            menu_usuario.ResumeLayout(false);
            menu_usuario.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
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
        private TableLayoutPanel tableLayoutPanel1;
        private Button btn_clientes;
        private Button btn_cotizacion;
        private Button btn_inventario;
        private Button button1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
    }
}