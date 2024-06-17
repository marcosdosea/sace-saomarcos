using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public class GerenciadorPlanoConta
    {
        private readonly SaceContext context;

        public GerenciadorPlanoConta(SaceContext saceContext)
        {
            context = saceContext;
        }


        /// <summary>
        /// Insere um novo plano de contas
        /// </summary>
        /// <param name="planoConta"></param>
        /// <returns></returns>
        public long Inserir(PlanoConta planoConta)
        {
            try
            {
                var _planoConta = new TbPlanoContum();
                Atribuir(planoConta, _planoConta);

                context.Add(_planoConta);
                context.SaveChanges();

                return _planoConta.CodPlanoConta;
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
                var _planoConta = new TbPlanoContum();
                _planoConta.CodPlanoConta = planoConta.CodPlanoConta;

                _planoConta = context.TbPlanoConta.Find(_planoConta);
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
                var _planoConta = new TbPlanoContum();
                _planoConta.CodPlanoConta = codplanoConta;

                context.Remove(_planoConta);
                context.SaveChanges();
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