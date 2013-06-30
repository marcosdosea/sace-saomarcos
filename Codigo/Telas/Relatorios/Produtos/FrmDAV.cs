using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Dominio;
using Microsoft.Reporting.WinForms;

namespace Telas.Relatorios.Produtos
{
    public partial class FrmDAV : Form
    {
        public FrmDAV()
        {
            InitializeComponent();
        }

        private void FrmDAV_Load(object sender, EventArgs e)
        {
            
            List<SaidaProdutoRelatorio> listaSaidaProdutoRelatorio = GerenciadorSaidaProduto.GetInstance(null).ObterPorPedidoRelatorio("053992");
            SaidaProdutoRelatorioBindingSource.DataSource = listaSaidaProdutoRelatorio;

            if (listaSaidaProdutoRelatorio.Count > 0)
            {
                long codCliente = listaSaidaProdutoRelatorio.ElementAtOrDefault(0).CodCliente;
                PessoaBindingSource.DataSource = GerenciadorPessoa.GetInstance().Obter(codCliente);
                
                Loja loja = GerenciadorLoja.GetInstance().Obter(Util.Global.LOJA_PADRAO).ElementAtOrDefault(0);
                PessoaLojaBindingSource.DataSource = GerenciadorPessoa.GetInstance().Obter(loja.CodPessoa);

                ReportParameterCollection parameterCollection = new ReportParameterCollection();
                parameterCollection.Add(new ReportParameter("TotalSaidas", "1000"));
                parameterCollection.Add(new ReportParameter("Desconto", "10"));
                parameterCollection.Add(new ReportParameter("TotalPagar", "900"));
                this.reportViewer1.LocalReport.SetParameters(parameterCollection);
                
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
