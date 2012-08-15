namespace Telas
{
    partial class FrmSaidaConfirma
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnPreVenda = new System.Windows.Forms.Button();
            this.btnOrcamento = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.trocoTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.label1.Location = new System.Drawing.Point(2, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Como Deseja Gravar o Pedido?";
            // 
            // btnPreVenda
            // 
            this.btnPreVenda.FlatAppearance.BorderSize = 3;
            this.btnPreVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreVenda.Location = new System.Drawing.Point(28, 137);
            this.btnPreVenda.Name = "btnPreVenda";
            this.btnPreVenda.Size = new System.Drawing.Size(112, 29);
            this.btnPreVenda.TabIndex = 1;
            this.btnPreVenda.Text = "Pré-Venda";
            this.btnPreVenda.UseVisualStyleBackColor = true;
            this.btnPreVenda.Click += new System.EventHandler(this.btnPreVenda_Click);
            // 
            // btnOrcamento
            // 
            this.btnOrcamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOrcamento.Location = new System.Drawing.Point(146, 137);
            this.btnOrcamento.Name = "btnOrcamento";
            this.btnOrcamento.Size = new System.Drawing.Size(121, 29);
            this.btnOrcamento.TabIndex = 2;
            this.btnOrcamento.Text = "Orçamento";
            this.btnOrcamento.UseVisualStyleBackColor = true;
            this.btnOrcamento.Click += new System.EventHandler(this.btnOrcamento_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(272, 136);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(103, 29);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.label2.Location = new System.Drawing.Point(2, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 22);
            this.label2.TabIndex = 4;
            this.label2.Text = "Troco:";
            // 
            // trocoTextBox
            // 
            this.trocoTextBox.BackColor = System.Drawing.Color.White;
            this.trocoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 24.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trocoTextBox.ForeColor = System.Drawing.Color.Red;
            this.trocoTextBox.Location = new System.Drawing.Point(6, 40);
            this.trocoTextBox.Name = "trocoTextBox";
            this.trocoTextBox.ReadOnly = true;
            this.trocoTextBox.Size = new System.Drawing.Size(357, 45);
            this.trocoTextBox.TabIndex = 11;
            this.trocoTextBox.TabStop = false;
            this.trocoTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FrmSaidaConfirma
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Alert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 171);
            this.ControlBox = false;
            this.Controls.Add(this.trocoTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnOrcamento);
            this.Controls.Add(this.btnPreVenda);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmSaidaConfirma";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Finalizar Orçamento / Pré-Venda";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSaidaConfirma_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPreVenda;
        private System.Windows.Forms.Button btnOrcamento;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox trocoTextBox;
    }
}