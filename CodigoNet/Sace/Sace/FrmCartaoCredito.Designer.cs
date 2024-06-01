namespace Telas
{
    partial class FrmCartaoCredito
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
            System.Windows.Forms.Label codCartaoLabel;
            System.Windows.Forms.Label nomeLabel;
            System.Windows.Forms.Label codContaBancoLabel;
            System.Windows.Forms.Label diaBaseLabel;
            System.Windows.Forms.Label codPessoaLabel;
            System.Windows.Forms.Label mapeamentoLabel;
            System.Windows.Forms.Label descontoLabel;
            System.Windows.Forms.Label mapeamentoCapptaLabel;
            System.Windows.Forms.Label tipoCartaoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCartaoCredito));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.tb_cartao_creditoBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.cartaoCreditoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.codCartaoTextBox = new System.Windows.Forms.TextBox();
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.diaBaseTextBox = new System.Windows.Forms.TextBox();
            this.codContaBancoComboBox = new System.Windows.Forms.ComboBox();
            this.contaBancoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codPessoaComboBox = new System.Windows.Forms.ComboBox();
            this.pessoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mapeamentoTextBox = new System.Windows.Forms.TextBox();
            this.descontoTextBox = new System.Windows.Forms.TextBox();
            this.mapeamentoCapptaTextBox = new System.Windows.Forms.TextBox();
            this.tipoCartaoComboBox = new System.Windows.Forms.ComboBox();
            codCartaoLabel = new System.Windows.Forms.Label();
            nomeLabel = new System.Windows.Forms.Label();
            codContaBancoLabel = new System.Windows.Forms.Label();
            diaBaseLabel = new System.Windows.Forms.Label();
            codPessoaLabel = new System.Windows.Forms.Label();
            mapeamentoLabel = new System.Windows.Forms.Label();
            descontoLabel = new System.Windows.Forms.Label();
            mapeamentoCapptaLabel = new System.Windows.Forms.Label();
            tipoCartaoLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_cartao_creditoBindingNavigator)).BeginInit();
            this.tb_cartao_creditoBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cartaoCreditoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contaBancoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pessoaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // codCartaoLabel
            // 
            codCartaoLabel.AutoSize = true;
            codCartaoLabel.Location = new System.Drawing.Point(8, 54);
            codCartaoLabel.Name = "codCartaoLabel";
            codCartaoLabel.Size = new System.Drawing.Size(63, 13);
            codCartaoLabel.TabIndex = 20;
            codCartaoLabel.Text = "Cód Cartão:";
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Location = new System.Drawing.Point(130, 54);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new System.Drawing.Size(38, 13);
            nomeLabel.TabIndex = 21;
            nomeLabel.Text = "Nome:";
            // 
            // codContaBancoLabel
            // 
            codContaBancoLabel.AutoSize = true;
            codContaBancoLabel.Location = new System.Drawing.Point(8, 150);
            codContaBancoLabel.Name = "codContaBancoLabel";
            codContaBancoLabel.Size = new System.Drawing.Size(72, 13);
            codContaBancoLabel.TabIndex = 22;
            codContaBancoLabel.Text = "Conta Banco:";
            // 
            // diaBaseLabel
            // 
            diaBaseLabel.AutoSize = true;
            diaBaseLabel.Location = new System.Drawing.Point(358, 153);
            diaBaseLabel.Name = "diaBaseLabel";
            diaBaseLabel.Size = new System.Drawing.Size(107, 13);
            diaBaseLabel.TabIndex = 23;
            diaBaseLabel.Text = "Qtd Dias Para Pagar:";
            diaBaseLabel.Click += new System.EventHandler(this.diaBaseLabel_Click);
            // 
            // codPessoaLabel
            // 
            codPessoaLabel.AutoSize = true;
            codPessoaLabel.Location = new System.Drawing.Point(130, 105);
            codPessoaLabel.Name = "codPessoaLabel";
            codPessoaLabel.Size = new System.Drawing.Size(116, 13);
            codPessoaLabel.TabIndex = 31;
            codPessoaLabel.Text = "Empresa Responsável:";
            // 
            // mapeamentoLabel
            // 
            mapeamentoLabel.AutoSize = true;
            mapeamentoLabel.Location = new System.Drawing.Point(8, 194);
            mapeamentoLabel.Name = "mapeamentoLabel";
            mapeamentoLabel.Size = new System.Drawing.Size(128, 13);
            mapeamentoLabel.TabIndex = 33;
            mapeamentoLabel.Text = "Mapeamento Markssyste:";
            mapeamentoLabel.Click += new System.EventHandler(this.mapeamentoLabel_Click);
            // 
            // descontoLabel
            // 
            descontoLabel.AutoSize = true;
            descontoLabel.Location = new System.Drawing.Point(289, 151);
            descontoLabel.Name = "descontoLabel";
            descontoLabel.Size = new System.Drawing.Size(56, 13);
            descontoLabel.TabIndex = 34;
            descontoLabel.Text = "Desconto:";
            descontoLabel.Click += new System.EventHandler(this.descontoLabel_Click);
            // 
            // mapeamentoCapptaLabel
            // 
            mapeamentoCapptaLabel.AutoSize = true;
            mapeamentoCapptaLabel.Location = new System.Drawing.Point(151, 194);
            mapeamentoCapptaLabel.Name = "mapeamentoCapptaLabel";
            mapeamentoCapptaLabel.Size = new System.Drawing.Size(109, 13);
            mapeamentoCapptaLabel.TabIndex = 34;
            mapeamentoCapptaLabel.Text = "Mapeamento Cappta:";
            // 
            // tipoCartaoLabel
            // 
            tipoCartaoLabel.AutoSize = true;
            tipoCartaoLabel.Location = new System.Drawing.Point(8, 105);
            tipoCartaoLabel.Name = "tipoCartaoLabel";
            tipoCartaoLabel.Size = new System.Drawing.Size(65, 13);
            tipoCartaoLabel.TabIndex = 35;
            tipoCartaoLabel.Text = "Tipo Cartao:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastro de Cartões de Crédito";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(475, 41);
            this.panel1.TabIndex = 20;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(304, 247);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(4, 247);
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
            this.btnCancelar.Location = new System.Drawing.Point(385, 247);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(79, 247);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "F3 - Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(229, 247);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "F5 - Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(154, 247);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "F4 - Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // tb_cartao_creditoBindingNavigator
            // 
            this.tb_cartao_creditoBindingNavigator.AddNewItem = null;
            this.tb_cartao_creditoBindingNavigator.BindingSource = this.cartaoCreditoBindingSource;
            this.tb_cartao_creditoBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tb_cartao_creditoBindingNavigator.DeleteItem = null;
            this.tb_cartao_creditoBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.tb_cartao_creditoBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.tb_cartao_creditoBindingNavigator.Location = new System.Drawing.Point(270, 40);
            this.tb_cartao_creditoBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tb_cartao_creditoBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tb_cartao_creditoBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tb_cartao_creditoBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tb_cartao_creditoBindingNavigator.Name = "tb_cartao_creditoBindingNavigator";
            this.tb_cartao_creditoBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tb_cartao_creditoBindingNavigator.Size = new System.Drawing.Size(209, 25);
            this.tb_cartao_creditoBindingNavigator.TabIndex = 24;
            this.tb_cartao_creditoBindingNavigator.Text = "bindingNavigator1";
            // 
            // cartaoCreditoBindingSource
            // 
            this.cartaoCreditoBindingSource.DataSource = typeof(Dominio.CartaoCredito);
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
            // codCartaoTextBox
            // 
            this.codCartaoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cartaoCreditoBindingSource, "CodCartao", true));
            this.codCartaoTextBox.Location = new System.Drawing.Point(11, 72);
            this.codCartaoTextBox.Name = "codCartaoTextBox";
            this.codCartaoTextBox.Size = new System.Drawing.Size(113, 20);
            this.codCartaoTextBox.TabIndex = 25;
            this.codCartaoTextBox.Enter += new System.EventHandler(this.codCartaoTextBox_Enter);
            this.codCartaoTextBox.Leave += new System.EventHandler(this.codCartaoTextBox_Leave);
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cartaoCreditoBindingSource, "Nome", true));
            this.nomeTextBox.Location = new System.Drawing.Point(133, 72);
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.Size = new System.Drawing.Size(336, 20);
            this.nomeTextBox.TabIndex = 27;
            this.nomeTextBox.Enter += new System.EventHandler(this.codCartaoTextBox_Enter);
            this.nomeTextBox.Leave += new System.EventHandler(this.nomeTextBox_Leave);
            // 
            // diaBaseTextBox
            // 
            this.diaBaseTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cartaoCreditoBindingSource, "DiaBase", true));
            this.diaBaseTextBox.Location = new System.Drawing.Point(361, 169);
            this.diaBaseTextBox.Name = "diaBaseTextBox";
            this.diaBaseTextBox.Size = new System.Drawing.Size(104, 20);
            this.diaBaseTextBox.TabIndex = 33;
            this.diaBaseTextBox.TextChanged += new System.EventHandler(this.diaBaseTextBox_TextChanged);
            this.diaBaseTextBox.Enter += new System.EventHandler(this.codCartaoTextBox_Enter);
            this.diaBaseTextBox.Leave += new System.EventHandler(this.codCartaoTextBox_Leave);
            // 
            // codContaBancoComboBox
            // 
            this.codContaBancoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codContaBancoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codContaBancoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.cartaoCreditoBindingSource, "CodContaBanco", true));
            this.codContaBancoComboBox.DataSource = this.contaBancoBindingSource;
            this.codContaBancoComboBox.DisplayMember = "Descricao";
            this.codContaBancoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codContaBancoComboBox.FormattingEnabled = true;
            this.codContaBancoComboBox.Location = new System.Drawing.Point(11, 168);
            this.codContaBancoComboBox.Name = "codContaBancoComboBox";
            this.codContaBancoComboBox.Size = new System.Drawing.Size(275, 21);
            this.codContaBancoComboBox.TabIndex = 31;
            this.codContaBancoComboBox.ValueMember = "codContaBanco";
            this.codContaBancoComboBox.Enter += new System.EventHandler(this.codCartaoTextBox_Enter);
            this.codContaBancoComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codContaBancoComboBox_KeyPress);
            this.codContaBancoComboBox.Leave += new System.EventHandler(this.codCartaoTextBox_Leave);
            // 
            // contaBancoBindingSource
            // 
            this.contaBancoBindingSource.DataSource = typeof(Dominio.ContaBanco);
            // 
            // codPessoaComboBox
            // 
            this.codPessoaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codPessoaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codPessoaComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.cartaoCreditoBindingSource, "CodPessoa", true));
            this.codPessoaComboBox.DataSource = this.pessoaBindingSource;
            this.codPessoaComboBox.DisplayMember = "NomeFantasia";
            this.codPessoaComboBox.FormattingEnabled = true;
            this.codPessoaComboBox.Location = new System.Drawing.Point(133, 121);
            this.codPessoaComboBox.Name = "codPessoaComboBox";
            this.codPessoaComboBox.Size = new System.Drawing.Size(336, 21);
            this.codPessoaComboBox.TabIndex = 29;
            this.codPessoaComboBox.ValueMember = "CodPessoa";
            this.codPessoaComboBox.SelectedIndexChanged += new System.EventHandler(this.codPessoaComboBox_SelectedIndexChanged);
            this.codPessoaComboBox.Enter += new System.EventHandler(this.codCartaoTextBox_Enter);
            this.codPessoaComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codContaBancoComboBox_KeyPress);
            this.codPessoaComboBox.Leave += new System.EventHandler(this.codPessoaComboBox_Leave);
            // 
            // pessoaBindingSource
            // 
            this.pessoaBindingSource.DataSource = typeof(Dominio.Pessoa);
            // 
            // mapeamentoTextBox
            // 
            this.mapeamentoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cartaoCreditoBindingSource, "Mapeamento", true));
            this.mapeamentoTextBox.Location = new System.Drawing.Point(11, 212);
            this.mapeamentoTextBox.Name = "mapeamentoTextBox";
            this.mapeamentoTextBox.Size = new System.Drawing.Size(125, 20);
            this.mapeamentoTextBox.TabIndex = 34;
            this.mapeamentoTextBox.TextChanged += new System.EventHandler(this.mapeamentoTextBox_TextChanged);
            this.mapeamentoTextBox.Enter += new System.EventHandler(this.codCartaoTextBox_Enter);
            this.mapeamentoTextBox.Leave += new System.EventHandler(this.codCartaoTextBox_Leave);
            // 
            // descontoTextBox
            // 
            this.descontoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cartaoCreditoBindingSource, "Desconto", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.descontoTextBox.Location = new System.Drawing.Point(292, 169);
            this.descontoTextBox.Name = "descontoTextBox";
            this.descontoTextBox.Size = new System.Drawing.Size(63, 20);
            this.descontoTextBox.TabIndex = 32;
            this.descontoTextBox.TextChanged += new System.EventHandler(this.descontoTextBox_TextChanged);
            this.descontoTextBox.Enter += new System.EventHandler(this.codCartaoTextBox_Enter);
            this.descontoTextBox.Leave += new System.EventHandler(this.codCartaoTextBox_Leave);
            // 
            // mapeamentoCapptaTextBox
            // 
            this.mapeamentoCapptaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cartaoCreditoBindingSource, "MapeamentoCappta", true));
            this.mapeamentoCapptaTextBox.Location = new System.Drawing.Point(154, 212);
            this.mapeamentoCapptaTextBox.Name = "mapeamentoCapptaTextBox";
            this.mapeamentoCapptaTextBox.Size = new System.Drawing.Size(315, 20);
            this.mapeamentoCapptaTextBox.TabIndex = 35;
            // 
            // tipoCartaoComboBox
            // 
            this.tipoCartaoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cartaoCreditoBindingSource, "TipoCartao", true));
            this.tipoCartaoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.cartaoCreditoBindingSource, "TipoCartao", true));
            this.tipoCartaoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tipoCartaoComboBox.FormattingEnabled = true;
            this.tipoCartaoComboBox.Items.AddRange(new object[] {
            "CREDITO",
            "DEBITO"});
            this.tipoCartaoComboBox.Location = new System.Drawing.Point(11, 121);
            this.tipoCartaoComboBox.Name = "tipoCartaoComboBox";
            this.tipoCartaoComboBox.Size = new System.Drawing.Size(113, 21);
            this.tipoCartaoComboBox.TabIndex = 28;
            this.tipoCartaoComboBox.SelectedIndexChanged += new System.EventHandler(this.tipoCartaoComboBox_SelectedIndexChanged);
            // 
            // FrmCartaoCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 290);
            this.Controls.Add(tipoCartaoLabel);
            this.Controls.Add(this.tipoCartaoComboBox);
            this.Controls.Add(mapeamentoCapptaLabel);
            this.Controls.Add(this.mapeamentoCapptaTextBox);
            this.Controls.Add(descontoLabel);
            this.Controls.Add(this.descontoTextBox);
            this.Controls.Add(mapeamentoLabel);
            this.Controls.Add(this.mapeamentoTextBox);
            this.Controls.Add(codPessoaLabel);
            this.Controls.Add(this.codPessoaComboBox);
            this.Controls.Add(this.codContaBancoComboBox);
            this.Controls.Add(this.tb_cartao_creditoBindingNavigator);
            this.Controls.Add(this.codCartaoTextBox);
            this.Controls.Add(this.nomeTextBox);
            this.Controls.Add(this.diaBaseTextBox);
            this.Controls.Add(diaBaseLabel);
            this.Controls.Add(codContaBancoLabel);
            this.Controls.Add(nomeLabel);
            this.Controls.Add(codCartaoLabel);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmCartaoCredito";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de Cartões de Crédito";
            this.Load += new System.EventHandler(this.FrmCartaoCredito_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCartaoCredito_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_cartao_creditoBindingNavigator)).EndInit();
            this.tb_cartao_creditoBindingNavigator.ResumeLayout(false);
            this.tb_cartao_creditoBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cartaoCreditoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contaBancoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pessoaBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingNavigator tb_cartao_creditoBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.TextBox codCartaoTextBox;
        private System.Windows.Forms.TextBox nomeTextBox;
        private System.Windows.Forms.TextBox diaBaseTextBox;
        private System.Windows.Forms.ComboBox codContaBancoComboBox;
        private System.Windows.Forms.ComboBox codPessoaComboBox;
        private System.Windows.Forms.TextBox mapeamentoTextBox;
        private System.Windows.Forms.BindingSource cartaoCreditoBindingSource;
        private System.Windows.Forms.BindingSource pessoaBindingSource;
        private System.Windows.Forms.BindingSource contaBancoBindingSource;
        private System.Windows.Forms.TextBox descontoTextBox;
        private System.Windows.Forms.TextBox mapeamentoCapptaTextBox;
        private System.Windows.Forms.ComboBox tipoCartaoComboBox;
    }
}