namespace Ensumex.Views
{
    partial class panel23
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(panel23));
            panel3 = new Panel();
            btn_cerrar = new PictureBox();
            btn_maximizar = new PictureBox();
            btn_minimizar = new PictureBox();
            lbl1_usuariocrear = new Label();
            textnewUsuario = new TextBox();
            textNewContraseña = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textNewNombre = new TextBox();
            label3 = new Label();
            cmb_NewPosicion = new ComboBox();
            label4 = new Label();
            textNewCorreo = new TextBox();
            panel2 = new Panel();
            lbl_usuario = new Label();
            lbl_posicion = new Label();
            txt_usuario = new TextBox();
            pictureBox3 = new PictureBox();
            menu_usuario = new MenuStrip();
            administrarUsuarioToolStripMenuItem = new ToolStripMenuItem();
            nuevoToolStripMenuItem = new ToolStripMenuItem();
            editarToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            btn_clientes = new Button();
            btn_cotizacion = new Button();
            btn_inventario = new Button();
            btn_cerrarsesion = new Button();
            dataGridView1 = new DataGridView();
            btn_nuevoUsuario = new Button();
            btn_editarUsuario = new Button();
            btn_eliminarUsuario = new Button();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel4 = new Panel();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btn_cerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            menu_usuario.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
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
            // lbl1_usuariocrear
            // 
            lbl1_usuariocrear.AutoSize = true;
            lbl1_usuariocrear.Location = new Point(3, 12);
            lbl1_usuariocrear.Name = "lbl1_usuariocrear";
            lbl1_usuariocrear.Size = new Size(62, 20);
            lbl1_usuariocrear.TabIndex = 6;
            lbl1_usuariocrear.Text = "Usuario:";
            // 
            // textnewUsuario
            // 
            textnewUsuario.BackColor = Color.Silver;
            textnewUsuario.Location = new Point(90, 12);
            textnewUsuario.Name = "textnewUsuario";
            textnewUsuario.Size = new Size(160, 27);
            textnewUsuario.TabIndex = 7;
            // 
            // textNewContraseña
            // 
            textNewContraseña.BackColor = Color.Silver;
            textNewContraseña.Location = new Point(378, 13);
            textNewContraseña.Name = "textNewContraseña";
            textNewContraseña.Size = new Size(140, 27);
            textNewContraseña.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(286, 14);
            label1.Name = "label1";
            label1.Size = new Size(86, 20);
            label1.TabIndex = 9;
            label1.Text = "Contraseña:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 55);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 10;
            label2.Text = "Nombre:";
            // 
            // textNewNombre
            // 
            textNewNombre.BackColor = Color.Silver;
            textNewNombre.Location = new Point(90, 52);
            textNewNombre.Name = "textNewNombre";
            textNewNombre.Size = new Size(239, 27);
            textNewNombre.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 93);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 12;
            label3.Text = "Posición:";
            // 
            // cmb_NewPosicion
            // 
            cmb_NewPosicion.BackColor = Color.Silver;
            cmb_NewPosicion.FormattingEnabled = true;
            cmb_NewPosicion.Items.AddRange(new object[] { "Administrador", "Vendedor" });
            cmb_NewPosicion.Location = new Point(90, 90);
            cmb_NewPosicion.Name = "cmb_NewPosicion";
            cmb_NewPosicion.Size = new Size(129, 28);
            cmb_NewPosicion.TabIndex = 13;
            cmb_NewPosicion.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(263, 94);
            label4.Name = "label4";
            label4.Size = new Size(57, 20);
            label4.TabIndex = 14;
            label4.Text = "Correo:";
            label4.Click += label4_Click;
            // 
            // textNewCorreo
            // 
            textNewCorreo.BackColor = Color.Silver;
            textNewCorreo.Location = new Point(326, 91);
            textNewCorreo.Name = "textNewCorreo";
            textNewCorreo.Size = new Size(201, 27);
            textNewCorreo.TabIndex = 15;
            textNewCorreo.TextChanged += textBox1_TextChanged;
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
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 81, 46);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(btn_cerrarsesion);
            panel1.Controls.Add(panel2);
            panel1.Cursor = Cursors.Hand;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 450);
            panel1.TabIndex = 3;
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
            tableLayoutPanel1.TabIndex = 6;
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
            // btn_cerrarsesion
            // 
            btn_cerrarsesion.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btn_cerrarsesion.BackColor = Color.LightGray;
            btn_cerrarsesion.FlatStyle = FlatStyle.Popup;
            btn_cerrarsesion.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_cerrarsesion.ForeColor = Color.Black;
            btn_cerrarsesion.Image = (Image)resources.GetObject("btn_cerrarsesion.Image");
            btn_cerrarsesion.ImageAlign = ContentAlignment.MiddleLeft;
            btn_cerrarsesion.Location = new Point(6, 412);
            btn_cerrarsesion.Name = "btn_cerrarsesion";
            btn_cerrarsesion.Size = new Size(247, 38);
            btn_cerrarsesion.TabIndex = 7;
            btn_cerrarsesion.Text = "  Cerrar sesión";
            btn_cerrarsesion.UseVisualStyleBackColor = false;
            btn_cerrarsesion.Click += btn_cerrarsesion_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(256, 241);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(541, 197);
            dataGridView1.TabIndex = 16;
            // 
            // btn_nuevoUsuario
            // 
            btn_nuevoUsuario.BackColor = Color.Green;
            btn_nuevoUsuario.Image = (Image)resources.GetObject("btn_nuevoUsuario.Image");
            btn_nuevoUsuario.ImageAlign = ContentAlignment.MiddleLeft;
            btn_nuevoUsuario.Location = new Point(3, 3);
            btn_nuevoUsuario.Name = "btn_nuevoUsuario";
            btn_nuevoUsuario.Size = new Size(177, 51);
            btn_nuevoUsuario.TabIndex = 1;
            btn_nuevoUsuario.Text = "Guardar Usuario";
            btn_nuevoUsuario.TextAlign = ContentAlignment.MiddleRight;
            btn_nuevoUsuario.UseVisualStyleBackColor = false;
            btn_nuevoUsuario.Click += btn_nuevoUsuario_Click;
            // 
            // btn_editarUsuario
            // 
            btn_editarUsuario.BackColor = Color.RoyalBlue;
            btn_editarUsuario.Image = (Image)resources.GetObject("btn_editarUsuario.Image");
            btn_editarUsuario.ImageAlign = ContentAlignment.MiddleLeft;
            btn_editarUsuario.Location = new Point(186, 3);
            btn_editarUsuario.Name = "btn_editarUsuario";
            btn_editarUsuario.Size = new Size(177, 51);
            btn_editarUsuario.TabIndex = 2;
            btn_editarUsuario.Text = "Editar Usuario";
            btn_editarUsuario.TextAlign = ContentAlignment.MiddleRight;
            btn_editarUsuario.UseVisualStyleBackColor = false;
            btn_editarUsuario.Click += btn_editarUsuario_Click;
            // 
            // btn_eliminarUsuario
            // 
            btn_eliminarUsuario.BackColor = Color.Red;
            btn_eliminarUsuario.Image = (Image)resources.GetObject("btn_eliminarUsuario.Image");
            btn_eliminarUsuario.ImageAlign = ContentAlignment.MiddleLeft;
            btn_eliminarUsuario.Location = new Point(369, 3);
            btn_eliminarUsuario.Name = "btn_eliminarUsuario";
            btn_eliminarUsuario.Size = new Size(178, 51);
            btn_eliminarUsuario.TabIndex = 3;
            btn_eliminarUsuario.Text = "Eliminar Usuario";
            btn_eliminarUsuario.TextAlign = ContentAlignment.MiddleRight;
            btn_eliminarUsuario.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Controls.Add(btn_nuevoUsuario, 0, 0);
            tableLayoutPanel2.Controls.Add(btn_eliminarUsuario, 2, 0);
            tableLayoutPanel2.Controls.Add(btn_editarUsuario, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Top;
            tableLayoutPanel2.Location = new Point(250, 25);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(550, 57);
            tableLayoutPanel2.TabIndex = 17;
            // 
            // panel4
            // 
            panel4.Controls.Add(textNewContraseña);
            panel4.Controls.Add(label1);
            panel4.Controls.Add(lbl1_usuariocrear);
            panel4.Controls.Add(textNewCorreo);
            panel4.Controls.Add(textnewUsuario);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(cmb_NewPosicion);
            panel4.Controls.Add(textNewNombre);
            panel4.Controls.Add(label3);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(250, 82);
            panel4.Name = "panel4";
            panel4.Size = new Size(550, 153);
            panel4.TabIndex = 18;
            // 
            // panel23
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel4);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(dataGridView1);
            Controls.Add(panel3);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "panel23";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Usuarios";
            Load += Usuarios_Load;
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btn_cerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_maximizar).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_minimizar).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            menu_usuario.ResumeLayout(false);
            menu_usuario.PerformLayout();
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel3;
        private PictureBox btn_cerrar;
        private PictureBox btn_maximizar;
        private PictureBox btn_minimizar;
        private Label lbl1_usuariocrear;
        private TextBox textnewUsuario;
        private TextBox textNewContraseña;
        private Label label1;
        private Label label2;
        private TextBox textNewNombre;
        private Label label3;
        private ComboBox cmb_NewPosicion;
        private Label label4;
        private TextBox textNewCorreo;
        private Panel panel2;
        private Label lbl_usuario;
        private Label lbl_posicion;
        private TextBox txt_usuario;
        private PictureBox pictureBox3;
        private MenuStrip menu_usuario;
        private ToolStripMenuItem administrarUsuarioToolStripMenuItem;
        private ToolStripMenuItem nuevoToolStripMenuItem;
        private ToolStripMenuItem editarToolStripMenuItem;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button btn_clientes;
        private Button btn_cotizacion;
        private Button btn_inventario;
        private Button btn_cerrarsesion;
        private DataGridView dataGridView1;
        private Button btn_nuevoUsuario;
        private Button btn_editarUsuario;
        private Button btn_eliminarUsuario;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel4;
    }
}