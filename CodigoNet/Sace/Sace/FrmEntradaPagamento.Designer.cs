namespace Telas
{
    partial class FrmEntradaPagamento
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
            System.Windows.Forms.Label codEntradaLabel;
            System.Windows.Forms.Label codEmpresaFreteLabel;
            System.Windows.Forms.Label valorFreteLabel;
            System.Windows.Forms.Label codFornecedorLabel;
            System.Windows.Forms.Label totalNotaLabel;
            System.Windows.Forms.Label codFormaPagamentoLabel;
            System.Windows.Forms.Label codDocumentoPagamentoLabel;
            System.Windows.Forms.Label codContaBancoLabel;
            System.Windows.Forms.Label valorLabel;
            System.Windows.Forms.Label dataLabel;
            System.Windows.Forms.Label label7;
            this.saceDataSet = new Dados.saceDataSet();
            this.tb_entradaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codEntradaTextBox = new System.Windows.Forms.TextBox();
            this.codEmpresaFreteTextBox = new System.Windows.Forms.TextBox();
            this.valorFreteTextBox = new System.Windows.Forms.TextBox();
            this.codFornecedorTextBox = new System.Windows.Forms.TextBox();
            this.totalNotaTextBox = new System.Windows.Forms.TextBox();
            this.tb_entrada_forma_pagamentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codFormaPagamentoComboBox = new System.Windows.Forms.ComboBox();
            this.tbformapagamentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codDocumentoPagamentoComboBox = new System.Windows.Forms.ComboBox();
            this.tbdocumentopagamentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codContaBancoComboBox = new System.Windows.Forms.ComboBox();
            this.tbcontabancoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.valorTextBox = new System.Windows.Forms.TextBox();
            this.dataDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.pagamentoDoFreteCheckBox = new System.Windows.Forms.CheckBox();
            this.tb_entrada_forma_pagamentoDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalRecebidoLabel = new System.Windows.Forms.Label();
            this.btnEncerrar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_forma_pagamentoTableAdapter = new Dados.saceDataSetTableAdapters.tb_forma_pagamentoTableAdapter();
            this.tb_conta_bancoTableAdapter = new Dados.saceDataSetTableAdapters.tb_conta_bancoTableAdapter();
            this.tb_documento_pagamentoTableAdapter = new Dados.saceDataSetTableAdapters.tb_documento_pagamentoTableAdapter();
            this.tb_entrada_forma_pagamentoTableAdapter = new Dados.saceDataSetTableAdapters.tb_entrada_forma_pagamentoTableAdapter();
            codEntradaLabel = new System.Windows.Forms.Label();
            codEmpresaFreteLabel = new System.Windows.Forms.Label();
            valorFreteLabel = new System.Windows.Forms.Label();
            codFornecedorLabel = new System.Windows.Forms.Label();
            totalNotaLabel = new System.Windows.Forms.Label();
            codFormaPagamentoLabel = new System.Windows.Forms.Label();
            codDocumentoPagamentoLabel = new System.Windows.Forms.Label();
            codContaBancoLabel = new System.Windows.Forms.Label();
            valorLabel = new System.Windows.Forms.Label();
            dataLabel = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entradaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entrada_forma_pagamentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbformapagamentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdocumentopagamentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcontabancoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entrada_forma_pagamentoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // codEntradaLabel
            // 
            codEntradaLabel.AutoSize = true;
            codEntradaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            codEntradaLabel.Location = new System.Drawing.Point(12, 13);
            codEntradaLabel.Name = "codEntradaLabel";
            codEntradaLabel.Size = new System.Drawing.Size(63, 18);
            codEntradaLabel.TabIndex = 1;
            codEntradaLabel.Text = "Entrada:";
            // 
            // codEmpresaFreteLabel
            // 
            codEmpresaFreteLabel.AutoSize = true;
            codEmpresaFreteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            codEmpresaFreteLabel.Location = new System.Drawing.Point(12, 66);
            codEmpresaFreteLabel.Name = "codEmpresaFreteLabel";
            codEmpresaFreteLabel.Size = new System.Drawing.Size(110, 18);
            codEmpresaFreteLabel.TabIndex = 2;
            codEmpresaFreteLabel.Text = "Empresa Frete:";
            // 
            // valorFreteLabel
            // 
            valorFreteLabel.AutoSize = true;
            valorFreteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            valorFreteLabel.Location = new System.Drawing.Point(517, 66);
            valorFreteLabel.Name = "valorFreteLabel";
            valorFreteLabel.Size = new System.Drawing.Size(117, 18);
            valorFreteLabel.TabIndex = 4;
            valorFreteLabel.Text = "Valor Frete (R$):";
            // 
            // codFornecedorLabel
            // 
            codFornecedorLabel.AutoSize = true;
            codFornecedorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            codFornecedorLabel.Location = new System.Drawing.Point(122, 13);
            codFornecedorLabel.Name = "codFornecedorLabel";
            codFornecedorLabel.Size = new System.Drawing.Size(89, 18);
            codFornecedorLabel.TabIndex = 6;
            codFornecedorLabel.Text = "Fornecedor:";
            // 
            // totalNotaLabel
            // 
            totalNotaLabel.AutoSize = true;
            totalNotaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            totalNotaLabel.Location = new System.Drawing.Point(517, 13);
            totalNotaLabel.Name = "totalNotaLabel";
            totalNotaLabel.Size = new System.Drawing.Size(114, 18);
            totalNotaLabel.TabIndex = 8;
            totalNotaLabel.Text = "Total Nota (R$):";
            // 
            // codFormaPagamentoLabel
            // 
            codFormaPagamentoLabel.AutoSize = true;
            codFormaPagamentoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            codFormaPagamentoLabel.Location = new System.Drawing.Point(12, 122);
            codFormaPagamentoLabel.Name = "codFormaPagamentoLabel";
            codFormaPagamentoLabel.Size = new System.Drawing.Size(136, 18);
            codFormaPagamentoLabel.TabIndex = 10;
            codFormaPagamentoLabel.Text = "Forma Pagamento:";
            // 
            // codDocumentoPagamentoLabel
            // 
            codDocumentoPagamentoLabel.AutoSize = true;
            codDocumentoPagamentoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            codDocumentoPagamentoLabel.Location = new System.Drawing.Point(12, 184);
            codDocumentoPagamentoLabel.Name = "codDocumentoPagamentoLabel";
            codDocumentoPagamentoLabel.Size = new System.Drawing.Size(114, 18);
            codDocumentoPagamentoLabel.TabIndex = 12;
            codDocumentoPagamentoLabel.Text = "Boleto / Cheque";
            // 
            // codContaBancoLabel
            // 
            codContaBancoLabel.AutoSize = true;
            codContaBancoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            codContaBancoLabel.Location = new System.Drawing.Point(263, 122);
            codContaBancoLabel.Name = "codContaBancoLabel";
            codContaBancoLabel.Size = new System.Drawing.Size(99, 18);
            codContaBancoLabel.TabIndex = 14;
            codContaBancoLabel.Text = "Conta Banco:";
            // 
            // valorLabel
            // 
            valorLabel.AutoSize = true;
            valorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            valorLabel.Location = new System.Drawing.Point(495, 184);
            valorLabel.Name = "valorLabel";
            valorLabel.Size = new System.Drawing.Size(159, 18);
            valorLabel.TabIndex = 16;
            valorLabel.Text = "Valor Pagamento (R$):";
            // 
            // dataLabel
            // 
            dataLabel.AutoSize = true;
            dataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataLabel.Location = new System.Drawing.Point(334, 180);
            dataLabel.Name = "dataLabel";
            dataLabel.Size = new System.Drawing.Size(43, 18);
            dataLabel.TabIndex = 18;
            dataLabel.Text = "Data:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(180, 408);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(120, 20);
            label7.TabIndex = 79;
            label7.Text = "Total Recebido:";
            // 
            // saceDataSet
            // 
            this.saceDataSet.DataSetName = "saceDataSet";
            this.saceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tb_entradaBindingSource
            // 
            this.tb_entradaBindingSource.DataMember = "tb_entrada";
            this.tb_entradaBindingSource.DataSource = this.saceDataSet;
            this.tb_entradaBindingSource.Sort = "codEntrada";
            // 
            // codEntradaTextBox
            // 
            this.codEntradaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "codEntrada", true));
            this.codEntradaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.codEntradaTextBox.Location = new System.Drawing.Point(12, 37);
            this.codEntradaTextBox.Name = "codEntradaTextBox";
            this.codEntradaTextBox.ReadOnly = true;
            this.codEntradaTextBox.Size = new System.Drawing.Size(100, 24);
            this.codEntradaTextBox.TabIndex = 2;
            this.codEntradaTextBox.TabStop = false;
            // 
            // codEmpresaFreteTextBox
            // 
            this.codEmpresaFreteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "codEmpresaFrete", true));
            this.codEmpresaFreteTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.codEmpresaFreteTextBox.Location = new System.Drawing.Point(15, 89);
            this.codEmpresaFreteTextBox.Name = "codEmpresaFreteTextBox";
            this.codEmpresaFreteTextBox.ReadOnly = true;
            this.codEmpresaFreteTextBox.Size = new System.Drawing.Size(499, 24);
            this.codEmpresaFreteTextBox.TabIndex = 8;
            this.codEmpresaFreteTextBox.TabStop = false;
            // 
            // valorFreteTextBox
            // 
            this.valorFreteTextBox.BackColor = System.Drawing.Color.Blue;
            this.valorFreteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "valorFrete", true));
            this.valorFreteTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.valorFreteTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.valorFreteTextBox.Location = new System.Drawing.Point(520, 89);
            this.valorFreteTextBox.Name = "valorFreteTextBox";
            this.valorFreteTextBox.ReadOnly = true;
            this.valorFreteTextBox.Size = new System.Drawing.Size(130, 24);
            this.valorFreteTextBox.TabIndex = 10;
            this.valorFreteTextBox.TabStop = false;
            // 
            // codFornecedorTextBox
            // 
            this.codFornecedorTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "codFornecedor", true));
            this.codFornecedorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.codFornecedorTextBox.Location = new System.Drawing.Point(125, 37);
            this.codFornecedorTextBox.Name = "codFornecedorTextBox";
            this.codFornecedorTextBox.ReadOnly = true;
            this.codFornecedorTextBox.Size = new System.Drawing.Size(389, 24);
            this.codFornecedorTextBox.TabIndex = 4;
            this.codFornecedorTextBox.TabStop = false;
            // 
            // totalNotaTextBox
            // 
            this.totalNotaTextBox.BackColor = System.Drawing.Color.Blue;
            this.totalNotaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "totalNota", true));
            this.totalNotaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.totalNotaTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.totalNotaTextBox.Location = new System.Drawing.Point(520, 37);
            this.totalNotaTextBox.Name = "totalNotaTextBox";
            this.totalNotaTextBox.ReadOnly = true;
            this.totalNotaTextBox.Size = new System.Drawing.Size(130, 24);
            this.totalNotaTextBox.TabIndex = 6;
            this.totalNotaTextBox.TabStop = false;
            // 
            // tb_entrada_forma_pagamentoBindingSource
            // 
            this.tb_entrada_forma_pagamentoBindingSource.DataMember = "tb_entrada_forma_pagamento";
            this.tb_entrada_forma_pagamentoBindingSource.DataSource = this.saceDataSet;
            // 
            // codFormaPagamentoComboBox
            // 
            this.codFormaPagamentoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_entrada_forma_pagamentoBindingSource, "codFormaPagamento", true));
            this.codFormaPagamentoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entrada_forma_pagamentoBindingSource, "descricaoFormaPagamento", true));
            this.codFormaPagamentoComboBox.DataSource = this.tbformapagamentoBindingSource;
            this.codFormaPagamentoComboBox.DisplayMember = "descricao";
            this.codFormaPagamentoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codFormaPagamentoComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.codFormaPagamentoComboBox.FormattingEnabled = true;
            this.codFormaPagamentoComboBox.Location = new System.Drawing.Point(12, 148);
            this.codFormaPagamentoComboBox.Name = "codFormaPagamentoComboBox";
            this.codFormaPagamentoComboBox.Size = new System.Drawing.Size(233, 26);
            this.codFormaPagamentoComboBox.TabIndex = 12;
            this.codFormaPagamentoComboBox.ValueMember = "codFormaPagamento";
            this.codFormaPagamentoComboBox.SelectedIndexChanged += new System.EventHandler(this.codFormaPagamentoComboBox_SelectedIndexChanged);
            // 
            // tbformapagamentoBindingSource
            // 
            this.tbformapagamentoBindingSource.DataMember = "tb_forma_pagamento";
            this.tbformapagamentoBindingSource.DataSource = this.saceDataSet;
            // 
            // codDocumentoPagamentoComboBox
            // 
            this.codDocumentoPagamentoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codDocumentoPagamentoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codDocumentoPagamentoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_entrada_forma_pagamentoBindingSource, "codDocumentoPagamento", true));
            this.codDocumentoPagamentoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entrada_forma_pagamentoBindingSource, "codDocumentoPagamento", true));
            this.codDocumentoPagamentoComboBox.DataSource = this.tbdocumentopagamentoBindingSource;
            this.codDocumentoPagamentoComboBox.DisplayMember = "codDocumentoPagamento";
            this.codDocumentoPagamentoComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.codDocumentoPagamentoComboBox.FormattingEnabled = true;
            this.codDocumentoPagamentoComboBox.Location = new System.Drawing.Point(15, 207);
            this.codDocumentoPagamentoComboBox.Name = "codDocumentoPagamentoComboBox";
            this.codDocumentoPagamentoComboBox.Size = new System.Drawing.Size(305, 26);
            this.codDocumentoPagamentoComboBox.TabIndex = 18;
            this.codDocumentoPagamentoComboBox.ValueMember = "codDocumentoPagamento";
            this.codDocumentoPagamentoComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codDocumentoPagamentoComboBox_KeyPress);
            // 
            // tbdocumentopagamentoBindingSource
            // 
            this.tbdocumentopagamentoBindingSource.DataMember = "tb_documento_pagamento";
            this.tbdocumentopagamentoBindingSource.DataSource = this.saceDataSet;
            // 
            // codContaBancoComboBox
            // 
            this.codContaBancoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_entrada_forma_pagamentoBindingSource, "codContaBanco", true));
            this.codContaBancoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entrada_forma_pagamentoBindingSource, "descricaoConta", true));
            this.codContaBancoComboBox.DataSource = this.tbcontabancoBindingSource;
            this.codContaBancoComboBox.DisplayMember = "descricao";
            this.codContaBancoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codContaBancoComboBox.Enabled = false;
            this.codContaBancoComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.codContaBancoComboBox.FormattingEnabled = true;
            this.codContaBancoComboBox.Location = new System.Drawing.Point(266, 148);
            this.codContaBancoComboBox.Name = "codContaBancoComboBox";
            this.codContaBancoComboBox.Size = new System.Drawing.Size(227, 26);
            this.codContaBancoComboBox.TabIndex = 14;
            this.codContaBancoComboBox.ValueMember = "codContaBanco";
            // 
            // tbcontabancoBindingSource
            // 
            this.tbcontabancoBindingSource.DataMember = "tb_conta_banco";
            this.tbcontabancoBindingSource.DataSource = this.saceDataSet;
            // 
            // valorTextBox
            // 
            this.valorTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbdocumentopagamentoBindingSource, "valor", true));
            this.valorTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.valorTextBox.Location = new System.Drawing.Point(498, 209);
            this.valorTextBox.Name = "valorTextBox";
            this.valorTextBox.Size = new System.Drawing.Size(156, 24);
            this.valorTextBox.TabIndex = 22;
            this.valorTextBox.Leave += new System.EventHandler(this.valorTextBox_Leave);
            // 
            // dataDateTimePicker
            // 
            this.dataDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tbdocumentopagamentoBindingSource, "dataVencimento", true));
            this.dataDateTimePicker.Enabled = false;
            this.dataDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dataDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataDateTimePicker.Location = new System.Drawing.Point(337, 205);
            this.dataDateTimePicker.Name = "dataDateTimePicker";
            this.dataDateTimePicker.Size = new System.Drawing.Size(136, 24);
            this.dataDateTimePicker.TabIndex = 20;
            // 
            // pagamentoDoFreteCheckBox
            // 
            this.pagamentoDoFreteCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.tb_entrada_forma_pagamentoBindingSource, "pagamentoDoFrete", true));
            this.pagamentoDoFreteCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pagamentoDoFreteCheckBox.Location = new System.Drawing.Point(499, 148);
            this.pagamentoDoFreteCheckBox.Name = "pagamentoDoFreteCheckBox";
            this.pagamentoDoFreteCheckBox.Size = new System.Drawing.Size(104, 24);
            this.pagamentoDoFreteCheckBox.TabIndex = 16;
            this.pagamentoDoFreteCheckBox.Text = "Frete";
            this.pagamentoDoFreteCheckBox.UseVisualStyleBackColor = true;
            // 
            // tb_entrada_forma_pagamentoDataGridView
            // 
            this.tb_entrada_forma_pagamentoDataGridView.AllowUserToAddRows = false;
            this.tb_entrada_forma_pagamentoDataGridView.AllowUserToDeleteRows = false;
            this.tb_entrada_forma_pagamentoDataGridView.AutoGenerateColumns = false;
            this.tb_entrada_forma_pagamentoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_entrada_forma_pagamentoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewCheckBoxColumn1,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn6});
            this.tb_entrada_forma_pagamentoDataGridView.DataSource = this.tb_entrada_forma_pagamentoBindingSource;
            this.tb_entrada_forma_pagamentoDataGridView.Location = new System.Drawing.Point(15, 258);
            this.tb_entrada_forma_pagamentoDataGridView.MultiSelect = false;
            this.tb_entrada_forma_pagamentoDataGridView.Name = "tb_entrada_forma_pagamentoDataGridView";
            this.tb_entrada_forma_pagamentoDataGridView.ReadOnly = true;
            this.tb_entrada_forma_pagamentoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_entrada_forma_pagamentoDataGridView.Size = new System.Drawing.Size(635, 145);
            this.tb_entrada_forma_pagamentoDataGridView.TabIndex = 24;
            this.tb_entrada_forma_pagamentoDataGridView.TabStop = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "codEntradaFormaPagamento";
            this.dataGridViewTextBoxColumn1.HeaderText = "codEntradaFormaPagamento";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "descricaoFormaPagamento";
            this.dataGridViewTextBoxColumn8.HeaderText = "Forma Pagamento";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "numeroDocumento";
            this.dataGridViewTextBoxColumn9.HeaderText = "Documento";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 87;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "descricaoConta";
            this.dataGridViewTextBoxColumn10.HeaderText = "Caixa / Conta";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "pagamentoDoFrete";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Frete";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Width = 37;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "data";
            this.dataGridViewTextBoxColumn7.HeaderText = "Data";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "valor";
            this.dataGridViewTextBoxColumn6.HeaderText = "Valor (R$)";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // totalRecebidoLabel
            // 
            this.totalRecebidoLabel.AutoSize = true;
            this.totalRecebidoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalRecebidoLabel.ForeColor = System.Drawing.Color.Red;
            this.totalRecebidoLabel.Location = new System.Drawing.Point(306, 408);
            this.totalRecebidoLabel.Name = "totalRecebidoLabel";
            this.totalRecebidoLabel.Size = new System.Drawing.Size(40, 20);
            this.totalRecebidoLabel.TabIndex = 80;
            this.totalRecebidoLabel.Text = "0,00";
            // 
            // btnEncerrar
            // 
            this.btnEncerrar.Location = new System.Drawing.Point(479, 409);
            this.btnEncerrar.Name = "btnEncerrar";
            this.btnEncerrar.Size = new System.Drawing.Size(81, 23);
            this.btnEncerrar.TabIndex = 28;
            this.btnEncerrar.Text = "F7 - Encerrar";
            this.btnEncerrar.UseVisualStyleBackColor = true;
            this.btnEncerrar.Click += new System.EventHandler(this.btnEncerrar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(392, 409);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 26;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(566, 409);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 30;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(92, 411);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 78;
            this.label5.Text = "DEL - Excluir";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(16, 411);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 77;
            this.label6.Text = "F12 - Navegar";
            // 
            // tb_forma_pagamentoTableAdapter
            // 
            this.tb_forma_pagamentoTableAdapter.ClearBeforeFill = true;
            // 
            // tb_conta_bancoTableAdapter
            // 
            this.tb_conta_bancoTableAdapter.ClearBeforeFill = true;
            // 
            // tb_documento_pagamentoTableAdapter
            // 
            this.tb_documento_pagamentoTableAdapter.ClearBeforeFill = true;
            // 
            // tb_entrada_forma_pagamentoTableAdapter
            // 
            this.tb_entrada_forma_pagamentoTableAdapter.ClearBeforeFill = true;
            // 
            // FrmEntradaPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 438);
            this.Controls.Add(this.totalRecebidoLabel);
            this.Controls.Add(label7);
            this.Controls.Add(this.btnEncerrar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_entrada_forma_pagamentoDataGridView);
            this.Controls.Add(this.pagamentoDoFreteCheckBox);
            this.Controls.Add(dataLabel);
            this.Controls.Add(this.dataDateTimePicker);
            this.Controls.Add(valorLabel);
            this.Controls.Add(this.valorTextBox);
            this.Controls.Add(codContaBancoLabel);
            this.Controls.Add(this.codContaBancoComboBox);
            this.Controls.Add(codDocumentoPagamentoLabel);
            this.Controls.Add(this.codDocumentoPagamentoComboBox);
            this.Controls.Add(codFormaPagamentoLabel);
            this.Controls.Add(this.codFormaPagamentoComboBox);
            this.Controls.Add(totalNotaLabel);
            this.Controls.Add(this.totalNotaTextBox);
            this.Controls.Add(codFornecedorLabel);
            this.Controls.Add(this.codFornecedorTextBox);
            this.Controls.Add(valorFreteLabel);
            this.Controls.Add(this.valorFreteTextBox);
            this.Controls.Add(codEmpresaFreteLabel);
            this.Controls.Add(this.codEmpresaFreteTextBox);
            this.Controls.Add(codEntradaLabel);
            this.Controls.Add(this.codEntradaTextBox);
            this.KeyPreview = true;
            this.Name = "FrmEntradaPagamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pagamentos da Entrada";
            this.Load += new System.EventHandler(this.FrmEntradaPagamento_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmEntradaPagamento_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entradaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entrada_forma_pagamentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbformapagamentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdocumentopagamentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcontabancoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entrada_forma_pagamentoDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource tb_entradaBindingSource;
        private System.Windows.Forms.TextBox codEntradaTextBox;
        private System.Windows.Forms.TextBox codEmpresaFreteTextBox;
        private System.Windows.Forms.TextBox valorFreteTextBox;
        private System.Windows.Forms.TextBox codFornecedorTextBox;
        private System.Windows.Forms.TextBox totalNotaTextBox;
        private System.Windows.Forms.BindingSource tb_entrada_forma_pagamentoBindingSource;
        private System.Windows.Forms.ComboBox codFormaPagamentoComboBox;
        private System.Windows.Forms.ComboBox codDocumentoPagamentoComboBox;
        private System.Windows.Forms.ComboBox codContaBancoComboBox;
        private System.Windows.Forms.TextBox valorTextBox;
        private System.Windows.Forms.DateTimePicker dataDateTimePicker;
        private System.Windows.Forms.CheckBox pagamentoDoFreteCheckBox;
        private System.Windows.Forms.DataGridView tb_entrada_forma_pagamentoDataGridView;
        private System.Windows.Forms.Label totalRecebidoLabel;
        private System.Windows.Forms.Button btnEncerrar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.BindingSource tbformapagamentoBindingSource;
        private System.Windows.Forms.BindingSource tbcontabancoBindingSource;
        private System.Windows.Forms.BindingSource tbdocumentopagamentoBindingSource;
    }
}