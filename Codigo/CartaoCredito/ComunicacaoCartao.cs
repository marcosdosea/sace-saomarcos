using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cappta.Gp.Api.Com.Model;
using Cappta.Gp.Api.Com;
using System.Windows.Forms;
using System.Threading;



namespace Cartao
{
    public class ComunicacaoCartao
    {
        private const int INTERVALO_MILISEGUNDOS = 500;
        private const int TIPO_VIA_TODAS = 1;
        private const int TIPO_VIA_CLIENTE = 2;
        private const int TIPO_VIA_LOJA = 3;


        private ClienteCappta clienteCappta;
        private bool processandoPagamento;
        private bool sessaoMultiTefEmAndamento;
        private int tipoVia = TIPO_VIA_TODAS;

        public bool AutenticarPdv()
        {
            string chaveAutenticacao = Properties.Settings.Default.ChaveAutenticacao;
            if (String.IsNullOrWhiteSpace(chaveAutenticacao)) { this.InvalidarAutenticacao("Chave de Autenticação inválida"); }

            string cnpj = Properties.Settings.Default.Cnpj;
            if (String.IsNullOrWhiteSpace(cnpj) || cnpj.Length != 14) { this.InvalidarAutenticacao("CNPJ inválido"); }

            int pdv;
            if (Int32.TryParse(Properties.Settings.Default.Pdv, out pdv) == false || pdv == 0)
            {
                this.InvalidarAutenticacao("PDV inválido");
            }

            int resultadoAutenticacao = clienteCappta.AutenticarPdv(cnpj, pdv, chaveAutenticacao);
            if (resultadoAutenticacao == 0) { return true; }

            String mensagem = Mensagens.ResourceManager.GetString(String.Format("RESULTADO_CAPPTA_{0}", resultadoAutenticacao));
            MessageBox.Show(mensagem, "SAMPLE API COM", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
        }


        public void ProcessarPagamentos(List<Pagamento> pagamentos)
        {
            foreach(Pagamento pagamento in pagamentos) {
                if (pagamento.TipoCartao.Equals(Pagamento.Cartao.CREDITO))
                {
                    PagarCredito(pagamento.Valor, pagamento.QuantidadeParcelas, (int) pagamento.TipoParcelamento);
                }
                else if (pagamento.TipoCartao.Equals(Pagamento.Cartao.DEBITO))
                {
                    PagarDebito(pagamento.Valor);
                }
                else if (pagamento.TipoCartao.Equals(Pagamento.Cartao.CREDIARIO))
                {
                    PagarCrediario(pagamento.Valor, pagamento.QuantidadeParcelas);
                }

            }
            FinalizarPagamento();
        }


        private void InvalidarAutenticacao(string mensagemErro)
        {
            this.CriarMensagemErroJanela(String.Format("{0}. Verifique seu valor no arquivo de configuração.", mensagemErro));
            System.Environment.Exit(0);
        }

        private void PagarDebito(double valor)
        {
            int resultado = clienteCappta.PagamentoDebito(valor);
            if (resultado != 0) { this.CriarMensagemErroPainel(resultado); return; }

            this.processandoPagamento = true;
            this.IterarOperacaoTef();
        }

        private void PagarCredito(double valor, int quantidadeParcelas, int tipoParcelamento)
        {
            IDetalhesCredito details = new DetalhesCredito
            {
                QuantidadeParcelas = quantidadeParcelas,
                TipoParcelamento = tipoParcelamento,
                TransacaoParcelada = (quantidadeParcelas > 1)
            };

            int resultado = clienteCappta.PagamentoCredito(valor, details);
            if (resultado != 0) { this.CriarMensagemErroPainel(resultado); return; }

            this.processandoPagamento = true;
            this.IterarOperacaoTef();
        }

        private void PagarCrediario(double valor, int quantidadeParcelas)
        {
            IDetalhesCrediario detalhes = new DetalhesCrediario
            {
                QuantidadeParcelas = quantidadeParcelas,
            };

            int resultado = clienteCappta.PagamentoCrediario(valor, detalhes);
            if (resultado != 0) { this.CriarMensagemErroPainel(resultado); return; }

            this.processandoPagamento = true;
            this.IterarOperacaoTef();
        }

        public void ReimprimirCupom(bool ehUltimoCupom, int numeroCupom, int tipoVia)
        {
            if (this.sessaoMultiTefEmAndamento == true)
            {
                this.CriarMensagemErroJanela("Não é possível reimprimir um cupom com uma sessão multitef em andamento."); return;
            }

            int resultado = ehUltimoCupom
                ? this.clienteCappta.ReimprimirUltimoCupom(tipoVia)
                : this.clienteCappta.ReimprimirCupom(numeroCupom.ToString("00000000000"), tipoVia);

            if (resultado != 0) { this.CriarMensagemErroPainel(resultado); return; }

            this.processandoPagamento = false;
            this.IterarOperacaoTef();
        }

        public void Cancelar(string senhaAdministrativa, long numeroControle)
        {
            if (this.sessaoMultiTefEmAndamento == true)
            {
                this.CriarMensagemErroJanela("Não é possível cancelar um pagamento com uma sessão multitef em andamento."); return;
            }

            if (String.IsNullOrEmpty(senhaAdministrativa)) { this.CriarMensagemErroJanela("A senha administrativa não pode ser vazia."); return; }

            int resultado = clienteCappta.CancelarPagamento(senhaAdministrativa, numeroControle.ToString("00000000000"));
            if (resultado != 0) { this.CriarMensagemErroPainel(resultado); return; }

            this.processandoPagamento = false;
            this.IterarOperacaoTef();
        }


        private void CriarMensagemErroPainel(int resultado)
        {
            String mensagem = Mensagens.ResourceManager.GetString(String.Format("RESULTADO_CAPPTA_{0}", resultado));
            if (String.IsNullOrEmpty(mensagem)) { mensagem = "Não foi possível executar a operação."; }

            this.AtualizarResultado(String.Format("{0}. Código de erro {1}", mensagem, resultado));
        }

        private void CriarMensagemErroJanela(string mensagem)
        {
            MessageBox.Show(mensagem, "Erro");
        }

        public void IterarOperacaoTef()
        {
            IIteracaoTef iteracaoTef = null;

            do
            {
                iteracaoTef = clienteCappta.IterarOperacaoTef();

                if (iteracaoTef is IMensagem)
                {
                    this.AtualizarResultado(((IMensagem)iteracaoTef).Descricao);
                    Thread.Sleep(INTERVALO_MILISEGUNDOS);
                }

                if (iteracaoTef is IRequisicaoParametro) { this.RequisitarParametros((IRequisicaoParametro)iteracaoTef); }

                if (iteracaoTef is IRespostaOperacaoRecusada) { this.ExibirDadosOperacaoRecusada((IRespostaOperacaoRecusada)iteracaoTef); }
                if (iteracaoTef is IRespostaOperacaoAprovada)
                {
                    this.ExibirDadosOperacaoAprovada((IRespostaOperacaoAprovada)iteracaoTef);
                    this.FinalizarPagamento();
                }

            } while (this.OperacaoNaoFinalizada(iteracaoTef));
        }

        private void AtualizarResultado(String mensagem)
        {
            //this.TextBoxResultado.Text = mensagem;
            //this.TextBoxResultado.Update();
        }

        private void RequisitarParametros(IRequisicaoParametro requisicaoParametros)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox(requisicaoParametros.Mensagem);
            this.clienteCappta.EnviarParametro(input, String.IsNullOrWhiteSpace(input) ? 2 : 1);
        }

        private bool OperacaoNaoFinalizada(IIteracaoTef iteracaoTef)
        {
            return iteracaoTef.TipoIteracao != 1 && iteracaoTef.TipoIteracao != 2;
        }

        private void ExibirDadosOperacaoRecusada(IRespostaOperacaoRecusada resposta)
        {
            if (this.sessaoMultiTefEmAndamento)
            {
                this.processandoPagamento = false;
                this.sessaoMultiTefEmAndamento = false;
            };

            this.AtualizarResultado(String.Format("Código: {0}{1}{2}", resposta.CodigoMotivo, Environment.NewLine, resposta.Motivo));
        }

        private void ExibirDadosOperacaoAprovada(IRespostaOperacaoAprovada resposta)
        {
            StringBuilder mensagemAprovada = new StringBuilder();

            if (resposta.CupomCliente != null) { mensagemAprovada.Append(resposta.CupomCliente.Replace("\"", String.Empty)).AppendLine().AppendLine(); }
            if (resposta.CupomLojista != null) { mensagemAprovada.Append(resposta.CupomLojista.Replace("\"", String.Empty)).AppendLine(); }
            if (resposta.CupomReduzido != null) { mensagemAprovada.Append(resposta.CupomReduzido.Replace("\"", String.Empty)).AppendLine(); }


            this.AtualizarResultado(mensagemAprovada.ToString());
        }

        private void FinalizarPagamento()
        {
            if (this.processandoPagamento == false) { return; }

            string mensagem = this.GerarMensagemTransacaoAprovada();

            this.processandoPagamento = false;
            this.sessaoMultiTefEmAndamento = false;

            DialogResult result = MessageBox.Show(mensagem.ToString(), "Sample API COM", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (result == System.Windows.Forms.DialogResult.OK) { this.clienteCappta.ConfirmarPagamentos(); }
            else { this.clienteCappta.DesfazerPagamentos(); }
        }

        private string GerarMensagemTransacaoAprovada()
        {
            string mensagem = String.Format("Transaç{0} Aprovada{1}!!! {2} Clique em \"OK\" para confirmar a{1} transaç{0} e \"Cancelar\" para desfaze-la{1}.",
                    (this.sessaoMultiTefEmAndamento ? "ões" : "ão"),
                    (this.sessaoMultiTefEmAndamento ? "s" : ""),
                    Environment.NewLine);

            return mensagem;
        }
    }
}
