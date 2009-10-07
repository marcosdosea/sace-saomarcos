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
    public partial class FrmLojaPesquisa : Form
    {
        private Int32 codLoja;

        public FrmLojaPesquisa()
        {
            InitializeComponent();
            codLoja = -1;
        }

        private void FrmLojaPesquisa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'saceDataSet.tb_loja' table. You can move, or remove it, as needed.
            this.tb_lojaTableAdapter.Fill(this.saceDataSet.tb_loja);
            cmbBusca.SelectedIndex = 0;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                //    this.tb_lojaTableAdapter.FillByCodLoja(this.saceDataSet.tb_loja, int.Parse(txtTexto.Text));
                   
                //else
                //    this.tb_lojaTableAdapter.FillByNome(this.saceDataSet.tb_loja, txtTexto.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void tb_lojaDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            codLoja = int.Parse(tb_lojaDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            this.Close();
        }

        private void FrmLojaPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_lojaDataGridView_CellClick(sender, null);
            } 
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            } 
            else if ((e.KeyCode == Keys.Down) && (txtTexto.Focused))
            {
                tb_lojaBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                tb_lojaBindingSource.MovePrevious();
            }
        }

        public Int32 getCodLoja()
        {
            return codLoja;
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }
    }
}
