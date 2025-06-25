namespace Sace
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
            label1 = new Label();
            btnNotmal = new Button();
            btnReduzido = new Button();
            btnCancelar = new Button();
            btnReduzido2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 13.25F);
            label1.Location = new Point(5, 31);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(232, 22);
            label1.TabIndex = 0;
            label1.Text = "Confirma Emissão do DAV?";
            // 
            // btnNotmal
            // 
            btnNotmal.Font = new Font("Microsoft Sans Serif", 10F);
            btnNotmal.Location = new Point(9, 84);
            btnNotmal.Margin = new Padding(4, 3, 4, 3);
            btnNotmal.Name = "btnNotmal";
            btnNotmal.Size = new Size(107, 30);
            btnNotmal.TabIndex = 1;
            btnNotmal.Text = "Normal";
            btnNotmal.UseVisualStyleBackColor = true;
            btnNotmal.Click += btnNotmal_Click;
            // 
            // btnReduzido
            // 
            btnReduzido.Font = new Font("Microsoft Sans Serif", 10F);
            btnReduzido.Location = new Point(119, 84);
            btnReduzido.Margin = new Padding(4, 3, 4, 3);
            btnReduzido.Name = "btnReduzido";
            btnReduzido.Size = new Size(118, 30);
            btnReduzido.TabIndex = 2;
            btnReduzido.Text = "Reduzido";
            btnReduzido.UseVisualStyleBackColor = true;
            btnReduzido.Click += btnReduzido_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Microsoft Sans Serif", 10F);
            btnCancelar.Location = new Point(355, 84);
            btnCancelar.Margin = new Padding(4, 3, 4, 3);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(97, 30);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnReduzido2
            // 
            btnReduzido2.Font = new Font("Microsoft Sans Serif", 10F);
            btnReduzido2.Location = new Point(237, 84);
            btnReduzido2.Margin = new Padding(4, 3, 4, 3);
            btnReduzido2.Name = "btnReduzido2";
            btnReduzido2.Size = new Size(118, 30);
            btnReduzido2.TabIndex = 3;
            btnReduzido2.Text = "Reduzido 2";
            btnReduzido2.UseVisualStyleBackColor = true;
            btnReduzido2.Click += btnReduzido2_Click;
            // 
            // FrmSaidaDAV
            // 
            AccessibleRole = AccessibleRole.Alert;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(484, 173);
            ControlBox = false;
            Controls.Add(btnReduzido2);
            Controls.Add(btnCancelar);
            Controls.Add(btnReduzido);
            Controls.Add(btnNotmal);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "FrmSaidaDAV";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Confirma Emissão do DAV";
            KeyDown += FrmSaidaDAV_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNotmal;
        private System.Windows.Forms.Button btnReduzido;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnReduzido2;
    }
}