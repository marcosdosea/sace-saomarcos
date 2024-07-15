using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Negocio;

namespace Sace
{
    public partial class FrmCartaoCreditoPesquisa : Form
    {
        public CartaoCredito CartaoCreditoSelected { get; set; }
        public FrmCartaoCreditoPesquisa()
        {
            InitializeComponent();
            CartaoCreditoSelected = null;
        }

        private void FrmCartaoCreditoPesquisa_Load(object sender, EventArgs e)
        {
            cartaoCreditoBindingSource.DataSource = GerenciadorCartaoCredito.ObterTodos();
            cmbBusca.SelectedIndex = 0;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                cartaoCreditoBindingSource.DataSource = GerenciadorCartaoCredito.Obter(int.Parse(txtTexto.Text));
            else
                cartaoCreditoBindingSource.DataSource = GerenciadorCartaoCredito.ObterPorNome(txtTexto.Text);
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
