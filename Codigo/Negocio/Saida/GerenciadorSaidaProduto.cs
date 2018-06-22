using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Dados;
using Dominio;
using Dominio.Consultas;


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
            else if (saida.TipoSaida.Equals(Saida.TIPO_VENDA))
                throw new NegocioException("Não é possível inserir produtos de uma Venda cujo Comprovante Fiscal já foi emitido.");
            else if (saida.TipoSaida.Equals(Saida.TIPO_REMESSA_DEPOSITO) && string.IsNullOrEmpty(saida.Nfe))
                throw new NegocioException("Não é possível inserir produtos em uma transferência para depósito cuja nota fiscal já foi emitida.");
            else if (saida.TipoSaida.Equals(Saida.TIPO_RETORNO_DEPOSITO) && string.IsNullOrEmpty(saida.Nfe))
                throw new NegocioException("Não é possível inserir produtos em um retorno de depósito cuja nota fiscal já foi emitida.");
            else if (saida.TipoSaida.Equals(Saida.TIPO_DEVOLUCAO_FORNECEDOR) &&  string.IsNullOrEmpty(saida.Nfe))
                throw new NegocioException("Não é possível inserir produtos em uma devolução para fornecedor cuja nota fiscal já foi emitida.");

            SaidaProdutoE _saidaProdutoE = new SaidaProdutoE();
            Atribuir(saidaProduto, _saidaProdutoE);

            repSaidaProduto.Inserir(_saidaProdutoE);
            repSaidaProduto.SaveChanges();
            return _saidaProdutoE.codSaidaProduto;
        }

        /// <summary>
        /// Atualiza os dados de um produto da saída
        /// </summary>
        /// <param name="saidaProduto"></param>
        /// <param name="saida"></param>
        public void Atualizar(SaidaProduto saidaProduto, Saida saida)
        {
            if (saidaProduto.Quantidade == 0)
                throw new NegocioException("A quantidade do produto não pode ser igual a zero.");
            else if (saidaProduto.ValorVendaAVista <= 0)
                throw new NegocioException("O preço de venda do produto deve ser maior que zero.");
            else if (saida.TipoSaida == Saida.TIPO_VENDA)
                throw new NegocioException("Não é possível alterar produtos de uma Venda cujo Comprovante Fiscal já foi emitido.");
            else if ((saida.TipoSaida == Saida.TIPO_REMESSA_DEPOSITO) && (saida.Nfe != null) && (!saida.Nfe.Equals("")))
                throw new NegocioException("Não é possível alterar produtos numa transferência para depósito cuja nota fiscal já foi emitida.");
            else if ((saida.TipoSaida == Saida.TIPO_DEVOLUCAO_FORNECEDOR) && (saida.Nfe != null) && (!saida.Nfe.Equals("")))
                throw new NegocioException("Não é possível alterar produtos numa devolução para fornecedor cuja nota fiscal já foi emitida.");

            
            var query = from saidaProdutoE in saceContext.SaidaProdutoSet
                        where saidaProdutoE.codSaidaProduto == saidaProduto.CodSaidaProduto
                        select saidaProdutoE;

            foreach (SaidaProdutoE _saidaProdutoE in query)
            {
                Atribuir(saidaProduto, _saidaProdutoE);
            }
            saceContext.SaveChanges();
        }

        /// <summary>
        /// Atualiza cfop dos produtos
        /// </summary>
        /// <param name="saidaProduto"></param>
        /// <param name="saida"></param>
        public void AtualizarCFOP(long codSaidaProduto, int codCFOP)
        {
            
            var query = from saidaProdutoE in saceContext.SaidaProdutoSet
                        where saidaProdutoE.codSaidaProduto == codSaidaProduto
                        select saidaProdutoE;

            foreach (SaidaProdutoE _saidaProdutoE in query)
            {
                _saidaProdutoE.cfop = codCFOP;
            }
            saceContext.SaveChanges();
        }

        /// <summary>
        /// Atualiza os preços dos produtos utilizandos os valores do dia.
        /// </summary>
        /// <param name="p"></param>
        public void AtualizarPrecosComValoresDia(Saida saida, bool podeBaixarPreco)
        {
            if (!saida.TipoSaida.Equals(Saida.TIPO_ORCAMENTO))
            {
                throw new NegocioException("A atualização de preços com os preços do dia só pode ser realizada em ORÇAMENTOS.");
            }
            List<SaidaProduto> listaSaidaProdutos = ObterPorSaida(saida.CodSaida);
            GerenciadorProduto gProduto = GerenciadorProduto.GetInstance();
            
            foreach (SaidaProduto _saidaProduto in listaSaidaProdutos)
            {
                ProdutoPesquisa produto = gProduto.Obter(_saidaProduto.CodProduto).ElementAtOrDefault(0);
                if ((_saidaProduto.ValorVendaAVista < produto.PrecoVendaVarejo) || 
                    ((_saidaProduto.ValorVendaAVista > produto.PrecoVendaVarejo) && podeBaixarPreco))
                {
                    _saidaProduto.ValorVendaAVista = produto.PrecoVendaVarejo;
                    //_saidaProduto.ValorVenda = produto.PrecoVendaVarejoSemDesconto;

                    Atualizar(_saidaProduto, saida);
                } 
            }
            RecalcularTotais(saida);
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
                else if ((saida.TipoSaida == Saida.TIPO_REMESSA_DEPOSITO) && (saida.Nfe != null) && (!saida.Nfe.Equals("")))
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
                        select new SaidaProduto
                        {
                            BaseCalculoICMS = (decimal) saidaProduto.baseCalculoICMS,
                            BaseCalculoICMSSubst = (decimal) saidaProduto.baseCalculoICMSSubst,
                            CodProduto = saidaProduto.codProduto,
                            CodSaida = saidaProduto.codSaida,
                            CodSaidaProduto = saidaProduto.codSaidaProduto,
                            CodCST = saidaProduto.codCST,
                            CodCfop = saidaProduto.cfop,
                            DataValidade = (DateTime) saidaProduto.data_validade,
                            Desconto = (decimal) saidaProduto.desconto,
                            Quantidade = (decimal) saidaProduto.quantidade,
                            Nome = saidaProduto.tb_produto.nome,
                            SubtotalAVista = (decimal) saidaProduto.subtotalAVista,
                            Unidade = saidaProduto.tb_produto.unidade,
                            ValorICMS = (decimal) saidaProduto.valorICMS,
                            ValorICMSSubst = (decimal) saidaProduto.valorICMSSubst,
                            ValorIPI = (decimal) saidaProduto.valorIPI,
                            TemVencimento = (bool) saidaProduto.tb_produto.temVencimento,
                            PrecoVendaVarejo = (decimal)saidaProduto.tb_produto.precoVendaVarejo,
                            Ncmsh = saidaProduto.tb_produto.ncmsh
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
        /// Obtém os produtos por uma determinada NFC-e
        /// </summary>
        /// <param name="codPedido"></param>
        /// <returns></returns>
        public List<SaidaProduto> ObterPorNfeControle(int codNfeControle)
        {
            var query1 = from saida in saceContext.tb_saida
                         where saida.tb_nfe.Select(nfe=> nfe.codNFe).Contains(codNfeControle)
                         select saida.codSaida; 

            List<long> listaCodSaida = query1.ToList();
            var query = from saidaProduto in saceContext.SaidaProdutoSet
                        where listaCodSaida.Contains(saidaProduto.codSaida)
                        select new SaidaProduto
                        {
                            BaseCalculoICMS = (decimal)saidaProduto.baseCalculoICMS,
                            BaseCalculoICMSSubst = (decimal)saidaProduto.baseCalculoICMSSubst,
                            CodProduto = saidaProduto.codProduto,
                            CodSaida = saidaProduto.codSaida,
                            CodSaidaProduto = saidaProduto.codSaidaProduto,
                            CodCST = saidaProduto.tb_produto.codCST,
                            CodCfop = saidaProduto.cfop,
                            DataValidade = (DateTime)saidaProduto.data_validade,
                            Desconto = (decimal)saidaProduto.desconto,
                            Quantidade = (decimal)saidaProduto.quantidade,
                            Nome = saidaProduto.tb_produto.nome,
                            SubtotalAVista = (decimal)saidaProduto.subtotalAVista,
                            Unidade = saidaProduto.tb_produto.unidade,
                            ValorICMS = (decimal)saidaProduto.valorICMS,
                            ValorICMSSubst = (decimal)saidaProduto.valorICMSSubst,
                            ValorIPI = (decimal)saidaProduto.valorIPI,
                            TemVencimento = (bool)saidaProduto.tb_produto.temVencimento,
                            PrecoVendaVarejo = (decimal)saidaProduto.tb_produto.precoVendaVarejo,
                            Ncmsh = saidaProduto.tb_produto.ncmsh
                        };
            return query.ToList();
        }

        /// <summary>
        /// Obtém os produtos de um determinado pedido (cupom fiscal)
        /// sem um determinado CST
        /// </summary>
        /// <param name="codPedido"></param>
        /// <returns></returns>
        public List<SaidaProduto> ObterPorNfeControleSemCST(int codNfeControle, string codCST)
        {
            var query1 = from saida in saceContext.tb_saida
                         where saida.tb_nfe.Select(nfe => nfe.codNFe).Contains(codNfeControle)
                         select saida.codSaida;

            List<long> listaCodSaida = query1.ToList();
            
            
            var query = from saidaProduto in saceContext.SaidaProdutoSet
                        where listaCodSaida.Contains(saidaProduto.codSaida)  && !saidaProduto.codCST.EndsWith(codCST)
                        select new SaidaProduto
                        {
                            BaseCalculoICMS = (decimal)saidaProduto.baseCalculoICMS,
                            BaseCalculoICMSSubst = (decimal)saidaProduto.baseCalculoICMSSubst,
                            CodProduto = saidaProduto.codProduto,
                            CodSaida = saidaProduto.codSaida,
                            CodSaidaProduto = saidaProduto.codSaidaProduto,
                            CodCST = saidaProduto.tb_produto.codCST,
                            CodCfop = saidaProduto.cfop,
                            DataValidade = (DateTime)saidaProduto.data_validade,
                            Desconto = (decimal)saidaProduto.desconto,
                            Quantidade = (decimal)saidaProduto.quantidade,
                            Nome = saidaProduto.tb_produto.nome,
                            SubtotalAVista = (decimal)saidaProduto.subtotalAVista,
                            Unidade = saidaProduto.tb_produto.unidade,
                            ValorICMS = (decimal)saidaProduto.valorICMS,
                            ValorICMSSubst = (decimal)saidaProduto.valorICMSSubst,
                            ValorIPI = (decimal)saidaProduto.valorIPI,
                            TemVencimento = (bool)saidaProduto.tb_produto.temVencimento,
                            PrecoVendaVarejo = (decimal)saidaProduto.tb_produto.precoVendaVarejo,
                            Ncmsh = saidaProduto.tb_produto.ncmsh
                        };
            return query.ToList();
        }
        
        /// <summary>
        /// Obtém os produtos de um determinado pedido (cupom fiscal)
        /// </summary>
        /// <param name="codPedido"></param>
        /// <returns></returns>
        public List<SaidaProduto> ObterPorPedido(string codPedido)
        {
            var query = from saidaProduto in saceContext.SaidaProdutoSet
                        where saidaProduto.tb_saida.pedidoGerado.Equals(codPedido)
                        select new SaidaProduto
                        {
                            BaseCalculoICMS = (decimal)saidaProduto.baseCalculoICMS,
                            BaseCalculoICMSSubst = (decimal)saidaProduto.baseCalculoICMSSubst,
                            CodProduto = saidaProduto.codProduto,
                            CodSaida = saidaProduto.codSaida,
                            CodSaidaProduto = saidaProduto.codSaidaProduto,
                            CodCST = saidaProduto.tb_produto.codCST,
                            CodCfop = saidaProduto.cfop,
                            DataValidade = (DateTime)saidaProduto.data_validade,
                            Desconto = (decimal)saidaProduto.desconto,
                            Quantidade = (decimal)saidaProduto.quantidade,
                            Nome = saidaProduto.tb_produto.nome,
                            SubtotalAVista = (decimal)saidaProduto.subtotalAVista,
                            Unidade = saidaProduto.tb_produto.unidade,
                            ValorICMS = (decimal)saidaProduto.valorICMS,
                            ValorICMSSubst = (decimal)saidaProduto.valorICMSSubst,
                            ValorIPI = (decimal)saidaProduto.valorIPI,
                            TemVencimento = (bool)saidaProduto.tb_produto.temVencimento,
                            PrecoVendaVarejo = (decimal) saidaProduto.tb_produto.precoVendaVarejo,
                            Ncmsh = saidaProduto.tb_produto.ncmsh
                        };
            return query.ToList();
        }

        /// <summary>
        /// Obtém os produtos de um determinado pedido (cupom fiscal)
        /// sem um determinado CST
        /// </summary>
        /// <param name="codPedido"></param>
        /// <returns></returns>
        public List<SaidaProduto> ObterPorPedidoSemCST(string codPedido, string codCST)
        {
            var query = from saidaProduto in saceContext.SaidaProdutoSet
                        where saidaProduto.tb_saida.pedidoGerado.Equals(codPedido) && !saidaProduto.codCST.EndsWith(codCST)
                        select new SaidaProduto
                        {
                            BaseCalculoICMS = (decimal)saidaProduto.baseCalculoICMS,
                            BaseCalculoICMSSubst = (decimal)saidaProduto.baseCalculoICMSSubst,
                            CodProduto = saidaProduto.codProduto,
                            CodSaida = saidaProduto.codSaida,
                            CodSaidaProduto = saidaProduto.codSaidaProduto,
                            CodCST = saidaProduto.tb_produto.codCST,
                            CodCfop = saidaProduto.cfop,
                            DataValidade = (DateTime)saidaProduto.data_validade,
                            Desconto = (decimal)saidaProduto.desconto,
                            Quantidade = (decimal)saidaProduto.quantidade,
                            Nome = saidaProduto.tb_produto.nome,
                            SubtotalAVista = (decimal)saidaProduto.subtotalAVista,
                            Unidade = saidaProduto.tb_produto.unidade,
                            ValorICMS = (decimal)saidaProduto.valorICMS,
                            ValorICMSSubst = (decimal)saidaProduto.valorICMSSubst,
                            ValorIPI = (decimal)saidaProduto.valorIPI,
                            TemVencimento = (bool)saidaProduto.tb_produto.temVencimento,
                            PrecoVendaVarejo = (decimal)saidaProduto.tb_produto.precoVendaVarejo,
                            Ncmsh = saidaProduto.tb_produto.ncmsh
                        };
            return query.ToList();
        }

        /// <summary>
        /// Obtém os produtos de uma lista de saidas
        /// </summary>
        /// <param name="codPedido"></param>
        /// <returns></returns>
        public List<SaidaProduto> ObterPorSolicitacaoSaidas(List<tb_solicitacao_saida> listaSolicitacaoSaidas)
        {
            List<long> listaCodSaidas = listaSolicitacaoSaidas.Select(s => s.codSaida).ToList();
            var query = from saidaProduto in saceContext.SaidaProdutoSet
                        where listaCodSaidas.Contains(saidaProduto.codSaida)
                        select new SaidaProduto
                        {
                            BaseCalculoICMS = (decimal)saidaProduto.baseCalculoICMS,
                            BaseCalculoICMSSubst = (decimal)saidaProduto.baseCalculoICMSSubst,
                            CodProduto = saidaProduto.codProduto,
                            CodSaida = saidaProduto.codSaida,
                            CodSaidaProduto = saidaProduto.codSaidaProduto,
                            CodCST = saidaProduto.tb_produto.codCST,
                            CodCfop = saidaProduto.cfop,
                            DataValidade = (DateTime)saidaProduto.data_validade,
                            Desconto = (decimal)saidaProduto.desconto,
                            Quantidade = (decimal)saidaProduto.quantidade,
                            Nome = saidaProduto.tb_produto.nome,
                            SubtotalAVista = (decimal)saidaProduto.subtotalAVista,
                            Unidade = saidaProduto.tb_produto.unidade,
                            ValorICMS = (decimal)saidaProduto.valorICMS,
                            ValorICMSSubst = (decimal)saidaProduto.valorICMSSubst,
                            ValorIPI = (decimal)saidaProduto.valorIPI,
                            TemVencimento = (bool)saidaProduto.tb_produto.temVencimento,
                            PrecoVendaVarejo = (decimal)saidaProduto.tb_produto.precoVendaVarejo,
                            Ncmsh = saidaProduto.tb_produto.ncmsh
                        };
            return query.ToList();
        }

        /// <summary>
        /// Obtém os produtos de uma lista de saidas
        /// </summary>
        /// <param name="codPedido"></param>
        /// <returns></returns>
        public List<SaidaProduto> ObterPorSolicitacaoSaidasSemCST(List<tb_solicitacao_saida> listaSolicitacaoSaidas, string codCST)
        {
            List<long> listaCodSaidas = listaSolicitacaoSaidas.Select(s => s.codSaida).ToList();
            var query = from saidaProduto in saceContext.SaidaProdutoSet
                        where listaCodSaidas.Contains(saidaProduto.codSaida) && !saidaProduto.codCST.EndsWith(codCST)
                        select new SaidaProduto
                        {
                            BaseCalculoICMS = (decimal)saidaProduto.baseCalculoICMS,
                            BaseCalculoICMSSubst = (decimal)saidaProduto.baseCalculoICMSSubst,
                            CodProduto = saidaProduto.codProduto,
                            CodSaida = saidaProduto.codSaida,
                            CodSaidaProduto = saidaProduto.codSaidaProduto,
                            CodCST = saidaProduto.tb_produto.codCST,
                            CodCfop = saidaProduto.cfop,
                            DataValidade = (DateTime)saidaProduto.data_validade,
                            Desconto = (decimal)saidaProduto.desconto,
                            Quantidade = (decimal)saidaProduto.quantidade,
                            Nome = saidaProduto.tb_produto.nome,
                            SubtotalAVista = (decimal)saidaProduto.subtotalAVista,
                            Unidade = saidaProduto.tb_produto.unidade,
                            ValorICMS = (decimal)saidaProduto.valorICMS,
                            ValorICMSSubst = (decimal)saidaProduto.valorICMSSubst,
                            ValorIPI = (decimal)saidaProduto.valorIPI,
                            TemVencimento = (bool)saidaProduto.tb_produto.temVencimento,
                            PrecoVendaVarejo = (decimal)saidaProduto.tb_produto.precoVendaVarejo,
                            Ncmsh = saidaProduto.tb_produto.ncmsh
                        };
            return query.ToList();
        }

        /// <summary>
        /// Consulta para retornar dados dos produtos para relatório
        /// </summary>
        /// <returns></returns>
        private IQueryable<SaidaProdutoRelatorio> GetQueryRelatorio()
        {
            var query = from saidaProduto in saceContext.SaidaProdutoSet
                        join produto in saceContext.ProdutoSet on saidaProduto.codProduto equals produto.codProduto
                        join saida in saceContext.tb_saida on saidaProduto.codSaida equals saida.codSaida
                        select new SaidaProdutoRelatorio
                        {
                            CodProduto = saidaProduto.codProduto,
                            CodSaida = saidaProduto.codSaida,
                            CodSaidaProduto = saidaProduto.codSaidaProduto,
                            Desconto = (decimal)saidaProduto.desconto,
                            Quantidade = (decimal)saidaProduto.quantidade,
                            Nome = produto.nome,
                            Subtotal = (decimal)saidaProduto.subtotal,
                            SubtotalAVista = (decimal)saidaProduto.subtotalAVista,
                            Unidade = produto.unidade == null ? "UN" : produto.unidade,
                            ValorVenda = (decimal)saidaProduto.valorVenda,
                            ValorVendaAVista = (decimal) (saidaProduto.subtotalAVista / saidaProduto.quantidade),
                            TotalSaida = (decimal)saida.total,
                            TotalSaidaAVista = (decimal) saida.totalAVista,
                            Pedido = saida.pedidoGerado,
                            DataSaida = saida.dataSaida,
                            CodCliente = saida.codCliente
                        };
            return query;
        }

        /// <summary>
        /// Obtém as saídas de produto para emissão de DAV
        /// </summary>
        /// <param name="codSaida"></param>
        /// <param name="codCST"></param>
        /// <returns></returns>
        public List<SaidaProdutoRelatorio> ObterPorSaidasRelatorio(List<long> listaCodSaida)
        {
            return GetQueryRelatorio().Where(sp => listaCodSaida.Contains(sp.CodSaida)).ToList();
        }

        /// <summary>
        /// Obter Produtos Vendidos nos últimos seis meses
        /// </summary>
        /// <returns></returns>
        public List<ProdutoVendido> ObterProdutosVendidosUltimosMeses(int numerosMeses)
        {
            DateTime dataMesesAntes = DateTime.Now.AddDays(-30 * numerosMeses);

            var query = from saidaProduto in saceContext.SaidaProdutoSet
                        where (saidaProduto.tb_saida.dataSaida > dataMesesAntes) && 
                              (saidaProduto.tb_saida.codTipoSaida.Equals(Saida.TIPO_PRE_VENDA) || saidaProduto.tb_saida.codTipoSaida.Equals(Saida.TIPO_VENDA))
                        group saidaProduto by saidaProduto.codProduto into gVendidos
                        select new ProdutoVendido
                        {
                            CodProduto = gVendidos.Key,
                            QuantidadeVendida = (decimal) gVendidos.Sum(sp => sp.quantidade)
                        };
            return query.ToList();
        }


        /// <summary>
        /// Atualizar Situação Produtos para Compra
        /// </summary>
        /// <returns></returns>
        public void AtualizarSituacaoEstoqueProdutos()
        {
            const int NUMERO_MESES_ANALISAR = 3;

            AtualizarSituacaoProdutosComprados(NUMERO_MESES_ANALISAR);

            List<ProdutoVendido> listaProdutosVendidos = ObterProdutosVendidosUltimosMeses(NUMERO_MESES_ANALISAR);

            List<ProdutoLoja> listaProdutoLoja = GerenciadorProdutoLoja.GetInstance(null).ObterTodos();
            
            var query = from produto in saceContext.ProdutoSet
                        where produto.codSituacaoProduto != SituacaoProduto.NAO_COMPRAR
                        select produto; 

            foreach( ProdutoE produtoE in query) {
                ProdutoVendido produtoVendido = listaProdutosVendidos.Where(pv => pv.CodProduto == produtoE.codProduto).FirstOrDefault();
                decimal estoqueAtual = listaProdutoLoja.Where(pl => pl.CodProduto == produtoE.codProduto).Sum(p => p.QtdEstoque + p.QtdEstoqueAux);
                
                // necessário deixar os itens como disponível antes da análise por conta das mudanças no estoque
                if (produtoE.codSituacaoProduto != SituacaoProduto.COMPRADO)
                    produtoE.codSituacaoProduto = SituacaoProduto.DISPONIVEL;
                
                if (produtoVendido != null) {
                    if (estoqueAtual <= produtoVendido.QuantidadeVendida) {
                        if ((produtoE.codSituacaoProduto != SituacaoProduto.NAO_COMPRAR) && (produtoE.codSituacaoProduto != SituacaoProduto.COMPRADO)) 
                        {
                            if (estoqueAtual <= (produtoVendido.QuantidadeVendida / 2))
                                produtoE.codSituacaoProduto = SituacaoProduto.COMPRA_URGENTE;
                            else
                                produtoE.codSituacaoProduto = SituacaoProduto.COMPRA_NECESSARIA;
                            produtoE.dataSolicitacaoCompra = DateTime.Now;
                        }
                    }
                    
                }
            }
            saceContext.SaveChanges();
        }


        /// <summary>
        /// Se produto não foi recebido no númeor de meses especificado então a situação dele volta a ser Disponível.
        /// O sistema irá avaliar se uma nova solicitação de compra será necessária.
        /// </summary>
        /// <param name="NUMERO_MESES_ANALISAR"></param>
        private void AtualizarSituacaoProdutosComprados(int NUMERO_MESES_ANALISAR)
        {
            const int NUMERO_DIAS_PRODUTO_STATUS_COMPRADO = -60;

            DateTime dataAnalise = DateTime.Now.AddDays(NUMERO_DIAS_PRODUTO_STATUS_COMPRADO);
            
            var query = from produto in saceContext.ProdutoSet
                         where produto.codSituacaoProduto == SituacaoProduto.COMPRADO &&
                               produto.dataPedidoCompra <= dataAnalise                        
                         select produto; 

            foreach( ProdutoE produtoE in query) {
                produtoE.codSituacaoProduto = SituacaoProduto.DISPONIVEL;
            }
            saceContext.SaveChanges();
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
            _saidaProdutoE.codCST = saidaProduto.CodCST;
            _saidaProdutoE.cfop = saidaProduto.CodCfop;
        }

        /// <summary>
        /// Recalcula os totais da saída de acordo com os produtos registrados.
        /// </summary>
        /// <param name="saida"></param>
        private void RecalcularTotais(Saida saida)
        {
            var query = from saidaProduto in saceContext.SaidaProdutoSet
                        where saidaProduto.codSaida == saida.CodSaida
                        select saidaProduto;
            List <SaidaProdutoE> listaSaidaProdutos = query.ToList();
            saida.Total = listaSaidaProdutos.Sum(sp => sp.subtotal).GetValueOrDefault();
            saida.TotalAVista = listaSaidaProdutos.Sum(sp => sp.subtotalAVista).GetValueOrDefault();
            saida.BaseCalculoICMS = listaSaidaProdutos.Sum(sp => sp.baseCalculoICMS).GetValueOrDefault();
            saida.ValorICMS = listaSaidaProdutos.Sum(sp => sp.valorICMS).GetValueOrDefault();
            saida.BaseCalculoICMSSubst = listaSaidaProdutos.Sum(sp => sp.baseCalculoICMSSubst).GetValueOrDefault();
            saida.ValorICMSSubst = listaSaidaProdutos.Sum(sp => sp.valorICMSSubst).GetValueOrDefault();
            saida.ValorIPI = listaSaidaProdutos.Sum(sp => sp.valorIPI).GetValueOrDefault();
            GerenciadorSaida.GetInstance(null).Atualizar(saida);
        }
    }
}