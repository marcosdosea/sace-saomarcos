namespace Telas
{
    partial class FrmConta
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
            System.Windows.Forms.Label codBancoLabel;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label planoContaLabel;
            System.Windows.Forms.Label pessoaLabel;
            System.Windows.Forms.Label dataVencLabel;
            System.Windows.Forms.Label valorLabel;
            System.Windows.Forms.Label observacaoLabel;
            System.Windows.Forms.Label label5;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConta));
            this.contaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saceDataSet = new Dados.saceDataSet();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_contaBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.codContaTextBox = new System.Windows.Forms.TextBox();
            this.codPlanoContaComboBox = new System.Windows.Forms.ComboBox();
            this.planoContaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codPessoaComboBox = new System.Windows.Forms.ComboBox();
            this.pessoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codEntradaTextBox = new System.Windows.Forms.TextBox();
            this.codSaidaTextBox = new System.Windows.Forms.TextBox();
            this.dataVencimentoDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.valorTextBox = new System.Windows.Forms.TextBox();
            this.observacaoTextBox = new System.Windows.Forms.TextBox();
            this.tb_movimentacao_contaTableAdapter = new Dados.saceDataSetTableAdapters.tb_movimentacao_contaTableAdapter();
            this.tb_movimentacao_contaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_movimentacao_contaDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaoTipoContaLabel1 = new System.Windows.Forms.Label();
            this.codSituacaoComboBox = new System.Windows.Forms.ComboBox();
            this.situacaoContaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            codBancoLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            planoContaLabel = new System.Windows.Forms.Label();
            pessoaLabel = new System.Windows.Forms.Label();
            dataVencLabel = new System.Windows.Forms.Label();
            valorLabel = new System.Windows.Forms.Label();
            observacaoLabel = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.contaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_contaBindingNavigator)).BeginInit();
            this.tb_contaBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planoContaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pessoaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_movimentacao_contaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_movimentacao_contaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.situacaoContaBindingSource)).BeginInit();
            this.SuspendLayout();
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
            label3.Location = new System.Drawing.Point(136, 70);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(83, 13);
            label3.TabIndex = 36;
            label3.Text = "Código Entrada:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(264, 70);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(75, 13);
            label4.TabIndex = 38;
            label4.Text = "Código Saída:";
            // 
            // planoContaLabel
            // 
            planoContaLabel.AutoSize = true;
            planoContaLabel.Location = new System.Drawing.Point(377, 161);
            planoContaLabel.Name = "planoContaLabel";
            planoContaLabel.Size = new System.Drawing.Size(83, 13);
            planoContaLabel.TabIndex = 41;
            planoContaLabel.Text = "Plano de Conta:";
            // 
            // pessoaLabel
            // 
            pessoaLabel.AutoSize = true;
            pessoaLabel.Location = new System.Drawing.Point(4, 161);
            pessoaLabel.Name = "pessoaLabel";
            pessoaLabel.Size = new System.Drawing.Size(45, 13);
            pessoaLabel.TabIndex = 43;
            pessoaLabel.Text = "Pessoa:";
            // 
            // dataVencLabel
            // 
            dataVencLabel.AutoSize = true;
            dataVencLabel.Location = new System.Drawing.Point(264, 111);
            dataVencLabel.Name = "dataVencLabel";
            dataVencLabel.Size = new System.Drawing.Size(92, 13);
            dataVencLabel.TabIndex = 45;
            dataVencLabel.Text = "Data Vencimento:";
            // 
            // valorLabel
            // 
            valorLabel.AutoSize = true;
            valorLabel.Location = new System.Drawing.Point(377, 111);
            valorLabel.Name = "valorLabel";
            valorLabel.Size = new System.Drawing.Size(34, 13);
            valorLabel.TabIndex = 47;
            valorLabel.Text = "Valor:";
            // 
            // observacaoLabel
            // 
            observacaoLabel.AutoSize = true;
            observacaoLabel.Location = new System.Drawing.Point(7, 206);
            observacaoLabel.Name = "observacaoLabel";
            observacaoLabel.Size = new System.Drawing.Size(68, 13);
            observacaoLabel.TabIndex = 51;
            observacaoLabel.Text = "Observacao:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(375, 70);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(52, 13);
            label5.TabIndex = 57;
            label5.Text = "Situação:";
            // 
            // contaBindingSource
            // 
            this.contaBindingSource.DataSource = typeof(Dominio.Conta);
            this.contaBindingSource.Sort = "codConta";
            this.contaBindingSource.CurrentChanged += new System.EventHandler(this.tb_contaBindingSource_CurrentChanged);
            // 
            // saceDataSet
            // 
            this.saceDataSet.DataSetName = "saceDataSet";
            this.saceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(639, 41);
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
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(304, 415);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 28;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(4, 415);
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
            this.btnCancelar.Location = new System.Drawing.Point(385, 415);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(79, 415);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 25;
            this.btnNovo.Text = "F3 - Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(229, 415);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 27;
            this.btnExcluir.Text = "F5 - Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(154, 415);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 26;
            this.btnEditar.Text = "F4 - Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 276);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Pagamentos:";
            // 
            // tb_contaBindingNavigator
            // 
            this.tb_contaBindingNavigator.AddNewItem = null;
            this.tb_contaBindingNavigator.BindingSource = this.contaBindingSource;
            this.tb_contaBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tb_contaBindingNavigator.DeleteItem = null;
            this.tb_contaBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.tb_contaBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.tb_contaBindingNavigator.Location = new System.Drawing.Point(433, 41);
            this.tb_contaBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tb_contaBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tb_contaBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tb_contaBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tb_contaBindingNavigator.Name = "tb_contaBindingNavigator";
            this.tb_contaBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tb_contaBindingNavigator.Size = new System.Drawing.Size(209, 25);
            this.tb_contaBindingNavigator.TabIndex = 58;
            this.tb_contaBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
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
            // codContaTextBox
            // 
            this.codContaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contaBindingSource, "codConta", true));
            this.codContaTextBox.Location = new System.Drawing.Point(7, 86);
            this.codContaTextBox.Name = "codContaTextBox";
            this.codContaTextBox.ReadOnly = true;
            this.codContaTextBox.Size = new System.Drawing.Size(120, 20);
            this.codContaTextBox.TabIndex = 30;
            this.codContaTextBox.TabStop = false;
            // 
            // codPlanoContaComboBox
            // 
            this.codPlanoContaComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.contaBindingSource, "codPlanoConta", true));
            this.codPlanoContaComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contaBindingSource, "descricaoPlanoConta", true));
            this.codPlanoContaComboBox.DataSource = this.planoContaBindingSource;
            this.codPlanoContaComboBox.DisplayMember = "descricao";
            this.codPlanoContaComboBox.FormattingEnabled = true;
            this.codPlanoContaComboBox.Location = new System.Drawing.Point(378, 181);
            this.codPlanoContaComboBox.Name = "codPlanoContaComboBox";
            this.codPlanoContaComboBox.Size = new System.Drawing.Size(248, 21);
            this.codPlanoContaComboBox.TabIndex = 46;
            this.codPlanoContaComboBox.ValueMember = "codPlanoConta";
            this.codPlanoContaComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codDocumentoPagamentoComboBox_KeyPress);
            this.codPlanoContaComboBox.Leave += new System.EventHandler(this.codPlanoContaComboBox_Leave);
            // 
            // planoContaBindingSource
            // 
            this.planoContaBindingSource.DataSource = typeof(Dominio.PlanoConta);
            // 
            // codPessoaComboBox
            // 
            this.codPessoaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codPessoaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codPessoaComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.contaBindingSource, "codPessoa", true));
            this.codPessoaComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contaBindingSource, "nomePessoa", true));
            this.codPessoaComboBox.DataSource = this.pessoaBindingSource;
            this.codPessoaComboBox.DisplayMember = "nome";
            this.codPessoaComboBox.FormattingEnabled = true;
            this.codPessoaComboBox.Location = new System.Drawing.Point(7, 181);
            this.codPessoaComboBox.Name = "codPessoaComboBox";
            this.codPessoaComboBox.Size = new System.Drawing.Size(358, 21);
            this.codPessoaComboBox.TabIndex = 44;
            this.codPessoaComboBox.ValueMember = "codPessoa";
            this.codPessoaComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codDocumentoPagamentoComboBox_KeyPress);
            this.codPessoaComboBox.Leave += new System.EventHandler(this.codPessoaComboBox_Leave);
            // 
            // pessoaBindingSource
            // 
            this.pessoaBindingSource.DataSource = typeof(Dominio.Pessoa);
            // 
            // codEntradaTextBox
            // 
            this.codEntradaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contaBindingSource, "codEntrada", true));
            this.codEntradaTextBox.Location = new System.Drawing.Point(139, 87);
            this.codEntradaTextBox.Name = "codEntradaTextBox";
            this.codEntradaTextBox.ReadOnly = true;
            this.codEntradaTextBox.Size = new System.Drawing.Size(114, 20);
            this.codEntradaTextBox.TabIndex = 32;
            this.codEntradaTextBox.TabStop = false;
            // 
            // codSaidaTextBox
            // 
            this.codSaidaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contaBindingSource, "codSaida", true));
            this.codSaidaTextBox.Location = new System.Drawing.Point(267, 87);
            this.codSaidaTextBox.Name = "codSaidaTextBox";
            this.codSaidaTextBox.ReadOnly = true;
            this.codSaidaTextBox.Size = new System.Drawing.Size(98, 20);
            this.codSaidaTextBox.TabIndex = 34;
            this.codSaidaTextBox.TabStop = false;
            // 
            // dataVencimentoDateTimePicker
            // 
            this.dataVencimentoDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.contaBindingSource, "dataVencimento", true));
            this.dataVencimentoDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataVencimentoDateTimePicker.Location = new System.Drawing.Point(267, 130);
            this.dataVencimentoDateTimePicker.Name = "dataVencimentoDateTimePicker";
            this.dataVencimentoDateTimePicker.Size = new System.Drawing.Size(98, 20);
            this.dataVencimentoDateTimePicker.TabIndex = 40;
            // 
            // valorTextBox
            // 
            this.valorTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.valorTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contaBindingSource, "valor", true));
            this.valorTextBox.Location = new System.Drawing.Point(377, 130);
            this.valorTextBox.Name = "valorTextBox";
            this.valorTextBox.Size = new System.Drawing.Size(128, 20);
            this.valorTextBox.TabIndex = 42;
            // 
            // observacaoTextBox
            // 
            this.observacaoTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.observacaoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contaBindingSource, "observacao", true));
            this.observacaoTextBox.Location = new System.Drawing.Point(7, 224);
            this.observacaoTextBox.Multiline = true;
            this.observacaoTextBox.Name = "observacaoTextBox";
            this.observacaoTextBox.Size = new System.Drawing.Size(619, 45);
            this.observacaoTextBox.TabIndex = 48;
            // 
            // tb_movimentacao_contaTableAdapter
            // 
            this.tb_movimentacao_contaTableAdapter.ClearBeforeFill = true;
            // 
            // tb_movimentacao_contaBindingSource
            // 
            this.tb_movimentacao_contaBindingSource.DataMember = "tb_movimentacao_conta";
            this.tb_movimentacao_contaBindingSource.DataSource = this.saceDataSet;
            // 
            // tb_movimentacao_contaDataGridView
            // 
            this.tb_movimentacao_contaDataGridView.AllowUserToAddRows = false;
            this.tb_movimentacao_contaDataGridView.AllowUserToDeleteRows = false;
            this.tb_movimentacao_contaDataGridView.AutoGenerateColumns = false;
            this.tb_movimentacao_contaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_movimentacao_contaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn6});
            this.tb_movimentacao_contaDataGridView.DataSource = this.tb_movimentacao_contaBindingSource;
            this.tb_movimentacao_contaDataGridView.Location = new System.Drawing.Point(7, 297);
            this.tb_movimentacao_contaDataGridView.Name = "tb_movimentacao_contaDataGridView";
            this.tb_movimentacao_contaDataGridView.ReadOnly = true;
            this.tb_movimentacao_contaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_movimentacao_contaDataGridView.Size = new System.Drawing.Size(619, 112);
            this.tb_movimentacao_contaDataGridView.TabIndex = 58;
            this.tb_movimentacao_contaDataGridView.TabStop = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "codMovimentacao";
            this.dataGridViewTextBoxColumn1.FillWeight = 150F;
            this.dataGridViewTextBoxColumn1.HeaderText = "codMovimentacao";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "descricaoTipoMovimento";
            this.dataGridViewTextBoxColumn9.HeaderText = "Movimento";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "dataHora";
            this.dataGridViewTextBoxColumn7.HeaderText = "Data";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "nomeResponsavel";
            this.dataGridViewTextBoxColumn10.HeaderText = "Responsável";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "valor";
            this.dataGridViewTextBoxColumn6.HeaderText = "Valor";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // descricaoTipoContaLabel1
            // 
            this.descricaoTipoContaLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.planoContaBindingSource, "descricaoTipoConta", true));
            this.descricaoTipoContaLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descricaoTipoContaLabel1.Location = new System.Drawing.Point(526, 127);
            this.descricaoTipoContaLabel1.Name = "descricaoTipoContaLabel1";
            this.descricaoTipoContaLabel1.Size = new System.Drawing.Size(113, 35);
            this.descricaoTipoContaLabel1.TabIndex = 60;
            this.descricaoTipoContaLabel1.Text = "PAGAR";
            // 
            // codSituacaoComboBox
            // 
            this.codSituacaoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.contaBindingSource, "CodSituacao", true));
            this.codSituacaoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contaBindingSource, "DescricaoSituacao", true));
            this.codSituacaoComboBox.DataSource = this.situacaoContaBindingSource;
            this.codSituacaoComboBox.DisplayMember = "Descricao";
            this.codSituacaoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codSituacaoComboBox.Enabled = false;
            this.codSituacaoComboBox.FormattingEnabled = true;
            this.codSituacaoComboBox.Location = new System.Drawing.Point(380, 85);
            this.codSituacaoComboBox.Name = "codSituacaoComboBox";
            this.codSituacaoComboBox.Size = new System.Drawing.Size(224, 21);
            this.codSituacaoComboBox.TabIndex = 61;
            this.codSituacaoComboBox.ValueMember = "CodSituacao";
            // 
            // situacaoContaBindingSource
            // 
            this.situacaoContaBindingSource.DataSource = typeof(Dominio.SituacaoConta);
            // 
            // FrmConta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 458);
            this.Controls.Add(this.codSituacaoComboBox);
            this.Controls.Add(this.descricaoTipoContaLabel1);
            this.Controls.Add(this.tb_movimentacao_contaDataGridView);
            this.Controls.Add(this.tb_contaBindingNavigator);
            this.Controls.Add(this.codContaTextBox);
            this.Controls.Add(this.codPlanoContaComboBox);
            this.Controls.Add(this.codPessoaComboBox);
            this.Controls.Add(this.codEntradaTextBox);
            this.Controls.Add(this.codSaidaTextBox);
            this.Controls.Add(this.dataVencimentoDateTimePicker);
            this.Controls.Add(this.valorTextBox);
            this.Controls.Add(this.observacaoTextBox);
            this.Controls.Add(label5);
            this.Controls.Add(observacaoLabel);
            this.Controls.Add(valorLabel);
            this.Controls.Add(dataVencLabel);
            this.Controls.Add(pessoaLabel);
            this.Controls.Add(planoContaLabel);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(codBancoLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.panel1);
            this.KeyPreview = true;
            this.Name = "FrmConta";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Contas a Pagar e a Receber";
            this.Load += new System.EventHandler(this.FrmContas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmContas_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.contaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_contaBindingNavigator)).EndInit();
            this.tb_contaBindingNavigator.ResumeLayout(false);
            this.tb_contaBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planoContaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pessoaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_movimentacao_contaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_movimentacao_contaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.situacaoContaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label label2;
        private Dados.saceDataSet saceDataSet;
        private System.Windows.Forms.BindingSource contaBindingSource;
        private System.Windows.Forms.BindingNavigator tb_contaBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.TextBox codContaTextBox;
        private System.Windows.Forms.ComboBox codPlanoContaComboBox;
        private System.Windows.Forms.ComboBox codPessoaComboBox;
        private System.Windows.Forms.TextBox codEntradaTextBox;
        private System.Windows.Forms.TextBox codSaidaTextBox;
        private System.Windows.Forms.DateTimePicker dataVencimentoDateTimePicker;
        private System.Windows.Forms.TextBox valorTextBox;
        private System.Windows.Forms.TextBox observacaoTextBox;
        private System.Windows.Forms.BindingSource pessoaBindingSource;
        private System.Windows.Forms.BindingSource planoContaBindingSource;
        private Dados.saceDataSetTableAdapters.tb_movimentacao_contaTableAdapter tb_movimentacao_contaTableAdapter;
        private System.Windows.Forms.BindingSource tb_movimentacao_contaBindingSource;
        private System.Windows.Forms.DataGridView tb_movimentacao_contaDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Label descricaoTipoContaLabel1;
        private System.Windows.Forms.ComboBox codSituacaoComboBox;
        private System.Windows.Forms.BindingSource situacaoContaBindingSource;
    }
}