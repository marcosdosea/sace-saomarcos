namespace Sace
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
            components = new System.ComponentModel.Container();
            Label codPessoaLabel;
            Label enderecoLabel;
            Label cidadeLabel;
            Label fone1Label;
            Label fone2Label;
            Label limiteCompraLabel;
            Label valorComissaoLabel;
            Label observacaoLabel;
            Label ufLabel;
            Label ieLabel;
            Label fone3Label;
            Label emailLabel;
            Label ieSubstitutoLabel;
            Label complementoLabel;
            Label nomeLabel1;
            Label bairroLabel;
            Label cepLabel;
            Label numeroLabel;
            Label cidadeLabel1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPessoa));
            label1 = new Label();
            panel1 = new Panel();
            btnSalvar = new Button();
            btnBuscar = new Button();
            btnCancelar = new Button();
            btnNovo = new Button();
            btnExcluir = new Button();
            btnEditar = new Button();
            tb_pessoaBindingNavigator = new BindingNavigator(components);
            pessoaBindingSource = new BindingSource(components);
            bindingNavigatorCountItem = new ToolStripLabel();
            bindingNavigatorMoveFirstItem = new ToolStripButton();
            bindingNavigatorMovePreviousItem = new ToolStripButton();
            bindingNavigatorSeparator = new ToolStripSeparator();
            bindingNavigatorPositionItem = new ToolStripTextBox();
            bindingNavigatorSeparator1 = new ToolStripSeparator();
            bindingNavigatorMoveNextItem = new ToolStripButton();
            bindingNavigatorMoveLastItem = new ToolStripButton();
            bindingNavigatorSeparator2 = new ToolStripSeparator();
            codPessoaTextBox = new MaskedTextBox();
            nomeFantasiaTextBox = new TextBox();
            bairroTextBox = new TextBox();
            observacaoTextBox = new TextBox();
            enderecoTextBox = new TextBox();
            ufTextBox = new TextBox();
            municipiosIBGEBindingSource = new BindingSource(components);
            groupBox1 = new GroupBox();
            PjRadioButton = new RadioButton();
            PfRadioButton = new RadioButton();
            nomeLabel = new Label();
            cpfLabel = new Label();
            fone1MaskedTextBox = new MaskedTextBox();
            fone2MaskedTextBox = new MaskedTextBox();
            cpf_cnpjErrorProvider = new ErrorProvider(components);
            ieTextBox = new TextBox();
            fone3TextBox = new MaskedTextBox();
            tb_contato_empresaDataGridView = new DataGridView();
            contatosBindingSource = new BindingSource(components);
            label2 = new Label();
            label6 = new Label();
            btnAdicionarContato = new Button();
            emailTextBox = new TextBox();
            ieSubstitutoTextBox = new TextBox();
            numeroTextBox = new TextBox();
            complementoTextBox = new TextBox();
            limiteCompraTextBox = new TextBox();
            valorComissaoTextBox = new TextBox();
            cpf_CnpjTextBox = new TextBox();
            ehFabricanteCheckBox = new CheckBox();
            imprimirDAVCheckBox = new CheckBox();
            imprimirCFCheckBox = new CheckBox();
            nomeTextBox = new TextBox();
            cepMaskedTextBox = new MaskedTextBox();
            cidadeTextBox = new TextBox();
            codMunicipioIBGEComboBox = new ComboBox();
            bloquearCrediarioCheckBox = new CheckBox();
            codPessoaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeFantasiaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fone1DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            fone2DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            codPessoaLabel = new Label();
            enderecoLabel = new Label();
            cidadeLabel = new Label();
            fone1Label = new Label();
            fone2Label = new Label();
            limiteCompraLabel = new Label();
            valorComissaoLabel = new Label();
            observacaoLabel = new Label();
            ufLabel = new Label();
            ieLabel = new Label();
            fone3Label = new Label();
            emailLabel = new Label();
            ieSubstitutoLabel = new Label();
            complementoLabel = new Label();
            nomeLabel1 = new Label();
            bairroLabel = new Label();
            cepLabel = new Label();
            numeroLabel = new Label();
            cidadeLabel1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tb_pessoaBindingNavigator).BeginInit();
            tb_pessoaBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pessoaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)municipiosIBGEBindingSource).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cpf_cnpjErrorProvider).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tb_contato_empresaDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)contatosBindingSource).BeginInit();
            SuspendLayout();
            // 
            // codPessoaLabel
            // 
            codPessoaLabel.AutoSize = true;
            codPessoaLabel.Location = new Point(5, 80);
            codPessoaLabel.Margin = new Padding(4, 0, 4, 0);
            codPessoaLabel.Name = "codPessoaLabel";
            codPessoaLabel.Size = new Size(49, 15);
            codPessoaLabel.TabIndex = 21;
            codPessoaLabel.Text = "Código:";
            // 
            // enderecoLabel
            // 
            enderecoLabel.AutoSize = true;
            enderecoLabel.Location = new Point(8, 232);
            enderecoLabel.Margin = new Padding(4, 0, 4, 0);
            enderecoLabel.Name = "enderecoLabel";
            enderecoLabel.Size = new Size(59, 15);
            enderecoLabel.TabIndex = 25;
            enderecoLabel.Text = "Endereço:";
            // 
            // cidadeLabel
            // 
            cidadeLabel.AutoSize = true;
            cidadeLabel.Location = new Point(8, 335);
            cidadeLabel.Margin = new Padding(4, 0, 4, 0);
            cidadeLabel.Name = "cidadeLabel";
            cidadeLabel.Size = new Size(47, 15);
            cidadeLabel.TabIndex = 33;
            cidadeLabel.Text = "Cidade:";
            // 
            // fone1Label
            // 
            fone1Label.AutoSize = true;
            fone1Label.Location = new Point(8, 384);
            fone1Label.Margin = new Padding(4, 0, 4, 0);
            fone1Label.Name = "fone1Label";
            fone1Label.Size = new Size(42, 15);
            fone1Label.TabIndex = 35;
            fone1Label.Text = "Fone1:";
            // 
            // fone2Label
            // 
            fone2Label.AutoSize = true;
            fone2Label.Location = new Point(154, 384);
            fone2Label.Margin = new Padding(4, 0, 4, 0);
            fone2Label.Name = "fone2Label";
            fone2Label.Size = new Size(42, 15);
            fone2Label.TabIndex = 37;
            fone2Label.Text = "Fone2:";
            // 
            // limiteCompraLabel
            // 
            limiteCompraLabel.AutoSize = true;
            limiteCompraLabel.Location = new Point(424, 384);
            limiteCompraLabel.Margin = new Padding(4, 0, 4, 0);
            limiteCompraLabel.Name = "limiteCompraLabel";
            limiteCompraLabel.Size = new Size(89, 15);
            limiteCompraLabel.TabIndex = 39;
            limiteCompraLabel.Text = "Limite Compra:";
            // 
            // valorComissaoLabel
            // 
            valorComissaoLabel.AutoSize = true;
            valorComissaoLabel.Location = new Point(552, 384);
            valorComissaoLabel.Margin = new Padding(4, 0, 4, 0);
            valorComissaoLabel.Name = "valorComissaoLabel";
            valorComissaoLabel.Size = new Size(75, 15);
            valorComissaoLabel.TabIndex = 41;
            valorComissaoLabel.Text = "% Comissão:";
            // 
            // observacaoLabel
            // 
            observacaoLabel.AutoSize = true;
            observacaoLabel.Location = new Point(5, 433);
            observacaoLabel.Margin = new Padding(4, 0, 4, 0);
            observacaoLabel.Name = "observacaoLabel";
            observacaoLabel.Size = new Size(72, 15);
            observacaoLabel.TabIndex = 43;
            observacaoLabel.Text = "Observação:";
            // 
            // ufLabel
            // 
            ufLabel.AutoSize = true;
            ufLabel.Location = new Point(472, 287);
            ufLabel.Margin = new Padding(4, 0, 4, 0);
            ufLabel.Name = "ufLabel";
            ufLabel.Size = new Size(24, 15);
            ufLabel.TabIndex = 46;
            ufLabel.Text = "UF:";
            // 
            // ieLabel
            // 
            ieLabel.AutoSize = true;
            ieLabel.Location = new Point(138, 179);
            ieLabel.Margin = new Padding(4, 0, 4, 0);
            ieLabel.Name = "ieLabel";
            ieLabel.Size = new Size(101, 15);
            ieLabel.TabIndex = 49;
            ieLabel.Text = "Insc Estadual / RG";
            // 
            // fone3Label
            // 
            fone3Label.AutoSize = true;
            fone3Label.Location = new Point(298, 384);
            fone3Label.Margin = new Padding(4, 0, 4, 0);
            fone3Label.Name = "fone3Label";
            fone3Label.Size = new Size(42, 15);
            fone3Label.TabIndex = 50;
            fone3Label.Text = "Fone3:";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(468, 335);
            emailLabel.Margin = new Padding(4, 0, 4, 0);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(39, 15);
            emailLabel.TabIndex = 63;
            emailLabel.Text = "Email:";
            // 
            // ieSubstitutoLabel
            // 
            ieSubstitutoLabel.AutoSize = true;
            ieSubstitutoLabel.Location = new Point(294, 179);
            ieSubstitutoLabel.Margin = new Padding(4, 0, 4, 0);
            ieSubstitutoLabel.Name = "ieSubstitutoLabel";
            ieSubstitutoLabel.Size = new Size(106, 15);
            ieSubstitutoLabel.TabIndex = 63;
            ieSubstitutoLabel.Text = "Insc Est Substituto:";
            // 
            // complementoLabel
            // 
            complementoLabel.AutoSize = true;
            complementoLabel.Location = new Point(8, 287);
            complementoLabel.Margin = new Padding(4, 0, 4, 0);
            complementoLabel.Name = "complementoLabel";
            complementoLabel.Size = new Size(87, 15);
            complementoLabel.TabIndex = 65;
            complementoLabel.Text = "Complemento:";
            // 
            // nomeLabel1
            // 
            nomeLabel1.AutoSize = true;
            nomeLabel1.Location = new Point(8, 126);
            nomeLabel1.Margin = new Padding(4, 0, 4, 0);
            nomeLabel1.Name = "nomeLabel1";
            nomeLabel1.Size = new Size(43, 15);
            nomeLabel1.TabIndex = 68;
            nomeLabel1.Text = "Nome:";
            // 
            // bairroLabel
            // 
            bairroLabel.AutoSize = true;
            bairroLabel.Location = new Point(552, 232);
            bairroLabel.Margin = new Padding(4, 0, 4, 0);
            bairroLabel.Name = "bairroLabel";
            bairroLabel.Size = new Size(41, 15);
            bairroLabel.TabIndex = 31;
            bairroLabel.Text = "Bairro:";
            // 
            // cepLabel
            // 
            cepLabel.AutoSize = true;
            cepLabel.Location = new Point(472, 180);
            cepLabel.Margin = new Padding(4, 0, 4, 0);
            cepLabel.Name = "cepLabel";
            cepLabel.Size = new Size(31, 15);
            cepLabel.TabIndex = 44;
            cepLabel.Text = "CEP:";
            // 
            // numeroLabel
            // 
            numeroLabel.AutoSize = true;
            numeroLabel.Location = new Point(472, 231);
            numeroLabel.Margin = new Padding(4, 0, 4, 0);
            numeroLabel.Name = "numeroLabel";
            numeroLabel.Size = new Size(54, 15);
            numeroLabel.TabIndex = 64;
            numeroLabel.Text = "Número:";
            // 
            // cidadeLabel1
            // 
            cidadeLabel1.AutoSize = true;
            cidadeLabel1.ForeColor = Color.Red;
            cidadeLabel1.Location = new Point(552, 287);
            cidadeLabel1.Margin = new Padding(4, 0, 4, 0);
            cidadeLabel1.Name = "cidadeLabel1";
            cidadeLabel1.Size = new Size(109, 15);
            cidadeLabel1.TabIndex = 69;
            cidadeLabel1.Text = "Cidade Cadastrada:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(4, 10);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(155, 23);
            label1.TabIndex = 0;
            label1.Text = "Cadastro de Pessoas";
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, -1);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(748, 47);
            panel1.TabIndex = 20;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(358, 695);
            btnSalvar.Margin = new Padding(4, 3, 4, 3);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(94, 27);
            btnSalvar.TabIndex = 4;
            btnSalvar.Text = "F6 - Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(8, 695);
            btnBuscar.Margin = new Padding(4, 3, 4, 3);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(88, 27);
            btnBuscar.TabIndex = 0;
            btnBuscar.Text = "F2 - Buscar";
            btnBuscar.TextAlign = ContentAlignment.MiddleLeft;
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(453, 695);
            btnCancelar.Margin = new Padding(4, 3, 4, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(98, 27);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Esc - Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnNovo
            // 
            btnNovo.Location = new Point(96, 695);
            btnNovo.Margin = new Padding(4, 3, 4, 3);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(88, 27);
            btnNovo.TabIndex = 1;
            btnNovo.Text = "F3 - Novo";
            btnNovo.UseVisualStyleBackColor = true;
            btnNovo.Click += btnNovo_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(271, 695);
            btnExcluir.Margin = new Padding(4, 3, 4, 3);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(88, 27);
            btnExcluir.TabIndex = 3;
            btnExcluir.Text = "F5 - Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(183, 695);
            btnEditar.Margin = new Padding(4, 3, 4, 3);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(88, 27);
            btnEditar.TabIndex = 2;
            btnEditar.Text = "F4 - Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // tb_pessoaBindingNavigator
            // 
            tb_pessoaBindingNavigator.AddNewItem = null;
            tb_pessoaBindingNavigator.BindingSource = pessoaBindingSource;
            tb_pessoaBindingNavigator.CountItem = bindingNavigatorCountItem;
            tb_pessoaBindingNavigator.DeleteItem = null;
            tb_pessoaBindingNavigator.Dock = DockStyle.None;
            tb_pessoaBindingNavigator.Items.AddRange(new ToolStripItem[] { bindingNavigatorMoveFirstItem, bindingNavigatorMovePreviousItem, bindingNavigatorSeparator, bindingNavigatorPositionItem, bindingNavigatorCountItem, bindingNavigatorSeparator1, bindingNavigatorMoveNextItem, bindingNavigatorMoveLastItem, bindingNavigatorSeparator2 });
            tb_pessoaBindingNavigator.Location = new Point(509, 47);
            tb_pessoaBindingNavigator.MoveFirstItem = bindingNavigatorMoveFirstItem;
            tb_pessoaBindingNavigator.MoveLastItem = bindingNavigatorMoveLastItem;
            tb_pessoaBindingNavigator.MoveNextItem = bindingNavigatorMoveNextItem;
            tb_pessoaBindingNavigator.MovePreviousItem = bindingNavigatorMovePreviousItem;
            tb_pessoaBindingNavigator.Name = "tb_pessoaBindingNavigator";
            tb_pessoaBindingNavigator.PositionItem = bindingNavigatorPositionItem;
            tb_pessoaBindingNavigator.Size = new Size(217, 25);
            tb_pessoaBindingNavigator.TabIndex = 21;
            tb_pessoaBindingNavigator.Text = "bindingNavigator1";
            // 
            // pessoaBindingSource
            // 
            pessoaBindingSource.DataSource = typeof(Dominio.Pessoa);
            pessoaBindingSource.CurrentItemChanged += pessoaBindingSource_CurrentItemChanged;
            pessoaBindingSource.PositionChanged += pessoaBindingSource_PositionChanged;
            // 
            // bindingNavigatorCountItem
            // 
            bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            bindingNavigatorCountItem.Size = new Size(35, 22);
            bindingNavigatorCountItem.Text = "of {0}";
            bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            bindingNavigatorMoveFirstItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            bindingNavigatorMoveFirstItem.Image = (Image)resources.GetObject("bindingNavigatorMoveFirstItem.Image");
            bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMoveFirstItem.Size = new Size(23, 22);
            bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            bindingNavigatorMovePreviousItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            bindingNavigatorMovePreviousItem.Image = (Image)resources.GetObject("bindingNavigatorMovePreviousItem.Image");
            bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMovePreviousItem.Size = new Size(23, 22);
            bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            bindingNavigatorSeparator.Size = new Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            bindingNavigatorPositionItem.AccessibleName = "Position";
            bindingNavigatorPositionItem.AutoSize = false;
            bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            bindingNavigatorPositionItem.Size = new Size(58, 23);
            bindingNavigatorPositionItem.Text = "0";
            bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            bindingNavigatorSeparator1.Size = new Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            bindingNavigatorMoveNextItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            bindingNavigatorMoveNextItem.Image = (Image)resources.GetObject("bindingNavigatorMoveNextItem.Image");
            bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMoveNextItem.Size = new Size(23, 22);
            bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            bindingNavigatorMoveLastItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            bindingNavigatorMoveLastItem.Image = (Image)resources.GetObject("bindingNavigatorMoveLastItem.Image");
            bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMoveLastItem.Size = new Size(23, 22);
            bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            bindingNavigatorSeparator2.Size = new Size(6, 25);
            // 
            // codPessoaTextBox
            // 
            codPessoaTextBox.DataBindings.Add(new Binding("Text", pessoaBindingSource, "CodPessoa", true));
            codPessoaTextBox.Location = new Point(8, 99);
            codPessoaTextBox.Margin = new Padding(4, 3, 4, 3);
            codPessoaTextBox.Name = "codPessoaTextBox";
            codPessoaTextBox.ReadOnly = true;
            codPessoaTextBox.Size = new Size(116, 23);
            codPessoaTextBox.TabIndex = 22;
            codPessoaTextBox.TabStop = false;
            codPessoaTextBox.TextChanged += codPessoaTextBox_TextChanged;
            // 
            // nomeFantasiaTextBox
            // 
            nomeFantasiaTextBox.CharacterCasing = CharacterCasing.Upper;
            nomeFantasiaTextBox.DataBindings.Add(new Binding("Text", pessoaBindingSource, "NomeFantasia", true));
            nomeFantasiaTextBox.Location = new Point(136, 99);
            nomeFantasiaTextBox.Margin = new Padding(4, 3, 4, 3);
            nomeFantasiaTextBox.MaxLength = 50;
            nomeFantasiaTextBox.Name = "nomeFantasiaTextBox";
            nomeFantasiaTextBox.Size = new Size(452, 23);
            nomeFantasiaTextBox.TabIndex = 24;
            nomeFantasiaTextBox.Leave += nomeFantasiaTextBox_Leave;
            // 
            // bairroTextBox
            // 
            bairroTextBox.CharacterCasing = CharacterCasing.Upper;
            bairroTextBox.DataBindings.Add(new Binding("Text", pessoaBindingSource, "Bairro", true));
            bairroTextBox.Location = new Point(555, 250);
            bairroTextBox.Margin = new Padding(4, 3, 4, 3);
            bairroTextBox.MaxLength = 40;
            bairroTextBox.Name = "bairroTextBox";
            bairroTextBox.Size = new Size(187, 23);
            bairroTextBox.TabIndex = 40;
            bairroTextBox.Leave += nomeTextBox_Leave;
            // 
            // observacaoTextBox
            // 
            observacaoTextBox.CharacterCasing = CharacterCasing.Upper;
            observacaoTextBox.DataBindings.Add(new Binding("Text", pessoaBindingSource, "Observacao", true));
            observacaoTextBox.Location = new Point(8, 452);
            observacaoTextBox.Margin = new Padding(4, 3, 4, 3);
            observacaoTextBox.MaxLength = 300;
            observacaoTextBox.Multiline = true;
            observacaoTextBox.Name = "observacaoTextBox";
            observacaoTextBox.Size = new Size(734, 92);
            observacaoTextBox.TabIndex = 64;
            // 
            // enderecoTextBox
            // 
            enderecoTextBox.CharacterCasing = CharacterCasing.Upper;
            enderecoTextBox.DataBindings.Add(new Binding("Text", pessoaBindingSource, "Endereco", true));
            enderecoTextBox.Location = new Point(12, 250);
            enderecoTextBox.Margin = new Padding(4, 3, 4, 3);
            enderecoTextBox.MaxLength = 50;
            enderecoTextBox.Name = "enderecoTextBox";
            enderecoTextBox.Size = new Size(448, 23);
            enderecoTextBox.TabIndex = 36;
            enderecoTextBox.Leave += nomeTextBox_Leave;
            // 
            // ufTextBox
            // 
            ufTextBox.CharacterCasing = CharacterCasing.Upper;
            ufTextBox.DataBindings.Add(new Binding("Text", municipiosIBGEBindingSource, "uf", true));
            ufTextBox.Enabled = false;
            ufTextBox.Location = new Point(471, 307);
            ufTextBox.Margin = new Padding(4, 3, 4, 3);
            ufTextBox.MaxLength = 2;
            ufTextBox.Name = "ufTextBox";
            ufTextBox.Size = new Size(74, 23);
            ufTextBox.TabIndex = 44;
            // 
            // municipiosIBGEBindingSource
            // 
            municipiosIBGEBindingSource.AllowNew = false;
            municipiosIBGEBindingSource.DataSource = typeof(Dominio.MunicipiosIBGE);
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(PjRadioButton);
            groupBox1.Controls.Add(PfRadioButton);
            groupBox1.Location = new Point(596, 78);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(153, 47);
            groupBox1.TabIndex = 26;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tipo:";
            // 
            // PjRadioButton
            // 
            PjRadioButton.AutoSize = true;
            PjRadioButton.Location = new Point(74, 14);
            PjRadioButton.Margin = new Padding(4, 3, 4, 3);
            PjRadioButton.Name = "PjRadioButton";
            PjRadioButton.Size = new Size(65, 19);
            PjRadioButton.TabIndex = 1;
            PjRadioButton.Text = "Jurídica";
            PjRadioButton.UseVisualStyleBackColor = true;
            // 
            // PfRadioButton
            // 
            PfRadioButton.AutoSize = true;
            PfRadioButton.Checked = true;
            PfRadioButton.Location = new Point(8, 14);
            PfRadioButton.Margin = new Padding(4, 3, 4, 3);
            PfRadioButton.Name = "PfRadioButton";
            PfRadioButton.Size = new Size(54, 19);
            PfRadioButton.TabIndex = 0;
            PfRadioButton.TabStop = true;
            PfRadioButton.Text = "Física";
            PfRadioButton.UseVisualStyleBackColor = true;
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Location = new Point(138, 80);
            nomeLabel.Margin = new Padding(4, 0, 4, 0);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new Size(89, 15);
            nomeLabel.TabIndex = 48;
            nomeLabel.Text = "Nome Fantasia:";
            // 
            // cpfLabel
            // 
            cpfLabel.AutoSize = true;
            cpfLabel.Location = new Point(8, 180);
            cpfLabel.Margin = new Padding(4, 0, 4, 0);
            cpfLabel.Name = "cpfLabel";
            cpfLabel.Size = new Size(69, 15);
            cpfLabel.TabIndex = 49;
            cpfLabel.Text = "CNPJ / CPF:";
            // 
            // fone1MaskedTextBox
            // 
            fone1MaskedTextBox.DataBindings.Add(new Binding("Text", pessoaBindingSource, "Fone1", true));
            fone1MaskedTextBox.Location = new Point(12, 403);
            fone1MaskedTextBox.Margin = new Padding(4, 3, 4, 3);
            fone1MaskedTextBox.Mask = "(99) 9999-9999";
            fone1MaskedTextBox.Name = "fone1MaskedTextBox";
            fone1MaskedTextBox.Size = new Size(128, 23);
            fone1MaskedTextBox.TabIndex = 51;
            fone1MaskedTextBox.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // fone2MaskedTextBox
            // 
            fone2MaskedTextBox.DataBindings.Add(new Binding("Text", pessoaBindingSource, "Fone2", true));
            fone2MaskedTextBox.Location = new Point(158, 403);
            fone2MaskedTextBox.Margin = new Padding(4, 3, 4, 3);
            fone2MaskedTextBox.Mask = "(99) 9999-9999";
            fone2MaskedTextBox.Name = "fone2MaskedTextBox";
            fone2MaskedTextBox.Size = new Size(121, 23);
            fone2MaskedTextBox.TabIndex = 52;
            fone2MaskedTextBox.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // cpf_cnpjErrorProvider
            // 
            cpf_cnpjErrorProvider.ContainerControl = this;
            // 
            // ieTextBox
            // 
            ieTextBox.CharacterCasing = CharacterCasing.Upper;
            ieTextBox.DataBindings.Add(new Binding("Text", pessoaBindingSource, "Ie", true));
            ieTextBox.Location = new Point(136, 198);
            ieTextBox.Margin = new Padding(4, 3, 4, 3);
            ieTextBox.MaxLength = 20;
            ieTextBox.Name = "ieTextBox";
            ieTextBox.Size = new Size(142, 23);
            ieTextBox.TabIndex = 30;
            // 
            // fone3TextBox
            // 
            fone3TextBox.DataBindings.Add(new Binding("Text", pessoaBindingSource, "Fone3", true));
            fone3TextBox.Location = new Point(298, 403);
            fone3TextBox.Margin = new Padding(4, 3, 4, 3);
            fone3TextBox.Mask = "(99) 9999-9999";
            fone3TextBox.Name = "fone3TextBox";
            fone3TextBox.Size = new Size(119, 23);
            fone3TextBox.TabIndex = 54;
            fone3TextBox.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // tb_contato_empresaDataGridView
            // 
            tb_contato_empresaDataGridView.AllowUserToAddRows = false;
            tb_contato_empresaDataGridView.AllowUserToDeleteRows = false;
            tb_contato_empresaDataGridView.AutoGenerateColumns = false;
            tb_contato_empresaDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tb_contato_empresaDataGridView.Columns.AddRange(new DataGridViewColumn[] { codPessoaDataGridViewTextBoxColumn, nomeFantasiaDataGridViewTextBoxColumn, fone1DataGridViewTextBoxColumn, fone2DataGridViewTextBoxColumn });
            tb_contato_empresaDataGridView.DataSource = contatosBindingSource;
            tb_contato_empresaDataGridView.Location = new Point(8, 583);
            tb_contato_empresaDataGridView.Margin = new Padding(4, 3, 4, 3);
            tb_contato_empresaDataGridView.Name = "tb_contato_empresaDataGridView";
            tb_contato_empresaDataGridView.ReadOnly = true;
            tb_contato_empresaDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tb_contato_empresaDataGridView.Size = new Size(735, 105);
            tb_contato_empresaDataGridView.TabIndex = 68;
            tb_contato_empresaDataGridView.TabStop = false;
            // 
            // contatosBindingSource
            // 
            contatosBindingSource.DataSource = typeof(Dominio.Pessoa);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Red;
            label2.Location = new Point(103, 563);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 63;
            label2.Text = "DEL - Excluir";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Red;
            label6.Location = new Point(8, 563);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(80, 15);
            label6.TabIndex = 62;
            label6.Text = "F12 - Navegar";
            // 
            // btnAdicionarContato
            // 
            btnAdicionarContato.Location = new Point(610, 552);
            btnAdicionarContato.Margin = new Padding(4, 3, 4, 3);
            btnAdicionarContato.Name = "btnAdicionarContato";
            btnAdicionarContato.Size = new Size(133, 27);
            btnAdicionarContato.TabIndex = 66;
            btnAdicionarContato.Text = "F7 - Buscar Contato";
            btnAdicionarContato.UseVisualStyleBackColor = true;
            btnAdicionarContato.Click += btnAdicionarContato_Click;
            // 
            // emailTextBox
            // 
            emailTextBox.CharacterCasing = CharacterCasing.Lower;
            emailTextBox.DataBindings.Add(new Binding("Text", pessoaBindingSource, "Email", true));
            emailTextBox.Location = new Point(468, 353);
            emailTextBox.Margin = new Padding(4, 3, 4, 3);
            emailTextBox.MaxLength = 40;
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(275, 23);
            emailTextBox.TabIndex = 50;
            emailTextBox.Leave += nomeTextBox_Leave;
            // 
            // ieSubstitutoTextBox
            // 
            ieSubstitutoTextBox.CharacterCasing = CharacterCasing.Upper;
            ieSubstitutoTextBox.DataBindings.Add(new Binding("Text", pessoaBindingSource, "IeSubstituto", true));
            ieSubstitutoTextBox.Location = new Point(298, 198);
            ieSubstitutoTextBox.Margin = new Padding(4, 3, 4, 3);
            ieSubstitutoTextBox.MaxLength = 20;
            ieSubstitutoTextBox.Name = "ieSubstitutoTextBox";
            ieSubstitutoTextBox.Size = new Size(163, 23);
            ieSubstitutoTextBox.TabIndex = 32;
            // 
            // numeroTextBox
            // 
            numeroTextBox.CharacterCasing = CharacterCasing.Upper;
            numeroTextBox.DataBindings.Add(new Binding("Text", pessoaBindingSource, "Numero", true));
            numeroTextBox.Location = new Point(471, 250);
            numeroTextBox.Margin = new Padding(4, 3, 4, 3);
            numeroTextBox.MaxLength = 10;
            numeroTextBox.Name = "numeroTextBox";
            numeroTextBox.Size = new Size(74, 23);
            numeroTextBox.TabIndex = 38;
            // 
            // complementoTextBox
            // 
            complementoTextBox.CharacterCasing = CharacterCasing.Upper;
            complementoTextBox.DataBindings.Add(new Binding("Text", pessoaBindingSource, "Complemento", true));
            complementoTextBox.Location = new Point(12, 307);
            complementoTextBox.Margin = new Padding(4, 3, 4, 3);
            complementoTextBox.MaxLength = 40;
            complementoTextBox.Name = "complementoTextBox";
            complementoTextBox.Size = new Size(448, 23);
            complementoTextBox.TabIndex = 42;
            complementoTextBox.Leave += nomeTextBox_Leave;
            // 
            // limiteCompraTextBox
            // 
            limiteCompraTextBox.DataBindings.Add(new Binding("Text", pessoaBindingSource, "LimiteCompra", true));
            limiteCompraTextBox.Location = new Point(427, 403);
            limiteCompraTextBox.Margin = new Padding(4, 3, 4, 3);
            limiteCompraTextBox.Name = "limiteCompraTextBox";
            limiteCompraTextBox.Size = new Size(121, 23);
            limiteCompraTextBox.TabIndex = 56;
            limiteCompraTextBox.Leave += limiteCompraTextBox_Leave;
            // 
            // valorComissaoTextBox
            // 
            valorComissaoTextBox.DataBindings.Add(new Binding("Text", pessoaBindingSource, "ValorComissao", true));
            valorComissaoTextBox.Location = new Point(555, 403);
            valorComissaoTextBox.Margin = new Padding(4, 3, 4, 3);
            valorComissaoTextBox.Name = "valorComissaoTextBox";
            valorComissaoTextBox.Size = new Size(73, 23);
            valorComissaoTextBox.TabIndex = 58;
            valorComissaoTextBox.Leave += limiteCompraTextBox_Leave;
            // 
            // cpf_CnpjTextBox
            // 
            cpf_CnpjTextBox.DataBindings.Add(new Binding("Text", pessoaBindingSource, "CpfCnpj", true));
            cpf_CnpjTextBox.Location = new Point(8, 197);
            cpf_CnpjTextBox.Margin = new Padding(4, 3, 4, 3);
            cpf_CnpjTextBox.MaxLength = 14;
            cpf_CnpjTextBox.Name = "cpf_CnpjTextBox";
            cpf_CnpjTextBox.Size = new Size(116, 23);
            cpf_CnpjTextBox.TabIndex = 29;
            // 
            // ehFabricanteCheckBox
            // 
            ehFabricanteCheckBox.DataBindings.Add(new Binding("Checked", pessoaBindingSource, "EhFabricante", true));
            ehFabricanteCheckBox.Location = new Point(596, 148);
            ehFabricanteCheckBox.Margin = new Padding(4, 3, 4, 3);
            ehFabricanteCheckBox.Name = "ehFabricanteCheckBox";
            ehFabricanteCheckBox.Size = new Size(121, 28);
            ehFabricanteCheckBox.TabIndex = 28;
            ehFabricanteCheckBox.Text = "É Fabricante";
            ehFabricanteCheckBox.UseVisualStyleBackColor = true;
            // 
            // imprimirDAVCheckBox
            // 
            imprimirDAVCheckBox.DataBindings.Add(new Binding("Checked", pessoaBindingSource, "ImprimirDAV", true));
            imprimirDAVCheckBox.Location = new Point(636, 380);
            imprimirDAVCheckBox.Margin = new Padding(4, 3, 4, 3);
            imprimirDAVCheckBox.Name = "imprimirDAVCheckBox";
            imprimirDAVCheckBox.Size = new Size(107, 28);
            imprimirDAVCheckBox.TabIndex = 60;
            imprimirDAVCheckBox.Text = "Imprimir DAV";
            imprimirDAVCheckBox.UseVisualStyleBackColor = true;
            // 
            // imprimirCFCheckBox
            // 
            imprimirCFCheckBox.DataBindings.Add(new Binding("Checked", pessoaBindingSource, "ImprimirCF", true));
            imprimirCFCheckBox.Location = new Point(636, 404);
            imprimirCFCheckBox.Margin = new Padding(4, 3, 4, 3);
            imprimirCFCheckBox.Name = "imprimirCFCheckBox";
            imprimirCFCheckBox.Size = new Size(107, 28);
            imprimirCFCheckBox.TabIndex = 62;
            imprimirCFCheckBox.Text = "Imprimir NFe";
            imprimirCFCheckBox.UseVisualStyleBackColor = true;
            // 
            // nomeTextBox
            // 
            nomeTextBox.CharacterCasing = CharacterCasing.Upper;
            nomeTextBox.DataBindings.Add(new Binding("Text", pessoaBindingSource, "Nome", true));
            nomeTextBox.Location = new Point(8, 148);
            nomeTextBox.Margin = new Padding(4, 3, 4, 3);
            nomeTextBox.MaxLength = 50;
            nomeTextBox.Name = "nomeTextBox";
            nomeTextBox.Size = new Size(580, 23);
            nomeTextBox.TabIndex = 27;
            nomeTextBox.Leave += nomeTextBox_Leave;
            // 
            // cepMaskedTextBox
            // 
            cepMaskedTextBox.DataBindings.Add(new Binding("Text", pessoaBindingSource, "Cep", true));
            cepMaskedTextBox.Location = new Point(471, 197);
            cepMaskedTextBox.Margin = new Padding(4, 3, 4, 3);
            cepMaskedTextBox.Mask = "99.999-000";
            cepMaskedTextBox.Name = "cepMaskedTextBox";
            cepMaskedTextBox.Size = new Size(117, 23);
            cepMaskedTextBox.TabIndex = 34;
            cepMaskedTextBox.TextAlign = HorizontalAlignment.Right;
            cepMaskedTextBox.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            // 
            // cidadeTextBox
            // 
            cidadeTextBox.DataBindings.Add(new Binding("Text", pessoaBindingSource, "Cidade", true));
            cidadeTextBox.Enabled = false;
            cidadeTextBox.Location = new Point(555, 307);
            cidadeTextBox.Margin = new Padding(4, 3, 4, 3);
            cidadeTextBox.Name = "cidadeTextBox";
            cidadeTextBox.Size = new Size(187, 23);
            cidadeTextBox.TabIndex = 46;
            // 
            // codMunicipioIBGEComboBox
            // 
            codMunicipioIBGEComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            codMunicipioIBGEComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            codMunicipioIBGEComboBox.DataBindings.Add(new Binding("SelectedValue", pessoaBindingSource, "CodMunicipioIBGE", true));
            codMunicipioIBGEComboBox.DataBindings.Add(new Binding("Text", municipiosIBGEBindingSource, "Municipio", true, DataSourceUpdateMode.Never));
            codMunicipioIBGEComboBox.DataSource = municipiosIBGEBindingSource;
            codMunicipioIBGEComboBox.DisplayMember = "Municipio";
            codMunicipioIBGEComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            codMunicipioIBGEComboBox.FormattingEnabled = true;
            codMunicipioIBGEComboBox.Location = new Point(12, 352);
            codMunicipioIBGEComboBox.Margin = new Padding(4, 3, 4, 3);
            codMunicipioIBGEComboBox.Name = "codMunicipioIBGEComboBox";
            codMunicipioIBGEComboBox.Size = new Size(448, 23);
            codMunicipioIBGEComboBox.TabIndex = 48;
            codMunicipioIBGEComboBox.ValueMember = "Codigo";
            codMunicipioIBGEComboBox.KeyPress += codMunicipioIBGEComboBox_KeyPress;
            // 
            // bloquearCrediarioCheckBox
            // 
            bloquearCrediarioCheckBox.DataBindings.Add(new Binding("Checked", pessoaBindingSource, "BloquearCrediario", true, DataSourceUpdateMode.OnPropertyChanged));
            bloquearCrediarioCheckBox.Location = new Point(596, 193);
            bloquearCrediarioCheckBox.Margin = new Padding(4, 3, 4, 3);
            bloquearCrediarioCheckBox.Name = "bloquearCrediarioCheckBox";
            bloquearCrediarioCheckBox.Size = new Size(152, 29);
            bloquearCrediarioCheckBox.TabIndex = 35;
            bloquearCrediarioCheckBox.Text = "Crediário Bloqueado";
            bloquearCrediarioCheckBox.UseVisualStyleBackColor = true;
            // 
            // codPessoaDataGridViewTextBoxColumn
            // 
            codPessoaDataGridViewTextBoxColumn.DataPropertyName = "CodPessoa";
            codPessoaDataGridViewTextBoxColumn.HeaderText = "CodPessoa";
            codPessoaDataGridViewTextBoxColumn.Name = "codPessoaDataGridViewTextBoxColumn";
            codPessoaDataGridViewTextBoxColumn.ReadOnly = true;
            codPessoaDataGridViewTextBoxColumn.Visible = false;
            // 
            // nomeFantasiaDataGridViewTextBoxColumn
            // 
            nomeFantasiaDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nomeFantasiaDataGridViewTextBoxColumn.DataPropertyName = "NomeFantasia";
            nomeFantasiaDataGridViewTextBoxColumn.HeaderText = "Nome Fantasia";
            nomeFantasiaDataGridViewTextBoxColumn.Name = "nomeFantasiaDataGridViewTextBoxColumn";
            nomeFantasiaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fone1DataGridViewTextBoxColumn
            // 
            fone1DataGridViewTextBoxColumn.DataPropertyName = "Fone1";
            fone1DataGridViewTextBoxColumn.HeaderText = "Fone1";
            fone1DataGridViewTextBoxColumn.Name = "fone1DataGridViewTextBoxColumn";
            fone1DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fone2DataGridViewTextBoxColumn
            // 
            fone2DataGridViewTextBoxColumn.DataPropertyName = "Fone2";
            fone2DataGridViewTextBoxColumn.HeaderText = "Fone2";
            fone2DataGridViewTextBoxColumn.Name = "fone2DataGridViewTextBoxColumn";
            fone2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FrmPessoa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(749, 725);
            Controls.Add(bloquearCrediarioCheckBox);
            Controls.Add(codMunicipioIBGEComboBox);
            Controls.Add(cidadeLabel1);
            Controls.Add(cidadeTextBox);
            Controls.Add(nomeLabel1);
            Controls.Add(nomeTextBox);
            Controls.Add(imprimirCFCheckBox);
            Controls.Add(imprimirDAVCheckBox);
            Controls.Add(ehFabricanteCheckBox);
            Controls.Add(cpf_CnpjTextBox);
            Controls.Add(valorComissaoTextBox);
            Controls.Add(limiteCompraTextBox);
            Controls.Add(complementoLabel);
            Controls.Add(complementoTextBox);
            Controls.Add(numeroLabel);
            Controls.Add(numeroTextBox);
            Controls.Add(ieSubstitutoLabel);
            Controls.Add(ieSubstitutoTextBox);
            Controls.Add(emailLabel);
            Controls.Add(emailTextBox);
            Controls.Add(btnAdicionarContato);
            Controls.Add(label2);
            Controls.Add(label6);
            Controls.Add(tb_contato_empresaDataGridView);
            Controls.Add(fone3Label);
            Controls.Add(fone3TextBox);
            Controls.Add(ieLabel);
            Controls.Add(ieTextBox);
            Controls.Add(fone2MaskedTextBox);
            Controls.Add(fone1MaskedTextBox);
            Controls.Add(cepMaskedTextBox);
            Controls.Add(cpfLabel);
            Controls.Add(nomeLabel);
            Controls.Add(groupBox1);
            Controls.Add(ufLabel);
            Controls.Add(ufTextBox);
            Controls.Add(enderecoTextBox);
            Controls.Add(cepLabel);
            Controls.Add(codPessoaLabel);
            Controls.Add(tb_pessoaBindingNavigator);
            Controls.Add(codPessoaTextBox);
            Controls.Add(nomeFantasiaTextBox);
            Controls.Add(enderecoLabel);
            Controls.Add(bairroLabel);
            Controls.Add(bairroTextBox);
            Controls.Add(cidadeLabel);
            Controls.Add(fone1Label);
            Controls.Add(fone2Label);
            Controls.Add(limiteCompraLabel);
            Controls.Add(valorComissaoLabel);
            Controls.Add(observacaoLabel);
            Controls.Add(observacaoTextBox);
            Controls.Add(btnSalvar);
            Controls.Add(btnBuscar);
            Controls.Add(btnCancelar);
            Controls.Add(btnNovo);
            Controls.Add(btnExcluir);
            Controls.Add(btnEditar);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmPessoa";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro Pessoas";
            FormClosing += FrmPessoa_FormClosing;
            Load += FrmPessoa_Load;
            KeyDown += FrmPessoa_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tb_pessoaBindingNavigator).EndInit();
            tb_pessoaBindingNavigator.ResumeLayout(false);
            tb_pessoaBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pessoaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)municipiosIBGEBindingSource).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cpf_cnpjErrorProvider).EndInit();
            ((System.ComponentModel.ISupportInitialize)tb_contato_empresaDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)contatosBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();

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
        private System.Windows.Forms.MaskedTextBox codPessoaTextBox;
        private System.Windows.Forms.TextBox nomeFantasiaTextBox;
        private System.Windows.Forms.TextBox bairroTextBox;
        private System.Windows.Forms.TextBox observacaoTextBox;
        private System.Windows.Forms.TextBox enderecoTextBox;
        private System.Windows.Forms.TextBox ufTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton PjRadioButton;
        private System.Windows.Forms.RadioButton PfRadioButton;
        private System.Windows.Forms.Label nomeLabel;
        private System.Windows.Forms.Label cpfLabel;
        private System.Windows.Forms.MaskedTextBox fone1MaskedTextBox;
        private System.Windows.Forms.MaskedTextBox fone2MaskedTextBox;
        private System.Windows.Forms.ErrorProvider cpf_cnpjErrorProvider;
        private System.Windows.Forms.DataGridView tb_contato_empresaDataGridView;
        private System.Windows.Forms.MaskedTextBox fone3TextBox;
        private System.Windows.Forms.TextBox ieTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAdicionarContato;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.TextBox numeroTextBox;
        private System.Windows.Forms.TextBox ieSubstitutoTextBox;
        private System.Windows.Forms.TextBox complementoTextBox;
        private System.Windows.Forms.TextBox valorComissaoTextBox;
        private System.Windows.Forms.TextBox limiteCompraTextBox;
        private System.Windows.Forms.TextBox cpf_CnpjTextBox;
        private System.Windows.Forms.CheckBox ehFabricanteCheckBox;
        private System.Windows.Forms.CheckBox imprimirCFCheckBox;
        private System.Windows.Forms.CheckBox imprimirDAVCheckBox;
        private System.Windows.Forms.TextBox nomeTextBox;
        private System.Windows.Forms.MaskedTextBox cepMaskedTextBox;
        private System.Windows.Forms.BindingSource pessoaBindingSource;
        private System.Windows.Forms.BindingSource contatosBindingSource;
        private System.Windows.Forms.BindingSource municipiosIBGEBindingSource;
        private System.Windows.Forms.TextBox cidadeTextBox;
        private System.Windows.Forms.ComboBox codMunicipioIBGEComboBox;
        private System.Windows.Forms.CheckBox bloquearCrediarioCheckBox;
        private DataGridViewTextBoxColumn codPessoaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeFantasiaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fone1DataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fone2DataGridViewTextBoxColumn;
    }
}