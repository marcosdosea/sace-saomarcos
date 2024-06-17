namespace Telas
{
    partial class FrmPontaEstoquePesquisa
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
            System.Windows.Forms.Label codProdutoLabel;
            System.Windows.Forms.Label nomeProdutoLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pontaEstoqueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pontaEstoqueDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codProdutoTextBox = new System.Windows.Forms.TextBox();
            this.nomeProdutoTextBox = new System.Windows.Forms.TextBox();
            this.lblBalcao = new System.Windows.Forms.Label();
            codProdutoLabel = new System.Windows.Forms.Label();
            nomeProdutoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pontaEstoqueBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pontaEstoqueDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // codProdutoLabel
            // 
            codProdutoLabel.AutoSize = true;
            codProdutoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            codProdutoLabel.Location = new System.Drawing.Point(12, 100);
            codProdutoLabel.Name = "codProdutoLabel";
            codProdutoLabel.Size = new System.Drawing.Size(56, 17);
            codProdutoLabel.TabIndex = 1;
            codProdutoLabel.Text = "Código:";
            // 
            // nomeProdutoLabel
            // 
            nomeProdutoLabel.AutoSize = true;
            nomeProdutoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            nomeProdutoLabel.Location = new System.Drawing.Point(108, 100);
            nomeProdutoLabel.Name = "nomeProdutoLabel";
            nomeProdutoLabel.Size = new System.Drawing.Size(62, 17);
            nomeProdutoLabel.TabIndex = 3;
            nomeProdutoLabel.Text = "Produto:";
            // 
            // pontaEstoqueBindingSource
            // 
            this.pontaEstoqueBindingSource.DataSource = typeof(Dominio.PontaEstoque);
            // 
            // pontaEstoqueDataGridView
            // 
            this.pontaEstoqueDataGridView.AllowUserToAddRows = false;
            this.pontaEstoqueDataGridView.AllowUserToDeleteRows = false;
            this.pontaEstoqueDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.pontaEstoqueDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.pontaEstoqueDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pontaEstoqueDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.pontaEstoqueDataGridView.DataSource = this.pontaEstoqueBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.pontaEstoqueDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.pontaEstoqueDataGridView.Location = new System.Drawing.Point(12, 176);
            this.pontaEstoqueDataGridView.Name = "pontaEstoqueDataGridView";
            this.pontaEstoqueDataGridView.ReadOnly = true;
            this.pontaEstoqueDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.pontaEstoqueDataGridView.Size = new System.Drawing.Size(537, 169);
            this.pontaEstoqueDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CodPontaEstoque";
            this.dataGridViewTextBoxColumn1.HeaderText = "CodPontaEstoque";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Quantidade";
            this.dataGridViewTextBoxColumn4.HeaderText = "Quantidade";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Caracteristica";
            this.dataGridViewTextBoxColumn5.HeaderText = "Caracteristica";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // codProdutoTextBox
            // 
            this.codProdutoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pontaEstoqueBindingSource, "CodProduto", true));
            this.codProdutoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codProdutoTextBox.Location = new System.Drawing.Point(12, 120);
            this.codProdutoTextBox.Name = "codProdutoTextBox";
            this.codProdutoTextBox.ReadOnly = true;
            this.codProdutoTextBox.Size = new System.Drawing.Size(73, 23);
            this.codProdutoTextBox.TabIndex = 2;
            this.codProdutoTextBox.TabStop = false;
            // 
            // nomeProdutoTextBox
            // 
            this.nomeProdutoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.pontaEstoqueBindingSource, "NomeProduto", true));
            this.nomeProdutoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomeProdutoTextBox.Location = new System.Drawing.Point(111, 120);
            this.nomeProdutoTextBox.Name = "nomeProdutoTextBox";
            this.nomeProdutoTextBox.ReadOnly = true;
            this.nomeProdutoTextBox.Size = new System.Drawing.Size(433, 23);
            this.nomeProdutoTextBox.TabIndex = 4;
            this.nomeProdutoTextBox.TabStop = false;
            // 
            // lblBalcao
            // 
            this.lblBalcao.AutoSize = true;
            this.lblBalcao.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalcao.ForeColor = System.Drawing.Color.Red;
            this.lblBalcao.Location = new System.Drawing.Point(-1, 9);
            this.lblBalcao.Name = "lblBalcao";
            this.lblBalcao.Size = new System.Drawing.Size(560, 73);
            this.lblBalcao.TabIndex = 0;
            this.lblBalcao.Text = "Ponta de Estoque";
            // 
            // FrmPontaEstoquePesquisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 349);
            this.Controls.Add(this.lblBalcao);
            this.Controls.Add(nomeProdutoLabel);
            this.Controls.Add(this.nomeProdutoTextBox);
            this.Controls.Add(codProdutoLabel);
            this.Controls.Add(this.codProdutoTextBox);
            this.Controls.Add(this.pontaEstoqueDataGridView);
            this.KeyPreview = true;
            this.Name = "FrmPontaEstoquePesquisa";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Selecionar Ponta de Estoque";
            this.Load += new System.EventHandler(this.FrmBancoPesquisa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBancoPesquisa_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pontaEstoqueBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pontaEstoqueDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource pontaEstoqueBindingSource;
        private System.Windows.Forms.DataGridView pontaEstoqueDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.TextBox codProdutoTextBox;
        private System.Windows.Forms.TextBox nomeProdutoTextBox;
        private System.Windows.Forms.Label lblBalcao;


    }
}