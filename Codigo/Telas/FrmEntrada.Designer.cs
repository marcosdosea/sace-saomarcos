namespace Telas
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
            System.Windows.Forms.Label numeroNotaFiscalLabel;
            System.Windows.Forms.Label valorICMSSubstitutoLabel;
            System.Windows.Forms.Label icmsLabel;
            System.Windows.Forms.Label codProdutoLabel;
            System.Windows.Forms.Label ipiLabel;
            System.Windows.Forms.Label icmsLabel1;
            System.Windows.Forms.Label icms_substitutoLabel;
            System.Windows.Forms.Label data_validadeLabel;
            System.Windows.Forms.Label preco_custoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEntrada));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.saceDataSet = new Dados.saceDataSet();
            this.tb_entradaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_entradaTableAdapter = new Dados.saceDataSetTableAdapters.tb_entradaTableAdapter();
            this.tableAdapterManager = new Dados.saceDataSetTableAdapters.TableAdapterManager();
            this.tb_entrada_produtoTableAdapter = new Dados.saceDataSetTableAdapters.tb_entrada_produtoTableAdapter();
            this.tb_pessoaTableAdapter = new Dados.saceDataSetTableAdapters.tb_pessoaTableAdapter();
            this.tb_produtoTableAdapter = new Dados.saceDataSetTableAdapters.tb_produtoTableAdapter();
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
            this.tbpessoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codigoEmpresaFreteComboBox = new System.Windows.Forms.ComboBox();
            this.tbpessoaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.valorCustoFreteTextBox = new System.Windows.Forms.TextBox();
            this.dataEntradaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.valorTotalTextBox = new System.Windows.Forms.TextBox();
            this.numeroNotaFiscalTextBox = new System.Windows.Forms.TextBox();
            this.tb_entrada_produtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbprodutoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnProdutos = new System.Windows.Forms.Button();
            this.valorICMSSubstitutoTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPagamentos = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_entrada_produtoDataGridView = new System.Windows.Forms.DataGridView();
            this.codEntradaProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.icmsTextBox = new System.Windows.Forms.TextBox();
            this.totalNotaCalculadoTextBox = new System.Windows.Forms.TextBox();
            this.ProdutosGroupBox = new System.Windows.Forms.GroupBox();
            this.simplesTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.precoAtacadoTextBox = new System.Windows.Forms.TextBox();
            this.precoAtacadoSugestaoTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.precoVarejoTextBox = new System.Windows.Forms.TextBox();
            this.precoVarejoSugestaoTextBox = new System.Windows.Forms.TextBox();
            this.lucroAtacadoTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lucroVarejoTextBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.preco_custoTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.data_validadeDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.icms_substitutoTextBox = new System.Windows.Forms.TextBox();
            this.icmsProdutoTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.precoCompraTextBox = new System.Windows.Forms.TextBox();
            this.ipiTextBox = new System.Windows.Forms.TextBox();
            this.quantidadeTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.codProdutoComboBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.freteTextBox = new System.Windows.Forms.TextBox();
            codEntradaLabel = new System.Windows.Forms.Label();
            codigoFornecedorLabel = new System.Windows.Forms.Label();
            codigoEmpresaFreteLabel = new System.Windows.Forms.Label();
            valorCustoFreteLabel = new System.Windows.Forms.Label();
            dataEntradaLabel = new System.Windows.Forms.Label();
            valorTotalLabel = new System.Windows.Forms.Label();
            numeroNotaFiscalLabel = new System.Windows.Forms.Label();
            valorICMSSubstitutoLabel = new System.Windows.Forms.Label();
            icmsLabel = new System.Windows.Forms.Label();
            codProdutoLabel = new System.Windows.Forms.Label();
            ipiLabel = new System.Windows.Forms.Label();
            icmsLabel1 = new System.Windows.Forms.Label();
            icms_substitutoLabel = new System.Windows.Forms.Label();
            data_validadeLabel = new System.Windows.Forms.Label();
            preco_custoLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entradaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entradaBindingNavigator)).BeginInit();
            this.tb_entradaBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbpessoaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbpessoaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entrada_produtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbprodutoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entrada_produtoDataGridView)).BeginInit();
            this.ProdutosGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // codEntradaLabel
            // 
            codEntradaLabel.AutoSize = true;
            codEntradaLabel.Location = new System.Drawing.Point(4, 72);
            codEntradaLabel.Name = "codEntradaLabel";
            codEntradaLabel.Size = new System.Drawing.Size(43, 13);
            codEntradaLabel.TabIndex = 21;
            codEntradaLabel.Text = "Código:";
            // 
            // codigoFornecedorLabel
            // 
            codigoFornecedorLabel.AutoSize = true;
            codigoFornecedorLabel.Location = new System.Drawing.Point(97, 72);
            codigoFornecedorLabel.Name = "codigoFornecedorLabel";
            codigoFornecedorLabel.Size = new System.Drawing.Size(64, 13);
            codigoFornecedorLabel.TabIndex = 23;
            codigoFornecedorLabel.Text = "Fornecedor:";
            // 
            // codigoEmpresaFreteLabel
            // 
            codigoEmpresaFreteLabel.AutoSize = true;
            codigoEmpresaFreteLabel.Location = new System.Drawing.Point(4, 114);
            codigoEmpresaFreteLabel.Name = "codigoEmpresaFreteLabel";
            codigoEmpresaFreteLabel.Size = new System.Drawing.Size(78, 13);
            codigoEmpresaFreteLabel.TabIndex = 25;
            codigoEmpresaFreteLabel.Text = "Empresa Frete:";
            // 
            // valorCustoFreteLabel
            // 
            valorCustoFreteLabel.AutoSize = true;
            valorCustoFreteLabel.Location = new System.Drawing.Point(389, 114);
            valorCustoFreteLabel.Name = "valorCustoFreteLabel";
            valorCustoFreteLabel.Size = new System.Drawing.Size(87, 13);
            valorCustoFreteLabel.TabIndex = 27;
            valorCustoFreteLabel.Text = "Custo Frete (R$):";
            // 
            // dataEntradaLabel
            // 
            dataEntradaLabel.AutoSize = true;
            dataEntradaLabel.Location = new System.Drawing.Point(585, 73);
            dataEntradaLabel.Name = "dataEntradaLabel";
            dataEntradaLabel.Size = new System.Drawing.Size(73, 13);
            dataEntradaLabel.TabIndex = 29;
            dataEntradaLabel.Text = "Data Entrada:";
            // 
            // valorTotalLabel
            // 
            valorTotalLabel.AutoSize = true;
            valorTotalLabel.Location = new System.Drawing.Point(699, 115);
            valorTotalLabel.Name = "valorTotalLabel";
            valorTotalLabel.Size = new System.Drawing.Size(83, 13);
            valorTotalLabel.TabIndex = 31;
            valorTotalLabel.Text = "Total Nota (R$):";
            // 
            // numeroNotaFiscalLabel
            // 
            numeroNotaFiscalLabel.AutoSize = true;
            numeroNotaFiscalLabel.Location = new System.Drawing.Point(699, 72);
            numeroNotaFiscalLabel.Name = "numeroNotaFiscalLabel";
            numeroNotaFiscalLabel.Size = new System.Drawing.Size(63, 13);
            numeroNotaFiscalLabel.TabIndex = 35;
            numeroNotaFiscalLabel.Text = "Nota Fiscal:";
            // 
            // valorICMSSubstitutoLabel
            // 
            valorICMSSubstitutoLabel.AutoSize = true;
            valorICMSSubstitutoLabel.Location = new System.Drawing.Point(585, 115);
            valorICMSSubstitutoLabel.Name = "valorICMSSubstitutoLabel";
            valorICMSSubstitutoLabel.Size = new System.Drawing.Size(109, 13);
            valorICMSSubstitutoLabel.TabIndex = 46;
            valorICMSSubstitutoLabel.Text = "ICMS Substituto (R$):";
            // 
            // icmsLabel
            // 
            icmsLabel.AutoSize = true;
            icmsLabel.Location = new System.Drawing.Point(500, 114);
            icmsLabel.Name = "icmsLabel";
            icmsLabel.Size = new System.Drawing.Size(70, 13);
            icmsLabel.TabIndex = 64;
            icmsLabel.Text = "ICMS RF (%):";
            // 
            // codProdutoLabel
            // 
            codProdutoLabel.AutoSize = true;
            codProdutoLabel.Location = new System.Drawing.Point(6, 19);
            codProdutoLabel.Name = "codProdutoLabel";
            codProdutoLabel.Size = new System.Drawing.Size(47, 13);
            codProdutoLabel.TabIndex = 75;
            codProdutoLabel.Text = "Produto:";
            // 
            // ipiLabel
            // 
            ipiLabel.AutoSize = true;
            ipiLabel.Location = new System.Drawing.Point(508, 18);
            ipiLabel.Name = "ipiLabel";
            ipiLabel.Size = new System.Drawing.Size(23, 13);
            ipiLabel.TabIndex = 75;
            ipiLabel.Text = "IPI:";
            // 
            // icmsLabel1
            // 
            icmsLabel1.AutoSize = true;
            icmsLabel1.Location = new System.Drawing.Point(602, 17);
            icmsLabel1.Name = "icmsLabel1";
            icmsLabel1.Size = new System.Drawing.Size(36, 13);
            icmsLabel1.TabIndex = 75;
            icmsLabel1.Text = "ICMS:";
            // 
            // icms_substitutoLabel
            // 
            icms_substitutoLabel.AutoSize = true;
            icms_substitutoLabel.Location = new System.Drawing.Point(643, 17);
            icms_substitutoLabel.Name = "icms_substitutoLabel";
            icms_substitutoLabel.Size = new System.Drawing.Size(53, 13);
            icms_substitutoLabel.TabIndex = 76;
            icms_substitutoLabel.Text = "ICMS ST:";
            // 
            // data_validadeLabel
            // 
            data_validadeLabel.AutoSize = true;
            data_validadeLabel.Location = new System.Drawing.Point(8, 66);
            data_validadeLabel.Name = "data_validadeLabel";
            data_validadeLabel.Size = new System.Drawing.Size(77, 13);
            data_validadeLabel.TabIndex = 77;
            data_validadeLabel.Text = "Data Validade:";
            // 
            // preco_custoLabel
            // 
            preco_custoLabel.AutoSize = true;
            preco_custoLabel.Location = new System.Drawing.Point(88, 66);
            preco_custoLabel.Name = "preco_custoLabel";
            preco_custoLabel.Size = new System.Drawing.Size(91, 13);
            preco_custoLabel.TabIndex = 79;
            preco_custoLabel.Text = "Preço Custo (R$):";
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
            this.panel1.Size = new System.Drawing.Size(824, 41);
            this.panel1.TabIndex = 20;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(307, 551);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(7, 551);
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
            this.btnCancelar.Location = new System.Drawing.Point(572, 551);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(82, 551);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "F3 - Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(232, 551);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "F5 - Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(157, 551);
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
            this.saceDataSet.Prefix = "SACE";
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
            this.tableAdapterManager.tb_pagamentoTableAdapter = null;
            this.tableAdapterManager.tb_bancoTableAdapter = null;
            this.tableAdapterManager.tb_cartao_creditoTableAdapter = null;
            this.tableAdapterManager.tb_cfopTableAdapter = null;
            this.tableAdapterManager.tb_configuracao_sistemaTableAdapter = null;
            this.tableAdapterManager.tb_conta_bancoTableAdapter = null;
            this.tableAdapterManager.tb_contaTableAdapter = null;
            this.tableAdapterManager.tb_contato_empresaTableAdapter = null;
            this.tableAdapterManager.tb_entrada_produtoTableAdapter = this.tb_entrada_produtoTableAdapter;
            this.tableAdapterManager.tb_entradaTableAdapter = this.tb_entradaTableAdapter;
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
            this.tableAdapterManager.tb_produtoTableAdapter = this.tb_produtoTableAdapter;
            this.tableAdapterManager.tb_saida_produtoTableAdapter = null;
            this.tableAdapterManager.tb_saidaTableAdapter = null;
            this.tableAdapterManager.tb_tipo_movimentacao_contaTableAdapter = null;
            this.tableAdapterManager.tb_usuarioTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = Dados.saceDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tb_entrada_produtoTableAdapter
            // 
            this.tb_entrada_produtoTableAdapter.ClearBeforeFill = true;
            // 
            // tb_pessoaTableAdapter
            // 
            this.tb_pessoaTableAdapter.ClearBeforeFill = true;
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
            this.tb_entradaBindingNavigator.Location = new System.Drawing.Point(618, 41);
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
            this.codEntradaTextBox.ReadOnly = true;
            this.codEntradaTextBox.Size = new System.Drawing.Size(84, 20);
            this.codEntradaTextBox.TabIndex = 10;
            this.codEntradaTextBox.TabStop = false;
            this.codEntradaTextBox.TextChanged += new System.EventHandler(this.codEntradaTextBox_TextChanged);
            // 
            // codigoFornecedorComboBox
            // 
            this.codigoFornecedorComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codigoFornecedorComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codigoFornecedorComboBox.CausesValidation = false;
            this.codigoFornecedorComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "nomeFornecedor", true));
            this.codigoFornecedorComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_entradaBindingSource, "codFornecedor", true));
            this.codigoFornecedorComboBox.DataSource = this.tbpessoaBindingSource;
            this.codigoFornecedorComboBox.DisplayMember = "nome";
            this.codigoFornecedorComboBox.FormattingEnabled = true;
            this.codigoFornecedorComboBox.Location = new System.Drawing.Point(100, 89);
            this.codigoFornecedorComboBox.Name = "codigoFornecedorComboBox";
            this.codigoFornecedorComboBox.Size = new System.Drawing.Size(482, 21);
            this.codigoFornecedorComboBox.TabIndex = 12;
            this.codigoFornecedorComboBox.ValueMember = "codPessoa";
            this.codigoFornecedorComboBox.Leave += new System.EventHandler(this.codigoFornecedorComboBox_Leave);
            this.codigoFornecedorComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codigoFornecedorComboBox_KeyPress);
            // 
            // tbpessoaBindingSource
            // 
            this.tbpessoaBindingSource.DataMember = "tb_pessoa";
            this.tbpessoaBindingSource.DataSource = this.saceDataSet;
            // 
            // codigoEmpresaFreteComboBox
            // 
            this.codigoEmpresaFreteComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codigoEmpresaFreteComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codigoEmpresaFreteComboBox.CausesValidation = false;
            this.codigoEmpresaFreteComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "nomeEmpresaFrete", true));
            this.codigoEmpresaFreteComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_entradaBindingSource, "codEmpresaFrete", true));
            this.codigoEmpresaFreteComboBox.DataSource = this.tbpessoaBindingSource1;
            this.codigoEmpresaFreteComboBox.DisplayMember = "nome";
            this.codigoEmpresaFreteComboBox.FormattingEnabled = true;
            this.codigoEmpresaFreteComboBox.Location = new System.Drawing.Point(7, 131);
            this.codigoEmpresaFreteComboBox.Name = "codigoEmpresaFreteComboBox";
            this.codigoEmpresaFreteComboBox.Size = new System.Drawing.Size(371, 21);
            this.codigoEmpresaFreteComboBox.TabIndex = 18;
            this.codigoEmpresaFreteComboBox.ValueMember = "codPessoa";
            this.codigoEmpresaFreteComboBox.Leave += new System.EventHandler(this.codigoEmpresaFreteComboBox_Leave);
            this.codigoEmpresaFreteComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codigoFornecedorComboBox_KeyPress);
            // 
            // tbpessoaBindingSource1
            // 
            this.tbpessoaBindingSource1.DataMember = "tb_pessoa";
            this.tbpessoaBindingSource1.DataSource = this.saceDataSet;
            // 
            // valorCustoFreteTextBox
            // 
            this.valorCustoFreteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "valorCustoFrete", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0", "N2"));
            this.valorCustoFreteTextBox.Location = new System.Drawing.Point(392, 131);
            this.valorCustoFreteTextBox.Name = "valorCustoFreteTextBox";
            this.valorCustoFreteTextBox.Size = new System.Drawing.Size(94, 20);
            this.valorCustoFreteTextBox.TabIndex = 20;
            // 
            // dataEntradaDateTimePicker
            // 
            this.dataEntradaDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tb_entradaBindingSource, "dataEntrada", true));
            this.dataEntradaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dataEntradaDateTimePicker.Location = new System.Drawing.Point(588, 90);
            this.dataEntradaDateTimePicker.Name = "dataEntradaDateTimePicker";
            this.dataEntradaDateTimePicker.Size = new System.Drawing.Size(104, 20);
            this.dataEntradaDateTimePicker.TabIndex = 14;
            // 
            // valorTotalTextBox
            // 
            this.valorTotalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "valorTotal", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0", "N2"));
            this.valorTotalTextBox.Location = new System.Drawing.Point(700, 132);
            this.valorTotalTextBox.Name = "valorTotalTextBox";
            this.valorTotalTextBox.Size = new System.Drawing.Size(116, 20);
            this.valorTotalTextBox.TabIndex = 24;
            // 
            // numeroNotaFiscalTextBox
            // 
            this.numeroNotaFiscalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "numeroNotaFiscal", true));
            this.numeroNotaFiscalTextBox.Location = new System.Drawing.Point(702, 88);
            this.numeroNotaFiscalTextBox.Name = "numeroNotaFiscalTextBox";
            this.numeroNotaFiscalTextBox.Size = new System.Drawing.Size(110, 20);
            this.numeroNotaFiscalTextBox.TabIndex = 16;
            // 
            // tb_entrada_produtoBindingSource
            // 
            this.tb_entrada_produtoBindingSource.DataMember = "tb_entrada_produto";
            this.tb_entrada_produtoBindingSource.DataSource = this.saceDataSet;
            // 
            // tbprodutoBindingSource
            // 
            this.tbprodutoBindingSource.DataMember = "tb_produto";
            this.tbprodutoBindingSource.DataSource = this.saceDataSet;
            // 
            // btnProdutos
            // 
            this.btnProdutos.Location = new System.Drawing.Point(388, 551);
            this.btnProdutos.Name = "btnProdutos";
            this.btnProdutos.Size = new System.Drawing.Size(84, 23);
            this.btnProdutos.TabIndex = 5;
            this.btnProdutos.Text = "F7 - Produtos";
            this.btnProdutos.UseVisualStyleBackColor = true;
            this.btnProdutos.Click += new System.EventHandler(this.btnProdutos_Click);
            // 
            // valorICMSSubstitutoTextBox
            // 
            this.valorICMSSubstitutoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "valorICMSSubstituto", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0", "N2"));
            this.valorICMSSubstitutoTextBox.Location = new System.Drawing.Point(588, 131);
            this.valorICMSSubstitutoTextBox.Name = "valorICMSSubstitutoTextBox";
            this.valorICMSSubstitutoTextBox.Size = new System.Drawing.Size(104, 20);
            this.valorICMSSubstitutoTextBox.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(88, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "DEL - Excluir";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(7, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 60;
            this.label6.Text = "F12 - Navegar";
            // 
            // btnPagamentos
            // 
            this.btnPagamentos.Location = new System.Drawing.Point(472, 551);
            this.btnPagamentos.Name = "btnPagamentos";
            this.btnPagamentos.Size = new System.Drawing.Size(100, 23);
            this.btnPagamentos.TabIndex = 6;
            this.btnPagamentos.Text = "F8 - Pagamentos";
            this.btnPagamentos.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(591, 394);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 26);
            this.label7.TabIndex = 63;
            this.label7.Text = "Total ";
            // 
            // tb_entrada_produtoDataGridView
            // 
            this.tb_entrada_produtoDataGridView.AllowUserToAddRows = false;
            this.tb_entrada_produtoDataGridView.AllowUserToDeleteRows = false;
            this.tb_entrada_produtoDataGridView.AutoGenerateColumns = false;
            this.tb_entrada_produtoDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tb_entrada_produtoDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_entrada_produtoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_entrada_produtoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codEntradaProduto,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.nomeProduto,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.subtotal});
            this.tb_entrada_produtoDataGridView.DataSource = this.tb_entrada_produtoBindingSource;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tb_entrada_produtoDataGridView.DefaultCellStyle = dataGridViewCellStyle20;
            this.tb_entrada_produtoDataGridView.Location = new System.Drawing.Point(7, 170);
            this.tb_entrada_produtoDataGridView.Name = "tb_entrada_produtoDataGridView";
            this.tb_entrada_produtoDataGridView.ReadOnly = true;
            this.tb_entrada_produtoDataGridView.RowHeadersVisible = false;
            this.tb_entrada_produtoDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.tb_entrada_produtoDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_entrada_produtoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_entrada_produtoDataGridView.Size = new System.Drawing.Size(809, 218);
            this.tb_entrada_produtoDataGridView.TabIndex = 38;
            this.tb_entrada_produtoDataGridView.TabStop = false;
            // 
            // codEntradaProduto
            // 
            this.codEntradaProduto.DataPropertyName = "codEntradaProduto";
            this.codEntradaProduto.HeaderText = "codEntradaProduto";
            this.codEntradaProduto.Name = "codEntradaProduto";
            this.codEntradaProduto.ReadOnly = true;
            this.codEntradaProduto.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "codEntrada";
            this.dataGridViewTextBoxColumn1.HeaderText = "codEntrada";
            this.dataGridViewTextBoxColumn1.MaxInputLength = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "codProduto";
            this.dataGridViewTextBoxColumn2.FillWeight = 15F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Código";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // nomeProduto
            // 
            this.nomeProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomeProduto.DataPropertyName = "nomeProduto";
            this.nomeProduto.HeaderText = "Produto";
            this.nomeProduto.Name = "nomeProduto";
            this.nomeProduto.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "quantidade";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewTextBoxColumn4.FillWeight = 20F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Quantidade";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "valor_compra";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Format = "C2";
            dataGridViewCellStyle17.NullValue = "0";
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewTextBoxColumn5.FillWeight = 25F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Preço";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ipi";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewTextBoxColumn6.FillWeight = 15F;
            this.dataGridViewTextBoxColumn6.HeaderText = "IPI";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // subtotal
            // 
            this.subtotal.DataPropertyName = "subtotal";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle19.Format = "C2";
            dataGridViewCellStyle19.NullValue = "0";
            this.subtotal.DefaultCellStyle = dataGridViewCellStyle19;
            this.subtotal.FillWeight = 30F;
            this.subtotal.HeaderText = "SUBTOTAL";
            this.subtotal.Name = "subtotal";
            this.subtotal.ReadOnly = true;
            // 
            // icmsTextBox
            // 
            this.icmsTextBox.CausesValidation = false;
            this.icmsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "icmsPadrao", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, "0", "N2"));
            this.icmsTextBox.Location = new System.Drawing.Point(503, 131);
            this.icmsTextBox.Name = "icmsTextBox";
            this.icmsTextBox.Size = new System.Drawing.Size(79, 20);
            this.icmsTextBox.TabIndex = 21;
            // 
            // totalNotaCalculadoTextBox
            // 
            this.totalNotaCalculadoTextBox.BackColor = System.Drawing.Color.Blue;
            this.totalNotaCalculadoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalNotaCalculadoTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.totalNotaCalculadoTextBox.Location = new System.Drawing.Point(664, 394);
            this.totalNotaCalculadoTextBox.Name = "totalNotaCalculadoTextBox";
            this.totalNotaCalculadoTextBox.ReadOnly = true;
            this.totalNotaCalculadoTextBox.Size = new System.Drawing.Size(148, 31);
            this.totalNotaCalculadoTextBox.TabIndex = 66;
            this.totalNotaCalculadoTextBox.TabStop = false;
            this.totalNotaCalculadoTextBox.Text = "0";
            this.totalNotaCalculadoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ProdutosGroupBox
            // 
            this.ProdutosGroupBox.Controls.Add(this.freteTextBox);
            this.ProdutosGroupBox.Controls.Add(this.label14);
            this.ProdutosGroupBox.Controls.Add(this.simplesTextBox);
            this.ProdutosGroupBox.Controls.Add(this.label13);
            this.ProdutosGroupBox.Controls.Add(this.precoAtacadoTextBox);
            this.ProdutosGroupBox.Controls.Add(this.precoAtacadoSugestaoTextBox);
            this.ProdutosGroupBox.Controls.Add(this.label11);
            this.ProdutosGroupBox.Controls.Add(this.label12);
            this.ProdutosGroupBox.Controls.Add(this.precoVarejoTextBox);
            this.ProdutosGroupBox.Controls.Add(this.precoVarejoSugestaoTextBox);
            this.ProdutosGroupBox.Controls.Add(this.lucroAtacadoTextBox);
            this.ProdutosGroupBox.Controls.Add(this.label10);
            this.ProdutosGroupBox.Controls.Add(this.lucroVarejoTextBox);
            this.ProdutosGroupBox.Controls.Add(this.label9);
            this.ProdutosGroupBox.Controls.Add(this.label8);
            this.ProdutosGroupBox.Controls.Add(preco_custoLabel);
            this.ProdutosGroupBox.Controls.Add(this.preco_custoTextBox);
            this.ProdutosGroupBox.Controls.Add(this.label3);
            this.ProdutosGroupBox.Controls.Add(data_validadeLabel);
            this.ProdutosGroupBox.Controls.Add(this.data_validadeDateTimePicker);
            this.ProdutosGroupBox.Controls.Add(icms_substitutoLabel);
            this.ProdutosGroupBox.Controls.Add(this.icms_substitutoTextBox);
            this.ProdutosGroupBox.Controls.Add(icmsLabel1);
            this.ProdutosGroupBox.Controls.Add(this.icmsProdutoTextBox);
            this.ProdutosGroupBox.Controls.Add(codProdutoLabel);
            this.ProdutosGroupBox.Controls.Add(this.label5);
            this.ProdutosGroupBox.Controls.Add(this.precoCompraTextBox);
            this.ProdutosGroupBox.Controls.Add(this.ipiTextBox);
            this.ProdutosGroupBox.Controls.Add(this.quantidadeTextBox);
            this.ProdutosGroupBox.Controls.Add(this.label4);
            this.ProdutosGroupBox.Controls.Add(ipiLabel);
            this.ProdutosGroupBox.Controls.Add(this.codProdutoComboBox);
            this.ProdutosGroupBox.Enabled = false;
            this.ProdutosGroupBox.Location = new System.Drawing.Point(6, 423);
            this.ProdutosGroupBox.Name = "ProdutosGroupBox";
            this.ProdutosGroupBox.Size = new System.Drawing.Size(810, 112);
            this.ProdutosGroupBox.TabIndex = 76;
            this.ProdutosGroupBox.TabStop = false;
            this.ProdutosGroupBox.Text = "Produtos da Nota Fiscal";
            // 
            // simplesTextBox
            // 
            this.simplesTextBox.Location = new System.Drawing.Point(549, 37);
            this.simplesTextBox.Name = "simplesTextBox";
            this.simplesTextBox.Size = new System.Drawing.Size(39, 20);
            this.simplesTextBox.TabIndex = 34;
            this.simplesTextBox.Leave += new System.EventHandler(this.precoCompraTextBox_Leave);
            this.simplesTextBox.DragLeave += new System.EventHandler(this.precoCompraTextBox_Leave);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(546, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 13);
            this.label13.TabIndex = 91;
            this.label13.Text = "Simples:";
            // 
            // precoAtacadoTextBox
            // 
            this.precoAtacadoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precoAtacadoTextBox.ForeColor = System.Drawing.Color.Red;
            this.precoAtacadoTextBox.Location = new System.Drawing.Point(704, 85);
            this.precoAtacadoTextBox.Name = "precoAtacadoTextBox";
            this.precoAtacadoTextBox.Size = new System.Drawing.Size(98, 20);
            this.precoAtacadoTextBox.TabIndex = 56;
            this.precoAtacadoTextBox.Text = "0";
            // 
            // precoAtacadoSugestaoTextBox
            // 
            this.precoAtacadoSugestaoTextBox.Location = new System.Drawing.Point(590, 85);
            this.precoAtacadoSugestaoTextBox.Name = "precoAtacadoSugestaoTextBox";
            this.precoAtacadoSugestaoTextBox.ReadOnly = true;
            this.precoAtacadoSugestaoTextBox.Size = new System.Drawing.Size(106, 20);
            this.precoAtacadoSugestaoTextBox.TabIndex = 54;
            this.precoAtacadoSugestaoTextBox.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(701, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 13);
            this.label11.TabIndex = 90;
            this.label11.Text = "Preço Atacado (R$):";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(587, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 13);
            this.label12.TabIndex = 89;
            this.label12.Text = "Atacado Sugestão:";
            // 
            // precoVarejoTextBox
            // 
            this.precoVarejoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precoVarejoTextBox.ForeColor = System.Drawing.Color.Red;
            this.precoVarejoTextBox.Location = new System.Drawing.Point(374, 85);
            this.precoVarejoTextBox.Name = "precoVarejoTextBox";
            this.precoVarejoTextBox.Size = new System.Drawing.Size(114, 20);
            this.precoVarejoTextBox.TabIndex = 50;
            this.precoVarejoTextBox.Text = "0";
            // 
            // precoVarejoSugestaoTextBox
            // 
            this.precoVarejoSugestaoTextBox.Location = new System.Drawing.Point(272, 85);
            this.precoVarejoSugestaoTextBox.Name = "precoVarejoSugestaoTextBox";
            this.precoVarejoSugestaoTextBox.ReadOnly = true;
            this.precoVarejoSugestaoTextBox.Size = new System.Drawing.Size(90, 20);
            this.precoVarejoSugestaoTextBox.TabIndex = 48;
            this.precoVarejoSugestaoTextBox.TabStop = false;
            // 
            // lucroAtacadoTextBox
            // 
            this.lucroAtacadoTextBox.Location = new System.Drawing.Point(494, 85);
            this.lucroAtacadoTextBox.Name = "lucroAtacadoTextBox";
            this.lucroAtacadoTextBox.Size = new System.Drawing.Size(82, 20);
            this.lucroAtacadoTextBox.TabIndex = 52;
            this.lucroAtacadoTextBox.Leave += new System.EventHandler(this.precoCompraTextBox_Leave);
            this.lucroAtacadoTextBox.DragLeave += new System.EventHandler(this.precoCompraTextBox_Leave);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(491, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 13);
            this.label10.TabIndex = 85;
            this.label10.Text = "% Lucro Atacado:";
            // 
            // lucroVarejoTextBox
            // 
            this.lucroVarejoTextBox.Location = new System.Drawing.Point(188, 85);
            this.lucroVarejoTextBox.Name = "lucroVarejoTextBox";
            this.lucroVarejoTextBox.Size = new System.Drawing.Size(78, 20);
            this.lucroVarejoTextBox.TabIndex = 46;
            this.lucroVarejoTextBox.Leave += new System.EventHandler(this.precoCompraTextBox_Leave);
            this.lucroVarejoTextBox.DragLeave += new System.EventHandler(this.precoCompraTextBox_Leave);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(185, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 82;
            this.label9.Text = "% Lucro Varejo:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(371, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 81;
            this.label8.Text = "Preço Varejo (R$):";
            // 
            // preco_custoTextBox
            // 
            this.preco_custoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entrada_produtoBindingSource, "preco_custo", true));
            this.preco_custoTextBox.Location = new System.Drawing.Point(91, 85);
            this.preco_custoTextBox.Name = "preco_custoTextBox";
            this.preco_custoTextBox.ReadOnly = true;
            this.preco_custoTextBox.Size = new System.Drawing.Size(90, 20);
            this.preco_custoTextBox.TabIndex = 44;
            this.preco_custoTextBox.TabStop = false;
            this.preco_custoTextBox.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 79;
            this.label3.Text = "Varejo Sugestão:";
            // 
            // data_validadeDateTimePicker
            // 
            this.data_validadeDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tb_entrada_produtoBindingSource, "data_validade", true));
            this.data_validadeDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.data_validadeDateTimePicker.Location = new System.Drawing.Point(9, 85);
            this.data_validadeDateTimePicker.Name = "data_validadeDateTimePicker";
            this.data_validadeDateTimePicker.Size = new System.Drawing.Size(76, 20);
            this.data_validadeDateTimePicker.TabIndex = 42;
            // 
            // icms_substitutoTextBox
            // 
            this.icms_substitutoTextBox.Location = new System.Drawing.Point(646, 37);
            this.icms_substitutoTextBox.Name = "icms_substitutoTextBox";
            this.icms_substitutoTextBox.Size = new System.Drawing.Size(50, 20);
            this.icms_substitutoTextBox.TabIndex = 38;
            this.icms_substitutoTextBox.Leave += new System.EventHandler(this.precoCompraTextBox_Leave);
            this.icms_substitutoTextBox.DragLeave += new System.EventHandler(this.precoCompraTextBox_Leave);
            // 
            // icmsProdutoTextBox
            // 
            this.icmsProdutoTextBox.Location = new System.Drawing.Point(602, 37);
            this.icmsProdutoTextBox.Name = "icmsProdutoTextBox";
            this.icmsProdutoTextBox.Size = new System.Drawing.Size(38, 20);
            this.icmsProdutoTextBox.TabIndex = 36;
            this.icmsProdutoTextBox.Leave += new System.EventHandler(this.precoCompraTextBox_Leave);
            this.icmsProdutoTextBox.DragLeave += new System.EventHandler(this.precoCompraTextBox_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(699, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 13);
            this.label5.TabIndex = 74;
            this.label5.Text = "Preço Compra (R$)";
            // 
            // precoCompraTextBox
            // 
            this.precoCompraTextBox.CausesValidation = false;
            this.precoCompraTextBox.Location = new System.Drawing.Point(702, 37);
            this.precoCompraTextBox.Name = "precoCompraTextBox";
            this.precoCompraTextBox.Size = new System.Drawing.Size(100, 20);
            this.precoCompraTextBox.TabIndex = 40;
            this.precoCompraTextBox.Leave += new System.EventHandler(this.precoCompraTextBox_Leave);
            this.precoCompraTextBox.DragLeave += new System.EventHandler(this.precoCompraTextBox_Leave);
            // 
            // ipiTextBox
            // 
            this.ipiTextBox.CausesValidation = false;
            this.ipiTextBox.Location = new System.Drawing.Point(508, 36);
            this.ipiTextBox.Name = "ipiTextBox";
            this.ipiTextBox.Size = new System.Drawing.Size(34, 20);
            this.ipiTextBox.TabIndex = 32;
            this.ipiTextBox.Leave += new System.EventHandler(this.precoCompraTextBox_Leave);
            this.ipiTextBox.DragLeave += new System.EventHandler(this.precoCompraTextBox_Leave);
            // 
            // quantidadeTextBox
            // 
            this.quantidadeTextBox.CausesValidation = false;
            this.quantidadeTextBox.Location = new System.Drawing.Point(374, 36);
            this.quantidadeTextBox.Name = "quantidadeTextBox";
            this.quantidadeTextBox.Size = new System.Drawing.Size(74, 20);
            this.quantidadeTextBox.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(371, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 73;
            this.label4.Text = "Quantidade";
            // 
            // codProdutoComboBox
            // 
            this.codProdutoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codProdutoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codProdutoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_entrada_produtoBindingSource, "codProduto", true));
            this.codProdutoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entrada_produtoBindingSource, "nomeProduto", true));
            this.codProdutoComboBox.DataSource = this.tbprodutoBindingSource;
            this.codProdutoComboBox.DisplayMember = "nome";
            this.codProdutoComboBox.FormattingEnabled = true;
            this.codProdutoComboBox.Location = new System.Drawing.Point(6, 36);
            this.codProdutoComboBox.Name = "codProdutoComboBox";
            this.codProdutoComboBox.Size = new System.Drawing.Size(362, 21);
            this.codProdutoComboBox.TabIndex = 28;
            this.codProdutoComboBox.ValueMember = "codProduto";
            this.codProdutoComboBox.Leave += new System.EventHandler(this.codProdutoComboBox_Leave);
            this.codProdutoComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codigoFornecedorComboBox_KeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(451, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(51, 13);
            this.label14.TabIndex = 92;
            this.label14.Text = "Frete (%):";
            // 
            // freteTextBox
            // 
            this.freteTextBox.Location = new System.Drawing.Point(454, 36);
            this.freteTextBox.Name = "freteTextBox";
            this.freteTextBox.ReadOnly = true;
            this.freteTextBox.Size = new System.Drawing.Size(48, 20);
            this.freteTextBox.TabIndex = 93;
            this.freteTextBox.TabStop = false;
            // 
            // FrmEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 576);
            this.Controls.Add(this.totalNotaCalculadoTextBox);
            this.Controls.Add(icmsLabel);
            this.Controls.Add(this.icmsTextBox);
            this.Controls.Add(this.tb_entrada_produtoDataGridView);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnPagamentos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(valorICMSSubstitutoLabel);
            this.Controls.Add(this.valorICMSSubstitutoTextBox);
            this.Controls.Add(this.btnProdutos);
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
            this.Controls.Add(this.ProdutosGroupBox);
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
            ((System.ComponentModel.ISupportInitialize)(this.tbpessoaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbpessoaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entrada_produtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbprodutoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entrada_produtoDataGridView)).EndInit();
            this.ProdutosGroupBox.ResumeLayout(false);
            this.ProdutosGroupBox.PerformLayout();
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
        private System.Windows.Forms.BindingSource tb_entradaBindingSource;
        private Dados.saceDataSetTableAdapters.tb_entradaTableAdapter tb_entradaTableAdapter;
        private Dados.saceDataSetTableAdapters.TableAdapterManager tableAdapterManager;
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
        private System.Windows.Forms.TextBox numeroNotaFiscalTextBox;
        private System.Windows.Forms.BindingSource tbpessoaBindingSource;
        private System.Windows.Forms.BindingSource tbpessoaBindingSource1;
        private Dados.saceDataSetTableAdapters.tb_entrada_produtoTableAdapter tb_entrada_produtoTableAdapter;
        private System.Windows.Forms.BindingSource tb_entrada_produtoBindingSource;
        private Dados.saceDataSetTableAdapters.tb_produtoTableAdapter tb_produtoTableAdapter;
        private System.Windows.Forms.BindingSource tbprodutoBindingSource;
        private System.Windows.Forms.Button btnProdutos;
        private System.Windows.Forms.TextBox valorICMSSubstitutoTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPagamentos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView tb_entrada_produtoDataGridView;
        private System.Windows.Forms.TextBox icmsTextBox;
        private System.Windows.Forms.TextBox totalNotaCalculadoTextBox;
        private Dados.saceDataSetTableAdapters.tb_pessoaTableAdapter tb_pessoaTableAdapter;
        private System.Windows.Forms.GroupBox ProdutosGroupBox;
        private System.Windows.Forms.DateTimePicker data_validadeDateTimePicker;
        private System.Windows.Forms.TextBox icms_substitutoTextBox;
        private System.Windows.Forms.TextBox icmsProdutoTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox precoCompraTextBox;
        private System.Windows.Forms.TextBox ipiTextBox;
        private System.Windows.Forms.TextBox quantidadeTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox codProdutoComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox preco_custoTextBox;
        private System.Windows.Forms.TextBox lucroVarejoTextBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox precoVarejoSugestaoTextBox;
        private System.Windows.Forms.TextBox lucroAtacadoTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox precoAtacadoTextBox;
        private System.Windows.Forms.TextBox precoAtacadoSugestaoTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox precoVarejoTextBox;
        private System.Windows.Forms.TextBox simplesTextBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridViewTextBoxColumn codEntradaProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn subtotal;
        private System.Windows.Forms.TextBox freteTextBox;
        private System.Windows.Forms.Label label14;
    }
}