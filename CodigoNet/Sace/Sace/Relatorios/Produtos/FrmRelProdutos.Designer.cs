namespace Sace.Relatorios.Produtos
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
            components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            produtoBindingSource = new BindingSource(components);
            reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)produtoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // produtoBindingSource
            // 
            produtoBindingSource.DataSource = typeof(Dominio.Produto);
            produtoBindingSource.Sort = "nome";
            // 
            // reportViewer1
            // 
            reportViewer1.Dock = DockStyle.Fill;
            reportDataSource1.Name = "DataSetProduto";
            reportDataSource1.Value = produtoBindingSource;
            reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            reportViewer1.LocalReport.ReportEmbeddedResource = "Relatorios.Produtos.RptProdutos.rdlc";
            reportViewer1.LocalReport.ReportPath = "D:\\Projetos\\sace-saomarcos\\CodigoNet\\Sace\\Sace\\Relatorios\\Produtos\\RptProdutos.rdlc";
            reportViewer1.Location = new Point(0, 0);
            reportViewer1.Margin = new Padding(4, 3, 4, 3);
            reportViewer1.Name = "reportViewer1";
            reportViewer1.ServerReport.BearerToken = null;
            reportViewer1.Size = new Size(551, 302);
            reportViewer1.TabIndex = 0;
            // 
            // FrmRelProdutos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(551, 302);
            Controls.Add(reportViewer1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmRelProdutos";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmRelProdutos";
            WindowState = FormWindowState.Maximized;
            Load += FrmRelProdutos_Load;
            ((System.ComponentModel.ISupportInitialize)produtoBindingSource).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource produtoBindingSource;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}