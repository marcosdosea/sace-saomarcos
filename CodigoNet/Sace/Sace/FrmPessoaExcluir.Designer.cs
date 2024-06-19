namespace Sace
{
    partial class FrmPessoaExcluir
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label cpfCnpjLabel;
            System.Windows.Forms.Label enderecoLabel;
            System.Windows.Forms.Label nomeLabel;
            System.Windows.Forms.Label ieLabel;
            System.Windows.Forms.Label cpfCnpjLabel1;
            System.Windows.Forms.Label enderecoLabel1;
            System.Windows.Forms.Label ieLabel1;
            System.Windows.Forms.Label nomeLabel1;
            this.codPessoaLabel = new System.Windows.Forms.Label();
            this.codPessoaLabel1 = new System.Windows.Forms.Label();
            this.codPessoaLabel2 = new System.Windows.Forms.Label();
            this.codPessoaComboBox = new System.Windows.Forms.ComboBox();
            this.codPessoaTextBox = new System.Windows.Forms.TextBox();
            this.codPessoaComboBox1 = new System.Windows.Forms.ComboBox();
            this.codPessoaTextBox1 = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.pessoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pessoaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cpfCnpjTextBox = new System.Windows.Forms.TextBox();
            this.enderecoTextBox = new System.Windows.Forms.TextBox();
            this.nomeTextBox = new System.Windows.Forms.TextBox();
            this.ieTextBox = new System.Windows.Forms.TextBox();
            this.cpfCnpjTextBox1 = new System.Windows.Forms.TextBox();
            this.enderecoTextBox1 = new System.Windows.Forms.TextBox();
            this.ieTextBox1 = new System.Windows.Forms.TextBox();
            this.nomeTextBox1 = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            cpfCnpjLabel = new System.Windows.Forms.Label();
            enderecoLabel = new System.Windows.Forms.Label();
            nomeLabel = new System.Windows.Forms.Label();
            ieLabel = new System.Windows.Forms.Label();
            cpfCnpjLabel1 = new System.Windows.Forms.Label();
            enderecoLabel1 = new System.Windows.Forms.Label();
            ieLabel1 = new System.Windows.Forms.Label();
            nomeLabel1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pessoaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pessoaBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // codPessoaLabel
            // 
            this.codPessoaLabel.AutoSize = true;
            this.codPessoaLabel.ForeColor = System.Drawing.Color.Red;
            this.codPessoaLabel.Location = new System.Drawing.Point(12, 9);
            this.codPessoaLabel.Name = "codPessoaLabel";
            this.codPessoaLabel.Size = new System.Drawing.Size(168, 13);
            this.codPessoaLabel.TabIndex = 1;
            this.codPessoaLabel.Text = "Nome Fantasia Pessoa EXCLUIR:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.Green;
            label1.Location = new System.Drawing.Point(13, 145);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(366, 13);
            label1.TabIndex = 11;
            label1.Text = "Nome Fantasia Pessoa SUBSTITUTO (usar para fazer MERGE de Vendas):";
            // 
            // codPessoaLabel1
            // 
            this.codPessoaLabel1.AutoSize = true;
            this.codPessoaLabel1.Location = new System.Drawing.Point(448, 9);
            this.codPessoaLabel1.Name = "codPessoaLabel1";
            this.codPessoaLabel1.Size = new System.Drawing.Size(67, 13);
            this.codPessoaLabel1.TabIndex = 11;
            this.codPessoaLabel1.Text = "Cod Pessoa:";
            // 
            // codPessoaLabel2
            // 
            this.codPessoaLabel2.AutoSize = true;
            this.codPessoaLabel2.Location = new System.Drawing.Point(448, 145);
            this.codPessoaLabel2.Name = "codPessoaLabel2";
            this.codPessoaLabel2.Size = new System.Drawing.Size(67, 13);
            this.codPessoaLabel2.TabIndex = 14;
            this.codPessoaLabel2.Text = "Cod Pessoa:";
            // 
            // codPessoaComboBox
            // 
            this.codPessoaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codPessoaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codPessoaComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pessoaBindingSource, "NomeFantasia", true));
            this.codPessoaComboBox.DataSource = this.pessoaBindingSource;
            this.codPessoaComboBox.DisplayMember = "NomeFantasia";
            this.codPessoaComboBox.FormattingEnabled = true;
            this.codPessoaComboBox.Location = new System.Drawing.Point(12, 25);
            this.codPessoaComboBox.Name = "codPessoaComboBox";
            this.codPessoaComboBox.Size = new System.Drawing.Size(430, 21);
            this.codPessoaComboBox.TabIndex = 2;
            this.codPessoaComboBox.ValueMember = "CodPessoa";
            this.codPessoaComboBox.SelectedIndexChanged += new System.EventHandler(this.codPessoaComboBox_Leave);
            this.codPessoaComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codPessoaComboBox_KeyPress);
            this.codPessoaComboBox.Leave += new System.EventHandler(this.codPessoaComboBox_Leave);
            // 
            // codPessoaTextBox
            // 
            this.codPessoaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pessoaBindingSource, "CodPessoa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.codPessoaTextBox.Location = new System.Drawing.Point(448, 25);
            this.codPessoaTextBox.Name = "codPessoaTextBox";
            this.codPessoaTextBox.ReadOnly = true;
            this.codPessoaTextBox.Size = new System.Drawing.Size(125, 20);
            this.codPessoaTextBox.TabIndex = 13;
            this.codPessoaTextBox.TabStop = false;
            // 
            // codPessoaComboBox1
            // 
            this.codPessoaComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codPessoaComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codPessoaComboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pessoaBindingSource1, "NomeFantasia", true));
            this.codPessoaComboBox1.DataSource = this.pessoaBindingSource1;
            this.codPessoaComboBox1.DisplayMember = "NomeFantasia";
            this.codPessoaComboBox1.FormattingEnabled = true;
            this.codPessoaComboBox1.Location = new System.Drawing.Point(12, 161);
            this.codPessoaComboBox1.Name = "codPessoaComboBox1";
            this.codPessoaComboBox1.Size = new System.Drawing.Size(430, 21);
            this.codPessoaComboBox1.TabIndex = 14;
            this.codPessoaComboBox1.ValueMember = "CodPessoa";
            this.codPessoaComboBox1.SelectedIndexChanged += new System.EventHandler(this.codPessoaComboBox1_Leave);
            this.codPessoaComboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codPessoaComboBox_KeyPress);
            this.codPessoaComboBox1.Leave += new System.EventHandler(this.codPessoaComboBox1_Leave);
            // 
            // codPessoaTextBox1
            // 
            this.codPessoaTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pessoaBindingSource1, "CodPessoa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.codPessoaTextBox1.Enabled = false;
            this.codPessoaTextBox1.Location = new System.Drawing.Point(448, 162);
            this.codPessoaTextBox1.Name = "codPessoaTextBox1";
            this.codPessoaTextBox1.ReadOnly = true;
            this.codPessoaTextBox1.Size = new System.Drawing.Size(125, 20);
            this.codPessoaTextBox1.TabIndex = 15;
            this.codPessoaTextBox1.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(489, 290);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(84, 23);
            this.btnCancelar.TabIndex = 24;
            this.btnCancelar.Text = "Esc - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(406, 290);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 23);
            this.btnExcluir.TabIndex = 23;
            this.btnExcluir.Text = "F5 - Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // pessoaBindingSource
            // 
            this.pessoaBindingSource.DataSource = typeof(Dominio.Pessoa);
            // 
            // pessoaBindingSource1
            // 
            this.pessoaBindingSource1.DataSource = typeof(Dominio.Pessoa);
            // 
            // cpfCnpjLabel
            // 
            cpfCnpjLabel.AutoSize = true;
            cpfCnpjLabel.Location = new System.Drawing.Point(13, 50);
            cpfCnpjLabel.Name = "cpfCnpjLabel";
            cpfCnpjLabel.Size = new System.Drawing.Size(50, 13);
            cpfCnpjLabel.TabIndex = 24;
            cpfCnpjLabel.Text = "Cpf Cnpj:";
            // 
            // cpfCnpjTextBox
            // 
            this.cpfCnpjTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pessoaBindingSource, "CpfCnpj", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cpfCnpjTextBox.Location = new System.Drawing.Point(12, 65);
            this.cpfCnpjTextBox.Name = "cpfCnpjTextBox";
            this.cpfCnpjTextBox.ReadOnly = true;
            this.cpfCnpjTextBox.Size = new System.Drawing.Size(149, 20);
            this.cpfCnpjTextBox.TabIndex = 25;
            this.cpfCnpjTextBox.TabStop = false;
            // 
            // enderecoLabel
            // 
            enderecoLabel.AutoSize = true;
            enderecoLabel.Location = new System.Drawing.Point(169, 49);
            enderecoLabel.Name = "enderecoLabel";
            enderecoLabel.Size = new System.Drawing.Size(56, 13);
            enderecoLabel.TabIndex = 25;
            enderecoLabel.Text = "Endereco:";
            // 
            // enderecoTextBox
            // 
            this.enderecoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pessoaBindingSource, "Endereco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.enderecoTextBox.Location = new System.Drawing.Point(172, 65);
            this.enderecoTextBox.Name = "enderecoTextBox";
            this.enderecoTextBox.ReadOnly = true;
            this.enderecoTextBox.Size = new System.Drawing.Size(398, 20);
            this.enderecoTextBox.TabIndex = 26;
            this.enderecoTextBox.TabStop = false;
            // 
            // nomeLabel
            // 
            nomeLabel.AutoSize = true;
            nomeLabel.Location = new System.Drawing.Point(171, 97);
            nomeLabel.Name = "nomeLabel";
            nomeLabel.Size = new System.Drawing.Size(38, 13);
            nomeLabel.TabIndex = 26;
            nomeLabel.Text = "Nome:";
            // 
            // nomeTextBox
            // 
            this.nomeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pessoaBindingSource, "Nome", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nomeTextBox.Location = new System.Drawing.Point(172, 116);
            this.nomeTextBox.Name = "nomeTextBox";
            this.nomeTextBox.ReadOnly = true;
            this.nomeTextBox.Size = new System.Drawing.Size(398, 20);
            this.nomeTextBox.TabIndex = 27;
            this.nomeTextBox.TabStop = false;
            // 
            // ieLabel
            // 
            ieLabel.AutoSize = true;
            ieLabel.Location = new System.Drawing.Point(13, 94);
            ieLabel.Name = "ieLabel";
            ieLabel.Size = new System.Drawing.Size(19, 13);
            ieLabel.TabIndex = 27;
            ieLabel.Text = "Ie:";
            // 
            // ieTextBox
            // 
            this.ieTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pessoaBindingSource, "Ie", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ieTextBox.Location = new System.Drawing.Point(12, 116);
            this.ieTextBox.Name = "ieTextBox";
            this.ieTextBox.ReadOnly = true;
            this.ieTextBox.Size = new System.Drawing.Size(149, 20);
            this.ieTextBox.TabIndex = 28;
            this.ieTextBox.TabStop = false;
            // 
            // cpfCnpjLabel1
            // 
            cpfCnpjLabel1.AutoSize = true;
            cpfCnpjLabel1.Location = new System.Drawing.Point(13, 192);
            cpfCnpjLabel1.Name = "cpfCnpjLabel1";
            cpfCnpjLabel1.Size = new System.Drawing.Size(50, 13);
            cpfCnpjLabel1.TabIndex = 28;
            cpfCnpjLabel1.Text = "Cpf Cnpj:";
            // 
            // cpfCnpjTextBox1
            // 
            this.cpfCnpjTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pessoaBindingSource1, "CpfCnpj", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cpfCnpjTextBox1.Location = new System.Drawing.Point(12, 208);
            this.cpfCnpjTextBox1.Name = "cpfCnpjTextBox1";
            this.cpfCnpjTextBox1.ReadOnly = true;
            this.cpfCnpjTextBox1.Size = new System.Drawing.Size(149, 20);
            this.cpfCnpjTextBox1.TabIndex = 29;
            this.cpfCnpjTextBox1.TabStop = false;
            // 
            // enderecoLabel1
            // 
            enderecoLabel1.AutoSize = true;
            enderecoLabel1.Location = new System.Drawing.Point(171, 192);
            enderecoLabel1.Name = "enderecoLabel1";
            enderecoLabel1.Size = new System.Drawing.Size(56, 13);
            enderecoLabel1.TabIndex = 29;
            enderecoLabel1.Text = "Endereco:";
            // 
            // enderecoTextBox1
            // 
            this.enderecoTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pessoaBindingSource1, "Endereco", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.enderecoTextBox1.Location = new System.Drawing.Point(174, 208);
            this.enderecoTextBox1.Name = "enderecoTextBox1";
            this.enderecoTextBox1.ReadOnly = true;
            this.enderecoTextBox1.Size = new System.Drawing.Size(396, 20);
            this.enderecoTextBox1.TabIndex = 30;
            this.enderecoTextBox1.TabStop = false;
            // 
            // ieLabel1
            // 
            ieLabel1.AutoSize = true;
            ieLabel1.Location = new System.Drawing.Point(13, 236);
            ieLabel1.Name = "ieLabel1";
            ieLabel1.Size = new System.Drawing.Size(19, 13);
            ieLabel1.TabIndex = 30;
            ieLabel1.Text = "Ie:";
            // 
            // ieTextBox1
            // 
            this.ieTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pessoaBindingSource1, "Ie", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ieTextBox1.Location = new System.Drawing.Point(12, 252);
            this.ieTextBox1.Name = "ieTextBox1";
            this.ieTextBox1.ReadOnly = true;
            this.ieTextBox1.Size = new System.Drawing.Size(149, 20);
            this.ieTextBox1.TabIndex = 31;
            this.ieTextBox1.TabStop = false;
            // 
            // nomeLabel1
            // 
            nomeLabel1.AutoSize = true;
            nomeLabel1.Location = new System.Drawing.Point(171, 236);
            nomeLabel1.Name = "nomeLabel1";
            nomeLabel1.Size = new System.Drawing.Size(38, 13);
            nomeLabel1.TabIndex = 31;
            nomeLabel1.Text = "Nome:";
            // 
            // nomeTextBox1
            // 
            this.nomeTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pessoaBindingSource1, "Nome", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nomeTextBox1.Location = new System.Drawing.Point(172, 252);
            this.nomeTextBox1.Name = "nomeTextBox1";
            this.nomeTextBox1.ReadOnly = true;
            this.nomeTextBox1.Size = new System.Drawing.Size(398, 20);
            this.nomeTextBox1.TabIndex = 32;
            this.nomeTextBox1.TabStop = false;
            // 
            // FrmPessoaExcluir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 317);
            this.Controls.Add(nomeLabel1);
            this.Controls.Add(this.nomeTextBox1);
            this.Controls.Add(ieLabel1);
            this.Controls.Add(this.ieTextBox1);
            this.Controls.Add(enderecoLabel1);
            this.Controls.Add(this.enderecoTextBox1);
            this.Controls.Add(cpfCnpjLabel1);
            this.Controls.Add(this.cpfCnpjTextBox1);
            this.Controls.Add(ieLabel);
            this.Controls.Add(this.ieTextBox);
            this.Controls.Add(nomeLabel);
            this.Controls.Add(this.nomeTextBox);
            this.Controls.Add(enderecoLabel);
            this.Controls.Add(this.enderecoTextBox);
            this.Controls.Add(cpfCnpjLabel);
            this.Controls.Add(this.cpfCnpjTextBox);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.codPessoaLabel2);
            this.Controls.Add(this.codPessoaTextBox1);
            this.Controls.Add(this.codPessoaComboBox1);
            this.Controls.Add(this.codPessoaTextBox);
            this.Controls.Add(this.codPessoaLabel1);
            this.Controls.Add(label1);
            this.Controls.Add(this.codPessoaLabel);
            this.Controls.Add(this.codPessoaComboBox);
            this.KeyPreview = true;
            this.Name = "FrmPessoaExcluir";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Exclusão/Merge de Pessoas";
            this.Load += new System.EventHandler(this.FrmPessoaExcluir_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPessoaExcluir_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pessoaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pessoaBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox codPessoaComboBox;
        private System.Windows.Forms.TextBox codPessoaTextBox;
        private System.Windows.Forms.ComboBox codPessoaComboBox1;
        private System.Windows.Forms.TextBox codPessoaTextBox1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Label codPessoaLabel;
        private System.Windows.Forms.Label codPessoaLabel1;
        private System.Windows.Forms.Label codPessoaLabel2;
        private System.Windows.Forms.BindingSource pessoaBindingSource;
        private System.Windows.Forms.BindingSource pessoaBindingSource1;
        private System.Windows.Forms.TextBox cpfCnpjTextBox;
        private System.Windows.Forms.TextBox enderecoTextBox;
        private System.Windows.Forms.TextBox nomeTextBox;
        private System.Windows.Forms.TextBox ieTextBox;
        private System.Windows.Forms.TextBox cpfCnpjTextBox1;
        private System.Windows.Forms.TextBox enderecoTextBox1;
        private System.Windows.Forms.TextBox ieTextBox1;
        private System.Windows.Forms.TextBox nomeTextBox1;
    }
}