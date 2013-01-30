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
            System.Windows.Forms.Label intervaloDiasLabel;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label cpf_CnpjLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.saidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saidaPagamentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.totalPagarTextBox = new System.Windows.Forms.TextBox();
            this.valorRecebidoTextBox = new System.Windows.Forms.TextBox();
            this.parcelasTextBox = new System.Windows.Forms.TextBox();
            this.formaPagamentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.descontoTextBox = new System.Windows.Forms.TextBox();
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.codClienteComboBox = new System.Windows.Forms.ComboBox();
            this.clienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codProfissionalComboBox = new System.Windows.Forms.ComboBox();
            this.profissionalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.codSaidaTextBox = new System.Windows.Forms.TextBox();
            this.codContaBancoComboBox = new System.Windows.Forms.ComboBox();
            this.contaBancoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codFormaPagamentoComboBox = new System.Windows.Forms.ComboBox();
            this.codCartaoComboBox = new System.Windows.Forms.ComboBox();
            this.cartaoCreditoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_saida_forma_pagamentoDataGridView = new System.Windows.Forms.DataGridView();
            this.intervaloDiasTextBox = new System.Windows.Forms.TextBox();
            this.totalRecebidoLabel = new System.Windows.Forms.Label();
            this.descricaoTipoSaidaTextBox = new System.Windows.Forms.TextBox();
            this.cpf_CnpjTextBox = new System.Windows.Forms.TextBox();
            this.trocoTextBox = new System.Windows.Forms.TextBox();
            this.codSaidaPagamentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaoFormaPagamentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodContaBanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeCartaoCreditoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parcelas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            intervaloDiasLabel = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            cpf_CnpjLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.saidaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saidaPagamentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formaPagamentoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profissionalBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contaBancoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartaoCreditoBindingSource)).BeginInit();
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
            // saidaBindingSource
            // 
            this.saidaBindingSource.DataSource = typeof(Dominio.Saida);
            // 
            // saidaPagamentoBindingSource
            // 
            this.saidaPagamentoBindingSource.DataSource = typeof(Dominio.SaidaPagamento);
            // 
            // totalPagarTextBox
            // 
            this.totalPagarTextBox.BackColor = System.Drawing.Color.Blue;
            this.totalPagarTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.saidaBindingSource, "totalAVista", true));
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
            // parcelasTextBox
            // 
            this.parcelasTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.formaPagamentoBindingSource, "Parcelas", true));
            this.parcelasTextBox.Enabled = false;
            this.parcelasTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parcelasTextBox.Location = new System.Drawing.Point(643, 379);
            this.parcelasTextBox.Name = "parcelasTextBox";
            this.parcelasTextBox.Size = new System.Drawing.Size(83, 29);
            this.parcelasTextBox.TabIndex = 30;
            this.parcelasTextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.parcelasTextBox.Leave += new System.EventHandler(this.parcelasTextBox_Leave);
            // 
            // formaPagamentoBindingSource
            // 
            this.formaPagamentoBindingSource.DataSource = typeof(Dominio.FormaPagamento);
            // 
            // descontoTextBox
            // 
            this.descontoTextBox.BackColor = System.Drawing.Color.White;
            this.descontoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.saidaBindingSource, "desconto", true));
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
            this.totalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.saidaBindingSource, "total", true));
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
            this.codClienteComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.saidaBindingSource, "codCliente", true));
            this.codClienteComboBox.DataSource = this.clienteBindingSource;
            this.codClienteComboBox.DisplayMember = "NomeFantasia";
            this.codClienteComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codClienteComboBox.FormattingEnabled = true;
            this.codClienteComboBox.Location = new System.Drawing.Point(224, 98);
            this.codClienteComboBox.Name = "codClienteComboBox";
            this.codClienteComboBox.Size = new System.Drawing.Size(395, 32);
            this.codClienteComboBox.TabIndex = 16;
            this.codClienteComboBox.ValueMember = "CodPessoa";
            this.codClienteComboBox.SelectedIndexChanged += new System.EventHandler(this.codClienteComboBox_SelectedIndexChanged);
            this.codClienteComboBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.codClienteComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codTipoSaidaComboBox_KeyPress);
            this.codClienteComboBox.Leave += new System.EventHandler(this.codClienteComboBox_Leave);
            // 
            // clienteBindingSource
            // 
            this.clienteBindingSource.DataSource = typeof(Dominio.Pessoa);
            // 
            // codProfissionalComboBox
            // 
            this.codProfissionalComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codProfissionalComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codProfissionalComboBox.CausesValidation = false;
            this.codProfissionalComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.saidaBindingSource, "codProfissional", true));
            this.codProfissionalComboBox.DataSource = this.profissionalBindingSource;
            this.codProfissionalComboBox.DisplayMember = "NomeFantasia";
            this.codProfissionalComboBox.Enabled = false;
            this.codProfissionalComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codProfissionalComboBox.FormattingEnabled = true;
            this.codProfissionalComboBox.Location = new System.Drawing.Point(224, 165);
            this.codProfissionalComboBox.Name = "codProfissionalComboBox";
            this.codProfissionalComboBox.Size = new System.Drawing.Size(592, 32);
            this.codProfissionalComboBox.TabIndex = 18;
            this.codProfissionalComboBox.TabStop = false;
            this.codProfissionalComboBox.ValueMember = "CodPessoa";
            this.codProfissionalComboBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.codProfissionalComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codTipoSaidaComboBox_KeyPress);
            this.codProfissionalComboBox.Leave += new System.EventHandler(this.codProfissionalComboBox_Leave);
            // 
            // profissionalBindingSource
            // 
            this.profissionalBindingSource.DataSource = typeof(Dominio.Pessoa);
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
            this.codSaidaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.saidaBindingSource, "codSaida", true));
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
            // codContaBancoComboBox
            // 
            this.codContaBancoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codContaBancoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codContaBancoComboBox.CausesValidation = false;
            this.codContaBancoComboBox.DataSource = this.contaBancoBindingSource;
            this.codContaBancoComboBox.DisplayMember = "Descricao";
            this.codContaBancoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codContaBancoComboBox.Enabled = false;
            this.codContaBancoComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codContaBancoComboBox.FormattingEnabled = true;
            this.codContaBancoComboBox.Location = new System.Drawing.Point(223, 304);
            this.codContaBancoComboBox.Name = "codContaBancoComboBox";
            this.codContaBancoComboBox.Size = new System.Drawing.Size(396, 32);
            this.codContaBancoComboBox.TabIndex = 24;
            this.codContaBancoComboBox.ValueMember = "CodContaBanco";
            this.codContaBancoComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codTipoSaidaComboBox_KeyPress);
            this.codContaBancoComboBox.Leave += new System.EventHandler(this.codContaBancoComboBox_Leave);
            // 
            // contaBancoBindingSource
            // 
            this.contaBancoBindingSource.DataSource = typeof(Dominio.ContaBanco);
            // 
            // codFormaPagamentoComboBox
            // 
            this.codFormaPagamentoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codFormaPagamentoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codFormaPagamentoComboBox.CausesValidation = false;
            this.codFormaPagamentoComboBox.DataSource = this.formaPagamentoBindingSource;
            this.codFormaPagamentoComboBox.DisplayMember = "Descricao";
            this.codFormaPagamentoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codFormaPagamentoComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codFormaPagamentoComboBox.FormattingEnabled = true;
            this.codFormaPagamentoComboBox.Location = new System.Drawing.Point(224, 237);
            this.codFormaPagamentoComboBox.Name = "codFormaPagamentoComboBox";
            this.codFormaPagamentoComboBox.Size = new System.Drawing.Size(592, 32);
            this.codFormaPagamentoComboBox.TabIndex = 20;
            this.codFormaPagamentoComboBox.ValueMember = "CodFormaPagamento";
            this.codFormaPagamentoComboBox.SelectedIndexChanged += new System.EventHandler(this.codFormaPagamentoComboBox_SelectedIndexChanged);
            this.codFormaPagamentoComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codTipoSaidaComboBox_KeyPress);
            this.codFormaPagamentoComboBox.Leave += new System.EventHandler(this.codFormaPagamentoComboBox_Leave);
            // 
            // codCartaoComboBox
            // 
            this.codCartaoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codCartaoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codCartaoComboBox.DataSource = this.cartaoCreditoBindingSource;
            this.codCartaoComboBox.DisplayMember = "Nome";
            this.codCartaoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codCartaoComboBox.Enabled = false;
            this.codCartaoComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codCartaoComboBox.FormattingEnabled = true;
            this.codCartaoComboBox.Location = new System.Drawing.Point(225, 376);
            this.codCartaoComboBox.Name = "codCartaoComboBox";
            this.codCartaoComboBox.Size = new System.Drawing.Size(394, 32);
            this.codCartaoComboBox.TabIndex = 28;
            this.codCartaoComboBox.ValueMember = "CodCartao";
            this.codCartaoComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codTipoSaidaComboBox_KeyPress);
            this.codCartaoComboBox.Leave += new System.EventHandler(this.codCartaoComboBox_Leave);
            // 
            // cartaoCreditoBindingSource
            // 
            this.cartaoCreditoBindingSource.DataSource = typeof(Dominio.CartaoCredito);
            this.cartaoCreditoBindingSource.Sort = "nome";
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
            this.codSaidaPagamentoDataGridViewTextBoxColumn,
            this.descricaoFormaPagamentoDataGridViewTextBoxColumn,
            this.CodContaBanco,
            this.nomeCartaoCreditoDataGridViewTextBoxColumn,
            this.parcelas,
            this.valorDataGridViewTextBoxColumn});
            this.tb_saida_forma_pagamentoDataGridView.DataSource = this.saidaPagamentoBindingSource;
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
            // intervaloDiasTextBox
            // 
            this.intervaloDiasTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.saidaPagamentoBindingSource, "intervaloDias", true));
            this.intervaloDiasTextBox.Enabled = false;
            this.intervaloDiasTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intervaloDiasTextBox.Location = new System.Drawing.Point(749, 379);
            this.intervaloDiasTextBox.Name = "intervaloDiasTextBox";
            this.intervaloDiasTextBox.Size = new System.Drawing.Size(62, 29);
            this.intervaloDiasTextBox.TabIndex = 32;
            this.intervaloDiasTextBox.Enter += new System.EventHandler(this.codSaidaTextBox_Enter);
            this.intervaloDiasTextBox.Leave += new System.EventHandler(this.codSaidaTextBox_Leave);
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
            this.descricaoTipoSaidaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.saidaBindingSource, "descricaoTipoSaida", true));
            this.descricaoTipoSaidaTextBox.Enabled = false;
            this.descricaoTipoSaidaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.descricaoTipoSaidaTextBox.Location = new System.Drawing.Point(223, 34);
            this.descricaoTipoSaidaTextBox.Name = "descricaoTipoSaidaTextBox";
            this.descricaoTipoSaidaTextBox.Size = new System.Drawing.Size(396, 29);
            this.descricaoTipoSaidaTextBox.TabIndex = 12;
            // 
            // cpf_CnpjTextBox
            // 
            this.cpf_CnpjTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.clienteBindingSource, "CpfCnpj", true));
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
            this.trocoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.saidaBindingSource, "troco", true));
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
            // codSaidaPagamentoDataGridViewTextBoxColumn
            // 
            this.codSaidaPagamentoDataGridViewTextBoxColumn.DataPropertyName = "CodSaidaPagamento";
            this.codSaidaPagamentoDataGridViewTextBoxColumn.HeaderText = "CodSaidaPagamento";
            this.codSaidaPagamentoDataGridViewTextBoxColumn.Name = "codSaidaPagamentoDataGridViewTextBoxColumn";
            this.codSaidaPagamentoDataGridViewTextBoxColumn.ReadOnly = true;
            this.codSaidaPagamentoDataGridViewTextBoxColumn.Visible = false;
            // 
            // descricaoFormaPagamentoDataGridViewTextBoxColumn
            // 
            this.descricaoFormaPagamentoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricaoFormaPagamentoDataGridViewTextBoxColumn.DataPropertyName = "DescricaoFormaPagamento";
            this.descricaoFormaPagamentoDataGridViewTextBoxColumn.FillWeight = 40F;
            this.descricaoFormaPagamentoDataGridViewTextBoxColumn.HeaderText = "Forma Pagamento";
            this.descricaoFormaPagamentoDataGridViewTextBoxColumn.Name = "descricaoFormaPagamentoDataGridViewTextBoxColumn";
            this.descricaoFormaPagamentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // CodContaBanco
            // 
            this.CodContaBanco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CodContaBanco.DataPropertyName = "DescricaoContaBanco";
            this.CodContaBanco.FillWeight = 40F;
            this.CodContaBanco.HeaderText = "Caixa / Conta";
            this.CodContaBanco.Name = "CodContaBanco";
            this.CodContaBanco.ReadOnly = true;
            // 
            // nomeCartaoCreditoDataGridViewTextBoxColumn
            // 
            this.nomeCartaoCreditoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomeCartaoCreditoDataGridViewTextBoxColumn.DataPropertyName = "NomeCartaoCredito";
            this.nomeCartaoCreditoDataGridViewTextBoxColumn.FillWeight = 40F;
            this.nomeCartaoCreditoDataGridViewTextBoxColumn.HeaderText = "Cartao Credito";
            this.nomeCartaoCreditoDataGridViewTextBoxColumn.Name = "nomeCartaoCreditoDataGridViewTextBoxColumn";
            this.nomeCartaoCreditoDataGridViewTextBoxColumn.ReadOnly = true;
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
            // valorDataGridViewTextBoxColumn
            // 
            this.valorDataGridViewTextBoxColumn.DataPropertyName = "Valor";
            this.valorDataGridViewTextBoxColumn.HeaderText = "Valor";
            this.valorDataGridViewTextBoxColumn.Name = "valorDataGridViewTextBoxColumn";
            this.valorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FrmSaidaPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 607);
            this.Controls.Add(cpf_CnpjLabel);
            this.Controls.Add(this.cpf_CnpjTextBox);
            this.Controls.Add(this.descricaoTipoSaidaTextBox);
            this.Controls.Add(this.intervaloDiasTextBox);
            this.Controls.Add(this.codCartaoComboBox);
            this.Controls.Add(this.totalRecebidoLabel);
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
            ((System.ComponentModel.ISupportInitialize)(this.saidaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saidaPagamentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formaPagamentoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profissionalBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contaBancoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartaoCreditoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saida_forma_pagamentoDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource saidaBindingSource;
        private System.Windows.Forms.BindingSource formaPagamentoBindingSource;
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
        private System.Windows.Forms.BindingSource saidaPagamentoBindingSource;
        private System.Windows.Forms.TextBox codSaidaTextBox;
        private System.Windows.Forms.BindingSource contaBancoBindingSource;
        private System.Windows.Forms.ComboBox codContaBancoComboBox;
        private System.Windows.Forms.BindingSource clienteBindingSource;
        private System.Windows.Forms.BindingSource profissionalBindingSource;
        private System.Windows.Forms.ComboBox codFormaPagamentoComboBox;
        private System.Windows.Forms.ComboBox codCartaoComboBox;
        private System.Windows.Forms.BindingSource cartaoCreditoBindingSource;
        private System.Windows.Forms.DataGridView tb_saida_forma_pagamentoDataGridView;
        private System.Windows.Forms.TextBox intervaloDiasTextBox;
        private System.Windows.Forms.Label totalRecebidoLabel;
        private System.Windows.Forms.TextBox descricaoTipoSaidaTextBox;
        private System.Windows.Forms.TextBox cpf_CnpjTextBox;
        private System.Windows.Forms.TextBox trocoTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn codDocumentoPagamentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codSaidaPagamentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoFormaPagamentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodContaBanco;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeCartaoCreditoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn parcelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorDataGridViewTextBoxColumn;
    }
}