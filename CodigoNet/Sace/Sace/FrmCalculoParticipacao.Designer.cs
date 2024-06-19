namespace Sace
{
    partial class FrmCalculoParticipacao
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
            this.btnCalcular = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dateTimeInicial = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimeFinal = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.textFuncionarios = new System.Windows.Forms.TextBox();
            this.textValorVenda = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textValorCalculado = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textAvaliacaoClientes = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textMetaVendas = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCalcular
            // 
            this.btnCalcular.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcular.Location = new System.Drawing.Point(271, 102);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(121, 29);
            this.btnCalcular.TabIndex = 2;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(394, 102);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(103, 29);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // dateTimeInicial
            // 
            this.dateTimeInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeInicial.Location = new System.Drawing.Point(12, 22);
            this.dateTimeInicial.Name = "dateTimeInicial";
            this.dateTimeInicial.Size = new System.Drawing.Size(92, 20);
            this.dateTimeInicial.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Data Inicial";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(129, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Data Final";
            // 
            // dateTimeFinal
            // 
            this.dateTimeFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeFinal.Location = new System.Drawing.Point(129, 22);
            this.dateTimeFinal.Name = "dateTimeFinal";
            this.dateTimeFinal.Size = new System.Drawing.Size(92, 20);
            this.dateTimeFinal.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(239, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Número Funcionários:";
            // 
            // textFuncionarios
            // 
            this.textFuncionarios.Location = new System.Drawing.Point(242, 22);
            this.textFuncionarios.Name = "textFuncionarios";
            this.textFuncionarios.Size = new System.Drawing.Size(100, 20);
            this.textFuncionarios.TabIndex = 10;
            this.textFuncionarios.Text = "5";
            // 
            // textValorVenda
            // 
            this.textValorVenda.Location = new System.Drawing.Point(360, 22);
            this.textValorVenda.Name = "textValorVenda";
            this.textValorVenda.Size = new System.Drawing.Size(132, 20);
            this.textValorVenda.TabIndex = 12;
            this.textValorVenda.Text = "20";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(357, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Valor da Venda >= :";
            // 
            // textValorCalculado
            // 
            this.textValorCalculado.Location = new System.Drawing.Point(360, 76);
            this.textValorCalculado.Name = "textValorCalculado";
            this.textValorCalculado.Size = new System.Drawing.Size(137, 20);
            this.textValorCalculado.TabIndex = 14;
            this.textValorCalculado.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(357, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Valor Calculado:";
            // 
            // textAvaliacaoClientes
            // 
            this.textAvaliacaoClientes.Location = new System.Drawing.Point(15, 76);
            this.textAvaliacaoClientes.Name = "textAvaliacaoClientes";
            this.textAvaliacaoClientes.Size = new System.Drawing.Size(150, 20);
            this.textAvaliacaoClientes.TabIndex = 16;
            this.textAvaliacaoClientes.Text = "5";
            this.textAvaliacaoClientes.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Avaliação Media Clientes (0-5):";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // textMetaVendas
            // 
            this.textMetaVendas.Location = new System.Drawing.Point(192, 76);
            this.textMetaVendas.Name = "textMetaVendas";
            this.textMetaVendas.Size = new System.Drawing.Size(150, 20);
            this.textMetaVendas.TabIndex = 18;
            this.textMetaVendas.Text = "100";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(189, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Meta de Vendas (0-100):";
            // 
            // FrmCalculoParticipacao
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Alert;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 136);
            this.Controls.Add(this.textMetaVendas);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textAvaliacaoClientes);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textValorCalculado);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textValorVenda);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textFuncionarios);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimeFinal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimeInicial);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnCalcular);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmCalculoParticipacao";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cálculo Participação Funcionários";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DateTimePicker dateTimeInicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimeFinal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textFuncionarios;
        private System.Windows.Forms.TextBox textValorVenda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textValorCalculado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textAvaliacaoClientes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textMetaVendas;
        private System.Windows.Forms.Label label7;
    }
}