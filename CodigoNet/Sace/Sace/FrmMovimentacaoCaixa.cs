using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Negocio;
using System.Data;

namespace Sace
{
    public partial class FrmMovimentacaoCaixa : Form
    {
        private readonly SaceService service;
        private readonly DbContextOptions<SaceContext> saceOptions;

        public FrmMovimentacaoCaixa(DbContextOptions<SaceContext> saceOptions)
        {
            InitializeComponent();
            this.saceOptions = saceOptions;
            var context = new SaceContext(saceOptions);
            service = new SaceService(context);

            contaBancoBindingSource.DataSource = GerenciadorContaBanco.ObterTodos();
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
            dataFinal = dataFinal.AddHours(23).AddMinutes(59).AddSeconds(59);

            
            int codContaBanco = (int)codContaBancoComboBox.SelectedValue;

            // Totais de Pagamentos no período
            IEnumerable<TotalPagamentoSaida> totaisPagamentos = GerenciadorSaidaPagamento.ObterTotalPagamento(dataInicial, dataFinal);
            TotalPagamentoSaida totalPagamentoDinheiro = totaisPagamentos.Where(t => t.CodFormaPagamentos.Equals(FormaPagamento.DINHEIRO)).FirstOrDefault();
            if (totalPagamentoDinheiro != null)
            {
                decimal trocoPorPeriodo = gerenciadorSaida.ObterTrocoPagamentos(dataInicial, dataFinal);
                totalPagamentoDinheiro.TotalPagamento -= trocoPorPeriodo;
            }
            totaisPagamentosBindingSource.DataSource = totaisPagamentos;


            // Totais de Vendas no período
            IEnumerable<TotalPagamentoSaida> totaisSaida = GerenciadorSaidaPagamento.ObterTotalPagamentoSaida(dataInicial, dataFinal);
            TotalPagamentoSaida totalPagamentoSaidaDinheiro = totaisSaida.Where(t => t.CodFormaPagamentos.Equals(FormaPagamento.DINHEIRO)).FirstOrDefault();
            if (totalPagamentoSaidaDinheiro != null)
            {
                decimal trocoPorPeriodo = gerenciadorSaida.ObterTrocoSaidas(dataInicial, dataFinal);
                totalPagamentoSaidaDinheiro.TotalPagamento -= trocoPorPeriodo;
            }
            totaisSaidaBindingSource.DataSource = totaisSaida;

            textTotalPagamentos.Text = totaisPagamentos.Sum(t => t.TotalPagamento).ToString("N2");
            textTotalVendas.Text = totaisSaida.Sum(t => t.TotalPagamento).ToString("N2");

            IEnumerable<VendasCartao> vendasCartao = GerenciadorSaidaPagamento.ObterVendasCartao(dataInicial, dataFinal);
            IEnumerable<VendasCartao> redeCredito = vendasCartao.Where(vendas => vendas.CodCartao != CartaoCredito.CARTAO_BANESECARD_CREDITO && vendas.TipoCartao != "DEBITO");
            IEnumerable<VendasCartao> redeDebito = vendasCartao.Where(vendas => vendas.TipoCartao == "DEBITO" && vendas.CodCartao != CartaoCredito.CARTAO_PIX);
            IEnumerable<VendasCartao> redePix = vendasCartao.Where(vendas => vendas.CodCartao == CartaoCredito.CARTAO_PIX);
            IEnumerable<VendasCartao> baneseCredito = vendasCartao.Where(vendas => vendas.CodCartao == CartaoCredito.CARTAO_BANESECARD_CREDITO);

            vendasCartaoRede.DataSource = RemoverDuplicados(redeCredito.Union(redeDebito).Union(redePix));
            vendasCartaoBaneseCredito.DataSource = RemoverDuplicados(baneseCredito);

            totalCreditoRede.Text = redeCredito.Sum(t => t.TotalCartao).ToString("N2");
            totalDebitoRede.Text = redeDebito.Sum(t => t.TotalCartao).ToString("N2");
            totalPix.Text = redePix.Sum(t => t.TotalCartao).ToString("N2");
            totalCreditoBanese.Text = baneseCredito.Sum(t => t.TotalCartao).ToString("N2");

            var vendasPixDeposito = GerenciadorSaidaPagamento.ObterVendasPixDeposito(dataInicial, dataFinal);
            vendasPixDepositoBindingSource.DataSource = vendasPixDeposito;
            totalPixDepositoText.Text = vendasPixDeposito.Sum(t => t.Valor).ToString("N2");
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
            FrmMovimentacaoCaixaRecebido frmRecebido = new FrmMovimentacaoCaixaRecebido(dateTimePickerInicial.Value, dateTimePickerFinal.Value, saceOptions);
            frmRecebido.ShowDialog();
            frmRecebido.Dispose();
        }
    }
}
