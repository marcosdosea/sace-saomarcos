namespace Telas
{
    partial class FrmEntradaPesquisa
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBusca = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.entradaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_entradaDataGridView = new System.Windows.Forms.DataGridView();
            this.codEntradaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroNotaFiscalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeFornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataEntradaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.entradaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entradaDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buscar Por:";
            // 
            // cmbBusca
            // 
            this.cmbBusca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusca.FormattingEnabled = true;
            this.cmbBusca.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cmbBusca.Items.AddRange(new object[] {
            "Código",
            "Número Nota Fiscal",
            "Nome Fornecedor"});
            this.cmbBusca.Location = new System.Drawing.Point(10, 26);
            this.cmbBusca.Name = "cmbBusca";
            this.cmbBusca.Size = new System.Drawing.Size(121, 21);
            this.cmbBusca.TabIndex = 3;
            this.cmbBusca.SelectedIndexChanged += new System.EventHandler(this.cmbBusca_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Texto:";
            // 
            // txtTexto
            // 
            this.txtTexto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTexto.Location = new System.Drawing.Point(146, 26);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(641, 20);
            this.txtTexto.TabIndex = 1;
            this.txtTexto.TextChanged += new System.EventHandler(this.txtTexto_TextChanged);
            // 
            // entradaBindingSource
            // 
            this.entradaBindingSource.DataSource = typeof(Dominio.Entrada);
            // 
            // tb_entradaDataGridView
            // 
            this.tb_entradaDataGridView.AllowUserToAddRows = false;
            this.tb_entradaDataGridView.AllowUserToDeleteRows = false;
            this.tb_entradaDataGridView.AutoGenerateColumns = false;
            this.tb_entradaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_entradaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codEntradaDataGridViewTextBoxColumn,
            this.numeroNotaFiscalDataGridViewTextBoxColumn,
            this.nomeFornecedor,
            this.dataEntradaDataGridViewTextBoxColumn,
            this.totalNota});
            this.tb_entradaDataGridView.DataSource = this.entradaBindingSource;
            this.tb_entradaDataGridView.Location = new System.Drawing.Point(12, 63);
            this.tb_entradaDataGridView.MultiSelect = false;
            this.tb_entradaDataGridView.Name = "tb_entradaDataGridView";
            this.tb_entradaDataGridView.ReadOnly = true;
            this.tb_entradaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_entradaDataGridView.Size = new System.Drawing.Size(775, 260);
            this.tb_entradaDataGridView.TabIndex = 4;
            this.tb_entradaDataGridView.TabStop = false;
            this.tb_entradaDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tb_entradaDataGridView_CellClick);
            this.tb_entradaDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tb_entradaDataGridView_CellClick);
            // 
            // codEntradaDataGridViewTextBoxColumn
            // 
            this.codEntradaDataGridViewTextBoxColumn.DataPropertyName = "CodEntrada";
            this.codEntradaDataGridViewTextBoxColumn.HeaderText = "Cod Entrada";
            this.codEntradaDataGridViewTextBoxColumn.Name = "codEntradaDataGridViewTextBoxColumn";
            this.codEntradaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numeroNotaFiscalDataGridViewTextBoxColumn
            // 
            this.numeroNotaFiscalDataGridViewTextBoxColumn.DataPropertyName = "NumeroNotaFiscal";
            this.numeroNotaFiscalDataGridViewTextBoxColumn.HeaderText = "Nota Fiscal";
            this.numeroNotaFiscalDataGridViewTextBoxColumn.Name = "numeroNotaFiscalDataGridViewTextBoxColumn";
            this.numeroNotaFiscalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeFornecedor
            // 
            this.nomeFornecedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomeFornecedor.DataPropertyName = "NomeFornecedor";
            this.nomeFornecedor.HeaderText = "Fornecedor";
            this.nomeFornecedor.Name = "nomeFornecedor";
            this.nomeFornecedor.ReadOnly = true;
            // 
            // dataEntradaDataGridViewTextBoxColumn
            // 
            this.dataEntradaDataGridViewTextBoxColumn.DataPropertyName = "DataEntrada";
            this.dataEntradaDataGridViewTextBoxColumn.HeaderText = "Data Entrada";
            this.dataEntradaDataGridViewTextBoxColumn.Name = "dataEntradaDataGridViewTextBoxColumn";
            this.dataEntradaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalNota
            // 
            this.totalNota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.totalNota.DataPropertyName = "TotalNota";
            this.totalNota.FillWeight = 40F;
            this.totalNota.HeaderText = "Total Nota (R$)";
            this.totalNota.Name = "totalNota";
            this.totalNota.ReadOnly = true;
            // 
            // FrmEntradaPesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 335);
            this.Controls.Add(this.tb_entradaDataGridView);
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBusca);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "FrmEntradaPesquisa";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pesquisa Entrada de Produtos";
            this.Load += new System.EventHandler(this.FrmEntradaPesquisa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmEntradaPesquisa_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.entradaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entradaDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBusca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.BindingSource entradaBindingSource;
        private System.Windows.Forms.DataGridView tb_entradaDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn codEntradaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroNotaFiscalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeFornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataEntradaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalNota;
        
    }
}