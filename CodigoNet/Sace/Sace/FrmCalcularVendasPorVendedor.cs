using Dados;
using Microsoft.EntityFrameworkCore;
using Negocio;

namespace Sace
{
    public partial class FrmCalcularVendasPorVendedor : Form
    {

        private readonly SaceService service;
        private readonly DbContextOptions<SaceContext> saceOptions;
        public FrmCalcularVendasPorVendedor(DbContextOptions<SaceContext> saceOptions)
        {
            InitializeComponent();
            dateTimeInicial.Value = DateTime.Now.AddMonths(-1);
            this.saceOptions = saceOptions;
            SaceContext context = new SaceContext();
            SaceService service = new SaceService(context);
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
            vendasVendedorBindingSource.DataSource = service.GerenciadorSaida.ObterVendasPorVendedor(dataInicial, dataFinal);
            Cursor.Current = Cursors.Default; 
        }

    }
}
