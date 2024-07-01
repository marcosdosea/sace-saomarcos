using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using Negocio;
using Util;

namespace Sace
{
    public partial class FrmSaidaPagamentoBoleto : Form
    {
        SaidaPesquisa saida;
        List<Conta> listaContaBoletos;
        private readonly SaceService service;
        private readonly DbContextOptions<SaceContext> saceOptions;

        public FrmSaidaPagamentoBoleto(string cupomFiscal, DbContextOptions<SaceContext> saceOptions)
        {
            InitializeComponent();
            this.saceOptions = saceOptions;
            SaceContext context = new SaceContext(saceOptions);
            service = new SaceService(context);

            List<SaidaPesquisa> saidas = gerenciadorSaida.ObterPorCupomFiscal(cupomFiscal);
            if (saidas.Count > 0)
            {
                saida = saidas.FirstOrDefault();
                if (saida.CodCliente == Util.UtilConfig.Default.CLIENTE_PADRAO)
                {
                    throw new TelaException("Não é possível cadastrar boleto. Boletos devem ser associados a clientes.");
                }
                InitializeComponent();
                nomeClienteTextBox.Text = saida.NomeCliente;
                cupomFiscalTextBox.Text = saida.CupomFiscal;
                dataEmissaoCupomFiscalDateTimePicker.Value = saida.DataSaida;
                totalTextBox.Text = saidas.Sum(s => s.TotalAVista).ToString("N2");
                dataVencimentoDateTimePicker.Value = DateTime.Now.AddDays(7);
                valorPagarTextBox.Text = totalTextBox.Text;
                numeroDocumentoTextBox.Text = saida.CupomFiscal + "/1";
                listaContaBoletos = new List<Conta>();
            }
            
        }

        private void FrmSaidaPagamentoBoleto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6)
            {
                btnSalvar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                btnCancelar_Click(sender, e);
            }
            // Coloca o foco na grid caso ela não possua
            else if ((e.KeyCode == Keys.F12) && (contaDataGridView.Focused))
            {
                contaDataGridView.Focus();
            }
            else if (e.KeyCode == Keys.F12)
            {
                contaDataGridView.Focus();
            }

            // permite excluir um contato quando o foco está na grid
            else if ((e.KeyCode == Keys.Delete) && (contaDataGridView.Focused == true))
            {
                ExcluirBoleto(sender, e);
            }


            else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                SendKeys.Send("{tab}");
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            decimal total = decimal.Parse(totalTextBox.Text);
            if (saida != null) {
                SaidaPagamento saidaPagamento = service.GerenciadorSaidaPagamento.ObterPorSaida(saida.CodSaida).FirstOrDefault();
                Conta conta = new Conta();
                conta.CF = saida.CupomFiscal;
                conta.CodEntrada = UtilConfig.Default.ENTRADA_PADRAO;
                if (saidaPagamento != null)
                    conta.CodPagamento = saidaPagamento.CodSaidaPagamento;
                conta.CodPessoa = saida.CodCliente;
                conta.CodPlanoConta = PlanoConta.SAIDA_PRODUTOS;
                conta.CodSaida = saida.CodSaida;
                conta.CodSituacao = SituacaoConta.SITUACAO_ABERTA;
                conta.DescricaoSituacao = "ABERTA";
                conta.DataVencimento = dataVencimentoDateTimePicker.Value;
                conta.Desconto = 0;
                conta.FormatoConta = Conta.FORMATO_CONTA_BOLETO;
                conta.NumeroDocumento = numeroDocumentoTextBox.Text;
                conta.Valor = Decimal.Parse(valorPagarTextBox.Text);
                
                listaContaBoletos.Add(conta);
                contaBindingSource.DataSource = listaContaBoletos;
            }

            if (listaContaBoletos.Sum(b => b.Valor) >= total)
            {
                if (MessageBox.Show("Confirma Substitução por Boletos?", "Confirmar Substituição por Boletos", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    service.GerenciadorConta.Substituir(saida.CupomFiscal, listaContaBoletos);
                }
            
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExcluirBoleto(object sender, EventArgs e)
        {

        }
    }
}
