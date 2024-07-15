using System;
using System.Windows.Forms;
using Dados;
using Microsoft.EntityFrameworkCore;
using Negocio;

namespace Sace
{
    public partial class FrmMovimentacaoCaixaRecebido: Form
    {
        private readonly SaceService service;
        private readonly DbContextOptions<SaceContext> saceOptions;

        public FrmMovimentacaoCaixaRecebido(DateTime dataInicio, DateTime dataFim, DbContextOptions<SaceContext> saceOptions)
        {
            InitializeComponent();
            dataInicioDateTimePicker.Value = dataInicio;
            dataFinalDateTimePicker.Value = dataFim;
            this.saceOptions = saceOptions;
            SaceContext context = new SaceContext(saceOptions);
            service = new SaceService(context);
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
