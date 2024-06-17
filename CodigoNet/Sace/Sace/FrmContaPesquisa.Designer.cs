namespace Telas
{
    partial class FrmContaPesquisa
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
            this.tb_contaDataGridView = new System.Windows.Forms.DataGridView();
            this.contaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBusca = new System.Windows.Forms.ComboBox();
            this.codContaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codEntradaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codSaidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataVencimento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaoSituacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tb_contaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_contaDataGridView
            // 
            this.tb_contaDataGridView.AllowUserToAddRows = false;
            this.tb_contaDataGridView.AllowUserToDeleteRows = false;
            this.tb_contaDataGridView.AutoGenerateColumns = false;
            this.tb_contaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_contaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codContaDataGridViewTextBoxColumn,
            this.codEntradaDataGridViewTextBoxColumn,
            this.codSaidaDataGridViewTextBoxColumn,
            this.valorDataGridViewTextBoxColumn,
            this.DataVencimento,
            this.descricaoSituacaoDataGridViewTextBoxColumn});
            this.tb_contaDataGridView.DataSource = this.contaBindingSource;
            this.tb_contaDataGridView.Location = new System.Drawing.Point(11, 52);
            this.tb_contaDataGridView.Name = "tb_contaDataGridView";
            this.tb_contaDataGridView.ReadOnly = true;
            this.tb_contaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_contaDataGridView.Size = new System.Drawing.Size(654, 220);
            this.tb_contaDataGridView.TabIndex = 10;
            this.tb_contaDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tb_grupo_contaDataGridView_CellClick);
            // 
            // contaBindingSource
            // 
            this.contaBindingSource.DataSource = typeof(Dominio.Conta);
            // 
            // txtTexto
            // 
            this.txtTexto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTexto.Location = new System.Drawing.Point(147, 25);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(518, 20);
            this.txtTexto.TabIndex = 6;
            this.txtTexto.TextChanged += new System.EventHandler(this.txtTexto_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Texto:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Buscar Por:";
            // 
            // cmbBusca
            // 
            this.cmbBusca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusca.FormattingEnabled = true;
            this.cmbBusca.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cmbBusca.Items.AddRange(new object[] {
            "Codigo Conta",
            "Entrada",
            "Saída"});
            this.cmbBusca.Location = new System.Drawing.Point(11, 24);
            this.cmbBusca.Name = "cmbBusca";
            this.cmbBusca.Size = new System.Drawing.Size(121, 21);
            this.cmbBusca.TabIndex = 13;
            this.cmbBusca.SelectedIndexChanged += new System.EventHandler(this.cmbBusca_SelectedIndexChanged);
            // 
            // codContaDataGridViewTextBoxColumn
            // 
            this.codContaDataGridViewTextBoxColumn.DataPropertyName = "CodConta";
            this.codContaDataGridViewTextBoxColumn.HeaderText = "Código";
            this.codContaDataGridViewTextBoxColumn.Name = "codContaDataGridViewTextBoxColumn";
            this.codContaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codEntradaDataGridViewTextBoxColumn
            // 
            this.codEntradaDataGridViewTextBoxColumn.DataPropertyName = "CodEntrada";
            this.codEntradaDataGridViewTextBoxColumn.HeaderText = "Entrada";
            this.codEntradaDataGridViewTextBoxColumn.Name = "codEntradaDataGridViewTextBoxColumn";
            this.codEntradaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codSaidaDataGridViewTextBoxColumn
            // 
            this.codSaidaDataGridViewTextBoxColumn.DataPropertyName = "CodSaida";
            this.codSaidaDataGridViewTextBoxColumn.HeaderText = "Saída";
            this.codSaidaDataGridViewTextBoxColumn.Name = "codSaidaDataGridViewTextBoxColumn";
            this.codSaidaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorDataGridViewTextBoxColumn
            // 
            this.valorDataGridViewTextBoxColumn.DataPropertyName = "Valor";
            this.valorDataGridViewTextBoxColumn.HeaderText = "Valor";
            this.valorDataGridViewTextBoxColumn.Name = "valorDataGridViewTextBoxColumn";
            this.valorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // DataVencimento
            // 
            this.DataVencimento.DataPropertyName = "DataVencimento";
            this.DataVencimento.HeaderText = "Vencimento";
            this.DataVencimento.Name = "DataVencimento";
            this.DataVencimento.ReadOnly = true;
            // 
            // descricaoSituacaoDataGridViewTextBoxColumn
            // 
            this.descricaoSituacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricaoSituacaoDataGridViewTextBoxColumn.DataPropertyName = "DescricaoSituacao";
            this.descricaoSituacaoDataGridViewTextBoxColumn.HeaderText = "Situação";
            this.descricaoSituacaoDataGridViewTextBoxColumn.Name = "descricaoSituacaoDataGridViewTextBoxColumn";
            this.descricaoSituacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FrmContaPesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 281);
            this.Controls.Add(this.cmbBusca);
            this.Controls.Add(this.tb_contaDataGridView);
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmContaPesquisa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pesquisa de Contas";
            this.Load += new System.EventHandler(this.FrmContaPesquisa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmContaPesquisa_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tb_contaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tb_contaDataGridView;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource contaBindingSource;
        private System.Windows.Forms.ComboBox cmbBusca;
        private System.Windows.Forms.DataGridViewTextBoxColumn codContaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codEntradaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codSaidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataVencimento;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoSituacaoDataGridViewTextBoxColumn;
    }
}