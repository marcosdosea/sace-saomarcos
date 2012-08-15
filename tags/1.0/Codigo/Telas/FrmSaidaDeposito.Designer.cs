namespace Telas
{
    partial class FrmSaidaDeposito
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
            this.tb_saidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saceDataSet = new Dados.saceDataSet();
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.codSaidaTextBox = new System.Windows.Forms.TextBox();
            this.tb_tipo_saidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tb_tipo_saidaTableAdapter = new Dados.saceDataSetTableAdapters.tb_tipo_saidaTableAdapter();
            this.tb_saidaTableAdapter = new Dados.saceDataSetTableAdapters.tb_saidaTableAdapter();
            this.descricaoTipoSaidaTextBox = new System.Windows.Forms.TextBox();
            this.tb_lojaBindingSourceOrigem = new System.Windows.Forms.BindingSource(this.components);
            this.codPessoaComboBox = new System.Windows.Forms.ComboBox();
            this.codPessoaComboBox1 = new System.Windows.Forms.ComboBox();
            this.tb_lojaBindingSourceDestino = new System.Windows.Forms.BindingSource(this.components);
            this.tb_lojaTableAdapter = new Dados.saceDataSetTableAdapters.tb_lojaTableAdapter();
            tipoSaidaLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            codSaidaLabel = new System.Windows.Forms.Label();
            codPessoaLabel = new System.Windows.Forms.Label();
            codPessoaLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tb_saidaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_tipo_saidaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_lojaBindingSourceOrigem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_lojaBindingSourceDestino)).BeginInit();
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
            codSaidaLabel.Location = new System.Drawing.Point(546, 9);
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
            codPessoaLabel.Size = new System.Drawing.Size(152, 29);
            codPessoaLabel.TabIndex = 65;
            codPessoaLabel.Text = "Loja Origem:";
            // 
            // codPessoaLabel1
            // 
            codPessoaLabel1.AutoSize = true;
            codPessoaLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codPessoaLabel1.Location = new System.Drawing.Point(7, 164);
            codPessoaLabel1.Name = "codPessoaLabel1";
            codPessoaLabel1.Size = new System.Drawing.Size(153, 29);
            codPessoaLabel1.TabIndex = 66;
            codPessoaLabel1.Text = "Loja Destino:";
            // 
            // tb_saidaBindingSource
            // 
            this.tb_saidaBindingSource.DataMember = "tb_saida";
            this.tb_saidaBindingSource.DataSource = this.saceDataSet;
            // 
            // saceDataSet
            // 
            this.saceDataSet.DataSetName = "saceDataSet";
            this.saceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // totalTextBox
            // 
            this.totalTextBox.BackColor = System.Drawing.Color.Blue;
            this.totalTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "total", true));
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
            this.btnSalvar.Location = new System.Drawing.Point(493, 267);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(81, 23);
            this.btnSalvar.TabIndex = 33;
            this.btnSalvar.Text = "F6 - Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(580, 267);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 36;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // codSaidaTextBox
            // 
            this.codSaidaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "codSaida", true));
            this.codSaidaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codSaidaTextBox.Location = new System.Drawing.Point(550, 39);
            this.codSaidaTextBox.Name = "codSaidaTextBox";
            this.codSaidaTextBox.ReadOnly = true;
            this.codSaidaTextBox.Size = new System.Drawing.Size(114, 35);
            this.codSaidaTextBox.TabIndex = 6;
            this.codSaidaTextBox.TabStop = false;
            // 
            // tb_tipo_saidaBindingSource
            // 
            this.tb_tipo_saidaBindingSource.AllowNew = false;
            this.tb_tipo_saidaBindingSource.DataMember = "tb_tipo_saida";
            this.tb_tipo_saidaBindingSource.DataSource = this.saceDataSet;
            // 
            // tb_tipo_saidaTableAdapter
            // 
            this.tb_tipo_saidaTableAdapter.ClearBeforeFill = true;
            // 
            // tb_saidaTableAdapter
            // 
            this.tb_saidaTableAdapter.ClearBeforeFill = true;
            // 
            // descricaoTipoSaidaTextBox
            // 
            this.descricaoTipoSaidaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_saidaBindingSource, "descricaoTipoSaida", true));
            this.descricaoTipoSaidaTextBox.Enabled = false;
            this.descricaoTipoSaidaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descricaoTipoSaidaTextBox.Location = new System.Drawing.Point(169, 39);
            this.descricaoTipoSaidaTextBox.Name = "descricaoTipoSaidaTextBox";
            this.descricaoTipoSaidaTextBox.Size = new System.Drawing.Size(369, 35);
            this.descricaoTipoSaidaTextBox.TabIndex = 4;
            // 
            // tb_lojaBindingSourceOrigem
            // 
            this.tb_lojaBindingSourceOrigem.AllowNew = false;
            this.tb_lojaBindingSourceOrigem.DataMember = "tb_loja";
            this.tb_lojaBindingSourceOrigem.DataSource = this.saceDataSet;
            // 
            // codPessoaComboBox
            // 
            this.codPessoaComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_lojaBindingSourceOrigem, "codPessoa", true));
            this.codPessoaComboBox.DataSource = this.tb_lojaBindingSourceOrigem;
            this.codPessoaComboBox.DisplayMember = "nome";
            this.codPessoaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codPessoaComboBox.Enabled = false;
            this.codPessoaComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codPessoaComboBox.FormattingEnabled = true;
            this.codPessoaComboBox.Location = new System.Drawing.Point(11, 120);
            this.codPessoaComboBox.Name = "codPessoaComboBox";
            this.codPessoaComboBox.Size = new System.Drawing.Size(653, 37);
            this.codPessoaComboBox.TabIndex = 8;
            this.codPessoaComboBox.TabStop = false;
            this.codPessoaComboBox.ValueMember = "codPessoa";
            // 
            // codPessoaComboBox1
            // 
            this.codPessoaComboBox1.CausesValidation = false;
            this.codPessoaComboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tb_lojaBindingSourceOrigem, "codPessoa", true));
            this.codPessoaComboBox1.DataSource = this.tb_lojaBindingSourceDestino;
            this.codPessoaComboBox1.DisplayMember = "nome";
            this.codPessoaComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codPessoaComboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codPessoaComboBox1.FormattingEnabled = true;
            this.codPessoaComboBox1.Location = new System.Drawing.Point(12, 200);
            this.codPessoaComboBox1.Name = "codPessoaComboBox1";
            this.codPessoaComboBox1.Size = new System.Drawing.Size(652, 37);
            this.codPessoaComboBox1.TabIndex = 10;
            this.codPessoaComboBox1.ValueMember = "codPessoa";
            // 
            // tb_lojaBindingSourceDestino
            // 
            this.tb_lojaBindingSourceDestino.AllowNew = false;
            this.tb_lojaBindingSourceDestino.DataMember = "tb_loja";
            this.tb_lojaBindingSourceDestino.DataSource = this.saceDataSet;
            // 
            // tb_lojaTableAdapter
            // 
            this.tb_lojaTableAdapter.ClearBeforeFill = true;
            // 
            // FrmSaidaDeposito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 294);
            this.Controls.Add(codPessoaLabel1);
            this.Controls.Add(this.codPessoaComboBox1);
            this.Controls.Add(codPessoaLabel);
            this.Controls.Add(this.codPessoaComboBox);
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
            this.Name = "FrmSaidaDeposito";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagamento";
            this.Load += new System.EventHandler(this.FrmSaidaDeposito_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSaidaDeposito_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.tb_saidaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_tipo_saidaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_lojaBindingSourceOrigem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_lojaBindingSourceDestino)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Dados.saceDataSet saceDataSet;
        private System.Windows.Forms.BindingSource tb_saidaBindingSource;
        private System.Windows.Forms.TextBox totalTextBox;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox codSaidaTextBox;
        private System.Windows.Forms.BindingSource tb_tipo_saidaBindingSource;
        private Dados.saceDataSetTableAdapters.tb_tipo_saidaTableAdapter tb_tipo_saidaTableAdapter;
        private Dados.saceDataSetTableAdapters.tb_saidaTableAdapter tb_saidaTableAdapter;
        private System.Windows.Forms.TextBox descricaoTipoSaidaTextBox;
        private System.Windows.Forms.BindingSource tb_lojaBindingSourceOrigem;
        private System.Windows.Forms.ComboBox codPessoaComboBox;
        private System.Windows.Forms.ComboBox codPessoaComboBox1;
        private System.Windows.Forms.BindingSource tb_lojaBindingSourceDestino;
        private Dados.saceDataSetTableAdapters.tb_lojaTableAdapter tb_lojaTableAdapter;
    }
}