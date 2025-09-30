namespace Sace
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            label1 = new Label();
            cmbBusca = new ComboBox();
            label2 = new Label();
            txtTexto = new TextBox();
            btnSalvar = new Button();
            saveFileDialog = new SaveFileDialog();
            btnEstatistica = new Button();
            PrecoRevenda = new DataGridViewTextBoxColumn();
            PrecoVendaAtacado = new DataGridViewTextBoxColumn();
            PrecoVendaVarejoSemDesconto = new DataGridViewTextBoxColumn();
            UltimoPrecoCompra = new DataGridViewTextBoxColumn();
            UltimaDataAtualizacao = new DataGridViewTextBoxColumn();
            CodProduto = new DataGridViewTextBoxColumn();
            tb_produtoDataGridView = new DataGridView();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            produtoBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)tb_produtoDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)produtoBindingSource).BeginInit();
            SuspendLayout();
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
            cmbBusca.Items.AddRange(new object[] { "Descrição", "Código", "Referência Fabricante", "Nome Produto no Fabricante", "Data Atualização Maior que", "Códigos de Barras Inválidos", "Códigos de Barras em Branco", "Data Última Mudança de Preço Etiqueta Maior que", "Nome Fabricante" });
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
            txtTexto.Size = new Size(1193, 26);
            txtTexto.TabIndex = 1;
            txtTexto.TextChanged += txtTexto_TextChanged;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(1340, 586);
            btnSalvar.Margin = new Padding(4, 3, 4, 3);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(170, 27);
            btnSalvar.TabIndex = 6;
            btnSalvar.Text = "SALVAR ALTERAÇÕES";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // saveFileDialog
            // 
            saveFileDialog.DefaultExt = "xls";
            saveFileDialog.FileName = "ProdutosEtiquetas.xls";
            saveFileDialog.InitialDirectory = "C:\\Documents and Settings\\vendas\\Meus documentos\\Dropbox\\Documentos\\etiquetas";
            saveFileDialog.Title = "Exportar Excel";
            // 
            // btnEstatistica
            // 
            btnEstatistica.Location = new Point(1231, 586);
            btnEstatistica.Margin = new Padding(4, 3, 4, 3);
            btnEstatistica.Name = "btnEstatistica";
            btnEstatistica.Size = new Size(103, 27);
            btnEstatistica.TabIndex = 8;
            btnEstatistica.Text = "F9 - Estatística";
            btnEstatistica.UseVisualStyleBackColor = true;
            btnEstatistica.Click += btnEstatistica_Click;
            // 
            // PrecoRevenda
            // 
            PrecoRevenda.DataPropertyName = "PrecoRevenda";
            dataGridViewCellStyle1.Format = "C3";
            PrecoRevenda.DefaultCellStyle = dataGridViewCellStyle1;
            PrecoRevenda.HeaderText = "Preco Revenda";
            PrecoRevenda.Name = "PrecoRevenda";
            // 
            // PrecoVendaAtacado
            // 
            PrecoVendaAtacado.DataPropertyName = "PrecoVendaAtacado";
            dataGridViewCellStyle2.Format = "C3";
            dataGridViewCellStyle2.NullValue = null;
            PrecoVendaAtacado.DefaultCellStyle = dataGridViewCellStyle2;
            PrecoVendaAtacado.HeaderText = "Preço Atacado";
            PrecoVendaAtacado.Name = "PrecoVendaAtacado";
            // 
            // PrecoVendaVarejoSemDesconto
            // 
            PrecoVendaVarejoSemDesconto.DataPropertyName = "PrecoVendaVarejo";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            PrecoVendaVarejoSemDesconto.DefaultCellStyle = dataGridViewCellStyle3;
            PrecoVendaVarejoSemDesconto.HeaderText = "Preço Varejo";
            PrecoVendaVarejoSemDesconto.Name = "PrecoVendaVarejoSemDesconto";
            // 
            // UltimoPrecoCompra
            // 
            UltimoPrecoCompra.DataPropertyName = "UltimoPrecoCompra";
            UltimoPrecoCompra.HeaderText = "Ultimo Preco Compra";
            UltimoPrecoCompra.Name = "UltimoPrecoCompra";
            // 
            // UltimaDataAtualizacao
            // 
            UltimaDataAtualizacao.DataPropertyName = "UltimaDataAtualizacao";
            UltimaDataAtualizacao.HeaderText = "Última Atualização";
            UltimaDataAtualizacao.Name = "UltimaDataAtualizacao";
            UltimaDataAtualizacao.ReadOnly = true;
            // 
            // CodProduto
            // 
            CodProduto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CodProduto.DataPropertyName = "CodProduto";
            CodProduto.FillWeight = 15F;
            CodProduto.HeaderText = "Código";
            CodProduto.Name = "CodProduto";
            CodProduto.ReadOnly = true;
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
            tb_produtoDataGridView.Columns.AddRange(new DataGridViewColumn[] { CodProduto, nomeDataGridViewTextBoxColumn, UltimaDataAtualizacao, UltimoPrecoCompra, PrecoVendaVarejoSemDesconto, PrecoVendaAtacado, PrecoRevenda });
            tb_produtoDataGridView.DataSource = produtoBindingSource;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.Padding = new Padding(0, 5, 0, 0);
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            tb_produtoDataGridView.DefaultCellStyle = dataGridViewCellStyle5;
            tb_produtoDataGridView.EditMode = DataGridViewEditMode.EditOnEnter;
            tb_produtoDataGridView.Location = new Point(14, 96);
            tb_produtoDataGridView.Margin = new Padding(4, 3, 4, 3);
            tb_produtoDataGridView.Name = "tb_produtoDataGridView";
            tb_produtoDataGridView.RowHeadersWidth = 7;
            dataGridViewCellStyle6.Font = new Font("Microsoft Sans Serif", 11F);
            tb_produtoDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle6;
            tb_produtoDataGridView.RowTemplate.Height = 30;
            tb_produtoDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tb_produtoDataGridView.Size = new Size(1497, 483);
            tb_produtoDataGridView.TabIndex = 5;
            tb_produtoDataGridView.TabStop = false;
            tb_produtoDataGridView.RowEnter += tb_produtoDataGridView_RowEnter;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.FillWeight = 84.26873F;
            nomeDataGridViewTextBoxColumn.HeaderText = "Produto";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            // 
            // produtoBindingSource
            // 
            produtoBindingSource.DataSource = typeof(Dominio.Produto);
            // 
            // FrmProdutoPreco
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1540, 661);
            ControlBox = false;
            Controls.Add(btnEstatistica);
            Controls.Add(btnSalvar);
            Controls.Add(tb_produtoDataGridView);
            Controls.Add(txtTexto);
            Controls.Add(label2);
            Controls.Add(cmbBusca);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmProdutoPreco";
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Atualiza Preço de Produtos";
            Load += FrmProdutoPesquisaPreco_Load;
            KeyDown += FrmProdutoPesquisaPreco_KeyDown;
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
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button btnEstatistica;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecoRevenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecoVendaAtacado;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecoVendaVarejoSemDesconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltimoPrecoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltimaDataAtualizacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodProduto;
        private System.Windows.Forms.DataGridView tb_produtoDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
  
    }
}