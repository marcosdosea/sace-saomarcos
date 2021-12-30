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
using Dominio;
using Util;

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
            dataFinal = dataFinal.AddDays(1).AddSeconds(-1);

            int codContaBanco = (int)codContaBancoComboBox.SelectedValue;

            IEnumerable<TotaisMovimentacaoConta> totaisMovimentacaoConta = GerenciadorMovimentacaoConta.GetInstance(null).ObterTotalMovimentacaoContaPeriodo(codContaBanco, dataInicial, dataFinal);
            totaisMovimentacaoContaBindingSource.DataSource = totaisMovimentacaoConta;
            textTotalMovimentacao.Text = totaisMovimentacaoConta.Sum(t => t.TotalMovimentacaoConta).ToString("N2");

            IEnumerable<TotalPagamentoSaida> totaisSaida = GerenciadorSaidaPagamento.GetInstance(null).ObterTotalPagamentoSaida(dataInicial, dataFinal);
            TotalPagamentoSaida totalPagamentoSaidaDinheiro = totaisSaida.Where(t => t.CodFormaPagamentos.Equals(FormaPagamento.DINHEIRO)).FirstOrDefault();
            if (totalPagamentoSaidaDinheiro != null)
            {
                decimal trocoPorPeriodo = GerenciadorSaida.GetInstance(null).ObterTrocoPorPeriodo(dataInicial, dataFinal);
                totalPagamentoSaidaDinheiro.TotalPagamento -= trocoPorPeriodo;
            }
            totaisSaidaBindingSource.DataSource = totaisSaida;

            textTotalVendas.Text = totaisSaida.Sum(t => t.TotalPagamento).ToString("N2");

            IEnumerable<VendasCartao> vendasCartao = GerenciadorSaidaPagamento.GetInstance(null).ObterVendasCartao(dataInicial, dataFinal);
            IEnumerable<VendasCartao> redeCredito = vendasCartao.Where(vendas => vendas.CodCartao != Global.CARTAO_BANESECARD_CREDITO && vendas.TipoCartao != "DEBITO");
            IEnumerable<VendasCartao> redeDebito = vendasCartao.Where(vendas => vendas.TipoCartao == "DEBITO" && vendas.CodCartao != Global.CARTAO_PIX);
            IEnumerable<VendasCartao> redePix = vendasCartao.Where(vendas => vendas.CodCartao == Global.CARTAO_PIX);
            IEnumerable<VendasCartao> baneseCredito = vendasCartao.Where(vendas => vendas.CodCartao == Global.CARTAO_BANESECARD_CREDITO);

            vendasCartaoRede.DataSource = RemoverDuplicados(redeCredito.Union(redeDebito).Union(redePix));
            vendasCartaoBaneseCredito.DataSource = RemoverDuplicados(baneseCredito);

            totalCreditoRede.Text = redeCredito.Sum(t => t.TotalCartao).ToString("N2");
            totalDebitoRede.Text = redeDebito.Sum(t => t.TotalCartao).ToString("N2");
            totalPix.Text = redePix.Sum(t => t.TotalCartao).ToString("N2");
            totalRede.Text = (redeCredito.Sum(t => t.TotalCartao) + redeDebito.Sum(t => t.TotalCartao) + redePix.Sum(t => t.TotalCartao)).ToString("N2");
            totalCreditoBanese.Text = baneseCredito.Sum(t => t.TotalCartao).ToString("N2");
        }


        private IEnumerable<VendasCartao> RemoverDuplicados(IEnumerable<VendasCartao> vendasCartao)
        {
            List<VendasCartao> final = new List<VendasCartao>();
            foreach (VendasCartao venda in vendasCartao)
            {
                if (String.IsNullOrEmpty(venda.NumeroControle))
                {
                    final.Add(venda);
                }
                else if (final.Where(v => v.NumeroControle.Equals(venda.NumeroControle)).Count() == 0)
                {
                    final.Add(venda);
                }
            }
            return final;
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

        private void btnDetalhes_Click(object sender, EventArgs e)
        {
            FrmMovimentacaoCaixaRecebido frmRecebido = new FrmMovimentacaoCaixaRecebido(dateTimePickerInicial.Value, dateTimePickerFinal.Value);
            frmRecebido.ShowDialog();
            frmRecebido.Dispose();
        }

    }
}
