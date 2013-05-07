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
        private static SaceEntities saceContext;
        private static RepositorioGenerico<SaidaProdutoE> repSaidaProduto;
        
        public static GerenciadorSaidaProduto GetInstance(SaceEntities context)
        {
            if (gSaidaProduto == null)
            {
                gSaidaProduto = new GerenciadorSaidaProduto();
            }
            if (context == null)
            {
                repSaidaProduto = new RepositorioGenerico<SaidaProdutoE>();
            }
            else
            {
                repSaidaProduto = new RepositorioGenerico<SaidaProdutoE>(context);
            }
            saceContext = (SaceEntities)repSaidaProduto.ObterContexto();
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
            else if ((saida.TipoSaida == Saida.TIPO_DEVOLUCAO_FORNECEDOR) && (saida.Nfe != null) && (!saida.Nfe.Equals("")))
                throw new NegocioException("Não é possível inserir produtos numa devolução para fornecedor cuja nota fiscal já foi emitida.");

            DbTransaction transaction = null;
            try
            {
                if (saceContext.Connection.State == System.Data.ConnectionState.Closed)
                    saceContext.Connection.Open();
                transaction = saceContext.Connection.BeginTransaction();

                SaidaProdutoE _saidaProdutoE = new SaidaProdutoE();
                Atribuir(saidaProduto, _saidaProdutoE);

                repSaidaProduto.Inserir(_saidaProdutoE);
                repSaidaProduto.SaveChanges();


                AtualizarTotaisSaida(saida, saidaProduto, false);
                transaction.Commit();
                return _saidaProdutoE.codSaidaProduto;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new DadosException("Saída de Produtos", e.Message, e);
            }
            finally
            {
                saceContext.Connection.Close();
            }
        }

        /// <summary>
        /// Remover um produto de uma saída
        /// </summary>
        /// <param name="saidaProduto"></param>
        /// <param name="saida"></param>
        public void Remover(SaidaProduto saidaProduto, Saida saida)
        {
            if (saida.TipoSaida == Saida.TIPO_VENDA)
                    throw new NegocioException("Não é possível remover produtos de uma Venda cujo Comprovante Fiscal já foi emitido.");
                else if ((saida.TipoSaida == Saida.TIPO_SAIDA_DEPOSITO) && (saida.Nfe != null) && (!saida.Nfe.Equals("")))
                    throw new NegocioException("Não é possível remover produtos de uma Saída para Deposito com Nota Fiscal já emitida.");
                else if ((saida.TipoSaida == Saida.TIPO_DEVOLUCAO_FORNECEDOR) && (saida.Nfe != null) && (!saida.Nfe.Equals("")))
                    throw new NegocioException("Não é possível remover produtos de uma Devolução para Fornecedor com Nota Fiscal já emitida.");

            DbTransaction transaction = null;
            try
            {
                if (saceContext.Connection.State == System.Data.ConnectionState.Closed)
                    saceContext.Connection.Open();
                transaction = saceContext.Connection.BeginTransaction();

                var query = from _saidaProduto in saceContext.SaidaProdutoSet
                            where _saidaProduto.codSaidaProduto == saidaProduto.CodSaidaProduto
                            select _saidaProduto;
                foreach (SaidaProdutoE saidaProdutoE in query)
                {
                    repSaidaProduto.Remover(saidaProdutoE);
                }
                repSaidaProduto.SaveChanges();
                AtualizarTotaisSaida(saida, saidaProduto, true);

                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new DadosException("Saída de Produtos", e.Message, e);
            }
            finally
            {
                saceContext.Connection.Close();
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<SaidaProduto> GetQuery()
        {
            var query = from saidaProduto in saceContext.SaidaProdutoSet
                        join produto in saceContext.ProdutoSet on saidaProduto.codProduto equals produto.codProduto
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
                            Unidade = produto.unidade == null ? "UN": produto.unidade,
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
            var query = from saidaProduto in saceContext.SaidaProdutoSet
                        join produto in saceContext.ProdutoSet on saidaProduto.codProduto equals produto.codProduto
                        join saida in saceContext.SaidaSet on saidaProduto.codSaida equals saida.codSaida
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
            
            GerenciadorSaida.GetInstance(saceContext).Atualizar(saida);
        }
    }
}