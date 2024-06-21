using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Negocio;

namespace Sace
{
    public partial class FrmEntradaPesquisa : Form
    {
        public Entrada EntradaSelected { get; set; }

        private readonly GerenciadorEntrada gerenciadorEntrada;
        public FrmEntradaPesquisa(SaceContext context)
        {
            InitializeComponent();
            EntradaSelected = null;
            gerenciadorEntrada = new GerenciadorEntrada(context);
        }

        private void FrmEntradaPesquisa_Load(object sender, EventArgs e)
        {
            cmbBusca.SelectedIndex = 0;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!txtTexto.Text.Equals(""))
                {
                    if (cmbBusca.SelectedIndex == 0)
                        entradaBindingSource.DataSource = gerenciadorEntrada.Obter(long.Parse(txtTexto.Text));
                    else if (cmbBusca.SelectedIndex == 1)
                        entradaBindingSource.DataSource = gerenciadorEntrada.ObterPorNumeroNotaFiscal(txtTexto.Text);
                    else
                        entradaBindingSource.DataSource = gerenciadorEntrada.ObterPorNomeFornecedor(txtTexto.Text);
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
                EntradaSelected = (Entrada)entradaBindingSource.Current;
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
