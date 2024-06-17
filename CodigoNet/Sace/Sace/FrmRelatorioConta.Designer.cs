namespace Telas
{
    partial class FrmRelatorioConta
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
            this.contasReportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.inicialDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.finalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.codPessoaTextBox = new System.Windows.Forms.MaskedTextBox();
            this.tb_contaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.tb_pessoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saceDataSet = new Dados.saceDataSet();
            this.tb_contaTableAdapter1 = new Dados.saceDataSetTableAdapters.tb_contaTableAdapter();
            this.tableAdapterManager1 = new Dados.saceDataSetTableAdapters.TableAdapterManager();
            this.tb_pessoaTableAdapter1 = new Dados.saceDataSetTableAdapters.tb_pessoaTableAdapter();
            this.saceRelatoriosDataSet = new Dados.saceRelatoriosDataSet();
            this.dt_RelContaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dt_RelContaTableAdapter1 = new Dados.saceRelatoriosDataSetTableAdapters.dt_RelContaTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.abertoRadioButton = new System.Windows.Forms.RadioButton();
            this.quitadoRadioButton = new System.Windows.Forms.RadioButton();
            this.pagarRadioButton = new System.Windows.Forms.RadioButton();
            this.receberRadioButton = new System.Windows.Forms.RadioButton();
            this.todosTipoRadioButton = new System.Windows.Forms.RadioButton();
            this.todosSituacaoRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.tb_contaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_pessoaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceRelatoriosDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_RelContaBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // contasReportViewer
            // 
            this.contasReportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.contasReportViewer.LocalReport.ReportPath = "..\\..\\RelContas.rdlc";
            this.contasReportViewer.Location = new System.Drawing.Point(12, 101);
            this.contasReportViewer.Name = "contasReportViewer";
            this.contasReportViewer.Size = new System.Drawing.Size(732, 371);
            this.contasReportViewer.TabIndex = 0;
            this.contasReportViewer.Visible = false;
            // 
            // inicialDateTimePicker
            // 
            this.inicialDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.inicialDateTimePicker.Location = new System.Drawing.Point(99, 38);
            this.inicialDateTimePicker.Name = "inicialDateTimePicker";
            this.inicialDateTimePicker.Size = new System.Drawing.Size(95, 20);
            this.inicialDateTimePicker.TabIndex = 1;
            // 
            // finalDateTimePicker
            // 
            this.finalDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.finalDateTimePicker.Location = new System.Drawing.Point(99, 66);
            this.finalDateTimePicker.Name = "finalDateTimePicker";
            this.finalDateTimePicker.Size = new System.Drawing.Size(95, 20);
            this.finalDateTimePicker.TabIndex = 2;
            // 
            // codPessoaTextBox
            // 
            this.codPessoaTextBox.Location = new System.Drawing.Point(99, 12);
            this.codPessoaTextBox.Name = "codPessoaTextBox";
            this.codPessoaTextBox.Size = new System.Drawing.Size(100, 20);
            this.codPessoaTextBox.TabIndex = 3;
            // 
            // tb_contaBindingSource
            // 
            this.tb_contaBindingSource.DataMember = "fk_conta_pagar_2";
            this.tb_contaBindingSource.DataSource = this.tb_pessoaBindingSource;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(333, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Gerar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb_pessoaBindingSource
            // 
            this.tb_pessoaBindingSource.DataMember = "tb_pessoa";
            this.tb_pessoaBindingSource.DataSource = this.saceDataSet;
            // 
            // saceDataSet
            // 
            this.saceDataSet.DataSetName = "saceDataSet";
            this.saceDataSet.Prefix = "SACE";
            this.saceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tb_contaTableAdapter1
            // 
            this.tb_contaTableAdapter1.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.tb_bancoTableAdapter = null;
            this.tableAdapterManager1.tb_cartao_creditoTableAdapter = null;
            this.tableAdapterManager1.tb_cfopTableAdapter = null;
            this.tableAdapterManager1.tb_configuracao_sistemaTableAdapter = null;
            this.tableAdapterManager1.tb_conta_bancoTableAdapter = null;
            this.tableAdapterManager1.tb_contaTableAdapter = this.tb_contaTableAdapter1;
            this.tableAdapterManager1.tb_contato_empresaTableAdapter = null;
            this.tableAdapterManager1.tb_entrada_produtoTableAdapter = null;
            this.tableAdapterManager1.tb_entradaTableAdapter = null;
            this.tableAdapterManager1.tb_forma_pagamentoTableAdapter = null;
            this.tableAdapterManager1.tb_funcionalidadeTableAdapter = null;
            this.tableAdapterManager1.tb_grupo_contaTableAdapter = null;
            this.tableAdapterManager1.tb_grupoTableAdapter = null;
            this.tableAdapterManager1.tb_lojaTableAdapter = null;
            this.tableAdapterManager1.tb_movimentacao_contaTableAdapter = null;
            this.tableAdapterManager1.tb_perfil_funcionalidadeTableAdapter = null;
            this.tableAdapterManager1.tb_perfilTableAdapter = null;
            this.tableAdapterManager1.tb_permissaoTableAdapter = null;
            this.tableAdapterManager1.tb_pessoaTableAdapter = this.tb_pessoaTableAdapter1;
            this.tableAdapterManager1.tb_plano_contaTableAdapter = null;
            this.tableAdapterManager1.tb_produtoTableAdapter = null;
            this.tableAdapterManager1.tb_saida_produtoTableAdapter = null;
            this.tableAdapterManager1.tb_saidaTableAdapter = null;
            this.tableAdapterManager1.tb_tipo_movimentacao_contaTableAdapter = null;
            this.tableAdapterManager1.tb_usuarioTableAdapter = null;
            this.tableAdapterManager1.UpdateOrder = Dados.saceDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tb_pessoaTableAdapter1
            // 
            this.tb_pessoaTableAdapter1.ClearBeforeFill = true;
            // 
            // saceRelatoriosDataSet
            // 
            this.saceRelatoriosDataSet.DataSetName = "saceRelatoriosDataSet";
            this.saceRelatoriosDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dt_RelContaBindingSource
            // 
            this.dt_RelContaBindingSource.DataMember = "dt_RelConta";
            this.dt_RelContaBindingSource.DataSource = this.saceRelatoriosDataSet;
            // 
            // dt_RelContaTableAdapter1
            // 
            this.dt_RelContaTableAdapter1.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Código Pessoa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Data Inicial:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Data Final:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.todosTipoRadioButton);
            this.groupBox1.Controls.Add(this.receberRadioButton);
            this.groupBox1.Controls.Add(this.pagarRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(262, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 45);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo Conta";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.todosSituacaoRadioButton);
            this.groupBox2.Controls.Add(this.quitadoRadioButton);
            this.groupBox2.Controls.Add(this.abertoRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(527, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 43);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Situação";
            // 
            // abertoRadioButton
            // 
            this.abertoRadioButton.AutoSize = true;
            this.abertoRadioButton.Location = new System.Drawing.Point(7, 20);
            this.abertoRadioButton.Name = "abertoRadioButton";
            this.abertoRadioButton.Size = new System.Drawing.Size(56, 17);
            this.abertoRadioButton.TabIndex = 0;
            this.abertoRadioButton.Text = "Aberto";
            this.abertoRadioButton.UseVisualStyleBackColor = true;
            // 
            // quitadoRadioButton
            // 
            this.quitadoRadioButton.AutoSize = true;
            this.quitadoRadioButton.Location = new System.Drawing.Point(69, 19);
            this.quitadoRadioButton.Name = "quitadoRadioButton";
            this.quitadoRadioButton.Size = new System.Drawing.Size(62, 17);
            this.quitadoRadioButton.TabIndex = 1;
            this.quitadoRadioButton.Text = "Quitado";
            this.quitadoRadioButton.UseVisualStyleBackColor = true;
            // 
            // pagarRadioButton
            // 
            this.pagarRadioButton.AutoSize = true;
            this.pagarRadioButton.Location = new System.Drawing.Point(6, 22);
            this.pagarRadioButton.Name = "pagarRadioButton";
            this.pagarRadioButton.Size = new System.Drawing.Size(63, 17);
            this.pagarRadioButton.TabIndex = 1;
            this.pagarRadioButton.Text = "À Pagar";
            this.pagarRadioButton.UseVisualStyleBackColor = true;
            // 
            // receberRadioButton
            // 
            this.receberRadioButton.AutoSize = true;
            this.receberRadioButton.Location = new System.Drawing.Point(75, 21);
            this.receberRadioButton.Name = "receberRadioButton";
            this.receberRadioButton.Size = new System.Drawing.Size(76, 17);
            this.receberRadioButton.TabIndex = 2;
            this.receberRadioButton.Text = "À Receber";
            this.receberRadioButton.UseVisualStyleBackColor = true;
            // 
            // todosTipoRadioButton
            // 
            this.todosTipoRadioButton.AutoSize = true;
            this.todosTipoRadioButton.Checked = true;
            this.todosTipoRadioButton.Location = new System.Drawing.Point(157, 21);
            this.todosTipoRadioButton.Name = "todosTipoRadioButton";
            this.todosTipoRadioButton.Size = new System.Drawing.Size(55, 17);
            this.todosTipoRadioButton.TabIndex = 3;
            this.todosTipoRadioButton.TabStop = true;
            this.todosTipoRadioButton.Text = "Todos";
            this.todosTipoRadioButton.UseVisualStyleBackColor = true;
            // 
            // todosSituacaoRadioButton
            // 
            this.todosSituacaoRadioButton.AutoSize = true;
            this.todosSituacaoRadioButton.Checked = true;
            this.todosSituacaoRadioButton.Location = new System.Drawing.Point(137, 19);
            this.todosSituacaoRadioButton.Name = "todosSituacaoRadioButton";
            this.todosSituacaoRadioButton.Size = new System.Drawing.Size(55, 17);
            this.todosSituacaoRadioButton.TabIndex = 2;
            this.todosSituacaoRadioButton.TabStop = true;
            this.todosSituacaoRadioButton.Text = "Todos";
            this.todosSituacaoRadioButton.UseVisualStyleBackColor = true;
            // 
            // FrmRelatorioConta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 492);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.codPessoaTextBox);
            this.Controls.Add(this.finalDateTimePicker);
            this.Controls.Add(this.inicialDateTimePicker);
            this.Controls.Add(this.contasReportViewer);
            this.Name = "FrmRelatorioConta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatorio de Contas";
            this.Load += new System.EventHandler(this.FrmRelatorioConta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tb_contaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_pessoaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.saceRelatoriosDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dt_RelContaBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer contasReportViewer;
        private System.Windows.Forms.DateTimePicker inicialDateTimePicker;
        private System.Windows.Forms.DateTimePicker finalDateTimePicker;
        private System.Windows.Forms.MaskedTextBox codPessoaTextBox;
        private Dados.saceDataSet saceDataSet;
        private System.Windows.Forms.BindingSource tb_pessoaBindingSource;
        private System.Windows.Forms.BindingSource tb_contaBindingSource;
        private System.Windows.Forms.Button button1;
        private Dados.saceDataSetTableAdapters.tb_contaTableAdapter tb_contaTableAdapter1;
        private Dados.saceDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
        private Dados.saceDataSetTableAdapters.tb_pessoaTableAdapter tb_pessoaTableAdapter1;
        private System.Windows.Forms.BindingSource dt_RelContaBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton todosTipoRadioButton;
        private System.Windows.Forms.RadioButton receberRadioButton;
        private System.Windows.Forms.RadioButton pagarRadioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton todosSituacaoRadioButton;
        private System.Windows.Forms.RadioButton quitadoRadioButton;
        private System.Windows.Forms.RadioButton abertoRadioButton;
    }
}