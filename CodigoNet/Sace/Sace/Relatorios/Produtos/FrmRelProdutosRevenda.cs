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

        public FrmRelProdutosRevenda(long codPessoa, decimal lucro)
        {
            this.codPessoa = codPessoa;
            this.lucro = lucro;
            InitializeComponent();
        }

        private void FrmRelProdutosRevenda_Load(object sender, EventArgs e)
        {
            ProdutoBindingSource.DataSource = GerenciadorProduto.ObterPorCodigoFabricante(codPessoa);
            Loja loja = GerenciadorLoja.Obter(UtilConfig.Default.LOJA_PADRAO).ElementAtOrDefault(0);
            PessoaBindingSource.DataSource = GerenciadorPessoa.Obter(loja.CodPessoa);

            string parametroLucro = (1 + lucro / 100).ToString();

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Relatorios.Produtos.ReportProdutosRevenda.rdlc";
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
