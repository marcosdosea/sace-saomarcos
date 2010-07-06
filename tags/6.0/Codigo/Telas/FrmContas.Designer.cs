namespace SACE.Telas
{
    partial class FrmContas
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
            System.Windows.Forms.Label nomeLabel;
            System.Windows.Forms.Label codBancoLabel;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label planoContaLabel;
            System.Windows.Forms.Label pessoaLabel;
            System.Windows.Forms.Label dataVencLabel;
            System.Windows.Forms.Label valorLabel;
            System.Windows.Forms.Label observacaoLabel;
            System.Windows.Forms.Label label5;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmContas));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tb_contasBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.tb_contasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saceDataSet = new SACE.Dados.saceDataSet();
            this.tableAdapterManager1 = new SACE.Dados.saceDataSetTableAdapters.TableAdapterManager();
            this.tb_baixa_contaTableAdapter = new SACE.Dados.saceDataSetTableAdapters.tb_baixa_contaTableAdapter();
            this.tb_contaTableAdapter = new SACE.Dados.saceDataSetTableAdapters.tb_contaTableAdapter();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.codPagamentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codFormaPagamentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorPagoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codContaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorDiferencaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codContaBancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataBaixaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.baixaContasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.documentoTextBox = new System.Windows.Forms.TextBox();
            this.codContaTextBox = new System.Windows.Forms.TextBox();
            this.planoContaComboBox = new System.Windows.Forms.ComboBox();
            this.planoContaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pessoaComboBox = new System.Windows.Forms.ComboBox();
            this.pessoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataVencDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pagarRadioButton = new System.Windows.Forms.RadioButton();
            this.receberRadioButton = new System.Windows.Forms.RadioButton();
            this.tb_pessoaTableAdapter = new SACE.Dados.saceDataSetTableAdapters.tb_pessoaTableAdapter();
            this.tb_plano_contaTableAdapter = new SACE.Dados.saceDataSetTableAdapters.tb_plano_contaTableAdapter();
            this.codEntradaMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.codSaidaMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.valorTextBox = new System.Windows.Forms.TextBox();
            this.observacaoRichTextBox = new System.Windows.Forms.RichTextBox();
            this.situacaoComboBox = new System.Windows.Forms.ComboBox();
            nomeLabel = new System.Windows.Forms.Label();
            codBancoLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            planoContaLabel = new System.Windows.Forms.Label();
            pessoaLabel = new System.Windows.Forms.Label();
            dataVencLabel = new System.Windows.Forms.Label();
            valorLabel = new System.Windows.Forms.Label();
            observacaoLabel = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_contasBindingNavigator)).BeginInit();
            this.tb_contasBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_contasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baixaContasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planoContaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pessoaBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Location = new System.Drawing.Point(4, 117);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new System.Drawing.Size(65, 13);
            nomeLabel.TabIndex = 34;
            nomeLabel.Text = "Documento:";
            // 
            // codBancoLabel
            // 
            codBancoLabel.AutoSize = true;
            codBancoLabel.Location = new System.Drawing.Point(4, 70);
            codBancoLabel.Name = "codBancoLabel";
            codBancoLabel.Size = new System.Drawing.Size(43, 13);
            codBancoLabel.TabIndex = 32;
            codBancoLabel.Text = "Código:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(110, 70);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(83, 13);
            label3.TabIndex = 36;
            label3.Text = "Código Entrada:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(216, 70);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(75, 13);
            label4.TabIndex = 38;
            label4.Text = "Código Saída:";
            // 
            // planoContaLabel
            // 
            planoContaLabel.AutoSize = true;
            planoContaLabel.Location = new System.Drawing.Point(216, 161);
            planoContaLabel.Name = "planoContaLabel";
            planoContaLabel.Size = new System.Drawing.Size(83, 13);
            planoContaLabel.TabIndex = 41;
            planoContaLabel.Text = "Plano de Conta:";
            // 
            // pessoaLabel
            // 
            pessoaLabel.AutoSize = true;
            pessoaLabel.Location = new System.Drawing.Point(216, 117);
            pessoaLabel.Name = "pessoaLabel";
            pessoaLabel.Size = new System.Drawing.Size(45, 13);
            pessoaLabel.TabIndex = 43;
            pessoaLabel.Text = "Pessoa:";
            // 
            // dataVencLabel
            // 
            dataVencLabel.AutoSize = true;
            dataVencLabel.Location = new System.Drawing.Point(4, 161);
            dataVencLabel.Name = "dataVencLabel";
            dataVencLabel.Size = new System.Drawing.Size(92, 13);
            dataVencLabel.TabIndex = 45;
            dataVencLabel.Text = "Data Vencimento:";
            // 
            // valorLabel
            // 
            valorLabel.AutoSize = true;
            valorLabel.Location = new System.Drawing.Point(111, 161);
            valorLabel.Name = "valorLabel";
            valorLabel.Size = new System.Drawing.Size(34, 13);
            valorLabel.TabIndex = 47;
            valorLabel.Text = "Valor:";
            // 
            // observacaoLabel
            // 
            observacaoLabel.AutoSize = true;
            observacaoLabel.Location = new System.Drawing.Point(4, 203);
            observacaoLabel.Name = "observacaoLabel";
            observacaoLabel.Size = new System.Drawing.Size(68, 13);
            observacaoLabel.TabIndex = 51;
            observacaoLabel.Text = "Observacao:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(367, 161);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(52, 13);
            label5.TabIndex = 57;
            label5.Text = "Situação:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 41);
            this.panel1.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastro de Contas a Pagar e a Receber";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tb_contasBindingNavigator
            // 
            this.tb_contasBindingNavigator.AddNewItem = null;
            this.tb_contasBindingNavigator.BindingSource = this.tb_contasBindingSource;
            this.tb_contasBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tb_contasBindingNavigator.DeleteItem = null;
            this.tb_contasBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.tb_contasBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.tb_contasBindingNavigator.Location = new System.Drawing.Point(269, 40);
            this.tb_contasBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tb_contasBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tb_contasBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tb_contasBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tb_contasBindingNavigator.Name = "tb_contasBindingNavigator";
            this.tb_contasBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tb_contasBindingNavigator.Size = new System.Drawing.Size(209, 25);
            this.tb_contasBindingNavigator.TabIndex = 23;
            this.tb_contasBindingNavigator.Text = "bindingNavigator1";
            // 
            // tb_contasBindingSource
            // 
            this.tb_contasBindingSource.DataMember = "tb_conta";
            this.tb_contasBindingSource.DataSource = this.saceDataSet;
            this.tb_contasBindingSource.PositionChanged += new System.EventHandler(this.tb_contasBindingSource_PositionChanged);
            // 
            // saceDataSet
            // 
            this.saceDataSet.DataSetName = "saceDataSet";
            this.saceDataSet.Prefix = "SACE";
            this.saceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // tb_contaTableAdapter
            // 
            this.tb_contaTableAdapter.ClearBeforeFill = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(304, 402);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 28;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(4, 402);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 24;
            this.btnBuscar.Text = "F2 - Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(385, 402);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(79, 402);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 25;
            this.btnNovo.Text = "F3 - Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(229, 402);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 27;
            this.btnExcluir.Text = "F5 - Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(154, 402);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 26;
            this.btnEditar.Text = "F4 - Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codPagamentoDataGridViewTextBoxColumn,
            this.codFormaPagamentoDataGridViewTextBoxColumn,
            this.valorPagoDataGridViewTextBoxColumn,
            this.codContaDataGridViewTextBoxColumn,
            this.valorDiferencaDataGridViewTextBoxColumn,
            this.codContaBancoDataGridViewTextBoxColumn,
            this.dataBaixaDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.baixaContasBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(4, 298);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(465, 100);
            this.dataGridView1.TabIndex = 30;
            // 
            // codPagamentoDataGridViewTextBoxColumn
            // 
            this.codPagamentoDataGridViewTextBoxColumn.DataPropertyName = "codPagamento";
            this.codPagamentoDataGridViewTextBoxColumn.HeaderText = "codPagamento";
            this.codPagamentoDataGridViewTextBoxColumn.Name = "codPagamentoDataGridViewTextBoxColumn";
            this.codPagamentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codFormaPagamentoDataGridViewTextBoxColumn
            // 
            this.codFormaPagamentoDataGridViewTextBoxColumn.DataPropertyName = "codFormaPagamento";
            this.codFormaPagamentoDataGridViewTextBoxColumn.HeaderText = "codFormaPagamento";
            this.codFormaPagamentoDataGridViewTextBoxColumn.Name = "codFormaPagamentoDataGridViewTextBoxColumn";
            this.codFormaPagamentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorPagoDataGridViewTextBoxColumn
            // 
            this.valorPagoDataGridViewTextBoxColumn.DataPropertyName = "valorPago";
            this.valorPagoDataGridViewTextBoxColumn.HeaderText = "valorPago";
            this.valorPagoDataGridViewTextBoxColumn.Name = "valorPagoDataGridViewTextBoxColumn";
            this.valorPagoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codContaDataGridViewTextBoxColumn
            // 
            this.codContaDataGridViewTextBoxColumn.DataPropertyName = "codConta";
            this.codContaDataGridViewTextBoxColumn.HeaderText = "codConta";
            this.codContaDataGridViewTextBoxColumn.Name = "codContaDataGridViewTextBoxColumn";
            this.codContaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorDiferencaDataGridViewTextBoxColumn
            // 
            this.valorDiferencaDataGridViewTextBoxColumn.DataPropertyName = "valorDiferenca";
            this.valorDiferencaDataGridViewTextBoxColumn.HeaderText = "valorDiferenca";
            this.valorDiferencaDataGridViewTextBoxColumn.Name = "valorDiferencaDataGridViewTextBoxColumn";
            this.valorDiferencaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codContaBancoDataGridViewTextBoxColumn
            // 
            this.codContaBancoDataGridViewTextBoxColumn.DataPropertyName = "codContaBanco";
            this.codContaBancoDataGridViewTextBoxColumn.HeaderText = "codContaBanco";
            this.codContaBancoDataGridViewTextBoxColumn.Name = "codContaBancoDataGridViewTextBoxColumn";
            this.codContaBancoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataBaixaDataGridViewTextBoxColumn
            // 
            this.dataBaixaDataGridViewTextBoxColumn.DataPropertyName = "dataBaixa";
            this.dataBaixaDataGridViewTextBoxColumn.HeaderText = "dataBaixa";
            this.dataBaixaDataGridViewTextBoxColumn.Name = "dataBaixaDataGridViewTextBoxColumn";
            this.dataBaixaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // baixaContasBindingSource
            // 
            this.baixaContasBindingSource.DataMember = "tb_baixa_conta";
            this.baixaContasBindingSource.DataSource = this.saceDataSet;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Quitado:";
            // 
            // documentoTextBox
            // 
            this.documentoTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.documentoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_contasBindingSource, "documento", true));
            this.documentoTextBox.Location = new System.Drawing.Point(7, 136);
            this.documentoTextBox.MaxLength = 20;
            this.documentoTextBox.Name = "documentoTextBox";
            this.documentoTextBox.Size = new System.Drawing.Size(207, 20);
            this.documentoTextBox.TabIndex = 42;
            // 
            // codContaTextBox
            // 
            this.codContaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_contasBindingSource, "codConta", true));
            this.codContaTextBox.Location = new System.Drawing.Point(7, 89);
            this.codContaTextBox.Name = "codContaTextBox";
            this.codContaTextBox.ReadOnly = true;
            this.codContaTextBox.Size = new System.Drawing.Size(100, 20);
            this.codContaTextBox.TabIndex = 33;
            // 
            // planoContaComboBox
            // 
            this.planoContaComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_contasBindingSource, "codPlanoConta", true));
            this.planoContaComboBox.DataSource = this.planoContaBindingSource;
            this.planoContaComboBox.DisplayMember = "descricao";
            this.planoContaComboBox.FormattingEnabled = true;
            this.planoContaComboBox.Location = new System.Drawing.Point(219, 180);
            this.planoContaComboBox.Name = "planoContaComboBox";
            this.planoContaComboBox.Size = new System.Drawing.Size(144, 21);
            this.planoContaComboBox.TabIndex = 40;
            this.planoContaComboBox.ValueMember = "codPlanoConta";
            // 
            // planoContaBindingSource
            // 
            this.planoContaBindingSource.DataMember = "tb_plano_conta";
            this.planoContaBindingSource.DataSource = this.saceDataSet;
            // 
            // pessoaComboBox
            // 
            this.pessoaComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_contasBindingSource, "codPessoa", true));
            this.pessoaComboBox.DataSource = this.pessoaBindingSource;
            this.pessoaComboBox.DisplayMember = "nome";
            this.pessoaComboBox.FormattingEnabled = true;
            this.pessoaComboBox.Location = new System.Drawing.Point(220, 136);
            this.pessoaComboBox.Name = "pessoaComboBox";
            this.pessoaComboBox.Size = new System.Drawing.Size(249, 21);
            this.pessoaComboBox.TabIndex = 44;
            this.pessoaComboBox.ValueMember = "codPessoa";
            // 
            // pessoaBindingSource
            // 
            this.pessoaBindingSource.DataMember = "tb_pessoa";
            this.pessoaBindingSource.DataSource = this.saceDataSet;
            // 
            // dataVencDateTimePicker
            // 
            this.dataVencDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tb_contasBindingSource, "dataVencimento", true));
            this.dataVencDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataVencDateTimePicker.Location = new System.Drawing.Point(7, 180);
            this.dataVencDateTimePicker.Name = "dataVencDateTimePicker";
            this.dataVencDateTimePicker.Size = new System.Drawing.Size(100, 20);
            this.dataVencDateTimePicker.TabIndex = 46;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pagarRadioButton);
            this.groupBox2.Controls.Add(this.receberRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(325, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(144, 34);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo:";
            // 
            // pagarRadioButton
            // 
            this.pagarRadioButton.AutoSize = true;
            this.pagarRadioButton.Location = new System.Drawing.Point(86, 14);
            this.pagarRadioButton.Name = "pagarRadioButton";
            this.pagarRadioButton.Size = new System.Drawing.Size(63, 17);
            this.pagarRadioButton.TabIndex = 1;
            this.pagarRadioButton.Text = "À Pagar";
            this.pagarRadioButton.UseVisualStyleBackColor = true;
            // 
            // receberRadioButton
            // 
            this.receberRadioButton.AutoSize = true;
            this.receberRadioButton.Checked = true;
            this.receberRadioButton.Location = new System.Drawing.Point(10, 14);
            this.receberRadioButton.Name = "receberRadioButton";
            this.receberRadioButton.Size = new System.Drawing.Size(76, 17);
            this.receberRadioButton.TabIndex = 0;
            this.receberRadioButton.TabStop = true;
            this.receberRadioButton.Text = "À Receber";
            this.receberRadioButton.UseVisualStyleBackColor = true;
            // 
            // tb_pessoaTableAdapter
            // 
            this.tb_pessoaTableAdapter.ClearBeforeFill = true;
            // 
            // tb_plano_contaTableAdapter
            // 
            this.tb_plano_contaTableAdapter.ClearBeforeFill = true;
            // 
            // codEntradaMaskedTextBox
            // 
            this.codEntradaMaskedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_contasBindingSource, "codEntrada", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.codEntradaMaskedTextBox.Location = new System.Drawing.Point(113, 89);
            this.codEntradaMaskedTextBox.Mask = "0000000000000000";
            this.codEntradaMaskedTextBox.Name = "codEntradaMaskedTextBox";
            this.codEntradaMaskedTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.codEntradaMaskedTextBox.Size = new System.Drawing.Size(100, 20);
            this.codEntradaMaskedTextBox.TabIndex = 36;
            this.codEntradaMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // codSaidaMaskedTextBox
            // 
            this.codSaidaMaskedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_contasBindingSource, "codSaida", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N0"));
            this.codSaidaMaskedTextBox.Location = new System.Drawing.Point(219, 89);
            this.codSaidaMaskedTextBox.Mask = "000000000000000";
            this.codSaidaMaskedTextBox.Name = "codSaidaMaskedTextBox";
            this.codSaidaMaskedTextBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.codSaidaMaskedTextBox.Size = new System.Drawing.Size(100, 20);
            this.codSaidaMaskedTextBox.TabIndex = 38;
            this.codSaidaMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // valorTextBox
            // 
            this.valorTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_contasBindingSource, "valor", true));
            this.valorTextBox.Location = new System.Drawing.Point(114, 180);
            this.valorTextBox.MaxLength = 13;
            this.valorTextBox.Name = "valorTextBox";
            this.valorTextBox.Size = new System.Drawing.Size(100, 20);
            this.valorTextBox.TabIndex = 48;
            this.valorTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.valorTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.valorTextBox_KeyDown);
            // 
            // observacaoRichTextBox
            // 
            this.observacaoRichTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_contasBindingSource, "observacao", true));
            this.observacaoRichTextBox.Location = new System.Drawing.Point(7, 222);
            this.observacaoRichTextBox.Name = "observacaoRichTextBox";
            this.observacaoRichTextBox.Size = new System.Drawing.Size(462, 51);
            this.observacaoRichTextBox.TabIndex = 55;
            this.observacaoRichTextBox.Text = "";
            // 
            // situacaoComboBox
            // 
            this.situacaoComboBox.Enabled = false;
            this.situacaoComboBox.FormattingEnabled = true;
            this.situacaoComboBox.Items.AddRange(new object[] {
            "Aberto",
            "Quitado"});
            this.situacaoComboBox.Location = new System.Drawing.Point(370, 179);
            this.situacaoComboBox.Name = "situacaoComboBox";
            this.situacaoComboBox.Size = new System.Drawing.Size(99, 21);
            this.situacaoComboBox.TabIndex = 56;
            // 
            // FrmContas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 437);
            this.Controls.Add(label5);
            this.Controls.Add(this.situacaoComboBox);
            this.Controls.Add(this.observacaoRichTextBox);
            this.Controls.Add(this.valorTextBox);
            this.Controls.Add(this.codSaidaMaskedTextBox);
            this.Controls.Add(this.codEntradaMaskedTextBox);
            this.Controls.Add(observacaoLabel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(valorLabel);
            this.Controls.Add(dataVencLabel);
            this.Controls.Add(this.dataVencDateTimePicker);
            this.Controls.Add(pessoaLabel);
            this.Controls.Add(this.pessoaComboBox);
            this.Controls.Add(planoContaLabel);
            this.Controls.Add(this.planoContaComboBox);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(nomeLabel);
            this.Controls.Add(this.documentoTextBox);
            this.Controls.Add(codBancoLabel);
            this.Controls.Add(this.codContaTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.tb_contasBindingNavigator);
            this.Controls.Add(this.panel1);
            this.Name = "FrmContas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Contas a Pagar e a Receber";
            this.Load += new System.EventHandler(this.FrmContas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_contasBindingNavigator)).EndInit();
            this.tb_contasBindingNavigator.ResumeLayout(false);
            this.tb_contasBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_contasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baixaContasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planoContaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pessoaBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.BindingNavigator tb_contasBindingNavigator;
        private SACE.Dados.saceDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private SACE.Dados.saceDataSetTableAdapters.tb_baixa_contaTableAdapter tb_baixa_contaTableAdapter;
        private SACE.Dados.saceDataSetTableAdapters.tb_contaTableAdapter tb_contaTableAdapter;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnEditar;
        private SACE.Dados.saceDataSet saceDataSet;
        private System.Windows.Forms.BindingSource tb_contasBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox documentoTextBox;
        private System.Windows.Forms.TextBox codContaTextBox;
        private System.Windows.Forms.ComboBox planoContaComboBox;
        private System.Windows.Forms.ComboBox pessoaComboBox;
        private System.Windows.Forms.DateTimePicker dataVencDateTimePicker;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton pagarRadioButton;
        private System.Windows.Forms.RadioButton receberRadioButton;
        private System.Windows.Forms.BindingSource baixaContasBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn codPagamentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codFormaPagamentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorPagoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codContaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorDiferencaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codContaBancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataBaixaDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource planoContaBindingSource;
        private System.Windows.Forms.BindingSource pessoaBindingSource;
        private SACE.Dados.saceDataSetTableAdapters.tb_pessoaTableAdapter tb_pessoaTableAdapter;
        private SACE.Dados.saceDataSetTableAdapters.tb_plano_contaTableAdapter tb_plano_contaTableAdapter;
        private System.Windows.Forms.MaskedTextBox codEntradaMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox codSaidaMaskedTextBox;
        private System.Windows.Forms.TextBox valorTextBox;
        private System.Windows.Forms.RichTextBox observacaoRichTextBox;
        private System.Windows.Forms.ComboBox situacaoComboBox;
    }
}