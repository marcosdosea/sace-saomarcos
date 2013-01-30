using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio;
using Dados.saceDataSetTableAdapters;
using Dados.saceDataSetConsultasTableAdapters;
using Dados;
using Util;
using System.Data.Common;
using System.Data.Objects;


namespace Negocio
{
    public class GerenciadorSaidaProduto {
        private static GerenciadorSaidaProduto gSaidaProduto;
        
        public static GerenciadorSaidaProduto GetInstance()
        {
            if (gSaidaProduto == null)
            {
                gSaidaProduto = new GerenciadorSaidaProduto();
            }
            return gSaidaProduto;
        }

        /// <summary>
        /// Insere um novo produto na saída
        /// </summary>
        /// <param name="saidaProduto"></param>
        /// <param name="saida"></param>
        /// <returns></returns>
        public Int64 Inserir(SaidaProduto saidaProduto, Saida saida)
        {
            if (saidaProduto.Quantidade == 0)
                throw new NegocioException("A quantidade do produto não pode ser igual a zero.");
            else if (saidaProduto.ValorVendaAVista <= 0)
                throw new NegocioException("O preço de venda do produto deve ser maior que zero.");
            else if (saida.TipoSaida == Saida.TIPO_VENDA)
                throw new NegocioException("Não é possível inserir produtos de uma Venda cujo Comprovante Fiscal já foi emitido.");
            else if ((saida.TipoSaida == Saida.TIPO_SAIDA_DEPOSITO) && (saida.Nfe != null) && (!saida.Nfe.Equals("")))
                throw new NegocioException("Não é possível inserir produtos numa transferência para depósito cuja nota fiscal já foi emitida.");
            else if ((saida.TipoSaida == Saida.TIPO_DEVOLUCAO_FRONECEDOR) && (saida.Nfe != null) && (!saida.Nfe.Equals("")))
                throw new NegocioException("Não é possível inserir produtos numa devolução para fornecedor cuja nota fiscal já foi emitida.");
            
            try
            {
                var repSaidaProduto = new RepositorioGenerico<SaidaProdutoE>();
                //repSaidaProduto.ObterContexto().Exe
                
                SaidaProdutoE _saidaProdutoE = new SaidaProdutoE();
                Atribuir(saidaProduto, _saidaProdutoE);

                repSaidaProduto.Inserir(_saidaProdutoE);
                repSaidaProduto.SaveChanges();


                AtualizarTotaisSaida(saida, saidaProduto, false);
                return _saidaProdutoE.codSaidaProduto;
                
            }
            catch (Exception e)
            {
                throw new DadosException("Saída de Produtos", e.Message, e);
            }
        }

        /// <summary>
        /// Remover um produto de uma saída
        /// </summary>
        /// <param name="saidaProduto"></param>
        /// <param name="saida"></param>
        public void Remover(SaidaProduto saidaProduto, Saida saida)
        {
            try
            {
                if (saida.TipoSaida == Saida.TIPO_VENDA)
                    throw new NegocioException("Não é possível remover produtos de uma Venda cujo Comprovante Fiscal já foi emitido.");
                else if ((saida.TipoSaida == Saida.TIPO_SAIDA_DEPOSITO) && (saida.Nfe != null) && (!saida.Nfe.Equals("")))
                    throw new NegocioException("Não é possível remover produtos de uma Saída para Deposito com Nota Fiscal já emitida.");
                else if ((saida.TipoSaida == Saida.TIPO_DEVOLUCAO_FRONECEDOR) && (saida.Nfe != null) && (!saida.Nfe.Equals("")))
                    throw new NegocioException("Não é possível remover produtos de uma Devolução para Fornecedor com Nota Fiscal já emitida.");

               
                var repSaidaProduto = new RepositorioGenerico<SaidaProdutoE>();
            
                var saceEntities = (SaceEntities)repSaidaProduto.ObterContexto();
                var query = from _saidaProduto in saceEntities.SaidaProdutoSet
                            where _saidaProduto.codSaidaProduto == saidaProduto.CodSaidaProduto
                            select _saidaProduto;
                foreach (SaidaProdutoE saidaProdutoE in query)
                {
                    repSaidaProduto.Remover(saidaProdutoE);
                }
                repSaidaProduto.SaveChanges();
                AtualizarTotaisSaida(saida, saidaProduto, true);
            }
            catch (Exception e)
            {
                throw new DadosException("Saída de Produtos", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<SaidaProduto> GetQuery()
        {
            var repSaidaProduto = new RepositorioGenerico<SaidaProdutoE>();
            
            var saceEntities = (SaceEntities)repSaidaProduto.ObterContexto();
            var query = from saidaProduto in saceEntities.SaidaProdutoSet
                        join produto in saceEntities.ProdutoSet on saidaProduto.codProduto equals produto.codProduto
                        select new SaidaProduto
                        {
                            BaseCalculoICMS = (decimal) saidaProduto.baseCalculoICMS,
                            BaseCalculoICMSSubst = (decimal) saidaProduto.baseCalculoICMSSubst,
                            CodProduto = saidaProduto.codProduto,
                            CodSaida = saidaProduto.codSaida,
                            CodSaidaProduto = saidaProduto.codSaidaProduto,
                            CodCST = produto.codCST,
                            DataValidade = (DateTime) saidaProduto.data_validade,
                            Desconto = (decimal) saidaProduto.desconto,
                            Quantidade = (decimal) saidaProduto.quantidade,
                            Nome = produto.nome,
                            Subtotal = (decimal) saidaProduto.subtotal,
                            SubtotalAVista = (decimal) saidaProduto.subtotalAVista,
                            Unidade = produto.unidade,
                            ValorICMS = (decimal) saidaProduto.valorICMS,
                            ValorICMSSubst = (decimal) saidaProduto.valorICMSSubst,
                            ValorIPI = (decimal) saidaProduto.valorIPI,
                            ValorVenda = (decimal) saidaProduto.valorVenda,
                        };
            return query;
        }

        /// <summary>
        /// Obtém as saídas de produto sem um determinado CST
        /// </summary>
        /// <param name="codSaida"></param>
        /// <param name="codCST"></param>
        /// <returns></returns>
        public List<SaidaProduto> ObterPorSaidaSemCST(Int64 codSaida, String codCST)
        {
            return GetQuery().Where(sp => sp.CodSaida == codSaida && sp.CodCST.EndsWith(codCST) == false).ToList();
        }


        /// <summary>
        /// Obtém os produtos de uma determinada saída
        /// </summary>
        /// <param name="codSaida"></param>
        /// <param name="codCST"></param>
        /// <returns></returns>
        public List<SaidaProduto> ObterPorSaida(Int64 codSaida)
        {
            return GetQuery().Where(sp => sp.CodSaida == codSaida).ToList();
        }

        /// <summary>
        /// Obtém os produtos de um determinado pedido (cupom fiscal)
        /// </summary>
        /// <param name="codPedido"></param>
        /// <returns></returns>
        public List<SaidaProduto> ObterPorPedido(string codPedido)
        {
            var repSaidaProduto = new RepositorioGenerico<SaidaProdutoE>();
            
            var saceEntities = (SaceEntities)repSaidaProduto.ObterContexto();
            var query = from saidaProduto in saceEntities.SaidaProdutoSet
                        join produto in saceEntities.ProdutoSet on saidaProduto.codProduto equals produto.codProduto
                        join saida in saceEntities.SaidaSet on saidaProduto.codSaida equals saida.codSaida
                        where saida.pedidoGerado == codPedido
                        select new SaidaProduto
                        {
                            BaseCalculoICMS = (decimal)saidaProduto.baseCalculoICMS,
                            BaseCalculoICMSSubst = (decimal)saidaProduto.baseCalculoICMSSubst,
                            CodProduto = saidaProduto.codProduto,
                            CodSaida = saidaProduto.codSaida,
                            CodCST = produto.codCST,
                            DataValidade = (DateTime)saidaProduto.data_validade,
                            Desconto = (decimal)saidaProduto.desconto,
                            Quantidade = (decimal)saidaProduto.quantidade,
                            Nome = produto.nome,
                            Subtotal = (decimal)saidaProduto.subtotal,
                            SubtotalAVista = (decimal)saidaProduto.subtotalAVista,
                            Unidade = produto.unidade,
                            ValorICMS = (decimal)saidaProduto.valorICMS,
                            ValorICMSSubst = (decimal)saidaProduto.valorICMSSubst,
                            ValorIPI = (decimal)saidaProduto.valorIPI,
                            ValorVenda = (decimal)saidaProduto.valorVenda,
                        };
            return query.ToList();
        }
        /// <summary>
        /// Atribui entidade para entidade persistente
        /// </summary>
        /// <param name="saidaProduto"></param>
        /// <param name="_saidaProdutoE"></param>
        private static void Atribuir(SaidaProduto saidaProduto, SaidaProdutoE _saidaProdutoE)
        {
            _saidaProdutoE.baseCalculoICMS = saidaProduto.BaseCalculoICMS;
            _saidaProdutoE.baseCalculoICMSSubst = saidaProduto.BaseCalculoICMSSubst;
            _saidaProdutoE.codProduto = saidaProduto.CodProduto;
            _saidaProdutoE.codSaida = saidaProduto.CodSaida;
            _saidaProdutoE.data_validade = saidaProduto.DataValidade;
            _saidaProdutoE.desconto = saidaProduto.Desconto;
            _saidaProdutoE.quantidade = saidaProduto.Quantidade;
            _saidaProdutoE.subtotal = saidaProduto.Subtotal;
            _saidaProdutoE.subtotalAVista = saidaProduto.SubtotalAVista;
            _saidaProdutoE.valorICMS = saidaProduto.ValorICMS;
            _saidaProdutoE.valorICMSSubst = saidaProduto.ValorICMSSubst;
            _saidaProdutoE.valorIPI = saidaProduto.ValorIPI;
            _saidaProdutoE.valorVenda = saidaProduto.ValorVenda;
        }

        /// <summary>
        /// Atualiza os totais de uma saída quando um produto é inserido ou excluído de uma saída
        /// </summary>
        /// <param name="saida"></param>
        /// <param name="saidaProduto"></param>
        /// <param name="ehRemocao"></param>
        
        private void AtualizarTotaisSaida(Saida saida, SaidaProduto saidaProduto, bool ehRemocao)
        {
            if (ehRemocao)
            {
                saida.Total -= saidaProduto.Subtotal;
                saida.TotalAVista -= saidaProduto.SubtotalAVista;
                saida.BaseCalculoICMS -= saidaProduto.BaseCalculoICMS;
                saida.ValorICMS -= saidaProduto.ValorICMS;
                saida.BaseCalculoICMSSubst -= saidaProduto.BaseCalculoICMSSubst;
                saida.ValorICMSSubst -= saidaProduto.ValorICMSSubst;
                saida.ValorIPI -= saidaProduto.ValorIPI;
            }
            else
            {
                saida.Total += saidaProduto.Subtotal;
                saida.TotalAVista += saidaProduto.SubtotalAVista;
                saida.BaseCalculoICMS += saidaProduto.BaseCalculoICMS;
                saida.ValorICMS += saidaProduto.ValorICMS;
                saida.BaseCalculoICMSSubst += saidaProduto.BaseCalculoICMSSubst;
                saida.ValorICMSSubst += saidaProduto.ValorICMSSubst;
                saida.ValorIPI += saidaProduto.ValorIPI;
            }
            
            GerenciadorSaida.GetInstance().Atualizar(saida);
        }
    }
}