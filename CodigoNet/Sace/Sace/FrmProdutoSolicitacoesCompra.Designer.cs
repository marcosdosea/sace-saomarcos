namespace Sace
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
            components = new System.ComponentModel.Container();
            Label valorUnitarioLabel;
            Label lucroPrecoVendaAtacadoLabel;
            Label lucroPrecoVendaVarejoLabel;
            Label precoVendaVarejoLabel;
            Label qtdProdutoAtacadoLabel;
            Label precoVendaAtacadoLabel;
            Label preco_custoLabel;
            Label codProdutoLabel;
            Label label6;
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            label1 = new Label();
            panel1 = new Panel();
            ProdutosGroupBox = new GroupBox();
            preco_custoTextBox = new TextBox();
            label3 = new Label();
            precoVendaAtacadoTextBox = new TextBox();
            produtoBindingSource = new BindingSource(components);
            precoAtacadoSugestaoTextBox = new TextBox();
            qtdProdutoAtacadoTextBox = new TextBox();
            precoVarejoSugestaoTextBox = new TextBox();
            precoVendaVarejoTextBox = new TextBox();
            label4 = new Label();
            lucroPrecoVendaVarejoTextBox = new TextBox();
            lucroPrecoVendaAtacadoTextBox = new TextBox();
            valorUnitarioTextBox = new TextBox();
            chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            produtoVendidoBindingSource = new BindingSource(components);
            label5 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            vendidos3textBox = new TextBox();
            vendidos6textBox = new TextBox();
            vendidos12textBox = new TextBox();
            vendidos18textBox = new TextBox();
            label12 = new Label();
            entradasPorProdutoBindingSource = new BindingSource(components);
            entradasPorProdutoDataGridView = new DataGridView();
            label11 = new Label();
            produtoLojaBindingSource = new BindingSource(components);
            tb_produto_lojaDataGridView = new DataGridView();
            codLojaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeLojaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            qtdEstoqueDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            qtdEstoqueAuxDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            label13 = new Label();
            label2 = new Label();
            comboBoxFornecedor = new ComboBox();
            pessoaBindingSource = new BindingSource(components);
            solicitacoesCompraBindingSource = new BindingSource(components);
            solicitacoesCompraDataGridView = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            checkBoxDisponivel = new CheckBox();
            checkBoxComprado = new CheckBox();
            checkBoxCompraUrgente = new CheckBox();
            checkBoxNaoComprar = new CheckBox();
            checkBoxSolicitacaoCompra = new CheckBox();
            dataEntrada = new DataGridViewTextBoxColumn();
            codEntradaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            unidadeCompraDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            quantidadeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valorTotalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            codFornecedorDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valorUnitarioLabel = new Label();
            lucroPrecoVendaAtacadoLabel = new Label();
            lucroPrecoVendaVarejoLabel = new Label();
            precoVendaVarejoLabel = new Label();
            qtdProdutoAtacadoLabel = new Label();
            precoVendaAtacadoLabel = new Label();
            preco_custoLabel = new Label();
            codProdutoLabel = new Label();
            label6 = new Label();
            panel1.SuspendLayout();
            ProdutosGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)produtoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chart1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)produtoVendidoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)entradasPorProdutoBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)entradasPorProdutoDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)produtoLojaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tb_produto_lojaDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pessoaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)solicitacoesCompraBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)solicitacoesCompraDataGridView).BeginInit();
            SuspendLayout();
            // 
            // valorUnitarioLabel
            // 
            valorUnitarioLabel.AutoSize = true;
            valorUnitarioLabel.Location = new Point(7, 20);
            valorUnitarioLabel.Margin = new Padding(4, 0, 4, 0);
            valorUnitarioLabel.Name = "valorUnitarioLabel";
            valorUnitarioLabel.Size = new Size(108, 15);
            valorUnitarioLabel.TabIndex = 8;
            valorUnitarioLabel.Text = "Pç Último Compra:";
            // 
            // lucroPrecoVendaAtacadoLabel
            // 
            lucroPrecoVendaAtacadoLabel.AutoSize = true;
            lucroPrecoVendaAtacadoLabel.Location = new Point(632, 22);
            lucroPrecoVendaAtacadoLabel.Margin = new Padding(4, 0, 4, 0);
            lucroPrecoVendaAtacadoLabel.Name = "lucroPrecoVendaAtacadoLabel";
            lucroPrecoVendaAtacadoLabel.Size = new Size(80, 15);
            lucroPrecoVendaAtacadoLabel.TabIndex = 40;
            lucroPrecoVendaAtacadoLabel.Text = "% Lucro Atac:";
            // 
            // lucroPrecoVendaVarejoLabel
            // 
            lucroPrecoVendaVarejoLabel.AutoSize = true;
            lucroPrecoVendaVarejoLabel.Location = new Point(219, 22);
            lucroPrecoVendaVarejoLabel.Margin = new Padding(4, 0, 4, 0);
            lucroPrecoVendaVarejoLabel.Name = "lucroPrecoVendaVarejoLabel";
            lucroPrecoVendaVarejoLabel.Size = new Size(73, 15);
            lucroPrecoVendaVarejoLabel.TabIndex = 42;
            lucroPrecoVendaVarejoLabel.Text = "% Lucro Vjo:";
            // 
            // precoVendaVarejoLabel
            // 
            precoVendaVarejoLabel.AutoSize = true;
            precoVendaVarejoLabel.Location = new Point(416, 22);
            precoVendaVarejoLabel.Margin = new Padding(4, 0, 4, 0);
            precoVendaVarejoLabel.Name = "precoVendaVarejoLabel";
            precoVendaVarejoLabel.Size = new Size(106, 15);
            precoVendaVarejoLabel.TabIndex = 44;
            precoVendaVarejoLabel.Text = "Preço Varejo Atual:";
            // 
            // qtdProdutoAtacadoLabel
            // 
            qtdProdutoAtacadoLabel.AutoSize = true;
            qtdProdutoAtacadoLabel.Location = new Point(547, 22);
            qtdProdutoAtacadoLabel.Margin = new Padding(4, 0, 4, 0);
            qtdProdutoAtacadoLabel.Name = "qtdProdutoAtacadoLabel";
            qtdProdutoAtacadoLabel.Size = new Size(77, 15);
            qtdProdutoAtacadoLabel.TabIndex = 46;
            qtdProdutoAtacadoLabel.Text = "Qtd Atacado:";
            // 
            // precoVendaAtacadoLabel
            // 
            precoVendaAtacadoLabel.AutoSize = true;
            precoVendaAtacadoLabel.Location = new Point(847, 22);
            precoVendaAtacadoLabel.Margin = new Padding(4, 0, 4, 0);
            precoVendaAtacadoLabel.Name = "precoVendaAtacadoLabel";
            precoVendaAtacadoLabel.Size = new Size(118, 15);
            precoVendaAtacadoLabel.TabIndex = 48;
            precoVendaAtacadoLabel.Text = "Preço Atacado Atual:";
            // 
            // preco_custoLabel
            // 
            preco_custoLabel.AutoSize = true;
            preco_custoLabel.Location = new Point(122, 22);
            preco_custoLabel.Margin = new Padding(4, 0, 4, 0);
            preco_custoLabel.Name = "preco_custoLabel";
            preco_custoLabel.Size = new Size(74, 15);
            preco_custoLabel.TabIndex = 115;
            preco_custoLabel.Text = "Preço Custo:";
            // 
            // codProdutoLabel
            // 
            codProdutoLabel.AutoSize = true;
            codProdutoLabel.Font = new Font("Microsoft Sans Serif", 12F);
            codProdutoLabel.Location = new Point(8, 120);
            codProdutoLabel.Margin = new Padding(4, 0, 4, 0);
            codProdutoLabel.Name = "codProdutoLabel";
            codProdutoLabel.Size = new Size(77, 20);
            codProdutoLabel.TabIndex = 126;
            codProdutoLabel.Text = "Produtos:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F);
            label6.Location = new Point(6, 48);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(254, 20);
            label6.TabIndex = 130;
            label6.Text = "Filtrar por Fornecedor / Fabricante:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(4, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(276, 23);
            label1.TabIndex = 0;
            label1.Text = "Solicitações de Compras de Produtos";
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1017, 45);
            panel1.TabIndex = 20;
            // 
            // ProdutosGroupBox
            // 
            ProdutosGroupBox.Controls.Add(preco_custoLabel);
            ProdutosGroupBox.Controls.Add(preco_custoTextBox);
            ProdutosGroupBox.Controls.Add(label3);
            ProdutosGroupBox.Controls.Add(precoVendaAtacadoLabel);
            ProdutosGroupBox.Controls.Add(precoVendaAtacadoTextBox);
            ProdutosGroupBox.Controls.Add(qtdProdutoAtacadoLabel);
            ProdutosGroupBox.Controls.Add(precoAtacadoSugestaoTextBox);
            ProdutosGroupBox.Controls.Add(qtdProdutoAtacadoTextBox);
            ProdutosGroupBox.Controls.Add(precoVarejoSugestaoTextBox);
            ProdutosGroupBox.Controls.Add(precoVendaVarejoLabel);
            ProdutosGroupBox.Controls.Add(precoVendaVarejoTextBox);
            ProdutosGroupBox.Controls.Add(label4);
            ProdutosGroupBox.Controls.Add(lucroPrecoVendaVarejoLabel);
            ProdutosGroupBox.Controls.Add(lucroPrecoVendaVarejoTextBox);
            ProdutosGroupBox.Controls.Add(lucroPrecoVendaAtacadoLabel);
            ProdutosGroupBox.Controls.Add(lucroPrecoVendaAtacadoTextBox);
            ProdutosGroupBox.Controls.Add(valorUnitarioLabel);
            ProdutosGroupBox.Controls.Add(valorUnitarioTextBox);
            ProdutosGroupBox.Location = new Point(2, 322);
            ProdutosGroupBox.Margin = new Padding(4, 3, 4, 3);
            ProdutosGroupBox.Name = "ProdutosGroupBox";
            ProdutosGroupBox.Padding = new Padding(4, 3, 4, 3);
            ProdutosGroupBox.Size = new Size(1001, 97);
            ProdutosGroupBox.TabIndex = 76;
            ProdutosGroupBox.TabStop = false;
            ProdutosGroupBox.Text = "Dados do Produto";
            // 
            // preco_custoTextBox
            // 
            preco_custoTextBox.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            preco_custoTextBox.Location = new Point(126, 40);
            preco_custoTextBox.Margin = new Padding(4, 3, 4, 3);
            preco_custoTextBox.Name = "preco_custoTextBox";
            preco_custoTextBox.ReadOnly = true;
            preco_custoTextBox.Size = new Size(90, 22);
            preco_custoTextBox.TabIndex = 76;
            preco_custoTextBox.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(726, 22);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(101, 15);
            label3.TabIndex = 115;
            label3.Text = "Pç Atac Sugestão:";
            // 
            // precoVendaAtacadoTextBox
            // 
            precoVendaAtacadoTextBox.DataBindings.Add(new Binding("Text", produtoBindingSource, "precoVendaAtacado", true));
            precoVendaAtacadoTextBox.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            precoVendaAtacadoTextBox.ForeColor = Color.Red;
            precoVendaAtacadoTextBox.Location = new Point(850, 40);
            precoVendaAtacadoTextBox.Margin = new Padding(4, 3, 4, 3);
            precoVendaAtacadoTextBox.Name = "precoVendaAtacadoTextBox";
            precoVendaAtacadoTextBox.ReadOnly = true;
            precoVendaAtacadoTextBox.Size = new Size(122, 24);
            precoVendaAtacadoTextBox.TabIndex = 102;
            precoVendaAtacadoTextBox.TabStop = false;
            // 
            // produtoBindingSource
            // 
            produtoBindingSource.DataSource = typeof(Dominio.Produto);
            produtoBindingSource.Sort = "nome";
            // 
            // precoAtacadoSugestaoTextBox
            // 
            precoAtacadoSugestaoTextBox.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            precoAtacadoSugestaoTextBox.Location = new Point(726, 40);
            precoAtacadoSugestaoTextBox.Margin = new Padding(4, 3, 4, 3);
            precoAtacadoSugestaoTextBox.Name = "precoAtacadoSugestaoTextBox";
            precoAtacadoSugestaoTextBox.ReadOnly = true;
            precoAtacadoSugestaoTextBox.Size = new Size(115, 22);
            precoAtacadoSugestaoTextBox.TabIndex = 100;
            precoAtacadoSugestaoTextBox.TabStop = false;
            // 
            // qtdProdutoAtacadoTextBox
            // 
            qtdProdutoAtacadoTextBox.DataBindings.Add(new Binding("Text", produtoBindingSource, "qtdProdutoAtacado", true));
            qtdProdutoAtacadoTextBox.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            qtdProdutoAtacadoTextBox.Location = new Point(551, 40);
            qtdProdutoAtacadoTextBox.Margin = new Padding(4, 3, 4, 3);
            qtdProdutoAtacadoTextBox.Name = "qtdProdutoAtacadoTextBox";
            qtdProdutoAtacadoTextBox.ReadOnly = true;
            qtdProdutoAtacadoTextBox.Size = new Size(78, 22);
            qtdProdutoAtacadoTextBox.TabIndex = 96;
            qtdProdutoAtacadoTextBox.TabStop = false;
            // 
            // precoVarejoSugestaoTextBox
            // 
            precoVarejoSugestaoTextBox.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            precoVarejoSugestaoTextBox.ForeColor = Color.Black;
            precoVarejoSugestaoTextBox.Location = new Point(302, 40);
            precoVarejoSugestaoTextBox.Margin = new Padding(4, 3, 4, 3);
            precoVarejoSugestaoTextBox.Name = "precoVarejoSugestaoTextBox";
            precoVarejoSugestaoTextBox.ReadOnly = true;
            precoVarejoSugestaoTextBox.Size = new Size(110, 22);
            precoVarejoSugestaoTextBox.TabIndex = 92;
            precoVarejoSugestaoTextBox.TabStop = false;
            // 
            // precoVendaVarejoTextBox
            // 
            precoVendaVarejoTextBox.DataBindings.Add(new Binding("Text", produtoBindingSource, "precoVendaVarejo", true));
            precoVendaVarejoTextBox.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            precoVendaVarejoTextBox.ForeColor = Color.Red;
            precoVendaVarejoTextBox.Location = new Point(420, 40);
            precoVendaVarejoTextBox.Margin = new Padding(4, 3, 4, 3);
            precoVendaVarejoTextBox.Name = "precoVendaVarejoTextBox";
            precoVendaVarejoTextBox.ReadOnly = true;
            precoVendaVarejoTextBox.Size = new Size(122, 24);
            precoVendaVarejoTextBox.TabIndex = 94;
            precoVendaVarejoTextBox.TabStop = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(302, 22);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(101, 15);
            label4.TabIndex = 114;
            label4.Text = "Pço Vjo Sugestão:";
            // 
            // lucroPrecoVendaVarejoTextBox
            // 
            lucroPrecoVendaVarejoTextBox.DataBindings.Add(new Binding("Text", produtoBindingSource, "lucroPrecoVendaVarejo", true));
            lucroPrecoVendaVarejoTextBox.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lucroPrecoVendaVarejoTextBox.Location = new Point(223, 40);
            lucroPrecoVendaVarejoTextBox.Margin = new Padding(4, 3, 4, 3);
            lucroPrecoVendaVarejoTextBox.Name = "lucroPrecoVendaVarejoTextBox";
            lucroPrecoVendaVarejoTextBox.ReadOnly = true;
            lucroPrecoVendaVarejoTextBox.Size = new Size(73, 22);
            lucroPrecoVendaVarejoTextBox.TabIndex = 90;
            lucroPrecoVendaVarejoTextBox.TabStop = false;
            // 
            // lucroPrecoVendaAtacadoTextBox
            // 
            lucroPrecoVendaAtacadoTextBox.DataBindings.Add(new Binding("Text", produtoBindingSource, "lucroPrecoVendaAtacado", true));
            lucroPrecoVendaAtacadoTextBox.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lucroPrecoVendaAtacadoTextBox.Location = new Point(636, 40);
            lucroPrecoVendaAtacadoTextBox.Margin = new Padding(4, 3, 4, 3);
            lucroPrecoVendaAtacadoTextBox.Name = "lucroPrecoVendaAtacadoTextBox";
            lucroPrecoVendaAtacadoTextBox.ReadOnly = true;
            lucroPrecoVendaAtacadoTextBox.Size = new Size(86, 22);
            lucroPrecoVendaAtacadoTextBox.TabIndex = 98;
            lucroPrecoVendaAtacadoTextBox.TabStop = false;
            // 
            // valorUnitarioTextBox
            // 
            valorUnitarioTextBox.DataBindings.Add(new Binding("Text", produtoBindingSource, "ultimoPrecoCompra", true));
            valorUnitarioTextBox.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            valorUnitarioTextBox.Location = new Point(8, 40);
            valorUnitarioTextBox.Margin = new Padding(4, 3, 4, 3);
            valorUnitarioTextBox.Name = "valorUnitarioTextBox";
            valorUnitarioTextBox.ReadOnly = true;
            valorUnitarioTextBox.Size = new Size(108, 22);
            valorUnitarioTextBox.TabIndex = 60;
            valorUnitarioTextBox.TabStop = false;
            // 
            // chart1
            // 
            chart1.BackColor = Color.LightGray;
            chart1.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.DarkDownwardDiagonal;
            chart1.BackImageTransparentColor = Color.FromArgb(224, 224, 224);
            chart1.BackSecondaryColor = Color.FromArgb(224, 224, 224);
            chartArea1.Name = "ChartArea1";
            chart1.ChartAreas.Add(chartArea1);
            chart1.DataSource = produtoVendidoBindingSource;
            chart1.Location = new Point(2, 532);
            chart1.Margin = new Padding(4, 3, 4, 3);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.IsXValueIndexed = true;
            series1.Name = "Series1";
            chart1.Series.Add(series1);
            chart1.Size = new Size(1001, 150);
            chart1.TabIndex = 113;
            chart1.Text = "chart1";
            // 
            // produtoVendidoBindingSource
            // 
            produtoVendidoBindingSource.DataSource = typeof(Dominio.ProdutoVendido);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(5, 505);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(186, 18);
            label5.TabIndex = 115;
            label5.Text = "Gráfico Mensal de Vendas:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Red;
            label8.Location = new Point(12, 428);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(65, 15);
            label8.TabIndex = 116;
            label8.Text = "3 meses:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Red;
            label9.Location = new Point(12, 473);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(65, 15);
            label9.TabIndex = 117;
            label9.Text = "6 meses:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Red;
            label10.Location = new Point(252, 429);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(73, 15);
            label10.TabIndex = 118;
            label10.Text = "12 meses:";
            // 
            // vendidos3textBox
            // 
            vendidos3textBox.Location = new Point(94, 428);
            vendidos3textBox.Margin = new Padding(4, 3, 4, 3);
            vendidos3textBox.Name = "vendidos3textBox";
            vendidos3textBox.ReadOnly = true;
            vendidos3textBox.Size = new Size(149, 23);
            vendidos3textBox.TabIndex = 104;
            vendidos3textBox.TabStop = false;
            // 
            // vendidos6textBox
            // 
            vendidos6textBox.Location = new Point(94, 474);
            vendidos6textBox.Margin = new Padding(4, 3, 4, 3);
            vendidos6textBox.Name = "vendidos6textBox";
            vendidos6textBox.ReadOnly = true;
            vendidos6textBox.Size = new Size(145, 23);
            vendidos6textBox.TabIndex = 106;
            vendidos6textBox.TabStop = false;
            // 
            // vendidos12textBox
            // 
            vendidos12textBox.Location = new Point(344, 427);
            vendidos12textBox.Margin = new Padding(4, 3, 4, 3);
            vendidos12textBox.Name = "vendidos12textBox";
            vendidos12textBox.ReadOnly = true;
            vendidos12textBox.Size = new Size(150, 23);
            vendidos12textBox.TabIndex = 108;
            vendidos12textBox.TabStop = false;
            // 
            // vendidos18textBox
            // 
            vendidos18textBox.Location = new Point(344, 474);
            vendidos18textBox.Margin = new Padding(4, 3, 4, 3);
            vendidos18textBox.Name = "vendidos18textBox";
            vendidos18textBox.ReadOnly = true;
            vendidos18textBox.Size = new Size(150, 23);
            vendidos18textBox.TabIndex = 123;
            vendidos18textBox.TabStop = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Red;
            label12.Location = new Point(252, 474);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(73, 15);
            label12.TabIndex = 124;
            label12.Text = "18 meses:";
            // 
            // entradasPorProdutoBindingSource
            // 
            entradasPorProdutoBindingSource.DataSource = typeof(Dominio.EntradaProduto);
            // 
            // entradasPorProdutoDataGridView
            // 
            entradasPorProdutoDataGridView.AllowUserToAddRows = false;
            entradasPorProdutoDataGridView.AllowUserToDeleteRows = false;
            entradasPorProdutoDataGridView.AutoGenerateColumns = false;
            entradasPorProdutoDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            entradasPorProdutoDataGridView.Columns.AddRange(new DataGridViewColumn[] { dataEntrada, codEntradaDataGridViewTextBoxColumn, unidadeCompraDataGridViewTextBoxColumn, quantidadeDataGridViewTextBoxColumn, valorTotalDataGridViewTextBoxColumn, codFornecedorDataGridViewTextBoxColumn });
            entradasPorProdutoDataGridView.DataSource = entradasPorProdutoBindingSource;
            entradasPorProdutoDataGridView.Location = new Point(4, 708);
            entradasPorProdutoDataGridView.Margin = new Padding(4, 3, 4, 3);
            entradasPorProdutoDataGridView.MultiSelect = false;
            entradasPorProdutoDataGridView.Name = "entradasPorProdutoDataGridView";
            entradasPorProdutoDataGridView.ReadOnly = true;
            entradasPorProdutoDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            entradasPorProdutoDataGridView.Size = new Size(997, 87);
            entradasPorProdutoDataGridView.TabIndex = 124;
            entradasPorProdutoDataGridView.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(-1, 685);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(179, 18);
            label11.TabIndex = 122;
            label11.Text = "Últimas Entradas/Pedidos";
            // 
            // produtoLojaBindingSource
            // 
            produtoLojaBindingSource.DataSource = typeof(Dominio.ProdutoLoja);
            // 
            // tb_produto_lojaDataGridView
            // 
            tb_produto_lojaDataGridView.AllowUserToAddRows = false;
            tb_produto_lojaDataGridView.AllowUserToDeleteRows = false;
            tb_produto_lojaDataGridView.AutoGenerateColumns = false;
            tb_produto_lojaDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tb_produto_lojaDataGridView.Columns.AddRange(new DataGridViewColumn[] { codLojaDataGridViewTextBoxColumn, nomeLojaDataGridViewTextBoxColumn, qtdEstoqueDataGridViewTextBoxColumn, qtdEstoqueAuxDataGridViewTextBoxColumn });
            tb_produto_lojaDataGridView.DataSource = produtoLojaBindingSource;
            tb_produto_lojaDataGridView.Location = new Point(531, 427);
            tb_produto_lojaDataGridView.Margin = new Padding(4, 3, 4, 3);
            tb_produto_lojaDataGridView.MultiSelect = false;
            tb_produto_lojaDataGridView.Name = "tb_produto_lojaDataGridView";
            tb_produto_lojaDataGridView.ReadOnly = true;
            tb_produto_lojaDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tb_produto_lojaDataGridView.Size = new Size(472, 99);
            tb_produto_lojaDataGridView.TabIndex = 124;
            tb_produto_lojaDataGridView.TabStop = false;
            // 
            // codLojaDataGridViewTextBoxColumn
            // 
            codLojaDataGridViewTextBoxColumn.DataPropertyName = "CodLoja";
            codLojaDataGridViewTextBoxColumn.HeaderText = "CodLoja";
            codLojaDataGridViewTextBoxColumn.Name = "codLojaDataGridViewTextBoxColumn";
            codLojaDataGridViewTextBoxColumn.ReadOnly = true;
            codLojaDataGridViewTextBoxColumn.Visible = false;
            // 
            // nomeLojaDataGridViewTextBoxColumn
            // 
            nomeLojaDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nomeLojaDataGridViewTextBoxColumn.DataPropertyName = "NomeLoja";
            nomeLojaDataGridViewTextBoxColumn.HeaderText = "Loja";
            nomeLojaDataGridViewTextBoxColumn.Name = "nomeLojaDataGridViewTextBoxColumn";
            nomeLojaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtdEstoqueDataGridViewTextBoxColumn
            // 
            qtdEstoqueDataGridViewTextBoxColumn.DataPropertyName = "QtdEstoque";
            qtdEstoqueDataGridViewTextBoxColumn.HeaderText = "Estoque";
            qtdEstoqueDataGridViewTextBoxColumn.Name = "qtdEstoqueDataGridViewTextBoxColumn";
            qtdEstoqueDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtdEstoqueAuxDataGridViewTextBoxColumn
            // 
            qtdEstoqueAuxDataGridViewTextBoxColumn.DataPropertyName = "QtdEstoqueAux";
            qtdEstoqueAuxDataGridViewTextBoxColumn.HeaderText = "Estoque Aux";
            qtdEstoqueAuxDataGridViewTextBoxColumn.Name = "qtdEstoqueAuxDataGridViewTextBoxColumn";
            qtdEstoqueAuxDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Microsoft Sans Serif", 10F);
            label13.Location = new Point(527, 402);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(60, 17);
            label13.TabIndex = 125;
            label13.Text = "Estoque";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(4, 399);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(175, 18);
            label2.TabIndex = 128;
            label2.Text = "Total Produtos Vendidos:";
            // 
            // comboBoxFornecedor
            // 
            comboBoxFornecedor.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxFornecedor.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxFornecedor.CausesValidation = false;
            comboBoxFornecedor.DataSource = pessoaBindingSource;
            comboBoxFornecedor.DisplayMember = "NomeFantasia";
            comboBoxFornecedor.Font = new Font("Microsoft Sans Serif", 12F);
            comboBoxFornecedor.FormattingEnabled = true;
            comboBoxFornecedor.Location = new Point(8, 80);
            comboBoxFornecedor.Margin = new Padding(4, 3, 4, 3);
            comboBoxFornecedor.Name = "comboBoxFornecedor";
            comboBoxFornecedor.Size = new Size(524, 28);
            comboBoxFornecedor.TabIndex = 2;
            comboBoxFornecedor.ValueMember = "CodPessoa";
            comboBoxFornecedor.SelectedIndexChanged += comboBoxFornecedor_SelectedIndexChanged;
            comboBoxFornecedor.KeyPress += comboBoxFornecedor_KeyPress;
            comboBoxFornecedor.Leave += comboBoxFornecedor_Leave;
            // 
            // pessoaBindingSource
            // 
            pessoaBindingSource.DataSource = typeof(Dominio.Pessoa);
            // 
            // solicitacoesCompraBindingSource
            // 
            solicitacoesCompraBindingSource.DataSource = typeof(Dominio.SolicitacoesCompra);
            // 
            // solicitacoesCompraDataGridView
            // 
            solicitacoesCompraDataGridView.AllowUserToAddRows = false;
            solicitacoesCompraDataGridView.AllowUserToDeleteRows = false;
            solicitacoesCompraDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            solicitacoesCompraDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            solicitacoesCompraDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            solicitacoesCompraDataGridView.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9 });
            solicitacoesCompraDataGridView.DataSource = solicitacoesCompraBindingSource;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            solicitacoesCompraDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            solicitacoesCompraDataGridView.Location = new Point(10, 147);
            solicitacoesCompraDataGridView.Margin = new Padding(4, 3, 4, 3);
            solicitacoesCompraDataGridView.Name = "solicitacoesCompraDataGridView";
            solicitacoesCompraDataGridView.ReadOnly = true;
            solicitacoesCompraDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            solicitacoesCompraDataGridView.Size = new Size(993, 168);
            solicitacoesCompraDataGridView.TabIndex = 1;
            solicitacoesCompraDataGridView.CurrentCellChanged += solicitacoesCompraDataGridView_CurrentCellChanged;
            solicitacoesCompraDataGridView.DataBindingComplete += solicitacoesCompraDataGridView_DataBindingComplete;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn1.DataPropertyName = "CodProduto";
            dataGridViewTextBoxColumn1.FillWeight = 15F;
            dataGridViewTextBoxColumn1.HeaderText = "Código";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn4.DataPropertyName = "Nome";
            dataGridViewTextBoxColumn4.FillWeight = 80F;
            dataGridViewTextBoxColumn4.HeaderText = "Produto";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn5.DataPropertyName = "ReferenciaFabricante";
            dataGridViewTextBoxColumn5.FillWeight = 25F;
            dataGridViewTextBoxColumn5.HeaderText = "Ref Fabricante";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn7.DataPropertyName = "DataSolicitacaoCompra";
            dataGridViewTextBoxColumn7.FillWeight = 18F;
            dataGridViewTextBoxColumn7.HeaderText = "Data Solicitação";
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn8.DataPropertyName = "DataPedidoCompra";
            dataGridViewTextBoxColumn8.FillWeight = 18F;
            dataGridViewTextBoxColumn8.HeaderText = "Data Pedido";
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.DataPropertyName = "CodSituacaoProduto";
            dataGridViewTextBoxColumn9.HeaderText = "CodSituacaoProduto";
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            dataGridViewTextBoxColumn9.ReadOnly = true;
            dataGridViewTextBoxColumn9.Visible = false;
            // 
            // checkBoxDisponivel
            // 
            checkBoxDisponivel.AutoSize = true;
            checkBoxDisponivel.BackColor = Color.White;
            checkBoxDisponivel.Font = new Font("Microsoft Sans Serif", 12F);
            checkBoxDisponivel.Location = new Point(545, 83);
            checkBoxDisponivel.Margin = new Padding(4, 3, 4, 3);
            checkBoxDisponivel.Name = "checkBoxDisponivel";
            checkBoxDisponivel.Size = new Size(196, 24);
            checkBoxDisponivel.TabIndex = 3;
            checkBoxDisponivel.Text = "Disponivel - F9                ";
            checkBoxDisponivel.UseVisualStyleBackColor = false;
            checkBoxDisponivel.CheckedChanged += comboBoxFornecedor_SelectedIndexChanged;
            // 
            // checkBoxComprado
            // 
            checkBoxComprado.AutoSize = true;
            checkBoxComprado.BackColor = Color.FromArgb(0, 192, 0);
            checkBoxComprado.Font = new Font("Microsoft Sans Serif", 12F);
            checkBoxComprado.Location = new Point(788, 83);
            checkBoxComprado.Margin = new Padding(4, 3, 4, 3);
            checkBoxComprado.Name = "checkBoxComprado";
            checkBoxComprado.Size = new Size(187, 24);
            checkBoxComprado.TabIndex = 4;
            checkBoxComprado.Text = "Comprado - F12           ";
            checkBoxComprado.UseVisualStyleBackColor = false;
            checkBoxComprado.CheckedChanged += comboBoxFornecedor_SelectedIndexChanged;
            // 
            // checkBoxCompraUrgente
            // 
            checkBoxCompraUrgente.AutoSize = true;
            checkBoxCompraUrgente.BackColor = Color.Red;
            checkBoxCompraUrgente.Checked = true;
            checkBoxCompraUrgente.CheckState = CheckState.Checked;
            checkBoxCompraUrgente.Font = new Font("Microsoft Sans Serif", 12F);
            checkBoxCompraUrgente.Location = new Point(788, 48);
            checkBoxCompraUrgente.Margin = new Padding(4, 3, 4, 3);
            checkBoxCompraUrgente.Name = "checkBoxCompraUrgente";
            checkBoxCompraUrgente.Size = new Size(187, 24);
            checkBoxCompraUrgente.TabIndex = 6;
            checkBoxCompraUrgente.Text = "Compra Urgente - F11";
            checkBoxCompraUrgente.UseVisualStyleBackColor = false;
            checkBoxCompraUrgente.CheckStateChanged += comboBoxFornecedor_SelectedIndexChanged;
            // 
            // checkBoxNaoComprar
            // 
            checkBoxNaoComprar.AutoSize = true;
            checkBoxNaoComprar.BackColor = Color.Black;
            checkBoxNaoComprar.Font = new Font("Microsoft Sans Serif", 12F);
            checkBoxNaoComprar.ForeColor = Color.White;
            checkBoxNaoComprar.Location = new Point(545, 50);
            checkBoxNaoComprar.Margin = new Padding(4, 3, 4, 3);
            checkBoxNaoComprar.Name = "checkBoxNaoComprar";
            checkBoxNaoComprar.Size = new Size(194, 24);
            checkBoxNaoComprar.TabIndex = 131;
            checkBoxNaoComprar.Text = "Não Comprar - F8          ";
            checkBoxNaoComprar.UseVisualStyleBackColor = false;
            checkBoxNaoComprar.CheckStateChanged += comboBoxFornecedor_SelectedIndexChanged;
            // 
            // checkBoxSolicitacaoCompra
            // 
            checkBoxSolicitacaoCompra.AutoSize = true;
            checkBoxSolicitacaoCompra.BackColor = Color.Yellow;
            checkBoxSolicitacaoCompra.Checked = true;
            checkBoxSolicitacaoCompra.CheckState = CheckState.Checked;
            checkBoxSolicitacaoCompra.Font = new Font("Microsoft Sans Serif", 12F);
            checkBoxSolicitacaoCompra.Location = new Point(542, 115);
            checkBoxSolicitacaoCompra.Margin = new Padding(4, 3, 4, 3);
            checkBoxSolicitacaoCompra.Name = "checkBoxSolicitacaoCompra";
            checkBoxSolicitacaoCompra.Size = new Size(198, 24);
            checkBoxSolicitacaoCompra.TabIndex = 5;
            checkBoxSolicitacaoCompra.Text = "Compra Solicitada - F10";
            checkBoxSolicitacaoCompra.UseVisualStyleBackColor = false;
            checkBoxSolicitacaoCompra.CheckStateChanged += comboBoxFornecedor_SelectedIndexChanged;
            // 
            // dataEntrada
            // 
            dataEntrada.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataEntrada.DataPropertyName = "dataEntrada";
            dataEntrada.HeaderText = "Data";
            dataEntrada.Name = "dataEntrada";
            dataEntrada.ReadOnly = true;
            dataEntrada.Width = 56;
            // 
            // codEntradaDataGridViewTextBoxColumn
            // 
            codEntradaDataGridViewTextBoxColumn.DataPropertyName = "CodEntrada";
            codEntradaDataGridViewTextBoxColumn.HeaderText = "CodEntrada";
            codEntradaDataGridViewTextBoxColumn.Name = "codEntradaDataGridViewTextBoxColumn";
            codEntradaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // unidadeCompraDataGridViewTextBoxColumn
            // 
            unidadeCompraDataGridViewTextBoxColumn.DataPropertyName = "UnidadeCompra";
            unidadeCompraDataGridViewTextBoxColumn.HeaderText = "UnidadeCompra";
            unidadeCompraDataGridViewTextBoxColumn.Name = "unidadeCompraDataGridViewTextBoxColumn";
            unidadeCompraDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantidadeDataGridViewTextBoxColumn
            // 
            quantidadeDataGridViewTextBoxColumn.DataPropertyName = "Quantidade";
            quantidadeDataGridViewTextBoxColumn.HeaderText = "Quantidade";
            quantidadeDataGridViewTextBoxColumn.Name = "quantidadeDataGridViewTextBoxColumn";
            quantidadeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorTotalDataGridViewTextBoxColumn
            // 
            valorTotalDataGridViewTextBoxColumn.DataPropertyName = "ValorTotal";
            valorTotalDataGridViewTextBoxColumn.HeaderText = "ValorTotal";
            valorTotalDataGridViewTextBoxColumn.Name = "valorTotalDataGridViewTextBoxColumn";
            valorTotalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codFornecedorDataGridViewTextBoxColumn
            // 
            codFornecedorDataGridViewTextBoxColumn.DataPropertyName = "CodFornecedor";
            codFornecedorDataGridViewTextBoxColumn.HeaderText = "CodFornecedor";
            codFornecedorDataGridViewTextBoxColumn.Name = "codFornecedorDataGridViewTextBoxColumn";
            codFornecedorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FrmProdutoSolicitacoesCompra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1016, 802);
            ControlBox = false;
            Controls.Add(checkBoxNaoComprar);
            Controls.Add(checkBoxCompraUrgente);
            Controls.Add(checkBoxComprado);
            Controls.Add(checkBoxSolicitacaoCompra);
            Controls.Add(checkBoxDisponivel);
            Controls.Add(solicitacoesCompraDataGridView);
            Controls.Add(label6);
            Controls.Add(comboBoxFornecedor);
            Controls.Add(label2);
            Controls.Add(codProdutoLabel);
            Controls.Add(tb_produto_lojaDataGridView);
            Controls.Add(entradasPorProdutoDataGridView);
            Controls.Add(vendidos18textBox);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(vendidos12textBox);
            Controls.Add(vendidos6textBox);
            Controls.Add(vendidos3textBox);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label5);
            Controls.Add(chart1);
            Controls.Add(panel1);
            Controls.Add(ProdutosGroupBox);
            Controls.Add(label13);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmProdutoSolicitacoesCompra";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Solicitações de Compras de Produto";
            Load += FrmProdutoEstatistica_Load;
            KeyDown += FrmProdutoEstatistica_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ProdutosGroupBox.ResumeLayout(false);
            ProdutosGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)produtoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)chart1).EndInit();
            ((System.ComponentModel.ISupportInitialize)produtoVendidoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)entradasPorProdutoBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)entradasPorProdutoDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)produtoLojaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)tb_produto_lojaDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)pessoaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)solicitacoesCompraBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)solicitacoesCompraDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.BindingSource produtoVendidoBindingSource;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
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
        private DataGridViewTextBoxColumn dataEntrada;
        private DataGridViewTextBoxColumn codEntradaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn unidadeCompraDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn quantidadeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valorTotalDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn codFornecedorDataGridViewTextBoxColumn;
    }
}