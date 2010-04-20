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
    public partial class FrmGrupoPesquisa : Form
    {
        private Int32 codGrupo;

        public FrmGrupoPesquisa()
        {
            InitializeComponent();
            codGrupo = -1;
        }

        private void FrmGrupoPesquisa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'saceDataSet.tb_grupo' table. You can move, or remove it, as needed.
            this.tb_grupoTableAdapter.Fill(this.saceDataSet.tb_grupo);
            cmbBusca.SelectedIndex = 0;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                //    this.tb_grupoTableAdapter.FillByCodGrupo(this.saceDataSet.tb_grupo, long.Parse(txtTexto.Text));
                   
                //else
                //    this.tb_grupoTableAdapter.FillByDescricao(this.saceDataSet.tb_grupo, txtTexto.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void tb_grupoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            codGrupo = int.Parse(tb_grupoDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            this.Close();
        }

        private void FrmGrupoPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_grupoDataGridView_CellClick(sender, null);
            } 
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            } 
            else if ((e.KeyCode == Keys.Down) && (txtTexto.Focused))
            {
                tb_grupoBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                tb_grupoBindingSource.MovePrevious();
            }
        }

        public Int32 getCodGrupo()
        {
            return codGrupo;
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }

        private void tb_grupoBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tb_grupoBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.saceDataSet);

        }
    }
}
