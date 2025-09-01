using System.Windows.Forms;

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
            BtnCerrar = new FontAwesome.Sharp.IconButton();
            BtnClient = new FontAwesome.Sharp.IconButton();
            BtnSincroniza = new FontAwesome.Sharp.IconButton();
            BtnCotiza = new FontAwesome.Sharp.IconButton();
            BtnInve = new FontAwesome.Sharp.IconButton();
            BtnInicio = new FontAwesome.Sharp.IconButton();
            panel1 = new Panel();
            tableLayoutPanel2 = new TableLayoutPanel();
            Btn_Mantenimientos = new FontAwesome.Sharp.IconButton();
            Btn_Autonom = new FontAwesome.Sharp.IconButton();
            progressBar1 = new ProgressBar();
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
            panelContenedor.BackColor = SystemColors.Control;
            panelContenedor.Dock = DockStyle.Fill;
            panelContenedor.Location = new Point(3, 2);
            panelContenedor.Margin = new Padding(3, 2, 3, 2);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(814, 499);
            panelContenedor.TabIndex = 8;
            // 
            // BtnCerrar
            // 
            BtnCerrar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            BtnCerrar.IconChar = FontAwesome.Sharp.IconChar.None;
            BtnCerrar.IconColor = Color.Black;
            BtnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnCerrar.Location = new Point(3, 355);
            BtnCerrar.Name = "BtnCerrar";
            BtnCerrar.Size = new Size(197, 45);
            BtnCerrar.TabIndex = 6;
            BtnCerrar.Text = "Cerrar Sesión";
            BtnCerrar.UseVisualStyleBackColor = true;
            BtnCerrar.Click += BtnCerrar_Click;
            BtnCerrar.MouseEnter += Button_MouseEnter;
            BtnCerrar.MouseLeave += Button_MouseLeave;
            // 
            // BtnClient
            // 
            BtnClient.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            BtnClient.IconChar = FontAwesome.Sharp.IconChar.None;
            BtnClient.IconColor = Color.Black;
            BtnClient.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnClient.Location = new Point(3, 179);
            BtnClient.Name = "BtnClient";
            BtnClient.Size = new Size(197, 38);
            BtnClient.TabIndex = 4;
            BtnClient.Text = "CLIENTES";
            BtnClient.UseVisualStyleBackColor = true;
            BtnClient.Click += BtnClient_Click;
            BtnClient.MouseEnter += Button_MouseEnter;
            BtnClient.MouseLeave += Button_MouseLeave;
            // 
            // BtnSincroniza
            // 
            BtnSincroniza.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            BtnSincroniza.IconChar = FontAwesome.Sharp.IconChar.None;
            BtnSincroniza.IconColor = Color.Black;
            BtnSincroniza.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnSincroniza.Location = new Point(3, 267);
            BtnSincroniza.Name = "BtnSincroniza";
            BtnSincroniza.Size = new Size(197, 38);
            BtnSincroniza.TabIndex = 5;
            BtnSincroniza.Text = "SINCRONIZAR";
            BtnSincroniza.UseVisualStyleBackColor = true;
            BtnSincroniza.Click += BtnSincroniza_Click;
            BtnSincroniza.MouseEnter += Button_MouseEnter;
            BtnSincroniza.MouseLeave += Button_MouseLeave;
            // 
            // BtnCotiza
            // 
            BtnCotiza.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            BtnCotiza.IconChar = FontAwesome.Sharp.IconChar.None;
            BtnCotiza.IconColor = Color.Black;
            BtnCotiza.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnCotiza.Location = new Point(3, 91);
            BtnCotiza.Name = "BtnCotiza";
            BtnCotiza.Size = new Size(197, 38);
            BtnCotiza.TabIndex = 3;
            BtnCotiza.Text = "COTIZACIÓN";
            BtnCotiza.UseVisualStyleBackColor = true;
            BtnCotiza.Click += BtnCotiza_Click;
            BtnCotiza.MouseEnter += Button_MouseEnter;
            BtnCotiza.MouseLeave += Button_MouseLeave;
            // 
            // BtnInve
            // 
            BtnInve.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            BtnInve.IconChar = FontAwesome.Sharp.IconChar.None;
            BtnInve.IconColor = Color.Black;
            BtnInve.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnInve.Location = new Point(3, 47);
            BtnInve.Name = "BtnInve";
            BtnInve.Size = new Size(197, 38);
            BtnInve.TabIndex = 2;
            BtnInve.Text = "INVENTARIO";
            BtnInve.UseVisualStyleBackColor = true;
            BtnInve.Click += BtnInve_Click;
            BtnInve.MouseEnter += Button_MouseEnter;
            BtnInve.MouseLeave += Button_MouseLeave;
            // 
            // BtnInicio
            // 
            BtnInicio.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            BtnInicio.ForeColor = SystemColors.ControlText;
            BtnInicio.IconChar = FontAwesome.Sharp.IconChar.None;
            BtnInicio.IconColor = Color.Black;
            BtnInicio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtnInicio.Location = new Point(3, 3);
            BtnInicio.Name = "BtnInicio";
            BtnInicio.Size = new Size(197, 38);
            BtnInicio.TabIndex = 1;
            BtnInicio.Text = "INICIO";
            BtnInicio.UseVisualStyleBackColor = true;
            BtnInicio.Click += BtnInicio_Click;
            BtnInicio.MouseEnter += Button_MouseEnter;
            BtnInicio.MouseLeave += Button_MouseLeave;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Control;
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
            tableLayoutPanel2.Controls.Add(Btn_Mantenimientos, 0, 5);
            tableLayoutPanel2.Controls.Add(Btn_Autonom, 0, 3);
            tableLayoutPanel2.Controls.Add(BtnCotiza, 0, 2);
            tableLayoutPanel2.Controls.Add(BtnInve, 0, 1);
            tableLayoutPanel2.Controls.Add(BtnInicio, 0, 0);
            tableLayoutPanel2.Controls.Add(BtnClient, 0, 4);
            tableLayoutPanel2.Controls.Add(BtnCerrar, 0, 8);
            tableLayoutPanel2.Controls.Add(progressBar1, 0, 7);
            tableLayoutPanel2.Controls.Add(BtnSincroniza, 0, 6);
            tableLayoutPanel2.Dock = DockStyle.Left;
            tableLayoutPanel2.Location = new Point(0, 100);
            tableLayoutPanel2.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 9;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 11.1111107F));
            tableLayoutPanel2.Size = new Size(198, 403);
            tableLayoutPanel2.TabIndex = 5;
            // 
            // Btn_Mantenimientos
            // 
            Btn_Mantenimientos.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Btn_Mantenimientos.IconChar = FontAwesome.Sharp.IconChar.None;
            Btn_Mantenimientos.IconColor = Color.Black;
            Btn_Mantenimientos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Btn_Mantenimientos.Location = new Point(3, 223);
            Btn_Mantenimientos.Name = "Btn_Mantenimientos";
            Btn_Mantenimientos.Size = new Size(197, 38);
            Btn_Mantenimientos.TabIndex = 14;
            Btn_Mantenimientos.Text = "MANTENIMIENTOS";
            Btn_Mantenimientos.UseVisualStyleBackColor = true;
            Btn_Mantenimientos.Click += iconButton1_Click_1;
            Btn_Mantenimientos.MouseEnter += Btn_Mantenimientos_MouseEnter;
            Btn_Mantenimientos.MouseLeave += Btn_Mantenimientos_MouseLeave;
            // 
            // Btn_Autonom
            // 
            Btn_Autonom.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Btn_Autonom.IconChar = FontAwesome.Sharp.IconChar.None;
            Btn_Autonom.IconColor = Color.Black;
            Btn_Autonom.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Btn_Autonom.Location = new Point(3, 135);
            Btn_Autonom.Name = "Btn_Autonom";
            Btn_Autonom.Size = new Size(197, 38);
            Btn_Autonom.TabIndex = 13;
            Btn_Autonom.Text = "AUTONOMOS";
            Btn_Autonom.UseVisualStyleBackColor = true;
            Btn_Autonom.Click += iconButton1_Click;
            Btn_Autonom.MouseEnter += Btn_Autonom_MouseEnter;
            Btn_Autonom.MouseLeave += Btn_Autonom_MouseLeave;
            // 
            // progressBar1
            // 
            progressBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            progressBar1.Location = new Point(3, 311);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(197, 20);
            progressBar1.TabIndex = 12;
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
            panel2.Size = new Size(198, 100);
            panel2.TabIndex = 1;
            // 
            // lbl_UsuarioInicio
            // 
            lbl_UsuarioInicio.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lbl_UsuarioInicio.AutoSize = true;
            lbl_UsuarioInicio.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_UsuarioInicio.ForeColor = SystemColors.ControlText;
            lbl_UsuarioInicio.Location = new Point(0, 67);
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
            lbl_posicion.Location = new Point(47, 36);
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
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "ENSUMEX";
            Padding = new Padding(3, 48, 3, 2);
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += ENSUMEX_FormClosing;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
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
        private ProgressBar progressBar1;
        private FontAwesome.Sharp.IconButton BtnClient;
        private FontAwesome.Sharp.IconButton BtnSincroniza;
        private FontAwesome.Sharp.IconButton BtnCotiza;
        private FontAwesome.Sharp.IconButton BtnInve;
        private FontAwesome.Sharp.IconButton BtnInicio;
        private FontAwesome.Sharp.IconButton BtnCerrar;
        private FontAwesome.Sharp.IconButton Btn_Autonom;
        private FontAwesome.Sharp.IconButton Btn_Mantenimientos;
    }
}