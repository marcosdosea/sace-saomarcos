using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace Negocio
{
    public class GerenciadorImprimirDocumento
    {
        private readonly SaceContext context;

        public GerenciadorImprimirDocumento(SaceContext saceContext)
        {
            context = saceContext;
        }

        /// <summary>
        /// Insere um novo ImprimirDocumento na base de dados
        /// </summary>
        /// <param name="ImprimirDocumento"></param>
        /// <returns></returns>
        public Int64 Inserir(ImprimirDocumento documento)
        {
            TbImprimirDocumento _documento = new TbImprimirDocumento();
            try
            {
                if (ObterPorTipoDocumentoCodDocumento(documento.TipoDocumento, documento.CodDocumento).Count() > 0)
                    throw new NegocioException("Documento já está na fila de impressão. Favor verificar se o computador está ligado.");
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


        /// <summary>
        /// Remove ImprimirDocumento da base de dados
        /// </summary>
        /// <param name="codImprimirDocumento"></param>
        public void Remover(long codImprimirDocumento)
        {
            try
            {
                var _imprimirDocumento = new TbImprimirDocumento();
                _imprimirDocumento.CodImprimir = codImprimirDocumento;

                context.Remove(_imprimirDocumento);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("ImprimirDocumento", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta padrão para retornar dados do cartão de crédito
        /// </summary>
        /// <returns></returns>
        private IQueryable<ImprimirDocumento> GetQuery()
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
        public IEnumerable<ImprimirDocumento> ObterPorTipoDocumento(string tipoDocumento)
        {
            return GetQuery().
                Where(d => d.TipoDocumento == tipoDocumento).
                OrderBy(d => d.CodImprimir).
                ToList();
        }

        /// <summary>
        /// Obter todos os ImprimirDocumentos pelo tipo documento
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ImprimirDocumento> ObterPorHost(string host)
        {
            return GetQuery().
                Where(d => d.HostSolicitante.Equals(host) ).
                OrderBy(d => d.CodImprimir).
                ToList();
        }


        /// <summary>
        /// Obter todos os ImprimirDocumentos pelo tipo documento
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ImprimirDocumento> ObterPorTipoDocumentoCodDocumento(string tipoDocumento, long codDocumento)
        {
            return GetQuery().
                Where(d => d.TipoDocumento.Equals(tipoDocumento) && d.CodDocumento.Equals(codDocumento)).
                OrderBy(d => d.CodImprimir).
                ToList();
        }


        /// <summary>
        /// Obter todos os ImprimirDocumentos pelo tipo documento
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ImprimirDocumento> ObterPorTipoDocumentoHost(string tipoDocumento, string host)
        {
            return GetQuery().
                Where(d => d.TipoDocumento.Equals(tipoDocumento) && d.HostSolicitante.Equals(host)).
                OrderBy(d => d.CodImprimir).
                ToList();
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