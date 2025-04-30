namespace Ensumex
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            text_usuario = new TextBox();
            text_contraseña = new TextBox();
            label2 = new Label();
            btn_login = new Button();
            linkLabel1 = new LinkLabel();
            btn_cerrar = new PictureBox();
            bn_minimizar = new PictureBox();
            lbl_error = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btn_cerrar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bn_minimizar).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Green;
            panel1.Controls.Add(pictureBox3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 330);
            panel1.TabIndex = 0;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(23, 55);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(200, 200);
            pictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // text_usuario
            // 
            text_usuario.BackColor = Color.FromArgb(15, 15, 15);
            text_usuario.BorderStyle = BorderStyle.None;
            text_usuario.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            text_usuario.ForeColor = Color.DimGray;
            text_usuario.Location = new Point(312, 76);
            text_usuario.Name = "text_usuario";
            text_usuario.Size = new Size(406, 25);
            text_usuario.TabIndex = 1;
            text_usuario.Text = "Usuario";
            text_usuario.TextChanged += text_usuario_TextChanged;
            text_usuario.Enter += text_usuario_Enter;
            text_usuario.Leave += text_usuario_Leave;
            // 
            // text_contraseña
            // 
            text_contraseña.BackColor = Color.FromArgb(15, 15, 15);
            text_contraseña.BorderStyle = BorderStyle.None;
            text_contraseña.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            text_contraseña.ForeColor = Color.DimGray;
            text_contraseña.Location = new Point(312, 141);
            text_contraseña.Name = "text_contraseña";
            text_contraseña.Size = new Size(406, 25);
            text_contraseña.TabIndex = 2;
            text_contraseña.Text = "Contraseña";
            text_contraseña.Enter += textcontraseña_Enter;
            text_contraseña.Leave += textcontraseña_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(464, 0);
            label2.Name = "label2";
            label2.Size = new Size(106, 40);
            label2.TabIndex = 4;
            label2.Text = "Login";
            // 
            // btn_login
            // 
            btn_login.BackColor = Color.FromArgb(40, 40, 40);
            btn_login.FlatAppearance.BorderSize = 0;
            btn_login.FlatAppearance.MouseDownBackColor = Color.FromArgb(28, 28, 28);
            btn_login.FlatAppearance.MouseOverBackColor = Color.FromArgb(64, 64, 64);
            btn_login.FlatStyle = FlatStyle.Flat;
            btn_login.ForeColor = Color.LightGray;
            btn_login.Location = new Point(312, 187);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(408, 40);
            btn_login.TabIndex = 3;
            btn_login.Text = "Acceder";
            btn_login.UseVisualStyleBackColor = false;
            btn_login.Click += btn_login_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.FromArgb(0, 192, 0);
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel1.LinkColor = Color.DimGray;
            linkLabel1.Location = new Point(412, 291);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(222, 20);
            linkLabel1.TabIndex = 4;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "¿Ha olvidado la contraseña?";
            // 
            // btn_cerrar
            // 
            btn_cerrar.Image = (Image)resources.GetObject("btn_cerrar.Image");
            btn_cerrar.Location = new Point(760, 0);
            btn_cerrar.Name = "btn_cerrar";
            btn_cerrar.Size = new Size(20, 20);
            btn_cerrar.SizeMode = PictureBoxSizeMode.Zoom;
            btn_cerrar.TabIndex = 7;
            btn_cerrar.TabStop = false;
            btn_cerrar.Click += btn_cerrar_Click;
            // 
            // bn_minimizar
            // 
            bn_minimizar.Image = (Image)resources.GetObject("bn_minimizar.Image");
            bn_minimizar.Location = new Point(734, 0);
            bn_minimizar.Name = "bn_minimizar";
            bn_minimizar.Size = new Size(20, 20);
            bn_minimizar.SizeMode = PictureBoxSizeMode.Zoom;
            bn_minimizar.TabIndex = 8;
            bn_minimizar.TabStop = false;
            bn_minimizar.Click += bn_minimizar_Click;
            // 
            // lbl_error
            // 
            lbl_error.AutoSize = true;
            lbl_error.BackColor = Color.Transparent;
            lbl_error.FlatStyle = FlatStyle.Flat;
            lbl_error.ForeColor = Color.Red;
            lbl_error.Location = new Point(312, 251);
            lbl_error.Name = "lbl_error";
            lbl_error.Size = new Size(97, 20);
            lbl_error.TabIndex = 9;
            lbl_error.Text = "Erro_Mensaje";
            lbl_error.Visible = false;
            lbl_error.Click += label1_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(780, 330);
            Controls.Add(lbl_error);
            Controls.Add(bn_minimizar);
            Controls.Add(btn_cerrar);
            Controls.Add(linkLabel1);
            Controls.Add(btn_login);
            Controls.Add(label2);
            Controls.Add(text_contraseña);
            Controls.Add(text_usuario);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            Opacity = 0.9D;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)btn_cerrar).EndInit();
            ((System.ComponentModel.ISupportInitialize)bn_minimizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox text_usuario;
        private TextBox text_contraseña;
        private Label label2;
        private Button btn_login;
        private LinkLabel linkLabel1;
        private PictureBox btn_cerrar;
        private PictureBox pictureBox3;
        private PictureBox bn_minimizar;
        private Label lbl_error;
    }
}
