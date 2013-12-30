using System;
using System.Collections.Generic;
using System.Linq;
using Dados;
using Dominio;
using Util;
using System.IO;
using System.Threading;

namespace Negocio
{
    public class GerenciadorCupom
    {

        private static GerenciadorCupom gCupom;

        public static GerenciadorCupom GetInstace()
        {
            if (gCupom == null)
            {
                gCupom = new GerenciadorCupom();
            }
            return gCupom;
        }

        /// <summary>
        /// Insere dados do cupom
        /// </summary>
        /// <param name="cupom"></param>
        /// <returns></returns>
        public long InserirSolicitacaoCupom(long codSaida, decimal total)
        {
            var repCupom = new RepositorioGenerico<tb_solicitacao_cupom>();
            tb_solicitacao_cupom _cupomE = new tb_solicitacao_cupom();
            try
            {
                _cupomE.codSaida = codSaida;
                _cupomE.dataSolicitacao = DateTime.Now;
                _cupomE.enviada = false;
                _cupomE.total = total;

                repCupom.Inserir(_cupomE);
                repCupom.SaveChanges();

                return _cupomE.codSaida;
            }
            catch (Exception e)
            {
                // se ocorrer erro na inserção provavelmente é reenvio do cupom fiscal
                //throw new DadosException("Cupom", e.Message, e);
            }
            return 0;

        }

        /// <summary>
        /// Atualiza dados do cupom
        /// </summary>
        /// <param name="cupom"></param>
        public void EnviarProximoCupom()
        {
            try
            {
               string nomeComputador = System.Windows.Forms.SystemInformation.ComputerName;
               if (nomeComputador.Equals(Global.NOME_SERVIDOR))
               {
                   var repCupom = new RepositorioGenerico<tb_solicitacao_cupom>();
                   DirectoryInfo pastaECF = new DirectoryInfo(Global.PASTA_COMUNICACAO_FRENTE_LOJA);
                   if (pastaECF.Exists)
                   {
                       FileInfo[] files = pastaECF.GetFiles("*.TXT", SearchOption.TopDirectoryOnly);
                       if (files.Length == 0)
                       {
                           IQueryable<tb_solicitacao_cupom> solicitacoes = GetQuery().OrderBy(s => s.dataSolicitacao);
                           if (solicitacoes.Count() > 0)
                           {
                               Thread.Sleep(1000); // Aguarda 1 segundo para enviar o próximo cupum e evitar junção.
                               SortedList<long, decimal> saidaTotalAVista = new SortedList<long, decimal>();
                               tb_solicitacao_cupom solicitacaoE = solicitacoes.ToList().ElementAt(0);
                               saidaTotalAVista.Add(solicitacaoE.codSaida, solicitacaoE.total);
                               RemoverSolicitacaoCupom(solicitacaoE.codSaida);
                               GerenciadorSaida.GetInstance(null).GerarDocumentoFiscal(saidaTotalAVista, null);
                           }
                       }
                   }
                   
               }
            }
            catch (Exception e)
            {
                throw new DadosException("Cupom", e.Message, e);
            }
        }

        /// <summary>
        /// Remove dados do cupom
        /// </summary>
        /// <param name="codCupom"></param>
        public void RemoverSolicitacaoCupom(long codSaida)
        {
            try
            {
                var repCupom = new RepositorioGenerico<tb_solicitacao_cupom>();
                repCupom.Remover(s => s.codSaida == codSaida);
                repCupom.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Cupom", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<tb_solicitacao_cupom> GetQuery()
        {
            var repCupom = new RepositorioGenerico<tb_solicitacao_cupom>();
            var saceEntities = (SaceEntities)repCupom.ObterContexto();
            var query = from cupom in saceEntities.tb_solicitacao_cupom
                            select cupom;
            return query;
        }

    }
}