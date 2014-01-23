using System;
using System.Collections.Generic;
using System.Linq;
using Dados;
using Dominio;

namespace Negocio
{
    public class GerenciadorPlanoConta 
    {
        private static GerenciadorPlanoConta gPlanoConta;
        
        public static GerenciadorPlanoConta GetInstance()
        {
            if (gPlanoConta == null)
            {
                gPlanoConta = new GerenciadorPlanoConta();
            }
            return gPlanoConta;
        }


        /// <summary>
        /// Insere um novo plano de contas
        /// </summary>
        /// <param name="planoConta"></param>
        /// <returns></returns>
        public Int64 Inserir(PlanoConta planoConta)
        {
            try
            {
                var repPlanoConta = new RepositorioGenerico<PlanoContaE>();

                PlanoContaE _planoContaE = new PlanoContaE();
                Atribuir(planoConta, _planoContaE);

                repPlanoConta.Inserir(_planoContaE);
                repPlanoConta.SaveChanges();

                return _planoContaE.codPlanoConta;
            }
            catch (Exception e)
            {
                throw new DadosException("Plano de Contas", e.Message, e);
            }
        }

        /// <summary>
        /// Atualiza os dados do plano de contas
        /// </summary>
        /// <param name="planoConta"></param>
        public void Atualizar(PlanoConta planoConta)
        {
            if ((planoConta.CodPlanoConta == 1) || (planoConta.CodPlanoConta == 2))
                throw new NegocioException("O plano de conta não pode ser editado para manter a consitência da base de dados.");
            
            try
            {
                var repPlanoConta = new RepositorioGenerico<PlanoContaE>();

                PlanoContaE _planoContaE = repPlanoConta.ObterEntidade(pc => pc.codPlanoConta == planoConta.CodPlanoConta);
                Atribuir(planoConta, _planoContaE);
                
                repPlanoConta.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Plano de Contas", e.Message, e);
            }
        }

        /// <summary>
        /// Remove um plano de conta
        /// </summary>
        /// <param name="codplanoConta"></param>
        public void Remover(Int64 codplanoConta)
        {
            if ((codplanoConta == 1) || (codplanoConta == 2))
                throw new NegocioException("O plano de conta não pode ser removido para manter a consitência da base de dados.");
            try
            {
                var repPlanoConta = new RepositorioGenerico<PlanoContaE>();

                repPlanoConta.Remover(pc => pc.codPlanoConta == codplanoConta);
                repPlanoConta.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Plano de Contas", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<PlanoConta> GetQuery()
        {
            var repPlanoConta = new RepositorioGenerico<PlanoContaE>();

            var saceEntities = (SaceEntities)repPlanoConta.ObterContexto();
            var query = from planoConta in saceEntities.PlanoContaSet
                        join tipoConta in saceEntities.TipoContaSet on planoConta.codTipoConta equals tipoConta.codTipoConta
                        select new PlanoConta
                        {
                            CodPlanoConta = planoConta.codPlanoConta,
                            CodGrupoConta = planoConta.codGrupoConta,
                            Descricao = planoConta.descricao,
                            DiaBase = planoConta.diaBase == null ? (short) 1 : (short) planoConta.diaBase ,
                            TipoConta = planoConta.codTipoConta,
                            DescricaoTipoConta = tipoConta.descricaoTipoConta
                        };
            return query;
        }

        /// <summary>
        /// Obtém todos os planos de contas cadastrados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<PlanoConta> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Obtém planos de contas com o código especificiado
        /// </summary>
        /// <param name="codPlanoConta"></param>
        /// <returns></returns>
        public IEnumerable<PlanoConta> Obter(int codPlanoConta)
        {
            return GetQuery().Where(planoConta => planoConta.CodPlanoConta == codPlanoConta).ToList();
        }

        /// <summary>
        /// Obtém planos de contas que iniciam com a descrição
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public IEnumerable<PlanoConta> ObterPorDescricao(string descricao)
        {
            return GetQuery().Where(planoConta => planoConta.Descricao.StartsWith(descricao)).ToList();
        }

        /// <summary>
        /// Atribui a entidade à entidade persistente
        /// </summary>
        /// <param name="planoConta"></param>
        /// <param name="_planoContaE"></param>
        private static void Atribuir(PlanoConta planoConta, PlanoContaE _planoContaE)
        {
            _planoContaE.codPlanoConta = planoConta.CodPlanoConta;
            _planoContaE.codTipoConta = planoConta.TipoConta;
            _planoContaE.descricao = planoConta.Descricao;
            _planoContaE.diaBase = planoConta.DiaBase;
        }
    }
}