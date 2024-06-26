using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;
using Negocio;
using System.Data;
using Util;

namespace Sace.Relatorios.Produtos
{
    public partial class FrmDAV : Form
    {
        
        private List<long> listaCodSaidas;
        private decimal total;
        private decimal totalPagar;
        private decimal desconto;

        private readonly SaceService service;
        private readonly DbContextOptions<SaceContext> saceOptions;

        public FrmDAV(List<long> listaCodSaidas, decimal total, decimal totalPagar, decimal desconto, DbContextOptions<SaceContext> saceOptions)
        {
            InitializeComponent();
            this.listaCodSaidas = listaCodSaidas;
            this.total = total;
            this.totalPagar = totalPagar;
            this.desconto = desconto;
            this.saceOptions = saceOptions;
            var context = new SaceContext(saceOptions);
            service = new SaceService(context);
        }

        private void FrmDAV_Load(object sender, EventArgs e)
        {
            // Obtém os produtos das saídas
            List<SaidaProdutoRelatorio> listaSaidaProdutoRelatorio = service.GerenciadorSaidaProduto.ObterPorSaidasRelatorio(listaCodSaidas);
            SaidaProdutoRelatorioBindingSource.DataSource = listaSaidaProdutoRelatorio;

            if (listaSaidaProdutoRelatorio.Count > 0)
            {
                // Obtém os demais dados para preenchimento do relatório
                long codCliente = listaSaidaProdutoRelatorio.ElementAtOrDefault(0).CodCliente;
                PessoaBindingSource.DataSource = service.GerenciadorPessoa.Obter(codCliente);
                
                Loja loja = service.GerenciadorLoja.Obter(UtilConfig.Default.LOJA_PADRAO).ElementAtOrDefault(0);
                PessoaLojaBindingSource.DataSource = service.GerenciadorPessoa.Obter(loja.CodPessoa);

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
