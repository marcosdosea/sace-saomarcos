namespace Telas
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBusca = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.tb_produtoDataGridView = new System.Windows.Forms.DataGridView();
            this.CodProduto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimaDataAtualizacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimoPrecoCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecoVendaVarejoSemDesconto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecoVendaAtacado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecoRevenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.produtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSalvar = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnEstatistica = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoBindingSource)).BeginInit();
            this.SuspendLayout();
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
            "Data Atualização Maior que",
            "Códigos de Barras Inválidos",
            "Códigos de Barras em Branco",
            "Data Última Mudança de Preço Etiqueta Maior que",
            "Nome Fabricante"});
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
            this.txtTexto.Size = new System.Drawing.Size(1023, 26);
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
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tb_produtoDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.tb_produtoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_produtoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodProduto,
            this.nomeDataGridViewTextBoxColumn,
            this.UltimaDataAtualizacao,
            this.UltimoPrecoCompra,
            this.PrecoVendaVarejoSemDesconto,
            this.PrecoVendaAtacado,
            this.PrecoRevenda});
            this.tb_produtoDataGridView.DataSource = this.produtoBindingSource;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tb_produtoDataGridView.DefaultCellStyle = dataGridViewCellStyle11;
            this.tb_produtoDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.tb_produtoDataGridView.Location = new System.Drawing.Point(12, 83);
            this.tb_produtoDataGridView.Name = "tb_produtoDataGridView";
            this.tb_produtoDataGridView.RowHeadersWidth = 7;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F);
            this.tb_produtoDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.tb_produtoDataGridView.RowTemplate.Height = 30;
            this.tb_produtoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_produtoDataGridView.Size = new System.Drawing.Size(1283, 419);
            this.tb_produtoDataGridView.TabIndex = 5;
            this.tb_produtoDataGridView.TabStop = false;
            this.tb_produtoDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.tb_produtoDataGridView_RowEnter);
            // 
            // CodProduto
            // 
            this.CodProduto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CodProduto.DataPropertyName = "CodProduto";
            this.CodProduto.FillWeight = 15F;
            this.CodProduto.HeaderText = "Código";
            this.CodProduto.Name = "CodProduto";
            this.CodProduto.ReadOnly = true;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            this.nomeDataGridViewTextBoxColumn.FillWeight = 84.26873F;
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Produto";
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            // 
            // UltimaDataAtualizacao
            // 
            this.UltimaDataAtualizacao.DataPropertyName = "UltimaDataAtualizacao";
            this.UltimaDataAtualizacao.HeaderText = "Última Atualização";
            this.UltimaDataAtualizacao.Name = "UltimaDataAtualizacao";
            this.UltimaDataAtualizacao.ReadOnly = true;
            // 
            // UltimoPrecoCompra
            // 
            this.UltimoPrecoCompra.DataPropertyName = "UltimoPrecoCompra";
            this.UltimoPrecoCompra.HeaderText = "Ultimo Preco Compra";
            this.UltimoPrecoCompra.Name = "UltimoPrecoCompra";
            // 
            // PrecoVendaVarejoSemDesconto
            // 
            this.PrecoVendaVarejoSemDesconto.DataPropertyName = "PrecoVendaVarejo";
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = null;
            this.PrecoVendaVarejoSemDesconto.DefaultCellStyle = dataGridViewCellStyle8;
            this.PrecoVendaVarejoSemDesconto.HeaderText = "Preço Varejo";
            this.PrecoVendaVarejoSemDesconto.Name = "PrecoVendaVarejoSemDesconto";
            // 
            // PrecoVendaAtacado
            // 
            this.PrecoVendaAtacado.DataPropertyName = "PrecoVendaAtacado";
            dataGridViewCellStyle9.Format = "C2";
            dataGridViewCellStyle9.NullValue = null;
            this.PrecoVendaAtacado.DefaultCellStyle = dataGridViewCellStyle9;
            this.PrecoVendaAtacado.HeaderText = "Preço Atacado";
            this.PrecoVendaAtacado.Name = "PrecoVendaAtacado";
            // 
            // PrecoRevenda
            // 
            this.PrecoRevenda.DataPropertyName = "PrecoRevenda";
            dataGridViewCellStyle10.Format = "c2";
            this.PrecoRevenda.DefaultCellStyle = dataGridViewCellStyle10;
            this.PrecoRevenda.HeaderText = "Preco Revenda";
            this.PrecoRevenda.Name = "PrecoRevenda";
            // 
            // produtoBindingSource
            // 
            this.produtoBindingSource.DataSource = typeof(Dominio.Produto);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(1149, 508);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(146, 23);
            this.btnSalvar.TabIndex = 6;
            this.btnSalvar.Text = "SALVAR ALTERAÇÕES";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "xls";
            this.saveFileDialog.FileName = "ProdutosEtiquetas.xls";
            this.saveFileDialog.InitialDirectory = "C:\\Documents and Settings\\vendas\\Meus documentos\\Dropbox\\Documentos\\etiquetas";
            this.saveFileDialog.Title = "Exportar Excel";
            // 
            // btnEstatistica
            // 
            this.btnEstatistica.Location = new System.Drawing.Point(1055, 508);
            this.btnEstatistica.Name = "btnEstatistica";
            this.btnEstatistica.Size = new System.Drawing.Size(88, 23);
            this.btnEstatistica.TabIndex = 8;
            this.btnEstatistica.Text = "F9 - Estatística";
            this.btnEstatistica.UseVisualStyleBackColor = true;
            this.btnEstatistica.Click += new System.EventHandler(this.btnEstatistica_Click);
            // 
            // FrmProdutoPreco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 539);
            this.ControlBox = false;
            this.Controls.Add(this.btnEstatistica);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.tb_produtoDataGridView);
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBusca);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "FrmProdutoPreco";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Atualiza Preço de Produtos";
            this.Load += new System.EventHandler(this.FrmProdutoPesquisaPreco_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmProdutoPesquisaPreco_KeyDown);
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
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodProduto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltimaDataAtualizacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltimoPrecoCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecoVendaVarejoSemDesconto;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecoVendaAtacado;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecoRevenda;
        private System.Windows.Forms.Button btnEstatistica;
  
    }
}