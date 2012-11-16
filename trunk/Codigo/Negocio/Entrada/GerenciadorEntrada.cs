using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio;
using Dados.saceDataSetTableAdapters;
using Dados;
using Util;
using System.Data.Common;

namespace Negocio
{
    public class GerenciadorEntrada 
    {
        private static GerenciadorEntrada gEntrada;
        private static tb_entradaTableAdapter tb_entradaTA;
        
        
        public static GerenciadorEntrada getInstace()
        {
            if (gEntrada == null)
            {
                gEntrada = new GerenciadorEntrada();
                tb_entradaTA = new tb_entradaTableAdapter();
            }
            return gEntrada;
        }

        public Int64 inserir(Entrada entrada)
        {
            try
            {
                byte fretePagoEmitenteByte = (byte)(entrada.FretePagoEmitente ? 1 : 0);

                tb_entradaTA.Insert(entrada.NumeroNotaFiscal, entrada.CodEmpresaFrete, entrada.CodFornecedor,
                    entrada.CodTipoEntrada, entrada.DataEmissao, entrada.DataEntrada, entrada.TotalBaseCalculo.ToString(),
                    entrada.TotalICMS.ToString(), entrada.TotalBaseSubstituicao.ToString(), entrada.TotalSubstituicao.ToString(),
                    entrada.TotalProdutos.ToString(), entrada.TotalProdutosST.ToString(), entrada.ValorFrete.ToString(), entrada.ValorSeguro.ToString(),
                    entrada.Desconto.ToString(), entrada.OutrasDespesas.ToString(), entrada.TotalIPI.ToString(),
                    entrada.TotalNota.ToString(), entrada.CodSituacaoPagamentos, fretePagoEmitenteByte);

                return (Int64) tb_entradaTA.getMaxCodEntrada();
            }
            catch (Exception e)
            {
                throw new DadosException("Entrada", e.Message, e);
            }
        }

        public void atualizar(Entrada entrada)
        {
            try
            {
                byte fretePagoEmitenteByte = (byte)(entrada.FretePagoEmitente ? 1 : 0);

                tb_entradaTA.Update(entrada.NumeroNotaFiscal, entrada.CodEmpresaFrete, entrada.CodFornecedor,
                    entrada.CodTipoEntrada, entrada.DataEmissao, entrada.DataEntrada, entrada.TotalBaseCalculo,
                    entrada.TotalICMS, entrada.TotalBaseSubstituicao, entrada.TotalSubstituicao,
                    entrada.TotalProdutos, entrada.TotalProdutosST, entrada.ValorFrete, entrada.ValorSeguro,
                    entrada.Desconto, entrada.OutrasDespesas, entrada.TotalIPI,
                    entrada.TotalNota, entrada.CodSituacaoPagamentos, fretePagoEmitenteByte,
                    entrada.CodEntrada);
            }
            catch (Exception e)
            {
                throw new DadosException("Entrada", e.Message, e);
            }
        }

        public void remover(Int64 codEntrada)
        {
            try
            {
                tb_entradaTA.Delete(codEntrada);
            }
            catch (Exception e)
            {
                throw new DadosException("Entrada", e.Message, e);
            }
        }

        public void encerrar(Entrada entrada)
        {

            if (GerenciadorConta.getInstace().obterContasPorEntada(entrada.CodEntrada).Count == 0)
            {
                List<EntradaPagamento> entradaPagamentos = GerenciadorEntradaPagamento.getInstace().obterEntradaPagamentos(entrada.CodEntrada);
                registrarPagamentosEntrada(entradaPagamentos, entrada);
            }
            else
            {
                throw new NegocioException("Existem contas associadas a essa entrada. Ela não pode ser encerrada novamente.");
            }

            entrada.CodSituacaoPagamentos = SituacaoPagamentos.LANCADOS;
            atualizar(entrada);
        }

        private void registrarPagamentosEntrada(List<EntradaPagamento> pagamentos, Entrada entrada)
        {

            foreach (EntradaPagamento pagamento in pagamentos)
            {
                // Para cada pagamento é criada uma nova conta
                Conta conta = new Conta();
                if (pagamento.PagamentoDoFrete)
                    conta.CodPessoa = entrada.CodEmpresaFrete;
                else
                    conta.CodPessoa = entrada.CodFornecedor;

                conta.CodPlanoConta = PlanoConta.ENTRADA_PRODUTOS;
                conta.CodEntrada = entrada.CodEntrada;
                conta.CodSaida = 1; // saída não válida
                conta.CodPagamento = pagamento.CodEntradaFormaPagamento;
                conta.Desconto = 0;
                
                // Quando o pagamento é realizado em dinheiro a conta já é inserido quitada
                if (pagamento.CodFormaPagamento == FormaPagamento.DINHEIRO)
                    conta.CodSituacao = Conta.SITUACAO_QUITADA;
                else
                    conta.CodSituacao = Conta.SITUACAO_ABERTA;

                conta.CodDocumento = pagamento.CodDocumentoPagamento;
                conta.TipoConta = Conta.CONTA_PAGAR;

                
                conta.Valor = pagamento.Valor;

                if ((pagamento.CodFormaPagamento == FormaPagamento.BOLETO) || (pagamento.CodFormaPagamento == FormaPagamento.CHEQUE))
                {
                     DocumentoPagamento documento = GerenciadorDocumentoPagamento.getInstace().obterDocumentoPagamento(pagamento.CodDocumentoPagamento);
                     conta.DataVencimento = documento.DataVencimento;
                     conta.Valor = documento.Valor;
                }
                else
                {
                     conta.DataVencimento = pagamento.Data;
                 }
                
                Int64 codConta = GerenciadorConta.getInstace().inserir(conta);
                
                if (pagamento.CodFormaPagamento == FormaPagamento.DINHEIRO)
                {
                    MovimentacaoConta movimentacao = new MovimentacaoConta();
                    movimentacao.CodContaBanco = pagamento.CodContaBanco;
                    movimentacao.CodConta = codConta;
                    movimentacao.CodResponsavel = GerenciadorLoja.getInstace().obter(Global.LOJA_PADRAO).CodPessoa;

                    movimentacao.CodTipoMovimentacao = MovimentacaoConta.PAGAMENTO_FORNECEDOR;
                    movimentacao.DataHora = DateTime.Now;
                    movimentacao.Valor = pagamento.Valor;

                    GerenciadorMovimentacaoConta.getInstace().inserir(movimentacao);
                }
            }
        }
        public Entrada obterEntrada(Int64 codEntrada)
        {
            Entrada entrada = new Entrada();

            tb_entradaTableAdapter tb_entradaTA = new tb_entradaTableAdapter();
            Dados.saceDataSet.tb_entradaDataTable entradaDT = tb_entradaTA.GetDataByCodEntrada(codEntrada);

            entrada.CodEntrada = Convert.ToInt64(entradaDT.Rows[0]["codEntrada"].ToString());
            entrada.CodEmpresaFrete = Convert.ToInt64(entradaDT.Rows[0]["codEmpresaFrete"].ToString());
            entrada.CodFornecedor = Convert.ToInt64(entradaDT.Rows[0]["codFornecedor"].ToString());
            entrada.CodTipoEntrada = Convert.ToInt32(entradaDT.Rows[0]["codTipoEntrada"].ToString());
            entrada.DataEmissao = Convert.ToDateTime(entradaDT.Rows[0]["dataEmissao"].ToString());
            entrada.DataEntrada = Convert.ToDateTime(entradaDT.Rows[0]["dataEntrada"].ToString());
            entrada.Desconto = Convert.ToDecimal(entradaDT.Rows[0]["desconto"].ToString());
            entrada.NomeEmpresaFrete = entradaDT.Rows[0]["nomeEmpresaFrete"].ToString();
            entrada.NomeFornecedor = entradaDT.Rows[0]["nomeFornecedor"].ToString();
            entrada.NumeroNotaFiscal = entradaDT.Rows[0]["numeroNotaFiscal"].ToString();
            entrada.OutrasDespesas = Convert.ToDecimal(entradaDT.Rows[0]["outrasDespesas"].ToString());
            entrada.TotalBaseCalculo = Convert.ToDecimal(entradaDT.Rows[0]["totalBaseCalculo"].ToString());
            entrada.TotalBaseSubstituicao = Convert.ToDecimal(entradaDT.Rows[0]["totalBaseSubstituicao"].ToString());
            entrada.TotalICMS = Convert.ToDecimal(entradaDT.Rows[0]["totalICMS"].ToString());
            entrada.TotalIPI = Convert.ToDecimal(entradaDT.Rows[0]["totalIPI"].ToString());
            entrada.TotalNota = Convert.ToDecimal(entradaDT.Rows[0]["totalNota"].ToString());
            entrada.TotalProdutos = Convert.ToDecimal(entradaDT.Rows[0]["totalProdutos"].ToString());
            entrada.TotalSubstituicao = Convert.ToDecimal(entradaDT.Rows[0]["totalSubstituicao"].ToString());
            entrada.ValorFrete = Convert.ToDecimal(entradaDT.Rows[0]["valorFrete"].ToString());
            entrada.ValorSeguro = Convert.ToDecimal(entradaDT.Rows[0]["valorSeguro"].ToString());
            entrada.CodSituacaoPagamentos = Convert.ToInt32(entradaDT.Rows[0]["codSituacaoPagamentos"].ToString());
            entrada.FretePagoEmitente = Convert.ToBoolean(entradaDT.Rows[0]["fretePagoEmitente"].ToString());

            return entrada;
        }
    }
}