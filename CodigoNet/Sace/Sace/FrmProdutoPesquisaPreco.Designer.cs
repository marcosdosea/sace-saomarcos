namespace Sace
{
    partial class FrmProdutoPesquisaPreco
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
            DataGridView tb_produto_lojaDataGridView;
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            NomeLoja = new DataGridViewTextBoxColumn();
            qtdEstoqueDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            qtdEstoqueAuxDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            localizacaoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            localizacao2DataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            produtoLojaBindingSource = new BindingSource(components);
            label1 = new Label();
            cmbBusca = new ComboBox();
            label2 = new Label();
            txtTexto = new TextBox();
            tb_produtoDataGridView = new DataGridView();
            CodProduto = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeProdutoFabricanteDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            unidade = new DataGridViewTextBoxColumn();
            precoVendaVarejoSemDesconto = new DataGridViewTextBoxColumn();
            precoVendaVarejoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            qtdProdutoAtacado = new DataGridViewTextBoxColumn();
            totalPrecoAtacadoSemDesconto = new DataGridViewTextBoxColumn();
            totalPrecoAtacado = new DataGridViewTextBoxColumn();
            UltimaDataAtualizacao = new DataGridViewTextBoxColumn();
            EmPromocao = new DataGridViewCheckBoxColumn();
            ExibeNaListagem = new DataGridViewCheckBoxColumn();
            CodSituacaoProduto = new DataGridViewTextBoxColumn();
            produtoBindingSource = new BindingSource(components);
            label6 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            tb_produto_lojaDataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)tb_produto_lojaDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)produtoLojaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tb_produtoDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)produtoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // tb_produto_lojaDataGridView
            // 
            tb_produto_lojaDataGridView.AllowUserToAddRows = false;
            tb_produto_lojaDataGridView.AllowUserToDeleteRows = false;
            tb_produto_lojaDataGridView.AllowUserToResizeColumns = false;
            tb_produto_lojaDataGridView.AllowUserToResizeRows = false;
            tb_produto_lojaDataGridView.AutoGenerateColumns = false;
            tb_produto_lojaDataGridView.BackgroundColor = SystemColors.ActiveBorder;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 11.25F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            tb_produto_lojaDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            tb_produto_lojaDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tb_produto_lojaDataGridView.Columns.AddRange(new DataGridViewColumn[] { NomeLoja, qtdEstoqueDataGridViewTextBoxColumn, qtdEstoqueAuxDataGridViewTextBoxColumn, localizacaoDataGridViewTextBoxColumn, localizacao2DataGridViewTextBoxColumn });
            tb_produto_lojaDataGridView.DataSource = produtoLojaBindingSource;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 11.25F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            tb_produto_lojaDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            tb_produto_lojaDataGridView.Enabled = false;
            tb_produto_lojaDataGridView.EnableHeadersVisualStyles = false;
            tb_produto_lojaDataGridView.ImeMode = ImeMode.Off;
            tb_produto_lojaDataGridView.Location = new Point(14, 571);
            tb_produto_lojaDataGridView.Margin = new Padding(4, 3, 4, 3);
            tb_produto_lojaDataGridView.MultiSelect = false;
            tb_produto_lojaDataGridView.Name = "tb_produto_lojaDataGridView";
            tb_produto_lojaDataGridView.ReadOnly = true;
            tb_produto_lojaDataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(255, 255, 192);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(255, 255, 192);
            dataGridViewCellStyle3.SelectionForeColor = Color.Black;
            tb_produto_lojaDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            tb_produto_lojaDataGridView.ScrollBars = ScrollBars.Vertical;
            tb_produto_lojaDataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            tb_produto_lojaDataGridView.Size = new Size(1214, 91);
            tb_produto_lojaDataGridView.TabIndex = 70;
            tb_produto_lojaDataGridView.TabStop = false;
            // 
            // NomeLoja
            // 
            NomeLoja.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            NomeLoja.DataPropertyName = "NomeLoja";
            NomeLoja.HeaderText = "Loja";
            NomeLoja.Name = "NomeLoja";
            NomeLoja.ReadOnly = true;
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
            qtdEstoqueAuxDataGridViewTextBoxColumn.HeaderText = "Auxiliar";
            qtdEstoqueAuxDataGridViewTextBoxColumn.Name = "qtdEstoqueAuxDataGridViewTextBoxColumn";
            qtdEstoqueAuxDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // localizacaoDataGridViewTextBoxColumn
            // 
            localizacaoDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            localizacaoDataGridViewTextBoxColumn.DataPropertyName = "Localizacao";
            localizacaoDataGridViewTextBoxColumn.HeaderText = "Localizacao";
            localizacaoDataGridViewTextBoxColumn.Name = "localizacaoDataGridViewTextBoxColumn";
            localizacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // localizacao2DataGridViewTextBoxColumn
            // 
            localizacao2DataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            localizacao2DataGridViewTextBoxColumn.DataPropertyName = "Localizacao2";
            localizacao2DataGridViewTextBoxColumn.HeaderText = "Localizacao 2";
            localizacao2DataGridViewTextBoxColumn.Name = "localizacao2DataGridViewTextBoxColumn";
            localizacao2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // produtoLojaBindingSource
            // 
            produtoLojaBindingSource.DataSource = typeof(Dominio.ProdutoLoja);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(14, 10);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(91, 20);
            label1.TabIndex = 2;
            label1.Text = "Buscar Por:";
            // 
            // cmbBusca
            // 
            cmbBusca.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbBusca.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbBusca.FormattingEnabled = true;
            cmbBusca.ImeMode = ImeMode.On;
            cmbBusca.Items.AddRange(new object[] { "Descrição", "Código", "Referência Fabricante", "Nome Produto no Fabricante", "Data Atualização Maior que", "Ncmsh", "Data Última Mudança de Preço Etiqueta Maior que", "Código de Barra" });
            cmbBusca.Location = new Point(14, 42);
            cmbBusca.Margin = new Padding(4, 3, 4, 3);
            cmbBusca.Name = "cmbBusca";
            cmbBusca.Size = new Size(296, 28);
            cmbBusca.TabIndex = 3;
            cmbBusca.SelectedIndexChanged += cmbBusca_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(313, 10);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(52, 20);
            label2.TabIndex = 4;
            label2.Text = "Texto:";
            // 
            // txtTexto
            // 
            txtTexto.CharacterCasing = CharacterCasing.Upper;
            txtTexto.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTexto.Location = new Point(317, 44);
            txtTexto.Margin = new Padding(4, 3, 4, 3);
            txtTexto.Name = "txtTexto";
            txtTexto.Size = new Size(910, 26);
            txtTexto.TabIndex = 1;
            txtTexto.TextChanged += txtTexto_TextChanged;
            // 
            // tb_produtoDataGridView
            // 
            tb_produtoDataGridView.AllowUserToAddRows = false;
            tb_produtoDataGridView.AllowUserToDeleteRows = false;
            tb_produtoDataGridView.AllowUserToResizeColumns = false;
            tb_produtoDataGridView.AllowUserToResizeRows = false;
            tb_produtoDataGridView.AutoGenerateColumns = false;
            tb_produtoDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            tb_produtoDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            tb_produtoDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tb_produtoDataGridView.Columns.AddRange(new DataGridViewColumn[] { CodProduto, nomeDataGridViewTextBoxColumn, nomeProdutoFabricanteDataGridViewTextBoxColumn, unidade, precoVendaVarejoSemDesconto, precoVendaVarejoDataGridViewTextBoxColumn, qtdProdutoAtacado, totalPrecoAtacadoSemDesconto, totalPrecoAtacado, UltimaDataAtualizacao, EmPromocao, ExibeNaListagem, CodSituacaoProduto });
            tb_produtoDataGridView.DataSource = produtoBindingSource;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = SystemColors.Window;
            dataGridViewCellStyle10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle10.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle10.Padding = new Padding(0, 5, 0, 0);
            dataGridViewCellStyle10.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.False;
            tb_produtoDataGridView.DefaultCellStyle = dataGridViewCellStyle10;
            tb_produtoDataGridView.Location = new Point(14, 96);
            tb_produtoDataGridView.Margin = new Padding(4, 3, 4, 3);
            tb_produtoDataGridView.MultiSelect = false;
            tb_produtoDataGridView.Name = "tb_produtoDataGridView";
            tb_produtoDataGridView.ReadOnly = true;
            tb_produtoDataGridView.RowHeadersWidth = 7;
            dataGridViewCellStyle11.Font = new Font("Microsoft Sans Serif", 10.5F);
            tb_produtoDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle11;
            tb_produtoDataGridView.RowTemplate.Height = 30;
            tb_produtoDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tb_produtoDataGridView.Size = new Size(1214, 443);
            tb_produtoDataGridView.TabIndex = 5;
            tb_produtoDataGridView.TabStop = false;
            tb_produtoDataGridView.RowEnter += tb_produtoDataGridView_RowEnter;
            tb_produtoDataGridView.RowsAdded += tb_produtoDataGridView_RowsAdded;
            tb_produtoDataGridView.SelectionChanged += tb_produtoDataGridView_SelectionChanged;
            // 
            // CodProduto
            // 
            CodProduto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CodProduto.DataPropertyName = "CodProduto";
            CodProduto.FillWeight = 17F;
            CodProduto.HeaderText = "Código";
            CodProduto.Name = "CodProduto";
            CodProduto.ReadOnly = true;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.FillWeight = 120F;
            nomeDataGridViewTextBoxColumn.HeaderText = "Produto";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeProdutoFabricanteDataGridViewTextBoxColumn
            // 
            nomeProdutoFabricanteDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nomeProdutoFabricanteDataGridViewTextBoxColumn.DataPropertyName = "NomeProdutoFabricante";
            nomeProdutoFabricanteDataGridViewTextBoxColumn.HeaderText = "Nome Produto conforme Fabricante";
            nomeProdutoFabricanteDataGridViewTextBoxColumn.Name = "nomeProdutoFabricanteDataGridViewTextBoxColumn";
            nomeProdutoFabricanteDataGridViewTextBoxColumn.ReadOnly = true;
            nomeProdutoFabricanteDataGridViewTextBoxColumn.Visible = false;
            // 
            // unidade
            // 
            unidade.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            unidade.DataPropertyName = "unidade";
            unidade.FillWeight = 10F;
            unidade.HeaderText = "UN";
            unidade.MinimumWidth = 10;
            unidade.Name = "unidade";
            unidade.ReadOnly = true;
            // 
            // precoVendaVarejoSemDesconto
            // 
            precoVendaVarejoSemDesconto.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            precoVendaVarejoSemDesconto.DataPropertyName = "PrecoVendaVarejoSemDesconto";
            dataGridViewCellStyle5.ForeColor = Color.Red;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            precoVendaVarejoSemDesconto.DefaultCellStyle = dataGridViewCellStyle5;
            precoVendaVarejoSemDesconto.HeaderText = "Varejo";
            precoVendaVarejoSemDesconto.MinimumWidth = 90;
            precoVendaVarejoSemDesconto.Name = "precoVendaVarejoSemDesconto";
            precoVendaVarejoSemDesconto.ReadOnly = true;
            precoVendaVarejoSemDesconto.Width = 90;
            // 
            // precoVendaVarejoDataGridViewTextBoxColumn
            // 
            precoVendaVarejoDataGridViewTextBoxColumn.DataPropertyName = "PrecoVendaVarejo";
            precoVendaVarejoDataGridViewTextBoxColumn.HeaderText = "Varejo à Vista";
            precoVendaVarejoDataGridViewTextBoxColumn.Name = "precoVendaVarejoDataGridViewTextBoxColumn";
            precoVendaVarejoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtdProdutoAtacado
            // 
            qtdProdutoAtacado.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            qtdProdutoAtacado.DataPropertyName = "QtdProdutoAtacado";
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 13F);
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            qtdProdutoAtacado.DefaultCellStyle = dataGridViewCellStyle6;
            qtdProdutoAtacado.FillWeight = 15F;
            qtdProdutoAtacado.HeaderText = "Qtd Atcd";
            qtdProdutoAtacado.Name = "qtdProdutoAtacado";
            qtdProdutoAtacado.ReadOnly = true;
            // 
            // totalPrecoAtacadoSemDesconto
            // 
            totalPrecoAtacadoSemDesconto.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            totalPrecoAtacadoSemDesconto.DataPropertyName = "TotalPrecoVendaAtacadoSemDesconto";
            dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 13F);
            dataGridViewCellStyle7.ForeColor = Color.Navy;
            dataGridViewCellStyle7.Format = "C2";
            totalPrecoAtacadoSemDesconto.DefaultCellStyle = dataGridViewCellStyle7;
            totalPrecoAtacadoSemDesconto.HeaderText = "Atacado";
            totalPrecoAtacadoSemDesconto.MinimumWidth = 90;
            totalPrecoAtacadoSemDesconto.Name = "totalPrecoAtacadoSemDesconto";
            totalPrecoAtacadoSemDesconto.ReadOnly = true;
            totalPrecoAtacadoSemDesconto.Width = 90;
            // 
            // totalPrecoAtacado
            // 
            totalPrecoAtacado.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            totalPrecoAtacado.DataPropertyName = "TotalPrecoVendaAtacado";
            dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 13F);
            dataGridViewCellStyle8.ForeColor = Color.Navy;
            dataGridViewCellStyle8.Format = "C2";
            totalPrecoAtacado.DefaultCellStyle = dataGridViewCellStyle8;
            totalPrecoAtacado.HeaderText = "Atacado à Vista";
            totalPrecoAtacado.MinimumWidth = 90;
            totalPrecoAtacado.Name = "totalPrecoAtacado";
            totalPrecoAtacado.ReadOnly = true;
            totalPrecoAtacado.Width = 90;
            // 
            // UltimaDataAtualizacao
            // 
            UltimaDataAtualizacao.DataPropertyName = "UltimaDataAtualizacao";
            dataGridViewCellStyle9.Format = "d";
            dataGridViewCellStyle9.NullValue = null;
            UltimaDataAtualizacao.DefaultCellStyle = dataGridViewCellStyle9;
            UltimaDataAtualizacao.HeaderText = "DT Atualização";
            UltimaDataAtualizacao.Name = "UltimaDataAtualizacao";
            UltimaDataAtualizacao.ReadOnly = true;
            // 
            // EmPromocao
            // 
            EmPromocao.DataPropertyName = "EmPromocao";
            EmPromocao.HeaderText = "EmPromocao";
            EmPromocao.Name = "EmPromocao";
            EmPromocao.ReadOnly = true;
            EmPromocao.Visible = false;
            // 
            // ExibeNaListagem
            // 
            ExibeNaListagem.DataPropertyName = "ExibeNaListagem";
            ExibeNaListagem.HeaderText = "ExibeNaListagem";
            ExibeNaListagem.Name = "ExibeNaListagem";
            ExibeNaListagem.ReadOnly = true;
            ExibeNaListagem.Visible = false;
            // 
            // CodSituacaoProduto
            // 
            CodSituacaoProduto.DataPropertyName = "CodSituacaoProduto";
            CodSituacaoProduto.HeaderText = "CodSituacaoProduto";
            CodSituacaoProduto.Name = "CodSituacaoProduto";
            CodSituacaoProduto.ReadOnly = true;
            CodSituacaoProduto.Visible = false;
            // 
            // produtoBindingSource
            // 
            produtoBindingSource.DataSource = typeof(Dominio.Produto);
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = Color.Red;
            label6.Location = new Point(15, 666);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(242, 15);
            label6.TabIndex = 61;
            label6.Text = "F7 - Ajustar Estoque do Produto Selecionado";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(14, 542);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(247, 20);
            label3.TabIndex = 71;
            label3.Text = "Estoque do Produto Selecionado:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Yellow;
            label4.Location = new Point(377, 668);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(28, 15);
            label4.TabIndex = 72;
            label4.Text = "       ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Red;
            label5.Location = new Point(538, 668);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(28, 15);
            label5.TabIndex = 73;
            label5.Text = "       ";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.FromArgb(0, 192, 0);
            label7.Location = new Point(685, 668);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(40, 15);
            label7.TabIndex = 74;
            label7.Text = "           ";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.White;
            label8.Location = new Point(278, 668);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(28, 15);
            label8.TabIndex = 75;
            label8.Text = "       ";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(306, 668);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(62, 15);
            label9.TabIndex = 76;
            label9.Text = "Disponível";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(413, 668);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(109, 15);
            label10.TabIndex = 77;
            label10.Text = "Compra Necessária";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(574, 668);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(95, 15);
            label11.TabIndex = 78;
            label11.Text = "Compra Urgente";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(721, 668);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(64, 15);
            label12.TabIndex = 79;
            label12.Text = "Comprado";
            // 
            // FrmProdutoPesquisaPreco
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1247, 730);
            ControlBox = false;
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(tb_produto_lojaDataGridView);
            Controls.Add(label6);
            Controls.Add(tb_produtoDataGridView);
            Controls.Add(txtTexto);
            Controls.Add(label2);
            Controls.Add(cmbBusca);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmProdutoPesquisaPreco";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Pesquisa Preço de Produtos";
            Load += FrmProdutoPesquisaPreco_Load;
            KeyDown += FrmProdutoPesquisaPreco_KeyDown;
            ((System.ComponentModel.ISupportInitialize)tb_produto_lojaDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)produtoLojaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)tb_produtoDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)produtoBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBusca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.BindingSource produtoBindingSource;
        private System.Windows.Forms.DataGridView tb_produtoDataGridView;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.BindingSource produtoLojaBindingSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeLoja;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdEstoqueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdEstoqueAuxDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localizacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn localizacao2DataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeProdutoFabricanteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoVendaVarejoSemDesconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn precoVendaVarejoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtdProdutoAtacado;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPrecoAtacadoSemDesconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalPrecoAtacado;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltimaDataAtualizacao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn EmPromocao;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ExibeNaListagem;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodSituacaoProduto;
  
    }
}