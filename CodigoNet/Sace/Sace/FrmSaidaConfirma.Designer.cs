namespace Sace
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
            label1 = new Label();
            btnPreVenda = new Button();
            btnOrcamento = new Button();
            btnCancelar = new Button();
            label2 = new Label();
            trocoTextBox = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 13.25F);
            label1.Location = new Point(2, 121);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(264, 22);
            label1.TabIndex = 0;
            label1.Text = "Como Deseja Gravar o Pedido?";
            // 
            // btnPreVenda
            // 
            btnPreVenda.FlatAppearance.BorderSize = 3;
            btnPreVenda.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPreVenda.Location = new Point(186, 157);
            btnPreVenda.Margin = new Padding(4, 3, 4, 3);
            btnPreVenda.Name = "btnPreVenda";
            btnPreVenda.Size = new Size(131, 33);
            btnPreVenda.TabIndex = 1;
            btnPreVenda.Text = "Pré-Venda";
            btnPreVenda.UseVisualStyleBackColor = true;
            btnPreVenda.Click += btnPreVenda_Click;
            // 
            // btnOrcamento
            // 
            btnOrcamento.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOrcamento.Location = new Point(318, 157);
            btnOrcamento.Margin = new Padding(4, 3, 4, 3);
            btnOrcamento.Name = "btnOrcamento";
            btnOrcamento.Size = new Size(141, 33);
            btnOrcamento.TabIndex = 2;
            btnOrcamento.Text = "Orçamento";
            btnOrcamento.UseVisualStyleBackColor = true;
            btnOrcamento.Click += btnOrcamento_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(462, 157);
            btnCancelar.Margin = new Padding(4, 3, 4, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(120, 33);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 13.25F);
            label2.Location = new Point(2, 17);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(62, 22);
            label2.TabIndex = 4;
            label2.Text = "Troco:";
            // 
            // trocoTextBox
            // 
            trocoTextBox.BackColor = Color.White;
            trocoTextBox.Font = new Font("Microsoft Sans Serif", 24.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            trocoTextBox.ForeColor = Color.Red;
            trocoTextBox.Location = new Point(7, 46);
            trocoTextBox.Margin = new Padding(4, 3, 4, 3);
            trocoTextBox.Name = "trocoTextBox";
            trocoTextBox.ReadOnly = true;
            trocoTextBox.Size = new Size(566, 45);
            trocoTextBox.TabIndex = 11;
            trocoTextBox.TabStop = false;
            trocoTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // FrmSaidaConfirma
            // 
            AccessibleRole = AccessibleRole.Alert;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(597, 246);
            ControlBox = false;
            Controls.Add(trocoTextBox);
            Controls.Add(label2);
            Controls.Add(btnCancelar);
            Controls.Add(btnOrcamento);
            Controls.Add(btnPreVenda);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "FrmSaidaConfirma";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Finalizar Orçamento / Pré-Venda";
            KeyDown += FrmSaidaConfirma_KeyDown;
            ResumeLayout(false);
            PerformLayout();
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