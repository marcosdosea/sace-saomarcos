using System;
using System.Collections.Generic;
using System.Linq;
using Dados;
using Dominio;

namespace Negocio
{
    public class GerenciadorConta
    {
        private static GerenciadorConta gConta;
        private static SaceEntities saceContext;
        private static RepositorioGenerico<ContaE> repConta;

       
        public static GerenciadorConta GetInstance(SaceEntities context)
        {
            if (gConta == null)
            {
                gConta = new GerenciadorConta();
            }
            if (context == null) 
            {
                repConta = new RepositorioGenerico<ContaE>();
            }
            else 
            {
                repConta = new RepositorioGenerico<ContaE>(context);
            }
            saceContext = (SaceEntities)repConta.ObterContexto();
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
                saceContext.SaveChanges();
                
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
                var repConta = new RepositorioGenerico<ContaE>();

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
                var query = from contaSet in saceContext.ContaSet
                            where contaSet.codConta == codConta
                            select contaSet;

                ContaE _conta = query.ToList().ElementAtOrDefault(0);
                _conta.codSituacao = codSituacao;
                _conta.desconto = desconto;

                saceContext.SaveChanges();
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
        /// <param name="codConta">conta pesquisada</param>
        public void Atualizar(string codSituacao, long codConta)
        {
            try
            {
                var query = from contaSet in saceContext.ContaSet
                            where contaSet.codConta == codConta
                            select contaSet;

                ContaE _conta = query.ToList().ElementAtOrDefault(0);
                _conta.codSituacao = codSituacao;
                
                saceContext.SaveChanges();
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
                var query = from contaSet in saceContext.ContaSet
                            where contaSet.codConta == codConta
                            select contaSet;

                foreach (ContaE _contaE in query)
                {
                    repConta.Remover(_contaE);
                }
                repConta.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Conta", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade quando houver saídas associadas
        /// </summary>
        /// <returns></returns>
        private IQueryable<Conta> GetQuery()
        {
            var query = from conta in saceContext.ContaSet
                        join planoConta in saceContext.PlanoContaSet on conta.codPlanoConta equals planoConta.codPlanoConta
                        join situacaoConta in saceContext.SituacaoContaSet on conta.codSituacao equals situacaoConta.codSituacao
                        join saida in saceContext.tb_saida on conta.codSaida equals saida.codSaida
                        orderby conta.codConta
                        select new Conta
                        {
                            CodConta = conta.codConta,
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
                            FormatoConta = conta.formatoConta,
                            NumeroDocumento = conta.numeroDocumento,
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
            return GetQuery().Where(conta => conta.CodSituacao.Equals(codSituacao) && conta.CodPessoa == codPessoa).OrderBy(conta => conta.DataVencimento).ToList();
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
            return GetQuery().Where(conta => (conta.CodSituacao.Equals(situacao1) || conta.CodSituacao.Equals(situacao2)) && 
                  conta.CodPessoa == codPessoa && conta.DataVencimento >= dataInicial && conta.DataVencimento <= dataFinal).OrderBy(conta => conta.DataVencimento).ToList();
        }

        /// <summary>
        /// Obtém todas as situações de conta
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SituacaoConta> ObterSituacoesConta()
        {
            var query = from situacaoConta in saceContext.SituacaoContaSet
                        select new SituacaoConta
                        {
                            CodSituacao = situacaoConta.codSituacao,
                            Descricao = situacaoConta.descricaoSituacao
                            };
            return query.ToList();
        }
       
        /// <summary>
        /// Atribui entidade à entidade persistente
        /// </summary>
        /// <param name="conta"></param>
        /// <param name="_conta"></param>
        private void Atribuir(Conta conta, ContaE _conta)
        {
            _conta.codConta = conta.CodConta;
            _conta.codEntrada = conta.CodEntrada;
            _conta.codPagamento = conta.CodPagamento;
            _conta.codPessoa = conta.CodPessoa;
            _conta.codPlanoConta = conta.CodPlanoConta;
            _conta.codSaida = conta.CodSaida;
            _conta.codSituacao = conta.CodSituacao.ToString();
            _conta.dataVencimento = conta.DataVencimento;
            _conta.desconto = conta.Desconto;
            _conta.observacao = conta.Observacao;
            _conta.numeroDocumento = conta.NumeroDocumento;
            _conta.formatoConta = conta.FormatoConta;
            _conta.valor = conta.Valor;
        }


        /// <summary>
        /// Substitui um conjunto de contas por uma nova conta para receber do cartão de crédito. 
        /// </summary>
        /// <param name="listaContas">Contas que serão baixadas</param>
        /// <param name="valorPagamento">valor pago nessas contas</param>
        /// <param name="cartaoCredito">cartão de crédito quando necessário</param>
        /// <param name="parcelas">número de parcelas do pagamento</param>
        public void QuitarContasCartaoCredito(List<long> listaContas, decimal valorPagamento, CartaoCredito cartaoCredito, int parcelas)
        {
            try
            {
                string observacao = "Substituiu as contas: ";
                foreach (long codConta in listaContas)
                {
                    Atualizar(SituacaoConta.SITUACAO_QUITADA, codConta);
                    observacao += codConta + ", ";

                }
                DateTime dataVecimento = DateTime.Now;
                Conta contaSubstituida = Obter((long) listaContas.ElementAtOrDefault(0)).ElementAtOrDefault(0);
                

                for (int i = 0; i < parcelas; i++)
                {
                    Conta conta = new Conta();
                    conta.CodEntrada = 1;
                    conta.CodPagamento = 1;
                    conta.CodPessoa = cartaoCredito.CodPessoa;
                    conta.CodPlanoConta = PlanoConta.RECEBIMENTO_CREDIARIO;
                    conta.CodSaida = 1;
                    conta.CodSituacao = SituacaoConta.SITUACAO_ABERTA;
                    dataVecimento = dataVecimento.AddDays(cartaoCredito.DiaBase);
                    conta.DataVencimento = dataVecimento;
                    conta.Desconto = 0;
                    conta.Valor = valorPagamento / parcelas;
                    conta.Observacao = observacao;
                    conta.FormatoConta = Conta.FORMATO_CONTA_CARTAO;
                    conta.NumeroDocumento = contaSubstituida.CF;
                    Inserir(conta);
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Não foi possível realizar a substituição de contas. Favor contactar o administrador.", e);
            }

        }
    }
}