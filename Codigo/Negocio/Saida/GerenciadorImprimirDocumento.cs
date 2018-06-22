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
    public class GerenciadorImprimirDocumento
    {

        private static GerenciadorImprimirDocumento gImprimirDocumento;

        public static GerenciadorImprimirDocumento GetInstance()
        {
            if (gImprimirDocumento == null)
            {
                gImprimirDocumento = new GerenciadorImprimirDocumento();
            }
            return gImprimirDocumento;
        }

        /// <summary>
        /// Insere um novo ImprimirDocumento na base de dados
        /// </summary>
        /// <param name="ImprimirDocumento"></param>
        /// <returns></returns>
        public Int64 Inserir(tb_imprimir_documento documento)
        {
            var repImprimirDocumento = new RepositorioGenerico<tb_imprimir_documento>();
            try
            {
                if (ObterPorTipoDocumentoCodDocumento(documento.tipoDocumento, documento.codDocumento).Count() > 0)
                    throw new NegocioException("Documento já está na fila de impressão. Favor verificar se o computador está ligado.");


                repImprimirDocumento.Inserir(documento);
                repImprimirDocumento.SaveChanges();


                return documento.codImprimir;
            }
            catch (Exception e)
            {
                throw new DadosException("ImprimirDocumento", e.Message, e);
            }
        }

        /// <summary>
        /// Remove ImprimirDocumento da base de dados
        /// </summary>
        /// <param name="codImprimirDocumento"></param>
        public void Remover(Int64 codImprimirDocumento)
        {
            try
            {
                var repImprimirDocumento = new RepositorioGenerico<tb_imprimir_documento>();

                repImprimirDocumento.Remover(d => d.codImprimir == codImprimirDocumento);
                repImprimirDocumento.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("ImprimirDocumento", e.Message, e);
            }
        }

        /// <summary>
        /// Obter todos os ImprimirDocumentos pelo tipo documento
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tb_imprimir_documento> ObterPorTipoDocumento(string tipoDocumento)
        {
            var repImprimirDocumento = new RepositorioGenerico<tb_imprimir_documento>();

            var saceEntities = (SaceEntities)repImprimirDocumento.ObterContexto();
            var query = from imprimir in saceEntities.tb_imprimir_documento
                        where imprimir.tipoDocumento.Equals(tipoDocumento)
                        orderby imprimir.codImprimir
                        select imprimir;
            return query.ToList();
        }

        /// <summary>
        /// Obter todos os ImprimirDocumentos pelo tipo documento
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tb_imprimir_documento> ObterPorHost(string host)
        {
            var repImprimirDocumento = new RepositorioGenerico<tb_imprimir_documento>();

            var saceEntities = (SaceEntities)repImprimirDocumento.ObterContexto();
            var query = from imprimir in saceEntities.tb_imprimir_documento
                        where imprimir.hostSolicitante.Equals(host)
                        orderby imprimir.codImprimir
                        select imprimir;
            return query.ToList();
        }


        /// <summary>
        /// Obter todos os ImprimirDocumentos pelo tipo documento
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tb_imprimir_documento> ObterPorTipoDocumentoCodDocumento(string tipoDocumento, long codDocumento)
        {
            var repImprimirDocumento = new RepositorioGenerico<tb_imprimir_documento>();

            var saceEntities = (SaceEntities)repImprimirDocumento.ObterContexto();
            var query = from imprimir in saceEntities.tb_imprimir_documento
                        where imprimir.tipoDocumento.Equals(tipoDocumento) && imprimir.codDocumento.Equals(codDocumento) 
                        orderby imprimir.codImprimir
                        select imprimir;
            return query.ToList();
        }


        /// <summary>
        /// Obter todos os ImprimirDocumentos pelo tipo documento
        /// </summary>
        /// <returns></returns>
        public IEnumerable<tb_imprimir_documento> ObterPorTipoDocumentoHost(string tipoDocumento, string host)
        {
            var repImprimirDocumento = new RepositorioGenerico<tb_imprimir_documento>();

            var saceEntities = (SaceEntities)repImprimirDocumento.ObterContexto();
            var query = from imprimir in saceEntities.tb_imprimir_documento
                        where imprimir.tipoDocumento.Equals(tipoDocumento) && imprimir.hostSolicitante.Equals(host)
                        orderby imprimir.codImprimir
                        select imprimir;
            return query.ToList();
        }
    }
}