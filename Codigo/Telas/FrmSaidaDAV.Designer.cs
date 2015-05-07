namespace Telas
{
    partial class FrmSaidaDAV
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
            this.btnNotmal = new System.Windows.Forms.Button();
            this.btnReduzido = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F);
            this.label1.Location = new System.Drawing.Point(4, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Confirma Emissão do DAV?";
            // 
            // btnNotmal
            // 
            this.btnNotmal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnNotmal.Location = new System.Drawing.Point(8, 73);
            this.btnNotmal.Name = "btnNotmal";
            this.btnNotmal.Size = new System.Drawing.Size(92, 26);
            this.btnNotmal.TabIndex = 1;
            this.btnNotmal.Text = "Normal";
            this.btnNotmal.UseVisualStyleBackColor = true;
            this.btnNotmal.Click += new System.EventHandler(this.btnNotmal_Click);
            // 
            // btnReduzido
            // 
            this.btnReduzido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnReduzido.Location = new System.Drawing.Point(102, 73);
            this.btnReduzido.Name = "btnReduzido";
            this.btnReduzido.Size = new System.Drawing.Size(101, 26);
            this.btnReduzido.TabIndex = 2;
            this.btnReduzido.Text = "Reduzido";
            this.btnReduzido.UseVisualStyleBackColor = true;
            this.btnReduzido.Click += new System.EventHandler(this.btnReduzido_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCancelar.Location = new System.Drawing.Point(205, 73);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 26);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmSaidaDAV
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Alert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 102);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnReduzido);
            this.Controls.Add(this.btnNotmal);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmSaidaDAV";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Confirma Emissão do DAV";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSaidaDAV_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNotmal;
        private System.Windows.Forms.Button btnReduzido;
        private System.Windows.Forms.Button btnCancelar;
    }
}