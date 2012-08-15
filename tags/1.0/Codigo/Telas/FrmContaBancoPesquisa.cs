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
    public partial class FrmContaBancoPesquisa : Form
    {
        private String codContaBanco;

        public String CodContaBanco
        {
            get { return codContaBanco; }
            set { codContaBanco = value; }
        }

        public FrmContaBancoPesquisa()
        {
            InitializeComponent();
            codContaBanco = "";
        }

        private void FrmBancoPesquisa_Load(object sender, EventArgs e)
        {
            this.tb_conta_bancoTableAdapter.Fill(this.saceDataSet.tb_conta_banco);
            cmbBusca.SelectedIndex = 1;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if ((cmbBusca.SelectedIndex == 0) && !txtTexto.Text.Equals(""))
                this.tb_conta_bancoTableAdapter.FillByNumeroConta(this.saceDataSet.tb_conta_banco, txtTexto.Text);
            else
                this.tb_conta_bancoTableAdapter.FillByDescricao(this.saceDataSet.tb_conta_banco, txtTexto.Text);                
            
        }

        private void tb_bancoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            codContaBanco = tb_conta_bancoDataGridView.SelectedRows[0].Cells[0].Value.ToString();
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

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }
    }
}
