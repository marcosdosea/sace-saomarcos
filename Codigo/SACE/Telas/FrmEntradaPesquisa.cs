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
    public partial class FrmEntradaPesquisa : Form
    {
        private Int64 codEntrada;

        public FrmEntradaPesquisa()
        {
            InitializeComponent();
            codEntrada = -1;
        }

        private void FrmEntradaPesquisa_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'saceDataSet.tb_entrada' table. You can move, or remove it, as needed.
            this.tb_entradaTableAdapter.Fill(this.saceDataSet.tb_entrada);
            // TODO: This line of code loads data into the 'saceDataSet.tb_entrada' table. You can move, or remove it, as needed.
            cmbBusca.SelectedIndex = 0;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                //    this.tb_entradaTableAdapter.FillByCodEntrada(this.saceDataSet.tb_entrada, int.Parse(txtTexto.Text));
                   
                //else
                //    this.tb_entradaTableAdapter.FillByNome(this.saceDataSet.tb_entrada, txtTexto.Text);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void tb_entradaDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            codEntrada = int.Parse(tb_entradaDataGridView.SelectedRows[0].Cells[0].Value.ToString());
            this.Close();
        }

        private void FrmEntradaPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_entradaDataGridView_CellClick(sender, null);
            } 
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            } 
            else if ((e.KeyCode == Keys.Down) && (txtTexto.Focused))
            {
                tb_entradaBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                tb_entradaBindingSource.MovePrevious();
            }
        }

        public Int64 getCodEntrada()
        {
            return codEntrada;
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }

        private void tb_entradaBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tb_entradaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.saceDataSet);

        }
    }
}
