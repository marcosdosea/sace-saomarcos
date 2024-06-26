using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Negocio;

namespace Sace
{
    public partial class FrmGrupoContaPesquisa : Form
    {
        public GrupoConta GrupoConta { get; set; }
        private readonly SaceService service;
        private readonly DbContextOptions<SaceContext> saceOptions;

        public FrmGrupoContaPesquisa(DbContextOptions<SaceContext> saceOptions)
        {
            InitializeComponent();
            GrupoConta = null;
            this.saceOptions = saceOptions; 
            SaceContext context = new SaceContext(saceOptions);
            this.service = new SaceService(context);
        }

        private void FrmGrupoContaPesquisa_Load(object sender, EventArgs e)
        {
            grupoContaBindingSource.DataSource = service.GerenciadorGrupoConta.ObterTodos();
            cmbBusca.SelectedIndex = 0;
        }

        private void txtTexto_TextChanged(object sender, EventArgs e)
        {
            if ((cmbBusca.SelectedIndex == 1) && !txtTexto.Text.Equals(""))
               grupoContaBindingSource.DataSource = service.GerenciadorGrupoConta.Obter(Convert.ToInt32(txtTexto.Text));
            else
              grupoContaBindingSource.DataSource = service.GerenciadorGrupoConta.ObterPorDescricao(txtTexto.Text);
         }

        private void tb_grupo_contaDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GrupoConta = (GrupoConta) grupoContaBindingSource.Current;
            this.Close();
        }

        private void FrmGrupoContaPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tb_grupo_contaDataGridView_CellClick(sender, null);
            } 
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            } 
            else if ((e.KeyCode == Keys.Down) && (txtTexto.Focused))
            {
                grupoContaBindingSource.MoveNext();
            }
            else if ((e.KeyCode == Keys.Up) && (txtTexto.Focused))
            {
                grupoContaBindingSource.MovePrevious();
            }
        }

        private void cmbBusca_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTexto.Text = "";
        }
    }
}
