using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Negocio;

namespace Sace
{
    public partial class FrmContaBancoPesquisa : Form
    {
        public ContaBanco ContaBancoSelected { get; set; }
        private readonly SaceService service;
        private readonly DbContextOptions<SaceContext> saceOptions;

        public FrmContaBancoPesquisa(DbContextOptions<SaceContext> saceOptions)
        {
            InitializeComponent();
            ContaBancoSelected = null;
            this.saceOptions = saceOptions;
            SaceContext context = new SaceContext(saceOptions);
            service = new SaceService(context);
        }

        private void FrmBancoPesquisa_Load(object sender, EventArgs e)
        {
            contaBancoBindingSource.DataSource = service.GerenciadorContaBanco.ObterTodos();
            cmbBusca.SelectedIndex = 1;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if ((cmbBusca.SelectedIndex == 0) && !txtTexto.Text.Equals(""))
                contaBancoBindingSource.DataSource = service.GerenciadorContaBanco.ObterPorNumero(txtTexto.Text);
            else
                contaBancoBindingSource.DataSource = service.GerenciadorContaBanco.ObterPorDescricao(txtTexto.Text);

        }

        private void tb_bancoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ContaBancoSelected = (ContaBanco)contaBancoBindingSource.Current;
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
                contaBancoBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                contaBancoBindingSource.MovePrevious();
            }
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }
    }
}