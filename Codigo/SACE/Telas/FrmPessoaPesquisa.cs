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
    public partial class FrmPessoaPesquisa : Form
    {
        private Int32 codPessoa;

        public FrmPessoaPesquisa()
        {
            InitializeComponent();
            codPessoa = -1;
        }

        private void FrmPessoaPesquisa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'saceDataSet.tb_pessoa' table. You can move, or remove it, as needed.
            this.tb_pessoaTableAdapter.Fill(this.saceDataSet.tb_pessoa);
            cmbBusca.SelectedIndex = 0;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                //    this.tb_pessoaTableAdapter.FillByCodPessoa(this.saceDataSet.tb_pessoa, int.Parse(txtTexto.Text));
                //else if ((cmbBusca.SelectedIndex == 2) && !txtTexto.Text.Equals(""))
                //    this.tb_pessoaTableAdapter.FillByCPF(this.saceDataSet.tb_pessoa, txtTexto.Text);
                //else if ((cmbBusca.SelectedIndex == 3) && !txtTexto.Text.Equals(""))
                //    this.tb_pessoaTableAdapter.FillByEndereco(this.saceDataSet.tb_pessoa, txtTexto.Text);
                //else if ((cmbBusca.SelectedIndex == 4) && !txtTexto.Text.Equals(""))
                //    this.tb_pessoaTableAdapter.FillByBairro(this.saceDataSet.tb_pessoa, txtTexto.Text);          
                //else
                //    this.tb_pessoaTableAdapter.FillByNome(this.saceDataSet.tb_pessoa, txtTexto.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void tb_pessoaDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            codPessoa = int.Parse(tb_pessoaDataGridView.SelectedRows[0].Cells[2].Value.ToString());
            this.Close();
        }

        private void FrmPessoaPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_pessoaDataGridView_CellClick(sender, null);
            } 
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            } 
            else if ((e.KeyCode == Keys.Down) && (txtTexto.Focused))
            {
                tb_pessoaBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                tb_pessoaBindingSource.MovePrevious();
            }
        }

        public Int32 getCodPessoa()
        {
            return codPessoa;
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }

    }
}
