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
    public partial class FrmEmpresaPesquisa : Form
    {
        private Int32 codEmpresa;

        public FrmEmpresaPesquisa()
        {
            InitializeComponent();
            codEmpresa = -1;
        }

        private void FrmEmpresaPesquisa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'saceDataSet.tb_empresa' table. You can move, or remove it, as needed.
            this.tb_empresaTableAdapter.Fill(this.saceDataSet.tb_empresa);
            cmbBusca.SelectedIndex = 0;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                //    this.tb_empresaTableAdapter.FillByCodigoEmpresa(this.saceDataSet.tb_empresa, int.Parse(txtTexto.Text));
                //else if ((cmbBusca.SelectedIndex == 2) && !txtTexto.Text.Equals(""))
                //    this.tb_empresaTableAdapter.FillByCnpj(this.saceDataSet.tb_empresa, txtTexto.Text);
                //else
                //    this.tb_empresaTableAdapter.FillByNome(this.saceDataSet.tb_empresa, txtTexto.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void tb_empresaDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            codEmpresa = int.Parse(tb_empresaDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            this.Close();
        }

        private void FrmEmpresaPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_empresaDataGridView_CellClick(sender, null);
            } 
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            } 
            else if ((e.KeyCode == Keys.Down) && (txtTexto.Focused))
            {
                tb_empresaBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                tb_empresaBindingSource.MovePrevious();
            }
        }

        public Int32 getCodEmpresa()
        {
            return codEmpresa;
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }
    }
}
