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
            System.Windows.Forms.Label nomeFabricanteLabel;
            System.Windows.Forms.Label codSituacaoProdutoLabel;
            System.Windows.Forms.Label referenciaFabricanteLabel;
            System.Windows.Forms.Label ncmshLabel;
            System.Windows.Forms.Label codCSTLabel;
            System.Windows.Forms.Label precoVendaAtacadoLabel;
            System.Windows.Forms.Label lucroPrecoVendaAtacadoLabel;
            System.Windows.Forms.Label precoVendaVarejoLabel;
            System.Windows.Forms.Label lucroPrecoVendaVarejoLabel;
            System.Windows.Forms.Label ultimaDataAtualizacaoLabel;
            System.Windows.Forms.Label custoVendaLabel;
            System.Windows.Forms.Label freteLabel;
            System.Windows.Forms.Label ipiLabel;
            System.Windows.Forms.Label simplesLabel;
            System.Windows.Forms.Label icmsLabel;
            System.Windows.Forms.Label qtdProdutoAtacadoLabel;
            System.Windows.Forms.Label icms_substitutoLabel;
            System.Windows.Forms.Label dataUltimoPedidoLabel;
            System.Windows.Forms.Label codSubgrupoLabel;
            System.Windows.Forms.Label descontoLabel;
            System.Windows.Forms.Label unidadeCompraLabel;
            System.Windows.Forms.Label quantidadeEmbalagemLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProduto));
            System.Windows.Forms.Label lucroPrecoRevendaLabel;
            System.Windows.Forms.Label precoRevendaSugestaoLabel;
            System.Windows.Forms.Label precoRevendaLabel;
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.codProdutoTextBox = new System.Windows.Forms.TextBox();
            this.produtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.unidadeTextBox = new System.Windows.Forms.TextBox();
            this.codigoBarraTextBox = new System.Windows.Forms.TextBox();
            this.codGrupoComboBox = new System.Windows.Forms.ComboBox();
            this.grupoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codigoFabricanteComboBox = new System.Windows.Forms.ComboBox();
            this.pessoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.temVencimentoCheckBox = new System.Windows.Forms.CheckBox();
            this.exibeNaListagemCheckBox = new System.Windows.Forms.CheckBox();
            this.nomeFabricanteTextBox = new System.Windows.Forms.TextBox();
            this.btnEstoque = new System.Windows.Forms.Button();
            this.codSituacaoProdutoComboBox = new System.Windows.Forms.ComboBox();
            this.situacaoprodutoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.precoVendaAtacadoTextBox = new System.Windows.Forms.TextBox();
            this.lucroPrecoVendaAtacadoTextBox = new System.Windows.Forms.TextBox();
            this.precoVendaVarejoTextBox = new System.Windows.Forms.TextBox();
            this.lucroPrecoVendaVarejoTextBox = new System.Windows.Forms.TextBox();
            this.ultimaDataAtualizacaoDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.ultimoPrecoCompraTextBox = new System.Windows.Forms.TextBox();
            this.freteTextBox = new System.Windows.Forms.TextBox();
            this.ipiTextBox = new System.Windows.Forms.TextBox();
            this.simplesTextBox = new System.Windows.Forms.TextBox();
            this.icmsTextBox = new System.Windows.Forms.TextBox();
            this.qtdProdutoAtacadoTextBox = new System.Windows.Forms.TextBox();
            this.icms_substitutoTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.precoVarejoSugestaoTextBox = new System.Windows.Forms.TextBox();
            this.precoAtacadoSugestaoTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_produto_lojaDataGridView = new System.Windows.Forms.DataGridView();
            this.nomeLoja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdEstoqueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdEstoqueAuxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localizacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localizacao2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.produtoLojaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataUltimoPedidoDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.referenciaFabricanteTextBox = new System.Windows.Forms.TextBox();
            this.ncmshTextBox = new System.Windows.Forms.TextBox();
            this.codCSTComboBox = new System.Windows.Forms.ComboBox();
            this.cstBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.subgrupoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codSubgrupoComboBox = new System.Windows.Forms.ComboBox();
            this.precoCustoTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.descontoTextBox = new System.Windows.Forms.TextBox();
            this.unidadeCompraTextBox = new System.Windows.Forms.TextBox();
            this.quantidadeEmbalagemTextBox = new System.Windows.Forms.TextBox();
            this.lucroPrecoRevendaTextBox = new System.Windows.Forms.TextBox();
            this.precoRevendaSugestaoTextBox = new System.Windows.Forms.TextBox();
            this.precoRevendaTextBox = new System.Windows.Forms.TextBox();
            codProdutoLabel = new System.Windows.Forms.Label();
            nomeLabel = new System.Windows.Forms.Label();
            unidadeLabel = new System.Windows.Forms.Label();
            codigoBarraLabel = new System.Windows.Forms.Label();
            codGrupoLabel = new System.Windows.Forms.Label();
            codigoFabricanteLabel = new System.Windows.Forms.Label();
            nomeFabricanteLabel = new System.Windows.Forms.Label();
            codSituacaoProdutoLabel = new System.Windows.Forms.Label();
            referenciaFabricanteLabel = new System.Windows.Forms.Label();
            ncmshLabel = new System.Windows.Forms.Label();
            codCSTLabel = new System.Windows.Forms.Label();
            precoVendaAtacadoLabel = new System.Windows.Forms.Label();
            lucroPrecoVendaAtacadoLabel = new System.Windows.Forms.Label();
            precoVendaVarejoLabel = new System.Windows.Forms.Label();
            lucroPrecoVendaVarejoLabel = new System.Windows.Forms.Label();
            ultimaDataAtualizacaoLabel = new System.Windows.Forms.Label();
            custoVendaLabel = new System.Windows.Forms.Label();
            freteLabel = new System.Windows.Forms.Label();
            ipiLabel = new System.Windows.Forms.Label();
            simplesLabel = new System.Windows.Forms.Label();
            icmsLabel = new System.Windows.Forms.Label();
            qtdProdutoAtacadoLabel = new System.Windows.Forms.Label();
            icms_substitutoLabel = new System.Windows.Forms.Label();
            dataUltimoPedidoLabel = new System.Windows.Forms.Label();
            codSubgrupoLabel = new System.Windows.Forms.Label();
            descontoLabel = new System.Windows.Forms.Label();
            unidadeCompraLabel = new System.Windows.Forms.Label();
            quantidadeEmbalagemLabel = new System.Windows.Forms.Label();
            lucroPrecoRevendaLabel = new System.Windows.Forms.Label();
            precoRevendaSugestaoLabel = new System.Windows.Forms.Label();
            precoRevendaLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.produtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grupoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pessoaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.situacaoprodutoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produto_lojaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoLojaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cstBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoBindingNavigator)).BeginInit();
            this.tb_produtoBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subgrupoBindingSource)).BeginInit();
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
            unidadeLabel.Location = new System.Drawing.Point(6, 112);
            unidadeLabel.Name = "unidadeLabel";
            unidadeLabel.Size = new System.Drawing.Size(81, 13);
            unidadeLabel.TabIndex = 25;
            unidadeLabel.Text = "Unidade Venda";
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
            codGrupoLabel.Location = new System.Drawing.Point(8, 239);
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
            // nomeFabricanteLabel
            // 
            nomeFabricanteLabel.AutoSize = true;
            nomeFabricanteLabel.Location = new System.Drawing.Point(150, 112);
            nomeFabricanteLabel.Name = "nomeFabricanteLabel";
            nomeFabricanteLabel.Size = new System.Drawing.Size(178, 13);
            nomeFabricanteLabel.TabIndex = 57;
            nomeFabricanteLabel.Text = "Nome Produto conforme Fabricante:";
            // 
            // codSituacaoProdutoLabel
            // 
            codSituacaoProdutoLabel.AutoSize = true;
            codSituacaoProdutoLabel.Location = new System.Drawing.Point(419, 196);
            codSituacaoProdutoLabel.Name = "codSituacaoProdutoLabel";
            codSituacaoProdutoLabel.Size = new System.Drawing.Size(92, 13);
            codSituacaoProdutoLabel.TabIndex = 86;
            codSituacaoProdutoLabel.Text = "Situação Produto:";
            // 
            // referenciaFabricanteLabel
            // 
            referenciaFabricanteLabel.AutoSize = true;
            referenciaFabricanteLabel.Location = new System.Drawing.Point(4, 154);
            referenciaFabricanteLabel.Name = "referenciaFabricanteLabel";
            referenciaFabricanteLabel.Size = new System.Drawing.Size(115, 13);
            referenciaFabricanteLabel.TabIndex = 86;
            referenciaFabricanteLabel.Text = "Referência Fabricante:";
            // 
            // ncmshLabel
            // 
            ncmshLabel.AutoSize = true;
            ncmshLabel.Location = new System.Drawing.Point(8, 283);
            ncmshLabel.Name = "ncmshLabel";
            ncmshLabel.Size = new System.Drawing.Size(54, 13);
            ncmshLabel.TabIndex = 87;
            ncmshLabel.Text = "NCM/SH:";
            // 
            // codCSTLabel
            // 
            codCSTLabel.AutoSize = true;
            codCSTLabel.Location = new System.Drawing.Point(129, 283);
            codCSTLabel.Name = "codCSTLabel";
            codCSTLabel.Size = new System.Drawing.Size(31, 13);
            codCSTLabel.TabIndex = 88;
            codCSTLabel.Text = "CST:";
            codCSTLabel.Click += new System.EventHandler(this.codCSTLabel_Click);
            // 
            // precoVendaAtacadoLabel
            // 
            precoVendaAtacadoLabel.AutoSize = true;
            precoVendaAtacadoLabel.Location = new System.Drawing.Point(464, 423);
            precoVendaAtacadoLabel.Name = "precoVendaAtacadoLabel";
            precoVendaAtacadoLabel.Size = new System.Drawing.Size(81, 13);
            precoVendaAtacadoLabel.TabIndex = 65;
            precoVendaAtacadoLabel.Text = "Preço Atacado:";
            // 
            // lucroPrecoVendaAtacadoLabel
            // 
            lucroPrecoVendaAtacadoLabel.AutoSize = true;
            lucroPrecoVendaAtacadoLabel.Location = new System.Drawing.Point(235, 423);
            lucroPrecoVendaAtacadoLabel.Name = "lucroPrecoVendaAtacadoLabel";
            lucroPrecoVendaAtacadoLabel.Size = new System.Drawing.Size(91, 13);
            lucroPrecoVendaAtacadoLabel.TabIndex = 63;
            lucroPrecoVendaAtacadoLabel.Text = "% Lucro Atacado:";
            // 
            // precoVendaVarejoLabel
            // 
            precoVendaVarejoLabel.AutoSize = true;
            precoVendaVarejoLabel.Location = new System.Drawing.Point(464, 380);
            precoVendaVarejoLabel.Name = "precoVendaVarejoLabel";
            precoVendaVarejoLabel.Size = new System.Drawing.Size(71, 13);
            precoVendaVarejoLabel.TabIndex = 61;
            precoVendaVarejoLabel.Text = "Preço Varejo:";
            // 
            // lucroPrecoVendaVarejoLabel
            // 
            lucroPrecoVendaVarejoLabel.AutoSize = true;
            lucroPrecoVendaVarejoLabel.Location = new System.Drawing.Point(235, 380);
            lucroPrecoVendaVarejoLabel.Name = "lucroPrecoVendaVarejoLabel";
            lucroPrecoVendaVarejoLabel.Size = new System.Drawing.Size(81, 13);
            lucroPrecoVendaVarejoLabel.TabIndex = 59;
            lucroPrecoVendaVarejoLabel.Text = "% Lucro Varejo:";
            // 
            // ultimaDataAtualizacaoLabel
            // 
            ultimaDataAtualizacaoLabel.AutoSize = true;
            ultimaDataAtualizacaoLabel.Location = new System.Drawing.Point(7, 422);
            ultimaDataAtualizacaoLabel.Name = "ultimaDataAtualizacaoLabel";
            ultimaDataAtualizacaoLabel.Size = new System.Drawing.Size(97, 13);
            ultimaDataAtualizacaoLabel.TabIndex = 53;
            ultimaDataAtualizacaoLabel.Text = "Última Atualizacao:";
            // 
            // custoVendaLabel
            // 
            custoVendaLabel.AutoSize = true;
            custoVendaLabel.Location = new System.Drawing.Point(7, 381);
            custoVendaLabel.Name = "custoVendaLabel";
            custoVendaLabel.Size = new System.Drawing.Size(109, 13);
            custoVendaLabel.TabIndex = 45;
            custoVendaLabel.Text = "Último Preço Compra:";
            // 
            // freteLabel
            // 
            freteLabel.AutoSize = true;
            freteLabel.Location = new System.Drawing.Point(461, 333);
            freteLabel.Name = "freteLabel";
            freteLabel.Size = new System.Drawing.Size(45, 13);
            freteLabel.TabIndex = 43;
            freteLabel.Text = "% Frete:";
            // 
            // ipiLabel
            // 
            ipiLabel.AutoSize = true;
            ipiLabel.Location = new System.Drawing.Point(392, 332);
            ipiLabel.Name = "ipiLabel";
            ipiLabel.Size = new System.Drawing.Size(34, 13);
            ipiLabel.TabIndex = 41;
            ipiLabel.Text = "% IPI:";
            // 
            // simplesLabel
            // 
            simplesLabel.AutoSize = true;
            simplesLabel.Location = new System.Drawing.Point(304, 333);
            simplesLabel.Name = "simplesLabel";
            simplesLabel.Size = new System.Drawing.Size(57, 13);
            simplesLabel.TabIndex = 39;
            simplesLabel.Text = "% Simples:";
            // 
            // icmsLabel
            // 
            icmsLabel.AutoSize = true;
            icmsLabel.Location = new System.Drawing.Point(124, 332);
            icmsLabel.Name = "icmsLabel";
            icmsLabel.Size = new System.Drawing.Size(72, 13);
            icmsLabel.TabIndex = 37;
            icmsLabel.Text = "%Cred  ICMS:";
            // 
            // qtdProdutoAtacadoLabel
            // 
            qtdProdutoAtacadoLabel.AutoSize = true;
            qtdProdutoAtacadoLabel.Location = new System.Drawing.Point(121, 424);
            qtdProdutoAtacadoLabel.Name = "qtdProdutoAtacadoLabel";
            qtdProdutoAtacadoLabel.Size = new System.Drawing.Size(101, 13);
            qtdProdutoAtacadoLabel.TabIndex = 72;
            qtdProdutoAtacadoLabel.Text = "Qtd Preço Atacado:";
            // 
            // icms_substitutoLabel
            // 
            icms_substitutoLabel.AutoSize = true;
            icms_substitutoLabel.Location = new System.Drawing.Point(222, 333);
            icms_substitutoLabel.Name = "icms_substitutoLabel";
            icms_substitutoLabel.Size = new System.Drawing.Size(77, 13);
            icms_substitutoLabel.TabIndex = 76;
            icms_substitutoLabel.Text = "% ICMS Subst:";
            // 
            // dataUltimoPedidoLabel
            // 
            dataUltimoPedidoLabel.AutoSize = true;
            dataUltimoPedidoLabel.Location = new System.Drawing.Point(7, 329);
            dataUltimoPedidoLabel.Name = "dataUltimoPedidoLabel";
            dataUltimoPedidoLabel.Size = new System.Drawing.Size(101, 13);
            dataUltimoPedidoLabel.TabIndex = 84;
            dataUltimoPedidoLabel.Text = "Data Último Pedido:";
            // 
            // codSubgrupoLabel
            // 
            codSubgrupoLabel.AutoSize = true;
            codSubgrupoLabel.Location = new System.Drawing.Point(285, 238);
            codSubgrupoLabel.Name = "codSubgrupoLabel";
            codSubgrupoLabel.Size = new System.Drawing.Size(56, 13);
            codSubgrupoLabel.TabIndex = 89;
            codSubgrupoLabel.Text = "Subgrupo:";
            // 
            // descontoLabel
            // 
            descontoLabel.AutoSize = true;
            descontoLabel.Location = new System.Drawing.Point(528, 332);
            descontoLabel.Name = "descontoLabel";
            descontoLabel.Size = new System.Drawing.Size(67, 13);
            descontoLabel.TabIndex = 91;
            descontoLabel.Text = "% Desconto:";
            // 
            // unidadeCompraLabel
            // 
            unidadeCompraLabel.AutoSize = true;
            unidadeCompraLabel.Location = new System.Drawing.Point(150, 196);
            unidadeCompraLabel.Name = "unidadeCompraLabel";
            unidadeCompraLabel.Size = new System.Drawing.Size(89, 13);
            unidadeCompraLabel.TabIndex = 91;
            unidadeCompraLabel.Text = "Unidade Compra:";
            // 
            // quantidadeEmbalagemLabel
            // 
            quantidadeEmbalagemLabel.AutoSize = true;
            quantidadeEmbalagemLabel.Location = new System.Drawing.Point(284, 195);
            quantidadeEmbalagemLabel.Name = "quantidadeEmbalagemLabel";
            quantidadeEmbalagemLabel.Size = new System.Drawing.Size(123, 13);
            quantidadeEmbalagemLabel.TabIndex = 92;
            quantidadeEmbalagemLabel.Text = "Quantidade Embalagem:";
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
            this.panel1.Size = new System.Drawing.Size(608, 41);
            this.panel1.TabIndex = 20;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(310, 594);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(10, 594);
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
            this.btnCancelar.Location = new System.Drawing.Point(472, 594);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(85, 594);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 23);
            this.btnNovo.TabIndex = 1;
            this.btnNovo.Text = "F3 - Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(235, 594);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "F5 - Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(160, 594);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "F4 - Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // codProdutoTextBox
            // 
            this.codProdutoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "CodProduto", true));
            this.codProdutoTextBox.Enabled = false;
            this.codProdutoTextBox.Location = new System.Drawing.Point(7, 89);
            this.codProdutoTextBox.Name = "codProdutoTextBox";
            this.codProdutoTextBox.Size = new System.Drawing.Size(134, 20);
            this.codProdutoTextBox.TabIndex = 7;
            this.codProdutoTextBox.TextChanged += new System.EventHandler(this.codProdutoTextBox_TextChanged);
            this.codProdutoTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.codProdutoTextBox.Leave += new System.EventHandler(this.codProdutoTextBox_Leave);
            // 
            // produtoBindingSource
            // 
            this.produtoBindingSource.DataSource = typeof(Dominio.Produto);
            this.produtoBindingSource.Sort = "codProduto";
            this.produtoBindingSource.CurrentItemChanged += new System.EventHandler(this.produtoBindingSource_CurrentItemChanged);
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "Nome", true));
            this.nomeTextBox.Location = new System.Drawing.Point(150, 90);
            this.nomeTextBox.MaxLength = 50;
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.Size = new System.Drawing.Size(446, 20);
            this.nomeTextBox.TabIndex = 9;
            this.nomeTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.nomeTextBox.Leave += new System.EventHandler(this.nomeTextBox_Leave);
            // 
            // unidadeTextBox
            // 
            this.unidadeTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.unidadeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "Unidade", true));
            this.unidadeTextBox.Location = new System.Drawing.Point(7, 129);
            this.unidadeTextBox.MaxLength = 2;
            this.unidadeTextBox.Name = "unidadeTextBox";
            this.unidadeTextBox.Size = new System.Drawing.Size(134, 20);
            this.unidadeTextBox.TabIndex = 11;
            this.unidadeTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.unidadeTextBox.Leave += new System.EventHandler(this.codProdutoTextBox_Leave);
            // 
            // codigoBarraTextBox
            // 
            this.codigoBarraTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.codigoBarraTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "CodigoBarra", true));
            this.codigoBarraTextBox.Location = new System.Drawing.Point(10, 213);
            this.codigoBarraTextBox.MaxLength = 40;
            this.codigoBarraTextBox.Name = "codigoBarraTextBox";
            this.codigoBarraTextBox.Size = new System.Drawing.Size(134, 20);
            this.codigoBarraTextBox.TabIndex = 21;
            this.codigoBarraTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.codigoBarraTextBox.Leave += new System.EventHandler(this.codProdutoTextBox_Leave);
            // 
            // codGrupoComboBox
            // 
            this.codGrupoComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codGrupoComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codGrupoComboBox.CausesValidation = false;
            this.codGrupoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.produtoBindingSource, "CodGrupo", true));
            this.codGrupoComboBox.DataSource = this.grupoBindingSource;
            this.codGrupoComboBox.DisplayMember = "descricao";
            this.codGrupoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codGrupoComboBox.FormattingEnabled = true;
            this.codGrupoComboBox.Location = new System.Drawing.Point(7, 258);
            this.codGrupoComboBox.Name = "codGrupoComboBox";
            this.codGrupoComboBox.Size = new System.Drawing.Size(274, 21);
            this.codGrupoComboBox.TabIndex = 29;
            this.codGrupoComboBox.ValueMember = "codGrupo";
            this.codGrupoComboBox.SelectedIndexChanged += new System.EventHandler(this.codGrupoComboBox_SelectedIndexChanged);
            this.codGrupoComboBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.codGrupoComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codigoFabricanteComboBox_KeyPress);
            this.codGrupoComboBox.Leave += new System.EventHandler(this.codProdutoTextBox_Leave);
            // 
            // grupoBindingSource
            // 
            this.grupoBindingSource.DataSource = typeof(Dominio.Grupo);
            // 
            // codigoFabricanteComboBox
            // 
            this.codigoFabricanteComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codigoFabricanteComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codigoFabricanteComboBox.CausesValidation = false;
            this.codigoFabricanteComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.produtoBindingSource, "CodFabricante", true));
            this.codigoFabricanteComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "NomeFabricante", true));
            this.codigoFabricanteComboBox.DataSource = this.pessoaBindingSource;
            this.codigoFabricanteComboBox.DisplayMember = "NomeFantasia";
            this.codigoFabricanteComboBox.FormattingEnabled = true;
            this.codigoFabricanteComboBox.Location = new System.Drawing.Point(150, 170);
            this.codigoFabricanteComboBox.Name = "codigoFabricanteComboBox";
            this.codigoFabricanteComboBox.Size = new System.Drawing.Size(446, 21);
            this.codigoFabricanteComboBox.TabIndex = 17;
            this.codigoFabricanteComboBox.ValueMember = "CodPessoa";
            this.codigoFabricanteComboBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.codigoFabricanteComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codigoFabricanteComboBox_KeyPress);
            this.codigoFabricanteComboBox.Leave += new System.EventHandler(this.codigoFabricanteComboBox_Leave);
            // 
            // pessoaBindingSource
            // 
            this.pessoaBindingSource.AllowNew = false;
            this.pessoaBindingSource.DataSource = typeof(Dominio.Pessoa);
            // 
            // temVencimentoCheckBox
            // 
            this.temVencimentoCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.produtoBindingSource, "TemVencimento", true));
            this.temVencimentoCheckBox.Location = new System.Drawing.Point(124, 475);
            this.temVencimentoCheckBox.Name = "temVencimentoCheckBox";
            this.temVencimentoCheckBox.Size = new System.Drawing.Size(125, 24);
            this.temVencimentoCheckBox.TabIndex = 78;
            this.temVencimentoCheckBox.Text = "Possui Vencimento";
            this.temVencimentoCheckBox.UseVisualStyleBackColor = true;
            // 
            // exibeNaListagemCheckBox
            // 
            this.exibeNaListagemCheckBox.Checked = true;
            this.exibeNaListagemCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.exibeNaListagemCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.produtoBindingSource, "ExibeNaListagem", true));
            this.exibeNaListagemCheckBox.Location = new System.Drawing.Point(10, 475);
            this.exibeNaListagemCheckBox.Name = "exibeNaListagemCheckBox";
            this.exibeNaListagemCheckBox.Size = new System.Drawing.Size(101, 24);
            this.exibeNaListagemCheckBox.TabIndex = 76;
            this.exibeNaListagemCheckBox.Text = "Exibir Listagem";
            this.exibeNaListagemCheckBox.UseVisualStyleBackColor = true;
            // 
            // nomeFabricanteTextBox
            // 
            this.nomeFabricanteTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.nomeFabricanteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "NomeProdutoFabricante", true));
            this.nomeFabricanteTextBox.Location = new System.Drawing.Point(150, 129);
            this.nomeFabricanteTextBox.MaxLength = 50;
            this.nomeFabricanteTextBox.Name = "nomeFabricanteTextBox";
            this.nomeFabricanteTextBox.Size = new System.Drawing.Size(446, 20);
            this.nomeFabricanteTextBox.TabIndex = 13;
            this.nomeFabricanteTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.nomeFabricanteTextBox.Leave += new System.EventHandler(this.nomeFabricanteTextBox_Leave);
            // 
            // btnEstoque
            // 
            this.btnEstoque.Location = new System.Drawing.Point(391, 594);
            this.btnEstoque.Name = "btnEstoque";
            this.btnEstoque.Size = new System.Drawing.Size(81, 23);
            this.btnEstoque.TabIndex = 84;
            this.btnEstoque.Text = "F7 - Estoque";
            this.btnEstoque.UseVisualStyleBackColor = true;
            this.btnEstoque.Click += new System.EventHandler(this.btnEstoque_Click);
            // 
            // codSituacaoProdutoComboBox
            // 
            this.codSituacaoProdutoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.produtoBindingSource, "CodSituacaoProduto", true));
            this.codSituacaoProdutoComboBox.DataSource = this.situacaoprodutoBindingSource;
            this.codSituacaoProdutoComboBox.DisplayMember = "DescricaoSituacao";
            this.codSituacaoProdutoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codSituacaoProdutoComboBox.FormattingEnabled = true;
            this.codSituacaoProdutoComboBox.Location = new System.Drawing.Point(422, 213);
            this.codSituacaoProdutoComboBox.Name = "codSituacaoProdutoComboBox";
            this.codSituacaoProdutoComboBox.Size = new System.Drawing.Size(172, 21);
            this.codSituacaoProdutoComboBox.TabIndex = 27;
            this.codSituacaoProdutoComboBox.ValueMember = "CodSituacaoProduto";
            this.codSituacaoProdutoComboBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.codSituacaoProdutoComboBox.Leave += new System.EventHandler(this.codProdutoTextBox_Leave);
            // 
            // situacaoprodutoBindingSource
            // 
            this.situacaoprodutoBindingSource.DataSource = typeof(Dominio.SituacaoProduto);
            // 
            // precoVendaAtacadoTextBox
            // 
            this.precoVendaAtacadoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "PrecoVendaAtacado", true));
            this.precoVendaAtacadoTextBox.ForeColor = System.Drawing.Color.Red;
            this.precoVendaAtacadoTextBox.Location = new System.Drawing.Point(467, 440);
            this.precoVendaAtacadoTextBox.Name = "precoVendaAtacadoTextBox";
            this.precoVendaAtacadoTextBox.Size = new System.Drawing.Size(127, 20);
            this.precoVendaAtacadoTextBox.TabIndex = 74;
            this.precoVendaAtacadoTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.precoVendaAtacadoTextBox.Leave += new System.EventHandler(this.precoVendaAtacadoTextBox_Leave);
            // 
            // lucroPrecoVendaAtacadoTextBox
            // 
            this.lucroPrecoVendaAtacadoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "LucroPrecoVendaAtacado", true));
            this.lucroPrecoVendaAtacadoTextBox.Location = new System.Drawing.Point(238, 440);
            this.lucroPrecoVendaAtacadoTextBox.Name = "lucroPrecoVendaAtacadoTextBox";
            this.lucroPrecoVendaAtacadoTextBox.Size = new System.Drawing.Size(82, 20);
            this.lucroPrecoVendaAtacadoTextBox.TabIndex = 70;
            this.lucroPrecoVendaAtacadoTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.lucroPrecoVendaAtacadoTextBox.Leave += new System.EventHandler(this.icmsTextBox_Leave_1);
            // 
            // precoVendaVarejoTextBox
            // 
            this.precoVendaVarejoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "PrecoVendaVarejo", true));
            this.precoVendaVarejoTextBox.ForeColor = System.Drawing.Color.Red;
            this.precoVendaVarejoTextBox.Location = new System.Drawing.Point(467, 399);
            this.precoVendaVarejoTextBox.Name = "precoVendaVarejoTextBox";
            this.precoVendaVarejoTextBox.Size = new System.Drawing.Size(127, 20);
            this.precoVendaVarejoTextBox.TabIndex = 64;
            this.precoVendaVarejoTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.precoVendaVarejoTextBox.Leave += new System.EventHandler(this.precoVendaVarejoTextBox_Leave);
            // 
            // lucroPrecoVendaVarejoTextBox
            // 
            this.lucroPrecoVendaVarejoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "LucroPrecoVendaVarejo", true));
            this.lucroPrecoVendaVarejoTextBox.Location = new System.Drawing.Point(237, 397);
            this.lucroPrecoVendaVarejoTextBox.Name = "lucroPrecoVendaVarejoTextBox";
            this.lucroPrecoVendaVarejoTextBox.Size = new System.Drawing.Size(83, 20);
            this.lucroPrecoVendaVarejoTextBox.TabIndex = 60;
            this.lucroPrecoVendaVarejoTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.lucroPrecoVendaVarejoTextBox.Leave += new System.EventHandler(this.icmsTextBox_Leave_1);
            // 
            // ultimaDataAtualizacaoDateTimePicker
            // 
            this.ultimaDataAtualizacaoDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "UltimaDataAtualizacao", true));
            this.ultimaDataAtualizacaoDateTimePicker.Enabled = false;
            this.ultimaDataAtualizacaoDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.ultimaDataAtualizacaoDateTimePicker.Location = new System.Drawing.Point(10, 440);
            this.ultimaDataAtualizacaoDateTimePicker.Name = "ultimaDataAtualizacaoDateTimePicker";
            this.ultimaDataAtualizacaoDateTimePicker.Size = new System.Drawing.Size(112, 20);
            this.ultimaDataAtualizacaoDateTimePicker.TabIndex = 66;
            this.ultimaDataAtualizacaoDateTimePicker.TabStop = false;
            this.ultimaDataAtualizacaoDateTimePicker.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.ultimaDataAtualizacaoDateTimePicker.Leave += new System.EventHandler(this.codProdutoTextBox_Leave);
            // 
            // ultimoPrecoCompraTextBox
            // 
            this.ultimoPrecoCompraTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "UltimoPrecoCompra", true));
            this.ultimoPrecoCompraTextBox.Location = new System.Drawing.Point(10, 397);
            this.ultimoPrecoCompraTextBox.Name = "ultimoPrecoCompraTextBox";
            this.ultimoPrecoCompraTextBox.Size = new System.Drawing.Size(106, 20);
            this.ultimoPrecoCompraTextBox.TabIndex = 56;
            this.ultimoPrecoCompraTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.ultimoPrecoCompraTextBox.Leave += new System.EventHandler(this.icmsTextBox_Leave_1);
            // 
            // freteTextBox
            // 
            this.freteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "Frete", true));
            this.freteTextBox.Location = new System.Drawing.Point(464, 349);
            this.freteTextBox.Name = "freteTextBox";
            this.freteTextBox.Size = new System.Drawing.Size(60, 20);
            this.freteTextBox.TabIndex = 52;
            this.freteTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.freteTextBox.Leave += new System.EventHandler(this.icmsTextBox_Leave_1);
            // 
            // ipiTextBox
            // 
            this.ipiTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "Ipi", true));
            this.ipiTextBox.Location = new System.Drawing.Point(395, 349);
            this.ipiTextBox.Name = "ipiTextBox";
            this.ipiTextBox.Size = new System.Drawing.Size(60, 20);
            this.ipiTextBox.TabIndex = 50;
            this.ipiTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.ipiTextBox.Leave += new System.EventHandler(this.icmsTextBox_Leave_1);
            // 
            // simplesTextBox
            // 
            this.simplesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "Simples", true));
            this.simplesTextBox.Location = new System.Drawing.Point(307, 349);
            this.simplesTextBox.Name = "simplesTextBox";
            this.simplesTextBox.Size = new System.Drawing.Size(73, 20);
            this.simplesTextBox.TabIndex = 48;
            this.simplesTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.simplesTextBox.Leave += new System.EventHandler(this.icmsTextBox_Leave_1);
            // 
            // icmsTextBox
            // 
            this.icmsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "Icms", true));
            this.icmsTextBox.Location = new System.Drawing.Point(126, 349);
            this.icmsTextBox.Name = "icmsTextBox";
            this.icmsTextBox.Size = new System.Drawing.Size(81, 20);
            this.icmsTextBox.TabIndex = 44;
            this.icmsTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.icmsTextBox.Leave += new System.EventHandler(this.icmsTextBox_Leave_1);
            // 
            // qtdProdutoAtacadoTextBox
            // 
            this.qtdProdutoAtacadoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "QtdProdutoAtacado", true));
            this.qtdProdutoAtacadoTextBox.Location = new System.Drawing.Point(126, 441);
            this.qtdProdutoAtacadoTextBox.MaxLength = 8;
            this.qtdProdutoAtacadoTextBox.Name = "qtdProdutoAtacadoTextBox";
            this.qtdProdutoAtacadoTextBox.Size = new System.Drawing.Size(106, 20);
            this.qtdProdutoAtacadoTextBox.TabIndex = 68;
            this.qtdProdutoAtacadoTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.qtdProdutoAtacadoTextBox.Leave += new System.EventHandler(this.icmsTextBox_Leave_1);
            // 
            // icms_substitutoTextBox
            // 
            this.icms_substitutoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "IcmsSubstituto", true));
            this.icms_substitutoTextBox.Location = new System.Drawing.Point(225, 349);
            this.icms_substitutoTextBox.Name = "icms_substitutoTextBox";
            this.icms_substitutoTextBox.Size = new System.Drawing.Size(74, 20);
            this.icms_substitutoTextBox.TabIndex = 46;
            this.icms_substitutoTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.icms_substitutoTextBox.Leave += new System.EventHandler(this.icmsTextBox_Leave_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(328, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 78;
            this.label2.Text = "Preço Varejo Sugestão:";
            // 
            // precoVarejoSugestaoTextBox
            // 
            this.precoVarejoSugestaoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "PrecoVendaVarejoSugestao", true));
            this.precoVarejoSugestaoTextBox.Location = new System.Drawing.Point(329, 399);
            this.precoVarejoSugestaoTextBox.Name = "precoVarejoSugestaoTextBox";
            this.precoVarejoSugestaoTextBox.ReadOnly = true;
            this.precoVarejoSugestaoTextBox.Size = new System.Drawing.Size(129, 20);
            this.precoVarejoSugestaoTextBox.TabIndex = 62;
            this.precoVarejoSugestaoTextBox.TabStop = false;
            this.precoVarejoSugestaoTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.precoVarejoSugestaoTextBox.Leave += new System.EventHandler(this.codProdutoTextBox_Leave);
            // 
            // precoAtacadoSugestaoTextBox
            // 
            this.precoAtacadoSugestaoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "PrecoVendaAtacadoSugestao", true));
            this.precoAtacadoSugestaoTextBox.Location = new System.Drawing.Point(329, 440);
            this.precoAtacadoSugestaoTextBox.Name = "precoAtacadoSugestaoTextBox";
            this.precoAtacadoSugestaoTextBox.ReadOnly = true;
            this.precoAtacadoSugestaoTextBox.Size = new System.Drawing.Size(129, 20);
            this.precoAtacadoSugestaoTextBox.TabIndex = 72;
            this.precoAtacadoSugestaoTextBox.TabStop = false;
            this.precoAtacadoSugestaoTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.precoAtacadoSugestaoTextBox.Leave += new System.EventHandler(this.codProdutoTextBox_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(329, 423);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 81;
            this.label3.Text = "Preço Atacado Sugestão:";
            // 
            // tb_produto_lojaDataGridView
            // 
            this.tb_produto_lojaDataGridView.AllowUserToAddRows = false;
            this.tb_produto_lojaDataGridView.AllowUserToDeleteRows = false;
            this.tb_produto_lojaDataGridView.AutoGenerateColumns = false;
            this.tb_produto_lojaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_produto_lojaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nomeLoja,
            this.qtdEstoqueDataGridViewTextBoxColumn,
            this.qtdEstoqueAuxDataGridViewTextBoxColumn,
            this.localizacaoDataGridViewTextBoxColumn,
            this.localizacao2DataGridViewTextBoxColumn});
            this.tb_produto_lojaDataGridView.DataSource = this.produtoLojaBindingSource;
            this.tb_produto_lojaDataGridView.Location = new System.Drawing.Point(12, 505);
            this.tb_produto_lojaDataGridView.MultiSelect = false;
            this.tb_produto_lojaDataGridView.Name = "tb_produto_lojaDataGridView";
            this.tb_produto_lojaDataGridView.ReadOnly = true;
            this.tb_produto_lojaDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_produto_lojaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_produto_lojaDataGridView.Size = new System.Drawing.Size(584, 83);
            this.tb_produto_lojaDataGridView.TabIndex = 86;
            this.tb_produto_lojaDataGridView.TabStop = false;
            // 
            // nomeLoja
            // 
            this.nomeLoja.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomeLoja.DataPropertyName = "NomeLoja";
            this.nomeLoja.HeaderText = "Loja";
            this.nomeLoja.Name = "nomeLoja";
            this.nomeLoja.ReadOnly = true;
            // 
            // qtdEstoqueDataGridViewTextBoxColumn
            // 
            this.qtdEstoqueDataGridViewTextBoxColumn.DataPropertyName = "QtdEstoque";
            this.qtdEstoqueDataGridViewTextBoxColumn.HeaderText = "Estoque";
            this.qtdEstoqueDataGridViewTextBoxColumn.Name = "qtdEstoqueDataGridViewTextBoxColumn";
            this.qtdEstoqueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtdEstoqueAuxDataGridViewTextBoxColumn
            // 
            this.qtdEstoqueAuxDataGridViewTextBoxColumn.DataPropertyName = "QtdEstoqueAux";
            this.qtdEstoqueAuxDataGridViewTextBoxColumn.HeaderText = "Estoque Aux";
            this.qtdEstoqueAuxDataGridViewTextBoxColumn.Name = "qtdEstoqueAuxDataGridViewTextBoxColumn";
            this.qtdEstoqueAuxDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // localizacaoDataGridViewTextBoxColumn
            // 
            this.localizacaoDataGridViewTextBoxColumn.DataPropertyName = "Localizacao";
            this.localizacaoDataGridViewTextBoxColumn.HeaderText = "Localizacao";
            this.localizacaoDataGridViewTextBoxColumn.Name = "localizacaoDataGridViewTextBoxColumn";
            this.localizacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // localizacao2DataGridViewTextBoxColumn
            // 
            this.localizacao2DataGridViewTextBoxColumn.DataPropertyName = "Localizacao2";
            this.localizacao2DataGridViewTextBoxColumn.HeaderText = "Localizacao 2";
            this.localizacao2DataGridViewTextBoxColumn.Name = "localizacao2DataGridViewTextBoxColumn";
            this.localizacao2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // produtoLojaBindingSource
            // 
            this.produtoLojaBindingSource.DataSource = typeof(Dominio.ProdutoLoja);
            // 
            // dataUltimoPedidoDateTimePicker
            // 
            this.dataUltimoPedidoDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.produtoBindingSource, "DataUltimoPedido", true));
            this.dataUltimoPedidoDateTimePicker.Enabled = false;
            this.dataUltimoPedidoDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataUltimoPedidoDateTimePicker.Location = new System.Drawing.Point(9, 346);
            this.dataUltimoPedidoDateTimePicker.Name = "dataUltimoPedidoDateTimePicker";
            this.dataUltimoPedidoDateTimePicker.Size = new System.Drawing.Size(107, 20);
            this.dataUltimoPedidoDateTimePicker.TabIndex = 42;
            this.dataUltimoPedidoDateTimePicker.TabStop = false;
            this.dataUltimoPedidoDateTimePicker.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.dataUltimoPedidoDateTimePicker.Leave += new System.EventHandler(this.codProdutoTextBox_Leave);
            // 
            // referenciaFabricanteTextBox
            // 
            this.referenciaFabricanteTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.referenciaFabricanteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "ReferenciaFabricante", true));
            this.referenciaFabricanteTextBox.Location = new System.Drawing.Point(7, 171);
            this.referenciaFabricanteTextBox.MaxLength = 20;
            this.referenciaFabricanteTextBox.Name = "referenciaFabricanteTextBox";
            this.referenciaFabricanteTextBox.Size = new System.Drawing.Size(134, 20);
            this.referenciaFabricanteTextBox.TabIndex = 15;
            this.referenciaFabricanteTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.referenciaFabricanteTextBox.Leave += new System.EventHandler(this.codProdutoTextBox_Leave);
            // 
            // ncmshTextBox
            // 
            this.ncmshTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ncmshTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "Ncmsh", true));
            this.ncmshTextBox.Location = new System.Drawing.Point(7, 300);
            this.ncmshTextBox.MaxLength = 8;
            this.ncmshTextBox.Name = "ncmshTextBox";
            this.ncmshTextBox.Size = new System.Drawing.Size(109, 20);
            this.ncmshTextBox.TabIndex = 38;
            this.ncmshTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.ncmshTextBox.Leave += new System.EventHandler(this.codProdutoTextBox_Leave);
            // 
            // codCSTComboBox
            // 
            this.codCSTComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codCSTComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codCSTComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.produtoBindingSource, "CodCST", true));
            this.codCSTComboBox.DataSource = this.cstBindingSource;
            this.codCSTComboBox.DisplayMember = "Descricao";
            this.codCSTComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codCSTComboBox.FormattingEnabled = true;
            this.codCSTComboBox.Location = new System.Drawing.Point(126, 299);
            this.codCSTComboBox.Name = "codCSTComboBox";
            this.codCSTComboBox.Size = new System.Drawing.Size(468, 21);
            this.codCSTComboBox.TabIndex = 40;
            this.codCSTComboBox.ValueMember = "CodCST";
            this.codCSTComboBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.codCSTComboBox.Leave += new System.EventHandler(this.codProdutoTextBox_Leave);
            // 
            // cstBindingSource
            // 
            this.cstBindingSource.DataSource = typeof(Dominio.Cst);
            // 
            // tb_produtoBindingNavigator
            // 
            this.tb_produtoBindingNavigator.AddNewItem = null;
            this.tb_produtoBindingNavigator.BindingSource = this.produtoBindingSource;
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
            this.tb_produtoBindingNavigator.Location = new System.Drawing.Point(403, 40);
            this.tb_produtoBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tb_produtoBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tb_produtoBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tb_produtoBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tb_produtoBindingNavigator.Name = "tb_produtoBindingNavigator";
            this.tb_produtoBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tb_produtoBindingNavigator.Size = new System.Drawing.Size(209, 25);
            this.tb_produtoBindingNavigator.TabIndex = 89;
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
            // subgrupoBindingSource
            // 
            this.subgrupoBindingSource.DataSource = typeof(Dominio.Subgrupo);
            // 
            // codSubgrupoComboBox
            // 
            this.codSubgrupoComboBox.CausesValidation = false;
            this.codSubgrupoComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.produtoBindingSource, "codSubgrupo", true));
            this.codSubgrupoComboBox.DataSource = this.subgrupoBindingSource;
            this.codSubgrupoComboBox.DisplayMember = "descricao";
            this.codSubgrupoComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codSubgrupoComboBox.FormattingEnabled = true;
            this.codSubgrupoComboBox.Location = new System.Drawing.Point(287, 258);
            this.codSubgrupoComboBox.Name = "codSubgrupoComboBox";
            this.codSubgrupoComboBox.Size = new System.Drawing.Size(309, 21);
            this.codSubgrupoComboBox.TabIndex = 31;
            this.codSubgrupoComboBox.ValueMember = "codSubgrupo";
            this.codSubgrupoComboBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.codSubgrupoComboBox.Leave += new System.EventHandler(this.codProdutoTextBox_Leave);
            // 
            // precoCustoTextBox
            // 
            this.precoCustoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "PrecoCusto", true));
            this.precoCustoTextBox.Location = new System.Drawing.Point(124, 397);
            this.precoCustoTextBox.Name = "precoCustoTextBox";
            this.precoCustoTextBox.ReadOnly = true;
            this.precoCustoTextBox.Size = new System.Drawing.Size(108, 20);
            this.precoCustoTextBox.TabIndex = 58;
            this.precoCustoTextBox.TabStop = false;
            this.precoCustoTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.precoCustoTextBox.Leave += new System.EventHandler(this.codProdutoTextBox_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 380);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 91;
            this.label4.Text = "Preço Custo:";
            // 
            // descontoTextBox
            // 
            this.descontoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "Desconto", true));
            this.descontoTextBox.Location = new System.Drawing.Point(531, 350);
            this.descontoTextBox.Name = "descontoTextBox";
            this.descontoTextBox.Size = new System.Drawing.Size(65, 20);
            this.descontoTextBox.TabIndex = 54;
            this.descontoTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.descontoTextBox.Leave += new System.EventHandler(this.icmsTextBox_Leave_1);
            // 
            // unidadeCompraTextBox
            // 
            this.unidadeCompraTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.unidadeCompraTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "UnidadeCompra", true));
            this.unidadeCompraTextBox.Location = new System.Drawing.Point(150, 213);
            this.unidadeCompraTextBox.MaxLength = 2;
            this.unidadeCompraTextBox.Name = "unidadeCompraTextBox";
            this.unidadeCompraTextBox.Size = new System.Drawing.Size(131, 20);
            this.unidadeCompraTextBox.TabIndex = 23;
            // 
            // quantidadeEmbalagemTextBox
            // 
            this.quantidadeEmbalagemTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.quantidadeEmbalagemTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "QuantidadeEmbalagem", true));
            this.quantidadeEmbalagemTextBox.Location = new System.Drawing.Point(288, 212);
            this.quantidadeEmbalagemTextBox.Name = "quantidadeEmbalagemTextBox";
            this.quantidadeEmbalagemTextBox.Size = new System.Drawing.Size(119, 20);
            this.quantidadeEmbalagemTextBox.TabIndex = 25;
            // 
            // lucroPrecoRevendaLabel
            // 
            lucroPrecoRevendaLabel.AutoSize = true;
            lucroPrecoRevendaLabel.Location = new System.Drawing.Point(235, 463);
            lucroPrecoRevendaLabel.Name = "lucroPrecoRevendaLabel";
            lucroPrecoRevendaLabel.Size = new System.Drawing.Size(95, 13);
            lucroPrecoRevendaLabel.TabIndex = 92;
            lucroPrecoRevendaLabel.Text = "% Lucro Revenda:";
            // 
            // lucroPrecoRevendaTextBox
            // 
            this.lucroPrecoRevendaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "LucroPrecoRevenda", true));
            this.lucroPrecoRevendaTextBox.Location = new System.Drawing.Point(238, 479);
            this.lucroPrecoRevendaTextBox.Name = "lucroPrecoRevendaTextBox";
            this.lucroPrecoRevendaTextBox.Size = new System.Drawing.Size(88, 20);
            this.lucroPrecoRevendaTextBox.TabIndex = 80;
            this.lucroPrecoRevendaTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.lucroPrecoRevendaTextBox.Leave += new System.EventHandler(this.icmsTextBox_Leave_1);
            // 
            // precoRevendaSugestaoLabel
            // 
            precoRevendaSugestaoLabel.AutoSize = true;
            precoRevendaSugestaoLabel.Location = new System.Drawing.Point(329, 463);
            precoRevendaSugestaoLabel.Name = "precoRevendaSugestaoLabel";
            precoRevendaSugestaoLabel.Size = new System.Drawing.Size(133, 13);
            precoRevendaSugestaoLabel.TabIndex = 93;
            precoRevendaSugestaoLabel.Text = "Preco Revenda Sugestão:";
            // 
            // precoRevendaSugestaoTextBox
            // 
            this.precoRevendaSugestaoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "PrecoRevendaSugestao", true));
            this.precoRevendaSugestaoTextBox.Location = new System.Drawing.Point(332, 479);
            this.precoRevendaSugestaoTextBox.Name = "precoRevendaSugestaoTextBox";
            this.precoRevendaSugestaoTextBox.ReadOnly = true;
            this.precoRevendaSugestaoTextBox.Size = new System.Drawing.Size(126, 20);
            this.precoRevendaSugestaoTextBox.TabIndex = 82;
            this.precoRevendaSugestaoTextBox.TabStop = false;
            // 
            // precoRevendaLabel
            // 
            precoRevendaLabel.AutoSize = true;
            precoRevendaLabel.Location = new System.Drawing.Point(468, 463);
            precoRevendaLabel.Name = "precoRevendaLabel";
            precoRevendaLabel.Size = new System.Drawing.Size(85, 13);
            precoRevendaLabel.TabIndex = 94;
            precoRevendaLabel.Text = "Preço Revenda:";
            // 
            // precoRevendaTextBox
            // 
            this.precoRevendaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "PrecoRevenda", true));
            this.precoRevendaTextBox.Location = new System.Drawing.Point(467, 479);
            this.precoRevendaTextBox.Name = "precoRevendaTextBox";
            this.precoRevendaTextBox.Size = new System.Drawing.Size(128, 20);
            this.precoRevendaTextBox.TabIndex = 84;
            this.precoRevendaTextBox.Enter += new System.EventHandler(this.codProdutoTextBox_Enter);
            this.precoRevendaTextBox.Leave += new System.EventHandler(this.icmsTextBox_Leave_1);
            // 
            // FrmProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 622);
            this.ControlBox = false;
            this.Controls.Add(precoRevendaLabel);
            this.Controls.Add(this.precoRevendaTextBox);
            this.Controls.Add(precoRevendaSugestaoLabel);
            this.Controls.Add(this.precoRevendaSugestaoTextBox);
            this.Controls.Add(lucroPrecoRevendaLabel);
            this.Controls.Add(this.lucroPrecoRevendaTextBox);
            this.Controls.Add(quantidadeEmbalagemLabel);
            this.Controls.Add(this.quantidadeEmbalagemTextBox);
            this.Controls.Add(unidadeCompraLabel);
            this.Controls.Add(this.unidadeCompraTextBox);
            this.Controls.Add(descontoLabel);
            this.Controls.Add(this.descontoTextBox);
            this.Controls.Add(this.precoCustoTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.codSubgrupoComboBox);
            this.Controls.Add(codSubgrupoLabel);
            this.Controls.Add(this.tb_produtoBindingNavigator);
            this.Controls.Add(codCSTLabel);
            this.Controls.Add(this.codCSTComboBox);
            this.Controls.Add(ncmshLabel);
            this.Controls.Add(this.ncmshTextBox);
            this.Controls.Add(referenciaFabricanteLabel);
            this.Controls.Add(this.referenciaFabricanteTextBox);
            this.Controls.Add(codSituacaoProdutoLabel);
            this.Controls.Add(this.codSituacaoProdutoComboBox);
            this.Controls.Add(dataUltimoPedidoLabel);
            this.Controls.Add(this.dataUltimoPedidoDateTimePicker);
            this.Controls.Add(this.btnEstoque);
            this.Controls.Add(this.tb_produto_lojaDataGridView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.precoAtacadoSugestaoTextBox);
            this.Controls.Add(this.precoVarejoSugestaoTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(icms_substitutoLabel);
            this.Controls.Add(this.icms_substitutoTextBox);
            this.Controls.Add(qtdProdutoAtacadoLabel);
            this.Controls.Add(this.qtdProdutoAtacadoTextBox);
            this.Controls.Add(codProdutoLabel);
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
            this.Controls.Add(this.temVencimentoCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "FrmProduto";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cadastro de Produtos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmProduto_FormClosing);
            this.Load += new System.EventHandler(this.FrmProduto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmProduto_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.produtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grupoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pessoaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.situacaoprodutoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produto_lojaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoLojaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cstBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoBindingNavigator)).EndInit();
            this.tb_produtoBindingNavigator.ResumeLayout(false);
            this.tb_produtoBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subgrupoBindingSource)).EndInit();
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
        private System.Windows.Forms.TextBox codProdutoTextBox;
        private System.Windows.Forms.TextBox nomeTextBox;
        private System.Windows.Forms.TextBox unidadeTextBox;
        private System.Windows.Forms.TextBox codigoBarraTextBox;
        private System.Windows.Forms.ComboBox codGrupoComboBox;
        private System.Windows.Forms.ComboBox codigoFabricanteComboBox;
        private System.Windows.Forms.CheckBox temVencimentoCheckBox;
        private System.Windows.Forms.CheckBox exibeNaListagemCheckBox;
        private System.Windows.Forms.TextBox nomeFabricanteTextBox;
        private System.Windows.Forms.Button btnEstoque;
        private System.Windows.Forms.ComboBox codSituacaoProdutoComboBox;
        private System.Windows.Forms.TextBox precoVendaAtacadoTextBox;
        private System.Windows.Forms.TextBox lucroPrecoVendaAtacadoTextBox;
        private System.Windows.Forms.TextBox precoVendaVarejoTextBox;
        private System.Windows.Forms.TextBox lucroPrecoVendaVarejoTextBox;
        private System.Windows.Forms.DateTimePicker ultimaDataAtualizacaoDateTimePicker;
        private System.Windows.Forms.TextBox ultimoPrecoCompraTextBox;
        private System.Windows.Forms.TextBox freteTextBox;
        private System.Windows.Forms.TextBox ipiTextBox;
        private System.Windows.Forms.TextBox simplesTextBox;
        private System.Windows.Forms.TextBox icmsTextBox;
        private System.Windows.Forms.TextBox qtdProdutoAtacadoTextBox;
        private System.Windows.Forms.TextBox icms_substitutoTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox precoVarejoSugestaoTextBox;
        private System.Windows.Forms.TextBox precoAtacadoSugestaoTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView tb_produto_lojaDataGridView;
        private System.Windows.Forms.DateTimePicker dataUltimoPedidoDateTimePicker;
        private System.Windows.Forms.TextBox referenciaFabricanteTextBox;
        private System.Windows.Forms.TextBox ncmshTextBox;
        private System.Windows.Forms.ComboBox codCSTComboBox;
        private System.Windows.Forms.BindingSource produtoBindingSource;
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
        private System.Windows.Forms.BindingSource grupoBindingSource;
        private System.Windows.Forms.BindingSource situacaoprodutoBindingSource;
        private System.Windows.Forms.BindingSource cstBindingSource;
        private System.Windows.Forms.BindingSource produtoLojaBindingSource;
        private System.Windows.Forms.BindingSource subgrupoBindingSource;
        private System.Windows.Forms.ComboBox codSubgrupoComboBox;
        private System.Windows.Forms.TextBox precoCustoTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox descontoTextBox;
        private System.Windows.Forms.TextBox unidadeCompraTextBox;
        private System.Windows.Forms.TextBox quantidadeEmbalagemTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeLoja;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdEstoqueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdEstoqueAuxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localizacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localizacao2DataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource pessoaBindingSource;
        private System.Windows.Forms.TextBox lucroPrecoRevendaTextBox;
        private System.Windows.Forms.TextBox precoRevendaSugestaoTextBox;
        private System.Windows.Forms.TextBox precoRevendaTextBox;
    }
}