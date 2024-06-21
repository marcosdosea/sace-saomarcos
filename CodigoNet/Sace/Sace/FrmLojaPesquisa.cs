using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Negocio;

namespace Sace
{
    public partial class FrmLojaPesquisa : Form
    {
        public Loja LojaSelected { get; set; }
        private readonly GerenciadorLoja gerenciadorLoja;

        public FrmLojaPesquisa(SaceContext context)
        {
            InitializeComponent();
            LojaSelected = null;
            gerenciadorLoja = new GerenciadorLoja(context);
        }

        private void FrmLojaPesquisa_Load(object sender, EventArgs e)
        {
            lojaBindingSource.DataSource = gerenciadorLoja.ObterTodos();
            cmbBusca.SelectedIndex = 0;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                lojaBindingSource.DataSource = gerenciadorLoja.Obter(int.Parse(txtTexto.Text));

            else
                lojaBindingSource.DataSource = gerenciadorLoja.ObterPorNome(txtTexto.Text);
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