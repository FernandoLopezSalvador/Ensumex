namespace Ensumex.Views
{
    partial class ProdTemp
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
            lbl_ProducTemp = new MaterialSkin.Controls.MaterialLabel();
            tableLayoutPanel1 = new TableLayoutPanel();
            materialButton2 = new MaterialSkin.Controls.MaterialButton();
            lbl_ClaveTemp = new MaterialSkin.Controls.MaterialLabel();
            lbl_descripcionTemp = new MaterialSkin.Controls.MaterialLabel();
            materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            lbl_PPTemp = new MaterialSkin.Controls.MaterialLabel();
            lbl_UnidadTemp = new MaterialSkin.Controls.MaterialLabel();
            txb_PrecioUnitarioTemp = new MaterialSkin.Controls.MaterialMaskedTextBox();
            txb_ClaveTemp = new MaterialSkin.Controls.MaterialMaskedTextBox();
            txb_Descripcion = new MaterialSkin.Controls.MaterialMaskedTextBox();
            txb_PrecioPublicoTemp = new MaterialSkin.Controls.MaterialMaskedTextBox();
            txb_UnidadEntradaTemp = new MaterialSkin.Controls.MaterialMaskedTextBox();
            materialButton1 = new MaterialSkin.Controls.MaterialButton();
            cmb_Unidentrada = new MaterialSkin.Controls.MaterialComboBox();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_ProducTemp
            // 
            lbl_ProducTemp.AutoSize = true;
            lbl_ProducTemp.Depth = 0;
            lbl_ProducTemp.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lbl_ProducTemp.Location = new Point(362, -74);
            lbl_ProducTemp.MouseState = MaterialSkin.MouseState.HOVER;
            lbl_ProducTemp.Name = "lbl_ProducTemp";
            lbl_ProducTemp.Size = new Size(124, 19);
            lbl_ProducTemp.TabIndex = 18;
            lbl_ProducTemp.Text = "Agregar Producto";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40.30837F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 59.69163F));
            tableLayoutPanel1.Controls.Add(materialButton2, 1, 6);
            tableLayoutPanel1.Controls.Add(lbl_ClaveTemp, 0, 0);
            tableLayoutPanel1.Controls.Add(lbl_descripcionTemp, 0, 1);
            tableLayoutPanel1.Controls.Add(materialLabel1, 0, 2);
            tableLayoutPanel1.Controls.Add(lbl_PPTemp, 0, 3);
            tableLayoutPanel1.Controls.Add(lbl_UnidadTemp, 0, 4);
            tableLayoutPanel1.Controls.Add(txb_PrecioUnitarioTemp, 1, 2);
            tableLayoutPanel1.Controls.Add(txb_ClaveTemp, 1, 0);
            tableLayoutPanel1.Controls.Add(txb_Descripcion, 1, 1);
            tableLayoutPanel1.Controls.Add(txb_PrecioPublicoTemp, 1, 3);
            tableLayoutPanel1.Controls.Add(txb_UnidadEntradaTemp, 1, 4);
            tableLayoutPanel1.Controls.Add(materialButton1, 0, 6);
            tableLayoutPanel1.Controls.Add(cmb_Unidentrada, 1, 5);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 64);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.Size = new Size(454, 491);
            tableLayoutPanel1.TabIndex = 19;
            // 
            // materialButton2
            // 
            materialButton2.Anchor = AnchorStyles.None;
            materialButton2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton2.BackColor = Color.Green;
            materialButton2.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton2.Depth = 0;
            materialButton2.HighEmphasis = true;
            materialButton2.Icon = null;
            materialButton2.Location = new Point(274, 437);
            materialButton2.Margin = new Padding(4, 6, 4, 6);
            materialButton2.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton2.Name = "materialButton2";
            materialButton2.NoAccentTextColor = Color.Empty;
            materialButton2.Size = new Size(88, 36);
            materialButton2.TabIndex = 8;
            materialButton2.Text = "Agregar";
            materialButton2.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton2.UseAccentColor = false;
            materialButton2.UseVisualStyleBackColor = false;
            materialButton2.Click += materialButton2_Click;
            // 
            // lbl_ClaveTemp
            // 
            lbl_ClaveTemp.Anchor = AnchorStyles.Left;
            lbl_ClaveTemp.AutoSize = true;
            lbl_ClaveTemp.BackColor = Color.Transparent;
            lbl_ClaveTemp.Depth = 0;
            lbl_ClaveTemp.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lbl_ClaveTemp.Location = new Point(3, 25);
            lbl_ClaveTemp.MouseState = MaterialSkin.MouseState.HOVER;
            lbl_ClaveTemp.Name = "lbl_ClaveTemp";
            lbl_ClaveTemp.Size = new Size(53, 19);
            lbl_ClaveTemp.TabIndex = 31;
            lbl_ClaveTemp.Text = "CLAVE:";
            // 
            // lbl_descripcionTemp
            // 
            lbl_descripcionTemp.Anchor = AnchorStyles.Left;
            lbl_descripcionTemp.AutoSize = true;
            lbl_descripcionTemp.BackColor = Color.Transparent;
            lbl_descripcionTemp.Depth = 0;
            lbl_descripcionTemp.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lbl_descripcionTemp.Location = new Point(3, 95);
            lbl_descripcionTemp.MouseState = MaterialSkin.MouseState.HOVER;
            lbl_descripcionTemp.Name = "lbl_descripcionTemp";
            lbl_descripcionTemp.Size = new Size(84, 19);
            lbl_descripcionTemp.TabIndex = 32;
            lbl_descripcionTemp.Text = "Descripción";
            lbl_descripcionTemp.TextAlign = ContentAlignment.TopCenter;
            // 
            // materialLabel1
            // 
            materialLabel1.Anchor = AnchorStyles.Left;
            materialLabel1.AutoSize = true;
            materialLabel1.Depth = 0;
            materialLabel1.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            materialLabel1.Location = new Point(3, 165);
            materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            materialLabel1.Name = "materialLabel1";
            materialLabel1.Size = new Size(104, 19);
            materialLabel1.TabIndex = 35;
            materialLabel1.Text = "Precio Unitario";
            // 
            // lbl_PPTemp
            // 
            lbl_PPTemp.Anchor = AnchorStyles.Left;
            lbl_PPTemp.AutoSize = true;
            lbl_PPTemp.Depth = 0;
            lbl_PPTemp.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lbl_PPTemp.Location = new Point(3, 235);
            lbl_PPTemp.MouseState = MaterialSkin.MouseState.HOVER;
            lbl_PPTemp.Name = "lbl_PPTemp";
            lbl_PPTemp.Size = new Size(102, 19);
            lbl_PPTemp.TabIndex = 34;
            lbl_PPTemp.Text = "Precio Publico";
            // 
            // lbl_UnidadTemp
            // 
            lbl_UnidadTemp.Anchor = AnchorStyles.Left;
            lbl_UnidadTemp.AutoSize = true;
            lbl_UnidadTemp.Depth = 0;
            lbl_UnidadTemp.Font = new Font("Roboto", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
            lbl_UnidadTemp.Location = new Point(3, 305);
            lbl_UnidadTemp.MouseState = MaterialSkin.MouseState.HOVER;
            lbl_UnidadTemp.Name = "lbl_UnidadTemp";
            lbl_UnidadTemp.Size = new Size(110, 19);
            lbl_UnidadTemp.TabIndex = 33;
            lbl_UnidadTemp.Text = "Unidad Entrada";
            // 
            // txb_PrecioUnitarioTemp
            // 
            txb_PrecioUnitarioTemp.AllowPromptAsInput = true;
            txb_PrecioUnitarioTemp.Anchor = AnchorStyles.Left;
            txb_PrecioUnitarioTemp.AnimateReadOnly = false;
            txb_PrecioUnitarioTemp.AsciiOnly = false;
            txb_PrecioUnitarioTemp.BackgroundImageLayout = ImageLayout.None;
            txb_PrecioUnitarioTemp.BeepOnError = false;
            txb_PrecioUnitarioTemp.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txb_PrecioUnitarioTemp.Depth = 0;
            txb_PrecioUnitarioTemp.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txb_PrecioUnitarioTemp.HidePromptOnLeave = false;
            txb_PrecioUnitarioTemp.HideSelection = true;
            txb_PrecioUnitarioTemp.InsertKeyMode = InsertKeyMode.Default;
            txb_PrecioUnitarioTemp.LeadingIcon = null;
            txb_PrecioUnitarioTemp.Location = new Point(186, 151);
            txb_PrecioUnitarioTemp.Mask = "";
            txb_PrecioUnitarioTemp.MaxLength = 32767;
            txb_PrecioUnitarioTemp.MouseState = MaterialSkin.MouseState.OUT;
            txb_PrecioUnitarioTemp.Name = "txb_PrecioUnitarioTemp";
            txb_PrecioUnitarioTemp.PasswordChar = '\0';
            txb_PrecioUnitarioTemp.PrefixSuffixText = null;
            txb_PrecioUnitarioTemp.PromptChar = '_';
            txb_PrecioUnitarioTemp.ReadOnly = false;
            txb_PrecioUnitarioTemp.RejectInputOnFirstFailure = false;
            txb_PrecioUnitarioTemp.ResetOnPrompt = true;
            txb_PrecioUnitarioTemp.ResetOnSpace = true;
            txb_PrecioUnitarioTemp.RightToLeft = RightToLeft.No;
            txb_PrecioUnitarioTemp.SelectedText = "";
            txb_PrecioUnitarioTemp.SelectionLength = 0;
            txb_PrecioUnitarioTemp.SelectionStart = 0;
            txb_PrecioUnitarioTemp.ShortcutsEnabled = true;
            txb_PrecioUnitarioTemp.Size = new Size(250, 48);
            txb_PrecioUnitarioTemp.SkipLiterals = true;
            txb_PrecioUnitarioTemp.TabIndex = 3;
            txb_PrecioUnitarioTemp.TabStop = false;
            txb_PrecioUnitarioTemp.TextAlign = HorizontalAlignment.Left;
            txb_PrecioUnitarioTemp.TextMaskFormat = MaskFormat.IncludeLiterals;
            txb_PrecioUnitarioTemp.TrailingIcon = null;
            txb_PrecioUnitarioTemp.UseSystemPasswordChar = false;
            txb_PrecioUnitarioTemp.ValidatingType = null;
            txb_PrecioUnitarioTemp.KeyPress += txb_PrecioUnitarioTemp_KeyPress;
            txb_PrecioUnitarioTemp.TabIndexChanged += txb_PrecioUnitarioTemp_TabIndexChanged;
            // 
            // txb_ClaveTemp
            // 
            txb_ClaveTemp.AllowPromptAsInput = true;
            txb_ClaveTemp.Anchor = AnchorStyles.Left;
            txb_ClaveTemp.AnimateReadOnly = false;
            txb_ClaveTemp.AsciiOnly = false;
            txb_ClaveTemp.BackgroundImageLayout = ImageLayout.None;
            txb_ClaveTemp.BeepOnError = false;
            txb_ClaveTemp.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txb_ClaveTemp.Depth = 0;
            txb_ClaveTemp.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txb_ClaveTemp.HidePromptOnLeave = false;
            txb_ClaveTemp.HideSelection = true;
            txb_ClaveTemp.InsertKeyMode = InsertKeyMode.Default;
            txb_ClaveTemp.LeadingIcon = null;
            txb_ClaveTemp.Location = new Point(186, 11);
            txb_ClaveTemp.Mask = "";
            txb_ClaveTemp.MaxLength = 32767;
            txb_ClaveTemp.MouseState = MaterialSkin.MouseState.OUT;
            txb_ClaveTemp.Name = "txb_ClaveTemp";
            txb_ClaveTemp.PasswordChar = '\0';
            txb_ClaveTemp.PrefixSuffixText = null;
            txb_ClaveTemp.PromptChar = '_';
            txb_ClaveTemp.ReadOnly = false;
            txb_ClaveTemp.RejectInputOnFirstFailure = false;
            txb_ClaveTemp.ResetOnPrompt = true;
            txb_ClaveTemp.ResetOnSpace = true;
            txb_ClaveTemp.RightToLeft = RightToLeft.No;
            txb_ClaveTemp.SelectedText = "";
            txb_ClaveTemp.SelectionLength = 0;
            txb_ClaveTemp.SelectionStart = 0;
            txb_ClaveTemp.ShortcutsEnabled = true;
            txb_ClaveTemp.Size = new Size(250, 48);
            txb_ClaveTemp.SkipLiterals = true;
            txb_ClaveTemp.TabIndex = 1;
            txb_ClaveTemp.TabStop = false;
            txb_ClaveTemp.TextAlign = HorizontalAlignment.Left;
            txb_ClaveTemp.TextMaskFormat = MaskFormat.IncludeLiterals;
            txb_ClaveTemp.TrailingIcon = null;
            txb_ClaveTemp.UseSystemPasswordChar = false;
            txb_ClaveTemp.ValidatingType = null;
            // 
            // txb_Descripcion
            // 
            txb_Descripcion.AllowPromptAsInput = true;
            txb_Descripcion.Anchor = AnchorStyles.Left;
            txb_Descripcion.AnimateReadOnly = false;
            txb_Descripcion.AsciiOnly = false;
            txb_Descripcion.BackgroundImageLayout = ImageLayout.None;
            txb_Descripcion.BeepOnError = false;
            txb_Descripcion.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txb_Descripcion.Depth = 0;
            txb_Descripcion.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txb_Descripcion.HidePromptOnLeave = false;
            txb_Descripcion.HideSelection = true;
            txb_Descripcion.InsertKeyMode = InsertKeyMode.Default;
            txb_Descripcion.LeadingIcon = null;
            txb_Descripcion.Location = new Point(186, 81);
            txb_Descripcion.Mask = "";
            txb_Descripcion.MaxLength = 32767;
            txb_Descripcion.MouseState = MaterialSkin.MouseState.OUT;
            txb_Descripcion.Name = "txb_Descripcion";
            txb_Descripcion.PasswordChar = '\0';
            txb_Descripcion.PrefixSuffixText = null;
            txb_Descripcion.PromptChar = '_';
            txb_Descripcion.ReadOnly = false;
            txb_Descripcion.RejectInputOnFirstFailure = false;
            txb_Descripcion.ResetOnPrompt = true;
            txb_Descripcion.ResetOnSpace = true;
            txb_Descripcion.RightToLeft = RightToLeft.No;
            txb_Descripcion.SelectedText = "";
            txb_Descripcion.SelectionLength = 0;
            txb_Descripcion.SelectionStart = 0;
            txb_Descripcion.ShortcutsEnabled = true;
            txb_Descripcion.Size = new Size(250, 48);
            txb_Descripcion.SkipLiterals = true;
            txb_Descripcion.TabIndex = 2;
            txb_Descripcion.TabStop = false;
            txb_Descripcion.TextAlign = HorizontalAlignment.Left;
            txb_Descripcion.TextMaskFormat = MaskFormat.IncludeLiterals;
            txb_Descripcion.TrailingIcon = null;
            txb_Descripcion.UseSystemPasswordChar = false;
            txb_Descripcion.ValidatingType = null;
            // 
            // txb_PrecioPublicoTemp
            // 
            txb_PrecioPublicoTemp.AllowPromptAsInput = true;
            txb_PrecioPublicoTemp.Anchor = AnchorStyles.Left;
            txb_PrecioPublicoTemp.AnimateReadOnly = false;
            txb_PrecioPublicoTemp.AsciiOnly = false;
            txb_PrecioPublicoTemp.BackgroundImageLayout = ImageLayout.None;
            txb_PrecioPublicoTemp.BeepOnError = false;
            txb_PrecioPublicoTemp.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txb_PrecioPublicoTemp.Depth = 0;
            txb_PrecioPublicoTemp.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txb_PrecioPublicoTemp.HidePromptOnLeave = false;
            txb_PrecioPublicoTemp.HideSelection = true;
            txb_PrecioPublicoTemp.InsertKeyMode = InsertKeyMode.Default;
            txb_PrecioPublicoTemp.LeadingIcon = null;
            txb_PrecioPublicoTemp.Location = new Point(186, 221);
            txb_PrecioPublicoTemp.Mask = "";
            txb_PrecioPublicoTemp.MaxLength = 32767;
            txb_PrecioPublicoTemp.MouseState = MaterialSkin.MouseState.OUT;
            txb_PrecioPublicoTemp.Name = "txb_PrecioPublicoTemp";
            txb_PrecioPublicoTemp.PasswordChar = '\0';
            txb_PrecioPublicoTemp.PrefixSuffixText = null;
            txb_PrecioPublicoTemp.PromptChar = '_';
            txb_PrecioPublicoTemp.ReadOnly = false;
            txb_PrecioPublicoTemp.RejectInputOnFirstFailure = false;
            txb_PrecioPublicoTemp.ResetOnPrompt = true;
            txb_PrecioPublicoTemp.ResetOnSpace = true;
            txb_PrecioPublicoTemp.RightToLeft = RightToLeft.No;
            txb_PrecioPublicoTemp.SelectedText = "";
            txb_PrecioPublicoTemp.SelectionLength = 0;
            txb_PrecioPublicoTemp.SelectionStart = 0;
            txb_PrecioPublicoTemp.ShortcutsEnabled = true;
            txb_PrecioPublicoTemp.Size = new Size(250, 48);
            txb_PrecioPublicoTemp.SkipLiterals = true;
            txb_PrecioPublicoTemp.TabIndex = 4;
            txb_PrecioPublicoTemp.TabStop = false;
            txb_PrecioPublicoTemp.TextAlign = HorizontalAlignment.Left;
            txb_PrecioPublicoTemp.TextMaskFormat = MaskFormat.IncludeLiterals;
            txb_PrecioPublicoTemp.TrailingIcon = null;
            txb_PrecioPublicoTemp.UseSystemPasswordChar = false;
            txb_PrecioPublicoTemp.ValidatingType = null;
            txb_PrecioPublicoTemp.KeyPress += txb_PrecioPublicoTemp_KeyPress;
            // 
            // txb_UnidadEntradaTemp
            // 
            txb_UnidadEntradaTemp.AllowPromptAsInput = true;
            txb_UnidadEntradaTemp.Anchor = AnchorStyles.Left;
            txb_UnidadEntradaTemp.AnimateReadOnly = false;
            txb_UnidadEntradaTemp.AsciiOnly = false;
            txb_UnidadEntradaTemp.BackgroundImageLayout = ImageLayout.None;
            txb_UnidadEntradaTemp.BeepOnError = false;
            txb_UnidadEntradaTemp.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txb_UnidadEntradaTemp.Depth = 0;
            txb_UnidadEntradaTemp.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txb_UnidadEntradaTemp.HidePromptOnLeave = false;
            txb_UnidadEntradaTemp.HideSelection = true;
            txb_UnidadEntradaTemp.InsertKeyMode = InsertKeyMode.Default;
            txb_UnidadEntradaTemp.LeadingIcon = null;
            txb_UnidadEntradaTemp.Location = new Point(186, 291);
            txb_UnidadEntradaTemp.Mask = "";
            txb_UnidadEntradaTemp.MaxLength = 32767;
            txb_UnidadEntradaTemp.MouseState = MaterialSkin.MouseState.OUT;
            txb_UnidadEntradaTemp.Name = "txb_UnidadEntradaTemp";
            txb_UnidadEntradaTemp.PasswordChar = '\0';
            txb_UnidadEntradaTemp.PrefixSuffixText = null;
            txb_UnidadEntradaTemp.PromptChar = '_';
            txb_UnidadEntradaTemp.ReadOnly = false;
            txb_UnidadEntradaTemp.RejectInputOnFirstFailure = false;
            txb_UnidadEntradaTemp.ResetOnPrompt = true;
            txb_UnidadEntradaTemp.ResetOnSpace = true;
            txb_UnidadEntradaTemp.RightToLeft = RightToLeft.No;
            txb_UnidadEntradaTemp.SelectedText = "";
            txb_UnidadEntradaTemp.SelectionLength = 0;
            txb_UnidadEntradaTemp.SelectionStart = 0;
            txb_UnidadEntradaTemp.ShortcutsEnabled = true;
            txb_UnidadEntradaTemp.Size = new Size(250, 48);
            txb_UnidadEntradaTemp.SkipLiterals = true;
            txb_UnidadEntradaTemp.TabIndex = 5;
            txb_UnidadEntradaTemp.TabStop = false;
            txb_UnidadEntradaTemp.TextAlign = HorizontalAlignment.Left;
            txb_UnidadEntradaTemp.TextMaskFormat = MaskFormat.IncludeLiterals;
            txb_UnidadEntradaTemp.TrailingIcon = null;
            txb_UnidadEntradaTemp.UseSystemPasswordChar = false;
            txb_UnidadEntradaTemp.ValidatingType = null;
            // 
            // materialButton1
            // 
            materialButton1.Anchor = AnchorStyles.None;
            materialButton1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            materialButton1.BackColor = Color.Red;
            materialButton1.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            materialButton1.Depth = 0;
            materialButton1.HighEmphasis = true;
            materialButton1.Icon = null;
            materialButton1.Location = new Point(43, 437);
            materialButton1.Margin = new Padding(4, 6, 4, 6);
            materialButton1.MouseState = MaterialSkin.MouseState.HOVER;
            materialButton1.Name = "materialButton1";
            materialButton1.NoAccentTextColor = Color.Empty;
            materialButton1.Size = new Size(96, 36);
            materialButton1.TabIndex = 7;
            materialButton1.Text = "Cancelar";
            materialButton1.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            materialButton1.UseAccentColor = false;
            materialButton1.UseVisualStyleBackColor = false;
            materialButton1.Click += materialButton1_Click;
            // 
            // cmb_Unidentrada
            // 
            cmb_Unidentrada.Anchor = AnchorStyles.Left;
            cmb_Unidentrada.AutoResize = false;
            cmb_Unidentrada.BackColor = Color.FromArgb(255, 255, 255);
            cmb_Unidentrada.Depth = 0;
            cmb_Unidentrada.DrawMode = DrawMode.OwnerDrawVariable;
            cmb_Unidentrada.DropDownHeight = 174;
            cmb_Unidentrada.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_Unidentrada.DropDownWidth = 121;
            cmb_Unidentrada.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cmb_Unidentrada.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cmb_Unidentrada.FormattingEnabled = true;
            cmb_Unidentrada.IntegralHeight = false;
            cmb_Unidentrada.ItemHeight = 43;
            cmb_Unidentrada.Location = new Point(186, 360);
            cmb_Unidentrada.MaxDropDownItems = 4;
            cmb_Unidentrada.MouseState = MaterialSkin.MouseState.OUT;
            cmb_Unidentrada.Name = "cmb_Unidentrada";
            cmb_Unidentrada.Size = new Size(250, 49);
            cmb_Unidentrada.StartIndex = 0;
            cmb_Unidentrada.TabIndex = 36;
            // 
            // ProdTemp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(460, 558);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(lbl_ProducTemp);
            Name = "ProdTemp";
            StartPosition = FormStartPosition.CenterScreen;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel lbl_ProducTemp;
        private TableLayoutPanel tableLayoutPanel1;
        private MaterialSkin.Controls.MaterialMaskedTextBox txb_PrecioUnitarioTemp;
        private MaterialSkin.Controls.MaterialMaskedTextBox txb_UnidadEntradaTemp;
        private MaterialSkin.Controls.MaterialMaskedTextBox txb_ClaveTemp;
        private MaterialSkin.Controls.MaterialLabel lbl_ClaveTemp;
        private MaterialSkin.Controls.MaterialLabel lbl_descripcionTemp;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialMaskedTextBox txb_Descripcion;
        private MaterialSkin.Controls.MaterialMaskedTextBox txb_PrecioPublicoTemp;
        private MaterialSkin.Controls.MaterialLabel lbl_PPTemp;
        private MaterialSkin.Controls.MaterialLabel lbl_UnidadTemp;
        private MaterialSkin.Controls.MaterialButton materialButton2;
        private MaterialSkin.Controls.MaterialButton materialButton1;
        private MaterialSkin.Controls.MaterialComboBox cmb_Unidentrada;
    }
}