namespace Telas
{
    partial class FrmMovimentacaoCaixa
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
            System.Windows.Forms.Label codContaBancoLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.contaBancoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codContaBancoComboBox = new System.Windows.Forms.ComboBox();
            this.dateTimePickerInicial = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFinal = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.totaisMovimentacaoContaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.totaisMovimentacaoContaDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textTotalMovimentacao = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.totaisSaidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.totaisSaidaDataGridView = new System.Windows.Forms.DataGridView();
            this.descricaoFormaPagamentosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPagamentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendasCartaoRede = new System.Windows.Forms.BindingSource(this.components);
            this.totaisCartaoDataGridView = new System.Windows.Forms.DataGridView();
            this.codSaidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroControle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaoCartaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parcelasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalCartaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.textTotalVendas = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.totalCreditoRede = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.totalDebitoRede = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.totalCreditoBanese = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendasCartaoBaneseCredito = new System.Windows.Forms.BindingSource(this.components);
            this.totalRede = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            codContaBancoLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contaBancoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totaisMovimentacaoContaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totaisMovimentacaoContaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totaisSaidaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totaisSaidaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendasCartaoRede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totaisCartaoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendasCartaoBaneseCredito)).BeginInit();
            this.SuspendLayout();
            // 
            // codContaBancoLabel
            // 
            codContaBancoLabel.AutoSize = true;
            codContaBancoLabel.Location = new System.Drawing.Point(13, 70);
            codContaBancoLabel.Name = "codContaBancoLabel";
            codContaBancoLabel.Size = new System.Drawing.Size(109, 13);
            codContaBancoLabel.TabIndex = 22;
            codContaBancoLabel.Text = "Caixa / Conta Banco:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(116, -89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastro de Bancos";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1009, 53);
            this.panel1.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(11, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Movimentação de Caixa / Contas";
            // 
            // contaBancoBindingSource
            // 
            this.contaBancoBindingSource.DataSource = typeof(Dominio.ContaBanco);
            // 
            // codContaBancoComboBox
            // 
            this.codContaBancoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contaBancoBindingSource, "CodContaBanco", true));
            this.codContaBancoComboBox.DataSource = this.contaBancoBindingSource;
            this.codContaBancoComboBox.DisplayMember = "Descricao";
            this.codContaBancoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codContaBancoComboBox.FormattingEnabled = true;
            this.codContaBancoComboBox.Location = new System.Drawing.Point(16, 87);
            this.codContaBancoComboBox.Name = "codContaBancoComboBox";
            this.codContaBancoComboBox.Size = new System.Drawing.Size(447, 21);
            this.codContaBancoComboBox.TabIndex = 23;
            this.codContaBancoComboBox.ValueMember = "CodContaBanco";
            // 
            // dateTimePickerInicial
            // 
            this.dateTimePickerInicial.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dateTimePickerInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerInicial.Location = new System.Drawing.Point(486, 88);
            this.dateTimePickerInicial.Name = "dateTimePickerInicial";
            this.dateTimePickerInicial.Size = new System.Drawing.Size(96, 20);
            this.dateTimePickerInicial.TabIndex = 24;
            this.dateTimePickerInicial.Value = new System.DateTime(2016, 9, 30, 0, 0, 0, 0);
            this.dateTimePickerInicial.ValueChanged += new System.EventHandler(this.dateTimePickerInicial_ValueChanged);
            // 
            // dateTimePickerFinal
            // 
            this.dateTimePickerFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerFinal.Location = new System.Drawing.Point(612, 87);
            this.dateTimePickerFinal.Name = "dateTimePickerFinal";
            this.dateTimePickerFinal.Size = new System.Drawing.Size(113, 20);
            this.dateTimePickerFinal.TabIndex = 25;
            this.dateTimePickerFinal.Value = new System.DateTime(2014, 12, 29, 22, 49, 42, 0);
            this.dateTimePickerFinal.ValueChanged += new System.EventHandler(this.dateTimePickerInicial_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(483, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Data Inicial:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(609, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Data Final:";
            // 
            // totaisMovimentacaoContaBindingSource
            // 
            this.totaisMovimentacaoContaBindingSource.DataSource = typeof(Dominio.Consultas.TotaisMovimentacaoConta);
            // 
            // totaisMovimentacaoContaDataGridView
            // 
            this.totaisMovimentacaoContaDataGridView.AllowUserToAddRows = false;
            this.totaisMovimentacaoContaDataGridView.AllowUserToDeleteRows = false;
            this.totaisMovimentacaoContaDataGridView.AutoGenerateColumns = false;
            this.totaisMovimentacaoContaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.totaisMovimentacaoContaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn2});
            this.totaisMovimentacaoContaDataGridView.DataSource = this.totaisMovimentacaoContaBindingSource;
            this.totaisMovimentacaoContaDataGridView.Location = new System.Drawing.Point(16, 140);
            this.totaisMovimentacaoContaDataGridView.Name = "totaisMovimentacaoContaDataGridView";
            this.totaisMovimentacaoContaDataGridView.ReadOnly = true;
            this.totaisMovimentacaoContaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.totaisMovimentacaoContaDataGridView.Size = new System.Drawing.Size(447, 149);
            this.totaisMovimentacaoContaDataGridView.TabIndex = 27;
            this.totaisMovimentacaoContaDataGridView.TabStop = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CodTipoMovimentacaoConta";
            this.dataGridViewTextBoxColumn1.HeaderText = "CodTipoMovimentacaoConta";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DescricaoMovimentacaoConta";
            this.dataGridViewTextBoxColumn3.HeaderText = "Movimentação";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TotalMovimentacaoConta";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn2.HeaderText = "Total (R$)";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(13, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(194, 18);
            this.label5.TabIndex = 28;
            this.label5.Text = "Movimentação do Caixa:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(826, 84);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(264, 301);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 30;
            this.label6.Text = "TOTAL";
            // 
            // textTotalMovimentacao
            // 
            this.textTotalMovimentacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotalMovimentacao.ForeColor = System.Drawing.Color.Red;
            this.textTotalMovimentacao.Location = new System.Drawing.Point(334, 295);
            this.textTotalMovimentacao.Name = "textTotalMovimentacao";
            this.textTotalMovimentacao.Size = new System.Drawing.Size(129, 26);
            this.textTotalMovimentacao.TabIndex = 31;
            this.textTotalMovimentacao.TabStop = false;
            this.textTotalMovimentacao.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(13, 330);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 18);
            this.label7.TabIndex = 32;
            this.label7.Text = "Vendas Realizadas:";
            // 
            // totaisSaidaBindingSource
            // 
            this.totaisSaidaBindingSource.DataSource = typeof(Dominio.Consultas.TotalPagamentoSaida);
            // 
            // totaisSaidaDataGridView
            // 
            this.totaisSaidaDataGridView.AllowUserToAddRows = false;
            this.totaisSaidaDataGridView.AllowUserToDeleteRows = false;
            this.totaisSaidaDataGridView.AutoGenerateColumns = false;
            this.totaisSaidaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.totaisSaidaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.descricaoFormaPagamentosDataGridViewTextBoxColumn,
            this.totalPagamentoDataGridViewTextBoxColumn});
            this.totaisSaidaDataGridView.DataSource = this.totaisSaidaBindingSource;
            this.totaisSaidaDataGridView.Location = new System.Drawing.Point(16, 356);
            this.totaisSaidaDataGridView.Name = "totaisSaidaDataGridView";
            this.totaisSaidaDataGridView.ReadOnly = true;
            this.totaisSaidaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.totaisSaidaDataGridView.Size = new System.Drawing.Size(447, 201);
            this.totaisSaidaDataGridView.TabIndex = 32;
            // 
            // descricaoFormaPagamentosDataGridViewTextBoxColumn
            // 
            this.descricaoFormaPagamentosDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricaoFormaPagamentosDataGridViewTextBoxColumn.DataPropertyName = "DescricaoFormaPagamentos";
            this.descricaoFormaPagamentosDataGridViewTextBoxColumn.HeaderText = "Forma Pagamento";
            this.descricaoFormaPagamentosDataGridViewTextBoxColumn.Name = "descricaoFormaPagamentosDataGridViewTextBoxColumn";
            this.descricaoFormaPagamentosDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalPagamentoDataGridViewTextBoxColumn
            // 
            this.totalPagamentoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.totalPagamentoDataGridViewTextBoxColumn.DataPropertyName = "TotalPagamento";
            this.totalPagamentoDataGridViewTextBoxColumn.HeaderText = "Total (R$)";
            this.totalPagamentoDataGridViewTextBoxColumn.Name = "totalPagamentoDataGridViewTextBoxColumn";
            this.totalPagamentoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vendasCartaoRede
            // 
            this.vendasCartaoRede.DataSource = typeof(Dominio.Consultas.VendasCartao);
            // 
            // totaisCartaoDataGridView
            // 
            this.totaisCartaoDataGridView.AllowUserToAddRows = false;
            this.totaisCartaoDataGridView.AllowUserToDeleteRows = false;
            this.totaisCartaoDataGridView.AutoGenerateColumns = false;
            this.totaisCartaoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.totaisCartaoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codSaidaDataGridViewTextBoxColumn,
            this.NumeroControle,
            this.descricaoCartaoDataGridViewTextBoxColumn,
            this.parcelasDataGridViewTextBoxColumn,
            this.totalCartaoDataGridViewTextBoxColumn});
            this.totaisCartaoDataGridView.DataSource = this.vendasCartaoRede;
            this.totaisCartaoDataGridView.Location = new System.Drawing.Point(486, 140);
            this.totaisCartaoDataGridView.Name = "totaisCartaoDataGridView";
            this.totaisCartaoDataGridView.ReadOnly = true;
            this.totaisCartaoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.totaisCartaoDataGridView.Size = new System.Drawing.Size(511, 277);
            this.totaisCartaoDataGridView.TabIndex = 32;
            // 
            // codSaidaDataGridViewTextBoxColumn
            // 
            this.codSaidaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.codSaidaDataGridViewTextBoxColumn.DataPropertyName = "CodSaida";
            this.codSaidaDataGridViewTextBoxColumn.FillWeight = 20F;
            this.codSaidaDataGridViewTextBoxColumn.HeaderText = "Saída";
            this.codSaidaDataGridViewTextBoxColumn.Name = "codSaidaDataGridViewTextBoxColumn";
            this.codSaidaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // NumeroControle
            // 
            this.NumeroControle.DataPropertyName = "NumeroControle";
            this.NumeroControle.HeaderText = "Autorização";
            this.NumeroControle.Name = "NumeroControle";
            this.NumeroControle.ReadOnly = true;
            // 
            // descricaoCartaoDataGridViewTextBoxColumn
            // 
            this.descricaoCartaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricaoCartaoDataGridViewTextBoxColumn.DataPropertyName = "DescricaoCartao";
            this.descricaoCartaoDataGridViewTextBoxColumn.FillWeight = 50F;
            this.descricaoCartaoDataGridViewTextBoxColumn.HeaderText = "Cartão";
            this.descricaoCartaoDataGridViewTextBoxColumn.Name = "descricaoCartaoDataGridViewTextBoxColumn";
            this.descricaoCartaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // parcelasDataGridViewTextBoxColumn
            // 
            this.parcelasDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.parcelasDataGridViewTextBoxColumn.DataPropertyName = "Parcelas";
            this.parcelasDataGridViewTextBoxColumn.FillWeight = 20F;
            this.parcelasDataGridViewTextBoxColumn.HeaderText = "Parcelas";
            this.parcelasDataGridViewTextBoxColumn.Name = "parcelasDataGridViewTextBoxColumn";
            this.parcelasDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // totalCartaoDataGridViewTextBoxColumn
            // 
            this.totalCartaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.totalCartaoDataGridViewTextBoxColumn.DataPropertyName = "TotalCartao";
            this.totalCartaoDataGridViewTextBoxColumn.FillWeight = 30F;
            this.totalCartaoDataGridViewTextBoxColumn.HeaderText = "Valor (R$)";
            this.totalCartaoDataGridViewTextBoxColumn.Name = "totalCartaoDataGridViewTextBoxColumn";
            this.totalCartaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(483, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 16);
            this.label8.TabIndex = 33;
            this.label8.Text = "REDE";
            // 
            // textTotalVendas
            // 
            this.textTotalVendas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTotalVendas.ForeColor = System.Drawing.Color.Red;
            this.textTotalVendas.Location = new System.Drawing.Point(334, 563);
            this.textTotalVendas.Name = "textTotalVendas";
            this.textTotalVendas.Size = new System.Drawing.Size(129, 26);
            this.textTotalVendas.TabIndex = 35;
            this.textTotalVendas.TabStop = false;
            this.textTotalVendas.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(264, 569);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 20);
            this.label9.TabIndex = 34;
            this.label9.Text = "TOTAL";
            // 
            // totalCreditoRede
            // 
            this.totalCreditoRede.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalCreditoRede.ForeColor = System.Drawing.Color.Red;
            this.totalCreditoRede.Location = new System.Drawing.Point(556, 426);
            this.totalCreditoRede.Name = "totalCreditoRede";
            this.totalCreditoRede.Size = new System.Drawing.Size(85, 22);
            this.totalCreditoRede.TabIndex = 37;
            this.totalCreditoRede.TabStop = false;
            this.totalCreditoRede.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(483, 429);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 20);
            this.label10.TabIndex = 36;
            this.label10.Text = "Crédito";
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Location = new System.Drawing.Point(745, 84);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizar.TabIndex = 26;
            this.btnAtualizar.Text = "Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = true;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // totalDebitoRede
            // 
            this.totalDebitoRede.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalDebitoRede.ForeColor = System.Drawing.Color.Red;
            this.totalDebitoRede.Location = new System.Drawing.Point(718, 426);
            this.totalDebitoRede.Name = "totalDebitoRede";
            this.totalDebitoRede.Size = new System.Drawing.Size(91, 22);
            this.totalDebitoRede.TabIndex = 41;
            this.totalDebitoRede.TabStop = false;
            this.totalDebitoRede.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(650, 429);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(62, 20);
            this.label12.TabIndex = 40;
            this.label12.Text = "Débito";
            // 
            // totalCreditoBanese
            // 
            this.totalCreditoBanese.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalCreditoBanese.ForeColor = System.Drawing.Color.Red;
            this.totalCreditoBanese.Location = new System.Drawing.Point(868, 563);
            this.totalCreditoBanese.Name = "totalCreditoBanese";
            this.totalCreditoBanese.Size = new System.Drawing.Size(129, 26);
            this.totalCreditoBanese.TabIndex = 45;
            this.totalCreditoBanese.TabStop = false;
            this.totalCreditoBanese.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(813, 569);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 20);
            this.label13.TabIndex = 44;
            this.label13.Text = "Total";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(483, 463);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(149, 16);
            this.label14.TabIndex = 43;
            this.label14.Text = "BANESE - CRÉDITO";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13});
            this.dataGridView2.DataSource = this.vendasCartaoBaneseCredito;
            this.dataGridView2.Location = new System.Drawing.Point(486, 484);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(511, 73);
            this.dataGridView2.TabIndex = 42;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "CodSaida";
            this.dataGridViewTextBoxColumn9.FillWeight = 20F;
            this.dataGridViewTextBoxColumn9.HeaderText = "Saída";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "NumeroControle";
            this.dataGridViewTextBoxColumn10.HeaderText = "Autorização";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "DescricaoCartao";
            this.dataGridViewTextBoxColumn11.FillWeight = 50F;
            this.dataGridViewTextBoxColumn11.HeaderText = "Cartão";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Parcelas";
            this.dataGridViewTextBoxColumn12.FillWeight = 20F;
            this.dataGridViewTextBoxColumn12.HeaderText = "Parcelas";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn13.DataPropertyName = "TotalCartao";
            this.dataGridViewTextBoxColumn13.FillWeight = 30F;
            this.dataGridViewTextBoxColumn13.HeaderText = "Valor (R$)";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // vendasCartaoBaneseCredito
            // 
            this.vendasCartaoBaneseCredito.DataSource = typeof(Dominio.Consultas.VendasCartao);
            // 
            // totalRede
            // 
            this.totalRede.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalRede.ForeColor = System.Drawing.Color.Red;
            this.totalRede.Location = new System.Drawing.Point(868, 423);
            this.totalRede.Name = "totalRede";
            this.totalRede.Size = new System.Drawing.Size(129, 26);
            this.totalRede.TabIndex = 47;
            this.totalRede.TabStop = false;
            this.totalRede.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(813, 429);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 20);
            this.label11.TabIndex = 46;
            this.label11.Text = "Total";
            // 
            // FrmMovimentacaoCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 619);
            this.Controls.Add(this.totalRede);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.totalCreditoBanese);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.totalDebitoRede);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.totalCreditoRede);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textTotalVendas);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.totaisCartaoDataGridView);
            this.Controls.Add(this.totaisSaidaDataGridView);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textTotalMovimentacao);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.totaisMovimentacaoContaDataGridView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePickerFinal);
            this.Controls.Add(this.dateTimePickerInicial);
            this.Controls.Add(codContaBancoLabel);
            this.Controls.Add(this.codContaBancoComboBox);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "FrmMovimentacaoCaixa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Movimentação de Caixa / Contas";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMovimentacaoCaixa_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contaBancoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totaisMovimentacaoContaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totaisMovimentacaoContaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totaisSaidaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totaisSaidaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendasCartaoRede)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totaisCartaoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendasCartaoBaneseCredito)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource contaBancoBindingSource;
        private System.Windows.Forms.ComboBox codContaBancoComboBox;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicial;
        private System.Windows.Forms.DateTimePicker dateTimePickerFinal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource totaisMovimentacaoContaBindingSource;
        private System.Windows.Forms.DataGridView totaisMovimentacaoContaDataGridView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textTotalMovimentacao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource totaisSaidaBindingSource;
        private System.Windows.Forms.DataGridView totaisSaidaDataGridView;
        private System.Windows.Forms.BindingSource vendasCartaoRede;
        private System.Windows.Forms.DataGridView totaisCartaoDataGridView;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textTotalVendas;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox totalCreditoRede;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoFormaPagamentosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPagamentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codSaidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroControle;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoCartaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn parcelasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalCartaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox totalDebitoRede;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox totalCreditoBanese;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.BindingSource vendasCartaoBaneseCredito;
        private System.Windows.Forms.TextBox totalRede;
        private System.Windows.Forms.Label label11;

    }
}