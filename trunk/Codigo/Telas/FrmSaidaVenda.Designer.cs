namespace Telas
{
    partial class FrmSaidaVenda
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
            System.Windows.Forms.Label observacaoLabel;
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.observacaoTextBox = new System.Windows.Forms.TextBox();
            observacaoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // observacaoLabel
            // 
            observacaoLabel.AutoSize = true;
            observacaoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            observacaoLabel.Location = new System.Drawing.Point(0, 9);
            observacaoLabel.Name = "observacaoLabel";
            observacaoLabel.Size = new System.Drawing.Size(93, 18);
            observacaoLabel.TabIndex = 5;
            observacaoLabel.Text = "Observacao:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnImprimir.Location = new System.Drawing.Point(181, 143);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(92, 26);
            this.btnImprimir.TabIndex = 3;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCancelar.Location = new System.Drawing.Point(277, 143);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 26);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // observacaoTextBox
            // 
            this.observacaoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.observacaoTextBox.Location = new System.Drawing.Point(116, 12);
            this.observacaoTextBox.MaxLength = 165;
            this.observacaoTextBox.Multiline = true;
            this.observacaoTextBox.Name = "observacaoTextBox";
            this.observacaoTextBox.Size = new System.Drawing.Size(244, 125);
            this.observacaoTextBox.TabIndex = 2;
            // 
            // FrmSaidaVenda
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Alert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 171);
            this.ControlBox = false;
            this.Controls.Add(observacaoLabel);
            this.Controls.Add(this.observacaoTextBox);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnImprimir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmSaidaVenda";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Emissão da NF";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSaidaNF_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox observacaoTextBox;
    }
}