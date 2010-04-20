namespace SACE.Telas
{
    partial class FrmEmpresa
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
            System.Windows.Forms.Label codigoEmpresaLabel;
            System.Windows.Forms.Label nomeLabel;
            System.Windows.Forms.Label cnpjLabel;
            System.Windows.Forms.Label ieLabel;
            System.Windows.Forms.Label foneLabel;
            System.Windows.Forms.Label enderecoLabel;
            System.Windows.Forms.Label bairroLabel;
            System.Windows.Forms.Label cepLabel;
            System.Windows.Forms.Label cidadeLabel;
            System.Windows.Forms.Label ufLabel;
            System.Windows.Forms.Label limiteCompraLabel;
            System.Windows.Forms.Label observacaoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmpresa));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnContato = new System.Windows.Forms.Button();
            this.tb_empresaBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.tb_empresaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saceDataSet = new SACE.Dados.saceDataSet();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.codigoEmpresaTextBox = new System.Windows.Forms.TextBox();
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.cnpjTextBox = new System.Windows.Forms.TextBox();
            this.ieTextBox = new System.Windows.Forms.TextBox();
            this.foneTextBox = new System.Windows.Forms.TextBox();
            this.enderecoTextBox = new System.Windows.Forms.TextBox();
            this.bairroTextBox = new System.Windows.Forms.TextBox();
            this.cepTextBox = new System.Windows.Forms.TextBox();
            this.cidadeTextBox = new System.Windows.Forms.TextBox();
            this.ufTextBox = new System.Windows.Forms.TextBox();
            this.limiteCompraTextBox = new System.Windows.Forms.TextBox();
            this.observacaoTextBox = new System.Windows.Forms.TextBox();
            this.tb_contato_empresaDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_contato_empresaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_empresaTableAdapter = new SACE.Dados.saceDataSetTableAdapters.tb_empresaTableAdapter();
            this.tableAdapterManager = new SACE.Dados.saceDataSetTableAdapters.TableAdapterManager();
            this.tb_contato_empresaTableAdapter = new SACE.Dados.saceDataSetTableAdapters.tb_contato_empresaTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            codigoEmpresaLabel = new System.Windows.Forms.Label();
            nomeLabel = new System.Windows.Forms.Label();
            cnpjLabel = new System.Windows.Forms.Label();
            ieLabel = new System.Windows.Forms.Label();
            foneLabel = new System.Windows.Forms.Label();
            enderecoLabel = new System.Windows.Forms.Label();
            bairroLabel = new System.Windows.Forms.Label();
            cepLabel = new System.Windows.Forms.Label();
            cidadeLabel = new System.Windows.Forms.Label();
            ufLabel = new System.Windows.Forms.Label();
            limiteCompraLabel = new System.Windows.Forms.Label();
            observacaoLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_empresaBindingNavigator)).BeginInit();
            this.tb_empresaBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_empresaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_contato_empresaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_contato_empresaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // codigoEmpresaLabel
            // 
            codigoEmpresaLabel.AutoSize = true;
            codigoEmpresaLabel.Location = new System.Drawing.Point(4, 65);
            codigoEmpresaLabel.Name = "codigoEmpresaLabel";
            codigoEmpresaLabel.Size = new System.Drawing.Size(43, 13);
            codigoEmpresaLabel.TabIndex = 32;
            codigoEmpresaLabel.Text = "Código:";
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Location = new System.Drawing.Point(121, 65);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new System.Drawing.Size(38, 13);
            nomeLabel.TabIndex = 34;
            nomeLabel.Text = "Nome:";
            // 
            // cnpjLabel
            // 
            cnpjLabel.AutoSize = true;
            cnpjLabel.Location = new System.Drawing.Point(4, 110);
            cnpjLabel.Name = "cnpjLabel";
            cnpjLabel.Size = new System.Drawing.Size(37, 13);
            cnpjLabel.TabIndex = 36;
            cnpjLabel.Text = "CNPJ:";
            // 
            // ieLabel
            // 
            ieLabel.AutoSize = true;
            ieLabel.Location = new System.Drawing.Point(121, 110);
            ieLabel.Name = "ieLabel";
            ieLabel.Size = new System.Drawing.Size(97, 13);
            ieLabel.TabIndex = 38;
            ieLabel.Text = "Inscrição Estadual:";
            // 
            // foneLabel
            // 
            foneLabel.AutoSize = true;
            foneLabel.Location = new System.Drawing.Point(243, 211);
            foneLabel.Name = "foneLabel";
            foneLabel.Size = new System.Drawing.Size(34, 13);
            foneLabel.TabIndex = 40;
            foneLabel.Text = "Fone:";
            // 
            // enderecoLabel
            // 
            enderecoLabel.AutoSize = true;
            enderecoLabel.Location = new System.Drawing.Point(4, 161);
            enderecoLabel.Name = "enderecoLabel";
            enderecoLabel.Size = new System.Drawing.Size(56, 13);
            enderecoLabel.TabIndex = 42;
            enderecoLabel.Text = "Endereço:";
            // 
            // bairroLabel
            // 
            bairroLabel.AutoSize = true;
            bairroLabel.Location = new System.Drawing.Point(4, 211);
            bairroLabel.Name = "bairroLabel";
            bairroLabel.Size = new System.Drawing.Size(37, 13);
            bairroLabel.TabIndex = 44;
            bairroLabel.Text = "Bairro:";
            // 
            // cepLabel
            // 
            cepLabel.AutoSize = true;
            cepLabel.Location = new System.Drawing.Point(153, 211);
            cepLabel.Name = "cepLabel";
            cepLabel.Size = new System.Drawing.Size(31, 13);
            cepLabel.TabIndex = 46;
            cepLabel.Text = "CEP:";
            // 
            // cidadeLabel
            // 
            cidadeLabel.AutoSize = true;
            cidadeLabel.Location = new System.Drawing.Point(237, 110);
            cidadeLabel.Name = "cidadeLabel";
            cidadeLabel.Size = new System.Drawing.Size(43, 13);
            cidadeLabel.TabIndex = 48;
            cidadeLabel.Text = "Cidade:";
            // 
            // ufLabel
            // 
            ufLabel.AutoSize = true;
            ufLabel.Location = new System.Drawing.Point(432, 110);
            ufLabel.Name = "ufLabel";
            ufLabel.Size = new System.Drawing.Size(24, 13);
            ufLabel.TabIndex = 50;
            ufLabel.Text = "UF:";
            // 
            // limiteCompraLabel
            // 
            limiteCompraLabel.AutoSize = true;
            limiteCompraLabel.Location = new System.Drawing.Point(358, 211);
            limiteCompraLabel.Name = "limiteCompraLabel";
            limiteCompraLabel.Size = new System.Drawing.Size(76, 13);
            limiteCompraLabel.TabIndex = 52;
            limiteCompraLabel.Text = "Limite Compra:";
            // 
            // observacaoLabel
            // 
            observacaoLabel.AutoSize = true;
            observacaoLabel.Location = new System.Drawing.Point(4, 259);
            observacaoLabel.Name = "observacaoLabel";
            observacaoLabel.Size = new System.Drawing.Size(68, 13);
            observacaoLabel.TabIndex = 53;
            observacaoLabel.Text = "Observação:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastro de Empresas";
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
            this.btnSalvar.Location = new System.Drawing.Point(306, 447);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(6, 447);
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
            this.btnCancelar.Location = new System.Drawing.Point(387, 447);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(81, 447);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "F3 - Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(231, 447);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "F5 - Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(156, 447);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "F4 - Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnContato
            // 
            this.btnContato.Location = new System.Drawing.Point(344, 315);
            this.btnContato.Name = "btnContato";
            this.btnContato.Size = new System.Drawing.Size(127, 23);
            this.btnContato.TabIndex = 56;
            this.btnContato.Text = "F7 - Adicionar Contato";
            this.btnContato.UseVisualStyleBackColor = true;
            this.btnContato.Click += new System.EventHandler(this.btnContato_Click);
            // 
            // tb_empresaBindingNavigator
            // 
            this.tb_empresaBindingNavigator.AddNewItem = null;
            this.tb_empresaBindingNavigator.BindingSource = this.tb_empresaBindingSource;
            this.tb_empresaBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tb_empresaBindingNavigator.DeleteItem = null;
            this.tb_empresaBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.tb_empresaBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.tb_empresaBindingNavigator.Location = new System.Drawing.Point(271, 41);
            this.tb_empresaBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tb_empresaBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tb_empresaBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tb_empresaBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tb_empresaBindingNavigator.Name = "tb_empresaBindingNavigator";
            this.tb_empresaBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tb_empresaBindingNavigator.Size = new System.Drawing.Size(209, 25);
            this.tb_empresaBindingNavigator.TabIndex = 32;
            this.tb_empresaBindingNavigator.Text = "bindingNavigator1";
            // 
            // tb_empresaBindingSource
            // 
            this.tb_empresaBindingSource.DataMember = "tb_empresa";
            this.tb_empresaBindingSource.DataSource = this.saceDataSet;
            this.tb_empresaBindingSource.Sort = "codigoEmpresa";
            // 
            // saceDataSet
            // 
            this.saceDataSet.DataSetName = "saceDataSet";
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
            // codigoEmpresaTextBox
            // 
            this.codigoEmpresaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_empresaBindingSource, "codigoEmpresa", true));
            this.codigoEmpresaTextBox.Location = new System.Drawing.Point(4, 82);
            this.codigoEmpresaTextBox.Multiline = true;
            this.codigoEmpresaTextBox.Name = "codigoEmpresaTextBox";
            this.codigoEmpresaTextBox.ReadOnly = true;
            this.codigoEmpresaTextBox.Size = new System.Drawing.Size(100, 20);
            this.codigoEmpresaTextBox.TabIndex = 33;
            this.codigoEmpresaTextBox.TabStop = false;
            this.codigoEmpresaTextBox.TextChanged += new System.EventHandler(this.codigoEmpresaTextBox_TextChanged);
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_empresaBindingSource, "nome", true));
            this.nomeTextBox.Location = new System.Drawing.Point(124, 82);
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.Size = new System.Drawing.Size(347, 20);
            this.nomeTextBox.TabIndex = 35;
            // 
            // cnpjTextBox
            // 
            this.cnpjTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cnpjTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_empresaBindingSource, "cnpj", true));
            this.cnpjTextBox.Location = new System.Drawing.Point(4, 127);
            this.cnpjTextBox.Name = "cnpjTextBox";
            this.cnpjTextBox.Size = new System.Drawing.Size(100, 20);
            this.cnpjTextBox.TabIndex = 37;
            // 
            // ieTextBox
            // 
            this.ieTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ieTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_empresaBindingSource, "ie", true));
            this.ieTextBox.Location = new System.Drawing.Point(124, 127);
            this.ieTextBox.Name = "ieTextBox";
            this.ieTextBox.Size = new System.Drawing.Size(100, 20);
            this.ieTextBox.TabIndex = 39;
            // 
            // foneTextBox
            // 
            this.foneTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.foneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_empresaBindingSource, "fone", true));
            this.foneTextBox.Location = new System.Drawing.Point(246, 228);
            this.foneTextBox.Name = "foneTextBox";
            this.foneTextBox.Size = new System.Drawing.Size(100, 20);
            this.foneTextBox.TabIndex = 51;
            // 
            // enderecoTextBox
            // 
            this.enderecoTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.enderecoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_empresaBindingSource, "endereco", true));
            this.enderecoTextBox.Location = new System.Drawing.Point(7, 178);
            this.enderecoTextBox.Name = "enderecoTextBox";
            this.enderecoTextBox.Size = new System.Drawing.Size(464, 20);
            this.enderecoTextBox.TabIndex = 45;
            // 
            // bairroTextBox
            // 
            this.bairroTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.bairroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_empresaBindingSource, "bairro", true));
            this.bairroTextBox.Location = new System.Drawing.Point(7, 228);
            this.bairroTextBox.Name = "bairroTextBox";
            this.bairroTextBox.Size = new System.Drawing.Size(132, 20);
            this.bairroTextBox.TabIndex = 47;
            // 
            // cepTextBox
            // 
            this.cepTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cepTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_empresaBindingSource, "cep", true));
            this.cepTextBox.Location = new System.Drawing.Point(156, 228);
            this.cepTextBox.Name = "cepTextBox";
            this.cepTextBox.Size = new System.Drawing.Size(75, 20);
            this.cepTextBox.TabIndex = 49;
            // 
            // cidadeTextBox
            // 
            this.cidadeTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cidadeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_empresaBindingSource, "cidade", true));
            this.cidadeTextBox.Location = new System.Drawing.Point(240, 127);
            this.cidadeTextBox.Name = "cidadeTextBox";
            this.cidadeTextBox.Size = new System.Drawing.Size(185, 20);
            this.cidadeTextBox.TabIndex = 41;
            // 
            // ufTextBox
            // 
            this.ufTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ufTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_empresaBindingSource, "uf", true));
            this.ufTextBox.Location = new System.Drawing.Point(435, 127);
            this.ufTextBox.Name = "ufTextBox";
            this.ufTextBox.Size = new System.Drawing.Size(36, 20);
            this.ufTextBox.TabIndex = 43;
            // 
            // limiteCompraTextBox
            // 
            this.limiteCompraTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.limiteCompraTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_empresaBindingSource, "limiteCompra", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0", "N2"));
            this.limiteCompraTextBox.Location = new System.Drawing.Point(361, 228);
            this.limiteCompraTextBox.Name = "limiteCompraTextBox";
            this.limiteCompraTextBox.Size = new System.Drawing.Size(110, 20);
            this.limiteCompraTextBox.TabIndex = 53;
            // 
            // observacaoTextBox
            // 
            this.observacaoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_empresaBindingSource, "observacao", true));
            this.observacaoTextBox.Location = new System.Drawing.Point(7, 276);
            this.observacaoTextBox.Multiline = true;
            this.observacaoTextBox.Name = "observacaoTextBox";
            this.observacaoTextBox.Size = new System.Drawing.Size(464, 32);
            this.observacaoTextBox.TabIndex = 55;
            // 
            // tb_contato_empresaDataGridView
            // 
            this.tb_contato_empresaDataGridView.AllowUserToAddRows = false;
            this.tb_contato_empresaDataGridView.AllowUserToDeleteRows = false;
            this.tb_contato_empresaDataGridView.AutoGenerateColumns = false;
            this.tb_contato_empresaDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tb_contato_empresaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_contato_empresaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8});
            this.tb_contato_empresaDataGridView.DataSource = this.tb_contato_empresaBindingSource;
            this.tb_contato_empresaDataGridView.Location = new System.Drawing.Point(7, 339);
            this.tb_contato_empresaDataGridView.MultiSelect = false;
            this.tb_contato_empresaDataGridView.Name = "tb_contato_empresaDataGridView";
            this.tb_contato_empresaDataGridView.ReadOnly = true;
            this.tb_contato_empresaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_contato_empresaDataGridView.Size = new System.Drawing.Size(464, 102);
            this.tb_contato_empresaDataGridView.TabIndex = 57;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "codigoEmpresa";
            this.dataGridViewTextBoxColumn1.FillWeight = 200F;
            this.dataGridViewTextBoxColumn1.HeaderText = "codigoEmpresa";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "codPessoa";
            this.dataGridViewTextBoxColumn2.HeaderText = "codPessoa";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "nome";
            this.dataGridViewTextBoxColumn3.HeaderText = "nome";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "fone1";
            this.dataGridViewTextBoxColumn6.HeaderText = "fone1";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "fone2";
            this.dataGridViewTextBoxColumn8.HeaderText = "fone2";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // tb_contato_empresaBindingSource
            // 
            this.tb_contato_empresaBindingSource.DataMember = "tb_contato_empresa";
            this.tb_contato_empresaBindingSource.DataSource = this.saceDataSet;
            // 
            // tb_empresaTableAdapter
            // 
            this.tb_empresaTableAdapter.ClearBeforeFill = true;
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
            this.tableAdapterManager.tb_contato_empresaTableAdapter = this.tb_contato_empresaTableAdapter;
            this.tableAdapterManager.tb_empresaTableAdapter = this.tb_empresaTableAdapter;
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
            this.tableAdapterManager.tb_pessoaTableAdapter = null;
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
            // tb_contato_empresaTableAdapter
            // 
            this.tb_contato_empresaTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(6, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "F12 - Navegar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(91, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "DEL - Excluir";
            // 
            // FrmEmpresa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 474);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_contato_empresaDataGridView);
            this.Controls.Add(observacaoLabel);
            this.Controls.Add(this.observacaoTextBox);
            this.Controls.Add(codigoEmpresaLabel);
            this.Controls.Add(this.tb_empresaBindingNavigator);
            this.Controls.Add(this.codigoEmpresaTextBox);
            this.Controls.Add(nomeLabel);
            this.Controls.Add(this.nomeTextBox);
            this.Controls.Add(cnpjLabel);
            this.Controls.Add(this.cnpjTextBox);
            this.Controls.Add(ieLabel);
            this.Controls.Add(this.ieTextBox);
            this.Controls.Add(foneLabel);
            this.Controls.Add(this.foneTextBox);
            this.Controls.Add(enderecoLabel);
            this.Controls.Add(this.enderecoTextBox);
            this.Controls.Add(bairroLabel);
            this.Controls.Add(this.bairroTextBox);
            this.Controls.Add(cepLabel);
            this.Controls.Add(this.cepTextBox);
            this.Controls.Add(cidadeLabel);
            this.Controls.Add(this.cidadeTextBox);
            this.Controls.Add(ufLabel);
            this.Controls.Add(this.ufTextBox);
            this.Controls.Add(limiteCompraLabel);
            this.Controls.Add(this.limiteCompraTextBox);
            this.Controls.Add(this.btnContato);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmEmpresa";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro Empresas";
            this.Load += new System.EventHandler(this.FrmEmpresa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmEmpresa_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_empresaBindingNavigator)).EndInit();
            this.tb_empresaBindingNavigator.ResumeLayout(false);
            this.tb_empresaBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_empresaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).EndInit();
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
        private System.Windows.Forms.Button btnContato;
        private SACE.Dados.saceDataSet saceDataSet;
        private System.Windows.Forms.BindingSource tb_empresaBindingSource;
        private SACE.Dados.saceDataSetTableAdapters.tb_empresaTableAdapter tb_empresaTableAdapter;
        private SACE.Dados.saceDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator tb_empresaBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.TextBox codigoEmpresaTextBox;
        private System.Windows.Forms.TextBox nomeTextBox;
        private System.Windows.Forms.TextBox cnpjTextBox;
        private System.Windows.Forms.TextBox ieTextBox;
        private System.Windows.Forms.TextBox foneTextBox;
        private System.Windows.Forms.TextBox enderecoTextBox;
        private System.Windows.Forms.TextBox bairroTextBox;
        private System.Windows.Forms.TextBox cepTextBox;
        private System.Windows.Forms.TextBox cidadeTextBox;
        private System.Windows.Forms.TextBox ufTextBox;
        private System.Windows.Forms.TextBox limiteCompraTextBox;
        private System.Windows.Forms.TextBox observacaoTextBox;
        private SACE.Dados.saceDataSetTableAdapters.tb_contato_empresaTableAdapter tb_contato_empresaTableAdapter;
        private System.Windows.Forms.BindingSource tb_contato_empresaBindingSource;
        private System.Windows.Forms.DataGridView tb_contato_empresaDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}