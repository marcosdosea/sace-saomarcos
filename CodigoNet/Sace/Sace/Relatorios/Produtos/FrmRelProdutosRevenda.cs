using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WinForms;
using Negocio;
using System.Data;
using Util;

namespace Sace.Relatorios.Produtos
{
    public partial class FrmRelProdutosRevenda : Form
    {
        private long codPessoa;
        private decimal lucro;
        private readonly SaceService service;
        private readonly DbContextOptions<SaceContext> saceOptions;

        public FrmRelProdutosRevenda(long codPessoa, decimal lucro, DbContextOptions<SaceContext> saceOptions)
        {
            this.codPessoa = codPessoa;
            this.lucro = lucro;
            InitializeComponent();
            this.saceOptions = saceOptions;
            SaceContext context = new SaceContext(saceOptions);
            service = new SaceService(context);
        }

        private void FrmRelProdutosRevenda_Load(object sender, EventArgs e)
        {
            ProdutoBindingSource.DataSource = service.GerenciadorProduto.ObterPorCodigoFabricante(codPessoa);
            Loja loja = service.GerenciadorLoja.Obter(UtilConfig.Default.LOJA_PADRAO).ElementAtOrDefault(0);
            PessoaBindingSource.DataSource = gerenciadorPessoa.Obter(loja.CodPessoa);

            string parametroLucro = (1 + lucro / 100).ToString();

            ReportParameter p1 = new ReportParameter("PorcentagemLucro", parametroLucro);
            this.reportViewer1.LocalReport.SetParameters(p1);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
