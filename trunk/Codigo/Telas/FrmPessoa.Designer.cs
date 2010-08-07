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
            System.Windows.Forms.Label enderecoLabel;
            System.Windows.Forms.Label bairroLabel;
            System.Windows.Forms.Label cidadeLabel;
            System.Windows.Forms.Label fone1Label;
            System.Windows.Forms.Label fone2Label;
            System.Windows.Forms.Label limiteCompraLabel;
            System.Windows.Forms.Label valorComissaoLabel;
            System.Windows.Forms.Label observacaoLabel;
            System.Windows.Forms.Label cepLabel;
            System.Windows.Forms.Label ufLabel;
            System.Windows.Forms.Label ieLabel;
            System.Windows.Forms.Label fone3Label;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPessoa));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.tb_pessoaBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.tb_pessoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saceDataSet = new Dados.saceDataSet();
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
            this.bairroTextBox = new System.Windows.Forms.TextBox();
            this.cidadeTextBox = new System.Windows.Forms.TextBox();
            this.observacaoTextBox = new System.Windows.Forms.TextBox();
            this.enderecoTextBox = new System.Windows.Forms.TextBox();
            this.ufTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PjRadioButton = new System.Windows.Forms.RadioButton();
            this.PfRadioButton = new System.Windows.Forms.RadioButton();
            this.nomeLabel = new System.Windows.Forms.Label();
            this.cpfLabel = new System.Windows.Forms.Label();
            this.cpf_cnpjMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.cepMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.fone1MaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.fone2MaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.limiteCompraMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.valorComissaoMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.cpf_cnpjErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ieTextBox = new System.Windows.Forms.TextBox();
            this.fone3TextBox = new System.Windows.Forms.TextBox();
            this.tb_contato_empresaDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_contato_empresaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAdicionarContato = new System.Windows.Forms.Button();
            this.tb_pessoaTableAdapter = new Dados.saceDataSetTableAdapters.tb_pessoaTableAdapter();
            this.tableAdapterManager = new Dados.saceDataSetTableAdapters.TableAdapterManager();
            this.tb_contato_empresaTableAdapter1 = new Dados.saceDataSetTableAdapters.tb_contato_empresaTableAdapter();
            codPessoaLabel = new System.Windows.Forms.Label();
            enderecoLabel = new System.Windows.Forms.Label();
            bairroLabel = new System.Windows.Forms.Label();
            cidadeLabel = new System.Windows.Forms.Label();
            fone1Label = new System.Windows.Forms.Label();
            fone2Label = new System.Windows.Forms.Label();
            limiteCompraLabel = new System.Windows.Forms.Label();
            valorComissaoLabel = new System.Windows.Forms.Label();
            observacaoLabel = new System.Windows.Forms.Label();
            cepLabel = new System.Windows.Forms.Label();
            ufLabel = new System.Windows.Forms.Label();
            ieLabel = new System.Windows.Forms.Label();
            fone3Label = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_pessoaBindingNavigator)).BeginInit();
            this.tb_pessoaBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_pessoaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpf_cnpjErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_contato_empresaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_contato_empresaBindingSource)).BeginInit();
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
            // enderecoLabel
            // 
            enderecoLabel.AutoSize = true;
            enderecoLabel.Location = new System.Drawing.Point(115, 111);
            enderecoLabel.Name = "enderecoLabel";
            enderecoLabel.Size = new System.Drawing.Size(56, 13);
            enderecoLabel.TabIndex = 25;
            enderecoLabel.Text = "Endereço:";
            // 
            // bairroLabel
            // 
            bairroLabel.AutoSize = true;
            bairroLabel.Location = new System.Drawing.Point(224, 158);
            bairroLabel.Name = "bairroLabel";
            bairroLabel.Size = new System.Drawing.Size(37, 13);
            bairroLabel.TabIndex = 31;
            bairroLabel.Text = "Bairro:";
            // 
            // cidadeLabel
            // 
            cidadeLabel.AutoSize = true;
            cidadeLabel.Location = new System.Drawing.Point(396, 157);
            cidadeLabel.Name = "cidadeLabel";
            cidadeLabel.Size = new System.Drawing.Size(43, 13);
            cidadeLabel.TabIndex = 33;
            cidadeLabel.Text = "Cidade:";
            // 
            // fone1Label
            // 
            fone1Label.AutoSize = true;
            fone1Label.Location = new System.Drawing.Point(7, 200);
            fone1Label.Name = "fone1Label";
            fone1Label.Size = new System.Drawing.Size(40, 13);
            fone1Label.TabIndex = 35;
            fone1Label.Text = "Fone1:";
            // 
            // fone2Label
            // 
            fone2Label.AutoSize = true;
            fone2Label.Location = new System.Drawing.Point(132, 200);
            fone2Label.Name = "fone2Label";
            fone2Label.Size = new System.Drawing.Size(40, 13);
            fone2Label.TabIndex = 37;
            fone2Label.Text = "Fone2:";
            // 
            // limiteCompraLabel
            // 
            limiteCompraLabel.AutoSize = true;
            limiteCompraLabel.Location = new System.Drawing.Point(396, 200);
            limiteCompraLabel.Name = "limiteCompraLabel";
            limiteCompraLabel.Size = new System.Drawing.Size(76, 13);
            limiteCompraLabel.TabIndex = 39;
            limiteCompraLabel.Text = "Limite Compra:";
            // 
            // valorComissaoLabel
            // 
            valorComissaoLabel.AutoSize = true;
            valorComissaoLabel.Location = new System.Drawing.Point(530, 200);
            valorComissaoLabel.Name = "valorComissaoLabel";
            valorComissaoLabel.Size = new System.Drawing.Size(66, 13);
            valorComissaoLabel.TabIndex = 41;
            valorComissaoLabel.Text = "% Comissão:";
            // 
            // observacaoLabel
            // 
            observacaoLabel.AutoSize = true;
            observacaoLabel.Location = new System.Drawing.Point(4, 242);
            observacaoLabel.Name = "observacaoLabel";
            observacaoLabel.Size = new System.Drawing.Size(68, 13);
            observacaoLabel.TabIndex = 43;
            observacaoLabel.Text = "Observação:";
            // 
            // cepLabel
            // 
            cepLabel.AutoSize = true;
            cepLabel.Location = new System.Drawing.Point(118, 158);
            cepLabel.Name = "cepLabel";
            cepLabel.Size = new System.Drawing.Size(31, 13);
            cepLabel.TabIndex = 44;
            cepLabel.Text = "CEP:";
            // 
            // ufLabel
            // 
            ufLabel.AutoSize = true;
            ufLabel.Location = new System.Drawing.Point(549, 156);
            ufLabel.Name = "ufLabel";
            ufLabel.Size = new System.Drawing.Size(24, 13);
            ufLabel.TabIndex = 46;
            ufLabel.Text = "UF:";
            // 
            // ieLabel
            // 
            ieLabel.AutoSize = true;
            ieLabel.Location = new System.Drawing.Point(7, 158);
            ieLabel.Name = "ieLabel";
            ieLabel.Size = new System.Drawing.Size(98, 13);
            ieLabel.TabIndex = 49;
            ieLabel.Text = "Insc Estadual / RG";
            // 
            // fone3Label
            // 
            fone3Label.AutoSize = true;
            fone3Label.Location = new System.Drawing.Point(268, 200);
            fone3Label.Name = "fone3Label";
            fone3Label.Size = new System.Drawing.Size(40, 13);
            fone3Label.TabIndex = 50;
            fone3Label.Text = "Fone3:";
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
            this.panel1.Size = new System.Drawing.Size(600, 41);
            this.panel1.TabIndex = 20;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(307, 428);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(7, 428);
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
            this.btnCancelar.Location = new System.Drawing.Point(388, 428);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(82, 428);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "F3 - Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(232, 428);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "F5 - Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(157, 428);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "F4 - Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
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
            this.tb_pessoaBindingNavigator.Location = new System.Drawing.Point(395, 43);
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
            // tb_pessoaBindingSource
            // 
            this.tb_pessoaBindingSource.DataMember = "tb_pessoa";
            this.tb_pessoaBindingSource.DataSource = this.saceDataSet;
            this.tb_pessoaBindingSource.Sort = "codPessoa";
            this.tb_pessoaBindingSource.PositionChanged += new System.EventHandler(this.tb_pessoaBindingSource_PositionChanged);
            // 
            // saceDataSet
            // 
            this.saceDataSet.DataSetName = "saceDataSet";
            this.saceDataSet.Prefix = "SACE";
            this.saceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.codPessoaTextBox.TextChanged += new System.EventHandler(this.codPessoaTextBox_TextChanged);
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_pessoaBindingSource, "nome", true));
            this.nomeTextBox.Location = new System.Drawing.Point(117, 86);
            this.nomeTextBox.MaxLength = 40;
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.Size = new System.Drawing.Size(388, 20);
            this.nomeTextBox.TabIndex = 23;
            // 
            // bairroTextBox
            // 
            this.bairroTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.bairroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_pessoaBindingSource, "bairro", true));
            this.bairroTextBox.Location = new System.Drawing.Point(227, 174);
            this.bairroTextBox.MaxLength = 40;
            this.bairroTextBox.Name = "bairroTextBox";
            this.bairroTextBox.Size = new System.Drawing.Size(166, 20);
            this.bairroTextBox.TabIndex = 29;
            // 
            // cidadeTextBox
            // 
            this.cidadeTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cidadeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_pessoaBindingSource, "cidade", true));
            this.cidadeTextBox.Location = new System.Drawing.Point(399, 174);
            this.cidadeTextBox.MaxLength = 40;
            this.cidadeTextBox.Name = "cidadeTextBox";
            this.cidadeTextBox.Size = new System.Drawing.Size(147, 20);
            this.cidadeTextBox.TabIndex = 30;
            // 
            // observacaoTextBox
            // 
            this.observacaoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_pessoaBindingSource, "observacao", true));
            this.observacaoTextBox.Location = new System.Drawing.Point(7, 259);
            this.observacaoTextBox.Multiline = true;
            this.observacaoTextBox.Name = "observacaoTextBox";
            this.observacaoTextBox.Size = new System.Drawing.Size(588, 41);
            this.observacaoTextBox.TabIndex = 37;
            // 
            // enderecoTextBox
            // 
            this.enderecoTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.enderecoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_pessoaBindingSource, "endereco", true));
            this.enderecoTextBox.Location = new System.Drawing.Point(118, 127);
            this.enderecoTextBox.MaxLength = 64;
            this.enderecoTextBox.Name = "enderecoTextBox";
            this.enderecoTextBox.Size = new System.Drawing.Size(477, 20);
            this.enderecoTextBox.TabIndex = 26;
            // 
            // ufTextBox
            // 
            this.ufTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ufTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_pessoaBindingSource, "uf", true));
            this.ufTextBox.Location = new System.Drawing.Point(552, 173);
            this.ufTextBox.MaxLength = 2;
            this.ufTextBox.Name = "ufTextBox";
            this.ufTextBox.Size = new System.Drawing.Size(43, 20);
            this.ufTextBox.TabIndex = 31;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PjRadioButton);
            this.groupBox1.Controls.Add(this.PfRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(511, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(84, 52);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo:";
            // 
            // PjRadioButton
            // 
            this.PjRadioButton.AutoSize = true;
            this.PjRadioButton.Location = new System.Drawing.Point(6, 32);
            this.PjRadioButton.Name = "PjRadioButton";
            this.PjRadioButton.Size = new System.Drawing.Size(63, 17);
            this.PjRadioButton.TabIndex = 1;
            this.PjRadioButton.Text = "Jurídica";
            this.PjRadioButton.UseVisualStyleBackColor = true;
            // 
            // PfRadioButton
            // 
            this.PfRadioButton.AutoSize = true;
            this.PfRadioButton.Checked = true;
            this.PfRadioButton.Location = new System.Drawing.Point(7, 14);
            this.PfRadioButton.Name = "PfRadioButton";
            this.PfRadioButton.Size = new System.Drawing.Size(54, 17);
            this.PfRadioButton.TabIndex = 0;
            this.PfRadioButton.TabStop = true;
            this.PfRadioButton.Text = "Física";
            this.PfRadioButton.UseVisualStyleBackColor = true;
            // 
            // nomeLabel
            // 
            this.nomeLabel.AutoSize = true;
            this.nomeLabel.Location = new System.Drawing.Point(118, 69);
            this.nomeLabel.Name = "nomeLabel";
            this.nomeLabel.Size = new System.Drawing.Size(81, 13);
            this.nomeLabel.TabIndex = 48;
            this.nomeLabel.Text = "Nome Fantasia:";
            // 
            // cpfLabel
            // 
            this.cpfLabel.AutoSize = true;
            this.cpfLabel.Location = new System.Drawing.Point(7, 111);
            this.cpfLabel.Name = "cpfLabel";
            this.cpfLabel.Size = new System.Drawing.Size(68, 13);
            this.cpfLabel.TabIndex = 49;
            this.cpfLabel.Text = "CNPJ / CPF:";
            // 
            // cpf_cnpjMaskedTextBox
            // 
            this.cpf_cnpjMaskedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_pessoaBindingSource, "cpf_Cnpj", true));
            this.cpf_cnpjMaskedTextBox.Location = new System.Drawing.Point(7, 127);
            this.cpf_cnpjMaskedTextBox.Name = "cpf_cnpjMaskedTextBox";
            this.cpf_cnpjMaskedTextBox.Size = new System.Drawing.Size(100, 20);
            this.cpf_cnpjMaskedTextBox.TabIndex = 25;
            this.cpf_cnpjMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // cepMaskedTextBox
            // 
            this.cepMaskedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_pessoaBindingSource, "cep", true));
            this.cepMaskedTextBox.Location = new System.Drawing.Point(121, 173);
            this.cepMaskedTextBox.Mask = "99.999-000";
            this.cepMaskedTextBox.Name = "cepMaskedTextBox";
            this.cepMaskedTextBox.Size = new System.Drawing.Size(100, 20);
            this.cepMaskedTextBox.TabIndex = 28;
            this.cepMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cepMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // fone1MaskedTextBox
            // 
            this.fone1MaskedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_pessoaBindingSource, "fone1", true));
            this.fone1MaskedTextBox.Location = new System.Drawing.Point(10, 216);
            this.fone1MaskedTextBox.Mask = "(99) 9999-9999";
            this.fone1MaskedTextBox.Name = "fone1MaskedTextBox";
            this.fone1MaskedTextBox.Size = new System.Drawing.Size(110, 20);
            this.fone1MaskedTextBox.TabIndex = 32;
            this.fone1MaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // fone2MaskedTextBox
            // 
            this.fone2MaskedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_pessoaBindingSource, "fone2", true));
            this.fone2MaskedTextBox.Location = new System.Drawing.Point(135, 216);
            this.fone2MaskedTextBox.Mask = "(99) 9999-9999";
            this.fone2MaskedTextBox.Name = "fone2MaskedTextBox";
            this.fone2MaskedTextBox.Size = new System.Drawing.Size(117, 20);
            this.fone2MaskedTextBox.TabIndex = 33;
            this.fone2MaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // limiteCompraMaskedTextBox
            // 
            this.limiteCompraMaskedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_pessoaBindingSource, "limiteCompra", true));
            this.limiteCompraMaskedTextBox.Location = new System.Drawing.Point(399, 216);
            this.limiteCompraMaskedTextBox.Name = "limiteCompraMaskedTextBox";
            this.limiteCompraMaskedTextBox.Size = new System.Drawing.Size(117, 20);
            this.limiteCompraMaskedTextBox.TabIndex = 35;
            this.limiteCompraMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // valorComissaoMaskedTextBox
            // 
            this.valorComissaoMaskedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_pessoaBindingSource, "valorComissao", true));
            this.valorComissaoMaskedTextBox.Location = new System.Drawing.Point(533, 216);
            this.valorComissaoMaskedTextBox.Name = "valorComissaoMaskedTextBox";
            this.valorComissaoMaskedTextBox.Size = new System.Drawing.Size(62, 20);
            this.valorComissaoMaskedTextBox.TabIndex = 36;
            this.valorComissaoMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // cpf_cnpjErrorProvider
            // 
            this.cpf_cnpjErrorProvider.ContainerControl = this;
            // 
            // ieTextBox
            // 
            this.ieTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_pessoaBindingSource, "ie", true));
            this.ieTextBox.Location = new System.Drawing.Point(7, 174);
            this.ieTextBox.Name = "ieTextBox";
            this.ieTextBox.Size = new System.Drawing.Size(100, 20);
            this.ieTextBox.TabIndex = 27;
            // 
            // fone3TextBox
            // 
            this.fone3TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_pessoaBindingSource, "fone3", true));
            this.fone3TextBox.Location = new System.Drawing.Point(271, 216);
            this.fone3TextBox.Name = "fone3TextBox";
            this.fone3TextBox.Size = new System.Drawing.Size(117, 20);
            this.fone3TextBox.TabIndex = 34;
            // 
            // tb_contato_empresaDataGridView
            // 
            this.tb_contato_empresaDataGridView.AllowUserToAddRows = false;
            this.tb_contato_empresaDataGridView.AllowUserToDeleteRows = false;
            this.tb_contato_empresaDataGridView.AutoGenerateColumns = false;
            this.tb_contato_empresaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_contato_empresaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.tb_contato_empresaDataGridView.DataSource = this.tb_contato_empresaBindingSource;
            this.tb_contato_empresaDataGridView.Location = new System.Drawing.Point(7, 331);
            this.tb_contato_empresaDataGridView.Name = "tb_contato_empresaDataGridView";
            this.tb_contato_empresaDataGridView.ReadOnly = true;
            this.tb_contato_empresaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_contato_empresaDataGridView.Size = new System.Drawing.Size(588, 91);
            this.tb_contato_empresaDataGridView.TabIndex = 51;
            this.tb_contato_empresaDataGridView.TabStop = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "codigoEmpresa";
            this.dataGridViewTextBoxColumn1.HeaderText = "codigoEmpresa";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "codPessoa";
            this.dataGridViewTextBoxColumn2.HeaderText = "Cod Pessoa";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "nome";
            this.dataGridViewTextBoxColumn3.FillWeight = 500F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Nome";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "cpf_Cnpj";
            this.dataGridViewTextBoxColumn7.HeaderText = "CPF / CNPJ";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "fone1";
            this.dataGridViewTextBoxColumn4.HeaderText = "Fone 1";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "fone2";
            this.dataGridViewTextBoxColumn5.HeaderText = "Fone 2";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "fone3";
            this.dataGridViewTextBoxColumn6.HeaderText = "Fone 3";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // tb_contato_empresaBindingSource
            // 
            this.tb_contato_empresaBindingSource.DataMember = "tb_contato_empresa";
            this.tb_contato_empresaBindingSource.DataSource = this.saceDataSet;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(88, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 63;
            this.label2.Text = "DEL - Excluir";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(7, 314);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 62;
            this.label6.Text = "F12 - Navegar";
            // 
            // btnAdicionarContato
            // 
            this.btnAdicionarContato.Location = new System.Drawing.Point(480, 304);
            this.btnAdicionarContato.Name = "btnAdicionarContato";
            this.btnAdicionarContato.Size = new System.Drawing.Size(114, 23);
            this.btnAdicionarContato.TabIndex = 38;
            this.btnAdicionarContato.Text = "F7 - Buscar Contato";
            this.btnAdicionarContato.UseVisualStyleBackColor = true;
            this.btnAdicionarContato.Click += new System.EventHandler(this.btnAdicionarContato_Click);
            // 
            // tb_pessoaTableAdapter
            // 
            this.tb_pessoaTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.tb_baixa_contaTableAdapter = null;
            this.tableAdapterManager.tb_bancoTableAdapter = null;
            this.tableAdapterManager.tb_cartao_creditoTableAdapter = null;
            this.tableAdapterManager.tb_cfopTableAdapter = null;
            this.tableAdapterManager.tb_configuracao_sistemaTableAdapter = null;
            this.tableAdapterManager.tb_conta_bancoTableAdapter = null;
            this.tableAdapterManager.tb_contaTableAdapter = null;
            this.tableAdapterManager.tb_contato_empresaTableAdapter = this.tb_contato_empresaTableAdapter1;
            this.tableAdapterManager.tb_entrada_produtoTableAdapter = null;
            this.tableAdapterManager.tb_entradaTableAdapter = null;
            this.tableAdapterManager.tb_forma_pagamentoTableAdapter = null;
            this.tableAdapterManager.tb_funcionalidadeTableAdapter = null;
            this.tableAdapterManager.tb_grupo_contaTableAdapter = null;
            this.tableAdapterManager.tb_grupoTableAdapter = null;
            this.tableAdapterManager.tb_lojaTableAdapter = null;
            this.tableAdapterManager.tb_movimentacao_contaTableAdapter = null;
            this.tableAdapterManager.tb_perfil_funcionalidadeTableAdapter = null;
            this.tableAdapterManager.tb_perfilTableAdapter = null;
            this.tableAdapterManager.tb_permissaoTableAdapter = null;
            this.tableAdapterManager.tb_pessoaTableAdapter = this.tb_pessoaTableAdapter;
            this.tableAdapterManager.tb_plano_contaTableAdapter = null;
            this.tableAdapterManager.tb_produto_lojaTableAdapter = null;
            this.tableAdapterManager.tb_produtoTableAdapter = null;
            this.tableAdapterManager.tb_saida_produtoTableAdapter = null;
            this.tableAdapterManager.tb_saidaTableAdapter = null;
            this.tableAdapterManager.tb_tipo_movimentacao_contaTableAdapter = null;
            this.tableAdapterManager.tb_usuarioTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Dados.saceDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tb_contato_empresaTableAdapter1
            // 
            this.tb_contato_empresaTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmPessoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 454);
            this.Controls.Add(this.btnAdicionarContato);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_contato_empresaDataGridView);
            this.Controls.Add(fone3Label);
            this.Controls.Add(this.fone3TextBox);
            this.Controls.Add(ieLabel);
            this.Controls.Add(this.ieTextBox);
            this.Controls.Add(this.valorComissaoMaskedTextBox);
            this.Controls.Add(this.limiteCompraMaskedTextBox);
            this.Controls.Add(this.fone2MaskedTextBox);
            this.Controls.Add(this.fone1MaskedTextBox);
            this.Controls.Add(this.cepMaskedTextBox);
            this.Controls.Add(this.cpf_cnpjMaskedTextBox);
            this.Controls.Add(this.cpfLabel);
            this.Controls.Add(this.nomeLabel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(ufLabel);
            this.Controls.Add(this.ufTextBox);
            this.Controls.Add(this.enderecoTextBox);
            this.Controls.Add(cepLabel);
            this.Controls.Add(codPessoaLabel);
            this.Controls.Add(this.tb_pessoaBindingNavigator);
            this.Controls.Add(this.codPessoaTextBox);
            this.Controls.Add(this.nomeTextBox);
            this.Controls.Add(enderecoLabel);
            this.Controls.Add(bairroLabel);
            this.Controls.Add(this.bairroTextBox);
            this.Controls.Add(cidadeLabel);
            this.Controls.Add(this.cidadeTextBox);
            this.Controls.Add(fone1Label);
            this.Controls.Add(fone2Label);
            this.Controls.Add(limiteCompraLabel);
            this.Controls.Add(valorComissaoLabel);
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
            ((System.ComponentModel.ISupportInitialize)(this.tb_pessoaBindingNavigator)).EndInit();
            this.tb_pessoaBindingNavigator.ResumeLayout(false);
            this.tb_pessoaBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_pessoaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpf_cnpjErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_contato_empresaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_contato_empresaBindingSource)).EndInit();
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
        private Dados.saceDataSet saceDataSet;
        private System.Windows.Forms.BindingSource tb_pessoaBindingSource;
        private Dados.saceDataSetTableAdapters.tb_pessoaTableAdapter tb_pessoaTableAdapter;
        private Dados.saceDataSetTableAdapters.TableAdapterManager tableAdapterManager;
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
        private System.Windows.Forms.TextBox bairroTextBox;
        private System.Windows.Forms.TextBox cidadeTextBox;
        private System.Windows.Forms.TextBox observacaoTextBox;
        private System.Windows.Forms.TextBox enderecoTextBox;
        private System.Windows.Forms.TextBox ufTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton PjRadioButton;
        private System.Windows.Forms.RadioButton PfRadioButton;
        private System.Windows.Forms.Label nomeLabel;
        private System.Windows.Forms.Label cpfLabel;
        private System.Windows.Forms.MaskedTextBox cpf_cnpjMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox cepMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox fone1MaskedTextBox;
        private System.Windows.Forms.MaskedTextBox fone2MaskedTextBox;
        private System.Windows.Forms.MaskedTextBox limiteCompraMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox valorComissaoMaskedTextBox;
        private System.Windows.Forms.ErrorProvider cpf_cnpjErrorProvider;
        private System.Windows.Forms.DataGridView tb_contato_empresaDataGridView;
        private System.Windows.Forms.BindingSource tb_contato_empresaBindingSource;
        private System.Windows.Forms.TextBox fone3TextBox;
        private System.Windows.Forms.TextBox ieTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAdicionarContato;
        private Dados.saceDataSetTableAdapters.tb_contato_empresaTableAdapter tb_contato_empresaTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}