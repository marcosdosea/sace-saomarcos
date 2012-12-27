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
using MySql.Data.MySqlClient;

namespace Negocio
{
    public class GerenciadorConta
    {
        private static GerenciadorConta gConta;
        private static RepositorioGenerico<ContaE, SaceEntities> repConta;
        
        public static GerenciadorConta GetInstance()
        {
            if (gConta == null)
            {
                gConta = new GerenciadorConta();
                repConta = new RepositorioGenerico<ContaE, SaceEntities>("chave");
            }
            return gConta;
        }

        /// <summary>
        /// Insere conta na base de dados
        /// </summary>
        /// <param name="conta"></param>
        /// <returns></returns>
        public Int64 Inserir(Conta conta)
        {
            try
            {
                ContaE _conta = new ContaE();
                Atribuir(conta, _conta);

                repConta.Inserir(_conta);
                repConta.SaveChanges();
                
                return _conta.codConta;
            }
            catch (Exception e)
            {
                throw new DadosException("Conta", e.Message, e);
            }
        }

        /// <summary>
        /// Atualiza dados da conta no banco de dados
        /// </summary>
        /// <param name="conta"></param>
        public void Atualizar(Conta conta)
        {
            if ( (conta.CodEntrada != 1) || (conta.CodSaida != 1) )
                throw new NegocioException("Essa conta não pode ser alterada por estar associada a uma entrada / saída.");

            try
            {
                ContaE _conta = repConta.ObterEntidade(c => c.codConta == conta.CodConta);
                Atribuir(conta, _conta);

                repConta.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Conta", e.Message, e);
            }
        }

        /// <summary>
        /// Atualizar dados da conta no banco de dados.
        /// </summary>
        /// <param name="codSituacao">nova situação da conta</param>
        /// <param name="valorDesconto">novo valor de desconto</param>
        /// <param name="codConta">conta pesquisada</param>
        public void Atualizar(string codSituacao, decimal desconto, long codConta)
        {
            try
            {
                ContaE _conta = repConta.ObterEntidade(c => c.codConta == codConta);
                _conta.codSituacao = codSituacao;
                _conta.desconto = desconto;

                repConta.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Conta", e.Message, e);
            }
        }

        /// <summary>
        /// Remove conta da base de dados
        /// </summary>
        /// <param name="codConta"></param>
        public void Remover(Int64 codConta)
        {
            try
            {
                repConta.Remover(c => c.codConta == codConta);
                repConta.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Conta", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<Conta> GetQuery()
        {
            var saceEntities = (SaceEntities)repConta.ObterContexto();
            var query = from conta in saceEntities.ContaSet
                        join planoConta in saceEntities.PlanoContaSet on conta.codPlanoConta equals planoConta.codPlanoConta
                        join situacaoConta in saceEntities.SituacaoContaSet on conta.codSituacao equals situacaoConta.codSituacao
                        join pessoa in saceEntities.PessoaSet on conta.codPessoa equals pessoa.codPessoa
                        orderby conta.dataVencimento, conta.codConta
                        select new Conta
                        {
                            CodConta = conta.codConta,
                            CodDocumento = conta.codDocumentoPagamento,
                            CodEntrada = (long) conta.codEntrada,
                            CodPagamento = conta.codPagamento,
                            CodPessoa = conta.codPessoa,
                            NomePessoa = pessoa.nomeFantasia,
                            CodPlanoConta = conta.codPlanoConta,
                            CodSaida = (long) conta.codSaida,
                            CodSituacao = conta.codSituacao,
                            DescricaoSituacao = situacaoConta.descricaoSituacao,
                            DataVencimento = conta.dataVencimento,
                            Desconto = conta.desconto,
                            Observacao = conta.observacao,
                            TipoConta = planoConta.codTipoConta,
                            Valor = conta.valor
                        };
            return query;
        }

        /// <summary>
        /// Consulta para retornar dados da entidade quando houver saídas associadas
        /// </summary>
        /// <returns></returns>
        private IQueryable<Conta> GetQuerySaida()
        {
            var saceEntities = (SaceEntities)repConta.ObterContexto();
            var query = from conta in saceEntities.ContaSet
                        join planoConta in saceEntities.PlanoContaSet on conta.codPlanoConta equals planoConta.codPlanoConta
                        join situacaoConta in saceEntities.SituacaoContaSet on conta.codSituacao equals situacaoConta.codSituacao
                        join saida in saceEntities.SaidaSet on conta.codSaida equals saida.codSaida
                        orderby conta.dataVencimento, conta.codConta
                        select new Conta
                        {
                            CodConta = conta.codConta,
                            CodDocumento = conta.codDocumentoPagamento,
                            CodEntrada = (long)conta.codEntrada,
                            CodPagamento = conta.codPagamento,
                            CodPessoa = conta.codPessoa,
                            CF = saida.pedidoGerado,
                            CodPlanoConta = conta.codPlanoConta,
                            CodSaida = (long)conta.codSaida,
                            CodSituacao = conta.codSituacao,
                            DescricaoSituacao = situacaoConta.descricaoSituacao,
                            DataVencimento = conta.dataVencimento,
                            Desconto = conta.desconto,
                            Observacao = conta.observacao,
                            TipoConta = planoConta.codTipoConta,
                            Valor = conta.valor
                        };
            return query;
        }

        /// <summary>
        /// Obtém todas as contas cadastradas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Conta> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Obtém os dados da conta pelo código
        /// </summary>
        /// <param name="codCartaoCredito"></param>
        /// <returns>código do cartão</returns>
        public IEnumerable<Conta> Obter(long codConta)
        {
            return GetQuery().Where(conta => conta.CodConta == codConta).ToList();
        }

        /// <summary>
        /// Obtém os dados da conta pela entrada
        /// </summary>
        /// <param name="codEntrada"></param>
        /// <returns>código da entrada</returns>
        public IEnumerable<Conta> ObterPorEntrada(long codEntrada)
        {
            return GetQuery().Where(conta => conta.CodEntrada == codEntrada).ToList();
        }

        /// <summary>
        /// Obtém os dados da conta pela saída
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns>código da saida</returns>
        public IEnumerable<Conta> ObterPorSaida(long codSaida)
        {
            
            return GetQuery().Where(conta => conta.CodSaida == codSaida).ToList();
        }

    
        /// <summary>
        /// Obter contas por entrada e pagamento da entrada
        /// </summary>
        /// <param name="codEntrada">código da entrada</param>
        /// <param name="codPagamento">código do pagamento</param>
        /// <returns></returns>
        public IEnumerable<Conta> ObterPorEntradaPagamento(long codEntrada, long codPagamento)
        {
            return GetQuery().Where(conta => conta.CodEntrada == codEntrada && conta.CodPagamento == codPagamento).ToList();
        }

    
        /// <summary>
        /// Obter contas pela saída e pagamento da saída
        /// </summary>
        /// <param name="codSaida">Código da Saída</param>
        /// <param name="codPagamento">Código do Pagamento</param>
        /// <returns></returns>
        public IEnumerable<Conta> ObterPorSaidaPagamento(long codSaida, long codPagamento)
        {
            return GetQuery().Where(conta => conta.CodSaida == codSaida && conta.CodPagamento == codPagamento).ToList();
        }

        /// <summary>
        /// Obter contas de uma determinada entrada numa situação
        /// </summary>
        /// <param name="codSituacao">situação das contas</param>
        /// <param name="codEntrada">código da entrada</param>
        /// <returns></returns>
        public IEnumerable<Conta> ObterPorSituacaoEntrada(string codSituacao, long codEntrada)
        {
            return GetQuery().Where(conta => conta.CodSituacao.Equals(codSituacao) && conta.CodEntrada == codEntrada).ToList();
        }

        /// <summary>
        /// Obter contas de uma determinada saida na situação
        /// </summary>
        /// <param name="codSituacao">situação das contas</param>
        /// <param name="codSaida">código da saída</param>
        /// <returns></returns>
        public IEnumerable<Conta> ObterPorSituacaoSaida(string codSituacao, long codSaida)
        {
            return GetQuery().Where(conta => conta.CodSituacao.Equals(codSituacao) && conta.CodSaida == codSaida).ToList();
        }


        /// <summary>
        /// Obter contas de uma determinada pessoa na situação especificada
        /// </summary>
        /// <param name="codSituacao">situação das contas</param>
        /// <param name="codPessoa">código da pessoa</param>
        /// <returns></returns>
        public IEnumerable<Conta> ObterPorSituacaoPessoa(string codSituacao, long codPessoa)
        {
            return GetQuerySaida().Where(conta => conta.CodSituacao.Equals(codSituacao) && conta.CodPessoa == codPessoa).ToList();
        }

        /// <summary>
        /// Obter contas de uma determinada pessoa na situação especificada num determinado período
        /// </summary>
        /// <param name="codSituacao">situação das contas</param>
        /// <param name="codPessoa">código da pessoa</param>
        /// <param name="dataInicial">data inicial</param>
        /// <param name="dataFinal">data final</param>
        /// <returns></returns>
        public IEnumerable<Conta> ObterPorSituacaoPessoaPeriodo(string situacao1, string situacao2, long codPessoa, DateTime dataInicial, DateTime dataFinal)
        {
            return GetQuerySaida().Where(conta => (conta.CodSituacao.Equals(situacao1) || conta.CodSituacao.Equals(situacao2)) && 
                  conta.CodPessoa == codPessoa && conta.DataVencimento >= dataInicial && conta.DataVencimento <= dataFinal).ToList();
        }

       
        /// <summary>
        /// Atribui entidade à entidade persistente
        /// </summary>
        /// <param name="conta"></param>
        /// <param name="_conta"></param>
        private void Atribuir(Conta conta, ContaE _conta)
        {
            _conta.codConta = conta.CodConta;
            _conta.codDocumentoPagamento = conta.CodDocumento;
            _conta.codEntrada = conta.CodEntrada;
            _conta.codPagamento = conta.CodPagamento;
            _conta.codPessoa = conta.CodPessoa;
            _conta.codPlanoConta = conta.CodPlanoConta;
            _conta.codSaida = conta.CodSaida;
            _conta.codSituacao = conta.CodSituacao.ToString();
            _conta.dataVencimento = conta.DataVencimento;
            _conta.desconto = conta.Desconto;
            _conta.observacao = conta.Observacao;
            _conta.valor = conta.Valor;
        }

    }
}