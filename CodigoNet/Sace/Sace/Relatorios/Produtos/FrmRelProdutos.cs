using Dados;
using Negocio;

namespace Sace.Relatorios.Produtos
{
    public partial class FrmRelProdutos : Form
    {
        private readonly GerenciadorProduto gerenciadorProduto;

        public FrmRelProdutos(SaceContext context)
        {
            InitializeComponent();
            gerenciadorProduto = new GerenciadorProduto(context);
        }

        private void FrmRelProdutos_Load(object sender, EventArgs e)
        {
            produtoBindingSource.DataSource = gerenciadorProduto.ObterTodosExibiveis();
            this.reportViewer1.RefreshReport();
        }
    }
}
