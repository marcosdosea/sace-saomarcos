namespace Sace
{
    partial class FrmSaidaPagamentoBoleto
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
            System.Windows.Forms.Label cupomFiscalLabel;
            System.Windows.Forms.Label nomeClienteLabel;
            System.Windows.Forms.Label totalLabel;
            System.Windows.Forms.Label numeroDocumentoLabel;
            System.Windows.Forms.Label dataVencimentoLabel;
            System.Windows.Forms.Label valorPagarLabel;
            System.Windows.Forms.Label dataEmissaoCupomFiscalLabel;
            this.cupomFiscalTextBox = new System.Windows.Forms.TextBox();
            this.saidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nomeClienteTextBox = new System.Windows.Forms.TextBox();
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.numeroDocumentoTextBox = new System.Windows.Forms.TextBox();
            this.contaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataVencimentoDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.valorPagarTextBox = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.contaDataGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dataEmissaoCupomFiscalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            cupomFiscalLabel = new System.Windows.Forms.Label();
            nomeClienteLabel = new System.Windows.Forms.Label();
            totalLabel = new System.Windows.Forms.Label();
            numeroDocumentoLabel = new System.Windows.Forms.Label();
            dataVencimentoLabel = new System.Windows.Forms.Label();
            valorPagarLabel = new System.Windows.Forms.Label();
            dataEmissaoCupomFiscalLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.saidaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.contaDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // cupomFiscalLabel
            // 
            cupomFiscalLabel.AutoSize = true;
            cupomFiscalLabel.Location = new System.Drawing.Point(11, 49);
            cupomFiscalLabel.Name = "cupomFiscalLabel";
            cupomFiscalLabel.Size = new System.Drawing.Size(73, 13);
            cupomFiscalLabel.TabIndex = 1;
            cupomFiscalLabel.Text = "Cupom Fiscal:";
            // 
            // nomeClienteLabel
            // 
            nomeClienteLabel.AutoSize = true;
            nomeClienteLabel.Location = new System.Drawing.Point(12, 9);
            nomeClienteLabel.Name = "nomeClienteLabel";
            nomeClienteLabel.Size = new System.Drawing.Size(73, 13);
            nomeClienteLabel.TabIndex = 2;
            nomeClienteLabel.Text = "Nome Cliente:";
            // 
            // totalLabel
            // 
            totalLabel.AutoSize = true;
            totalLabel.Location = new System.Drawing.Point(364, 49);
            totalLabel.Name = "totalLabel";
            totalLabel.Size = new System.Drawing.Size(34, 13);
            totalLabel.TabIndex = 6;
            totalLabel.Text = "Total:";
            // 
            // numeroDocumentoLabel
            // 
            numeroDocumentoLabel.AutoSize = true;
            numeroDocumentoLabel.Location = new System.Drawing.Point(9, 89);
            numeroDocumentoLabel.Name = "numeroDocumentoLabel";
            numeroDocumentoLabel.Size = new System.Drawing.Size(105, 13);
            numeroDocumentoLabel.TabIndex = 8;
            numeroDocumentoLabel.Text = "Numero Documento:";
            // 
            // dataVencimentoLabel
            // 
            dataVencimentoLabel.AutoSize = true;
            dataVencimentoLabel.Location = new System.Drawing.Point(208, 89);
            dataVencimentoLabel.Name = "dataVencimentoLabel";
            dataVencimentoLabel.Size = new System.Drawing.Size(92, 13);
            dataVencimentoLabel.TabIndex = 10;
            dataVencimentoLabel.Text = "Data Vencimento:";
            // 
            // valorPagarLabel
            // 
            valorPagarLabel.AutoSize = true;
            valorPagarLabel.Location = new System.Drawing.Point(364, 89);
            valorPagarLabel.Name = "valorPagarLabel";
            valorPagarLabel.Size = new System.Drawing.Size(65, 13);
            valorPagarLabel.TabIndex = 12;
            valorPagarLabel.Text = "Valor Pagar:";
            // 
            // dataEmissaoCupomFiscalLabel
            // 
            dataEmissaoCupomFiscalLabel.AutoSize = true;
            dataEmissaoCupomFiscalLabel.Location = new System.Drawing.Point(208, 49);
            dataEmissaoCupomFiscalLabel.Name = "dataEmissaoCupomFiscalLabel";
            dataEmissaoCupomFiscalLabel.Size = new System.Drawing.Size(141, 13);
            dataEmissaoCupomFiscalLabel.TabIndex = 4;
            dataEmissaoCupomFiscalLabel.Text = "Data Emissao Cupom Fiscal:";
            // 
            // cupomFiscalTextBox
            // 
            this.cupomFiscalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.saidaBindingSource, "CupomFiscal", true));
            this.cupomFiscalTextBox.Location = new System.Drawing.Point(12, 66);
            this.cupomFiscalTextBox.Name = "cupomFiscalTextBox";
            this.cupomFiscalTextBox.ReadOnly = true;
            this.cupomFiscalTextBox.Size = new System.Drawing.Size(180, 20);
            this.cupomFiscalTextBox.TabIndex = 2;
            this.cupomFiscalTextBox.TabStop = false;
            // 
            // saidaBindingSource
            // 
            this.saidaBindingSource.DataSource = typeof(Dominio.Saida);
            // 
            // nomeClienteTextBox
            // 
            this.nomeClienteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.saidaBindingSource, "NomeCliente", true));
            this.nomeClienteTextBox.Location = new System.Drawing.Point(12, 25);
            this.nomeClienteTextBox.Name = "nomeClienteTextBox";
            this.nomeClienteTextBox.ReadOnly = true;
            this.nomeClienteTextBox.Size = new System.Drawing.Size(544, 20);
            this.nomeClienteTextBox.TabIndex = 3;
            this.nomeClienteTextBox.TabStop = false;
            // 
            // totalTextBox
            // 
            this.totalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.saidaBindingSource, "Total", true));
            this.totalTextBox.Enabled = false;
            this.totalTextBox.Location = new System.Drawing.Point(367, 66);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.Size = new System.Drawing.Size(189, 20);
            this.totalTextBox.TabIndex = 7;
            this.totalTextBox.TabStop = false;
            // 
            // numeroDocumentoTextBox
            // 
            this.numeroDocumentoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contaBindingSource, "NumeroDocumento", true));
            this.numeroDocumentoTextBox.Enabled = false;
            this.numeroDocumentoTextBox.Location = new System.Drawing.Point(12, 105);
            this.numeroDocumentoTextBox.Name = "numeroDocumentoTextBox";
            this.numeroDocumentoTextBox.Size = new System.Drawing.Size(180, 20);
            this.numeroDocumentoTextBox.TabIndex = 9;
            this.numeroDocumentoTextBox.TabStop = false;
            // 
            // contaBindingSource
            // 
            this.contaBindingSource.DataSource = typeof(Dominio.Conta);
            // 
            // dataVencimentoDateTimePicker
            // 
            this.dataVencimentoDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.contaBindingSource, "DataVencimento", true));
            this.dataVencimentoDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataVencimentoDateTimePicker.Location = new System.Drawing.Point(211, 105);
            this.dataVencimentoDateTimePicker.Name = "dataVencimentoDateTimePicker";
            this.dataVencimentoDateTimePicker.Size = new System.Drawing.Size(138, 20);
            this.dataVencimentoDateTimePicker.TabIndex = 11;
            // 
            // valorPagarTextBox
            // 
            this.valorPagarTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.contaBindingSource, "ValorPagar", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.valorPagarTextBox.Location = new System.Drawing.Point(367, 108);
            this.valorPagarTextBox.Name = "valorPagarTextBox";
            this.valorPagarTextBox.Size = new System.Drawing.Size(189, 20);
            this.valorPagarTextBox.TabIndex = 13;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(385, 276);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 14;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(472, 276);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // contaDataGridView
            // 
            this.contaDataGridView.AllowUserToAddRows = false;
            this.contaDataGridView.AllowUserToDeleteRows = false;
            this.contaDataGridView.AutoGenerateColumns = false;
            this.contaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contaDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn14});
            this.contaDataGridView.DataSource = this.contaBindingSource;
            this.contaDataGridView.Location = new System.Drawing.Point(12, 155);
            this.contaDataGridView.MultiSelect = false;
            this.contaDataGridView.Name = "contaDataGridView";
            this.contaDataGridView.ReadOnly = true;
            this.contaDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.contaDataGridView.Size = new System.Drawing.Size(543, 115);
            this.contaDataGridView.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(97, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "DEL - Excluir";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(16, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 64;
            this.label6.Text = "F12 - Navegar";
            // 
            // dataEmissaoCupomFiscalDateTimePicker
            // 
            this.dataEmissaoCupomFiscalDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.saidaBindingSource, "DataEmissaoCupomFiscal", true));
            this.dataEmissaoCupomFiscalDateTimePicker.Enabled = false;
            this.dataEmissaoCupomFiscalDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataEmissaoCupomFiscalDateTimePicker.Location = new System.Drawing.Point(211, 66);
            this.dataEmissaoCupomFiscalDateTimePicker.Name = "dataEmissaoCupomFiscalDateTimePicker";
            this.dataEmissaoCupomFiscalDateTimePicker.Size = new System.Drawing.Size(138, 20);
            this.dataEmissaoCupomFiscalDateTimePicker.TabIndex = 5;
            this.dataEmissaoCupomFiscalDateTimePicker.TabStop = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CodConta";
            this.dataGridViewTextBoxColumn1.FillWeight = 150F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Conta";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn18.DataPropertyName = "NumeroDocumento";
            this.dataGridViewTextBoxColumn18.HeaderText = "Documento";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "DataVencimento";
            this.dataGridViewTextBoxColumn7.HeaderText = "Vencimento";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "DescricaoSituacao";
            this.dataGridViewTextBoxColumn10.HeaderText = "Situacao";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "ValorPagar";
            this.dataGridViewTextBoxColumn14.HeaderText = "Valor Pagar";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 150;
            // 
            // FrmSaidaPagamentoBoleto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 305);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.contaDataGridView);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(valorPagarLabel);
            this.Controls.Add(this.valorPagarTextBox);
            this.Controls.Add(dataVencimentoLabel);
            this.Controls.Add(this.dataVencimentoDateTimePicker);
            this.Controls.Add(numeroDocumentoLabel);
            this.Controls.Add(this.numeroDocumentoTextBox);
            this.Controls.Add(totalLabel);
            this.Controls.Add(this.totalTextBox);
            this.Controls.Add(dataEmissaoCupomFiscalLabel);
            this.Controls.Add(this.dataEmissaoCupomFiscalDateTimePicker);
            this.Controls.Add(nomeClienteLabel);
            this.Controls.Add(this.nomeClienteTextBox);
            this.Controls.Add(this.cupomFiscalTextBox);
            this.Controls.Add(cupomFiscalLabel);
            this.KeyPreview = true;
            this.Name = "FrmSaidaPagamentoBoleto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Pagamento por Boletos";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSaidaPagamentoBoleto_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.saidaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.contaDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource saidaBindingSource;
        private System.Windows.Forms.TextBox cupomFiscalTextBox;
        private System.Windows.Forms.TextBox nomeClienteTextBox;
        private System.Windows.Forms.TextBox totalTextBox;
        private System.Windows.Forms.BindingSource contaBindingSource;
        private System.Windows.Forms.TextBox numeroDocumentoTextBox;
        private System.Windows.Forms.DateTimePicker dataVencimentoDateTimePicker;
        private System.Windows.Forms.TextBox valorPagarTextBox;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView contaDataGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dataEmissaoCupomFiscalDateTimePicker;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
    }
}