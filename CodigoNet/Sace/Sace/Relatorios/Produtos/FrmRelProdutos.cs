using Dados;
using Microsoft.EntityFrameworkCore;
using Negocio;

namespace Sace.Relatorios.Produtos
{
    public partial class FrmRelProdutos : Form
    {
        private readonly SaceService service;
        private readonly DbContextOptions<SaceContext> saceOptions;

        public FrmRelProdutos(DbContextOptions<SaceContext> saceOptions)
        {
            InitializeComponent();
            this.saceOptions = saceOptions;
            SaceContext context = new SaceContext(saceOptions);
            service = new SaceService(context);
        }

        private void FrmRelProdutos_Load(object sender, EventArgs e)
        {
            produtoBindingSource.DataSource = GerenciadorProduto.ObterTodosExibiveis();
            this.reportViewer1.RefreshReport();
        }
    }
}
