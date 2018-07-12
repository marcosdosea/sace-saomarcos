using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio;
using Dados;
using Util;
using System.Data.Common;

namespace Negocio
{
    public class GerenciadorSolicitacaoEvento
    {

        private static GerenciadorSolicitacaoEvento gSolicitacaoEvento;

        public static GerenciadorSolicitacaoEvento GetInstance()
        {
            if (gSolicitacaoEvento == null)
            {
                gSolicitacaoEvento = new GerenciadorSolicitacaoEvento();
            }
            return gSolicitacaoEvento;
        }

        /// <summary>
        /// Insere um novo SolicitacaoEvento na base de dados
        /// </summary>
        /// <param name="SolicitacaoEvento"></param>
        /// <returns></returns>
        public Int64 Inserir(tb_solicitacao_evento_nfe solicitacaoEvento)
        {
            var repSolicitacaoEvento = new RepositorioGenerico<tb_solicitacao_evento_nfe>();
            try
            {
                if (ObterPorTiposolicitacaoEventoCodNfe(solicitacaoEvento.tipoSolicitacao, solicitacaoEvento.codNFe).Count() > 0)
                    throw new NegocioException("Evento já está na fila para ser processado. Favor aguardar.");


                repSolicitacaoEvento.Inserir(solicitacaoEvento);
                repSolicitacaoEvento.SaveChanges();


                return solicitacaoEvento.idSolicitacaoEvento;
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
        public void Remover(Int64 codSolicitacaoEvento)
        {
            try
            {
                var repSolicitacaoEvento = new RepositorioGenerico<tb_solicitacao_evento_nfe>();

                repSolicitacaoEvento.Remover(d => d.idSolicitacaoEvento == codSolicitacaoEvento);
                repSolicitacaoEvento.SaveChanges();
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
        public IEnumerable<tb_solicitacao_evento_nfe> ObterPorTiposolicitacaoEvento(string tiposolicitacaoEvento)
        {
            var repSolicitacaoEvento = new RepositorioGenerico<tb_solicitacao_evento_nfe>();

            var saceEntities = (SaceEntities)repSolicitacaoEvento.ObterContexto();
            var query = from solicitacao in saceEntities.tb_solicitacao_evento_nfe
                        where solicitacao.tipoSolicitacao.Equals(tiposolicitacaoEvento)
                        orderby solicitacao.idSolicitacaoEvento
                        select solicitacao;
            return query.ToList();
        }

        /// <summary>
        /// Obter todos os SolicitacaoEventos pelo tipo solicitacaoEvento
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tb_solicitacao_evento_nfe> ObterPorTiposolicitacaoEventoCodNfe(string tiposolicitacaoEvento, int codNfe)
        {
            var repSolicitacaoEvento = new RepositorioGenerico<tb_solicitacao_evento_nfe>();

            var saceEntities = (SaceEntities)repSolicitacaoEvento.ObterContexto();
            var query = from solicitacao in saceEntities.tb_solicitacao_evento_nfe
                        where solicitacao.tipoSolicitacao.Equals(tiposolicitacaoEvento) && solicitacao.codNFe.Equals(codNfe)
                        orderby solicitacao.idSolicitacaoEvento
                        select solicitacao;
            return query.ToList();
        }
    }

}