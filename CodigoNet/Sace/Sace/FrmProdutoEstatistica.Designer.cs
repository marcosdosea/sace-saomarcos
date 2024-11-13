namespace Sace
{
    partial class FrmProdutoEstatistica
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
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
            dataEntrada = new DataGridViewTextBoxColumn();
            codCST = new DataGridViewTextBoxColumn();
            quantidade = new DataGridViewTextBoxColumn();
            label11 = new Label();
            produtoLojaBindingSource = new BindingSource(components);
            tb_produto_lojaDataGridView = new DataGridView();
            codLojaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeLojaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            qtdEstoqueDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            qtdEstoqueAuxDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            label13 = new Label();
            codProdutoComboBox = new ComboBox();
            label2 = new Label();
            pessoaBindingSource = new BindingSource(components);
            valorUnitarioLabel = new Label();
            lucroPrecoVendaAtacadoLabel = new Label();
            lucroPrecoVendaVarejoLabel = new Label();
            precoVendaVarejoLabel = new Label();
            qtdProdutoAtacadoLabel = new Label();
            precoVendaAtacadoLabel = new Label();
            preco_custoLabel = new Label();
            codProdutoLabel = new Label();
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
            codProdutoLabel.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            codProdutoLabel.Location = new Point(8, 53);
            codProdutoLabel.Margin = new Padding(4, 0, 4, 0);
            codProdutoLabel.Name = "codProdutoLabel";
            codProdutoLabel.Size = new Size(81, 24);
            codProdutoLabel.TabIndex = 126;
            codProdutoLabel.Text = "Produto:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(4, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(179, 23);
            label1.TabIndex = 0;
            label1.Text = "Estatísticas do Produto";
            // 
            // panel1
            // 
            panel1.BackColor = Color.SteelBlue;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(5, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1017, 47);
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
            ProdutosGroupBox.Location = new Point(2, 128);
            ProdutosGroupBox.Margin = new Padding(4, 3, 4, 3);
            ProdutosGroupBox.Name = "ProdutosGroupBox";
            ProdutosGroupBox.Padding = new Padding(4, 3, 4, 3);
            ProdutosGroupBox.Size = new Size(1001, 72);
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
            chart1.Location = new Point(2, 342);
            chart1.Margin = new Padding(4, 3, 4, 3);
            chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.IsXValueIndexed = true;
            series1.Name = "Series1";
            series1.XValueMember = "MesAno";
            series1.YValueMembers = "QuantidadeVendida";
            chart1.Series.Add(series1);
            chart1.Size = new Size(1001, 165);
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
            label5.Location = new Point(5, 312);
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
            label8.Location = new Point(12, 234);
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
            label9.Location = new Point(12, 279);
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
            label10.Location = new Point(252, 235);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(73, 15);
            label10.TabIndex = 118;
            label10.Text = "12 meses:";
            // 
            // vendidos3textBox
            // 
            vendidos3textBox.Location = new Point(94, 234);
            vendidos3textBox.Margin = new Padding(4, 3, 4, 3);
            vendidos3textBox.Name = "vendidos3textBox";
            vendidos3textBox.ReadOnly = true;
            vendidos3textBox.Size = new Size(149, 23);
            vendidos3textBox.TabIndex = 104;
            vendidos3textBox.TabStop = false;
            // 
            // vendidos6textBox
            // 
            vendidos6textBox.Location = new Point(94, 280);
            vendidos6textBox.Margin = new Padding(4, 3, 4, 3);
            vendidos6textBox.Name = "vendidos6textBox";
            vendidos6textBox.ReadOnly = true;
            vendidos6textBox.Size = new Size(145, 23);
            vendidos6textBox.TabIndex = 106;
            vendidos6textBox.TabStop = false;
            // 
            // vendidos12textBox
            // 
            vendidos12textBox.Location = new Point(344, 233);
            vendidos12textBox.Margin = new Padding(4, 3, 4, 3);
            vendidos12textBox.Name = "vendidos12textBox";
            vendidos12textBox.ReadOnly = true;
            vendidos12textBox.Size = new Size(150, 23);
            vendidos12textBox.TabIndex = 108;
            vendidos12textBox.TabStop = false;
            // 
            // vendidos18textBox
            // 
            vendidos18textBox.Location = new Point(344, 280);
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
            label12.Location = new Point(252, 280);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(73, 15);
            label12.TabIndex = 124;
            label12.Text = "18 meses:";
            // 
            // entradasPorProdutoBindingSource
            // 
            entradasPorProdutoBindingSource.DataMember = "EntradasPorProduto";
            // 
            // entradasPorProdutoDataGridView
            // 
            entradasPorProdutoDataGridView.AllowUserToAddRows = false;
            entradasPorProdutoDataGridView.AllowUserToDeleteRows = false;
            entradasPorProdutoDataGridView.AutoGenerateColumns = false;
            entradasPorProdutoDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            entradasPorProdutoDataGridView.Columns.AddRange(new DataGridViewColumn[] { dataEntrada, codCST, quantidade });
            entradasPorProdutoDataGridView.DataSource = entradasPorProdutoBindingSource;
            entradasPorProdutoDataGridView.Location = new Point(6, 535);
            entradasPorProdutoDataGridView.Margin = new Padding(4, 3, 4, 3);
            entradasPorProdutoDataGridView.MultiSelect = false;
            entradasPorProdutoDataGridView.Name = "entradasPorProdutoDataGridView";
            entradasPorProdutoDataGridView.ReadOnly = true;
            entradasPorProdutoDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            entradasPorProdutoDataGridView.Size = new Size(997, 118);
            entradasPorProdutoDataGridView.TabIndex = 124;
            entradasPorProdutoDataGridView.TabStop = false;
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
            // codCST
            // 
            codCST.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            codCST.DataPropertyName = "codCST";
            codCST.FillWeight = 15F;
            codCST.HeaderText = "CST";
            codCST.Name = "codCST";
            codCST.ReadOnly = true;
            codCST.Width = 52;
            // 
            // quantidade
            // 
            quantidade.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            quantidade.DataPropertyName = "Quantidade";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            quantidade.DefaultCellStyle = dataGridViewCellStyle1;
            quantidade.HeaderText = "Quantidade";
            quantidade.Name = "quantidade";
            quantidade.ReadOnly = true;
            quantidade.Width = 94;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(0, 510);
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
            tb_produto_lojaDataGridView.Location = new Point(531, 233);
            tb_produto_lojaDataGridView.Margin = new Padding(4, 3, 4, 3);
            tb_produto_lojaDataGridView.MultiSelect = false;
            tb_produto_lojaDataGridView.Name = "tb_produto_lojaDataGridView";
            tb_produto_lojaDataGridView.ReadOnly = true;
            tb_produto_lojaDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tb_produto_lojaDataGridView.Size = new Size(472, 102);
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
            label13.Location = new Point(527, 208);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(60, 17);
            label13.TabIndex = 125;
            label13.Text = "Estoque";
            // 
            // codProdutoComboBox
            // 
            codProdutoComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            codProdutoComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
            codProdutoComboBox.CausesValidation = false;
            codProdutoComboBox.DataSource = produtoBindingSource;
            codProdutoComboBox.DisplayMember = "nome";
            codProdutoComboBox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            codProdutoComboBox.FormattingEnabled = true;
            codProdutoComboBox.Location = new Point(10, 84);
            codProdutoComboBox.Margin = new Padding(4, 3, 4, 3);
            codProdutoComboBox.Name = "codProdutoComboBox";
            codProdutoComboBox.Size = new Size(992, 32);
            codProdutoComboBox.TabIndex = 5;
            codProdutoComboBox.ValueMember = "codProduto";
            codProdutoComboBox.SelectedIndexChanged += codProdutoComboBox_Leave;
            codProdutoComboBox.KeyPress += codProdutoComboBox_KeyPress;
            codProdutoComboBox.Leave += codProdutoComboBox_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(4, 205);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(125, 18);
            label2.TabIndex = 128;
            label2.Text = "Média de Vendas:";
            // 
            // pessoaBindingSource
            // 
            pessoaBindingSource.DataSource = typeof(Dominio.Pessoa);
            // 
            // FrmProdutoEstatistica
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1015, 658);
            ControlBox = false;
            Controls.Add(label2);
            Controls.Add(codProdutoLabel);
            Controls.Add(codProdutoComboBox);
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
            Name = "FrmProdutoEstatistica";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Estatísticas do Produto";
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
        private System.Windows.Forms.TextBox vendidos18textBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.BindingSource entradasPorProdutoBindingSource;
        private System.Windows.Forms.DataGridView entradasPorProdutoDataGridView;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.BindingSource produtoLojaBindingSource;
        private System.Windows.Forms.DataGridView tb_produto_lojaDataGridView;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox codProdutoComboBox;
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
        private System.Windows.Forms.BindingSource pessoaBindingSource;
        private BindingSource produtoVendidoBindingSource;
    }
}