using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
            this.tb_saidaTableAdapter.FillPreVendasPendentes(this.saceDataSet.tb_saida);
            cmbBusca.SelectedIndex = 0;
         }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbBusca.SelectedIndex == 0)
                {
                    this.tb_saidaTableAdapter.FillPreVendasPendentes(this.saceDataSet.tb_saida);
                }
                else
                    if (!txtTexto.Text.Trim().Equals(""))
                    {
                        if (cmbBusca.SelectedIndex == 1)
                            this.tb_saidaTableAdapter.FillByCodSaida(this.saceDataSet.tb_saida, int.Parse(txtTexto.Text));
                        else if (cmbBusca.SelectedIndex == 2)
                            this.tb_saidaTableAdapter.FillByPedidoGerado(this.saceDataSet.tb_saida, txtTexto.Text);
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
                tb_saidaBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                tb_saidaBindingSource.MovePrevious();
            }
        }        

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
            if (cmbBusca.SelectedIndex == 0)
            {
                this.tb_saidaTableAdapter.FillPreVendasPendentes(this.saceDataSet.tb_saida);
            }
        }

        private void tb_saidaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tb_saidaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.saceDataSet);

        }

        
    }
}
