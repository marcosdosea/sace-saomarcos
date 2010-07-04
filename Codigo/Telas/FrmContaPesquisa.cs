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
    public partial class FrmContaPesquisa : Form
    {
        private int codConta;

        public FrmContaPesquisa()
        {
            InitializeComponent();
            codConta = -1;
        }

        public int getCodConta()
        {
            return codConta;
        }

        private void FrmContaPesquisa_Load(object sender, EventArgs e)
        {
            this.tb_contaTableAdapter.Fill(this.saceDataSet.tb_conta);
            cmbBusca.SelectedIndex = 0;
        }

        private void tb_grupo_contaDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            codConta = int.Parse(tb_contaDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            this.Close();
        }

        private void FrmContaPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_grupo_contaDataGridView_CellClick(sender, null);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if ((e.KeyCode == Keys.Down) && (txtTexto.Focused))
            {
                tb_contaBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                tb_contaBindingSource.MovePrevious();
            }
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if ((cmbBusca.SelectedIndex == 0) && !txtTexto.Text.Equals(""))
                this.tb_contaTableAdapter.FillByCodConta(this.saceDataSet.tb_conta, int.Parse(txtTexto.Text), null);
            else if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                this.tb_contaTableAdapter.FillByCodPessoa(this.saceDataSet.tb_conta, int.Parse(txtTexto.Text), null);
            else if ((cmbBusca.SelectedIndex == 2) && !txtTexto.Text.Equals(""))
                this.tb_contaTableAdapter.FillByCodEntrada(this.saceDataSet.tb_conta, int.Parse(txtTexto.Text), null);
            else if ((cmbBusca.SelectedIndex == 3) && !txtTexto.Text.Equals(""))
                this.tb_contaTableAdapter.FillByCodSaida(this.saceDataSet.tb_conta, int.Parse(txtTexto.Text), null);
        }
    }
}
