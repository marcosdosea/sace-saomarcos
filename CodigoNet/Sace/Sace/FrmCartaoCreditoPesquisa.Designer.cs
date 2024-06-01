namespace Telas
{
    partial class FrmCartaoCreditoPesquisa
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbBusca = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTexto = new System.Windows.Forms.TextBox();
            this.tb_cartao_creditoDataGridView = new System.Windows.Forms.DataGridView();
            this.cartaoCreditoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codCartaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomePessoaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tb_cartao_creditoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartaoCreditoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Buscar Por:";
            // 
            // cmbBusca
            // 
            this.cmbBusca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBusca.FormattingEnabled = true;
            this.cmbBusca.ImeMode = System.Windows.Forms.ImeMode.On;
            this.cmbBusca.Items.AddRange(new object[] {
            "Nome",
            "Código"});
            this.cmbBusca.Location = new System.Drawing.Point(10, 26);
            this.cmbBusca.Name = "cmbBusca";
            this.cmbBusca.Size = new System.Drawing.Size(121, 21);
            this.cmbBusca.TabIndex = 3;
            this.cmbBusca.SelectedIndexChanged += new System.EventHandler(this.cmbBusca_SelectedIndexChanged);
            this.cmbBusca.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCartaoCreditoPesquisa_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(143, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Texto:";
            // 
            // txtTexto
            // 
            this.txtTexto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTexto.Location = new System.Drawing.Point(146, 26);
            this.txtTexto.Name = "txtTexto";
            this.txtTexto.Size = new System.Drawing.Size(308, 20);
            this.txtTexto.TabIndex = 1;
            this.txtTexto.TextChanged += new System.EventHandler(this.txtTexto_TextChanged);
            // 
            // tb_cartao_creditoDataGridView
            // 
            this.tb_cartao_creditoDataGridView.AllowUserToAddRows = false;
            this.tb_cartao_creditoDataGridView.AllowUserToDeleteRows = false;
            this.tb_cartao_creditoDataGridView.AutoGenerateColumns = false;
            this.tb_cartao_creditoDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tb_cartao_creditoDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tb_cartao_creditoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_cartao_creditoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codCartaoDataGridViewTextBoxColumn,
            this.nomeDataGridViewTextBoxColumn,
            this.nomePessoaDataGridViewTextBoxColumn});
            this.tb_cartao_creditoDataGridView.DataSource = this.cartaoCreditoBindingSource;
            this.tb_cartao_creditoDataGridView.Location = new System.Drawing.Point(10, 66);
            this.tb_cartao_creditoDataGridView.Name = "tb_cartao_creditoDataGridView";
            this.tb_cartao_creditoDataGridView.ReadOnly = true;
            this.tb_cartao_creditoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_cartao_creditoDataGridView.Size = new System.Drawing.Size(444, 220);
            this.tb_cartao_creditoDataGridView.TabIndex = 4;
            this.tb_cartao_creditoDataGridView.TabStop = false;
            // 
            // cartaoCreditoBindingSource
            // 
            this.cartaoCreditoBindingSource.DataSource = typeof(Dominio.CartaoCredito);
            // 
            // codCartaoDataGridViewTextBoxColumn
            // 
            this.codCartaoDataGridViewTextBoxColumn.DataPropertyName = "CodCartao";
            this.codCartaoDataGridViewTextBoxColumn.HeaderText = "CodCartao";
            this.codCartaoDataGridViewTextBoxColumn.Name = "codCartaoDataGridViewTextBoxColumn";
            this.codCartaoDataGridViewTextBoxColumn.ReadOnly = true;
            this.codCartaoDataGridViewTextBoxColumn.Visible = false;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            this.nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomePessoaDataGridViewTextBoxColumn
            // 
            this.nomePessoaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomePessoaDataGridViewTextBoxColumn.DataPropertyName = "NomePessoa";
            this.nomePessoaDataGridViewTextBoxColumn.HeaderText = "NomePessoa";
            this.nomePessoaDataGridViewTextBoxColumn.Name = "nomePessoaDataGridViewTextBoxColumn";
            this.nomePessoaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FrmCartaoCreditoPesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 294);
            this.Controls.Add(this.tb_cartao_creditoDataGridView);
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBusca);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "FrmCartaoCreditoPesquisa";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pesquisa Cartões de Crédito";
            this.Load += new System.EventHandler(this.FrmCartaoCreditoPesquisa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCartaoCreditoPesquisa_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tb_cartao_creditoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartaoCreditoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBusca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.BindingSource cartaoCreditoBindingSource;
        private System.Windows.Forms.DataGridView tb_cartao_creditoDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn codCartaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomePessoaDataGridViewTextBoxColumn;
        
    }
}