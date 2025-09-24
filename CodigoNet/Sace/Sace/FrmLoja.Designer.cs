namespace Sace
{
    partial class FrmLoja
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
            Label codLojaLabel;
            Label nomeLabel;
            Label codPessoaLabel;
            Label cpf_CnpjLabel;
            Label ieLabel;
            Label cidadeLabel;
            Label nomeServidorNfeLabel;
            Label pastaNfeAutorizadosLabel;
            Label pastaNfeEnviadoLabel;
            Label pastaNfeEnvioLabel;
            Label pastaNfeErroLabel;
            Label pastaNfeEspelhoLabel;
            Label pastaNfeRetornoLabel;
            Label numeroSequenciaNfeAtualLabel;
            Label label2;
            Label pastaNfeValidadoLabel;
            Label pastaNfeValidarLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoja));
            label1 = new Label();
            panel1 = new Panel();
            btnSalvar = new Button();
            btnBuscar = new Button();
            btnCancelar = new Button();
            btnNovo = new Button();
            btnExcluir = new Button();
            btnEditar = new Button();
            lojaBindingSource = new BindingSource(components);
            tb_lojaBindingNavigator = new BindingNavigator(components);
            bindingNavigatorCountItem = new ToolStripLabel();
            bindingNavigatorMoveFirstItem = new ToolStripButton();
            bindingNavigatorMovePreviousItem = new ToolStripButton();
            bindingNavigatorSeparator = new ToolStripSeparator();
            bindingNavigatorPositionItem = new ToolStripTextBox();
            bindingNavigatorSeparator1 = new ToolStripSeparator();
            bindingNavigatorMoveNextItem = new ToolStripButton();
            bindingNavigatorMoveLastItem = new ToolStripButton();
            bindingNavigatorSeparator2 = new ToolStripSeparator();
            codLojaTextBox = new MaskedTextBox();
            nomeTextBox = new TextBox();
            codPessoaComboBox = new ComboBox();
            pessoaBindingSource = new BindingSource(components);
            cpf_CnpjTextBox = new TextBox();
            ieTextBox = new TextBox();
            cidadeTextBox = new TextBox();
            nomeServidorNfeTextBox = new TextBox();
            pastaNfeAutorizadosTextBox = new TextBox();
            pastaNfeEnviadoTextBox = new TextBox();
            pastaNfeEnvioTextBox = new TextBox();
            pastaNfeErroTextBox = new TextBox();
            pastaNfeEspelhoTextBox = new TextBox();
            pastaNfeRetornoTextBox = new TextBox();
            numeroSequenciaNfeAtualTextBox = new TextBox();
            numeroSequenciaNFCeAtual = new TextBox();
            pastaNfeValidadoTextBox = new TextBox();
            pastaNfeValidarTextBox = new TextBox();
            codLojaLabel = new Label();
            nomeLabel = new Label();
            codPessoaLabel = new Label();
            cpf_CnpjLabel = new Label();
            ieLabel = new Label();
            cidadeLabel = new Label();
            nomeServidorNfeLabel = new Label();
            pastaNfeAutorizadosLabel = new Label();
            pastaNfeEnviadoLabel = new Label();
            pastaNfeEnvioLabel = new Label();
            pastaNfeErroLabel = new Label();
            pastaNfeEspelhoLabel = new Label();
            pastaNfeRetornoLabel = new Label();
            numeroSequenciaNfeAtualLabel = new Label();
            label2 = new Label();
            pastaNfeValidadoLabel = new Label();
            pastaNfeValidarLabel = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lojaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tb_lojaBindingNavigator).BeginInit();
            tb_lojaBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pessoaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // codLojaLabel
            // 
            codLojaLabel.AutoSize = true;
            codLojaLabel.Location = new Point(7, 83);
            codLojaLabel.Margin = new Padding(4, 0, 4, 0);
            codLojaLabel.Name = "codLojaLabel";
            codLojaLabel.Size = new Size(49, 15);
            codLojaLabel.TabIndex = 21;
            codLojaLabel.Text = "Código:";
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Location = new Point(140, 83);
            nomeLabel.Margin = new Padding(4, 0, 4, 0);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new Size(43, 15);
            nomeLabel.TabIndex = 23;
            nomeLabel.Text = "Nome:";
            // 
            // codPessoaLabel
            // 
            codPessoaLabel.AutoSize = true;
            codPessoaLabel.Location = new Point(7, 143);
            codPessoaLabel.Margin = new Padding(4, 0, 4, 0);
            codPessoaLabel.Name = "codPessoaLabel";
            codPessoaLabel.Size = new Size(145, 15);
            codPessoaLabel.TabIndex = 24;
            codPessoaLabel.Text = "Pessoa Jurídica Associada:";
            // 
            // cpf_CnpjLabel
            // 
            cpf_CnpjLabel.AutoSize = true;
            cpf_CnpjLabel.Location = new Point(7, 198);
            cpf_CnpjLabel.Margin = new Padding(4, 0, 4, 0);
            cpf_CnpjLabel.Name = "cpf_CnpjLabel";
            cpf_CnpjLabel.Size = new Size(35, 15);
            cpf_CnpjLabel.TabIndex = 26;
            cpf_CnpjLabel.Text = "Cnpj:";
            // 
            // ieLabel
            // 
            ieLabel.AutoSize = true;
            ieLabel.Location = new Point(202, 198);
            ieLabel.Margin = new Padding(4, 0, 4, 0);
            ieLabel.Name = "ieLabel";
            ieLabel.Size = new Size(104, 15);
            ieLabel.TabIndex = 27;
            ieLabel.Text = "Inscrição Estadual:";
            // 
            // cidadeLabel
            // 
            cidadeLabel.AutoSize = true;
            cidadeLabel.Location = new Point(359, 202);
            cidadeLabel.Margin = new Padding(4, 0, 4, 0);
            cidadeLabel.Name = "cidadeLabel";
            cidadeLabel.Size = new Size(47, 15);
            cidadeLabel.TabIndex = 28;
            cidadeLabel.Text = "Cidade:";
            // 
            // nomeServidorNfeLabel
            // 
            nomeServidorNfeLabel.AutoSize = true;
            nomeServidorNfeLabel.Location = new Point(10, 249);
            nomeServidorNfeLabel.Margin = new Padding(4, 0, 4, 0);
            nomeServidorNfeLabel.Name = "nomeServidorNfeLabel";
            nomeServidorNfeLabel.Size = new Size(111, 15);
            nomeServidorNfeLabel.TabIndex = 29;
            nomeServidorNfeLabel.Text = "Nome Servidor Nfe:";
            // 
            // pastaNfeAutorizadosLabel
            // 
            pastaNfeAutorizadosLabel.AutoSize = true;
            pastaNfeAutorizadosLabel.Location = new Point(5, 301);
            pastaNfeAutorizadosLabel.Margin = new Padding(4, 0, 4, 0);
            pastaNfeAutorizadosLabel.Name = "pastaNfeAutorizadosLabel";
            pastaNfeAutorizadosLabel.Size = new Size(126, 15);
            pastaNfeAutorizadosLabel.TabIndex = 30;
            pastaNfeAutorizadosLabel.Text = "Pasta Nfe Autorizados:";
            // 
            // pastaNfeEnviadoLabel
            // 
            pastaNfeEnviadoLabel.AutoSize = true;
            pastaNfeEnviadoLabel.Location = new Point(359, 305);
            pastaNfeEnviadoLabel.Margin = new Padding(4, 0, 4, 0);
            pastaNfeEnviadoLabel.Name = "pastaNfeEnviadoLabel";
            pastaNfeEnviadoLabel.Size = new Size(105, 15);
            pastaNfeEnviadoLabel.TabIndex = 31;
            pastaNfeEnviadoLabel.Text = "Pasta Nfe Enviado:";
            // 
            // pastaNfeEnvioLabel
            // 
            pastaNfeEnvioLabel.AutoSize = true;
            pastaNfeEnvioLabel.Location = new Point(5, 354);
            pastaNfeEnvioLabel.Margin = new Padding(4, 0, 4, 0);
            pastaNfeEnvioLabel.Name = "pastaNfeEnvioLabel";
            pastaNfeEnvioLabel.Size = new Size(92, 15);
            pastaNfeEnvioLabel.TabIndex = 32;
            pastaNfeEnvioLabel.Text = "Pasta Nfe Envio:";
            // 
            // pastaNfeErroLabel
            // 
            pastaNfeErroLabel.AutoSize = true;
            pastaNfeErroLabel.Location = new Point(359, 350);
            pastaNfeErroLabel.Margin = new Padding(4, 0, 4, 0);
            pastaNfeErroLabel.Name = "pastaNfeErroLabel";
            pastaNfeErroLabel.Size = new Size(84, 15);
            pastaNfeErroLabel.TabIndex = 33;
            pastaNfeErroLabel.Text = "Pasta Nfe Erro:";
            // 
            // pastaNfeEspelhoLabel
            // 
            pastaNfeEspelhoLabel.AutoSize = true;
            pastaNfeEspelhoLabel.Location = new Point(9, 402);
            pastaNfeEspelhoLabel.Margin = new Padding(4, 0, 4, 0);
            pastaNfeEspelhoLabel.Name = "pastaNfeEspelhoLabel";
            pastaNfeEspelhoLabel.Size = new Size(104, 15);
            pastaNfeEspelhoLabel.TabIndex = 34;
            pastaNfeEspelhoLabel.Text = "Pasta Nfe Espelho:";
            // 
            // pastaNfeRetornoLabel
            // 
            pastaNfeRetornoLabel.AutoSize = true;
            pastaNfeRetornoLabel.Location = new Point(360, 402);
            pastaNfeRetornoLabel.Margin = new Padding(4, 0, 4, 0);
            pastaNfeRetornoLabel.Name = "pastaNfeRetornoLabel";
            pastaNfeRetornoLabel.Size = new Size(105, 15);
            pastaNfeRetornoLabel.TabIndex = 35;
            pastaNfeRetornoLabel.Text = "Pasta Nfe Retorno:";
            // 
            // numeroSequenciaNfeAtualLabel
            // 
            numeroSequenciaNfeAtualLabel.AutoSize = true;
            numeroSequenciaNfeAtualLabel.Location = new Point(559, 249);
            numeroSequenciaNfeAtualLabel.Margin = new Padding(4, 0, 4, 0);
            numeroSequenciaNfeAtualLabel.Name = "numeroSequenciaNfeAtualLabel";
            numeroSequenciaNfeAtualLabel.Size = new Size(78, 15);
            numeroSequenciaNfeAtualLabel.TabIndex = 36;
            numeroSequenciaNfeAtualLabel.Text = "Numero NFe:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(359, 249);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 38;
            label2.Text = "Numero NFCe:";
            // 
            // pastaNfeValidadoLabel
            // 
            pastaNfeValidadoLabel.AutoSize = true;
            pastaNfeValidadoLabel.Location = new Point(360, 448);
            pastaNfeValidadoLabel.Margin = new Padding(4, 0, 4, 0);
            pastaNfeValidadoLabel.Name = "pastaNfeValidadoLabel";
            pastaNfeValidadoLabel.Size = new Size(164, 15);
            pastaNfeValidadoLabel.TabIndex = 38;
            pastaNfeValidadoLabel.Text = "Pasta Nfe em Processamento:";
            // 
            // pastaNfeValidarLabel
            // 
            pastaNfeValidarLabel.AutoSize = true;
            pastaNfeValidarLabel.Location = new Point(9, 448);
            pastaNfeValidarLabel.Margin = new Padding(4, 0, 4, 0);
            pastaNfeValidarLabel.Name = "pastaNfeValidarLabel";
            pastaNfeValidarLabel.Size = new Size(98, 15);
            pastaNfeValidarLabel.TabIndex = 40;
            pastaNfeValidarLabel.Text = "Pasta Nfe Validar:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(4, 10);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(140, 23);
            label1.TabIndex = 0;
            label1.Text = "Cadastro de Lojas";
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, -1);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(716, 47);
            panel1.TabIndex = 20;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(361, 508);
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
            btnBuscar.Location = new Point(10, 508);
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
            btnCancelar.Location = new Point(455, 508);
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
            btnNovo.Location = new Point(98, 508);
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
            btnExcluir.Location = new Point(273, 508);
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
            btnEditar.Location = new Point(186, 508);
            btnEditar.Margin = new Padding(4, 3, 4, 3);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(88, 27);
            btnEditar.TabIndex = 2;
            btnEditar.Text = "F4 - Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // lojaBindingSource
            // 
            lojaBindingSource.DataSource = typeof(Dominio.Loja);
            lojaBindingSource.Sort = "codLoja";
            // 
            // tb_lojaBindingNavigator
            // 
            tb_lojaBindingNavigator.AddNewItem = null;
            tb_lojaBindingNavigator.BindingSource = lojaBindingSource;
            tb_lojaBindingNavigator.CountItem = bindingNavigatorCountItem;
            tb_lojaBindingNavigator.DeleteItem = null;
            tb_lojaBindingNavigator.Dock = DockStyle.None;
            tb_lojaBindingNavigator.Items.AddRange(new ToolStripItem[] { bindingNavigatorMoveFirstItem, bindingNavigatorMovePreviousItem, bindingNavigatorSeparator, bindingNavigatorPositionItem, bindingNavigatorCountItem, bindingNavigatorSeparator1, bindingNavigatorMoveNextItem, bindingNavigatorMoveLastItem, bindingNavigatorSeparator2 });
            tb_lojaBindingNavigator.Location = new Point(498, 50);
            tb_lojaBindingNavigator.MoveFirstItem = bindingNavigatorMoveFirstItem;
            tb_lojaBindingNavigator.MoveLastItem = bindingNavigatorMoveLastItem;
            tb_lojaBindingNavigator.MoveNextItem = bindingNavigatorMoveNextItem;
            tb_lojaBindingNavigator.MovePreviousItem = bindingNavigatorMovePreviousItem;
            tb_lojaBindingNavigator.Name = "tb_lojaBindingNavigator";
            tb_lojaBindingNavigator.PositionItem = bindingNavigatorPositionItem;
            tb_lojaBindingNavigator.Size = new Size(217, 25);
            tb_lojaBindingNavigator.TabIndex = 21;
            tb_lojaBindingNavigator.Text = "bindingNavigator1";
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
            // codLojaTextBox
            // 
            codLojaTextBox.DataBindings.Add(new Binding("Text", lojaBindingSource, "CodLoja", true));
            codLojaTextBox.Location = new Point(10, 103);
            codLojaTextBox.Margin = new Padding(4, 3, 4, 3);
            codLojaTextBox.Name = "codLojaTextBox";
            codLojaTextBox.ReadOnly = true;
            codLojaTextBox.Size = new Size(116, 23);
            codLojaTextBox.TabIndex = 22;
            codLojaTextBox.TabStop = false;
            // 
            // nomeTextBox
            // 
            nomeTextBox.CharacterCasing = CharacterCasing.Upper;
            nomeTextBox.DataBindings.Add(new Binding("Text", lojaBindingSource, "Nome", true));
            nomeTextBox.Location = new Point(144, 103);
            nomeTextBox.Margin = new Padding(4, 3, 4, 3);
            nomeTextBox.MaxLength = 40;
            nomeTextBox.Name = "nomeTextBox";
            nomeTextBox.Size = new Size(560, 23);
            nomeTextBox.TabIndex = 24;
            nomeTextBox.Leave += nomeTextBox_Leave;
            // 
            // codPessoaComboBox
            // 
            codPessoaComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            codPessoaComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            codPessoaComboBox.DataBindings.Add(new Binding("SelectedValue", lojaBindingSource, "CodPessoa", true));
            codPessoaComboBox.DataSource = pessoaBindingSource;
            codPessoaComboBox.DisplayMember = "NomeFantasia";
            codPessoaComboBox.FormattingEnabled = true;
            codPessoaComboBox.Location = new Point(10, 162);
            codPessoaComboBox.Margin = new Padding(4, 3, 4, 3);
            codPessoaComboBox.Name = "codPessoaComboBox";
            codPessoaComboBox.Size = new Size(694, 23);
            codPessoaComboBox.TabIndex = 25;
            codPessoaComboBox.ValueMember = "CodPessoa";
            codPessoaComboBox.KeyPress += codPessoaComboBox_KeyPress;
            codPessoaComboBox.Leave += codPessoaComboBox_Leave;
            // 
            // pessoaBindingSource
            // 
            pessoaBindingSource.DataSource = typeof(Dominio.Pessoa);
            // 
            // cpf_CnpjTextBox
            // 
            cpf_CnpjTextBox.DataBindings.Add(new Binding("Text", pessoaBindingSource, "CpfCnpj", true));
            cpf_CnpjTextBox.Location = new Point(10, 219);
            cpf_CnpjTextBox.Margin = new Padding(4, 3, 4, 3);
            cpf_CnpjTextBox.Name = "cpf_CnpjTextBox";
            cpf_CnpjTextBox.ReadOnly = true;
            cpf_CnpjTextBox.Size = new Size(166, 23);
            cpf_CnpjTextBox.TabIndex = 27;
            cpf_CnpjTextBox.TabStop = false;
            // 
            // ieTextBox
            // 
            ieTextBox.DataBindings.Add(new Binding("Text", pessoaBindingSource, "Ie", true));
            ieTextBox.Location = new Point(198, 219);
            ieTextBox.Margin = new Padding(4, 3, 4, 3);
            ieTextBox.Name = "ieTextBox";
            ieTextBox.ReadOnly = true;
            ieTextBox.Size = new Size(144, 23);
            ieTextBox.TabIndex = 28;
            ieTextBox.TabStop = false;
            // 
            // cidadeTextBox
            // 
            cidadeTextBox.DataBindings.Add(new Binding("Text", pessoaBindingSource, "Cidade", true));
            cidadeTextBox.Location = new Point(362, 223);
            cidadeTextBox.Margin = new Padding(4, 3, 4, 3);
            cidadeTextBox.Name = "cidadeTextBox";
            cidadeTextBox.ReadOnly = true;
            cidadeTextBox.Size = new Size(342, 23);
            cidadeTextBox.TabIndex = 29;
            cidadeTextBox.TabStop = false;
            // 
            // nomeServidorNfeTextBox
            // 
            nomeServidorNfeTextBox.DataBindings.Add(new Binding("Text", lojaBindingSource, "NomeServidorNfe", true));
            nomeServidorNfeTextBox.Location = new Point(10, 275);
            nomeServidorNfeTextBox.Margin = new Padding(4, 3, 4, 3);
            nomeServidorNfeTextBox.Name = "nomeServidorNfeTextBox";
            nomeServidorNfeTextBox.Size = new Size(344, 23);
            nomeServidorNfeTextBox.TabIndex = 30;
            // 
            // pastaNfeAutorizadosTextBox
            // 
            pastaNfeAutorizadosTextBox.DataBindings.Add(new Binding("Text", lojaBindingSource, "PastaNfeAutorizados", true));
            pastaNfeAutorizadosTextBox.Location = new Point(10, 323);
            pastaNfeAutorizadosTextBox.Margin = new Padding(4, 3, 4, 3);
            pastaNfeAutorizadosTextBox.Name = "pastaNfeAutorizadosTextBox";
            pastaNfeAutorizadosTextBox.Size = new Size(344, 23);
            pastaNfeAutorizadosTextBox.TabIndex = 31;
            // 
            // pastaNfeEnviadoTextBox
            // 
            pastaNfeEnviadoTextBox.DataBindings.Add(new Binding("Text", lojaBindingSource, "PastaNfeEnviado", true));
            pastaNfeEnviadoTextBox.Location = new Point(362, 323);
            pastaNfeEnviadoTextBox.Margin = new Padding(4, 3, 4, 3);
            pastaNfeEnviadoTextBox.Name = "pastaNfeEnviadoTextBox";
            pastaNfeEnviadoTextBox.Size = new Size(339, 23);
            pastaNfeEnviadoTextBox.TabIndex = 32;
            // 
            // pastaNfeEnvioTextBox
            // 
            pastaNfeEnvioTextBox.DataBindings.Add(new Binding("Text", lojaBindingSource, "PastaNfeEnvio", true));
            pastaNfeEnvioTextBox.Location = new Point(10, 373);
            pastaNfeEnvioTextBox.Margin = new Padding(4, 3, 4, 3);
            pastaNfeEnvioTextBox.Name = "pastaNfeEnvioTextBox";
            pastaNfeEnvioTextBox.Size = new Size(344, 23);
            pastaNfeEnvioTextBox.TabIndex = 33;
            // 
            // pastaNfeErroTextBox
            // 
            pastaNfeErroTextBox.DataBindings.Add(new Binding("Text", lojaBindingSource, "PastaNfeErro", true));
            pastaNfeErroTextBox.Location = new Point(362, 373);
            pastaNfeErroTextBox.Margin = new Padding(4, 3, 4, 3);
            pastaNfeErroTextBox.Name = "pastaNfeErroTextBox";
            pastaNfeErroTextBox.Size = new Size(339, 23);
            pastaNfeErroTextBox.TabIndex = 34;
            // 
            // pastaNfeEspelhoTextBox
            // 
            pastaNfeEspelhoTextBox.DataBindings.Add(new Binding("Text", lojaBindingSource, "PastaNfeEspelho", true));
            pastaNfeEspelhoTextBox.Location = new Point(10, 420);
            pastaNfeEspelhoTextBox.Margin = new Padding(4, 3, 4, 3);
            pastaNfeEspelhoTextBox.Name = "pastaNfeEspelhoTextBox";
            pastaNfeEspelhoTextBox.Size = new Size(344, 23);
            pastaNfeEspelhoTextBox.TabIndex = 35;
            // 
            // pastaNfeRetornoTextBox
            // 
            pastaNfeRetornoTextBox.DataBindings.Add(new Binding("Text", lojaBindingSource, "PastaNfeRetorno", true));
            pastaNfeRetornoTextBox.Location = new Point(362, 420);
            pastaNfeRetornoTextBox.Margin = new Padding(4, 3, 4, 3);
            pastaNfeRetornoTextBox.Name = "pastaNfeRetornoTextBox";
            pastaNfeRetornoTextBox.Size = new Size(339, 23);
            pastaNfeRetornoTextBox.TabIndex = 36;
            // 
            // numeroSequenciaNfeAtualTextBox
            // 
            numeroSequenciaNfeAtualTextBox.DataBindings.Add(new Binding("Text", lojaBindingSource, "NumeroSequenciaNfeAtual", true));
            numeroSequenciaNfeAtualTextBox.Location = new Point(566, 275);
            numeroSequenciaNfeAtualTextBox.Margin = new Padding(4, 3, 4, 3);
            numeroSequenciaNfeAtualTextBox.Name = "numeroSequenciaNfeAtualTextBox";
            numeroSequenciaNfeAtualTextBox.ReadOnly = true;
            numeroSequenciaNfeAtualTextBox.Size = new Size(138, 23);
            numeroSequenciaNfeAtualTextBox.TabIndex = 37;
            numeroSequenciaNfeAtualTextBox.TabStop = false;
            // 
            // numeroSequenciaNFCeAtual
            // 
            numeroSequenciaNFCeAtual.DataBindings.Add(new Binding("Text", lojaBindingSource, "NumeroSequenciaNFCeAtual", true));
            numeroSequenciaNFCeAtual.Location = new Point(362, 275);
            numeroSequenciaNFCeAtual.Margin = new Padding(4, 3, 4, 3);
            numeroSequenciaNFCeAtual.Name = "numeroSequenciaNFCeAtual";
            numeroSequenciaNFCeAtual.ReadOnly = true;
            numeroSequenciaNFCeAtual.Size = new Size(162, 23);
            numeroSequenciaNFCeAtual.TabIndex = 36;
            numeroSequenciaNFCeAtual.TabStop = false;
            // 
            // pastaNfeValidadoTextBox
            // 
            pastaNfeValidadoTextBox.DataBindings.Add(new Binding("Text", lojaBindingSource, "PastaNfeValidado", true));
            pastaNfeValidadoTextBox.Location = new Point(363, 467);
            pastaNfeValidadoTextBox.Margin = new Padding(4, 3, 4, 3);
            pastaNfeValidadoTextBox.Name = "pastaNfeValidadoTextBox";
            pastaNfeValidadoTextBox.Size = new Size(338, 23);
            pastaNfeValidadoTextBox.TabIndex = 40;
            // 
            // pastaNfeValidarTextBox
            // 
            pastaNfeValidarTextBox.DataBindings.Add(new Binding("Text", lojaBindingSource, "PastaNfeValidar", true));
            pastaNfeValidarTextBox.Location = new Point(10, 467);
            pastaNfeValidarTextBox.Margin = new Padding(4, 3, 4, 3);
            pastaNfeValidarTextBox.Name = "pastaNfeValidarTextBox";
            pastaNfeValidarTextBox.Size = new Size(345, 23);
            pastaNfeValidarTextBox.TabIndex = 38;
            // 
            // FrmLoja
            // 
            AccessibleDescription = "'";
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(717, 538);
            Controls.Add(pastaNfeValidarLabel);
            Controls.Add(pastaNfeValidarTextBox);
            Controls.Add(pastaNfeValidadoLabel);
            Controls.Add(pastaNfeValidadoTextBox);
            Controls.Add(label2);
            Controls.Add(numeroSequenciaNFCeAtual);
            Controls.Add(numeroSequenciaNfeAtualLabel);
            Controls.Add(numeroSequenciaNfeAtualTextBox);
            Controls.Add(pastaNfeRetornoLabel);
            Controls.Add(pastaNfeRetornoTextBox);
            Controls.Add(pastaNfeEspelhoLabel);
            Controls.Add(pastaNfeEspelhoTextBox);
            Controls.Add(pastaNfeErroLabel);
            Controls.Add(pastaNfeErroTextBox);
            Controls.Add(pastaNfeEnvioLabel);
            Controls.Add(pastaNfeEnvioTextBox);
            Controls.Add(pastaNfeEnviadoLabel);
            Controls.Add(pastaNfeEnviadoTextBox);
            Controls.Add(pastaNfeAutorizadosLabel);
            Controls.Add(pastaNfeAutorizadosTextBox);
            Controls.Add(nomeServidorNfeLabel);
            Controls.Add(nomeServidorNfeTextBox);
            Controls.Add(cidadeLabel);
            Controls.Add(cidadeTextBox);
            Controls.Add(ieLabel);
            Controls.Add(ieTextBox);
            Controls.Add(cpf_CnpjLabel);
            Controls.Add(cpf_CnpjTextBox);
            Controls.Add(codPessoaLabel);
            Controls.Add(codPessoaComboBox);
            Controls.Add(codLojaLabel);
            Controls.Add(tb_lojaBindingNavigator);
            Controls.Add(codLojaTextBox);
            Controls.Add(nomeLabel);
            Controls.Add(nomeTextBox);
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
            Name = "FrmLoja";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cadastro Lojas";
            Load += FrmLoja_Load;
            KeyDown += FrmLoja_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lojaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)tb_lojaBindingNavigator).EndInit();
            tb_lojaBindingNavigator.ResumeLayout(false);
            tb_lojaBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pessoaBindingSource).EndInit();
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
        private System.Windows.Forms.BindingSource lojaBindingSource;
        private System.Windows.Forms.BindingNavigator tb_lojaBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.MaskedTextBox codLojaTextBox;
        private System.Windows.Forms.TextBox nomeTextBox;
        private System.Windows.Forms.ComboBox codPessoaComboBox;
        private System.Windows.Forms.TextBox cpf_CnpjTextBox;
        private System.Windows.Forms.TextBox ieTextBox;
        private System.Windows.Forms.TextBox cidadeTextBox;
        private System.Windows.Forms.BindingSource pessoaBindingSource;
        private System.Windows.Forms.TextBox nomeServidorNfeTextBox;
        private System.Windows.Forms.TextBox pastaNfeAutorizadosTextBox;
        private System.Windows.Forms.TextBox pastaNfeEnviadoTextBox;
        private System.Windows.Forms.TextBox pastaNfeEnvioTextBox;
        private System.Windows.Forms.TextBox pastaNfeErroTextBox;
        private System.Windows.Forms.TextBox pastaNfeEspelhoTextBox;
        private System.Windows.Forms.TextBox pastaNfeRetornoTextBox;
        private System.Windows.Forms.TextBox numeroSequenciaNfeAtualTextBox;
        private System.Windows.Forms.TextBox numeroSequenciaNFCeAtual;
        private System.Windows.Forms.TextBox pastaNfeValidadoTextBox;
        private System.Windows.Forms.TextBox pastaNfeValidarTextBox;
    }
}