namespace SACE.Telas
{
    partial class FrmBaixaConta
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tb_contasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_contaTableAdapter = new SACE.Dados.saceDataSetTableAdapters.tb_contaTableAdapter();
            this.saceDataSet1 = new SACE.Dados.saceDataSet();
            this.tableAdapterManager1 = new SACE.Dados.saceDataSetTableAdapters.TableAdapterManager();
            this.tb_baixa_contaTableAdapter = new SACE.Dados.saceDataSetTableAdapters.tb_baixa_contaTableAdapter();
            this.baixaButton = new System.Windows.Forms.Button();
            this.codPessoaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codPlanoContaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codSaidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.documentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codEntradaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codContaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataVencimentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.situacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.observacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoContaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_contasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codPessoaDataGridViewTextBoxColumn,
            this.codPlanoContaDataGridViewTextBoxColumn,
            this.codSaidaDataGridViewTextBoxColumn,
            this.documentoDataGridViewTextBoxColumn,
            this.codEntradaDataGridViewTextBoxColumn,
            this.codContaDataGridViewTextBoxColumn,
            this.dataVencimentoDataGridViewTextBoxColumn,
            this.valorDataGridViewTextBoxColumn,
            this.situacaoDataGridViewTextBoxColumn,
            this.observacaoDataGridViewTextBoxColumn,
            this.tipoContaDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.tb_contasBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(9, 115);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(864, 150);
            this.dataGridView1.TabIndex = 0;
            // 
            // tb_contasBindingSource
            // 
            this.tb_contasBindingSource.DataMember = "tb_conta";
            this.tb_contasBindingSource.DataSource = this.saceDataSet1;
            // 
            // tb_contaTableAdapter
            // 
            this.tb_contaTableAdapter.ClearBeforeFill = true;
            // 
            // saceDataSet1
            // 
            this.saceDataSet1.DataSetName = "saceDataSet";
            this.saceDataSet1.Prefix = "SACE";
            this.saceDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.tb_baixa_contaTableAdapter = this.tb_baixa_contaTableAdapter;
            this.tableAdapterManager1.tb_bancoTableAdapter = null;
            this.tableAdapterManager1.tb_cartao_creditoTableAdapter = null;
            this.tableAdapterManager1.tb_cfopTableAdapter = null;
            this.tableAdapterManager1.tb_configuracao_sistemaTableAdapter = null;
            this.tableAdapterManager1.tb_conta_bancoTableAdapter = null;
            this.tableAdapterManager1.tb_contaTableAdapter = this.tb_contaTableAdapter;
            this.tableAdapterManager1.tb_contato_empresaTableAdapter = null;
            this.tableAdapterManager1.tb_entrada_produtoTableAdapter = null;
            this.tableAdapterManager1.tb_entradaTableAdapter = null;
            this.tableAdapterManager1.tb_forma_pagamentoTableAdapter = null;
            this.tableAdapterManager1.tb_funcionalidadeTableAdapter = null;
            this.tableAdapterManager1.tb_grupo_contaTableAdapter = null;
            this.tableAdapterManager1.tb_grupoTableAdapter = null;
            this.tableAdapterManager1.tb_lojaTableAdapter = null;
            this.tableAdapterManager1.tb_movimentacao_contaTableAdapter = null;
            this.tableAdapterManager1.tb_perfil_funcionalidadeTableAdapter = null;
            this.tableAdapterManager1.tb_perfilTableAdapter = null;
            this.tableAdapterManager1.tb_permissaoTableAdapter = null;
            this.tableAdapterManager1.tb_pessoaTableAdapter = null;
            this.tableAdapterManager1.tb_plano_contaTableAdapter = null;
            this.tableAdapterManager1.tb_produto_lojaTableAdapter = null;
            this.tableAdapterManager1.tb_produtoTableAdapter = null;
            this.tableAdapterManager1.tb_saida_produtoTableAdapter = null;
            this.tableAdapterManager1.tb_saidaTableAdapter = null;
            this.tableAdapterManager1.tb_tipo_movimentacao_contaTableAdapter = null;
            this.tableAdapterManager1.tb_usuarioTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = SACE.Dados.saceDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tb_baixa_contaTableAdapter
            // 
            this.tb_baixa_contaTableAdapter.ClearBeforeFill = true;
            // 
            // baixaButton
            // 
            this.baixaButton.Location = new System.Drawing.Point(404, 271);
            this.baixaButton.Name = "baixaButton";
            this.baixaButton.Size = new System.Drawing.Size(75, 23);
            this.baixaButton.TabIndex = 1;
            this.baixaButton.Text = "Dar Baixa";
            this.baixaButton.UseVisualStyleBackColor = true;
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
            // situacaoDataGridViewTextBoxColumn
            // 
            this.situacaoDataGridViewTextBoxColumn.DataPropertyName = "situacao";
            this.situacaoDataGridViewTextBoxColumn.HeaderText = "situacao";
            this.situacaoDataGridViewTextBoxColumn.Name = "situacaoDataGridViewTextBoxColumn";
            this.situacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // observacaoDataGridViewTextBoxColumn
            // 
            this.observacaoDataGridViewTextBoxColumn.DataPropertyName = "observacao";
            this.observacaoDataGridViewTextBoxColumn.HeaderText = "observacao";
            this.observacaoDataGridViewTextBoxColumn.Name = "observacaoDataGridViewTextBoxColumn";
            this.observacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tipoContaDataGridViewTextBoxColumn
            // 
            this.tipoContaDataGridViewTextBoxColumn.DataPropertyName = "tipoConta";
            this.tipoContaDataGridViewTextBoxColumn.HeaderText = "tipoConta";
            this.tipoContaDataGridViewTextBoxColumn.Name = "tipoContaDataGridViewTextBoxColumn";
            this.tipoContaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FrmBaixaConta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 464);
            this.Controls.Add(this.baixaButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmBaixaConta";
            this.Text = "FrmBaixaConta";
            this.Load += new System.EventHandler(this.FrmBaixaConta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_contasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource tb_contasBindingSource;
        private SACE.Dados.saceDataSetTableAdapters.tb_contaTableAdapter tb_contaTableAdapter;
        private SACE.Dados.saceDataSet saceDataSet1;
        private SACE.Dados.saceDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private SACE.Dados.saceDataSetTableAdapters.tb_baixa_contaTableAdapter tb_baixa_contaTableAdapter;
        private System.Windows.Forms.Button baixaButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn codPessoaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codPlanoContaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codSaidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn documentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codEntradaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codContaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataVencimentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn situacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn observacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoContaDataGridViewTextBoxColumn;
    }
}