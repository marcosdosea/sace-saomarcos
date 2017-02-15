namespace Cartao
{
    partial class FrmProcessarCartao
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
            this.btnProcessar = new System.Windows.Forms.Button();
            this.lblParcelas = new System.Windows.Forms.Button();
            this.pictureBanese = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureHipercard = new System.Windows.Forms.PictureBox();
            this.pictureElo = new System.Windows.Forms.PictureBox();
            this.pictureMastercard = new System.Windows.Forms.PictureBox();
            this.pictureVisa = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblOperacao = new System.Windows.Forms.Label();
            this.lblCodPedido = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblAutorizacao = new System.Windows.Forms.Label();
            this.lblNumeroCartoes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBanese)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHipercard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureElo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMastercard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureVisa)).BeginInit();
            this.SuspendLayout();
            // 
            // btnProcessar
            // 
            this.btnProcessar.Location = new System.Drawing.Point(492, 363);
            this.btnProcessar.Name = "btnProcessar";
            this.btnProcessar.Size = new System.Drawing.Size(97, 27);
            this.btnProcessar.TabIndex = 27;
            this.btnProcessar.Tag = "";
            this.btnProcessar.Text = "F6 - Salvar";
            this.btnProcessar.UseVisualStyleBackColor = true;
            this.btnProcessar.Click += new System.EventHandler(this.btnProcessar_Click);
            // 
            // lblParcelas
            // 
            this.lblParcelas.Location = new System.Drawing.Point(593, 363);
            this.lblParcelas.Name = "lblParcelas";
            this.lblParcelas.Size = new System.Drawing.Size(97, 27);
            this.lblParcelas.TabIndex = 28;
            this.lblParcelas.Tag = "";
            this.lblParcelas.Text = "ESC - Cancelar";
            this.lblParcelas.UseVisualStyleBackColor = true;
            // 
            // pictureBanese
            // 
            this.pictureBanese.Image = global::Cartao.Mensagens.banese;
            this.pictureBanese.Location = new System.Drawing.Point(1, -1);
            this.pictureBanese.Name = "pictureBanese";
            this.pictureBanese.Size = new System.Drawing.Size(688, 149);
            this.pictureBanese.TabIndex = 29;
            this.pictureBanese.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(25, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(557, 181);
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // pictureHipercard
            // 
            this.pictureHipercard.Image = global::Cartao.Mensagens.hipercard3;
            this.pictureHipercard.Location = new System.Drawing.Point(1, -1);
            this.pictureHipercard.Name = "pictureHipercard";
            this.pictureHipercard.Size = new System.Drawing.Size(534, 215);
            this.pictureHipercard.TabIndex = 30;
            this.pictureHipercard.TabStop = false;
            // 
            // pictureElo
            // 
            this.pictureElo.Image = global::Cartao.Mensagens.elo;
            this.pictureElo.Location = new System.Drawing.Point(1, -1);
            this.pictureElo.Name = "pictureElo";
            this.pictureElo.Size = new System.Drawing.Size(366, 203);
            this.pictureElo.TabIndex = 31;
            this.pictureElo.TabStop = false;
            // 
            // pictureMastercard
            // 
            this.pictureMastercard.Image = global::Cartao.Mensagens.mastercard;
            this.pictureMastercard.Location = new System.Drawing.Point(1, -53);
            this.pictureMastercard.Name = "pictureMastercard";
            this.pictureMastercard.Size = new System.Drawing.Size(634, 299);
            this.pictureMastercard.TabIndex = 32;
            this.pictureMastercard.TabStop = false;
            // 
            // pictureVisa
            // 
            this.pictureVisa.Image = global::Cartao.Mensagens.visa;
            this.pictureVisa.Location = new System.Drawing.Point(1, -1);
            this.pictureVisa.Name = "pictureVisa";
            this.pictureVisa.Size = new System.Drawing.Size(680, 215);
            this.pictureVisa.TabIndex = 33;
            this.pictureVisa.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(263, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 24);
            this.label2.TabIndex = 35;
            this.label2.Text = "Pedido: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 24);
            this.label3.TabIndex = 36;
            this.label3.Text = "Operação: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(461, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 24);
            this.label4.TabIndex = 37;
            this.label4.Text = "Número Cartões: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 311);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 24);
            this.label1.TabIndex = 38;
            this.label1.Text = "Valor R$: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(263, 314);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 24);
            this.label5.TabIndex = 39;
            this.label5.Text = "Parcelas: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(461, 311);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 24);
            this.label6.TabIndex = 40;
            this.label6.Text = "Autorização: ";
            // 
            // lblOperacao
            // 
            this.lblOperacao.AutoSize = true;
            this.lblOperacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOperacao.ForeColor = System.Drawing.Color.Red;
            this.lblOperacao.Location = new System.Drawing.Point(117, 263);
            this.lblOperacao.Name = "lblOperacao";
            this.lblOperacao.Size = new System.Drawing.Size(100, 24);
            this.lblOperacao.TabIndex = 41;
            this.lblOperacao.Text = "CRÉDITO";
            // 
            // lblCodPedido
            // 
            this.lblCodPedido.AutoSize = true;
            this.lblCodPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodPedido.ForeColor = System.Drawing.Color.Red;
            this.lblCodPedido.Location = new System.Drawing.Point(346, 263);
            this.lblCodPedido.Name = "lblCodPedido";
            this.lblCodPedido.Size = new System.Drawing.Size(98, 24);
            this.lblCodPedido.TabIndex = 42;
            this.lblCodPedido.Text = "77777777";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.ForeColor = System.Drawing.Color.Red;
            this.lblValor.Location = new System.Drawing.Point(120, 311);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(93, 24);
            this.lblValor.TabIndex = 43;
            this.lblValor.Text = "10000,00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(361, 311);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 24);
            this.label7.TabIndex = 44;
            this.label7.Text = "06";
            // 
            // lblAutorizacao
            // 
            this.lblAutorizacao.AutoSize = true;
            this.lblAutorizacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAutorizacao.ForeColor = System.Drawing.Color.Red;
            this.lblAutorizacao.Location = new System.Drawing.Point(589, 311);
            this.lblAutorizacao.Name = "lblAutorizacao";
            this.lblAutorizacao.Size = new System.Drawing.Size(87, 24);
            this.lblAutorizacao.TabIndex = 45;
            this.lblAutorizacao.Text = "9999999";
            // 
            // lblNumeroCartoes
            // 
            this.lblNumeroCartoes.AutoSize = true;
            this.lblNumeroCartoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumeroCartoes.ForeColor = System.Drawing.Color.Red;
            this.lblNumeroCartoes.Location = new System.Drawing.Point(625, 263);
            this.lblNumeroCartoes.Name = "lblNumeroCartoes";
            this.lblNumeroCartoes.Size = new System.Drawing.Size(60, 24);
            this.lblNumeroCartoes.TabIndex = 46;
            this.lblNumeroCartoes.Text = "01/01";
            // 
            // FrmProcessarCartao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 393);
            this.Controls.Add(this.lblNumeroCartoes);
            this.Controls.Add(this.lblAutorizacao);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.lblCodPedido);
            this.Controls.Add(this.lblOperacao);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureElo);
            this.Controls.Add(this.pictureHipercard);
            this.Controls.Add(this.pictureBanese);
            this.Controls.Add(this.lblParcelas);
            this.Controls.Add(this.btnProcessar);
            this.Controls.Add(this.pictureMastercard);
            this.Controls.Add(this.pictureVisa);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "FrmProcessarCartao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Processar Pagamento de Cartões de Crédito";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBanese)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHipercard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureElo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMastercard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureVisa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcessar;
        private System.Windows.Forms.Button lblParcelas;
        private System.Windows.Forms.PictureBox pictureBanese;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureHipercard;
        private System.Windows.Forms.PictureBox pictureElo;
        private System.Windows.Forms.PictureBox pictureMastercard;
        private System.Windows.Forms.PictureBox pictureVisa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblOperacao;
        private System.Windows.Forms.Label lblCodPedido;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblAutorizacao;
        private System.Windows.Forms.Label lblNumeroCartoes;
    }
}