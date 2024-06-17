using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dados;
using Dominio;

namespace Negocio
{
    public class GerenciadorSaidaPedido
    {
        private readonly SaceContext context;

        public GerenciadorSaidaPedido(SaceContext saceContext)
        {
            context = saceContext;
        }

        /// <summary>
        /// Insere dados de saídas associadas a um pedido
        /// </summary>
        /// <param name="saida"></param>
        /// <returns></returns>
        public Int64 Inserir(SaidaPedido saidaPedido)
        {
            try
            {
                var repSaidaPedido = new RepositorioGenerico<SaidaPedidoE>();
            
                SaidaPedidoE _saidaPedidoE = new SaidaPedidoE();
                _saidaPedidoE.codSaida = saidaPedido.CodSaida;
                _saidaPedidoE.codPedidoGerado = saidaPedido.CodPedido;
                _saidaPedidoE.totalAVista = saidaPedido.TotalAVista;

                repSaidaPedido.Inserir(_saidaPedidoE);
                repSaidaPedido.SaveChanges();
                
                return _saidaPedidoE.codSaida;
            }
            catch (Exception e)
            {
                throw new DadosException("Pedidos da Saída", e.Message, e);
            }
        }

        /// <summary>
        /// Atualizar dados de saídas associadas a um pedido
        /// </summary>
        /// <param name="saida"></param>
        /// <returns></returns>
        public void Atualizar(SaidaPedido saidaPedido)
        {
            try
            {
                var repSaidaPedido = new RepositorioGenerico<SaidaPedidoE>();
                var  saceContext = (SaceEntities) repSaidaPedido.ObterContexto();
                var query = from saidaPedidoE in saceContext.SaidaPedidoSet
                            where saidaPedidoE.codSaida == saidaPedido.CodSaida
                            select saidaPedidoE;

                foreach (SaidaPedidoE _saidaPedidoE in query)
                {
                    _saidaPedidoE.codPedidoGerado = saidaPedido.CodPedido;
                    _saidaPedidoE.totalAVista = saidaPedido.TotalAVista;
                }
                saceContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Saída", e.Message, e);
            }
            
        }

        /// <summary>
        /// Remove os todos associados ao pedido
        /// </summary>
        /// <param name="saida"></param>
        public void RemoverPorPedido(long codPedido)
        {
            try
            {
                var repSaidaPedido = new RepositorioGenerico<SaidaPedidoE>();
                var saceEntities = (SaceEntities)repSaidaPedido.ObterContexto();
                var query = from saidaPedidoSet in saceEntities.SaidaPedidoSet
                            where saidaPedidoSet.codPedidoGerado == codPedido
                            select saidaPedidoSet;
                //SaidaPedidoE saidaPedidoE = query.ToList().ElementAtOrDefault(0);
                foreach(SaidaPedidoE saidaPedidoE in query) 
                {
                    saceEntities.DeleteObject(saidaPedidoE);
                }
                saceEntities.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Saída", e.Message, e);
            }
        }

        /// <summary>
        /// Remove uma saída
        /// </summary>
        /// <param name="saida"></param>
        public void RemoverPorSaida(long codSaida, SaceEntities saceContext)
        {
            try
            {
                var query = from saidaPedidoSet in saceContext.SaidaPedidoSet
                            where saidaPedidoSet.codSaida == codSaida
                            select saidaPedidoSet;
                foreach (SaidaPedidoE saidaPedidoE in query)
                {
                    saceContext.DeleteObject(saidaPedidoE);
                }
                saceContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Saída", e.Message, e);
            }
        }
        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<SaidaPedido> GetQuery()
        {
            var repSaidaPedido = new RepositorioGenerico<SaidaPedidoE>();
            
            var saceEntities = (SaceEntities)repSaidaPedido.ObterContexto();
            var query = from saidaPedido in saceEntities.SaidaPedidoSet
                        select new SaidaPedido
                        {
                            CodPedido = saidaPedido.codPedidoGerado,
                            CodSaida = saidaPedido.codSaida,
                            TotalAVista = saidaPedido.totalAVista
                        };
            return query;
        }

        
        /// <summary>
        /// Obtém todos os pedidos associados a uma saída
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public List<SaidaPedido> ObterPorSaida(long codSaida)
        {
            return GetQuery().Where(sp => sp.CodSaida == codSaida).ToList();
        }

        /// <summary>
        /// Obtém todos os pedidos associados a uma saída
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public List<SaidaPedido> ObterPorSaida(List<SaidaPesquisa> saidas)
        {
            return GetQuery().Where(sp => saidas.Select(s=>s.CodSaida).Contains(sp.CodSaida)).ToList();
        }

        /// <summary>
        /// Trasnformar Pre-vendas em orçamento quando não há crediários
        /// </summary>
        /// <param name="_listaSaidaPedido"></param>
        public void TransformarOrcamentoPorRecusaDocumentoFiscal(IEnumerable<long> listaCodSaidas)
        {
            Saida saida = gerenciadorSaida.Obter(listaCodSaidas.ElementAt(0));
            if (Saida.LISTA_TIPOS_VENDA.Contains(saida.TipoSaida))
            {
                foreach (long codSaida in listaCodSaidas)
                {
                    bool temPagamentoCrediario = GerenciadorSaidaPagamento.GetInstance(null).ObterPorSaidaFormaPagamento(codSaida, FormaPagamento.CREDIARIO).ToList().Count > 0;
                    if (!temPagamentoCrediario)
                    {
                        saida = gerenciadorSaida.Obter(codSaida);
                        if ((saida != null) && (saida.TipoSaida != Saida.TIPO_VENDA))
                        {
                            saida.TipoSaida = Saida.TIPO_PRE_VENDA;
                            //gerenciadorSaida.PrepararEdicaoSaida(saida);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Obtém todos os pedidos associados a uma saída
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public List<SaidaPedido> ObterPorPedido(long codPedido)
        {
            return GetQuery().Where(sp => sp.CodPedido == codPedido).ToList();
        }
    }
}
