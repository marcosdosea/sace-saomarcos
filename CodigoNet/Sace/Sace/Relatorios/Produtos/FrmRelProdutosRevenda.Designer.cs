namespace Sace.Relatorios.Produtos
{
    partial class FrmRelProdutosRevenda
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
            this.ProdutoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PessoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.ProdutoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PessoaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ProdutoBindingSource
            // 
            this.ProdutoBindingSource.DataSource = typeof(Dominio.Produto);
            // 
            // PessoaBindingSource
            // 
            this.PessoaBindingSource.DataSource = typeof(Dominio.Pessoa);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetProdutos";
            reportDataSource1.Value = this.ProdutoBindingSource;
            reportDataSource2.Name = "DataSetPessoaLoja";
            reportDataSource2.Value = this.PessoaBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Relatorios.Produtos.ReportProdutosRevenda.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(753, 318);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.reportViewer1_KeyDown);
            // 
            // FrmRelProdutosRevenda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 318);
            this.Controls.Add(this.reportViewer1);
            this.KeyPreview = true;
            this.Name = "FrmRelProdutosRevenda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRelProdutosRevenda";
            this.Load += new System.EventHandler(this.FrmRelProdutosRevenda_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.reportViewer1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ProdutoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PessoaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ProdutoBindingSource;
        private System.Windows.Forms.BindingSource PessoaBindingSource;
    }
}