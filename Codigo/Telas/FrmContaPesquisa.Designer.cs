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
            this.codPessoaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codPlanoContaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codSaidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codEntradaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codContaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataVencimentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_contaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saceDataSet = new Dados.saceDataSet();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBusca = new System.Windows.Forms.ComboBox();
            this.tb_contaTableAdapter = new Dados.saceDataSetTableAdapters.tb_contaTableAdapter();
            this.tableAdapterManager = new Dados.saceDataSetTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.tb_contaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_contaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_contaDataGridView
            // 
            this.tb_contaDataGridView.AllowUserToAddRows = false;
            this.tb_contaDataGridView.AllowUserToDeleteRows = false;
            this.tb_contaDataGridView.AutoGenerateColumns = false;
            this.tb_contaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_contaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codPessoaDataGridViewTextBoxColumn,
            this.codPlanoContaDataGridViewTextBoxColumn,
            this.codSaidaDataGridViewTextBoxColumn,
            this.documentoDataGridViewTextBoxColumn,
            this.codEntradaDataGridViewTextBoxColumn,
            this.codContaDataGridViewTextBoxColumn,
            this.dataVencimentoDataGridViewTextBoxColumn,
            this.valorDataGridViewTextBoxColumn,
            this.observacaoDataGridViewTextBoxColumn});
            this.tb_contaDataGridView.DataSource = this.tb_contaBindingSource;
            this.tb_contaDataGridView.Location = new System.Drawing.Point(11, 52);
            this.tb_contaDataGridView.Name = "tb_contaDataGridView";
            this.tb_contaDataGridView.ReadOnly = true;
            this.tb_contaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_contaDataGridView.Size = new System.Drawing.Size(561, 220);
            this.tb_contaDataGridView.TabIndex = 10;
            this.tb_contaDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tb_grupo_contaDataGridView_CellClick);
            // 
            // codPessoaDataGridViewTextBoxColumn
            // 
            this.codPessoaDataGridViewTextBoxColumn.DataPropertyName = "codPessoa";
            this.codPessoaDataGridViewTextBoxColumn.HeaderText = "codPessoa";
            this.codPessoaDataGridViewTextBoxColumn.Name = "codPessoaDataGridViewTextBoxColumn";
            this.codPessoaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codPlanoContaDataGridViewTextBoxColumn
            // 
            this.codPlanoContaDataGridViewTextBoxColumn.DataPropertyName = "codPlanoConta";
            this.codPlanoContaDataGridViewTextBoxColumn.HeaderText = "codPlanoConta";
            this.codPlanoContaDataGridViewTextBoxColumn.Name = "codPlanoContaDataGridViewTextBoxColumn";
            this.codPlanoContaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codSaidaDataGridViewTextBoxColumn
            // 
            this.codSaidaDataGridViewTextBoxColumn.DataPropertyName = "codSaida";
            this.codSaidaDataGridViewTextBoxColumn.HeaderText = "codSaida";
            this.codSaidaDataGridViewTextBoxColumn.Name = "codSaidaDataGridViewTextBoxColumn";
            this.codSaidaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // documentoDataGridViewTextBoxColumn
            // 
            this.documentoDataGridViewTextBoxColumn.DataPropertyName = "documento";
            this.documentoDataGridViewTextBoxColumn.HeaderText = "documento";
            this.documentoDataGridViewTextBoxColumn.Name = "documentoDataGridViewTextBoxColumn";
            this.documentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codEntradaDataGridViewTextBoxColumn
            // 
            this.codEntradaDataGridViewTextBoxColumn.DataPropertyName = "codEntrada";
            this.codEntradaDataGridViewTextBoxColumn.HeaderText = "codEntrada";
            this.codEntradaDataGridViewTextBoxColumn.Name = "codEntradaDataGridViewTextBoxColumn";
            this.codEntradaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codContaDataGridViewTextBoxColumn
            // 
            this.codContaDataGridViewTextBoxColumn.DataPropertyName = "codConta";
            this.codContaDataGridViewTextBoxColumn.HeaderText = "codConta";
            this.codContaDataGridViewTextBoxColumn.Name = "codContaDataGridViewTextBoxColumn";
            this.codContaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataVencimentoDataGridViewTextBoxColumn
            // 
            this.dataVencimentoDataGridViewTextBoxColumn.DataPropertyName = "dataVencimento";
            this.dataVencimentoDataGridViewTextBoxColumn.HeaderText = "dataVencimento";
            this.dataVencimentoDataGridViewTextBoxColumn.Name = "dataVencimentoDataGridViewTextBoxColumn";
            this.dataVencimentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorDataGridViewTextBoxColumn
            // 
            this.valorDataGridViewTextBoxColumn.DataPropertyName = "valor";
            this.valorDataGridViewTextBoxColumn.HeaderText = "valor";
            this.valorDataGridViewTextBoxColumn.Name = "valorDataGridViewTextBoxColumn";
            this.valorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // observacaoDataGridViewTextBoxColumn
            // 
            this.observacaoDataGridViewTextBoxColumn.DataPropertyName = "observacao";
            this.observacaoDataGridViewTextBoxColumn.HeaderText = "observacao";
            this.observacaoDataGridViewTextBoxColumn.Name = "observacaoDataGridViewTextBoxColumn";
            this.observacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tb_contaBindingSource
            // 
            this.tb_contaBindingSource.DataMember = "tb_conta";
            this.tb_contaBindingSource.DataSource = this.saceDataSet;
            // 
            // saceDataSet
            // 
            this.saceDataSet.DataSetName = "saceDataSet";
            this.saceDataSet.Prefix = "SACE";
            this.saceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtTexto
            // 
            this.txtTexto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTexto.Location = new System.Drawing.Point(147, 25);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(425, 20);
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
            "Codigo Pessoa",
            "Codigo Entrada",
            "Codigo Saída",
            "Data Vencimento"});
            this.cmbBusca.Location = new System.Drawing.Point(11, 24);
            this.cmbBusca.Name = "cmbBusca";
            this.cmbBusca.Size = new System.Drawing.Size(121, 21);
            this.cmbBusca.TabIndex = 13;
            this.cmbBusca.SelectedIndexChanged += new System.EventHandler(this.cmbBusca_SelectedIndexChanged);
            // 
            // tb_contaTableAdapter
            // 
            this.tb_contaTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.tb_bancoTableAdapter = null;
            this.tableAdapterManager.tb_cartao_creditoTableAdapter = null;
            this.tableAdapterManager.tb_cfopTableAdapter = null;
            this.tableAdapterManager.tb_configuracao_sistemaTableAdapter = null;
            this.tableAdapterManager.tb_conta_bancoTableAdapter = null;
            this.tableAdapterManager.tb_contaTableAdapter = this.tb_contaTableAdapter;
            this.tableAdapterManager.tb_contato_empresaTableAdapter = null;
            this.tableAdapterManager.tb_entrada_forma_pagamentoTableAdapter = null;
            this.tableAdapterManager.tb_entrada_produtoTableAdapter = null;
            this.tableAdapterManager.tb_entradaTableAdapter = null;
            this.tableAdapterManager.tb_forma_pagamentoTableAdapter = null;
            this.tableAdapterManager.tb_funcionalidadeTableAdapter = null;
            this.tableAdapterManager.tb_grupo_contaTableAdapter = null;
            this.tableAdapterManager.tb_grupoTableAdapter = null;
            this.tableAdapterManager.tb_lojaTableAdapter = null;
            this.tableAdapterManager.tb_movimentacao_contaTableAdapter = null;
            this.tableAdapterManager.tb_perfil_funcionalidadeTableAdapter = null;
            this.tableAdapterManager.tb_perfilTableAdapter = null;
            this.tableAdapterManager.tb_permissaoTableAdapter = null;
            this.tableAdapterManager.tb_pessoaTableAdapter = null;
            this.tableAdapterManager.tb_plano_contaTableAdapter = null;
            this.tableAdapterManager.tb_produto_lojaTableAdapter = null;
            this.tableAdapterManager.tb_produtoTableAdapter = null;
            this.tableAdapterManager.tb_saida_forma_pagamentoTableAdapter = null;
            this.tableAdapterManager.tb_saida_produtoTableAdapter = null;
            this.tableAdapterManager.tb_saidaTableAdapter = null;
            this.tableAdapterManager.tb_situacao_contaTableAdapter = null;
            this.tableAdapterManager.tb_situacao_produtoTableAdapter = null;
            this.tableAdapterManager.tb_tipo_contaTableAdapter = null;
            this.tableAdapterManager.tb_tipo_movimentacao_contaTableAdapter = null;
            this.tableAdapterManager.tb_tipo_saidaTableAdapter = null;
            this.tableAdapterManager.tb_usuarioTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Dados.saceDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // FrmContaPesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 281);
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
            ((System.ComponentModel.ISupportInitialize)(this.tb_contaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tb_contaDataGridView;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Dados.saceDataSetTableAdapters.tb_contaTableAdapter tb_contaTableAdapter;
        private Dados.saceDataSet saceDataSet;
        private Dados.saceDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource tb_contaBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn codPessoaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codPlanoContaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codSaidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codEntradaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codContaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataVencimentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox cmbBusca;
    }
}