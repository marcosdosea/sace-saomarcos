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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pagamentoDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagamentoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textTotal = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbLoja = new System.Windows.Forms.RadioButton();
            this.rbCliente = new System.Windows.Forms.RadioButton();
            this.rbTodas = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumeroControle = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pagamentoDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pagamentoBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn4.HeaderText = "Valor";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // pagamentoBindingSource
            // 
            this.pagamentoBindingSource.DataSource = typeof(Cartao.Pagamento);
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
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(595, 234);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(107, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "F7 - &Cancelamento";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(595, 243);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(107, 23);
            this.btnImprimir.TabIndex = 9;
            this.btnImprimir.Text = "F8 - &Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbLoja);
            this.groupBox1.Controls.Add(this.rbCliente);
            this.groupBox1.Controls.Add(this.rbTodas);
            this.groupBox1.Location = new System.Drawing.Point(6, 183);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(96, 87);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Imprimir Vias";
            // 
            // rbLoja
            // 
            this.rbLoja.AutoSize = true;
            this.rbLoja.Location = new System.Drawing.Point(6, 62);
            this.rbLoja.Name = "rbLoja";
            this.rbLoja.Size = new System.Drawing.Size(45, 17);
            this.rbLoja.TabIndex = 2;
            this.rbLoja.Text = "Loja";
            this.rbLoja.UseVisualStyleBackColor = true;
            // 
            // rbCliente
            // 
            this.rbCliente.AutoSize = true;
            this.rbCliente.Location = new System.Drawing.Point(6, 39);
            this.rbCliente.Name = "rbCliente";
            this.rbCliente.Size = new System.Drawing.Size(57, 17);
            this.rbCliente.TabIndex = 1;
            this.rbCliente.Text = "Cliente";
            this.rbCliente.UseVisualStyleBackColor = true;
            // 
            // rbTodas
            // 
            this.rbTodas.AutoSize = true;
            this.rbTodas.Checked = true;
            this.rbTodas.Location = new System.Drawing.Point(6, 18);
            this.rbTodas.Name = "rbTodas";
            this.rbTodas.Size = new System.Drawing.Size(55, 17);
            this.rbTodas.TabIndex = 0;
            this.rbTodas.TabStop = true;
            this.rbTodas.Text = "Todas";
            this.rbTodas.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(120, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Número Controle:";
            this.label3.Visible = false;
            // 
            // txtNumeroControle
            // 
            this.txtNumeroControle.Location = new System.Drawing.Point(212, 185);
            this.txtNumeroControle.Name = "txtNumeroControle";
            this.txtNumeroControle.Size = new System.Drawing.Size(149, 20);
            this.txtNumeroControle.TabIndex = 29;
            this.txtNumeroControle.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(213, 214);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(149, 20);
            this.textBox1.TabIndex = 31;
            this.textBox1.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(121, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Código Saída:";
            this.label4.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(213, 241);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(149, 20);
            this.textBox2.TabIndex = 33;
            this.textBox2.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(121, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 32;
            this.label5.Text = "Senha Cappta:";
            this.label5.Visible = false;
            // 
            // FrmProcessarPagamentoCartao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 272);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtNumeroControle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pagamentoDataGridView);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "FrmProcessarPagamentoCartao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Processar Pagamento de Cartões de Crédito";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmProcessarPagamentoCartao_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pagamentoDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pagamentoBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource pagamentoBindingSource;
        private System.Windows.Forms.DataGridView pagamentoDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textTotal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbCliente;
        private System.Windows.Forms.RadioButton rbTodas;
        private System.Windows.Forms.RadioButton rbLoja;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumeroControle;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}