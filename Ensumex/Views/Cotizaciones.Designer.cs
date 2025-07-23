namespace Ensumex.Views
{
    partial class Cotizaciones
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
            tabla_cotizaciones = new DataGridView();
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            cmb_filtrarcotiza = new ComboBox();
            text_buscar = new TextBox();
            ((System.ComponentModel.ISupportInitialize)tabla_cotizaciones).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tabla_cotizaciones
            // 
            tabla_cotizaciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            tabla_cotizaciones.ColumnHeadersHeight = 29;
            tabla_cotizaciones.Dock = DockStyle.Fill;
            tabla_cotizaciones.Location = new Point(0, 128);
            tabla_cotizaciones.Margin = new Padding(3, 2, 3, 2);
            tabla_cotizaciones.Name = "tabla_cotizaciones";
            tabla_cotizaciones.RowHeadersWidth = 51;
            tabla_cotizaciones.Size = new Size(676, 255);
            tabla_cotizaciones.TabIndex = 21;
            tabla_cotizaciones.CellClick += tabla_cotizaciones_CellClick_1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.Control;
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Controls.Add(label2, 1, 1);
            tableLayoutPanel1.Controls.Add(cmb_filtrarcotiza, 2, 0);
            tableLayoutPanel1.Controls.Add(text_buscar, 2, 1);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.ForeColor = SystemColors.ControlText;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(676, 128);
            tableLayoutPanel1.TabIndex = 20;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(261, 21);
            label1.Name = "label1";
            label1.Size = new Size(74, 21);
            label1.TabIndex = 11;
            label1.Text = "Mostrar:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Right;
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(270, 85);
            label2.Name = "label2";
            label2.Size = new Size(65, 21);
            label2.TabIndex = 13;
            label2.Text = "Buscar:";
            // 
            // cmb_filtrarcotiza
            // 
            cmb_filtrarcotiza.Anchor = AnchorStyles.None;
            cmb_filtrarcotiza.FormattingEnabled = true;
            cmb_filtrarcotiza.Location = new Point(341, 20);
            cmb_filtrarcotiza.Margin = new Padding(3, 2, 3, 2);
            cmb_filtrarcotiza.Name = "cmb_filtrarcotiza";
            cmb_filtrarcotiza.Size = new Size(163, 23);
            cmb_filtrarcotiza.TabIndex = 12;
            cmb_filtrarcotiza.SelectedIndexChanged += cmb_clientes_SelectedIndexChanged;
            // 
            // text_buscar
            // 
            text_buscar.Anchor = AnchorStyles.None;
            text_buscar.Location = new Point(341, 84);
            text_buscar.Name = "text_buscar";
            text_buscar.Size = new Size(163, 23);
            text_buscar.TabIndex = 1;
            text_buscar.TextChanged += text_buscar_TextChanged;
            // 
            // Cotizaciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tabla_cotizaciones);
            Controls.Add(tableLayoutPanel1);
            Name = "Cotizaciones";
            Size = new Size(676, 383);
            ((System.ComponentModel.ISupportInitialize)tabla_cotizaciones).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView tabla_cotizaciones;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private ComboBox cmb_filtrarcotiza;
        private TextBox text_buscar;
    }
}
