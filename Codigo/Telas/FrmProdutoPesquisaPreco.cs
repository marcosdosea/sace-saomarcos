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
    public partial class FrmProdutoPesquisaPreco : Form
    {
        private Int32 codProduto;
        private String filtroNome;

        public Int32 CodProduto
        {
            get { return codProduto; }
            set { codProduto = value; }
        }

        public FrmProdutoPesquisaPreco()
        {
            InitializeComponent();
            codProduto = -1;
            filtroNome = null;
        }

        public FrmProdutoPesquisaPreco(String nome)
        {
            InitializeComponent();
            codProduto = -1;
            filtroNome = nome;
        }

        private void FrmProdutoPesquisaPreco_Load(object sender, EventArgs e)
        {
            cmbBusca.SelectedIndex = 0;

            if (filtroNome != null)
            {
                txtTexto.Text = filtroNome;
                txtTexto.Select(filtroNome.Length + 1, filtroNome.Length + 1);
            }
            else
            {
                this.tb_produtoTableAdapter.Fill(this.saceDataSet.tb_produto);
            }
            
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
               this.tb_produtoTableAdapter.FillByCodProduto(this.saceDataSet.tb_produto, int.Parse(txtTexto.Text));
            else
               this.tb_produtoTableAdapter.FillByNome(this.saceDataSet.tb_produto, txtTexto.Text);
        }

        private void tb_produtoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            codProduto = int.Parse(tb_produtoDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            this.Close();
        }

        private void FrmProdutoPesquisaPreco_KeyDown(object sender, KeyEventArgs e)
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
