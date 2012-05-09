namespace Telas
{
    partial class FrmProdutoPesquisaPreco
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBusca = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.tb_produtoDataGridView = new System.Windows.Forms.DataGridView();
            this.unidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoVendaVarejoSemDesconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdProdutoAtacado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPrecoAtacadoSemDesconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPrecoAtacado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_produtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saceDataSet = new Dados.saceDataSet();
            this.tb_produtoTableAdapter = new Dados.saceDataSetTableAdapters.tb_produtoTableAdapter();
            this.tableAdapterManager = new Dados.saceDataSetTableAdapters.TableAdapterManager();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buscar Por:";
            // 
            // cmbBusca
            // 
            this.cmbBusca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBusca.FormattingEnabled = true;
            this.cmbBusca.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cmbBusca.Items.AddRange(new object[] {
            "Descrição",
            "Código",
            "Data Atualização Maior que"});
            this.cmbBusca.Location = new System.Drawing.Point(12, 36);
            this.cmbBusca.Name = "cmbBusca";
            this.cmbBusca.Size = new System.Drawing.Size(216, 28);
            this.cmbBusca.TabIndex = 3;
            this.cmbBusca.SelectedIndexChanged += new System.EventHandler(this.cmbBusca_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(232, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Texto:";
            // 
            // txtTexto
            // 
            this.txtTexto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTexto.Location = new System.Drawing.Point(234, 38);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(755, 26);
            this.txtTexto.TabIndex = 1;
            this.txtTexto.TextChanged += new System.EventHandler(this.txtTexto_TextChanged);
            // 
            // tb_produtoDataGridView
            // 
            this.tb_produtoDataGridView.AllowUserToAddRows = false;
            this.tb_produtoDataGridView.AllowUserToDeleteRows = false;
            this.tb_produtoDataGridView.AllowUserToResizeColumns = false;
            this.tb_produtoDataGridView.AllowUserToResizeRows = false;
            this.tb_produtoDataGridView.AutoGenerateColumns = false;
            this.tb_produtoDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tb_produtoDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tb_produtoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_produtoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.unidade,
            this.precoVendaVarejoSemDesconto,
            this.dataGridViewTextBoxColumn20,
            this.qtdProdutoAtacado,
            this.totalPrecoAtacadoSemDesconto,
            this.totalPrecoAtacado,
            this.dataGridViewTextBoxColumn17});
            this.tb_produtoDataGridView.DataSource = this.tb_produtoBindingSource;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tb_produtoDataGridView.DefaultCellStyle = dataGridViewCellStyle8;
            this.tb_produtoDataGridView.Location = new System.Drawing.Point(12, 83);
            this.tb_produtoDataGridView.MultiSelect = false;
            this.tb_produtoDataGridView.Name = "tb_produtoDataGridView";
            this.tb_produtoDataGridView.ReadOnly = true;
            this.tb_produtoDataGridView.RowHeadersWidth = 7;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F);
            this.tb_produtoDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.tb_produtoDataGridView.RowTemplate.Height = 30;
            this.tb_produtoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_produtoDataGridView.Size = new System.Drawing.Size(977, 536);
            this.tb_produtoDataGridView.TabIndex = 5;
            this.tb_produtoDataGridView.TabStop = false;
            this.tb_produtoDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tb_produtoDataGridView_CellContentClick);
            // 
            // unidade
            // 
            this.unidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.unidade.DataPropertyName = "unidade";
            this.unidade.FillWeight = 30F;
            this.unidade.HeaderText = "Unid";
            this.unidade.MinimumWidth = 40;
            this.unidade.Name = "unidade";
            this.unidade.ReadOnly = true;
            // 
            // precoVendaVarejoSemDesconto
            // 
            this.precoVendaVarejoSemDesconto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.precoVendaVarejoSemDesconto.DataPropertyName = "precoVendaVarejoSemDesconto";
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.precoVendaVarejoSemDesconto.DefaultCellStyle = dataGridViewCellStyle2;
            this.precoVendaVarejoSemDesconto.HeaderText = "Varejo";
            this.precoVendaVarejoSemDesconto.MinimumWidth = 90;
            this.precoVendaVarejoSemDesconto.Name = "precoVendaVarejoSemDesconto";
            this.precoVendaVarejoSemDesconto.ReadOnly = true;
            this.precoVendaVarejoSemDesconto.Width = 90;
            // 
            // qtdProdutoAtacado
            // 
            this.qtdProdutoAtacado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.qtdProdutoAtacado.DataPropertyName = "qtdProdutoAtacado";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.qtdProdutoAtacado.DefaultCellStyle = dataGridViewCellStyle4;
            this.qtdProdutoAtacado.FillWeight = 40F;
            this.qtdProdutoAtacado.HeaderText = "Qtd Atcd";
            this.qtdProdutoAtacado.MinimumWidth = 45;
            this.qtdProdutoAtacado.Name = "qtdProdutoAtacado";
            this.qtdProdutoAtacado.ReadOnly = true;
            // 
            // totalPrecoAtacadoSemDesconto
            // 
            this.totalPrecoAtacadoSemDesconto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.totalPrecoAtacadoSemDesconto.DataPropertyName = "totalPrecoAtacadoSemDesconto";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle5.Format = "C2";
            this.totalPrecoAtacadoSemDesconto.DefaultCellStyle = dataGridViewCellStyle5;
            this.totalPrecoAtacadoSemDesconto.HeaderText = "Atacado";
            this.totalPrecoAtacadoSemDesconto.MinimumWidth = 90;
            this.totalPrecoAtacadoSemDesconto.Name = "totalPrecoAtacadoSemDesconto";
            this.totalPrecoAtacadoSemDesconto.ReadOnly = true;
            this.totalPrecoAtacadoSemDesconto.Width = 90;
            // 
            // totalPrecoAtacado
            // 
            this.totalPrecoAtacado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.totalPrecoAtacado.DataPropertyName = "totalPrecoAtacado";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle6.Format = "C2";
            this.totalPrecoAtacado.DefaultCellStyle = dataGridViewCellStyle6;
            this.totalPrecoAtacado.HeaderText = "Atacado à Vista";
            this.totalPrecoAtacado.MinimumWidth = 90;
            this.totalPrecoAtacado.Name = "totalPrecoAtacado";
            this.totalPrecoAtacado.ReadOnly = true;
            this.totalPrecoAtacado.Width = 93;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "codProduto";
            this.dataGridViewTextBoxColumn2.FillWeight = 50F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Código";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 60;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "nome";
            this.dataGridViewTextBoxColumn3.FillWeight = 400F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Produto";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 420;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 420;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn20.DataPropertyName = "precoVendaVarejo";
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.Format = "C2";
            this.dataGridViewTextBoxColumn20.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn20.FillWeight = 200F;
            this.dataGridViewTextBoxColumn20.HeaderText = "Varejo à Vista";
            this.dataGridViewTextBoxColumn20.MinimumWidth = 90;
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.Width = 90;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn17.DataPropertyName = "ultimaDataAtualizacao";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.dataGridViewTextBoxColumn17.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn17.HeaderText = "Data Atualização";
            this.dataGridViewTextBoxColumn17.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            // 
            // tb_produtoBindingSource
            // 
            this.tb_produtoBindingSource.DataMember = "tb_produto";
            this.tb_produtoBindingSource.DataSource = this.saceDataSet;
            // 
            // saceDataSet
            // 
            this.saceDataSet.DataSetName = "saceDataSet";
            this.saceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tb_produtoTableAdapter
            // 
            this.tb_produtoTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.tb_bancoTableAdapter = null;
            this.tableAdapterManager.tb_cartao_creditoTableAdapter = null;
            this.tableAdapterManager.tb_cfopTableAdapter = null;
            this.tableAdapterManager.tb_configuracao_sistemaTableAdapter = null;
            this.tableAdapterManager.tb_conta_bancoTableAdapter = null;
            this.tableAdapterManager.tb_contaTableAdapter = null;
            this.tableAdapterManager.tb_contato_empresaTableAdapter = null;
            this.tableAdapterManager.tb_cstTableAdapter = null;
            this.tableAdapterManager.tb_documento_pagamentoTableAdapter = null;
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
            this.tableAdapterManager.tb_produtoTableAdapter = this.tb_produtoTableAdapter;
            this.tableAdapterManager.tb_saida_forma_pagamentoTableAdapter = null;
            this.tableAdapterManager.tb_saida_produtoTableAdapter = null;
            this.tableAdapterManager.tb_saidaTableAdapter = null;
            this.tableAdapterManager.tb_situacao_contaTableAdapter = null;
            this.tableAdapterManager.tb_situacao_pagamentosTableAdapter = null;
            this.tableAdapterManager.tb_situacao_produtoTableAdapter = null;
            this.tableAdapterManager.tb_subgrupoTableAdapter = null;
            this.tableAdapterManager.tb_tipo_contaTableAdapter = null;
            this.tableAdapterManager.tb_tipo_documentoTableAdapter = null;
            this.tableAdapterManager.tb_tipo_movimentacao_contaTableAdapter = null;
            this.tableAdapterManager.tb_tipo_saidaTableAdapter = null;
            this.tableAdapterManager.tb_usuarioTableAdapter = null;
            this.tableAdapterManager.tp_tipo_entradaTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Dados.saceDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // FrmProdutoPesquisaPreco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 631);
            this.Controls.Add(this.tb_produtoDataGridView);
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBusca);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "FrmProdutoPesquisaPreco";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pesquisa Preço de Produtos";
            this.Load += new System.EventHandler(this.FrmProdutoPesquisaPreco_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmProdutoPesquisaPreco_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBusca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTexto;
        private Dados.saceDataSet saceDataSet;
        private System.Windows.Forms.BindingSource tb_produtoBindingSource;
        private Dados.saceDataSetTableAdapters.tb_produtoTableAdapter tb_produtoTableAdapter;
        private Dados.saceDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView tb_produtoDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoVendaVarejoSemDesconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdProdutoAtacado;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPrecoAtacadoSemDesconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPrecoAtacado;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
  
    }
}