using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public static class GerenciadorPlanoConta
    {

        /// <summary>
        /// Insere um novo plano de contas
        /// </summary>
        /// <param name="planoConta"></param>
        /// <returns></returns>
        public static long Inserir(PlanoConta planoConta)
        {
            try
            {
                var _planoConta = new TbPlanoContum();
                Atribuir(planoConta, _planoConta);
                using (var context = new SaceContext())
                {
                    context.Add(_planoConta);
                    context.SaveChanges();
                    return _planoConta.CodPlanoConta;
                }
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
        public static void Atualizar(PlanoConta planoConta)
        {
            if ((planoConta.CodPlanoConta == 1) || (planoConta.CodPlanoConta == 2))
                throw new NegocioException("O plano de conta não pode ser editado para manter a consitência da base de dados.");

            try
            {
                using (var context = new SaceContext())
                {

                    var _planoConta = context.TbPlanoConta.FirstOrDefault(p => p.CodPlanoConta == planoConta.CodPlanoConta);
                    if (_planoConta != null)
                    {
                        Atribuir(planoConta, _planoConta);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new NegocioException("Plano de contas não encontrado para atualização.");
                    }
                }
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
        public static void Remover(long codPlanoConta)
        {
            if ((codPlanoConta == 1) || (codPlanoConta == 2))
                throw new NegocioException("O plano de conta não pode ser removido para manter a consitência da base de dados.");
            try
            {
                using (var context = new SaceContext())
                {
                    var _planoConta = context.TbPlanoConta.FirstOrDefault(p => p.CodPlanoConta == codPlanoConta);

                    if (_planoConta != null)
                    {
                        context.Remove(_planoConta);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new NegocioException("Plano de conta não encontrado para remoção.");
                    }
                }
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
        private static IQueryable<PlanoConta> GetQuery(SaceContext context)
        {
            var query = from planoConta in context.TbPlanoConta
                        select new PlanoConta
                        {
                            CodPlanoConta = planoConta.CodPlanoConta,
                            CodGrupoConta = planoConta.CodGrupoConta,
                            Descricao = planoConta.Descricao,
                            DiaBase = planoConta.DiaBase == null ? (short)1 : (short)planoConta.DiaBase,
                            TipoConta = planoConta.CodTipoConta,
                            DescricaoTipoConta = planoConta.CodTipoContaNavigation.DescricaoTipoConta
                        };
            return query.AsNoTracking();
        }

        /// <summary>
        /// Obtém todos os planos de contas cadastrados
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<PlanoConta> ObterTodos()
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).ToList();
            }
        }

        /// <summary>
        /// Obtém planos de contas com o código especificiado
        /// </summary>
        /// <param name="codPlanoConta"></param>
        /// <returns></returns>
        public static IEnumerable<PlanoConta> Obter(int codPlanoConta)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(planoConta => planoConta.CodPlanoConta == codPlanoConta).ToList();
            }
        }

        /// <summary>
        /// Obtém planos de contas que iniciam com a descrição
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        public static IEnumerable<PlanoConta> ObterPorDescricao(string descricao)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(planoConta => planoConta.Descricao.StartsWith(descricao)).ToList();
            }
        }

        /// <summary>
        /// Atribui a entidade à entidade persistente
        /// </summary>
        /// <param name="planoConta"></param>
        /// <param name="_planoConta"></param>
        private static void Atribuir(PlanoConta planoConta, TbPlanoContum _planoConta)
        {
            _planoConta.CodPlanoConta = planoConta.CodPlanoConta;
            _planoConta.CodTipoConta = planoConta.TipoConta;
            _planoConta.Descricao = planoConta.Descricao;
            _planoConta.DiaBase = planoConta.DiaBase;
        }
    }
}