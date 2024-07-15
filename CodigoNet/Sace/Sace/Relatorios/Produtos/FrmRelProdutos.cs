using Negocio;

namespace Sace.Relatorios.Produtos
{
    public partial class FrmRelProdutos : Form
    {
        public FrmRelProdutos()
        {
            InitializeComponent();
        }

        private void FrmRelProdutos_Load(object sender, EventArgs e)
        {
            produtoBindingSource.DataSource = GerenciadorProduto.ObterTodosExibiveis();
            this.reportViewer1.RefreshReport();
        }
    }
}
