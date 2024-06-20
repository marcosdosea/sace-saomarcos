namespace Sace
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
            components = new System.ComponentModel.Container();
            Label codBancoLabel;
            Label label3;
            Label label4;
            Label planoContaLabel;
            Label pessoaLabel;
            Label dataVencLabel;
            Label valorLabel;
            Label observacaoLabel;
            Label label5;
            Label numeroDocumentoLabel;
            Label formatoContaLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConta));
            contaBindingSource = new BindingSource(components);
            panel1 = new Panel();
            label1 = new Label();
            btnSalvar = new Button();
            btnBuscar = new Button();
            btnCancelar = new Button();
            btnNovo = new Button();
            btnExcluir = new Button();
            btnEditar = new Button();
            label2 = new Label();
            tb_contaBindingNavigator = new BindingNavigator(components);
            bindingNavigatorCountItem = new ToolStripLabel();
            bindingNavigatorMoveFirstItem = new ToolStripButton();
            bindingNavigatorMovePreviousItem = new ToolStripButton();
            bindingNavigatorSeparator = new ToolStripSeparator();
            bindingNavigatorPositionItem = new ToolStripTextBox();
            bindingNavigatorSeparator1 = new ToolStripSeparator();
            bindingNavigatorMoveNextItem = new ToolStripButton();
            bindingNavigatorMoveLastItem = new ToolStripButton();
            bindingNavigatorSeparator2 = new ToolStripSeparator();
            codContaTextBox = new TextBox();
            codPlanoContaComboBox = new ComboBox();
            planoContaBindingSource = new BindingSource(components);
            codPessoaComboBox = new ComboBox();
            pessoaBindingSource = new BindingSource(components);
            codEntradaTextBox = new TextBox();
            codSaidaTextBox = new TextBox();
            dataVencimentoDateTimePicker = new DateTimePicker();
            valorTextBox = new TextBox();
            observacaoTextBox = new TextBox();
            movimentacaoContaBindingSource = new BindingSource(components);
            tb_movimentacao_contaDataGridView = new DataGridView();
            codMovimentacaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            DescricaoTipoMovimentacao = new DataGridViewTextBoxColumn();
            dataHoraDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            NomeResponsavel = new DataGridViewTextBoxColumn();
            valorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            descricaoTipoContaLabel1 = new Label();
            codSituacaoComboBox = new ComboBox();
            situacaoContaBindingSource = new BindingSource(components);
            numeroDocumentoTextBox = new TextBox();
            formatoContaComboBox = new ComboBox();
            codBancoLabel = new Label();
            label3 = new Label();
            label4 = new Label();
            planoContaLabel = new Label();
            pessoaLabel = new Label();
            dataVencLabel = new Label();
            valorLabel = new Label();
            observacaoLabel = new Label();
            label5 = new Label();
            numeroDocumentoLabel = new Label();
            formatoContaLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)contaBindingSource).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tb_contaBindingNavigator).BeginInit();
            tb_contaBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)planoContaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pessoaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)movimentacaoContaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tb_movimentacao_contaDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)situacaoContaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // codBancoLabel
            // 
            codBancoLabel.AutoSize = true;
            codBancoLabel.Location = new Point(5, 108);
            codBancoLabel.Margin = new Padding(4, 0, 4, 0);
            codBancoLabel.Name = "codBancoLabel";
            codBancoLabel.Size = new Size(61, 20);
            codBancoLabel.TabIndex = 32;
            codBancoLabel.Text = "Código:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(181, 108);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(116, 20);
            label3.TabIndex = 36;
            label3.Text = "Código Entrada:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(352, 108);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(102, 20);
            label4.TabIndex = 38;
            label4.Text = "Código Saída:";
            // 
            // planoContaLabel
            // 
            planoContaLabel.AutoSize = true;
            planoContaLabel.Location = new Point(503, 248);
            planoContaLabel.Margin = new Padding(4, 0, 4, 0);
            planoContaLabel.Name = "planoContaLabel";
            planoContaLabel.Size = new Size(113, 20);
            planoContaLabel.TabIndex = 41;
            planoContaLabel.Text = "Plano de Conta:";
            // 
            // pessoaLabel
            // 
            pessoaLabel.AutoSize = true;
            pessoaLabel.Location = new Point(5, 248);
            pessoaLabel.Margin = new Padding(4, 0, 4, 0);
            pessoaLabel.Name = "pessoaLabel";
            pessoaLabel.Size = new Size(56, 20);
            pessoaLabel.TabIndex = 43;
            pessoaLabel.Text = "Pessoa:";
            // 
            // dataVencLabel
            // 
            dataVencLabel.AutoSize = true;
            dataVencLabel.Location = new Point(352, 171);
            dataVencLabel.Margin = new Padding(4, 0, 4, 0);
            dataVencLabel.Name = "dataVencLabel";
            dataVencLabel.Size = new Size(126, 20);
            dataVencLabel.TabIndex = 45;
            dataVencLabel.Text = "Data Vencimento:";
            // 
            // valorLabel
            // 
            valorLabel.AutoSize = true;
            valorLabel.Location = new Point(503, 171);
            valorLabel.Margin = new Padding(4, 0, 4, 0);
            valorLabel.Name = "valorLabel";
            valorLabel.Size = new Size(46, 20);
            valorLabel.TabIndex = 47;
            valorLabel.Text = "Valor:";
            // 
            // observacaoLabel
            // 
            observacaoLabel.AutoSize = true;
            observacaoLabel.Location = new Point(9, 317);
            observacaoLabel.Margin = new Padding(4, 0, 4, 0);
            observacaoLabel.Name = "observacaoLabel";
            observacaoLabel.Size = new Size(90, 20);
            observacaoLabel.TabIndex = 51;
            observacaoLabel.Text = "Observacao:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(500, 108);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(69, 20);
            label5.TabIndex = 57;
            label5.Text = "Situação:";
            // 
            // numeroDocumentoLabel
            // 
            numeroDocumentoLabel.AutoSize = true;
            numeroDocumentoLabel.Location = new Point(181, 169);
            numeroDocumentoLabel.Margin = new Padding(4, 0, 4, 0);
            numeroDocumentoLabel.Name = "numeroDocumentoLabel";
            numeroDocumentoLabel.Size = new Size(148, 20);
            numeroDocumentoLabel.TabIndex = 61;
            numeroDocumentoLabel.Text = "Numero Documento:";
            // 
            // formatoContaLabel
            // 
            formatoContaLabel.AutoSize = true;
            formatoContaLabel.Location = new Point(5, 171);
            formatoContaLabel.Margin = new Padding(4, 0, 4, 0);
            formatoContaLabel.Name = "formatoContaLabel";
            formatoContaLabel.Size = new Size(111, 20);
            formatoContaLabel.TabIndex = 62;
            formatoContaLabel.Text = "Formato Conta:";
            // 
            // contaBindingSource
            // 
            contaBindingSource.DataSource = typeof(Dominio.Conta);
            contaBindingSource.Sort = "codConta";
            contaBindingSource.CurrentChanged += tb_contaBindingSource_CurrentChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, -2);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(852, 63);
            panel1.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(4, 14);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(381, 28);
            label1.TabIndex = 0;
            label1.Text = "Cadastro de Contas a Pagar e a Receber";
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(405, 638);
            btnSalvar.Margin = new Padding(4, 5, 4, 5);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(108, 35);
            btnSalvar.TabIndex = 28;
            btnSalvar.Text = "F6 - Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(5, 638);
            btnBuscar.Margin = new Padding(4, 5, 4, 5);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(100, 35);
            btnBuscar.TabIndex = 24;
            btnBuscar.Text = "F2 - Buscar";
            btnBuscar.TextAlign = ContentAlignment.MiddleLeft;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(513, 638);
            btnCancelar.Margin = new Padding(4, 5, 4, 5);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(112, 35);
            btnCancelar.TabIndex = 29;
            btnCancelar.Text = "Esc - Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(105, 638);
            btnNovo.Margin = new Padding(4, 5, 4, 5);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(100, 35);
            btnNovo.TabIndex = 25;
            btnNovo.Text = "F3 - Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(305, 638);
            btnExcluir.Margin = new Padding(4, 5, 4, 5);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(100, 35);
            btnExcluir.TabIndex = 27;
            btnExcluir.Text = "F5 - Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(205, 638);
            btnEditar.Margin = new Padding(4, 5, 4, 5);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(100, 35);
            btnEditar.TabIndex = 26;
            btnEditar.Text = "F4 - Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 425);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(93, 20);
            label2.TabIndex = 31;
            label2.Text = "Pagamentos:";
            // 
            // tb_contaBindingNavigator
            // 
            tb_contaBindingNavigator.AddNewItem = null;
            tb_contaBindingNavigator.BindingSource = contaBindingSource;
            tb_contaBindingNavigator.CountItem = bindingNavigatorCountItem;
            tb_contaBindingNavigator.DeleteItem = null;
            tb_contaBindingNavigator.Dock = DockStyle.None;
            tb_contaBindingNavigator.ImageScalingSize = new Size(20, 20);
            tb_contaBindingNavigator.Items.AddRange(new ToolStripItem[] { bindingNavigatorMoveFirstItem, bindingNavigatorMovePreviousItem, bindingNavigatorSeparator, bindingNavigatorPositionItem, bindingNavigatorCountItem, bindingNavigatorSeparator1, bindingNavigatorMoveNextItem, bindingNavigatorMoveLastItem, bindingNavigatorSeparator2 });
            tb_contaBindingNavigator.Location = new Point(577, 63);
            tb_contaBindingNavigator.MoveFirstItem = bindingNavigatorMoveFirstItem;
            tb_contaBindingNavigator.MoveLastItem = bindingNavigatorMoveLastItem;
            tb_contaBindingNavigator.MoveNextItem = bindingNavigatorMoveNextItem;
            tb_contaBindingNavigator.MovePreviousItem = bindingNavigatorMovePreviousItem;
            tb_contaBindingNavigator.Name = "tb_contaBindingNavigator";
            tb_contaBindingNavigator.PositionItem = bindingNavigatorPositionItem;
            tb_contaBindingNavigator.Size = new Size(262, 27);
            tb_contaBindingNavigator.TabIndex = 58;
            tb_contaBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            bindingNavigatorCountItem.Size = new Size(48, 24);
            bindingNavigatorCountItem.Text = "de {0}";
            bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            bindingNavigatorMoveFirstItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            bindingNavigatorMoveFirstItem.Image = (Image)resources.GetObject("bindingNavigatorMoveFirstItem.Image");
            bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMoveFirstItem.Size = new Size(29, 24);
            bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            bindingNavigatorMovePreviousItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            bindingNavigatorMovePreviousItem.Image = (Image)resources.GetObject("bindingNavigatorMovePreviousItem.Image");
            bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMovePreviousItem.Size = new Size(29, 24);
            bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            bindingNavigatorSeparator.Size = new Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            bindingNavigatorPositionItem.AccessibleName = "Position";
            bindingNavigatorPositionItem.AutoSize = false;
            bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            bindingNavigatorPositionItem.Size = new Size(65, 27);
            bindingNavigatorPositionItem.Text = "0";
            bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            bindingNavigatorSeparator1.Size = new Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            bindingNavigatorMoveNextItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            bindingNavigatorMoveNextItem.Image = (Image)resources.GetObject("bindingNavigatorMoveNextItem.Image");
            bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMoveNextItem.Size = new Size(29, 24);
            bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            bindingNavigatorMoveLastItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            bindingNavigatorMoveLastItem.Image = (Image)resources.GetObject("bindingNavigatorMoveLastItem.Image");
            bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMoveLastItem.Size = new Size(29, 24);
            bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            bindingNavigatorSeparator2.Size = new Size(6, 27);
            // 
            // codContaTextBox
            // 
            codContaTextBox.DataBindings.Add(new Binding("Text", contaBindingSource, "CodConta", true));
            codContaTextBox.Location = new Point(9, 132);
            codContaTextBox.Margin = new Padding(4, 5, 4, 5);
            codContaTextBox.Name = "codContaTextBox";
            codContaTextBox.ReadOnly = true;
            codContaTextBox.Size = new Size(159, 27);
            codContaTextBox.TabIndex = 30;
            codContaTextBox.TabStop = false;
            // 
            // codPlanoContaComboBox
            // 
            codPlanoContaComboBox.DataBindings.Add(new Binding("SelectedValue", contaBindingSource, "CodPlanoConta", true));
            codPlanoContaComboBox.DataSource = planoContaBindingSource;
            codPlanoContaComboBox.DisplayMember = "Descricao";
            codPlanoContaComboBox.FormattingEnabled = true;
            codPlanoContaComboBox.Location = new Point(504, 278);
            codPlanoContaComboBox.Margin = new Padding(4, 5, 4, 5);
            codPlanoContaComboBox.Name = "codPlanoContaComboBox";
            codPlanoContaComboBox.Size = new Size(329, 28);
            codPlanoContaComboBox.TabIndex = 46;
            codPlanoContaComboBox.ValueMember = "CodPlanoConta";
            codPlanoContaComboBox.KeyPress += codDocumentoPagamentoComboBox_KeyPress;
            codPlanoContaComboBox.Leave += codPlanoContaComboBox_Leave;
            // 
            // planoContaBindingSource
            // 
            planoContaBindingSource.DataSource = typeof(Dominio.PlanoConta);
            // 
            // codPessoaComboBox
            // 
            codPessoaComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            codPessoaComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            codPessoaComboBox.DataBindings.Add(new Binding("SelectedValue", contaBindingSource, "CodPessoa", true));
            codPessoaComboBox.DataSource = pessoaBindingSource;
            codPessoaComboBox.DisplayMember = "Nome";
            codPessoaComboBox.FormattingEnabled = true;
            codPessoaComboBox.Location = new Point(9, 278);
            codPessoaComboBox.Margin = new Padding(4, 5, 4, 5);
            codPessoaComboBox.Name = "codPessoaComboBox";
            codPessoaComboBox.Size = new Size(476, 28);
            codPessoaComboBox.TabIndex = 44;
            codPessoaComboBox.ValueMember = "CodPessoa";
            codPessoaComboBox.KeyPress += codDocumentoPagamentoComboBox_KeyPress;
            codPessoaComboBox.Leave += codPessoaComboBox_Leave;
            // 
            // pessoaBindingSource
            // 
            pessoaBindingSource.AllowNew = false;
            pessoaBindingSource.DataSource = typeof(Dominio.Pessoa);
            // 
            // codEntradaTextBox
            // 
            codEntradaTextBox.DataBindings.Add(new Binding("Text", contaBindingSource, "CodEntrada", true));
            codEntradaTextBox.Location = new Point(185, 134);
            codEntradaTextBox.Margin = new Padding(4, 5, 4, 5);
            codEntradaTextBox.Name = "codEntradaTextBox";
            codEntradaTextBox.ReadOnly = true;
            codEntradaTextBox.Size = new Size(151, 27);
            codEntradaTextBox.TabIndex = 32;
            codEntradaTextBox.TabStop = false;
            // 
            // codSaidaTextBox
            // 
            codSaidaTextBox.DataBindings.Add(new Binding("Text", contaBindingSource, "CodSaida", true));
            codSaidaTextBox.Location = new Point(356, 134);
            codSaidaTextBox.Margin = new Padding(4, 5, 4, 5);
            codSaidaTextBox.Name = "codSaidaTextBox";
            codSaidaTextBox.ReadOnly = true;
            codSaidaTextBox.Size = new Size(129, 27);
            codSaidaTextBox.TabIndex = 34;
            codSaidaTextBox.TabStop = false;
            // 
            // dataVencimentoDateTimePicker
            // 
            dataVencimentoDateTimePicker.DataBindings.Add(new Binding("Value", contaBindingSource, "DataVencimento", true));
            dataVencimentoDateTimePicker.DataBindings.Add(new Binding("Text", contaBindingSource, "DataVencimento", true));
            dataVencimentoDateTimePicker.Format = DateTimePickerFormat.Short;
            dataVencimentoDateTimePicker.Location = new Point(356, 200);
            dataVencimentoDateTimePicker.Margin = new Padding(4, 5, 4, 5);
            dataVencimentoDateTimePicker.Name = "dataVencimentoDateTimePicker";
            dataVencimentoDateTimePicker.Size = new Size(129, 27);
            dataVencimentoDateTimePicker.TabIndex = 40;
            // 
            // valorTextBox
            // 
            valorTextBox.CharacterCasing = CharacterCasing.Upper;
            valorTextBox.DataBindings.Add(new Binding("Text", contaBindingSource, "Valor", true));
            valorTextBox.Location = new Point(503, 200);
            valorTextBox.Margin = new Padding(4, 5, 4, 5);
            valorTextBox.Name = "valorTextBox";
            valorTextBox.Size = new Size(169, 27);
            valorTextBox.TabIndex = 42;
            // 
            // observacaoTextBox
            // 
            observacaoTextBox.CharacterCasing = CharacterCasing.Upper;
            observacaoTextBox.DataBindings.Add(new Binding("Text", contaBindingSource, "Observacao", true));
            observacaoTextBox.Location = new Point(9, 345);
            observacaoTextBox.Margin = new Padding(4, 5, 4, 5);
            observacaoTextBox.Multiline = true;
            observacaoTextBox.Name = "observacaoTextBox";
            observacaoTextBox.Size = new Size(824, 67);
            observacaoTextBox.TabIndex = 48;
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
            tb_movimentacao_contaDataGridView.Columns.AddRange(new DataGridViewColumn[] { codMovimentacaoDataGridViewTextBoxColumn, DescricaoTipoMovimentacao, dataHoraDataGridViewTextBoxColumn, NomeResponsavel, valorDataGridViewTextBoxColumn });
            tb_movimentacao_contaDataGridView.DataSource = movimentacaoContaBindingSource;
            tb_movimentacao_contaDataGridView.Location = new Point(9, 457);
            tb_movimentacao_contaDataGridView.Margin = new Padding(4, 5, 4, 5);
            tb_movimentacao_contaDataGridView.Name = "tb_movimentacao_contaDataGridView";
            tb_movimentacao_contaDataGridView.ReadOnly = true;
            tb_movimentacao_contaDataGridView.RowHeadersWidth = 51;
            tb_movimentacao_contaDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tb_movimentacao_contaDataGridView.Size = new Size(825, 172);
            tb_movimentacao_contaDataGridView.TabIndex = 58;
            tb_movimentacao_contaDataGridView.TabStop = false;
            // 
            // codMovimentacaoDataGridViewTextBoxColumn
            // 
            codMovimentacaoDataGridViewTextBoxColumn.DataPropertyName = "CodMovimentacao";
            codMovimentacaoDataGridViewTextBoxColumn.HeaderText = "CodMovimentacao";
            codMovimentacaoDataGridViewTextBoxColumn.MinimumWidth = 6;
            codMovimentacaoDataGridViewTextBoxColumn.Name = "codMovimentacaoDataGridViewTextBoxColumn";
            codMovimentacaoDataGridViewTextBoxColumn.ReadOnly = true;
            codMovimentacaoDataGridViewTextBoxColumn.Visible = false;
            codMovimentacaoDataGridViewTextBoxColumn.Width = 125;
            // 
            // DescricaoTipoMovimentacao
            // 
            DescricaoTipoMovimentacao.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DescricaoTipoMovimentacao.DataPropertyName = "DescricaoTipoMovimentacao";
            DescricaoTipoMovimentacao.HeaderText = "Movimentacao";
            DescricaoTipoMovimentacao.MinimumWidth = 6;
            DescricaoTipoMovimentacao.Name = "DescricaoTipoMovimentacao";
            DescricaoTipoMovimentacao.ReadOnly = true;
            // 
            // dataHoraDataGridViewTextBoxColumn
            // 
            dataHoraDataGridViewTextBoxColumn.DataPropertyName = "DataHora";
            dataHoraDataGridViewTextBoxColumn.HeaderText = "Data / Hora";
            dataHoraDataGridViewTextBoxColumn.MinimumWidth = 6;
            dataHoraDataGridViewTextBoxColumn.Name = "dataHoraDataGridViewTextBoxColumn";
            dataHoraDataGridViewTextBoxColumn.ReadOnly = true;
            dataHoraDataGridViewTextBoxColumn.Width = 125;
            // 
            // NomeResponsavel
            // 
            NomeResponsavel.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            NomeResponsavel.DataPropertyName = "NomeResponsavel";
            NomeResponsavel.HeaderText = "Responsável";
            NomeResponsavel.MinimumWidth = 6;
            NomeResponsavel.Name = "NomeResponsavel";
            NomeResponsavel.ReadOnly = true;
            // 
            // valorDataGridViewTextBoxColumn
            // 
            valorDataGridViewTextBoxColumn.DataPropertyName = "Valor";
            valorDataGridViewTextBoxColumn.HeaderText = "Valor (R$)";
            valorDataGridViewTextBoxColumn.MinimumWidth = 6;
            valorDataGridViewTextBoxColumn.Name = "valorDataGridViewTextBoxColumn";
            valorDataGridViewTextBoxColumn.ReadOnly = true;
            valorDataGridViewTextBoxColumn.Width = 125;
            // 
            // descricaoTipoContaLabel1
            // 
            descricaoTipoContaLabel1.DataBindings.Add(new Binding("Text", planoContaBindingSource, "DescricaoTipoConta", true));
            descricaoTipoContaLabel1.Font = new Font("Microsoft Sans Serif", 15.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            descricaoTipoContaLabel1.Location = new Point(701, 195);
            descricaoTipoContaLabel1.Margin = new Padding(4, 0, 4, 0);
            descricaoTipoContaLabel1.Name = "descricaoTipoContaLabel1";
            descricaoTipoContaLabel1.Size = new Size(151, 54);
            descricaoTipoContaLabel1.TabIndex = 60;
            descricaoTipoContaLabel1.Text = "PAGAR";
            // 
            // codSituacaoComboBox
            // 
            codSituacaoComboBox.DataBindings.Add(new Binding("Text", contaBindingSource, "DescricaoSituacao", true));
            codSituacaoComboBox.DataBindings.Add(new Binding("SelectedValue", contaBindingSource, "CodSituacao", true));
            codSituacaoComboBox.DataSource = situacaoContaBindingSource;
            codSituacaoComboBox.DisplayMember = "Descricao";
            codSituacaoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            codSituacaoComboBox.Enabled = false;
            codSituacaoComboBox.FormattingEnabled = true;
            codSituacaoComboBox.Location = new Point(507, 131);
            codSituacaoComboBox.Margin = new Padding(4, 5, 4, 5);
            codSituacaoComboBox.Name = "codSituacaoComboBox";
            codSituacaoComboBox.Size = new Size(297, 28);
            codSituacaoComboBox.TabIndex = 61;
            codSituacaoComboBox.ValueMember = "CodSituacao";
            // 
            // situacaoContaBindingSource
            // 
            situacaoContaBindingSource.DataSource = typeof(Dominio.SituacaoConta);
            // 
            // numeroDocumentoTextBox
            // 
            numeroDocumentoTextBox.DataBindings.Add(new Binding("Text", contaBindingSource, "NumeroDocumento", true));
            numeroDocumentoTextBox.Location = new Point(188, 200);
            numeroDocumentoTextBox.Margin = new Padding(4, 5, 4, 5);
            numeroDocumentoTextBox.Name = "numeroDocumentoTextBox";
            numeroDocumentoTextBox.Size = new Size(132, 27);
            numeroDocumentoTextBox.TabIndex = 62;
            // 
            // formatoContaComboBox
            // 
            formatoContaComboBox.DataBindings.Add(new Binding("Text", contaBindingSource, "FormatoConta", true));
            formatoContaComboBox.FormattingEnabled = true;
            formatoContaComboBox.Items.AddRange(new object[] { "FICHA", "BOLETO", "CARTAO", "CHEQUE" });
            formatoContaComboBox.Location = new Point(8, 195);
            formatoContaComboBox.Margin = new Padding(4, 5, 4, 5);
            formatoContaComboBox.Name = "formatoContaComboBox";
            formatoContaComboBox.Size = new Size(160, 28);
            formatoContaComboBox.TabIndex = 63;
            // 
            // FrmConta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(852, 705);
            Controls.Add(formatoContaComboBox);
            Controls.Add(formatoContaLabel);
            Controls.Add(numeroDocumentoLabel);
            Controls.Add(numeroDocumentoTextBox);
            Controls.Add(codSituacaoComboBox);
            Controls.Add(descricaoTipoContaLabel1);
            Controls.Add(tb_movimentacao_contaDataGridView);
            Controls.Add(tb_contaBindingNavigator);
            Controls.Add(codContaTextBox);
            Controls.Add(codPlanoContaComboBox);
            Controls.Add(codPessoaComboBox);
            Controls.Add(codEntradaTextBox);
            Controls.Add(codSaidaTextBox);
            Controls.Add(dataVencimentoDateTimePicker);
            Controls.Add(valorTextBox);
            Controls.Add(observacaoTextBox);
            Controls.Add(label5);
            Controls.Add(observacaoLabel);
            Controls.Add(valorLabel);
            Controls.Add(dataVencLabel);
            Controls.Add(pessoaLabel);
            Controls.Add(planoContaLabel);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(codBancoLabel);
            Controls.Add(label2);
            Controls.Add(btnSalvar);
            Controls.Add(btnBuscar);
            Controls.Add(btnCancelar);
            Controls.Add(btnNovo);
            Controls.Add(btnExcluir);
            Controls.Add(btnEditar);
            Controls.Add(panel1);
            KeyPreview = true;
            Margin = new Padding(4, 5, 4, 5);
            Name = "FrmConta";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Contas a Pagar e a Receber";
            Load += FrmContas_Load;
            KeyDown += FrmContas_KeyDown;
            ((System.ComponentModel.ISupportInitialize)contaBindingSource).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tb_contaBindingNavigator).EndInit();
            tb_contaBindingNavigator.ResumeLayout(false);
            tb_contaBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)planoContaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)pessoaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)movimentacaoContaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)tb_movimentacao_contaDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)situacaoContaBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.BindingSource movimentacaoContaBindingSource;
        private System.Windows.Forms.DataGridView tb_movimentacao_contaDataGridView;
        private System.Windows.Forms.Label descricaoTipoContaLabel1;
        private System.Windows.Forms.ComboBox codSituacaoComboBox;
        private System.Windows.Forms.BindingSource situacaoContaBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn codMovimentacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescricaoTipoMovimentacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataHoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeResponsavel;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox numeroDocumentoTextBox;
        private System.Windows.Forms.ComboBox formatoContaComboBox;
    }
}