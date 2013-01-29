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

        public static GerenciadorMovimentacaoConta getInstace()
        {
            if (gMovimentacaoConta == null)
            {
                gMovimentacaoConta = new GerenciadorMovimentacaoConta();
            }
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
                var repMovimentacaoConta = new RepositorioGenerico<MovimentacaoContaE>();
                ObjectContext context = repMovimentacaoConta.ObterContexto();
                //var repConta = new RepositorioGenerico<ContaE>();

                MovimentacaoContaE _movimentacaoE = new MovimentacaoContaE();
                Atribuir(movimentacaoConta, _movimentacaoE);

                repMovimentacaoConta.Inserir(_movimentacaoE);

                // Atualiza saldo da conta bancária
                AtualizaSaldoContaBanco(movimentacaoConta, context);

                // Atualiza status da conta, entrada e saída 
                ContaE _contaE = AtualizaSituacaoConta((long)_movimentacaoE.codConta);
                AtualizaSituacaoPagamentosEntrada(_contaE);
                AtualizaSituacaoPagamentosSaida(_contaE);

                repMovimentacaoConta.SaveChanges();
                return _movimentacaoE.codMovimentacao;
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
        public Int64 Inserir(MovimentacaoConta movimentacaoConta, List<long> listaContas)
        {
            var repMovimentacaoConta = new RepositorioGenerico<MovimentacaoContaE>();
            var repConta = new RepositorioGenerico<ContaE>(repMovimentacaoConta.ObterContexto());

            decimal totalMovimentacao = movimentacaoConta.Valor;
            foreach (long codConta in listaContas)
            {
                if (totalMovimentacao > 0)
                {
                    ContaE _contaE = repConta.ObterEntidade(c => c.codConta == codConta);
                    if (!_contaE.codSituacao.Equals(SituacaoConta.SITUACAO_QUITADA))
                    {
                        movimentacaoConta.CodConta = codConta;
                        decimal valorPagar = Math.Round(_contaE.valor - _contaE.desconto, 2);
                        if (valorPagar <= totalMovimentacao)
                        {
                            movimentacaoConta.Valor = valorPagar;
                        }
                        else
                        {
                            movimentacaoConta.Valor = totalMovimentacao;
                        }
                        totalMovimentacao -= movimentacaoConta.Valor;

                        MovimentacaoContaE _movimentacaoE = new MovimentacaoContaE();
                        Atribuir(movimentacaoConta, _movimentacaoE);

                        repMovimentacaoConta.Inserir(_movimentacaoE);

                        // Atualiza saldo da conta bancária
                        AtualizaSaldoContaBanco(movimentacaoConta, repMovimentacaoConta.ObterContexto());

                        // Atualiza status da conta, entrada e saída 
                        AtualizaSituacaoConta(repConta, _contaE);
                        AtualizaSituacaoPagamentosEntrada(_contaE);
                        AtualizaSituacaoPagamentosSaida(_contaE);
                    }
                }
            }
            repMovimentacaoConta.SaveChanges();
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
                var repMovimentacaoConta = new RepositorioGenerico<MovimentacaoContaE>();
                var repConta = new RepositorioGenerico<ContaE>(repMovimentacaoConta.ObterContexto());

                MovimentacaoConta movimentacaoConta = Obter(codMovimentacaoConta).ElementAt(0);
                repMovimentacaoConta.Remover(m => m.codMovimentacao == codMovimentacaoConta);

                // Decrementa o saldo da conta
                movimentacaoConta.Valor *= (-1);
                AtualizaSaldoContaBanco(movimentacaoConta, repMovimentacaoConta.ObterContexto());

                // Atualiza status da conta, entrada e saída 
                ContaE _contaE = AtualizaSituacaoConta(movimentacaoConta.CodConta);
                AtualizaSituacaoPagamentosEntrada(_contaE);
                AtualizaSituacaoPagamentosSaida(_contaE);

                repMovimentacaoConta.SaveChanges();
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
                var repMovimentacaoConta = new RepositorioGenerico<MovimentacaoContaE>();

                IEnumerable<MovimentacaoConta> movimentosConta = ObterPorConta(codConta);
                foreach (MovimentacaoConta movimento in movimentosConta)
                {
                    Remover(movimento.CodMovimentacao);
                }
                repMovimentacaoConta.SaveChanges();
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
            var repMovimentacaoConta = new RepositorioGenerico<MovimentacaoContaE>();

            var saceEntities = (SaceEntities)repMovimentacaoConta.ObterContexto();
            var query = from movimentacao in saceEntities.MovimentacaoContaSet
                        join tipoMovimentacao in saceEntities.TipoMovimentacaoContaSet on movimentacao.codTipoMovimentacao equals tipoMovimentacao.codTipoMovimentacao
                        join pessoa in saceEntities.PessoaSet on movimentacao.codResponsavel equals pessoa.codPessoa
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
        private static void AtualizaSituacaoPagamentosSaida(ContaE _contaE)
        {
            var repSaida = new RepositorioGenerico<SaidaE>();
            var saceEntities = (SaceEntities)repSaida.ObterContexto();
            var query = from saida in saceEntities.SaidaSet
                        where saida.codSaida == _contaE.codSaida
                        select saida;
            foreach (SaidaE _saidaE in query)
            {
                if (!_contaE.codSaida.Equals(Global.SAIDA_PADRAO))
                {
                    if (GerenciadorConta.GetInstance().ObterPorSituacaoSaida(SituacaoConta.SITUACAO_ABERTA, (long)_contaE.codSaida).ToList().Count == 0)
                    {
                        _saidaE.codSituacaoPagamentos = SituacaoPagamentos.QUITADA;
                    }
                    else
                    {
                        _saidaE.codSituacaoPagamentos = SituacaoPagamentos.LANCADOS;
                    }
                }
            }
            repSaida.SaveChanges();
        }

        /// <summary>
        /// Atualiza Situacao dos pagamentos da entrada para quitado quando todas as contas estão quitadas
        /// </summary>
        /// <param name="_contaE"></param>
        private static void AtualizaSituacaoPagamentosEntrada(ContaE _contaE)
        {
            var repEntrada = new RepositorioGenerico<EntradaE>();
            var saceEntities = (SaceEntities)repEntrada.ObterContexto();
            var query = from entrada in saceEntities.EntradaSet
                        where entrada.codEntrada == _contaE.codEntrada
                        select entrada;
            foreach (EntradaE _entradaE in query)
            {
                if (!_contaE.codEntrada.Equals(Global.ENTRADA_PADRAO))
                {
                    if (GerenciadorConta.GetInstance().ObterPorSituacaoEntrada(SituacaoConta.SITUACAO_ABERTA, (long)_contaE.codEntrada).ToList().Count == 0)
                    {
                        _entradaE.codSituacaoPagamentos = SituacaoPagamentos.QUITADA;
                    }
                    else
                    {
                        _entradaE.codSituacaoPagamentos = SituacaoPagamentos.LANCADOS;
                    }
                }
            }
            repEntrada.SaveChanges();
        }

        /// <summary>
        /// Atualiza conta para quitada quando todas a soma de todas as movimentacoes quitam a conta
        /// </summary>
        /// <param name="_contaE"></param>
        private ContaE AtualizaSituacaoConta(long codConta)
        {
            var repConta = new RepositorioGenerico<ContaE>();
            var saceEntities = (SaceEntities)repConta.ObterContexto();
            var query = from conta in saceEntities.ContaSet
                        where conta.codConta == codConta
                        select conta;

            foreach (ContaE _contaE in query)
            {
                AtualizaSituacaoConta(repConta, _contaE);
                return _contaE;
            }
            return null;
        }

        private void AtualizaSituacaoConta(RepositorioGenerico<ContaE> repConta, ContaE _contaE)
        {
            if (!_contaE.codSituacao.Equals(SituacaoConta.SITUACAO_QUITADA))
            {
                decimal valorConta = Math.Round(_contaE.valor - _contaE.desconto, 2);
                decimal totalMovimentacoesConta = ObterPorConta(_contaE.codConta).Sum(c => c.Valor);
                if (valorConta <= totalMovimentacoesConta)
                    _contaE.codSituacao = SituacaoConta.SITUACAO_QUITADA;
                else
                    _contaE.codSituacao = SituacaoConta.SITUACAO_ABERTA;
            }
            repConta.SaveChanges();
        }


        /// <summary>
        /// Atualiza saldo da conta de acordo com o tipo de movimentacao
        /// </summary>
        /// <param name="movimentacaoConta"></param>
        /// <param name="_movimentacaoE"></param>
        private static void AtualizaSaldoContaBanco(MovimentacaoConta movimentacaoConta, ObjectContext context)
        {
            TipoMovimentacaoConta tipoMovimentacaoConta = GerenciadorTipoMovimentacaoConta.GetInstance().Obter(movimentacaoConta.CodTipoMovimentacao).ElementAt(0);
            var saceEntities = (SaceEntities)context;
            var query = from contaBanco in saceEntities.ContaBancoSet
                        where contaBanco.codContaBanco == movimentacaoConta.CodContaBanco
                        select contaBanco;
            foreach (ContaBancoE _contaBancoE in query)
            {

                if (tipoMovimentacaoConta.SomaSaldo)
                    _contaBancoE.saldo += movimentacaoConta.Valor;
                else
                    _contaBancoE.saldo += movimentacaoConta.Valor * (-1);
            }
            context.SaveChanges();
        }


        /// <summary>
        /// Atribui a classe entidade para entidade persistente
        /// </summary>
        /// <param name="movimentacaoConta"></param>
        /// <param name="_movimentacaoE"></param>
        private static void Atribuir(MovimentacaoConta movimentacaoConta, MovimentacaoContaE _movimentacaoE)
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
