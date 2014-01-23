using System;
using System.Collections.Generic;
using System.Linq;
using Dados;
using Dominio;

namespace Negocio
{
    public class GerenciadorTipoMovimentacaoConta
    {
        private static GerenciadorTipoMovimentacaoConta gTipoMovimentacaoConta;
        
        public static GerenciadorTipoMovimentacaoConta GetInstance()
        {
            if (gTipoMovimentacaoConta == null)
            {
                gTipoMovimentacaoConta = new GerenciadorTipoMovimentacaoConta();
            }
            return gTipoMovimentacaoConta;
        }

        /// <summary>
        /// Insere um novo tipo de movimentacao
        /// </summary>
        /// <param name="tipoMovimentacaoConta"></param>
        /// <returns></returns>
        public Int64 Inserir(TipoMovimentacaoConta tipoMovimentacaoConta)
        {
            try
            {
                var repTipoMovimentacaoConta = new RepositorioGenerico<TipoMovimentacaoContaE>();

                TipoMovimentacaoContaE _tipoMovimentacaoContaE = new TipoMovimentacaoContaE();
                _tipoMovimentacaoContaE.descricao = tipoMovimentacaoConta.Descricao;
                _tipoMovimentacaoContaE.somaSaldo = tipoMovimentacaoConta.SomaSaldo;

                repTipoMovimentacaoConta.Inserir(_tipoMovimentacaoContaE);
                repTipoMovimentacaoConta.SaveChanges();
                
                return _tipoMovimentacaoContaE.codTipoMovimentacao;
            }
            catch (Exception e)
            {
                throw new DadosException("Tipo Movimentação Conta", e.Message, e);
            }
        }

        /// <summary>
        /// Atualiza os dados do tipo de movimentacao
        /// </summary>
        /// <param name="tipoMovimentacaoConta"></param>
        public void atualizar(TipoMovimentacaoConta tipoMovimentacaoConta)
        {
            try
            {
                var repTipoMovimentacaoConta = new RepositorioGenerico<TipoMovimentacaoContaE>();

                TipoMovimentacaoContaE _tipoMovimentacaoConta = repTipoMovimentacaoConta.ObterEntidade(tmc => tmc.codTipoMovimentacao == tipoMovimentacaoConta.CodTipoMovimentacao);

                _tipoMovimentacaoConta.descricao = tipoMovimentacaoConta.Descricao;
                _tipoMovimentacaoConta.somaSaldo = tipoMovimentacaoConta.SomaSaldo;

                repTipoMovimentacaoConta.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Tipo Movimentação Conta", e.Message, e);
            }
        }

        /// <summary>
        /// Remove um tipo de movimentacao de conta
        /// </summary>
        /// <param name="codTipoMovimentacaoConta"></param>
        public void Remover(Int32 codTipoMovimentacaoConta)
        {
            try
            {
                var repTipoMovimentacaoConta = new RepositorioGenerico<TipoMovimentacaoContaE>();

                repTipoMovimentacaoConta.Remover(tmc => tmc.codTipoMovimentacao == codTipoMovimentacaoConta);
                repTipoMovimentacaoConta.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Tipo Movimentação Conta", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<TipoMovimentacaoConta> GetQuery()
        {
            var repTipoMovimentacaoConta = new RepositorioGenerico<TipoMovimentacaoContaE>();
            var saceEntities = (SaceEntities)repTipoMovimentacaoConta.ObterContexto();
            var query = from tipoMovimentacaoConta in saceEntities.TipoMovimentacaoContaSet
                        select new TipoMovimentacaoConta
                        {
                            CodTipoMovimentacao = tipoMovimentacaoConta.codTipoMovimentacao,
                            Descricao = tipoMovimentacaoConta.descricao,
                            SomaSaldo = tipoMovimentacaoConta.somaSaldo
                        };

            return query;
        }

        /// <summary>
        /// Obtém todos os tipoMovimentacoes de contas cadastrados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TipoMovimentacaoConta> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Obtém tipoMovimentacao de contas com o código especificiado
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public IEnumerable<TipoMovimentacaoConta> Obter(int codTipoMovimentacaoConta)
        {
            return GetQuery().Where(tmc => tmc.CodTipoMovimentacao == codTipoMovimentacaoConta).ToList();
        }

        /// <summary>
        /// Obtém tipoMovimentacaos de contas que iniciam com a descrição
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public IEnumerable<TipoMovimentacaoConta> ObterPorDescricao(string descricao)
        {
            return GetQuery().Where(tmc => tmc.Descricao.StartsWith(descricao)).ToList();
        }


    }
}
