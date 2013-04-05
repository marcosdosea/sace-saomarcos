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
                
        public static GerenciadorEntrada GetInstance()
        {
            if (gEntrada == null)
            {
                gEntrada = new GerenciadorEntrada();
            }
            return gEntrada;
        }

        /// <summary>
        /// Inserir uma nova entrada
        /// </summary>
        /// <param name="entrada"></param>
        /// <returns></returns>
        public Int64 Inserir(Entrada entrada)
        {
            try
            {
                var repEntrada = new RepositorioGenerico<EntradaE>();

                EntradaE _entradaE = new EntradaE();
                if ((entrada.TotalBaseSubstituicao > 0) && (entrada.TotalProdutosST <= 0 ))
                  throw new NegocioException("Quando a entrada possui valor de substituição tributária é necessário informar o valor Total dos Produtos Substituição Tributária");
                

                Atribuir(entrada, _entradaE);

                repEntrada.Inserir(_entradaE);
                repEntrada.SaveChanges();
                
                return _entradaE.codEntrada;
            }
            catch (Exception e)
            {
                throw new DadosException("Entrada", e.Message, e);
            }
        }


        /// <summary>
        /// Atualizar dados da entrada
        /// </summary>
        /// <param name="entrada"></param>
        public void Atualizar(Entrada entrada)
        {
            var repEntrada = new RepositorioGenerico<EntradaE>();
            Atualizar(entrada, (SaceEntities) repEntrada.ObterContexto());
        }

        /// <summary>
        /// Atualizar dados da entrada
        /// </summary>
        /// <param name="entrada"></param>
        public void Atualizar(Entrada entrada, SaceEntities saceContext)
        {
            try
            {
                if ((entrada.TotalBaseSubstituicao > 0) && (entrada.TotalProdutosST <= 0))
                    throw new NegocioException("Quando a entrada possui valor de substituição tributária é necessário informar o valor Total dos Produtos Substituição Tributária");
                
                var query = from entradaSet in saceContext.EntradaSet
                            where entradaSet.codEntrada == entrada.CodEntrada
                            select entradaSet;
                EntradaE _entradaE = query.ToList().ElementAtOrDefault(0);    
                Atribuir(entrada, _entradaE);
                saceContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Entrada", e.Message, e);
            }
        }

        /// <summary>
        /// REmover uma entrada
        /// </summary>
        /// <param name="codEntrada"></param>
        public void Remover(long codEntrada)
        {
            try
            {
                var repEntrada = new RepositorioGenerico<EntradaE>();

                repEntrada.Remover(e => e.codEntrada == codEntrada);
                repEntrada.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Entrada", e.Message, e);
            }
        }

        /// <summary>
        /// Encerra o cadastramento da entrada lançando todas as contas a pagar
        /// </summary>
        /// <param name="entrada"></param>
        public void Encerrar(Entrada entrada)
        {
            var repEntrada = new RepositorioGenerico<EntradaE>();
            SaceEntities saceContext = (SaceEntities) repEntrada.ObterContexto();
            DbTransaction transaction = null;
            try
            {
                if (saceContext.Connection.State == System.Data.ConnectionState.Closed)
                    saceContext.Connection.Open();
                transaction = saceContext.Connection.BeginTransaction();
                if (GerenciadorConta.GetInstance(saceContext).ObterPorEntrada(entrada.CodEntrada).ToList().Count == 0)
                {
                    List<EntradaPagamento> entradaPagamentos = (List<EntradaPagamento>)GerenciadorEntradaPagamento.GetInstance().ObterPorEntrada(entrada.CodEntrada);
                    RegistrarPagamentosEntrada(entradaPagamentos, entrada, saceContext);
                }
                else
                {
                    throw new NegocioException("Existem contas associadas a essa entrada. Ela não pode ser encerrada novamente.");
                }
                entrada.CodSituacaoPagamentos = SituacaoPagamentos.LANCADOS;
                Atualizar(entrada, saceContext);
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw e;
            }
            finally
            {
                saceContext.Connection.Close();
            }
        }

        /// <summary>
        /// REgistra os pagamentos associando para cada um dele uma conta a pagar
        /// </summary>
        /// <param name="pagamentos"></param>
        /// <param name="entrada"></param>
        private void RegistrarPagamentosEntrada(List<EntradaPagamento> pagamentos, Entrada entrada, SaceEntities saceContext)
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
                conta.CodSaida = Global.SAIDA_PADRAO; // saída não válida
                conta.CodPagamento = pagamento.CodEntradaFormaPagamento;
                conta.Desconto = 0;
                
                // Quando o pagamento é realizado em dinheiro a conta já é inserido quitada
                if (pagamento.CodFormaPagamento == FormaPagamento.DINHEIRO)
                    conta.CodSituacao = SituacaoConta.SITUACAO_QUITADA.ToString();
                else
                    conta.CodSituacao = SituacaoConta.SITUACAO_ABERTA.ToString();

                conta.TipoConta = Conta.CONTA_PAGAR.ToString();

                
                conta.Valor = pagamento.Valor;

                if ((pagamento.CodFormaPagamento == FormaPagamento.BOLETO) || (pagamento.CodFormaPagamento == FormaPagamento.CHEQUE))
                {
                     //DocumentoPagamento documento = GerenciadorDocumentoPagamento.getInstace().obterDocumentoPagamento(pagamento.CodDocumentoPagamento);
                     //conta.DataVencimento = documento.DataVencimento;
                     //conta.Valor = documento.Valor;
                }
                else
                {
                     conta.DataVencimento = pagamento.Data;
                 }

                conta.CodConta = GerenciadorConta.GetInstance(saceContext).Inserir(conta);
                
                if (pagamento.CodFormaPagamento == FormaPagamento.DINHEIRO)
                {
                    MovimentacaoConta movimentacao = new MovimentacaoConta();
                    movimentacao.CodContaBanco = pagamento.CodContaBanco;
                    movimentacao.CodConta = conta.CodConta;
                    movimentacao.CodResponsavel = GerenciadorLoja.GetInstance().Obter(Global.LOJA_PADRAO).ElementAt(0).CodPessoa;

                    movimentacao.CodTipoMovimentacao = MovimentacaoConta.PAGAMENTO_FORNECEDOR;
                    movimentacao.DataHora = DateTime.Now;
                    movimentacao.Valor = pagamento.Valor;

                    GerenciadorMovimentacaoConta.GetInstance(saceContext).Inserir(movimentacao);
                }
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<Entrada> GetQuery()
        {
            var repEntrada = new RepositorioGenerico<EntradaE>();

            var saceEntities = (SaceEntities)repEntrada.ObterContexto();
            var query = from entrada in saceEntities.EntradaSet
                        join fornecedor in saceEntities.PessoaSet on entrada.codFornecedor equals fornecedor.codPessoa
                        join transportadora in saceEntities.PessoaSet on entrada.codEmpresaFrete equals transportadora.codPessoa
                        select new Entrada
                        {
                            CodEmpresaFrete = entrada.codEmpresaFrete,
                            CodEntrada = entrada.codEntrada,
                            CodFornecedor = entrada.codFornecedor,
                            CodSituacaoPagamentos = entrada.codSituacaoPagamentos,
                            CodTipoEntrada = entrada.codTipoEntrada,
                            DataEmissao = (DateTime) entrada.dataEmissao,
                            DataEntrada = (DateTime) entrada.dataEntrada,
                            Desconto = (decimal) entrada.desconto,
                            FretePagoEmitente = entrada.fretePagoEmitente,
                            NomeEmpresaFrete = transportadora.nome,
                            NomeFornecedor = fornecedor.nome,
                            NumeroNotaFiscal = entrada.numeroNotaFiscal,
                            OutrasDespesas = (decimal) entrada.outrasDespesas,
                            TotalBaseCalculo = (decimal) entrada.totalBaseCalculo,
                            TotalBaseSubstituicao = (decimal) entrada.totalBaseSubstituicao,
                            TotalICMS = (decimal) entrada.totalICMS,
                            TotalIPI = (decimal) entrada.totalIPI,
                            TotalNota = (decimal) entrada.totalNota,
                            TotalProdutos = (decimal) entrada.totalProdutos,
                            TotalProdutosST = (decimal) entrada.totalProdutosST,
                            TotalSubstituicao = (decimal) entrada.totalSubstituicao,
                            ValorFrete = (decimal) entrada.valorFrete,
                            ValorSeguro = (decimal) entrada.valorSeguro
                        };
            return query;
        }

        /// <summary>
        /// Obtém todos os banco cadastrados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Entrada> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Obtém banco com o código especificiado
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public IEnumerable<Entrada> Obter(long codEntrada)
        {
            return GetQuery().Where(entrada => entrada.CodEntrada == codEntrada).ToList();
        }

        /// <summary>
        /// Obtém banco com o código especificiado
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public IEnumerable<Entrada> ObterPorTipoEntrada(int codTipoEntrada)
        {
            return GetQuery().Where(entrada => entrada.CodTipoEntrada == codTipoEntrada).ToList();
        }

        /// <summary>
        /// Obtém entradas pelo número da nota fiscal
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public IEnumerable<Entrada> ObterPorNumeroNotaFiscal(string numeroNotaFiscal)
        {
            return GetQuery().Where(entrada => entrada.NumeroNotaFiscal.StartsWith(numeroNotaFiscal)).ToList();
        }

        /// <summary>
        /// Obtém entradas pelo nome do fornecedor
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public IEnumerable<Entrada> ObterPorNomeFornecedor(string nomeFornecedor)
        {
            return GetQuery().Where(entrada => entrada.NomeFornecedor.StartsWith(nomeFornecedor)).ToList();
        }
        
        
        /// <summary>
        /// Obtém situacoes Pagamentos
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public IEnumerable<SituacaoPagamentos> ObterTodosSituacoesPagamentos()
        {
            var repEntrada = new RepositorioGenerico<EntradaE>();

            var saceEntities = (SaceEntities)repEntrada.ObterContexto();
            var query = from situacaoPagamentos in saceEntities.SituacaoPagamentosSet
                        select new SituacaoPagamentos
                        {
                            CodSituacaoPagamentos = situacaoPagamentos.codSituacaoPagamentos,
                            DescricaoSituacaoPagamentos = situacaoPagamentos.descricaoSituacaoPagamentos
                        };
            return query.ToList();
        }


        /// <summary>
        /// Atribui os dados da entidade para entidade persistente
        /// </summary>
        /// <param name="entrada"></param>
        /// <param name="_entradaE"></param>
        private static void Atribuir(Entrada entrada, EntradaE _entradaE)
        {
            _entradaE.codEmpresaFrete = entrada.CodEmpresaFrete;
            _entradaE.codFornecedor = entrada.CodFornecedor;
            _entradaE.codSituacaoPagamentos = entrada.CodSituacaoPagamentos;
            _entradaE.codTipoEntrada = entrada.CodTipoEntrada;
            _entradaE.dataEmissao = entrada.DataEmissao;
            _entradaE.dataEntrada = entrada.DataEntrada;
            _entradaE.desconto = entrada.Desconto;
            _entradaE.fretePagoEmitente = entrada.FretePagoEmitente;
            _entradaE.numeroNotaFiscal = entrada.NumeroNotaFiscal;
            _entradaE.outrasDespesas = entrada.OutrasDespesas;
            _entradaE.totalBaseCalculo = entrada.TotalBaseCalculo;
            _entradaE.totalBaseSubstituicao = entrada.TotalBaseSubstituicao;
            _entradaE.totalICMS = entrada.TotalICMS;
            _entradaE.totalIPI = entrada.TotalIPI;
            _entradaE.totalNota = entrada.TotalNota;
            _entradaE.totalProdutos = entrada.TotalProdutos;
            _entradaE.totalProdutosST = entrada.TotalProdutosST;
            _entradaE.totalSubstituicao = entrada.TotalSubstituicao;
            _entradaE.valorFrete = entrada.ValorFrete;
            _entradaE.valorSeguro = entrada.ValorSeguro;
        }

    }
}