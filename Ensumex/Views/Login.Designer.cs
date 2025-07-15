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
            linkLabel1 = new LinkLabel();
            lbl_error = new Label();
            pictureBox3 = new PictureBox();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            txt_Usuariologin = new MaterialSkin.Controls.MaterialTextBox2();
            txt_contraseñalogin = new MaterialSkin.Controls.MaterialTextBox2();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = Color.FromArgb(0, 192, 0);
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel1.LinkColor = Color.DimGray;
            linkLabel1.Location = new Point(318, 275);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(180, 17);
            linkLabel1.TabIndex = 4;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "¿Ha olvidado la contraseña?";
            // 
            // lbl_error
            // 
            lbl_error.AutoSize = true;
            lbl_error.BackColor = Color.Transparent;
            lbl_error.FlatStyle = FlatStyle.Flat;
            lbl_error.ForeColor = Color.Red;
            lbl_error.Location = new Point(229, 254);
            lbl_error.Name = "lbl_error";
            lbl_error.Size = new Size(77, 15);
            lbl_error.TabIndex = 9;
            lbl_error.Text = "Erro_Mensaje";
            lbl_error.Visible = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(6, 83);
            pictureBox3.Margin = new Padding(3, 2, 3, 2);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(175, 161);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 0;
            pictureBox3.TabStop = false;
            // 
            // materialButton1
            // 
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(364, 208);
            materialButton1.Margin = new Padding(4);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(86, 36);
            materialButton1.TabIndex = 3;
            materialButton1.Text = "Acceder";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = true;
            materialButton1.Click += materialButton1_Click;
            // 
            // txt_Usuariologin
            // 
            txt_Usuariologin.AnimateReadOnly = false;
            txt_Usuariologin.BackgroundImageLayout = ImageLayout.None;
            txt_Usuariologin.CharacterCasing = CharacterCasing.Normal;
            txt_Usuariologin.Depth = 0;
            txt_Usuariologin.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txt_Usuariologin.HideSelection = true;
            txt_Usuariologin.LeadingIcon = null;
            txt_Usuariologin.Location = new Point(229, 83);
            txt_Usuariologin.Margin = new Padding(3, 2, 3, 2);
            txt_Usuariologin.MaxLength = 32767;
            txt_Usuariologin.MouseState = MaterialSkin.MouseState.OUT;
            txt_Usuariologin.Name = "txt_Usuariologin";
            txt_Usuariologin.PasswordChar = '\0';
            txt_Usuariologin.PrefixSuffixText = null;
            txt_Usuariologin.ReadOnly = false;
            txt_Usuariologin.RightToLeft = RightToLeft.No;
            txt_Usuariologin.SelectedText = "";
            txt_Usuariologin.SelectionLength = 0;
            txt_Usuariologin.SelectionStart = 0;
            txt_Usuariologin.ShortcutsEnabled = true;
            txt_Usuariologin.Size = new Size(355, 48);
            txt_Usuariologin.TabIndex = 1;
            txt_Usuariologin.TabStop = false;
            txt_Usuariologin.TextAlign = HorizontalAlignment.Left;
            txt_Usuariologin.TrailingIcon = null;
            txt_Usuariologin.UseSystemPasswordChar = false;
            txt_Usuariologin.Enter += txt_Usuariologin_Enter;
            txt_Usuariologin.KeyDown += txt_Usuariologin_KeyDown;
            txt_Usuariologin.Leave += txt_Usuariologin_Leave;
            txt_Usuariologin.MouseEnter += txt_Usuariologin_MouseEnter;
            txt_Usuariologin.MouseLeave += txt_Usuariologin_MouseLeave;
            // 
            // txt_contraseñalogin
            // 
            txt_contraseñalogin.AnimateReadOnly = false;
            txt_contraseñalogin.BackgroundImageLayout = ImageLayout.None;
            txt_contraseñalogin.CharacterCasing = CharacterCasing.Normal;
            txt_contraseñalogin.Depth = 0;
            txt_contraseñalogin.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txt_contraseñalogin.HideSelection = true;
            txt_contraseñalogin.LeadingIcon = null;
            txt_contraseñalogin.Location = new Point(229, 154);
            txt_contraseñalogin.Margin = new Padding(3, 2, 3, 2);
            txt_contraseñalogin.MaxLength = 32767;
            txt_contraseñalogin.MouseState = MaterialSkin.MouseState.OUT;
            txt_contraseñalogin.Name = "txt_contraseñalogin";
            txt_contraseñalogin.PasswordChar = '\0';
            txt_contraseñalogin.PrefixSuffixText = null;
            txt_contraseñalogin.ReadOnly = false;
            txt_contraseñalogin.RightToLeft = RightToLeft.No;
            txt_contraseñalogin.SelectedText = "";
            txt_contraseñalogin.SelectionLength = 0;
            txt_contraseñalogin.SelectionStart = 0;
            txt_contraseñalogin.ShortcutsEnabled = true;
            txt_contraseñalogin.Size = new Size(355, 48);
            txt_contraseñalogin.TabIndex = 2;
            txt_contraseñalogin.TabStop = false;
            txt_contraseñalogin.TextAlign = HorizontalAlignment.Left;
            txt_contraseñalogin.TrailingIcon = null;
            txt_contraseñalogin.UseSystemPasswordChar = false;
            txt_contraseñalogin.Enter += txt_contraseñalogin_Enter;
            txt_contraseñalogin.KeyDown += txt_contraseñalogin_KeyDown;
            txt_contraseñalogin.Leave += txt_contraseñalogin_Leave;
            txt_contraseñalogin.MouseEnter += txt_contraseñalogin_MouseEnter;
            txt_contraseñalogin.MouseLeave += txt_contraseñalogin_MouseLeave;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 15, 15);
            ClientSize = new Size(636, 294);
            Controls.Add(txt_contraseñalogin);
            Controls.Add(txt_Usuariologin);
            Controls.Add(materialButton1);
            Controls.Add(pictureBox3);
            Controls.Add(lbl_error);
            Controls.Add(linkLabel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Login";
            Opacity = 0.9D;
            Padding = new Padding(3, 48, 3, 2);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ENSUMEX";
            FormClosing += Login_FormClosing;
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private LinkLabel linkLabel1;
        private Label lbl_error;
        private PictureBox pictureBox3;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialTextBox2 txt_Usuariologin;
        private MaterialSkin.Controls.MaterialTextBox2 txt_contraseñalogin;
    }
}
