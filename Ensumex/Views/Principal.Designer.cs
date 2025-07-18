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
            tableLayoutPanel1 = new TableLayoutPanel();
            materialSwitch1 = new MaterialSkin.Controls.MaterialSwitch();
            panelContenedor = new Panel();
            panel1 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            Btn_Inicio = new MaterialSkin.Controls.MaterialButton();
            btn_cerrarsesion = new Button();
            progressBar1 = new ProgressBar();
            btn_sincronizar = new MaterialSkin.Controls.MaterialButton();
            materialButton3 = new MaterialSkin.Controls.MaterialButton();
            materialButton2 = new MaterialSkin.Controls.MaterialButton();
            btn_inventarioP = new MaterialSkin.Controls.MaterialButton();
            panel2 = new Panel();
            lbl_UsuarioInicio = new Label();
            lbl_posicion = new Label();
            menu_usuario = new MenuStrip();
            administrarUsuarioToolStripMenuItem = new ToolStripMenuItem();
            nuevoToolStripMenuItem = new ToolStripMenuItem();
            cargarDatosToolStripMenuItem = new ToolStripMenuItem();
            productosToolStripMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            miniToolStrip = new MenuStrip();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel2.SuspendLayout();
            menu_usuario.SuspendLayout();
            tableLayoutPanel4.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(materialSwitch1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(3, 48);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1018, 15);
            tableLayoutPanel1.TabIndex = 7;
            // 
            // materialSwitch1
            // 
            materialSwitch1.Anchor = AnchorStyles.Right;
            materialSwitch1.AutoSize = true;
            materialSwitch1.BackColor = Color.FromArgb(0, 81, 46);
            materialSwitch1.Depth = 0;
            materialSwitch1.Location = new Point(919, 0);
            materialSwitch1.Margin = new Padding(0);
            materialSwitch1.MouseLocation = new Point(-1, -1);
            materialSwitch1.MouseState = MaterialSkin.MouseState.HOVER;
            materialSwitch1.Name = "materialSwitch1";
            materialSwitch1.Ripple = true;
            materialSwitch1.Size = new Size(99, 15);
            materialSwitch1.TabIndex = 6;
            materialSwitch1.Text = "Tema";
            materialSwitch1.UseVisualStyleBackColor = false;
            materialSwitch1.CheckedChanged += materialSwitch1_CheckedChanged;
            // 
            // panelContenedor
            // 
            panelContenedor.BackColor = Color.White;
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(3, 2);
            panelContenedor.Margin = new Padding(3, 2, 3, 2);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(814, 499);
            panelContenedor.TabIndex = 8;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 81, 46);
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Controls.Add(panel2);
            panel1.Cursor = Cursors.IBeam;
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(3, 63);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(198, 503);
            panel1.TabIndex = 2;
            panel1.Paint += panel1_Paint;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = SystemColors.Control;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add(Btn_Inicio, 0, 0);
            tableLayoutPanel2.Controls.Add(btn_cerrarsesion, 0, 6);
            tableLayoutPanel2.Controls.Add(progressBar1, 0, 5);
            tableLayoutPanel2.Controls.Add(btn_sincronizar, 0, 4);
            tableLayoutPanel2.Controls.Add(materialButton3, 0, 3);
            tableLayoutPanel2.Controls.Add(materialButton2, 0, 2);
            tableLayoutPanel2.Controls.Add(btn_inventarioP, 0, 1);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 79);
            tableLayoutPanel2.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 7;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857113F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanel2.Size = new Size(198, 424);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // Btn_Inicio
            // 
            Btn_Inicio.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Btn_Inicio.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Btn_Inicio.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            Btn_Inicio.Depth = 0;
            Btn_Inicio.HighEmphasis = true;
            Btn_Inicio.Icon = (Image)resources.GetObject("Btn_Inicio.Icon");
            Btn_Inicio.Image = (Image)resources.GetObject("Btn_Inicio.Image");
            Btn_Inicio.ImageAlign = ContentAlignment.MiddleLeft;
            Btn_Inicio.Location = new Point(4, 12);
            Btn_Inicio.Margin = new Padding(4);
            Btn_Inicio.MouseState = MaterialSkin.MouseState.HOVER;
            Btn_Inicio.Name = "Btn_Inicio";
            Btn_Inicio.NoAccentTextColor = Color.Empty;
            Btn_Inicio.Size = new Size(195, 36);
            Btn_Inicio.TabIndex = 1;
            Btn_Inicio.Text = "Inicio";
            Btn_Inicio.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            Btn_Inicio.UseAccentColor = false;
            Btn_Inicio.UseVisualStyleBackColor = true;
            Btn_Inicio.Click += Btn_Inicio_Click;
            // 
            // btn_cerrarsesion
            // 
            btn_cerrarsesion.BackColor = Color.LightGray;
            btn_cerrarsesion.Dock = DockStyle.Bottom;
            btn_cerrarsesion.FlatStyle = FlatStyle.Popup;
            btn_cerrarsesion.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_cerrarsesion.ForeColor = Color.Black;
            btn_cerrarsesion.Image = (Image)resources.GetObject("btn_cerrarsesion.Image");
            btn_cerrarsesion.ImageAlign = ContentAlignment.MiddleLeft;
            btn_cerrarsesion.Location = new Point(3, 393);
            btn_cerrarsesion.Margin = new Padding(3, 2, 3, 2);
            btn_cerrarsesion.Name = "btn_cerrarsesion";
            btn_cerrarsesion.Size = new Size(197, 29);
            btn_cerrarsesion.TabIndex = 6;
            btn_cerrarsesion.Text = "  Cerrar sesión";
            btn_cerrarsesion.UseVisualStyleBackColor = false;
            btn_cerrarsesion.Click += btn_cerrarsesion_Click;
            btn_cerrarsesion.MouseEnter += btn_cerrarsesion_MouseEnter;
            btn_cerrarsesion.MouseLeave += btn_cerrarsesion_MouseLeave;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(3, 320);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(197, 20);
            progressBar1.TabIndex = 12;
            // 
            // btn_sincronizar
            // 
            btn_sincronizar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btn_sincronizar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_sincronizar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_sincronizar.Depth = 0;
            btn_sincronizar.HighEmphasis = true;
            btn_sincronizar.Icon = (Image)resources.GetObject("btn_sincronizar.Icon");
            btn_sincronizar.Location = new Point(4, 252);
            btn_sincronizar.Margin = new Padding(4, 6, 4, 6);
            btn_sincronizar.MouseState = MaterialSkin.MouseState.HOVER;
            btn_sincronizar.Name = "btn_sincronizar";
            btn_sincronizar.NoAccentTextColor = Color.Empty;
            btn_sincronizar.Size = new Size(195, 36);
            btn_sincronizar.TabIndex = 5;
            btn_sincronizar.Text = "Sincronizar Datos";
            btn_sincronizar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_sincronizar.UseAccentColor = false;
            btn_sincronizar.UseVisualStyleBackColor = true;
            btn_sincronizar.Click += btn_sincronizar_Click;
            // 
            // materialButton3
            // 
            materialButton3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            materialButton3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton3.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton3.Depth = 0;
            materialButton3.HighEmphasis = true;
            materialButton3.Icon = (Image)resources.GetObject("materialButton3.Icon");
            materialButton3.Location = new Point(4, 192);
            materialButton3.Margin = new Padding(4);
            materialButton3.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton3.Name = "materialButton3";
            materialButton3.NoAccentTextColor = Color.Empty;
            materialButton3.Size = new Size(195, 36);
            materialButton3.TabIndex = 4;
            materialButton3.Text = "Clientes";
            materialButton3.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton3.UseAccentColor = false;
            materialButton3.UseVisualStyleBackColor = true;
            materialButton3.Click += materialButton3_Click;
            // 
            // materialButton2
            // 
            materialButton2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            materialButton2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton2.Depth = 0;
            materialButton2.HighEmphasis = true;
            materialButton2.Icon = (Image)resources.GetObject("materialButton2.Icon");
            materialButton2.Location = new Point(4, 132);
            materialButton2.Margin = new Padding(4);
            materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton2.Name = "materialButton2";
            materialButton2.NoAccentTextColor = Color.Empty;
            materialButton2.Size = new Size(195, 36);
            materialButton2.TabIndex = 3;
            materialButton2.Text = "Cotización";
            materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton2.UseAccentColor = false;
            materialButton2.UseVisualStyleBackColor = true;
            materialButton2.Click += materialButton2_Click;
            // 
            // btn_inventarioP
            // 
            btn_inventarioP.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btn_inventarioP.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_inventarioP.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btn_inventarioP.Depth = 0;
            btn_inventarioP.HighEmphasis = true;
            btn_inventarioP.Icon = (Image)resources.GetObject("btn_inventarioP.Icon");
            btn_inventarioP.Image = (Image)resources.GetObject("btn_inventarioP.Image");
            btn_inventarioP.ImageAlign = ContentAlignment.MiddleLeft;
            btn_inventarioP.Location = new Point(4, 72);
            btn_inventarioP.Margin = new Padding(4);
            btn_inventarioP.MouseState = MaterialSkin.MouseState.HOVER;
            btn_inventarioP.Name = "btn_inventarioP";
            btn_inventarioP.NoAccentTextColor = Color.Empty;
            btn_inventarioP.Size = new Size(195, 36);
            btn_inventarioP.TabIndex = 2;
            btn_inventarioP.Text = "Inventario";
            btn_inventarioP.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btn_inventarioP.UseAccentColor = false;
            btn_inventarioP.UseVisualStyleBackColor = true;
            btn_inventarioP.Click += btn_inventarioP_Click;
            btn_inventarioP.MouseEnter += materialButton1_MouseEnter;
            btn_inventarioP.MouseLeave += btn_inventarioP_MouseLeave;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Control;
            panel2.Controls.Add(lbl_UsuarioInicio);
            panel2.Controls.Add(lbl_posicion);
            panel2.Controls.Add(menu_usuario);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(198, 79);
            panel2.TabIndex = 1;
            // 
            // lbl_UsuarioInicio
            // 
            lbl_UsuarioInicio.Anchor = AnchorStyles.Left;
            lbl_UsuarioInicio.AutoSize = true;
            lbl_UsuarioInicio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_UsuarioInicio.ForeColor = SystemColors.ControlText;
            lbl_UsuarioInicio.Location = new Point(0, 56);
            lbl_UsuarioInicio.Name = "lbl_UsuarioInicio";
            lbl_UsuarioInicio.Size = new Size(123, 21);
            lbl_UsuarioInicio.TabIndex = 5;
            lbl_UsuarioInicio.Text = "nombre Usuario";
            // 
            // lbl_posicion
            // 
            lbl_posicion.Anchor = AnchorStyles.None;
            lbl_posicion.AutoSize = true;
            lbl_posicion.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_posicion.ForeColor = SystemColors.ControlText;
            lbl_posicion.Location = new Point(47, 25);
            lbl_posicion.Name = "lbl_posicion";
            lbl_posicion.Size = new Size(83, 23);
            lbl_posicion.TabIndex = 3;
            lbl_posicion.Text = "Cuenta:";
            // 
            // menu_usuario
            // 
            menu_usuario.BackColor = SystemColors.Control;
            menu_usuario.BackgroundImageLayout = ImageLayout.None;
            menu_usuario.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            menu_usuario.ImageScalingSize = new Size(20, 20);
            menu_usuario.Items.AddRange(new ToolStripItem[] { administrarUsuarioToolStripMenuItem });
            menu_usuario.Location = new Point(0, 0);
            menu_usuario.Name = "menu_usuario";
            menu_usuario.Padding = new Padding(5, 2, 0, 2);
            menu_usuario.RenderMode = ToolStripRenderMode.System;
            menu_usuario.Size = new Size(198, 25);
            menu_usuario.TabIndex = 4;
            menu_usuario.Text = "Usuarios";
            // 
            // administrarUsuarioToolStripMenuItem
            // 
            administrarUsuarioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nuevoToolStripMenuItem, cargarDatosToolStripMenuItem });
            administrarUsuarioToolStripMenuItem.Name = "administrarUsuarioToolStripMenuItem";
            administrarUsuarioToolStripMenuItem.Size = new Size(78, 21);
            administrarUsuarioToolStripMenuItem.Text = "Gestionar";
            // 
            // nuevoToolStripMenuItem
            // 
            nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            nuevoToolStripMenuItem.Size = new Size(180, 22);
            nuevoToolStripMenuItem.Text = "Nuevo Usuario";
            nuevoToolStripMenuItem.Click += nuevoToolStripMenuItem_Click;
            // 
            // cargarDatosToolStripMenuItem
            // 
            cargarDatosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { productosToolStripMenuItem, clientesToolStripMenuItem });
            cargarDatosToolStripMenuItem.Name = "cargarDatosToolStripMenuItem";
            cargarDatosToolStripMenuItem.Size = new Size(180, 22);
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
            // 
            // miniToolStrip
            // 
            miniToolStrip.AccessibleName = "Selección de nuevo elemento";
            miniToolStrip.AccessibleRole = AccessibleRole.ComboBox;
            miniToolStrip.AutoSize = false;
            miniToolStrip.BackColor = Color.FromArgb(0, 81, 46);
            miniToolStrip.BackgroundImageLayout = ImageLayout.None;
            miniToolStrip.Dock = DockStyle.None;
            miniToolStrip.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            miniToolStrip.ImageScalingSize = new Size(20, 20);
            miniToolStrip.Location = new Point(0, 0);
            miniToolStrip.Name = "miniToolStrip";
            miniToolStrip.Padding = new Padding(5, 2, 0, 2);
            miniToolStrip.RenderMode = ToolStripRenderMode.System;
            miniToolStrip.Size = new Size(198, 25);
            miniToolStrip.TabIndex = 4;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.BackColor = Color.White;
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel4.Controls.Add(panelContenedor, 0, 0);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(201, 63);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 1;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Size = new Size(820, 503);
            tableLayoutPanel4.TabIndex = 10;
            // 
            // ENSUMEX
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1024, 568);
            Controls.Add(tableLayoutPanel4);
            Controls.Add(panel1);
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ENSUMEX";
            Padding = new Padding(3, 48, 3, 2);
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += ENSUMEX_FormClosing;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            menu_usuario.ResumeLayout(false);
            menu_usuario.PerformLayout();
            tableLayoutPanel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialSwitch materialSwitch1;
        private Panel panelContenedor;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btn_cerrarsesion;
        private MaterialSkin.Controls.MaterialButton btn_inventarioP;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialButton materialButton3;
        private Panel panel1;
        private Panel panel2;
        private Label lbl_UsuarioInicio;
        private Label lbl_posicion;
        private MenuStrip menu_usuario;
        private ToolStripMenuItem administrarUsuarioToolStripMenuItem;
        private ToolStripMenuItem nuevoToolStripMenuItem;
        private ToolStripMenuItem cargarDatosToolStripMenuItem;
        private ToolStripMenuItem productosToolStripMenuItem;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private MenuStrip miniToolStrip;
        private TableLayoutPanel tableLayoutPanel4;
        private MaterialSkin.Controls.MaterialButton btn_sincronizar;
        private ProgressBar progressBar1;
        private MaterialSkin.Controls.MaterialButton Btn_Inicio;
    }
}