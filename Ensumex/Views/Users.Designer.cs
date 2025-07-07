namespace Ensumex.Views
{
    partial class Users
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Users));
            tableLayoutPanel2 = new TableLayoutPanel();
            btn_nuevoUsuario = new Button();
            lbl_NuevoUsuario = new Label();
            Tabla_usuarios = new DataGridView();
            Panel_Nuevousuario = new TableLayoutPanel();
            lbl1_usuariocrear = new Label();
            btn_GuardarUsuario = new Button();
            btn_Cancelar = new Button();
            textnewUsuario = new TextBox();
            textNewContraseña = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textNewNombre = new TextBox();
            label3 = new Label();
            label4 = new Label();
            textNewCorreo = new TextBox();
            cmb_NewPosicion = new ComboBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Tabla_usuarios).BeginInit();
            Panel_Nuevousuario.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 5;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel2.Controls.Add(btn_nuevoUsuario, 3, 0);
            tableLayoutPanel2.Controls.Add(lbl_NuevoUsuario, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Top;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(916, 54);
            tableLayoutPanel2.TabIndex = 18;
            // 
            // btn_nuevoUsuario
            // 
            btn_nuevoUsuario.BackColor = Color.Green;
            btn_nuevoUsuario.Image = (Image)resources.GetObject("btn_nuevoUsuario.Image");
            btn_nuevoUsuario.ImageAlign = ContentAlignment.MiddleLeft;
            btn_nuevoUsuario.Location = new Point(552, 2);
            btn_nuevoUsuario.Margin = new Padding(3, 2, 3, 2);
            btn_nuevoUsuario.Name = "btn_nuevoUsuario";
            btn_nuevoUsuario.Size = new Size(125, 38);
            btn_nuevoUsuario.TabIndex = 1;
            btn_nuevoUsuario.Text = "Nuevo";
            btn_nuevoUsuario.UseVisualStyleBackColor = false;
            btn_nuevoUsuario.Click += btn_nuevoUsuario_Click;
            // 
            // lbl_NuevoUsuario
            // 
            lbl_NuevoUsuario.Anchor = AnchorStyles.Right;
            lbl_NuevoUsuario.AutoSize = true;
            lbl_NuevoUsuario.Location = new Point(47, 19);
            lbl_NuevoUsuario.Name = "lbl_NuevoUsuario";
            lbl_NuevoUsuario.Size = new Size(133, 15);
            lbl_NuevoUsuario.TabIndex = 2;
            lbl_NuevoUsuario.Text = "Agregar Nuevo Usuario:";
            // 
            // Tabla_usuarios
            // 
            Tabla_usuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Tabla_usuarios.Dock = DockStyle.Fill;
            Tabla_usuarios.Location = new Point(3, 298);
            Tabla_usuarios.Margin = new Padding(3, 2, 3, 2);
            Tabla_usuarios.Name = "Tabla_usuarios";
            Tabla_usuarios.RowHeadersWidth = 51;
            Tabla_usuarios.Size = new Size(910, 292);
            Tabla_usuarios.TabIndex = 20;
            Tabla_usuarios.CellClick += Tabla_usuarios_CellClick;
            // 
            // Panel_Nuevousuario
            // 
            Panel_Nuevousuario.ColumnCount = 4;
            Panel_Nuevousuario.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.4630871F));
            Panel_Nuevousuario.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.8456383F));
            Panel_Nuevousuario.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.5950775F));
            Panel_Nuevousuario.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30.8724823F));
            Panel_Nuevousuario.Controls.Add(lbl1_usuariocrear, 0, 0);
            Panel_Nuevousuario.Controls.Add(btn_GuardarUsuario, 3, 2);
            Panel_Nuevousuario.Controls.Add(btn_Cancelar, 2, 2);
            Panel_Nuevousuario.Controls.Add(textnewUsuario, 1, 0);
            Panel_Nuevousuario.Controls.Add(textNewContraseña, 3, 0);
            Panel_Nuevousuario.Controls.Add(label1, 2, 0);
            Panel_Nuevousuario.Controls.Add(label2, 0, 1);
            Panel_Nuevousuario.Controls.Add(textNewNombre, 1, 1);
            Panel_Nuevousuario.Controls.Add(label3, 0, 2);
            Panel_Nuevousuario.Controls.Add(label4, 2, 1);
            Panel_Nuevousuario.Controls.Add(textNewCorreo, 3, 1);
            Panel_Nuevousuario.Controls.Add(cmb_NewPosicion, 1, 2);
            Panel_Nuevousuario.Dock = DockStyle.Fill;
            Panel_Nuevousuario.Location = new Point(3, 2);
            Panel_Nuevousuario.Margin = new Padding(3, 2, 3, 2);
            Panel_Nuevousuario.Name = "Panel_Nuevousuario";
            Panel_Nuevousuario.RowCount = 3;
            Panel_Nuevousuario.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            Panel_Nuevousuario.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            Panel_Nuevousuario.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            Panel_Nuevousuario.Size = new Size(910, 292);
            Panel_Nuevousuario.TabIndex = 20;
            // 
            // lbl1_usuariocrear
            // 
            lbl1_usuariocrear.Anchor = AnchorStyles.None;
            lbl1_usuariocrear.AutoSize = true;
            lbl1_usuariocrear.Location = new Point(63, 41);
            lbl1_usuariocrear.Name = "lbl1_usuariocrear";
            lbl1_usuariocrear.Size = new Size(50, 15);
            lbl1_usuariocrear.TabIndex = 6;
            lbl1_usuariocrear.Text = "Usuario:";
            // 
            // btn_GuardarUsuario
            // 
            btn_GuardarUsuario.Anchor = AnchorStyles.None;
            btn_GuardarUsuario.BackColor = SystemColors.Control;
            btn_GuardarUsuario.FlatStyle = FlatStyle.Flat;
            btn_GuardarUsuario.ForeColor = Color.Green;
            btn_GuardarUsuario.Location = new Point(717, 231);
            btn_GuardarUsuario.Margin = new Padding(3, 2, 3, 2);
            btn_GuardarUsuario.Name = "btn_GuardarUsuario";
            btn_GuardarUsuario.Size = new Size(103, 23);
            btn_GuardarUsuario.TabIndex = 15;
            btn_GuardarUsuario.Text = "Guardar";
            btn_GuardarUsuario.UseVisualStyleBackColor = false;
            btn_GuardarUsuario.Click += btn_GuardarUsuario_Click;
            // 
            // btn_Cancelar
            // 
            btn_Cancelar.Anchor = AnchorStyles.None;
            btn_Cancelar.BackColor = SystemColors.Control;
            btn_Cancelar.FlatStyle = FlatStyle.Flat;
            btn_Cancelar.ForeColor = Color.Red;
            btn_Cancelar.Location = new Point(471, 231);
            btn_Cancelar.Margin = new Padding(3, 2, 3, 2);
            btn_Cancelar.Name = "btn_Cancelar";
            btn_Cancelar.Size = new Size(105, 23);
            btn_Cancelar.TabIndex = 16;
            btn_Cancelar.Text = "Cancelar";
            btn_Cancelar.UseVisualStyleBackColor = false;
            btn_Cancelar.Click += btn_Cancelar_Click_1;
            // 
            // textnewUsuario
            // 
            textnewUsuario.Anchor = AnchorStyles.Left;
            textnewUsuario.BackColor = Color.Silver;
            textnewUsuario.Location = new Point(180, 37);
            textnewUsuario.Margin = new Padding(3, 2, 3, 2);
            textnewUsuario.Name = "textnewUsuario";
            textnewUsuario.Size = new Size(238, 23);
            textnewUsuario.TabIndex = 4;
            // 
            // textNewContraseña
            // 
            textNewContraseña.Anchor = AnchorStyles.Left;
            textNewContraseña.BackColor = Color.Silver;
            textNewContraseña.Location = new Point(630, 37);
            textNewContraseña.Margin = new Padding(3, 2, 3, 2);
            textNewContraseña.Name = "textNewContraseña";
            textNewContraseña.Size = new Size(277, 23);
            textNewContraseña.TabIndex = 5;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(489, 41);
            label1.Name = "label1";
            label1.Size = new Size(70, 15);
            label1.TabIndex = 9;
            label1.Text = "Contraseña:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(61, 138);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 10;
            label2.Text = "Nombre:";
            // 
            // textNewNombre
            // 
            textNewNombre.Anchor = AnchorStyles.Left;
            textNewNombre.BackColor = Color.Silver;
            textNewNombre.Location = new Point(180, 134);
            textNewNombre.Margin = new Padding(3, 2, 3, 2);
            textNewNombre.Name = "textNewNombre";
            textNewNombre.Size = new Size(238, 23);
            textNewNombre.TabIndex = 6;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(61, 235);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 12;
            label3.Text = "Posición:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Location = new Point(501, 138);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 14;
            label4.Text = "Correo:";
            // 
            // textNewCorreo
            // 
            textNewCorreo.Anchor = AnchorStyles.Left;
            textNewCorreo.BackColor = Color.Silver;
            textNewCorreo.Location = new Point(630, 134);
            textNewCorreo.Margin = new Padding(3, 2, 3, 2);
            textNewCorreo.Name = "textNewCorreo";
            textNewCorreo.Size = new Size(277, 23);
            textNewCorreo.TabIndex = 8;
            // 
            // cmb_NewPosicion
            // 
            cmb_NewPosicion.Anchor = AnchorStyles.Left;
            cmb_NewPosicion.BackColor = Color.Silver;
            cmb_NewPosicion.FormattingEnabled = true;
            cmb_NewPosicion.Items.AddRange(new object[] { "Administrador", "Vendedor" });
            cmb_NewPosicion.Location = new Point(180, 231);
            cmb_NewPosicion.Margin = new Padding(3, 2, 3, 2);
            cmb_NewPosicion.Name = "cmb_NewPosicion";
            cmb_NewPosicion.Size = new Size(238, 23);
            cmb_NewPosicion.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(Tabla_usuarios, 0, 1);
            tableLayoutPanel1.Controls.Add(Panel_Nuevousuario, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.Location = new Point(0, 54);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(916, 592);
            tableLayoutPanel1.TabIndex = 19;
            // 
            // Users
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tableLayoutPanel2);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Users";
            Size = new Size(916, 701);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Tabla_usuarios).EndInit();
            Panel_Nuevousuario.ResumeLayout(false);
            Panel_Nuevousuario.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel2;
        private Button btn_nuevoUsuario;
        private Label lbl_NuevoUsuario;
        private DataGridView Tabla_usuarios;
        private TableLayoutPanel Panel_Nuevousuario;
        private Label lbl1_usuariocrear;
        private Button btn_GuardarUsuario;
        private Button btn_Cancelar;
        private TextBox textnewUsuario;
        private TextBox textNewContraseña;
        private Label label1;
        private Label label2;
        private TextBox textNewNombre;
        private Label label3;
        private Label label4;
        private TextBox textNewCorreo;
        private ComboBox cmb_NewPosicion;
        private TableLayoutPanel tableLayoutPanel1;
    }
}
