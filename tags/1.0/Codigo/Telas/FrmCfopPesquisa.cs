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
    public partial class FrmCfopPesquisa : Form
    {
        public Int32 CodCfop { get; set; }

        public FrmCfopPesquisa()
        {
            InitializeComponent();
            CodCfop = -1;
        }

        private void FrmCfopPesquisa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'saceDataSet.tb_cfop' table. You can move, or remove it, as needed.
            this.tb_cfopTableAdapter.Fill(this.saceDataSet.tb_cfop);
            cmbBusca.SelectedIndex = 0;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                this.tb_cfopTableAdapter.FillByCodCfop(this.saceDataSet.tb_cfop, Convert.ToInt32(txtTexto.Text));
            else
                this.tb_cfopTableAdapter.FillByDescricao(this.saceDataSet.tb_cfop, txtTexto.Text);
        }

        private void tb_cfopDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CodCfop = int.Parse(tb_cfopDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            this.Close();
        }

        private void FrmCfopPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_cfopDataGridView_CellClick(sender, null);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if ((e.KeyCode == Keys.Down) && (txtTexto.Focused))
            {
                tb_cfopBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                tb_cfopBindingSource.MovePrevious();
            }
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }

        private void tb_cfopBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tb_cfopBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.saceDataSet);

        }
    }
}
