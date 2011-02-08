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
    public partial class FrmBancoPesquisa : Form
    {
        private Int32 codBanco;

        public Int32 CodBanco
        {
            get { return codBanco; }
            set { codBanco = value; }
        }

        public FrmBancoPesquisa()
        {
            InitializeComponent();
            codBanco = -1;
        }

        private void FrmBancoPesquisa_Load(object sender, EventArgs e)
        {
            this.tb_bancoTableAdapter.Fill(this.saceDataSet.tb_banco);
            cmbBusca.SelectedIndex = 0;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                this.tb_bancoTableAdapter.FillByCodBanco(this.saceDataSet.tb_banco, int.Parse(txtTexto.Text));
            else
                this.tb_bancoTableAdapter.FillByNome(this.saceDataSet.tb_banco, txtTexto.Text);

        }

        private void tb_bancoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            codBanco = int.Parse(tb_bancoDataGridView.SelectedRows[0].Cells[0].Value.ToString());
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
                tb_bancoBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                tb_bancoBindingSource.MovePrevious();
            }
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }
    }
}
