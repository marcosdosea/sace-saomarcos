namespace Telas
{
    partial class FrmLojaPesquisa
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
            this.tb_lojaDataGridView = new System.Windows.Forms.DataGridView();
            this.lojaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codLojaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tb_lojaDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lojaBindingSource)).BeginInit();
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
            this.txtTexto.Size = new System.Drawing.Size(326, 20);
            this.txtTexto.TabIndex = 1;
            this.txtTexto.TextChanged += new System.EventHandler(this.txtTexto_TextChanged);
            // 
            // tb_lojaDataGridView
            // 
            this.tb_lojaDataGridView.AllowUserToAddRows = false;
            this.tb_lojaDataGridView.AllowUserToDeleteRows = false;
            this.tb_lojaDataGridView.AutoGenerateColumns = false;
            this.tb_lojaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_lojaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codLojaDataGridViewTextBoxColumn,
            this.nomeDataGridViewTextBoxColumn});
            this.tb_lojaDataGridView.DataSource = this.lojaBindingSource;
            this.tb_lojaDataGridView.Location = new System.Drawing.Point(10, 53);
            this.tb_lojaDataGridView.MultiSelect = false;
            this.tb_lojaDataGridView.Name = "tb_lojaDataGridView";
            this.tb_lojaDataGridView.ReadOnly = true;
            this.tb_lojaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_lojaDataGridView.Size = new System.Drawing.Size(462, 241);
            this.tb_lojaDataGridView.TabIndex = 5;
            this.tb_lojaDataGridView.TabStop = false;
            // 
            // lojaBindingSource
            // 
            this.lojaBindingSource.DataSource = typeof(Dominio.Loja);
            // 
            // codLojaDataGridViewTextBoxColumn
            // 
            this.codLojaDataGridViewTextBoxColumn.DataPropertyName = "CodLoja";
            this.codLojaDataGridViewTextBoxColumn.HeaderText = "Código";
            this.codLojaDataGridViewTextBoxColumn.Name = "codLojaDataGridViewTextBoxColumn";
            this.codLojaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            this.nomeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            this.nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            this.nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            this.nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FrmLojaPesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 306);
            this.Controls.Add(this.tb_lojaDataGridView);
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBusca);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "FrmLojaPesquisa";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pesquisa Lojas";
            this.Load += new System.EventHandler(this.FrmLojaPesquisa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmLojaPesquisa_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tb_lojaDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lojaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBusca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.BindingSource lojaBindingSource;
        private System.Windows.Forms.DataGridView tb_lojaDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn codLojaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
  
    }
}