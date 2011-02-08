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
            this.tb_saidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saceDataSet = new Dados.saceDataSet();
            this.tb_forma_pagamentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_saida_pagamentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.totalPagarTextBox = new System.Windows.Forms.TextBox();
            this.valorPagoTextBox = new System.Windows.Forms.TextBox();
            this.parcelasTextBox = new System.Windows.Forms.TextBox();
            this.descontoTextBox = new System.Windows.Forms.TextBox();
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.trocoTextBox = new System.Windows.Forms.TextBox();
            this.codClienteComboBox = new System.Windows.Forms.ComboBox();
            this.tbpessoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codProfissionalComboBox = new System.Windows.Forms.ComboBox();
            this.tbpessoaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.codSaidaTextBox = new System.Windows.Forms.TextBox();
            this.tb_saida_pagamentoDataGridView = new System.Windows.Forms.DataGridView();
            this.tb_tipo_saidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codTipoSaidaComboBox = new System.Windows.Forms.ComboBox();
            this.tb_pessoaTableAdapter = new Dados.saceDataSetTableAdapters.tb_pessoaTableAdapter();
            this.tb_forma_pagamentoTableAdapter = new Dados.saceDataSetTableAdapters.tb_forma_pagamentoTableAdapter();
            this.tb_tipo_saidaTableAdapter = new Dados.saceDataSetTableAdapters.tb_tipo_saidaTableAdapter();
            this.tb_saida_pagamentoTableAdapter = new Dados.saceDataSetTableAdapters.tb_saida_pagamentoTableAdapter();
            this.tb_conta_bancoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codContaBancoComboBox = new System.Windows.Forms.ComboBox();
            this.codFormaPagamentoComboBox = new System.Windows.Forms.ComboBox();
            this.tb_conta_bancoTableAdapter = new Dados.saceDataSetTableAdapters.tb_conta_bancoTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.tb_saidaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_forma_pagamentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saida_pagamentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbpessoaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbpessoaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saida_pagamentoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_tipo_saidaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_conta_bancoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tipoSaidaLabel
            // 
            tipoSaidaLabel.AutoSize = true;
            tipoSaidaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tipoSaidaLabel.Location = new System.Drawing.Point(12, 8);
            tipoSaidaLabel.Name = "tipoSaidaLabel";
            tipoSaidaLabel.Size = new System.Drawing.Size(105, 24);
            tipoSaidaLabel.TabIndex = 12;
            tipoSaidaLabel.Text = "Tipo Saída:";
            // 
            // descricaoLabel
            // 
            descricaoLabel.AutoSize = true;
            descricaoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            descricaoLabel.Location = new System.Drawing.Point(203, 201);
            descricaoLabel.Name = "descricaoLabel";
            descricaoLabel.Size = new System.Drawing.Size(245, 31);
            descricaoLabel.TabIndex = 13;
            descricaoLabel.Text = "Forma Pagamento:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.Location = new System.Drawing.Point(15, 284);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(163, 29);
            label1.TabIndex = 15;
            label1.Text = "Total a Pagar:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label2.Location = new System.Drawing.Point(20, 371);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(138, 29);
            label2.TabIndex = 17;
            label2.Text = "Valor Pago:";
            // 
            // parcelasLabel
            // 
            parcelasLabel.AutoSize = true;
            parcelasLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            parcelasLabel.Location = new System.Drawing.Point(590, 201);
            parcelasLabel.Name = "parcelasLabel";
            parcelasLabel.Size = new System.Drawing.Size(128, 31);
            parcelasLabel.TabIndex = 18;
            parcelasLabel.Text = "Parcelas:";
            // 
            // descontoAcrescimoLabel
            // 
            descontoAcrescimoLabel.AutoSize = true;
            descontoAcrescimoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            descontoAcrescimoLabel.Location = new System.Drawing.Point(502, 201);
            descontoAcrescimoLabel.Name = "descontoAcrescimoLabel";
            descontoAcrescimoLabel.Size = new System.Drawing.Size(85, 31);
            descontoAcrescimoLabel.TabIndex = 19;
            descontoAcrescimoLabel.Text = "Desc:";
            descontoAcrescimoLabel.Click += new System.EventHandler(this.descontoAcrescimoLabel_Click);
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(14, 197);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(83, 31);
            label3.TabIndex = 21;
            label3.Text = "Total:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label4.Location = new System.Drawing.Point(20, 451);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(83, 29);
            label4.TabIndex = 23;
            label4.Text = "Troco:";
            // 
            // codClienteLabel
            // 
            codClienteLabel.AutoSize = true;
            codClienteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codClienteLabel.Location = new System.Drawing.Point(16, 71);
            codClienteLabel.Name = "codClienteLabel";
            codClienteLabel.Size = new System.Drawing.Size(73, 24);
            codClienteLabel.TabIndex = 24;
            codClienteLabel.Text = "Cliente:";
            // 
            // codProfissionalLabel
            // 
            codProfissionalLabel.AutoSize = true;
            codProfissionalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codProfissionalLabel.Location = new System.Drawing.Point(16, 136);
            codProfissionalLabel.Name = "codProfissionalLabel";
            codProfissionalLabel.Size = new System.Drawing.Size(110, 24);
            codProfissionalLabel.TabIndex = 25;
            codProfissionalLabel.Text = "Profissional:";
            // 
            // codSaidaLabel
            // 
            codSaidaLabel.AutoSize = true;
            codSaidaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codSaidaLabel.Location = new System.Drawing.Point(619, 8);
            codSaidaLabel.Name = "codSaidaLabel";
            codSaidaLabel.Size = new System.Drawing.Size(62, 24);
            codSaidaLabel.TabIndex = 65;
            codSaidaLabel.Text = "Saída:";
            // 
            // codContaBancoLabel
            // 
            codContaBancoLabel.AutoSize = true;
            codContaBancoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codContaBancoLabel.Location = new System.Drawing.Point(203, 278);
            codContaBancoLabel.Name = "codContaBancoLabel";
            codContaBancoLabel.Size = new System.Drawing.Size(186, 31);
            codContaBancoLabel.TabIndex = 66;
            codContaBancoLabel.Text = "Caixa / Conta:";
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
            this.tb_saida_pagamentoBindingSource.DataMember = "tb_saida_pagamento";
            this.tb_saida_pagamentoBindingSource.DataSource = this.saceDataSet;
            // 
            // totalPagarTextBox
            // 
            this.totalPagarTextBox.BackColor = System.Drawing.Color.Blue;
            this.totalPagarTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "total", true));
            this.totalPagarTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPagarTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.totalPagarTextBox.Location = new System.Drawing.Point(20, 316);
            this.totalPagarTextBox.Name = "totalPagarTextBox";
            this.totalPagarTextBox.Size = new System.Drawing.Size(178, 45);
            this.totalPagarTextBox.TabIndex = 18;
            this.totalPagarTextBox.TabStop = false;
            this.totalPagarTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // valorPagoTextBox
            // 
            this.valorPagoTextBox.BackColor = System.Drawing.Color.Blue;
            this.valorPagoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "total", true));
            this.valorPagoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valorPagoTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.valorPagoTextBox.Location = new System.Drawing.Point(25, 403);
            this.valorPagoTextBox.Name = "valorPagoTextBox";
            this.valorPagoTextBox.Size = new System.Drawing.Size(173, 45);
            this.valorPagoTextBox.TabIndex = 22;
            this.valorPagoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.valorPagoTextBox.Leave += new System.EventHandler(this.valorPagoTextBox_Leave);
            // 
            // parcelasTextBox
            // 
            this.parcelasTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_forma_pagamentoBindingSource, "parcelas", true));
            this.parcelasTextBox.Enabled = false;
            this.parcelasTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parcelasTextBox.Location = new System.Drawing.Point(596, 239);
            this.parcelasTextBox.Name = "parcelasTextBox";
            this.parcelasTextBox.Size = new System.Drawing.Size(122, 38);
            this.parcelasTextBox.TabIndex = 16;
            this.parcelasTextBox.TabStop = false;
            // 
            // descontoTextBox
            // 
            this.descontoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_forma_pagamentoBindingSource, "descontoAcrescimo", true));
            this.descontoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descontoTextBox.Location = new System.Drawing.Point(508, 238);
            this.descontoTextBox.Name = "descontoTextBox";
            this.descontoTextBox.Size = new System.Drawing.Size(68, 38);
            this.descontoTextBox.TabIndex = 14;
            this.descontoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.descontoTextBox.Leave += new System.EventHandler(this.descontoTextBox_Leave);
            // 
            // totalTextBox
            // 
            this.totalTextBox.BackColor = System.Drawing.Color.Blue;
            this.totalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "total", true));
            this.totalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.totalTextBox.Location = new System.Drawing.Point(20, 232);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.Size = new System.Drawing.Size(178, 45);
            this.totalTextBox.TabIndex = 10;
            this.totalTextBox.TabStop = false;
            this.totalTextBox.Text = "999.999,99";
            this.totalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // trocoTextBox
            // 
            this.trocoTextBox.BackColor = System.Drawing.Color.Blue;
            this.trocoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "total", true));
            this.trocoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trocoTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.trocoTextBox.Location = new System.Drawing.Point(25, 483);
            this.trocoTextBox.Name = "trocoTextBox";
            this.trocoTextBox.Size = new System.Drawing.Size(173, 45);
            this.trocoTextBox.TabIndex = 24;
            this.trocoTextBox.TabStop = false;
            this.trocoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // codClienteComboBox
            // 
            this.codClienteComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codClienteComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codClienteComboBox.CausesValidation = false;
            this.codClienteComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_saidaBindingSource, "codCliente", true));
            this.codClienteComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "nomeCliente", true));
            this.codClienteComboBox.DataSource = this.tbpessoaBindingSource;
            this.codClienteComboBox.DisplayMember = "nome";
            this.codClienteComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codClienteComboBox.FormattingEnabled = true;
            this.codClienteComboBox.Location = new System.Drawing.Point(18, 98);
            this.codClienteComboBox.Name = "codClienteComboBox";
            this.codClienteComboBox.Size = new System.Drawing.Size(700, 32);
            this.codClienteComboBox.TabIndex = 6;
            this.codClienteComboBox.ValueMember = "codPessoa";
            this.codClienteComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codTipoSaidaComboBox_KeyPress);
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
            this.codProfissionalComboBox.Location = new System.Drawing.Point(20, 165);
            this.codProfissionalComboBox.Name = "codProfissionalComboBox";
            this.codProfissionalComboBox.Size = new System.Drawing.Size(698, 32);
            this.codProfissionalComboBox.TabIndex = 8;
            this.codProfissionalComboBox.ValueMember = "codPessoa";
            this.codProfissionalComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codTipoSaidaComboBox_KeyPress);
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
            this.label5.Location = new System.Drawing.Point(295, 362);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 13);
            this.label5.TabIndex = 65;
            this.label5.Text = "DEL - Excluir";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(214, 362);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 64;
            this.label6.Text = "F12 - Navegar";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(553, 534);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 28;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(640, 534);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 30;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // codSaidaTextBox
            // 
            this.codSaidaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "codSaida", true));
            this.codSaidaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codSaidaTextBox.Location = new System.Drawing.Point(623, 37);
            this.codSaidaTextBox.Name = "codSaidaTextBox";
            this.codSaidaTextBox.ReadOnly = true;
            this.codSaidaTextBox.Size = new System.Drawing.Size(89, 29);
            this.codSaidaTextBox.TabIndex = 4;
            this.codSaidaTextBox.TabStop = false;
            this.codSaidaTextBox.TextChanged += new System.EventHandler(this.codSaidaTextBox_TextChanged);
            // 
            // tb_saida_pagamentoDataGridView
            // 
            this.tb_saida_pagamentoDataGridView.AllowUserToAddRows = false;
            this.tb_saida_pagamentoDataGridView.AllowUserToDeleteRows = false;
            this.tb_saida_pagamentoDataGridView.AutoGenerateColumns = false;
            this.tb_saida_pagamentoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_saida_pagamentoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn4});
            this.tb_saida_pagamentoDataGridView.DataSource = this.tb_saida_pagamentoBindingSource;
            this.tb_saida_pagamentoDataGridView.Location = new System.Drawing.Point(209, 380);
            this.tb_saida_pagamentoDataGridView.Name = "tb_saida_pagamentoDataGridView";
            this.tb_saida_pagamentoDataGridView.ReadOnly = true;
            this.tb_saida_pagamentoDataGridView.Size = new System.Drawing.Size(515, 148);
            this.tb_saida_pagamentoDataGridView.TabIndex = 26;
            this.tb_saida_pagamentoDataGridView.TabStop = false;
            // 
            // tb_tipo_saidaBindingSource
            // 
            this.tb_tipo_saidaBindingSource.AllowNew = false;
            this.tb_tipo_saidaBindingSource.DataMember = "tb_tipo_saida";
            this.tb_tipo_saidaBindingSource.DataSource = this.saceDataSet;
            // 
            // codTipoSaidaComboBox
            // 
            this.codTipoSaidaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codTipoSaidaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codTipoSaidaComboBox.CausesValidation = false;
            this.codTipoSaidaComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_tipo_saidaBindingSource, "codTipoSaida", true));
            this.codTipoSaidaComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_saidaBindingSource, "tipoSaida", true));
            this.codTipoSaidaComboBox.DataSource = this.tb_tipo_saidaBindingSource;
            this.codTipoSaidaComboBox.DisplayMember = "descricaoTipoSaida";
            this.codTipoSaidaComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codTipoSaidaComboBox.FormattingEnabled = true;
            this.codTipoSaidaComboBox.Location = new System.Drawing.Point(18, 34);
            this.codTipoSaidaComboBox.Name = "codTipoSaidaComboBox";
            this.codTipoSaidaComboBox.Size = new System.Drawing.Size(586, 32);
            this.codTipoSaidaComboBox.TabIndex = 2;
            this.codTipoSaidaComboBox.ValueMember = "codTipoSaida";
            this.codTipoSaidaComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codTipoSaidaComboBox_KeyPress);
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
            // tb_saida_pagamentoTableAdapter
            // 
            this.tb_saida_pagamentoTableAdapter.ClearBeforeFill = true;
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
            this.codContaBancoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_saida_pagamentoBindingSource, "codContaBanco", true));
            this.codContaBancoComboBox.DataSource = this.tb_conta_bancoBindingSource;
            this.codContaBancoComboBox.DisplayMember = "descricao";
            this.codContaBancoComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codContaBancoComboBox.FormattingEnabled = true;
            this.codContaBancoComboBox.Location = new System.Drawing.Point(209, 311);
            this.codContaBancoComboBox.Name = "codContaBancoComboBox";
            this.codContaBancoComboBox.Size = new System.Drawing.Size(515, 39);
            this.codContaBancoComboBox.TabIndex = 20;
            this.codContaBancoComboBox.TabStop = false;
            this.codContaBancoComboBox.ValueMember = "codContaBanco";
            this.codContaBancoComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codTipoSaidaComboBox_KeyPress);
            // 
            // codFormaPagamentoComboBox
            // 
            this.codFormaPagamentoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codFormaPagamentoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codFormaPagamentoComboBox.CausesValidation = false;
            this.codFormaPagamentoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_forma_pagamentoBindingSource, "codFormaPagamento", true));
            this.codFormaPagamentoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_saida_pagamentoBindingSource, "codFormaPagamento", true));
            this.codFormaPagamentoComboBox.DataSource = this.tb_forma_pagamentoBindingSource;
            this.codFormaPagamentoComboBox.DisplayMember = "descricao";
            this.codFormaPagamentoComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codFormaPagamentoComboBox.FormattingEnabled = true;
            this.codFormaPagamentoComboBox.Location = new System.Drawing.Point(209, 237);
            this.codFormaPagamentoComboBox.Name = "codFormaPagamentoComboBox";
            this.codFormaPagamentoComboBox.Size = new System.Drawing.Size(289, 39);
            this.codFormaPagamentoComboBox.TabIndex = 12;
            this.codFormaPagamentoComboBox.ValueMember = "codFormaPagamento";
            this.codFormaPagamentoComboBox.SelectedIndexChanged += new System.EventHandler(this.codFormaPagamentoComboBox_SelectedIndexChanged);
            this.codFormaPagamentoComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codTipoSaidaComboBox_KeyPress);
            // 
            // tb_conta_bancoTableAdapter
            // 
            this.tb_conta_bancoTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "codSaidaPagamento";
            this.dataGridViewTextBoxColumn1.HeaderText = "codSaidaPagamento";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "codSaida";
            this.dataGridViewTextBoxColumn2.HeaderText = "codSaida";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "codFormaPagamento";
            this.dataGridViewTextBoxColumn3.HeaderText = "codFormaPagamento";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "descricaoFormaPagamento";
            this.dataGridViewTextBoxColumn7.HeaderText = "Forma Pagamento";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "descricaoConta";
            this.dataGridViewTextBoxColumn8.HeaderText = "Conta";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "data";
            this.dataGridViewTextBoxColumn6.HeaderText = "Data";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "valor";
            this.dataGridViewTextBoxColumn5.HeaderText = "Valor";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "codContaBanco";
            this.dataGridViewTextBoxColumn4.HeaderText = "codContaBanco";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // FrmSaidaPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 559);
            this.Controls.Add(this.codFormaPagamentoComboBox);
            this.Controls.Add(this.codContaBancoComboBox);
            this.Controls.Add(codContaBancoLabel);
            this.Controls.Add(this.codTipoSaidaComboBox);
            this.Controls.Add(this.tb_saida_pagamentoDataGridView);
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
            this.Controls.Add(label4);
            this.Controls.Add(this.trocoTextBox);
            this.Controls.Add(label3);
            this.Controls.Add(this.totalTextBox);
            this.Controls.Add(descontoAcrescimoLabel);
            this.Controls.Add(this.descontoTextBox);
            this.Controls.Add(parcelasLabel);
            this.Controls.Add(this.parcelasTextBox);
            this.Controls.Add(label2);
            this.Controls.Add(this.valorPagoTextBox);
            this.Controls.Add(label1);
            this.Controls.Add(this.totalPagarTextBox);
            this.Controls.Add(descricaoLabel);
            this.Controls.Add(tipoSaidaLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmSaidaPagamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSaidaPagamento";
            this.Load += new System.EventHandler(this.FrmSaidaPagamento_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSaidaPagamento_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tb_saidaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_forma_pagamentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saida_pagamentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbpessoaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbpessoaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saida_pagamentoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_tipo_saidaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_conta_bancoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Dados.saceDataSet saceDataSet;
        private System.Windows.Forms.BindingSource tb_saidaBindingSource;
        private System.Windows.Forms.BindingSource tb_forma_pagamentoBindingSource;
        private System.Windows.Forms.TextBox totalPagarTextBox;
        private System.Windows.Forms.TextBox valorPagoTextBox;
        private System.Windows.Forms.TextBox parcelasTextBox;
        private System.Windows.Forms.TextBox descontoTextBox;
        private System.Windows.Forms.TextBox totalTextBox;
        private System.Windows.Forms.TextBox trocoTextBox;
        private System.Windows.Forms.ComboBox codClienteComboBox;
        private System.Windows.Forms.ComboBox codProfissionalComboBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.BindingSource tb_saida_pagamentoBindingSource;
        private System.Windows.Forms.TextBox codSaidaTextBox;
        private System.Windows.Forms.DataGridView tb_saida_pagamentoDataGridView;
        private System.Windows.Forms.BindingSource tb_tipo_saidaBindingSource;
        private System.Windows.Forms.ComboBox codTipoSaidaComboBox;
        private Dados.saceDataSetTableAdapters.tb_pessoaTableAdapter tb_pessoaTableAdapter;
        private Dados.saceDataSetTableAdapters.tb_forma_pagamentoTableAdapter tb_forma_pagamentoTableAdapter;
        private Dados.saceDataSetTableAdapters.tb_tipo_saidaTableAdapter tb_tipo_saidaTableAdapter;
        private Dados.saceDataSetTableAdapters.tb_saida_pagamentoTableAdapter tb_saida_pagamentoTableAdapter;
        private System.Windows.Forms.BindingSource tb_conta_bancoBindingSource;
        private System.Windows.Forms.ComboBox codContaBancoComboBox;
        private System.Windows.Forms.BindingSource tbpessoaBindingSource;
        private System.Windows.Forms.BindingSource tbpessoaBindingSource1;
        private System.Windows.Forms.ComboBox codFormaPagamentoComboBox;
        private Dados.saceDataSetTableAdapters.tb_conta_bancoTableAdapter tb_conta_bancoTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}