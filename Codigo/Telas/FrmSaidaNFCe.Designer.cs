namespace Telas
{
    partial class FrmSaidaNFCe
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
            this.progressBarEnvio = new System.Windows.Forms.ProgressBar();
            this.lblEnvio = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.timerAtualizaNFCe = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // progressBarEnvio
            // 
            this.progressBarEnvio.Location = new System.Drawing.Point(12, 45);
            this.progressBarEnvio.Name = "progressBarEnvio";
            this.progressBarEnvio.Size = new System.Drawing.Size(392, 33);
            this.progressBarEnvio.TabIndex = 0;
            // 
            // lblEnvio
            // 
            this.lblEnvio.AutoSize = true;
            this.lblEnvio.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnvio.Location = new System.Drawing.Point(12, 19);
            this.lblEnvio.Name = "lblEnvio";
            this.lblEnvio.Size = new System.Drawing.Size(237, 20);
            this.lblEnvio.TabIndex = 1;
            this.lblEnvio.Text = "Enviando NFC-e. Aguarde... ";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(244, 89);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(325, 89);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // timerAtualizaNFCe
            // 
            this.timerAtualizaNFCe.Enabled = true;
            this.timerAtualizaNFCe.Interval = 200;
            this.timerAtualizaNFCe.Tick += new System.EventHandler(this.timerAtualizaNFCe_Tick);
            // 
            // FrmSaidaNFCe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 117);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblEnvio);
            this.Controls.Add(this.progressBarEnvio);
            this.Name = "FrmSaidaNFCe";
            this.Text = "Envio de NFC-e";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBarEnvio;
        private System.Windows.Forms.Label lblEnvio;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Timer timerAtualizaNFCe;
    }
}