namespace Telas
{
    partial class FrmSubgrupoPesquisa
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
            this.subgrupoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_subgrupoDataGridView = new System.Windows.Forms.DataGridView();
            this.codSubgrupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codGrupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaoGrupoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.subgrupoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_subgrupoDataGridView)).BeginInit();
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
            // subgrupoBindingSource
            // 
            this.subgrupoBindingSource.DataSource = typeof(Dominio.Subgrupo);
            // 
            // tb_subgrupoDataGridView
            // 
            this.tb_subgrupoDataGridView.AllowUserToAddRows = false;
            this.tb_subgrupoDataGridView.AllowUserToDeleteRows = false;
            this.tb_subgrupoDataGridView.AutoGenerateColumns = false;
            this.tb_subgrupoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_subgrupoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codSubgrupoDataGridViewTextBoxColumn,
            this.descricaoDataGridViewTextBoxColumn,
            this.codGrupoDataGridViewTextBoxColumn,
            this.descricaoGrupoDataGridViewTextBoxColumn});
            this.tb_subgrupoDataGridView.DataSource = this.subgrupoBindingSource;
            this.tb_subgrupoDataGridView.Location = new System.Drawing.Point(10, 62);
            this.tb_subgrupoDataGridView.Name = "tb_subgrupoDataGridView";
            this.tb_subgrupoDataGridView.ReadOnly = true;
            this.tb_subgrupoDataGridView.Size = new System.Drawing.Size(586, 220);
            this.tb_subgrupoDataGridView.TabIndex = 5;
            // 
            // codSubgrupoDataGridViewTextBoxColumn
            // 
            this.codSubgrupoDataGridViewTextBoxColumn.DataPropertyName = "CodSubgrupo";
            this.codSubgrupoDataGridViewTextBoxColumn.HeaderText = "Código";
            this.codSubgrupoDataGridViewTextBoxColumn.Name = "codSubgrupoDataGridViewTextBoxColumn";
            this.codSubgrupoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descricaoDataGridViewTextBoxColumn
            // 
            this.descricaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricaoDataGridViewTextBoxColumn.DataPropertyName = "Descricao";
            this.descricaoDataGridViewTextBoxColumn.HeaderText = "Descricao";
            this.descricaoDataGridViewTextBoxColumn.Name = "descricaoDataGridViewTextBoxColumn";
            this.descricaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // codGrupoDataGridViewTextBoxColumn
            // 
            this.codGrupoDataGridViewTextBoxColumn.DataPropertyName = "CodGrupo";
            this.codGrupoDataGridViewTextBoxColumn.HeaderText = "CodGrupo";
            this.codGrupoDataGridViewTextBoxColumn.Name = "codGrupoDataGridViewTextBoxColumn";
            this.codGrupoDataGridViewTextBoxColumn.ReadOnly = true;
            this.codGrupoDataGridViewTextBoxColumn.Visible = false;
            // 
            // descricaoGrupoDataGridViewTextBoxColumn
            // 
            this.descricaoGrupoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricaoGrupoDataGridViewTextBoxColumn.DataPropertyName = "DescricaoGrupo";
            this.descricaoGrupoDataGridViewTextBoxColumn.HeaderText = "Grupo";
            this.descricaoGrupoDataGridViewTextBoxColumn.Name = "descricaoGrupoDataGridViewTextBoxColumn";
            this.descricaoGrupoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FrmSubgrupoPesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 287);
            this.Controls.Add(this.tb_subgrupoDataGridView);
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBusca);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "FrmSubgrupoPesquisa";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pesquisa Subgrupo de Produtos";
            this.Load += new System.EventHandler(this.FrmSubgrupoPesquisa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSubgrupoPesquisa_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.subgrupoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_subgrupoDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBusca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.BindingSource subgrupoBindingSource;
        private System.Windows.Forms.DataGridView tb_subgrupoDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn codSubgrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codGrupoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoGrupoDataGridViewTextBoxColumn;
  
    }
}