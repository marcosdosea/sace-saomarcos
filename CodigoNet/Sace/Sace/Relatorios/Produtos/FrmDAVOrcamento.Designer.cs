namespace Sace.Relatorios.Produtos
{
    partial class FrmDAVOrcamento
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
            components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            PessoaLojaBindingSource = new BindingSource(components);
            SaidaProdutoRelatorioBindingSource = new BindingSource(components);
            PessoaBindingSource = new BindingSource(components);
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)PessoaLojaBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SaidaProdutoRelatorioBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PessoaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // PessoaLojaBindingSource
            // 
            PessoaLojaBindingSource.DataSource = typeof(Dominio.Pessoa);
            // 
            // SaidaProdutoRelatorioBindingSource
            // 
            SaidaProdutoRelatorioBindingSource.DataSource = typeof(Dominio.SaidaProdutoRelatorio);
            // 
            // PessoaBindingSource
            // 
            PessoaBindingSource.DataSource = typeof(Dominio.Pessoa);
            // 
            // reportViewer1
            // 
            reportViewer1.Dock = DockStyle.Fill;
            reportDataSource1.Name = "DataSetPessoaLoja";
            reportDataSource1.Value = PessoaLojaBindingSource;
            reportDataSource2.Name = "DataSetSaidaProdutoRelatorio";
            reportDataSource2.Value = SaidaProdutoRelatorioBindingSource;
            reportDataSource3.Name = "DataSetCliente";
            reportDataSource3.Value = PessoaBindingSource;
            reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            reportViewer1.LocalReport.ReportEmbeddedResource = "Relatorios.Produtos.ReportDAVOrcamento.rdlc";
            reportViewer1.LocalReport.ReportPath = "D:\\Projetos\\sace-saomarcos\\CodigoNet\\Sace\\Sace\\Relatorios\\Produtos\\ReportDAVOrcamento.rdlc";
            reportViewer1.Location = new Point(0, 0);
            reportViewer1.Margin = new Padding(4, 3, 4, 3);
            reportViewer1.Name = "reportViewer1";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(1101, 565);
            reportViewer1.TabIndex = 0;
            // 
            // FrmDAVOrcamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1101, 565);
            Controls.Add(reportViewer1);
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmDAVOrcamento";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Documento Auxiliar de Venda - Orçamento";
            Load += FrmDAV_Load;
            KeyDown += FrmDAV_KeyDown;
            ((System.ComponentModel.ISupportInitialize)PessoaLojaBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)SaidaProdutoRelatorioBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)PessoaBindingSource).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PessoaBindingSource;
        private System.Windows.Forms.BindingSource SaidaProdutoRelatorioBindingSource;
        private System.Windows.Forms.BindingSource PessoaLojaBindingSource;



    }
}