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
    public partial class FrmContaBancoPesquisa : Form
    {
        private Int32 codContaBanco;

        public FrmContaBancoPesquisa()
        {
            InitializeComponent();
            codContaBanco = -1;
        }

        private void FrmBancoPesquisa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'saceDataSet.tb_conta_banco' table. You can move, or remove it, as needed.
            this.tb_conta_bancoTableAdapter.Fill(this.saceDataSet.tb_conta_banco);
            cmbBusca.SelectedIndex = 0;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                //    this.tb_conta_bancoTableAdapter.FillByDescricao(this.saceDataSet.tb_conta_banco, txtTexto.Text);
                //else
                //    this.tb_conta_bancoTableAdapter.FillByConta(this.saceDataSet.tb_conta_banco, txtTexto.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void tb_bancoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            codContaBanco = int.Parse(tb_conta_bancoDataGridView.SelectedRows[0].Cells[0].Value.ToString());
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
                tb_conta_bancoBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                tb_conta_bancoBindingSource.MovePrevious();
            }
        }

        public Int32 getCodContaBanco()
        {
            return codContaBanco;
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }
    }
}
