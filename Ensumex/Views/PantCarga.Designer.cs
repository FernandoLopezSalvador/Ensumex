namespace Ensumex.Views
{
    partial class Cargando
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cargando));
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            pictureBox2 = new PictureBox();
            LblBienvenido = new Label();
            LblPoss = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            timer2 = new System.Windows.Forms.Timer(components);
            progressBar1 = new ProgressBar();
            fbCommand1 = new FirebirdSql.Data.FirebirdClient.FbCommand();
            LblEstado = new Label();
            LblUsuario = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 66);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(300, 272);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(38, 50, 56);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(LblBienvenido);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 63);
            panel1.TabIndex = 1;
            // 
            // pictureBox2
            // 
            pictureBox2.Dock = DockStyle.Left;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(100, 63);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // LblBienvenido
            // 
            LblBienvenido.AutoSize = true;
            LblBienvenido.Font = new Font("Franklin Gothic Medium", 36F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            LblBienvenido.ForeColor = Color.FromArgb(141, 198, 63);
            LblBienvenido.Location = new Point(282, 0);
            LblBienvenido.Name = "LblBienvenido";
            LblBienvenido.Size = new Size(264, 61);
            LblBienvenido.TabIndex = 0;
            LblBienvenido.Text = "Bienvenido";
            LblBienvenido.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LblPoss
            // 
            LblPoss.AutoSize = true;
            LblPoss.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblPoss.ForeColor = Color.White;
            LblPoss.Location = new Point(354, 66);
            LblPoss.Name = "LblPoss";
            LblPoss.Size = new Size(235, 37);
            LblPoss.TabIndex = 2;
            LblPoss.Text = "PosicionUsusario";
            // 
            // timer1
            // 
            timer1.Interval = 30;
            timer1.Tick += timer1_Tick;
            // 
            // timer2
            // 
            timer2.Interval = 30;
            timer2.Tick += timer2_Tick;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(354, 233);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(373, 23);
            progressBar1.TabIndex = 3;
            // 
            // LblEstado
            // 
            LblEstado.AutoSize = true;
            LblEstado.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblEstado.Location = new Point(486, 271);
            LblEstado.Name = "LblEstado";
            LblEstado.Size = new Size(60, 20);
            LblEstado.TabIndex = 5;
            LblEstado.Text = "Estado:";
            // 
            // LblUsuario
            // 
            LblUsuario.AutoSize = true;
            LblUsuario.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblUsuario.ForeColor = Color.White;
            LblUsuario.Location = new Point(354, 148);
            LblUsuario.Name = "LblUsuario";
            LblUsuario.Size = new Size(175, 30);
            LblUsuario.TabIndex = 6;
            LblUsuario.Text = "NombreUsuario.";
            // 
            // Cargando
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(69, 90, 100);
            ClientSize = new Size(800, 340);
            Controls.Add(LblUsuario);
            Controls.Add(LblEstado);
            Controls.Add(progressBar1);
            Controls.Add(LblPoss);
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Cargando";
            Load += Cargando_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private Label LblBienvenido;
        private Label LblPoss;
        private PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private ProgressBar progressBar1;
        private FirebirdSql.Data.FirebirdClient.FbCommand fbCommand1;
        private Label LblEstado;
        private Label LblUsuario;
    }
}