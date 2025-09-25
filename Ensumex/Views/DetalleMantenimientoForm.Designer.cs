namespace Ensumex.Views
{
    partial class DetalleMantenimientoForm
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
            LblRealizado = new Label();
            LblObserv = new Label();
            txtRealizadoPor = new TextBox();
            txtObservaciones = new TextBox();
            btnGuardar = new Button();
            SuspendLayout();
            // 
            // LblRealizado
            // 
            LblRealizado.AutoSize = true;
            LblRealizado.Location = new Point(17, 22);
            LblRealizado.Name = "LblRealizado";
            LblRealizado.Size = new Size(122, 15);
            LblRealizado.TabIndex = 0;
            LblRealizado.Text = "Servicio realizado por:";
            // 
            // LblObserv
            // 
            LblObserv.AutoSize = true;
            LblObserv.Location = new Point(17, 96);
            LblObserv.Name = "LblObserv";
            LblObserv.Size = new Size(84, 15);
            LblObserv.TabIndex = 1;
            LblObserv.Text = "Observaciones";
            // 
            // txtRealizadoPor
            // 
            txtRealizadoPor.Location = new Point(17, 56);
            txtRealizadoPor.Name = "txtRealizadoPor";
            txtRealizadoPor.Size = new Size(307, 23);
            txtRealizadoPor.TabIndex = 2;
            // 
            // txtObservaciones
            // 
            txtObservaciones.Location = new Point(17, 127);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(307, 97);
            txtObservaciones.TabIndex = 3;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(129, 248);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // DetalleMantenimientoForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(374, 295);
            Controls.Add(btnGuardar);
            Controls.Add(txtObservaciones);
            Controls.Add(txtRealizadoPor);
            Controls.Add(LblObserv);
            Controls.Add(LblRealizado);
            Name = "DetalleMantenimientoForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblRealizado;
        private Label LblObserv;
        private TextBox txtRealizadoPor;
        private TextBox txtObservaciones;
        private Button btnGuardar;
    }
}
