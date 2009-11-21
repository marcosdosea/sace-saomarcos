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
            System.Windows.Forms.Label valorICMSSubstitutoLabel;
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
            this.tb_entrada_produtoTableAdapter = new SACE.Dados.saceDataSetTableAdapters.tb_entrada_produtoTableAdapter();
            this.tb_produtoTableAdapter = new SACE.Dados.saceDataSetTableAdapters.tb_produtoTableAdapter();
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.tb_entrada_produtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_entrada_produtoDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codProdutoComboBox = new System.Windows.Forms.ComboBox();
            this.tbprodutoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnProduto = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.valorICMSSubstitutoTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPagamentos = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            codEntradaLabel = new System.Windows.Forms.Label();
            codigoFornecedorLabel = new System.Windows.Forms.Label();
            codigoEmpresaFreteLabel = new System.Windows.Forms.Label();
            valorCustoFreteLabel = new System.Windows.Forms.Label();
            dataEntradaLabel = new System.Windows.Forms.Label();
            valorTotalLabel = new System.Windows.Forms.Label();
            tipoEntradaLabel = new System.Windows.Forms.Label();
            numeroNotaFiscalLabel = new System.Windows.Forms.Label();
            valorICMSSubstitutoLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entradaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entradaBindingNavigator)).BeginInit();
            this.tb_entradaBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbempresaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbempresaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entrada_produtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entrada_produtoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbprodutoBindingSource)).BeginInit();
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
            codigoEmpresaFreteLabel.Location = new System.Drawing.Point(0, 118);
            codigoEmpresaFreteLabel.Name = "codigoEmpresaFreteLabel";
            codigoEmpresaFreteLabel.Size = new System.Drawing.Size(78, 13);
            codigoEmpresaFreteLabel.TabIndex = 25;
            codigoEmpresaFreteLabel.Text = "Empresa Frete:";
            // 
            // valorCustoFreteLabel
            // 
            valorCustoFreteLabel.AutoSize = true;
            valorCustoFreteLabel.Location = new System.Drawing.Point(491, 118);
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
            valorTotalLabel.Location = new System.Drawing.Point(611, 118);
            valorTotalLabel.Name = "valorTotalLabel";
            valorTotalLabel.Size = new System.Drawing.Size(83, 13);
            valorTotalLabel.TabIndex = 31;
            valorTotalLabel.Text = "Total Nota (R$):";
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
            numeroNotaFiscalLabel.Location = new System.Drawing.Point(653, 73);
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
            this.panel1.Size = new System.Drawing.Size(749, 41);
            this.panel1.TabIndex = 20;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(300, 469);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(0, 469);
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
            this.btnCancelar.Location = new System.Drawing.Point(561, 469);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(75, 469);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "F3 - Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(225, 469);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "F5 - Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(150, 469);
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
            this.tableAdapterManager.tb_entrada_produtoTableAdapter = this.tb_entrada_produtoTableAdapter;
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
            this.tableAdapterManager.tb_produtoTableAdapter = this.tb_produtoTableAdapter;
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
            // tb_entrada_produtoTableAdapter
            // 
            this.tb_entrada_produtoTableAdapter.ClearBeforeFill = true;
            // 
            // tb_produtoTableAdapter
            // 
            this.tb_produtoTableAdapter.ClearBeforeFill = true;
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
            this.tb_entradaBindingNavigator.Location = new System.Drawing.Point(540, 41);
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
            this.codigoEmpresaFreteComboBox.Location = new System.Drawing.Point(3, 133);
            this.codigoEmpresaFreteComboBox.Name = "codigoEmpresaFreteComboBox";
            this.codigoEmpresaFreteComboBox.Size = new System.Drawing.Size(331, 21);
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
            this.valorCustoFreteTextBox.Location = new System.Drawing.Point(494, 134);
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
            this.valorTotalTextBox.Location = new System.Drawing.Point(614, 134);
            this.valorTotalTextBox.Name = "valorTotalTextBox";
            this.valorTotalTextBox.Size = new System.Drawing.Size(126, 20);
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
            this.numeroNotaFiscalTextBox.Location = new System.Drawing.Point(656, 89);
            this.numeroNotaFiscalTextBox.Name = "numeroNotaFiscalTextBox";
            this.numeroNotaFiscalTextBox.Size = new System.Drawing.Size(84, 20);
            this.numeroNotaFiscalTextBox.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Produto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(494, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Quantidade";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(615, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Preço (R$)";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(494, 190);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(112, 20);
            this.textBox3.TabIndex = 42;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(616, 190);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(124, 20);
            this.textBox4.TabIndex = 43;
            // 
            // tb_entrada_produtoBindingSource
            // 
            this.tb_entrada_produtoBindingSource.DataMember = "tb_entrada_produto";
            this.tb_entrada_produtoBindingSource.DataSource = this.saceDataSet;
            // 
            // tb_entrada_produtoDataGridView
            // 
            this.tb_entrada_produtoDataGridView.AllowUserToAddRows = false;
            this.tb_entrada_produtoDataGridView.AllowUserToDeleteRows = false;
            this.tb_entrada_produtoDataGridView.AutoGenerateColumns = false;
            this.tb_entrada_produtoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_entrada_produtoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.tb_entrada_produtoDataGridView.DataSource = this.tb_entrada_produtoBindingSource;
            this.tb_entrada_produtoDataGridView.Location = new System.Drawing.Point(7, 243);
            this.tb_entrada_produtoDataGridView.Name = "tb_entrada_produtoDataGridView";
            this.tb_entrada_produtoDataGridView.ReadOnly = true;
            this.tb_entrada_produtoDataGridView.Size = new System.Drawing.Size(733, 166);
            this.tb_entrada_produtoDataGridView.TabIndex = 43;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "codEntrada";
            this.dataGridViewTextBoxColumn1.HeaderText = "codEntrada";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "codProduto";
            this.dataGridViewTextBoxColumn2.HeaderText = "codProduto";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "quantidade";
            this.dataGridViewTextBoxColumn3.HeaderText = "quantidade";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "valor_compra";
            this.dataGridViewTextBoxColumn4.HeaderText = "valor_compra";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ipi";
            this.dataGridViewTextBoxColumn5.HeaderText = "ipi";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "icms";
            this.dataGridViewTextBoxColumn6.HeaderText = "icms";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "preco_custo";
            this.dataGridViewTextBoxColumn7.HeaderText = "preco_custo";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "nome";
            this.dataGridViewTextBoxColumn8.HeaderText = "nome";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // codProdutoComboBox
            // 
            this.codProdutoComboBox.DataSource = this.tbprodutoBindingSource;
            this.codProdutoComboBox.DisplayMember = "nome";
            this.codProdutoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codProdutoComboBox.FormattingEnabled = true;
            this.codProdutoComboBox.Location = new System.Drawing.Point(7, 190);
            this.codProdutoComboBox.Name = "codProdutoComboBox";
            this.codProdutoComboBox.Size = new System.Drawing.Size(469, 21);
            this.codProdutoComboBox.TabIndex = 44;
            this.codProdutoComboBox.ValueMember = "codProduto";
            // 
            // tbprodutoBindingSource
            // 
            this.tbprodutoBindingSource.DataMember = "tb_produto";
            this.tbprodutoBindingSource.DataSource = this.saceDataSet;
            // 
            // btnProduto
            // 
            this.btnProduto.Location = new System.Drawing.Point(380, 469);
            this.btnProduto.Name = "btnProduto";
            this.btnProduto.Size = new System.Drawing.Size(81, 23);
            this.btnProduto.TabIndex = 45;
            this.btnProduto.Text = "F7 - Produtos";
            this.btnProduto.UseVisualStyleBackColor = true;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(632, 214);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(106, 23);
            this.btnAdicionar.TabIndex = 46;
            this.btnAdicionar.Text = "Adicionar Produto";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            // 
            // valorICMSSubstitutoLabel
            // 
            valorICMSSubstitutoLabel.AutoSize = true;
            valorICMSSubstitutoLabel.Location = new System.Drawing.Point(353, 118);
            valorICMSSubstitutoLabel.Name = "valorICMSSubstitutoLabel";
            valorICMSSubstitutoLabel.Size = new System.Drawing.Size(109, 13);
            valorICMSSubstitutoLabel.TabIndex = 46;
            valorICMSSubstitutoLabel.Text = "ICMS Substituto (R$):";
            // 
            // valorICMSSubstitutoTextBox
            // 
            this.valorICMSSubstitutoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "valorICMSSubstituto", true));
            this.valorICMSSubstitutoTextBox.Location = new System.Drawing.Point(351, 133);
            this.valorICMSSubstitutoTextBox.Name = "valorICMSSubstitutoTextBox";
            this.valorICMSSubstitutoTextBox.Size = new System.Drawing.Size(125, 20);
            this.valorICMSSubstitutoTextBox.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(89, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "DEL - Excluir";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(4, 227);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 60;
            this.label6.Text = "F12 - Navegar";
            // 
            // btnPagamentos
            // 
            this.btnPagamentos.Location = new System.Drawing.Point(461, 469);
            this.btnPagamentos.Name = "btnPagamentos";
            this.btnPagamentos.Size = new System.Drawing.Size(100, 23);
            this.btnPagamentos.TabIndex = 62;
            this.btnPagamentos.Text = "F8 - Pagamentos";
            this.btnPagamentos.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(525, 423);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 63;
            this.label7.Text = "Total: ";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(605, 423);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(57, 13);
            this.lblTotal.TabIndex = 64;
            this.lblTotal.Text = "R$ 100,00";
            // 
            // FrmEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 496);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnPagamentos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(valorICMSSubstitutoLabel);
            this.Controls.Add(this.valorICMSSubstitutoTextBox);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.btnProduto);
            this.Controls.Add(this.codProdutoComboBox);
            this.Controls.Add(this.tb_entrada_produtoDataGridView);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
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
            ((System.ComponentModel.ISupportInitialize)(this.tb_entrada_produtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entrada_produtoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbprodutoBindingSource)).EndInit();
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private SACE.Dados.saceDataSetTableAdapters.tb_entrada_produtoTableAdapter tb_entrada_produtoTableAdapter;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.BindingSource tb_entrada_produtoBindingSource;
        private System.Windows.Forms.DataGridView tb_entrada_produtoDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.ComboBox codProdutoComboBox;
        private SACE.Dados.saceDataSetTableAdapters.tb_produtoTableAdapter tb_produtoTableAdapter;
        private System.Windows.Forms.BindingSource tbprodutoBindingSource;
        private System.Windows.Forms.Button btnProduto;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.TextBox valorICMSSubstitutoTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPagamentos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotal;
    }
}