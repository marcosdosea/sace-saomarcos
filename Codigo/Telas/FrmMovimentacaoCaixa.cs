using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Negocio;
using Dominio.Consultas;

namespace Telas
{
    public partial class FrmMovimentacaoCaixa : Form
    {
        public FrmMovimentacaoCaixa()
        {
            InitializeComponent();
            contaBancoBindingSource.DataSource = GerenciadorContaBanco.GetInstance().ObterTodos();
            dateTimePickerFinal.Value = DateTime.Now;
            dateTimePickerInicial.Value = DateTime.Now;            
            ObterMovimentacaoPeriodo();
        }

        /// <summary>
        /// Obtém movimentações da conta / caixa no período especificado
        /// </summary>
        private void ObterMovimentacaoPeriodo()
        {
            DateTime dataInicial = dateTimePickerInicial.Value.Date;
            DateTime dataFinal = dateTimePickerFinal.Value.Date;
            dataFinal = dataFinal.AddMinutes(24 * 60);
            
            int codContaBanco = (int) codContaBancoComboBox.SelectedValue;

            IEnumerable<TotaisMovimentacaoConta> totaisMovimentacaoConta = GerenciadorMovimentacaoConta.GetInstance(null).ObterTotalMovimentacaoContaPeriodo(codContaBanco, dataInicial, dataFinal);
            totaisMovimentacaoContaBindingSource.DataSource = totaisMovimentacaoConta;
            textTotalMovimentacao.Text = totaisMovimentacaoConta.Sum(t => t.TotalMovimentacaoConta).ToString("N2");

            IEnumerable<TotalPagamentoSaida> totaisSaida = GerenciadorSaidaPagamento.GetInstance(null).ObterTotalPagamentoSaida(dataInicial, dataFinal);
            totaisSaidaBindingSource.DataSource = totaisSaida;
            
            decimal trocoPorPeriodo = GerenciadorSaida.GetInstance(null).ObterTrocoPorPeriodo(dataInicial, dataFinal);
            textTroco.Text = trocoPorPeriodo.ToString("N2");

            textTotalVendas.Text = (totaisSaida.Sum(t => t.TotalPagamento) - trocoPorPeriodo).ToString("N2");

            IEnumerable<VendasCartao> vendasCartao = GerenciadorSaidaPagamento.GetInstance(null).ObterVendasCartao(dataInicial, dataFinal);
            VendasCartaoBindingSource.DataSource = vendasCartao;
            textTotalCartao.Text = vendasCartao.Sum(t => t.TotalCartao).ToString("N2");
        }

        private void dateTimePickerInicial_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmMovimentacaoCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            ObterMovimentacaoPeriodo();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
