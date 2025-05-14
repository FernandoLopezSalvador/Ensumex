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
            FormNuevoUsuario = new TableLayoutPanel();
            lbl1_usuariocrear = new Label();
            btn_GuardarUsuario = new Button();
            btn_Cancelar = new Button();
            textnewUsuario = new TextBox();
            textNewContraseña = new TextBox();
            label1 = new Label();
            label2 = new Label();
            cmb_NewPosicion = new ComboBox();
            textNewNombre = new TextBox();
            label3 = new Label();
            label4 = new Label();
            textNewCorreo = new TextBox();
            Tabla_usuarios = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            lbl_NuevoUsuario = new Label();
            tableLayoutPanel2.SuspendLayout();
            FormNuevoUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Tabla_usuarios).BeginInit();
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
            tableLayoutPanel2.Controls.Add(lbl_NuevoUsuario, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Top;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(1047, 72);
            tableLayoutPanel2.TabIndex = 18;
            // 
            // btn_nuevoUsuario
            // 
            btn_nuevoUsuario.BackColor = Color.Green;
            btn_nuevoUsuario.Image = (Image)resources.GetObject("btn_nuevoUsuario.Image");
            btn_nuevoUsuario.ImageAlign = ContentAlignment.MiddleLeft;
            btn_nuevoUsuario.Location = new Point(630, 3);
            btn_nuevoUsuario.Name = "btn_nuevoUsuario";
            btn_nuevoUsuario.Size = new Size(143, 51);
            btn_nuevoUsuario.TabIndex = 1;
            btn_nuevoUsuario.Text = "Nuevo";
            btn_nuevoUsuario.UseVisualStyleBackColor = false;
            btn_nuevoUsuario.Click += btn_nuevoUsuario_Click;
            // 
            // FormNuevoUsuario
            // 
            FormNuevoUsuario.ColumnCount = 4;
            FormNuevoUsuario.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.1544113F));
            FormNuevoUsuario.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.84559F));
            FormNuevoUsuario.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.0955887F));
            FormNuevoUsuario.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.90441F));
            FormNuevoUsuario.Controls.Add(lbl1_usuariocrear, 0, 0);
            FormNuevoUsuario.Controls.Add(btn_GuardarUsuario, 3, 2);
            FormNuevoUsuario.Controls.Add(btn_Cancelar, 2, 2);
            FormNuevoUsuario.Controls.Add(textnewUsuario, 1, 0);
            FormNuevoUsuario.Controls.Add(textNewContraseña, 3, 0);
            FormNuevoUsuario.Controls.Add(label1, 2, 0);
            FormNuevoUsuario.Controls.Add(label2, 0, 1);
            FormNuevoUsuario.Controls.Add(cmb_NewPosicion, 1, 2);
            FormNuevoUsuario.Controls.Add(textNewNombre, 1, 1);
            FormNuevoUsuario.Controls.Add(label3, 0, 2);
            FormNuevoUsuario.Controls.Add(label4, 2, 1);
            FormNuevoUsuario.Controls.Add(textNewCorreo, 3, 1);
            FormNuevoUsuario.Dock = DockStyle.Top;
            FormNuevoUsuario.Location = new Point(531, 3);
            FormNuevoUsuario.Name = "FormNuevoUsuario";
            FormNuevoUsuario.RowCount = 3;
            FormNuevoUsuario.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            FormNuevoUsuario.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            FormNuevoUsuario.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            FormNuevoUsuario.Size = new Size(513, 431);
            FormNuevoUsuario.TabIndex = 19;
            // 
            // lbl1_usuariocrear
            // 
            lbl1_usuariocrear.Anchor = AnchorStyles.None;
            lbl1_usuariocrear.AutoSize = true;
            lbl1_usuariocrear.Location = new Point(5, 61);
            lbl1_usuariocrear.Name = "lbl1_usuariocrear";
            lbl1_usuariocrear.Size = new Size(62, 20);
            lbl1_usuariocrear.TabIndex = 6;
            lbl1_usuariocrear.Text = "Usuario:";
            // 
            // btn_GuardarUsuario
            // 
            btn_GuardarUsuario.Anchor = AnchorStyles.None;
            btn_GuardarUsuario.BackColor = Color.Lime;
            btn_GuardarUsuario.FlatStyle = FlatStyle.Flat;
            btn_GuardarUsuario.Location = new Point(380, 344);
            btn_GuardarUsuario.Name = "btn_GuardarUsuario";
            btn_GuardarUsuario.Size = new Size(94, 29);
            btn_GuardarUsuario.TabIndex = 15;
            btn_GuardarUsuario.Text = "Guardar";
            btn_GuardarUsuario.UseVisualStyleBackColor = false;
            btn_GuardarUsuario.Click += btn_GuardarUsuario_Click;
            // 
            // btn_Cancelar
            // 
            btn_Cancelar.Anchor = AnchorStyles.None;
            btn_Cancelar.BackColor = Color.Red;
            btn_Cancelar.FlatStyle = FlatStyle.Flat;
            btn_Cancelar.Location = new Point(260, 344);
            btn_Cancelar.Name = "btn_Cancelar";
            btn_Cancelar.Size = new Size(77, 29);
            btn_Cancelar.TabIndex = 16;
            btn_Cancelar.Text = "Cancelar";
            btn_Cancelar.UseVisualStyleBackColor = false;
            btn_Cancelar.Click += btn_Cancelar_Click;
            // 
            // textnewUsuario
            // 
            textnewUsuario.Anchor = AnchorStyles.Left;
            textnewUsuario.BackColor = Color.Silver;
            textnewUsuario.Location = new Point(75, 58);
            textnewUsuario.Name = "textnewUsuario";
            textnewUsuario.Size = new Size(170, 27);
            textnewUsuario.TabIndex = 4;
            // 
            // textNewContraseña
            // 
            textNewContraseña.Anchor = AnchorStyles.Left;
            textNewContraseña.BackColor = Color.Silver;
            textNewContraseña.Location = new Point(345, 58);
            textNewContraseña.Name = "textNewContraseña";
            textNewContraseña.Size = new Size(157, 27);
            textNewContraseña.TabIndex = 5;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(261, 51);
            label1.Name = "label1";
            label1.Size = new Size(75, 40);
            label1.TabIndex = 9;
            label1.Text = "Contraseña:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(4, 194);
            label2.Name = "label2";
            label2.Size = new Size(64, 40);
            label2.TabIndex = 10;
            label2.Text = "Nombre:";
            // 
            // cmb_NewPosicion
            // 
            cmb_NewPosicion.Anchor = AnchorStyles.Left;
            cmb_NewPosicion.BackColor = Color.Silver;
            cmb_NewPosicion.FormattingEnabled = true;
            cmb_NewPosicion.Items.AddRange(new object[] { "Administrador", "Vendedor" });
            cmb_NewPosicion.Location = new Point(75, 344);
            cmb_NewPosicion.Name = "cmb_NewPosicion";
            cmb_NewPosicion.Size = new Size(170, 28);
            cmb_NewPosicion.TabIndex = 7;
            // 
            // textNewNombre
            // 
            textNewNombre.Anchor = AnchorStyles.Left;
            textNewNombre.BackColor = Color.Silver;
            textNewNombre.Location = new Point(75, 201);
            textNewNombre.Name = "textNewNombre";
            textNewNombre.Size = new Size(170, 27);
            textNewNombre.TabIndex = 6;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(3, 348);
            label3.Name = "label3";
            label3.Size = new Size(66, 20);
            label3.TabIndex = 12;
            label3.Text = "Posición:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Location = new Point(270, 204);
            label4.Name = "label4";
            label4.Size = new Size(57, 20);
            label4.TabIndex = 14;
            label4.Text = "Correo:";
            // 
            // textNewCorreo
            // 
            textNewCorreo.Anchor = AnchorStyles.Left;
            textNewCorreo.BackColor = Color.Silver;
            textNewCorreo.Location = new Point(345, 201);
            textNewCorreo.Name = "textNewCorreo";
            textNewCorreo.Size = new Size(157, 27);
            textNewCorreo.TabIndex = 8;
            // 
            // Tabla_usuarios
            // 
            Tabla_usuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Tabla_usuarios.Dock = DockStyle.Top;
            Tabla_usuarios.Location = new Point(3, 3);
            Tabla_usuarios.Name = "Tabla_usuarios";
            Tabla_usuarios.RowHeadersWidth = 51;
            Tabla_usuarios.Size = new Size(512, 431);
            Tabla_usuarios.TabIndex = 20;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.49495F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 1.010101F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.49495F));
            tableLayoutPanel1.Controls.Add(Tabla_usuarios, 0, 0);
            tableLayoutPanel1.Controls.Add(FormNuevoUsuario, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 72);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1047, 437);
            tableLayoutPanel1.TabIndex = 21;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Dock = DockStyle.Bottom;
            tableLayoutPanel3.Location = new Point(0, 421);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(1047, 88);
            tableLayoutPanel3.TabIndex = 22;
            // 
            // lbl_NuevoUsuario
            // 
            lbl_NuevoUsuario.Anchor = AnchorStyles.Right;
            lbl_NuevoUsuario.AutoSize = true;
            lbl_NuevoUsuario.Location = new Point(248, 26);
            lbl_NuevoUsuario.Name = "lbl_NuevoUsuario";
            lbl_NuevoUsuario.Size = new Size(167, 20);
            lbl_NuevoUsuario.TabIndex = 2;
            lbl_NuevoUsuario.Text = "Agregar Nuevo Usuario:";
            // 
            // Users
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel3);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(tableLayoutPanel2);
            Name = "Users";
            Size = new Size(1047, 509);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            FormNuevoUsuario.ResumeLayout(false);
            FormNuevoUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)Tabla_usuarios).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel2;
        private Button btn_nuevoUsuario;
        private TableLayoutPanel FormNuevoUsuario;
        private Label lbl1_usuariocrear;
        private Button btn_GuardarUsuario;
        private Button btn_Cancelar;
        private TextBox textnewUsuario;
        private TextBox textNewContraseña;
        private Label label1;
        private Label label2;
        private ComboBox cmb_NewPosicion;
        private TextBox textNewNombre;
        private Label label3;
        private Label label4;
        private TextBox textNewCorreo;
        private DataGridView Tabla_usuarios;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel3;
        private Label lbl_NuevoUsuario;
    }
}
