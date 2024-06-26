using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Negocio;

namespace Sace
{
    public partial class FrmBancoPesquisa : Form
    {
        public Banco BancoSelected { get; set; }
        private readonly SaceService service;
        private readonly DbContextOptions<SaceContext> saceOptions;

        public FrmBancoPesquisa(DbContextOptions<SaceContext> saceOptions)
        {
            InitializeComponent();
            BancoSelected = null;
            this.saceOptions = saceOptions;
            SaceContext context = new SaceContext(saceOptions);
            SaceService service = new SaceService(context);
        }

        private void FrmBancoPesquisa_Load(object sender, EventArgs e)
        {
            bancoBindingSource.DataSource = service.GerenciadorBanco.ObterTodos();
            cmbBusca.SelectedIndex = 0;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                bancoBindingSource.DataSource = service.GerenciadorBanco.Obter(int.Parse(txtTexto.Text));
            else
                bancoBindingSource.DataSource = service.GerenciadorBanco.ObterPorNome(txtTexto.Text);

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
