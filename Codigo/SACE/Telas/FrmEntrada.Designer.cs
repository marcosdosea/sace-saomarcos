namespace SACE.Telas
{
    partial class FrmEntrada
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
            System.Windows.Forms.Label codEntradaLabel;
            System.Windows.Forms.Label codigoFornecedorLabel;
            System.Windows.Forms.Label codigoEmpresaFreteLabel;
            System.Windows.Forms.Label valorCustoFreteLabel;
            System.Windows.Forms.Label dataEntradaLabel;
            System.Windows.Forms.Label valorTotalLabel;
            System.Windows.Forms.Label tipoEntradaLabel;
            System.Windows.Forms.Label numeroNotaFiscalLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEntrada));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.saceDataSet = new SACE.Dados.saceDataSet();
            this.tb_entradaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_entradaTableAdapter = new SACE.Dados.saceDataSetTableAdapters.tb_entradaTableAdapter();
            this.tableAdapterManager = new SACE.Dados.saceDataSetTableAdapters.TableAdapterManager();
            this.tb_empresaTableAdapter = new SACE.Dados.saceDataSetTableAdapters.tb_empresaTableAdapter();
            this.tb_entradaBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.codEntradaTextBox = new System.Windows.Forms.TextBox();
            this.codigoFornecedorComboBox = new System.Windows.Forms.ComboBox();
            this.tbempresaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codigoEmpresaFreteComboBox = new System.Windows.Forms.ComboBox();
            this.tbempresaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.valorCustoFreteTextBox = new System.Windows.Forms.TextBox();
            this.dataEntradaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.valorTotalTextBox = new System.Windows.Forms.TextBox();
            this.tipoEntradaTextBox = new System.Windows.Forms.TextBox();
            this.numeroNotaFiscalTextBox = new System.Windows.Forms.TextBox();
            codEntradaLabel = new System.Windows.Forms.Label();
            codigoFornecedorLabel = new System.Windows.Forms.Label();
            codigoEmpresaFreteLabel = new System.Windows.Forms.Label();
            valorCustoFreteLabel = new System.Windows.Forms.Label();
            dataEntradaLabel = new System.Windows.Forms.Label();
            valorTotalLabel = new System.Windows.Forms.Label();
            tipoEntradaLabel = new System.Windows.Forms.Label();
            numeroNotaFiscalLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entradaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entradaBindingNavigator)).BeginInit();
            this.tb_entradaBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbempresaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbempresaBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // codEntradaLabel
            // 
            codEntradaLabel.AutoSize = true;
            codEntradaLabel.Location = new System.Drawing.Point(4, 73);
            codEntradaLabel.Name = "codEntradaLabel";
            codEntradaLabel.Size = new System.Drawing.Size(43, 13);
            codEntradaLabel.TabIndex = 21;
            codEntradaLabel.Text = "Código:";
            // 
            // codigoFornecedorLabel
            // 
            codigoFornecedorLabel.AutoSize = true;
            codigoFornecedorLabel.Location = new System.Drawing.Point(97, 73);
            codigoFornecedorLabel.Name = "codigoFornecedorLabel";
            codigoFornecedorLabel.Size = new System.Drawing.Size(64, 13);
            codigoFornecedorLabel.TabIndex = 23;
            codigoFornecedorLabel.Text = "Fornecedor:";
            // 
            // codigoEmpresaFreteLabel
            // 
            codigoEmpresaFreteLabel.AutoSize = true;
            codigoEmpresaFreteLabel.Location = new System.Drawing.Point(97, 121);
            codigoEmpresaFreteLabel.Name = "codigoEmpresaFreteLabel";
            codigoEmpresaFreteLabel.Size = new System.Drawing.Size(78, 13);
            codigoEmpresaFreteLabel.TabIndex = 25;
            codigoEmpresaFreteLabel.Text = "Empresa Frete:";
            // 
            // valorCustoFreteLabel
            // 
            valorCustoFreteLabel.AutoSize = true;
            valorCustoFreteLabel.Location = new System.Drawing.Point(395, 121);
            valorCustoFreteLabel.Name = "valorCustoFreteLabel";
            valorCustoFreteLabel.Size = new System.Drawing.Size(87, 13);
            valorCustoFreteLabel.TabIndex = 27;
            valorCustoFreteLabel.Text = "Custo Frete (R$):";
            // 
            // dataEntradaLabel
            // 
            dataEntradaLabel.AutoSize = true;
            dataEntradaLabel.Location = new System.Drawing.Point(515, 74);
            dataEntradaLabel.Name = "dataEntradaLabel";
            dataEntradaLabel.Size = new System.Drawing.Size(73, 13);
            dataEntradaLabel.TabIndex = 29;
            dataEntradaLabel.Text = "Data Entrada:";
            // 
            // valorTotalLabel
            // 
            valorTotalLabel.AutoSize = true;
            valorTotalLabel.Location = new System.Drawing.Point(515, 121);
            valorTotalLabel.Name = "valorTotalLabel";
            valorTotalLabel.Size = new System.Drawing.Size(57, 13);
            valorTotalLabel.TabIndex = 31;
            valorTotalLabel.Text = "Total (R$):";
            // 
            // tipoEntradaLabel
            // 
            tipoEntradaLabel.AutoSize = true;
            tipoEntradaLabel.Location = new System.Drawing.Point(106, 44);
            tipoEntradaLabel.Name = "tipoEntradaLabel";
            tipoEntradaLabel.Size = new System.Drawing.Size(67, 13);
            tipoEntradaLabel.TabIndex = 33;
            tipoEntradaLabel.Text = "tipo Entrada:";
            // 
            // numeroNotaFiscalLabel
            // 
            numeroNotaFiscalLabel.AutoSize = true;
            numeroNotaFiscalLabel.Location = new System.Drawing.Point(4, 121);
            numeroNotaFiscalLabel.Name = "numeroNotaFiscalLabel";
            numeroNotaFiscalLabel.Size = new System.Drawing.Size(63, 13);
            numeroNotaFiscalLabel.TabIndex = 35;
            numeroNotaFiscalLabel.Text = "Nota Fiscal:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Entrada de Produtos";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(655, 41);
            this.panel1.TabIndex = 20;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(300, 426);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(0, 426);
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
            this.btnCancelar.Location = new System.Drawing.Point(381, 426);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(75, 426);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "F3 - Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(225, 426);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "F5 - Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(150, 426);
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
            // tb_entradaBindingSource
            // 
            this.tb_entradaBindingSource.DataMember = "tb_entrada";
            this.tb_entradaBindingSource.DataSource = this.saceDataSet;
            // 
            // tb_entradaTableAdapter
            // 
            this.tb_entradaTableAdapter.ClearBeforeFill = true;
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
            this.tableAdapterManager.tb_empresaTableAdapter = this.tb_empresaTableAdapter;
            this.tableAdapterManager.tb_entrada_produtoTableAdapter = null;
            this.tableAdapterManager.tb_entradaTableAdapter = this.tb_entradaTableAdapter;
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
            // tb_empresaTableAdapter
            // 
            this.tb_empresaTableAdapter.ClearBeforeFill = true;
            // 
            // tb_entradaBindingNavigator
            // 
            this.tb_entradaBindingNavigator.AddNewItem = null;
            this.tb_entradaBindingNavigator.BindingSource = this.tb_entradaBindingSource;
            this.tb_entradaBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tb_entradaBindingNavigator.DeleteItem = null;
            this.tb_entradaBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.tb_entradaBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.tb_entradaBindingNavigator.Location = new System.Drawing.Point(449, 41);
            this.tb_entradaBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tb_entradaBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tb_entradaBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tb_entradaBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tb_entradaBindingNavigator.Name = "tb_entradaBindingNavigator";
            this.tb_entradaBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tb_entradaBindingNavigator.Size = new System.Drawing.Size(209, 25);
            this.tb_entradaBindingNavigator.TabIndex = 21;
            this.tb_entradaBindingNavigator.Text = "bindingNavigator1";
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
            // codEntradaTextBox
            // 
            this.codEntradaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "codEntrada", true));
            this.codEntradaTextBox.Location = new System.Drawing.Point(7, 89);
            this.codEntradaTextBox.Name = "codEntradaTextBox";
            this.codEntradaTextBox.Size = new System.Drawing.Size(84, 20);
            this.codEntradaTextBox.TabIndex = 22;
            // 
            // codigoFornecedorComboBox
            // 
            this.codigoFornecedorComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "codigoFornecedor", true));
            this.codigoFornecedorComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_entradaBindingSource, "codigoFornecedor", true));
            this.codigoFornecedorComboBox.DataSource = this.tbempresaBindingSource;
            this.codigoFornecedorComboBox.DisplayMember = "nome";
            this.codigoFornecedorComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codigoFornecedorComboBox.FormattingEnabled = true;
            this.codigoFornecedorComboBox.Location = new System.Drawing.Point(100, 89);
            this.codigoFornecedorComboBox.Name = "codigoFornecedorComboBox";
            this.codigoFornecedorComboBox.Size = new System.Drawing.Size(412, 21);
            this.codigoFornecedorComboBox.TabIndex = 23;
            this.codigoFornecedorComboBox.ValueMember = "codigoEmpresa";
            // 
            // tbempresaBindingSource
            // 
            this.tbempresaBindingSource.DataMember = "tb_empresa";
            this.tbempresaBindingSource.DataSource = this.saceDataSet;
            // 
            // codigoEmpresaFreteComboBox
            // 
            this.codigoEmpresaFreteComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "codigoEmpresaFrete", true));
            this.codigoEmpresaFreteComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_entradaBindingSource, "codigoEmpresaFrete", true));
            this.codigoEmpresaFreteComboBox.DataSource = this.tbempresaBindingSource1;
            this.codigoEmpresaFreteComboBox.DisplayMember = "nome";
            this.codigoEmpresaFreteComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codigoEmpresaFreteComboBox.FormattingEnabled = true;
            this.codigoEmpresaFreteComboBox.Location = new System.Drawing.Point(100, 136);
            this.codigoEmpresaFreteComboBox.Name = "codigoEmpresaFreteComboBox";
            this.codigoEmpresaFreteComboBox.Size = new System.Drawing.Size(281, 21);
            this.codigoEmpresaFreteComboBox.TabIndex = 28;
            this.codigoEmpresaFreteComboBox.ValueMember = "codigoEmpresa";
            // 
            // tbempresaBindingSource1
            // 
            this.tbempresaBindingSource1.DataMember = "tb_empresa";
            this.tbempresaBindingSource1.DataSource = this.saceDataSet;
            // 
            // valorCustoFreteTextBox
            // 
            this.valorCustoFreteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "valorCustoFrete", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.valorCustoFreteTextBox.Location = new System.Drawing.Point(398, 137);
            this.valorCustoFreteTextBox.Name = "valorCustoFreteTextBox";
            this.valorCustoFreteTextBox.Size = new System.Drawing.Size(114, 20);
            this.valorCustoFreteTextBox.TabIndex = 30;
            // 
            // dataEntradaDateTimePicker
            // 
            this.dataEntradaDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tb_entradaBindingSource, "dataEntrada", true));
            this.dataEntradaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dataEntradaDateTimePicker.Location = new System.Drawing.Point(518, 90);
            this.dataEntradaDateTimePicker.Name = "dataEntradaDateTimePicker";
            this.dataEntradaDateTimePicker.Size = new System.Drawing.Size(124, 20);
            this.dataEntradaDateTimePicker.TabIndex = 24;
            // 
            // valorTotalTextBox
            // 
            this.valorTotalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "valorTotal", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "C2"));
            this.valorTotalTextBox.Location = new System.Drawing.Point(518, 137);
            this.valorTotalTextBox.Name = "valorTotalTextBox";
            this.valorTotalTextBox.Size = new System.Drawing.Size(124, 20);
            this.valorTotalTextBox.TabIndex = 32;
            // 
            // tipoEntradaTextBox
            // 
            this.tipoEntradaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "tipoEntrada", true));
            this.tipoEntradaTextBox.Location = new System.Drawing.Point(179, 41);
            this.tipoEntradaTextBox.Name = "tipoEntradaTextBox";
            this.tipoEntradaTextBox.Size = new System.Drawing.Size(72, 20);
            this.tipoEntradaTextBox.TabIndex = 34;
            // 
            // numeroNotaFiscalTextBox
            // 
            this.numeroNotaFiscalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "numeroNotaFiscal", true));
            this.numeroNotaFiscalTextBox.Location = new System.Drawing.Point(7, 137);
            this.numeroNotaFiscalTextBox.Name = "numeroNotaFiscalTextBox";
            this.numeroNotaFiscalTextBox.Size = new System.Drawing.Size(84, 20);
            this.numeroNotaFiscalTextBox.TabIndex = 26;
            // 
            // FrmEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 469);
            this.Controls.Add(codEntradaLabel);
            this.Controls.Add(this.codEntradaTextBox);
            this.Controls.Add(codigoFornecedorLabel);
            this.Controls.Add(this.codigoFornecedorComboBox);
            this.Controls.Add(codigoEmpresaFreteLabel);
            this.Controls.Add(this.codigoEmpresaFreteComboBox);
            this.Controls.Add(valorCustoFreteLabel);
            this.Controls.Add(this.valorCustoFreteTextBox);
            this.Controls.Add(dataEntradaLabel);
            this.Controls.Add(this.dataEntradaDateTimePicker);
            this.Controls.Add(valorTotalLabel);
            this.Controls.Add(this.valorTotalTextBox);
            this.Controls.Add(tipoEntradaLabel);
            this.Controls.Add(this.tipoEntradaTextBox);
            this.Controls.Add(numeroNotaFiscalLabel);
            this.Controls.Add(this.numeroNotaFiscalTextBox);
            this.Controls.Add(this.tb_entradaBindingNavigator);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmEntrada";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de Entradas";
            this.Load += new System.EventHandler(this.FrmEntrada_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmEntrada_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entradaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entradaBindingNavigator)).EndInit();
            this.tb_entradaBindingNavigator.ResumeLayout(false);
            this.tb_entradaBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbempresaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbempresaBindingSource1)).EndInit();
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
        private System.Windows.Forms.BindingSource tb_entradaBindingSource;
        private SACE.Dados.saceDataSetTableAdapters.tb_entradaTableAdapter tb_entradaTableAdapter;
        private SACE.Dados.saceDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator tb_entradaBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.TextBox codEntradaTextBox;
        private System.Windows.Forms.ComboBox codigoFornecedorComboBox;
        private System.Windows.Forms.ComboBox codigoEmpresaFreteComboBox;
        private System.Windows.Forms.TextBox valorCustoFreteTextBox;
        private System.Windows.Forms.DateTimePicker dataEntradaDateTimePicker;
        private System.Windows.Forms.TextBox valorTotalTextBox;
        private System.Windows.Forms.TextBox tipoEntradaTextBox;
        private System.Windows.Forms.TextBox numeroNotaFiscalTextBox;
        private SACE.Dados.saceDataSetTableAdapters.tb_empresaTableAdapter tb_empresaTableAdapter;
        private System.Windows.Forms.BindingSource tbempresaBindingSource;
        private System.Windows.Forms.BindingSource tbempresaBindingSource1;
    }
}