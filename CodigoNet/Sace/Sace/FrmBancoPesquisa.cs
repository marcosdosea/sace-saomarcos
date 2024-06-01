using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Negocio;

namespace Telas
{
    public partial class FrmBancoPesquisa : Form
    {
        public Banco BancoSelected { get; set; }
        private GerenciadorBanco gerenciadorBanco;

        public FrmBancoPesquisa(DbContextOptions<SaceContext> options)
        {
            InitializeComponent();
            BancoSelected = null;
            SaceContext context = new SaceContext(options);
            gerenciadorBanco = new GerenciadorBanco(context);
        }

        private void FrmBancoPesquisa_Load(object sender, EventArgs e)
        {
            bancoBindingSource.DataSource = gerenciadorBanco.ObterTodos();
            cmbBusca.SelectedIndex = 0;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                bancoBindingSource.DataSource = gerenciadorBanco.Obter(int.Parse(txtTexto.Text));
            else
                bancoBindingSource.DataSource = gerenciadorBanco.ObterPorNome(txtTexto.Text);

        }

        private void tb_bancoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BancoSelected = (Banco) bancoBindingSource.Current;
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
            else if ((e.KeyCode == Keys.Down) && (txtTexto.Focused))
            {
                bancoBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                bancoBindingSource.MovePrevious();
            }
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }
    }
}
