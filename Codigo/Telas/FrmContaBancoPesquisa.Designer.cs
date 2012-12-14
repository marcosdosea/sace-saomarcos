namespace Telas
{
    partial class FrmContaBancoPesquisa
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
            this.tb_conta_bancoDataGridView = new System.Windows.Forms.DataGridView();
            this.contaBancoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codContaBancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroContaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.agenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeBancoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tb_conta_bancoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contaBancoBindingSource)).BeginInit();
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
            "Número Conta",
            "Descrição"});
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
            this.txtTexto.Size = new System.Drawing.Size(450, 20);
            this.txtTexto.TabIndex = 1;
            this.txtTexto.TextChanged += new System.EventHandler(this.txtTexto_TextChanged);
            // 
            // tb_conta_bancoDataGridView
            // 
            this.tb_conta_bancoDataGridView.AllowUserToAddRows = false;
            this.tb_conta_bancoDataGridView.AllowUserToDeleteRows = false;
            this.tb_conta_bancoDataGridView.AutoGenerateColumns = false;
            this.tb_conta_bancoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_conta_bancoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codContaBancoDataGridViewTextBoxColumn,
            this.descricaoDataGridViewTextBoxColumn,
            this.numeroContaDataGridViewTextBoxColumn,
            this.agenciaDataGridViewTextBoxColumn,
            this.nomeBancoDataGridViewTextBoxColumn});
            this.tb_conta_bancoDataGridView.DataSource = this.contaBancoBindingSource;
            this.tb_conta_bancoDataGridView.Location = new System.Drawing.Point(17, 61);
            this.tb_conta_bancoDataGridView.MultiSelect = false;
            this.tb_conta_bancoDataGridView.Name = "tb_conta_bancoDataGridView";
            this.tb_conta_bancoDataGridView.ReadOnly = true;
            this.tb_conta_bancoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_conta_bancoDataGridView.Size = new System.Drawing.Size(579, 220);
            this.tb_conta_bancoDataGridView.TabIndex = 4;
            this.tb_conta_bancoDataGridView.TabStop = false;
            // 
            // contaBancoBindingSource
            // 
            this.contaBancoBindingSource.DataSource = typeof(Dominio.ContaBanco);
            // 
            // codContaBancoDataGridViewTextBoxColumn
            // 
            this.codContaBancoDataGridViewTextBoxColumn.DataPropertyName = "CodContaBanco";
            this.codContaBancoDataGridViewTextBoxColumn.HeaderText = "Código";
            this.codContaBancoDataGridViewTextBoxColumn.Name = "codContaBancoDataGridViewTextBoxColumn";
            this.codContaBancoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descricaoDataGridViewTextBoxColumn
            // 
            this.descricaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricaoDataGridViewTextBoxColumn.DataPropertyName = "Descricao";
            this.descricaoDataGridViewTextBoxColumn.HeaderText = "Descricao";
            this.descricaoDataGridViewTextBoxColumn.Name = "descricaoDataGridViewTextBoxColumn";
            this.descricaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numeroContaDataGridViewTextBoxColumn
            // 
            this.numeroContaDataGridViewTextBoxColumn.DataPropertyName = "NumeroConta";
            this.numeroContaDataGridViewTextBoxColumn.HeaderText = "Número Conta";
            this.numeroContaDataGridViewTextBoxColumn.Name = "numeroContaDataGridViewTextBoxColumn";
            this.numeroContaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // agenciaDataGridViewTextBoxColumn
            // 
            this.agenciaDataGridViewTextBoxColumn.DataPropertyName = "Agencia";
            this.agenciaDataGridViewTextBoxColumn.HeaderText = "Agencia";
            this.agenciaDataGridViewTextBoxColumn.Name = "agenciaDataGridViewTextBoxColumn";
            this.agenciaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeBancoDataGridViewTextBoxColumn
            // 
            this.nomeBancoDataGridViewTextBoxColumn.DataPropertyName = "NomeBanco";
            this.nomeBancoDataGridViewTextBoxColumn.HeaderText = "NomeBanco";
            this.nomeBancoDataGridViewTextBoxColumn.Name = "nomeBancoDataGridViewTextBoxColumn";
            this.nomeBancoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FrmContaBancoPesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 313);
            this.Controls.Add(this.tb_conta_bancoDataGridView);
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBusca);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "FrmContaBancoPesquisa";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pesquisa Contas Bancárias/Caixas";
            this.Load += new System.EventHandler(this.FrmBancoPesquisa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBancoPesquisa_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tb_conta_bancoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contaBancoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBusca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.DataGridView tb_conta_bancoDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn codContaBancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroContaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn agenciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeBancoDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource contaBancoBindingSource;
  
    }
}