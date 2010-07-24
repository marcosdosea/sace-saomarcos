namespace Telas
{
    partial class FrmSaidaPesquisa
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
            this.tb_saidaDataGridView = new System.Windows.Forms.DataGridView();
            this.tb_saidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saceDataSet = new Dados.saceDataSet();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBusca = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_saidaTableAdapter = new Dados.saceDataSetTableAdapters.tb_saidaTableAdapter();
            this.tableAdapterManager = new Dados.saceDataSetTableAdapters.TableAdapterManager();
            this.codSaidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataSaida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codProfissional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroCartaoVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pedidoGerado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saidaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saidaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_saidaDataGridView
            // 
            this.tb_saidaDataGridView.AllowUserToAddRows = false;
            this.tb_saidaDataGridView.AllowUserToDeleteRows = false;
            this.tb_saidaDataGridView.AutoGenerateColumns = false;
            this.tb_saidaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_saidaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codSaidaDataGridViewTextBoxColumn,
            this.dataSaida,
            this.codCliente,
            this.codProfissional,
            this.numeroCartaoVenda,
            this.pedidoGerado,
            this.total,
            this.desconto,
            this.totalPago});
            this.tb_saidaDataGridView.DataSource = this.tb_saidaBindingSource;
            this.tb_saidaDataGridView.Location = new System.Drawing.Point(8, 50);
            this.tb_saidaDataGridView.MultiSelect = false;
            this.tb_saidaDataGridView.Name = "tb_saidaDataGridView";
            this.tb_saidaDataGridView.ReadOnly = true;
            this.tb_saidaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_saidaDataGridView.Size = new System.Drawing.Size(673, 260);
            this.tb_saidaDataGridView.TabIndex = 8;
            this.tb_saidaDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tb_saidaDataGridView_CellClick);
            this.tb_saidaDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tb_saidaDataGridView_CellClick);
            // 
            // tb_saidaBindingSource
            // 
            this.tb_saidaBindingSource.DataMember = "tb_saida";
            this.tb_saidaBindingSource.DataSource = this.saceDataSet;
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
            this.txtTexto.Location = new System.Drawing.Point(144, 23);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(539, 20);
            this.txtTexto.TabIndex = 5;
            this.txtTexto.TextChanged += new System.EventHandler(this.txtTexto_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Texto:";
            // 
            // cmbBusca
            // 
            this.cmbBusca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusca.FormattingEnabled = true;
            this.cmbBusca.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cmbBusca.Items.AddRange(new object[] {
            "Código"});
            this.cmbBusca.Location = new System.Drawing.Point(8, 23);
            this.cmbBusca.Name = "cmbBusca";
            this.cmbBusca.Size = new System.Drawing.Size(121, 21);
            this.cmbBusca.TabIndex = 7;
            this.cmbBusca.SelectedIndexChanged += new System.EventHandler(this.cmbBusca_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Buscar Por:";
            // 
            // tb_saidaTableAdapter
            // 
            this.tb_saidaTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.tb_baixa_contaTableAdapter = null;
            this.tableAdapterManager.tb_bancoTableAdapter = null;
            this.tableAdapterManager.tb_cartao_creditoTableAdapter = null;
            this.tableAdapterManager.tb_cfopTableAdapter = null;
            this.tableAdapterManager.tb_configuracao_sistemaTableAdapter = null;
            this.tableAdapterManager.tb_conta_bancoTableAdapter = null;
            this.tableAdapterManager.tb_contaTableAdapter = null;
            this.tableAdapterManager.tb_contato_empresaTableAdapter = null;
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
            this.tableAdapterManager.tb_saida_produtoTableAdapter = null;
            this.tableAdapterManager.tb_saidaTableAdapter = this.tb_saidaTableAdapter;
            this.tableAdapterManager.tb_tipo_movimentacao_contaTableAdapter = null;
            this.tableAdapterManager.tb_usuarioTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Dados.saceDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // codSaidaDataGridViewTextBoxColumn
            // 
            this.codSaidaDataGridViewTextBoxColumn.DataPropertyName = "codSaida";
            this.codSaidaDataGridViewTextBoxColumn.HeaderText = "codSaida";
            this.codSaidaDataGridViewTextBoxColumn.Name = "codSaidaDataGridViewTextBoxColumn";
            this.codSaidaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataSaida
            // 
            this.dataSaida.DataPropertyName = "dataSaida";
            this.dataSaida.HeaderText = "dataSaida";
            this.dataSaida.Name = "dataSaida";
            this.dataSaida.ReadOnly = true;
            // 
            // codCliente
            // 
            this.codCliente.DataPropertyName = "codCliente";
            this.codCliente.HeaderText = "codCliente";
            this.codCliente.Name = "codCliente";
            this.codCliente.ReadOnly = true;
            // 
            // codProfissional
            // 
            this.codProfissional.DataPropertyName = "codProfissional";
            this.codProfissional.HeaderText = "codProfissional";
            this.codProfissional.Name = "codProfissional";
            this.codProfissional.ReadOnly = true;
            // 
            // numeroCartaoVenda
            // 
            this.numeroCartaoVenda.DataPropertyName = "numeroCartaoVenda";
            this.numeroCartaoVenda.HeaderText = "numeroCartaoVenda";
            this.numeroCartaoVenda.Name = "numeroCartaoVenda";
            this.numeroCartaoVenda.ReadOnly = true;
            // 
            // pedidoGerado
            // 
            this.pedidoGerado.DataPropertyName = "pedidoGerado";
            this.pedidoGerado.HeaderText = "pedidoGerado";
            this.pedidoGerado.Name = "pedidoGerado";
            this.pedidoGerado.ReadOnly = true;
            // 
            // total
            // 
            this.total.DataPropertyName = "total";
            this.total.HeaderText = "total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // desconto
            // 
            this.desconto.DataPropertyName = "desconto";
            this.desconto.HeaderText = "desconto";
            this.desconto.Name = "desconto";
            this.desconto.ReadOnly = true;
            // 
            // totalPago
            // 
            this.totalPago.DataPropertyName = "totalPago";
            this.totalPago.HeaderText = "totalPago";
            this.totalPago.Name = "totalPago";
            this.totalPago.ReadOnly = true;
            // 
            // FrmSaidaPesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 318);
            this.Controls.Add(this.tb_saidaDataGridView);
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBusca);
            this.Controls.Add(this.label1);
            this.Name = "FrmSaidaPesquisa";
            this.Text = "FrmSaidaPesquisa";
            this.Load += new System.EventHandler(this.FrmSaidaPesquisa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSaidaPesquisa_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tb_saidaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saidaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tb_saidaDataGridView;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBusca;
        private System.Windows.Forms.Label label1;
        private Dados.saceDataSet saceDataSet;
        private Dados.saceDataSetTableAdapters.tb_saidaTableAdapter tb_saidaTableAdapter;
        private Dados.saceDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource tb_saidaBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn codSaidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataSaida;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn codProfissional;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroCartaoVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn pedidoGerado;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn desconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPago;

    }
}