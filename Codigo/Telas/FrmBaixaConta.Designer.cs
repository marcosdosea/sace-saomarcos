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
            System.Windows.Forms.Label valorLabel;
            System.Windows.Forms.Label dataPgtoLabel;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            this.totalLabel = new System.Windows.Forms.Label();
            this.baixaButton = new System.Windows.Forms.Button();
            this.pesquisaPanel = new System.Windows.Forms.Panel();
            this.tipoGroupBox = new System.Windows.Forms.GroupBox();
            this.receberRadioButton = new System.Windows.Forms.RadioButton();
            this.pagarRadioButton = new System.Windows.Forms.RadioButton();
            this.todosRadioButton = new System.Windows.Forms.RadioButton();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBusca = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contasDataGridView = new System.Windows.Forms.DataGridView();
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
            this.tb_contasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saceDataSet1 = new SACE.Dados.saceDataSet();
            this.baixaPanel = new System.Windows.Forms.Panel();
            this.valorTextBox = new System.Windows.Forms.TextBox();
            this.ConfirmarButton = new System.Windows.Forms.Button();
            this.contaBancoComboBox = new System.Windows.Forms.ComboBox();
            this.tb_contaBancobindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cancelarButton = new System.Windows.Forms.Button();
            this.formaPagamentoComboBox = new System.Windows.Forms.ComboBox();
            this.tb_formasPagamentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.tb_contaTableAdapter = new SACE.Dados.saceDataSetTableAdapters.tb_contaTableAdapter();
            this.tableAdapterManager1 = new SACE.Dados.saceDataSetTableAdapters.TableAdapterManager();
            this.tb_baixa_contaTableAdapter = new SACE.Dados.saceDataSetTableAdapters.tb_baixa_contaTableAdapter();
            this.tb_baixaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_forma_pagamentoTableAdapter1 = new SACE.Dados.saceDataSetTableAdapters.tb_forma_pagamentoTableAdapter();
            this.tb_conta_bancoTableAdapter1 = new SACE.Dados.saceDataSetTableAdapters.tb_conta_bancoTableAdapter();
            valorLabel = new System.Windows.Forms.Label();
            dataPgtoLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            this.pesquisaPanel.SuspendLayout();
            this.tipoGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contasDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_contasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet1)).BeginInit();
            this.baixaPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_contaBancobindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_formasPagamentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_baixaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // valorLabel
            // 
            valorLabel.AutoSize = true;
            valorLabel.Location = new System.Drawing.Point(288, 8);
            valorLabel.Name = "valorLabel";
            valorLabel.Size = new System.Drawing.Size(34, 13);
            valorLabel.TabIndex = 57;
            valorLabel.Text = "Valor:";
            // 
            // dataPgtoLabel
            // 
            dataPgtoLabel.AutoSize = true;
            dataPgtoLabel.Location = new System.Drawing.Point(181, 8);
            dataPgtoLabel.Name = "dataPgtoLabel";
            dataPgtoLabel.Size = new System.Drawing.Size(77, 13);
            dataPgtoLabel.TabIndex = 56;
            dataPgtoLabel.Text = "Data da Baixa:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(395, 8);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(111, 13);
            label3.TabIndex = 59;
            label3.Text = "Forma de Pagamento:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(523, 8);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(69, 13);
            label4.TabIndex = 63;
            label4.Text = "Conta Banco";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(5, 8);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(123, 13);
            label5.TabIndex = 65;
            label5.Text = "Valor Total Selecionado:";
            // 
            // totalLabel
            // 
            this.totalLabel.AutoSize = true;
            this.totalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalLabel.ForeColor = System.Drawing.Color.Red;
            this.totalLabel.Location = new System.Drawing.Point(5, 26);
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(58, 17);
            this.totalLabel.TabIndex = 66;
            this.totalLabel.Text = "R$ 0,00";
            // 
            // baixaButton
            // 
            this.baixaButton.Location = new System.Drawing.Point(308, 233);
            this.baixaButton.Name = "baixaButton";
            this.baixaButton.Size = new System.Drawing.Size(75, 23);
            this.baixaButton.TabIndex = 1;
            this.baixaButton.Text = "Dar Baixa";
            this.baixaButton.UseVisualStyleBackColor = true;
            this.baixaButton.Click += new System.EventHandler(this.baixaButton_Click);
            // 
            // pesquisaPanel
            // 
            this.pesquisaPanel.Controls.Add(this.tipoGroupBox);
            this.pesquisaPanel.Controls.Add(this.txtTexto);
            this.pesquisaPanel.Controls.Add(this.label2);
            this.pesquisaPanel.Controls.Add(this.cmbBusca);
            this.pesquisaPanel.Controls.Add(this.label1);
            this.pesquisaPanel.Controls.Add(this.contasDataGridView);
            this.pesquisaPanel.Location = new System.Drawing.Point(7, 12);
            this.pesquisaPanel.Name = "pesquisaPanel";
            this.pesquisaPanel.Size = new System.Drawing.Size(683, 217);
            this.pesquisaPanel.TabIndex = 9;
            // 
            // tipoGroupBox
            // 
            this.tipoGroupBox.Controls.Add(this.receberRadioButton);
            this.tipoGroupBox.Controls.Add(this.pagarRadioButton);
            this.tipoGroupBox.Controls.Add(this.todosRadioButton);
            this.tipoGroupBox.Location = new System.Drawing.Point(457, 6);
            this.tipoGroupBox.Name = "tipoGroupBox";
            this.tipoGroupBox.Size = new System.Drawing.Size(222, 44);
            this.tipoGroupBox.TabIndex = 14;
            this.tipoGroupBox.TabStop = false;
            this.tipoGroupBox.Text = "Tipo:";
            // 
            // receberRadioButton
            // 
            this.receberRadioButton.AutoSize = true;
            this.receberRadioButton.Location = new System.Drawing.Point(139, 17);
            this.receberRadioButton.Name = "receberRadioButton";
            this.receberRadioButton.Size = new System.Drawing.Size(76, 17);
            this.receberRadioButton.TabIndex = 2;
            this.receberRadioButton.Text = "À Receber";
            this.receberRadioButton.UseVisualStyleBackColor = true;
            this.receberRadioButton.TextChanged += new System.EventHandler(this.txtTexto_TextChanged);
            this.receberRadioButton.CheckedChanged += new System.EventHandler(this.txtTexto_TextChanged);
            // 
            // pagarRadioButton
            // 
            this.pagarRadioButton.AutoSize = true;
            this.pagarRadioButton.Location = new System.Drawing.Point(69, 17);
            this.pagarRadioButton.Name = "pagarRadioButton";
            this.pagarRadioButton.Size = new System.Drawing.Size(63, 17);
            this.pagarRadioButton.TabIndex = 1;
            this.pagarRadioButton.Text = "À Pagar";
            this.pagarRadioButton.UseVisualStyleBackColor = true;
            this.pagarRadioButton.TextChanged += new System.EventHandler(this.txtTexto_TextChanged);
            this.pagarRadioButton.CheckedChanged += new System.EventHandler(this.txtTexto_TextChanged);
            // 
            // todosRadioButton
            // 
            this.todosRadioButton.AutoSize = true;
            this.todosRadioButton.Checked = true;
            this.todosRadioButton.Location = new System.Drawing.Point(7, 17);
            this.todosRadioButton.Name = "todosRadioButton";
            this.todosRadioButton.Size = new System.Drawing.Size(55, 17);
            this.todosRadioButton.TabIndex = 0;
            this.todosRadioButton.TabStop = true;
            this.todosRadioButton.Text = "Todos";
            this.todosRadioButton.UseVisualStyleBackColor = true;
            this.todosRadioButton.TextChanged += new System.EventHandler(this.txtTexto_TextChanged);
            this.todosRadioButton.CheckedChanged += new System.EventHandler(this.txtTexto_TextChanged);
            // 
            // txtTexto
            // 
            this.txtTexto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTexto.Location = new System.Drawing.Point(142, 23);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(308, 20);
            this.txtTexto.TabIndex = 10;
            this.txtTexto.TextChanged += new System.EventHandler(this.txtTexto_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Texto:";
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
            "Data Vencimento",
            "Data Pagamento"});
            this.cmbBusca.Location = new System.Drawing.Point(6, 23);
            this.cmbBusca.Name = "cmbBusca";
            this.cmbBusca.Size = new System.Drawing.Size(121, 21);
            this.cmbBusca.TabIndex = 12;
            this.cmbBusca.SelectedIndexChanged += new System.EventHandler(this.cmbBusca_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Buscar Por:";
            // 
            // contasDataGridView
            // 
            this.contasDataGridView.AllowUserToAddRows = false;
            this.contasDataGridView.AllowUserToDeleteRows = false;
            this.contasDataGridView.AutoGenerateColumns = false;
            this.contasDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contasDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.contasDataGridView.DataSource = this.tb_contasBindingSource;
            this.contasDataGridView.Location = new System.Drawing.Point(4, 56);
            this.contasDataGridView.Name = "contasDataGridView";
            this.contasDataGridView.ReadOnly = true;
            this.contasDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.contasDataGridView.Size = new System.Drawing.Size(675, 150);
            this.contasDataGridView.TabIndex = 9;
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
            // tb_contasBindingSource
            // 
            this.tb_contasBindingSource.DataMember = "tb_conta";
            this.tb_contasBindingSource.DataSource = this.saceDataSet1;
            // 
            // saceDataSet1
            // 
            this.saceDataSet1.DataSetName = "saceDataSet";
            this.saceDataSet1.Prefix = "SACE";
            this.saceDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // baixaPanel
            // 
            this.baixaPanel.Controls.Add(this.valorTextBox);
            this.baixaPanel.Controls.Add(this.totalLabel);
            this.baixaPanel.Controls.Add(label5);
            this.baixaPanel.Controls.Add(this.ConfirmarButton);
            this.baixaPanel.Controls.Add(label4);
            this.baixaPanel.Controls.Add(this.contaBancoComboBox);
            this.baixaPanel.Controls.Add(this.cancelarButton);
            this.baixaPanel.Controls.Add(this.formaPagamentoComboBox);
            this.baixaPanel.Controls.Add(label3);
            this.baixaPanel.Controls.Add(valorLabel);
            this.baixaPanel.Controls.Add(dataPgtoLabel);
            this.baixaPanel.Controls.Add(this.dataDateTimePicker);
            this.baixaPanel.Enabled = false;
            this.baixaPanel.Location = new System.Drawing.Point(7, 262);
            this.baixaPanel.Name = "baixaPanel";
            this.baixaPanel.Size = new System.Drawing.Size(683, 89);
            this.baixaPanel.TabIndex = 10;
            // 
            // valorTextBox
            // 
            this.valorTextBox.Location = new System.Drawing.Point(291, 27);
            this.valorTextBox.MaxLength = 13;
            this.valorTextBox.Name = "valorTextBox";
            this.valorTextBox.Size = new System.Drawing.Size(100, 20);
            this.valorTextBox.TabIndex = 67;
            this.valorTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.valorTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.valorTextBox_KeyDown);
            // 
            // ConfirmarButton
            // 
            this.ConfirmarButton.Location = new System.Drawing.Point(227, 53);
            this.ConfirmarButton.Name = "ConfirmarButton";
            this.ConfirmarButton.Size = new System.Drawing.Size(75, 23);
            this.ConfirmarButton.TabIndex = 64;
            this.ConfirmarButton.Text = "Confirmar";
            this.ConfirmarButton.UseVisualStyleBackColor = true;
            this.ConfirmarButton.Click += new System.EventHandler(this.ConfirmarButton_Click);
            // 
            // contaBancoComboBox
            // 
            this.contaBancoComboBox.DataSource = this.tb_contaBancobindingSource;
            this.contaBancoComboBox.DisplayMember = "descricao";
            this.contaBancoComboBox.FormattingEnabled = true;
            this.contaBancoComboBox.Location = new System.Drawing.Point(526, 26);
            this.contaBancoComboBox.Name = "contaBancoComboBox";
            this.contaBancoComboBox.Size = new System.Drawing.Size(121, 21);
            this.contaBancoComboBox.TabIndex = 62;
            this.contaBancoComboBox.ValueMember = "codContaBanco";
            // 
            // tb_contaBancobindingSource
            // 
            this.tb_contaBancobindingSource.DataMember = "tb_conta_banco";
            this.tb_contaBancobindingSource.DataSource = this.saceDataSet1;
            // 
            // cancelarButton
            // 
            this.cancelarButton.Location = new System.Drawing.Point(357, 53);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(75, 23);
            this.cancelarButton.TabIndex = 61;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // formaPagamentoComboBox
            // 
            this.formaPagamentoComboBox.DataSource = this.tb_formasPagamentoBindingSource;
            this.formaPagamentoComboBox.DisplayMember = "descricao";
            this.formaPagamentoComboBox.FormattingEnabled = true;
            this.formaPagamentoComboBox.Location = new System.Drawing.Point(398, 26);
            this.formaPagamentoComboBox.Name = "formaPagamentoComboBox";
            this.formaPagamentoComboBox.Size = new System.Drawing.Size(121, 21);
            this.formaPagamentoComboBox.TabIndex = 60;
            this.formaPagamentoComboBox.ValueMember = "codFormaPagamento";
            // 
            // tb_formasPagamentoBindingSource
            // 
            this.tb_formasPagamentoBindingSource.DataMember = "tb_forma_pagamento";
            this.tb_formasPagamentoBindingSource.DataSource = this.saceDataSet1;
            // 
            // dataDateTimePicker
            // 
            this.dataDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataDateTimePicker.Location = new System.Drawing.Point(184, 27);
            this.dataDateTimePicker.Name = "dataDateTimePicker";
            this.dataDateTimePicker.Size = new System.Drawing.Size(100, 20);
            this.dataDateTimePicker.TabIndex = 55;
            // 
            // tb_contaTableAdapter
            // 
            this.tb_contaTableAdapter.ClearBeforeFill = true;
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
            // tb_baixaBindingSource
            // 
            this.tb_baixaBindingSource.DataMember = "tb_baixa_conta";
            this.tb_baixaBindingSource.DataSource = this.saceDataSet1;
            // 
            // tb_forma_pagamentoTableAdapter1
            // 
            this.tb_forma_pagamentoTableAdapter1.ClearBeforeFill = true;
            // 
            // tb_conta_bancoTableAdapter1
            // 
            this.tb_conta_bancoTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmBaixaConta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 361);
            this.Controls.Add(this.baixaPanel);
            this.Controls.Add(this.pesquisaPanel);
            this.Controls.Add(this.baixaButton);
            this.Name = "FrmBaixaConta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Baixa de contas";
            this.Load += new System.EventHandler(this.FrmBaixaConta_Load);
            this.pesquisaPanel.ResumeLayout(false);
            this.pesquisaPanel.PerformLayout();
            this.tipoGroupBox.ResumeLayout(false);
            this.tipoGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contasDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_contasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet1)).EndInit();
            this.baixaPanel.ResumeLayout(false);
            this.baixaPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_contaBancobindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_formasPagamentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_baixaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource tb_contasBindingSource;
        private SACE.Dados.saceDataSetTableAdapters.tb_contaTableAdapter tb_contaTableAdapter;
        private SACE.Dados.saceDataSet saceDataSet1;
        private SACE.Dados.saceDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private SACE.Dados.saceDataSetTableAdapters.tb_baixa_contaTableAdapter tb_baixa_contaTableAdapter;
        private System.Windows.Forms.Button baixaButton;
        private System.Windows.Forms.Panel pesquisaPanel;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbBusca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView contasDataGridView;
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
        private System.Windows.Forms.Panel baixaPanel;
        private System.Windows.Forms.DateTimePicker dataDateTimePicker;
        private System.Windows.Forms.BindingSource tb_baixaBindingSource;
        private System.Windows.Forms.GroupBox tipoGroupBox;
        private System.Windows.Forms.RadioButton receberRadioButton;
        private System.Windows.Forms.RadioButton pagarRadioButton;
        private System.Windows.Forms.RadioButton todosRadioButton;
        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.ComboBox formaPagamentoComboBox;
        private System.Windows.Forms.ComboBox contaBancoComboBox;
        private System.Windows.Forms.Button ConfirmarButton;
        private System.Windows.Forms.Label totalLabel;
        private SACE.Dados.saceDataSetTableAdapters.tb_forma_pagamentoTableAdapter tb_forma_pagamentoTableAdapter1;
        private SACE.Dados.saceDataSetTableAdapters.tb_conta_bancoTableAdapter tb_conta_bancoTableAdapter1;
        private System.Windows.Forms.TextBox valorTextBox;
        private System.Windows.Forms.BindingSource tb_formasPagamentoBindingSource;
        private System.Windows.Forms.BindingSource tb_contaBancobindingSource;
    }
}