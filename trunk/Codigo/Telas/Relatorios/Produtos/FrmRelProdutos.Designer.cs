namespace Telas.Relatorios.Produtos
{
    partial class FrmRelProdutos
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.saceDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbprodutoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbprodutoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSetProdutos";
            reportDataSource1.Value = this.saceDataSetBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Telas.Relatorios.Produtos.RptProdutos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(-1, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(474, 262);
            this.reportViewer1.TabIndex = 0;
            // 
            // saceDataSetBindingSource
            // 
            this.saceDataSetBindingSource.DataMember = "tb_produto";
            this.saceDataSetBindingSource.DataSource = typeof(Dados.saceDataSet);
            // 
            // tbprodutoBindingSource
            // 
            this.tbprodutoBindingSource.DataMember = "tb_produto";
            this.tbprodutoBindingSource.DataSource = typeof(Dados.saceDataSet);
            // 
            // FrmRelProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 262);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmRelProdutos";
            this.Text = "FrmRelProdutos";
            this.Load += new System.EventHandler(this.FrmRelProdutos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.saceDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbprodutoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource saceDataSetBindingSource;
        private System.Windows.Forms.BindingSource tbprodutoBindingSource;
    }
}