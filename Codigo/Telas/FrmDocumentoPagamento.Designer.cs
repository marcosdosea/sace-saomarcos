namespace Telas
 {
    partial class FrmDocumentoPagamento
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
             System.Windows.Forms.Label codDocumentoPagamentoLabel;
             System.Windows.Forms.Label codPessoaResponsavelLabel;
             System.Windows.Forms.Label codBancoLabel;
             System.Windows.Forms.Label codTipoDocumentoLabel;
             System.Windows.Forms.Label numeroDocumentoLabel;
             System.Windows.Forms.Label dataDocumentoLabel;
             System.Windows.Forms.Label dataVencimentoLabel;
             System.Windows.Forms.Label valorLabel;
             System.Windows.Forms.Label agenciaLabel;
             System.Windows.Forms.Label contaLabel;
             System.Windows.Forms.Label emitenteLabel;
             System.Windows.Forms.Label observacaoLabel;
             System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDocumentoPagamento));
             this.label1 = new System.Windows.Forms.Label();
             this.panel1 = new System.Windows.Forms.Panel();
             this.btnSalvar = new System.Windows.Forms.Button();
             this.btnBuscar = new System.Windows.Forms.Button();
             this.btnCancelar = new System.Windows.Forms.Button();
             this.btnNovo = new System.Windows.Forms.Button();
             this.btnExcluir = new System.Windows.Forms.Button();
             this.btnEditar = new System.Windows.Forms.Button();
             this.tb_documento_pagamentoBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
             this.tb_documento_pagamentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
             this.codDocumentoPagamentoTextBox = new System.Windows.Forms.TextBox();
             this.codBancoComboBox = new System.Windows.Forms.ComboBox();
             this.tbbancoBindingSource = new System.Windows.Forms.BindingSource(this.components);
             this.codTipoDocumentoComboBox = new System.Windows.Forms.ComboBox();
             this.tbtipodocumentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
             this.numeroDocumentoTextBox = new System.Windows.Forms.TextBox();
             this.dataDocumentoDateTimePicker = new System.Windows.Forms.DateTimePicker();
             this.dataVencimentoDateTimePicker = new System.Windows.Forms.DateTimePicker();
             this.valorTextBox = new System.Windows.Forms.TextBox();
             this.agenciaTextBox = new System.Windows.Forms.TextBox();
             this.contaTextBox = new System.Windows.Forms.TextBox();
             this.emitenteTextBox = new System.Windows.Forms.TextBox();
             this.observacaoTextBox = new System.Windows.Forms.TextBox();
             this.codPessoaResponsavelComboBox = new System.Windows.Forms.ComboBox();
             this.tbpessoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
             this.tb_documento_pagamentoTableAdapter = new Dados.saceDataSetTableAdapters.tb_documento_pagamentoTableAdapter();
             this.tb_pessoaTableAdapter = new Dados.saceDataSetTableAdapters.tb_pessoaTableAdapter();
             this.tb_bancoTableAdapter = new Dados.saceDataSetTableAdapters.tb_bancoTableAdapter();
             this.tb_tipo_documentoTableAdapter = new Dados.saceDataSetTableAdapters.tb_tipo_documentoTableAdapter();
             codDocumentoPagamentoLabel = new System.Windows.Forms.Label();
             codPessoaResponsavelLabel = new System.Windows.Forms.Label();
             codBancoLabel = new System.Windows.Forms.Label();
             codTipoDocumentoLabel = new System.Windows.Forms.Label();
             numeroDocumentoLabel = new System.Windows.Forms.Label();
             dataDocumentoLabel = new System.Windows.Forms.Label();
             dataVencimentoLabel = new System.Windows.Forms.Label();
             valorLabel = new System.Windows.Forms.Label();
             agenciaLabel = new System.Windows.Forms.Label();
             contaLabel = new System.Windows.Forms.Label();
             emitenteLabel = new System.Windows.Forms.Label();
             observacaoLabel = new System.Windows.Forms.Label();
             this.panel1.SuspendLayout();
             ((System.ComponentModel.ISupportInitialize)(this.tb_documento_pagamentoBindingNavigator)).BeginInit();
             this.tb_documento_pagamentoBindingNavigator.SuspendLayout();
             ((System.ComponentModel.ISupportInitialize)(this.tb_documento_pagamentoBindingSource)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.tbbancoBindingSource)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.tbtipodocumentoBindingSource)).BeginInit();
             ((System.ComponentModel.ISupportInitialize)(this.tbpessoaBindingSource)).BeginInit();
             this.SuspendLayout();
             // 
             // codDocumentoPagamentoLabel
             // 
             codDocumentoPagamentoLabel.AutoSize = true;
             codDocumentoPagamentoLabel.Location = new System.Drawing.Point(4, 73);
             codDocumentoPagamentoLabel.Name = "codDocumentoPagamentoLabel";
             codDocumentoPagamentoLabel.Size = new System.Drawing.Size(87, 13);
             codDocumentoPagamentoLabel.TabIndex = 21;
             codDocumentoPagamentoLabel.Text = "Cod Documento:";
             // 
             // codPessoaResponsavelLabel
             // 
             codPessoaResponsavelLabel.AutoSize = true;
             codPessoaResponsavelLabel.Location = new System.Drawing.Point(111, 73);
             codPessoaResponsavelLabel.Name = "codPessoaResponsavelLabel";
             codPessoaResponsavelLabel.Size = new System.Drawing.Size(72, 13);
             codPessoaResponsavelLabel.TabIndex = 23;
             codPessoaResponsavelLabel.Text = "Responsavel:";
             // 
             // codBancoLabel
             // 
             codBancoLabel.AutoSize = true;
             codBancoLabel.Location = new System.Drawing.Point(145, 126);
             codBancoLabel.Name = "codBancoLabel";
             codBancoLabel.Size = new System.Drawing.Size(41, 13);
             codBancoLabel.TabIndex = 25;
             codBancoLabel.Text = "Banco:";
             // 
             // codTipoDocumentoLabel
             // 
             codTipoDocumentoLabel.AutoSize = true;
             codTipoDocumentoLabel.Location = new System.Drawing.Point(461, 73);
             codTipoDocumentoLabel.Name = "codTipoDocumentoLabel";
             codTipoDocumentoLabel.Size = new System.Drawing.Size(89, 13);
             codTipoDocumentoLabel.TabIndex = 27;
             codTipoDocumentoLabel.Text = "Tipo Documento:";
             // 
             // numeroDocumentoLabel
             // 
             numeroDocumentoLabel.AutoSize = true;
             numeroDocumentoLabel.Location = new System.Drawing.Point(4, 126);
             numeroDocumentoLabel.Name = "numeroDocumentoLabel";
             numeroDocumentoLabel.Size = new System.Drawing.Size(105, 13);
             numeroDocumentoLabel.TabIndex = 29;
             numeroDocumentoLabel.Text = "Número Documento:";
             // 
             // dataDocumentoLabel
             // 
             dataDocumentoLabel.AutoSize = true;
             dataDocumentoLabel.Location = new System.Drawing.Point(4, 176);
             dataDocumentoLabel.Name = "dataDocumentoLabel";
             dataDocumentoLabel.Size = new System.Drawing.Size(91, 13);
             dataDocumentoLabel.TabIndex = 31;
             dataDocumentoLabel.Text = "Data Documento:";
             // 
             // dataVencimentoLabel
             // 
             dataVencimentoLabel.AutoSize = true;
             dataVencimentoLabel.Location = new System.Drawing.Point(461, 126);
             dataVencimentoLabel.Name = "dataVencimentoLabel";
             dataVencimentoLabel.Size = new System.Drawing.Size(92, 13);
             dataVencimentoLabel.TabIndex = 33;
             dataVencimentoLabel.Text = "Data Vencimento:";
             // 
             // valorLabel
             // 
             valorLabel.AutoSize = true;
             valorLabel.Location = new System.Drawing.Point(461, 176);
             valorLabel.Name = "valorLabel";
             valorLabel.Size = new System.Drawing.Size(34, 13);
             valorLabel.TabIndex = 35;
             valorLabel.Text = "Valor:";
             // 
             // agenciaLabel
             // 
             agenciaLabel.AutoSize = true;
             agenciaLabel.Location = new System.Drawing.Point(151, 176);
             agenciaLabel.Name = "agenciaLabel";
             agenciaLabel.Size = new System.Drawing.Size(49, 13);
             agenciaLabel.TabIndex = 37;
             agenciaLabel.Text = "Agência:";
             // 
             // contaLabel
             // 
             contaLabel.AutoSize = true;
             contaLabel.Location = new System.Drawing.Point(288, 176);
             contaLabel.Name = "contaLabel";
             contaLabel.Size = new System.Drawing.Size(38, 13);
             contaLabel.TabIndex = 39;
             contaLabel.Text = "Conta:";
             // 
             // emitenteLabel
             // 
             emitenteLabel.AutoSize = true;
             emitenteLabel.Location = new System.Drawing.Point(4, 227);
             emitenteLabel.Name = "emitenteLabel";
             emitenteLabel.Size = new System.Drawing.Size(51, 13);
             emitenteLabel.TabIndex = 41;
             emitenteLabel.Text = "Emitente:";
             // 
             // observacaoLabel
             // 
             observacaoLabel.AutoSize = true;
             observacaoLabel.Location = new System.Drawing.Point(4, 271);
             observacaoLabel.Name = "observacaoLabel";
             observacaoLabel.Size = new System.Drawing.Size(68, 13);
             observacaoLabel.TabIndex = 43;
             observacaoLabel.Text = "Observação:";
             // 
             // label1
             // 
             this.label1.AutoSize = true;
             this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
             this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
             this.label1.Location = new System.Drawing.Point(3, 9);
             this.label1.Name = "label1";
             this.label1.Size = new System.Drawing.Size(288, 23);
             this.label1.TabIndex = 0;
             this.label1.Text = "Cadastro de Documentos de Pagamento";
             // 
             // panel1
             // 
             this.panel1.BackColor = System.Drawing.Color.SteelBlue;
             this.panel1.Controls.Add(this.label1);
             this.panel1.Location = new System.Drawing.Point(0, -1);
             this.panel1.Name = "panel1";
             this.panel1.Size = new System.Drawing.Size(602, 41);
             this.panel1.TabIndex = 20;
             // 
             // btnSalvar
             // 
             this.btnSalvar.Location = new System.Drawing.Point(304, 369);
             this.btnSalvar.Name = "btnSalvar";
             this.btnSalvar.Size = new System.Drawing.Size(81, 23);
             this.btnSalvar.TabIndex = 4;
             this.btnSalvar.Text = "F6 - Salvar";
             this.btnSalvar.UseVisualStyleBackColor = true;
             this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
             // 
             // btnBuscar
             // 
             this.btnBuscar.Location = new System.Drawing.Point(4, 369);
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
             this.btnCancelar.Location = new System.Drawing.Point(385, 369);
             this.btnCancelar.Name = "btnCancelar";
             this.btnCancelar.Size = new System.Drawing.Size(84, 23);
             this.btnCancelar.TabIndex = 5;
             this.btnCancelar.Text = "Esc - Cancelar";
             this.btnCancelar.UseVisualStyleBackColor = true;
             this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
             // 
             // btnNovo
             // 
             this.btnNovo.Location = new System.Drawing.Point(79, 369);
             this.btnNovo.Name = "btnNovo";
             this.btnNovo.Size = new System.Drawing.Size(75, 23);
             this.btnNovo.TabIndex = 1;
             this.btnNovo.Text = "F3 - Novo";
             this.btnNovo.UseVisualStyleBackColor = true;
             this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
             // 
             // btnExcluir
             // 
             this.btnExcluir.Location = new System.Drawing.Point(229, 369);
             this.btnExcluir.Name = "btnExcluir";
             this.btnExcluir.Size = new System.Drawing.Size(75, 23);
             this.btnExcluir.TabIndex = 3;
             this.btnExcluir.Text = "F5 - Excluir";
             this.btnExcluir.UseVisualStyleBackColor = true;
             this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
             // 
             // btnEditar
             // 
             this.btnEditar.Location = new System.Drawing.Point(154, 369);
             this.btnEditar.Name = "btnEditar";
             this.btnEditar.Size = new System.Drawing.Size(75, 23);
             this.btnEditar.TabIndex = 2;
             this.btnEditar.Text = "F4 - Editar";
             this.btnEditar.UseVisualStyleBackColor = true;
             this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
             // 
             // tb_documento_pagamentoBindingNavigator
             // 
             this.tb_documento_pagamentoBindingNavigator.AddNewItem = null;
             this.tb_documento_pagamentoBindingNavigator.BindingSource = this.tb_documento_pagamentoBindingSource;
             this.tb_documento_pagamentoBindingNavigator.CountItem = this.bindingNavigatorCountItem;
             this.tb_documento_pagamentoBindingNavigator.DeleteItem = null;
             this.tb_documento_pagamentoBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
             this.tb_documento_pagamentoBindingNavigator.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
             this.tb_documento_pagamentoBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
             this.tb_documento_pagamentoBindingNavigator.Location = new System.Drawing.Point(407, 40);
             this.tb_documento_pagamentoBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
             this.tb_documento_pagamentoBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
             this.tb_documento_pagamentoBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
             this.tb_documento_pagamentoBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
             this.tb_documento_pagamentoBindingNavigator.Name = "tb_documento_pagamentoBindingNavigator";
             this.tb_documento_pagamentoBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
             this.tb_documento_pagamentoBindingNavigator.Size = new System.Drawing.Size(200, 25);
             this.tb_documento_pagamentoBindingNavigator.TabIndex = 21;
             this.tb_documento_pagamentoBindingNavigator.Text = "bindingNavigator1";
             // 
             // tb_documento_pagamentoBindingSource
             // 
             this.tb_documento_pagamentoBindingSource.DataMember = "tb_documento_pagamento";
             this.tb_documento_pagamentoBindingSource.DataSource = this.saceDataSet;
             this.tb_documento_pagamentoBindingSource.Sort = "codDocumentoPagamento";
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
             // codDocumentoPagamentoTextBox
             // 
             this.codDocumentoPagamentoTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
             this.codDocumentoPagamentoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_documento_pagamentoBindingSource, "codDocumentoPagamento", true));
             this.codDocumentoPagamentoTextBox.Location = new System.Drawing.Point(5, 91);
             this.codDocumentoPagamentoTextBox.Name = "codDocumentoPagamentoTextBox";
             this.codDocumentoPagamentoTextBox.Size = new System.Drawing.Size(95, 20);
             this.codDocumentoPagamentoTextBox.TabIndex = 22;
             // 
             // codBancoComboBox
             // 
             this.codBancoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
             this.codBancoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
             this.codBancoComboBox.CausesValidation = false;
             this.codBancoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_documento_pagamentoBindingSource, "codBanco", true));
             this.codBancoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_documento_pagamentoBindingSource, "nomeBanco", true));
             this.codBancoComboBox.DataSource = this.tbbancoBindingSource;
             this.codBancoComboBox.DisplayMember = "nome";
             this.codBancoComboBox.FormattingEnabled = true;
             this.codBancoComboBox.Location = new System.Drawing.Point(146, 142);
             this.codBancoComboBox.Name = "codBancoComboBox";
             this.codBancoComboBox.Size = new System.Drawing.Size(300, 21);
             this.codBancoComboBox.TabIndex = 30;
             this.codBancoComboBox.ValueMember = "codBanco";
             this.codBancoComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codPessoaResponsavelComboBox_KeyPress);
             this.codBancoComboBox.Leave += new System.EventHandler(this.codBancoComboBox_Leave);
             // 
             // tbbancoBindingSource
             // 
             this.tbbancoBindingSource.DataMember = "tb_banco";
             this.tbbancoBindingSource.DataSource = this.saceDataSet;
             // 
             // codTipoDocumentoComboBox
             // 
             this.codTipoDocumentoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
             this.codTipoDocumentoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
             this.codTipoDocumentoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_documento_pagamentoBindingSource, "codTipoDocumento", true));
             this.codTipoDocumentoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_documento_pagamentoBindingSource, "descricaoTipoDocumento", true));
             this.codTipoDocumentoComboBox.DataSource = this.tbtipodocumentoBindingSource;
             this.codTipoDocumentoComboBox.DisplayMember = "descricao";
             this.codTipoDocumentoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
             this.codTipoDocumentoComboBox.FormattingEnabled = true;
             this.codTipoDocumentoComboBox.Location = new System.Drawing.Point(464, 91);
             this.codTipoDocumentoComboBox.Name = "codTipoDocumentoComboBox";
             this.codTipoDocumentoComboBox.Size = new System.Drawing.Size(126, 21);
             this.codTipoDocumentoComboBox.TabIndex = 26;
             this.codTipoDocumentoComboBox.ValueMember = "codTipoDocumento";
             this.codTipoDocumentoComboBox.SelectedIndexChanged += new System.EventHandler(this.codTipoDocumentoComboBox_SelectedIndexChanged);
             this.codTipoDocumentoComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codPessoaResponsavelComboBox_KeyPress);
             // 
             // tbtipodocumentoBindingSource
             // 
             this.tbtipodocumentoBindingSource.DataMember = "tb_tipo_documento";
             this.tbtipodocumentoBindingSource.DataSource = this.saceDataSet;
             this.tbtipodocumentoBindingSource.Sort = "";
             // 
             // numeroDocumentoTextBox
             // 
             this.numeroDocumentoTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
             this.numeroDocumentoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_documento_pagamentoBindingSource, "numeroDocumento", true));
             this.numeroDocumentoTextBox.Location = new System.Drawing.Point(6, 143);
             this.numeroDocumentoTextBox.MaxLength = 30;
             this.numeroDocumentoTextBox.Name = "numeroDocumentoTextBox";
             this.numeroDocumentoTextBox.Size = new System.Drawing.Size(130, 20);
             this.numeroDocumentoTextBox.TabIndex = 28;
             // 
             // dataDocumentoDateTimePicker
             // 
             this.dataDocumentoDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tb_documento_pagamentoBindingSource, "dataDocumento", true));
             this.dataDocumentoDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
             this.dataDocumentoDateTimePicker.Location = new System.Drawing.Point(6, 194);
             this.dataDocumentoDateTimePicker.Name = "dataDocumentoDateTimePicker";
             this.dataDocumentoDateTimePicker.Size = new System.Drawing.Size(130, 20);
             this.dataDocumentoDateTimePicker.TabIndex = 34;
             // 
             // dataVencimentoDateTimePicker
             // 
             this.dataVencimentoDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tb_documento_pagamentoBindingSource, "dataVencimento", true));
             this.dataVencimentoDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
             this.dataVencimentoDateTimePicker.Location = new System.Drawing.Point(464, 143);
             this.dataVencimentoDateTimePicker.Name = "dataVencimentoDateTimePicker";
             this.dataVencimentoDateTimePicker.Size = new System.Drawing.Size(126, 20);
             this.dataVencimentoDateTimePicker.TabIndex = 32;
             // 
             // valorTextBox
             // 
             this.valorTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
             this.valorTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_documento_pagamentoBindingSource, "valor", true));
             this.valorTextBox.Location = new System.Drawing.Point(464, 194);
             this.valorTextBox.MaxLength = 20;
             this.valorTextBox.Name = "valorTextBox";
             this.valorTextBox.Size = new System.Drawing.Size(126, 20);
             this.valorTextBox.TabIndex = 40;
             this.valorTextBox.Leave += new System.EventHandler(this.valorTextBox_Leave);
             // 
             // agenciaTextBox
             // 
             this.agenciaTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
             this.agenciaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_documento_pagamentoBindingSource, "agencia", true));
             this.agenciaTextBox.Location = new System.Drawing.Point(148, 197);
             this.agenciaTextBox.MaxLength = 10;
             this.agenciaTextBox.Name = "agenciaTextBox";
             this.agenciaTextBox.Size = new System.Drawing.Size(129, 20);
             this.agenciaTextBox.TabIndex = 36;
             // 
             // contaTextBox
             // 
             this.contaTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
             this.contaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_documento_pagamentoBindingSource, "conta", true));
             this.contaTextBox.Location = new System.Drawing.Point(291, 197);
             this.contaTextBox.MaxLength = 20;
             this.contaTextBox.Name = "contaTextBox";
             this.contaTextBox.Size = new System.Drawing.Size(155, 20);
             this.contaTextBox.TabIndex = 38;
             // 
             // emitenteTextBox
             // 
             this.emitenteTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
             this.emitenteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_documento_pagamentoBindingSource, "emitente", true));
             this.emitenteTextBox.Location = new System.Drawing.Point(6, 243);
             this.emitenteTextBox.MaxLength = 40;
             this.emitenteTextBox.Name = "emitenteTextBox";
             this.emitenteTextBox.Size = new System.Drawing.Size(584, 20);
             this.emitenteTextBox.TabIndex = 42;
             // 
             // observacaoTextBox
             // 
             this.observacaoTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
             this.observacaoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_documento_pagamentoBindingSource, "observacao", true));
             this.observacaoTextBox.Location = new System.Drawing.Point(7, 287);
             this.observacaoTextBox.MaxLength = 200;
             this.observacaoTextBox.Multiline = true;
             this.observacaoTextBox.Name = "observacaoTextBox";
             this.observacaoTextBox.Size = new System.Drawing.Size(583, 68);
             this.observacaoTextBox.TabIndex = 44;
             // 
             // codPessoaResponsavelComboBox
             // 
             this.codPessoaResponsavelComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
             this.codPessoaResponsavelComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
             this.codPessoaResponsavelComboBox.CausesValidation = false;
             this.codPessoaResponsavelComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_documento_pagamentoBindingSource, "codPessoaResponsavel", true));
             this.codPessoaResponsavelComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_documento_pagamentoBindingSource, "nomePessoaResponsavel", true));
             this.codPessoaResponsavelComboBox.DataSource = this.tbpessoaBindingSource;
             this.codPessoaResponsavelComboBox.DisplayMember = "nome";
             this.codPessoaResponsavelComboBox.FormattingEnabled = true;
             this.codPessoaResponsavelComboBox.Location = new System.Drawing.Point(114, 89);
             this.codPessoaResponsavelComboBox.Name = "codPessoaResponsavelComboBox";
             this.codPessoaResponsavelComboBox.Size = new System.Drawing.Size(332, 21);
             this.codPessoaResponsavelComboBox.TabIndex = 24;
             this.codPessoaResponsavelComboBox.ValueMember = "codPessoa";
             this.codPessoaResponsavelComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codPessoaResponsavelComboBox_KeyPress);
             this.codPessoaResponsavelComboBox.Leave += new System.EventHandler(this.codPessoaResponsavelComboBox_Leave);
             // 
             // tbpessoaBindingSource
             // 
             this.tbpessoaBindingSource.DataMember = "tb_pessoa";
             this.tbpessoaBindingSource.DataSource = this.saceDataSet;
             // 
             // tb_documento_pagamentoTableAdapter
             // 
             this.tb_documento_pagamentoTableAdapter.ClearBeforeFill = true;
             // 
             // tb_pessoaTableAdapter
             // 
             this.tb_pessoaTableAdapter.ClearBeforeFill = true;
             // 
             // tb_bancoTableAdapter
             // 
             this.tb_bancoTableAdapter.ClearBeforeFill = true;
             // 
             // tb_tipo_documentoTableAdapter
             // 
             this.tb_tipo_documentoTableAdapter.ClearBeforeFill = true;
             // 
             // FrmDocumentoPagamento
             // 
             this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
             this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
             this.ClientSize = new System.Drawing.Size(602, 396);
             this.Controls.Add(this.codPessoaResponsavelComboBox);
             this.Controls.Add(this.observacaoTextBox);
             this.Controls.Add(codDocumentoPagamentoLabel);
             this.Controls.Add(this.tb_documento_pagamentoBindingNavigator);
             this.Controls.Add(this.codDocumentoPagamentoTextBox);
             this.Controls.Add(codPessoaResponsavelLabel);
             this.Controls.Add(codBancoLabel);
             this.Controls.Add(this.codBancoComboBox);
             this.Controls.Add(codTipoDocumentoLabel);
             this.Controls.Add(this.codTipoDocumentoComboBox);
             this.Controls.Add(numeroDocumentoLabel);
             this.Controls.Add(this.numeroDocumentoTextBox);
             this.Controls.Add(dataDocumentoLabel);
             this.Controls.Add(this.dataDocumentoDateTimePicker);
             this.Controls.Add(dataVencimentoLabel);
             this.Controls.Add(this.dataVencimentoDateTimePicker);
             this.Controls.Add(valorLabel);
             this.Controls.Add(this.valorTextBox);
             this.Controls.Add(agenciaLabel);
             this.Controls.Add(this.agenciaTextBox);
             this.Controls.Add(contaLabel);
             this.Controls.Add(this.contaTextBox);
             this.Controls.Add(emitenteLabel);
             this.Controls.Add(this.emitenteTextBox);
             this.Controls.Add(observacaoLabel);
             this.Controls.Add(this.btnSalvar);
             this.Controls.Add(this.btnBuscar);
             this.Controls.Add(this.btnCancelar);
             this.Controls.Add(this.btnNovo);
             this.Controls.Add(this.btnExcluir);
             this.Controls.Add(this.btnEditar);
             this.Controls.Add(this.panel1);
             this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
             this.KeyPreview = true;
             this.Name = "FrmDocumentoPagamento";
             this.ShowInTaskbar = false;
             this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
             this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
             this.Text = "Cadastro de Documentos de Pagamento";
             this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDocumentoPagamento_FormClosing);
             this.Load += new System.EventHandler(this.FrmDocumentoPagamento_Load);
             this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmDocumentoPagamento_KeyDown);
             this.panel1.ResumeLayout(false);
             this.panel1.PerformLayout();
             ((System.ComponentModel.ISupportInitialize)(this.tb_documento_pagamentoBindingNavigator)).EndInit();
             this.tb_documento_pagamentoBindingNavigator.ResumeLayout(false);
             this.tb_documento_pagamentoBindingNavigator.PerformLayout();
             ((System.ComponentModel.ISupportInitialize)(this.tb_documento_pagamentoBindingSource)).EndInit();
             ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).EndInit();
             ((System.ComponentModel.ISupportInitialize)(this.tbbancoBindingSource)).EndInit();
             ((System.ComponentModel.ISupportInitialize)(this.tbtipodocumentoBindingSource)).EndInit();
             ((System.ComponentModel.ISupportInitialize)(this.tbpessoaBindingSource)).EndInit();
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
         private System.Windows.Forms.BindingSource tb_documento_pagamentoBindingSource;
         private System.Windows.Forms.BindingNavigator tb_documento_pagamentoBindingNavigator;
         private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
         private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
         private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
         private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
         private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
         private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
         private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
         private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
         private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
         private System.Windows.Forms.TextBox codDocumentoPagamentoTextBox;
         private System.Windows.Forms.ComboBox codBancoComboBox;
         private System.Windows.Forms.ComboBox codTipoDocumentoComboBox;
         private System.Windows.Forms.TextBox numeroDocumentoTextBox;
         private System.Windows.Forms.DateTimePicker dataDocumentoDateTimePicker;
         private System.Windows.Forms.DateTimePicker dataVencimentoDateTimePicker;
         private System.Windows.Forms.TextBox valorTextBox;
         private System.Windows.Forms.TextBox agenciaTextBox;
         private System.Windows.Forms.TextBox contaTextBox;
         private System.Windows.Forms.TextBox emitenteTextBox;
         private System.Windows.Forms.TextBox observacaoTextBox;
         private Dados.saceDataSetTableAdapters.tb_documento_pagamentoTableAdapter tb_documento_pagamentoTableAdapter;
         private System.Windows.Forms.ComboBox codPessoaResponsavelComboBox;
         private System.Windows.Forms.BindingSource tbpessoaBindingSource;
         private System.Windows.Forms.BindingSource tbbancoBindingSource;
         private Dados.saceDataSetTableAdapters.tb_pessoaTableAdapter tb_pessoaTableAdapter;
         private Dados.saceDataSetTableAdapters.tb_bancoTableAdapter tb_bancoTableAdapter;
         private System.Windows.Forms.BindingSource tbtipodocumentoBindingSource;
         private Dados.saceDataSetTableAdapters.tb_tipo_documentoTableAdapter tb_tipo_documentoTableAdapter;
     }
 }