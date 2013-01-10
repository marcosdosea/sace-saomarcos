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
    public partial class FrmContaPesquisa : Form
    {
        public Conta ContaSelected { get; set; }

        public FrmContaPesquisa()
        {
            InitializeComponent();
            ContaSelected = null;
        }

                
        private void FrmContaPesquisa_Load(object sender, EventArgs e)
        {
            contaBindingSource.DataSource = GerenciadorConta.GetInstance().ObterTodos();
            cmbBusca.SelectedIndex = 0;
        }


        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if ((cmbBusca.SelectedIndex == 0) && !txtTexto.Text.Equals(""))
                contaBindingSource.DataSource = GerenciadorConta.GetInstance().Obter(Convert.ToInt64(txtTexto.Text));
            else if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                contaBindingSource.DataSource = GerenciadorConta.GetInstance().ObterPorEntrada(Convert.ToInt64(txtTexto.Text));
            else if ((cmbBusca.SelectedIndex == 2) && !txtTexto.Text.Equals(""))
                contaBindingSource.DataSource = GerenciadorConta.GetInstance().ObterPorSaida(Convert.ToInt64(txtTexto.Text));
            }

        private void tb_grupo_contaDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ContaSelected = (Conta) contaBindingSource.Current;
            this.Close();
        }

        private void FrmContaPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_grupo_contaDataGridView_CellClick(sender, null);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if ((e.KeyCode == Keys.Down) && (txtTexto.Focused))
            {
                contaBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                contaBindingSource.MovePrevious();
            }
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }
    }
}
