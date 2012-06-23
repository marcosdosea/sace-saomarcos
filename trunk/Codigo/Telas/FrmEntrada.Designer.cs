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
            System.Windows.Forms.Label numeroNotaFiscalLabel;
            System.Windows.Forms.Label codEmpresaFreteLabel;
            System.Windows.Forms.Label codFornecedorLabel;
            System.Windows.Forms.Label dataEmissaoLabel;
            System.Windows.Forms.Label dataEntradaLabel;
            System.Windows.Forms.Label totalBaseCalculoLabel;
            System.Windows.Forms.Label totalICMSLabel;
            System.Windows.Forms.Label totalBaseSubstituicaoLabel;
            System.Windows.Forms.Label totalSubstituicaoLabel;
            System.Windows.Forms.Label totalProdutosLabel;
            System.Windows.Forms.Label valorFreteLabel;
            System.Windows.Forms.Label valorSeguroLabel;
            System.Windows.Forms.Label descontoLabel;
            System.Windows.Forms.Label outrasDespesasLabel;
            System.Windows.Forms.Label totalIPILabel;
            System.Windows.Forms.Label totalNotaLabel;
            System.Windows.Forms.Label codProdutoLabel;
            System.Windows.Forms.Label cfopLabel;
            System.Windows.Forms.Label unidadeCompraLabel;
            System.Windows.Forms.Label quantidadeLabel;
            System.Windows.Forms.Label valorUnitarioLabel;
            System.Windows.Forms.Label valorTotalLabel;
            System.Windows.Forms.Label quantidadeEmbalagemLabel;
            System.Windows.Forms.Label baseCalculoICMSLabel;
            System.Windows.Forms.Label baseCalculoICMSSTLabel;
            System.Windows.Forms.Label valorICMSLabel;
            System.Windows.Forms.Label valorICMSSTLabel;
            System.Windows.Forms.Label valorIPILabel;
            System.Windows.Forms.Label data_validadeLabel;
            System.Windows.Forms.Label ncmshLabel;
            System.Windows.Forms.Label codCSTLabel;
            System.Windows.Forms.Label icmsLabel;
            System.Windows.Forms.Label icms_substitutoLabel;
            System.Windows.Forms.Label ipiLabel;
            System.Windows.Forms.Label freteLabel;
            System.Windows.Forms.Label simplesLabel;
            System.Windows.Forms.Label lucroPrecoVendaAtacadoLabel;
            System.Windows.Forms.Label lucroPrecoVendaVarejoLabel;
            System.Windows.Forms.Label precoVendaVarejoLabel;
            System.Windows.Forms.Label qtdProdutoAtacadoLabel;
            System.Windows.Forms.Label precoVendaAtacadoLabel;
            System.Windows.Forms.Label preco_custoLabel;
            System.Windows.Forms.Label descricaoSituacaoPagamentosLabel;
            System.Windows.Forms.Label valorDescontoLabel;
            System.Windows.Forms.Label totalProdutosSTLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEntrada));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnProdutos = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPagamentos = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.totalNotaCalculadoTextBox = new System.Windows.Forms.TextBox();
            this.ProdutosGroupBox = new System.Windows.Forms.GroupBox();
            this.descontoProdutoTextBox = new System.Windows.Forms.TextBox();
            this.tb_entrada_produtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saceDataSet = new Dados.saceDataSet();
            this.codCSTComboBox = new System.Windows.Forms.ComboBox();
            this.tb_produtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbcstBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cfopComboBox = new System.Windows.Forms.ComboBox();
            this.tbcfopBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.preco_custoTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.precoVendaAtacadoTextBox = new System.Windows.Forms.TextBox();
            this.precoAtacadoSugestaoTextBox = new System.Windows.Forms.TextBox();
            this.qtdProdutoAtacadoTextBox = new System.Windows.Forms.TextBox();
            this.precoVarejoSugestaoTextBox = new System.Windows.Forms.TextBox();
            this.precoVendaVarejoTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lucroPrecoVendaVarejoTextBox = new System.Windows.Forms.TextBox();
            this.lucroPrecoVendaAtacadoTextBox = new System.Windows.Forms.TextBox();
            this.simplesTextBox = new System.Windows.Forms.TextBox();
            this.freteTextBox = new System.Windows.Forms.TextBox();
            this.ipiTextBox = new System.Windows.Forms.TextBox();
            this.icms_substitutoTextBox = new System.Windows.Forms.TextBox();
            this.icmsTextBox = new System.Windows.Forms.TextBox();
            this.ncmshTextBox = new System.Windows.Forms.TextBox();
            this.data_validadeDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.valorIPITextBox = new System.Windows.Forms.TextBox();
            this.valorICMSSTTextBox = new System.Windows.Forms.TextBox();
            this.valorICMSTextBox = new System.Windows.Forms.TextBox();
            this.baseCalculoICMSSTTextBox = new System.Windows.Forms.TextBox();
            this.baseCalculoICMSTextBox = new System.Windows.Forms.TextBox();
            this.quantidadeEmbalagemTextBox = new System.Windows.Forms.TextBox();
            this.valorTotalTextBox = new System.Windows.Forms.TextBox();
            this.valorUnitarioTextBox = new System.Windows.Forms.TextBox();
            this.quantidadeTextBox = new System.Windows.Forms.TextBox();
            this.unidadeCompraTextBox = new System.Windows.Forms.TextBox();
            this.codProdutoComboBox = new System.Windows.Forms.ComboBox();
            this.temVencimentoCheckBox = new System.Windows.Forms.CheckBox();
            this.tb_entradaBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.numeroNotaFiscalTextBox = new System.Windows.Forms.TextBox();
            this.codEmpresaFreteComboBox = new System.Windows.Forms.ComboBox();
            this.tbpessoaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tbpessoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codFornecedorComboBox = new System.Windows.Forms.ComboBox();
            this.dataEmissaoDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dataEntradaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.totalBaseCalculoTextBox = new System.Windows.Forms.TextBox();
            this.totalICMSTextBox = new System.Windows.Forms.TextBox();
            this.totalBaseSubstituicaoTextBox = new System.Windows.Forms.TextBox();
            this.totalSubstituicaoTextBox = new System.Windows.Forms.TextBox();
            this.totalProdutosTextBox = new System.Windows.Forms.TextBox();
            this.valorFreteTextBox = new System.Windows.Forms.TextBox();
            this.valorSeguroTextBox = new System.Windows.Forms.TextBox();
            this.descontoTextBox = new System.Windows.Forms.TextBox();
            this.outrasDespesasTextBox = new System.Windows.Forms.TextBox();
            this.totalIPITextBox = new System.Windows.Forms.TextBox();
            this.totalNotaTextBox = new System.Windows.Forms.TextBox();
            this.tb_entrada_produtoDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tb_produtoTableAdapter = new Dados.saceDataSetTableAdapters.tb_produtoTableAdapter();
            this.tb_entrada_produtoTableAdapter = new Dados.saceDataSetTableAdapters.tb_entrada_produtoTableAdapter();
            this.tb_pessoaTableAdapter = new Dados.saceDataSetTableAdapters.tb_pessoaTableAdapter();
            this.tb_entradaTableAdapter = new Dados.saceDataSetTableAdapters.tb_entradaTableAdapter();
            this.tb_cfopTableAdapter = new Dados.saceDataSetTableAdapters.tb_cfopTableAdapter();
            this.fretePagoEmitenteCheckBox = new System.Windows.Forms.CheckBox();
            this.codSituacaoPagamentosComboBox = new System.Windows.Forms.ComboBox();
            this.tbsituacaopagamentosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_situacao_pagamentosTableAdapter = new Dados.saceDataSetTableAdapters.tb_situacao_pagamentosTableAdapter();
            this.tb_cstTableAdapter = new Dados.saceDataSetTableAdapters.tb_cstTableAdapter();
            this.totalProdutosSTTextBox = new System.Windows.Forms.TextBox();
            codEntradaLabel = new System.Windows.Forms.Label();
            numeroNotaFiscalLabel = new System.Windows.Forms.Label();
            codEmpresaFreteLabel = new System.Windows.Forms.Label();
            codFornecedorLabel = new System.Windows.Forms.Label();
            dataEmissaoLabel = new System.Windows.Forms.Label();
            dataEntradaLabel = new System.Windows.Forms.Label();
            totalBaseCalculoLabel = new System.Windows.Forms.Label();
            totalICMSLabel = new System.Windows.Forms.Label();
            totalBaseSubstituicaoLabel = new System.Windows.Forms.Label();
            totalSubstituicaoLabel = new System.Windows.Forms.Label();
            totalProdutosLabel = new System.Windows.Forms.Label();
            valorFreteLabel = new System.Windows.Forms.Label();
            valorSeguroLabel = new System.Windows.Forms.Label();
            descontoLabel = new System.Windows.Forms.Label();
            outrasDespesasLabel = new System.Windows.Forms.Label();
            totalIPILabel = new System.Windows.Forms.Label();
            totalNotaLabel = new System.Windows.Forms.Label();
            codProdutoLabel = new System.Windows.Forms.Label();
            cfopLabel = new System.Windows.Forms.Label();
            unidadeCompraLabel = new System.Windows.Forms.Label();
            quantidadeLabel = new System.Windows.Forms.Label();
            valorUnitarioLabel = new System.Windows.Forms.Label();
            valorTotalLabel = new System.Windows.Forms.Label();
            quantidadeEmbalagemLabel = new System.Windows.Forms.Label();
            baseCalculoICMSLabel = new System.Windows.Forms.Label();
            baseCalculoICMSSTLabel = new System.Windows.Forms.Label();
            valorICMSLabel = new System.Windows.Forms.Label();
            valorICMSSTLabel = new System.Windows.Forms.Label();
            valorIPILabel = new System.Windows.Forms.Label();
            data_validadeLabel = new System.Windows.Forms.Label();
            ncmshLabel = new System.Windows.Forms.Label();
            codCSTLabel = new System.Windows.Forms.Label();
            icmsLabel = new System.Windows.Forms.Label();
            icms_substitutoLabel = new System.Windows.Forms.Label();
            ipiLabel = new System.Windows.Forms.Label();
            freteLabel = new System.Windows.Forms.Label();
            simplesLabel = new System.Windows.Forms.Label();
            lucroPrecoVendaAtacadoLabel = new System.Windows.Forms.Label();
            lucroPrecoVendaVarejoLabel = new System.Windows.Forms.Label();
            precoVendaVarejoLabel = new System.Windows.Forms.Label();
            qtdProdutoAtacadoLabel = new System.Windows.Forms.Label();
            precoVendaAtacadoLabel = new System.Windows.Forms.Label();
            preco_custoLabel = new System.Windows.Forms.Label();
            descricaoSituacaoPagamentosLabel = new System.Windows.Forms.Label();
            valorDescontoLabel = new System.Windows.Forms.Label();
            totalProdutosSTLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.ProdutosGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entrada_produtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcstBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcfopBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entradaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entradaBindingNavigator)).BeginInit();
            this.tb_entradaBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbpessoaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbpessoaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entrada_produtoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbsituacaopagamentosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // codEntradaLabel
            // 
            codEntradaLabel.AutoSize = true;
            codEntradaLabel.Location = new System.Drawing.Point(2, 67);
            codEntradaLabel.Name = "codEntradaLabel";
            codEntradaLabel.Size = new System.Drawing.Size(43, 13);
            codEntradaLabel.TabIndex = 77;
            codEntradaLabel.Text = "Código:";
            // 
            // numeroNotaFiscalLabel
            // 
            numeroNotaFiscalLabel.AutoSize = true;
            numeroNotaFiscalLabel.Location = new System.Drawing.Point(88, 67);
            numeroNotaFiscalLabel.Name = "numeroNotaFiscalLabel";
            numeroNotaFiscalLabel.Size = new System.Drawing.Size(103, 13);
            numeroNotaFiscalLabel.TabIndex = 79;
            numeroNotaFiscalLabel.Text = "Número Nota Fiscal:";
            // 
            // codEmpresaFreteLabel
            // 
            codEmpresaFreteLabel.AutoSize = true;
            codEmpresaFreteLabel.Location = new System.Drawing.Point(6, 108);
            codEmpresaFreteLabel.Name = "codEmpresaFreteLabel";
            codEmpresaFreteLabel.Size = new System.Drawing.Size(82, 13);
            codEmpresaFreteLabel.TabIndex = 81;
            codEmpresaFreteLabel.Text = "Transportadora:";
            // 
            // codFornecedorLabel
            // 
            codFornecedorLabel.AutoSize = true;
            codFornecedorLabel.Location = new System.Drawing.Point(196, 67);
            codFornecedorLabel.Name = "codFornecedorLabel";
            codFornecedorLabel.Size = new System.Drawing.Size(64, 13);
            codFornecedorLabel.TabIndex = 83;
            codFornecedorLabel.Text = "Fornecedor:";
            // 
            // dataEmissaoLabel
            // 
            dataEmissaoLabel.AutoSize = true;
            dataEmissaoLabel.Location = new System.Drawing.Point(607, 68);
            dataEmissaoLabel.Name = "dataEmissaoLabel";
            dataEmissaoLabel.Size = new System.Drawing.Size(75, 13);
            dataEmissaoLabel.TabIndex = 87;
            dataEmissaoLabel.Text = "Data Emissao:";
            // 
            // dataEntradaLabel
            // 
            dataEntradaLabel.AutoSize = true;
            dataEntradaLabel.Location = new System.Drawing.Point(717, 68);
            dataEntradaLabel.Name = "dataEntradaLabel";
            dataEntradaLabel.Size = new System.Drawing.Size(73, 13);
            dataEntradaLabel.TabIndex = 89;
            dataEntradaLabel.Text = "Data Entrada:";
            // 
            // totalBaseCalculoLabel
            // 
            totalBaseCalculoLabel.AutoSize = true;
            totalBaseCalculoLabel.Location = new System.Drawing.Point(379, 109);
            totalBaseCalculoLabel.Name = "totalBaseCalculoLabel";
            totalBaseCalculoLabel.Size = new System.Drawing.Size(101, 13);
            totalBaseCalculoLabel.TabIndex = 91;
            totalBaseCalculoLabel.Text = "Base Cálculo ICMS:";
            // 
            // totalICMSLabel
            // 
            totalICMSLabel.AutoSize = true;
            totalICMSLabel.Location = new System.Drawing.Point(493, 109);
            totalICMSLabel.Name = "totalICMSLabel";
            totalICMSLabel.Size = new System.Drawing.Size(63, 13);
            totalICMSLabel.TabIndex = 93;
            totalICMSLabel.Text = "Valor ICMS:";
            // 
            // totalBaseSubstituicaoLabel
            // 
            totalBaseSubstituicaoLabel.AutoSize = true;
            totalBaseSubstituicaoLabel.Location = new System.Drawing.Point(607, 107);
            totalBaseSubstituicaoLabel.Name = "totalBaseSubstituicaoLabel";
            totalBaseSubstituicaoLabel.Size = new System.Drawing.Size(102, 13);
            totalBaseSubstituicaoLabel.TabIndex = 95;
            totalBaseSubstituicaoLabel.Text = "Base Cálculo Subst:";
            // 
            // totalSubstituicaoLabel
            // 
            totalSubstituicaoLabel.AutoSize = true;
            totalSubstituicaoLabel.Location = new System.Drawing.Point(717, 109);
            totalSubstituicaoLabel.Name = "totalSubstituicaoLabel";
            totalSubstituicaoLabel.Size = new System.Drawing.Size(80, 13);
            totalSubstituicaoLabel.TabIndex = 97;
            totalSubstituicaoLabel.Text = "Valor ICMS ST:";
            // 
            // totalProdutosLabel
            // 
            totalProdutosLabel.AutoSize = true;
            totalProdutosLabel.Location = new System.Drawing.Point(607, 149);
            totalProdutosLabel.Name = "totalProdutosLabel";
            totalProdutosLabel.Size = new System.Drawing.Size(106, 13);
            totalProdutosLabel.TabIndex = 99;
            totalProdutosLabel.Text = "Valor Total Produtos:";
            // 
            // valorFreteLabel
            // 
            valorFreteLabel.AutoSize = true;
            valorFreteLabel.Location = new System.Drawing.Point(7, 150);
            valorFreteLabel.Name = "valorFreteLabel";
            valorFreteLabel.Size = new System.Drawing.Size(76, 13);
            valorFreteLabel.TabIndex = 101;
            valorFreteLabel.Text = "Valor do Frete:";
            // 
            // valorSeguroLabel
            // 
            valorSeguroLabel.AutoSize = true;
            valorSeguroLabel.Location = new System.Drawing.Point(118, 150);
            valorSeguroLabel.Name = "valorSeguroLabel";
            valorSeguroLabel.Size = new System.Drawing.Size(86, 13);
            valorSeguroLabel.TabIndex = 103;
            valorSeguroLabel.Text = "Valor do Seguro:";
            // 
            // descontoLabel
            // 
            descontoLabel.AutoSize = true;
            descontoLabel.Location = new System.Drawing.Point(228, 151);
            descontoLabel.Name = "descontoLabel";
            descontoLabel.Size = new System.Drawing.Size(56, 13);
            descontoLabel.TabIndex = 105;
            descontoLabel.Text = "Desconto:";
            // 
            // outrasDespesasLabel
            // 
            outrasDespesasLabel.AutoSize = true;
            outrasDespesasLabel.Location = new System.Drawing.Point(314, 151);
            outrasDespesasLabel.Name = "outrasDespesasLabel";
            outrasDespesasLabel.Size = new System.Drawing.Size(91, 13);
            outrasDespesasLabel.TabIndex = 107;
            outrasDespesasLabel.Text = "Outras Despesas:";
            // 
            // totalIPILabel
            // 
            totalIPILabel.AutoSize = true;
            totalIPILabel.Location = new System.Drawing.Point(411, 149);
            totalIPILabel.Name = "totalIPILabel";
            totalIPILabel.Size = new System.Drawing.Size(77, 13);
            totalIPILabel.TabIndex = 109;
            totalIPILabel.Text = "Valor Total IPI:";
            // 
            // totalNotaLabel
            // 
            totalNotaLabel.AutoSize = true;
            totalNotaLabel.Location = new System.Drawing.Point(717, 151);
            totalNotaLabel.Name = "totalNotaLabel";
            totalNotaLabel.Size = new System.Drawing.Size(87, 13);
            totalNotaLabel.TabIndex = 111;
            totalNotaLabel.Text = "Valor Total Nota:";
            // 
            // codProdutoLabel
            // 
            codProdutoLabel.AutoSize = true;
            codProdutoLabel.Location = new System.Drawing.Point(6, 16);
            codProdutoLabel.Name = "codProdutoLabel";
            codProdutoLabel.Size = new System.Drawing.Size(47, 13);
            codProdutoLabel.TabIndex = 0;
            codProdutoLabel.Text = "Produto:";
            // 
            // cfopLabel
            // 
            cfopLabel.AutoSize = true;
            cfopLabel.Location = new System.Drawing.Point(497, 16);
            cfopLabel.Name = "cfopLabel";
            cfopLabel.Size = new System.Drawing.Size(38, 13);
            cfopLabel.TabIndex = 2;
            cfopLabel.Text = "CFOP:";
            // 
            // unidadeCompraLabel
            // 
            unidadeCompraLabel.AutoSize = true;
            unidadeCompraLabel.Location = new System.Drawing.Point(555, 16);
            unidadeCompraLabel.Name = "unidadeCompraLabel";
            unidadeCompraLabel.Size = new System.Drawing.Size(26, 13);
            unidadeCompraLabel.TabIndex = 4;
            unidadeCompraLabel.Text = "UN:";
            // 
            // quantidadeLabel
            // 
            quantidadeLabel.AutoSize = true;
            quantidadeLabel.Location = new System.Drawing.Point(594, 16);
            quantidadeLabel.Name = "quantidadeLabel";
            quantidadeLabel.Size = new System.Drawing.Size(48, 13);
            quantidadeLabel.TabIndex = 6;
            quantidadeLabel.Text = "QUANT:";
            // 
            // valorUnitarioLabel
            // 
            valorUnitarioLabel.AutoSize = true;
            valorUnitarioLabel.Location = new System.Drawing.Point(653, 15);
            valorUnitarioLabel.Name = "valorUnitarioLabel";
            valorUnitarioLabel.Size = new System.Drawing.Size(51, 13);
            valorUnitarioLabel.TabIndex = 8;
            valorUnitarioLabel.Text = "Valor Un:";
            // 
            // valorTotalLabel
            // 
            valorTotalLabel.AutoSize = true;
            valorTotalLabel.Location = new System.Drawing.Point(723, 16);
            valorTotalLabel.Name = "valorTotalLabel";
            valorTotalLabel.Size = new System.Drawing.Size(61, 13);
            valorTotalLabel.TabIndex = 10;
            valorTotalLabel.Text = "Valor Total:";
            // 
            // quantidadeEmbalagemLabel
            // 
            quantidadeEmbalagemLabel.AutoSize = true;
            quantidadeEmbalagemLabel.Location = new System.Drawing.Point(112, 110);
            quantidadeEmbalagemLabel.Name = "quantidadeEmbalagemLabel";
            quantidadeEmbalagemLabel.Size = new System.Drawing.Size(85, 13);
            quantidadeEmbalagemLabel.TabIndex = 12;
            quantidadeEmbalagemLabel.Text = "Qtd Embalagem:";
            // 
            // baseCalculoICMSLabel
            // 
            baseCalculoICMSLabel.AutoSize = true;
            baseCalculoICMSLabel.Location = new System.Drawing.Point(6, 66);
            baseCalculoICMSLabel.Name = "baseCalculoICMSLabel";
            baseCalculoICMSLabel.Size = new System.Drawing.Size(53, 13);
            baseCalculoICMSLabel.TabIndex = 14;
            baseCalculoICMSLabel.Text = "BC ICMS:";
            // 
            // baseCalculoICMSSTLabel
            // 
            baseCalculoICMSSTLabel.AutoSize = true;
            baseCalculoICMSSTLabel.Location = new System.Drawing.Point(245, 66);
            baseCalculoICMSSTLabel.Name = "baseCalculoICMSSTLabel";
            baseCalculoICMSSTLabel.Size = new System.Drawing.Size(70, 13);
            baseCalculoICMSSTLabel.TabIndex = 16;
            baseCalculoICMSSTLabel.Text = "BC ICMS ST:";
            // 
            // valorICMSLabel
            // 
            valorICMSLabel.AutoSize = true;
            valorICMSLabel.Location = new System.Drawing.Point(157, 66);
            valorICMSLabel.Name = "valorICMSLabel";
            valorICMSLabel.Size = new System.Drawing.Size(63, 13);
            valorICMSLabel.TabIndex = 18;
            valorICMSLabel.Text = "Valor ICMS:";
            // 
            // valorICMSSTLabel
            // 
            valorICMSSTLabel.AutoSize = true;
            valorICMSSTLabel.Location = new System.Drawing.Point(393, 66);
            valorICMSSTLabel.Name = "valorICMSSTLabel";
            valorICMSSTLabel.Size = new System.Drawing.Size(80, 13);
            valorICMSSTLabel.TabIndex = 20;
            valorICMSSTLabel.Text = "Valor ICMS ST:";
            // 
            // valorIPILabel
            // 
            valorIPILabel.AutoSize = true;
            valorIPILabel.Location = new System.Drawing.Point(527, 65);
            valorIPILabel.Name = "valorIPILabel";
            valorIPILabel.Size = new System.Drawing.Size(50, 13);
            valorIPILabel.TabIndex = 22;
            valorIPILabel.Text = "Valor IPI:";
            // 
            // data_validadeLabel
            // 
            data_validadeLabel.AutoSize = true;
            data_validadeLabel.Location = new System.Drawing.Point(6, 110);
            data_validadeLabel.Name = "data_validadeLabel";
            data_validadeLabel.Size = new System.Drawing.Size(77, 13);
            data_validadeLabel.TabIndex = 24;
            data_validadeLabel.Text = "Data Validade:";
            // 
            // ncmshLabel
            // 
            ncmshLabel.AutoSize = true;
            ncmshLabel.Location = new System.Drawing.Point(375, 16);
            ncmshLabel.Name = "ncmshLabel";
            ncmshLabel.Size = new System.Drawing.Size(54, 13);
            ncmshLabel.TabIndex = 26;
            ncmshLabel.Text = "NCM/SH:";
            // 
            // codCSTLabel
            // 
            codCSTLabel.AutoSize = true;
            codCSTLabel.Location = new System.Drawing.Point(443, 16);
            codCSTLabel.Name = "codCSTLabel";
            codCSTLabel.Size = new System.Drawing.Size(31, 13);
            codCSTLabel.TabIndex = 28;
            codCSTLabel.Text = "CST:";
            // 
            // icmsLabel
            // 
            icmsLabel.AutoSize = true;
            icmsLabel.Location = new System.Drawing.Point(89, 66);
            icmsLabel.Name = "icmsLabel";
            icmsLabel.Size = new System.Drawing.Size(72, 13);
            icmsLabel.TabIndex = 30;
            icmsLabel.Text = "% Cred ICMS:";
            // 
            // icms_substitutoLabel
            // 
            icms_substitutoLabel.AutoSize = true;
            icms_substitutoLabel.Location = new System.Drawing.Point(326, 66);
            icms_substitutoLabel.Name = "icms_substitutoLabel";
            icms_substitutoLabel.Size = new System.Drawing.Size(64, 13);
            icms_substitutoLabel.TabIndex = 32;
            icms_substitutoLabel.Text = "% ICMS ST:";
            // 
            // ipiLabel
            // 
            ipiLabel.AutoSize = true;
            ipiLabel.Location = new System.Drawing.Point(476, 66);
            ipiLabel.Name = "ipiLabel";
            ipiLabel.Size = new System.Drawing.Size(31, 13);
            ipiLabel.TabIndex = 34;
            ipiLabel.Text = "%IPI:";
            // 
            // freteLabel
            // 
            freteLabel.AutoSize = true;
            freteLabel.Location = new System.Drawing.Point(629, 64);
            freteLabel.Name = "freteLabel";
            freteLabel.Size = new System.Drawing.Size(45, 13);
            freteLabel.TabIndex = 36;
            freteLabel.Text = "% Frete:";
            // 
            // simplesLabel
            // 
            simplesLabel.AutoSize = true;
            simplesLabel.Location = new System.Drawing.Point(671, 64);
            simplesLabel.Name = "simplesLabel";
            simplesLabel.Size = new System.Drawing.Size(57, 13);
            simplesLabel.TabIndex = 38;
            simplesLabel.Text = "% Simples:";
            // 
            // lucroPrecoVendaAtacadoLabel
            // 
            lucroPrecoVendaAtacadoLabel.AutoSize = true;
            lucroPrecoVendaAtacadoLabel.Location = new System.Drawing.Point(534, 110);
            lucroPrecoVendaAtacadoLabel.Name = "lucroPrecoVendaAtacadoLabel";
            lucroPrecoVendaAtacadoLabel.Size = new System.Drawing.Size(73, 13);
            lucroPrecoVendaAtacadoLabel.TabIndex = 40;
            lucroPrecoVendaAtacadoLabel.Text = "% Lucro Atac:";
            // 
            // lucroPrecoVendaVarejoLabel
            // 
            lucroPrecoVendaVarejoLabel.AutoSize = true;
            lucroPrecoVendaVarejoLabel.Location = new System.Drawing.Point(198, 110);
            lucroPrecoVendaVarejoLabel.Name = "lucroPrecoVendaVarejoLabel";
            lucroPrecoVendaVarejoLabel.Size = new System.Drawing.Size(66, 13);
            lucroPrecoVendaVarejoLabel.TabIndex = 42;
            lucroPrecoVendaVarejoLabel.Text = "% Lucro Vjo:";
            // 
            // precoVendaVarejoLabel
            // 
            precoVendaVarejoLabel.AutoSize = true;
            precoVendaVarejoLabel.Location = new System.Drawing.Point(366, 110);
            precoVendaVarejoLabel.Name = "precoVendaVarejoLabel";
            precoVendaVarejoLabel.Size = new System.Drawing.Size(71, 13);
            precoVendaVarejoLabel.TabIndex = 44;
            precoVendaVarejoLabel.Text = "Preço Varejo:";
            // 
            // qtdProdutoAtacadoLabel
            // 
            qtdProdutoAtacadoLabel.AutoSize = true;
            qtdProdutoAtacadoLabel.Location = new System.Drawing.Point(463, 110);
            qtdProdutoAtacadoLabel.Name = "qtdProdutoAtacadoLabel";
            qtdProdutoAtacadoLabel.Size = new System.Drawing.Size(70, 13);
            qtdProdutoAtacadoLabel.TabIndex = 46;
            qtdProdutoAtacadoLabel.Text = "Qtd Atacado:";
            // 
            // precoVendaAtacadoLabel
            // 
            precoVendaAtacadoLabel.AutoSize = true;
            precoVendaAtacadoLabel.Location = new System.Drawing.Point(710, 110);
            precoVendaAtacadoLabel.Name = "precoVendaAtacadoLabel";
            precoVendaAtacadoLabel.Size = new System.Drawing.Size(81, 13);
            precoVendaAtacadoLabel.TabIndex = 48;
            precoVendaAtacadoLabel.Text = "Preço Atacado:";
            // 
            // preco_custoLabel
            // 
            preco_custoLabel.AutoSize = true;
            preco_custoLabel.Location = new System.Drawing.Point(724, 64);
            preco_custoLabel.Name = "preco_custoLabel";
            preco_custoLabel.Size = new System.Drawing.Size(68, 13);
            preco_custoLabel.TabIndex = 115;
            preco_custoLabel.Text = "Preço Custo:";
            // 
            // descricaoSituacaoPagamentosLabel
            // 
            descricaoSituacaoPagamentosLabel.AutoSize = true;
            descricaoSituacaoPagamentosLabel.Location = new System.Drawing.Point(410, 43);
            descricaoSituacaoPagamentosLabel.Name = "descricaoSituacaoPagamentosLabel";
            descricaoSituacaoPagamentosLabel.Size = new System.Drawing.Size(69, 13);
            descricaoSituacaoPagamentosLabel.TabIndex = 111;
            descricaoSituacaoPagamentosLabel.Text = "Pagamentos:";
            descricaoSituacaoPagamentosLabel.Visible = false;
            // 
            // valorDescontoLabel
            // 
            valorDescontoLabel.AutoSize = true;
            valorDescontoLabel.Location = new System.Drawing.Point(579, 64);
            valorDescontoLabel.Name = "valorDescontoLabel";
            valorDescontoLabel.Size = new System.Drawing.Size(55, 13);
            valorDescontoLabel.TabIndex = 117;
            valorDescontoLabel.Text = "% Descto:";
            // 
            // totalProdutosSTLabel
            // 
            totalProdutosSTLabel.AutoSize = true;
            totalProdutosSTLabel.Location = new System.Drawing.Point(493, 149);
            totalProdutosSTLabel.Name = "totalProdutosSTLabel";
            totalProdutosSTLabel.Size = new System.Drawing.Size(103, 13);
            totalProdutosSTLabel.TabIndex = 112;
            totalProdutosSTLabel.Text = "Valor Total Prod ST:";
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
            this.btnSalvar.Location = new System.Drawing.Point(307, 583);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(7, 583);
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
            this.btnCancelar.Location = new System.Drawing.Point(572, 583);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(82, 583);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "F3 - Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(232, 583);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "F5 - Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(157, 583);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "F4 - Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnProdutos
            // 
            this.btnProdutos.Location = new System.Drawing.Point(388, 583);
            this.btnProdutos.Name = "btnProdutos";
            this.btnProdutos.Size = new System.Drawing.Size(84, 23);
            this.btnProdutos.TabIndex = 5;
            this.btnProdutos.Text = "F7 - Produtos";
            this.btnProdutos.UseVisualStyleBackColor = true;
            this.btnProdutos.Click += new System.EventHandler(this.btnProdutos_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(89, 381);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "DEL - Excluir";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(8, 381);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 60;
            this.label6.Text = "F12 - Navegar";
            // 
            // btnPagamentos
            // 
            this.btnPagamentos.Location = new System.Drawing.Point(472, 583);
            this.btnPagamentos.Name = "btnPagamentos";
            this.btnPagamentos.Size = new System.Drawing.Size(100, 23);
            this.btnPagamentos.TabIndex = 6;
            this.btnPagamentos.Text = "F8 - Pagamentos";
            this.btnPagamentos.UseVisualStyleBackColor = true;
            this.btnPagamentos.Click += new System.EventHandler(this.btnPagamentos_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(507, 381);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 26);
            this.label7.TabIndex = 63;
            this.label7.Text = "Total Produtos ";
            // 
            // totalNotaCalculadoTextBox
            // 
            this.totalNotaCalculadoTextBox.BackColor = System.Drawing.Color.Blue;
            this.totalNotaCalculadoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalNotaCalculadoTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.totalNotaCalculadoTextBox.Location = new System.Drawing.Point(667, 381);
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
            this.ProdutosGroupBox.Controls.Add(valorDescontoLabel);
            this.ProdutosGroupBox.Controls.Add(this.descontoProdutoTextBox);
            this.ProdutosGroupBox.Controls.Add(this.codCSTComboBox);
            this.ProdutosGroupBox.Controls.Add(this.cfopComboBox);
            this.ProdutosGroupBox.Controls.Add(preco_custoLabel);
            this.ProdutosGroupBox.Controls.Add(this.preco_custoTextBox);
            this.ProdutosGroupBox.Controls.Add(this.label3);
            this.ProdutosGroupBox.Controls.Add(precoVendaAtacadoLabel);
            this.ProdutosGroupBox.Controls.Add(this.precoVendaAtacadoTextBox);
            this.ProdutosGroupBox.Controls.Add(qtdProdutoAtacadoLabel);
            this.ProdutosGroupBox.Controls.Add(this.precoAtacadoSugestaoTextBox);
            this.ProdutosGroupBox.Controls.Add(this.qtdProdutoAtacadoTextBox);
            this.ProdutosGroupBox.Controls.Add(this.precoVarejoSugestaoTextBox);
            this.ProdutosGroupBox.Controls.Add(precoVendaVarejoLabel);
            this.ProdutosGroupBox.Controls.Add(this.precoVendaVarejoTextBox);
            this.ProdutosGroupBox.Controls.Add(this.label4);
            this.ProdutosGroupBox.Controls.Add(lucroPrecoVendaVarejoLabel);
            this.ProdutosGroupBox.Controls.Add(this.lucroPrecoVendaVarejoTextBox);
            this.ProdutosGroupBox.Controls.Add(lucroPrecoVendaAtacadoLabel);
            this.ProdutosGroupBox.Controls.Add(this.lucroPrecoVendaAtacadoTextBox);
            this.ProdutosGroupBox.Controls.Add(simplesLabel);
            this.ProdutosGroupBox.Controls.Add(this.simplesTextBox);
            this.ProdutosGroupBox.Controls.Add(freteLabel);
            this.ProdutosGroupBox.Controls.Add(this.freteTextBox);
            this.ProdutosGroupBox.Controls.Add(ipiLabel);
            this.ProdutosGroupBox.Controls.Add(this.ipiTextBox);
            this.ProdutosGroupBox.Controls.Add(icms_substitutoLabel);
            this.ProdutosGroupBox.Controls.Add(this.icms_substitutoTextBox);
            this.ProdutosGroupBox.Controls.Add(this.icmsTextBox);
            this.ProdutosGroupBox.Controls.Add(codCSTLabel);
            this.ProdutosGroupBox.Controls.Add(ncmshLabel);
            this.ProdutosGroupBox.Controls.Add(this.ncmshTextBox);
            this.ProdutosGroupBox.Controls.Add(data_validadeLabel);
            this.ProdutosGroupBox.Controls.Add(this.data_validadeDateTimePicker);
            this.ProdutosGroupBox.Controls.Add(valorIPILabel);
            this.ProdutosGroupBox.Controls.Add(this.valorIPITextBox);
            this.ProdutosGroupBox.Controls.Add(valorICMSSTLabel);
            this.ProdutosGroupBox.Controls.Add(this.valorICMSSTTextBox);
            this.ProdutosGroupBox.Controls.Add(valorICMSLabel);
            this.ProdutosGroupBox.Controls.Add(this.valorICMSTextBox);
            this.ProdutosGroupBox.Controls.Add(baseCalculoICMSSTLabel);
            this.ProdutosGroupBox.Controls.Add(this.baseCalculoICMSSTTextBox);
            this.ProdutosGroupBox.Controls.Add(baseCalculoICMSLabel);
            this.ProdutosGroupBox.Controls.Add(this.baseCalculoICMSTextBox);
            this.ProdutosGroupBox.Controls.Add(quantidadeEmbalagemLabel);
            this.ProdutosGroupBox.Controls.Add(this.quantidadeEmbalagemTextBox);
            this.ProdutosGroupBox.Controls.Add(valorTotalLabel);
            this.ProdutosGroupBox.Controls.Add(this.valorTotalTextBox);
            this.ProdutosGroupBox.Controls.Add(valorUnitarioLabel);
            this.ProdutosGroupBox.Controls.Add(this.valorUnitarioTextBox);
            this.ProdutosGroupBox.Controls.Add(quantidadeLabel);
            this.ProdutosGroupBox.Controls.Add(this.quantidadeTextBox);
            this.ProdutosGroupBox.Controls.Add(unidadeCompraLabel);
            this.ProdutosGroupBox.Controls.Add(this.unidadeCompraTextBox);
            this.ProdutosGroupBox.Controls.Add(cfopLabel);
            this.ProdutosGroupBox.Controls.Add(codProdutoLabel);
            this.ProdutosGroupBox.Controls.Add(this.codProdutoComboBox);
            this.ProdutosGroupBox.Controls.Add(icmsLabel);
            this.ProdutosGroupBox.Controls.Add(this.temVencimentoCheckBox);
            this.ProdutosGroupBox.Enabled = false;
            this.ProdutosGroupBox.Location = new System.Drawing.Point(6, 412);
            this.ProdutosGroupBox.Name = "ProdutosGroupBox";
            this.ProdutosGroupBox.Size = new System.Drawing.Size(818, 155);
            this.ProdutosGroupBox.TabIndex = 76;
            this.ProdutosGroupBox.TabStop = false;
            this.ProdutosGroupBox.Text = "Produtos da Nota Fiscal";
            // 
            // descontoProdutoTextBox
            // 
            this.descontoProdutoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entrada_produtoBindingSource, "desconto", true));
            this.descontoProdutoTextBox.Location = new System.Drawing.Point(583, 82);
            this.descontoProdutoTextBox.Name = "descontoProdutoTextBox";
            this.descontoProdutoTextBox.Size = new System.Drawing.Size(45, 20);
            this.descontoProdutoTextBox.TabIndex = 81;
            this.descontoProdutoTextBox.Leave += new System.EventHandler(this.quantidadeTextBox_Leave);
            // 
            // tb_entrada_produtoBindingSource
            // 
            this.tb_entrada_produtoBindingSource.DataMember = "tb_entrada_produto";
            this.tb_entrada_produtoBindingSource.DataSource = this.saceDataSet;
            this.tb_entrada_produtoBindingSource.Sort = "";
            // 
            // saceDataSet
            // 
            this.saceDataSet.DataSetName = "saceDataSet";
            this.saceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // codCSTComboBox
            // 
            this.codCSTComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "codCST", true));
            this.codCSTComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_produtoBindingSource, "codCST", true));
            this.codCSTComboBox.DataSource = this.tbcstBindingSource;
            this.codCSTComboBox.DisplayMember = "codCST";
            this.codCSTComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codCSTComboBox.FormattingEnabled = true;
            this.codCSTComboBox.Location = new System.Drawing.Point(443, 33);
            this.codCSTComboBox.Name = "codCSTComboBox";
            this.codCSTComboBox.Size = new System.Drawing.Size(51, 21);
            this.codCSTComboBox.TabIndex = 54;
            this.codCSTComboBox.ValueMember = "codCST";
            this.codCSTComboBox.SelectedIndexChanged += new System.EventHandler(this.codCSTComboBox_SelectedIndexChanged);
            this.codCSTComboBox.Leave += new System.EventHandler(this.codCSTComboBox_SelectedIndexChanged);
            // 
            // tb_produtoBindingSource
            // 
            this.tb_produtoBindingSource.DataMember = "tb_produto";
            this.tb_produtoBindingSource.DataSource = this.saceDataSet;
            // 
            // tbcstBindingSource
            // 
            this.tbcstBindingSource.DataMember = "tb_cst";
            this.tbcstBindingSource.DataSource = this.saceDataSet;
            // 
            // cfopComboBox
            // 
            this.cfopComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entrada_produtoBindingSource, "cfop", true));
            this.cfopComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_produtoBindingSource, "cfop", true));
            this.cfopComboBox.DataSource = this.tbcfopBindingSource;
            this.cfopComboBox.DisplayMember = "cfop";
            this.cfopComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cfopComboBox.FormattingEnabled = true;
            this.cfopComboBox.Location = new System.Drawing.Point(500, 33);
            this.cfopComboBox.Name = "cfopComboBox";
            this.cfopComboBox.Size = new System.Drawing.Size(52, 21);
            this.cfopComboBox.TabIndex = 56;
            this.cfopComboBox.ValueMember = "cfop";
            // 
            // tbcfopBindingSource
            // 
            this.tbcfopBindingSource.DataMember = "tb_cfop";
            this.tbcfopBindingSource.DataSource = this.saceDataSet;
            // 
            // preco_custoTextBox
            // 
            this.preco_custoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entrada_produtoBindingSource, "preco_custo", true));
            this.preco_custoTextBox.Location = new System.Drawing.Point(726, 81);
            this.preco_custoTextBox.Name = "preco_custoTextBox";
            this.preco_custoTextBox.ReadOnly = true;
            this.preco_custoTextBox.Size = new System.Drawing.Size(86, 20);
            this.preco_custoTextBox.TabIndex = 116;
            this.preco_custoTextBox.TabStop = false;
            this.preco_custoTextBox.Leave += new System.EventHandler(this.quantidadeTextBox_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(612, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 115;
            this.label3.Text = "Pç Atac Sugestão:";
            // 
            // precoVendaAtacadoTextBox
            // 
            this.precoVendaAtacadoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "precoVendaAtacado", true));
            this.precoVendaAtacadoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precoVendaAtacadoTextBox.ForeColor = System.Drawing.Color.Red;
            this.precoVendaAtacadoTextBox.Location = new System.Drawing.Point(713, 126);
            this.precoVendaAtacadoTextBox.Name = "precoVendaAtacadoTextBox";
            this.precoVendaAtacadoTextBox.Size = new System.Drawing.Size(99, 20);
            this.precoVendaAtacadoTextBox.TabIndex = 102;
            this.precoVendaAtacadoTextBox.Leave += new System.EventHandler(this.precoVendaAtacadoTextBox_Leave);
            // 
            // precoAtacadoSugestaoTextBox
            // 
            this.precoAtacadoSugestaoTextBox.Location = new System.Drawing.Point(612, 126);
            this.precoAtacadoSugestaoTextBox.Name = "precoAtacadoSugestaoTextBox";
            this.precoAtacadoSugestaoTextBox.ReadOnly = true;
            this.precoAtacadoSugestaoTextBox.Size = new System.Drawing.Size(93, 20);
            this.precoAtacadoSugestaoTextBox.TabIndex = 100;
            this.precoAtacadoSugestaoTextBox.TabStop = false;
            // 
            // qtdProdutoAtacadoTextBox
            // 
            this.qtdProdutoAtacadoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "qtdProdutoAtacado", true));
            this.qtdProdutoAtacadoTextBox.Location = new System.Drawing.Point(466, 126);
            this.qtdProdutoAtacadoTextBox.Name = "qtdProdutoAtacadoTextBox";
            this.qtdProdutoAtacadoTextBox.Size = new System.Drawing.Size(67, 20);
            this.qtdProdutoAtacadoTextBox.TabIndex = 96;
            this.qtdProdutoAtacadoTextBox.Leave += new System.EventHandler(this.qtdProdutoAtacadoTextBox_Leave);
            // 
            // precoVarejoSugestaoTextBox
            // 
            this.precoVarejoSugestaoTextBox.Location = new System.Drawing.Point(267, 126);
            this.precoVarejoSugestaoTextBox.Name = "precoVarejoSugestaoTextBox";
            this.precoVarejoSugestaoTextBox.ReadOnly = true;
            this.precoVarejoSugestaoTextBox.Size = new System.Drawing.Size(93, 20);
            this.precoVarejoSugestaoTextBox.TabIndex = 92;
            this.precoVarejoSugestaoTextBox.TabStop = false;
            // 
            // precoVendaVarejoTextBox
            // 
            this.precoVendaVarejoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "precoVendaVarejo", true));
            this.precoVendaVarejoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precoVendaVarejoTextBox.ForeColor = System.Drawing.Color.Red;
            this.precoVendaVarejoTextBox.Location = new System.Drawing.Point(369, 126);
            this.precoVendaVarejoTextBox.Name = "precoVendaVarejoTextBox";
            this.precoVendaVarejoTextBox.Size = new System.Drawing.Size(93, 20);
            this.precoVendaVarejoTextBox.TabIndex = 94;
            this.precoVendaVarejoTextBox.Leave += new System.EventHandler(this.precoVendaVarejoTextBox_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(267, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 114;
            this.label4.Text = "Pço Vjo Sugestão:";
            // 
            // lucroPrecoVendaVarejoTextBox
            // 
            this.lucroPrecoVendaVarejoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "lucroPrecoVendaVarejo", true));
            this.lucroPrecoVendaVarejoTextBox.Location = new System.Drawing.Point(201, 126);
            this.lucroPrecoVendaVarejoTextBox.Name = "lucroPrecoVendaVarejoTextBox";
            this.lucroPrecoVendaVarejoTextBox.Size = new System.Drawing.Size(63, 20);
            this.lucroPrecoVendaVarejoTextBox.TabIndex = 90;
            this.lucroPrecoVendaVarejoTextBox.Leave += new System.EventHandler(this.quantidadeTextBox_Leave);
            // 
            // lucroPrecoVendaAtacadoTextBox
            // 
            this.lucroPrecoVendaAtacadoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "lucroPrecoVendaAtacado", true));
            this.lucroPrecoVendaAtacadoTextBox.Location = new System.Drawing.Point(538, 126);
            this.lucroPrecoVendaAtacadoTextBox.Name = "lucroPrecoVendaAtacadoTextBox";
            this.lucroPrecoVendaAtacadoTextBox.Size = new System.Drawing.Size(69, 20);
            this.lucroPrecoVendaAtacadoTextBox.TabIndex = 98;
            this.lucroPrecoVendaAtacadoTextBox.Leave += new System.EventHandler(this.quantidadeTextBox_Leave);
            // 
            // simplesTextBox
            // 
            this.simplesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "simples", true));
            this.simplesTextBox.Location = new System.Drawing.Point(676, 82);
            this.simplesTextBox.Name = "simplesTextBox";
            this.simplesTextBox.ReadOnly = true;
            this.simplesTextBox.Size = new System.Drawing.Size(46, 20);
            this.simplesTextBox.TabIndex = 84;
            this.simplesTextBox.TabStop = false;
            // 
            // freteTextBox
            // 
            this.freteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "frete", true));
            this.freteTextBox.Location = new System.Drawing.Point(632, 82);
            this.freteTextBox.Name = "freteTextBox";
            this.freteTextBox.ReadOnly = true;
            this.freteTextBox.Size = new System.Drawing.Size(36, 20);
            this.freteTextBox.TabIndex = 82;
            this.freteTextBox.TabStop = false;
            // 
            // ipiTextBox
            // 
            this.ipiTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "ipi", true));
            this.ipiTextBox.Location = new System.Drawing.Point(477, 82);
            this.ipiTextBox.Name = "ipiTextBox";
            this.ipiTextBox.Size = new System.Drawing.Size(46, 20);
            this.ipiTextBox.TabIndex = 78;
            this.ipiTextBox.Leave += new System.EventHandler(this.quantidadeTextBox_Leave);
            // 
            // icms_substitutoTextBox
            // 
            this.icms_substitutoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "icms_substituto", true));
            this.icms_substitutoTextBox.Location = new System.Drawing.Point(329, 84);
            this.icms_substitutoTextBox.Name = "icms_substitutoTextBox";
            this.icms_substitutoTextBox.Size = new System.Drawing.Size(61, 20);
            this.icms_substitutoTextBox.TabIndex = 74;
            this.icms_substitutoTextBox.Leave += new System.EventHandler(this.quantidadeTextBox_Leave);
            // 
            // icmsTextBox
            // 
            this.icmsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "icms", true));
            this.icmsTextBox.Location = new System.Drawing.Point(92, 84);
            this.icmsTextBox.Name = "icmsTextBox";
            this.icmsTextBox.Size = new System.Drawing.Size(63, 20);
            this.icmsTextBox.TabIndex = 68;
            this.icmsTextBox.Leave += new System.EventHandler(this.quantidadeTextBox_Leave);
            // 
            // ncmshTextBox
            // 
            this.ncmshTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "ncmsh", true));
            this.ncmshTextBox.Location = new System.Drawing.Point(378, 34);
            this.ncmshTextBox.MaxLength = 8;
            this.ncmshTextBox.Name = "ncmshTextBox";
            this.ncmshTextBox.Size = new System.Drawing.Size(59, 20);
            this.ncmshTextBox.TabIndex = 52;
            // 
            // data_validadeDateTimePicker
            // 
            this.data_validadeDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tb_entrada_produtoBindingSource, "data_validade", true));
            this.data_validadeDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.data_validadeDateTimePicker.Location = new System.Drawing.Point(9, 126);
            this.data_validadeDateTimePicker.Name = "data_validadeDateTimePicker";
            this.data_validadeDateTimePicker.Size = new System.Drawing.Size(98, 20);
            this.data_validadeDateTimePicker.TabIndex = 86;
            // 
            // valorIPITextBox
            // 
            this.valorIPITextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entrada_produtoBindingSource, "valorIPI", true));
            this.valorIPITextBox.Location = new System.Drawing.Point(529, 82);
            this.valorIPITextBox.Name = "valorIPITextBox";
            this.valorIPITextBox.ReadOnly = true;
            this.valorIPITextBox.Size = new System.Drawing.Size(52, 20);
            this.valorIPITextBox.TabIndex = 80;
            this.valorIPITextBox.TabStop = false;
            // 
            // valorICMSSTTextBox
            // 
            this.valorICMSSTTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entrada_produtoBindingSource, "valorICMSST", true));
            this.valorICMSSTTextBox.Location = new System.Drawing.Point(393, 84);
            this.valorICMSSTTextBox.Name = "valorICMSSTTextBox";
            this.valorICMSSTTextBox.ReadOnly = true;
            this.valorICMSSTTextBox.Size = new System.Drawing.Size(80, 20);
            this.valorICMSSTTextBox.TabIndex = 76;
            this.valorICMSSTTextBox.TabStop = false;
            this.valorICMSSTTextBox.Leave += new System.EventHandler(this.quantidadeTextBox_Leave);
            // 
            // valorICMSTextBox
            // 
            this.valorICMSTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entrada_produtoBindingSource, "valorICMS", true));
            this.valorICMSTextBox.Location = new System.Drawing.Point(160, 84);
            this.valorICMSTextBox.Name = "valorICMSTextBox";
            this.valorICMSTextBox.ReadOnly = true;
            this.valorICMSTextBox.Size = new System.Drawing.Size(80, 20);
            this.valorICMSTextBox.TabIndex = 70;
            this.valorICMSTextBox.TabStop = false;
            // 
            // baseCalculoICMSSTTextBox
            // 
            this.baseCalculoICMSSTTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entrada_produtoBindingSource, "baseCalculoICMSST", true));
            this.baseCalculoICMSSTTextBox.Location = new System.Drawing.Point(246, 84);
            this.baseCalculoICMSSTTextBox.Name = "baseCalculoICMSSTTextBox";
            this.baseCalculoICMSSTTextBox.Size = new System.Drawing.Size(77, 20);
            this.baseCalculoICMSSTTextBox.TabIndex = 72;
            this.baseCalculoICMSSTTextBox.Leave += new System.EventHandler(this.quantidadeTextBox_Leave);
            // 
            // baseCalculoICMSTextBox
            // 
            this.baseCalculoICMSTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entrada_produtoBindingSource, "baseCalculoICMS", true));
            this.baseCalculoICMSTextBox.Location = new System.Drawing.Point(9, 84);
            this.baseCalculoICMSTextBox.Name = "baseCalculoICMSTextBox";
            this.baseCalculoICMSTextBox.Size = new System.Drawing.Size(80, 20);
            this.baseCalculoICMSTextBox.TabIndex = 66;
            this.baseCalculoICMSTextBox.Leave += new System.EventHandler(this.quantidadeTextBox_Leave);
            // 
            // quantidadeEmbalagemTextBox
            // 
            this.quantidadeEmbalagemTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entrada_produtoBindingSource, "quantidadeEmbalagem", true));
            this.quantidadeEmbalagemTextBox.Location = new System.Drawing.Point(118, 126);
            this.quantidadeEmbalagemTextBox.Name = "quantidadeEmbalagemTextBox";
            this.quantidadeEmbalagemTextBox.Size = new System.Drawing.Size(77, 20);
            this.quantidadeEmbalagemTextBox.TabIndex = 88;
            this.quantidadeEmbalagemTextBox.Leave += new System.EventHandler(this.quantidadeTextBox_Leave);
            // 
            // valorTotalTextBox
            // 
            this.valorTotalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entrada_produtoBindingSource, "valorTotal", true));
            this.valorTotalTextBox.Location = new System.Drawing.Point(726, 34);
            this.valorTotalTextBox.Name = "valorTotalTextBox";
            this.valorTotalTextBox.Size = new System.Drawing.Size(86, 20);
            this.valorTotalTextBox.TabIndex = 64;
            this.valorTotalTextBox.Leave += new System.EventHandler(this.quantidadeTextBox_Leave);
            // 
            // valorUnitarioTextBox
            // 
            this.valorUnitarioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "ultimoPrecoCompra", true));
            this.valorUnitarioTextBox.Location = new System.Drawing.Point(653, 34);
            this.valorUnitarioTextBox.Name = "valorUnitarioTextBox";
            this.valorUnitarioTextBox.Size = new System.Drawing.Size(67, 20);
            this.valorUnitarioTextBox.TabIndex = 62;
            this.valorUnitarioTextBox.Leave += new System.EventHandler(this.quantidadeTextBox_Leave);
            // 
            // quantidadeTextBox
            // 
            this.quantidadeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entrada_produtoBindingSource, "quantidade", true));
            this.quantidadeTextBox.Location = new System.Drawing.Point(595, 34);
            this.quantidadeTextBox.Name = "quantidadeTextBox";
            this.quantidadeTextBox.Size = new System.Drawing.Size(55, 20);
            this.quantidadeTextBox.TabIndex = 60;
            this.quantidadeTextBox.Leave += new System.EventHandler(this.quantidadeTextBox_Leave);
            // 
            // unidadeCompraTextBox
            // 
            this.unidadeCompraTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.unidadeCompraTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "unidade", true));
            this.unidadeCompraTextBox.Location = new System.Drawing.Point(558, 34);
            this.unidadeCompraTextBox.MaxLength = 2;
            this.unidadeCompraTextBox.Name = "unidadeCompraTextBox";
            this.unidadeCompraTextBox.Size = new System.Drawing.Size(31, 20);
            this.unidadeCompraTextBox.TabIndex = 58;
            // 
            // codProdutoComboBox
            // 
            this.codProdutoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codProdutoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codProdutoComboBox.CausesValidation = false;
            this.codProdutoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_entrada_produtoBindingSource, "codProduto", true));
            this.codProdutoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entrada_produtoBindingSource, "nomeProduto", true));
            this.codProdutoComboBox.DataSource = this.tb_produtoBindingSource;
            this.codProdutoComboBox.DisplayMember = "nome";
            this.codProdutoComboBox.FormattingEnabled = true;
            this.codProdutoComboBox.Location = new System.Drawing.Point(6, 33);
            this.codProdutoComboBox.Name = "codProdutoComboBox";
            this.codProdutoComboBox.Size = new System.Drawing.Size(363, 21);
            this.codProdutoComboBox.TabIndex = 50;
            this.codProdutoComboBox.ValueMember = "codProduto";
            this.codProdutoComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codigoFornecedorComboBox_KeyPress);
            this.codProdutoComboBox.Leave += new System.EventHandler(this.codProdutoComboBox_Leave);
            // 
            // temVencimentoCheckBox
            // 
            this.temVencimentoCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.tb_produtoBindingSource, "temVencimento", true));
            this.temVencimentoCheckBox.Location = new System.Drawing.Point(41, 124);
            this.temVencimentoCheckBox.Name = "temVencimentoCheckBox";
            this.temVencimentoCheckBox.Size = new System.Drawing.Size(18, 24);
            this.temVencimentoCheckBox.TabIndex = 117;
            this.temVencimentoCheckBox.UseVisualStyleBackColor = true;
            // 
            // tb_entradaBindingSource
            // 
            this.tb_entradaBindingSource.DataMember = "tb_entrada";
            this.tb_entradaBindingSource.DataSource = this.saceDataSet;
            this.tb_entradaBindingSource.Sort = "codEntrada";
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
            this.tb_entradaBindingNavigator.Location = new System.Drawing.Point(619, 40);
            this.tb_entradaBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tb_entradaBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tb_entradaBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tb_entradaBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tb_entradaBindingNavigator.Name = "tb_entradaBindingNavigator";
            this.tb_entradaBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tb_entradaBindingNavigator.Size = new System.Drawing.Size(209, 25);
            this.tb_entradaBindingNavigator.TabIndex = 77;
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
            this.codEntradaTextBox.Enabled = false;
            this.codEntradaTextBox.Location = new System.Drawing.Point(5, 84);
            this.codEntradaTextBox.Name = "codEntradaTextBox";
            this.codEntradaTextBox.Size = new System.Drawing.Size(75, 20);
            this.codEntradaTextBox.TabIndex = 12;
            this.codEntradaTextBox.TextChanged += new System.EventHandler(this.codEntradaTextBox_TextChanged);
            // 
            // numeroNotaFiscalTextBox
            // 
            this.numeroNotaFiscalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "numeroNotaFiscal", true));
            this.numeroNotaFiscalTextBox.Location = new System.Drawing.Point(91, 84);
            this.numeroNotaFiscalTextBox.Name = "numeroNotaFiscalTextBox";
            this.numeroNotaFiscalTextBox.Size = new System.Drawing.Size(100, 20);
            this.numeroNotaFiscalTextBox.TabIndex = 14;
            // 
            // codEmpresaFreteComboBox
            // 
            this.codEmpresaFreteComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codEmpresaFreteComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codEmpresaFreteComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "nomeEmpresaFrete", true));
            this.codEmpresaFreteComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_entradaBindingSource, "codEmpresaFrete", true));
            this.codEmpresaFreteComboBox.DataSource = this.tbpessoaBindingSource1;
            this.codEmpresaFreteComboBox.DisplayMember = "nome";
            this.codEmpresaFreteComboBox.FormattingEnabled = true;
            this.codEmpresaFreteComboBox.Location = new System.Drawing.Point(5, 125);
            this.codEmpresaFreteComboBox.Name = "codEmpresaFreteComboBox";
            this.codEmpresaFreteComboBox.Size = new System.Drawing.Size(295, 21);
            this.codEmpresaFreteComboBox.TabIndex = 22;
            this.codEmpresaFreteComboBox.ValueMember = "codPessoa";
            this.codEmpresaFreteComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codigoFornecedorComboBox_KeyPress);
            this.codEmpresaFreteComboBox.Leave += new System.EventHandler(this.codFornecedorComboBox_Leave);
            // 
            // tbpessoaBindingSource1
            // 
            this.tbpessoaBindingSource1.DataMember = "tb_pessoa";
            this.tbpessoaBindingSource1.DataSource = this.saceDataSet;
            // 
            // tbpessoaBindingSource
            // 
            this.tbpessoaBindingSource.DataMember = "tb_pessoa";
            this.tbpessoaBindingSource.DataSource = this.saceDataSet;
            // 
            // codFornecedorComboBox
            // 
            this.codFornecedorComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codFornecedorComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codFornecedorComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "nomeFornecedor", true));
            this.codFornecedorComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_entradaBindingSource, "codFornecedor", true));
            this.codFornecedorComboBox.DataSource = this.tbpessoaBindingSource;
            this.codFornecedorComboBox.DisplayMember = "nome";
            this.codFornecedorComboBox.FormattingEnabled = true;
            this.codFornecedorComboBox.Location = new System.Drawing.Point(199, 84);
            this.codFornecedorComboBox.Name = "codFornecedorComboBox";
            this.codFornecedorComboBox.Size = new System.Drawing.Size(399, 21);
            this.codFornecedorComboBox.TabIndex = 16;
            this.codFornecedorComboBox.ValueMember = "codPessoa";
            this.codFornecedorComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codigoFornecedorComboBox_KeyPress);
            this.codFornecedorComboBox.Leave += new System.EventHandler(this.codFornecedorComboBox_Leave);
            // 
            // dataEmissaoDateTimePicker
            // 
            this.dataEmissaoDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tb_entradaBindingSource, "dataEmissao", true));
            this.dataEmissaoDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataEmissaoDateTimePicker.Location = new System.Drawing.Point(610, 85);
            this.dataEmissaoDateTimePicker.Name = "dataEmissaoDateTimePicker";
            this.dataEmissaoDateTimePicker.Size = new System.Drawing.Size(101, 20);
            this.dataEmissaoDateTimePicker.TabIndex = 18;
            // 
            // dataEntradaDateTimePicker
            // 
            this.dataEntradaDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tb_entradaBindingSource, "dataEntrada", true));
            this.dataEntradaDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataEntradaDateTimePicker.Location = new System.Drawing.Point(720, 85);
            this.dataEntradaDateTimePicker.Name = "dataEntradaDateTimePicker";
            this.dataEntradaDateTimePicker.Size = new System.Drawing.Size(95, 20);
            this.dataEntradaDateTimePicker.TabIndex = 20;
            // 
            // totalBaseCalculoTextBox
            // 
            this.totalBaseCalculoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "totalBaseCalculo", true));
            this.totalBaseCalculoTextBox.Location = new System.Drawing.Point(382, 126);
            this.totalBaseCalculoTextBox.Name = "totalBaseCalculoTextBox";
            this.totalBaseCalculoTextBox.Size = new System.Drawing.Size(104, 20);
            this.totalBaseCalculoTextBox.TabIndex = 24;
            this.totalBaseCalculoTextBox.Leave += new System.EventHandler(this.totalBaseCalculoTextBox_Leave);
            // 
            // totalICMSTextBox
            // 
            this.totalICMSTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "totalICMS", true));
            this.totalICMSTextBox.Location = new System.Drawing.Point(495, 126);
            this.totalICMSTextBox.Name = "totalICMSTextBox";
            this.totalICMSTextBox.Size = new System.Drawing.Size(104, 20);
            this.totalICMSTextBox.TabIndex = 26;
            this.totalICMSTextBox.Leave += new System.EventHandler(this.totalBaseCalculoTextBox_Leave);
            // 
            // totalBaseSubstituicaoTextBox
            // 
            this.totalBaseSubstituicaoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "totalBaseSubstituicao", true));
            this.totalBaseSubstituicaoTextBox.Location = new System.Drawing.Point(610, 126);
            this.totalBaseSubstituicaoTextBox.Name = "totalBaseSubstituicaoTextBox";
            this.totalBaseSubstituicaoTextBox.Size = new System.Drawing.Size(101, 20);
            this.totalBaseSubstituicaoTextBox.TabIndex = 28;
            this.totalBaseSubstituicaoTextBox.Leave += new System.EventHandler(this.totalBaseCalculoTextBox_Leave);
            // 
            // totalSubstituicaoTextBox
            // 
            this.totalSubstituicaoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "totalSubstituicao", true));
            this.totalSubstituicaoTextBox.Location = new System.Drawing.Point(720, 126);
            this.totalSubstituicaoTextBox.Name = "totalSubstituicaoTextBox";
            this.totalSubstituicaoTextBox.Size = new System.Drawing.Size(95, 20);
            this.totalSubstituicaoTextBox.TabIndex = 30;
            this.totalSubstituicaoTextBox.Leave += new System.EventHandler(this.totalBaseCalculoTextBox_Leave);
            // 
            // totalProdutosTextBox
            // 
            this.totalProdutosTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "totalProdutos", true));
            this.totalProdutosTextBox.Location = new System.Drawing.Point(610, 167);
            this.totalProdutosTextBox.Name = "totalProdutosTextBox";
            this.totalProdutosTextBox.Size = new System.Drawing.Size(99, 20);
            this.totalProdutosTextBox.TabIndex = 42;
            this.totalProdutosTextBox.Leave += new System.EventHandler(this.totalBaseCalculoTextBox_Leave);
            // 
            // valorFreteTextBox
            // 
            this.valorFreteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "valorFrete", true));
            this.valorFreteTextBox.Location = new System.Drawing.Point(9, 167);
            this.valorFreteTextBox.Name = "valorFreteTextBox";
            this.valorFreteTextBox.Size = new System.Drawing.Size(104, 20);
            this.valorFreteTextBox.TabIndex = 32;
            this.valorFreteTextBox.Leave += new System.EventHandler(this.totalBaseCalculoTextBox_Leave);
            // 
            // valorSeguroTextBox
            // 
            this.valorSeguroTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "valorSeguro", true));
            this.valorSeguroTextBox.Location = new System.Drawing.Point(121, 167);
            this.valorSeguroTextBox.Name = "valorSeguroTextBox";
            this.valorSeguroTextBox.Size = new System.Drawing.Size(104, 20);
            this.valorSeguroTextBox.TabIndex = 34;
            this.valorSeguroTextBox.Leave += new System.EventHandler(this.totalBaseCalculoTextBox_Leave);
            // 
            // descontoTextBox
            // 
            this.descontoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "desconto", true));
            this.descontoTextBox.Location = new System.Drawing.Point(231, 167);
            this.descontoTextBox.Name = "descontoTextBox";
            this.descontoTextBox.Size = new System.Drawing.Size(80, 20);
            this.descontoTextBox.TabIndex = 36;
            this.descontoTextBox.Leave += new System.EventHandler(this.totalBaseCalculoTextBox_Leave);
            // 
            // outrasDespesasTextBox
            // 
            this.outrasDespesasTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "outrasDespesas", true));
            this.outrasDespesasTextBox.Location = new System.Drawing.Point(317, 167);
            this.outrasDespesasTextBox.Name = "outrasDespesasTextBox";
            this.outrasDespesasTextBox.Size = new System.Drawing.Size(88, 20);
            this.outrasDespesasTextBox.TabIndex = 38;
            this.outrasDespesasTextBox.Leave += new System.EventHandler(this.totalBaseCalculoTextBox_Leave);
            // 
            // totalIPITextBox
            // 
            this.totalIPITextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "totalIPI", true));
            this.totalIPITextBox.Location = new System.Drawing.Point(414, 167);
            this.totalIPITextBox.Name = "totalIPITextBox";
            this.totalIPITextBox.Size = new System.Drawing.Size(72, 20);
            this.totalIPITextBox.TabIndex = 40;
            this.totalIPITextBox.Leave += new System.EventHandler(this.totalBaseCalculoTextBox_Leave);
            // 
            // totalNotaTextBox
            // 
            this.totalNotaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "totalNota", true));
            this.totalNotaTextBox.Location = new System.Drawing.Point(720, 167);
            this.totalNotaTextBox.Name = "totalNotaTextBox";
            this.totalNotaTextBox.Size = new System.Drawing.Size(95, 20);
            this.totalNotaTextBox.TabIndex = 44;
            this.totalNotaTextBox.Leave += new System.EventHandler(this.totalBaseCalculoTextBox_Leave);
            // 
            // tb_entrada_produtoDataGridView
            // 
            this.tb_entrada_produtoDataGridView.AllowUserToAddRows = false;
            this.tb_entrada_produtoDataGridView.AllowUserToDeleteRows = false;
            this.tb_entrada_produtoDataGridView.AutoGenerateColumns = false;
            this.tb_entrada_produtoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_entrada_produtoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.codProduto,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.tb_entrada_produtoDataGridView.DataSource = this.tb_entrada_produtoBindingSource;
            this.tb_entrada_produtoDataGridView.Location = new System.Drawing.Point(9, 193);
            this.tb_entrada_produtoDataGridView.Name = "tb_entrada_produtoDataGridView";
            this.tb_entrada_produtoDataGridView.ReadOnly = true;
            this.tb_entrada_produtoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_entrada_produtoDataGridView.Size = new System.Drawing.Size(806, 182);
            this.tb_entrada_produtoDataGridView.TabIndex = 46;
            this.tb_entrada_produtoDataGridView.TabStop = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "codEntradaProduto";
            this.dataGridViewTextBoxColumn1.HeaderText = "codEntradaProduto";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // codProduto
            // 
            this.codProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.codProduto.DataPropertyName = "codProduto";
            this.codProduto.FillWeight = 25F;
            this.codProduto.HeaderText = "Cód Produto";
            this.codProduto.MinimumWidth = 25;
            this.codProduto.Name = "codProduto";
            this.codProduto.ReadOnly = true;
            this.codProduto.Width = 91;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn18.DataPropertyName = "nomeProduto";
            this.dataGridViewTextBoxColumn18.FillWeight = 200F;
            this.dataGridViewTextBoxColumn18.HeaderText = "Nome Produto";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "cfop";
            this.dataGridViewTextBoxColumn4.HeaderText = "CFOP";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "unidadeCompra";
            this.dataGridViewTextBoxColumn5.HeaderText = "UN";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 48;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "quantidade";
            this.dataGridViewTextBoxColumn6.HeaderText = "Quantidade";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "valorUnitario";
            this.dataGridViewTextBoxColumn8.HeaderText = "Valor Unitário";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "valorTotal";
            this.dataGridViewTextBoxColumn9.HeaderText = "Valor Total";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // tb_produtoTableAdapter
            // 
            this.tb_produtoTableAdapter.ClearBeforeFill = true;
            // 
            // tb_entrada_produtoTableAdapter
            // 
            this.tb_entrada_produtoTableAdapter.ClearBeforeFill = true;
            // 
            // tb_pessoaTableAdapter
            // 
            this.tb_pessoaTableAdapter.ClearBeforeFill = true;
            // 
            // tb_entradaTableAdapter
            // 
            this.tb_entradaTableAdapter.ClearBeforeFill = true;
            // 
            // tb_cfopTableAdapter
            // 
            this.tb_cfopTableAdapter.ClearBeforeFill = true;
            // 
            // fretePagoEmitenteCheckBox
            // 
            this.fretePagoEmitenteCheckBox.Checked = true;
            this.fretePagoEmitenteCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fretePagoEmitenteCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.tb_entradaBindingSource, "fretePagoEmitente", true));
            this.fretePagoEmitenteCheckBox.Location = new System.Drawing.Point(308, 111);
            this.fretePagoEmitenteCheckBox.Name = "fretePagoEmitenteCheckBox";
            this.fretePagoEmitenteCheckBox.Size = new System.Drawing.Size(69, 35);
            this.fretePagoEmitenteCheckBox.TabIndex = 23;
            this.fretePagoEmitenteCheckBox.Text = "Pago Emitente";
            this.fretePagoEmitenteCheckBox.UseVisualStyleBackColor = true;
            // 
            // codSituacaoPagamentosComboBox
            // 
            this.codSituacaoPagamentosComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.tb_entradaBindingSource, "codSituacaoPagamentos", true));
            this.codSituacaoPagamentosComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "descricaoSituacaoPagamentos", true));
            this.codSituacaoPagamentosComboBox.DataSource = this.tbsituacaopagamentosBindingSource;
            this.codSituacaoPagamentosComboBox.DisplayMember = "descricaoSituacaoPagamentos";
            this.codSituacaoPagamentosComboBox.Enabled = false;
            this.codSituacaoPagamentosComboBox.FormattingEnabled = true;
            this.codSituacaoPagamentosComboBox.Location = new System.Drawing.Point(485, 40);
            this.codSituacaoPagamentosComboBox.Name = "codSituacaoPagamentosComboBox";
            this.codSituacaoPagamentosComboBox.Size = new System.Drawing.Size(103, 21);
            this.codSituacaoPagamentosComboBox.TabIndex = 112;
            this.codSituacaoPagamentosComboBox.ValueMember = "codSituacaoPagamentos";
            this.codSituacaoPagamentosComboBox.Visible = false;
            // 
            // tbsituacaopagamentosBindingSource
            // 
            this.tbsituacaopagamentosBindingSource.DataMember = "tb_situacao_pagamentos";
            this.tbsituacaopagamentosBindingSource.DataSource = this.saceDataSet;
            // 
            // tb_situacao_pagamentosTableAdapter
            // 
            this.tb_situacao_pagamentosTableAdapter.ClearBeforeFill = true;
            // 
            // tb_cstTableAdapter
            // 
            this.tb_cstTableAdapter.ClearBeforeFill = true;
            // 
            // totalProdutosSTTextBox
            // 
            this.totalProdutosSTTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_entradaBindingSource, "totalProdutosST", true));
            this.totalProdutosSTTextBox.Location = new System.Drawing.Point(496, 167);
            this.totalProdutosSTTextBox.Name = "totalProdutosSTTextBox";
            this.totalProdutosSTTextBox.Size = new System.Drawing.Size(103, 20);
            this.totalProdutosSTTextBox.TabIndex = 41;
            this.totalProdutosSTTextBox.Leave += new System.EventHandler(this.totalBaseCalculoTextBox_Leave);
            // 
            // FrmEntrada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 608);
            this.ControlBox = false;
            this.Controls.Add(totalProdutosSTLabel);
            this.Controls.Add(this.totalProdutosSTTextBox);
            this.Controls.Add(this.codSituacaoPagamentosComboBox);
            this.Controls.Add(this.fretePagoEmitenteCheckBox);
            this.Controls.Add(descricaoSituacaoPagamentosLabel);
            this.Controls.Add(this.tb_entrada_produtoDataGridView);
            this.Controls.Add(codEntradaLabel);
            this.Controls.Add(this.tb_entradaBindingNavigator);
            this.Controls.Add(this.codEntradaTextBox);
            this.Controls.Add(numeroNotaFiscalLabel);
            this.Controls.Add(this.numeroNotaFiscalTextBox);
            this.Controls.Add(codEmpresaFreteLabel);
            this.Controls.Add(this.codEmpresaFreteComboBox);
            this.Controls.Add(codFornecedorLabel);
            this.Controls.Add(this.codFornecedorComboBox);
            this.Controls.Add(dataEmissaoLabel);
            this.Controls.Add(this.dataEmissaoDateTimePicker);
            this.Controls.Add(dataEntradaLabel);
            this.Controls.Add(this.dataEntradaDateTimePicker);
            this.Controls.Add(totalBaseCalculoLabel);
            this.Controls.Add(this.totalBaseCalculoTextBox);
            this.Controls.Add(totalICMSLabel);
            this.Controls.Add(this.totalICMSTextBox);
            this.Controls.Add(totalBaseSubstituicaoLabel);
            this.Controls.Add(this.totalBaseSubstituicaoTextBox);
            this.Controls.Add(totalSubstituicaoLabel);
            this.Controls.Add(this.totalSubstituicaoTextBox);
            this.Controls.Add(totalProdutosLabel);
            this.Controls.Add(this.totalProdutosTextBox);
            this.Controls.Add(valorFreteLabel);
            this.Controls.Add(this.valorFreteTextBox);
            this.Controls.Add(valorSeguroLabel);
            this.Controls.Add(this.valorSeguroTextBox);
            this.Controls.Add(descontoLabel);
            this.Controls.Add(this.descontoTextBox);
            this.Controls.Add(outrasDespesasLabel);
            this.Controls.Add(this.outrasDespesasTextBox);
            this.Controls.Add(totalIPILabel);
            this.Controls.Add(this.totalIPITextBox);
            this.Controls.Add(totalNotaLabel);
            this.Controls.Add(this.totalNotaTextBox);
            this.Controls.Add(this.totalNotaCalculadoTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnPagamentos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnProdutos);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ProdutosGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "FrmEntrada";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Entrada de Produtos";
            this.Load += new System.EventHandler(this.FrmEntrada_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmEntrada_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ProdutosGroupBox.ResumeLayout(false);
            this.ProdutosGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entrada_produtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcstBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbcfopBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entradaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entradaBindingNavigator)).EndInit();
            this.tb_entradaBindingNavigator.ResumeLayout(false);
            this.tb_entradaBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbpessoaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbpessoaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_entrada_produtoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbsituacaopagamentosBindingSource)).EndInit();
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
        private System.Windows.Forms.Button btnProdutos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPagamentos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox totalNotaCalculadoTextBox;
        private System.Windows.Forms.GroupBox ProdutosGroupBox;
        private Dados.saceDataSet saceDataSet;
        private System.Windows.Forms.BindingSource tb_entradaBindingSource;
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
        private System.Windows.Forms.TextBox numeroNotaFiscalTextBox;
        private System.Windows.Forms.ComboBox codEmpresaFreteComboBox;
        private System.Windows.Forms.ComboBox codFornecedorComboBox;
        private System.Windows.Forms.DateTimePicker dataEmissaoDateTimePicker;
        private System.Windows.Forms.DateTimePicker dataEntradaDateTimePicker;
        private System.Windows.Forms.TextBox totalBaseCalculoTextBox;
        private System.Windows.Forms.TextBox totalICMSTextBox;
        private System.Windows.Forms.TextBox totalBaseSubstituicaoTextBox;
        private System.Windows.Forms.TextBox totalSubstituicaoTextBox;
        private System.Windows.Forms.TextBox totalProdutosTextBox;
        private System.Windows.Forms.TextBox valorFreteTextBox;
        private System.Windows.Forms.TextBox valorSeguroTextBox;
        private System.Windows.Forms.TextBox descontoTextBox;
        private System.Windows.Forms.TextBox outrasDespesasTextBox;
        private System.Windows.Forms.TextBox totalIPITextBox;
        private System.Windows.Forms.TextBox totalNotaTextBox;
        private System.Windows.Forms.DateTimePicker data_validadeDateTimePicker;
        private System.Windows.Forms.BindingSource tb_entrada_produtoBindingSource;
        private System.Windows.Forms.TextBox valorIPITextBox;
        private System.Windows.Forms.TextBox valorICMSSTTextBox;
        private System.Windows.Forms.TextBox valorICMSTextBox;
        private System.Windows.Forms.TextBox baseCalculoICMSSTTextBox;
        private System.Windows.Forms.TextBox baseCalculoICMSTextBox;
        private System.Windows.Forms.TextBox quantidadeEmbalagemTextBox;
        private System.Windows.Forms.TextBox valorTotalTextBox;
        private System.Windows.Forms.TextBox valorUnitarioTextBox;
        private System.Windows.Forms.TextBox quantidadeTextBox;
        private System.Windows.Forms.TextBox unidadeCompraTextBox;
        private System.Windows.Forms.ComboBox codProdutoComboBox;
        private System.Windows.Forms.DataGridView tb_entrada_produtoDataGridView;
        private System.Windows.Forms.TextBox icmsTextBox;
        private System.Windows.Forms.BindingSource tb_produtoBindingSource;
        private System.Windows.Forms.TextBox ncmshTextBox;
        private System.Windows.Forms.TextBox precoVendaAtacadoTextBox;
        private System.Windows.Forms.TextBox qtdProdutoAtacadoTextBox;
        private System.Windows.Forms.TextBox precoVendaVarejoTextBox;
        private System.Windows.Forms.TextBox lucroPrecoVendaVarejoTextBox;
        private System.Windows.Forms.TextBox lucroPrecoVendaAtacadoTextBox;
        private System.Windows.Forms.TextBox simplesTextBox;
        private System.Windows.Forms.TextBox freteTextBox;
        private System.Windows.Forms.TextBox ipiTextBox;
        private System.Windows.Forms.TextBox icms_substitutoTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox precoAtacadoSugestaoTextBox;
        private System.Windows.Forms.TextBox precoVarejoSugestaoTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource tbpessoaBindingSource;
        private System.Windows.Forms.BindingSource tbpessoaBindingSource1;
        private Dados.saceDataSetTableAdapters.tb_produtoTableAdapter tb_produtoTableAdapter;
        private Dados.saceDataSetTableAdapters.tb_entrada_produtoTableAdapter tb_entrada_produtoTableAdapter;
        private Dados.saceDataSetTableAdapters.tb_pessoaTableAdapter tb_pessoaTableAdapter;
        private Dados.saceDataSetTableAdapters.tb_entradaTableAdapter tb_entradaTableAdapter;
        private System.Windows.Forms.TextBox preco_custoTextBox;
        private System.Windows.Forms.ComboBox cfopComboBox;
        private System.Windows.Forms.BindingSource tbcfopBindingSource;
        private Dados.saceDataSetTableAdapters.tb_cfopTableAdapter tb_cfopTableAdapter;
        private System.Windows.Forms.CheckBox fretePagoEmitenteCheckBox;
        private System.Windows.Forms.ComboBox codSituacaoPagamentosComboBox;
        private System.Windows.Forms.BindingSource tbsituacaopagamentosBindingSource;
        private Dados.saceDataSetTableAdapters.tb_situacao_pagamentosTableAdapter tb_situacao_pagamentosTableAdapter;
        private System.Windows.Forms.CheckBox temVencimentoCheckBox;
        private System.Windows.Forms.ComboBox codCSTComboBox;
        private System.Windows.Forms.BindingSource tbcstBindingSource;
        private Dados.saceDataSetTableAdapters.tb_cstTableAdapter tb_cstTableAdapter;
        private System.Windows.Forms.TextBox descontoProdutoTextBox;
        private System.Windows.Forms.TextBox totalProdutosSTTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    }
}