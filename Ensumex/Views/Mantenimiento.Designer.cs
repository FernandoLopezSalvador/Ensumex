namespace Ensumex.Views
{
    partial class Mantenimiento
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
            tableLayoutPanel1 = new TableLayoutPanel();
            label1 = new Label();
            label2 = new Label();
            cmb_clientes = new ComboBox();
            text_buscar = new TextBox();
            Btn_DescargarClients = new FontAwesome.Sharp.IconButton();
            dgvMantenimiento = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMantenimiento).BeginInit();
            SuspendLayout();
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
            tableLayoutPanel1.Controls.Add(cmb_clientes, 2, 0);
            tableLayoutPanel1.Controls.Add(text_buscar, 2, 1);
            tableLayoutPanel1.Controls.Add(Btn_DescargarClients, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Top;
            tableLayoutPanel1.ForeColor = SystemColors.ControlText;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(1029, 128);
            tableLayoutPanel1.TabIndex = 19;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(437, 21);
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
            label2.Location = new Point(446, 85);
            label2.Name = "label2";
            label2.Size = new Size(65, 21);
            label2.TabIndex = 13;
            label2.Text = "Buscar:";
            // 
            // cmb_clientes
            // 
            cmb_clientes.Anchor = AnchorStyles.None;
            cmb_clientes.FormattingEnabled = true;
            cmb_clientes.Location = new Point(552, 20);
            cmb_clientes.Margin = new Padding(3, 2, 3, 2);
            cmb_clientes.Name = "cmb_clientes";
            cmb_clientes.Size = new Size(180, 23);
            cmb_clientes.TabIndex = 12;
            // 
            // text_buscar
            // 
            text_buscar.Anchor = AnchorStyles.None;
            text_buscar.Location = new Point(555, 84);
            text_buscar.Name = "text_buscar";
            text_buscar.Size = new Size(175, 23);
            text_buscar.TabIndex = 1;
            // 
            // Btn_DescargarClients
            // 
            Btn_DescargarClients.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            Btn_DescargarClients.IconChar = FontAwesome.Sharp.IconChar.None;
            Btn_DescargarClients.IconColor = Color.Black;
            Btn_DescargarClients.IconFont = FontAwesome.Sharp.IconFont.Auto;
            Btn_DescargarClients.Location = new Point(128, 67);
            Btn_DescargarClients.Name = "Btn_DescargarClients";
            Btn_DescargarClients.Size = new Size(126, 58);
            Btn_DescargarClients.TabIndex = 17;
            Btn_DescargarClients.Text = "Descargar:";
            Btn_DescargarClients.UseVisualStyleBackColor = true;
            // 
            // dgvMantenimiento
            // 
            dgvMantenimiento.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMantenimiento.ColumnHeadersHeight = 29;
            dgvMantenimiento.Dock = DockStyle.Fill;
            dgvMantenimiento.Location = new Point(0, 128);
            dgvMantenimiento.Margin = new Padding(3, 2, 3, 2);
            dgvMantenimiento.Name = "dgvMantenimiento";
            dgvMantenimiento.RowHeadersWidth = 51;
            dgvMantenimiento.Size = new Size(1029, 486);
            dgvMantenimiento.TabIndex = 20;
            dgvMantenimiento.CellValueChanged += dgvMantenimiento_CellValueChanged;
            // 
            // Mantenimiento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvMantenimiento);
            Controls.Add(tableLayoutPanel1);
            Name = "Mantenimiento";
            Size = new Size(1029, 614);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMantenimiento).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private ComboBox cmb_clientes;
        private TextBox text_buscar;
        private FontAwesome.Sharp.IconButton Btn_DescargarClients;
        private DataGridView dgvMantenimiento;
    }
}
