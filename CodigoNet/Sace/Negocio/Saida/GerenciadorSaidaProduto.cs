using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Util;


namespace Negocio
{
    public class GerenciadorSaidaProduto {

        private readonly SaceContext context;
        private readonly GerenciadorProduto gerenciadorProduto;
        private readonly GerenciadorProdutoLoja gerenciadorProdutoLoja;
        private readonly GerenciadorSaida gerenciadorSaida; 

        public GerenciadorSaidaProduto(SaceContext saceContext)
        {
            context = saceContext;
            gerenciadorProduto = new GerenciadorProduto(context);
            gerenciadorSaida = new GerenciadorSaida(context);
            gerenciadorProdutoLoja = new GerenciadorProdutoLoja(context);
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

            var _saidaProduto = new TbSaidaProduto();
            Atribuir(saidaProduto, _saidaProduto);

            context.Add(_saidaProduto);
            context.SaveChanges();
            return _saidaProduto.CodSaidaProduto;
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


            var _saidaProduto = context.TbSaidaProdutos.Find(new TbSaidaProduto() { CodSaidaProduto = saidaProduto.CodSaidaProduto });
            if (_saidaProduto != null)
            {
                Atribuir(saidaProduto, _saidaProduto);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Atualiza cfop dos produtos
        /// </summary>
        /// <param name="saidaProduto"></param>
        /// <param name="saida"></param>
        public void AtualizarCFOP(long codSaidaProduto, int codCFOP)
        {

            var _saidaProduto = context.TbSaidaProdutos.Find(new TbSaidaProduto() { CodSaidaProduto = codSaidaProduto });
            if (_saidaProduto != null)
            {
                _saidaProduto.Cfop = codCFOP;
                context.SaveChanges();
            }
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
                        
            foreach (SaidaProduto _saidaProduto in listaSaidaProdutos)
            {
                ProdutoPesquisa produto = gerenciadorProduto.Obter(_saidaProduto.CodProduto).ElementAtOrDefault(0);
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

            
            try
            {
                context.Database.BeginTransaction();
                
                var query = from _saidaProduto in context.TbSaidaProdutos
                            where _saidaProduto.CodSaidaProduto == saidaProduto.CodSaidaProduto
                            select _saidaProduto;
                foreach (TbSaidaProduto saidaProdutoE in query)
                {
                    context.Remove(saidaProdutoE);
                }
                context.SaveChanges();

                context.Database.CommitTransaction();
            }
            catch (Exception e)
            {
                context.Database.RollbackTransaction();
                throw new DadosException("Saída de Produtos", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<SaidaProduto> GetQuery()
        {
            var query = from saidaProduto in context.TbSaidaProdutos
                        select new SaidaProduto
                        {
                            BaseCalculoICMS = (decimal) saidaProduto.BaseCalculoIcms,
                            BaseCalculoICMSSubst = (decimal) saidaProduto.BaseCalculoIcmssubst,
                            CodProduto = saidaProduto.CodProduto,
                            CodSaida = saidaProduto.CodSaida,
                            CodSaidaProduto = saidaProduto.CodSaidaProduto,
                            CodCST = saidaProduto.CodCst,
                            CodCfop = saidaProduto.Cfop,
                            DataValidade = (DateTime) saidaProduto.DataValidade,
                            Desconto = (decimal) saidaProduto.Desconto,
                            Quantidade = (decimal) saidaProduto.Quantidade,
                            Nome = saidaProduto.CodProdutoNavigation.Nome,
                            SubtotalAVista = (decimal) saidaProduto.SubtotalAvista,
                            Unidade = saidaProduto.CodProdutoNavigation.Unidade,
                            ValorICMS = (decimal) saidaProduto.ValorIcms,
                            ValorICMSSubst = (decimal) saidaProduto.ValorIcmssubst,
                            ValorIPI = (decimal) saidaProduto.ValorIpi,
                            TemVencimento = (bool) saidaProduto.CodProdutoNavigation.TemVencimento,
                            PrecoVendaVarejo = (decimal)saidaProduto.CodProdutoNavigation.PrecoVendaVarejo,
                            Ncmsh = saidaProduto.CodProdutoNavigation.Ncmsh
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
        public List<SaidaProduto> ObterPorSaida(long codSaida)
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
            var query1 = from saida in context.TbSaida
                         where saida.CodNves.Select(nfe=> nfe.CodNfe).Contains(codNfeControle)
                         select saida.CodSaida; 

            List<long> listaCodSaida = query1.ToList();
            var query = from saidaProduto in context.TbSaidaProdutos
                        where listaCodSaida.Contains(saidaProduto.CodSaida)
                        select new SaidaProduto
                        {
                            BaseCalculoICMS = (decimal)saidaProduto.BaseCalculoIcms,
                            BaseCalculoICMSSubst = (decimal)saidaProduto.BaseCalculoIcmssubst,
                            CodProduto = saidaProduto.CodProduto,
                            CodSaida = saidaProduto.CodSaida,
                            CodSaidaProduto = saidaProduto.CodSaidaProduto,
                            CodCST = saidaProduto.CodProdutoNavigation.CodCst,
                            CodCfop = saidaProduto.Cfop,
                            DataValidade = (DateTime)saidaProduto.DataValidade,
                            Desconto = (decimal)saidaProduto.Desconto,
                            Quantidade = (decimal)saidaProduto.Quantidade,
                            Nome = saidaProduto.CodProdutoNavigation.Nome,
                            SubtotalAVista = (decimal)saidaProduto.SubtotalAvista,
                            Unidade = saidaProduto.CodProdutoNavigation.Unidade,
                            ValorICMS = (decimal)saidaProduto.ValorIcms,
                            ValorICMSSubst = (decimal)saidaProduto.ValorIcmssubst,
                            ValorIPI = (decimal)saidaProduto.ValorIpi,
                            TemVencimento = (bool)saidaProduto.CodProdutoNavigation.TemVencimento,
                            PrecoVendaVarejo = (decimal)saidaProduto.CodProdutoNavigation.PrecoVendaVarejo,
                            Ncmsh = saidaProduto.CodProdutoNavigation.Ncmsh
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
            var query1 = from saida in context.TbSaida
                         where saida.CodNves.Select(nfe => nfe.CodNfe).Contains(codNfeControle)
                         select saida.CodSaida;

            List<long> listaCodSaida = query1.ToList();
            
            
            var query = from saidaProduto in context.TbSaidaProdutos
                        where listaCodSaida.Contains(saidaProduto.CodSaida)  && !saidaProduto.CodCst.EndsWith(codCST)
                        select new SaidaProduto
                        {
                            BaseCalculoICMS = (decimal)saidaProduto.BaseCalculoIcms,
                            BaseCalculoICMSSubst = (decimal)saidaProduto.BaseCalculoIcmssubst,
                            CodProduto = saidaProduto.CodProduto,
                            CodSaida = saidaProduto.CodSaida,
                            CodSaidaProduto = saidaProduto.CodSaidaProduto,
                            CodCST = saidaProduto.CodProdutoNavigation.CodCst,
                            CodCfop = saidaProduto.Cfop,
                            DataValidade = (DateTime)saidaProduto.DataValidade,
                            Desconto = (decimal)saidaProduto.Desconto,
                            Quantidade = (decimal)saidaProduto.Quantidade,
                            Nome = saidaProduto.CodProdutoNavigation.Nome,
                            SubtotalAVista = (decimal)saidaProduto.SubtotalAvista,
                            Unidade = saidaProduto.CodProdutoNavigation.Unidade,
                            ValorICMS = (decimal)saidaProduto.ValorIcms,
                            ValorICMSSubst = (decimal)saidaProduto.ValorIcmssubst,
                            ValorIPI = (decimal)saidaProduto.ValorIpi,
                            TemVencimento = (bool)saidaProduto.CodProdutoNavigation.TemVencimento,
                            PrecoVendaVarejo = (decimal)saidaProduto.CodProdutoNavigation.PrecoVendaVarejo,
                            Ncmsh = saidaProduto.CodProdutoNavigation.Ncmsh
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
            var query = from saidaProduto in context.TbSaidaProdutos
                        where saidaProduto.CodSaidaNavigation.PedidoGerado.Equals(codPedido)
                        select new SaidaProduto
                        {
                            BaseCalculoICMS = (decimal)saidaProduto.BaseCalculoIcms,
                            BaseCalculoICMSSubst = (decimal)saidaProduto.BaseCalculoIcmssubst,
                            CodProduto = saidaProduto.CodProduto,
                            CodSaida = saidaProduto.CodSaida,
                            CodSaidaProduto = saidaProduto.CodSaidaProduto,
                            CodCST = saidaProduto.CodProdutoNavigation.CodCst,
                            CodCfop = saidaProduto.Cfop,
                            DataValidade = (DateTime)saidaProduto.DataValidade,
                            Desconto = (decimal)saidaProduto.Desconto,
                            Quantidade = (decimal)saidaProduto.Quantidade,
                            Nome = saidaProduto.CodProdutoNavigation.Nome,
                            SubtotalAVista = (decimal)saidaProduto.SubtotalAvista,
                            Unidade = saidaProduto.CodProdutoNavigation.Unidade,
                            ValorICMS = (decimal)saidaProduto.ValorIcms,
                            ValorICMSSubst = (decimal)saidaProduto.ValorIcmssubst,
                            ValorIPI = (decimal)saidaProduto.ValorIpi,
                            TemVencimento = (bool)saidaProduto.CodProdutoNavigation.TemVencimento,
                            PrecoVendaVarejo = (decimal) saidaProduto.CodProdutoNavigation.PrecoVendaVarejo,
                            Ncmsh = saidaProduto.CodProdutoNavigation.Ncmsh
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
            var query = from saidaProduto in context.TbSaidaProdutos
                        where saidaProduto.CodSaidaNavigation.PedidoGerado.Equals(codPedido) && !saidaProduto.CodCst.EndsWith(codCST)
                        select new SaidaProduto
                        {
                            BaseCalculoICMS = (decimal)saidaProduto.BaseCalculoIcms,
                            BaseCalculoICMSSubst = (decimal)saidaProduto.BaseCalculoIcmssubst,
                            CodProduto = saidaProduto.CodProduto,
                            CodSaida = saidaProduto.CodSaida,
                            CodSaidaProduto = saidaProduto.CodSaidaProduto,
                            CodCST = saidaProduto.CodProdutoNavigation.CodCst,
                            CodCfop = saidaProduto.Cfop,
                            DataValidade = (DateTime)saidaProduto.DataValidade,
                            Desconto = (decimal)saidaProduto.Desconto,
                            Quantidade = (decimal)saidaProduto.Quantidade,
                            Nome = saidaProduto.CodProdutoNavigation.Nome,
                            SubtotalAVista = (decimal)saidaProduto.SubtotalAvista,
                            Unidade = saidaProduto.CodProdutoNavigation.Unidade,
                            ValorICMS = (decimal)saidaProduto.ValorIcms,
                            ValorICMSSubst = (decimal)saidaProduto.ValorIcmssubst,
                            ValorIPI = (decimal)saidaProduto.ValorIpi,
                            TemVencimento = (bool)saidaProduto.CodProdutoNavigation.TemVencimento,
                            PrecoVendaVarejo = (decimal)saidaProduto.CodProdutoNavigation.PrecoVendaVarejo,
                            Ncmsh = saidaProduto.CodProdutoNavigation.Ncmsh
                        };
            return query.ToList();
        }

        /// <summary>
        /// Obtém os produtos de uma lista de saidas
        /// </summary>
        /// <param name="codPedido"></param>
        /// <returns></returns>
        public List<SaidaProduto> ObterPorSolicitacaoSaidas(List<SolicitacaoSaida> listaSolicitacaoSaidas)
        {
            List<long> listaCodSaidas = listaSolicitacaoSaidas.Select(s => s.CodSaida).ToList();
            var query = from saidaProduto in context.TbSaidaProdutos
                        where listaCodSaidas.Contains(saidaProduto.CodSaida)
                        select new SaidaProduto
                        {
                            BaseCalculoICMS = (decimal)saidaProduto.BaseCalculoIcms,
                            BaseCalculoICMSSubst = (decimal)saidaProduto.BaseCalculoIcmssubst,
                            CodProduto = saidaProduto.CodProduto,
                            CodSaida = saidaProduto.CodSaida,
                            CodSaidaProduto = saidaProduto.CodSaidaProduto,
                            CodCST = saidaProduto.CodProdutoNavigation.CodCst,
                            CodCfop = saidaProduto.Cfop,
                            DataValidade = (DateTime)saidaProduto.DataValidade,
                            Desconto = (decimal)saidaProduto.Desconto,
                            Quantidade = (decimal)saidaProduto.Quantidade,
                            Nome = saidaProduto.CodProdutoNavigation.Nome,
                            SubtotalAVista = (decimal)saidaProduto.SubtotalAvista,
                            Unidade = saidaProduto.CodProdutoNavigation.Unidade,
                            ValorICMS = (decimal)saidaProduto.ValorIcms,
                            ValorICMSSubst = (decimal)saidaProduto.ValorIcmssubst,
                            ValorIPI = (decimal)saidaProduto.ValorIpi,
                            TemVencimento = (bool)saidaProduto.CodProdutoNavigation.TemVencimento,
                            PrecoVendaVarejo = (decimal)saidaProduto.CodProdutoNavigation.PrecoVendaVarejo,
                            Ncmsh = saidaProduto.CodProdutoNavigation.Ncmsh
                        };
            return query.ToList();
        }

        /// <summary>
        /// Obtém os produtos de uma lista de saidas
        /// </summary>
        /// <param name="codPedido"></param>
        /// <returns></returns>
        public List<SaidaProduto> ObterPorSolicitacaoSaidasSemCST(List<SolicitacaoSaida> listaSolicitacaoSaidas, string codCST)
        {
            List<long> listaCodSaidas = listaSolicitacaoSaidas.Select(s => s.CodSaida).ToList();
            var query = from saidaProduto in context.TbSaidaProdutos
                        where listaCodSaidas.Contains(saidaProduto.CodSaida) && !saidaProduto.CodCst.EndsWith(codCST)
                        select new SaidaProduto
                        {
                            BaseCalculoICMS = (decimal)saidaProduto.BaseCalculoIcms,
                            BaseCalculoICMSSubst = (decimal)saidaProduto.BaseCalculoIcmssubst,
                            CodProduto = saidaProduto.CodProduto,
                            CodSaida = saidaProduto.CodSaida,
                            CodSaidaProduto = saidaProduto.CodSaidaProduto,
                            CodCST = saidaProduto.CodProdutoNavigation.CodCst,
                            CodCfop = saidaProduto.Cfop,
                            DataValidade = (DateTime)saidaProduto.DataValidade,
                            Desconto = (decimal)saidaProduto.Desconto,
                            Quantidade = (decimal)saidaProduto.Quantidade,
                            Nome = saidaProduto.CodProdutoNavigation.Nome,
                            SubtotalAVista = (decimal)saidaProduto.SubtotalAvista,
                            Unidade = saidaProduto.CodProdutoNavigation.Unidade,
                            ValorICMS = (decimal)saidaProduto.ValorIcms,
                            ValorICMSSubst = (decimal)saidaProduto.ValorIcmssubst,
                            ValorIPI = (decimal)saidaProduto.ValorIpi,
                            TemVencimento = (bool)saidaProduto.CodProdutoNavigation.TemVencimento,
                            PrecoVendaVarejo = (decimal)saidaProduto.CodProdutoNavigation.PrecoVendaVarejo,
                            Ncmsh = saidaProduto.CodProdutoNavigation.Ncmsh
                        };
            return query.ToList();
        }

        /// <summary>
        /// Consulta para retornar dados dos produtos para relatório
        /// </summary>
        /// <returns></returns>
        private IQueryable<SaidaProdutoRelatorio> GetQueryRelatorio()
        {
            var query = from saidaProduto in context.TbSaidaProdutos
                        select new SaidaProdutoRelatorio
                        {
                            CodProduto = saidaProduto.CodProduto,
                            CodSaida = saidaProduto.CodSaida,
                            CodSaidaProduto = saidaProduto.CodSaidaProduto,
                            Desconto = (decimal)saidaProduto.Desconto,
                            Quantidade = (decimal)saidaProduto.Quantidade,
                            Nome = saidaProduto.CodProdutoNavigation.Nome,
                            Subtotal = (decimal)saidaProduto.Subtotal,
                            SubtotalAVista = (decimal)saidaProduto.SubtotalAvista,
                            Unidade = saidaProduto.CodProdutoNavigation.Unidade == null ? "UN" : saidaProduto.CodProdutoNavigation.Unidade,
                            ValorVenda = (decimal)saidaProduto.ValorVenda,
                            ValorVendaAVista = (decimal) (saidaProduto.SubtotalAvista / saidaProduto.Quantidade),
                            TotalSaida = (decimal)saidaProduto.CodSaidaNavigation.Total,
                            TotalSaidaAVista = (decimal)saidaProduto.CodSaidaNavigation.TotalAvista,
                            Pedido = saidaProduto.CodSaidaNavigation.PedidoGerado,
                            DataSaida = saidaProduto.CodSaidaNavigation.DataSaida,
                            CodCliente = saidaProduto.CodSaidaNavigation.CodCliente
                        };
            return query.AsNoTracking();
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

            var query = from saidaProduto in context.TbSaidaProdutos
                        where (saidaProduto.CodSaidaNavigation.DataSaida >= dataMesesAntes) && 
                              (saidaProduto.CodSaidaNavigation.CodTipoSaida.Equals(Saida.TIPO_PRE_VENDA) 
                              || saidaProduto.CodSaidaNavigation.CodTipoSaida.Equals(Saida.TIPO_VENDA)
                              || saidaProduto.CodSaidaNavigation.CodTipoSaida.Equals(Saida.TIPO_USO_INTERNO))
                        group saidaProduto by saidaProduto.CodProduto into gVendidos
                        select new ProdutoVendido
                        {
                            CodProduto = gVendidos.Key,
                            QuantidadeVendida = (decimal) gVendidos.Sum(sp => sp.Quantidade)
                        };
            return query.ToList();
        }

        /// <summary>
        /// Obtem os dados dos produtos vendidos por mês no número de anos informados
        /// </summary>
        /// <param name="codProduto"></param>
        /// <param name="numeroAnos"></param>
        /// <returns></returns>
        public List<ProdutoVendido> ObterProdutosVendidosUltimosAnos(long codProduto, int numeroAnos)
        {

            string nomeProduto = context.TbProdutos.Find(new TbProduto { CodProduto = codProduto }).Nome;

            var query = from saidaProduto in context.TbSaidaProdutos
                        where (saidaProduto.CodSaidaNavigation.CodTipoSaida == Saida.TIPO_VENDA ||
                              saidaProduto.CodSaidaNavigation.CodTipoSaida == Saida.TIPO_PRE_VENDA ||
                              saidaProduto.CodSaidaNavigation.CodTipoSaida == Saida.TIPO_USO_INTERNO) &&
                              saidaProduto.CodSaidaNavigation.DataSaida.Year >= (DateTime.Now.Year - numeroAnos)
                        orderby saidaProduto.CodSaidaNavigation.DataSaida.Year descending, saidaProduto.CodSaidaNavigation.DataSaida.Month descending
                        group saidaProduto by
                            new { saidaProduto.CodSaidaNavigation.DataSaida.Year, saidaProduto.CodSaidaNavigation.DataSaida.Month } into gVendidos
                        select new ProdutoVendido
                        {
                            CodProduto = codProduto,
                            Nome = nomeProduto,
                            Ano = gVendidos.Key.Year,
                            Mes = gVendidos.Key.Month,
                            MesAno = String.Concat(gVendidos.Key.Month, "/", gVendidos.Key.Year),
                            QuantidadeVendida = (decimal)gVendidos.Sum(sp => sp.Quantidade)
                        };

            List<ProdutoVendido> listaProdutosVendidos = new List<ProdutoVendido>();


            // Insere zero nos meses sem vendas do produto
            DateTime dataAtual = DateTime.Now;
            int numeroMeses = numeroAnos * 12;
            for (int i = 0; i < numeroMeses && i < listaProdutosVendidos.Count; i++)
            {
                ProdutoVendido produtoVendido = listaProdutosVendidos[i];
                if (produtoVendido.Mes != dataAtual.Month || produtoVendido.Ano != dataAtual.Year)
                {
                    ProdutoVendido _produtoVendido = new ProdutoVendido();
                    _produtoVendido.Ano = dataAtual.Year;
                    _produtoVendido.Mes = dataAtual.Month;
                    _produtoVendido.MesAno = dataAtual.Month + "/" + dataAtual.Year;
                    _produtoVendido.Nome = produtoVendido.Nome;
                    _produtoVendido.QuantidadeVendida = 0;
                    listaProdutosVendidos.Insert(i, _produtoVendido);
                }
                dataAtual = dataAtual.AddMonths(-1);
            }
            return listaProdutosVendidos;
        }

        /// <summary>
        /// Atualizar Situação Produtos para Compra
        /// </summary>
        /// <returns></returns>
        public void AtualizarSituacaoEstoqueProdutos()
        {
            AtualizarSituacaoProdutosComprados(UtilConfig.Default.NUMERO_MESES_ANALISAR_ESTOQUE);

            List<ProdutoVendido> listaProdutosVendidos = ObterProdutosVendidosUltimosMeses(UtilConfig.Default.NUMERO_MESES_ANALISAR_ESTOQUE);

            List<ProdutoLoja> listaProdutoLoja = gerenciadorProdutoLoja.ObterTodos();
            
            var query = from produto in context.TbProdutos
                        where produto.CodSituacaoProduto != SituacaoProduto.NAO_COMPRAR
                        select produto; 

            foreach( TbProduto produto in query) {
                ProdutoVendido produtoVendido = listaProdutosVendidos.Where(pv => pv.CodProduto == produto.CodProduto).FirstOrDefault();
                decimal estoqueAtual = listaProdutoLoja.Where(pl => pl.CodProduto == produto.CodProduto).Sum(p => p.QtdEstoque + p.QtdEstoqueAux);

                // necessário deixar os itens como disponível antes da análise por conta das mudanças no estoque
                if (produto.CodSituacaoProduto != SituacaoProduto.COMPRADO)
                    produto.CodSituacaoProduto = SituacaoProduto.DISPONIVEL;


                if (produtoVendido != null)
                {
                    if (estoqueAtual <= produtoVendido.QuantidadeVendida)
                    {
                        if ((produto.CodSituacaoProduto != SituacaoProduto.NAO_COMPRAR) && (produto.CodSituacaoProduto != SituacaoProduto.COMPRADO))
                        {
                            if (estoqueAtual <= (produtoVendido.QuantidadeVendida / 2))
                                produto.CodSituacaoProduto = SituacaoProduto.COMPRA_URGENTE;
                            else
                                produto.CodSituacaoProduto = SituacaoProduto.COMPRA_NECESSARIA;
                            produto.DataSolicitacaoCompra = DateTime.Now;
                        }
                    }
                }
                else
                {
                    if (estoqueAtual <= 0)
                    {
                        if ((produto.CodSituacaoProduto != SituacaoProduto.NAO_COMPRAR) && (produto.CodSituacaoProduto != SituacaoProduto.COMPRADO))
                        {
                            produto.CodSituacaoProduto = SituacaoProduto.COMPRA_URGENTE;
                            produto.DataSolicitacaoCompra = DateTime.Now;
                        }
                    }
                }
            }
            context.SaveChanges();
        }


        /// <summary>
        /// Se produto não foi recebido no númeor de meses especificado então a situação dele volta a ser Disponível.
        /// O sistema irá avaliar se uma nova solicitação de compra será necessária.
        /// </summary>
        /// <param name="NUMERO_MESES_ANALISAR"></param>
        private void AtualizarSituacaoProdutosComprados(int NUMERO_MESES_ANALISAR)
        {
            DateTime dataAnalise = DateTime.Now.AddDays(UtilConfig.Default.NUMERO_DIAS_PRODUTO_STATUS_COMPRADO * (-1));
            
            var query = from produto in context.TbProdutos
                         where produto.CodSituacaoProduto == SituacaoProduto.COMPRADO &&
                               produto.DataPedidoCompra <= dataAnalise                        
                         select produto; 

            foreach( TbProduto produto in query) {
                produto.CodSituacaoProduto = SituacaoProduto.DISPONIVEL;
            }
            context.SaveChanges();
        }
        


        /// <summary>
        /// Atribui entidade para entidade persistente
        /// </summary>
        /// <param name="saidaProduto"></param>
        /// <param name="_saidaProdutoE"></param>
        private static void Atribuir(SaidaProduto saidaProduto, TbSaidaProduto _saidaProduto)
        {
            _saidaProduto.BaseCalculoIcms = saidaProduto.BaseCalculoICMS;
            _saidaProduto.BaseCalculoIcmssubst = saidaProduto.BaseCalculoICMSSubst;
            _saidaProduto.CodProduto = saidaProduto.CodProduto;
            _saidaProduto.CodSaida = saidaProduto.CodSaida;
            _saidaProduto.DataValidade = saidaProduto.DataValidade;
            _saidaProduto.Desconto = saidaProduto.Desconto;
            _saidaProduto.Quantidade = saidaProduto.Quantidade;
            _saidaProduto.Subtotal = saidaProduto.Subtotal;
            _saidaProduto.SubtotalAvista = saidaProduto.SubtotalAVista;
            _saidaProduto.ValorIcms = saidaProduto.ValorICMS;
            _saidaProduto.ValorIcmssubst = saidaProduto.ValorICMSSubst;
            _saidaProduto.ValorIpi = saidaProduto.ValorIPI;
            _saidaProduto.ValorVenda = saidaProduto.ValorVenda;
            _saidaProduto.CodCst = saidaProduto.CodCST;
            _saidaProduto.Cfop = saidaProduto.CodCfop;
        }

        /// <summary>
        /// Recalcula os totais da saída de acordo com os produtos registrados.
        /// </summary>
        /// <param name="saida"></param>
        private void RecalcularTotais(Saida saida)
        {
            var query = from saidaProduto in context.TbSaidaProdutos
                        where saidaProduto.CodSaida == saida.CodSaida
                        select saidaProduto;
            var listaSaidaProdutos = query.ToList();
            saida.Total = listaSaidaProdutos.Sum(sp => sp.Subtotal).GetValueOrDefault();
            saida.TotalAVista = listaSaidaProdutos.Sum(sp => sp.SubtotalAvista).GetValueOrDefault();
            saida.BaseCalculoICMS = listaSaidaProdutos.Sum(sp => sp.BaseCalculoIcms).GetValueOrDefault();
            saida.ValorICMS = listaSaidaProdutos.Sum(sp => sp.ValorIcms).GetValueOrDefault();
            saida.BaseCalculoICMSSubst = listaSaidaProdutos.Sum(sp => sp.BaseCalculoIcmssubst).GetValueOrDefault();
            saida.ValorICMSSubst = listaSaidaProdutos.Sum(sp => sp.ValorIcmssubst).GetValueOrDefault();
            saida.ValorIPI = listaSaidaProdutos.Sum(sp => sp.ValorIpi).GetValueOrDefault();
            gerenciadorSaida.Atualizar(saida);
        }
    }
}