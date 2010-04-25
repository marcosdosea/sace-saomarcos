namespace SACE.Telas
{
    partial class FrmProdutoPreco
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
            System.Windows.Forms.Label custoVendaLabel;
            System.Windows.Forms.Label ultimoPrecoCompraLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProdutoPreco));
            this.textBoxCFOP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPrecoCusto = new System.Windows.Forms.TextBox();
            this.textBoxPrecoCustoMedio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lucroPrecoVendaVarejoTextBox = new System.Windows.Forms.TextBox();
            this.tb_produtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saceDataSet = new SACE.Dados.saceDataSet();
            this.precoVendaVarejoTextBox = new System.Windows.Forms.TextBox();
            this.novoPrecoVarejoTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxVarejoMedio = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxVarejoCusto = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lucroPrecoVendaAtacadoTextBox = new System.Windows.Forms.TextBox();
            this.precoVendaAtacadoTextBox = new System.Windows.Forms.TextBox();
            this.novoPrecoAtacadoTextBox = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lucroPrecoVendaSuperAtacadoTextBox = new System.Windows.Forms.TextBox();
            this.precoVendaSuperAtacadoTextBox = new System.Windows.Forms.TextBox();
            this.novoPrecoSuperTextBox = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAjustar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CFOP = new System.Windows.Forms.Label();
            this.tb_produtoTableAdapter = new SACE.Dados.saceDataSetTableAdapters.tb_produtoTableAdapter();
            this.tableAdapterManager = new SACE.Dados.saceDataSetTableAdapters.TableAdapterManager();
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
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.codProdutoTextBox = new System.Windows.Forms.TextBox();
            this.ipiTextBox = new System.Windows.Forms.TextBox();
            this.icmsTextBox = new System.Windows.Forms.TextBox();
            this.simplesTextBox = new System.Windows.Forms.TextBox();
            this.freteTextBox = new System.Windows.Forms.TextBox();
            this.custoVendaTextBox = new System.Windows.Forms.TextBox();
            this.ultimoPrecoCompraTextBox = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            codProdutoLabel = new System.Windows.Forms.Label();
            custoVendaLabel = new System.Windows.Forms.Label();
            ultimoPrecoCompraLabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoBindingNavigator)).BeginInit();
            this.tb_produtoBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // codProdutoLabel
            // 
            codProdutoLabel.AutoSize = true;
            codProdutoLabel.Location = new System.Drawing.Point(6, 67);
            codProdutoLabel.Name = "codProdutoLabel";
            codProdutoLabel.Size = new System.Drawing.Size(43, 13);
            codProdutoLabel.TabIndex = 33;
            codProdutoLabel.Text = "Código:";
            // 
            // custoVendaLabel
            // 
            custoVendaLabel.AutoSize = true;
            custoVendaLabel.Location = new System.Drawing.Point(501, 113);
            custoVendaLabel.Name = "custoVendaLabel";
            custoVendaLabel.Size = new System.Drawing.Size(87, 13);
            custoVendaLabel.TabIndex = 38;
            custoVendaLabel.Text = "Manutenção (%):";
            // 
            // ultimoPrecoCompraLabel
            // 
            ultimoPrecoCompraLabel.AutoSize = true;
            ultimoPrecoCompraLabel.Location = new System.Drawing.Point(320, 113);
            ultimoPrecoCompraLabel.Name = "ultimoPrecoCompraLabel";
            ultimoPrecoCompraLabel.Size = new System.Drawing.Size(109, 13);
            ultimoPrecoCompraLabel.TabIndex = 39;
            ultimoPrecoCompraLabel.Text = "Último Preço Compra:";
            // 
            // textBoxCFOP
            // 
            this.textBoxCFOP.Location = new System.Drawing.Point(8, 129);
            this.textBoxCFOP.Name = "textBoxCFOP";
            this.textBoxCFOP.ReadOnly = true;
            this.textBoxCFOP.Size = new System.Drawing.Size(291, 20);
            this.textBoxCFOP.TabIndex = 10;
            this.textBoxCFOP.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(117, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Produto";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(318, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Preço Custo (R$)";
            // 
            // textBoxPrecoCusto
            // 
            this.textBoxPrecoCusto.Location = new System.Drawing.Point(319, 180);
            this.textBoxPrecoCusto.Name = "textBoxPrecoCusto";
            this.textBoxPrecoCusto.ReadOnly = true;
            this.textBoxPrecoCusto.Size = new System.Drawing.Size(122, 20);
            this.textBoxPrecoCusto.TabIndex = 24;
            this.textBoxPrecoCusto.TabStop = false;
            // 
            // textBoxPrecoCustoMedio
            // 
            this.textBoxPrecoCustoMedio.Location = new System.Drawing.Point(464, 180);
            this.textBoxPrecoCustoMedio.Name = "textBoxPrecoCustoMedio";
            this.textBoxPrecoCustoMedio.ReadOnly = true;
            this.textBoxPrecoCustoMedio.Size = new System.Drawing.Size(124, 20);
            this.textBoxPrecoCustoMedio.TabIndex = 26;
            this.textBoxPrecoCustoMedio.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(463, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Preço Custo Médio (R$)";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.lucroPrecoVendaVarejoTextBox);
            this.groupBox1.Controls.Add(this.precoVendaVarejoTextBox);
            this.groupBox1.Controls.Add(this.novoPrecoVarejoTextBox);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.textBoxVarejoMedio);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.textBoxVarejoCusto);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(8, 207);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(589, 67);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " VAREJO ";
            // 
            // lucroPrecoVendaVarejoTextBox
            // 
            this.lucroPrecoVendaVarejoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "lucroPrecoVendaVarejo", true));
            this.lucroPrecoVendaVarejoTextBox.Location = new System.Drawing.Point(123, 36);
            this.lucroPrecoVendaVarejoTextBox.Name = "lucroPrecoVendaVarejoTextBox";
            this.lucroPrecoVendaVarejoTextBox.ReadOnly = true;
            this.lucroPrecoVendaVarejoTextBox.Size = new System.Drawing.Size(52, 20);
            this.lucroPrecoVendaVarejoTextBox.TabIndex = 30;
            this.lucroPrecoVendaVarejoTextBox.TabStop = false;
            // 
            // tb_produtoBindingSource
            // 
            this.tb_produtoBindingSource.DataMember = "tb_produto";
            this.tb_produtoBindingSource.DataSource = this.saceDataSet;
            // 
            // saceDataSet
            // 
            this.saceDataSet.DataSetName = "saceDataSet";
            this.saceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // precoVendaVarejoTextBox
            // 
            this.precoVendaVarejoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "precoVendaVarejo", true));
            this.precoVendaVarejoTextBox.Location = new System.Drawing.Point(8, 36);
            this.precoVendaVarejoTextBox.Name = "precoVendaVarejoTextBox";
            this.precoVendaVarejoTextBox.ReadOnly = true;
            this.precoVendaVarejoTextBox.Size = new System.Drawing.Size(100, 20);
            this.precoVendaVarejoTextBox.TabIndex = 28;
            this.precoVendaVarejoTextBox.TabStop = false;
            // 
            // novoPrecoVarejoTextBox
            // 
            this.novoPrecoVarejoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "precoVendaVarejo", true));
            this.novoPrecoVarejoTextBox.Location = new System.Drawing.Point(458, 36);
            this.novoPrecoVarejoTextBox.Name = "novoPrecoVarejoTextBox";
            this.novoPrecoVarejoTextBox.Size = new System.Drawing.Size(123, 20);
            this.novoPrecoVarejoTextBox.TabIndex = 36;
            this.novoPrecoVarejoTextBox.Text = "0,00";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(457, 17);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "Novo Preço Venda (R$)";
            // 
            // textBoxVarejoMedio
            // 
            this.textBoxVarejoMedio.Location = new System.Drawing.Point(329, 36);
            this.textBoxVarejoMedio.Name = "textBoxVarejoMedio";
            this.textBoxVarejoMedio.ReadOnly = true;
            this.textBoxVarejoMedio.Size = new System.Drawing.Size(123, 20);
            this.textBoxVarejoMedio.TabIndex = 34;
            this.textBoxVarejoMedio.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(328, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(126, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Preço Venda/Média (R$)";
            // 
            // textBoxVarejoCusto
            // 
            this.textBoxVarejoCusto.Location = new System.Drawing.Point(200, 36);
            this.textBoxVarejoCusto.Name = "textBoxVarejoCusto";
            this.textBoxVarejoCusto.ReadOnly = true;
            this.textBoxVarejoCusto.Size = new System.Drawing.Size(123, 20);
            this.textBoxVarejoCusto.TabIndex = 32;
            this.textBoxVarejoCusto.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(199, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Preço Sugestão (R$)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Preço Atual (R$)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(137, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Lucro (%)";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.groupBox2.Controls.Add(this.lucroPrecoVendaAtacadoTextBox);
            this.groupBox2.Controls.Add(this.precoVendaAtacadoTextBox);
            this.groupBox2.Controls.Add(this.novoPrecoAtacadoTextBox);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.textBox4);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Location = new System.Drawing.Point(6, 280);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(591, 63);
            this.groupBox2.TabIndex = 26;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " ATACADO ";
            // 
            // lucroPrecoVendaAtacadoTextBox
            // 
            this.lucroPrecoVendaAtacadoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "lucroPrecoVendaAtacado", true));
            this.lucroPrecoVendaAtacadoTextBox.Location = new System.Drawing.Point(125, 33);
            this.lucroPrecoVendaAtacadoTextBox.Name = "lucroPrecoVendaAtacadoTextBox";
            this.lucroPrecoVendaAtacadoTextBox.ReadOnly = true;
            this.lucroPrecoVendaAtacadoTextBox.Size = new System.Drawing.Size(52, 20);
            this.lucroPrecoVendaAtacadoTextBox.TabIndex = 40;
            this.lucroPrecoVendaAtacadoTextBox.TabStop = false;
            // 
            // precoVendaAtacadoTextBox
            // 
            this.precoVendaAtacadoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "precoVendaAtacado", true));
            this.precoVendaAtacadoTextBox.Location = new System.Drawing.Point(10, 34);
            this.precoVendaAtacadoTextBox.Name = "precoVendaAtacadoTextBox";
            this.precoVendaAtacadoTextBox.ReadOnly = true;
            this.precoVendaAtacadoTextBox.Size = new System.Drawing.Size(100, 20);
            this.precoVendaAtacadoTextBox.TabIndex = 38;
            this.precoVendaAtacadoTextBox.TabStop = false;
            // 
            // novoPrecoAtacadoTextBox
            // 
            this.novoPrecoAtacadoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "precoVendaAtacado", true));
            this.novoPrecoAtacadoTextBox.Location = new System.Drawing.Point(458, 36);
            this.novoPrecoAtacadoTextBox.Name = "novoPrecoAtacadoTextBox";
            this.novoPrecoAtacadoTextBox.Size = new System.Drawing.Size(123, 20);
            this.novoPrecoAtacadoTextBox.TabIndex = 46;
            this.novoPrecoAtacadoTextBox.Text = "0,00";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(457, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Novo Preço Venda (R$)";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(329, 36);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(123, 20);
            this.textBox3.TabIndex = 44;
            this.textBox3.TabStop = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(328, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(126, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "Preço Venda/Média (R$)";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(200, 36);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(123, 20);
            this.textBox4.TabIndex = 42;
            this.textBox4.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(199, 17);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 13);
            this.label16.TabIndex = 27;
            this.label16.Text = "Preço Sugestão (R$)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(5, 18);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(85, 13);
            this.label17.TabIndex = 24;
            this.label17.Text = "Preço Atual (R$)";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(137, 18);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(51, 13);
            this.label18.TabIndex = 23;
            this.label18.Text = "Lucro (%)";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox3.Controls.Add(this.lucroPrecoVendaSuperAtacadoTextBox);
            this.groupBox3.Controls.Add(this.precoVendaSuperAtacadoTextBox);
            this.groupBox3.Controls.Add(this.novoPrecoSuperTextBox);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.textBox8);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.textBox9);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Location = new System.Drawing.Point(6, 349);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(591, 68);
            this.groupBox3.TabIndex = 27;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = " SUPER ATACADO ";
            // 
            // lucroPrecoVendaSuperAtacadoTextBox
            // 
            this.lucroPrecoVendaSuperAtacadoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "lucroPrecoVendaSuperAtacado", true));
            this.lucroPrecoVendaSuperAtacadoTextBox.Location = new System.Drawing.Point(125, 33);
            this.lucroPrecoVendaSuperAtacadoTextBox.Name = "lucroPrecoVendaSuperAtacadoTextBox";
            this.lucroPrecoVendaSuperAtacadoTextBox.ReadOnly = true;
            this.lucroPrecoVendaSuperAtacadoTextBox.Size = new System.Drawing.Size(65, 20);
            this.lucroPrecoVendaSuperAtacadoTextBox.TabIndex = 50;
            this.lucroPrecoVendaSuperAtacadoTextBox.TabStop = false;
            // 
            // precoVendaSuperAtacadoTextBox
            // 
            this.precoVendaSuperAtacadoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "precoVendaSuperAtacado", true));
            this.precoVendaSuperAtacadoTextBox.Location = new System.Drawing.Point(10, 36);
            this.precoVendaSuperAtacadoTextBox.Name = "precoVendaSuperAtacadoTextBox";
            this.precoVendaSuperAtacadoTextBox.ReadOnly = true;
            this.precoVendaSuperAtacadoTextBox.Size = new System.Drawing.Size(100, 20);
            this.precoVendaSuperAtacadoTextBox.TabIndex = 48;
            this.precoVendaSuperAtacadoTextBox.TabStop = false;
            // 
            // novoPrecoSuperTextBox
            // 
            this.novoPrecoSuperTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "precoVendaSuperAtacado", true));
            this.novoPrecoSuperTextBox.Location = new System.Drawing.Point(458, 36);
            this.novoPrecoSuperTextBox.Name = "novoPrecoSuperTextBox";
            this.novoPrecoSuperTextBox.Size = new System.Drawing.Size(123, 20);
            this.novoPrecoSuperTextBox.TabIndex = 56;
            this.novoPrecoSuperTextBox.Text = "0,00";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(457, 17);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(121, 13);
            this.label19.TabIndex = 31;
            this.label19.Text = "Novo Preço Venda (R$)";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(329, 36);
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(123, 20);
            this.textBox8.TabIndex = 54;
            this.textBox8.TabStop = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(328, 17);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(126, 13);
            this.label20.TabIndex = 29;
            this.label20.Text = "Preço Venda/Média (R$)";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(200, 36);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(123, 20);
            this.textBox9.TabIndex = 52;
            this.textBox9.TabStop = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(199, 17);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(106, 13);
            this.label21.TabIndex = 27;
            this.label21.Text = "Preço Sugestão (R$)";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(5, 18);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(85, 13);
            this.label22.TabIndex = 24;
            this.label22.Text = "Preço Atual (R$)";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(137, 18);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(51, 13);
            this.label23.TabIndex = 23;
            this.label23.Text = "Lucro (%)";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(503, 423);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label24.Location = new System.Drawing.Point(3, 9);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(305, 23);
            this.label24.TabIndex = 0;
            this.label24.Text = "Cálculo Individual de Preços de Produtos";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label24);
            this.panel1.Location = new System.Drawing.Point(1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(602, 41);
            this.panel1.TabIndex = 31;
            // 
            // btnAjustar
            // 
            this.btnAjustar.Location = new System.Drawing.Point(327, 423);
            this.btnAjustar.Name = "btnAjustar";
            this.btnAjustar.Size = new System.Drawing.Size(84, 23);
            this.btnAjustar.TabIndex = 3;
            this.btnAjustar.Text = "F5 - Ajustar %";
            this.btnAjustar.UseVisualStyleBackColor = true;
            this.btnAjustar.Click += new System.EventHandler(this.btnAjustar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(436, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IPI (%):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(212, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Frete (%)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(111, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Simples (%):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Dif ICMS (%)";
            // 
            // CFOP
            // 
            this.CFOP.AutoSize = true;
            this.CFOP.Location = new System.Drawing.Point(6, 113);
            this.CFOP.Name = "CFOP";
            this.CFOP.Size = new System.Drawing.Size(35, 13);
            this.CFOP.TabIndex = 7;
            this.CFOP.Text = "CFOP";
            // 
            // tb_produtoTableAdapter
            // 
            this.tb_produtoTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.tb_bancoTableAdapter = null;
            this.tableAdapterManager.tb_cartao_creditoTableAdapter = null;
            this.tableAdapterManager.tb_cfopTableAdapter = null;
            this.tableAdapterManager.tb_configuracao_sistemaTableAdapter = null;
            this.tableAdapterManager.tb_conta_bancoTableAdapter = null;
            this.tableAdapterManager.tb_conta_pagarTableAdapter = null;
            this.tableAdapterManager.tb_conta_receberTableAdapter = null;
            this.tableAdapterManager.tb_contato_empresaTableAdapter = null;
            this.tableAdapterManager.tb_empresaTableAdapter = null;
            this.tableAdapterManager.tb_entrada_produtoTableAdapter = null;
            this.tableAdapterManager.tb_entradaTableAdapter = null;
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
            this.tb_produtoBindingNavigator.Location = new System.Drawing.Point(394, 41);
            this.tb_produtoBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tb_produtoBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tb_produtoBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tb_produtoBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tb_produtoBindingNavigator.Name = "tb_produtoBindingNavigator";
            this.tb_produtoBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tb_produtoBindingNavigator.Size = new System.Drawing.Size(209, 25);
            this.tb_produtoBindingNavigator.TabIndex = 32;
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
            // nomeTextBox
            // 
            this.nomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "nome", true));
            this.nomeTextBox.Location = new System.Drawing.Point(120, 83);
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.ReadOnly = true;
            this.nomeTextBox.Size = new System.Drawing.Size(467, 20);
            this.nomeTextBox.TabIndex = 8;
            this.nomeTextBox.TabStop = false;
            // 
            // codProdutoTextBox
            // 
            this.codProdutoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "codProduto", true));
            this.codProdutoTextBox.Location = new System.Drawing.Point(6, 84);
            this.codProdutoTextBox.Name = "codProdutoTextBox";
            this.codProdutoTextBox.ReadOnly = true;
            this.codProdutoTextBox.Size = new System.Drawing.Size(100, 20);
            this.codProdutoTextBox.TabIndex = 6;
            this.codProdutoTextBox.TabStop = false;
            // 
            // ipiTextBox
            // 
            this.ipiTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "ipi", true));
            this.ipiTextBox.Location = new System.Drawing.Point(439, 129);
            this.ipiTextBox.Name = "ipiTextBox";
            this.ipiTextBox.ReadOnly = true;
            this.ipiTextBox.Size = new System.Drawing.Size(59, 20);
            this.ipiTextBox.TabIndex = 14;
            this.ipiTextBox.TabStop = false;
            // 
            // icmsTextBox
            // 
            this.icmsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "icms", true));
            this.icmsTextBox.Location = new System.Drawing.Point(9, 178);
            this.icmsTextBox.Name = "icmsTextBox";
            this.icmsTextBox.ReadOnly = true;
            this.icmsTextBox.Size = new System.Drawing.Size(84, 20);
            this.icmsTextBox.TabIndex = 18;
            this.icmsTextBox.TabStop = false;
            // 
            // simplesTextBox
            // 
            this.simplesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "simples", true));
            this.simplesTextBox.Location = new System.Drawing.Point(112, 178);
            this.simplesTextBox.Name = "simplesTextBox";
            this.simplesTextBox.ReadOnly = true;
            this.simplesTextBox.Size = new System.Drawing.Size(84, 20);
            this.simplesTextBox.TabIndex = 20;
            this.simplesTextBox.TabStop = false;
            // 
            // freteTextBox
            // 
            this.freteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "frete", true));
            this.freteTextBox.Location = new System.Drawing.Point(215, 178);
            this.freteTextBox.Name = "freteTextBox";
            this.freteTextBox.ReadOnly = true;
            this.freteTextBox.Size = new System.Drawing.Size(84, 20);
            this.freteTextBox.TabIndex = 22;
            this.freteTextBox.TabStop = false;
            // 
            // custoVendaTextBox
            // 
            this.custoVendaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "custoVenda", true));
            this.custoVendaTextBox.Location = new System.Drawing.Point(515, 129);
            this.custoVendaTextBox.Name = "custoVendaTextBox";
            this.custoVendaTextBox.ReadOnly = true;
            this.custoVendaTextBox.Size = new System.Drawing.Size(68, 20);
            this.custoVendaTextBox.TabIndex = 16;
            this.custoVendaTextBox.TabStop = false;
            // 
            // ultimoPrecoCompraTextBox
            // 
            this.ultimoPrecoCompraTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_produtoBindingSource, "ultimoPrecoCompra", true));
            this.ultimoPrecoCompraTextBox.Location = new System.Drawing.Point(319, 129);
            this.ultimoPrecoCompraTextBox.Name = "ultimoPrecoCompraTextBox";
            this.ultimoPrecoCompraTextBox.ReadOnly = true;
            this.ultimoPrecoCompraTextBox.Size = new System.Drawing.Size(106, 20);
            this.ultimoPrecoCompraTextBox.TabIndex = 12;
            this.ultimoPrecoCompraTextBox.TabStop = false;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(417, 423);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(165, 423);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "F2 - Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(246, 423);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "F4 - Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // FrmProdutoPreco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 452);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(ultimoPrecoCompraLabel);
            this.Controls.Add(this.ultimoPrecoCompraTextBox);
            this.Controls.Add(custoVendaLabel);
            this.Controls.Add(this.custoVendaTextBox);
            this.Controls.Add(this.freteTextBox);
            this.Controls.Add(this.simplesTextBox);
            this.Controls.Add(this.icmsTextBox);
            this.Controls.Add(this.ipiTextBox);
            this.Controls.Add(codProdutoLabel);
            this.Controls.Add(this.tb_produtoBindingNavigator);
            this.Controls.Add(this.codProdutoTextBox);
            this.Controls.Add(this.nomeTextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAjustar);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxPrecoCustoMedio);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxPrecoCusto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CFOP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxCFOP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "FrmProdutoPreco";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cálculo Individual de Preços";
            this.Load += new System.EventHandler(this.FrmCalcularPreco_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmProdutoPreco_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoBindingNavigator)).EndInit();
            this.tb_produtoBindingNavigator.ResumeLayout(false);
            this.tb_produtoBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCFOP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPrecoCusto;
        private System.Windows.Forms.TextBox textBoxPrecoCustoMedio;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxVarejoCusto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox novoPrecoVarejoTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxVarejoMedio;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox novoPrecoAtacadoTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox novoPrecoSuperTextBox;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnAjustar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label CFOP;
        private SACE.Dados.saceDataSet saceDataSet;
        private System.Windows.Forms.BindingSource tb_produtoBindingSource;
        private SACE.Dados.saceDataSetTableAdapters.tb_produtoTableAdapter tb_produtoTableAdapter;
        private SACE.Dados.saceDataSetTableAdapters.TableAdapterManager tableAdapterManager;
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
        private System.Windows.Forms.TextBox nomeTextBox;
        private System.Windows.Forms.TextBox codProdutoTextBox;
        private System.Windows.Forms.TextBox ipiTextBox;
        private System.Windows.Forms.TextBox icmsTextBox;
        private System.Windows.Forms.TextBox lucroPrecoVendaVarejoTextBox;
        private System.Windows.Forms.TextBox precoVendaVarejoTextBox;
        private System.Windows.Forms.TextBox simplesTextBox;
        private System.Windows.Forms.TextBox freteTextBox;
        private System.Windows.Forms.TextBox custoVendaTextBox;
        private System.Windows.Forms.TextBox lucroPrecoVendaAtacadoTextBox;
        private System.Windows.Forms.TextBox precoVendaAtacadoTextBox;
        private System.Windows.Forms.TextBox lucroPrecoVendaSuperAtacadoTextBox;
        private System.Windows.Forms.TextBox precoVendaSuperAtacadoTextBox;
        private System.Windows.Forms.TextBox ultimoPrecoCompraTextBox;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnEditar;
    }
}