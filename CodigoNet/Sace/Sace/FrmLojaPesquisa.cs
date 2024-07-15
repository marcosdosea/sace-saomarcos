using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Negocio;

namespace Sace
{
    public partial class FrmLojaPesquisa : Form
    {
        public Loja LojaSelected { get; set; }

        public FrmLojaPesquisa()
        {
            InitializeComponent();
            LojaSelected = null;
        }

        private void FrmLojaPesquisa_Load(object sender, EventArgs e)
        {
            lojaBindingSource.DataSource = GerenciadorLoja.ObterTodos();
            cmbBusca.SelectedIndex = 0;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                lojaBindingSource.DataSource = GerenciadorLoja.Obter(int.Parse(txtTexto.Text));

            else
                lojaBindingSource.DataSource = GerenciadorLoja.ObterPorNome(txtTexto.Text);
        }

        private void tb_lojaDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LojaSelected = (Loja)lojaBindingSource.Current;
            this.Close();
        }

        private void FrmLojaPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_lojaDataGridView_CellClick(sender, null);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if ((e.KeyCode == Keys.Down) && (txtTexto.Focused))
            {
                lojaBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                lojaBindingSource.MovePrevious();
            }
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }
    }
}