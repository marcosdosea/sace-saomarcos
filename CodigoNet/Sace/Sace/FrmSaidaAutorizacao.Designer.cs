namespace Sace
{
    partial class FrmSaidaAutorizacao
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
            this.lblCartao = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.timerAtualizaNFCe = new System.Windows.Forms.Timer(this.components);
            this.textCartao = new System.Windows.Forms.RichTextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textNfe = new System.Windows.Forms.RichTextBox();
            this.lblNffe = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCartao
            // 
            this.lblCartao.AutoSize = true;
            this.lblCartao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCartao.Location = new System.Drawing.Point(15, 180);
            this.lblCartao.Name = "lblCartao";
            this.lblCartao.Size = new System.Drawing.Size(287, 20);
            this.lblCartao.TabIndex = 1;
            this.lblCartao.Text = "Aguardando Autorização Cartão... ";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Enabled = false;
            this.btnCancelar.Location = new System.Drawing.Point(436, 333);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "ESC - Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // timerAtualizaNFCe
            // 
            this.timerAtualizaNFCe.Enabled = true;
            this.timerAtualizaNFCe.Interval = 200;
            this.timerAtualizaNFCe.Tick += new System.EventHandler(this.timerAtualizaNFCe_Tick);
            // 
            // textCartao
            // 
            this.textCartao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCartao.Location = new System.Drawing.Point(16, 203);
            this.textCartao.Name = "textCartao";
            this.textCartao.ReadOnly = true;
            this.textCartao.Size = new System.Drawing.Size(355, 115);
            this.textCartao.TabIndex = 5;
            this.textCartao.Text = "";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image =  global::Sace.Properties.Resources.nfe_150x150;
            this.pictureBox2.Location = new System.Drawing.Point(375, 38);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(152, 135);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Sace.Properties.Resources.credit_cards_icon_150x150;
            this.pictureBox1.Location = new System.Drawing.Point(381, 203);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(141, 115);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // textNfe
            // 
            this.textNfe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNfe.Location = new System.Drawing.Point(16, 38);
            this.textNfe.Name = "textNfe";
            this.textNfe.ReadOnly = true;
            this.textNfe.Size = new System.Drawing.Size(355, 135);
            this.textNfe.TabIndex = 7;
            this.textNfe.Text = "";
            // 
            // lblNffe
            // 
            this.lblNffe.AutoSize = true;
            this.lblNffe.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblNffe.Location = new System.Drawing.Point(12, 8);
            this.lblNffe.Name = "lblNffe";
            this.lblNffe.Size = new System.Drawing.Size(291, 26);
            this.lblNffe.TabIndex = 8;
            this.lblNffe.Text = "Solicitando Autorização... ";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Enabled = false;
            this.btnImprimir.Location = new System.Drawing.Point(339, 333);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(91, 23);
            this.btnImprimir.TabIndex = 2;
            this.btnImprimir.Text = "F8 - Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // FrmSaidaAutorizacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 360);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.lblNffe);
            this.Controls.Add(this.textNfe);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.textCartao);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblCartao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmSaidaAutorizacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autorização Cartão Crédito / NFC-e";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSaidaAutorizacao_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCartao;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Timer timerAtualizaNFCe;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox textCartao;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RichTextBox textNfe;
        private System.Windows.Forms.Label lblNffe;
        private System.Windows.Forms.Button btnImprimir;
    }
}