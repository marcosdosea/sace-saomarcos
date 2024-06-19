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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label codLojaLabel;
            System.Windows.Forms.Label nomeLabel;
            System.Windows.Forms.Label codPessoaLabel;
            System.Windows.Forms.Label cpf_CnpjLabel;
            System.Windows.Forms.Label ieLabel;
            System.Windows.Forms.Label cidadeLabel;
            System.Windows.Forms.Label nomeServidorNfeLabel;
            System.Windows.Forms.Label pastaNfeAutorizadosLabel;
            System.Windows.Forms.Label pastaNfeEnviadoLabel;
            System.Windows.Forms.Label pastaNfeEnvioLabel;
            System.Windows.Forms.Label pastaNfeErroLabel;
            System.Windows.Forms.Label pastaNfeEspelhoLabel;
            System.Windows.Forms.Label pastaNfeRetornoLabel;
            System.Windows.Forms.Label numeroSequenciaNfeAtualLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label pastaNfeValidadoLabel;
            System.Windows.Forms.Label pastaNfeValidarLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoja));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.lojaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_lojaBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.codLojaTextBox = new System.Windows.Forms.MaskedTextBox();
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.codPessoaComboBox = new System.Windows.Forms.ComboBox();
            this.pessoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cpf_CnpjTextBox = new System.Windows.Forms.TextBox();
            this.ieTextBox = new System.Windows.Forms.TextBox();
            this.cidadeTextBox = new System.Windows.Forms.TextBox();
            this.nomeServidorNfeTextBox = new System.Windows.Forms.TextBox();
            this.pastaNfeAutorizadosTextBox = new System.Windows.Forms.TextBox();
            this.pastaNfeEnviadoTextBox = new System.Windows.Forms.TextBox();
            this.pastaNfeEnvioTextBox = new System.Windows.Forms.TextBox();
            this.pastaNfeErroTextBox = new System.Windows.Forms.TextBox();
            this.pastaNfeEspelhoTextBox = new System.Windows.Forms.TextBox();
            this.pastaNfeRetornoTextBox = new System.Windows.Forms.TextBox();
            this.numeroSequenciaNfeAtualTextBox = new System.Windows.Forms.TextBox();
            this.numeroSequenciaNFCeAtual = new System.Windows.Forms.TextBox();
            this.pastaNfeValidadoTextBox = new System.Windows.Forms.TextBox();
            this.pastaNfeValidarTextBox = new System.Windows.Forms.TextBox();
            codLojaLabel = new System.Windows.Forms.Label();
            nomeLabel = new System.Windows.Forms.Label();
            codPessoaLabel = new System.Windows.Forms.Label();
            cpf_CnpjLabel = new System.Windows.Forms.Label();
            ieLabel = new System.Windows.Forms.Label();
            cidadeLabel = new System.Windows.Forms.Label();
            nomeServidorNfeLabel = new System.Windows.Forms.Label();
            pastaNfeAutorizadosLabel = new System.Windows.Forms.Label();
            pastaNfeEnviadoLabel = new System.Windows.Forms.Label();
            pastaNfeEnvioLabel = new System.Windows.Forms.Label();
            pastaNfeErroLabel = new System.Windows.Forms.Label();
            pastaNfeEspelhoLabel = new System.Windows.Forms.Label();
            pastaNfeRetornoLabel = new System.Windows.Forms.Label();
            numeroSequenciaNfeAtualLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            pastaNfeValidadoLabel = new System.Windows.Forms.Label();
            pastaNfeValidarLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lojaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_lojaBindingNavigator)).BeginInit();
            this.tb_lojaBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pessoaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // codLojaLabel
            // 
            codLojaLabel.AutoSize = true;
            codLojaLabel.Location = new System.Drawing.Point(6, 72);
            codLojaLabel.Name = "codLojaLabel";
            codLojaLabel.Size = new System.Drawing.Size(43, 13);
            codLojaLabel.TabIndex = 21;
            codLojaLabel.Text = "Código:";
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Location = new System.Drawing.Point(120, 72);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new System.Drawing.Size(38, 13);
            nomeLabel.TabIndex = 23;
            nomeLabel.Text = "Nome:";
            // 
            // codPessoaLabel
            // 
            codPessoaLabel.AutoSize = true;
            codPessoaLabel.Location = new System.Drawing.Point(6, 124);
            codPessoaLabel.Name = "codPessoaLabel";
            codPessoaLabel.Size = new System.Drawing.Size(138, 13);
            codPessoaLabel.TabIndex = 24;
            codPessoaLabel.Text = "Pessoa Jurídica Associada:";
            // 
            // cpf_CnpjLabel
            // 
            cpf_CnpjLabel.AutoSize = true;
            cpf_CnpjLabel.Location = new System.Drawing.Point(6, 172);
            cpf_CnpjLabel.Name = "cpf_CnpjLabel";
            cpf_CnpjLabel.Size = new System.Drawing.Size(31, 13);
            cpf_CnpjLabel.TabIndex = 26;
            cpf_CnpjLabel.Text = "Cnpj:";
            // 
            // ieLabel
            // 
            ieLabel.AutoSize = true;
            ieLabel.Location = new System.Drawing.Point(173, 172);
            ieLabel.Name = "ieLabel";
            ieLabel.Size = new System.Drawing.Size(97, 13);
            ieLabel.TabIndex = 27;
            ieLabel.Text = "Inscrição Estadual:";
            // 
            // cidadeLabel
            // 
            cidadeLabel.AutoSize = true;
            cidadeLabel.Location = new System.Drawing.Point(279, 175);
            cidadeLabel.Name = "cidadeLabel";
            cidadeLabel.Size = new System.Drawing.Size(43, 13);
            cidadeLabel.TabIndex = 28;
            cidadeLabel.Text = "Cidade:";
            // 
            // nomeServidorNfeLabel
            // 
            nomeServidorNfeLabel.AutoSize = true;
            nomeServidorNfeLabel.Location = new System.Drawing.Point(6, 219);
            nomeServidorNfeLabel.Name = "nomeServidorNfeLabel";
            nomeServidorNfeLabel.Size = new System.Drawing.Size(100, 13);
            nomeServidorNfeLabel.TabIndex = 29;
            nomeServidorNfeLabel.Text = "Nome Servidor Nfe:";
            // 
            // pastaNfeAutorizadosLabel
            // 
            pastaNfeAutorizadosLabel.AutoSize = true;
            pastaNfeAutorizadosLabel.Location = new System.Drawing.Point(4, 261);
            pastaNfeAutorizadosLabel.Name = "pastaNfeAutorizadosLabel";
            pastaNfeAutorizadosLabel.Size = new System.Drawing.Size(115, 13);
            pastaNfeAutorizadosLabel.TabIndex = 30;
            pastaNfeAutorizadosLabel.Text = "Pasta Nfe Autorizados:";
            // 
            // pastaNfeEnviadoLabel
            // 
            pastaNfeEnviadoLabel.AutoSize = true;
            pastaNfeEnviadoLabel.Location = new System.Drawing.Point(279, 264);
            pastaNfeEnviadoLabel.Name = "pastaNfeEnviadoLabel";
            pastaNfeEnviadoLabel.Size = new System.Drawing.Size(99, 13);
            pastaNfeEnviadoLabel.TabIndex = 31;
            pastaNfeEnviadoLabel.Text = "Pasta Nfe Enviado:";
            // 
            // pastaNfeEnvioLabel
            // 
            pastaNfeEnvioLabel.AutoSize = true;
            pastaNfeEnvioLabel.Location = new System.Drawing.Point(4, 307);
            pastaNfeEnvioLabel.Name = "pastaNfeEnvioLabel";
            pastaNfeEnvioLabel.Size = new System.Drawing.Size(87, 13);
            pastaNfeEnvioLabel.TabIndex = 32;
            pastaNfeEnvioLabel.Text = "Pasta Nfe Envio:";
            // 
            // pastaNfeErroLabel
            // 
            pastaNfeErroLabel.AutoSize = true;
            pastaNfeErroLabel.Location = new System.Drawing.Point(279, 303);
            pastaNfeErroLabel.Name = "pastaNfeErroLabel";
            pastaNfeErroLabel.Size = new System.Drawing.Size(79, 13);
            pastaNfeErroLabel.TabIndex = 33;
            pastaNfeErroLabel.Text = "Pasta Nfe Erro:";
            // 
            // pastaNfeEspelhoLabel
            // 
            pastaNfeEspelhoLabel.AutoSize = true;
            pastaNfeEspelhoLabel.Location = new System.Drawing.Point(8, 348);
            pastaNfeEspelhoLabel.Name = "pastaNfeEspelhoLabel";
            pastaNfeEspelhoLabel.Size = new System.Drawing.Size(98, 13);
            pastaNfeEspelhoLabel.TabIndex = 34;
            pastaNfeEspelhoLabel.Text = "Pasta Nfe Espelho:";
            // 
            // pastaNfeRetornoLabel
            // 
            pastaNfeRetornoLabel.AutoSize = true;
            pastaNfeRetornoLabel.Location = new System.Drawing.Point(280, 348);
            pastaNfeRetornoLabel.Name = "pastaNfeRetornoLabel";
            pastaNfeRetornoLabel.Size = new System.Drawing.Size(98, 13);
            pastaNfeRetornoLabel.TabIndex = 35;
            pastaNfeRetornoLabel.Text = "Pasta Nfe Retorno:";
            // 
            // numeroSequenciaNfeAtualLabel
            // 
            numeroSequenciaNfeAtualLabel.AutoSize = true;
            numeroSequenciaNfeAtualLabel.Location = new System.Drawing.Point(421, 216);
            numeroSequenciaNfeAtualLabel.Name = "numeroSequenciaNfeAtualLabel";
            numeroSequenciaNfeAtualLabel.Size = new System.Drawing.Size(70, 13);
            numeroSequenciaNfeAtualLabel.TabIndex = 36;
            numeroSequenciaNfeAtualLabel.Text = "Numero NFe:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(279, 216);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(77, 13);
            label2.TabIndex = 38;
            label2.Text = "Numero NFCe:";
            // 
            // pastaNfeValidadoLabel
            // 
            pastaNfeValidadoLabel.AutoSize = true;
            pastaNfeValidadoLabel.Location = new System.Drawing.Point(280, 388);
            pastaNfeValidadoLabel.Name = "pastaNfeValidadoLabel";
            pastaNfeValidadoLabel.Size = new System.Drawing.Size(150, 13);
            pastaNfeValidadoLabel.TabIndex = 38;
            pastaNfeValidadoLabel.Text = "Pasta Nfe em Processamento:";
            // 
            // pastaNfeValidarLabel
            // 
            pastaNfeValidarLabel.AutoSize = true;
            pastaNfeValidarLabel.Location = new System.Drawing.Point(8, 388);
            pastaNfeValidarLabel.Name = "pastaNfeValidarLabel";
            pastaNfeValidarLabel.Size = new System.Drawing.Size(92, 13);
            pastaNfeValidarLabel.TabIndex = 40;
            pastaNfeValidarLabel.Text = "Pasta Nfe Validar:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastro de Lojas";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 41);
            this.panel1.TabIndex = 20;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(309, 440);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(9, 440);
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
            this.btnCancelar.Location = new System.Drawing.Point(390, 440);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(84, 440);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "F3 - Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(234, 440);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "F5 - Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(159, 440);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "F4 - Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // lojaBindingSource
            // 
            this.lojaBindingSource.DataSource = typeof(Dominio.Loja);
            this.lojaBindingSource.Sort = "codLoja";
            // 
            // tb_lojaBindingNavigator
            // 
            this.tb_lojaBindingNavigator.AddNewItem = null;
            this.tb_lojaBindingNavigator.BindingSource = this.lojaBindingSource;
            this.tb_lojaBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tb_lojaBindingNavigator.DeleteItem = null;
            this.tb_lojaBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.tb_lojaBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.tb_lojaBindingNavigator.Location = new System.Drawing.Point(342, 43);
            this.tb_lojaBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tb_lojaBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tb_lojaBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tb_lojaBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tb_lojaBindingNavigator.Name = "tb_lojaBindingNavigator";
            this.tb_lojaBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tb_lojaBindingNavigator.Size = new System.Drawing.Size(209, 25);
            this.tb_lojaBindingNavigator.TabIndex = 21;
            this.tb_lojaBindingNavigator.Text = "bindingNavigator1";
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
            // codLojaTextBox
            // 
            this.codLojaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lojaBindingSource, "CodLoja", true));
            this.codLojaTextBox.Location = new System.Drawing.Point(9, 89);
            this.codLojaTextBox.Name = "codLojaTextBox";
            this.codLojaTextBox.ReadOnly = true;
            this.codLojaTextBox.Size = new System.Drawing.Size(100, 20);
            this.codLojaTextBox.TabIndex = 22;
            this.codLojaTextBox.TabStop = false;
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lojaBindingSource, "Nome", true));
            this.nomeTextBox.Location = new System.Drawing.Point(123, 89);
            this.nomeTextBox.MaxLength = 40;
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.Size = new System.Drawing.Size(412, 20);
            this.nomeTextBox.TabIndex = 24;
            this.nomeTextBox.Leave += new System.EventHandler(this.nomeTextBox_Leave);
            // 
            // codPessoaComboBox
            // 
            this.codPessoaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codPessoaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codPessoaComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.lojaBindingSource, "CodPessoa", true));
            this.codPessoaComboBox.DataSource = this.pessoaBindingSource;
            this.codPessoaComboBox.DisplayMember = "NomeFantasia";
            this.codPessoaComboBox.FormattingEnabled = true;
            this.codPessoaComboBox.Location = new System.Drawing.Point(2, 140);
            this.codPessoaComboBox.Name = "codPessoaComboBox";
            this.codPessoaComboBox.Size = new System.Drawing.Size(533, 21);
            this.codPessoaComboBox.TabIndex = 25;
            this.codPessoaComboBox.ValueMember = "CodPessoa";
            this.codPessoaComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codPessoaComboBox_KeyPress);
            this.codPessoaComboBox.Leave += new System.EventHandler(this.codPessoaComboBox_Leave);
            // 
            // pessoaBindingSource
            // 
            this.pessoaBindingSource.DataSource = typeof(Dominio.Pessoa);
            // 
            // cpf_CnpjTextBox
            // 
            this.cpf_CnpjTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pessoaBindingSource, "CpfCnpj", true));
            this.cpf_CnpjTextBox.Location = new System.Drawing.Point(9, 190);
            this.cpf_CnpjTextBox.Name = "cpf_CnpjTextBox";
            this.cpf_CnpjTextBox.ReadOnly = true;
            this.cpf_CnpjTextBox.Size = new System.Drawing.Size(143, 20);
            this.cpf_CnpjTextBox.TabIndex = 27;
            this.cpf_CnpjTextBox.TabStop = false;
            // 
            // ieTextBox
            // 
            this.ieTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pessoaBindingSource, "IeSubstituto", true));
            this.ieTextBox.Location = new System.Drawing.Point(170, 190);
            this.ieTextBox.Name = "ieTextBox";
            this.ieTextBox.ReadOnly = true;
            this.ieTextBox.Size = new System.Drawing.Size(100, 20);
            this.ieTextBox.TabIndex = 28;
            this.ieTextBox.TabStop = false;
            // 
            // cidadeTextBox
            // 
            this.cidadeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pessoaBindingSource, "Cidade", true));
            this.cidadeTextBox.Location = new System.Drawing.Point(282, 193);
            this.cidadeTextBox.Name = "cidadeTextBox";
            this.cidadeTextBox.ReadOnly = true;
            this.cidadeTextBox.Size = new System.Drawing.Size(253, 20);
            this.cidadeTextBox.TabIndex = 29;
            this.cidadeTextBox.TabStop = false;
            // 
            // nomeServidorNfeTextBox
            // 
            this.nomeServidorNfeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lojaBindingSource, "NomeServidorNfe", true));
            this.nomeServidorNfeTextBox.Location = new System.Drawing.Point(9, 235);
            this.nomeServidorNfeTextBox.Name = "nomeServidorNfeTextBox";
            this.nomeServidorNfeTextBox.Size = new System.Drawing.Size(261, 20);
            this.nomeServidorNfeTextBox.TabIndex = 30;
            // 
            // pastaNfeAutorizadosTextBox
            // 
            this.pastaNfeAutorizadosTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lojaBindingSource, "PastaNfeAutorizados", true));
            this.pastaNfeAutorizadosTextBox.Location = new System.Drawing.Point(9, 280);
            this.pastaNfeAutorizadosTextBox.Name = "pastaNfeAutorizadosTextBox";
            this.pastaNfeAutorizadosTextBox.Size = new System.Drawing.Size(261, 20);
            this.pastaNfeAutorizadosTextBox.TabIndex = 31;
            // 
            // pastaNfeEnviadoTextBox
            // 
            this.pastaNfeEnviadoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lojaBindingSource, "PastaNfeEnviado", true));
            this.pastaNfeEnviadoTextBox.Location = new System.Drawing.Point(282, 280);
            this.pastaNfeEnviadoTextBox.Name = "pastaNfeEnviadoTextBox";
            this.pastaNfeEnviadoTextBox.Size = new System.Drawing.Size(253, 20);
            this.pastaNfeEnviadoTextBox.TabIndex = 32;
            // 
            // pastaNfeEnvioTextBox
            // 
            this.pastaNfeEnvioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lojaBindingSource, "PastaNfeEnvio", true));
            this.pastaNfeEnvioTextBox.Location = new System.Drawing.Point(9, 323);
            this.pastaNfeEnvioTextBox.Name = "pastaNfeEnvioTextBox";
            this.pastaNfeEnvioTextBox.Size = new System.Drawing.Size(261, 20);
            this.pastaNfeEnvioTextBox.TabIndex = 33;
            // 
            // pastaNfeErroTextBox
            // 
            this.pastaNfeErroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lojaBindingSource, "PastaNfeErro", true));
            this.pastaNfeErroTextBox.Location = new System.Drawing.Point(282, 323);
            this.pastaNfeErroTextBox.Name = "pastaNfeErroTextBox";
            this.pastaNfeErroTextBox.Size = new System.Drawing.Size(253, 20);
            this.pastaNfeErroTextBox.TabIndex = 34;
            // 
            // pastaNfeEspelhoTextBox
            // 
            this.pastaNfeEspelhoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lojaBindingSource, "PastaNfeEspelho", true));
            this.pastaNfeEspelhoTextBox.Location = new System.Drawing.Point(9, 364);
            this.pastaNfeEspelhoTextBox.Name = "pastaNfeEspelhoTextBox";
            this.pastaNfeEspelhoTextBox.Size = new System.Drawing.Size(261, 20);
            this.pastaNfeEspelhoTextBox.TabIndex = 35;
            // 
            // pastaNfeRetornoTextBox
            // 
            this.pastaNfeRetornoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lojaBindingSource, "PastaNfeRetorno", true));
            this.pastaNfeRetornoTextBox.Location = new System.Drawing.Point(282, 364);
            this.pastaNfeRetornoTextBox.Name = "pastaNfeRetornoTextBox";
            this.pastaNfeRetornoTextBox.Size = new System.Drawing.Size(253, 20);
            this.pastaNfeRetornoTextBox.TabIndex = 36;
            // 
            // numeroSequenciaNfeAtualTextBox
            // 
            this.numeroSequenciaNfeAtualTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lojaBindingSource, "NumeroSequenciaNfeAtual", true));
            this.numeroSequenciaNfeAtualTextBox.Location = new System.Drawing.Point(424, 235);
            this.numeroSequenciaNfeAtualTextBox.Name = "numeroSequenciaNfeAtualTextBox";
            this.numeroSequenciaNfeAtualTextBox.ReadOnly = true;
            this.numeroSequenciaNfeAtualTextBox.Size = new System.Drawing.Size(111, 20);
            this.numeroSequenciaNfeAtualTextBox.TabIndex = 37;
            this.numeroSequenciaNfeAtualTextBox.TabStop = false;
            // 
            // numeroSequenciaNFCeAtual
            // 
            this.numeroSequenciaNFCeAtual.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lojaBindingSource, "NumeroSequenciaNFCeAtual", true));
            this.numeroSequenciaNFCeAtual.Location = new System.Drawing.Point(282, 238);
            this.numeroSequenciaNFCeAtual.Name = "numeroSequenciaNFCeAtual";
            this.numeroSequenciaNFCeAtual.ReadOnly = true;
            this.numeroSequenciaNFCeAtual.Size = new System.Drawing.Size(124, 20);
            this.numeroSequenciaNFCeAtual.TabIndex = 36;
            this.numeroSequenciaNFCeAtual.TabStop = false;
            // 
            // pastaNfeValidadoTextBox
            // 
            this.pastaNfeValidadoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lojaBindingSource, "PastaNfeValidado", true));
            this.pastaNfeValidadoTextBox.Location = new System.Drawing.Point(283, 405);
            this.pastaNfeValidadoTextBox.Name = "pastaNfeValidadoTextBox";
            this.pastaNfeValidadoTextBox.Size = new System.Drawing.Size(252, 20);
            this.pastaNfeValidadoTextBox.TabIndex = 40;
            // 
            // pastaNfeValidarTextBox
            // 
            this.pastaNfeValidarTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lojaBindingSource, "PastaNfeValidar", true));
            this.pastaNfeValidarTextBox.Location = new System.Drawing.Point(9, 405);
            this.pastaNfeValidarTextBox.Name = "pastaNfeValidarTextBox";
            this.pastaNfeValidarTextBox.Size = new System.Drawing.Size(261, 20);
            this.pastaNfeValidarTextBox.TabIndex = 38;
            // 
            // FrmLoja
            // 
            this.AccessibleDescription = "\'";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 466);
            this.Controls.Add(pastaNfeValidarLabel);
            this.Controls.Add(this.pastaNfeValidarTextBox);
            this.Controls.Add(pastaNfeValidadoLabel);
            this.Controls.Add(this.pastaNfeValidadoTextBox);
            this.Controls.Add(label2);
            this.Controls.Add(this.numeroSequenciaNFCeAtual);
            this.Controls.Add(numeroSequenciaNfeAtualLabel);
            this.Controls.Add(this.numeroSequenciaNfeAtualTextBox);
            this.Controls.Add(pastaNfeRetornoLabel);
            this.Controls.Add(this.pastaNfeRetornoTextBox);
            this.Controls.Add(pastaNfeEspelhoLabel);
            this.Controls.Add(this.pastaNfeEspelhoTextBox);
            this.Controls.Add(pastaNfeErroLabel);
            this.Controls.Add(this.pastaNfeErroTextBox);
            this.Controls.Add(pastaNfeEnvioLabel);
            this.Controls.Add(this.pastaNfeEnvioTextBox);
            this.Controls.Add(pastaNfeEnviadoLabel);
            this.Controls.Add(this.pastaNfeEnviadoTextBox);
            this.Controls.Add(pastaNfeAutorizadosLabel);
            this.Controls.Add(this.pastaNfeAutorizadosTextBox);
            this.Controls.Add(nomeServidorNfeLabel);
            this.Controls.Add(this.nomeServidorNfeTextBox);
            this.Controls.Add(cidadeLabel);
            this.Controls.Add(this.cidadeTextBox);
            this.Controls.Add(ieLabel);
            this.Controls.Add(this.ieTextBox);
            this.Controls.Add(cpf_CnpjLabel);
            this.Controls.Add(this.cpf_CnpjTextBox);
            this.Controls.Add(codPessoaLabel);
            this.Controls.Add(this.codPessoaComboBox);
            this.Controls.Add(codLojaLabel);
            this.Controls.Add(this.tb_lojaBindingNavigator);
            this.Controls.Add(this.codLojaTextBox);
            this.Controls.Add(nomeLabel);
            this.Controls.Add(this.nomeTextBox);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmLoja";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro Lojas";
            this.Load += new System.EventHandler(this.FrmLoja_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLoja_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lojaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_lojaBindingNavigator)).EndInit();
            this.tb_lojaBindingNavigator.ResumeLayout(false);
            this.tb_lojaBindingNavigator.PerformLayout();
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