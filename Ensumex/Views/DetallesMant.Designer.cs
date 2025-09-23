namespace Ensumex.Views
{
    partial class DetallesMant
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
            GridMantenimientos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)GridMantenimientos).BeginInit();
            SuspendLayout();
            // 
            // GridMantenimientos
            // 
            GridMantenimientos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GridMantenimientos.Dock = DockStyle.Fill;
            GridMantenimientos.Location = new Point(0, 0);
            GridMantenimientos.Name = "GridMantenimientos";
            GridMantenimientos.Size = new Size(448, 373);
            GridMantenimientos.TabIndex = 0;
            // 
            // DetallesMant
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(GridMantenimientos);
            Name = "DetallesMant";
            Size = new Size(448, 373);
            ((System.ComponentModel.ISupportInitialize)GridMantenimientos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView GridMantenimientos;
    }
}
