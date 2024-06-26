using Dados;
using Dominio;
using Negocio;

namespace Sace
{
    public partial class FrmSubgrupoPesquisa : Form
    {
        public Subgrupo SubgrupoSelected { get; set; }
        public Grupo GrupoSelected { get; set; }

        private readonly GerenciadorSubgrupo gerenciadorSubgrupo;
        private readonly GerenciadorGrupo gerenciadorGrupo;
        public FrmSubgrupoPesquisa(SaceContext context)
        {
            InitializeComponent();
            SubgrupoSelected = null;
            GrupoSelected = null;
            gerenciadorSubgrupo = new GerenciadorSubgrupo(context);
            gerenciadorGrupo = new GerenciadorGrupo(context);
        }

        private void FrmSubgrupoPesquisa_Load(object sender, EventArgs e)
        {
            subgrupoBindingSource.DataSource = gerenciadorSubgrupo.ObterTodos();
            cmbBusca.SelectedIndex = 1;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if ((cmbBusca.SelectedIndex == 0) && !txtTexto.Text.Equals(""))
                subgrupoBindingSource.DataSource = gerenciadorSubgrupo.Obter(Convert.ToInt32(txtTexto.Text));
            else if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                subgrupoBindingSource.DataSource = gerenciadorSubgrupo.ObterPorDescricao(txtTexto.Text);                
            else if ((cmbBusca.SelectedIndex == 2) && !txtTexto.Text.Equals(""))
                subgrupoBindingSource.DataSource = gerenciadorSubgrupo.ObterPorDescricaoGrupo(txtTexto.Text);
            
        }

        private void tb_bancoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SubgrupoSelected = (Subgrupo) subgrupoBindingSource.Current;
            GrupoSelected = gerenciadorGrupo.Obter(SubgrupoSelected.CodGrupo).ElementAt(0);
            this.Close();
        }

        private void FrmSubgrupoPesquisa_KeyDown(object sender, KeyEventArgs e)
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
                subgrupoBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                subgrupoBindingSource.MovePrevious();
            }
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }
    }
}
