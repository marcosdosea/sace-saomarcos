using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Dominio;

namespace Sace
{
    public partial class FrmEntradaPesquisa : Form
    {
        public Entrada EntradaSelected { get; set; } 

        public FrmEntradaPesquisa()
        {
            InitializeComponent();
            EntradaSelected = null;
        }

        private void FrmEntradaPesquisa_Load(object sender, EventArgs e)
        {
            cmbBusca.SelectedIndex = 0;
        }



          private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtTexto.Text.Equals("")) {
                    if (cmbBusca.SelectedIndex == 0) 
                        entradaBindingSource.DataSource = GerenciadorEntrada.GetInstance().Obter(long.Parse(txtTexto.Text));
                    else if (cmbBusca.SelectedIndex == 1)
                        entradaBindingSource.DataSource = GerenciadorEntrada.GetInstance().ObterPorNumeroNotaFiscal(txtTexto.Text);
                    else
                        entradaBindingSource.DataSource = GerenciadorEntrada.GetInstance().ObterPorNomeFornecedor(txtTexto.Text);
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void tb_entradaDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (tb_entradaDataGridView.SelectedRows.Count > 0)
            {
                EntradaSelected = (Entrada) entradaBindingSource.Current;
            }
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
                entradaBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                entradaBindingSource.MovePrevious();
            }
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }

    }
}
