namespace Telas.Relatorios
{
    partial class FrmFiltroRelatorioProduto
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
            System.Windows.Forms.BindingSource pessoaBindingSource;
            System.Windows.Forms.Label codPessoaLabel;
            this.codPessoaComboBox = new System.Windows.Forms.ComboBox();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lucroTextBox = new System.Windows.Forms.TextBox();
            pessoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            codPessoaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(pessoaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pessoaBindingSource
            // 
            pessoaBindingSource.AllowNew = false;
            pessoaBindingSource.DataSource = typeof(Dominio.Pessoa);
            pessoaBindingSource.CurrentChanged += new System.EventHandler(this.pessoaBindingSource_CurrentChanged);
            // 
            // codPessoaLabel
            // 
            codPessoaLabel.AutoSize = true;
            codPessoaLabel.Location = new System.Drawing.Point(12, 9);
            codPessoaLabel.Name = "codPessoaLabel";
            codPessoaLabel.Size = new System.Drawing.Size(64, 13);
            codPessoaLabel.TabIndex = 1;
            codPessoaLabel.Text = "Fornecedor:";
            // 
            // codPessoaComboBox
            // 
            this.codPessoaComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.codPessoaComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.codPessoaComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", pessoaBindingSource, "CodPessoa", true));
            this.codPessoaComboBox.DataSource = pessoaBindingSource;
            this.codPessoaComboBox.DisplayMember = "Nome";
            this.codPessoaComboBox.FormattingEnabled = true;
            this.codPessoaComboBox.Location = new System.Drawing.Point(12, 25);
            this.codPessoaComboBox.Name = "codPessoaComboBox";
            this.codPessoaComboBox.Size = new System.Drawing.Size(459, 21);
            this.codPessoaComboBox.TabIndex = 2;
            this.codPessoaComboBox.ValueMember = "CodPessoa";
            this.codPessoaComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.codPessoaComboBox_KeyPress);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(343, 52);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(93, 23);
            this.btnImprimir.TabIndex = 5;
            this.btnImprimir.Text = "F8-Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(442, 52);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(88, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "ESC-Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(476, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Lucro (%):";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lucroTextBox
            // 
            this.lucroTextBox.Location = new System.Drawing.Point(479, 25);
            this.lucroTextBox.Name = "lucroTextBox";
            this.lucroTextBox.Size = new System.Drawing.Size(51, 20);
            this.lucroTextBox.TabIndex = 3;
            this.lucroTextBox.Text = "15";
            // 
            // FrmFiltroRelatorioProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 82);
            this.Controls.Add(this.lucroTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(codPessoaLabel);
            this.Controls.Add(this.codPessoaComboBox);
            this.KeyPreview = true;
            this.Name = "FrmFiltroRelatorioProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Relatório Produtos para Revenda";
            this.Load += new System.EventHandler(this.FrmFiltroRelatorioProduto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmFiltroRelatorioProduto_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(pessoaBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox codPessoaComboBox;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox lucroTextBox;
    }
}