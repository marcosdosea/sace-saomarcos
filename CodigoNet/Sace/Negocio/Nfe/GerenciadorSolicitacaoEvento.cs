using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public class GerenciadorSolicitacaoEvento
    {

        private readonly SaceContext context;

        public GerenciadorSolicitacaoEvento(SaceContext saceContext)
        {
            context = saceContext;
        }

        /// <summary>
        /// Insere um novo SolicitacaoEvento na base de dados
        /// </summary>
        /// <param name="SolicitacaoEvento"></param>
        /// <returns></returns>
        public long Inserir(SolicitacaoEventoNfe solicitacaoEvento)
        {
            
            try
            {
                if (ObterPorTiposolicitacaoEventoCodNfe(solicitacaoEvento.TipoSolicitacao, solicitacaoEvento.CodNfe).Count() > 0)
                    throw new NegocioException("Evento já está na fila para ser processado. Favor aguardar.");

                var tbSolicitacaoEventoNfe = new TbSolicitacaoEventoNfe();
                tbSolicitacaoEventoNfe.TipoSolicitacao = solicitacaoEvento.TipoSolicitacao;
                tbSolicitacaoEventoNfe.CodNfe = solicitacaoEvento.CodNfe;
                context.Add(tbSolicitacaoEventoNfe);
                context.SaveChanges();

                return solicitacaoEvento.IdSolicitacaoEvento;
            }
            catch (Exception e)
            {
                throw new DadosException("SolicitacaoEvento", e.Message, e);
            }
        }

        /// <summary>
        /// Remove SolicitacaoEvento da base de dados
        /// </summary>
        /// <param name="codSolicitacaoEvento"></param>
        public void Remover(uint codSolicitacaoEvento)
        {
            try
            {
                var solicitacaoEvento = context.TbSolicitacaoEventoNves.Find(new TbSolicitacaoEventoNfe { IdSolicitacaoEvento = codSolicitacaoEvento });
                if (solicitacaoEvento != null)
                {
                    context.Remove(solicitacaoEvento );
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new DadosException("SolicitacaoEvento", e.Message, e);
            }
        }

        /// <summary>
        /// Obter todos os SolicitacaoEventos pelo tipo solicitacaoEvento
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SolicitacaoEventoNfe> ObterPorTiposolicitacaoEvento(string tiposolicitacaoEvento)
        {
            var query = from solicitacao in context.TbSolicitacaoEventoNves
                        where solicitacao.TipoSolicitacao.Equals(tiposolicitacaoEvento)
                        orderby solicitacao.IdSolicitacaoEvento
                        select new SolicitacaoEventoNfe
                        {
                            CodNfe = solicitacao.CodNfe,
                            IdSolicitacaoEvento = solicitacao.IdSolicitacaoEvento,
                            TipoSolicitacao = solicitacao.TipoSolicitacao
                        };
            return query.AsNoTracking().ToList();
        }

        /// <summary>
        /// Obter todos os SolicitacaoEventos pelo tipo solicitacaoEvento
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SolicitacaoEventoNfe> ObterPorTiposolicitacaoEventoCodNfe(string tiposolicitacaoEvento, int codNfe)
        {
           var query = from solicitacao in context.TbSolicitacaoEventoNves
                        where solicitacao.TipoSolicitacao.Equals(tiposolicitacaoEvento) && solicitacao.CodNfe.Equals(codNfe)
                        orderby solicitacao.IdSolicitacaoEvento
                        select new SolicitacaoEventoNfe
                        {
                            CodNfe = solicitacao.CodNfe,
                            IdSolicitacaoEvento = solicitacao.IdSolicitacaoEvento,
                            TipoSolicitacao = solicitacao.TipoSolicitacao
                        };
            return query.AsNoTracking().ToList();
        }
    }
}