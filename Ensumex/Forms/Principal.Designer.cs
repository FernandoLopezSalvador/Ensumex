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
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox6 = new PictureBox();
            btn_cerrarsesion = new Button();
            btn_clientes = new Button();
            btn_cotizacion = new Button();
            btn_inventario = new Button();
            panel2 = new Panel();
            lbl_cuenta = new Label();
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
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
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
            btn_cerrar.Location = new Point(572, 3);
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
            btn_minimizar.Location = new Point(520, 3);
            btn_minimizar.Name = "btn_minimizar";
            btn_minimizar.Size = new Size(20, 20);
            btn_minimizar.SizeMode = PictureBoxSizeMode.Zoom;
            btn_minimizar.TabIndex = 1;
            btn_minimizar.TabStop = false;
            btn_minimizar.Click += pictureBox2_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 104, 56);
            panel1.Controls.Add(pictureBox4);
            panel1.Controls.Add(pictureBox5);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox6);
            panel1.Controls.Add(btn_cerrarsesion);
            panel1.Controls.Add(btn_clientes);
            panel1.Controls.Add(btn_cotizacion);
            panel1.Controls.Add(btn_inventario);
            panel1.Controls.Add(panel2);
            panel1.Cursor = Cursors.IBeam;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(207, 450);
            panel1.TabIndex = 2;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(3, 136);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(55, 38);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 2;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(3, 219);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(55, 38);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 3;
            pictureBox5.TabStop = false;
            pictureBox5.Click += pictureBox5_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(0, 412);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(58, 38);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 6;
            pictureBox2.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(3, 302);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(55, 38);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 5;
            pictureBox6.TabStop = false;
            pictureBox6.Click += pictureBox6_Click;
            // 
            // btn_cerrarsesion
            // 
            btn_cerrarsesion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_cerrarsesion.BackColor = Color.Transparent;
            btn_cerrarsesion.FlatStyle = FlatStyle.Popup;
            btn_cerrarsesion.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_cerrarsesion.ForeColor = Color.Black;
            btn_cerrarsesion.Location = new Point(12, 412);
            btn_cerrarsesion.Name = "btn_cerrarsesion";
            btn_cerrarsesion.Size = new Size(196, 38);
            btn_cerrarsesion.TabIndex = 4;
            btn_cerrarsesion.Text = "  Cerrar sesión";
            btn_cerrarsesion.UseVisualStyleBackColor = false;
            btn_cerrarsesion.Click += btn_cerrarsesion_Click;
            btn_cerrarsesion.MouseEnter += btn_cerrarsesion_MouseEnter;
            btn_cerrarsesion.MouseLeave += btn_cerrarsesion_MouseLeave;
            // 
            // btn_clientes
            // 
            btn_clientes.BackColor = Color.Transparent;
            btn_clientes.FlatStyle = FlatStyle.Popup;
            btn_clientes.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_clientes.ForeColor = Color.Black;
            btn_clientes.Location = new Point(12, 302);
            btn_clientes.Name = "btn_clientes";
            btn_clientes.Size = new Size(196, 38);
            btn_clientes.TabIndex = 3;
            btn_clientes.Text = "Clientes";
            btn_clientes.UseVisualStyleBackColor = false;
            btn_clientes.MouseEnter += btn_clientes_MouseEnter;
            btn_clientes.MouseLeave += btn_clientes_MouseLeave;
            // 
            // btn_cotizacion
            // 
            btn_cotizacion.BackColor = Color.Transparent;
            btn_cotizacion.FlatStyle = FlatStyle.Popup;
            btn_cotizacion.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_cotizacion.ForeColor = Color.Black;
            btn_cotizacion.Location = new Point(12, 219);
            btn_cotizacion.Name = "btn_cotizacion";
            btn_cotizacion.Size = new Size(196, 38);
            btn_cotizacion.TabIndex = 2;
            btn_cotizacion.Text = "Cotización";
            btn_cotizacion.UseVisualStyleBackColor = false;
            btn_cotizacion.Click += btn_cotizacion_Click;
            btn_cotizacion.MouseEnter += btn_cotizacion_MouseEnter;
            btn_cotizacion.MouseLeave += btn_cotizacion_MouseLeave;
            // 
            // btn_inventario
            // 
            btn_inventario.BackColor = Color.Transparent;
            btn_inventario.FlatStyle = FlatStyle.Popup;
            btn_inventario.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_inventario.ForeColor = Color.Black;
            btn_inventario.Location = new Point(12, 136);
            btn_inventario.Name = "btn_inventario";
            btn_inventario.Size = new Size(196, 38);
            btn_inventario.TabIndex = 1;
            btn_inventario.Text = "Inventario";
            btn_inventario.UseVisualStyleBackColor = false;
            btn_inventario.Click += btn_inventario_Click;
            btn_inventario.MouseEnter += btn_inventario_MouseEnter;
            btn_inventario.MouseLeave += btn_inventario_MouseLeave;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 104, 56);
            panel2.Controls.Add(lbl_cuenta);
            panel2.Controls.Add(txt_usuario);
            panel2.Controls.Add(pictureBox3);
            panel2.Controls.Add(menu_usuario);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 105);
            panel2.TabIndex = 1;
            // 
            // lbl_cuenta
            // 
            lbl_cuenta.AutoSize = true;
            lbl_cuenta.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_cuenta.Location = new Point(74, 40);
            lbl_cuenta.Name = "lbl_cuenta";
            lbl_cuenta.Size = new Size(79, 21);
            lbl_cuenta.TabIndex = 3;
            lbl_cuenta.Text = "Cuenta:";
            lbl_cuenta.Click += lbl_cuenta_Click;
            // 
            // txt_usuario
            // 
            txt_usuario.BackColor = Color.FromArgb(0, 104, 56);
            txt_usuario.BorderStyle = BorderStyle.None;
            txt_usuario.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_usuario.ForeColor = Color.Black;
            txt_usuario.Location = new Point(83, 72);
            txt_usuario.Name = "txt_usuario";
            txt_usuario.Size = new Size(125, 21);
            txt_usuario.TabIndex = 2;
            txt_usuario.Text = "Usuario";
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
            btn_maximizar.Location = new Point(546, 3);
            btn_maximizar.Name = "btn_maximizar";
            btn_maximizar.Size = new Size(20, 20);
            btn_maximizar.SizeMode = PictureBoxSizeMode.Zoom;
            btn_maximizar.TabIndex = 3;
            btn_maximizar.TabStop = false;
            btn_maximizar.Click += pictureBox7_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 104, 56);
            panel3.Controls.Add(btn_cerrar);
            panel3.Controls.Add(btn_maximizar);
            panel3.Controls.Add(btn_minimizar);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(207, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(593, 25);
            panel3.TabIndex = 4;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(207, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(593, 425);
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
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
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
        private Label lbl_cuenta;
        private Button btn_inventario;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
        private Button btn_cotizacion;
        private PictureBox pictureBox6;
        private Button btn_clientes;
        private PictureBox btn_maximizar;
        private Panel panel3;
        private PictureBox pictureBox1;
        private Button btn_cerrarsesion;
        private PictureBox pictureBox2;
        private MenuStrip menu_usuario;
        private ToolStripMenuItem administrarUsuarioToolStripMenuItem;
        private ToolStripMenuItem nuevoToolStripMenuItem;
        private ToolStripMenuItem editarToolStripMenuItem;
    }
}