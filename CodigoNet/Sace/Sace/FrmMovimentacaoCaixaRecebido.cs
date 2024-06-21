using System;
using System.Windows.Forms;
using Dados;
using Microsoft.EntityFrameworkCore;
using Negocio;

namespace Sace
{
    public partial class FrmMovimentacaoCaixaRecebido: Form
    {

        private readonly GerenciadorMovimentacaoConta gerenciadorMovimentacaoConta;
        public FrmMovimentacaoCaixaRecebido(DateTime dataInicio, DateTime dataFim, SaceContext context)
        {
            InitializeComponent();
            dataInicioDateTimePicker.Value = dataInicio;
            dataFinalDateTimePicker.Value = dataFim;
            gerenciadorMovimentacaoConta = new GerenciadorMovimentacaoConta(context);
        }

        private void FrmSaidaPagamentoRecebido_Load(object sender, EventArgs e)
        {

            movimentacaoPeriodoBindingSource.DataSource = gerenciadorMovimentacaoConta.ObterMovimentacaoContaPeriodo(dataInicioDateTimePicker.Value, dataFinalDateTimePicker.Value);
           
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
