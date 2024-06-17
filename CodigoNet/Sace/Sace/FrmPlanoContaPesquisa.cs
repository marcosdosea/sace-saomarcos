using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace Telas
{
    public partial class FrmPlanoContaPesquisa : Form
    {
        public PlanoConta PlanoContaSelected;

        public FrmPlanoContaPesquisa()
        {
            InitializeComponent();
            PlanoContaSelected = null;
        }

        private void FrmPlanoContaPesquisa_Load(object sender, EventArgs e)
        {
            planoContaBindingSource.DataSource = GerenciadorPlanoConta.GetInstance().ObterTodos();
            cmbBusca.SelectedIndex = 0;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                planoContaBindingSource.DataSource = GerenciadorPlanoConta.GetInstance().Obter(Convert.ToInt32(txtTexto.Text));
            else
                planoContaBindingSource.DataSource = GerenciadorPlanoConta.GetInstance().ObterPorDescricao(txtTexto.Text);
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
