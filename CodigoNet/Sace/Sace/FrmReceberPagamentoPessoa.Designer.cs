namespace Sace
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
            components = new System.ComponentModel.Container();
            Label codClienteLabel;
            Label label9;
            Label label12;
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            label1 = new Label();
            panel1 = new Panel();
            btnSalvar = new Button();
            btnCancelar = new Button();
            btnNovo = new Button();
            codClienteComboBox = new ComboBox();
            pessoaBindingSource = new BindingSource(components);
            groupBox2 = new GroupBox();
            quitadaCheckBox = new CheckBox();
            abertaCheckBox = new CheckBox();
            dataInicioDateTimePicker = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            dataFinalDateTimePicker = new DateTimePicker();
            contasPessoaDataGridView = new DataGridView();
            codContaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            codSaidaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            FormatoConta = new DataGridViewTextBoxColumn();
            dataVencimentoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            CF = new DataGridViewTextBoxColumn();
            NumeroDocumento = new DataGridViewTextBoxColumn();
            descricaoSituacaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            desconto = new DataGridViewTextBoxColumn();
            valorPagar = new DataGridViewTextBoxColumn();
            contasPessoaBindingSource = new BindingSource(components);
            movimentacaoContaBindingSource = new BindingSource(components);
            tb_movimentacao_contaDataGridView = new DataGridView();
            codMovimentacaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataHoraDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valorDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            label6 = new Label();
            label8 = new Label();
            totalContasTextBox = new TextBox();
            totalPagamentosTextBox = new TextBox();
            faltaReceberTextBox = new TextBox();
            descontoTextBox = new TextBox();
            totalAVistaTextBox = new TextBox();
            label10 = new Label();
            valorRecebidoTextBox = new TextBox();
            btnImprimir = new Button();
            btnCFNfe = new Button();
            label14 = new Label();
            label15 = new Label();
            codClienteLabel = new Label();
            label9 = new Label();
            label12 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pessoaBindingSource).BeginInit();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)contasPessoaDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)contasPessoaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)movimentacaoContaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tb_movimentacao_contaDataGridView).BeginInit();
            SuspendLayout();
            // 
            // codClienteLabel
            // 
            codClienteLabel.AutoSize = true;
            codClienteLabel.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            codClienteLabel.Location = new Point(4, 83);
            codClienteLabel.Margin = new Padding(4, 0, 4, 0);
            codClienteLabel.Name = "codClienteLabel";
            codClienteLabel.Size = new Size(73, 24);
            codClienteLabel.TabIndex = 26;
            codClienteLabel.Text = "Cliente:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 11F);
            label9.Location = new Point(379, 576);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(124, 18);
            label9.TabIndex = 44;
            label9.Text = "Desc/Acresc (%):";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 11F);
            label12.Location = new Point(1046, 635);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(108, 18);
            label12.TabIndex = 50;
            label12.Text = "Recebido (R$):";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(4, 10);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(157, 23);
            label1.TabIndex = 0;
            label1.Text = "Receber Pagamentos";
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, -1);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1366, 47);
            panel1.TabIndex = 20;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(97, 672);
            btnSalvar.Margin = new Padding(4, 3, 4, 3);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(94, 27);
            btnSalvar.TabIndex = 56;
            btnSalvar.Text = "F6 - Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(400, 672);
            btnCancelar.Margin = new Padding(4, 3, 4, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 27);
            btnCancelar.TabIndex = 62;
            btnCancelar.Text = "Esc - Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(9, 672);
            btnNovo.Margin = new Padding(4, 3, 4, 3);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(88, 27);
            btnNovo.TabIndex = 1;
            btnNovo.Text = "F3 - Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // codClienteComboBox
            // 
            codClienteComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            codClienteComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            codClienteComboBox.CausesValidation = false;
            codClienteComboBox.DataSource = pessoaBindingSource;
            codClienteComboBox.DisplayMember = "NomeFantasia";
            codClienteComboBox.Font = new Font("Microsoft Sans Serif", 16F);
            codClienteComboBox.FormattingEnabled = true;
            codClienteComboBox.Location = new Point(8, 120);
            codClienteComboBox.Margin = new Padding(4, 3, 4, 3);
            codClienteComboBox.Name = "codClienteComboBox";
            codClienteComboBox.Size = new Size(1030, 33);
            codClienteComboBox.TabIndex = 25;
            codClienteComboBox.ValueMember = "codPessoa";
            codClienteComboBox.KeyPress += codClienteComboBox_KeyPress;
            codClienteComboBox.Leave += codClienteComboBox_Leave;
            // 
            // pessoaBindingSource
            // 
            pessoaBindingSource.AllowNew = false;
            pessoaBindingSource.DataSource = typeof(Dominio.Pessoa);
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(quitadaCheckBox);
            groupBox2.Controls.Add(abertaCheckBox);
            groupBox2.Font = new Font("Microsoft Sans Serif", 10F);
            groupBox2.Location = new Point(1211, 53);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(138, 105);
            groupBox2.TabIndex = 30;
            groupBox2.TabStop = false;
            groupBox2.Text = "Situação Conta";
            // 
            // quitadaCheckBox
            // 
            quitadaCheckBox.AutoSize = true;
            quitadaCheckBox.Location = new Point(23, 68);
            quitadaCheckBox.Margin = new Padding(4, 3, 4, 3);
            quitadaCheckBox.Name = "quitadaCheckBox";
            quitadaCheckBox.Size = new Size(77, 21);
            quitadaCheckBox.TabIndex = 1;
            quitadaCheckBox.Text = "Quitada";
            quitadaCheckBox.UseVisualStyleBackColor = true;
            quitadaCheckBox.CheckedChanged += dataInicioDateTimePicker_Leave;
            // 
            // abertaCheckBox
            // 
            abertaCheckBox.AutoSize = true;
            abertaCheckBox.Checked = true;
            abertaCheckBox.CheckState = CheckState.Checked;
            abertaCheckBox.Location = new Point(23, 33);
            abertaCheckBox.Margin = new Padding(4, 3, 4, 3);
            abertaCheckBox.Name = "abertaCheckBox";
            abertaCheckBox.Size = new Size(69, 21);
            abertaCheckBox.TabIndex = 0;
            abertaCheckBox.Text = "Aberta";
            abertaCheckBox.UseVisualStyleBackColor = true;
            abertaCheckBox.CheckedChanged += dataInicioDateTimePicker_Leave;
            // 
            // dataInicioDateTimePicker
            // 
            dataInicioDateTimePicker.Font = new Font("Microsoft Sans Serif", 11F);
            dataInicioDateTimePicker.Format = DateTimePickerFormat.Short;
            dataInicioDateTimePicker.Location = new Point(1060, 75);
            dataInicioDateTimePicker.Margin = new Padding(4, 3, 4, 3);
            dataInicioDateTimePicker.Name = "dataInicioDateTimePicker";
            dataInicioDateTimePicker.Size = new Size(136, 24);
            dataInicioDateTimePicker.TabIndex = 27;
            dataInicioDateTimePicker.Leave += dataInicioDateTimePicker_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 11F);
            label2.Location = new Point(1057, 50);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(77, 18);
            label2.TabIndex = 30;
            label2.Text = "Data Início";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 11F);
            label3.Location = new Point(1057, 105);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(78, 18);
            label3.TabIndex = 32;
            label3.Text = "Data Final:";
            // 
            // dataFinalDateTimePicker
            // 
            dataFinalDateTimePicker.Font = new Font("Microsoft Sans Serif", 11F);
            dataFinalDateTimePicker.Format = DateTimePickerFormat.Short;
            dataFinalDateTimePicker.Location = new Point(1060, 130);
            dataFinalDateTimePicker.Margin = new Padding(4, 3, 4, 3);
            dataFinalDateTimePicker.Name = "dataFinalDateTimePicker";
            dataFinalDateTimePicker.Size = new Size(136, 24);
            dataFinalDateTimePicker.TabIndex = 29;
            dataFinalDateTimePicker.Leave += dataInicioDateTimePicker_Leave;
            // 
            // contasPessoaDataGridView
            // 
            contasPessoaDataGridView.AllowUserToAddRows = false;
            contasPessoaDataGridView.AllowUserToDeleteRows = false;
            contasPessoaDataGridView.AutoGenerateColumns = false;
            contasPessoaDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            contasPessoaDataGridView.Columns.AddRange(new DataGridViewColumn[] { codContaDataGridViewTextBoxColumn, codSaidaDataGridViewTextBoxColumn, FormatoConta, dataVencimentoDataGridViewTextBoxColumn, CF, NumeroDocumento, descricaoSituacaoDataGridViewTextBoxColumn, valorDataGridViewTextBoxColumn, desconto, valorPagar });
            contasPessoaDataGridView.DataSource = contasPessoaBindingSource;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            contasPessoaDataGridView.DefaultCellStyle = dataGridViewCellStyle5;
            contasPessoaDataGridView.Location = new Point(8, 203);
            contasPessoaDataGridView.Margin = new Padding(4, 3, 4, 3);
            contasPessoaDataGridView.Name = "contasPessoaDataGridView";
            contasPessoaDataGridView.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(255, 255, 192);
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            contasPessoaDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewCellStyle7.SelectionBackColor = Color.FromArgb(255, 255, 192);
            contasPessoaDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle7;
            contasPessoaDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            contasPessoaDataGridView.Size = new Size(1030, 350);
            contasPessoaDataGridView.StandardTab = true;
            contasPessoaDataGridView.TabIndex = 32;
            contasPessoaDataGridView.TabStop = false;
            contasPessoaDataGridView.SelectionChanged += ContasPessoaDataGridView_SelectionChanged;
            // 
            // codContaDataGridViewTextBoxColumn
            // 
            codContaDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            codContaDataGridViewTextBoxColumn.DataPropertyName = "CodConta";
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            codContaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            codContaDataGridViewTextBoxColumn.FillWeight = 60F;
            codContaDataGridViewTextBoxColumn.HeaderText = "Conta";
            codContaDataGridViewTextBoxColumn.Name = "codContaDataGridViewTextBoxColumn";
            codContaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codSaidaDataGridViewTextBoxColumn
            // 
            codSaidaDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            codSaidaDataGridViewTextBoxColumn.DataPropertyName = "CodSaida";
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            codSaidaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            codSaidaDataGridViewTextBoxColumn.FillWeight = 60F;
            codSaidaDataGridViewTextBoxColumn.HeaderText = "Pré-Venda";
            codSaidaDataGridViewTextBoxColumn.Name = "codSaidaDataGridViewTextBoxColumn";
            codSaidaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FormatoConta
            // 
            FormatoConta.DataPropertyName = "FormatoConta";
            FormatoConta.HeaderText = "Formato";
            FormatoConta.Name = "FormatoConta";
            FormatoConta.ReadOnly = true;
            // 
            // dataVencimentoDataGridViewTextBoxColumn
            // 
            dataVencimentoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataVencimentoDataGridViewTextBoxColumn.DataPropertyName = "DataVencimento";
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataVencimentoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            dataVencimentoDataGridViewTextBoxColumn.FillWeight = 70F;
            dataVencimentoDataGridViewTextBoxColumn.HeaderText = "Vencimento";
            dataVencimentoDataGridViewTextBoxColumn.Name = "dataVencimentoDataGridViewTextBoxColumn";
            dataVencimentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // CF
            // 
            CF.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CF.DataPropertyName = "CF";
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CF.DefaultCellStyle = dataGridViewCellStyle4;
            CF.FillWeight = 60F;
            CF.HeaderText = "CF";
            CF.MinimumWidth = 60;
            CF.Name = "CF";
            CF.ReadOnly = true;
            // 
            // NumeroDocumento
            // 
            NumeroDocumento.DataPropertyName = "NumeroDocumento";
            NumeroDocumento.HeaderText = "Dcto";
            NumeroDocumento.Name = "NumeroDocumento";
            NumeroDocumento.ReadOnly = true;
            // 
            // descricaoSituacaoDataGridViewTextBoxColumn
            // 
            descricaoSituacaoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            descricaoSituacaoDataGridViewTextBoxColumn.DataPropertyName = "DescricaoSituacao";
            descricaoSituacaoDataGridViewTextBoxColumn.FillWeight = 70F;
            descricaoSituacaoDataGridViewTextBoxColumn.HeaderText = "Situação";
            descricaoSituacaoDataGridViewTextBoxColumn.Name = "descricaoSituacaoDataGridViewTextBoxColumn";
            descricaoSituacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorDataGridViewTextBoxColumn
            // 
            valorDataGridViewTextBoxColumn.DataPropertyName = "Valor";
            valorDataGridViewTextBoxColumn.HeaderText = "Total (R$)";
            valorDataGridViewTextBoxColumn.Name = "valorDataGridViewTextBoxColumn";
            valorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // desconto
            // 
            desconto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            desconto.DataPropertyName = "Desconto";
            desconto.FillWeight = 70F;
            desconto.HeaderText = "Descto (R$)";
            desconto.Name = "desconto";
            desconto.ReadOnly = true;
            // 
            // valorPagar
            // 
            valorPagar.DataPropertyName = "ValorPagar";
            valorPagar.HeaderText = "À Vista (R$)";
            valorPagar.Name = "valorPagar";
            valorPagar.ReadOnly = true;
            // 
            // contasPessoaBindingSource
            // 
            contasPessoaBindingSource.DataSource = typeof(Dominio.Conta);
            // 
            // movimentacaoContaBindingSource
            // 
            movimentacaoContaBindingSource.DataSource = typeof(Dominio.MovimentacaoConta);
            // 
            // tb_movimentacao_contaDataGridView
            // 
            tb_movimentacao_contaDataGridView.AllowUserToAddRows = false;
            tb_movimentacao_contaDataGridView.AllowUserToDeleteRows = false;
            tb_movimentacao_contaDataGridView.AutoGenerateColumns = false;
            tb_movimentacao_contaDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tb_movimentacao_contaDataGridView.Columns.AddRange(new DataGridViewColumn[] { codMovimentacaoDataGridViewTextBoxColumn, dataHoraDataGridViewTextBoxColumn, valorDataGridViewTextBoxColumn1 });
            tb_movimentacao_contaDataGridView.DataSource = movimentacaoContaBindingSource;
            tb_movimentacao_contaDataGridView.Location = new Point(1064, 203);
            tb_movimentacao_contaDataGridView.Margin = new Padding(4, 3, 4, 3);
            tb_movimentacao_contaDataGridView.Name = "tb_movimentacao_contaDataGridView";
            tb_movimentacao_contaDataGridView.ReadOnly = true;
            tb_movimentacao_contaDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tb_movimentacao_contaDataGridView.Size = new Size(285, 350);
            tb_movimentacao_contaDataGridView.TabIndex = 34;
            tb_movimentacao_contaDataGridView.TabStop = false;
            // 
            // codMovimentacaoDataGridViewTextBoxColumn
            // 
            codMovimentacaoDataGridViewTextBoxColumn.DataPropertyName = "CodMovimentacao";
            codMovimentacaoDataGridViewTextBoxColumn.HeaderText = "CodMovimentacao";
            codMovimentacaoDataGridViewTextBoxColumn.Name = "codMovimentacaoDataGridViewTextBoxColumn";
            codMovimentacaoDataGridViewTextBoxColumn.ReadOnly = true;
            codMovimentacaoDataGridViewTextBoxColumn.Visible = false;
            // 
            // dataHoraDataGridViewTextBoxColumn
            // 
            dataHoraDataGridViewTextBoxColumn.DataPropertyName = "DataHora";
            dataHoraDataGridViewTextBoxColumn.HeaderText = "Data";
            dataHoraDataGridViewTextBoxColumn.Name = "dataHoraDataGridViewTextBoxColumn";
            dataHoraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorDataGridViewTextBoxColumn1
            // 
            valorDataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            valorDataGridViewTextBoxColumn1.DataPropertyName = "Valor";
            valorDataGridViewTextBoxColumn1.HeaderText = "Valor (R$)";
            valorDataGridViewTextBoxColumn1.Name = "valorDataGridViewTextBoxColumn1";
            valorDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 11F);
            label4.Location = new Point(5, 177);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(60, 18);
            label4.TabIndex = 33;
            label4.Text = "Contas:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 11F);
            label5.Location = new Point(1060, 177);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(96, 18);
            label5.TabIndex = 34;
            label5.Text = "Pagamentos:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 11F);
            label7.Location = new Point(14, 580);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(130, 18);
            label7.TabIndex = 36;
            label7.Text = "Total Contas (R$):";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 11F);
            label6.Location = new Point(1065, 573);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(84, 18);
            label6.TabIndex = 37;
            label6.Text = "Total Pago:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 11F);
            label8.Location = new Point(626, 642);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(137, 18);
            label8.TabIndex = 38;
            label8.Text = "Falta Receber (R$):";
            // 
            // totalContasTextBox
            // 
            totalContasTextBox.BackColor = Color.Blue;
            totalContasTextBox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            totalContasTextBox.ForeColor = Color.Yellow;
            totalContasTextBox.Location = new Point(173, 567);
            totalContasTextBox.Margin = new Padding(4, 3, 4, 3);
            totalContasTextBox.Name = "totalContasTextBox";
            totalContasTextBox.ReadOnly = true;
            totalContasTextBox.Size = new Size(182, 32);
            totalContasTextBox.TabIndex = 36;
            totalContasTextBox.TabStop = false;
            totalContasTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // totalPagamentosTextBox
            // 
            totalPagamentosTextBox.BackColor = Color.Blue;
            totalPagamentosTextBox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            totalPagamentosTextBox.ForeColor = Color.Yellow;
            totalPagamentosTextBox.Location = new Point(1183, 564);
            totalPagamentosTextBox.Margin = new Padding(4, 3, 4, 3);
            totalPagamentosTextBox.Name = "totalPagamentosTextBox";
            totalPagamentosTextBox.ReadOnly = true;
            totalPagamentosTextBox.Size = new Size(165, 32);
            totalPagamentosTextBox.TabIndex = 40;
            totalPagamentosTextBox.TabStop = false;
            totalPagamentosTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // faltaReceberTextBox
            // 
            faltaReceberTextBox.BackColor = Color.Blue;
            faltaReceberTextBox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            faltaReceberTextBox.ForeColor = Color.Yellow;
            faltaReceberTextBox.Location = new Point(805, 625);
            faltaReceberTextBox.Margin = new Padding(4, 3, 4, 3);
            faltaReceberTextBox.Name = "faltaReceberTextBox";
            faltaReceberTextBox.ReadOnly = true;
            faltaReceberTextBox.Size = new Size(220, 32);
            faltaReceberTextBox.TabIndex = 42;
            faltaReceberTextBox.TabStop = false;
            faltaReceberTextBox.Leave += faltaReceberTextBox_Leave;
            // 
            // descontoTextBox
            // 
            descontoTextBox.Font = new Font("Microsoft Sans Serif", 16F);
            descontoTextBox.Location = new Point(531, 567);
            descontoTextBox.Margin = new Padding(4, 3, 4, 3);
            descontoTextBox.Name = "descontoTextBox";
            descontoTextBox.Size = new Size(89, 32);
            descontoTextBox.TabIndex = 44;
            descontoTextBox.Leave += DescontoTextBox_Leave;
            // 
            // totalAVistaTextBox
            // 
            totalAVistaTextBox.BackColor = Color.Blue;
            totalAVistaTextBox.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            totalAVistaTextBox.ForeColor = Color.Yellow;
            totalAVistaTextBox.Location = new Point(805, 567);
            totalAVistaTextBox.Margin = new Padding(4, 3, 4, 3);
            totalAVistaTextBox.Name = "totalAVistaTextBox";
            totalAVistaTextBox.ReadOnly = true;
            totalAVistaTextBox.Size = new Size(220, 32);
            totalAVistaTextBox.TabIndex = 46;
            totalAVistaTextBox.TabStop = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 11F);
            label10.Location = new Point(681, 573);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(90, 18);
            label10.TabIndex = 46;
            label10.Text = "À Vista (R$):";
            // 
            // valorRecebidoTextBox
            // 
            valorRecebidoTextBox.Font = new Font("Microsoft Sans Serif", 16F);
            valorRecebidoTextBox.ForeColor = Color.Red;
            valorRecebidoTextBox.Location = new Point(1183, 625);
            valorRecebidoTextBox.Margin = new Padding(4, 3, 4, 3);
            valorRecebidoTextBox.Name = "valorRecebidoTextBox";
            valorRecebidoTextBox.Size = new Size(170, 32);
            valorRecebidoTextBox.TabIndex = 54;
            valorRecebidoTextBox.Leave += faltaReceberTextBox_Leave;
            // 
            // btnImprimir
            // 
            btnImprimir.Location = new Point(191, 672);
            btnImprimir.Margin = new Padding(4, 3, 4, 3);
            btnImprimir.Name = "btnImprimir";
            btnImprimir.Size = new Size(103, 27);
            btnImprimir.TabIndex = 58;
            btnImprimir.Text = "F7 - Imprimir";
            btnImprimir.UseVisualStyleBackColor = true;
            btnImprimir.Click += btnImprimir_Click;
            // 
            // btnCFNfe
            // 
            btnCFNfe.Location = new Point(294, 672);
            btnCFNfe.Margin = new Padding(4, 3, 4, 3);
            btnCFNfe.Name = "btnCFNfe";
            btnCFNfe.Size = new Size(103, 27);
            btnCFNfe.TabIndex = 60;
            btnCFNfe.Text = "F8 - CF / NF-e";
            btnCFNfe.UseVisualStyleBackColor = true;
            btnCFNfe.Click += btnCFNfe_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.ForeColor = Color.Red;
            label14.Location = new Point(1274, 182);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(72, 15);
            label14.TabIndex = 66;
            label14.Text = "DEL - Excluir";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.ForeColor = Color.Red;
            label15.Location = new Point(1180, 182);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(80, 15);
            label15.TabIndex = 65;
            label15.Text = "F12 - Navegar";
            // 
            // FrmReceberPagamentoPessoa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1367, 712);
            Controls.Add(label14);
            Controls.Add(label15);
            Controls.Add(btnCFNfe);
            Controls.Add(btnImprimir);
            Controls.Add(label12);
            Controls.Add(valorRecebidoTextBox);
            Controls.Add(totalAVistaTextBox);
            Controls.Add(label10);
            Controls.Add(descontoTextBox);
            Controls.Add(label9);
            Controls.Add(faltaReceberTextBox);
            Controls.Add(totalPagamentosTextBox);
            Controls.Add(totalContasTextBox);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(tb_movimentacao_contaDataGridView);
            Controls.Add(contasPessoaDataGridView);
            Controls.Add(label3);
            Controls.Add(dataFinalDateTimePicker);
            Controls.Add(label2);
            Controls.Add(dataInicioDateTimePicker);
            Controls.Add(groupBox2);
            Controls.Add(codClienteLabel);
            Controls.Add(codClienteComboBox);
            Controls.Add(btnSalvar);
            Controls.Add(btnCancelar);
            Controls.Add(btnNovo);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmReceberPagamentoPessoa";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Receber Pagamentos";
            Load += FrmReceberPagamentoPessoa_Load;
            KeyDown += FrmReceberPagamentoPessoa_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pessoaBindingSource).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)contasPessoaDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)contasPessoaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)movimentacaoContaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)tb_movimentacao_contaDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();

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