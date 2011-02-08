namespace Telas
{
    partial class FrmProduto
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
            System.Windows.Forms.Label codProdutoLabel;
            System.Windows.Forms.Label nomeLabel;
            System.Windows.Forms.Label unidadeLabel;
            System.Windows.Forms.Label codigoBarraLabel;
            System.Windows.Forms.Label codGrupoLabel;
            System.Windows.Forms.Label codigoFabricanteLabel;
            System.Windows.Forms.Label cfopLabel;
            System.Windows.Forms.Label icmsLabel;
            System.Windows.Forms.Label simplesLabel;
            System.Windows.Forms.Label ipiLabel;
            System.Windows.Forms.Label freteLabel;
            System.Windows.Forms.Label custoVendaLabel;
            System.Windows.Forms.Label ultimaDataAtualizacaoLabel;
            System.Windows.Forms.Label nomeFabricanteLabel;
            System.Windows.Forms.Label lucroPrecoVendaVarejoLabel;
            System.Windows.Forms.Label precoVendaVarejoLabel;
            System.Windows.Forms.Label lucroPrecoVendaAtacadoLabel;
            System.Windows.Forms.Label precoVendaAtacadoLabel;
            System.Windows.Forms.Label qtdProdutoAtacadoLabel;
            System.Windows.Forms.Label icms_substitutoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProduto));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.saceDataSet = new Dados.saceDataSet();
            this.tb_produtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_produtoTableAdapter = new Dados.saceDataSetTableAdapters.tb_produtoTableAdapter();
            this.tableAdapterManager = new Dados.saceDataSetTableAdapters.TableAdapterManager();
            this.tb_cfopTableAdapter = new Dados.saceDataSetTableAdapters.tb_cfopTableAdapter();
            this.tb_grupoTableAdapter = new Dados.saceDataSetTableAdapters.tb_grupoTableAdapter();
            this.tb_pessoaTableAdapter = new Dados.saceDataSetTableAdapters.tb_pessoaTableAdapter();
            this.tb_produtoBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.codProdutoTextBox = new System.Windows.Forms.TextBox();
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.unidadeTextBox = new System.Windows.Forms.TextBox();
            this.codigoBarraTextBox = new System.Windows.Forms.TextBox();
            this.codGrupoComboBox = new System.Windows.Forms.ComboBox();
            this.tbgrupoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codigoFabricanteComboBox = new System.Windows.Forms.ComboBox();
            this.tb_pessoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.temVencimentoCheckBox = new System.Windows.Forms.CheckBox();
            this.icmsTextBox = new System.Windows.Forms.TextBox();
            this.simplesTextBox = new System.Windows.Forms.TextBox();
            this.ipiTextBox = new System.Windows.Forms.TextBox();
            this.freteTextBox = new System.Windows.Forms.TextBox();
            this.ultimoPrecoCompraTextBox = new System.Windows.Forms.TextBox();
            this.ultimaDataAtualizacaoDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.exibeNaListagemCheckBox = new System.Windows.Forms.CheckBox();
            this.nomeFabricanteTextBox = new System.Windows.Forms.TextBox();
            this.lucroPrecoVendaVarejoTextBox = new System.Windows.Forms.TextBox();
            this.precoVendaVarejoTextBox = new System.Windows.Forms.TextBox();
            this.lucroPrecoVendaAtacadoTextBox = new System.Windows.Forms.TextBox();
            this.precoVendaAtacadoTextBox = new System.Windows.Forms.TextBox();
            this.qtdProdutoAtacadoTextBox = new System.Windows.Forms.TextBox();
            this.tbcfopBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cfopComboBox = new System.Windows.Forms.ComboBox();
            this.icms_substitutoTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.precoVarejoSugestaoTextBox = new System.Windows.Forms.TextBox();
            this.precoAtacadoSugestaoTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_produto_lojaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_produto_lojaDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeLoja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_produto_lojaTableAdapter = new Dados.saceDataSetTableAdapters.tb_produto_lojaTableAdapter();
            this.btnEstoque = new System.Windows.Forms.Button();
            codProdutoLabel = new System.Windows.Forms.Label();
            nomeLabel = new System.Windows.Forms.Label();
            unidadeLabel = new System.Windows.Forms.Label();
            codigoBarraLabel = new System.Windows.Forms.Label();
            codGrupoLabel = new System.Windows.Forms.Label();
            codigoFabricanteLabel = new System.Windows.Forms.Label();
            cfopLabel = new System.Windows.Forms.Label();
            icmsLabel = new System.Windows.Forms.Label();
            simplesLabel = new System.Windows.Forms.Label();
            ipiLabel = new System.Windows.Forms.Label();
            freteLabel = new System.Windows.Forms.Label();
            custoVendaLabel = new System.Windows.Forms.Label();
            ultimaDataAtualizacaoLabel = new System.Windows.Forms.Label();
            nomeFabricanteLabel = new System.Windows.Forms.Label();
            lucroPrecoVendaVarejoLabel = new System.Windows.Forms.Label();
            precoVendaVarejoLabel = new System.Windows.Forms.Label();
            lucroPrecoVendaAtacadoLabel = new System.Windows.Forms.Label();
            precoVendaAtacadoLabel = new System.Windows.Forms.Label();
            qtdProdutoAtacadoLabel = new System.Windows.Forms.Label();
            icms_substitutoLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoBindingNavigator)).BeginInit();
            this.tb_produtoBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbgrupoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_pessoaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcfopBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produto_lojaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produto_lojaDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // codProdutoLabel
            // 
            codProdutoLabel.AutoSize = true;
            codProdutoLabel.Location = new System.Drawing.Point(4, 72);
            codProdutoLabel.Name = "codProdutoLabel";
            codProdutoLabel.Size = new System.Drawing.Size(43, 13);
            codProdutoLabel.TabIndex = 21;
            codProdutoLabel.Text = "Código:";
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Location = new System.Drawing.Point(147, 68);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new System.Drawing.Size(38, 13);
            nomeLabel.TabIndex = 23;
            nomeLabel.Text = "Nome:";
            // 
            // unidadeLabel
            // 
            unidadeLabel.AutoSize = true;
            unidadeLabel.Location = new System.Drawing.Point(6, 155);
            unidadeLabel.Name = "unidadeLabel";
            unidadeLabel.Size = new System.Drawing.Size(47, 13);
            unidadeLabel.TabIndex = 25;
            unidadeLabel.Text = "Unidade";
            // 
            // codigoBarraLabel
            // 
            codigoBarraLabel.AutoSize = true;
            codigoBarraLabel.Location = new System.Drawing.Point(7, 196);
            codigoBarraLabel.Name = "codigoBarraLabel";
            codigoBarraLabel.Size = new System.Drawing.Size(68, 13);
            codigoBarraLabel.TabIndex = 27;
            codigoBarraLabel.Text = "Código Barra";
            // 
            // codGrupoLabel
            // 
            codGrupoLabel.AutoSize = true;
            codGrupoLabel.Location = new System.Drawing.Point(150, 196);
            codGrupoLabel.Name = "codGrupoLabel";
            codGrupoLabel.Size = new System.Drawing.Size(39, 13);
            codGrupoLabel.TabIndex = 29;
            codGrupoLabel.Text = "Grupo:";
            // 
            // codigoFabricanteLabel
            // 
            codigoFabricanteLabel.AutoSize = true;
            codigoFabricanteLabel.Location = new System.Drawing.Point(147, 152);
            codigoFabricanteLabel.Name = "codigoFabricanteLabel";
            codigoFabricanteLabel.Size = new System.Drawing.Size(60, 13);
            codigoFabricanteLabel.TabIndex = 31;
            codigoFabricanteLabel.Text = "Fabricante:";
            // 
            // cfopLabel
            // 
            cfopLabel.AutoSize = true;
            cfopLabel.Location = new System.Drawing.Point(6, 112);
            cfopLabel.Name = "cfopLabel";
            cfopLabel.Size = new System.Drawing.Size(31, 13);
            cfopLabel.TabIndex = 35;
            cfopLabel.Text = "cfop:";
            // 
            // icmsLabel
            // 
            icmsLabel.AutoSize = true;
            icmsLabel.Location = new System.Drawing.Point(149, 241);
            icmsLabel.Name = "icmsLabel";
            icmsLabel.Size = new System.Drawing.Size(63, 13);
            icmsLabel.TabIndex = 37;
            icmsLabel.Text = "%Dif  ICMS:";
            // 
            // simplesLabel
            // 
            simplesLabel.AutoSize = true;
            simplesLabel.Location = new System.Drawing.Point(304, 241);
            simplesLabel.Name = "simplesLabel";
            simplesLabel.Size = new System.Drawing.Size(57, 13);
            simplesLabel.TabIndex = 39;
            simplesLabel.Text = "% Simples:";
            // 
            // ipiLabel
            // 
            ipiLabel.AutoSize = true;
            ipiLabel.Location = new System.Drawing.Point(370, 241);
            ipiLabel.Name = "ipiLabel";
            ipiLabel.Size = new System.Drawing.Size(34, 13);
            ipiLabel.TabIndex = 41;
            ipiLabel.Text = "% IPI:";
            // 
            // freteLabel
            // 
            freteLabel.AutoSize = true;
            freteLabel.Location = new System.Drawing.Point(426, 241);
            freteLabel.Name = "freteLabel";
            freteLabel.Size = new System.Drawing.Size(45, 13);
            freteLabel.TabIndex = 43;
            freteLabel.Text = "% Frete:";
            // 
            // custoVendaLabel
            // 
            custoVendaLabel.AutoSize = true;
            custoVendaLabel.Location = new System.Drawing.Point(9, 288);
            custoVendaLabel.Name = "custoVendaLabel";
            custoVendaLabel.Size = new System.Drawing.Size(109, 13);
            custoVendaLabel.TabIndex = 45;
            custoVendaLabel.Text = "Último Preço Compra:";
            // 
            // ultimaDataAtualizacaoLabel
            // 
            ultimaDataAtualizacaoLabel.AutoSize = true;
            ultimaDataAtualizacaoLabel.Location = new System.Drawing.Point(481, 240);
            ultimaDataAtualizacaoLabel.Name = "ultimaDataAtualizacaoLabel";
            ultimaDataAtualizacaoLabel.Size = new System.Drawing.Size(97, 13);
            ultimaDataAtualizacaoLabel.TabIndex = 53;
            ultimaDataAtualizacaoLabel.Text = "Última Atualizacao:";
            // 
            // nomeFabricanteLabel
            // 
            nomeFabricanteLabel.AutoSize = true;
            nomeFabricanteLabel.Location = new System.Drawing.Point(150, 113);
            nomeFabricanteLabel.Name = "nomeFabricanteLabel";
            nomeFabricanteLabel.Size = new System.Drawing.Size(178, 13);
            nomeFabricanteLabel.TabIndex = 57;
            nomeFabricanteLabel.Text = "Nome Produto conforme Fabricante:";
            // 
            // lucroPrecoVendaVarejoLabel
            // 
            lucroPrecoVendaVarejoLabel.AutoSize = true;
            lucroPrecoVendaVarejoLabel.Location = new System.Drawing.Point(150, 288);
            lucroPrecoVendaVarejoLabel.Name = "lucroPrecoVendaVarejoLabel";
            lucroPrecoVendaVarejoLabel.Size = new System.Drawing.Size(81, 13);
            lucroPrecoVendaVarejoLabel.TabIndex = 59;
            lucroPrecoVendaVarejoLabel.Text = "% Lucro Varejo:";
            // 
            // precoVendaVarejoLabel
            // 
            precoVendaVarejoLabel.AutoSize = true;
            precoVendaVarejoLabel.Location = new System.Drawing.Point(426, 288);
            precoVendaVarejoLabel.Name = "precoVendaVarejoLabel";
            precoVendaVarejoLabel.Size = new System.Drawing.Size(71, 13);
            precoVendaVarejoLabel.TabIndex = 61;
            precoVendaVarejoLabel.Text = "Preço Varejo:";
            // 
            // lucroPrecoVendaAtacadoLabel
            // 
            lucroPrecoVendaAtacadoLabel.AutoSize = true;
            lucroPrecoVendaAtacadoLabel.Location = new System.Drawing.Point(150, 331);
            lucroPrecoVendaAtacadoLabel.Name = "lucroPrecoVendaAtacadoLabel";
            lucroPrecoVendaAtacadoLabel.Size = new System.Drawing.Size(91, 13);
            lucroPrecoVendaAtacadoLabel.TabIndex = 63;
            lucroPrecoVendaAtacadoLabel.Text = "% Lucro Atacado:";
            // 
            // precoVendaAtacadoLabel
            // 
            precoVendaAtacadoLabel.AutoSize = true;
            precoVendaAtacadoLabel.Location = new System.Drawing.Point(426, 331);
            precoVendaAtacadoLabel.Name = "precoVendaAtacadoLabel";
            precoVendaAtacadoLabel.Size = new System.Drawing.Size(81, 13);
            precoVendaAtacadoLabel.TabIndex = 65;
            precoVendaAtacadoLabel.Text = "Preço Atacado:";
            // 
            // qtdProdutoAtacadoLabel
            // 
            qtdProdutoAtacadoLabel.AutoSize = true;
            qtdProdutoAtacadoLabel.Location = new System.Drawing.Point(7, 330);
            qtdProdutoAtacadoLabel.Name = "qtdProdutoAtacadoLabel";
            qtdProdutoAtacadoLabel.Size = new System.Drawing.Size(101, 13);
            qtdProdutoAtacadoLabel.TabIndex = 72;
            qtdProdutoAtacadoLabel.Text = "Qtd Preço Atacado:";
            // 
            // icms_substitutoLabel
            // 
            icms_substitutoLabel.AutoSize = true;
            icms_substitutoLabel.Location = new System.Drawing.Point(218, 241);
            icms_substitutoLabel.Name = "icms_substitutoLabel";
            icms_substitutoLabel.Size = new System.Drawing.Size(77, 13);
            icms_substitutoLabel.TabIndex = 76;
            icms_substitutoLabel.Text = "% ICMS Subst:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cadastro de Produtos";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 41);
            this.panel1.TabIndex = 20;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(310, 478);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(10, 478);
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
            this.btnCancelar.Location = new System.Drawing.Point(472, 478);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(85, 478);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "F3 - Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(235, 478);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "F5 - Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(160, 478);
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
            // tb_produtoBindingSource
            // 
            this.tb_produtoBindingSource.DataMember = "tb_produto";
            this.tb_produtoBindingSource.DataSource = this.saceDataSet;
            this.tb_produtoBindingSource.Sort = "codProduto";
            // 
            // tb_produtoTableAdapter
            // 
            this.tb_produtoTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.tb_pagamentoTableAdapter = null;
            this.tableAdapterManager.tb_bancoTableAdapter = null;
            this.tableAdapterManager.tb_cartao_creditoTableAdapter = null;
            this.tableAdapterManager.tb_cfopTableAdapter = this.tb_cfopTableAdapter;
            this.tableAdapterManager.tb_configuracao_sistemaTableAdapter = null;
            this.tableAdapterManager.tb_conta_bancoTableAdapter = null;
            this.tableAdapterManager.tb_contaTableAdapter = null;
            this.tableAdapterManager.tb_contato_empresaTableAdapter = null;
            this.tableAdapterManager.tb_entrada_produtoTableAdapter = null;
            this.tableAdapterManager.tb_entradaTableAdapter = null;
            this.tableAdapterManager.tb_forma_pagamentoTableAdapter = null;
            this.tableAdapterManager.tb_funcionalidadeTableAdapter = null;
            this.tableAdapterManager.tb_grupo_contaTableAdapter = null;
            this.tableAdapterManager.tb_grupoTableAdapter = this.tb_grupoTableAdapter;
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
            // tb_cfopTableAdapter
            // 
            this.tb_cfopTableAdapter.ClearBeforeFill = true;
            // 
            // tb_grupoTableAdapter
            // 
            this.tb_grupoTableAdapter.ClearBeforeFill = true;
            // 
            // tb_pessoaTableAdapter
            // 
            this.tb_pessoaTableAdapter.ClearBeforeFill = true;
            // 
            // tb_produtoBindingNavigator
            // 
            this.tb_produtoBindingNavigator.AddNewItem = null;
            this.tb_produtoBindingNavigator.BindingSource = this.tb_produtoBindingSource;
            this.tb_produtoBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tb_produtoBindingNavigator.DeleteItem = null;
            this.tb_produtoBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.tb_produtoBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.tb_produtoBindingNavigator.Location = new System.Drawing.Point(373, 41);
            this.tb_produtoBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tb_produtoBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tb_produtoBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tb_produtoBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tb_produtoBindingNavigator.Name = "tb_produtoBindingNavigator";
            this.tb_produtoBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tb_produtoBindingNavigator.Size = new System.Drawing.Size(209, 25);
            this.tb_produtoBindingNavigator.TabIndex = 21;
            this.tb_produtoBindingNavigator.Text = "bindingNavigator1";
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
            // codProdutoTextBox
            // 
            this.codProdutoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "codProduto", true));
            this.codProdutoTextBox.Enabled = false;
            this.codProdutoTextBox.Location = new System.Drawing.Point(7, 89);
            this.codProdutoTextBox.Name = "codProdutoTextBox";
            this.codProdutoTextBox.Size = new System.Drawing.Size(134, 20);
            this.codProdutoTextBox.TabIndex = 7;
            this.codProdutoTextBox.TextChanged += new System.EventHandler(this.codProdutoTextBox_TextChanged);
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "nome", true));
            this.nomeTextBox.Location = new System.Drawing.Point(150, 90);
            this.nomeTextBox.MaxLength = 40;
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.Size = new System.Drawing.Size(430, 20);
            this.nomeTextBox.TabIndex = 8;
            this.nomeTextBox.Leave += new System.EventHandler(this.nomeTextBox_Leave);
            // 
            // unidadeTextBox
            // 
            this.unidadeTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.unidadeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "unidade", true));
            this.unidadeTextBox.Location = new System.Drawing.Point(7, 172);
            this.unidadeTextBox.MaxLength = 3;
            this.unidadeTextBox.Name = "unidadeTextBox";
            this.unidadeTextBox.Size = new System.Drawing.Size(134, 20);
            this.unidadeTextBox.TabIndex = 12;
            // 
            // codigoBarraTextBox
            // 
            this.codigoBarraTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.codigoBarraTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "codigoBarra", true));
            this.codigoBarraTextBox.Location = new System.Drawing.Point(10, 213);
            this.codigoBarraTextBox.MaxLength = 40;
            this.codigoBarraTextBox.Name = "codigoBarraTextBox";
            this.codigoBarraTextBox.Size = new System.Drawing.Size(134, 20);
            this.codigoBarraTextBox.TabIndex = 16;
            // 
            // codGrupoComboBox
            // 
            this.codGrupoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codGrupoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codGrupoComboBox.CausesValidation = false;
            this.codGrupoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_produtoBindingSource, "codGrupo", true));
            this.codGrupoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "descricaoGrupo", true));
            this.codGrupoComboBox.DataSource = this.tbgrupoBindingSource;
            this.codGrupoComboBox.DisplayMember = "descricao";
            this.codGrupoComboBox.FormattingEnabled = true;
            this.codGrupoComboBox.Location = new System.Drawing.Point(150, 213);
            this.codGrupoComboBox.Name = "codGrupoComboBox";
            this.codGrupoComboBox.Size = new System.Drawing.Size(430, 21);
            this.codGrupoComboBox.TabIndex = 18;
            this.codGrupoComboBox.ValueMember = "codGrupo";
            this.codGrupoComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codigoFabricanteComboBox_KeyPress);
            // 
            // tbgrupoBindingSource
            // 
            this.tbgrupoBindingSource.DataMember = "tb_grupo";
            this.tbgrupoBindingSource.DataSource = this.saceDataSet;
            // 
            // codigoFabricanteComboBox
            // 
            this.codigoFabricanteComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codigoFabricanteComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codigoFabricanteComboBox.CausesValidation = false;
            this.codigoFabricanteComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "nomeDoFabricante", true));
            this.codigoFabricanteComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_produtoBindingSource, "codigoFabricante", true));
            this.codigoFabricanteComboBox.DataSource = this.tb_pessoaBindingSource;
            this.codigoFabricanteComboBox.DisplayMember = "nome";
            this.codigoFabricanteComboBox.FormattingEnabled = true;
            this.codigoFabricanteComboBox.Location = new System.Drawing.Point(150, 170);
            this.codigoFabricanteComboBox.Name = "codigoFabricanteComboBox";
            this.codigoFabricanteComboBox.Size = new System.Drawing.Size(430, 21);
            this.codigoFabricanteComboBox.TabIndex = 14;
            this.codigoFabricanteComboBox.ValueMember = "codPessoa";
            this.codigoFabricanteComboBox.Leave += new System.EventHandler(this.codigoFabricanteComboBox_Leave);
            this.codigoFabricanteComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codigoFabricanteComboBox_KeyPress);
            // 
            // tb_pessoaBindingSource
            // 
            this.tb_pessoaBindingSource.DataMember = "tb_pessoa";
            this.tb_pessoaBindingSource.DataSource = this.saceDataSet;
            // 
            // temVencimentoCheckBox
            // 
            this.temVencimentoCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.tb_produtoBindingSource, "temVencimento", true));
            this.temVencimentoCheckBox.Location = new System.Drawing.Point(12, 238);
            this.temVencimentoCheckBox.Name = "temVencimentoCheckBox";
            this.temVencimentoCheckBox.Size = new System.Drawing.Size(125, 24);
            this.temVencimentoCheckBox.TabIndex = 20;
            this.temVencimentoCheckBox.Text = "Possui Vencimento";
            this.temVencimentoCheckBox.UseVisualStyleBackColor = true;
            // 
            // icmsTextBox
            // 
            this.icmsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "icms", true));
            this.icmsTextBox.Location = new System.Drawing.Point(150, 258);
            this.icmsTextBox.Name = "icmsTextBox";
            this.icmsTextBox.Size = new System.Drawing.Size(62, 20);
            this.icmsTextBox.TabIndex = 24;
            this.icmsTextBox.Leave += new System.EventHandler(this.icmsTextBox_Leave);
            // 
            // simplesTextBox
            // 
            this.simplesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "simples", true));
            this.simplesTextBox.Location = new System.Drawing.Point(307, 257);
            this.simplesTextBox.Name = "simplesTextBox";
            this.simplesTextBox.Size = new System.Drawing.Size(52, 20);
            this.simplesTextBox.TabIndex = 28;
            this.simplesTextBox.Leave += new System.EventHandler(this.icmsTextBox_Leave);
            // 
            // ipiTextBox
            // 
            this.ipiTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "ipi", true));
            this.ipiTextBox.Location = new System.Drawing.Point(373, 257);
            this.ipiTextBox.Name = "ipiTextBox";
            this.ipiTextBox.Size = new System.Drawing.Size(43, 20);
            this.ipiTextBox.TabIndex = 30;
            this.ipiTextBox.Leave += new System.EventHandler(this.icmsTextBox_Leave);
            // 
            // freteTextBox
            // 
            this.freteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "frete", true));
            this.freteTextBox.Location = new System.Drawing.Point(429, 257);
            this.freteTextBox.Name = "freteTextBox";
            this.freteTextBox.Size = new System.Drawing.Size(42, 20);
            this.freteTextBox.TabIndex = 32;
            this.freteTextBox.Leave += new System.EventHandler(this.icmsTextBox_Leave);
            // 
            // ultimoPrecoCompraTextBox
            // 
            this.ultimoPrecoCompraTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "ultimoPrecoCompra", true));
            this.ultimoPrecoCompraTextBox.Location = new System.Drawing.Point(12, 305);
            this.ultimoPrecoCompraTextBox.Name = "ultimoPrecoCompraTextBox";
            this.ultimoPrecoCompraTextBox.Size = new System.Drawing.Size(132, 20);
            this.ultimoPrecoCompraTextBox.TabIndex = 36;
            this.ultimoPrecoCompraTextBox.Leave += new System.EventHandler(this.icmsTextBox_Leave);
            // 
            // ultimaDataAtualizacaoDateTimePicker
            // 
            this.ultimaDataAtualizacaoDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tb_produtoBindingSource, "ultimaDataAtualizacao", true));
            this.ultimaDataAtualizacaoDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "ultimaDataAtualizacao", true));
            this.ultimaDataAtualizacaoDateTimePicker.Enabled = false;
            this.ultimaDataAtualizacaoDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ultimaDataAtualizacaoDateTimePicker.Location = new System.Drawing.Point(484, 258);
            this.ultimaDataAtualizacaoDateTimePicker.Name = "ultimaDataAtualizacaoDateTimePicker";
            this.ultimaDataAtualizacaoDateTimePicker.Size = new System.Drawing.Size(94, 20);
            this.ultimaDataAtualizacaoDateTimePicker.TabIndex = 34;
            // 
            // exibeNaListagemCheckBox
            // 
            this.exibeNaListagemCheckBox.Checked = true;
            this.exibeNaListagemCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.exibeNaListagemCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.tb_produtoBindingSource, "exibeNaListagem", true));
            this.exibeNaListagemCheckBox.Location = new System.Drawing.Point(13, 258);
            this.exibeNaListagemCheckBox.Name = "exibeNaListagemCheckBox";
            this.exibeNaListagemCheckBox.Size = new System.Drawing.Size(103, 24);
            this.exibeNaListagemCheckBox.TabIndex = 22;
            this.exibeNaListagemCheckBox.Text = "Exibir Listagem";
            this.exibeNaListagemCheckBox.UseVisualStyleBackColor = true;
            // 
            // nomeFabricanteTextBox
            // 
            this.nomeFabricanteTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nomeFabricanteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "nomeFabricante", true));
            this.nomeFabricanteTextBox.Location = new System.Drawing.Point(150, 129);
            this.nomeFabricanteTextBox.MaxLength = 40;
            this.nomeFabricanteTextBox.Name = "nomeFabricanteTextBox";
            this.nomeFabricanteTextBox.Size = new System.Drawing.Size(430, 20);
            this.nomeFabricanteTextBox.TabIndex = 10;
            // 
            // lucroPrecoVendaVarejoTextBox
            // 
            this.lucroPrecoVendaVarejoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "lucroPrecoVendaVarejo", true));
            this.lucroPrecoVendaVarejoTextBox.Location = new System.Drawing.Point(152, 305);
            this.lucroPrecoVendaVarejoTextBox.Name = "lucroPrecoVendaVarejoTextBox";
            this.lucroPrecoVendaVarejoTextBox.Size = new System.Drawing.Size(111, 20);
            this.lucroPrecoVendaVarejoTextBox.TabIndex = 38;
            this.lucroPrecoVendaVarejoTextBox.Leave += new System.EventHandler(this.icmsTextBox_Leave);
            // 
            // precoVendaVarejoTextBox
            // 
            this.precoVendaVarejoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "precoVendaVarejo", true));
            this.precoVendaVarejoTextBox.Location = new System.Drawing.Point(429, 307);
            this.precoVendaVarejoTextBox.Name = "precoVendaVarejoTextBox";
            this.precoVendaVarejoTextBox.Size = new System.Drawing.Size(149, 20);
            this.precoVendaVarejoTextBox.TabIndex = 42;
            // 
            // lucroPrecoVendaAtacadoTextBox
            // 
            this.lucroPrecoVendaAtacadoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "lucroPrecoVendaAtacado", true));
            this.lucroPrecoVendaAtacadoTextBox.Location = new System.Drawing.Point(153, 348);
            this.lucroPrecoVendaAtacadoTextBox.Name = "lucroPrecoVendaAtacadoTextBox";
            this.lucroPrecoVendaAtacadoTextBox.Size = new System.Drawing.Size(110, 20);
            this.lucroPrecoVendaAtacadoTextBox.TabIndex = 46;
            this.lucroPrecoVendaAtacadoTextBox.Leave += new System.EventHandler(this.icmsTextBox_Leave);
            // 
            // precoVendaAtacadoTextBox
            // 
            this.precoVendaAtacadoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "precoVendaAtacado", true));
            this.precoVendaAtacadoTextBox.Location = new System.Drawing.Point(429, 348);
            this.precoVendaAtacadoTextBox.Name = "precoVendaAtacadoTextBox";
            this.precoVendaAtacadoTextBox.Size = new System.Drawing.Size(149, 20);
            this.precoVendaAtacadoTextBox.TabIndex = 50;
            // 
            // qtdProdutoAtacadoTextBox
            // 
            this.qtdProdutoAtacadoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "qtdProdutoAtacado", true));
            this.qtdProdutoAtacadoTextBox.Location = new System.Drawing.Point(12, 348);
            this.qtdProdutoAtacadoTextBox.MaxLength = 8;
            this.qtdProdutoAtacadoTextBox.Name = "qtdProdutoAtacadoTextBox";
            this.qtdProdutoAtacadoTextBox.Size = new System.Drawing.Size(132, 20);
            this.qtdProdutoAtacadoTextBox.TabIndex = 44;
            // 
            // tbcfopBindingSource
            // 
            this.tbcfopBindingSource.DataMember = "tb_cfop";
            this.tbcfopBindingSource.DataSource = this.saceDataSet;
            // 
            // cfopComboBox
            // 
            this.cfopComboBox.CausesValidation = false;
            this.cfopComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "cfop", true));
            this.cfopComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_produtoBindingSource, "cfop", true));
            this.cfopComboBox.DataSource = this.tbcfopBindingSource;
            this.cfopComboBox.DisplayMember = "descricao";
            this.cfopComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cfopComboBox.FormattingEnabled = true;
            this.cfopComboBox.Location = new System.Drawing.Point(7, 128);
            this.cfopComboBox.Name = "cfopComboBox";
            this.cfopComboBox.Size = new System.Drawing.Size(134, 21);
            this.cfopComboBox.TabIndex = 9;
            this.cfopComboBox.ValueMember = "cfop";
            // 
            // icms_substitutoTextBox
            // 
            this.icms_substitutoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "icms_substituto", true));
            this.icms_substitutoTextBox.Location = new System.Drawing.Point(221, 257);
            this.icms_substitutoTextBox.Name = "icms_substitutoTextBox";
            this.icms_substitutoTextBox.Size = new System.Drawing.Size(77, 20);
            this.icms_substitutoTextBox.TabIndex = 26;
            this.icms_substitutoTextBox.Leave += new System.EventHandler(this.icmsTextBox_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 78;
            this.label2.Text = "Preço Varejo Sugestão:";
            // 
            // precoVarejoSugestaoTextBox
            // 
            this.precoVarejoSugestaoTextBox.Location = new System.Drawing.Point(272, 307);
            this.precoVarejoSugestaoTextBox.Name = "precoVarejoSugestaoTextBox";
            this.precoVarejoSugestaoTextBox.ReadOnly = true;
            this.precoVarejoSugestaoTextBox.Size = new System.Drawing.Size(144, 20);
            this.precoVarejoSugestaoTextBox.TabIndex = 40;
            this.precoVarejoSugestaoTextBox.TabStop = false;
            // 
            // precoAtacadoSugestaoTextBox
            // 
            this.precoAtacadoSugestaoTextBox.Location = new System.Drawing.Point(272, 348);
            this.precoAtacadoSugestaoTextBox.Name = "precoAtacadoSugestaoTextBox";
            this.precoAtacadoSugestaoTextBox.ReadOnly = true;
            this.precoAtacadoSugestaoTextBox.Size = new System.Drawing.Size(144, 20);
            this.precoAtacadoSugestaoTextBox.TabIndex = 48;
            this.precoAtacadoSugestaoTextBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 331);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "Preço Atacado Sugestão:";
            // 
            // tb_produto_lojaBindingSource
            // 
            this.tb_produto_lojaBindingSource.DataMember = "tb_produto_loja";
            this.tb_produto_lojaBindingSource.DataSource = this.saceDataSet;
            // 
            // tb_produto_lojaDataGridView
            // 
            this.tb_produto_lojaDataGridView.AllowUserToAddRows = false;
            this.tb_produto_lojaDataGridView.AllowUserToDeleteRows = false;
            this.tb_produto_lojaDataGridView.AutoGenerateColumns = false;
            this.tb_produto_lojaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_produto_lojaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.nomeLoja,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            this.tb_produto_lojaDataGridView.DataSource = this.tb_produto_lojaBindingSource;
            this.tb_produto_lojaDataGridView.Location = new System.Drawing.Point(12, 374);
            this.tb_produto_lojaDataGridView.MultiSelect = false;
            this.tb_produto_lojaDataGridView.Name = "tb_produto_lojaDataGridView";
            this.tb_produto_lojaDataGridView.ReadOnly = true;
            this.tb_produto_lojaDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_produto_lojaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_produto_lojaDataGridView.Size = new System.Drawing.Size(566, 98);
            this.tb_produto_lojaDataGridView.TabIndex = 48;
            this.tb_produto_lojaDataGridView.TabStop = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "codLoja";
            this.dataGridViewTextBoxColumn1.HeaderText = "codLoja";
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
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // nomeLoja
            // 
            this.nomeLoja.DataPropertyName = "nomeLoja";
            this.nomeLoja.HeaderText = "Loja";
            this.nomeLoja.Name = "nomeLoja";
            this.nomeLoja.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "qtdEstoque";
            this.dataGridViewTextBoxColumn4.HeaderText = "Estoque";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "qtdEstoqueAux";
            this.dataGridViewTextBoxColumn5.HeaderText = "Estoque Aux";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "precoCusto";
            this.dataGridViewTextBoxColumn7.HeaderText = "Preço Custo";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "localizacao";
            this.dataGridViewTextBoxColumn8.HeaderText = "Localização";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // tb_produto_lojaTableAdapter
            // 
            this.tb_produto_lojaTableAdapter.ClearBeforeFill = true;
            // 
            // btnEstoque
            // 
            this.btnEstoque.Location = new System.Drawing.Point(391, 478);
            this.btnEstoque.Name = "btnEstoque";
            this.btnEstoque.Size = new System.Drawing.Size(81, 23);
            this.btnEstoque.TabIndex = 84;
            this.btnEstoque.Text = "F7 - Estoque";
            this.btnEstoque.UseVisualStyleBackColor = true;
            this.btnEstoque.Click += new System.EventHandler(this.btnEstoque_Click);
            // 
            // FrmProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 503);
            this.Controls.Add(this.btnEstoque);
            this.Controls.Add(this.tb_produto_lojaDataGridView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.precoAtacadoSugestaoTextBox);
            this.Controls.Add(this.precoVarejoSugestaoTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(icms_substitutoLabel);
            this.Controls.Add(this.icms_substitutoTextBox);
            this.Controls.Add(this.cfopComboBox);
            this.Controls.Add(qtdProdutoAtacadoLabel);
            this.Controls.Add(this.qtdProdutoAtacadoTextBox);
            this.Controls.Add(codProdutoLabel);
            this.Controls.Add(this.tb_produtoBindingNavigator);
            this.Controls.Add(this.codProdutoTextBox);
            this.Controls.Add(nomeLabel);
            this.Controls.Add(this.nomeTextBox);
            this.Controls.Add(unidadeLabel);
            this.Controls.Add(this.unidadeTextBox);
            this.Controls.Add(codigoBarraLabel);
            this.Controls.Add(this.codigoBarraTextBox);
            this.Controls.Add(codGrupoLabel);
            this.Controls.Add(this.codGrupoComboBox);
            this.Controls.Add(codigoFabricanteLabel);
            this.Controls.Add(this.codigoFabricanteComboBox);
            this.Controls.Add(this.temVencimentoCheckBox);
            this.Controls.Add(cfopLabel);
            this.Controls.Add(icmsLabel);
            this.Controls.Add(this.icmsTextBox);
            this.Controls.Add(simplesLabel);
            this.Controls.Add(this.simplesTextBox);
            this.Controls.Add(ipiLabel);
            this.Controls.Add(this.ipiTextBox);
            this.Controls.Add(freteLabel);
            this.Controls.Add(this.freteTextBox);
            this.Controls.Add(custoVendaLabel);
            this.Controls.Add(this.ultimoPrecoCompraTextBox);
            this.Controls.Add(ultimaDataAtualizacaoLabel);
            this.Controls.Add(this.ultimaDataAtualizacaoDateTimePicker);
            this.Controls.Add(this.exibeNaListagemCheckBox);
            this.Controls.Add(nomeFabricanteLabel);
            this.Controls.Add(this.nomeFabricanteTextBox);
            this.Controls.Add(lucroPrecoVendaVarejoLabel);
            this.Controls.Add(this.lucroPrecoVendaVarejoTextBox);
            this.Controls.Add(precoVendaVarejoLabel);
            this.Controls.Add(this.precoVendaVarejoTextBox);
            this.Controls.Add(lucroPrecoVendaAtacadoLabel);
            this.Controls.Add(this.lucroPrecoVendaAtacadoTextBox);
            this.Controls.Add(precoVendaAtacadoLabel);
            this.Controls.Add(this.precoVendaAtacadoTextBox);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmProduto";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de Produtos";
            this.Load += new System.EventHandler(this.FrmProduto_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmProduto_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmProduto_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoBindingNavigator)).EndInit();
            this.tb_produtoBindingNavigator.ResumeLayout(false);
            this.tb_produtoBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbgrupoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_pessoaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcfopBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produto_lojaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produto_lojaDataGridView)).EndInit();
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
        private System.Windows.Forms.BindingSource tb_produtoBindingSource;
        private Dados.saceDataSetTableAdapters.tb_produtoTableAdapter tb_produtoTableAdapter;
        private Dados.saceDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator tb_produtoBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.TextBox codProdutoTextBox;
        private System.Windows.Forms.TextBox nomeTextBox;
        private System.Windows.Forms.TextBox unidadeTextBox;
        private System.Windows.Forms.TextBox codigoBarraTextBox;
        private System.Windows.Forms.ComboBox codGrupoComboBox;
        private System.Windows.Forms.ComboBox codigoFabricanteComboBox;
        private System.Windows.Forms.CheckBox temVencimentoCheckBox;
        private System.Windows.Forms.TextBox icmsTextBox;
        private System.Windows.Forms.TextBox simplesTextBox;
        private System.Windows.Forms.TextBox ipiTextBox;
        private System.Windows.Forms.TextBox freteTextBox;
        private System.Windows.Forms.TextBox ultimoPrecoCompraTextBox;
        private System.Windows.Forms.DateTimePicker ultimaDataAtualizacaoDateTimePicker;
        private System.Windows.Forms.CheckBox exibeNaListagemCheckBox;
        private System.Windows.Forms.TextBox nomeFabricanteTextBox;
        private System.Windows.Forms.TextBox lucroPrecoVendaVarejoTextBox;
        private System.Windows.Forms.TextBox precoVendaVarejoTextBox;
        private System.Windows.Forms.TextBox lucroPrecoVendaAtacadoTextBox;
        private System.Windows.Forms.TextBox precoVendaAtacadoTextBox;
        private System.Windows.Forms.BindingSource tb_pessoaBindingSource;
        private Dados.saceDataSetTableAdapters.tb_grupoTableAdapter tb_grupoTableAdapter;
        private System.Windows.Forms.BindingSource tbgrupoBindingSource;
        private System.Windows.Forms.TextBox qtdProdutoAtacadoTextBox;
        private Dados.saceDataSetTableAdapters.tb_cfopTableAdapter tb_cfopTableAdapter;
        private System.Windows.Forms.BindingSource tbcfopBindingSource;
        private System.Windows.Forms.ComboBox cfopComboBox;
        private System.Windows.Forms.TextBox icms_substitutoTextBox;
        private Dados.saceDataSetTableAdapters.tb_pessoaTableAdapter tb_pessoaTableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox precoVarejoSugestaoTextBox;
        private System.Windows.Forms.TextBox precoAtacadoSugestaoTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource tb_produto_lojaBindingSource;
        private System.Windows.Forms.DataGridView tb_produto_lojaDataGridView;
        private Dados.saceDataSetTableAdapters.tb_produto_lojaTableAdapter tb_produto_lojaTableAdapter;
        private System.Windows.Forms.Button btnEstoque;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeLoja;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
    }
}