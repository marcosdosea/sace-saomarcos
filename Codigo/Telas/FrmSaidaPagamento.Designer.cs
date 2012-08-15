namespace Telas
{
    partial class FrmSaidaPagamento
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
            System.Windows.Forms.Label tipoSaidaLabel;
            System.Windows.Forms.Label descricaoLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label parcelasLabel;
            System.Windows.Forms.Label descontoAcrescimoLabel;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label codClienteLabel;
            System.Windows.Forms.Label codProfissionalLabel;
            System.Windows.Forms.Label codSaidaLabel;
            System.Windows.Forms.Label codContaBancoLabel;
            System.Windows.Forms.Label codCartaoLabel;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label codDocumentoPagamentoLabel;
            System.Windows.Forms.Label intervaloDiasLabel;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label cpf_CnpjLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tb_saidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saceDataSet = new Dados.saceDataSet();
            this.tb_forma_pagamentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_saida_pagamentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.totalPagarTextBox = new System.Windows.Forms.TextBox();
            this.valorRecebidoTextBox = new System.Windows.Forms.TextBox();
            this.tbdocumentopagamentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.parcelasTextBox = new System.Windows.Forms.TextBox();
            this.descontoTextBox = new System.Windows.Forms.TextBox();
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.codClienteComboBox = new System.Windows.Forms.ComboBox();
            this.tbpessoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codProfissionalComboBox = new System.Windows.Forms.ComboBox();
            this.tbpessoaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.codSaidaTextBox = new System.Windows.Forms.TextBox();
            this.tb_tipo_saidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_pessoaTableAdapter = new Dados.saceDataSetTableAdapters.tb_pessoaTableAdapter();
            this.tb_forma_pagamentoTableAdapter = new Dados.saceDataSetTableAdapters.tb_forma_pagamentoTableAdapter();
            this.tb_tipo_saidaTableAdapter = new Dados.saceDataSetTableAdapters.tb_tipo_saidaTableAdapter();
            this.tb_saida_forma_pagamentoTableAdapter = new Dados.saceDataSetTableAdapters.tb_saida_forma_pagamentoTableAdapter();
            this.tb_conta_bancoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codContaBancoComboBox = new System.Windows.Forms.ComboBox();
            this.codFormaPagamentoComboBox = new System.Windows.Forms.ComboBox();
            this.tb_conta_bancoTableAdapter = new Dados.saceDataSetTableAdapters.tb_conta_bancoTableAdapter();
            this.codCartaoComboBox = new System.Windows.Forms.ComboBox();
            this.tbcartaocreditoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_cartao_creditoTableAdapter = new Dados.saceDataSetTableAdapters.tb_cartao_creditoTableAdapter();
            this.tb_saidaTableAdapter = new Dados.saceDataSetTableAdapters.tb_saidaTableAdapter();
            this.codDocumentoPagamentoComboBox = new System.Windows.Forms.ComboBox();
            this.tb_documento_pagamentoTableAdapter = new Dados.saceDataSetTableAdapters.tb_documento_pagamentoTableAdapter();
            this.tb_saida_forma_pagamentoDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parcelas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaoContaBanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.intervaloDiasTextBox = new System.Windows.Forms.TextBox();
            this.faltaReceberTextBox = new System.Windows.Forms.TextBox();
            this.totalRecebidoLabel = new System.Windows.Forms.Label();
            this.descricaoTipoSaidaTextBox = new System.Windows.Forms.TextBox();
            this.cpf_CnpjTextBox = new System.Windows.Forms.TextBox();
            this.trocoTextBox = new System.Windows.Forms.TextBox();
            tipoSaidaLabel = new System.Windows.Forms.Label();
            descricaoLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            parcelasLabel = new System.Windows.Forms.Label();
            descontoAcrescimoLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            codClienteLabel = new System.Windows.Forms.Label();
            codProfissionalLabel = new System.Windows.Forms.Label();
            codSaidaLabel = new System.Windows.Forms.Label();
            codContaBancoLabel = new System.Windows.Forms.Label();
            codCartaoLabel = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            codDocumentoPagamentoLabel = new System.Windows.Forms.Label();
            intervaloDiasLabel = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            cpf_CnpjLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saidaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_forma_pagamentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saida_pagamentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdocumentopagamentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbpessoaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbpessoaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_tipo_saidaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_conta_bancoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcartaocreditoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saida_forma_pagamentoDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tipoSaidaLabel
            // 
            tipoSaidaLabel.AutoSize = true;
            tipoSaidaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tipoSaidaLabel.Location = new System.Drawing.Point(218, 6);
            tipoSaidaLabel.Name = "tipoSaidaLabel";
            tipoSaidaLabel.Size = new System.Drawing.Size(105, 24);
            tipoSaidaLabel.TabIndex = 12;
            tipoSaidaLabel.Text = "Tipo Saída:";
            // 
            // descricaoLabel
            // 
            descricaoLabel.AutoSize = true;
            descricaoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            descricaoLabel.Location = new System.Drawing.Point(218, 204);
            descricaoLabel.Name = "descricaoLabel";
            descricaoLabel.Size = new System.Drawing.Size(171, 24);
            descricaoLabel.TabIndex = 13;
            descricaoLabel.Text = "Forma Pagamento:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(8, 171);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(163, 29);
            label1.TabIndex = 15;
            label1.Text = "Total a Pagar:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(644, 275);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(146, 24);
            label2.TabIndex = 17;
            label2.Text = "Valor Recebido:";
            // 
            // parcelasLabel
            // 
            parcelasLabel.AutoSize = true;
            parcelasLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            parcelasLabel.Location = new System.Drawing.Point(639, 351);
            parcelasLabel.Name = "parcelasLabel";
            parcelasLabel.Size = new System.Drawing.Size(87, 24);
            parcelasLabel.TabIndex = 18;
            parcelasLabel.Text = "Parcelas:";
            // 
            // descontoAcrescimoLabel
            // 
            descontoAcrescimoLabel.AutoSize = true;
            descontoAcrescimoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            descontoAcrescimoLabel.Location = new System.Drawing.Point(6, 89);
            descontoAcrescimoLabel.Name = "descontoAcrescimoLabel";
            descontoAcrescimoLabel.Size = new System.Drawing.Size(187, 31);
            descontoAcrescimoLabel.TabIndex = 19;
            descontoAcrescimoLabel.Text = "Desconto (%):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(6, 3);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(83, 31);
            label3.TabIndex = 21;
            label3.Text = "Total:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(15, 333);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(83, 29);
            label4.TabIndex = 23;
            label4.Text = "Troco:";
            label4.Visible = false;
            // 
            // codClienteLabel
            // 
            codClienteLabel.AutoSize = true;
            codClienteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codClienteLabel.Location = new System.Drawing.Point(220, 70);
            codClienteLabel.Name = "codClienteLabel";
            codClienteLabel.Size = new System.Drawing.Size(73, 24);
            codClienteLabel.TabIndex = 24;
            codClienteLabel.Text = "Cliente:";
            // 
            // codProfissionalLabel
            // 
            codProfissionalLabel.AutoSize = true;
            codProfissionalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codProfissionalLabel.Location = new System.Drawing.Point(218, 137);
            codProfissionalLabel.Name = "codProfissionalLabel";
            codProfissionalLabel.Size = new System.Drawing.Size(110, 24);
            codProfissionalLabel.TabIndex = 25;
            codProfissionalLabel.Text = "Profissional:";
            // 
            // codSaidaLabel
            // 
            codSaidaLabel.AutoSize = true;
            codSaidaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codSaidaLabel.Location = new System.Drawing.Point(633, 7);
            codSaidaLabel.Name = "codSaidaLabel";
            codSaidaLabel.Size = new System.Drawing.Size(62, 24);
            codSaidaLabel.TabIndex = 65;
            codSaidaLabel.Text = "Saída:";
            // 
            // codContaBancoLabel
            // 
            codContaBancoLabel.AutoSize = true;
            codContaBancoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codContaBancoLabel.Location = new System.Drawing.Point(218, 275);
            codContaBancoLabel.Name = "codContaBancoLabel";
            codContaBancoLabel.Size = new System.Drawing.Size(126, 24);
            codContaBancoLabel.TabIndex = 66;
            codContaBancoLabel.Text = "Caixa / Conta:";
            // 
            // codCartaoLabel
            // 
            codCartaoLabel.AutoSize = true;
            codCartaoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codCartaoLabel.Location = new System.Drawing.Point(221, 348);
            codCartaoLabel.Name = "codCartaoLabel";
            codCartaoLabel.Size = new System.Drawing.Size(161, 24);
            codCartaoLabel.TabIndex = 67;
            codCartaoLabel.Text = "Cartão de Crédito:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            label8.Location = new System.Drawing.Point(8, 251);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(171, 29);
            label8.TabIndex = 71;
            label8.Text = "Falta Receber:";
            label8.Visible = false;
            // 
            // codDocumentoPagamentoLabel
            // 
            codDocumentoPagamentoLabel.AutoSize = true;
            codDocumentoPagamentoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codDocumentoPagamentoLabel.Location = new System.Drawing.Point(646, 204);
            codDocumentoPagamentoLabel.Name = "codDocumentoPagamentoLabel";
            codDocumentoPagamentoLabel.Size = new System.Drawing.Size(151, 24);
            codDocumentoPagamentoLabel.TabIndex = 74;
            codDocumentoPagamentoLabel.Text = "Cheque / Boleto:";
            // 
            // intervaloDiasLabel
            // 
            intervaloDiasLabel.AutoSize = true;
            intervaloDiasLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            intervaloDiasLabel.Location = new System.Drawing.Point(745, 351);
            intervaloDiasLabel.Name = "intervaloDiasLabel";
            intervaloDiasLabel.Size = new System.Drawing.Size(51, 24);
            intervaloDiasLabel.TabIndex = 74;
            intervaloDiasLabel.Text = "Dias:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label7.Location = new System.Drawing.Point(262, 561);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(120, 20);
            label7.TabIndex = 69;
            label7.Text = "Total Recebido:";
            // 
            // cpf_CnpjLabel
            // 
            cpf_CnpjLabel.AutoSize = true;
            cpf_CnpjLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            cpf_CnpjLabel.Location = new System.Drawing.Point(639, 70);
            cpf_CnpjLabel.Name = "cpf_CnpjLabel";
            cpf_CnpjLabel.Size = new System.Drawing.Size(106, 24);
            cpf_CnpjLabel.TabIndex = 75;
            cpf_CnpjLabel.Text = "CPF / Cnpj:";
            // 
            // tb_saidaBindingSource
            // 
            this.tb_saidaBindingSource.DataMember = "tb_saida";
            this.tb_saidaBindingSource.DataSource = this.saceDataSet;
            // 
            // saceDataSet
            // 
            this.saceDataSet.DataSetName = "saceDataSet";
            this.saceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tb_forma_pagamentoBindingSource
            // 
            this.tb_forma_pagamentoBindingSource.DataMember = "tb_forma_pagamento";
            this.tb_forma_pagamentoBindingSource.DataSource = this.saceDataSet;
            // 
            // tb_saida_pagamentoBindingSource
            // 
            this.tb_saida_pagamentoBindingSource.DataMember = "tb_saida_forma_pagamento";
            this.tb_saida_pagamentoBindingSource.DataSource = this.saceDataSet;
            // 
            // totalPagarTextBox
            // 
            this.totalPagarTextBox.BackColor = System.Drawing.Color.Blue;
            this.totalPagarTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "totalAVista", true));
            this.totalPagarTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F);
            this.totalPagarTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.totalPagarTextBox.Location = new System.Drawing.Point(12, 201);
            this.totalPagarTextBox.Name = "totalPagarTextBox";
            this.totalPagarTextBox.Size = new System.Drawing.Size(189, 48);
            this.totalPagarTextBox.TabIndex = 6;
            this.totalPagarTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.totalPagarTextBox.Leave += new System.EventHandler(this.totalPagarTextBox_Leave);
            // 
            // valorRecebidoTextBox
            // 
            this.valorRecebidoTextBox.BackColor = System.Drawing.Color.White;
            this.valorRecebidoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbdocumentopagamentoBindingSource, "valor", true));
            this.valorRecebidoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.valorRecebidoTextBox.ForeColor = System.Drawing.Color.Red;
            this.valorRecebidoTextBox.Location = new System.Drawing.Point(643, 304);
            this.valorRecebidoTextBox.Name = "valorRecebidoTextBox";
            this.valorRecebidoTextBox.Size = new System.Drawing.Size(173, 45);
            this.valorRecebidoTextBox.TabIndex = 26;
            this.valorRecebidoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.valorRecebidoTextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.valorRecebidoTextBox.Leave += new System.EventHandler(this.valorRecebidoTextBox_Leave);
            // 
            // tbdocumentopagamentoBindingSource
            // 
            this.tbdocumentopagamentoBindingSource.DataMember = "tb_documento_pagamento";
            this.tbdocumentopagamentoBindingSource.DataSource = this.saceDataSet;
            // 
            // parcelasTextBox
            // 
            this.parcelasTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_forma_pagamentoBindingSource, "parcelas", true));
            this.parcelasTextBox.Enabled = false;
            this.parcelasTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parcelasTextBox.Location = new System.Drawing.Point(643, 379);
            this.parcelasTextBox.Name = "parcelasTextBox";
            this.parcelasTextBox.Size = new System.Drawing.Size(83, 29);
            this.parcelasTextBox.TabIndex = 30;
            this.parcelasTextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.parcelasTextBox.Leave += new System.EventHandler(this.parcelasTextBox_Leave);
            // 
            // descontoTextBox
            // 
            this.descontoTextBox.BackColor = System.Drawing.Color.White;
            this.descontoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "desconto", true));
            this.descontoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F);
            this.descontoTextBox.ForeColor = System.Drawing.Color.Red;
            this.descontoTextBox.Location = new System.Drawing.Point(12, 125);
            this.descontoTextBox.Name = "descontoTextBox";
            this.descontoTextBox.Size = new System.Drawing.Size(185, 48);
            this.descontoTextBox.TabIndex = 4;
            this.descontoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.descontoTextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.descontoTextBox.Leave += new System.EventHandler(this.descontoTextBox_Leave);
            // 
            // totalTextBox
            // 
            this.totalTextBox.BackColor = System.Drawing.Color.Blue;
            this.totalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "total", true));
            this.totalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F);
            this.totalTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.totalTextBox.Location = new System.Drawing.Point(12, 39);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.Size = new System.Drawing.Size(185, 48);
            this.totalTextBox.TabIndex = 2;
            this.totalTextBox.TabStop = false;
            this.totalTextBox.Text = "999.999,99";
            this.totalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.totalTextBox.Leave += new System.EventHandler(this.totalPagarTextBox_Leave);
            // 
            // codClienteComboBox
            // 
            this.codClienteComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codClienteComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codClienteComboBox.CausesValidation = false;
            this.codClienteComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "nomeCliente", true));
            this.codClienteComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_saidaBindingSource, "codCliente", true));
            this.codClienteComboBox.DataSource = this.tbpessoaBindingSource;
            this.codClienteComboBox.DisplayMember = "nome";
            this.codClienteComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codClienteComboBox.FormattingEnabled = true;
            this.codClienteComboBox.Location = new System.Drawing.Point(224, 98);
            this.codClienteComboBox.Name = "codClienteComboBox";
            this.codClienteComboBox.Size = new System.Drawing.Size(395, 32);
            this.codClienteComboBox.TabIndex = 16;
            this.codClienteComboBox.ValueMember = "codPessoa";
            this.codClienteComboBox.SelectedIndexChanged += new System.EventHandler(this.codClienteComboBox_SelectedIndexChanged);
            this.codClienteComboBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.codClienteComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codTipoSaidaComboBox_KeyPress);
            this.codClienteComboBox.Leave += new System.EventHandler(this.codClienteComboBox_Leave);
            // 
            // tbpessoaBindingSource
            // 
            this.tbpessoaBindingSource.DataMember = "tb_pessoa";
            this.tbpessoaBindingSource.DataSource = this.saceDataSet;
            // 
            // codProfissionalComboBox
            // 
            this.codProfissionalComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codProfissionalComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codProfissionalComboBox.CausesValidation = false;
            this.codProfissionalComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_saidaBindingSource, "codProfissional", true));
            this.codProfissionalComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "nomeProfissional", true));
            this.codProfissionalComboBox.DataSource = this.tbpessoaBindingSource1;
            this.codProfissionalComboBox.DisplayMember = "nome";
            this.codProfissionalComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codProfissionalComboBox.FormattingEnabled = true;
            this.codProfissionalComboBox.Location = new System.Drawing.Point(224, 165);
            this.codProfissionalComboBox.Name = "codProfissionalComboBox";
            this.codProfissionalComboBox.Size = new System.Drawing.Size(592, 32);
            this.codProfissionalComboBox.TabIndex = 18;
            this.codProfissionalComboBox.ValueMember = "codPessoa";
            this.codProfissionalComboBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.codProfissionalComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codTipoSaidaComboBox_KeyPress);
            this.codProfissionalComboBox.Leave += new System.EventHandler(this.codProfissionalComboBox_Leave);
            // 
            // tbpessoaBindingSource1
            // 
            this.tbpessoaBindingSource1.DataMember = "tb_pessoa";
            this.tbpessoaBindingSource1.DataSource = this.saceDataSet;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(99, 563);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 65;
            this.label5.Text = "DEL - Excluir";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(23, 563);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 64;
            this.label6.Text = "F12 - Navegar";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(642, 564);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 33;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(728, 564);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 36;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // codSaidaTextBox
            // 
            this.codSaidaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "codSaida", true));
            this.codSaidaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codSaidaTextBox.Location = new System.Drawing.Point(637, 34);
            this.codSaidaTextBox.Name = "codSaidaTextBox";
            this.codSaidaTextBox.ReadOnly = true;
            this.codSaidaTextBox.Size = new System.Drawing.Size(179, 29);
            this.codSaidaTextBox.TabIndex = 14;
            this.codSaidaTextBox.TabStop = false;
            this.codSaidaTextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.codSaidaTextBox.Leave += new System.EventHandler(this.codSaidaTextBox_Leave);
            // 
            // tb_tipo_saidaBindingSource
            // 
            this.tb_tipo_saidaBindingSource.AllowNew = false;
            this.tb_tipo_saidaBindingSource.DataMember = "tb_tipo_saida";
            this.tb_tipo_saidaBindingSource.DataSource = this.saceDataSet;
            // 
            // tb_pessoaTableAdapter
            // 
            this.tb_pessoaTableAdapter.ClearBeforeFill = true;
            // 
            // tb_forma_pagamentoTableAdapter
            // 
            this.tb_forma_pagamentoTableAdapter.ClearBeforeFill = true;
            // 
            // tb_tipo_saidaTableAdapter
            // 
            this.tb_tipo_saidaTableAdapter.ClearBeforeFill = true;
            // 
            // tb_saida_forma_pagamentoTableAdapter
            // 
            this.tb_saida_forma_pagamentoTableAdapter.ClearBeforeFill = true;
            // 
            // tb_conta_bancoBindingSource
            // 
            this.tb_conta_bancoBindingSource.DataMember = "tb_conta_banco";
            this.tb_conta_bancoBindingSource.DataSource = this.saceDataSet;
            // 
            // codContaBancoComboBox
            // 
            this.codContaBancoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codContaBancoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codContaBancoComboBox.CausesValidation = false;
            this.codContaBancoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_conta_bancoBindingSource, "codContaBanco", true));
            this.codContaBancoComboBox.DataSource = this.tb_conta_bancoBindingSource;
            this.codContaBancoComboBox.DisplayMember = "descricao";
            this.codContaBancoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codContaBancoComboBox.Enabled = false;
            this.codContaBancoComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codContaBancoComboBox.FormattingEnabled = true;
            this.codContaBancoComboBox.Location = new System.Drawing.Point(223, 304);
            this.codContaBancoComboBox.Name = "codContaBancoComboBox";
            this.codContaBancoComboBox.Size = new System.Drawing.Size(396, 32);
            this.codContaBancoComboBox.TabIndex = 24;
            this.codContaBancoComboBox.ValueMember = "codContaBanco";
            this.codContaBancoComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codTipoSaidaComboBox_KeyPress);
            this.codContaBancoComboBox.Leave += new System.EventHandler(this.codContaBancoComboBox_Leave);
            // 
            // codFormaPagamentoComboBox
            // 
            this.codFormaPagamentoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codFormaPagamentoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codFormaPagamentoComboBox.CausesValidation = false;
            this.codFormaPagamentoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_forma_pagamentoBindingSource, "descricao", true));
            this.codFormaPagamentoComboBox.DataSource = this.tb_forma_pagamentoBindingSource;
            this.codFormaPagamentoComboBox.DisplayMember = "descricao";
            this.codFormaPagamentoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codFormaPagamentoComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codFormaPagamentoComboBox.FormattingEnabled = true;
            this.codFormaPagamentoComboBox.Location = new System.Drawing.Point(224, 237);
            this.codFormaPagamentoComboBox.Name = "codFormaPagamentoComboBox";
            this.codFormaPagamentoComboBox.Size = new System.Drawing.Size(395, 32);
            this.codFormaPagamentoComboBox.TabIndex = 20;
            this.codFormaPagamentoComboBox.ValueMember = "codFormaPagamento";
            this.codFormaPagamentoComboBox.SelectedIndexChanged += new System.EventHandler(this.codFormaPagamentoComboBox_SelectedIndexChanged);
            this.codFormaPagamentoComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codTipoSaidaComboBox_KeyPress);
            this.codFormaPagamentoComboBox.Leave += new System.EventHandler(this.codFormaPagamentoComboBox_Leave);
            // 
            // tb_conta_bancoTableAdapter
            // 
            this.tb_conta_bancoTableAdapter.ClearBeforeFill = true;
            // 
            // codCartaoComboBox
            // 
            this.codCartaoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codCartaoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codCartaoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbcartaocreditoBindingSource, "nome", true));
            this.codCartaoComboBox.DataSource = this.tbcartaocreditoBindingSource;
            this.codCartaoComboBox.DisplayMember = "nome";
            this.codCartaoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codCartaoComboBox.Enabled = false;
            this.codCartaoComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codCartaoComboBox.FormattingEnabled = true;
            this.codCartaoComboBox.Location = new System.Drawing.Point(225, 376);
            this.codCartaoComboBox.Name = "codCartaoComboBox";
            this.codCartaoComboBox.Size = new System.Drawing.Size(394, 32);
            this.codCartaoComboBox.TabIndex = 28;
            this.codCartaoComboBox.ValueMember = "codCartao";
            this.codCartaoComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codTipoSaidaComboBox_KeyPress);
            this.codCartaoComboBox.Leave += new System.EventHandler(this.codCartaoComboBox_Leave);
            // 
            // tbcartaocreditoBindingSource
            // 
            this.tbcartaocreditoBindingSource.DataMember = "tb_cartao_credito";
            this.tbcartaocreditoBindingSource.DataSource = this.saceDataSet;
            this.tbcartaocreditoBindingSource.Sort = "nome";
            // 
            // tb_cartao_creditoTableAdapter
            // 
            this.tb_cartao_creditoTableAdapter.ClearBeforeFill = true;
            // 
            // tb_saidaTableAdapter
            // 
            this.tb_saidaTableAdapter.ClearBeforeFill = true;
            // 
            // codDocumentoPagamentoComboBox
            // 
            this.codDocumentoPagamentoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codDocumentoPagamentoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codDocumentoPagamentoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_saida_pagamentoBindingSource, "codDocumentoPagamento", true));
            this.codDocumentoPagamentoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saida_pagamentoBindingSource, "codDocumentoPagamento", true));
            this.codDocumentoPagamentoComboBox.DataSource = this.tbdocumentopagamentoBindingSource;
            this.codDocumentoPagamentoComboBox.DisplayMember = "codDocumentoPagamento";
            this.codDocumentoPagamentoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codDocumentoPagamentoComboBox.Enabled = false;
            this.codDocumentoPagamentoComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codDocumentoPagamentoComboBox.FormattingEnabled = true;
            this.codDocumentoPagamentoComboBox.Location = new System.Drawing.Point(643, 237);
            this.codDocumentoPagamentoComboBox.Name = "codDocumentoPagamentoComboBox";
            this.codDocumentoPagamentoComboBox.Size = new System.Drawing.Size(173, 32);
            this.codDocumentoPagamentoComboBox.TabIndex = 22;
            this.codDocumentoPagamentoComboBox.ValueMember = "codDocumentoPagamento";
            this.codDocumentoPagamentoComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codTipoSaidaComboBox_KeyPress);
            this.codDocumentoPagamentoComboBox.Leave += new System.EventHandler(this.codDocumentoPagamentoComboBox_Leave);
            // 
            // tb_documento_pagamentoTableAdapter
            // 
            this.tb_documento_pagamentoTableAdapter.ClearBeforeFill = true;
            // 
            // tb_saida_forma_pagamentoDataGridView
            // 
            this.tb_saida_forma_pagamentoDataGridView.AllowUserToAddRows = false;
            this.tb_saida_forma_pagamentoDataGridView.AllowUserToDeleteRows = false;
            this.tb_saida_forma_pagamentoDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tb_saida_forma_pagamentoDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tb_saida_forma_pagamentoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_saida_forma_pagamentoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn8,
            this.numeroDocumento,
            this.dataGridViewTextBoxColumn10,
            this.parcelas,
            this.descricaoContaBanco,
            this.dataGridViewTextBoxColumn6});
            this.tb_saida_forma_pagamentoDataGridView.DataSource = this.tb_saida_pagamentoBindingSource;
            this.tb_saida_forma_pagamentoDataGridView.Location = new System.Drawing.Point(20, 420);
            this.tb_saida_forma_pagamentoDataGridView.MultiSelect = false;
            this.tb_saida_forma_pagamentoDataGridView.Name = "tb_saida_forma_pagamentoDataGridView";
            this.tb_saida_forma_pagamentoDataGridView.ReadOnly = true;
            this.tb_saida_forma_pagamentoDataGridView.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_saida_forma_pagamentoDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tb_saida_forma_pagamentoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_saida_forma_pagamentoDataGridView.Size = new System.Drawing.Size(792, 138);
            this.tb_saida_forma_pagamentoDataGridView.TabIndex = 68;
            this.tb_saida_forma_pagamentoDataGridView.TabStop = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "codSaidaFormaPagamento";
            this.dataGridViewTextBoxColumn1.HeaderText = "codSaidaFormaPagamento";
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
            // numeroDocumento
            // 
            this.numeroDocumento.DataPropertyName = "numeroDocumento";
            this.numeroDocumento.HeaderText = "Cheque/Boleto";
            this.numeroDocumento.Name = "numeroDocumento";
            this.numeroDocumento.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "nomeCartaoCredito";
            this.dataGridViewTextBoxColumn10.HeaderText = "Cartao Crédito";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // parcelas
            // 
            this.parcelas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.parcelas.DataPropertyName = "parcelas";
            this.parcelas.HeaderText = "Parcelas";
            this.parcelas.Name = "parcelas";
            this.parcelas.ReadOnly = true;
            this.parcelas.Width = 80;
            // 
            // descricaoContaBanco
            // 
            this.descricaoContaBanco.DataPropertyName = "descricaoContaBanco";
            this.descricaoContaBanco.HeaderText = "Conta";
            this.descricaoContaBanco.Name = "descricaoContaBanco";
            this.descricaoContaBanco.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "valor";
            this.dataGridViewTextBoxColumn6.HeaderText = "Valor (R$)";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // intervaloDiasTextBox
            // 
            this.intervaloDiasTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saida_pagamentoBindingSource, "intervaloDias", true));
            this.intervaloDiasTextBox.Enabled = false;
            this.intervaloDiasTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intervaloDiasTextBox.Location = new System.Drawing.Point(749, 379);
            this.intervaloDiasTextBox.Name = "intervaloDiasTextBox";
            this.intervaloDiasTextBox.Size = new System.Drawing.Size(62, 29);
            this.intervaloDiasTextBox.TabIndex = 32;
            this.intervaloDiasTextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.intervaloDiasTextBox.Leave += new System.EventHandler(this.codSaidaTextBox_Leave);
            // 
            // faltaReceberTextBox
            // 
            this.faltaReceberTextBox.BackColor = System.Drawing.Color.White;
            this.faltaReceberTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "totalAVista", true));
            this.faltaReceberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F);
            this.faltaReceberTextBox.ForeColor = System.Drawing.Color.Black;
            this.faltaReceberTextBox.Location = new System.Drawing.Point(13, 282);
            this.faltaReceberTextBox.Name = "faltaReceberTextBox";
            this.faltaReceberTextBox.Size = new System.Drawing.Size(189, 48);
            this.faltaReceberTextBox.TabIndex = 75;
            this.faltaReceberTextBox.TabStop = false;
            this.faltaReceberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.faltaReceberTextBox.Visible = false;
            this.faltaReceberTextBox.TextChanged += new System.EventHandler(this.faltaReceberTextBox_TextChanged);
            this.faltaReceberTextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.faltaReceberTextBox.Leave += new System.EventHandler(this.codSaidaTextBox_Leave);
            // 
            // totalRecebidoLabel
            // 
            this.totalRecebidoLabel.AutoSize = true;
            this.totalRecebidoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalRecebidoLabel.ForeColor = System.Drawing.Color.Red;
            this.totalRecebidoLabel.Location = new System.Drawing.Point(380, 561);
            this.totalRecebidoLabel.Name = "totalRecebidoLabel";
            this.totalRecebidoLabel.Size = new System.Drawing.Size(40, 20);
            this.totalRecebidoLabel.TabIndex = 73;
            this.totalRecebidoLabel.Text = "0,00";
            // 
            // descricaoTipoSaidaTextBox
            // 
            this.descricaoTipoSaidaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "descricaoTipoSaida", true));
            this.descricaoTipoSaidaTextBox.Enabled = false;
            this.descricaoTipoSaidaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.descricaoTipoSaidaTextBox.Location = new System.Drawing.Point(223, 34);
            this.descricaoTipoSaidaTextBox.Name = "descricaoTipoSaidaTextBox";
            this.descricaoTipoSaidaTextBox.Size = new System.Drawing.Size(396, 29);
            this.descricaoTipoSaidaTextBox.TabIndex = 12;
            // 
            // cpf_CnpjTextBox
            // 
            this.cpf_CnpjTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tbpessoaBindingSource, "cpf_Cnpj", true));
            this.cpf_CnpjTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.cpf_CnpjTextBox.Location = new System.Drawing.Point(637, 101);
            this.cpf_CnpjTextBox.MaxLength = 14;
            this.cpf_CnpjTextBox.Name = "cpf_CnpjTextBox";
            this.cpf_CnpjTextBox.Size = new System.Drawing.Size(179, 29);
            this.cpf_CnpjTextBox.TabIndex = 17;
            this.cpf_CnpjTextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.cpf_CnpjTextBox.Leave += new System.EventHandler(this.codSaidaTextBox_Leave);
            // 
            // trocoTextBox
            // 
            this.trocoTextBox.BackColor = System.Drawing.Color.White;
            this.trocoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "troco", true));
            this.trocoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 27F);
            this.trocoTextBox.ForeColor = System.Drawing.Color.Black;
            this.trocoTextBox.Location = new System.Drawing.Point(13, 364);
            this.trocoTextBox.Name = "trocoTextBox";
            this.trocoTextBox.Size = new System.Drawing.Size(189, 48);
            this.trocoTextBox.TabIndex = 10;
            this.trocoTextBox.TabStop = false;
            this.trocoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.trocoTextBox.Visible = false;
            // 
            // FrmSaidaPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 607);
            this.Controls.Add(cpf_CnpjLabel);
            this.Controls.Add(this.cpf_CnpjTextBox);
            this.Controls.Add(this.descricaoTipoSaidaTextBox);
            this.Controls.Add(this.faltaReceberTextBox);
            this.Controls.Add(this.intervaloDiasTextBox);
            this.Controls.Add(this.codCartaoComboBox);
            this.Controls.Add(this.codDocumentoPagamentoComboBox);
            this.Controls.Add(codDocumentoPagamentoLabel);
            this.Controls.Add(this.totalRecebidoLabel);
            this.Controls.Add(label8);
            this.Controls.Add(label7);
            this.Controls.Add(this.tb_saida_forma_pagamentoDataGridView);
            this.Controls.Add(this.codFormaPagamentoComboBox);
            this.Controls.Add(this.codContaBancoComboBox);
            this.Controls.Add(codContaBancoLabel);
            this.Controls.Add(codSaidaLabel);
            this.Controls.Add(this.codSaidaTextBox);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(codProfissionalLabel);
            this.Controls.Add(this.codProfissionalComboBox);
            this.Controls.Add(codClienteLabel);
            this.Controls.Add(this.codClienteComboBox);
            this.Controls.Add(this.trocoTextBox);
            this.Controls.Add(this.totalTextBox);
            this.Controls.Add(this.descontoTextBox);
            this.Controls.Add(this.parcelasTextBox);
            this.Controls.Add(label2);
            this.Controls.Add(this.valorRecebidoTextBox);
            this.Controls.Add(this.totalPagarTextBox);
            this.Controls.Add(descricaoLabel);
            this.Controls.Add(tipoSaidaLabel);
            this.Controls.Add(codCartaoLabel);
            this.Controls.Add(label4);
            this.Controls.Add(descontoAcrescimoLabel);
            this.Controls.Add(label3);
            this.Controls.Add(label1);
            this.Controls.Add(parcelasLabel);
            this.Controls.Add(intervaloDiasLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmSaidaPagamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagamento";
            this.Load += new System.EventHandler(this.FrmSaidaPagamento_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSaidaPagamento_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tb_saidaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_forma_pagamentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saida_pagamentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbdocumentopagamentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbpessoaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbpessoaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_tipo_saidaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_conta_bancoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcartaocreditoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saida_forma_pagamentoDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Dados.saceDataSet saceDataSet;
        private System.Windows.Forms.BindingSource tb_saidaBindingSource;
        private System.Windows.Forms.BindingSource tb_forma_pagamentoBindingSource;
        private System.Windows.Forms.TextBox totalPagarTextBox;
        private System.Windows.Forms.TextBox valorRecebidoTextBox;
        private System.Windows.Forms.TextBox parcelasTextBox;
        private System.Windows.Forms.TextBox descontoTextBox;
        private System.Windows.Forms.TextBox totalTextBox;
        private System.Windows.Forms.ComboBox codClienteComboBox;
        private System.Windows.Forms.ComboBox codProfissionalComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.BindingSource tb_saida_pagamentoBindingSource;
        private System.Windows.Forms.TextBox codSaidaTextBox;
        private System.Windows.Forms.BindingSource tb_tipo_saidaBindingSource;
        private Dados.saceDataSetTableAdapters.tb_pessoaTableAdapter tb_pessoaTableAdapter;
        private Dados.saceDataSetTableAdapters.tb_forma_pagamentoTableAdapter tb_forma_pagamentoTableAdapter;
        private Dados.saceDataSetTableAdapters.tb_tipo_saidaTableAdapter tb_tipo_saidaTableAdapter;
        private Dados.saceDataSetTableAdapters.tb_saida_forma_pagamentoTableAdapter tb_saida_forma_pagamentoTableAdapter;
        private System.Windows.Forms.BindingSource tb_conta_bancoBindingSource;
        private System.Windows.Forms.ComboBox codContaBancoComboBox;
        private System.Windows.Forms.BindingSource tbpessoaBindingSource;
        private System.Windows.Forms.BindingSource tbpessoaBindingSource1;
        private System.Windows.Forms.ComboBox codFormaPagamentoComboBox;
        private Dados.saceDataSetTableAdapters.tb_conta_bancoTableAdapter tb_conta_bancoTableAdapter;
        private System.Windows.Forms.ComboBox codCartaoComboBox;
        private System.Windows.Forms.BindingSource tbcartaocreditoBindingSource;
        private Dados.saceDataSetTableAdapters.tb_cartao_creditoTableAdapter tb_cartao_creditoTableAdapter;
        private Dados.saceDataSetTableAdapters.tb_saidaTableAdapter tb_saidaTableAdapter;
        private System.Windows.Forms.ComboBox codDocumentoPagamentoComboBox;
        private System.Windows.Forms.BindingSource tbdocumentopagamentoBindingSource;
        private Dados.saceDataSetTableAdapters.tb_documento_pagamentoTableAdapter tb_documento_pagamentoTableAdapter;
        private System.Windows.Forms.DataGridView tb_saida_forma_pagamentoDataGridView;
        private System.Windows.Forms.TextBox intervaloDiasTextBox;
        private System.Windows.Forms.TextBox faltaReceberTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn parcelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoContaBanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Label totalRecebidoLabel;
        private System.Windows.Forms.TextBox descricaoTipoSaidaTextBox;
        private System.Windows.Forms.TextBox cpf_CnpjTextBox;
        private System.Windows.Forms.TextBox trocoTextBox;
    }
}