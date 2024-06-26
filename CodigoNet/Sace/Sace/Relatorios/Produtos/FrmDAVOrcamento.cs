using Dados;
using Dominio;
using Microsoft.Reporting.WinForms;
using Negocio;
using System.Data;
using Util;

namespace Sace.Relatorios.Produtos
{
    public partial class FrmDAVOrcamento : Form
    {
        
        private List<long> listaCodSaidas;
        private decimal total;
        private decimal totalPagar;
        private decimal desconto;
        private readonly GerenciadorLoja gerenciadorLoja;
        private readonly GerenciadorPessoa gerenciadorPessoa;
        private readonly GerenciadorSaidaProduto gerenciadorSaidaProduto;   


        public FrmDAVOrcamento(List<long> listaCodSaidas, decimal total, decimal totalPagar, decimal desconto, SaceContext context)
        {
            InitializeComponent();
            this.listaCodSaidas = listaCodSaidas;
            this.total = total;
            this.totalPagar = totalPagar;
            this.desconto = desconto;
            gerenciadorLoja = new GerenciadorLoja(context);
            gerenciadorPessoa = new GerenciadorPessoa(context); 
            gerenciadorSaidaProduto = new GerenciadorSaidaProduto(context);
        }

        private void FrmDAV_Load(object sender, EventArgs e)
        {
            // Obtém os produtos das saídas
            List<SaidaProdutoRelatorio> listaSaidaProdutoRelatorio = gerenciadorSaidaProduto.ObterPorSaidasRelatorio(listaCodSaidas);
            SaidaProdutoRelatorioBindingSource.DataSource = listaSaidaProdutoRelatorio;

            if (listaSaidaProdutoRelatorio.Count > 0)
            {
                // Obtém os demais dados para preenchimento do relatório
                long codCliente = listaSaidaProdutoRelatorio.ElementAtOrDefault(0).CodCliente;
                PessoaBindingSource.DataSource = gerenciadorPessoa.Obter(codCliente);
                
                Loja loja = gerenciadorLoja.Obter(UtilConfig.Default.LOJA_PADRAO).ElementAtOrDefault(0);
                PessoaLojaBindingSource.DataSource = gerenciadorPessoa.Obter(loja.CodPessoa);

                ReportParameterCollection parameterCollection = new ReportParameterCollection();
                parameterCollection.Add(new ReportParameter("TotalSaidas", total.ToString("N2")));
                parameterCollection.Add(new ReportParameter("Desconto", desconto.ToString("N2")));
                parameterCollection.Add(new ReportParameter("TotalPagar", totalPagar.ToString("N2")));
                this.reportViewer1.LocalReport.SetParameters(parameterCollection);
                
                this.reportViewer1.RefreshReport();
            }
        }

        private void FrmDAV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
