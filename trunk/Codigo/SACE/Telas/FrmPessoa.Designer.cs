namespace SACE.Telas
{
    partial class FrmPessoa
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
            System.Windows.Forms.Label codPessoaLabel;
            System.Windows.Forms.Label nomeLabel;
            System.Windows.Forms.Label enderecoLabel;
            System.Windows.Forms.Label cpfLabel;
            System.Windows.Forms.Label bairroLabel;
            System.Windows.Forms.Label cidadeLabel;
            System.Windows.Forms.Label fone1Label;
            System.Windows.Forms.Label fone2Label;
            System.Windows.Forms.Label limiteCompraLabel;
            System.Windows.Forms.Label valorComissaoLabel;
            System.Windows.Forms.Label observacaoLabel;
            System.Windows.Forms.Label cepLabel;
            System.Windows.Forms.Label ufLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPessoa));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.saceDataSet = new SACE.Dados.saceDataSet();
            this.tb_pessoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_pessoaTableAdapter = new SACE.Dados.saceDataSetTableAdapters.tb_pessoaTableAdapter();
            this.tableAdapterManager = new SACE.Dados.saceDataSetTableAdapters.TableAdapterManager();
            this.tb_pessoaBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.codPessoaTextBox = new System.Windows.Forms.TextBox();
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.cpfTextBox = new System.Windows.Forms.TextBox();
            this.bairroTextBox = new System.Windows.Forms.TextBox();
            this.cidadeTextBox = new System.Windows.Forms.TextBox();
            this.fone1TextBox = new System.Windows.Forms.TextBox();
            this.fone2TextBox = new System.Windows.Forms.TextBox();
            this.limiteCompraTextBox = new System.Windows.Forms.TextBox();
            this.valorComissaoTextBox = new System.Windows.Forms.TextBox();
            this.observacaoTextBox = new System.Windows.Forms.TextBox();
            this.cepTextBox = new System.Windows.Forms.TextBox();
            this.enderecoTextBox = new System.Windows.Forms.TextBox();
            this.ufTextBox = new System.Windows.Forms.TextBox();
            codPessoaLabel = new System.Windows.Forms.Label();
            nomeLabel = new System.Windows.Forms.Label();
            enderecoLabel = new System.Windows.Forms.Label();
            cpfLabel = new System.Windows.Forms.Label();
            bairroLabel = new System.Windows.Forms.Label();
            cidadeLabel = new System.Windows.Forms.Label();
            fone1Label = new System.Windows.Forms.Label();
            fone2Label = new System.Windows.Forms.Label();
            limiteCompraLabel = new System.Windows.Forms.Label();
            valorComissaoLabel = new System.Windows.Forms.Label();
            observacaoLabel = new System.Windows.Forms.Label();
            cepLabel = new System.Windows.Forms.Label();
            ufLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_pessoaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_pessoaBindingNavigator)).BeginInit();
            this.tb_pessoaBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // codPessoaLabel
            // 
            codPessoaLabel.AutoSize = true;
            codPessoaLabel.Location = new System.Drawing.Point(4, 69);
            codPessoaLabel.Name = "codPessoaLabel";
            codPessoaLabel.Size = new System.Drawing.Size(43, 13);
            codPessoaLabel.TabIndex = 21;
            codPessoaLabel.Text = "Código:";
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Location = new System.Drawing.Point(115, 69);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new System.Drawing.Size(38, 13);
            nomeLabel.TabIndex = 23;
            nomeLabel.Text = "Nome:";
            // 
            // enderecoLabel
            // 
            enderecoLabel.AutoSize = true;
            enderecoLabel.Location = new System.Drawing.Point(115, 111);
            enderecoLabel.Name = "enderecoLabel";
            enderecoLabel.Size = new System.Drawing.Size(56, 13);
            enderecoLabel.TabIndex = 25;
            enderecoLabel.Text = "Endereço:";
            // 
            // cpfLabel
            // 
            cpfLabel.AutoSize = true;
            cpfLabel.Location = new System.Drawing.Point(4, 111);
            cpfLabel.Name = "cpfLabel";
            cpfLabel.Size = new System.Drawing.Size(30, 13);
            cpfLabel.TabIndex = 27;
            cpfLabel.Text = "CPF:";
            // 
            // bairroLabel
            // 
            bairroLabel.AutoSize = true;
            bairroLabel.Location = new System.Drawing.Point(115, 160);
            bairroLabel.Name = "bairroLabel";
            bairroLabel.Size = new System.Drawing.Size(37, 13);
            bairroLabel.TabIndex = 31;
            bairroLabel.Text = "Bairro:";
            // 
            // cidadeLabel
            // 
            cidadeLabel.AutoSize = true;
            cidadeLabel.Location = new System.Drawing.Point(268, 159);
            cidadeLabel.Name = "cidadeLabel";
            cidadeLabel.Size = new System.Drawing.Size(43, 13);
            cidadeLabel.TabIndex = 33;
            cidadeLabel.Text = "Cidade:";
            // 
            // fone1Label
            // 
            fone1Label.AutoSize = true;
            fone1Label.Location = new System.Drawing.Point(4, 209);
            fone1Label.Name = "fone1Label";
            fone1Label.Size = new System.Drawing.Size(40, 13);
            fone1Label.TabIndex = 35;
            fone1Label.Text = "Fone1:";
            // 
            // fone2Label
            // 
            fone2Label.AutoSize = true;
            fone2Label.Location = new System.Drawing.Point(114, 209);
            fone2Label.Name = "fone2Label";
            fone2Label.Size = new System.Drawing.Size(40, 13);
            fone2Label.TabIndex = 37;
            fone2Label.Text = "Fone2:";
            // 
            // limiteCompraLabel
            // 
            limiteCompraLabel.AutoSize = true;
            limiteCompraLabel.Location = new System.Drawing.Point(240, 209);
            limiteCompraLabel.Name = "limiteCompraLabel";
            limiteCompraLabel.Size = new System.Drawing.Size(76, 13);
            limiteCompraLabel.TabIndex = 39;
            limiteCompraLabel.Text = "Limite Compra:";
            // 
            // valorComissaoLabel
            // 
            valorComissaoLabel.AutoSize = true;
            valorComissaoLabel.Location = new System.Drawing.Point(397, 209);
            valorComissaoLabel.Name = "valorComissaoLabel";
            valorComissaoLabel.Size = new System.Drawing.Size(66, 13);
            valorComissaoLabel.TabIndex = 41;
            valorComissaoLabel.Text = "% Comissão:";
            // 
            // observacaoLabel
            // 
            observacaoLabel.AutoSize = true;
            observacaoLabel.Location = new System.Drawing.Point(4, 258);
            observacaoLabel.Name = "observacaoLabel";
            observacaoLabel.Size = new System.Drawing.Size(68, 13);
            observacaoLabel.TabIndex = 43;
            observacaoLabel.Text = "Observação:";
            // 
            // cepLabel
            // 
            cepLabel.AutoSize = true;
            cepLabel.Location = new System.Drawing.Point(4, 160);
            cepLabel.Name = "cepLabel";
            cepLabel.Size = new System.Drawing.Size(31, 13);
            cepLabel.TabIndex = 44;
            cepLabel.Text = "CEP:";
            // 
            // ufLabel
            // 
            ufLabel.AutoSize = true;
            ufLabel.Location = new System.Drawing.Point(421, 158);
            ufLabel.Name = "ufLabel";
            ufLabel.Size = new System.Drawing.Size(24, 13);
            ufLabel.TabIndex = 46;
            ufLabel.Text = "UF:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastro de Pessoas";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 41);
            this.panel1.TabIndex = 20;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(302, 321);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(2, 321);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 0;
            this.btnBuscar.Text = "F2 - Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(383, 321);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(77, 321);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "F3 - Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(227, 321);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "F5 - Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(152, 321);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "F4 - Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // saceDataSet
            // 
            this.saceDataSet.DataSetName = "saceDataSet";
            this.saceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tb_pessoaBindingSource
            // 
            this.tb_pessoaBindingSource.DataMember = "tb_pessoa";
            this.tb_pessoaBindingSource.DataSource = this.saceDataSet;
            this.tb_pessoaBindingSource.Sort = "codPessoa";
            // 
            // tb_pessoaTableAdapter
            // 
            this.tb_pessoaTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.tb_bancoTableAdapter = null;
            this.tableAdapterManager.tb_cartao_creditoTableAdapter = null;
            this.tableAdapterManager.tb_configuracao_sistemaTableAdapter = null;
            this.tableAdapterManager.tb_conta_bancoTableAdapter = null;
            this.tableAdapterManager.tb_conta_pagarTableAdapter = null;
            this.tableAdapterManager.tb_conta_receberTableAdapter = null;
            this.tableAdapterManager.tb_contato_empresaTableAdapter = null;
            this.tableAdapterManager.tb_empresaTableAdapter = null;
            this.tableAdapterManager.tb_entrada_produtoTableAdapter = null;
            this.tableAdapterManager.tb_entradaTableAdapter = null;
            this.tableAdapterManager.tb_forma_pagamentoTableAdapter = null;
            this.tableAdapterManager.tb_funcionalidadeTableAdapter = null;
            this.tableAdapterManager.tb_grupo_contaTableAdapter = null;
            this.tableAdapterManager.tb_grupoTableAdapter = null;
            this.tableAdapterManager.tb_lojaTableAdapter = null;
            this.tableAdapterManager.tb_movimentacao_contaTableAdapter = null;
            this.tableAdapterManager.tb_pagamentoTableAdapter = null;
            this.tableAdapterManager.tb_permissaoTableAdapter = null;
            this.tableAdapterManager.tb_pessoaTableAdapter = this.tb_pessoaTableAdapter;
            this.tableAdapterManager.tb_plano_contaTableAdapter = null;
            this.tableAdapterManager.tb_produto_lojaTableAdapter = null;
            this.tableAdapterManager.tb_produtoTableAdapter = null;
            this.tableAdapterManager.tb_recebimentoTableAdapter = null;
            this.tableAdapterManager.tb_saida_produtoTableAdapter = null;
            this.tableAdapterManager.tb_saidaTableAdapter = null;
            this.tableAdapterManager.tb_tipo_movimentacao_contaTableAdapter = null;
            this.tableAdapterManager.tb_usuarioTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = SACE.Dados.saceDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tb_pessoaBindingNavigator
            // 
            this.tb_pessoaBindingNavigator.AddNewItem = null;
            this.tb_pessoaBindingNavigator.BindingSource = this.tb_pessoaBindingSource;
            this.tb_pessoaBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tb_pessoaBindingNavigator.DeleteItem = null;
            this.tb_pessoaBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.tb_pessoaBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.tb_pessoaBindingNavigator.Location = new System.Drawing.Point(271, 40);
            this.tb_pessoaBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tb_pessoaBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tb_pessoaBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tb_pessoaBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tb_pessoaBindingNavigator.Name = "tb_pessoaBindingNavigator";
            this.tb_pessoaBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tb_pessoaBindingNavigator.Size = new System.Drawing.Size(209, 25);
            this.tb_pessoaBindingNavigator.TabIndex = 21;
            this.tb_pessoaBindingNavigator.Text = "bindingNavigator1";
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
            // codPessoaTextBox
            // 
            this.codPessoaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_pessoaBindingSource, "codPessoa", true));
            this.codPessoaTextBox.Location = new System.Drawing.Point(7, 86);
            this.codPessoaTextBox.Name = "codPessoaTextBox";
            this.codPessoaTextBox.ReadOnly = true;
            this.codPessoaTextBox.Size = new System.Drawing.Size(100, 20);
            this.codPessoaTextBox.TabIndex = 22;
            this.codPessoaTextBox.TabStop = false;
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_pessoaBindingSource, "nome", true));
            this.nomeTextBox.Location = new System.Drawing.Point(117, 86);
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.Size = new System.Drawing.Size(350, 20);
            this.nomeTextBox.TabIndex = 24;
            // 
            // cpfTextBox
            // 
            this.cpfTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cpfTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_pessoaBindingSource, "cpf", true));
            this.cpfTextBox.Location = new System.Drawing.Point(7, 129);
            this.cpfTextBox.Name = "cpfTextBox";
            this.cpfTextBox.Size = new System.Drawing.Size(100, 20);
            this.cpfTextBox.TabIndex = 26;
            // 
            // bairroTextBox
            // 
            this.bairroTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.bairroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_pessoaBindingSource, "bairro", true));
            this.bairroTextBox.Location = new System.Drawing.Point(118, 177);
            this.bairroTextBox.Name = "bairroTextBox";
            this.bairroTextBox.Size = new System.Drawing.Size(143, 20);
            this.bairroTextBox.TabIndex = 32;
            // 
            // cidadeTextBox
            // 
            this.cidadeTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cidadeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_pessoaBindingSource, "cidade", true));
            this.cidadeTextBox.Location = new System.Drawing.Point(271, 176);
            this.cidadeTextBox.Name = "cidadeTextBox";
            this.cidadeTextBox.Size = new System.Drawing.Size(147, 20);
            this.cidadeTextBox.TabIndex = 34;
            // 
            // fone1TextBox
            // 
            this.fone1TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fone1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_pessoaBindingSource, "fone1", true));
            this.fone1TextBox.Location = new System.Drawing.Point(7, 226);
            this.fone1TextBox.Name = "fone1TextBox";
            this.fone1TextBox.Size = new System.Drawing.Size(100, 20);
            this.fone1TextBox.TabIndex = 38;
            // 
            // fone2TextBox
            // 
            this.fone2TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.fone2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_pessoaBindingSource, "fone2", true));
            this.fone2TextBox.Location = new System.Drawing.Point(118, 226);
            this.fone2TextBox.Name = "fone2TextBox";
            this.fone2TextBox.Size = new System.Drawing.Size(119, 20);
            this.fone2TextBox.TabIndex = 40;
            // 
            // limiteCompraTextBox
            // 
            this.limiteCompraTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.limiteCompraTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_pessoaBindingSource, "limiteCompra", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0", "N2"));
            this.limiteCompraTextBox.Location = new System.Drawing.Point(243, 226);
            this.limiteCompraTextBox.Name = "limiteCompraTextBox";
            this.limiteCompraTextBox.Size = new System.Drawing.Size(150, 20);
            this.limiteCompraTextBox.TabIndex = 42;
            // 
            // valorComissaoTextBox
            // 
            this.valorComissaoTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.valorComissaoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_pessoaBindingSource, "valorComissao", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0", "N2"));
            this.valorComissaoTextBox.Location = new System.Drawing.Point(400, 226);
            this.valorComissaoTextBox.Name = "valorComissaoTextBox";
            this.valorComissaoTextBox.Size = new System.Drawing.Size(67, 20);
            this.valorComissaoTextBox.TabIndex = 44;
            // 
            // observacaoTextBox
            // 
            this.observacaoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_pessoaBindingSource, "observacao", true));
            this.observacaoTextBox.Location = new System.Drawing.Point(7, 275);
            this.observacaoTextBox.Multiline = true;
            this.observacaoTextBox.Name = "observacaoTextBox";
            this.observacaoTextBox.Size = new System.Drawing.Size(460, 41);
            this.observacaoTextBox.TabIndex = 46;
            // 
            // cepTextBox
            // 
            this.cepTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cepTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_pessoaBindingSource, "cep", true));
            this.cepTextBox.Location = new System.Drawing.Point(7, 177);
            this.cepTextBox.Name = "cepTextBox";
            this.cepTextBox.Size = new System.Drawing.Size(100, 20);
            this.cepTextBox.TabIndex = 30;
            // 
            // enderecoTextBox
            // 
            this.enderecoTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.enderecoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_pessoaBindingSource, "endereco", true));
            this.enderecoTextBox.Location = new System.Drawing.Point(118, 127);
            this.enderecoTextBox.Name = "enderecoTextBox";
            this.enderecoTextBox.Size = new System.Drawing.Size(349, 20);
            this.enderecoTextBox.TabIndex = 28;
            // 
            // ufTextBox
            // 
            this.ufTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ufTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_pessoaBindingSource, "uf", true));
            this.ufTextBox.Location = new System.Drawing.Point(424, 175);
            this.ufTextBox.Name = "ufTextBox";
            this.ufTextBox.Size = new System.Drawing.Size(43, 20);
            this.ufTextBox.TabIndex = 36;
            // 
            // FrmPessoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 345);
            this.Controls.Add(ufLabel);
            this.Controls.Add(this.ufTextBox);
            this.Controls.Add(this.enderecoTextBox);
            this.Controls.Add(cepLabel);
            this.Controls.Add(this.cepTextBox);
            this.Controls.Add(codPessoaLabel);
            this.Controls.Add(this.tb_pessoaBindingNavigator);
            this.Controls.Add(this.codPessoaTextBox);
            this.Controls.Add(nomeLabel);
            this.Controls.Add(this.nomeTextBox);
            this.Controls.Add(enderecoLabel);
            this.Controls.Add(cpfLabel);
            this.Controls.Add(this.cpfTextBox);
            this.Controls.Add(bairroLabel);
            this.Controls.Add(this.bairroTextBox);
            this.Controls.Add(cidadeLabel);
            this.Controls.Add(this.cidadeTextBox);
            this.Controls.Add(fone1Label);
            this.Controls.Add(this.fone1TextBox);
            this.Controls.Add(fone2Label);
            this.Controls.Add(this.fone2TextBox);
            this.Controls.Add(limiteCompraLabel);
            this.Controls.Add(this.limiteCompraTextBox);
            this.Controls.Add(valorComissaoLabel);
            this.Controls.Add(this.valorComissaoTextBox);
            this.Controls.Add(observacaoLabel);
            this.Controls.Add(this.observacaoTextBox);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmPessoa";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro Pessoas";
            this.Load += new System.EventHandler(this.FrmPessoa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPessoa_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_pessoaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_pessoaBindingNavigator)).EndInit();
            this.tb_pessoaBindingNavigator.ResumeLayout(false);
            this.tb_pessoaBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnEditar;
        private SACE.Dados.saceDataSet saceDataSet;
        private System.Windows.Forms.BindingSource tb_pessoaBindingSource;
        private SACE.Dados.saceDataSetTableAdapters.tb_pessoaTableAdapter tb_pessoaTableAdapter;
        private SACE.Dados.saceDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator tb_pessoaBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.TextBox codPessoaTextBox;
        private System.Windows.Forms.TextBox nomeTextBox;
        private System.Windows.Forms.TextBox cpfTextBox;
        private System.Windows.Forms.TextBox bairroTextBox;
        private System.Windows.Forms.TextBox cidadeTextBox;
        private System.Windows.Forms.TextBox fone1TextBox;
        private System.Windows.Forms.TextBox fone2TextBox;
        private System.Windows.Forms.TextBox limiteCompraTextBox;
        private System.Windows.Forms.TextBox valorComissaoTextBox;
        private System.Windows.Forms.TextBox observacaoTextBox;
        private System.Windows.Forms.TextBox cepTextBox;
        private System.Windows.Forms.TextBox enderecoTextBox;
        private System.Windows.Forms.TextBox ufTextBox;
    }
}