using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Negocio;

namespace Sace
{
    public partial class FrmCartaoCreditoPesquisa : Form
    {
        public CartaoCredito CartaoCreditoSelected { get; set; }
        private readonly SaceService service;
        private readonly DbContextOptions<SaceContext> saceOptions;

        public FrmCartaoCreditoPesquisa(DbContextOptions<SaceContext> saceOptions)
        {
            InitializeComponent();
            CartaoCreditoSelected = null;
            this.saceOptions = saceOptions;
            SaceContext context = new SaceContext(saceOptions);
            service = new SaceService(context);
        }

        private void FrmCartaoCreditoPesquisa_Load(object sender, EventArgs e)
        {
            cartaoCreditoBindingSource.DataSource = service.GerenciadorCartaoCredito.ObterTodos();
            cmbBusca.SelectedIndex = 0;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                cartaoCreditoBindingSource.DataSource = service.GerenciadorCartaoCredito.Obter(int.Parse(txtTexto.Text));
            else
                cartaoCreditoBindingSource.DataSource = service.GerenciadorCartaoCredito.ObterPorNome(txtTexto.Text);
        }

        private void tb_cartao_creditoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CartaoCreditoSelected = (CartaoCredito)cartaoCreditoBindingSource.Current;
            this.Close();
        }

        private void FrmCartaoCreditoPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_cartao_creditoDataGridView_CellClick(sender, null);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if ((e.KeyCode == Keys.Down) && (txtTexto.Focused))
            {
                cartaoCreditoBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                cartaoCreditoBindingSource.MovePrevious();
            }
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }
    }
}
