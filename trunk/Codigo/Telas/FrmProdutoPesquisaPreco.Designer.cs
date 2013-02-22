namespace Telas
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridView tb_produto_lojaDataGridView;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.NomeLoja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdEstoqueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdEstoqueAuxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localizacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localizacao2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.produtoLojaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBusca = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.tb_produtoDataGridView = new System.Windows.Forms.DataGridView();
            this.produtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CodProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeProdutoFabricanteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoVendaVarejoSemDesconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precoVendaVarejoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtdProdutoAtacado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPrecoAtacadoSemDesconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPrecoAtacado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimaDataAtualizacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            tb_produto_lojaDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(tb_produto_lojaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoLojaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_produto_lojaDataGridView
            // 
            tb_produto_lojaDataGridView.AllowUserToAddRows = false;
            tb_produto_lojaDataGridView.AllowUserToDeleteRows = false;
            tb_produto_lojaDataGridView.AllowUserToResizeColumns = false;
            tb_produto_lojaDataGridView.AllowUserToResizeRows = false;
            tb_produto_lojaDataGridView.AutoGenerateColumns = false;
            tb_produto_lojaDataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            tb_produto_lojaDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            tb_produto_lojaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tb_produto_lojaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NomeLoja,
            this.qtdEstoqueDataGridViewTextBoxColumn,
            this.qtdEstoqueAuxDataGridViewTextBoxColumn,
            this.localizacaoDataGridViewTextBoxColumn,
            this.localizacao2DataGridViewTextBoxColumn});
            tb_produto_lojaDataGridView.DataSource = this.produtoLojaBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            tb_produto_lojaDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            tb_produto_lojaDataGridView.Enabled = false;
            tb_produto_lojaDataGridView.EnableHeadersVisualStyles = false;
            tb_produto_lojaDataGridView.ImeMode = System.Windows.Forms.ImeMode.Off;
            tb_produto_lojaDataGridView.Location = new System.Drawing.Point(12, 540);
            tb_produto_lojaDataGridView.MultiSelect = false;
            tb_produto_lojaDataGridView.Name = "tb_produto_lojaDataGridView";
            tb_produto_lojaDataGridView.ReadOnly = true;
            tb_produto_lojaDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            tb_produto_lojaDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            tb_produto_lojaDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            tb_produto_lojaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            tb_produto_lojaDataGridView.Size = new System.Drawing.Size(1041, 79);
            tb_produto_lojaDataGridView.TabIndex = 70;
            tb_produto_lojaDataGridView.TabStop = false;
            // 
            // NomeLoja
            // 
            this.NomeLoja.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NomeLoja.DataPropertyName = "NomeLoja";
            this.NomeLoja.HeaderText = "Loja";
            this.NomeLoja.Name = "NomeLoja";
            this.NomeLoja.ReadOnly = true;
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
            this.qtdEstoqueAuxDataGridViewTextBoxColumn.HeaderText = "Auxiliar";
            this.qtdEstoqueAuxDataGridViewTextBoxColumn.Name = "qtdEstoqueAuxDataGridViewTextBoxColumn";
            this.qtdEstoqueAuxDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // localizacaoDataGridViewTextBoxColumn
            // 
            this.localizacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.localizacaoDataGridViewTextBoxColumn.DataPropertyName = "Localizacao";
            this.localizacaoDataGridViewTextBoxColumn.HeaderText = "Localizacao";
            this.localizacaoDataGridViewTextBoxColumn.Name = "localizacaoDataGridViewTextBoxColumn";
            this.localizacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // localizacao2DataGridViewTextBoxColumn
            // 
            this.localizacao2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.localizacao2DataGridViewTextBoxColumn.DataPropertyName = "Localizacao2";
            this.localizacao2DataGridViewTextBoxColumn.HeaderText = "Localizacao 2";
            this.localizacao2DataGridViewTextBoxColumn.Name = "localizacao2DataGridViewTextBoxColumn";
            this.localizacao2DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // produtoLojaBindingSource
            // 
            this.produtoLojaBindingSource.DataSource = typeof(Dominio.ProdutoLoja);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buscar Por:";
            // 
            // cmbBusca
            // 
            this.cmbBusca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBusca.FormattingEnabled = true;
            this.cmbBusca.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cmbBusca.Items.AddRange(new object[] {
            "Descrição",
            "Código",
            "Referência Fabricante",
            "Nome Produto no Fabricante",
            "Data Atualização Maior que"});
            this.cmbBusca.Location = new System.Drawing.Point(12, 36);
            this.cmbBusca.Name = "cmbBusca";
            this.cmbBusca.Size = new System.Drawing.Size(254, 28);
            this.cmbBusca.TabIndex = 3;
            this.cmbBusca.SelectedIndexChanged += new System.EventHandler(this.cmbBusca_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(268, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Texto:";
            // 
            // txtTexto
            // 
            this.txtTexto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTexto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTexto.Location = new System.Drawing.Point(272, 38);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(781, 26);
            this.txtTexto.TabIndex = 1;
            this.txtTexto.TextChanged += new System.EventHandler(this.txtTexto_TextChanged);
            // 
            // tb_produtoDataGridView
            // 
            this.tb_produtoDataGridView.AllowUserToAddRows = false;
            this.tb_produtoDataGridView.AllowUserToDeleteRows = false;
            this.tb_produtoDataGridView.AllowUserToResizeColumns = false;
            this.tb_produtoDataGridView.AllowUserToResizeRows = false;
            this.tb_produtoDataGridView.AutoGenerateColumns = false;
            this.tb_produtoDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tb_produtoDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.tb_produtoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_produtoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodProduto,
            this.nomeDataGridViewTextBoxColumn,
            this.nomeProdutoFabricanteDataGridViewTextBoxColumn,
            this.unidade,
            this.precoVendaVarejoSemDesconto,
            this.precoVendaVarejoDataGridViewTextBoxColumn,
            this.qtdProdutoAtacado,
            this.totalPrecoAtacadoSemDesconto,
            this.totalPrecoAtacado,
            this.UltimaDataAtualizacao});
            this.tb_produtoDataGridView.DataSource = this.produtoBindingSource;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tb_produtoDataGridView.DefaultCellStyle = dataGridViewCellStyle10;
            this.tb_produtoDataGridView.Location = new System.Drawing.Point(12, 83);
            this.tb_produtoDataGridView.MultiSelect = false;
            this.tb_produtoDataGridView.Name = "tb_produtoDataGridView";
            this.tb_produtoDataGridView.ReadOnly = true;
            this.tb_produtoDataGridView.RowHeadersWidth = 7;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F);
            this.tb_produtoDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.tb_produtoDataGridView.RowTemplate.Height = 30;
            this.tb_produtoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_produtoDataGridView.Size = new System.Drawing.Size(1041, 418);
            this.tb_produtoDataGridView.TabIndex = 5;
            this.tb_produtoDataGridView.TabStop = false;
            this.tb_produtoDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.tb_produtoDataGridView_RowEnter);
            // 
            // produtoBindingSource
            // 
            this.produtoBindingSource.DataSource = typeof(Dominio.Produto);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(13, 622);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(219, 13);
            this.label6.TabIndex = 61;
            this.label6.Text = "F7 - Ajustar Estoque do Produto Selecionado";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 515);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(247, 20);
            this.label3.TabIndex = 71;
            this.label3.Text = "Estoque do Produto Selecionado:";
            // 
            // CodProduto
            // 
            this.CodProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CodProduto.DataPropertyName = "CodProduto";
            this.CodProduto.FillWeight = 17F;
            this.CodProduto.HeaderText = "Código";
            this.CodProduto.Name = "CodProduto";
            this.CodProduto.ReadOnly = true;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            this.nomeDataGridViewTextBoxColumn.FillWeight = 120F;
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Produto";
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            this.nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeProdutoFabricanteDataGridViewTextBoxColumn
            // 
            this.nomeProdutoFabricanteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomeProdutoFabricanteDataGridViewTextBoxColumn.DataPropertyName = "NomeProdutoFabricante";
            this.nomeProdutoFabricanteDataGridViewTextBoxColumn.HeaderText = "Nome Produto conforme Fabricante";
            this.nomeProdutoFabricanteDataGridViewTextBoxColumn.Name = "nomeProdutoFabricanteDataGridViewTextBoxColumn";
            this.nomeProdutoFabricanteDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomeProdutoFabricanteDataGridViewTextBoxColumn.Visible = false;
            // 
            // unidade
            // 
            this.unidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.unidade.DataPropertyName = "unidade";
            this.unidade.FillWeight = 13F;
            this.unidade.HeaderText = "UN";
            this.unidade.MinimumWidth = 30;
            this.unidade.Name = "unidade";
            this.unidade.ReadOnly = true;
            // 
            // precoVendaVarejoSemDesconto
            // 
            this.precoVendaVarejoSemDesconto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.precoVendaVarejoSemDesconto.DataPropertyName = "PrecoVendaVarejoSemDesconto";
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.precoVendaVarejoSemDesconto.DefaultCellStyle = dataGridViewCellStyle5;
            this.precoVendaVarejoSemDesconto.HeaderText = "Varejo";
            this.precoVendaVarejoSemDesconto.MinimumWidth = 90;
            this.precoVendaVarejoSemDesconto.Name = "precoVendaVarejoSemDesconto";
            this.precoVendaVarejoSemDesconto.ReadOnly = true;
            this.precoVendaVarejoSemDesconto.Width = 90;
            // 
            // precoVendaVarejoDataGridViewTextBoxColumn
            // 
            this.precoVendaVarejoDataGridViewTextBoxColumn.DataPropertyName = "PrecoVendaVarejo";
            this.precoVendaVarejoDataGridViewTextBoxColumn.HeaderText = "Varejo à Vista";
            this.precoVendaVarejoDataGridViewTextBoxColumn.Name = "precoVendaVarejoDataGridViewTextBoxColumn";
            this.precoVendaVarejoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // qtdProdutoAtacado
            // 
            this.qtdProdutoAtacado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.qtdProdutoAtacado.DataPropertyName = "QtdProdutoAtacado";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.qtdProdutoAtacado.DefaultCellStyle = dataGridViewCellStyle6;
            this.qtdProdutoAtacado.FillWeight = 15F;
            this.qtdProdutoAtacado.HeaderText = "Qtd Atcd";
            this.qtdProdutoAtacado.Name = "qtdProdutoAtacado";
            this.qtdProdutoAtacado.ReadOnly = true;
            // 
            // totalPrecoAtacadoSemDesconto
            // 
            this.totalPrecoAtacadoSemDesconto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.totalPrecoAtacadoSemDesconto.DataPropertyName = "TotalPrecoVendaAtacadoSemDesconto";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle7.Format = "C2";
            this.totalPrecoAtacadoSemDesconto.DefaultCellStyle = dataGridViewCellStyle7;
            this.totalPrecoAtacadoSemDesconto.HeaderText = "Atacado";
            this.totalPrecoAtacadoSemDesconto.MinimumWidth = 90;
            this.totalPrecoAtacadoSemDesconto.Name = "totalPrecoAtacadoSemDesconto";
            this.totalPrecoAtacadoSemDesconto.ReadOnly = true;
            this.totalPrecoAtacadoSemDesconto.Width = 90;
            // 
            // totalPrecoAtacado
            // 
            this.totalPrecoAtacado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.totalPrecoAtacado.DataPropertyName = "TotalPrecoVendaAtacado";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle8.Format = "C2";
            this.totalPrecoAtacado.DefaultCellStyle = dataGridViewCellStyle8;
            this.totalPrecoAtacado.HeaderText = "Atacado à Vista";
            this.totalPrecoAtacado.MinimumWidth = 90;
            this.totalPrecoAtacado.Name = "totalPrecoAtacado";
            this.totalPrecoAtacado.ReadOnly = true;
            this.totalPrecoAtacado.Width = 90;
            // 
            // UltimaDataAtualizacao
            // 
            this.UltimaDataAtualizacao.DataPropertyName = "UltimaDataAtualizacao";
            dataGridViewCellStyle9.Format = "d";
            dataGridViewCellStyle9.NullValue = null;
            this.UltimaDataAtualizacao.DefaultCellStyle = dataGridViewCellStyle9;
            this.UltimaDataAtualizacao.HeaderText = "DT Atualização";
            this.UltimaDataAtualizacao.Name = "UltimaDataAtualizacao";
            this.UltimaDataAtualizacao.ReadOnly = true;
            // 
            // FrmProdutoPesquisaPreco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 642);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(tb_produto_lojaDataGridView);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_produtoDataGridView);
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBusca);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "FrmProdutoPesquisaPreco";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pesquisa Preço de Produtos";
            this.Load += new System.EventHandler(this.FrmProdutoPesquisaPreco_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmProdutoPesquisaPreco_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(tb_produto_lojaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoLojaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
  
    }
}