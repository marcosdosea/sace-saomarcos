using Dados;
using Dominio;
using Negocio;

namespace Sace
{
    public partial class FrmCalculoParticipacao : Form
    {
        private readonly GerenciadorSaida gerenciadorSaida;
 
        public FrmCalculoParticipacao(SaceContext context)
        {
            InitializeComponent();
            gerenciadorSaida = new GerenciadorSaida(context);
        }

        private void FrmCalculoParticipacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor; 
            DateTime dataInicial = dateTimeInicial.Value;
            DateTime dataFinal = dateTimeFinal.Value;
            decimal valorMinimoVenda = 0;
            decimal.TryParse(textValorVenda.Text, out valorMinimoVenda);
            int numeroFuncionarios = 0;
            int.TryParse(textFuncionarios.Text, out numeroFuncionarios);
            decimal avaliacaoClientes = 0;
            decimal.TryParse(textAvaliacaoClientes.Text, out avaliacaoClientes);
            decimal metaVendas = 0;
            decimal.TryParse(textMetaVendas.Text, out metaVendas);
            
            List<Saida> saidas = gerenciadorSaida.ObterVendasParticipacaoLucros(dataInicial, dataFinal, valorMinimoVenda);
            decimal lucroBruto = saidas.Sum(s => s.TotalLucro);

            decimal descontoAvaliacaoClientes = avaliacaoClientes / 5;
            decimal descontoMetaVendas = metaVendas / 100;

            decimal valorParticipacao = lucroBruto * new Decimal(0.01);
            valorParticipacao *= descontoAvaliacaoClientes;
            valorParticipacao *= descontoMetaVendas;
            textValorCalculado.Text = (valorParticipacao / numeroFuncionarios).ToString("N2");
            Cursor.Current = Cursors.Default; 
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
