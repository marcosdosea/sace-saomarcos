using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Negocio;

namespace Sace
{
    public partial class FrmPlanoContaPesquisa : Form
    {
        public PlanoConta PlanoContaSelected;
        private readonly GerenciadorPlanoConta gerenciadorPlanoConta;

        public FrmPlanoContaPesquisa(SaceContext context)
        {
            InitializeComponent();
            PlanoContaSelected = null;
            gerenciadorPlanoConta = new GerenciadorPlanoConta(context);
        }

        private void FrmPlanoContaPesquisa_Load(object sender, EventArgs e)
        {
            planoContaBindingSource.DataSource = gerenciadorPlanoConta.ObterTodos();
            cmbBusca.SelectedIndex = 0;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                planoContaBindingSource.DataSource = gerenciadorPlanoConta.Obter(Convert.ToInt32(txtTexto.Text));
            else
                planoContaBindingSource.DataSource = gerenciadorPlanoConta.ObterPorDescricao(txtTexto.Text);
        }

        private void tb_plano_contaDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PlanoContaSelected = (PlanoConta)planoContaBindingSource.Current;
            this.Close();
        }

        private void FrmPlanoContaPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_plano_contaDataGridView_CellClick(sender, null);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if ((e.KeyCode == Keys.Down) && (txtTexto.Focused))
            {
                planoContaBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                planoContaBindingSource.MovePrevious();
            }
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }

    }
}
