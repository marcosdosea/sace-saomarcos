using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SACE.Telas
{
    public partial class FrmPlanoContaPesquisa : Form
    {
        private Int32 codPlanoConta;

        public FrmPlanoContaPesquisa()
        {
            InitializeComponent();
            codPlanoConta = -1;
        }

        private void FrmPlanoContaPesquisa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'saceDataSet.tb_plano_conta' table. You can move, or remove it, as needed.
            this.tb_plano_contaTableAdapter.Fill(this.saceDataSet.tb_plano_conta);
            // TODO: This line of code loads data into the 'saceDataSet.tb_plano_conta' table. You can move, or remove it, as needed.
            this.tb_plano_contaTableAdapter.Fill(this.saceDataSet.tb_plano_conta);
            cmbBusca.SelectedIndex = 0;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
               // if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                    //this.tb_plano_contaTableAdapter.FillByCodPlanoConta(this.saceDataSet.tb_plano_conta, int.Parse(txtTexto.Text));
                   
                //else
                    //this.tb_plano_contaTableAdapter.FillByDescricao(this.saceDataSet.tb_plano_conta, txtTexto.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void tb_plano_contaDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            codPlanoConta = int.Parse(tb_plano_contaDataGridView.SelectedRows[0].Cells[0].Value.ToString());
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
                tb_plano_contaBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                tb_plano_contaBindingSource.MovePrevious();
            }
        }

        public Int32 getCodPlanoConta()
        {
            return codPlanoConta;
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }

        private void tb_plano_contaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tb_plano_contaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.saceDataSet);

        }
    }
}
