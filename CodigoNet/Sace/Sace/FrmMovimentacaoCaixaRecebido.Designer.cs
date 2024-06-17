namespace Telas
{
    partial class FrmMovimentacaoCaixaRecebido
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tb_produtoDataGridView = new System.Windows.Forms.DataGridView();
            this.movimentacaoPeriodoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.dataFinalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dataInicioDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.codSaidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataSaidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeClienteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descricaoTipoMovimentacaoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataHoraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.movimentacaoPeriodoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tb_produtoDataGridView
            // 
            this.tb_produtoDataGridView.AllowUserToAddRows = false;
            this.tb_produtoDataGridView.AllowUserToDeleteRows = false;
            this.tb_produtoDataGridView.AllowUserToResizeColumns = false;
            this.tb_produtoDataGridView.AllowUserToResizeRows = false;
            this.tb_produtoDataGridView.AutoGenerateColumns = false;
            this.tb_produtoDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tb_produtoDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.tb_produtoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tb_produtoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codSaidaDataGridViewTextBoxColumn,
            this.dataSaidaDataGridViewTextBoxColumn,
            this.nomeClienteDataGridViewTextBoxColumn,
            this.descricaoTipoMovimentacaoDataGridViewTextBoxColumn,
            this.valorDataGridViewTextBoxColumn,
            this.dataHoraDataGridViewTextBoxColumn});
            this.tb_produtoDataGridView.DataSource = this.movimentacaoPeriodoBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.tb_produtoDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.tb_produtoDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.tb_produtoDataGridView.Location = new System.Drawing.Point(12, 34);
            this.tb_produtoDataGridView.Name = "tb_produtoDataGridView";
            this.tb_produtoDataGridView.ReadOnly = true;
            this.tb_produtoDataGridView.RowHeadersWidth = 7;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F);
            this.tb_produtoDataGridView.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.tb_produtoDataGridView.RowTemplate.Height = 30;
            this.tb_produtoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.tb_produtoDataGridView.Size = new System.Drawing.Size(1283, 468);
            this.tb_produtoDataGridView.TabIndex = 5;
            this.tb_produtoDataGridView.TabStop = false;
            // 
            // movimentacaoPeriodoBindingSource
            // 
            this.movimentacaoPeriodoBindingSource.DataSource = typeof(Dominio.Consultas.MovimentacaoPeriodo);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(212, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 18);
            this.label3.TabIndex = 36;
            this.label3.Text = "Data Final:";
            // 
            // dataFinalDateTimePicker
            // 
            this.dataFinalDateTimePicker.Enabled = false;
            this.dataFinalDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dataFinalDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataFinalDateTimePicker.Location = new System.Drawing.Point(296, 3);
            this.dataFinalDateTimePicker.Name = "dataFinalDateTimePicker";
            this.dataFinalDateTimePicker.Size = new System.Drawing.Size(117, 24);
            this.dataFinalDateTimePicker.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 18);
            this.label2.TabIndex = 35;
            this.label2.Text = "Data Início";
            // 
            // dataInicioDateTimePicker
            // 
            this.dataInicioDateTimePicker.Enabled = false;
            this.dataInicioDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dataInicioDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataInicioDateTimePicker.Location = new System.Drawing.Point(89, 4);
            this.dataInicioDateTimePicker.Name = "dataInicioDateTimePicker";
            this.dataInicioDateTimePicker.Size = new System.Drawing.Size(117, 24);
            this.dataInicioDateTimePicker.TabIndex = 33;
            // 
            // codSaidaDataGridViewTextBoxColumn
            // 
            this.codSaidaDataGridViewTextBoxColumn.DataPropertyName = "CodSaida";
            this.codSaidaDataGridViewTextBoxColumn.FillWeight = 30F;
            this.codSaidaDataGridViewTextBoxColumn.HeaderText = "Saida";
            this.codSaidaDataGridViewTextBoxColumn.Name = "codSaidaDataGridViewTextBoxColumn";
            this.codSaidaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataSaidaDataGridViewTextBoxColumn
            // 
            this.dataSaidaDataGridViewTextBoxColumn.DataPropertyName = "DataSaida";
            this.dataSaidaDataGridViewTextBoxColumn.FillWeight = 50F;
            this.dataSaidaDataGridViewTextBoxColumn.HeaderText = "Data Saida";
            this.dataSaidaDataGridViewTextBoxColumn.Name = "dataSaidaDataGridViewTextBoxColumn";
            this.dataSaidaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomeClienteDataGridViewTextBoxColumn
            // 
            this.nomeClienteDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nomeClienteDataGridViewTextBoxColumn.DataPropertyName = "NomeCliente";
            this.nomeClienteDataGridViewTextBoxColumn.FillWeight = 120F;
            this.nomeClienteDataGridViewTextBoxColumn.HeaderText = "Cliente";
            this.nomeClienteDataGridViewTextBoxColumn.Name = "nomeClienteDataGridViewTextBoxColumn";
            this.nomeClienteDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descricaoTipoMovimentacaoDataGridViewTextBoxColumn
            // 
            this.descricaoTipoMovimentacaoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descricaoTipoMovimentacaoDataGridViewTextBoxColumn.DataPropertyName = "DescricaoTipoMovimentacao";
            this.descricaoTipoMovimentacaoDataGridViewTextBoxColumn.FillWeight = 50F;
            this.descricaoTipoMovimentacaoDataGridViewTextBoxColumn.HeaderText = "Tipo Movimentacao";
            this.descricaoTipoMovimentacaoDataGridViewTextBoxColumn.Name = "descricaoTipoMovimentacaoDataGridViewTextBoxColumn";
            this.descricaoTipoMovimentacaoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valorDataGridViewTextBoxColumn
            // 
            this.valorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.valorDataGridViewTextBoxColumn.DataPropertyName = "Valor";
            this.valorDataGridViewTextBoxColumn.FillWeight = 20F;
            this.valorDataGridViewTextBoxColumn.HeaderText = "Valor";
            this.valorDataGridViewTextBoxColumn.Name = "valorDataGridViewTextBoxColumn";
            this.valorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dataHoraDataGridViewTextBoxColumn
            // 
            this.dataHoraDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataHoraDataGridViewTextBoxColumn.DataPropertyName = "DataHora";
            this.dataHoraDataGridViewTextBoxColumn.FillWeight = 20F;
            this.dataHoraDataGridViewTextBoxColumn.HeaderText = "DataHora Recebimento";
            this.dataHoraDataGridViewTextBoxColumn.Name = "dataHoraDataGridViewTextBoxColumn";
            this.dataHoraDataGridViewTextBoxColumn.ReadOnly = true;
            this.dataHoraDataGridViewTextBoxColumn.Width = 165;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(1190, 508);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(105, 23);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "<ESC> Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FrmMovimentacaoCaixaRecebido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1307, 539);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataFinalDateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataInicioDateTimePicker);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.tb_produtoDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.Name = "FrmMovimentacaoCaixaRecebido";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pagamentos Recebidos:";
            this.Load += new System.EventHandler(this.FrmSaidaPagamentoRecebido_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSaidaPagamentoRecebido_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tb_produtoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.movimentacaoPeriodoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView tb_produtoDataGridView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dataFinalDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dataInicioDateTimePicker;
        private System.Windows.Forms.BindingSource movimentacaoPeriodoBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn codSaidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataSaidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeClienteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descricaoTipoMovimentacaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataHoraDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnCancelar;
  
    }
}