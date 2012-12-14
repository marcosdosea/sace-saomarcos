namespace Telas
{
    partial class FrmPessoaPesquisa
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
            this.tb_pessoaDataGridView = new System.Windows.Forms.DataGridView();
            this.pessoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codPessoaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeFantasiaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cpfCnpjDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Endereco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bairroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ufDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tb_pessoaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pessoaBindingSource)).BeginInit();
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
            "Nome Fantasia",
            "Código",
            "CPF",
            "Endereço",
            "Bairro"});
            this.cmbBusca.Location = new System.Drawing.Point(10, 26);
            this.cmbBusca.Name = "cmbBusca";
            this.cmbBusca.Size = new System.Drawing.Size(121, 21);
            this.cmbBusca.TabIndex = 3;
            this.cmbBusca.SelectedIndexChanged += new System.EventHandler(this.cmbBusca_SelectedIndexChanged);
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
            this.txtTexto.Size = new System.Drawing.Size(598, 20);
            this.txtTexto.TabIndex = 1;
            this.txtTexto.TextChanged += new System.EventHandler(this.txtTexto_TextChanged);
            // 
            // tb_pessoaDataGridView
            // 
            this.tb_pessoaDataGridView.AllowUserToAddRows = false;
            this.tb_pessoaDataGridView.AllowUserToDeleteRows = false;
            this.tb_pessoaDataGridView.AutoGenerateColumns = false;
            this.tb_pessoaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_pessoaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codPessoaDataGridViewTextBoxColumn,
            this.nomeFantasiaDataGridViewTextBoxColumn,
            this.cpfCnpjDataGridViewTextBoxColumn,
            this.Endereco,
            this.bairroDataGridViewTextBoxColumn,
            this.Cidade,
            this.ufDataGridViewTextBoxColumn});
            this.tb_pessoaDataGridView.DataSource = this.pessoaBindingSource;
            this.tb_pessoaDataGridView.Location = new System.Drawing.Point(10, 64);
            this.tb_pessoaDataGridView.MultiSelect = false;
            this.tb_pessoaDataGridView.Name = "tb_pessoaDataGridView";
            this.tb_pessoaDataGridView.ReadOnly = true;
            this.tb_pessoaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_pessoaDataGridView.Size = new System.Drawing.Size(734, 259);
            this.tb_pessoaDataGridView.TabIndex = 5;
            this.tb_pessoaDataGridView.TabStop = false;
            this.tb_pessoaDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tb_pessoaDataGridView_CellClick);
            // 
            // pessoaBindingSource
            // 
            this.pessoaBindingSource.DataSource = typeof(Dominio.Pessoa);
            // 
            // codPessoaDataGridViewTextBoxColumn
            // 
            this.codPessoaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.codPessoaDataGridViewTextBoxColumn.DataPropertyName = "CodPessoa";
            this.codPessoaDataGridViewTextBoxColumn.HeaderText = "Código";
            this.codPessoaDataGridViewTextBoxColumn.Name = "codPessoaDataGridViewTextBoxColumn";
            this.codPessoaDataGridViewTextBoxColumn.ReadOnly = true;
            this.codPessoaDataGridViewTextBoxColumn.Width = 65;
            // 
            // nomeFantasiaDataGridViewTextBoxColumn
            // 
            this.nomeFantasiaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomeFantasiaDataGridViewTextBoxColumn.DataPropertyName = "NomeFantasia";
            this.nomeFantasiaDataGridViewTextBoxColumn.HeaderText = "NomeFantasia";
            this.nomeFantasiaDataGridViewTextBoxColumn.MinimumWidth = 80;
            this.nomeFantasiaDataGridViewTextBoxColumn.Name = "nomeFantasiaDataGridViewTextBoxColumn";
            this.nomeFantasiaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cpfCnpjDataGridViewTextBoxColumn
            // 
            this.cpfCnpjDataGridViewTextBoxColumn.DataPropertyName = "CpfCnpj";
            this.cpfCnpjDataGridViewTextBoxColumn.HeaderText = "CpfCnpj";
            this.cpfCnpjDataGridViewTextBoxColumn.Name = "cpfCnpjDataGridViewTextBoxColumn";
            this.cpfCnpjDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Endereco
            // 
            this.Endereco.DataPropertyName = "Endereco";
            this.Endereco.HeaderText = "Endereco";
            this.Endereco.Name = "Endereco";
            this.Endereco.ReadOnly = true;
            // 
            // bairroDataGridViewTextBoxColumn
            // 
            this.bairroDataGridViewTextBoxColumn.DataPropertyName = "Bairro";
            this.bairroDataGridViewTextBoxColumn.HeaderText = "Bairro";
            this.bairroDataGridViewTextBoxColumn.Name = "bairroDataGridViewTextBoxColumn";
            this.bairroDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Cidade
            // 
            this.Cidade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Cidade.DataPropertyName = "Cidade";
            this.Cidade.HeaderText = "Cidade";
            this.Cidade.Name = "Cidade";
            this.Cidade.ReadOnly = true;
            this.Cidade.Width = 65;
            // 
            // ufDataGridViewTextBoxColumn
            // 
            this.ufDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ufDataGridViewTextBoxColumn.DataPropertyName = "Uf";
            this.ufDataGridViewTextBoxColumn.HeaderText = "Uf";
            this.ufDataGridViewTextBoxColumn.Name = "ufDataGridViewTextBoxColumn";
            this.ufDataGridViewTextBoxColumn.ReadOnly = true;
            this.ufDataGridViewTextBoxColumn.Width = 43;
            // 
            // FrmPessoaPesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 330);
            this.Controls.Add(this.tb_pessoaDataGridView);
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBusca);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "FrmPessoaPesquisa";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pesquisa Pessoas";
            this.Load += new System.EventHandler(this.FrmPessoaPesquisa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPessoaPesquisa_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tb_pessoaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pessoaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBusca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.DataGridView tb_pessoaDataGridView;
        private System.Windows.Forms.BindingSource pessoaBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn codPessoaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeFantasiaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cpfCnpjDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Endereco;
        private System.Windows.Forms.DataGridViewTextBoxColumn bairroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn ufDataGridViewTextBoxColumn;
  
    }
}