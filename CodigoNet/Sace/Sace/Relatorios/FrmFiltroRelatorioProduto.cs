using Dados;
using Microsoft.EntityFrameworkCore;
using Negocio;
using Sace.Relatorios.Produtos;

namespace Sace.Relatorios
{
    public partial class FrmFiltroRelatorioProduto : Form
    {
        private readonly SaceService service;
        private readonly DbContextOptions<SaceContext> saceOptions;

        public FrmFiltroRelatorioProduto(DbContextOptions<SaceContext> saceOptions)
        {
            InitializeComponent();
            this.saceOptions = saceOptions;
            SaceContext context = new SaceContext(saceOptions);
            this.service = new SaceService(context);
        }

        private void FrmFiltroRelatorioProduto_Load(object sender, EventArgs e)
        {
            codPessoaComboBox.DataSource = service.GerenciadorPessoa.ObterTodos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            long codPessoa = Convert.ToInt64(codPessoaComboBox.SelectedValue.ToString());
            decimal lucro = Convert.ToDecimal(lucroTextBox.Text);
            FrmRelProdutosRevenda relatorio = new FrmRelProdutosRevenda(codPessoa, lucro, saceOptions);
            relatorio.ShowDialog();
            relatorio.Dispose();
        }

        private void FrmFiltroRelatorioProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F8)
            {
                btnImprimir_Click(sender, e);
            }
        }

        private void codPessoaComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = Char.Parse(e.KeyChar.ToString().ToUpper());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
