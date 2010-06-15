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
    public partial class FrmGrupoContaPesquisa : Form
    {
        private Int32 codGrupoConta;

        public FrmGrupoContaPesquisa()
        {
            InitializeComponent();
            codGrupoConta = -1;
        }

        private void FrmGrupoContaPesquisa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'saceDataSet.tb_grupo_conta' table. You can move, or remove it, as needed.
            this.tb_grupo_contaTableAdapter.Fill(this.saceDataSet.tb_grupo_conta);
            cmbBusca.SelectedIndex = 0;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                //    this.tb_grupo_contaTableAdapter.FillByCodTipoConta(this.saceDataSet.tb_grupo_conta, int.Parse(txtTexto.Text));
                   
                //else
                //    this.tb_grupo_contaTableAdapter.FillByDescricao(this.saceDataSet.tb_grupo_conta, txtTexto.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void tb_grupo_contaDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            codGrupoConta = int.Parse(tb_grupo_contaDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            this.Close();
        }

        private void FrmGrupoContaPesquisa_KeyDown(object sender, KeyEventArgs e)
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
                tb_grupo_contaBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                tb_grupo_contaBindingSource.MovePrevious();
            }
        }

        public Int32 getCodTipoConta()
        {
            return codGrupoConta;
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }
    }
}
