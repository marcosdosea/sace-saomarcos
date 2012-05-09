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
    public partial class FrmSubgrupoPesquisa : Form
    {
        public Int32 CodSubgrupo { get; set; }

        public FrmSubgrupoPesquisa()
        {
            InitializeComponent();
            CodSubgrupo = -1;
        }

        private void FrmSubgrupoPesquisa_Load(object sender, EventArgs e)
        {
            this.tb_subgrupoTableAdapter.Fill(this.saceDataSet.tb_subgrupo);
            cmbBusca.SelectedIndex = 1;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if ((cmbBusca.SelectedIndex == 0) && !txtTexto.Text.Equals(""))
                this.tb_subgrupoTableAdapter.FillByCodSubgrupo(this.saceDataSet.tb_subgrupo, Convert.ToInt32(txtTexto.Text));
            else
                this.tb_subgrupoTableAdapter.FillByDescricao(this.saceDataSet.tb_subgrupo, txtTexto.Text);                
            
        }

        private void tb_bancoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CodSubgrupo = Convert.ToInt32(tb_subgrupoDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            this.Close();
        }

        private void FrmSubgrupoPesquisa_KeyDown(object sender, KeyEventArgs e)
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
                tb_subgrupoBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                tb_subgrupoBindingSource.MovePrevious();
            }
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }
    }
}
