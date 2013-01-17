using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;

namespace Telas
{
    public partial class FrmSaidaPesquisa : Form
    {
        private Int64 codSaida;

        public Int64 CodSaida
        {
            get { return codSaida; }            
        }

        public FrmSaidaPesquisa()
        {
            InitializeComponent();
            codSaida = -1;
        }

        private void FrmSaidaPesquisa_Load(object sender, EventArgs e)
        {
            saidaBindingSource.DataSource = GerenciadorSaida.GetInstance().ObterPreVendasPendentes();
            cmbBusca.SelectedIndex = 1;
         }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbBusca.SelectedIndex == 0)
                {
                    saidaBindingSource.DataSource = GerenciadorSaida.GetInstance().ObterPreVendasPendentes();
                }
                else
                    if (!txtTexto.Text.Trim().Equals(""))
                    {
                        if (cmbBusca.SelectedIndex == 1)
                            saidaBindingSource.DataSource = GerenciadorSaida.GetInstance().Obter(long.Parse(txtTexto.Text));
                        else if (cmbBusca.SelectedIndex == 2)
                            saidaBindingSource.DataSource = GerenciadorSaida.GetInstance().ObterPorPedido(txtTexto.Text);
                        else if (cmbBusca.SelectedIndex == 3)
                            saidaBindingSource.DataSource = GerenciadorSaida.GetInstance().ObterPorNomeCliente(txtTexto.Text);
                    }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void tb_saidaDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            codSaida = int.Parse(tb_saidaDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            this.Close();
        }

        private void FrmSaidaPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_saidaDataGridView_CellClick(sender, null);
            } 
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            } 
            else if ((e.KeyCode == Keys.Down) && (txtTexto.Focused))
            {
                saidaBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                saidaBindingSource.MovePrevious();
            }
        }        

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
            if (cmbBusca.SelectedIndex == 0)
            {
                saidaBindingSource.DataSource = GerenciadorSaida.GetInstance().ObterPreVendasPendentes();
            }
        }
      
    }
}
