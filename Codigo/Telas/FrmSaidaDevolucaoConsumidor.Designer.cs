namespace Telas
{
    partial class FrmSaidaDevolucaoConsumidor
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
            System.Windows.Forms.Label tipoSaidaLabel;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label codSaidaLabel;
            System.Windows.Forms.Label codPessoaLabel;
            System.Windows.Forms.Label codPessoaLabel1;
            System.Windows.Forms.Label cupomFiscalLabel;
            System.Windows.Forms.Label dataEmissaoCupomFiscalLabel;
            System.Windows.Forms.Label nomeClienteLabel;
            this.saidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.codSaidaTextBox = new System.Windows.Forms.TextBox();
            this.descricaoTipoSaidaTextBox = new System.Windows.Forms.TextBox();
            this.lojaBindingSourceOrigem = new System.Windows.Forms.BindingSource(this.components);
            this.codPessoaComboBoxOrigem = new System.Windows.Forms.ComboBox();
            this.pessoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.codPessoaConsumidorComboBox = new System.Windows.Forms.ComboBox();
            this.cupomFiscalComboBox = new System.Windows.Forms.ComboBox();
            this.cupomFiscalBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataEmissaoCupomFiscalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.nomeClienteTextBox = new System.Windows.Forms.TextBox();
            tipoSaidaLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            codSaidaLabel = new System.Windows.Forms.Label();
            codPessoaLabel = new System.Windows.Forms.Label();
            codPessoaLabel1 = new System.Windows.Forms.Label();
            cupomFiscalLabel = new System.Windows.Forms.Label();
            dataEmissaoCupomFiscalLabel = new System.Windows.Forms.Label();
            nomeClienteLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.saidaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lojaBindingSourceOrigem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pessoaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cupomFiscalBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tipoSaidaLabel
            // 
            tipoSaidaLabel.AutoSize = true;
            tipoSaidaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tipoSaidaLabel.Location = new System.Drawing.Point(165, 6);
            tipoSaidaLabel.Name = "tipoSaidaLabel";
            tipoSaidaLabel.Size = new System.Drawing.Size(137, 29);
            tipoSaidaLabel.TabIndex = 12;
            tipoSaidaLabel.Text = "Tipo Saída:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label3.Location = new System.Drawing.Point(6, 3);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(74, 29);
            label3.TabIndex = 21;
            label3.Text = "Total:";
            // 
            // codSaidaLabel
            // 
            codSaidaLabel.AutoSize = true;
            codSaidaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codSaidaLabel.Location = new System.Drawing.Point(670, 9);
            codSaidaLabel.Name = "codSaidaLabel";
            codSaidaLabel.Size = new System.Drawing.Size(81, 29);
            codSaidaLabel.TabIndex = 65;
            codSaidaLabel.Text = "Saída:";
            // 
            // codPessoaLabel
            // 
            codPessoaLabel.AutoSize = true;
            codPessoaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codPessoaLabel.Location = new System.Drawing.Point(6, 82);
            codPessoaLabel.Name = "codPessoaLabel";
            codPessoaLabel.Size = new System.Drawing.Size(157, 29);
            codPessoaLabel.TabIndex = 65;
            codPessoaLabel.Text = "Loja Retorno:";
            // 
            // codPessoaLabel1
            // 
            codPessoaLabel1.AutoSize = true;
            codPessoaLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            codPessoaLabel1.Location = new System.Drawing.Point(7, 162);
            codPessoaLabel1.Name = "codPessoaLabel1";
            codPessoaLabel1.Size = new System.Drawing.Size(150, 29);
            codPessoaLabel1.TabIndex = 65;
            codPessoaLabel1.Text = "Consumidor:";
            // 
            // cupomFiscalLabel
            // 
            cupomFiscalLabel.AutoSize = true;
            cupomFiscalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            cupomFiscalLabel.Location = new System.Drawing.Point(7, 245);
            cupomFiscalLabel.Name = "cupomFiscalLabel";
            cupomFiscalLabel.Size = new System.Drawing.Size(167, 29);
            cupomFiscalLabel.TabIndex = 66;
            cupomFiscalLabel.Text = "Cupom Fiscal:";
            // 
            // dataEmissaoCupomFiscalLabel
            // 
            dataEmissaoCupomFiscalLabel.AutoSize = true;
            dataEmissaoCupomFiscalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            dataEmissaoCupomFiscalLabel.Location = new System.Drawing.Point(181, 245);
            dataEmissaoCupomFiscalLabel.Name = "dataEmissaoCupomFiscalLabel";
            dataEmissaoCupomFiscalLabel.Size = new System.Drawing.Size(167, 29);
            dataEmissaoCupomFiscalLabel.TabIndex = 67;
            dataEmissaoCupomFiscalLabel.Text = "Data Emissão:";
            // 
            // nomeClienteLabel
            // 
            nomeClienteLabel.AutoSize = true;
            nomeClienteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            nomeClienteLabel.Location = new System.Drawing.Point(365, 245);
            nomeClienteLabel.Name = "nomeClienteLabel";
            nomeClienteLabel.Size = new System.Drawing.Size(95, 29);
            nomeClienteLabel.TabIndex = 68;
            nomeClienteLabel.Text = "Cliente:";
            // 
            // saidaBindingSource
            // 
            this.saidaBindingSource.DataSource = typeof(Dominio.Saida);
            // 
            // totalTextBox
            // 
            this.totalTextBox.BackColor = System.Drawing.Color.Blue;
            this.totalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.saidaBindingSource, "total", true));
            this.totalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalTextBox.ForeColor = System.Drawing.Color.Yellow;
            this.totalTextBox.Location = new System.Drawing.Point(12, 39);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.Size = new System.Drawing.Size(148, 35);
            this.totalTextBox.TabIndex = 2;
            this.totalTextBox.TabStop = false;
            this.totalTextBox.Text = "999.999,99";
            this.totalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(617, 338);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 33;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(704, 338);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 36;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // codSaidaTextBox
            // 
            this.codSaidaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.saidaBindingSource, "codSaida", true));
            this.codSaidaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codSaidaTextBox.Location = new System.Drawing.Point(674, 39);
            this.codSaidaTextBox.Name = "codSaidaTextBox";
            this.codSaidaTextBox.ReadOnly = true;
            this.codSaidaTextBox.Size = new System.Drawing.Size(114, 35);
            this.codSaidaTextBox.TabIndex = 6;
            this.codSaidaTextBox.TabStop = false;
            // 
            // descricaoTipoSaidaTextBox
            // 
            this.descricaoTipoSaidaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.saidaBindingSource, "descricaoTipoSaida", true));
            this.descricaoTipoSaidaTextBox.Enabled = false;
            this.descricaoTipoSaidaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descricaoTipoSaidaTextBox.Location = new System.Drawing.Point(169, 39);
            this.descricaoTipoSaidaTextBox.Name = "descricaoTipoSaidaTextBox";
            this.descricaoTipoSaidaTextBox.Size = new System.Drawing.Size(495, 35);
            this.descricaoTipoSaidaTextBox.TabIndex = 4;
            // 
            // lojaBindingSourceOrigem
            // 
            this.lojaBindingSourceOrigem.AllowNew = false;
            this.lojaBindingSourceOrigem.DataSource = typeof(Dominio.Loja);
            // 
            // codPessoaComboBoxOrigem
            // 
            this.codPessoaComboBoxOrigem.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.lojaBindingSourceOrigem, "codPessoa", true));
            this.codPessoaComboBoxOrigem.DataSource = this.lojaBindingSourceOrigem;
            this.codPessoaComboBoxOrigem.DisplayMember = "nome";
            this.codPessoaComboBoxOrigem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codPessoaComboBoxOrigem.Enabled = false;
            this.codPessoaComboBoxOrigem.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codPessoaComboBoxOrigem.FormattingEnabled = true;
            this.codPessoaComboBoxOrigem.Location = new System.Drawing.Point(11, 120);
            this.codPessoaComboBoxOrigem.Name = "codPessoaComboBoxOrigem";
            this.codPessoaComboBoxOrigem.Size = new System.Drawing.Size(777, 37);
            this.codPessoaComboBoxOrigem.TabIndex = 8;
            this.codPessoaComboBoxOrigem.TabStop = false;
            this.codPessoaComboBoxOrigem.ValueMember = "codPessoa";
            // 
            // pessoaBindingSource
            // 
            this.pessoaBindingSource.DataSource = typeof(Dominio.Pessoa);
            // 
            // codPessoaConsumidorComboBox
            // 
            this.codPessoaConsumidorComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codPessoaConsumidorComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codPessoaConsumidorComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pessoaBindingSource, "Nome", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.codPessoaConsumidorComboBox.DataSource = this.pessoaBindingSource;
            this.codPessoaConsumidorComboBox.DisplayMember = "Nome";
            this.codPessoaConsumidorComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.codPessoaConsumidorComboBox.FormattingEnabled = true;
            this.codPessoaConsumidorComboBox.Location = new System.Drawing.Point(11, 198);
            this.codPessoaConsumidorComboBox.Name = "codPessoaConsumidorComboBox";
            this.codPessoaConsumidorComboBox.Size = new System.Drawing.Size(777, 37);
            this.codPessoaConsumidorComboBox.TabIndex = 66;
            this.codPessoaConsumidorComboBox.ValueMember = "CodPessoa";
            // 
            // cupomFiscalComboBox
            // 
            this.cupomFiscalComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.saidaBindingSource, "CupomFiscal", true));
            this.cupomFiscalComboBox.DataSource = this.cupomFiscalBindingSource;
            this.cupomFiscalComboBox.DisplayMember = "NumeroCupomFiscal";
            this.cupomFiscalComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.cupomFiscalComboBox.FormattingEnabled = true;
            this.cupomFiscalComboBox.Location = new System.Drawing.Point(12, 284);
            this.cupomFiscalComboBox.Name = "cupomFiscalComboBox";
            this.cupomFiscalComboBox.Size = new System.Drawing.Size(151, 37);
            this.cupomFiscalComboBox.TabIndex = 67;
            this.cupomFiscalComboBox.ValueMember = "CodSaida";
            // 
            // cupomFiscalBindingSource
            // 
            this.cupomFiscalBindingSource.DataSource = typeof(Dominio.DocumentoFiscal);
            // 
            // dataEmissaoCupomFiscalDateTimePicker
            // 
            this.dataEmissaoCupomFiscalDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.cupomFiscalBindingSource, "DataEmissaoCupomFiscal", true));
            this.dataEmissaoCupomFiscalDateTimePicker.Enabled = false;
            this.dataEmissaoCupomFiscalDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.dataEmissaoCupomFiscalDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataEmissaoCupomFiscalDateTimePicker.Location = new System.Drawing.Point(186, 284);
            this.dataEmissaoCupomFiscalDateTimePicker.Name = "dataEmissaoCupomFiscalDateTimePicker";
            this.dataEmissaoCupomFiscalDateTimePicker.Size = new System.Drawing.Size(162, 35);
            this.dataEmissaoCupomFiscalDateTimePicker.TabIndex = 68;
            // 
            // nomeClienteTextBox
            // 
            this.nomeClienteTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cupomFiscalBindingSource, "NomeCliente", true));
            this.nomeClienteTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.nomeClienteTextBox.Location = new System.Drawing.Point(370, 284);
            this.nomeClienteTextBox.Name = "nomeClienteTextBox";
            this.nomeClienteTextBox.ReadOnly = true;
            this.nomeClienteTextBox.Size = new System.Drawing.Size(418, 35);
            this.nomeClienteTextBox.TabIndex = 69;
            // 
            // FrmSaidaDevolucaoConsumidor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 369);
            this.Controls.Add(nomeClienteLabel);
            this.Controls.Add(this.nomeClienteTextBox);
            this.Controls.Add(dataEmissaoCupomFiscalLabel);
            this.Controls.Add(this.dataEmissaoCupomFiscalDateTimePicker);
            this.Controls.Add(cupomFiscalLabel);
            this.Controls.Add(this.cupomFiscalComboBox);
            this.Controls.Add(codPessoaLabel1);
            this.Controls.Add(this.codPessoaConsumidorComboBox);
            this.Controls.Add(codPessoaLabel);
            this.Controls.Add(this.codPessoaComboBoxOrigem);
            this.Controls.Add(this.descricaoTipoSaidaTextBox);
            this.Controls.Add(this.codSaidaTextBox);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.totalTextBox);
            this.Controls.Add(tipoSaidaLabel);
            this.Controls.Add(label3);
            this.Controls.Add(codSaidaLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmSaidaDevolucaoConsumidor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devolução";
            this.Load += new System.EventHandler(this.FrmSaidaDevolucaoConsumidor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSaidaDeposito_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.saidaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lojaBindingSourceOrigem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pessoaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cupomFiscalBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource saidaBindingSource;
        private System.Windows.Forms.TextBox totalTextBox;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox codSaidaTextBox;
        private System.Windows.Forms.TextBox descricaoTipoSaidaTextBox;
        private System.Windows.Forms.BindingSource lojaBindingSourceOrigem;
        private System.Windows.Forms.ComboBox codPessoaComboBoxOrigem;
        private System.Windows.Forms.BindingSource pessoaBindingSource;
        private System.Windows.Forms.ComboBox codPessoaConsumidorComboBox;
        private System.Windows.Forms.ComboBox cupomFiscalComboBox;
        private System.Windows.Forms.DateTimePicker dataEmissaoCupomFiscalDateTimePicker;
        private System.Windows.Forms.TextBox nomeClienteTextBox;
        private System.Windows.Forms.BindingSource cupomFiscalBindingSource;
    }
}