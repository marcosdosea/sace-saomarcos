using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Util;

namespace Negocio
{
    public class GerenciadorProduto
    {

        private readonly SaceContext context;

        public GerenciadorProduto(SaceContext saceContext)
        {
            context = saceContext;
        }

        /// <summary>
        /// Insere um novo produto na base de dados
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        public long Inserir(Produto produto)
        {
            try
            {
                if (produto.Nome.Trim().Equals(""))
                    throw new NegocioException("O nome do produto não pode ficar em branco.");
                else if (produto.QuantidadeEmbalagem <= 0)
                    throw new NegocioException("A quantidade de produtos na embalagem deve ser maior que zero.");
                else if (!produto.CodigoBarra.Trim().Equals("") && !produto.CodigoBarra.Trim().Equals("SEM GTIN"))
                {
                    if (ObterPorCodigoBarraExato(produto.CodigoBarra).Count() > 0)
                    {
                        throw new NegocioException("Já existe um produto cadastrado com esse código de barra. Favor verificar a possibilidade de ser o mesmo produto.");
                    }
                }

                var _produto = new TbProduto();
                Atribuir(produto, _produto);

                var transaction = context.Database.BeginTransaction();
                context.Add(_produto);
                context.SaveChanges();

                var produtoLoja = new TbProdutoLoja();
                produtoLoja.CodProduto = _produto.CodProduto;
                produtoLoja.CodLoja = UtilConfig.Default.LOJA_PADRAO;
                produtoLoja.QtdEstoque = 0;
                produtoLoja.QtdEstoqueAux = 0;

                context.Add(produtoLoja);
                context.SaveChanges();

                transaction.Commit();

                return _produto.CodProduto;
            }
            catch (Exception e)
            {
                throw new DadosException("Produto", e.Message, e);
            }
        }

        /// <summary>
        /// Insere um novo produto a partir dos dados de entrada
        /// </summary>
        /// <param name="entradaProduto"></param>
        /// <returns></returns>
        public long Inserir(EntradaProduto entradaProduto)
        {
            Produto produto = new Produto();
            produto.CodCST = entradaProduto.CodCST;
            produto.CodFabricante = entradaProduto.FornecedorEhFabricante ? entradaProduto.CodFornecedor : 1;
            produto.CodGrupo = 1;
            produto.CodigoBarra = entradaProduto.CodigoBarra;
            produto.CodSituacaoProduto = SituacaoProduto.DISPONIVEL;
            produto.CodSubgrupo = 1;
            produto.Desconto = entradaProduto.Desconto;
            produto.ExibeNaListagem = true;
            produto.Frete = entradaProduto.Frete;
            produto.Icms = entradaProduto.Icms;
            produto.IcmsSubstituto = entradaProduto.IcmsSubstituto;
            produto.Ipi = entradaProduto.Ipi;
            produto.LucroPrecoRevenda = entradaProduto.LucroPrecoRevenda;
            produto.LucroPrecoVendaAtacado = entradaProduto.LucroPrecoVendaAtacado;
            produto.LucroPrecoVendaVarejo = entradaProduto.LucroPrecoVendaVarejo;
            produto.Ncmsh = entradaProduto.Ncmsh;
            produto.Nome = entradaProduto.NomeProduto;
            produto.NomeProdutoFabricante = entradaProduto.NomeProduto;
            produto.PrecoRevenda = entradaProduto.PrecoRevenda;
            produto.PrecoVendaAtacado = entradaProduto.PrecoVendaAtacado;
            produto.PrecoVendaVarejo = entradaProduto.PrecoVendaVarejo;
            produto.QtdProdutoAtacado = entradaProduto.QtdProdutoAtacado;
            produto.QuantidadeEmbalagem = entradaProduto.QuantidadeEmbalagem;
            produto.ReferenciaFabricante = entradaProduto.ReferenciaFabricante;
            produto.Simples = entradaProduto.Simples;
            produto.UnidadeCompra = entradaProduto.UnidadeCompra;
            produto.Unidade = entradaProduto.UnidadeCompra;
            produto.DataUltimaMudancaPreco = DateTime.Now;
            produto.UltimaDataAtualizacao = DateTime.Now;
            return Inserir(produto);
        }

        /// <summary>
        /// Atualiza os dados do produto
        /// </summary>
        /// <param name="produto"></param>
        public void Atualizar(Produto produto)
        {
            if (produto.CodProduto == 1)
                throw new NegocioException("Esse produto não pode ser alterado ou removido.");
            else if (produto.Nome.Trim().Equals(""))
                throw new NegocioException("O nome do produto não pode ficar em branco.");
            else if (produto.QuantidadeEmbalagem <= 0)
                throw new NegocioException("A quantidade de produtos na embalagem deve ser maior que zero.");
            else if (!produto.CodigoBarra.Trim().Equals("") && !produto.CodigoBarra.Trim().Equals("SEM GTIN"))
            {
                ProdutoPesquisa produtoPesquisa = ObterPorCodigoBarraExato(produto.CodigoBarra).ElementAtOrDefault(0);
                if ((produtoPesquisa != null) && (produtoPesquisa.CodProduto != produto.CodProduto))
                {
                    throw new NegocioException("Já existe um produto cadastrado com esse código de barra. Favor verificar a possibilidade de ser o mesmo produto.");
                }
            }

            try
            {
                var query = from produtoSet in context.TbProdutos
                            where produtoSet.CodProduto == produto.CodProduto
                            select produtoSet;
                foreach (TbProduto _produto in query)
                {
                    // Atualiza data da ultima atualizacao
                    if ((produto.PrecoVendaVarejo != _produto.PrecoVendaVarejo) || (produto.PrecoVendaAtacado != _produto.PrecoVendaAtacado)
                        || (produto.PrecoRevenda != _produto.PrecoRevenda))
                    {
                        produto.UltimaDataAtualizacao = DateTime.Now;
                        produto.DataUltimaMudancaPreco = DateTime.Now;
                    }

                    // Atualiza data para mudança da pasta e das etiquetas
                    if (produto.PrecoVendaVarejo != _produto.PrecoVendaVarejo)
                    {
                        produto.DataUltimaMudancaPreco = DateTime.Now;
                    }

                    Atribuir(produto, _produto);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Produto", e.Message, e);
            }
        }

        /// <summary>
        /// Atualiza o código de barra do produto
        /// </summary>
        /// <param name="_produtoPesquisa"></param>
        /// <param name="ultimoCodigoBarraLido"></param>
        public void AtualizarCodigoBarra(ProdutoPesquisa _produtoPesquisa, string ultimoCodigoBarraLido)
        {
            try
            {
                var query = from produtoSet in context.TbProdutos
                            where produtoSet.CodProduto == _produtoPesquisa.CodProduto
                            select produtoSet;
                foreach (TbProduto _produto in query)
                {
                    _produto.CodigoBarra = ultimoCodigoBarraLido;
                    context.Update(_produto);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Produto", e.Message, e);
            }
        }

        /// <summary>
        /// Substituir todas as referências de um produto por outro
        /// </summary>
        /// <param name="codProdutoExcluir"></param>
        /// <param name="codProdutoManter"></param>
        public void SubstituirProduto(long codProdutoExcluir, long codProdutoManter)
        {
            try
            {
                var transaction = context.Database.BeginTransaction();
                // substitui todas as saídas
                var querySaidas = from saidaProduto in context.TbSaidaProdutos
                                  where saidaProduto.CodProduto == codProdutoExcluir
                                  select saidaProduto;
                foreach (TbSaidaProduto _saidaProduto in querySaidas)
                {
                    _saidaProduto.CodProduto = codProdutoManter;
                    context.Update(_saidaProduto);
                    context.SaveChanges();
                }

                // Substituti todas as entradas
                var queryEntrada = from entradaProduto in context.TbEntradaProdutos
                                   where entradaProduto.CodProduto == codProdutoExcluir
                                   select entradaProduto;
                foreach (TbEntradaProduto _entradaProduto in queryEntrada)
                {
                    _entradaProduto.CodProduto = codProdutoManter;
                    context.Update(_entradaProduto);
                    context.SaveChanges();
                }


                // Substituti todas as pontas de estoque
                var queryPontaEstoque = from pontaEstoque in context.TbPontaEstoques
                                        where pontaEstoque.CodProduto == codProdutoExcluir
                                        select pontaEstoque;
                foreach (TbPontaEstoque _pontaEstoque in queryPontaEstoque)
                {
                    _pontaEstoque.CodProduto = codProdutoManter;
                    context.Update(_pontaEstoque);
                    context.SaveChanges();
                }

                var _produto = new TbProduto();
                _produto.CodProduto = codProdutoExcluir;

                context.Remove(_produto);
                context.SaveChanges();
                transaction.Commit();
            }
            catch (Exception e)
            {
                throw new DadosException("Produto", e.Message, e);
            }
        }

        /// <summary>
        /// Atualizar situação do produto em relação ao estoque
        /// </summary>
        /// <param name="novaSituacao"></param>
        public void AtualizarSituacaoProduto(SolicitacoesCompra solicitacaoCompra, string nomeServidor)
        {
            try
            {
                var query = from produtoSet in context.TbProdutos
                            where produtoSet.CodProduto == solicitacaoCompra.CodProduto
                            select produtoSet;
                DirectoryInfo pastaProdutosAtualizados = new DirectoryInfo(UtilConfig.Default.PASTA_COMUNICACAO_PRODUTOS_ATUALIZADOS);
                foreach (TbProduto _produto in query)
                {
                    _produto.CodSituacaoProduto = solicitacaoCompra.CodSituacaoProduto;
                    _produto.DataSolicitacaoCompra = solicitacaoCompra.DataSolicitacaoCompra;
                    _produto.DataPedidoCompra = solicitacaoCompra.DataPedidoCompra;
                    var nomeComputador = SystemInformation.ComputerName.ToUpper();
                    if (pastaProdutosAtualizados.Exists && !nomeComputador.Equals(nomeServidor.ToUpper()))
                    {
                        string nomeArquivo = UtilConfig.Default.PASTA_COMUNICACAO_PRODUTOS_ATUALIZADOS + solicitacaoCompra.CodProduto + ".txt";
                        StreamWriter arquivo = new StreamWriter(nomeArquivo, false, Encoding.ASCII);
                        arquivo.WriteLine("[CodProduto]" + solicitacaoCompra.CodProduto);
                        arquivo.WriteLine("[CodSituacaoProduto]" + solicitacaoCompra.CodSituacaoProduto);
                        arquivo.WriteLine("[DataSolicitacaoCompra]" + solicitacaoCompra.DataSolicitacaoCompra);
                        arquivo.WriteLine("[DataPedidoCompra]" + solicitacaoCompra.DataPedidoCompra);
                        arquivo.Close();
                    }
                    context.Update(_produto);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Produto", e.Message, e);
            }

        }

        /// <summary>
        /// Solicita atualização da situação de produtos no servidor
        /// </summary>
        /// <param name="nomeServidor"></param>
        public void AtualizarSituacaoProdutoServidor(string nomeServidor)
        {
            DirectoryInfo Dir = new DirectoryInfo(UtilConfig.Default.PASTA_COMUNICACAO_PRODUTOS_ATUALIZADOS);
            if (Dir.Exists)
            {
                // Busca automaticamente todos os arquivos em todos os subdiretórios
                string arquivosProduto = "*.txt";
                FileInfo[] files = Dir.GetFiles(arquivosProduto, SearchOption.TopDirectoryOnly);
                foreach (FileInfo file in files)
                {
                    try
                    {
                        string linha = null;
                        StreamReader reader = new StreamReader(file.FullName);
                        SolicitacoesCompra solicitacaoCompra = new SolicitacoesCompra();
                        while ((linha = reader.ReadLine()) != null)
                        {
                            if (linha.StartsWith("[CodProduto]"))
                                solicitacaoCompra.CodProduto = Convert.ToInt32(linha.Substring("[CodProduto]".Length));
                            else if (linha.StartsWith("[CodSituacaoProduto]"))
                                solicitacaoCompra.CodSituacaoProduto = Convert.ToSByte(linha.Substring("[CodSituacaoProduto]".Length));
                            else if (linha.StartsWith("[DataSolicitacaoCompra]"))
                                solicitacaoCompra.DataSolicitacaoCompra = Convert.ToDateTime(linha.Substring("[DataSolicitacaoCompra]".Length));
                            else if (linha.StartsWith("[DataPedidoCompra]"))
                                solicitacaoCompra.DataPedidoCompra = Convert.ToDateTime(linha.Substring("[DataPedidoCompra]".Length));
                        }
                        AtualizarSituacaoProduto(solicitacaoCompra, nomeServidor);
                        reader.Close();
                        file.Delete();
                    }
                    catch (Exception)
                    {
                        // não atualiza produto no servidor
                    }
                }
            }

        }


        /// <summary>
        /// Atualiza ncm e quantidade Atacado
        /// </summary>
        /// <param name="_produtoPesquisa"></param>
        /// <param name="ultimoCodigoBarraLido"></param>
        public void AtualizarNcmshQtdAtacado(long codProduto, string nomeProduto, string ncsmsh, string codigoEAN)
        {
            try
            {
                var query = from produtoSet in context.TbProdutos
                            where produtoSet.CodProduto == codProduto
                            select produtoSet;
                foreach (TbProduto _produto in query)
                {
                    _produto.Ncmsh = ncsmsh;
                    _produto.Nome = nomeProduto;
                    _produto.CodigoBarra = codigoEAN;
                    context.Update(_produto);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Produto", e.Message, e);
            }
        }

        /// <summary>
        /// Atualiza preços do produto
        /// </summary>
        /// <param name="codProduto"></param>
        /// <param name="nomeProduto"></param>
        /// <param name="precoVarejo"></param>
        /// <param name="precoAtacado"></param>
        public void AtualizarPrecoVarejoAtacado(long codProduto, string nomeProduto, decimal precoVarejo, decimal precoAtacado, decimal precoRevenda)
        {
            try
            {
                var query = from produtoSet in context.TbProdutos
                            where produtoSet.CodProduto == codProduto
                            select produtoSet;
                foreach (TbProduto _produto in query)
                {
                    _produto.Nome = nomeProduto;
                    if (_produto.PrecoVendaVarejo != precoVarejo || _produto.PrecoVendaAtacado != precoAtacado)
                    {
                        _produto.PrecoVendaVarejo = precoVarejo;
                        _produto.PrecoVendaAtacado = precoAtacado;
                        _produto.PrecoRevenda = precoRevenda;
                        _produto.DataUltimaMudancaPreco = DateTime.Now;
                        _produto.UltimaDataAtualizacao = DateTime.Now;
                    }
                    context.Update(_produto);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new DadosException("Produto", e.Message, e);
            }
        }


        /// <summary>
        /// Remove produto da base de dados
        /// </summary>
        /// <param name="codproduto"></param>
        public void Remover(long codproduto)
        {
            if (codproduto == 1)
                throw new NegocioException("Esse produto não pode ser alterado ou removido.");
            try
            {
                var produto = new TbProduto();
                produto.CodProduto = codproduto;

                context.Remove(produto);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Produto", e.Message, e);
            }
        }

        /// <summary>
        /// Consulta para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<Produto> GetQuery()
        {
            var query = from produto in context.TbProdutos
                        orderby produto.Nome
                        select new Produto
                        {
                            CodCST = produto.CodCst,
                            CodFabricante = produto.CodFabricante,
                            NomeFabricante = produto.CodFabricanteNavigation.NomeFantasia,
                            CodGrupo = produto.CodGrupo,
                            CodigoBarra = produto.CodigoBarra,
                            CodProduto = produto.CodProduto,
                            CodSituacaoProduto = produto.CodSituacaoProduto,
                            CodSubgrupo = produto.CodSubgrupo,
                            DataUltimoPedido = produto.DataUltimoPedido,
                            Desconto = (decimal) produto.Desconto,
                            ExibeNaListagem = (bool) produto.ExibeNaListagem,
                            Frete = (decimal)produto.Frete,
                            Icms = (decimal)produto.Icms,
                            IcmsSubstituto = (decimal)produto.IcmsSubstituto,
                            Ipi = (decimal)produto.Ipi,
                            LucroPrecoVendaAtacado = (decimal)produto.LucroPrecoVendaAtacado,
                            LucroPrecoVendaVarejo =  (decimal)produto.LucroPrecoVendaVarejo,
                            LucroPrecoRevenda = (decimal)produto.LucroPrecoRevenda,
                            Ncmsh = produto.Ncmsh,
                            Nome = produto.Nome,
                            NomeProdutoFabricante = produto.NomeProdutoFabricante,
                            PrecoVendaAtacado = (decimal)produto.PrecoVendaAtacado,
                            PrecoVendaVarejo = (decimal)produto.PrecoVendaVarejo,
                            PrecoRevenda = (decimal)produto.PrecoRevenda,
                            QtdProdutoAtacado = (decimal)produto.QtdProdutoAtacado,
                            QuantidadeEmbalagem = (decimal)produto.QuantidadeEmbalagem,
                            ReferenciaFabricante = produto.ReferenciaFabricante,
                            Simples = (decimal)produto.Simples,
                            TemVencimento = produto.TemVencimento,
                            EmPromocao = produto.EmPromocao,
                            Unidade = produto.Unidade,
                            UnidadeCompra = produto.UnidadeCompra,
                            UltimoPrecoCompra = (decimal)produto.UltimoPrecoCompra,
                            UltimaDataAtualizacao = produto.UltimaDataAtualizacao,
                            DataUltimaMudancaPreco = produto.DataUltimaMudancaPreco
                        };
            return query.AsNoTracking();
        }

        /// <summary>
        /// Consulta simples para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<ProdutoPesquisa> GetQuerySimples()
        {
            var query = from produto in context.TbProdutos
                        orderby produto.Nome
                        select new ProdutoPesquisa
                        {
                            CodCST = produto.CodCst,
                            CodigoBarra = produto.CodigoBarra,
                            CodProduto = produto.CodProduto,
                            Desconto = (decimal)produto.Desconto,
                            ExibeNaListagem = (bool)produto.ExibeNaListagem,
                            Frete = (decimal)produto.Frete,
                            Icms = (decimal)produto.Icms,
                            IcmsSubstituto = (decimal)produto.IcmsSubstituto,
                            Ipi = (decimal)produto.Ipi,
                            LucroPrecoVendaAtacado = (decimal)produto.LucroPrecoVendaAtacado,
                            LucroPrecoVendaVarejo = (decimal)produto.LucroPrecoVendaVarejo,
                            LucroPrecoRevenda = (decimal)produto.LucroPrecoRevenda,
                            Ncmsh = produto.Ncmsh,
                            Nome = produto.Nome,
                            CodFabricante = produto.CodFabricante,
                            NomeProdutoFabricante = produto.NomeProdutoFabricante,
                            PrecoVendaAtacado = (decimal)produto.PrecoVendaAtacado,
                            PrecoVendaVarejo = (decimal)produto.PrecoVendaVarejo,
                            PrecoRevenda = (decimal)produto.PrecoRevenda,
                            QtdProdutoAtacado = (decimal)produto.QtdProdutoAtacado,
                            QuantidadeEmbalagem = (decimal)produto.QuantidadeEmbalagem,
                            ReferenciaFabricante = produto.ReferenciaFabricante,
                            Simples = (decimal)produto.Simples,
                            UltimaDataAtualizacao = produto.UltimaDataAtualizacao,
                            Unidade = produto.Unidade,
                            TemVencimento = produto.TemVencimento,
                            EmPromocao = produto.EmPromocao,
                            UltimoPrecoCompra = (decimal)produto.UltimoPrecoCompra,
                            UnidadeCompra = produto.UnidadeCompra,
                            CodSituacaoProduto = produto.CodSituacaoProduto,
                            DataUltimaMudancaPreco = produto.DataUltimaMudancaPreco
                        };
            return query.AsNoTracking();
        }


        /// <summary>
        /// Obter todos os produtos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Produto> ObterTodos()
        {
            return GetQuery().ToList();
        }

        /// <summary>
        /// Obtém produto que podem ser exibidos na listagem
        /// </summary>
        /// <param name="codBarra"></param>
        /// <returns></returns>
        public IEnumerable<ProdutoPesquisa> ObterTodosExibiveis()
        {

            return GetQuerySimples().Where(p => p.ExibeNaListagem == true).ToList();
        }

        public IEnumerable<ProdutoNome> ObterTodosNomesExibiveis()
        {
            var query = from produto in context.TbProdutos
                        where produto.ExibeNaListagem == true
                        orderby produto.Nome
                        select new ProdutoNome
                        {
                            CodProduto = produto.CodProduto,
                            Nome = produto.Nome
                        };
            return query.AsNoTracking().ToList();
        }

        /// <summary>
        /// Obter todos os produtos ordenados pelo nome
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProdutoNome> ObterTodosNomes()
        {
            var query = from produto in context.TbProdutos
                        orderby produto.Nome
                        select new ProdutoNome
                        {
                            CodProduto = produto.CodProduto,
                            Nome = produto.Nome
                        };
            return query.AsNoTracking().ToList();
        }

        /// <summary>
        /// Obter um produto usando um produto pesquisado
        /// </summary>
        /// <param name="produtoPesquisa"></param>
        /// <returns></returns>
        public Produto Obter(ProdutoPesquisa produtoPesquisa)
        {
            return GetQuery().Where(p => p.CodProduto == produtoPesquisa.CodProduto).First();
        }

        /// <summary>
        /// Obter pelo código do produto
        /// </summary>
        /// <param name="codProduto"></param>
        /// <returns></returns>
        public IEnumerable<ProdutoPesquisa> Obter(long codProduto)
        {
            return GetQuerySimples().Where(p => p.CodProduto == codProduto).ToList();
        }

        /// <summary>
        /// Obter pela referência do fabricante
        /// </summary>
        /// <param name="codProduto"></param>
        /// <returns></returns>
        public IEnumerable<ProdutoPesquisa> ObterPorReferenciaFabricante(string referenciaFabricante)
        {
            return GetQuerySimples().Where(p => p.ReferenciaFabricante.StartsWith(referenciaFabricante)).ToList();
        }


        /// <summary>
        /// Obter pela código de barra do produto
        /// </summary>
        /// <param name="codProduto"></param>
        /// <returns></returns>
        public IEnumerable<ProdutoPesquisa> ObterPorCodigoBarra(string codigoBarra)
        {
            return GetQuerySimples().Where(p => p.CodigoBarra.StartsWith(codigoBarra)).ToList();
        }

        /// <summary>
        /// Obter por Ncmsh
        /// </summary>
        /// <param name="Ncmsh"></param>
        /// <returns></returns>
        public IEnumerable<ProdutoPesquisa> ObterPorNcmsh(string ncmsh)
        {
            return GetQuerySimples().Where(p => p.Ncmsh.StartsWith(ncmsh)).ToList();
        }

        /// <summary>
        /// Obtém produto pelo código de barra
        /// </summary>
        /// <param name="codBarra"></param>
        /// <returns></returns>
        public IEnumerable<ProdutoPesquisa> ObterPorCodigoBarraExato(String codBarra)
        {
            return GetQuerySimples().Where(p => p.CodigoBarra.Equals(codBarra)).ToList();
        }

        /// <summary>
        /// Obtém produto pelo nome
        /// </summary>
        /// <param name="codBarra"></param>
        /// <returns></returns>
        public IEnumerable<ProdutoPesquisa> ObterPorNomeProdutoFabricante(String nomeProdutoFabricante)
        {
            return GetQuerySimples().Where(p => p.NomeProdutoFabricante.StartsWith(nomeProdutoFabricante)).ToList();
        }

        /// <summary>
        /// Retorna todos os produtos de um determinado fabricante
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        public IEnumerable<ProdutoPesquisa> ObterPorCodigoFabricante(long codPessoa)
        {
            return GetQuerySimples().Where(p => p.CodFabricante.Equals(codPessoa)).ToList();
        }

        /// <summary>
        /// Obtém produto pela data de atualização
        /// </summary>
        /// <param name="codBarra"></param>
        /// <returns></returns>
        public IEnumerable<ProdutoPesquisa> ObterPorDataAtualizacaoMaiorIgual(DateTime dataAtualizacao)
        {
            return GetQuerySimples().Where(p => p.UltimaDataAtualizacao >= dataAtualizacao).ToList();
        }

        public IEnumerable<ProdutoPesquisa> ObterPorDataMudancaPrecoMaiorIgual(DateTime dataMudancaPreco)
        {
            return GetQuerySimples().Where(p => p.DataUltimaMudancaPreco >= dataMudancaPreco).ToList();
        }

        /// <summary>
        /// Obtém produto pelo nome usand pesquisa com caracteres
        /// </summary>
        /// <param name="codBarra"></param>
        /// <returns></returns>
        public IEnumerable<ProdutoPesquisa> ObterPorNome(string nome)
        {
            var query = GetQuerySimples();
            if ((nome.Length > 0) && (nome[0] == '%'))
            {
                return query.Where(p => p.Nome.Contains(nome.Remove(0, 1))).ToList();
            }
            else
            {
                return query.Where(p => p.Nome.StartsWith(nome)).ToList();
            }
        }


        /// <summary>
        /// Obter solicitações de compras de produtos
        /// </summary>
        /// <param name="codBarra"></param>
        /// <returns></returns>
        public IEnumerable<SolicitacoesCompra> ObterSolicitacoesCompra(List<int> listaCodSituacoes, long codFornecedor)
        {
            if (codFornecedor == 1)
            {
                var query = from produto in context.TbProdutos
                            orderby produto.Nome
                            where listaCodSituacoes.Contains(produto.CodSituacaoProduto)
                            select new SolicitacoesCompra
                            {
                                CodProduto = produto.CodProduto,
                                Nome = produto.Nome,
                                ReferenciaFabricante = produto.ReferenciaFabricante,
                                Unidade = produto.Unidade,
                                CodSituacaoProduto = produto.CodSituacaoProduto,
                                DataSolicitacaoCompra = produto.DataSolicitacaoCompra,
                                DataPedidoCompra = produto.DataPedidoCompra
                            };
                return query.AsNoTracking().ToList();
            }
            else
            {
                var queryProdutosFornecedor = context.TbEntradaProdutos.Where(e => e.CodEntradaNavigation.CodFornecedor == codFornecedor);
                List<long> listaCodigoProdutosFornecedor = queryProdutosFornecedor.Select(p => p.CodProduto).Distinct().ToList();

                var query = from produto in context.TbProdutos
                            orderby produto.Nome
                            where listaCodSituacoes.Contains(produto.CodSituacaoProduto) &&
                                (listaCodigoProdutosFornecedor.Contains(produto.CodProduto) || produto.CodFabricante.Equals(codFornecedor))
                            select new SolicitacoesCompra
                            {
                                CodProduto = produto.CodProduto,
                                Nome = produto.Nome,
                                ReferenciaFabricante = produto.ReferenciaFabricante,
                                Unidade = produto.Unidade,
                                CodSituacaoProduto = produto.CodSituacaoProduto,
                                DataSolicitacaoCompra = produto.DataSolicitacaoCompra,
                                DataPedidoCompra = produto.DataPedidoCompra
                            };
                return query.ToList();
            }
        }


        /// <summary>
        /// Obtém produto que podem ser exibidos na lista pelo nome 
        /// </summary>
        /// <param name="codBarra"></param>
        /// <returns></returns>
        public IEnumerable<ProdutoPesquisa> ObterPorNomeExibiveis(string nome)
        {
            if ((nome.Length > 0) && (nome[0] == '%'))
            {
                return GetQuerySimples().Where(p => p.Nome.Contains(nome.Remove(0, 1)) && p.ExibeNaListagem).ToList();
            }
            else
            {
                return GetQuerySimples().Where(p => p.Nome.StartsWith(nome) && p.ExibeNaListagem).ToList();
            }
        }

        /// <summary>
        /// Obter todas as situações de produtos cadastradas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SituacaoProduto> ObterSituacoesProduto()
        {
            var query = from situacaoProduto in context.TbSituacaoProdutos
                        select new SituacaoProduto
                        {
                            CodSituacaoProduto = situacaoProduto.CodSituacaoProduto,
                            DescricaoSituacao = situacaoProduto.DescricaoSituacao
                        };
            return query.ToList();
        }

        /// <summary>
        /// Obtém lista de produtos com códigos de barra inválidos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProdutoPesquisa> ObterPorCodigosBarraInvalidos()
        {
            var listaProdutos = GetQuerySimples().ToList();
            var listaProdutosEANInvalidos = new List<ProdutoPesquisa>();

            foreach (ProdutoPesquisa produto in listaProdutos)
            {
                if (!string.IsNullOrWhiteSpace(produto.CodigoBarra) && (!Validacoes.ValidarEAN13(produto.CodigoBarra)))
                    listaProdutosEANInvalidos.Add(produto);
            }
            return listaProdutosEANInvalidos;
        }

        /// <summary>
        /// Obter lista de produtos com códigos de barra nulo ou branco
        /// </summary>
        /// <returns></returns>
        public object ObterPorCodigosBarraEmBranco()
        {
            var listaProdutos = GetQuerySimples().ToList();
            var listaProdutosEANEmBranco = new List<ProdutoPesquisa>();

            foreach (ProdutoPesquisa produto in listaProdutos)
            {
                if (string.IsNullOrWhiteSpace(produto.CodigoBarra))
                    listaProdutosEANEmBranco.Add(produto);
            }
            return listaProdutosEANEmBranco;
        }

        /// <summary>
        /// Atribui entidade à entidade persistente
        /// </summary>
        /// <param name="produto"></param>
        /// <param name="_produto"></param>
        private static void Atribuir(Produto produto, TbProduto _produto)
        {
            _produto.CodCst = produto.CodCST;
            _produto.CodFabricante = produto.CodFabricante;
            _produto.CodGrupo = produto.CodGrupo;
            _produto.CodigoBarra = produto.CodigoBarra == null ? "" : produto.CodigoBarra;
            _produto.CodSituacaoProduto = Convert.ToSByte(produto.CodSituacaoProduto);
            _produto.CodSubgrupo = produto.CodSubgrupo;
            _produto.DataUltimoPedido = produto.DataUltimoPedido;
            _produto.DataUltimaMudancaPreco = produto.DataUltimaMudancaPreco;
            _produto.Desconto = produto.Desconto;
            _produto.ExibeNaListagem = produto.ExibeNaListagem;
            _produto.Frete = produto.Frete;
            _produto.Icms = produto.Icms;
            _produto.IcmsSubstituto = produto.IcmsSubstituto;
            _produto.Ipi = produto.Ipi;
            _produto.LucroPrecoVendaAtacado = produto.LucroPrecoVendaAtacado;
            _produto.LucroPrecoVendaVarejo = produto.LucroPrecoVendaVarejo;
            _produto.LucroPrecoRevenda = produto.LucroPrecoRevenda;
            _produto.Ncmsh = produto.Ncmsh == null ? "" : produto.Ncmsh;
            _produto.Nome = produto.Nome;
            _produto.NomeProdutoFabricante = produto.NomeProdutoFabricante;
            _produto.PrecoVendaAtacado = produto.PrecoVendaAtacado;
            _produto.PrecoVendaVarejo = produto.PrecoVendaVarejo;
            _produto.PrecoRevenda = produto.PrecoRevenda;
            _produto.QtdProdutoAtacado = produto.QtdProdutoAtacado;
            _produto.QuantidadeEmbalagem = produto.QuantidadeEmbalagem;
            _produto.ReferenciaFabricante = produto.ReferenciaFabricante;
            _produto.Simples = produto.Simples;
            _produto.TemVencimento = produto.TemVencimento;
            _produto.UltimaDataAtualizacao = produto.UltimaDataAtualizacao;
            _produto.UltimoPrecoCompra = produto.UltimoPrecoCompra;
            _produto.Unidade = produto.Unidade;
            _produto.UnidadeCompra = produto.UnidadeCompra;
            _produto.EmPromocao = produto.EmPromocao;
        }

    }
}