using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Negocio;

namespace Sace
{
    public partial class FrmSubgrupoPesquisa : Form
    {
        public Subgrupo SubgrupoSelected { get; set; }
        public Grupo GrupoSelected { get; set; }

        private readonly SaceService service;
        private readonly DbContextOptions<SaceContext> saceOptions;
        public FrmSubgrupoPesquisa(DbContextOptions<SaceContext> saceOptions)
        {
            InitializeComponent();
            SubgrupoSelected = null;
            GrupoSelected = null;
            this.saceOptions = saceOptions;
            SaceContext context = new SaceContext(saceOptions);
            this.service = new SaceService(context);
        }

        private void FrmSubgrupoPesquisa_Load(object sender, EventArgs e)
        {
            subgrupoBindingSource.DataSource = service.GerenciadorSubgrupo.ObterTodos();
            cmbBusca.SelectedIndex = 1;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if ((cmbBusca.SelectedIndex == 0) && !txtTexto.Text.Equals(""))
                subgrupoBindingSource.DataSource = service.GerenciadorSubgrupo.Obter(Convert.ToInt32(txtTexto.Text));
            else if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
                subgrupoBindingSource.DataSource = service.GerenciadorSubgrupo.ObterPorDescricao(txtTexto.Text);                
            else if ((cmbBusca.SelectedIndex == 2) && !txtTexto.Text.Equals(""))
                subgrupoBindingSource.DataSource = service.GerenciadorSubgrupo.ObterPorDescricaoGrupo(txtTexto.Text);
            
        }

        private void tb_bancoDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SubgrupoSelected = (Subgrupo) subgrupoBindingSource.Current;
            GrupoSelected = service.GerenciadorGrupo.Obter(SubgrupoSelected.CodGrupo).ElementAt(0);
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
