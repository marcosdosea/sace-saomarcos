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
using System.Data.Objects;


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
                AtualizaSaldoContaBanco(_movimentacaoContaE);
                ContaE _contaE = AtualizaSituacaoConta((long)_movimentacaoContaE.codConta);
                AtualizaSituacaoPagamentosEntrada(_contaE);
                AtualizaSituacaoPagamentosSaida(_contaE);

                return _movimentacaoContaE.codMovimentacao;
            }
            catch (Exception e)
            {
                throw new DadosException("Movimentação de Conta", e.Message, e);
            }

        }

        /// <summary>
        /// Insere o valor de uma movimentacao, inserindo uma nova movimentacao para cada conta
        /// </summary>
        /// <param name="movimentacaoConta"></param>
        /// <param name="listaContas"></param>
        /// <returns></returns>
        public Int64 Inserir(MovimentacaoConta movimentacaoConta, List<long> listaContas, decimal totalPago)
        {
            try
            {
                decimal totalMovimentacao = movimentacaoConta.Valor;
                foreach (long codConta in listaContas)
                {
                    if (totalMovimentacao > 0)
                    {
                        var queryContas = from conta in saceContext.ContaSet
                                          where conta.codConta == codConta
                                          select conta;
                        IEnumerable<ContaE> contasE = queryContas.ToList();
                        foreach (ContaE _contaE in contasE)
                        {
                            if (!_contaE.codSituacao.Equals(SituacaoConta.SITUACAO_QUITADA))
                            {
                                movimentacaoConta.CodConta = codConta;
                                decimal valorPagar = Math.Round(_contaE.valor - _contaE.desconto, 2) - totalPago;
                                
                                if (valorPagar <= totalMovimentacao)
                                {
                                    movimentacaoConta.Valor = valorPagar;
                                }
                                else
                                {
                                    movimentacaoConta.Valor = totalMovimentacao;
                                }
                                totalMovimentacao -= movimentacaoConta.Valor;
                                totalPago = 0;

                                MovimentacaoContaE _movimentacaoE = new MovimentacaoContaE();
                                Atribuir(movimentacaoConta, _movimentacaoE);

                                repMovimentacaoConta.Inserir(_movimentacaoE);
                                saceContext.SaveChanges();

                                // Atualiza saldo da conta bancária
                                AtualizaSaldoContaBanco(_movimentacaoE);
                                AtualizaSituacaoConta(_contaE.codConta);
                                AtualizaSituacaoPagamentosEntrada(_contaE);
                                AtualizaSituacaoPagamentosSaida(_contaE);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Movimentação de Conta", e.Message, e);
            }
            return 0;
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
                    long codConta = (long) _movimentacaoContaE.codConta;
                    repMovimentacaoConta.Remover(_movimentacaoContaE);
                    saceContext.SaveChanges();

                    // Decrementa o saldo da conta
                    _movimentacaoContaE.valor *= (-1);
                    AtualizaSaldoContaBanco(_movimentacaoContaE);

                    // Atualiza status da conta, entrada e saída 
                    ContaE _contaE = AtualizaSituacaoConta(codConta);
                    AtualizaSituacaoPagamentosEntrada(_contaE);
                    AtualizaSituacaoPagamentosSaida(_contaE);
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
            //repMovimentacaoConta = new RepositorioGenerico<MovimentacaoContaE>(saceContext);
            var query = from movimentacao in saceContext.MovimentacaoContaSet
                        join tipoMovimentacao in saceContext.TipoMovimentacaoContaSet on movimentacao.codTipoMovimentacao equals tipoMovimentacao.codTipoMovimentacao
                        join pessoa in saceContext.PessoaSet on movimentacao.codResponsavel equals pessoa.codPessoa
                        select new MovimentacaoConta
                        {
                            CodConta = (long)movimentacao.codConta,
                            CodContaBanco = movimentacao.codContaBanco,
                            CodMovimentacao = movimentacao.codMovimentacao,
                            CodResponsavel = movimentacao.codResponsavel,
                            NomeResponsavel = pessoa.nome,
                            CodTipoMovimentacao = movimentacao.codTipoMovimentacao,
                            DescricaoTipoMovimentacao = tipoMovimentacao.descricao,
                            DataHora = movimentacao.dataHora,
                            SomaSaldo = tipoMovimentacao.somaSaldo,
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
        /// Atualiza Situacao dos pagamentos da saída para quitado quando todas as contas estão quitadas
        /// </summary>
        /// <param name="_contaE"></param>
        private void AtualizaSituacaoPagamentosSaida(ContaE _contaE)
        {
            var query = from saida in saceContext.SaidaSet
                        where saida.codSaida == _contaE.codSaida
                        select saida;
            SaidaE _saidaE = query.ToList().ElementAtOrDefault(0);
            if (_saidaE != null)
            {
                if (!_contaE.codSaida.Equals(Global.SAIDA_PADRAO))
                {
                    if (GerenciadorConta.GetInstance(saceContext).ObterPorSituacaoSaida(SituacaoConta.SITUACAO_ABERTA, (long)_contaE.codSaida).ToList().Count == 0)
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
                        GerenciadorSaida.GetInstance(saceContext).AtualizarTipoPedidoGeradoPorSaida(_saidaE.codTipoSaida, _saidaE.pedidoGerado, somaMovimentacoes, _saidaE.codSaida);
                        //_saidaE.totalAVista = somaMovimentacoes;
                    }
                    else
                    {
                        _saidaE.codSituacaoPagamentos = SituacaoPagamentos.LANCADOS;
                    }
                }
            }
            saceContext.SaveChanges();
        }

        /// <summary>
        /// Atualiza Situacao dos pagamentos da entrada para quitado quando todas as contas estão quitadas
        /// </summary>
        /// <param name="_contaE"></param>
        private void AtualizaSituacaoPagamentosEntrada(ContaE _contaE)
        {
            var query = from entrada in saceContext.EntradaSet
                        where entrada.codEntrada == _contaE.codEntrada
                        select entrada;
            EntradaE _entradaE = query.ToList().ElementAtOrDefault(0);

            if (_entradaE != null)
            {
                if (!_contaE.codEntrada.Equals(Global.ENTRADA_PADRAO))
                {
                    if (GerenciadorConta.GetInstance(saceContext).ObterPorSituacaoEntrada(SituacaoConta.SITUACAO_ABERTA, (long)_contaE.codEntrada).ToList().Count == 0)
                    {
                        _entradaE.codSituacaoPagamentos = SituacaoPagamentos.QUITADA;
                    }
                    else
                    {
                        _entradaE.codSituacaoPagamentos = SituacaoPagamentos.LANCADOS;
                    }
                }
            }
            saceContext.SaveChanges();
        }

        /// <summary>
        /// Atualiza conta para quitada quando todas a soma de todas as movimentacoes quitam a conta
        /// </summary>
        /// <param name="_contaE"></param>
        private ContaE AtualizaSituacaoConta(long codConta)
        {
            var query = from conta in saceContext.ContaSet
                        where conta.codConta == codConta
                        select conta;
            ContaE _contaE = query.ToList().ElementAtOrDefault(0);
            if (_contaE != null)
            {
                decimal valorConta = Math.Round(_contaE.valor - _contaE.desconto, 2);
                decimal totalMovimentacoesConta = ObterPorConta(_contaE.codConta).Sum(c => c.Valor);
                if (valorConta <= totalMovimentacoesConta)
                    _contaE.codSituacao = SituacaoConta.SITUACAO_QUITADA;
                else
                    _contaE.codSituacao = SituacaoConta.SITUACAO_ABERTA;
            }
            saceContext.SaveChanges();
            return _contaE;
        }

        /// <summary>
        /// Atualiza saldo da conta de acordo com o tipo de movimentacao
        /// </summary>
        /// <param name="movimentacaoConta"></param>
        /// <param name="_movimentacaoE"></param>
        private void AtualizaSaldoContaBanco(MovimentacaoContaE movimentacaoContaE)
        {
            //TipoMovimentacaoConta tipoMovimentacaoConta = GerenciadorTipoMovimentacaoConta.GetInstance().Obter(movimentacaoConta.CodTipoMovimentacao).ElementAt(0);
            //RepositorioGenerico<ContaBanco> repContaBanco = new RepositorioGenerico<ContaBanco>();
            var queryTipoMovConta = from tipoMovimentacaoContaE in saceContext.TipoMovimentacaoContaSet
                                    where tipoMovimentacaoContaE.codTipoMovimentacao == movimentacaoContaE.codTipoMovimentacao
                                    select tipoMovimentacaoContaE;
            TipoMovimentacaoContaE tipoMovimentacaoConta = queryTipoMovConta.First();


            var query = from contaBanco in saceContext.ContaBancoSet
                        where contaBanco.codContaBanco == movimentacaoContaE.codContaBanco
                        select contaBanco;
            List<ContaBancoE> listaContaBanco = query.ToList();
            foreach (ContaBancoE _contaBancoE in listaContaBanco)
            {
                if (tipoMovimentacaoConta.somaSaldo)
                    _contaBancoE.saldo += movimentacaoContaE.valor;
                else
                    _contaBancoE.saldo += movimentacaoContaE.valor * (-1);
            }
            saceContext.SaveChanges();
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
