namespace SACE.Telas
{
    partial class FrmGrupoContaPesquisa
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
            this.saceDataSet = new SACE.Dados.saceDataSet();
            this.tb_grupo_contaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_grupo_contaTableAdapter = new SACE.Dados.saceDataSetTableAdapters.tb_grupo_contaTableAdapter();
            this.tableAdapterManager = new SACE.Dados.saceDataSetTableAdapters.TableAdapterManager();
            this.tb_grupo_contaDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_grupo_contaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_grupo_contaDataGridView)).BeginInit();
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
            "Descrição",
            "Código"});
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
            this.txtTexto.Size = new System.Drawing.Size(308, 20);
            this.txtTexto.TabIndex = 1;
            this.txtTexto.TextChanged += new System.EventHandler(this.txtTexto_TextChanged);
            // 
            // saceDataSet
            // 
            this.saceDataSet.DataSetName = "saceDataSet";
            this.saceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tb_grupo_contaBindingSource
            // 
            this.tb_grupo_contaBindingSource.DataMember = "tb_grupo_conta";
            this.tb_grupo_contaBindingSource.DataSource = this.saceDataSet;
            // 
            // tb_grupo_contaTableAdapter
            // 
            this.tb_grupo_contaTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.tb_bancoTableAdapter = null;
            this.tableAdapterManager.tb_cartao_creditoTableAdapter = null;
            this.tableAdapterManager.tb_configuracao_sistemaTableAdapter = null;
            this.tableAdapterManager.tb_conta_bancoTableAdapter = null;
            this.tableAdapterManager.tb_conta_pagarTableAdapter = null;
            this.tableAdapterManager.tb_conta_receberTableAdapter = null;
            this.tableAdapterManager.tb_contato_empresaTableAdapter = null;
            this.tableAdapterManager.tb_empresaTableAdapter = null;
            this.tableAdapterManager.tb_entrada_produtoTableAdapter = null;
            this.tableAdapterManager.tb_entradaTableAdapter = null;
            this.tableAdapterManager.tb_forma_pagamentoTableAdapter = null;
            this.tableAdapterManager.tb_funcionalidadeTableAdapter = null;
            this.tableAdapterManager.tb_grupo_contaTableAdapter = this.tb_grupo_contaTableAdapter;
            this.tableAdapterManager.tb_grupoTableAdapter = null;
            this.tableAdapterManager.tb_lojaTableAdapter = null;
            this.tableAdapterManager.tb_movimentacao_contaTableAdapter = null;
            this.tableAdapterManager.tb_pagamentoTableAdapter = null;
            this.tableAdapterManager.tb_permissaoTableAdapter = null;
            this.tableAdapterManager.tb_pessoaTableAdapter = null;
            this.tableAdapterManager.tb_plano_contaTableAdapter = null;
            this.tableAdapterManager.tb_produto_lojaTableAdapter = null;
            this.tableAdapterManager.tb_produtoTableAdapter = null;
            this.tableAdapterManager.tb_recebimentoTableAdapter = null;
            this.tableAdapterManager.tb_saida_produtoTableAdapter = null;
            this.tableAdapterManager.tb_saidaTableAdapter = null;
            this.tableAdapterManager.tb_tipo_movimentacao_contaTableAdapter = null;
            this.tableAdapterManager.tb_usuarioTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = SACE.Dados.saceDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tb_grupo_contaDataGridView
            // 
            this.tb_grupo_contaDataGridView.AllowUserToAddRows = false;
            this.tb_grupo_contaDataGridView.AllowUserToDeleteRows = false;
            this.tb_grupo_contaDataGridView.AutoGenerateColumns = false;
            this.tb_grupo_contaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_grupo_contaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.tb_grupo_contaDataGridView.DataSource = this.tb_grupo_contaBindingSource;
            this.tb_grupo_contaDataGridView.Location = new System.Drawing.Point(10, 53);
            this.tb_grupo_contaDataGridView.Name = "tb_grupo_contaDataGridView";
            this.tb_grupo_contaDataGridView.ReadOnly = true;
            this.tb_grupo_contaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_grupo_contaDataGridView.Size = new System.Drawing.Size(444, 220);
            this.tb_grupo_contaDataGridView.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "codGrupoConta";
            this.dataGridViewTextBoxColumn2.HeaderText = "Código";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "descricao";
            this.dataGridViewTextBoxColumn3.HeaderText = "Descrição";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // FrmGrupoContaPesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 279);
            this.Controls.Add(this.tb_grupo_contaDataGridView);
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBusca);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "FrmGrupoContaPesquisa";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pesquisa TipoContas de Produtos";
            this.Load += new System.EventHandler(this.FrmGrupoContaPesquisa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmGrupoContaPesquisa_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_grupo_contaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_grupo_contaDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBusca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTexto;
        private SACE.Dados.saceDataSet saceDataSet;
        private System.Windows.Forms.BindingSource tb_grupo_contaBindingSource;
        private SACE.Dados.saceDataSetTableAdapters.tb_grupo_contaTableAdapter tb_grupo_contaTableAdapter;
        private SACE.Dados.saceDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView tb_grupo_contaDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
  
    }
}