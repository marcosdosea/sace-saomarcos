namespace Telas.Relatorios.Produtos
{
    partial class FrmDAV
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.PessoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SaidaProdutoRelatorioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PessoaLojaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PessoaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaidaProdutoRelatorioBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PessoaLojaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // PessoaBindingSource
            // 
            this.PessoaBindingSource.DataSource = typeof(Dominio.Pessoa);
            // 
            // SaidaProdutoRelatorioBindingSource
            // 
            this.SaidaProdutoRelatorioBindingSource.DataSource = typeof(Dominio.SaidaProdutoRelatorio);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetPessoaLoja";
            reportDataSource1.Value = this.PessoaLojaBindingSource;
            reportDataSource2.Name = "DataSetSaidaProdutoRelatorio";
            reportDataSource2.Value = this.SaidaProdutoRelatorioBindingSource;
            reportDataSource3.Name = "DataSetCliente";
            reportDataSource3.Value = this.PessoaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Telas.Relatorios.Produtos.ReportDAV.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(805, 441);
            this.reportViewer1.TabIndex = 0;
            // 
            // PessoaLojaBindingSource
            // 
            this.PessoaLojaBindingSource.DataSource = typeof(Dominio.Pessoa);
            // 
            // FrmDAV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 441);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmDAV";
            this.Text = "Documento Auxiliar de Venda";
            this.Load += new System.EventHandler(this.FrmDAV_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PessoaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaidaProdutoRelatorioBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PessoaLojaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PessoaBindingSource;
        private System.Windows.Forms.BindingSource SaidaProdutoRelatorioBindingSource;
        private System.Windows.Forms.BindingSource PessoaLojaBindingSource;



    }
}