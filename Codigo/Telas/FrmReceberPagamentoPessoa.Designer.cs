namespace Telas
 {
     partial class FrmReceberPagamentoPessoa
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
            System.Windows.Forms.Label codClienteLabel;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.codClienteComboBox = new System.Windows.Forms.ComboBox();
            this.pessoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.quitadaCheckBox = new System.Windows.Forms.CheckBox();
            this.abertaCheckBox = new System.Windows.Forms.CheckBox();
            this.dataInicioDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataFinalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.contasPessoaDataGridView = new System.Windows.Forms.DataGridView();
            this.codContaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codSaidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormatoConta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataVencimentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaoSituacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorPagar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contasPessoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.movimentacaoContaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_movimentacao_contaDataGridView = new System.Windows.Forms.DataGridView();
            this.codMovimentacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataHoraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.totalContasTextBox = new System.Windows.Forms.TextBox();
            this.totalPagamentosTextBox = new System.Windows.Forms.TextBox();
            this.faltaReceberTextBox = new System.Windows.Forms.TextBox();
            this.descontoTextBox = new System.Windows.Forms.TextBox();
            this.totalAVistaTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.valorRecebidoTextBox = new System.Windows.Forms.TextBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCFNfe = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            codClienteLabel = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pessoaBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contasPessoaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contasPessoaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.movimentacaoContaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_movimentacao_contaDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // codClienteLabel
            // 
            codClienteLabel.AutoSize = true;
            codClienteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codClienteLabel.Location = new System.Drawing.Point(3, 72);
            codClienteLabel.Name = "codClienteLabel";
            codClienteLabel.Size = new System.Drawing.Size(73, 24);
            codClienteLabel.TabIndex = 26;
            codClienteLabel.Text = "Cliente:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            label9.Location = new System.Drawing.Point(325, 499);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(124, 18);
            label9.TabIndex = 44;
            label9.Text = "Desc/Acresc (%):";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            label12.Location = new System.Drawing.Point(897, 550);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(108, 18);
            label12.TabIndex = 50;
            label12.Text = "Recebido (R$):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Receber Pagamentos";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1171, 41);
            this.panel1.TabIndex = 20;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(83, 582);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 56;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(343, 582);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 62;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(8, 582);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "F3 - Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // codClienteComboBox
            // 
            this.codClienteComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codClienteComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codClienteComboBox.CausesValidation = false;
            this.codClienteComboBox.DataSource = this.pessoaBindingSource;
            this.codClienteComboBox.DisplayMember = "NomeFantasia";
            this.codClienteComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.codClienteComboBox.FormattingEnabled = true;
            this.codClienteComboBox.Location = new System.Drawing.Point(7, 104);
            this.codClienteComboBox.Name = "codClienteComboBox";
            this.codClienteComboBox.Size = new System.Drawing.Size(883, 33);
            this.codClienteComboBox.TabIndex = 25;
            this.codClienteComboBox.ValueMember = "codPessoa";
            this.codClienteComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codClienteComboBox_KeyPress);
            this.codClienteComboBox.Leave += new System.EventHandler(this.codClienteComboBox_Leave);
            // 
            // pessoaBindingSource
            // 
            this.pessoaBindingSource.AllowNew = false;
            this.pessoaBindingSource.DataSource = typeof(Dominio.Pessoa);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.quitadaCheckBox);
            this.groupBox2.Controls.Add(this.abertaCheckBox);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox2.Location = new System.Drawing.Point(1038, 46);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(118, 91);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Situação Conta";
            // 
            // quitadaCheckBox
            // 
            this.quitadaCheckBox.AutoSize = true;
            this.quitadaCheckBox.Location = new System.Drawing.Point(20, 59);
            this.quitadaCheckBox.Name = "quitadaCheckBox";
            this.quitadaCheckBox.Size = new System.Drawing.Size(77, 21);
            this.quitadaCheckBox.TabIndex = 1;
            this.quitadaCheckBox.Text = "Quitada";
            this.quitadaCheckBox.UseVisualStyleBackColor = true;
            this.quitadaCheckBox.CheckedChanged += new System.EventHandler(this.dataInicioDateTimePicker_Leave);
            // 
            // abertaCheckBox
            // 
            this.abertaCheckBox.AutoSize = true;
            this.abertaCheckBox.Checked = true;
            this.abertaCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.abertaCheckBox.Location = new System.Drawing.Point(20, 29);
            this.abertaCheckBox.Name = "abertaCheckBox";
            this.abertaCheckBox.Size = new System.Drawing.Size(69, 21);
            this.abertaCheckBox.TabIndex = 0;
            this.abertaCheckBox.Text = "Aberta";
            this.abertaCheckBox.UseVisualStyleBackColor = true;
            this.abertaCheckBox.CheckedChanged += new System.EventHandler(this.dataInicioDateTimePicker_Leave);
            // 
            // dataInicioDateTimePicker
            // 
            this.dataInicioDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dataInicioDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataInicioDateTimePicker.Location = new System.Drawing.Point(909, 65);
            this.dataInicioDateTimePicker.Name = "dataInicioDateTimePicker";
            this.dataInicioDateTimePicker.Size = new System.Drawing.Size(117, 24);
            this.dataInicioDateTimePicker.TabIndex = 27;
            this.dataInicioDateTimePicker.Leave += new System.EventHandler(this.dataInicioDateTimePicker_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(906, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 18);
            this.label2.TabIndex = 30;
            this.label2.Text = "Data Início";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(906, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 18);
            this.label3.TabIndex = 32;
            this.label3.Text = "Data Final:";
            // 
            // dataFinalDateTimePicker
            // 
            this.dataFinalDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dataFinalDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataFinalDateTimePicker.Location = new System.Drawing.Point(909, 113);
            this.dataFinalDateTimePicker.Name = "dataFinalDateTimePicker";
            this.dataFinalDateTimePicker.Size = new System.Drawing.Size(117, 24);
            this.dataFinalDateTimePicker.TabIndex = 29;
            this.dataFinalDateTimePicker.Leave += new System.EventHandler(this.dataInicioDateTimePicker_Leave);
            // 
            // contasPessoaDataGridView
            // 
            this.contasPessoaDataGridView.AllowUserToAddRows = false;
            this.contasPessoaDataGridView.AllowUserToDeleteRows = false;
            this.contasPessoaDataGridView.AutoGenerateColumns = false;
            this.contasPessoaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contasPessoaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codContaDataGridViewTextBoxColumn,
            this.codSaidaDataGridViewTextBoxColumn,
            this.FormatoConta,
            this.dataVencimentoDataGridViewTextBoxColumn,
            this.CF,
            this.NumeroDocumento,
            this.descricaoSituacaoDataGridViewTextBoxColumn,
            this.valorDataGridViewTextBoxColumn,
            this.desconto,
            this.valorPagar});
            this.contasPessoaDataGridView.DataSource = this.contasPessoaBindingSource;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.contasPessoaDataGridView.DefaultCellStyle = dataGridViewCellStyle12;
            this.contasPessoaDataGridView.Location = new System.Drawing.Point(7, 176);
            this.contasPessoaDataGridView.Name = "contasPessoaDataGridView";
            this.contasPessoaDataGridView.ReadOnly = true;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.contasPessoaDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.contasPessoaDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle14;
            this.contasPessoaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.contasPessoaDataGridView.Size = new System.Drawing.Size(883, 303);
            this.contasPessoaDataGridView.StandardTab = true;
            this.contasPessoaDataGridView.TabIndex = 32;
            this.contasPessoaDataGridView.TabStop = false;
            this.contasPessoaDataGridView.SelectionChanged += new System.EventHandler(this.ContasPessoaDataGridView_SelectionChanged);
            // 
            // codContaDataGridViewTextBoxColumn
            // 
            this.codContaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.codContaDataGridViewTextBoxColumn.DataPropertyName = "CodConta";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codContaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.codContaDataGridViewTextBoxColumn.FillWeight = 60F;
            this.codContaDataGridViewTextBoxColumn.HeaderText = "Conta";
            this.codContaDataGridViewTextBoxColumn.Name = "codContaDataGridViewTextBoxColumn";
            this.codContaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codSaidaDataGridViewTextBoxColumn
            // 
            this.codSaidaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.codSaidaDataGridViewTextBoxColumn.DataPropertyName = "CodSaida";
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codSaidaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.codSaidaDataGridViewTextBoxColumn.FillWeight = 60F;
            this.codSaidaDataGridViewTextBoxColumn.HeaderText = "Pré-Venda";
            this.codSaidaDataGridViewTextBoxColumn.Name = "codSaidaDataGridViewTextBoxColumn";
            this.codSaidaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FormatoConta
            // 
            this.FormatoConta.DataPropertyName = "FormatoConta";
            this.FormatoConta.HeaderText = "Formato";
            this.FormatoConta.Name = "FormatoConta";
            this.FormatoConta.ReadOnly = true;
            // 
            // dataVencimentoDataGridViewTextBoxColumn
            // 
            this.dataVencimentoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataVencimentoDataGridViewTextBoxColumn.DataPropertyName = "DataVencimento";
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataVencimentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataVencimentoDataGridViewTextBoxColumn.FillWeight = 70F;
            this.dataVencimentoDataGridViewTextBoxColumn.HeaderText = "Vencimento";
            this.dataVencimentoDataGridViewTextBoxColumn.Name = "dataVencimentoDataGridViewTextBoxColumn";
            this.dataVencimentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // CF
            // 
            this.CF.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CF.DataPropertyName = "CF";
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CF.DefaultCellStyle = dataGridViewCellStyle11;
            this.CF.FillWeight = 60F;
            this.CF.HeaderText = "CF";
            this.CF.MinimumWidth = 60;
            this.CF.Name = "CF";
            this.CF.ReadOnly = true;
            // 
            // NumeroDocumento
            // 
            this.NumeroDocumento.DataPropertyName = "NumeroDocumento";
            this.NumeroDocumento.HeaderText = "Dcto";
            this.NumeroDocumento.Name = "NumeroDocumento";
            this.NumeroDocumento.ReadOnly = true;
            // 
            // descricaoSituacaoDataGridViewTextBoxColumn
            // 
            this.descricaoSituacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricaoSituacaoDataGridViewTextBoxColumn.DataPropertyName = "DescricaoSituacao";
            this.descricaoSituacaoDataGridViewTextBoxColumn.FillWeight = 70F;
            this.descricaoSituacaoDataGridViewTextBoxColumn.HeaderText = "Situação";
            this.descricaoSituacaoDataGridViewTextBoxColumn.Name = "descricaoSituacaoDataGridViewTextBoxColumn";
            this.descricaoSituacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorDataGridViewTextBoxColumn
            // 
            this.valorDataGridViewTextBoxColumn.DataPropertyName = "Valor";
            this.valorDataGridViewTextBoxColumn.HeaderText = "Total (R$)";
            this.valorDataGridViewTextBoxColumn.Name = "valorDataGridViewTextBoxColumn";
            this.valorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desconto
            // 
            this.desconto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.desconto.DataPropertyName = "Desconto";
            this.desconto.FillWeight = 70F;
            this.desconto.HeaderText = "Descto (R$)";
            this.desconto.Name = "desconto";
            this.desconto.ReadOnly = true;
            // 
            // valorPagar
            // 
            this.valorPagar.DataPropertyName = "ValorPagar";
            this.valorPagar.HeaderText = "À Vista (R$)";
            this.valorPagar.Name = "valorPagar";
            this.valorPagar.ReadOnly = true;
            // 
            // contasPessoaBindingSource
            // 
            this.contasPessoaBindingSource.DataSource = typeof(Dominio.Conta);
            // 
            // movimentacaoContaBindingSource
            // 
            this.movimentacaoContaBindingSource.DataSource = typeof(Dominio.MovimentacaoConta);
            // 
            // tb_movimentacao_contaDataGridView
            // 
            this.tb_movimentacao_contaDataGridView.AllowUserToAddRows = false;
            this.tb_movimentacao_contaDataGridView.AllowUserToDeleteRows = false;
            this.tb_movimentacao_contaDataGridView.AutoGenerateColumns = false;
            this.tb_movimentacao_contaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_movimentacao_contaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codMovimentacaoDataGridViewTextBoxColumn,
            this.dataHoraDataGridViewTextBoxColumn,
            this.valorDataGridViewTextBoxColumn1});
            this.tb_movimentacao_contaDataGridView.DataSource = this.movimentacaoContaBindingSource;
            this.tb_movimentacao_contaDataGridView.Location = new System.Drawing.Point(912, 176);
            this.tb_movimentacao_contaDataGridView.Name = "tb_movimentacao_contaDataGridView";
            this.tb_movimentacao_contaDataGridView.ReadOnly = true;
            this.tb_movimentacao_contaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_movimentacao_contaDataGridView.Size = new System.Drawing.Size(244, 303);
            this.tb_movimentacao_contaDataGridView.TabIndex = 34;
            this.tb_movimentacao_contaDataGridView.TabStop = false;
            // 
            // codMovimentacaoDataGridViewTextBoxColumn
            // 
            this.codMovimentacaoDataGridViewTextBoxColumn.DataPropertyName = "CodMovimentacao";
            this.codMovimentacaoDataGridViewTextBoxColumn.HeaderText = "CodMovimentacao";
            this.codMovimentacaoDataGridViewTextBoxColumn.Name = "codMovimentacaoDataGridViewTextBoxColumn";
            this.codMovimentacaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.codMovimentacaoDataGridViewTextBoxColumn.Visible = false;
            // 
            // dataHoraDataGridViewTextBoxColumn
            // 
            this.dataHoraDataGridViewTextBoxColumn.DataPropertyName = "DataHora";
            this.dataHoraDataGridViewTextBoxColumn.HeaderText = "Data";
            this.dataHoraDataGridViewTextBoxColumn.Name = "dataHoraDataGridViewTextBoxColumn";
            this.dataHoraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorDataGridViewTextBoxColumn1
            // 
            this.valorDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.valorDataGridViewTextBoxColumn1.DataPropertyName = "Valor";
            this.valorDataGridViewTextBoxColumn1.HeaderText = "Valor (R$)";
            this.valorDataGridViewTextBoxColumn1.Name = "valorDataGridViewTextBoxColumn1";
            this.valorDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label4.Location = new System.Drawing.Point(4, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 18);
            this.label4.TabIndex = 33;
            this.label4.Text = "Contas:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label5.Location = new System.Drawing.Point(909, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 18);
            this.label5.TabIndex = 34;
            this.label5.Text = "Pagamentos:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label7.Location = new System.Drawing.Point(12, 503);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 18);
            this.label7.TabIndex = 36;
            this.label7.Text = "Total Contas (R$):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label6.Location = new System.Drawing.Point(913, 497);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 18);
            this.label6.TabIndex = 37;
            this.label6.Text = "Total Pago:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label8.Location = new System.Drawing.Point(537, 556);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(137, 18);
            this.label8.TabIndex = 38;
            this.label8.Text = "Falta Receber (R$):";
            // 
            // totalContasTextBox
            // 
            this.totalContasTextBox.BackColor = System.Drawing.Color.Blue;
            this.totalContasTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.totalContasTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.totalContasTextBox.Location = new System.Drawing.Point(148, 491);
            this.totalContasTextBox.Name = "totalContasTextBox";
            this.totalContasTextBox.ReadOnly = true;
            this.totalContasTextBox.Size = new System.Drawing.Size(157, 32);
            this.totalContasTextBox.TabIndex = 36;
            this.totalContasTextBox.TabStop = false;
            this.totalContasTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // totalPagamentosTextBox
            // 
            this.totalPagamentosTextBox.BackColor = System.Drawing.Color.Blue;
            this.totalPagamentosTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.totalPagamentosTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.totalPagamentosTextBox.Location = new System.Drawing.Point(1014, 489);
            this.totalPagamentosTextBox.Name = "totalPagamentosTextBox";
            this.totalPagamentosTextBox.ReadOnly = true;
            this.totalPagamentosTextBox.Size = new System.Drawing.Size(142, 32);
            this.totalPagamentosTextBox.TabIndex = 40;
            this.totalPagamentosTextBox.TabStop = false;
            this.totalPagamentosTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // faltaReceberTextBox
            // 
            this.faltaReceberTextBox.BackColor = System.Drawing.Color.Blue;
            this.faltaReceberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.faltaReceberTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.faltaReceberTextBox.Location = new System.Drawing.Point(690, 542);
            this.faltaReceberTextBox.Name = "faltaReceberTextBox";
            this.faltaReceberTextBox.ReadOnly = true;
            this.faltaReceberTextBox.Size = new System.Drawing.Size(189, 32);
            this.faltaReceberTextBox.TabIndex = 42;
            this.faltaReceberTextBox.TabStop = false;
            this.faltaReceberTextBox.Leave += new System.EventHandler(this.faltaReceberTextBox_Leave);
            // 
            // descontoTextBox
            // 
            this.descontoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.descontoTextBox.Location = new System.Drawing.Point(455, 491);
            this.descontoTextBox.Name = "descontoTextBox";
            this.descontoTextBox.Size = new System.Drawing.Size(77, 32);
            this.descontoTextBox.TabIndex = 44;
            this.descontoTextBox.Leave += new System.EventHandler(this.DescontoTextBox_Leave);
            // 
            // totalAVistaTextBox
            // 
            this.totalAVistaTextBox.BackColor = System.Drawing.Color.Blue;
            this.totalAVistaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.totalAVistaTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.totalAVistaTextBox.Location = new System.Drawing.Point(690, 491);
            this.totalAVistaTextBox.Name = "totalAVistaTextBox";
            this.totalAVistaTextBox.ReadOnly = true;
            this.totalAVistaTextBox.Size = new System.Drawing.Size(189, 32);
            this.totalAVistaTextBox.TabIndex = 46;
            this.totalAVistaTextBox.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label10.Location = new System.Drawing.Point(584, 497);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 18);
            this.label10.TabIndex = 46;
            this.label10.Text = "À Vista (R$):";
            // 
            // valorRecebidoTextBox
            // 
            this.valorRecebidoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.valorRecebidoTextBox.ForeColor = System.Drawing.Color.Red;
            this.valorRecebidoTextBox.Location = new System.Drawing.Point(1014, 542);
            this.valorRecebidoTextBox.Name = "valorRecebidoTextBox";
            this.valorRecebidoTextBox.Size = new System.Drawing.Size(146, 32);
            this.valorRecebidoTextBox.TabIndex = 54;
            this.valorRecebidoTextBox.Leave += new System.EventHandler(this.faltaReceberTextBox_Leave);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(164, 582);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(88, 23);
            this.btnImprimir.TabIndex = 58;
            this.btnImprimir.Text = "F7 - Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnCFNfe
            // 
            this.btnCFNfe.Location = new System.Drawing.Point(252, 582);
            this.btnCFNfe.Name = "btnCFNfe";
            this.btnCFNfe.Size = new System.Drawing.Size(88, 23);
            this.btnCFNfe.TabIndex = 60;
            this.btnCFNfe.Text = "F8 - CF / NF-e";
            this.btnCFNfe.UseVisualStyleBackColor = true;
            this.btnCFNfe.Click += new System.EventHandler(this.btnCFNfe_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.Red;
            this.label14.Location = new System.Drawing.Point(1092, 158);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 13);
            this.label14.TabIndex = 66;
            this.label14.Text = "DEL - Excluir";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(1011, 158);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 13);
            this.label15.TabIndex = 65;
            this.label15.Text = "F12 - Navegar";
            // 
            // FrmReceberPagamentoPessoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1172, 617);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.btnCFNfe);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(label12);
            this.Controls.Add(this.valorRecebidoTextBox);
            this.Controls.Add(this.totalAVistaTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.descontoTextBox);
            this.Controls.Add(label9);
            this.Controls.Add(this.faltaReceberTextBox);
            this.Controls.Add(this.totalPagamentosTextBox);
            this.Controls.Add(this.totalContasTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_movimentacao_contaDataGridView);
            this.Controls.Add(this.contasPessoaDataGridView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataFinalDateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataInicioDateTimePicker);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(codClienteLabel);
            this.Controls.Add(this.codClienteComboBox);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmReceberPagamentoPessoa";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Receber Pagamentos";
            this.Load += new System.EventHandler(this.FrmReceberPagamentoPessoa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmReceberPagamentoPessoa_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pessoaBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contasPessoaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contasPessoaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.movimentacaoContaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_movimentacao_contaDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

         }

         #endregion

         private System.Windows.Forms.Label label1;
         private System.Windows.Forms.Panel panel1;
         private System.Windows.Forms.Button btnSalvar;
         private System.Windows.Forms.Button btnCancelar;
         private System.Windows.Forms.Button btnNovo;
         private System.Windows.Forms.ComboBox codClienteComboBox;
         private System.Windows.Forms.GroupBox groupBox2;
         private System.Windows.Forms.CheckBox abertaCheckBox;
         private System.Windows.Forms.DateTimePicker dataInicioDateTimePicker;
         private System.Windows.Forms.Label label2;
         private System.Windows.Forms.Label label3;
         private System.Windows.Forms.DateTimePicker dataFinalDateTimePicker;
         private System.Windows.Forms.CheckBox quitadaCheckBox;
         private System.Windows.Forms.BindingSource contasPessoaBindingSource;
         private System.Windows.Forms.DataGridView contasPessoaDataGridView;
         private System.Windows.Forms.BindingSource movimentacaoContaBindingSource;
         private System.Windows.Forms.DataGridView tb_movimentacao_contaDataGridView;
         private System.Windows.Forms.Label label4;
         private System.Windows.Forms.Label label5;
         private System.Windows.Forms.Label label7;
         private System.Windows.Forms.Label label6;
         private System.Windows.Forms.Label label8;
         private System.Windows.Forms.TextBox totalContasTextBox;
         private System.Windows.Forms.TextBox totalPagamentosTextBox;
         private System.Windows.Forms.TextBox faltaReceberTextBox;
         private System.Windows.Forms.TextBox descontoTextBox;
         private System.Windows.Forms.TextBox totalAVistaTextBox;
         private System.Windows.Forms.Label label10;
         private System.Windows.Forms.TextBox valorRecebidoTextBox;
         private System.Windows.Forms.Button btnImprimir;
         private System.Windows.Forms.Button btnCFNfe;
         private System.Windows.Forms.Label label14;
         private System.Windows.Forms.Label label15;
         private System.Windows.Forms.DataGridViewTextBoxColumn codMovimentacaoDataGridViewTextBoxColumn;
         private System.Windows.Forms.DataGridViewTextBoxColumn dataHoraDataGridViewTextBoxColumn;
         private System.Windows.Forms.DataGridViewTextBoxColumn valorDataGridViewTextBoxColumn1;
         private System.Windows.Forms.DataGridViewTextBoxColumn codContaDataGridViewTextBoxColumn;
         private System.Windows.Forms.DataGridViewTextBoxColumn codSaidaDataGridViewTextBoxColumn;
         private System.Windows.Forms.DataGridViewTextBoxColumn FormatoConta;
         private System.Windows.Forms.DataGridViewTextBoxColumn dataVencimentoDataGridViewTextBoxColumn;
         private System.Windows.Forms.DataGridViewTextBoxColumn CF;
         private System.Windows.Forms.DataGridViewTextBoxColumn NumeroDocumento;
         private System.Windows.Forms.DataGridViewTextBoxColumn descricaoSituacaoDataGridViewTextBoxColumn;
         private System.Windows.Forms.DataGridViewTextBoxColumn valorDataGridViewTextBoxColumn;
         private System.Windows.Forms.DataGridViewTextBoxColumn desconto;
         private System.Windows.Forms.DataGridViewTextBoxColumn valorPagar;
         private System.Windows.Forms.BindingSource pessoaBindingSource;
     }
 }