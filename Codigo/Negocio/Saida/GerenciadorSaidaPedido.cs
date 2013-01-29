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
        private static GerenciadorSaidaPedido gSaidaPedido;
        
        public static GerenciadorSaidaPedido GetInstance()
        {
            if (gSaidaPedido == null)
            {
                gSaidaPedido = new GerenciadorSaidaPedido();
            }
            return gSaidaPedido;
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
        /// Remove os todos associados ao pedido
        /// </summary>
        /// <param name="saida"></param>
        public void RemoverPorPedido(long codPedido)
        {
            try
            {
                var repSaidaPedido = new RepositorioGenerico<SaidaPedidoE>();
                repSaidaPedido.Remover(sp => sp.codPedidoGerado == codPedido);
                repSaidaPedido.SaveChanges();
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
                            CodSaida = saidaPedido.codSaida
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
        public List<SaidaPedido> ObterPorPedido(long codPedido)
        {
            return GetQuery().Where(sp => sp.CodPedido == codPedido).ToList();
        }
    }
}
