using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace Negocio
{
    public static class GerenciadorImprimirDocumento
    {
        /// <summary>
        /// Insere um novo ImprimirDocumento na base de dados
        /// </summary>
        /// <param name="ImprimirDocumento"></param>
        /// <returns></returns>
        public static long Inserir(ImprimirDocumento documento)
        {
            using (var context = new SaceContext())
            {
                try
                {
                    if (ObterPorTipoDocumentoCodDocumento(documento.TipoDocumento, documento.CodDocumento).Count() > 0)
                        throw new NegocioException("Documento já está na fila de impressão. Favor verificar se o computador está ligado.");
                    var _documento = new TbImprimirDocumento();
                    Atribuir(documento, _documento);
                    context.Add(_documento);
                    context.SaveChanges();

                    return _documento.CodImprimir;
                }
                catch (Exception e)
                {
                    throw new DadosException("ImprimirDocumento", e.Message, e);
                }
            }
        }


        /// <summary>
        /// Remove ImprimirDocumento da base de dados
        /// </summary>
        /// <param name="codImprimirDocumento"></param>
        public static void Remover(long codImprimirDocumento)
        {
            using (var context = new SaceContext())
            {
                try
                {
                    var _imprimirDocumento = context.TbImprimirDocumentos.FirstOrDefault(i => i.CodImprimir == codImprimirDocumento);
                    if (_imprimirDocumento != null)
                    {
                        context.Remove(_imprimirDocumento);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new NegocioException("Não encontrou documento para exclusão.");
                    }
                }
                catch (Exception e)
                {
                    throw new DadosException("ImprimirDocumento", e.Message, e);
                }
            }
        }

        /// <summary>
        /// Consulta padrão para retornar dados do cartão de crédito
        /// </summary>
        /// <returns></returns>
        private static IQueryable<ImprimirDocumento> GetQuery(SaceContext context)
        {
            var query = from imprimir in context.TbImprimirDocumentos
                        select new ImprimirDocumento
                        {
                            CodDocumento = imprimir.CodDocumento,
                            TipoDocumento = imprimir.TipoDocumento,
                            CodImprimir = imprimir.CodImprimir,
                            Desconto = imprimir.Desconto,
                            HostSolicitante = imprimir.HostSolicitante,
                            Total = imprimir.Total,
                            TotalAvista = imprimir.TotalAvista
                        };
            return query.AsNoTracking();
        }
        /// <summary>
        /// Obter todos os ImprimirDocumentos pelo tipo documento
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ImprimirDocumento> ObterPorTipoDocumento(string tipoDocumento)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).
                Where(d => d.TipoDocumento == tipoDocumento).
                OrderBy(d => d.CodImprimir).
                ToList();
            }
        }

        /// <summary>
        /// Obter todos os ImprimirDocumentos pelo tipo documento
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ImprimirDocumento> ObterPorHost(string host)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).
                Where(d => d.HostSolicitante.Equals(host)).
                OrderBy(d => d.CodImprimir).
                ToList();
            }
        }


        /// <summary>
        /// Obter todos os ImprimirDocumentos pelo tipo documento
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ImprimirDocumento> ObterPorTipoDocumentoCodDocumento(string tipoDocumento, long codDocumento)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).
                Where(d => d.TipoDocumento.Equals(tipoDocumento) && d.CodDocumento.Equals(codDocumento)).
                OrderBy(d => d.CodImprimir).
                ToList();
            }
        }


        /// <summary>
        /// Obter todos os ImprimirDocumentos pelo tipo documento
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ImprimirDocumento> ObterPorTipoDocumentoHost(string tipoDocumento, string host)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).
                Where(d => d.TipoDocumento.Equals(tipoDocumento) && d.HostSolicitante.Equals(host)).
                OrderBy(d => d.CodImprimir).
                ToList();
            }
        }

        private static void Atribuir(ImprimirDocumento documento, TbImprimirDocumento _documento)
        {
            _documento.CodDocumento = documento.CodDocumento;
            _documento.TipoDocumento = documento.TipoDocumento;
            _documento.CodImprimir = documento.CodImprimir;
            _documento.Desconto = documento.Desconto;
            _documento.HostSolicitante = documento.HostSolicitante;
            _documento.Total = documento.Total;
            _documento.TotalAvista = documento.TotalAvista;
        }
    }
}