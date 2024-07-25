using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public static class GerenciadorSaidaPedido
    {

        /// <summary>
        /// Insere dados de saídas associadas a um pedido
        /// </summary>
        /// <param name="saida"></param>
        /// <returns></returns>
        public static long Inserir(SaidaPedido saidaPedido)
        {
            try
            {
                using (var context = new SaceContext())
                {
                    TbSaidaPedido _saidaPedido = new TbSaidaPedido();
                    _saidaPedido.CodSaida = saidaPedido.CodSaida;
                    _saidaPedido.CodPedidoGerado = saidaPedido.CodPedido;
                    _saidaPedido.TotalAvista = saidaPedido.TotalAVista;

                    context.Add(_saidaPedido);
                    context.SaveChanges();

                    return _saidaPedido.CodSaida;
                }
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
        public static void Atualizar(SaidaPedido saidaPedido)
        {
            try
            {
                using (var context = new SaceContext())
                {
                    var query = from saidaPedidoE in context.TbSaidaPedidos
                                where saidaPedidoE.CodSaida == saidaPedido.CodSaida
                                select saidaPedidoE;

                    foreach (TbSaidaPedido _saidaPedido in query)
                    {
                        _saidaPedido.CodPedidoGerado = saidaPedido.CodPedido;
                        _saidaPedido.TotalAvista = saidaPedido.TotalAVista;
                    }
                    context.SaveChanges();
                }
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
        public static void RemoverPorPedido(long codPedido)
        {
            try
            {
                using (var context = new SaceContext())
                {
                    var query = from saidaPedido in context.TbSaidaPedidos
                                where saidaPedido.CodPedidoGerado == codPedido
                                select saidaPedido;
                    foreach (TbSaidaPedido saidaPedido in query)
                    {
                        context.Remove(saidaPedido);
                    }
                    context.SaveChanges();
                }
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
        public static void RemoverPorSaida(long codSaida)
        {
            try
            {
                using (var context = new SaceContext())
                {
                    var query = from saidaPedido in context.TbSaidaPedidos
                                where saidaPedido.CodSaida == codSaida
                                select saidaPedido;
                    foreach (TbSaidaPedido saidaPedido in query)
                    {
                        context.Remove(saidaPedido);
                    }
                    context.SaveChanges();
                }
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
        private static IQueryable<SaidaPedido> GetQuery(SaceContext context)
        {
            var query = from saidaPedido in context.TbSaidaPedidos
                        select new SaidaPedido
                        {
                            CodPedido = saidaPedido.CodPedidoGerado,
                            CodSaida = saidaPedido.CodSaida,
                            TotalAVista = saidaPedido.TotalAvista
                        };
            return query.AsNoTracking();
        }


        /// <summary>
        /// Obtém todos os pedidos associados a uma saída
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public static List<SaidaPedido> ObterPorSaida(long codSaida)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(sp => sp.CodSaida == codSaida).ToList();
            }
        }

        /// <summary>
        /// Obtém todos os pedidos associados a uma saída
        /// </summary>
        /// <param name="codBanco"></param>
        /// <returns></returns>
        public static List<SaidaPedido> ObterPorSaida(List<SaidaPesquisa> saidas)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(sp => saidas.Select(s => s.CodSaida).Contains(sp.CodSaida)).ToList();
            }
        }

        /// <summary>
        /// Trasnformar Pre-vendas em orçamento quando não há crediários
        /// </summary>
        /// <param name="_listaSaidaPedido"></param>
        public static void TransformarOrcamentoPorRecusaDocumentoFiscal(IEnumerable<long> listaCodSaidas)
        {
            Saida saida = GerenciadorSaida.Obter(listaCodSaidas.ElementAt(0));
            if (Saida.LISTA_TIPOS_VENDA.Contains(saida.TipoSaida))
            {
                foreach (long codSaida in listaCodSaidas)
                {
                    bool temPagamentoCrediario = GerenciadorSaidaPagamento.ObterPorSaidaFormaPagamento(codSaida, FormaPagamento.CREDIARIO).ToList().Count > 0;
                    if (!temPagamentoCrediario)
                    {
                        saida = GerenciadorSaida.Obter(codSaida);
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
        public static List<SaidaPedido> ObterPorPedido(long codPedido)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(sp => sp.CodPedido == codPedido).ToList();
            }
        }
    }
}
