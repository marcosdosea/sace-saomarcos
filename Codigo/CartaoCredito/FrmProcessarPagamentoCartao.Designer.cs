namespace Cartao
{
    partial class FrmProcessarPagamentoCartao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pagamentoDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.textTotal = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagamentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnProcessar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pagamentoDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pagamentoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pagamentoDataGridView
            // 
            this.pagamentoDataGridView.AllowUserToAddRows = false;
            this.pagamentoDataGridView.AllowUserToDeleteRows = false;
            this.pagamentoDataGridView.AutoGenerateColumns = false;
            this.pagamentoDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pagamentoDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn4});
            this.pagamentoDataGridView.DataSource = this.pagamentoBindingSource;
            this.pagamentoDataGridView.Location = new System.Drawing.Point(4, 48);
            this.pagamentoDataGridView.Name = "pagamentoDataGridView";
            this.pagamentoDataGridView.ReadOnly = true;
            this.pagamentoDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.pagamentoDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.pagamentoDataGridView.Size = new System.Drawing.Size(694, 132);
            this.pagamentoDataGridView.TabIndex = 1;
            this.pagamentoDataGridView.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Processar Cartões de Crédito";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(709, 41);
            this.panel1.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(438, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 25);
            this.label2.TabIndex = 25;
            this.label2.Text = "Total (R$):";
            // 
            // textTotal
            // 
            this.textTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.textTotal.Location = new System.Drawing.Point(549, 186);
            this.textTotal.Name = "textTotal";
            this.textTotal.Size = new System.Drawing.Size(149, 30);
            this.textTotal.TabIndex = 26;
            this.textTotal.TabStop = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "NomeCartao";
            this.dataGridViewTextBoxColumn1.HeaderText = "Cartão";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TipoCartao";
            this.dataGridViewTextBoxColumn2.HeaderText = "TipoCartao";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TipoParcelamento";
            this.dataGridViewTextBoxColumn3.HeaderText = "Parcelamento";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "QuantidadeParcelas";
            this.dataGridViewTextBoxColumn5.HeaderText = "Parcelas";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Valor";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn4.HeaderText = "Valor";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // pagamentoBindingSource
            // 
            this.pagamentoBindingSource.DataSource = typeof(Cartao.Pagamento);
            // 
            // btnProcessar
            // 
            this.btnProcessar.Location = new System.Drawing.Point(498, 234);
            this.btnProcessar.Name = "btnProcessar";
            this.btnProcessar.Size = new System.Drawing.Size(97, 27);
            this.btnProcessar.TabIndex = 27;
            this.btnProcessar.Tag = "";
            this.btnProcessar.Text = "F6 - Processar";
            this.btnProcessar.UseVisualStyleBackColor = true;
            this.btnProcessar.Click += new System.EventHandler(this.btnProcessar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(601, 234);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(97, 27);
            this.btnCancelar.TabIndex = 28;
            this.btnCancelar.Tag = "";
            this.btnCancelar.Text = "ESC - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FrmProcessarPagamentoCartao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 263);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnProcessar);
            this.Controls.Add(this.textTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pagamentoDataGridView);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "FrmProcessarPagamentoCartao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Processar Pagamento de Cartões de Crédito";
            ((System.ComponentModel.ISupportInitialize)(this.pagamentoDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pagamentoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource pagamentoBindingSource;
        private System.Windows.Forms.DataGridView pagamentoDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Button btnProcessar;
        private System.Windows.Forms.Button btnCancelar;
    }
}