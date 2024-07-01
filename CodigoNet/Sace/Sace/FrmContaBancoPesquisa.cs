using Dominio;
using Negocio;

namespace Sace
{
    public partial class FrmContaBancoPesquisa : Form
    {
        public ContaBanco ContaBancoSelected { get; set; }

        public FrmContaBancoPesquisa()
        {
            InitializeComponent();
            ContaBancoSelected = null;
        }

        private void FrmBancoPesquisa_Load(object sender, EventArgs e)
        {
            var gerenciadorContaBanco = new GerenciadorContaBanco();
            contaBancoBindingSource.DataSource = gerenciadorContaBanco.ObterTodos();
            cmbBusca.SelectedIndex = 1;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            var gerenciadorContaBanco = new GerenciadorContaBanco();
            if ((cmbBusca.SelectedIndex == 0) && !txtTexto.Text.Equals(""))
                contaBancoBindingSource.DataSource = gerenciadorContaBanco.ObterPorNumero(txtTexto.Text);
            else
                contaBancoBindingSource.DataSource = gerenciadorContaBanco.ObterPorDescricao(txtTexto.Text);
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