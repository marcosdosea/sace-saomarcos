using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Util;

namespace Negocio
{
    public class GerenciadorEntradaProduto 
    {
        private readonly SaceContext context;
        private readonly GerenciadorProduto gerenciadorProduto;
        private readonly GerenciadorProdutoLoja gerenciadorProdutoLoja;
        private readonly GerenciadorEntrada gerenciadorEntrada;

        public GerenciadorEntradaProduto(SaceContext saceContext)
        {
            context = saceContext;
            gerenciadorProduto = new GerenciadorProduto(context);
            gerenciadorProdutoLoja = new GerenciadorProdutoLoja(context);
            gerenciadorEntrada = new GerenciadorEntrada(context);
        }

        /// <summary>
        /// Insere uma novo produto na entrada
        public Int64 Inserir(EntradaProduto entradaProduto, int codTipoEntrada)
        {

            if (entradaProduto.Quantidade == 0)
                throw new NegocioException("A quantidade do produto não pode ser igual a zero.");
            else if (entradaProduto.PrecoVendaVarejo <= 0)
                throw new NegocioException("O preço de venda deve ser maior que zero.");
            else if (entradaProduto.QuantidadeEmbalagem <= 0)
                throw new NegocioException("A quantidade de produtos em cada embalagem deve ser maior que zero.");

            Produto produto = gerenciadorProduto.Obter(new ProdutoPesquisa() { CodProduto = entradaProduto.CodProduto });
            
            Cst cstEntrada = new Cst() { CodCST = entradaProduto.CodCST } ;

            bool ehTributacaoIntegral = cstEntrada.EhTributacaoIntegral;
            if (!produto.EhTributacaoIntegral && ehTributacaoIntegral)
            {
                throw new NegocioException("Esse produto não pode voltar a ser tributação Normal. Favor colocar CST com Substituição Tributária e CUIDADO no cálculo do preço. Verifique se o o DAE de encerramento de fase da nota já chegou.");
            }

            if (ehTributacaoIntegral && (entradaProduto.Icms <= 0))
            {
                throw new NegocioException("O campo % CRED ICMS não pode ser menor ou igual a zero quando o produto possui tributação normal.");
            }
            else if ((!ehTributacaoIntegral) && (entradaProduto.IcmsSubstituto <= 0) && 
                (!entradaProduto.CodCST.Substring(1).Equals(Cst.ST_SUBSTITUICAO_ICMS_COBRADO)) && !cstEntrada.EhTributacaoSimples)
            {
                throw new NegocioException("O campo % ICMS ST não pode ser menor ou igual a zero quando o produto possui substituição tributária.");
            }

            try
            {
                var _entradaProduto = new TbEntradaProduto();
                Atribuir(entradaProduto, _entradaProduto);

                context.Add(_entradaProduto);
                context.SaveChanges();

                if ((codTipoEntrada == Entrada.TIPO_ENTRADA) || (codTipoEntrada == Entrada.TIPO_ENTRADA_AUX))
                {
                    // Incrementa o estoque na loja principal
                    gerenciadorProdutoLoja.AdicionaQuantidade((entradaProduto.Quantidade * entradaProduto.QuantidadeEmbalagem), 0, UtilConfig.Default.LOJA_PADRAO, entradaProduto.CodProduto);

                    Atribuir(entradaProduto, produto);
                    produto.CodSituacaoProduto = SituacaoProduto.DISPONIVEL;
                    produto.ExibeNaListagem = true;
                    
                    // Atualiza os dados do produto se não foi na entrada padrão
                    if (entradaProduto.CodEntrada != UtilConfig.Default.ENTRADA_PADRAO) 
                        gerenciadorProduto.Atualizar(produto);
                }
                return _entradaProduto.CodEntrada;
            }
            catch (Exception e)
            {
                throw new DadosException("EntradaProduto", e.Message, e);
            }
        }

        
        /// <summary>
        /// Atualiza os dados de um produto na entrada
        /// </summary>
        /// <param name="entradaProduto"></param>
        public void Atualizar(EntradaProduto entradaProduto)
        {
            try
            {
                var _entradaProduto = new TbEntradaProduto();
                _entradaProduto.CodEntradaProduto = entradaProduto.CodEntradaProduto;

                _entradaProduto = context.TbEntradaProdutos.Find(_entradaProduto);
                if (_entradaProduto != null)
                {
                    Atribuir(entradaProduto, _entradaProduto);
                    context.SaveChanges();
                }
                else
                {
                    throw new NegocioException("Entrada de produto não encontrada para atualização.");
                }
            }
            catch (Exception e)
            {
                throw new DadosException("EntradaProduto", e.Message, e);
            }
        }

        /// <summary>
        /// REmove um produto de uma entrada
        /// </summary>
        /// <param name="codEntradaProduto"></param>
        public void Remover(EntradaProduto entradaProduto, int codTipoEntrada)
        {
            var transaction = context.Database.BeginTransaction();
            try
            {
                var _entradaProduto = new TbEntradaProduto();
                _entradaProduto.CodEntradaProduto = entradaProduto.CodEntradaProduto;

                context.Remove(entradaProduto);
                context.SaveChanges();

                // Decrementa o estoque na loja principal
                gerenciadorProdutoLoja.AdicionaQuantidade((entradaProduto.Quantidade * entradaProduto.QuantidadeEmbalagem * (-1)), 0, UtilConfig.Default.LOJA_PADRAO, entradaProduto.CodProduto);
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                throw new DadosException("EntradaProduto", e.Message, e);
            }
        }


        /// <summary>
        /// Importa os produtos de uma Nfe
        /// </summary>
        /// <param name="nfe"></param>
        public List<EntradaProduto> Importar(TNfeProc nfe)
        {
            const string VERSAO3 = "3.10";
            const string VERSAO4 = "4.00";

            try
            {
                CultureInfo ci = new CultureInfo("en-US"); // usado para connversão dos números do xml
                string numeroNF = nfe.NFe.infNFe.ide.nNF;
                string versaoNF = nfe.NFe.infNFe.versao;
                string cpf_cnpjFornecedor = nfe.NFe.infNFe.emit.Item;
                IEnumerable<Entrada> entradas = gerenciadorEntrada.ObterPorNumeroNotaFiscalFornecedor(numeroNF, cpf_cnpjFornecedor);
                if (entradas.Count() == 0)
                {
                    throw new NegocioException("A entrada não foi encontrada para realizar o cadastro de produtos");
                }
                Entrada entrada = entradas.ElementAtOrDefault(0);
                List<EntradaProduto> listaProtutos = new List<EntradaProduto>();
                foreach (TNFeInfNFeDet produto in nfe.NFe.infNFe.det)
                {
                    EntradaProduto entradaProduto = new EntradaProduto();
                    entradaProduto.Cfop = Convert.ToInt32(produto.prod.CFOP);
                    entradaProduto.CodEntrada = entrada.CodEntrada;
                    entradaProduto.CodFornecedor = entrada.CodFornecedor;
                    ProdutoPesquisa produtoPesquisa = null;
                    if (!string.IsNullOrEmpty(produto.prod.cEAN))
                    {
                        produtoPesquisa = gerenciadorProduto.ObterPorCodigoBarraExato(produto.prod.cEAN).ElementAtOrDefault(0);
                    }
                
                    entradaProduto.CodProduto = (produtoPesquisa != null) ? produtoPesquisa.CodProduto : 1;
                    entradaProduto.DataEntrada = entrada.DataEntrada;
                    entradaProduto.FornecedorEhFabricante = entrada.FornecedorEhFabricante;
                    if (entrada.ValorFrete > 0)
                        entradaProduto.Frete = ((entrada.ValorFrete / entrada.TotalProdutos) * 100);
                    else
                        entradaProduto.Frete = 0;
                    entradaProduto.Ncmsh = produto.prod.NCM;
                    entradaProduto.NomeProduto = produto.prod.xProd.Length > 50 ? produto.prod.xProd.Substring(0, 50).ToUpper() : produto.prod.xProd.ToUpper();
                    
                    entradaProduto.Quantidade = Convert.ToDecimal(produto.prod.qCom, ci);
                    entradaProduto.QuantidadeEmbalagem = (produtoPesquisa == null) ? 1 : produtoPesquisa.QuantidadeEmbalagem;
                    entradaProduto.Simples = (produtoPesquisa == null) ? UtilConfig.Default.SIMPLES : produtoPesquisa.Simples;
                    entradaProduto.UnidadeCompra = produto.prod.uCom;
                    entradaProduto.ValorDesconto = Convert.ToDecimal(produto.prod.vDesc, ci);
                    entradaProduto.ValorUnitario = Convert.ToDecimal(produto.prod.vUnCom, ci);
                    entradaProduto.Desconto = Convert.ToDecimal(produto.prod.vDesc, ci) / entradaProduto.ValorTotal * 100;
                    entradaProduto.CodigoBarra = produto.prod.cEAN;
                    
                    

                    entradaProduto.ReferenciaFabricante = produto.prod.cProd;

                    for (int i = 0; i < produto.imposto.Items.Length; i++)
                    {
                        
                        if (produto.imposto.Items[i] is TNFeInfNFeDetImpostoICMS)
                        {
                            var icms = ((TNFeInfNFeDetImpostoICMS)produto.imposto.Items[i]).Item;
                            if (icms is TNFeInfNFeDetImpostoICMSICMS00)
                            {
                                TNFeInfNFeDetImpostoICMSICMS00 icms00 = ((TNFeInfNFeDetImpostoICMSICMS00)icms); ;
                                entradaProduto.BaseCalculoICMS = Convert.ToDecimal(icms00.vBC, ci);
                                entradaProduto.BaseCalculoICMSST = 0;
                                entradaProduto.CodCST = icms00.orig.ToString().Substring(4) + icms00.CST.ToString().Substring(4);
                                entradaProduto.CodCSTNFe = icms00.orig.ToString().Substring(4) + icms00.CST.ToString().Substring(4);
                                entradaProduto.Icms = Convert.ToDecimal(icms00.pICMS, ci);
                                entradaProduto.IcmsSubstituto = 0; 
                            }
                            else if (icms is TNFeInfNFeDetImpostoICMSICMS10)
                            {
                                TNFeInfNFeDetImpostoICMSICMS10 icms10 = ((TNFeInfNFeDetImpostoICMSICMS10)icms); ;
                                entradaProduto.BaseCalculoICMS = Convert.ToDecimal(icms10.vBC, ci);
                                entradaProduto.BaseCalculoICMSST = Convert.ToDecimal(icms10.vBCST, ci);
                                entradaProduto.CodCST = icms10.orig.ToString().Substring(4) + icms10.CST.ToString().Substring(4);
                                entradaProduto.CodCSTNFe = icms10.orig.ToString().Substring(4) + icms10.CST.ToString().Substring(4);
                                entradaProduto.Icms = Convert.ToDecimal(icms10.pICMS, ci);
                                if (entrada.TotalProdutosST > 0)
                                    entradaProduto.IcmsSubstituto = entrada.TotalSubstituicao / entrada.TotalProdutosST * 100; //Convert.ToDecimal(icms10.pICMSST, ci);
                            } 
                            else if (icms is TNFeInfNFeDetImpostoICMSICMS20)
                            {
                                TNFeInfNFeDetImpostoICMSICMS20 icms20 = ((TNFeInfNFeDetImpostoICMSICMS20)icms); ;
                                entradaProduto.BaseCalculoICMS = Convert.ToDecimal(icms20.vBC, ci);
                                entradaProduto.BaseCalculoICMSST = 0;
                                entradaProduto.CodCST = icms20.orig.ToString().Substring(4) + icms20.CST.ToString().Substring(4);
                                entradaProduto.CodCSTNFe = icms20.orig.ToString().Substring(4) + icms20.CST.ToString().Substring(4);
                                entradaProduto.Icms = Convert.ToDecimal(icms20.pICMS, ci);
                                entradaProduto.IcmsSubstituto = 0; //Convert.ToDecimal(icms10.pICMSST, ci);
                            }
                            else if (icms is TNFeInfNFeDetImpostoICMSICMS30)
                            {
                                TNFeInfNFeDetImpostoICMSICMS30 icms30 = ((TNFeInfNFeDetImpostoICMSICMS30)icms); ;
                                entradaProduto.BaseCalculoICMS = 0;
                                entradaProduto.BaseCalculoICMSST = Convert.ToDecimal(icms30.vBCST, ci);
                                entradaProduto.CodCST = icms30.orig.ToString().Substring(4) + icms30.CST.ToString().Substring(4);
                                entradaProduto.CodCSTNFe = icms30.orig.ToString().Substring(4) + icms30.CST.ToString().Substring(4);
                                entradaProduto.Icms = 0;
                                if (entrada.TotalProdutosST > 0)
                                    entradaProduto.IcmsSubstituto = entrada.TotalSubstituicao / entrada.TotalProdutosST * 100; //Convert.ToDecimal(icms10.pICMSST, ci);
                            }
                            else if (icms is TNFeInfNFeDetImpostoICMSICMS40)
                            {
                                TNFeInfNFeDetImpostoICMSICMS40 icms40 = ((TNFeInfNFeDetImpostoICMSICMS40)icms); ;
                                entradaProduto.BaseCalculoICMS = 0;
                                entradaProduto.BaseCalculoICMSST = 0;
                                entradaProduto.CodCST = icms40.orig.ToString().Substring(4) + icms40.CST.ToString().Substring(4);
                                entradaProduto.CodCSTNFe = icms40.orig.ToString().Substring(4) + icms40.CST.ToString().Substring(4);
                                entradaProduto.Icms = 0;
                                if (entrada.TotalProdutosST > 0)
                                    entradaProduto.IcmsSubstituto = entrada.TotalSubstituicao / entrada.TotalProdutosST * 100; //Convert.ToDecimal(icms10.pICMSST, ci);
                            }
                            else if (icms is TNFeInfNFeDetImpostoICMSICMS60)
                            {
                                TNFeInfNFeDetImpostoICMSICMS60 icms60 = ((TNFeInfNFeDetImpostoICMSICMS60)icms); ;
                                entradaProduto.BaseCalculoICMS = 0;
                                entradaProduto.BaseCalculoICMSST = Convert.ToDecimal(icms60.vBCSTRet, ci);
                                entradaProduto.CodCST = icms60.orig.ToString().Substring(4) + icms60.CST.ToString().Substring(4);
                                entradaProduto.CodCSTNFe = icms60.orig.ToString().Substring(4) + icms60.CST.ToString().Substring(4);
                                entradaProduto.Icms = Convert.ToDecimal(icms60.vICMSSTRet, ci);
                                if (entrada.TotalProdutosST > 0)
                                    entradaProduto.IcmsSubstituto = entrada.TotalSubstituicao / entrada.TotalProdutosST * 100; //Convert.ToDecimal(icms10.pICMSST, ci);
                            } 
                            else if (icms is TNFeInfNFeDetImpostoICMSICMS70)
                            {
                                TNFeInfNFeDetImpostoICMSICMS70 icms70 = ((TNFeInfNFeDetImpostoICMSICMS70)icms); ;
                                entradaProduto.BaseCalculoICMS = Convert.ToDecimal(icms70.vBC, ci);
                                entradaProduto.BaseCalculoICMSST = Convert.ToDecimal(icms70.vBCST, ci);
                                entradaProduto.CodCST = icms70.orig.ToString().Substring(4) + icms70.CST.ToString().Substring(4);
                                entradaProduto.CodCSTNFe = icms70.orig.ToString().Substring(4) + icms70.CST.ToString().Substring(4);
                                entradaProduto.Icms = Convert.ToDecimal(icms70.pICMS, ci);
                                if (entrada.TotalProdutosST > 0)
                                    entradaProduto.IcmsSubstituto = entrada.TotalSubstituicao / entrada.TotalProdutosST * 100; //Convert.ToDecimal(icms10.pICMSST, ci);
                            }
                            else if (icms is TNFeInfNFeDetImpostoICMSICMSSN101)
                            {
                                TNFeInfNFeDetImpostoICMSICMSSN101 icms101 = ((TNFeInfNFeDetImpostoICMSICMSSN101)icms); ;
                                entradaProduto.BaseCalculoICMS = 0;
                                entradaProduto.BaseCalculoICMSST = 0;
                                entradaProduto.CodCST = icms101.orig.ToString().Substring(4) + icms101.CSOSN.ToString().Substring(4);
                                entradaProduto.CodCSTNFe = icms101.orig.ToString().Substring(4) + icms101.CSOSN.ToString().Substring(4);
                                entradaProduto.Icms = Convert.ToDecimal(icms101.pCredSN, ci);
                                entradaProduto.IcmsSubstituto = 0; 
                            }
                            else if (icms is TNFeInfNFeDetImpostoICMSICMSSN102)
                            {
                                TNFeInfNFeDetImpostoICMSICMSSN102 icms102 = ((TNFeInfNFeDetImpostoICMSICMSSN102)icms); ;
                                entradaProduto.BaseCalculoICMS = 0;
                                entradaProduto.BaseCalculoICMSST = 0;
                                entradaProduto.CodCST = icms102.orig.ToString().Substring(4) + icms102.CSOSN.ToString().Substring(4);
                                entradaProduto.CodCSTNFe = icms102.orig.ToString().Substring(4) + icms102.CSOSN.ToString().Substring(4);
                                entradaProduto.Icms = 0;
                                entradaProduto.IcmsSubstituto = 0;
                            }
                            else if (icms is TNFeInfNFeDetImpostoICMSICMSSN900)
                            {
                                TNFeInfNFeDetImpostoICMSICMSSN900 icms900 = ((TNFeInfNFeDetImpostoICMSICMSSN900)icms); ;
                                entradaProduto.BaseCalculoICMS = Convert.ToDecimal(icms900.vBC, ci);
                                entradaProduto.BaseCalculoICMSST = Convert.ToDecimal(icms900.vBCST, ci);
                                entradaProduto.CodCST = icms900.orig.ToString().Substring(4) + icms900.CSOSN.ToString().Substring(4);
                                entradaProduto.CodCSTNFe = icms900.orig.ToString().Substring(4) + icms900.CSOSN.ToString().Substring(4);
                                entradaProduto.Icms = Convert.ToDecimal(icms900.pICMS, ci); 
                                entradaProduto.IcmsSubstituto = 0;
                                if (entrada.TotalProdutosST > 0)
                                    entradaProduto.IcmsSubstituto = entrada.TotalSubstituicao / entrada.TotalProdutosST * 100;
                            }
                            else if (icms is TNFeInfNFeDetImpostoICMSICMSSN201)
                            {
                                TNFeInfNFeDetImpostoICMSICMSSN201 icms201 = ((TNFeInfNFeDetImpostoICMSICMSSN201)icms); ;
                                entradaProduto.BaseCalculoICMS = 0;
                                entradaProduto.BaseCalculoICMSST = Convert.ToDecimal(icms201.vBCST, ci);
                                entradaProduto.CodCST = icms201.orig.ToString().Substring(4) + icms201.CSOSN.ToString().Substring(4);
                                entradaProduto.CodCSTNFe = icms201.orig.ToString().Substring(4) + icms201.CSOSN.ToString().Substring(4);
                                entradaProduto.Icms = 0;
                                if (entrada.TotalProdutosST > 0)
                                    entradaProduto.IcmsSubstituto = entrada.TotalSubstituicao / entrada.TotalProdutosST * 100;
                            }
                            else if (icms is TNFeInfNFeDetImpostoICMSICMSSN202)
                            {
                                TNFeInfNFeDetImpostoICMSICMSSN202 icms202 = ((TNFeInfNFeDetImpostoICMSICMSSN202)icms); ;
                                entradaProduto.BaseCalculoICMS = 0;
                                entradaProduto.BaseCalculoICMSST = Convert.ToDecimal(icms202.vBCST, ci);
                                entradaProduto.CodCST = icms202.orig.ToString().Substring(4) + icms202.CSOSN.ToString().Substring(4);
                                entradaProduto.CodCSTNFe = icms202.orig.ToString().Substring(4) + icms202.CSOSN.ToString().Substring(4);
                                entradaProduto.Icms = 0;
                                if (entrada.TotalProdutosST > 0)
                                    entradaProduto.IcmsSubstituto = entrada.TotalSubstituicao / entrada.TotalProdutosST * 100;
                            }
                            else if (icms is TNFeInfNFeDetImpostoICMSICMSSN500)
                            {
                                TNFeInfNFeDetImpostoICMSICMSSN500 icms500 = ((TNFeInfNFeDetImpostoICMSICMSSN500)icms); ;
                                entradaProduto.BaseCalculoICMS = 0;
                                entradaProduto.BaseCalculoICMSST = Convert.ToDecimal(icms500.vBCSTRet, ci);
                                entradaProduto.CodCST = icms500.orig.ToString().Substring(4) + icms500.CSOSN.ToString().Substring(4);
                                entradaProduto.CodCSTNFe = icms500.orig.ToString().Substring(4) + icms500.CSOSN.ToString().Substring(4);
                                entradaProduto.Icms = 0;
                                if (entrada.TotalProdutosST > 0)
                                    entradaProduto.IcmsSubstituto = entrada.TotalSubstituicao / entrada.TotalProdutosST * 100;
                            }

                            else
                            {
                                throw new NegocioException("Existe um imposto ICMS não tratado pela importação. Avise ao administrador.");
                            }
                        }
                        else if (versaoNF.Equals(VERSAO3) || versaoNF.Equals(VERSAO4))
                        {
                            if (produto.imposto.Items[i] is TIpi)
                            {
                                TIpi ipi = (TIpi)produto.imposto.Items[i];
                                if (ipi.Item is TIpiIPITrib)
                                {
                                    TIpiIPITrib impostoIPI = (TIpiIPITrib)ipi.Item;
                                    entradaProduto.Ipi = Convert.ToDecimal(impostoIPI.vIPI, ci) / entradaProduto.ValorTotal * 100;
                                }
                                else
                                {
                                    entradaProduto.Ipi = 0;
                                }
                            }
                        }
                    }

                    Produto produtoCalculo = new Produto()
                    {
                        Desconto = entradaProduto.Desconto,
                        Icms = entradaProduto.Icms,
                        IcmsSubstituto = entradaProduto.IcmsSubstituto,
                        Ipi = entradaProduto.Ipi,
                        Frete = entradaProduto.Frete,
                        Simples = entradaProduto.Simples,
                        UltimoPrecoCompra = (entradaProduto.ValorUnitario / entradaProduto.QuantidadeEmbalagem)
                    };

                    entradaProduto.PrecoCusto = produtoCalculo.PrecoCusto;

                    if (produtoPesquisa == null)
                    {
                        entradaProduto.LucroPrecoRevenda = 15;
                        entradaProduto.LucroPrecoVendaAtacado = 30;
                        entradaProduto.LucroPrecoVendaVarejo = 35;
                        entradaProduto.QtdProdutoAtacado = 0;
                    }
                    else
                    {
                        entradaProduto.LucroPrecoRevenda = produtoPesquisa.LucroPrecoRevenda;
                        entradaProduto.LucroPrecoVendaAtacado = produtoPesquisa.LucroPrecoVendaAtacado;
                        entradaProduto.LucroPrecoVendaVarejo = produtoPesquisa.LucroPrecoVendaVarejo;
                        entradaProduto.QtdProdutoAtacado = produtoPesquisa.QtdProdutoAtacado;
                    }

                    produtoCalculo.LucroPrecoRevenda = entradaProduto.LucroPrecoRevenda;
                    produtoCalculo.LucroPrecoVendaAtacado = entradaProduto.LucroPrecoVendaAtacado;
                    produtoCalculo.LucroPrecoVendaVarejo = entradaProduto.LucroPrecoVendaVarejo;

                    entradaProduto.PrecoRevendaSugestao = produtoCalculo.PrecoRevendaSugestao;
                    entradaProduto.PrecoVendaAtacadoSugestao = produtoCalculo.PrecoVendaAtacadoSugestao;
                    entradaProduto.PrecoVendaVarejoSugestao = produtoCalculo.PrecoVendaVarejoSugestao;

                    if (produtoPesquisa == null)
                    {
                        entradaProduto.PrecoRevenda = entradaProduto.PrecoRevendaSugestao;
                        entradaProduto.PrecoVendaAtacado = entradaProduto.PrecoVendaAtacadoSugestao;
                        entradaProduto.PrecoVendaVarejo = entradaProduto.PrecoVendaVarejoSugestao;
                    }
                    else
                    {
                        entradaProduto.PrecoRevenda = produtoPesquisa.PrecoRevenda;
                        entradaProduto.PrecoVendaAtacado = produtoPesquisa.PrecoVendaAtacado;
                        entradaProduto.PrecoVendaVarejo = produtoPesquisa.PrecoVendaVarejo;
                    }
                     
                    listaProtutos.Add(entradaProduto);
                }

                return listaProtutos;
            }
            catch (Exception e)
            {
                throw new NegocioException("Problema durante a importação dos dados dos Produtos da NF-e. Favor contactar administrador.", e);
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<EntradaProduto> GetQuery()
        {
            var query = from entradaProduto in context.TbEntradaProdutos
                        select new EntradaProduto
                        {
                            BaseCalculoICMS = (decimal)entradaProduto.BaseCalculoIcms,
                            BaseCalculoICMSST = (decimal)entradaProduto.BaseCalculoIcmsst,
                            Cfop = entradaProduto.Cfop,
                            CodCST = entradaProduto.CodCst,
                            CodEntrada = entradaProduto.CodEntrada,
                            CodEntradaProduto = entradaProduto.CodEntradaProduto,
                            CodProduto = entradaProduto.CodProduto,
                            NomeProduto = entradaProduto.CodProdutoNavigation.Nome,
                            DataValidade = (DateTime)entradaProduto.DataValidade,
                            Desconto = (decimal)entradaProduto.Desconto,
                            PrecoCusto = (decimal)entradaProduto.PrecoCusto,
                            Quantidade = (decimal)entradaProduto.Quantidade,
                            QuantidadeDisponivel = (decimal)entradaProduto.QuantidadeDisponivel,
                            QuantidadeEmbalagem = (decimal)entradaProduto.QuantidadeEmbalagem,
                            UnidadeCompra = entradaProduto.UnidadeCompra,
                            ValorUnitario = (decimal)entradaProduto.ValorUnitario
                        };
            return query.AsNoTracking();
        }

        /// <summary>
        /// Obter uma determinada Entrada Produto
        /// </summary>
        /// <param name="codEntradaProduto"></param>
        /// <returns></returns>
        public IEnumerable<EntradaProduto> Obter(long codEntradaProduto)
        {
            return GetQuery().Where(ep => ep.CodEntradaProduto == codEntradaProduto).ToList();
        }

        /// <summary>
        /// Obter por Entrada 
        /// </summary>
        /// <param name="codEntradaProduto"></param>
        /// <returns></returns>
        public IEnumerable<EntradaProduto> ObterPorEntrada(long codEntrada)
        {
            return GetQuery().Where(ep => ep.CodEntrada == codEntrada).ToList();
        }

        /// <summary>
        /// Obter todas as Entrada Produto
        /// </summary>
        /// <param name="codEntradaProduto"></param>
        /// <returns></returns>
        public IEnumerable<EntradaProduto> Obter(long codEntrada, long codProduto)
        {
            return GetQuery().Where(ep => ep.CodEntrada == codEntrada && ep.CodProduto == codProduto).ToList();
        }

        /// <summary>
        /// Obter produtos disponíveis ordenado pela data de validade
        /// </summary>
        /// <param name="codProduto"></param>
        /// <returns></returns>
        public IEnumerable<EntradaProduto> ObterDisponiveisPorEntrada(long codProduto)
        {
            return GetQuery().Where(ep => ep.CodProduto == codProduto
                && ep.QuantidadeDisponivel > 0).OrderBy(ep => ep.CodEntradaProduto).ToList();
        }

        /// <summary>
        /// Obter produtos ordenado pela data de validade
        /// </summary>
        /// <param name="codProduto"></param>
        /// <returns></returns>
        public IEnumerable<EntradaProduto> ObterOrdenadoPorValidade(long codProduto)
        {
            return GetQuery().Where(ep => ep.CodProduto == codProduto).OrderBy(ep => ep.CodEntradaProduto).ToList();
        }

        /// <summary>
        /// Obtém os lotes que já foram vendidos ordenados pela data de validade
        /// </summary>
        /// <param name="codProduto"></param>
        /// <returns></returns>
        private List<EntradaProduto> ObterVendidosOrdenadoPorEntrada(long codProduto)
        {
            return GetQuery().Where(ep => ep.CodProduto == codProduto && ep.Quantidade > ep.QuantidadeDisponivel).
                OrderBy(ep => ep.CodEntradaProduto).ToList();
        }

        /// <summary>
        /// Obtém a data do lote de produtos disponíveis mais antigo do estoque
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        public DateTime GetDataProdutoMaisAntigoEstoque(ProdutoPesquisa produto)
        {
            List<EntradaProduto> entradaProdutos = (List<EntradaProduto>) ObterDisponiveisPorEntrada(produto.CodProduto);
            if (entradaProdutos.Count > 0)
            {
                return entradaProdutos[0].DataValidade;
            }
            return DateTime.Now;
        }

        public IEnumerable<EntradaProduto> ObterPorProdutoTipoEntrada(long codProduto, int tipoEntrada)
        {
            var query = from entradaProduto in context.TbEntradaProdutos
                        where entradaProduto.CodEntradaNavigation.CodTipoEntrada == tipoEntrada && entradaProduto.CodProduto == codProduto 
                        select new EntradaProduto
                        {
                            BaseCalculoICMS = (decimal)entradaProduto.BaseCalculoIcms,
                            BaseCalculoICMSST = (decimal)entradaProduto.BaseCalculoIcmsst,
                            Cfop = entradaProduto.Cfop,
                            CodCST = entradaProduto.CodCst,
                            CodEntrada = entradaProduto.CodEntrada,
                            CodEntradaProduto = entradaProduto.CodEntradaProduto,
                            CodProduto = entradaProduto.CodProduto,
                            DataValidade = (DateTime)entradaProduto.DataValidade,
                            Desconto = (decimal)entradaProduto.Desconto,
                            DataEntrada = (DateTime) entradaProduto.CodEntradaNavigation.DataEntrada,
                            PrecoCusto = (decimal)entradaProduto.PrecoCusto,
                            Quantidade = (decimal)entradaProduto.Quantidade,
                            QuantidadeDisponivel = (decimal)entradaProduto.QuantidadeDisponivel,
                            QuantidadeEmbalagem = (decimal)entradaProduto.QuantidadeEmbalagem,
                            UnidadeCompra = entradaProduto.UnidadeCompra,
                            ValorUnitario = (decimal)entradaProduto.ValorUnitario
                        };
            return query.ToList();
        }

        
        /// <summary>
        /// Estorna dos lotes do estoque uma determinada quantidade
        /// </summary>
        /// <param name="produto"></param>
        /// <param name="dataValidade"></param>
        /// <param name="quantidadeDevolvida"></param>
        private void EstornarItensVendidosEstoque(SaidaProduto saidaProduto)
        {
            decimal quantidadeDevolvida = Math.Abs(saidaProduto.Quantidade);
            List<EntradaProduto> entradaProdutos = ObterVendidosOrdenadoPorEntrada(saidaProduto.CodProduto);
            Decimal quantidadeRetornada = 0;

            if (entradaProdutos != null)
            {
                if (saidaProduto.TemVencimento)
                {
                    foreach (EntradaProduto entradaProduto in entradaProdutos)
                    {
                        if ((entradaProduto.DataValidade.Date.Equals(saidaProduto.DataValidade.Date)) && (quantidadeRetornada < quantidadeDevolvida))
                        {
                            if (entradaProduto.Quantidade <= (entradaProduto.QuantidadeDisponivel + (quantidadeDevolvida - quantidadeRetornada)))
                            {
                                entradaProduto.QuantidadeDisponivel += quantidadeDevolvida - quantidadeRetornada;
                                quantidadeRetornada += quantidadeDevolvida - quantidadeRetornada;
                                Atualizar(entradaProduto);
                            }
                        }
                        if (quantidadeDevolvida == quantidadeRetornada)
                            break;
                    }
                }

                // acontece quando uma data de validade não existe no estoque
                if (quantidadeRetornada < quantidadeDevolvida)
                {

                    foreach (EntradaProduto entradaProduto in entradaProdutos)
                    {
                        if (entradaProduto.Quantidade >= (entradaProduto.QuantidadeDisponivel + (quantidadeDevolvida - quantidadeRetornada)))
                        {
                            entradaProduto.QuantidadeDisponivel += quantidadeDevolvida - quantidadeRetornada;
                            quantidadeRetornada += quantidadeDevolvida - quantidadeRetornada;
                        }
                        else
                        {
                            quantidadeRetornada += entradaProduto.Quantidade - entradaProduto.QuantidadeDisponivel;
                            entradaProduto.QuantidadeDisponivel = entradaProduto.Quantidade;
                        }
                        Atualizar(entradaProduto);
                        if (quantidadeDevolvida == quantidadeRetornada)
                            break;
                    }
                }
            }
            
            // acontece quando uma data de validade não existe no estoque
            if (quantidadeRetornada < quantidadeDevolvida)
            {
                BaixarItensVendidosEstoqueEntradaPadrao(saidaProduto, ((-1) * (quantidadeDevolvida-quantidadeRetornada)));
            }
        }
        
        /// <summary>
        /// Baixa dos lotes do estoque uma determinada quantidade vendida
        /// </summary>
        /// <param name="produto"></param>
        /// <param name="dataValidade"></param>
        /// <param name="quantidadeVendida"></param>
        /// <returns></returns>
        public Decimal BaixarItensVendidosEstoque(SaidaProduto saidaProduto) {
            List<EntradaProduto> entradaProdutos = (List<EntradaProduto>)ObterDisponiveisPorEntrada(saidaProduto.CodProduto);

            decimal somaPrecosCusto = 0;
            decimal quantidadeBaixas = 0;

            if (saidaProduto.Quantidade < 0)
            {
                EstornarItensVendidosEstoque(saidaProduto);
            } 
            else if (entradaProdutos.Count > 0)
            {
                // reduz a quantidade de itens disponíveis nos lotes de entrada
                foreach (EntradaProduto entradaProduto in entradaProdutos)
                {
                    if (saidaProduto.Quantidade == quantidadeBaixas)
                        break;
                    if (saidaProduto.TemVencimento)
                    {
                        // quando produto tem vencimento
                        if ((entradaProduto.DataValidade.Date.Equals(saidaProduto.DataValidade.Date)) && (quantidadeBaixas < saidaProduto.Quantidade))
                        {
                            if (entradaProduto.QuantidadeDisponivel >= (saidaProduto.Quantidade - quantidadeBaixas))
                            {
                                entradaProduto.QuantidadeDisponivel -= saidaProduto.Quantidade - quantidadeBaixas;
                                somaPrecosCusto += (saidaProduto.Quantidade - quantidadeBaixas) * entradaProduto.PrecoCusto;
                                quantidadeBaixas += (saidaProduto.Quantidade - quantidadeBaixas);
                            }
                        }
                    }
                    else
                    {
                        if (quantidadeBaixas < saidaProduto.Quantidade)
                        {
                            if (entradaProduto.QuantidadeDisponivel >= (saidaProduto.Quantidade - quantidadeBaixas))
                            {
                                entradaProduto.QuantidadeDisponivel -= saidaProduto.Quantidade - quantidadeBaixas;
                                somaPrecosCusto += (saidaProduto.Quantidade - quantidadeBaixas) * entradaProduto.PrecoCusto;
                                quantidadeBaixas += (saidaProduto.Quantidade - quantidadeBaixas);
                            }
                            else
                            {
                                quantidadeBaixas += entradaProduto.QuantidadeDisponivel;
                                somaPrecosCusto += entradaProduto.QuantidadeDisponivel * entradaProduto.PrecoCusto;
                                entradaProduto.QuantidadeDisponivel = 0;
                            }
                        }
                    }
                    Atualizar(entradaProduto);
                }
            }

            if (quantidadeBaixas < saidaProduto.Quantidade)
            {
                somaPrecosCusto += BaixarItensVendidosEstoqueEntradaPadrao(saidaProduto, (saidaProduto.Quantidade - quantidadeBaixas));
            }
            return somaPrecosCusto;
        }

        /// <summary>
        /// Baixar uma certa quantidade de produtos da entrada padrão que contém todos os produtos sem entradas associadas
        /// </summary>
        /// <param name="produtoPesquisa"></param>
        /// <param name="quantidade"></param>
        /// <returns></returns>
        private decimal BaixarItensVendidosEstoqueEntradaPadrao(SaidaProduto saidaProduto, decimal quantidade) {
            List<EntradaProduto> entradaProdutos = (List<EntradaProduto>)Obter(UtilConfig.Default.ENTRADA_PADRAO, saidaProduto.CodProduto);
            Produto produto = gerenciadorProduto.Obter(new ProdutoPesquisa() { CodProduto = saidaProduto.CodProduto });
            EntradaProduto entradaProduto = null;
            if (entradaProdutos.Count > 0)
            {
                entradaProduto = entradaProdutos[0];
            }

            if (entradaProduto != null)
            {
                entradaProduto.QuantidadeDisponivel -= quantidade;
                Atualizar(entradaProduto);
            }
            else
            {
                entradaProduto = new EntradaProduto();
                entradaProduto.CodEntrada = UtilConfig.Default.ENTRADA_PADRAO;
                entradaProduto.CodProduto = produto.CodProduto; 

                entradaProduto.UnidadeCompra = produto.Unidade;
                entradaProduto.Quantidade = 10000;
                entradaProduto.QuantidadeEmbalagem = produto.QuantidadeEmbalagem == 0 ? 1 : produto.QuantidadeEmbalagem;
                entradaProduto.QuantidadeDisponivel = (entradaProduto.Quantidade * entradaProduto.QuantidadeEmbalagem) - quantidade; 
                entradaProduto.ValorUnitario = produto.UltimoPrecoCompra;
                //entradaProduto.ValorTotal = 0;
                entradaProduto.BaseCalculoICMS = 0;
                entradaProduto.BaseCalculoICMSST = 0;
                entradaProduto.DataValidade = DateTime.Now;
                // para não perder os dados do produto
                entradaProduto.LucroPrecoVendaAtacado = produto.LucroPrecoVendaAtacado;
                entradaProduto.LucroPrecoVendaVarejo = produto.LucroPrecoVendaVarejo;
                entradaProduto.PrecoVendaAtacado = produto.PrecoVendaAtacado;
                entradaProduto.PrecoVendaVarejo = produto.PrecoVendaVarejo;
                entradaProduto.Frete = produto.Frete;
                entradaProduto.Icms = 7;
                entradaProduto.IcmsSubstituto = 20;
                entradaProduto.Ipi = produto.Ipi;
                entradaProduto.Ncmsh = produto.Ncmsh;
                entradaProduto.QtdProdutoAtacado = produto.QtdProdutoAtacado;
                entradaProduto.DataEntrada = (DateTime)produto.DataUltimoPedido;
                entradaProduto.Desconto = produto.Desconto;
                entradaProduto.PrecoCusto = produto.PrecoCusto; 
                entradaProduto.ValorDesconto = 0;
                entradaProduto.CodCST = produto.CodCST;
                entradaProduto.Cfop = 9999;

                Inserir(entradaProduto, Entrada.TIPO_ENTRADA);
            }
            
            return 0;
        }

        /// <summary>
        /// Atribuição de entradaproduto para atualizar dados de produto
        /// </summary>
        /// <param name="entradaProduto"></param>
        /// <param name="produto"></param>
        public void Atribuir(EntradaProduto entradaProduto, Produto produto)
        {
            produto.LucroPrecoVendaAtacado = entradaProduto.LucroPrecoVendaAtacado;
            produto.LucroPrecoVendaVarejo = entradaProduto.LucroPrecoVendaVarejo;
            produto.PrecoVendaAtacado = entradaProduto.PrecoVendaAtacado;
            produto.PrecoVendaVarejo = entradaProduto.PrecoVendaVarejo;
            produto.Frete = entradaProduto.Frete;
            produto.Icms = entradaProduto.Icms;
            produto.IcmsSubstituto = entradaProduto.IcmsSubstituto;
            produto.Ipi = entradaProduto.Ipi;
            produto.Ncmsh = entradaProduto.Ncmsh;
            produto.QtdProdutoAtacado = entradaProduto.QtdProdutoAtacado;
            produto.UltimaDataAtualizacao = DateTime.Now;
            produto.DataUltimoPedido = entradaProduto.DataEntrada;
            produto.UltimoPrecoCompra = entradaProduto.ValorUnitario;
            produto.CodCST = entradaProduto.CodCST;
            produto.Desconto = entradaProduto.Desconto;
            produto.QuantidadeEmbalagem = entradaProduto.QuantidadeEmbalagem;
            produto.UnidadeCompra = entradaProduto.UnidadeCompra;
            produto.PrecoRevenda = entradaProduto.PrecoRevenda;
            produto.UltimoPrecoCompra = entradaProduto.ValorUnitario;
            produto.LucroPrecoRevenda = entradaProduto.LucroPrecoRevenda;
            if (!string.IsNullOrEmpty(entradaProduto.CodigoBarra) && string.IsNullOrEmpty(produto.CodigoBarra))
            {
                produto.CodigoBarra = entradaProduto.CodigoBarra;
            }

            if (entradaProduto.FornecedorEhFabricante)
            {
                produto.CodFabricante = entradaProduto.CodFornecedor;
                produto.NomeProdutoFabricante = entradaProduto.NomeProduto;
                produto.ReferenciaFabricante = entradaProduto.ReferenciaFabricante;
            }
        }

        /// <summary>
        /// Atribui a entidade para entidade persistente
        /// </summary>
        /// <param name="entradaProduto"></param>
        /// <param name="_entradaProduto"></param>
        private static void Atribuir(EntradaProduto entradaProduto, TbEntradaProduto _entradaProduto)
        {
            _entradaProduto.BaseCalculoIcms = entradaProduto.BaseCalculoICMS;
            _entradaProduto.BaseCalculoIcmsst = entradaProduto.BaseCalculoICMSST;
            _entradaProduto.Cfop = entradaProduto.Cfop;
            _entradaProduto.CodCst = entradaProduto.CodCST;
            _entradaProduto.CodEntrada = entradaProduto.CodEntrada;
            _entradaProduto.CodEntradaProduto = entradaProduto.CodEntradaProduto;
            _entradaProduto.CodProduto = entradaProduto.CodProduto;
            _entradaProduto.DataValidade = entradaProduto.DataValidade;
            _entradaProduto.Desconto = entradaProduto.Desconto;
            _entradaProduto.PrecoCusto = entradaProduto.PrecoCusto;
            _entradaProduto.Quantidade = entradaProduto.Quantidade;
            _entradaProduto.QuantidadeEmbalagem = entradaProduto.QuantidadeEmbalagem == 0 ? 1 : entradaProduto.QuantidadeEmbalagem;
            _entradaProduto.QuantidadeDisponivel = entradaProduto.QuantidadeDisponivel;
            _entradaProduto.UnidadeCompra = entradaProduto.UnidadeCompra;
            _entradaProduto.ValorIcms = entradaProduto.ValorICMS;
            _entradaProduto.ValorIcmsst = entradaProduto.ValorICMSST;
            _entradaProduto.ValorIpi = entradaProduto.ValorIPI;
            _entradaProduto.ValorTotal = entradaProduto.ValorTotal;
            _entradaProduto.ValorUnitario = entradaProduto.ValorUnitario;
        }


    }
}