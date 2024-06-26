using Dados;
using Dominio;
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
        private readonly GerenciadorLoja gerenciadorLoja;
        private readonly GerenciadorProduto gerenciadorProduto;
        private readonly GerenciadorPessoa gerenciadorPessoa;

        public FrmRelProdutosRevenda(long codPessoa, decimal lucro, SaceContext context)
        {
            this.codPessoa = codPessoa;
            this.lucro = lucro;
            InitializeComponent();
            gerenciadorLoja = new GerenciadorLoja(context);
            gerenciadorPessoa = new GerenciadorPessoa(context);
            gerenciadorProduto = new GerenciadorProduto(context);
        }

        private void FrmRelProdutosRevenda_Load(object sender, EventArgs e)
        {
            ProdutoBindingSource.DataSource = gerenciadorProduto.ObterPorCodigoFabricante(codPessoa);
            Loja loja = gerenciadorLoja.Obter(UtilConfig.Default.LOJA_PADRAO).ElementAtOrDefault(0);
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
