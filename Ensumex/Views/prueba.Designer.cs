namespace Ensumex.Views
{
    partial class prueba
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
            Tabla_Productos1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)Tabla_Productos1).BeginInit();
            SuspendLayout();
            // 
            // Tabla_Productos1
            // 
            Tabla_Productos1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Tabla_Productos1.Location = new Point(65, 142);
            Tabla_Productos1.Name = "Tabla_Productos1";
            Tabla_Productos1.RowHeadersWidth = 51;
            Tabla_Productos1.Size = new Size(630, 248);
            Tabla_Productos1.TabIndex = 0;
            // 
            // prueba
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Tabla_Productos1);
            Name = "prueba";
            Text = "prueba";
            ((System.ComponentModel.ISupportInitialize)Tabla_Productos1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView Tabla_Productos1;
    }
}