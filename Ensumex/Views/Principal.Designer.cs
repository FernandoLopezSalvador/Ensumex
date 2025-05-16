namespace Ensumex.Forms
{
    partial class ENSUMEX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ENSUMEX));
            tableLayoutPanel2 = new TableLayoutPanel();
            panel2 = new Panel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            lbl_usuario = new Label();
            lbl_posicion = new Label();
            txt_usuario = new TextBox();
            menu_usuario = new MenuStrip();
            administrarUsuarioToolStripMenuItem = new ToolStripMenuItem();
            nuevoToolStripMenuItem = new ToolStripMenuItem();
            cargarDatosToolStripMenuItem = new ToolStripMenuItem();
            productosToolStripMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            btn_cerrarsesion = new Button();
            materialButton3 = new MaterialSkin.Controls.MaterialButton();
            materialButton2 = new MaterialSkin.Controls.MaterialButton();
            btn_inventarioP = new MaterialSkin.Controls.MaterialButton();
            materialSwitch1 = new MaterialSkin.Controls.MaterialSwitch();
            tableLayoutPanel1 = new TableLayoutPanel();
            panelContenedor = new Panel();
            panel1 = new Panel();
            panel2.SuspendLayout();
            menu_usuario.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panelContenedor.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Location = new Point(4, 83);
            tableLayoutPanel2.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Size = new Size(219, 439);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 81, 46);
            panel2.Controls.Add(materialLabel1);
            panel2.Controls.Add(lbl_usuario);
            panel2.Controls.Add(lbl_posicion);
            panel2.Controls.Add(txt_usuario);
            panel2.Controls.Add(menu_usuario);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(219, 79);
            panel2.TabIndex = 1;
            // 
            // materialLabel1
            // 
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(3, 24);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(37, 19);
            materialLabel1.TabIndex = 7;
            materialLabel1.Text = "Tipo:";
            // 
            // lbl_usuario
            // 
            lbl_usuario.AutoSize = true;
            lbl_usuario.ForeColor = Color.White;
            lbl_usuario.Location = new Point(70, 49);
            lbl_usuario.Name = "lbl_usuario";
            lbl_usuario.Size = new Size(92, 15);
            lbl_usuario.TabIndex = 5;
            lbl_usuario.Text = "nombre Usuario";
            // 
            // lbl_posicion
            // 
            lbl_posicion.AutoSize = true;
            lbl_posicion.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_posicion.ForeColor = Color.White;
            lbl_posicion.Location = new Point(70, 24);
            lbl_posicion.Name = "lbl_posicion";
            lbl_posicion.Size = new Size(66, 19);
            lbl_posicion.TabIndex = 3;
            lbl_posicion.Text = "Cuenta:";
            lbl_posicion.Click += lbl_cuenta_Click;
            // 
            // txt_usuario
            // 
            txt_usuario.BackColor = Color.FromArgb(0, 81, 46);
            txt_usuario.BorderStyle = BorderStyle.None;
            txt_usuario.Enabled = false;
            txt_usuario.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txt_usuario.ForeColor = Color.Black;
            txt_usuario.Location = new Point(4, 49);
            txt_usuario.Margin = new Padding(3, 2, 3, 2);
            txt_usuario.Name = "txt_usuario";
            txt_usuario.Size = new Size(61, 17);
            txt_usuario.TabIndex = 6;
            txt_usuario.Text = "Usuario:";
            txt_usuario.TextChanged += txt_usuario_TextChanged;
            txt_usuario.Enter += txt_usuario_Enter;
            txt_usuario.Leave += txt_usuario_Leave;
            // 
            // menu_usuario
            // 
            menu_usuario.BackColor = Color.FromArgb(0, 81, 46);
            menu_usuario.BackgroundImageLayout = ImageLayout.None;
            menu_usuario.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menu_usuario.ImageScalingSize = new Size(20, 20);
            menu_usuario.Items.AddRange(new ToolStripItem[] { administrarUsuarioToolStripMenuItem });
            menu_usuario.Location = new Point(0, 0);
            menu_usuario.Name = "menu_usuario";
            menu_usuario.Padding = new Padding(5, 2, 0, 2);
            menu_usuario.RenderMode = ToolStripRenderMode.System;
            menu_usuario.Size = new Size(219, 25);
            menu_usuario.TabIndex = 4;
            menu_usuario.Text = "Usuarios";
            // 
            // administrarUsuarioToolStripMenuItem
            // 
            administrarUsuarioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nuevoToolStripMenuItem, cargarDatosToolStripMenuItem });
            administrarUsuarioToolStripMenuItem.Name = "administrarUsuarioToolStripMenuItem";
            administrarUsuarioToolStripMenuItem.Size = new Size(78, 21);
            administrarUsuarioToolStripMenuItem.Text = "Gestionar";
            administrarUsuarioToolStripMenuItem.Click += administrarUsuarioToolStripMenuItem_Click;
            // 
            // nuevoToolStripMenuItem
            // 
            nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            nuevoToolStripMenuItem.Size = new Size(162, 22);
            nuevoToolStripMenuItem.Text = "Nuevo Usuario";
            nuevoToolStripMenuItem.Click += nuevoToolStripMenuItem_Click;
            // 
            // cargarDatosToolStripMenuItem
            // 
            cargarDatosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { productosToolStripMenuItem, clientesToolStripMenuItem });
            cargarDatosToolStripMenuItem.Name = "cargarDatosToolStripMenuItem";
            cargarDatosToolStripMenuItem.Size = new Size(162, 22);
            cargarDatosToolStripMenuItem.Text = "Cargar Datos";
            // 
            // productosToolStripMenuItem
            // 
            productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            productosToolStripMenuItem.Size = new Size(136, 22);
            productosToolStripMenuItem.Text = "Productos";
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(136, 22);
            clientesToolStripMenuItem.Text = "Clientes";
            clientesToolStripMenuItem.Click += clientesToolStripMenuItem_Click;
            // 
            // btn_cerrarsesion
            // 
            btn_cerrarsesion.BackColor = Color.LightGray;
            btn_cerrarsesion.Dock = DockStyle.Fill;
            btn_cerrarsesion.FlatStyle = FlatStyle.Popup;
            btn_cerrarsesion.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_cerrarsesion.ForeColor = Color.Black;
            btn_cerrarsesion.Image = (Image)resources.GetObject("btn_cerrarsesion.Image");
            btn_cerrarsesion.ImageAlign = ContentAlignment.MiddleLeft;
            btn_cerrarsesion.Location = new Point(477, 2);
            btn_cerrarsesion.Margin = new Padding(3, 2, 3, 2);
            btn_cerrarsesion.Name = "btn_cerrarsesion";
            btn_cerrarsesion.Size = new Size(152, 29);
            btn_cerrarsesion.TabIndex = 4;
            btn_cerrarsesion.Text = "  Cerrar sesión";
            btn_cerrarsesion.UseVisualStyleBackColor = false;
            btn_cerrarsesion.Click += btn_cerrarsesion_Click;
            btn_cerrarsesion.MouseEnter += btn_cerrarsesion_MouseEnter;
            btn_cerrarsesion.MouseLeave += btn_cerrarsesion_MouseLeave;
            // 
            // materialButton3
            // 
            materialButton3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton3.Depth = 0;
            materialButton3.Dock = DockStyle.Fill;
            materialButton3.HighEmphasis = true;
            materialButton3.Icon = null;
            materialButton3.Location = new Point(320, 4);
            materialButton3.Margin = new Padding(4);
            materialButton3.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton3.Name = "materialButton3";
            materialButton3.NoAccentTextColor = Color.Empty;
            materialButton3.Size = new Size(150, 25);
            materialButton3.TabIndex = 3;
            materialButton3.Text = "Clientes";
            materialButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton3.UseAccentColor = false;
            materialButton3.UseVisualStyleBackColor = true;
            materialButton3.Click += materialButton3_Click;
            // 
            // materialButton2
            // 
            materialButton2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton2.Depth = 0;
            materialButton2.Dock = DockStyle.Fill;
            materialButton2.HighEmphasis = true;
            materialButton2.Icon = null;
            materialButton2.Location = new Point(162, 4);
            materialButton2.Margin = new Padding(4);
            materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton2.Name = "materialButton2";
            materialButton2.NoAccentTextColor = Color.Empty;
            materialButton2.Size = new Size(150, 25);
            materialButton2.TabIndex = 2;
            materialButton2.Text = "Cotización";
            materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton2.UseAccentColor = false;
            materialButton2.UseVisualStyleBackColor = true;
            materialButton2.Click += materialButton2_Click;
            // 
            // btn_inventarioP
            // 
            btn_inventarioP.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_inventarioP.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_inventarioP.Depth = 0;
            btn_inventarioP.HighEmphasis = true;
            btn_inventarioP.Icon = null;
            btn_inventarioP.Image = (Image)resources.GetObject("btn_inventarioP.Image");
            btn_inventarioP.ImageAlign = ContentAlignment.MiddleLeft;
            btn_inventarioP.Location = new Point(4, 4);
            btn_inventarioP.Margin = new Padding(4);
            btn_inventarioP.MouseState = MaterialSkin.MouseState.HOVER;
            btn_inventarioP.Name = "btn_inventarioP";
            btn_inventarioP.NoAccentTextColor = Color.Empty;
            btn_inventarioP.Size = new Size(107, 25);
            btn_inventarioP.TabIndex = 1;
            btn_inventarioP.Text = "Inventario";
            btn_inventarioP.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_inventarioP.UseAccentColor = false;
            btn_inventarioP.UseVisualStyleBackColor = true;
            btn_inventarioP.Click += btn_inventarioP_Click;
            btn_inventarioP.MouseEnter += materialButton1_MouseEnter;
            btn_inventarioP.MouseLeave += btn_inventarioP_MouseLeave;
            // 
            // materialSwitch1
            // 
            materialSwitch1.Anchor = AnchorStyles.Right;
            materialSwitch1.AutoSize = true;
            materialSwitch1.BackColor = Color.FromArgb(0, 81, 46);
            materialSwitch1.Depth = 0;
            materialSwitch1.Location = new Point(694, 0);
            materialSwitch1.Margin = new Padding(0);
            materialSwitch1.MouseLocation = new Point(-1, -1);
            materialSwitch1.MouseState = MaterialSkin.MouseState.HOVER;
            materialSwitch1.Name = "materialSwitch1";
            materialSwitch1.Ripple = true;
            materialSwitch1.Size = new Size(99, 33);
            materialSwitch1.TabIndex = 6;
            materialSwitch1.Text = "Tema";
            materialSwitch1.UseVisualStyleBackColor = false;
            materialSwitch1.CheckedChanged += materialSwitch1_CheckedChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 5;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel1.Controls.Add(btn_cerrarsesion, 3, 0);
            tableLayoutPanel1.Controls.Add(materialSwitch1, 4, 0);
            tableLayoutPanel1.Controls.Add(materialButton3, 2, 0);
            tableLayoutPanel1.Controls.Add(btn_inventarioP, 0, 0);
            tableLayoutPanel1.Controls.Add(materialButton2, 1, 0);
            tableLayoutPanel1.Location = new Point(225, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(793, 33);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // panelContenedor
            // 
            panelContenedor.Controls.Add(tableLayoutPanel1);
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(3, 48);
            panelContenedor.Margin = new Padding(3, 2, 3, 2);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(1018, 518);
            panelContenedor.TabIndex = 8;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 81, 46);
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Controls.Add(panel2);
            panel1.Cursor = Cursors.IBeam;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(3, 48);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(219, 518);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // ENSUMEX
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 192, 0);
            ClientSize = new Size(1024, 568);
            Controls.Add(panel1);
            Controls.Add(panelContenedor);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ENSUMEX";
            Padding = new Padding(3, 48, 3, 2);
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += ENSUMEX_FormClosing;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            menu_usuario.ResumeLayout(false);
            menu_usuario.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panelContenedor.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private TextBox txt_usuario;
        private Label lbl_posicion;
        private Button btn_cerrarsesion;
        private MenuStrip menu_usuario;
        private ToolStripMenuItem administrarUsuarioToolStripMenuItem;
        private ToolStripMenuItem nuevoToolStripMenuItem;
        private Label lbl_usuario;
        private TableLayoutPanel tableLayoutPanel2;
        private MaterialSkin.Controls.MaterialButton btn_inventarioP;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialButton materialButton3;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panelContenedor;
        private ToolStripMenuItem cargarDatosToolStripMenuItem;
        private ToolStripMenuItem productosToolStripMenuItem;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private Panel panel1;
    }
}