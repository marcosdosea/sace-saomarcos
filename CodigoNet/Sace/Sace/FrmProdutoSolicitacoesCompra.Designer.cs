﻿namespace Sace
{
    partial class FrmProdutoSolicitacoesCompra
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
            System.Windows.Forms.Label valorUnitarioLabel;
            System.Windows.Forms.Label lucroPrecoVendaAtacadoLabel;
            System.Windows.Forms.Label lucroPrecoVendaVarejoLabel;
            System.Windows.Forms.Label precoVendaVarejoLabel;
            System.Windows.Forms.Label qtdProdutoAtacadoLabel;
            System.Windows.Forms.Label precoVendaAtacadoLabel;
            System.Windows.Forms.Label preco_custoLabel;
            System.Windows.Forms.Label codProdutoLabel;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ProdutosGroupBox = new System.Windows.Forms.GroupBox();
            this.preco_custoTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.precoVendaAtacadoTextBox = new System.Windows.Forms.TextBox();
            this.produtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.precoAtacadoSugestaoTextBox = new System.Windows.Forms.TextBox();
            this.qtdProdutoAtacadoTextBox = new System.Windows.Forms.TextBox();
            this.precoVarejoSugestaoTextBox = new System.Windows.Forms.TextBox();
            this.precoVendaVarejoTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lucroPrecoVendaVarejoTextBox = new System.Windows.Forms.TextBox();
            this.lucroPrecoVendaAtacadoTextBox = new System.Windows.Forms.TextBox();
            this.valorUnitarioTextBox = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.produtosVendidosTableAdapterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saceDataSetConsultas = new Dados.saceDataSetConsultas();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.vendidos3textBox = new System.Windows.Forms.TextBox();
            this.vendidos6textBox = new System.Windows.Forms.TextBox();
            this.vendidos12textBox = new System.Windows.Forms.TextBox();
            this.produtosVendidosTableAdapter = new Dados.saceDataSetConsultasTableAdapters.ProdutosVendidosTableAdapter();
            this.vendidos18textBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.entradasPorProdutoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.entradasPorProdutoDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataEntrada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codCST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label11 = new System.Windows.Forms.Label();
            this.produtoLojaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_produto_lojaDataGridView = new System.Windows.Forms.DataGridView();
            this.codLojaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeLojaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdEstoqueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdEstoqueAuxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label13 = new System.Windows.Forms.Label();
            this.entradasPorProdutoTableAdapter = new Dados.saceDataSetConsultasTableAdapters.EntradasPorProdutoTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxFornecedor = new System.Windows.Forms.ComboBox();
            this.pessoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.solicitacoesCompraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.solicitacoesCompraDataGridView = new System.Windows.Forms.DataGridView();
            this.checkBoxDisponivel = new System.Windows.Forms.CheckBox();
            this.checkBoxComprado = new System.Windows.Forms.CheckBox();
            this.checkBoxCompraUrgente = new System.Windows.Forms.CheckBox();
            this.checkBoxNaoComprar = new System.Windows.Forms.CheckBox();
            this.checkBoxSolicitacaoCompra = new System.Windows.Forms.CheckBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            valorUnitarioLabel = new System.Windows.Forms.Label();
            lucroPrecoVendaAtacadoLabel = new System.Windows.Forms.Label();
            lucroPrecoVendaVarejoLabel = new System.Windows.Forms.Label();
            precoVendaVarejoLabel = new System.Windows.Forms.Label();
            qtdProdutoAtacadoLabel = new System.Windows.Forms.Label();
            precoVendaAtacadoLabel = new System.Windows.Forms.Label();
            preco_custoLabel = new System.Windows.Forms.Label();
            codProdutoLabel = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.ProdutosGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.produtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosVendidosTableAdapterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSetConsultas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entradasPorProdutoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.entradasPorProdutoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoLojaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produto_lojaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pessoaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.solicitacoesCompraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.solicitacoesCompraDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // valorUnitarioLabel
            // 
            valorUnitarioLabel.AutoSize = true;
            valorUnitarioLabel.Location = new System.Drawing.Point(6, 17);
            valorUnitarioLabel.Name = "valorUnitarioLabel";
            valorUnitarioLabel.Size = new System.Drawing.Size(94, 13);
            valorUnitarioLabel.TabIndex = 8;
            valorUnitarioLabel.Text = "Pç Último Compra:";
            // 
            // lucroPrecoVendaAtacadoLabel
            // 
            lucroPrecoVendaAtacadoLabel.AutoSize = true;
            lucroPrecoVendaAtacadoLabel.Location = new System.Drawing.Point(542, 19);
            lucroPrecoVendaAtacadoLabel.Name = "lucroPrecoVendaAtacadoLabel";
            lucroPrecoVendaAtacadoLabel.Size = new System.Drawing.Size(73, 13);
            lucroPrecoVendaAtacadoLabel.TabIndex = 40;
            lucroPrecoVendaAtacadoLabel.Text = "% Lucro Atac:";
            // 
            // lucroPrecoVendaVarejoLabel
            // 
            lucroPrecoVendaVarejoLabel.AutoSize = true;
            lucroPrecoVendaVarejoLabel.Location = new System.Drawing.Point(188, 19);
            lucroPrecoVendaVarejoLabel.Name = "lucroPrecoVendaVarejoLabel";
            lucroPrecoVendaVarejoLabel.Size = new System.Drawing.Size(66, 13);
            lucroPrecoVendaVarejoLabel.TabIndex = 42;
            lucroPrecoVendaVarejoLabel.Text = "% Lucro Vjo:";
            // 
            // precoVendaVarejoLabel
            // 
            precoVendaVarejoLabel.AutoSize = true;
            precoVendaVarejoLabel.Location = new System.Drawing.Point(357, 19);
            precoVendaVarejoLabel.Name = "precoVendaVarejoLabel";
            precoVendaVarejoLabel.Size = new System.Drawing.Size(98, 13);
            precoVendaVarejoLabel.TabIndex = 44;
            precoVendaVarejoLabel.Text = "Preço Varejo Atual:";
            // 
            // qtdProdutoAtacadoLabel
            // 
            qtdProdutoAtacadoLabel.AutoSize = true;
            qtdProdutoAtacadoLabel.Location = new System.Drawing.Point(469, 19);
            qtdProdutoAtacadoLabel.Name = "qtdProdutoAtacadoLabel";
            qtdProdutoAtacadoLabel.Size = new System.Drawing.Size(70, 13);
            qtdProdutoAtacadoLabel.TabIndex = 46;
            qtdProdutoAtacadoLabel.Text = "Qtd Atacado:";
            // 
            // precoVendaAtacadoLabel
            // 
            precoVendaAtacadoLabel.AutoSize = true;
            precoVendaAtacadoLabel.Location = new System.Drawing.Point(726, 19);
            precoVendaAtacadoLabel.Name = "precoVendaAtacadoLabel";
            precoVendaAtacadoLabel.Size = new System.Drawing.Size(108, 13);
            precoVendaAtacadoLabel.TabIndex = 48;
            precoVendaAtacadoLabel.Text = "Preço Atacado Atual:";
            // 
            // preco_custoLabel
            // 
            preco_custoLabel.AutoSize = true;
            preco_custoLabel.Location = new System.Drawing.Point(105, 19);
            preco_custoLabel.Name = "preco_custoLabel";
            preco_custoLabel.Size = new System.Drawing.Size(68, 13);
            preco_custoLabel.TabIndex = 115;
            preco_custoLabel.Text = "Preço Custo:";
            // 
            // codProdutoLabel
            // 
            codProdutoLabel.AutoSize = true;
            codProdutoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            codProdutoLabel.Location = new System.Drawing.Point(7, 104);
            codProdutoLabel.Name = "codProdutoLabel";
            codProdutoLabel.Size = new System.Drawing.Size(77, 20);
            codProdutoLabel.TabIndex = 126;
            codProdutoLabel.Text = "Produtos:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            label6.Location = new System.Drawing.Point(5, 42);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(254, 20);
            label6.TabIndex = 130;
            label6.Text = "Filtrar por Fornecedor / Fabricante:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Solicitações de Compras de Produtos";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(872, 39);
            this.panel1.TabIndex = 20;
            // 
            // ProdutosGroupBox
            // 
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
            this.ProdutosGroupBox.Controls.Add(valorUnitarioLabel);
            this.ProdutosGroupBox.Controls.Add(this.valorUnitarioTextBox);
            this.ProdutosGroupBox.Location = new System.Drawing.Point(2, 279);
            this.ProdutosGroupBox.Name = "ProdutosGroupBox";
            this.ProdutosGroupBox.Size = new System.Drawing.Size(858, 84);
            this.ProdutosGroupBox.TabIndex = 76;
            this.ProdutosGroupBox.TabStop = false;
            this.ProdutosGroupBox.Text = "Dados do Produto";
            // 
            // preco_custoTextBox
            // 
            this.preco_custoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.preco_custoTextBox.Location = new System.Drawing.Point(108, 35);
            this.preco_custoTextBox.Name = "preco_custoTextBox";
            this.preco_custoTextBox.ReadOnly = true;
            this.preco_custoTextBox.Size = new System.Drawing.Size(78, 22);
            this.preco_custoTextBox.TabIndex = 76;
            this.preco_custoTextBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(622, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 115;
            this.label3.Text = "Pç Atac Sugestão:";
            // 
            // precoVendaAtacadoTextBox
            // 
            this.precoVendaAtacadoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "precoVendaAtacado", true));
            this.precoVendaAtacadoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precoVendaAtacadoTextBox.ForeColor = System.Drawing.Color.Red;
            this.precoVendaAtacadoTextBox.Location = new System.Drawing.Point(729, 35);
            this.precoVendaAtacadoTextBox.Name = "precoVendaAtacadoTextBox";
            this.precoVendaAtacadoTextBox.ReadOnly = true;
            this.precoVendaAtacadoTextBox.Size = new System.Drawing.Size(105, 24);
            this.precoVendaAtacadoTextBox.TabIndex = 102;
            this.precoVendaAtacadoTextBox.TabStop = false;
            // 
            // produtoBindingSource
            // 
            this.produtoBindingSource.DataSource = typeof(Dominio.Produto);
            this.produtoBindingSource.Sort = "nome";
            // 
            // precoAtacadoSugestaoTextBox
            // 
            this.precoAtacadoSugestaoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precoAtacadoSugestaoTextBox.Location = new System.Drawing.Point(622, 35);
            this.precoAtacadoSugestaoTextBox.Name = "precoAtacadoSugestaoTextBox";
            this.precoAtacadoSugestaoTextBox.ReadOnly = true;
            this.precoAtacadoSugestaoTextBox.Size = new System.Drawing.Size(99, 22);
            this.precoAtacadoSugestaoTextBox.TabIndex = 100;
            this.precoAtacadoSugestaoTextBox.TabStop = false;
            // 
            // qtdProdutoAtacadoTextBox
            // 
            this.qtdProdutoAtacadoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "qtdProdutoAtacado", true));
            this.qtdProdutoAtacadoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.qtdProdutoAtacadoTextBox.Location = new System.Drawing.Point(472, 35);
            this.qtdProdutoAtacadoTextBox.Name = "qtdProdutoAtacadoTextBox";
            this.qtdProdutoAtacadoTextBox.ReadOnly = true;
            this.qtdProdutoAtacadoTextBox.Size = new System.Drawing.Size(67, 22);
            this.qtdProdutoAtacadoTextBox.TabIndex = 96;
            this.qtdProdutoAtacadoTextBox.TabStop = false;
            // 
            // precoVarejoSugestaoTextBox
            // 
            this.precoVarejoSugestaoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precoVarejoSugestaoTextBox.ForeColor = System.Drawing.Color.Black;
            this.precoVarejoSugestaoTextBox.Location = new System.Drawing.Point(259, 35);
            this.precoVarejoSugestaoTextBox.Name = "precoVarejoSugestaoTextBox";
            this.precoVarejoSugestaoTextBox.ReadOnly = true;
            this.precoVarejoSugestaoTextBox.Size = new System.Drawing.Size(95, 22);
            this.precoVarejoSugestaoTextBox.TabIndex = 92;
            this.precoVarejoSugestaoTextBox.TabStop = false;
            // 
            // precoVendaVarejoTextBox
            // 
            this.precoVendaVarejoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "precoVendaVarejo", true));
            this.precoVendaVarejoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.precoVendaVarejoTextBox.ForeColor = System.Drawing.Color.Red;
            this.precoVendaVarejoTextBox.Location = new System.Drawing.Point(360, 35);
            this.precoVendaVarejoTextBox.Name = "precoVendaVarejoTextBox";
            this.precoVendaVarejoTextBox.ReadOnly = true;
            this.precoVendaVarejoTextBox.Size = new System.Drawing.Size(105, 24);
            this.precoVendaVarejoTextBox.TabIndex = 94;
            this.precoVendaVarejoTextBox.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(259, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 114;
            this.label4.Text = "Pço Vjo Sugestão:";
            // 
            // lucroPrecoVendaVarejoTextBox
            // 
            this.lucroPrecoVendaVarejoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "lucroPrecoVendaVarejo", true));
            this.lucroPrecoVendaVarejoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lucroPrecoVendaVarejoTextBox.Location = new System.Drawing.Point(191, 35);
            this.lucroPrecoVendaVarejoTextBox.Name = "lucroPrecoVendaVarejoTextBox";
            this.lucroPrecoVendaVarejoTextBox.ReadOnly = true;
            this.lucroPrecoVendaVarejoTextBox.Size = new System.Drawing.Size(63, 22);
            this.lucroPrecoVendaVarejoTextBox.TabIndex = 90;
            this.lucroPrecoVendaVarejoTextBox.TabStop = false;
            // 
            // lucroPrecoVendaAtacadoTextBox
            // 
            this.lucroPrecoVendaAtacadoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "lucroPrecoVendaAtacado", true));
            this.lucroPrecoVendaAtacadoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lucroPrecoVendaAtacadoTextBox.Location = new System.Drawing.Point(545, 35);
            this.lucroPrecoVendaAtacadoTextBox.Name = "lucroPrecoVendaAtacadoTextBox";
            this.lucroPrecoVendaAtacadoTextBox.ReadOnly = true;
            this.lucroPrecoVendaAtacadoTextBox.Size = new System.Drawing.Size(74, 22);
            this.lucroPrecoVendaAtacadoTextBox.TabIndex = 98;
            this.lucroPrecoVendaAtacadoTextBox.TabStop = false;
            // 
            // valorUnitarioTextBox
            // 
            this.valorUnitarioTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.produtoBindingSource, "ultimoPrecoCompra", true));
            this.valorUnitarioTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valorUnitarioTextBox.Location = new System.Drawing.Point(7, 35);
            this.valorUnitarioTextBox.Name = "valorUnitarioTextBox";
            this.valorUnitarioTextBox.ReadOnly = true;
            this.valorUnitarioTextBox.Size = new System.Drawing.Size(93, 22);
            this.valorUnitarioTextBox.TabIndex = 60;
            this.valorUnitarioTextBox.TabStop = false;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.LightGray;
            this.chart1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.DarkDownwardDiagonal;
            this.chart1.BackImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chart1.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.DataSource = this.produtosVendidosTableAdapterBindingSource;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(2, 461);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(858, 130);
            this.chart1.TabIndex = 113;
            this.chart1.Text = "chart1";
            // 
            // produtosVendidosTableAdapterBindingSource
            // 
            this.produtosVendidosTableAdapterBindingSource.DataMember = "ProdutosVendidos";
            this.produtosVendidosTableAdapterBindingSource.DataSource = this.saceDataSetConsultas;
            // 
            // saceDataSetConsultas
            // 
            this.saceDataSetConsultas.DataSetName = "saceDataSetConsultas";
            this.saceDataSetConsultas.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 438);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 18);
            this.label5.TabIndex = 115;
            this.label5.Text = "Gráfico Mensal de Vendas:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(10, 371);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 15);
            this.label8.TabIndex = 116;
            this.label8.Text = "3 meses:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(10, 410);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 15);
            this.label9.TabIndex = 117;
            this.label9.Text = "6 meses:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(216, 372);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 15);
            this.label10.TabIndex = 118;
            this.label10.Text = "12 meses:";
            // 
            // vendidos3textBox
            // 
            this.vendidos3textBox.Location = new System.Drawing.Point(81, 371);
            this.vendidos3textBox.Name = "vendidos3textBox";
            this.vendidos3textBox.ReadOnly = true;
            this.vendidos3textBox.Size = new System.Drawing.Size(128, 20);
            this.vendidos3textBox.TabIndex = 104;
            this.vendidos3textBox.TabStop = false;
            // 
            // vendidos6textBox
            // 
            this.vendidos6textBox.Location = new System.Drawing.Point(81, 411);
            this.vendidos6textBox.Name = "vendidos6textBox";
            this.vendidos6textBox.ReadOnly = true;
            this.vendidos6textBox.Size = new System.Drawing.Size(125, 20);
            this.vendidos6textBox.TabIndex = 106;
            this.vendidos6textBox.TabStop = false;
            // 
            // vendidos12textBox
            // 
            this.vendidos12textBox.Location = new System.Drawing.Point(295, 370);
            this.vendidos12textBox.Name = "vendidos12textBox";
            this.vendidos12textBox.ReadOnly = true;
            this.vendidos12textBox.Size = new System.Drawing.Size(129, 20);
            this.vendidos12textBox.TabIndex = 108;
            this.vendidos12textBox.TabStop = false;
            // 
            // produtosVendidosTableAdapter
            // 
            this.produtosVendidosTableAdapter.ClearBeforeFill = true;
            // 
            // vendidos18textBox
            // 
            this.vendidos18textBox.Location = new System.Drawing.Point(295, 411);
            this.vendidos18textBox.Name = "vendidos18textBox";
            this.vendidos18textBox.ReadOnly = true;
            this.vendidos18textBox.Size = new System.Drawing.Size(129, 20);
            this.vendidos18textBox.TabIndex = 123;
            this.vendidos18textBox.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(216, 411);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 15);
            this.label12.TabIndex = 124;
            this.label12.Text = "18 meses:";
            // 
            // entradasPorProdutoBindingSource
            // 
            this.entradasPorProdutoBindingSource.DataMember = "EntradasPorProduto";
            this.entradasPorProdutoBindingSource.DataSource = this.saceDataSetConsultas;
            // 
            // entradasPorProdutoDataGridView
            // 
            this.entradasPorProdutoDataGridView.AllowUserToAddRows = false;
            this.entradasPorProdutoDataGridView.AllowUserToDeleteRows = false;
            this.entradasPorProdutoDataGridView.AutoGenerateColumns = false;
            this.entradasPorProdutoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.entradasPorProdutoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataEntrada,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn12,
            this.codCST,
            this.quantidade,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11});
            this.entradasPorProdutoDataGridView.DataSource = this.entradasPorProdutoBindingSource;
            this.entradasPorProdutoDataGridView.Location = new System.Drawing.Point(3, 614);
            this.entradasPorProdutoDataGridView.MultiSelect = false;
            this.entradasPorProdutoDataGridView.Name = "entradasPorProdutoDataGridView";
            this.entradasPorProdutoDataGridView.ReadOnly = true;
            this.entradasPorProdutoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.entradasPorProdutoDataGridView.Size = new System.Drawing.Size(855, 75);
            this.entradasPorProdutoDataGridView.TabIndex = 124;
            this.entradasPorProdutoDataGridView.TabStop = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "codEntrada";
            this.dataGridViewTextBoxColumn2.HeaderText = "Entrada";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 69;
            // 
            // dataEntrada
            // 
            this.dataEntrada.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dataEntrada.DataPropertyName = "dataEntrada";
            this.dataEntrada.HeaderText = "Data";
            this.dataEntrada.Name = "dataEntrada";
            this.dataEntrada.ReadOnly = true;
            this.dataEntrada.Width = 55;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "descricaoTipoEntrada";
            this.dataGridViewTextBoxColumn3.FillWeight = 15F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Tipo";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn12.DataPropertyName = "nomeFornecedor";
            this.dataGridViewTextBoxColumn12.FillWeight = 40F;
            this.dataGridViewTextBoxColumn12.HeaderText = "Fornecedor";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // codCST
            // 
            this.codCST.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.codCST.DataPropertyName = "codCST";
            this.codCST.FillWeight = 15F;
            this.codCST.HeaderText = "CST";
            this.codCST.Name = "codCST";
            this.codCST.ReadOnly = true;
            this.codCST.Width = 53;
            // 
            // quantidade
            // 
            this.quantidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.quantidade.DataPropertyName = "Quantidade";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.quantidade.DefaultCellStyle = dataGridViewCellStyle1;
            this.quantidade.HeaderText = "Quantidade";
            this.quantidade.Name = "quantidade";
            this.quantidade.ReadOnly = true;
            this.quantidade.Width = 87;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "valorUnitario";
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn10.FillWeight = 20F;
            this.dataGridViewTextBoxColumn10.HeaderText = "Valor UN (R$)";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "preco_custo";
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn11.FillWeight = 20F;
            this.dataGridViewTextBoxColumn11.HeaderText = "Preço Custo (R$)";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(-1, 594);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(179, 18);
            this.label11.TabIndex = 122;
            this.label11.Text = "Últimas Entradas/Pedidos";
            // 
            // produtoLojaBindingSource
            // 
            this.produtoLojaBindingSource.DataSource = typeof(Dominio.ProdutoLoja);
            // 
            // tb_produto_lojaDataGridView
            // 
            this.tb_produto_lojaDataGridView.AllowUserToAddRows = false;
            this.tb_produto_lojaDataGridView.AllowUserToDeleteRows = false;
            this.tb_produto_lojaDataGridView.AutoGenerateColumns = false;
            this.tb_produto_lojaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_produto_lojaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codLojaDataGridViewTextBoxColumn,
            this.nomeLojaDataGridViewTextBoxColumn,
            this.qtdEstoqueDataGridViewTextBoxColumn,
            this.qtdEstoqueAuxDataGridViewTextBoxColumn});
            this.tb_produto_lojaDataGridView.DataSource = this.produtoLojaBindingSource;
            this.tb_produto_lojaDataGridView.Location = new System.Drawing.Point(455, 370);
            this.tb_produto_lojaDataGridView.MultiSelect = false;
            this.tb_produto_lojaDataGridView.Name = "tb_produto_lojaDataGridView";
            this.tb_produto_lojaDataGridView.ReadOnly = true;
            this.tb_produto_lojaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_produto_lojaDataGridView.Size = new System.Drawing.Size(405, 86);
            this.tb_produto_lojaDataGridView.TabIndex = 124;
            this.tb_produto_lojaDataGridView.TabStop = false;
            // 
            // codLojaDataGridViewTextBoxColumn
            // 
            this.codLojaDataGridViewTextBoxColumn.DataPropertyName = "CodLoja";
            this.codLojaDataGridViewTextBoxColumn.HeaderText = "CodLoja";
            this.codLojaDataGridViewTextBoxColumn.Name = "codLojaDataGridViewTextBoxColumn";
            this.codLojaDataGridViewTextBoxColumn.ReadOnly = true;
            this.codLojaDataGridViewTextBoxColumn.Visible = false;
            // 
            // nomeLojaDataGridViewTextBoxColumn
            // 
            this.nomeLojaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomeLojaDataGridViewTextBoxColumn.DataPropertyName = "NomeLoja";
            this.nomeLojaDataGridViewTextBoxColumn.HeaderText = "Loja";
            this.nomeLojaDataGridViewTextBoxColumn.Name = "nomeLojaDataGridViewTextBoxColumn";
            this.nomeLojaDataGridViewTextBoxColumn.ReadOnly = true;
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
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label13.Location = new System.Drawing.Point(452, 348);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 17);
            this.label13.TabIndex = 125;
            this.label13.Text = "Estoque";
            // 
            // entradasPorProdutoTableAdapter
            // 
            this.entradasPorProdutoTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 346);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 18);
            this.label2.TabIndex = 128;
            this.label2.Text = "Total Produtos Vendidos:";
            // 
            // comboBoxFornecedor
            // 
            this.comboBoxFornecedor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxFornecedor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxFornecedor.CausesValidation = false;
            this.comboBoxFornecedor.DataSource = this.pessoaBindingSource;
            this.comboBoxFornecedor.DisplayMember = "NomeFantasia";
            this.comboBoxFornecedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.comboBoxFornecedor.FormattingEnabled = true;
            this.comboBoxFornecedor.Location = new System.Drawing.Point(7, 69);
            this.comboBoxFornecedor.Name = "comboBoxFornecedor";
            this.comboBoxFornecedor.Size = new System.Drawing.Size(450, 28);
            this.comboBoxFornecedor.TabIndex = 2;
            this.comboBoxFornecedor.ValueMember = "CodPessoa";
            this.comboBoxFornecedor.SelectedIndexChanged += new System.EventHandler(this.comboBoxFornecedor_SelectedIndexChanged);
            this.comboBoxFornecedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBoxFornecedor_KeyPress);
            this.comboBoxFornecedor.Leave += new System.EventHandler(this.comboBoxFornecedor_Leave);
            // 
            // pessoaBindingSource
            // 
            this.pessoaBindingSource.DataSource = typeof(Dominio.Pessoa);
            // 
            // solicitacoesCompraBindingSource
            // 
            this.solicitacoesCompraBindingSource.DataSource = typeof(Dominio.SolicitacoesCompra);
            // 
            // solicitacoesCompraDataGridView
            // 
            this.solicitacoesCompraDataGridView.AllowUserToAddRows = false;
            this.solicitacoesCompraDataGridView.AllowUserToDeleteRows = false;
            this.solicitacoesCompraDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.solicitacoesCompraDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.solicitacoesCompraDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.solicitacoesCompraDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            this.solicitacoesCompraDataGridView.DataSource = this.solicitacoesCompraBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.solicitacoesCompraDataGridView.DefaultCellStyle = dataGridViewCellStyle5;
            this.solicitacoesCompraDataGridView.Location = new System.Drawing.Point(9, 127);
            this.solicitacoesCompraDataGridView.Name = "solicitacoesCompraDataGridView";
            this.solicitacoesCompraDataGridView.ReadOnly = true;
            this.solicitacoesCompraDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.solicitacoesCompraDataGridView.Size = new System.Drawing.Size(851, 146);
            this.solicitacoesCompraDataGridView.TabIndex = 1;
            this.solicitacoesCompraDataGridView.CurrentCellChanged += new System.EventHandler(this.solicitacoesCompraDataGridView_CurrentCellChanged);
            this.solicitacoesCompraDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.solicitacoesCompraDataGridView_DataBindingComplete);
            // 
            // checkBoxDisponivel
            // 
            this.checkBoxDisponivel.AutoSize = true;
            this.checkBoxDisponivel.BackColor = System.Drawing.Color.White;
            this.checkBoxDisponivel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.checkBoxDisponivel.Location = new System.Drawing.Point(467, 72);
            this.checkBoxDisponivel.Name = "checkBoxDisponivel";
            this.checkBoxDisponivel.Size = new System.Drawing.Size(196, 24);
            this.checkBoxDisponivel.TabIndex = 3;
            this.checkBoxDisponivel.Text = "Disponivel - F9                ";
            this.checkBoxDisponivel.UseVisualStyleBackColor = false;
            this.checkBoxDisponivel.CheckedChanged += new System.EventHandler(this.comboBoxFornecedor_SelectedIndexChanged);
            // 
            // checkBoxComprado
            // 
            this.checkBoxComprado.AutoSize = true;
            this.checkBoxComprado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.checkBoxComprado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.checkBoxComprado.Location = new System.Drawing.Point(675, 72);
            this.checkBoxComprado.Name = "checkBoxComprado";
            this.checkBoxComprado.Size = new System.Drawing.Size(187, 24);
            this.checkBoxComprado.TabIndex = 4;
            this.checkBoxComprado.Text = "Comprado - F12           ";
            this.checkBoxComprado.UseVisualStyleBackColor = false;
            this.checkBoxComprado.CheckedChanged += new System.EventHandler(this.comboBoxFornecedor_SelectedIndexChanged);
            // 
            // checkBoxCompraUrgente
            // 
            this.checkBoxCompraUrgente.AutoSize = true;
            this.checkBoxCompraUrgente.BackColor = System.Drawing.Color.Red;
            this.checkBoxCompraUrgente.Checked = true;
            this.checkBoxCompraUrgente.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCompraUrgente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.checkBoxCompraUrgente.Location = new System.Drawing.Point(675, 42);
            this.checkBoxCompraUrgente.Name = "checkBoxCompraUrgente";
            this.checkBoxCompraUrgente.Size = new System.Drawing.Size(187, 24);
            this.checkBoxCompraUrgente.TabIndex = 6;
            this.checkBoxCompraUrgente.Text = "Compra Urgente - F11";
            this.checkBoxCompraUrgente.UseVisualStyleBackColor = false;
            this.checkBoxCompraUrgente.CheckStateChanged += new System.EventHandler(this.comboBoxFornecedor_SelectedIndexChanged);
            // 
            // checkBoxNaoComprar
            // 
            this.checkBoxNaoComprar.AutoSize = true;
            this.checkBoxNaoComprar.BackColor = System.Drawing.Color.Black;
            this.checkBoxNaoComprar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.checkBoxNaoComprar.ForeColor = System.Drawing.Color.White;
            this.checkBoxNaoComprar.Location = new System.Drawing.Point(467, 43);
            this.checkBoxNaoComprar.Name = "checkBoxNaoComprar";
            this.checkBoxNaoComprar.Size = new System.Drawing.Size(194, 24);
            this.checkBoxNaoComprar.TabIndex = 131;
            this.checkBoxNaoComprar.Text = "Não Comprar - F8          ";
            this.checkBoxNaoComprar.UseVisualStyleBackColor = false;
            this.checkBoxNaoComprar.CheckStateChanged += new System.EventHandler(this.comboBoxFornecedor_SelectedIndexChanged);
            // 
            // checkBoxSolicitacaoCompra
            // 
            this.checkBoxSolicitacaoCompra.AutoSize = true;
            this.checkBoxSolicitacaoCompra.BackColor = System.Drawing.Color.Yellow;
            this.checkBoxSolicitacaoCompra.Checked = true;
            this.checkBoxSolicitacaoCompra.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSolicitacaoCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.checkBoxSolicitacaoCompra.Location = new System.Drawing.Point(465, 100);
            this.checkBoxSolicitacaoCompra.Name = "checkBoxSolicitacaoCompra";
            this.checkBoxSolicitacaoCompra.Size = new System.Drawing.Size(198, 24);
            this.checkBoxSolicitacaoCompra.TabIndex = 5;
            this.checkBoxSolicitacaoCompra.Text = "Compra Solicitada - F10";
            this.checkBoxSolicitacaoCompra.UseVisualStyleBackColor = false;
            this.checkBoxSolicitacaoCompra.CheckStateChanged += new System.EventHandler(this.comboBoxFornecedor_SelectedIndexChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CodProduto";
            this.dataGridViewTextBoxColumn1.FillWeight = 15F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Código";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Nome";
            this.dataGridViewTextBoxColumn4.FillWeight = 80F;
            this.dataGridViewTextBoxColumn4.HeaderText = "Produto";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ReferenciaFabricante";
            this.dataGridViewTextBoxColumn5.FillWeight = 25F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Ref Fabricante";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "DataSolicitacaoCompra";
            this.dataGridViewTextBoxColumn7.FillWeight = 18F;
            this.dataGridViewTextBoxColumn7.HeaderText = "Data Solicitação";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "DataPedidoCompra";
            this.dataGridViewTextBoxColumn8.FillWeight = 18F;
            this.dataGridViewTextBoxColumn8.HeaderText = "Data Pedido";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "CodSituacaoProduto";
            this.dataGridViewTextBoxColumn9.HeaderText = "CodSituacaoProduto";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // FrmProdutoSolicitacoesCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 695);
            this.ControlBox = false;
            this.Controls.Add(this.checkBoxNaoComprar);
            this.Controls.Add(this.checkBoxCompraUrgente);
            this.Controls.Add(this.checkBoxComprado);
            this.Controls.Add(this.checkBoxSolicitacaoCompra);
            this.Controls.Add(this.checkBoxDisponivel);
            this.Controls.Add(this.solicitacoesCompraDataGridView);
            this.Controls.Add(label6);
            this.Controls.Add(this.comboBoxFornecedor);
            this.Controls.Add(this.label2);
            this.Controls.Add(codProdutoLabel);
            this.Controls.Add(this.tb_produto_lojaDataGridView);
            this.Controls.Add(this.entradasPorProdutoDataGridView);
            this.Controls.Add(this.vendidos18textBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.vendidos12textBox);
            this.Controls.Add(this.vendidos6textBox);
            this.Controls.Add(this.vendidos3textBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ProdutosGroupBox);
            this.Controls.Add(this.label13);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "FrmProdutoSolicitacoesCompra";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Solicitações de Compras de Produto";
            this.Load += new System.EventHandler(this.FrmProdutoEstatistica_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmProdutoEstatistica_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ProdutosGroupBox.ResumeLayout(false);
            this.ProdutosGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.produtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtosVendidosTableAdapterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSetConsultas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entradasPorProdutoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.entradasPorProdutoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoLojaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produto_lojaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pessoaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.solicitacoesCompraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.solicitacoesCompraDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox ProdutosGroupBox;
        private System.Windows.Forms.TextBox valorUnitarioTextBox;
        private System.Windows.Forms.BindingSource produtoBindingSource;
        private System.Windows.Forms.TextBox precoVendaAtacadoTextBox;
        private System.Windows.Forms.TextBox qtdProdutoAtacadoTextBox;
        private System.Windows.Forms.TextBox precoVendaVarejoTextBox;
        private System.Windows.Forms.TextBox lucroPrecoVendaVarejoTextBox;
        private System.Windows.Forms.TextBox lucroPrecoVendaAtacadoTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox precoAtacadoSugestaoTextBox;
        private System.Windows.Forms.TextBox precoVarejoSugestaoTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox preco_custoTextBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox vendidos3textBox;
        private System.Windows.Forms.TextBox vendidos6textBox;
        private System.Windows.Forms.TextBox vendidos12textBox;
        private System.Windows.Forms.BindingSource produtosVendidosTableAdapterBindingSource;
        private System.Windows.Forms.TextBox vendidos18textBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.BindingSource entradasPorProdutoBindingSource;
        private System.Windows.Forms.DataGridView entradasPorProdutoDataGridView;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.BindingSource produtoLojaBindingSource;
        private System.Windows.Forms.DataGridView tb_produto_lojaDataGridView;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn codLojaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeLojaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdEstoqueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdEstoqueAuxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataEntrada;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCST;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.ComboBox comboBoxFornecedor;
        private System.Windows.Forms.BindingSource pessoaBindingSource;
        private System.Windows.Forms.BindingSource solicitacoesCompraBindingSource;
        private System.Windows.Forms.DataGridView solicitacoesCompraDataGridView;
        private System.Windows.Forms.CheckBox checkBoxDisponivel;
        private System.Windows.Forms.CheckBox checkBoxComprado;
        private System.Windows.Forms.CheckBox checkBoxCompraUrgente;
        private System.Windows.Forms.CheckBox checkBoxNaoComprar;
        private System.Windows.Forms.CheckBox checkBoxSolicitacaoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
    }
}