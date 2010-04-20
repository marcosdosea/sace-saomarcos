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
    public partial class FrmProdutoPesquisa : Form
    {
        private Int32 codProduto;

        public FrmProdutoPesquisa()
        {
            InitializeComponent();
            codProduto = -1;
        }

        private void FrmProdutoPesquisa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'saceDataSet.tb_produto' table. You can move, or remove it, as needed.
            this.tb_produtoTableAdapter.Fill(this.saceDataSet.tb_produto);
            cmbBusca.SelectedIndex = 0;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                //    this.tb_produtoTableAdapter.FillByCodProduto(this.saceDataSet.tb_produto, int.Parse(txtTexto.Text));
                   
                //else
                //    this.tb_produtoTableAdapter.FillByNome(this.saceDataSet.tb_produto, txtTexto.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void tb_produtoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            codProduto = int.Parse(tb_produtoDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            this.Close();
        }

        private void FrmProdutoPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_produtoDataGridView_CellClick(sender, null);
            } 
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            } 
            else if ((e.KeyCode == Keys.Down) && (txtTexto.Focused))
            {
                tb_produtoBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                tb_produtoBindingSource.MovePrevious();
            }
        }

        public Int32 getCodProduto()
        {
            return codProduto;
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }

        private void tb_produtoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tb_produtoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.saceDataSet);

        }
    }
}
