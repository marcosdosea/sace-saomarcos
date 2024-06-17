﻿namespace Telas
{
    partial class FrmGrupoContaPesquisa
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
            this.grupoContaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_grupo_contaDataGridView = new System.Windows.Forms.DataGridView();
            this.codGrupoContaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grupoContaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_grupo_contaDataGridView)).BeginInit();
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
            "Descrição",
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
            this.txtTexto.Size = new System.Drawing.Size(308, 20);
            this.txtTexto.TabIndex = 1;
            this.txtTexto.TextChanged += new System.EventHandler(this.txtTexto_TextChanged);
            // 
            // grupoContaBindingSource
            // 
            this.grupoContaBindingSource.AllowNew = false;
            this.grupoContaBindingSource.DataSource = typeof(Dominio.GrupoConta);
            // 
            // tb_grupo_contaDataGridView
            // 
            this.tb_grupo_contaDataGridView.AllowUserToAddRows = false;
            this.tb_grupo_contaDataGridView.AllowUserToDeleteRows = false;
            this.tb_grupo_contaDataGridView.AutoGenerateColumns = false;
            this.tb_grupo_contaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_grupo_contaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codGrupoContaDataGridViewTextBoxColumn,
            this.descricaoDataGridViewTextBoxColumn});
            this.tb_grupo_contaDataGridView.DataSource = this.grupoContaBindingSource;
            this.tb_grupo_contaDataGridView.Location = new System.Drawing.Point(10, 53);
            this.tb_grupo_contaDataGridView.Name = "tb_grupo_contaDataGridView";
            this.tb_grupo_contaDataGridView.ReadOnly = true;
            this.tb_grupo_contaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_grupo_contaDataGridView.Size = new System.Drawing.Size(444, 220);
            this.tb_grupo_contaDataGridView.TabIndex = 5;
            this.tb_grupo_contaDataGridView.TabStop = false;
            // 
            // codGrupoContaDataGridViewTextBoxColumn
            // 
            this.codGrupoContaDataGridViewTextBoxColumn.DataPropertyName = "CodGrupoConta";
            this.codGrupoContaDataGridViewTextBoxColumn.HeaderText = "Código";
            this.codGrupoContaDataGridViewTextBoxColumn.Name = "codGrupoContaDataGridViewTextBoxColumn";
            this.codGrupoContaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descricaoDataGridViewTextBoxColumn
            // 
            this.descricaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricaoDataGridViewTextBoxColumn.DataPropertyName = "Descricao";
            this.descricaoDataGridViewTextBoxColumn.HeaderText = "Descrição";
            this.descricaoDataGridViewTextBoxColumn.Name = "descricaoDataGridViewTextBoxColumn";
            this.descricaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FrmGrupoContaPesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 279);
            this.Controls.Add(this.tb_grupo_contaDataGridView);
            this.Controls.Add(this.txtTexto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbBusca);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "FrmGrupoContaPesquisa";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pesquisa Grupo de Contas";
            this.Load += new System.EventHandler(this.FrmGrupoContaPesquisa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmGrupoContaPesquisa_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grupoContaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_grupo_contaDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbBusca;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTexto;
        private System.Windows.Forms.BindingSource grupoContaBindingSource;
        private System.Windows.Forms.DataGridView tb_grupo_contaDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn codGrupoContaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoDataGridViewTextBoxColumn;
  
    }
}