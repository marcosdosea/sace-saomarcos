using Dados;
using Negocio;

namespace Sace
{
    public partial class FrmCalcularVendasPorVendedor : Form
    {

        private readonly GerenciadorSaida gerenciadorSaida;
        public FrmCalcularVendasPorVendedor(SaceContext context)
        {
            InitializeComponent();
            dateTimeInicial.Value = DateTime.Now.AddMonths(-1);
            gerenciadorSaida = new GerenciadorSaida(context);
        }

        private void FrmCalcularVendasPorVendedor_KeyDown(object sender, KeyEventArgs e)
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
            vendasVendedorBindingSource.DataSource = gerenciadorSaida.ObterVendasPorVendedor(dataInicial, dataFinal);
            Cursor.Current = Cursors.Default; 
        }

    }
}
