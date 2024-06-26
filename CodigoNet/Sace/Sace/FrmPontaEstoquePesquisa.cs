using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Negocio;

namespace Sace
{
    public partial class FrmPontaEstoquePesquisa : Form
    {
        public PontaEstoque PontaEstoqueSelected { get; set; }
        IEnumerable<PontaEstoque> listaPontaEstoque;
        private readonly SaceService service;
        private readonly DbContextOptions<SaceContext> saceOptions;
        
        public FrmPontaEstoquePesquisa(IEnumerable<PontaEstoque> listaPontaEstoque, DbContextOptions<SaceContext> saceOptions)
        {
            InitializeComponent();
            PontaEstoqueSelected = null;
            this.listaPontaEstoque = listaPontaEstoque;
            this.saceOptions = saceOptions;
            SaceContext context = new SaceContext(saceOptions);
            service = new SaceService(context);
        }

        private void FrmBancoPesquisa_Load(object sender, EventArgs e)
        {
            pontaEstoqueBindingSource.DataSource = listaPontaEstoque;
            pontaEstoqueDataGridView.Select();
        }

        private void tb_bancoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (MessageBox.Show("Confirma Exclusão e Utilização dessa Ponta de Estoque?", "Confirmar Seleção Ponta Estoque", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                PontaEstoqueSelected = (PontaEstoque)pontaEstoqueBindingSource.Current;
                service.GerenciadorPontaEstoque.Remover(PontaEstoqueSelected.CodPontaEstoque);
            }
            else
            {
                PontaEstoqueSelected = null;
            }
            this.Close();
        }

        private void FrmBancoPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_bancoDataGridView_CellClick(sender, null);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
