using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Dominio;

namespace Telas
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
            cartaoCreditoBindingSource.DataSource = GerenciadorCartaoCredito.GetInstance().ObterTodos();
            cmbBusca.SelectedIndex = 0;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                cartaoCreditoBindingSource.DataSource = GerenciadorCartaoCredito.GetInstance().Obter(int.Parse(txtTexto.Text));
            else
                cartaoCreditoBindingSource.DataSource = GerenciadorCartaoCredito.GetInstance().ObterPorNome(txtTexto.Text);
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
