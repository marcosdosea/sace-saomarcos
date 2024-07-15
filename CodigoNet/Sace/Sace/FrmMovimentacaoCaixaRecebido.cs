using Negocio;

namespace Sace
{
    public partial class FrmMovimentacaoCaixaRecebido: Form
    {

        public FrmMovimentacaoCaixaRecebido(DateTime dataInicio, DateTime dataFim)
        {
            InitializeComponent();
            dataInicioDateTimePicker.Value = dataInicio;
            dataFinalDateTimePicker.Value = dataFim;
        }

        private void FrmSaidaPagamentoRecebido_Load(object sender, EventArgs e)
        {

            movimentacaoPeriodoBindingSource.DataSource = GerenciadorMovimentacaoConta.ObterMovimentacaoContaPeriodo(dataInicioDateTimePicker.Value, dataFinalDateTimePicker.Value);
           
        }


        private void FrmSaidaPagamentoRecebido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            } 
            else if (e.KeyCode == Keys.F9)
            {
               // btnEstatistica_Click(sender, e);
            }
        }


     
    }
}
