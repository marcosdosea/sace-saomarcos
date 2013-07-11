namespace Telas
{
    partial class Principal
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pessoasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lojasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bancosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.planoDeContasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contasBancáriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cartõesDeCréditoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gruposDeProdutosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subgrupoDeProdutosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tiposDeContasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuárioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.códigoFiscalDeOperaçãoCFOPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movimentaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.entradaDeProdutosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.vendaAoConsumidorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devoluçãoDeProdutosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferênciaEntreLojasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.estatísticaPorProdutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contasAPagarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contasAPagarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.receberPagamentosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilitáriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restaurarBackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.atualizarCSOSNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.produtosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSair = new System.Windows.Forms.Button();
            this.btnEntradas = new System.Windows.Forms.Button();
            this.btnContas = new System.Windows.Forms.Button();
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnProdutos = new System.Windows.Forms.Button();
            this.btnVenda = new System.Windows.Forms.Button();
            this.btnReceber = new System.Windows.Forms.Button();
            this.timerAtualizaCuponsFiscais = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorkerAtualizarCupons = new System.ComponentModel.BackgroundWorker();
            this.receberPagamentosCartõesDeCréditoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrosToolStripMenuItem,
            this.movimentaçãoToolStripMenuItem,
            this.contasAPagarToolStripMenuItem,
            this.utilitáriosToolStripMenuItem,
            this.relatóriosToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastrosToolStripMenuItem
            // 
            this.cadastrosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.produtosToolStripMenuItem,
            this.pessoasToolStripMenuItem,
            this.lojasToolStripMenuItem,
            this.bancosToolStripMenuItem,
            this.planoDeContasToolStripMenuItem,
            this.contasBancáriasToolStripMenuItem,
            this.cartõesDeCréditoToolStripMenuItem,
            this.gruposDeProdutosToolStripMenuItem,
            this.subgrupoDeProdutosToolStripMenuItem,
            this.tiposDeContasToolStripMenuItem,
            this.usuárioToolStripMenuItem,
            this.códigoFiscalDeOperaçãoCFOPToolStripMenuItem});
            this.cadastrosToolStripMenuItem.Name = "cadastrosToolStripMenuItem";
            this.cadastrosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.cadastrosToolStripMenuItem.Text = "&Cadastros";
            // 
            // produtosToolStripMenuItem
            // 
            this.produtosToolStripMenuItem.Name = "produtosToolStripMenuItem";
            this.produtosToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.produtosToolStripMenuItem.Text = "Produtos";
            this.produtosToolStripMenuItem.Click += new System.EventHandler(this.produtosToolStripMenuItem_Click);
            // 
            // pessoasToolStripMenuItem
            // 
            this.pessoasToolStripMenuItem.Name = "pessoasToolStripMenuItem";
            this.pessoasToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.pessoasToolStripMenuItem.Text = "Pessoas";
            this.pessoasToolStripMenuItem.Click += new System.EventHandler(this.pessoasToolStripMenuItem_Click);
            // 
            // lojasToolStripMenuItem
            // 
            this.lojasToolStripMenuItem.Name = "lojasToolStripMenuItem";
            this.lojasToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.lojasToolStripMenuItem.Text = "Lojas";
            this.lojasToolStripMenuItem.Click += new System.EventHandler(this.lojasToolStripMenuItem_Click);
            // 
            // bancosToolStripMenuItem
            // 
            this.bancosToolStripMenuItem.Name = "bancosToolStripMenuItem";
            this.bancosToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.bancosToolStripMenuItem.Text = "Bancos";
            this.bancosToolStripMenuItem.Click += new System.EventHandler(this.bancosToolStripMenuItem_Click);
            // 
            // planoDeContasToolStripMenuItem
            // 
            this.planoDeContasToolStripMenuItem.Name = "planoDeContasToolStripMenuItem";
            this.planoDeContasToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.planoDeContasToolStripMenuItem.Text = "Plano de Contas";
            this.planoDeContasToolStripMenuItem.Click += new System.EventHandler(this.planoDeContasToolStripMenuItem_Click);
            // 
            // contasBancáriasToolStripMenuItem
            // 
            this.contasBancáriasToolStripMenuItem.Name = "contasBancáriasToolStripMenuItem";
            this.contasBancáriasToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.contasBancáriasToolStripMenuItem.Text = "Contas Banco / Caixas";
            this.contasBancáriasToolStripMenuItem.Click += new System.EventHandler(this.contasBancáriasToolStripMenuItem_Click);
            // 
            // cartõesDeCréditoToolStripMenuItem
            // 
            this.cartõesDeCréditoToolStripMenuItem.Name = "cartõesDeCréditoToolStripMenuItem";
            this.cartõesDeCréditoToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.cartõesDeCréditoToolStripMenuItem.Text = "Cartões de Crédito";
            this.cartõesDeCréditoToolStripMenuItem.Click += new System.EventHandler(this.cartõesDeCréditoToolStripMenuItem_Click);
            // 
            // gruposDeProdutosToolStripMenuItem
            // 
            this.gruposDeProdutosToolStripMenuItem.Name = "gruposDeProdutosToolStripMenuItem";
            this.gruposDeProdutosToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.gruposDeProdutosToolStripMenuItem.Text = "Grupos de Produtos";
            this.gruposDeProdutosToolStripMenuItem.Click += new System.EventHandler(this.gruposDeProdutosToolStripMenuItem_Click);
            // 
            // subgrupoDeProdutosToolStripMenuItem
            // 
            this.subgrupoDeProdutosToolStripMenuItem.Name = "subgrupoDeProdutosToolStripMenuItem";
            this.subgrupoDeProdutosToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.subgrupoDeProdutosToolStripMenuItem.Text = "Subgrupo de Produtos";
            this.subgrupoDeProdutosToolStripMenuItem.Click += new System.EventHandler(this.subgrupoDeProdutosToolStripMenuItem_Click);
            // 
            // tiposDeContasToolStripMenuItem
            // 
            this.tiposDeContasToolStripMenuItem.Name = "tiposDeContasToolStripMenuItem";
            this.tiposDeContasToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.tiposDeContasToolStripMenuItem.Text = "Grupo de Contas Pagar/Receber";
            this.tiposDeContasToolStripMenuItem.Click += new System.EventHandler(this.tiposDeContasToolStripMenuItem_Click);
            // 
            // usuárioToolStripMenuItem
            // 
            this.usuárioToolStripMenuItem.Name = "usuárioToolStripMenuItem";
            this.usuárioToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.usuárioToolStripMenuItem.Text = "Usuário";
            this.usuárioToolStripMenuItem.Click += new System.EventHandler(this.usuárioToolStripMenuItem_Click);
            // 
            // códigoFiscalDeOperaçãoCFOPToolStripMenuItem
            // 
            this.códigoFiscalDeOperaçãoCFOPToolStripMenuItem.Name = "códigoFiscalDeOperaçãoCFOPToolStripMenuItem";
            this.códigoFiscalDeOperaçãoCFOPToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.códigoFiscalDeOperaçãoCFOPToolStripMenuItem.Text = "Código Fiscal de Operação (CFOP)";
            this.códigoFiscalDeOperaçãoCFOPToolStripMenuItem.Click += new System.EventHandler(this.códigoFiscalDeOperaçãoCFOPToolStripMenuItem_Click);
            // 
            // movimentaçãoToolStripMenuItem
            // 
            this.movimentaçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.entradaDeProdutosToolStripMenuItem,
            this.toolStripSeparator1,
            this.vendaAoConsumidorToolStripMenuItem,
            this.devoluçãoDeProdutosToolStripMenuItem,
            this.transferênciaEntreLojasToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripSeparator2,
            this.estatísticaPorProdutoToolStripMenuItem});
            this.movimentaçãoToolStripMenuItem.Name = "movimentaçãoToolStripMenuItem";
            this.movimentaçãoToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.movimentaçãoToolStripMenuItem.Text = "&Estoque";
            this.movimentaçãoToolStripMenuItem.Click += new System.EventHandler(this.movimentaçãoToolStripMenuItem_Click);
            // 
            // entradaDeProdutosToolStripMenuItem
            // 
            this.entradaDeProdutosToolStripMenuItem.Name = "entradaDeProdutosToolStripMenuItem";
            this.entradaDeProdutosToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.entradaDeProdutosToolStripMenuItem.Text = "Entrada de Produtos";
            this.entradaDeProdutosToolStripMenuItem.Click += new System.EventHandler(this.entradaDeProdutosToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(216, 6);
            // 
            // vendaAoConsumidorToolStripMenuItem
            // 
            this.vendaAoConsumidorToolStripMenuItem.Name = "vendaAoConsumidorToolStripMenuItem";
            this.vendaAoConsumidorToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.vendaAoConsumidorToolStripMenuItem.Text = "Pré-Venda ao Consumidor";
            this.vendaAoConsumidorToolStripMenuItem.Click += new System.EventHandler(this.vendaAoConsumidorToolStripMenuItem_Click);
            // 
            // devoluçãoDeProdutosToolStripMenuItem
            // 
            this.devoluçãoDeProdutosToolStripMenuItem.Name = "devoluçãoDeProdutosToolStripMenuItem";
            this.devoluçãoDeProdutosToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.devoluçãoDeProdutosToolStripMenuItem.Text = "Devolução para Fornecedor";
            this.devoluçãoDeProdutosToolStripMenuItem.Click += new System.EventHandler(this.devoluçãoDeProdutosToolStripMenuItem_Click);
            // 
            // transferênciaEntreLojasToolStripMenuItem
            // 
            this.transferênciaEntreLojasToolStripMenuItem.Name = "transferênciaEntreLojasToolStripMenuItem";
            this.transferênciaEntreLojasToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.transferênciaEntreLojasToolStripMenuItem.Text = "Transferência entre Lojas";
            this.transferênciaEntreLojasToolStripMenuItem.Click += new System.EventHandler(this.transferênciaEntreLojasToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(219, 22);
            this.toolStripMenuItem1.Text = "Nota Complementar";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(216, 6);
            // 
            // estatísticaPorProdutoToolStripMenuItem
            // 
            this.estatísticaPorProdutoToolStripMenuItem.Name = "estatísticaPorProdutoToolStripMenuItem";
            this.estatísticaPorProdutoToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.estatísticaPorProdutoToolStripMenuItem.Text = "Estatística por Produto";
            this.estatísticaPorProdutoToolStripMenuItem.Click += new System.EventHandler(this.estatísticaPorProdutoToolStripMenuItem_Click);
            // 
            // contasAPagarToolStripMenuItem
            // 
            this.contasAPagarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contasAPagarToolStripMenuItem1,
            this.receberPagamentosToolStripMenuItem,
            this.receberPagamentosCartõesDeCréditoToolStripMenuItem});
            this.contasAPagarToolStripMenuItem.Name = "contasAPagarToolStripMenuItem";
            this.contasAPagarToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.contasAPagarToolStripMenuItem.Text = "&Financeiro";
            // 
            // contasAPagarToolStripMenuItem1
            // 
            this.contasAPagarToolStripMenuItem1.Name = "contasAPagarToolStripMenuItem1";
            this.contasAPagarToolStripMenuItem1.Size = new System.Drawing.Size(313, 22);
            this.contasAPagarToolStripMenuItem1.Text = "Contas a Pagar / Receber";
            this.contasAPagarToolStripMenuItem1.Click += new System.EventHandler(this.contasAPagarToolStripMenuItem1_Click);
            // 
            // receberPagamentosToolStripMenuItem
            // 
            this.receberPagamentosToolStripMenuItem.Name = "receberPagamentosToolStripMenuItem";
            this.receberPagamentosToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
            this.receberPagamentosToolStripMenuItem.Text = "Receber Pagamentos Clientes";
            this.receberPagamentosToolStripMenuItem.Click += new System.EventHandler(this.receberPagamentosToolStripMenuItem_Click);
            // 
            // utilitáriosToolStripMenuItem
            // 
            this.utilitáriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupToolStripMenuItem,
            this.restaurarBackupToolStripMenuItem,
            this.atualizarCSOSNToolStripMenuItem});
            this.utilitáriosToolStripMenuItem.Name = "utilitáriosToolStripMenuItem";
            this.utilitáriosToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.utilitáriosToolStripMenuItem.Text = "&Utilitários";
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.backupToolStripMenuItem.Text = "Gravar Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // restaurarBackupToolStripMenuItem
            // 
            this.restaurarBackupToolStripMenuItem.Name = "restaurarBackupToolStripMenuItem";
            this.restaurarBackupToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.restaurarBackupToolStripMenuItem.Text = "Restaurar Backup";
            // 
            // atualizarCSOSNToolStripMenuItem
            // 
            this.atualizarCSOSNToolStripMenuItem.Name = "atualizarCSOSNToolStripMenuItem";
            this.atualizarCSOSNToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.atualizarCSOSNToolStripMenuItem.Text = "Atualizar CSOSN";
            this.atualizarCSOSNToolStripMenuItem.Click += new System.EventHandler(this.atualizarCSOSNToolStripMenuItem_Click);
            // 
            // relatóriosToolStripMenuItem
            // 
            this.relatóriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.produtosToolStripMenuItem1});
            this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
            this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.relatóriosToolStripMenuItem.Text = "&Relatórios";
            // 
            // produtosToolStripMenuItem1
            // 
            this.produtosToolStripMenuItem1.Name = "produtosToolStripMenuItem1";
            this.produtosToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.produtosToolStripMenuItem1.Text = "Produtos";
            this.produtosToolStripMenuItem1.Click += new System.EventHandler(this.produtosToolStripMenuItem1_Click_1);
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ajudaToolStripMenuItem.Text = "&Ajuda";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 512);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(97, 17);
            this.toolStripStatusLabel1.Text = "Usuário: VENDAS";
            // 
            // btnSair
            // 
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.Image = global::Telas.Properties.Resources._118;
            this.btnSair.Location = new System.Drawing.Point(624, 27);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(105, 78);
            this.btnSair.TabIndex = 12;
            this.btnSair.Text = "Sair - ESC";
            this.btnSair.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnEntradas
            // 
            this.btnEntradas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntradas.Image = global::Telas.Properties.Resources._66;
            this.btnEntradas.Location = new System.Drawing.Point(312, 27);
            this.btnEntradas.Name = "btnEntradas";
            this.btnEntradas.Size = new System.Drawing.Size(105, 78);
            this.btnEntradas.TabIndex = 8;
            this.btnEntradas.Text = "Entradas - F6";
            this.btnEntradas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEntradas.UseVisualStyleBackColor = true;
            this.btnEntradas.Click += new System.EventHandler(this.entradaDeProdutosToolStripMenuItem_Click);
            // 
            // btnContas
            // 
            this.btnContas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContas.Image = global::Telas.Properties.Resources._86;
            this.btnContas.Location = new System.Drawing.Point(416, 27);
            this.btnContas.Name = "btnContas";
            this.btnContas.Size = new System.Drawing.Size(105, 78);
            this.btnContas.TabIndex = 9;
            this.btnContas.Text = "Contas - F7";
            this.btnContas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnContas.UseVisualStyleBackColor = true;
            this.btnContas.Click += new System.EventHandler(this.contasAPagarToolStripMenuItem1_Click);
            // 
            // btnCliente
            // 
            this.btnCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCliente.Image = global::Telas.Properties.Resources._54;
            this.btnCliente.Location = new System.Drawing.Point(208, 27);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(105, 78);
            this.btnCliente.TabIndex = 6;
            this.btnCliente.Text = "Pessoas - F5";
            this.btnCliente.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.pessoasToolStripMenuItem_Click);
            // 
            // btnProdutos
            // 
            this.btnProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProdutos.Image = global::Telas.Properties.Resources._68;
            this.btnProdutos.Location = new System.Drawing.Point(104, 27);
            this.btnProdutos.Name = "btnProdutos";
            this.btnProdutos.Size = new System.Drawing.Size(105, 78);
            this.btnProdutos.TabIndex = 4;
            this.btnProdutos.Text = "Produtos - F4";
            this.btnProdutos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProdutos.UseVisualStyleBackColor = true;
            this.btnProdutos.Click += new System.EventHandler(this.produtosToolStripMenuItem_Click);
            // 
            // btnVenda
            // 
            this.btnVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVenda.Image = global::Telas.Properties.Resources._761;
            this.btnVenda.Location = new System.Drawing.Point(0, 27);
            this.btnVenda.Name = "btnVenda";
            this.btnVenda.Size = new System.Drawing.Size(105, 78);
            this.btnVenda.TabIndex = 3;
            this.btnVenda.Text = "Pré-Venda - F3";
            this.btnVenda.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVenda.UseVisualStyleBackColor = true;
            this.btnVenda.Click += new System.EventHandler(this.vendaAoConsumidorToolStripMenuItem_Click);
            // 
            // btnReceber
            // 
            this.btnReceber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReceber.Image = global::Telas.Properties.Resources.carteira2;
            this.btnReceber.Location = new System.Drawing.Point(520, 27);
            this.btnReceber.Name = "btnReceber";
            this.btnReceber.Size = new System.Drawing.Size(105, 78);
            this.btnReceber.TabIndex = 10;
            this.btnReceber.Text = "Receber - F8";
            this.btnReceber.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReceber.UseVisualStyleBackColor = true;
            this.btnReceber.Click += new System.EventHandler(this.receberPagamentosToolStripMenuItem_Click);
            // 
            // timerAtualizaCuponsFiscais
            // 
            this.timerAtualizaCuponsFiscais.Enabled = true;
            this.timerAtualizaCuponsFiscais.Interval = 500;
            this.timerAtualizaCuponsFiscais.Tick += new System.EventHandler(this.timerAtualizaCuponsFiscais_Tick);
            // 
            // backgroundWorkerAtualizarCupons
            // 
            this.backgroundWorkerAtualizarCupons.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerAtualizarCupons_DoWork);
            // 
            // receberPagamentosCartõesDeCréditoToolStripMenuItem
            // 
            this.receberPagamentosCartõesDeCréditoToolStripMenuItem.Name = "receberPagamentosCartõesDeCréditoToolStripMenuItem";
            this.receberPagamentosCartõesDeCréditoToolStripMenuItem.Size = new System.Drawing.Size(313, 22);
            this.receberPagamentosCartõesDeCréditoToolStripMenuItem.Text = "Receber Pagamentos Administradora Cartões";
            this.receberPagamentosCartõesDeCréditoToolStripMenuItem.Click += new System.EventHandler(this.receberPagamentosCartõesDeCréditoToolStripMenuItem_Click);
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Telas.Properties.Resources.fundo;
            this.ClientSize = new System.Drawing.Size(784, 534);
            this.Controls.Add(this.btnReceber);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.btnEntradas);
            this.Controls.Add(this.btnContas);
            this.Controls.Add(this.btnCliente);
            this.Controls.Add(this.btnProdutos);
            this.Controls.Add(this.btnVenda);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SACE - Sistema de Apoio ao Controle de Estoque";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Principal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Principal_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pessoasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gruposDeProdutosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem planoDeContasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movimentaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vendaAoConsumidorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem entradaDeProdutosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contasAPagarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contasAPagarToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnVenda;
        private System.Windows.Forms.Button btnProdutos;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Button btnContas;
        private System.Windows.Forms.Button btnEntradas;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.ToolStripMenuItem utilitáriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lojasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contasBancáriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cartõesDeCréditoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bancosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tiposDeContasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuárioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem produtosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restaurarBackupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subgrupoDeProdutosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transferênciaEntreLojasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receberPagamentosToolStripMenuItem;
        private System.Windows.Forms.Button btnReceber;
        private System.Windows.Forms.ToolStripMenuItem devoluçãoDeProdutosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem códigoFiscalDeOperaçãoCFOPToolStripMenuItem;
        private System.Windows.Forms.Timer timerAtualizaCuponsFiscais;
        private System.ComponentModel.BackgroundWorker backgroundWorkerAtualizarCupons;
        private System.Windows.Forms.ToolStripMenuItem estatísticaPorProdutoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem atualizarCSOSNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receberPagamentosCartõesDeCréditoToolStripMenuItem;

    }
}

