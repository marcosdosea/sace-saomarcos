﻿using System;
using System.Collections.Generic;
using System.Linq;
using Dados;
using Dominio;
using Util;
using System.Transactions;
using Dominio.Consultas;


namespace Negocio
{
    public class GerenciadorMovimentacaoConta
    {
        private static GerenciadorMovimentacaoConta gMovimentacaoConta;
        private static SaceEntities saceContext;
        private static RepositorioGenerico<MovimentacaoContaE> repMovimentacaoConta;

        public static GerenciadorMovimentacaoConta GetInstance(SaceEntities context)
        {
            if (gMovimentacaoConta == null)
            {
                gMovimentacaoConta = new GerenciadorMovimentacaoConta();
            }
            if (context == null)
            {
                repMovimentacaoConta = new RepositorioGenerico<MovimentacaoContaE>();
            }
            else
            {
                repMovimentacaoConta = new RepositorioGenerico<MovimentacaoContaE>(context);
            }
            saceContext = (SaceEntities)repMovimentacaoConta.ObterContexto();
            return gMovimentacaoConta;
        }

        /// <summary>
        /// Insere uma movimentacao na conta bancária e atualiza os dados da conta associada
        /// </summary>
        /// <param name="movimentacaoConta">movimentacao da conta</param>
        /// <param name="conta">conta associada</param>
        /// <returns></returns>
        public Int64 Inserir(MovimentacaoConta movimentacaoConta)
        {
            try
            {

                MovimentacaoContaE _movimentacaoContaE = new MovimentacaoContaE();
                Atribuir(movimentacaoConta, _movimentacaoContaE);

                repMovimentacaoConta.Inserir(_movimentacaoContaE);
                saceContext.SaveChanges();

                // Atualiza saldo da conta bancária
                var query = from conta in saceContext.ContaSet
                            where conta.codConta == _movimentacaoContaE.codConta
                            select conta;
                ContaE _contaE = query.FirstOrDefault();
                if (_contaE != null)
                {
                    AtualizaSituacaoConta(_contaE, _movimentacaoContaE, false);
                    AtualizaSituacaoPagamentosEntrada(_contaE);
                    AtualizaSituacaoPagamentosSaida(_contaE, _movimentacaoContaE, false);
                }

                return _movimentacaoContaE.codMovimentacao;
            }
            catch (Exception e)
            {
                throw new DadosException("Movimentação de Conta", e.Message, e);
            }

        }

        /// <summary>
        /// Remover movimentacao
        /// </summary>
        /// <param name="codMovimentacaoConta"></param>
        public void Remover(Int64 codMovimentacaoConta)
        {
            try
            {
                var queryMovimentacao = from movimentacaoContaE in saceContext.MovimentacaoContaSet
                                        where movimentacaoContaE.codMovimentacao == codMovimentacaoConta
                                        select movimentacaoContaE;
                MovimentacaoContaE _movimentacaoContaE = queryMovimentacao.ToList().ElementAtOrDefault(0);
                if (_movimentacaoContaE != null)
                {
                    long codConta = (long)_movimentacaoContaE.codConta;
                    // Atualiza status da conta, entrada e saída 
                    var query = from conta in saceContext.ContaSet
                                where conta.codConta == _movimentacaoContaE.codConta
                                select conta;
                    ContaE _contaE = query.FirstOrDefault();
                    
                    repMovimentacaoConta.Remover(_movimentacaoContaE);
                    saceContext.SaveChanges();

                    if (_contaE != null)
                    {
                        AtualizaSituacaoConta(_contaE, _movimentacaoContaE, true);
                        AtualizaSituacaoPagamentosEntrada(_contaE);
                        AtualizaSituacaoPagamentosSaida(_contaE, _movimentacaoContaE, true);
                    }
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Movimentação de Conta", e.Message, e);
            }
        }

        /// <summary>
        /// Remover todas as movimentacoes de uma conta
        /// </summary>
        /// <param name="conta"></param>
        public void RemoverPorConta(long codConta)
        {
            try
            {
                var query = from movimentacaoSet in saceContext.MovimentacaoContaSet
                            where movimentacaoSet.codConta == codConta
                            select movimentacaoSet;
                List<MovimentacaoContaE> movimentacoes = query.ToList();
                foreach (MovimentacaoContaE _movimentacaoContaE in movimentacoes)
                {
                    Remover(_movimentacaoContaE.codMovimentacao);
                }
                saceContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Movimentação de Conta", e.Message, e);
            }
        }

        /// <summary>
        /// Query Geral para obter dados das movimentacoes
        /// </summary>
        /// <returns></returns>
        private IQueryable<MovimentacaoConta> GetQuery()
        {
            var query = from movimentacao in saceContext.MovimentacaoContaSet
                        select new MovimentacaoConta
                        {
                            CodConta = (long)movimentacao.codConta,
                            CodContaBanco = movimentacao.codContaBanco,
                            CodMovimentacao = movimentacao.codMovimentacao,
                            CodResponsavel = movimentacao.codResponsavel,
                            NomeResponsavel = movimentacao.tb_pessoa.nome,
                            CodTipoMovimentacao = movimentacao.codTipoMovimentacao,
                            DescricaoTipoMovimentacao = movimentacao.tb_tipo_movimentacao_conta.descricao,
                            DataHora = movimentacao.dataHora,
                            SomaSaldo = movimentacao.tb_tipo_movimentacao_conta.somaSaldo,
                            Valor = movimentacao.valor
                        };
            return query;
        }

        /// <summary>
        /// Obter movimentacoes
        /// </summary>
        /// <param name="codMovimentacao"></param>
        /// <returns></returns>
        public IEnumerable<MovimentacaoConta> Obter(long codMovimentacao)
        {
            return GetQuery().Where(m => m.CodMovimentacao == codMovimentacao).ToList();
        }

        /// <summary>
        /// Obter movimentacoes por conta
        /// </summary>
        /// <param name="codConta"></param>
        /// <returns></returns>
        public IEnumerable<MovimentacaoConta> ObterPorConta(long codConta)
        {
            return GetQuery().Where(m => m.CodConta == codConta).ToList();
        }

        /// <summary>
        /// Obter todas as contas em aberto da pessoa
        /// </summary>
        /// <param name="codPessoa"> código da pessoa </param>
        /// <returns> Contas </returns>
        public IEnumerable<MovimentacaoConta> ObterPorContas(List<long> listaCodContas)
        {
            return GetQuery().Where(m => listaCodContas.Contains(m.CodConta)).ToList();
        }


        /// <summary>
        /// Obtém totais de movimentação em um dado período
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TotaisMovimentacaoConta> ObterTotalMovimentacaoContaPeriodo(int codContaBanco, DateTime dataInicial, DateTime dataFinal)
        {
            var query = from movimentacao in saceContext.MovimentacaoContaSet
                        where movimentacao.codContaBanco == codContaBanco &&
                            movimentacao.dataHora >= dataInicial 
                            && movimentacao.dataHora <= dataFinal
                        group movimentacao by movimentacao.codTipoMovimentacao into gmov 

                        select new TotaisMovimentacaoConta
                        {
                            CodTipoMovimentacaoConta= gmov.Key,
                            DescricaoMovimentacaoConta = gmov.FirstOrDefault().tb_tipo_movimentacao_conta.descricao,
                            //SomaSaldo = movimentacao.tb_tipo_movimentacao_conta.somaSaldo,
                            TotalMovimentacaoConta = gmov.Sum(mov => mov.valor)
                        };
            return query.ToList();
        }



        public IQueryable<MovimentacaoPeriodo> ObterMovimentacaoContaPeriodo(DateTime dataInicio, DateTime dataFim)
        {
            DateTime dataBuscaInicio = dataInicio.Date;
            DateTime dataBuscaFim = dataFim.Date.AddDays(1).AddMinutes(-1);
            var query = from movimentacaoConta in saceContext.MovimentacaoContaSet
                        join tipoMovimentacao in saceContext.TipoMovimentacaoContaSet on movimentacaoConta.codTipoMovimentacao equals tipoMovimentacao.codTipoMovimentacao
                        join conta in saceContext.ContaSet on movimentacaoConta.codConta equals conta.codConta
                        join saida in saceContext.tb_saida on conta.codSaida equals saida.codSaida
                        join pessoa in saceContext.PessoaSet on saida.codCliente equals pessoa.codPessoa
                        where movimentacaoConta.dataHora >= dataBuscaInicio && movimentacaoConta.dataHora <= dataBuscaFim
                        select new MovimentacaoPeriodo
                        {
                            CodSaida = saida.codSaida,
                            DataSaida = saida.dataSaida,
                            DescricaoTipoMovimentacao = tipoMovimentacao.descricao,
                            NomeCliente = pessoa.nomeFantasia,
                            Valor = movimentacaoConta.valor,
                            DataHora = movimentacaoConta.dataHora
                        };
            return query;
        }




        /// <summary>
        /// Atualiza Situacao dos pagamentos da saída para quitado quando todas as contas estão quitadas
        /// </summary>
        /// <param name="_contaE"></param>
        public void AtualizaSituacaoPagamentosSaida(ContaE contaE, MovimentacaoContaE movimentacaoContaE, bool removeuMovimento)
        {
            if (!contaE.codSaida.Equals(Global.SAIDA_PADRAO))
            {
                var query = from saida in saceContext.tb_saida
                            where saida.codSaida == contaE.codSaida
                            select saida;
                tb_saida _saidaE = query.FirstOrDefault();
                if (_saidaE != null)
                {
                    if (_saidaE.totalAVista == movimentacaoContaE.valor)
                    {
                        if (removeuMovimento)
                            _saidaE.codSituacaoPagamentos = SituacaoPagamentos.LANCADOS;
                        else
                            _saidaE.codSituacaoPagamentos = SituacaoPagamentos.QUITADA;
                    }
                    else
                    {
                        if (GerenciadorConta.GetInstance(saceContext).ObterPorSituacaoSaida(SituacaoConta.SITUACAO_ABERTA, (long)contaE.codSaida).ToList().Count == 0)
                        {
                            _saidaE.codSituacaoPagamentos = SituacaoPagamentos.QUITADA;
                            IEnumerable<Conta> contas = GerenciadorConta.GetInstance(saceContext).ObterPorSaida(_saidaE.codSaida);
                            List<long> listaCodContas = new List<long>();
                            foreach (Conta conta in contas)
                            {
                                listaCodContas.Add(conta.CodConta);
                            }
                            decimal somaMovimentacoes = 0;
                            IEnumerable<MovimentacaoConta> listaMovimentacoes = ObterPorContas(listaCodContas);
                            foreach (MovimentacaoConta movimentacao in listaMovimentacoes)
                            {
                                somaMovimentacoes += movimentacao.Valor;
                            }
                            AtualizarTipoPedidoGeradoPorSaida(_saidaE.codTipoSaida, _saidaE.pedidoGerado, _saidaE.tipoDocumentoFiscal, somaMovimentacoes, _saidaE.codSaida);
                            //_saidaE.totalAVista = somaMovimentacoes;
                        }
                        else
                        {
                            _saidaE.codSituacaoPagamentos = SituacaoPagamentos.LANCADOS;
                        }
                    }
                    saceContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Atualiza Situacao dos pagamentos da entrada para quitado quando todas as contas estão quitadas
        /// </summary>
        /// <param name="_contaE"></param>
        private void AtualizaSituacaoPagamentosEntrada(ContaE _contaE)
        {
            if (_contaE.codEntrada != Global.ENTRADA_PADRAO)
            {
                var query = from entrada in saceContext.EntradaSet
                            where entrada.codEntrada == _contaE.codEntrada
                            select entrada;
                EntradaE _entradaE = query.ToList().ElementAtOrDefault(0);

                if (_entradaE != null)
                {
                    var query2 = from conta in saceContext.ContaSet
                                 where conta.codSituacao.Equals(SituacaoConta.SITUACAO_ABERTA) && conta.codEntrada == _contaE.codEntrada
                                 select conta;

                    if (query2.Count() == 0)
                    {
                        _entradaE.codSituacaoPagamentos = SituacaoPagamentos.QUITADA;
                    }
                    else
                    {
                        _entradaE.codSituacaoPagamentos = SituacaoPagamentos.LANCADOS;
                    }

                }
                saceContext.SaveChanges();
            }
        }

        /// <summary>
        /// Atualiza conta para quitada quando todas a soma de todas as movimentacoes quitam a conta
        /// </summary>
        /// <param name="_contaE"></param>
        private ContaE AtualizaSituacaoConta(ContaE contaE, MovimentacaoContaE movimentacaoE, bool removeuMovimento)
        {
            if (contaE != null)
            {
                decimal valorConta = Math.Round(contaE.valor - contaE.desconto, 2);
                if (valorConta == movimentacaoE.valor)
                {
                    if (removeuMovimento)
                        contaE.codSituacao = SituacaoConta.SITUACAO_ABERTA;
                    else
                        contaE.codSituacao = SituacaoConta.SITUACAO_QUITADA;
                }
                else
                {
                    decimal totalMovimentacoesConta = ObterPorConta(contaE.codConta).Sum(c => c.Valor);
                    if (valorConta <= totalMovimentacoesConta)
                        contaE.codSituacao = SituacaoConta.SITUACAO_QUITADA;
                    else
                        contaE.codSituacao = SituacaoConta.SITUACAO_ABERTA;
                }
            }
            saceContext.SaveChanges();
            return contaE;
        }

        /// <summary>
        /// Atualiza o número da nota fiscal gerada a partir do pedido (cupom fiscal) gerado
        /// </summary>
        /// <param name="nfe"></param>
        /// <param name="pedidoGerado"></param>
        private void AtualizarTipoPedidoGeradoPorSaida(int codTipoSaida, string pedidoGerado, string tipoDocumentoFiscal, decimal totalAVista, long codSaida)
        {
            try
            {
                var query = from saidaE in saceContext.tb_saida
                            where saidaE.codSaida == codSaida
                            select saidaE;
                foreach (tb_saida _saidaE in query)
                {
                    // atualiza o lucro na venda de acordo com o que foi pago
                    if (_saidaE.totalAVista > totalAVista)
                    {
                        _saidaE.totalLucro -= _saidaE.totalAVista - totalAVista;
                    }
                    else
                    {
                        _saidaE.totalLucro += totalAVista - _saidaE.totalAVista;
                    }
                    _saidaE.codTipoSaida = codTipoSaida;
                    if (string.IsNullOrEmpty(_saidaE.pedidoGerado))
                    {
                        _saidaE.pedidoGerado = pedidoGerado.ToString();
                        _saidaE.dataEmissaoDocFiscal = DateTime.Now;
                    }
                    _saidaE.totalAVista = totalAVista;
                    _saidaE.totalPago = totalAVista;
                    _saidaE.tipoDocumentoFiscal = tipoDocumentoFiscal;
                    if (_saidaE.total > 0)
                    {
                        _saidaE.desconto = Math.Round(Convert.ToDecimal((1 - (_saidaE.totalAVista / _saidaE.total)) * 100), 2);
                    }
                    else
                    {
                        _saidaE.desconto = 0;
                    }
                }
                saceContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Saida", e.Message, e);
            }
        }

        /// <summary>
        /// Atribui a classe entidade para entidade persistente
        /// </summary>
        /// <param name="movimentacaoConta"></param>
        /// <param name="_movimentacaoE"></param>
        private void Atribuir(MovimentacaoConta movimentacaoConta, MovimentacaoContaE _movimentacaoE)
        {
            _movimentacaoE.codConta = movimentacaoConta.CodConta;
            _movimentacaoE.codContaBanco = movimentacaoConta.CodContaBanco;
            _movimentacaoE.codResponsavel = movimentacaoConta.CodResponsavel;
            _movimentacaoE.codTipoMovimentacao = movimentacaoConta.CodTipoMovimentacao;
            _movimentacaoE.dataHora = movimentacaoConta.DataHora;
            _movimentacaoE.valor = movimentacaoConta.Valor;
        }
    }
}
