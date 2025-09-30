using Dados;
using Dominio;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Util;

namespace Negocio
{
    public static class GerenciadorProduto
    {

        /// <summary>
        /// Insere um novo produto na base de dados
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        public static long Inserir(Produto produto)
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
                using (var context = new SaceContext())
                {
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
        public static long Inserir(EntradaProduto entradaProduto)
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
        /// Atualiza os dados do produto criando um novo contexto
        /// </summary>
        /// <param name="produto"></param>
        public static void Atualizar(Produto produto)
        {
            using(var context = new SaceContext())
            {
                Atualizar(produto, context);
            }
        }

        /// <summary>
        /// Atualiza os dados do produto
        /// </summary>
        /// <param name="produto"></param>
        public static void Atualizar(Produto produto, SaceContext context)
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
                var _produto = context.TbProdutos.Find(produto.CodProduto);

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
                context.Update(_produto);
                context.SaveChanges();

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
        public static void AtualizarCodigoBarra(ProdutoPesquisa _produtoPesquisa, string ultimoCodigoBarraLido)
        {
            try
            {
                using (var context = new SaceContext())
                {
                    var _produto = context.TbProdutos.Find(_produtoPesquisa.CodProduto);
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
        public static void SubstituirProduto(long codProdutoExcluir, long codProdutoManter)
        {
            try
            {
                using (var context = new SaceContext())
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
                    }
                    context.SaveChanges();

                    // Substituti todas as entradas
                    var queryEntrada = from entradaProduto in context.TbEntradaProdutos
                                       where entradaProduto.CodProduto == codProdutoExcluir
                                       select entradaProduto;
                    foreach (TbEntradaProduto _entradaProduto in queryEntrada)
                    {
                        _entradaProduto.CodProduto = codProdutoManter;
                        context.Update(_entradaProduto);
                    }
                    context.SaveChanges();

                    // Substituti todas as pontas de estoque
                    var queryPontaEstoque = from pontaEstoque in context.TbPontaEstoques
                                            where pontaEstoque.CodProduto == codProdutoExcluir
                                            select pontaEstoque;
                    foreach (TbPontaEstoque _pontaEstoque in queryPontaEstoque)
                    {
                        _pontaEstoque.CodProduto = codProdutoManter;
                        context.Update(_pontaEstoque);
                    }
                    context.SaveChanges();

                    var _produto = new TbProduto();
                    _produto.CodProduto = codProdutoExcluir;

                    context.Remove(_produto);
                    context.SaveChanges();
                    transaction.Commit();
                }
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
        public static void AtualizarSituacaoProduto(SolicitacoesCompra solicitacaoCompra, string nomeServidor)
        {
            using (var context = new SaceContext())
            {
                try
                {
                    var transaction = context.Database.BeginTransaction();

                    TbProduto _produto = context.TbProdutos.Find(solicitacaoCompra.CodProduto);
                    DirectoryInfo pastaProdutosAtualizados = new DirectoryInfo(UtilConfig.Default.PASTA_COMUNICACAO_PRODUTOS_ATUALIZADOS);
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
                    context.Database.CommitTransaction();
                }
                catch (Exception e)
                {
                    context.Database.RollbackTransaction();
                    throw new DadosException("Produto", e.Message, e);
                }
            }
        }

        /// <summary>
        /// Solicita atualização da situação de produtos no servidor
        /// </summary>
        /// <param name="nomeServidor"></param>
        public static void AtualizarSituacaoProdutoServidor(string nomeServidor)
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
        public static void AtualizarNcmshQtdAtacado(long codProduto, string nomeProduto, string ncsmsh, string codigoEAN)
        {
            using (var context = new SaceContext())
            {
                var transaction = context.Database.BeginTransaction();
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
                    }
                    context.SaveChanges();
                    context.Database.CommitTransaction();
                }
                catch (Exception e)
                {
                    context.Database.RollbackTransaction();
                    throw new DadosException("Produto", e.Message, e);
                }
            }
        }

        /// <summary>
        /// Atualiza preços do produto
        /// </summary>
        /// <param name="codProduto"></param>
        /// <param name="nomeProduto"></param>
        /// <param name="precoVarejo"></param>
        /// <param name="precoAtacado"></param>
        public static void AtualizarPrecoVarejoAtacado(List<ProdutoPesquisa> listaProdutos)
        {
            using (var context = new SaceContext())
            {
                context.Database.BeginTransaction();
                try
                {
                    foreach (ProdutoPesquisa produto in listaProdutos)
                    {
                        var _produto = context.TbProdutos.Find(produto.CodProduto);
                        if (_produto != null)
                        {
                            _produto.Nome = produto.Nome;
                            if ((_produto.PrecoVendaVarejo != produto.PrecoVendaVarejo) || 
                                (_produto.PrecoVendaAtacado != produto.PrecoVendaAtacado) ||
                                (_produto.PrecoRevenda != produto.PrecoRevenda))
                            {
                                _produto.PrecoVendaVarejo = produto.PrecoVendaVarejo;
                                _produto.PrecoVendaAtacado = produto.PrecoVendaAtacado;
                                _produto.PrecoRevenda = produto.PrecoRevenda;
                                _produto.DataUltimaMudancaPreco = DateTime.Now;
                                _produto.UltimaDataAtualizacao = DateTime.Now;
                            }
                            context.Update(_produto);
                            context.SaveChanges();
                        }
                    }
                    context.Database.CommitTransaction();
                }
                catch (Exception e)
                {
                    context.Database.RollbackTransaction();
                    throw new DadosException("Produto", e.Message, e);
                }
            }
        }


        /// <summary>
        /// Remove produto da base de dados
        /// </summary>
        /// <param name="codProduto"></param>
        public static void Remover(long codProduto)
        {
            if (codProduto == 1)
                throw new NegocioException("Esse produto não pode ser alterado ou removido.");
            try
            {
                using (var context = new SaceContext())
                {
                    var produto = context.TbProdutos.Find(codProduto);
                    if (produto != null)
                    {
                        context.Remove(produto);
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new NegocioException("Produto não encontrado.");
                    }
                }
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
        private static IQueryable<Produto> GetQuery(SaceContext context)
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
        private static IQueryable<ProdutoPesquisa> GetQuerySimples(SaceContext context)
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
        public static IEnumerable<Produto> ObterTodos()
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).ToList();
            }
        }

        /// <summary>
        /// Obter todos os produtos
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ProdutoPesquisa> ObterTodosPesquisa()
        {
            using (var context = new SaceContext())
            {
                return GetQuerySimples(context).ToList();
            }
        }


        /// <summary>
        /// Obtém produto que podem ser exibidos na listagem
        /// </summary>
        /// <param name="codBarra"></param>
        /// <returns></returns>
        public static IEnumerable<ProdutoPesquisa> ObterTodosExibiveis()
        {
            using (var context = new SaceContext())
            {
                return GetQuerySimples(context).Where(p => p.ExibeNaListagem == true).ToList();
            }
        }

        public static IEnumerable<ProdutoNome> ObterTodosNomesExibiveis()
        {
            using (var context = new SaceContext())
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
        }

        /// <summary>
        /// Obter todos os produtos ordenados pelo nome
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ProdutoNome> ObterTodosNomes()
        {
            using (var context = new SaceContext())
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
        }

        /// <summary>
        /// Obter um produto usando um produto pesquisado
        /// </summary>
        /// <param name="produtoPesquisa"></param>
        /// <returns></returns>
        public static Produto Obter(ProdutoPesquisa produtoPesquisa)
        {
            using (var context = new SaceContext())
            {
                return GetQuery(context).Where(p => p.CodProduto == produtoPesquisa.CodProduto).First();
            }
        }

        /// <summary>
        /// Obter pelo código do produto
        /// </summary>
        /// <param name="codProduto"></param>
        /// <returns></returns>
        public static IEnumerable<ProdutoPesquisa> Obter(long codProduto)
        {
            using (var context = new SaceContext())
            {
                return GetQuerySimples(context).Where(p => p.CodProduto == codProduto).ToList();
            }
        }

        /// <summary>
        /// Obter pela referência do fabricante
        /// </summary>
        /// <param name="codProduto"></param>
        /// <returns></returns>
        public static IEnumerable<ProdutoPesquisa> ObterPorReferenciaFabricante(string referenciaFabricante)
        {
            using (var context = new SaceContext())
            {
                return GetQuerySimples(context).Where(p => p.ReferenciaFabricante.StartsWith(referenciaFabricante)).ToList();
            }
        }


        /// <summary>
        /// Obter pela código de barra do produto
        /// </summary>
        /// <param name="codProduto"></param>
        /// <returns></returns>
        public static IEnumerable<ProdutoPesquisa> ObterPorCodigoBarra(string codigoBarra)
        {
            using (var context = new SaceContext())
            {
                return GetQuerySimples(context).Where(p => p.CodigoBarra.StartsWith(codigoBarra)).ToList();
            }
        }

        /// <summary>
        /// Obter por Ncmsh
        /// </summary>
        /// <param name="Ncmsh"></param>
        /// <returns></returns>
        public static IEnumerable<ProdutoPesquisa> ObterPorNcmsh(string ncmsh)
        {
            using (var context = new SaceContext())
            {
                return GetQuerySimples(context).Where(p => p.Ncmsh.StartsWith(ncmsh)).ToList();
            }
        }

        /// <summary>
        /// Obtém produto pelo código de barra
        /// </summary>
        /// <param name="codBarra"></param>
        /// <returns></returns>
        public static IEnumerable<ProdutoPesquisa> ObterPorCodigoBarraExato(String codBarra)
        {
            using (var context = new SaceContext())
            {
                return GetQuerySimples(context).Where(p => p.CodigoBarra.Equals(codBarra)).ToList();
            }
        }

        /// <summary>
        /// Obtém produto pelo nome
        /// </summary>
        /// <param name="codBarra"></param>
        /// <returns></returns>
        public static IEnumerable<ProdutoPesquisa> ObterPorNomeProdutoFabricante(String nomeProdutoFabricante)
        {
            using (var context = new SaceContext())
            {
                return GetQuerySimples(context).Where(p => p.NomeProdutoFabricante.StartsWith(nomeProdutoFabricante)).ToList();
            }
        }

        /// <summary>
        /// Retorna todos os produtos de um determinado fabricante
        /// </summary>
        /// <param name="codPessoa"></param>
        /// <returns></returns>
        public static IEnumerable<ProdutoPesquisa> ObterPorCodigoFabricante(long codPessoa)
        {
            using (var context = new SaceContext())
            {
                return GetQuerySimples(context).Where(p => p.CodFabricante.Equals(codPessoa)).ToList();
            }
        }

        /// <summary>
        /// Obtém produto pela data de atualização
        /// </summary>
        /// <param name="codBarra"></param>
        /// <returns></returns>
        public static IEnumerable<ProdutoPesquisa> ObterPorDataAtualizacaoMaiorIgual(DateTime dataAtualizacao)
        {
            using (var context = new SaceContext())
            {
                return GetQuerySimples(context).Where(p => p.UltimaDataAtualizacao >= dataAtualizacao).ToList();
            }
        }

        public static IEnumerable<ProdutoPesquisa> ObterPorDataMudancaPrecoMaiorIgual(DateTime dataMudancaPreco)
        {
            using (var context = new SaceContext())
            {
                return GetQuerySimples(context).Where(p => p.DataUltimaMudancaPreco >= dataMudancaPreco).ToList();
            }
        }

        /// <summary>
        /// Obtém produto pelo nome usand pesquisa com caracteres
        /// </summary>
        /// <param name="codBarra"></param>
        /// <returns></returns>
        public static IEnumerable<ProdutoPesquisa> ObterPorNome(string nome)
        {
            using (var context = new SaceContext())
            {
                var query = GetQuerySimples(context);
                if ((nome.Length > 0) && (nome[0] == '%'))
                {
                    return query.Where(p => p.Nome.Contains(nome.Remove(0, 1))).ToList();
                }
                else
                {
                    return query.Where(p => p.Nome.StartsWith(nome)).ToList();
                }
            }
        }


        /// <summary>
        /// Obter solicitações de compras de produtos
        /// </summary>
        /// <param name="codBarra"></param>
        /// <returns></returns>
        public static IEnumerable<SolicitacoesCompra> ObterSolicitacoesCompra(List<int> listaCodSituacoes, long codFornecedor)
        {
            using (var context = new SaceContext())
            {
                if (codFornecedor == 1)
                {
                    var query = from produto in context.TbProdutos
                                orderby produto.Nome
                                where produto.CodProduto != 1 && listaCodSituacoes.Contains(produto.CodSituacaoProduto)
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
                                where produto.CodProduto != 1 && listaCodSituacoes.Contains(produto.CodSituacaoProduto) &&
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
                    return query.AsNoTracking().ToList();
                }
            }
        }


        /// <summary>
        /// Obtém produto que podem ser exibidos na lista pelo nome 
        /// </summary>
        /// <param name="codBarra"></param>
        /// <returns></returns>
        public static IEnumerable<ProdutoPesquisa> ObterPorNomeExibiveis(string nome)
        {
            using (var context = new SaceContext())
            {

                if ((nome.Length > 0) && (nome[0] == '%'))
                {
                    return GetQuerySimples(context).Where(p => p.Nome.Contains(nome.Remove(0, 1)) && p.ExibeNaListagem).ToList();
                }
                else
                {
                    return GetQuerySimples(context).Where(p => p.Nome.StartsWith(nome) && p.ExibeNaListagem).ToList();
                }
            }
        }

        /// <summary>
        /// Obter todas as situações de produtos cadastradas
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SituacaoProduto> ObterSituacoesProduto()
        {
            using (var context = new SaceContext())
            {
                var query = from situacaoProduto in context.TbSituacaoProdutos
                            select new SituacaoProduto
                            {
                                CodSituacaoProduto = situacaoProduto.CodSituacaoProduto,
                                DescricaoSituacao = situacaoProduto.DescricaoSituacao
                            };
                return query.ToList();
            }
        }

        /// <summary>
        /// Obtém lista de produtos com códigos de barra inválidos
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ProdutoPesquisa> ObterPorCodigosBarraInvalidos()
        {
            var listaProdutos = ObterTodos();
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
        public static object ObterPorCodigosBarraEmBranco()
        {
            var listaProdutos = ObterTodos();
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