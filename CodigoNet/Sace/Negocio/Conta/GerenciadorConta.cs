using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public static class GerenciadorConta
    {

        /// <summary>
        /// Insere conta na base de dados
        /// </summary>
        /// <param name="conta"></param>
        /// <returns></returns>
        public static long Inserir(Conta conta, SaceContext context)
        {
            try
            {
                if (context == null)
                    context = new SaceContext();
                var _conta = new TbContum();
                Atribuir(conta, _conta);

                context.Add(_conta);
                context.SaveChanges();

                return _conta.CodConta;
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
        public static void Atualizar(Conta conta)
        {
            using (var context = new SaceContext())
            {
                if ((conta.CodEntrada != 1) || (conta.CodSaida != 1))
                    throw new NegocioException("Essa conta não pode ser alterada por estar associada a uma entrada / saída.");

                try
                {
                    var _conta = new TbContum();
                    _conta.CodConta = conta.CodConta;

                    _conta = context.TbConta.Find(_conta);
                    if (_conta != null)
                    {
                        Atribuir(conta, _conta);
                        context.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    throw new DadosException("Conta", e.Message, e);
                }
            }
        }

        /// <summary>
        /// Atualizar dados da conta no banco de dados.
        /// </summary>
        /// <param name="codSituacao">nova situação da conta</param>
        /// <param name="valorDesconto">novo valor de desconto</param>
        /// <param name="codConta">conta pesquisada</param>
        public static void Atualizar(string codSituacao, decimal desconto, long codConta)
        {
            using (var context = new SaceContext())
            {
                var transaction = context.Database.BeginTransaction();
                try
                {
                    var query = from contaSet in context.TbConta
                                where contaSet.CodConta == codConta
                                select contaSet;

                    TbContum _conta = query.First();
                    _conta.CodSituacao = codSituacao;
                    _conta.Desconto = desconto;
                    context.Update(_conta);
                    context.SaveChanges();

                    var query2 = from contaSet in context.TbConta
                                 where contaSet.CodSaida == _conta.CodSaida
                                 select contaSet;

                    decimal somaContas = query2.Sum(c => (c.Valor - c.Desconto));

                    var query3 = from saida in context.TbSaida
                                 where saida.CodSaida == _conta.CodSaida
                                 select saida;

                    var _saida = query3.First();
                    if (_saida != null)
                        _saida.TotalAvista = somaContas;
                    context.SaveChanges();

                    transaction.Commit();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DadosException("Conta", e.Message, e);
                }
            }
        }

        public static void Atualizar(long codPessoa, DateTime dataVencimento, string formatoConta,
            string nsuTransacao, decimal valor, long codConta)
        {
            using (var context = new SaceContext())
            {
                try
                {
                    var query = from contaSet in context.TbConta
                                where contaSet.CodConta == codConta
                                select contaSet;

                    var _conta = context.TbConta.FirstOrDefault(c => c.CodConta == codConta);
                    _conta.CodPessoa = codPessoa;
                    _conta.DataVencimento = dataVencimento;
                    _conta.FormatoConta = formatoConta;
                    _conta.NumeroDocumento = nsuTransacao.ToString();
                    _conta.Valor = valor;
                    context.Update(_conta);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new DadosException("Conta", e.Message, e);
                }
            }
        }



        /// <summary>
        /// Atualizar dados da conta no banco de dados.
        /// </summary>
        /// <param name="codSituacao">nova situação da conta</param>
        /// <param name="codConta">conta pesquisada</param>
        public static void Atualizar(string codSituacao, long codConta)
        {
            using (var context = new SaceContext())
            {
                try
                {
                    var _conta = context.TbConta.FirstOrDefault(c => c.CodConta == codConta);
                    _conta.CodSituacao = codSituacao;
                    context.Update(_conta);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new DadosException("Conta", e.Message, e);
                }
            }
        }

        /// <summary>
        /// Atualizar dados da conta no banco de dados.
        /// </summary>
        /// <param name="codSituacao">nova situação da conta</param>
        /// <param name="codConta">conta pesquisada</param>
        public static void AtualizarDadosCartaoCredito(Conta conta)
        {
            using (var context = new SaceContext())
            {
                try
                {
                    var _conta = context.TbConta.FirstOrDefault(c => c.CodPessoa == conta.CodPessoa);
                    if (_conta != null)
                    {
                        Atribuir(conta, _conta);
                        context.Update(_conta);
                        context.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    throw new DadosException("Conta", e.Message, e);
                }
            }
        }

        /// <summary>
        /// Remove conta da base de dados
        /// </summary>
        /// <param name="codConta"></param>
        public static void Remover(long codConta)
        {
            using (var context = new SaceContext())
            {
                try
                {
                    var conta = new TbContum();
                    conta.CodConta = codConta;

                    context.Remove(conta);
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    throw new DadosException("Conta", e.Message, e);
                }
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade quando houver saídas associadas
        /// </summary>
        /// <returns></returns>
        private static IQueryable<Conta> GetQuery(SaceContext context)
        {
            var query = from conta in context.TbConta
                        orderby conta.CodConta
                        select new Conta
                        {
                            CodConta = conta.CodConta,
                            CodEntrada = (long)conta.CodEntrada,
                            CodPagamento = conta.CodPagamento,
                            CodPessoa = conta.CodPessoa,
                            CF = conta.CodSaidaNavigation.PedidoGerado,
                            CodPlanoConta = conta.CodPlanoConta,
                            CodSaida = (long)conta.CodSaida,
                            CodSituacao = conta.CodSituacao,
                            DescricaoSituacao = conta.CodSituacaoNavigation.DescricaoSituacao,
                            DataVencimento = conta.DataVencimento,
                            Desconto = conta.Desconto,
                            Observacao = conta.Observacao,
                            TipoConta = conta.CodPlanoContaNavigation.CodTipoConta,
                            FormatoConta = conta.FormatoConta,
                            NumeroDocumento = conta.NumeroDocumento,
                            Valor = conta.Valor
                        };
            return query.AsNoTracking();
        }

        /// <summary>
        /// Obtém todas as contas cadastradas
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Conta> ObterTodos()
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).ToList();
            }
        }

        /// <summary>
        /// Obtém os dados da conta pelo código
        /// </summary>
        /// <param name="codCartaoCredito"></param>
        /// <returns>código do cartão</returns>
        public static IEnumerable<Conta> Obter(long codConta)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(conta => conta.CodConta == codConta).ToList();
            }
        }

        /// <summary>
        /// Obtém os dados da conta pela entrada
        /// </summary>
        /// <param name="codEntrada"></param>
        /// <returns>código da entrada</returns>
        public static IEnumerable<Conta> ObterPorEntrada(long codEntrada)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(conta => conta.CodEntrada == codEntrada).ToList();
            }
        }

        /// <summary>
        /// Obtém os dados da conta pela saída
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns>código da saida</returns>
        public static IEnumerable<Conta> ObterPorSaida(long codSaida)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(conta => conta.CodSaida == codSaida).ToList();
            }
        }


        /// <summary>
        /// Obtém os dados da conta pela saída
        /// </summary>
        /// <param name="codSaida"></param>
        /// <returns>código da saida</returns>
        public static IEnumerable<Conta> ObterPorNfe(string notaFiscal)
        {
            using (var context = new SaceContext())
            {
                var query = from conta in context.TbConta
                            where conta.CodSaidaNavigation.PedidoGerado.Equals(notaFiscal)
                            orderby conta.CodConta
                            select new Conta
                            {
                                CodConta = conta.CodConta,
                                CodEntrada = (long)conta.CodEntrada,
                                CodPagamento = conta.CodPagamento,
                                CodPessoa = conta.CodPessoa,
                                CF = conta.CodSaidaNavigation.PedidoGerado,
                                CodPlanoConta = conta.CodPlanoConta,
                                CodSaida = (long)conta.CodSaida,
                                CodSituacao = conta.CodSituacao,
                                DescricaoSituacao = conta.CodSituacaoNavigation.DescricaoSituacao,
                                DataVencimento = conta.DataVencimento,
                                Desconto = conta.Desconto,
                                Observacao = conta.Observacao,
                                TipoConta = conta.CodPlanoContaNavigation.CodTipoConta,
                                FormatoConta = conta.FormatoConta,
                                NumeroDocumento = conta.NumeroDocumento,
                                Valor = conta.Valor
                            };
                return query.AsNoTracking();
            }
        }

        /// <summary>
        /// Obter contas por entrada e pagamento da entrada
        /// </summary>
        /// <param name="codEntrada">código da entrada</param>
        /// <param name="codPagamento">código do pagamento</param>
        /// <returns></returns>
        public static IEnumerable<Conta> ObterPorEntradaPagamento(long codEntrada, long codPagamento)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(conta => conta.CodEntrada == codEntrada && conta.CodPagamento == codPagamento).ToList();

            }
        }


        /// <summary>
        /// Obter contas pela saída e pagamento da saída
        /// </summary>
        /// <param name="codSaida">Código da Saída</param>
        /// <param name="codPagamento">Código do Pagamento</param>
        /// <returns></returns>
        public static IEnumerable<Conta> ObterPorSaidaPagamento(long codSaida, long codPagamento)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(conta => conta.CodSaida == codSaida && conta.CodPagamento == codPagamento).ToList();
            }
        }

        /// <summary>
        /// Obter contas de uma determinada saida na situação
        /// </summary>
        /// <param name="codSituacao">situação das contas</param>
        /// <param name="codSaida">código da saída</param>
        /// <returns></returns>
        public static IEnumerable<Conta> ObterPorSituacaoSaida(string codSituacao, long codSaida)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(conta => conta.CodSituacao.Equals(codSituacao) && conta.CodSaida == codSaida).ToList();
            }
        }


        /// <summary>
        /// Obter contas de uma determinada pessoa na situação especificada
        /// </summary>
        /// <param name="codSituacao">situação das contas</param>
        /// <param name="codPessoa">código da pessoa</param>
        /// <returns></returns>
        public static IEnumerable<Conta> ObterPorSituacaoPessoa(string codSituacao, long codPessoa)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(conta => conta.CodSituacao.Equals(codSituacao) && conta.CodPessoa == codPessoa).OrderBy(conta => conta.DataVencimento).ToList();
            }
        }

        /// <summary>
        /// Obter contas de uma determinada pessoa na situação especificada num determinado período
        /// </summary>
        /// <param name="codSituacao">situação das contas</param>
        /// <param name="codPessoa">código da pessoa</param>
        /// <param name="dataInicial">data inicial</param>
        /// <param name="dataFinal">data final</param>
        /// <returns></returns>
        public static IEnumerable<Conta> ObterPorSituacaoPessoaPeriodo(string situacao1, string situacao2, long codPessoa, DateTime dataInicial, DateTime dataFinal)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(conta => (conta.CodSituacao.Equals(situacao1) || conta.CodSituacao.Equals(situacao2)) &&
                  conta.CodPessoa == codPessoa && conta.DataVencimento >= dataInicial && conta.DataVencimento <= dataFinal).OrderBy(conta => conta.DataVencimento).ToList();
            }
        }

        /// <summary>
        /// Obtém todas as situações de conta
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SituacaoConta> ObterSituacoesConta()
        {
            using (var context = new SaceContext())
            {
                var query = from situacaoConta in context.TbSituacaoConta
                            select new SituacaoConta
                            {
                                CodSituacao = situacaoConta.CodSituacao,
                                Descricao = situacaoConta.DescricaoSituacao
                            };
                return query.ToList();
            }
        }

        /// <summary>
        /// Atribui entidade à entidade persistente
        /// </summary>
        /// <param name="conta"></param>
        /// <param name="_conta"></param>
        private static void Atribuir(Conta conta, TbContum _conta)
        {
            _conta.CodConta = conta.CodConta;
            _conta.CodEntrada = conta.CodEntrada;
            _conta.CodPagamento = conta.CodPagamento;
            _conta.CodPessoa = conta.CodPessoa;
            _conta.CodPlanoConta = conta.CodPlanoConta;
            _conta.CodSaida = conta.CodSaida;
            _conta.CodSituacao = conta.CodSituacao.ToString();
            _conta.DataVencimento = conta.DataVencimento;
            _conta.Desconto = conta.Desconto;
            _conta.Observacao = conta.Observacao;
            _conta.NumeroDocumento = conta.NumeroDocumento;
            _conta.FormatoConta = conta.FormatoConta;
            _conta.Valor = conta.Valor;
        }


        /// <summary>
        /// Substitui um conjunto de contas por uma nova conta para receber do cartão de crédito. 
        /// </summary>
        /// <param name="listaContas">Contas que serão baixadas</param>
        /// <param name="valorPagamento">valor pago nessas contas</param>
        /// <param name="cartaoCredito">cartão de crédito quando necessário</param>
        /// <param name="parcelas">número de parcelas do pagamento</param>
        public static void QuitarContasCartaoCredito(List<long> listaContas, decimal valorPagamento, CartaoCredito cartaoCredito, int parcelas)
        {
            using (var context = new SaceContext())
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
                    Conta contaSubstituida = Obter((long)listaContas.ElementAtOrDefault(0)).ElementAtOrDefault(0);


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
                        Inserir(conta, context);
                    }
                }
                catch (Exception e)
                {
                    throw new DadosException("Não foi possível realizar a substituição de contas. Favor contactar o administrador.", e);
                }
            }
        }

        /// <summary>
        /// Substitui as contas associadas a um documento fiscal por uma lista de boletos
        /// </summary>
        /// <param name="cupomFiscal"></param>
        /// <param name="listaContaBoletos"></param>
        public static void Substituir(string cupomFiscal, List<Conta> listaContaBoletos)
        {
            using (var context = new SaceContext())
            {
                var transaction = context.Database.BeginTransaction();
                try
                {
                    var query = from conta in context.TbConta
                                where conta.NumeroDocumento.Equals(cupomFiscal)
                                select conta;

                    foreach (TbContum conta in query)
                    {
                        conta.CodSituacao = SituacaoConta.SITUACAO_SUBTITUIDA;
                    }
                    context.SaveChanges();
                    foreach (Conta boleto in listaContaBoletos)
                    {
                        Inserir(boleto, context);
                    }
                    transaction.Commit();

                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw new DadosException("Conta", e.Message, e);
                }
            }
        }
    }
}