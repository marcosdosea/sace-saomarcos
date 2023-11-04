using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio;
using Dados;
using Util;
using System.Data.Common;
using System.IO;

namespace Negocio
{
    public class GerenciadorProduto
    {

        private static GerenciadorProduto gProduto;

        public static GerenciadorProduto GetInstance()
        {
            if (gProduto == null)
            {
                gProduto = new GerenciadorProduto();
            }
            return gProduto;
        }

        /// <summary>
        /// Insere um novo produto na base de dados
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        public Int64 Inserir(Produto produto)
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

                ProdutoE _produtoE = new ProdutoE();
                Atribuir(produto, _produtoE);

                var repProduto = new RepositorioGenerico<ProdutoE>();
                repProduto.Inserir(_produtoE);
                repProduto.SaveChanges();

                ProdutoLoja produtoLoja = new ProdutoLoja();
                produtoLoja.CodProduto = _produtoE.codProduto;
                produtoLoja.CodLoja = Global.LOJA_PADRAO;
                produtoLoja.QtdEstoque = 0;
                produtoLoja.QtdEstoqueAux = 0;

                GerenciadorProdutoLoja.GetInstance(null).Inserir(produtoLoja);

                return _produtoE.codProduto;
            }
            catch (Exception e)
            {
                throw new DadosException("Produto", e.Message, e);
            }
        }

        public Int64 Inserir(EntradaProduto entradaProduto)
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
            var repProduto = new RepositorioGenerico<ProdutoE>();
            SaceEntities contexto = (SaceEntities)repProduto.ObterContexto();

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
                var query = from produtoSet in contexto.ProdutoSet
                            where produtoSet.codProduto == produto.CodProduto
                            select produtoSet;
                foreach (ProdutoE _produtoE in query)
                {
                    // Atualiza data da ultima atualizacao
                    if ((produto.PrecoVendaVarejo != _produtoE.precoVendaVarejo) || (produto.PrecoVendaAtacado != _produtoE.precoVendaAtacado)
                        || (produto.PrecoRevenda != _produtoE.precoRevenda))
                    {
                        produto.UltimaDataAtualizacao = DateTime.Now;
                        produto.DataUltimaMudancaPreco = DateTime.Now;
                    }

                    // Atualiza data para mudança da pasta e das etiquetas
                    if (produto.PrecoVendaVarejo != _produtoE.precoVendaVarejo)
                    {
                        produto.DataUltimaMudancaPreco = DateTime.Now;
                    }

                    // Atualiza dados do produto
                    Atribuir(produto, _produtoE);
                }
                repProduto.SaveChanges();
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
                var repProduto = new RepositorioGenerico<ProdutoE>();

                var saceEntities = (SaceEntities)repProduto.ObterContexto();
                var query = from produtoSet in saceEntities.ProdutoSet
                            where produtoSet.codProduto == _produtoPesquisa.CodProduto
                            select produtoSet;
                foreach (ProdutoE _produtoE in query)
                {
                    _produtoE.codigoBarra = ultimoCodigoBarraLido;
                }
                repProduto.SaveChanges();
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
                var repProduto = new RepositorioGenerico<ProdutoE>();
                var saceEntities = (SaceEntities)repProduto.ObterContexto();

                // substitui todas as saídas
                var querySaidas = from saidaProduto in saceEntities.SaidaProdutoSet
                                  where saidaProduto.codProduto == codProdutoExcluir
                                  select saidaProduto;
                foreach (SaidaProdutoE _saidaProdutoE in querySaidas)
                {
                    _saidaProdutoE.codProduto = codProdutoManter;
                }
                repProduto.SaveChanges();

                // Substituti todas as entradas
                var queryEntrada = from entradaProduto in saceEntities.EntradaProdutoSet
                                   where entradaProduto.codProduto == codProdutoExcluir
                                   select entradaProduto;
                foreach (EntradaProdutoE _entradaProdutoE in queryEntrada)
                {
                    _entradaProdutoE.codProduto = codProdutoManter;
                }
                repProduto.SaveChanges();

                // Substituti todas as pontas de estoque
                var queryPontaEstoque = from pontaEstoque in saceEntities.tb_ponta_estoque
                                   where pontaEstoque.codProduto == codProdutoExcluir
                                   select pontaEstoque;
                foreach (tb_ponta_estoque _pontaEstoque in queryPontaEstoque)
                {
                    _pontaEstoque.codProduto = codProdutoManter;
                }
                repProduto.SaveChanges();

                // Exclui Produto
                Remover(codProdutoExcluir);

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
                var repProduto = new RepositorioGenerico<ProdutoE>();

                var saceEntities = (SaceEntities)repProduto.ObterContexto();
                var query = from produtoSet in saceEntities.ProdutoSet
                            where produtoSet.codProduto == solicitacaoCompra.CodProduto
                            select produtoSet;
                DirectoryInfo pastaProdutosAtualizados = new DirectoryInfo(Global.PASTA_COMUNICACAO_PRODUTOS_ATUALIZADOS);
                foreach (ProdutoE _produtoE in query)
                {
                    _produtoE.codSituacaoProduto = solicitacaoCompra.CodSituacaoProduto;
                    _produtoE.dataSolicitacaoCompra = solicitacaoCompra.DataSolicitacaoCompra;
                    _produtoE.dataPedidoCompra = solicitacaoCompra.DataPedidoCompra;
                    var nomeComputador = System.Windows.Forms.SystemInformation.ComputerName.ToUpper();
                    if (pastaProdutosAtualizados.Exists && !nomeComputador.Equals(nomeServidor.ToUpper()))
                    {
                        String nomeArquivo = Global.PASTA_COMUNICACAO_PRODUTOS_ATUALIZADOS + solicitacaoCompra.CodProduto + ".txt";
                        StreamWriter arquivo = new StreamWriter(nomeArquivo, false, Encoding.ASCII);
                        arquivo.WriteLine("[CodProduto]" + solicitacaoCompra.CodProduto);
                        arquivo.WriteLine("[CodSituacaoProduto]" + solicitacaoCompra.CodSituacaoProduto);
                        arquivo.WriteLine("[DataSolicitacaoCompra]" + solicitacaoCompra.DataSolicitacaoCompra);
                        arquivo.WriteLine("[DataPedidoCompra]" + solicitacaoCompra.DataPedidoCompra);
                        arquivo.Close();
                    }
                }
                repProduto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new DadosException("Produto", e.Message, e);
            }

        }


        public void AtualizarSituacaoProdutoServidor(string nomeServidor)
        {
            DirectoryInfo Dir = new DirectoryInfo(Global.PASTA_COMUNICACAO_PRODUTOS_ATUALIZADOS);
            if (Dir.Exists)
            {
                // Busca automaticamente todos os arquivos em todos os subdiretórios
                string arquivosProduto = "*.txt";
                FileInfo[] files = Dir.GetFiles(arquivosProduto, SearchOption.TopDirectoryOnly);
                foreach (FileInfo file in files)
                {
                    try
                    {
                        String linha = null;
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
                var repProduto = new RepositorioGenerico<ProdutoE>();

                var saceEntities = (SaceEntities)repProduto.ObterContexto();
                var query = from produtoSet in saceEntities.ProdutoSet
                            where produtoSet.codProduto == codProduto
                            select produtoSet;
                foreach (ProdutoE _produtoE in query)
                {
                    _produtoE.ncmsh = ncsmsh;
                    _produtoE.nome = nomeProduto;
                    _produtoE.codigoBarra = codigoEAN;
                }
                repProduto.SaveChanges();
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
                var repProduto = new RepositorioGenerico<ProdutoE>();

                var saceEntities = (SaceEntities)repProduto.ObterContexto();
                var query = from produtoSet in saceEntities.ProdutoSet
                            where produtoSet.codProduto == codProduto
                            select produtoSet;
                foreach (ProdutoE _produtoE in query)
                {
                    _produtoE.nome = nomeProduto;
                    if (_produtoE.precoVendaVarejo != precoVarejo || _produtoE.precoVendaAtacado != precoAtacado)
                    {
                        _produtoE.precoVendaVarejo = precoVarejo;
                        _produtoE.precoVendaAtacado = precoAtacado;
                        _produtoE.precoRevenda = precoRevenda;
                        _produtoE.dataUltimaMudancaPreco = DateTime.Now;
                        _produtoE.ultimaDataAtualizacao = DateTime.Now;
                    }
                }
                repProduto.SaveChanges();
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
        public void Remover(Int64 codproduto)
        {
            if (codproduto == 1)
                throw new NegocioException("Esse produto não pode ser alterado ou removido.");
            try
            {
                var repProduto = new RepositorioGenerico<ProdutoE>();

                repProduto.Remover(p => p.codProduto == codproduto);
                repProduto.SaveChanges();
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
            var repProduto = new RepositorioGenerico<ProdutoE>();

            var saceEntities = (SaceEntities)repProduto.ObterContexto();
            var query = from produto in saceEntities.ProdutoSet
                        //join fabricante in saceEntities.PessoaSet on produto.codFabricante equals fabricante.codPessoa
                        orderby produto.nome
                        select new Produto
                        {
                            CodCST = produto.codCST,
                            CodFabricante = produto.codFabricante,
                            NomeFabricante = produto.tb_pessoa.nomeFantasia,
                            CodGrupo = (int)produto.codGrupo,
                            CodigoBarra = produto.codigoBarra,
                            CodProduto = produto.codProduto,
                            CodSituacaoProduto = produto.codSituacaoProduto,
                            CodSubgrupo = produto.codSubgrupo,
                            DataUltimoPedido = (DateTime)produto.dataUltimoPedido,
                            Desconto = (decimal)produto.desconto,
                            ExibeNaListagem = (bool)produto.exibeNaListagem,
                            Frete = (decimal)produto.frete,
                            Icms = (decimal)produto.icms,
                            IcmsSubstituto = (decimal)produto.icms_substituto,
                            Ipi = (decimal)produto.ipi,
                            LucroPrecoVendaAtacado = (decimal)produto.lucroPrecoVendaAtacado,
                            LucroPrecoVendaVarejo = (decimal)produto.lucroPrecoVendaVarejo,
                            LucroPrecoRevenda = (decimal)produto.lucroPrecoRevenda,
                            Ncmsh = produto.ncmsh,
                            Nome = produto.nome,
                            NomeProdutoFabricante = produto.nomeProdutoFabricante,
                            PrecoVendaAtacado = (decimal)produto.precoVendaAtacado,
                            PrecoVendaVarejo = (decimal)produto.precoVendaVarejo,
                            PrecoRevenda = (decimal)produto.precoRevenda,
                            QtdProdutoAtacado = (decimal)produto.qtdProdutoAtacado,
                            QuantidadeEmbalagem = (decimal)produto.quantidadeEmbalagem,
                            ReferenciaFabricante = produto.referenciaFabricante,
                            Simples = (decimal)produto.simples,
                            TemVencimento = (bool)produto.temVencimento,
                            EmPromocao = (bool)produto.emPromocao,
                            Unidade = produto.unidade,
                            UnidadeCompra = produto.unidadeCompra,
                            UltimoPrecoCompra = (decimal)produto.ultimoPrecoCompra,
                            UltimaDataAtualizacao = (DateTime)produto.ultimaDataAtualizacao,
                            DataUltimaMudancaPreco = (DateTime)produto.dataUltimaMudancaPreco
                        };
            return query;
        }

        /// <summary>
        /// Consulta simples para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<ProdutoPesquisa> GetQuerySimples()
        {
            var repProduto = new RepositorioGenerico<ProdutoE>();

            var saceEntities = (SaceEntities)repProduto.ObterContexto();
            var query = from produto in saceEntities.ProdutoSet
                        orderby produto.nome
                        select new ProdutoPesquisa
                        {
                            CodCST = produto.codCST,
                            CodigoBarra = produto.codigoBarra,
                            CodProduto = produto.codProduto,
                            Desconto = (decimal)produto.desconto,
                            ExibeNaListagem = (bool)produto.exibeNaListagem,
                            Frete = (decimal)produto.frete,
                            Icms = (decimal)produto.icms,
                            IcmsSubstituto = (decimal)produto.icms_substituto,
                            Ipi = (decimal)produto.ipi,
                            LucroPrecoVendaAtacado = (decimal)produto.lucroPrecoVendaAtacado,
                            LucroPrecoVendaVarejo = (decimal)produto.lucroPrecoVendaVarejo,
                            LucroPrecoRevenda = (decimal)produto.lucroPrecoRevenda,
                            Ncmsh = produto.ncmsh,
                            Nome = produto.nome,
                            CodFabricante = produto.codFabricante,
                            NomeProdutoFabricante = produto.nomeProdutoFabricante,
                            PrecoVendaAtacado = (decimal)produto.precoVendaAtacado,
                            PrecoVendaVarejo = (decimal)produto.precoVendaVarejo,
                            PrecoRevenda = (decimal)produto.precoRevenda,
                            QtdProdutoAtacado = (decimal)produto.qtdProdutoAtacado,
                            QuantidadeEmbalagem = (decimal)produto.quantidadeEmbalagem,
                            ReferenciaFabricante = produto.referenciaFabricante,
                            Simples = (decimal)produto.simples,
                            UltimaDataAtualizacao = (DateTime)produto.ultimaDataAtualizacao,
                            Unidade = produto.unidade,
                            TemVencimento = (bool)produto.temVencimento,
                            EmPromocao = (bool)produto.emPromocao,
                            UltimoPrecoCompra = (decimal)produto.ultimoPrecoCompra,
                            UnidadeCompra = produto.unidadeCompra,
                            CodSituacaoProduto = produto.codSituacaoProduto,
                            DataUltimaMudancaPreco = (DateTime)produto.dataUltimaMudancaPreco
                        };
            return query;
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
            var repProduto = new RepositorioGenerico<ProdutoE>();

            var saceEntities = (SaceEntities)repProduto.ObterContexto();
            var query = from produto in saceEntities.ProdutoSet
                        where produto.exibeNaListagem == true
                        orderby produto.nome
                        select new ProdutoNome
                        {
                            CodProduto = produto.codProduto,
                            Nome = produto.nome
                        };
            return query.ToList();
        }

        /// <summary>
        /// Obter todos os produtos ordenados pelo nome
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ProdutoNome> ObterTodosNomes()
        {
            var repProduto = new RepositorioGenerico<ProdutoE>();

            var saceEntities = (SaceEntities)repProduto.ObterContexto();
            var query = from produto in saceEntities.ProdutoSet
                        orderby produto.nome
                        select new ProdutoNome
                        {
                            CodProduto = produto.codProduto,
                            Nome = produto.nome
                        };
            return query.ToList();
        }
        /// <summary>
        /// Obter um produto usando um produto pesquisado
        /// </summary>
        /// <param name="produtoPesquisa"></param>
        /// <returns></returns>
        public Produto Obter(ProdutoPesquisa produtoPesquisa)
        {
            return GetQuery().Where(p => p.CodProduto == produtoPesquisa.CodProduto).ToList().ElementAt(0);
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
            return GetQuerySimples().Where(p => p.ReferenciaFabricante.Contains(referenciaFabricante)).ToList();
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
            return GetQuerySimples().Where(p => p.CodFabricante.Equals(codPessoa));//.ToList();
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
        /// Obtém produto pelo nome
        /// </summary>
        /// <param name="codBarra"></param>
        /// <returns></returns>
        public IEnumerable<ProdutoPesquisa> ObterPorNome(String nome)
        {
            var repProduto = new RepositorioGenerico<ProdutoE>();

            var saceEntities = (SaceEntities)repProduto.ObterContexto();
            var query = from produto in saceEntities.ProdutoSet
                        orderby produto.nome
                        select new ProdutoPesquisa
                        {
                            CodCST = produto.codCST,
                            CodigoBarra = produto.codigoBarra,
                            CodProduto = produto.codProduto,
                            Desconto = (decimal)produto.desconto,
                            ExibeNaListagem = (bool)produto.exibeNaListagem,
                            Frete = (decimal)produto.frete,
                            Icms = (decimal)produto.icms,
                            IcmsSubstituto = (decimal)produto.icms_substituto,
                            Ipi = (decimal)produto.ipi,
                            LucroPrecoVendaAtacado = (decimal)produto.lucroPrecoVendaAtacado,
                            LucroPrecoVendaVarejo = (decimal)produto.lucroPrecoVendaVarejo,
                            LucroPrecoRevenda = (decimal)produto.lucroPrecoRevenda,
                            Ncmsh = produto.ncmsh,
                            Nome = produto.nome,
                            CodFabricante = produto.codFabricante,
                            NomeProdutoFabricante = produto.nomeProdutoFabricante,
                            PrecoVendaAtacado = (decimal)produto.precoVendaAtacado,
                            PrecoVendaVarejo = (decimal)produto.precoVendaVarejo,
                            PrecoRevenda = (decimal)produto.precoRevenda,
                            QtdProdutoAtacado = (decimal)produto.qtdProdutoAtacado,
                            QuantidadeEmbalagem = (decimal)produto.quantidadeEmbalagem,
                            ReferenciaFabricante = produto.referenciaFabricante,
                            Simples = (decimal)produto.simples,
                            UltimaDataAtualizacao = (DateTime)produto.ultimaDataAtualizacao,
                            Unidade = produto.unidade,
                            TemVencimento = (bool)produto.temVencimento,
                            EmPromocao = (bool)produto.emPromocao,
                            UltimoPrecoCompra = (decimal)produto.ultimoPrecoCompra,
                            UnidadeCompra = produto.unidadeCompra,
                            CodSituacaoProduto = produto.codSituacaoProduto
                        };

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
            var repProduto = new RepositorioGenerico<ProdutoE>();
            var saceEntities = (SaceEntities)repProduto.ObterContexto();

            if (codFornecedor == 1)
            {
                var query = from produto in saceEntities.ProdutoSet
                            orderby produto.nome
                            where listaCodSituacoes.Contains(produto.codSituacaoProduto)
                            select new SolicitacoesCompra
                            {
                                CodProduto = produto.codProduto,
                                Nome = produto.nome,
                                ReferenciaFabricante = produto.referenciaFabricante,
                                Unidade = produto.unidade,
                                CodSituacaoProduto = produto.codSituacaoProduto,
                                DataSolicitacaoCompra = (DateTime)produto.dataSolicitacaoCompra,
                                DataPedidoCompra = (DateTime)produto.dataPedidoCompra
                            };
                return query.ToList();
            }
            else
            {
                var queryProdutosFornecedor = saceEntities.EntradaProdutoSet.Where(e => e.tb_entrada.codFornecedor == codFornecedor);
                List<long> listaCodigoProdutosFornecedor = queryProdutosFornecedor.Select(p => p.codProduto).Distinct().ToList();

                var query = from produto in saceEntities.ProdutoSet
                            orderby produto.nome
                            where listaCodSituacoes.Contains(produto.codSituacaoProduto) &&
                                (listaCodigoProdutosFornecedor.Contains(produto.codProduto) || produto.codFabricante.Equals(codFornecedor))
                            select new SolicitacoesCompra
                            {
                                CodProduto = produto.codProduto,
                                Nome = produto.nome,
                                ReferenciaFabricante = produto.referenciaFabricante,
                                Unidade = produto.unidade,
                                CodSituacaoProduto = produto.codSituacaoProduto,
                                DataSolicitacaoCompra = (DateTime)produto.dataSolicitacaoCompra,
                                DataPedidoCompra = (DateTime)produto.dataPedidoCompra
                            };
                return query.ToList();

            }


        }


        /// <summary>
        /// Obtém produto que podem ser exibidos na lista pelo nome 
        /// </summary>
        /// <param name="codBarra"></param>
        /// <returns></returns>
        public IEnumerable<ProdutoPesquisa> ObterPorNomeExibiveis(String nome)
        {
            if ((nome.Length > 0) && (nome[0] == '%'))
            {
                return GetQuerySimples().Where(p => p.Nome.Contains(nome.Remove(0, 1)) && p.ExibeNaListagem).ToList();
                //return GetQuerySimples().Where(p => p.Nome.Contains(nome.Remove(0, 1))).ToList();
            }
            else
            {
                //return GetQuerySimples().Where(p => p.Nome.StartsWith(nome)).ToList();
                return GetQuerySimples().Where(p => p.Nome.StartsWith(nome) && p.ExibeNaListagem).ToList();
            }
        }

        /// <summary>
        /// Obter todas as situações de produtos cadastradas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SituacaoProduto> ObterSituacoesProduto()
        {
            var repProduto = new RepositorioGenerico<ProdutoE>();

            var saceEntities = (SaceEntities)repProduto.ObterContexto();
            var query = from situacaoProduto in saceEntities.SituacaoProdutoSet
                        select new SituacaoProduto
                        {
                            CodSituacaoProduto = situacaoProduto.codSituacaoProduto,
                            DescricaoSituacao = situacaoProduto.descricaoSituacao
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
        /// <param name="_produtoE"></param>
        private static void Atribuir(Produto produto, ProdutoE _produtoE)
        {
            _produtoE.codCST = produto.CodCST;
            _produtoE.codFabricante = produto.CodFabricante;
            _produtoE.codGrupo = produto.CodGrupo;
            _produtoE.codigoBarra = produto.CodigoBarra == null ? "" : produto.CodigoBarra;
            _produtoE.codSituacaoProduto = Convert.ToSByte(produto.CodSituacaoProduto);
            _produtoE.codSubgrupo = produto.CodSubgrupo;
            _produtoE.dataUltimoPedido = produto.DataUltimoPedido;
            _produtoE.dataUltimaMudancaPreco = produto.DataUltimaMudancaPreco;
            _produtoE.desconto = produto.Desconto;
            _produtoE.exibeNaListagem = produto.ExibeNaListagem;
            _produtoE.frete = produto.Frete;
            _produtoE.icms = produto.Icms;
            _produtoE.icms_substituto = produto.IcmsSubstituto;
            _produtoE.ipi = produto.Ipi;
            _produtoE.lucroPrecoVendaAtacado = produto.LucroPrecoVendaAtacado;
            _produtoE.lucroPrecoVendaVarejo = produto.LucroPrecoVendaVarejo;
            _produtoE.lucroPrecoRevenda = produto.LucroPrecoRevenda;
            _produtoE.ncmsh = produto.Ncmsh == null ? "" : produto.Ncmsh;
            _produtoE.nome = produto.Nome;
            _produtoE.nomeProdutoFabricante = produto.NomeProdutoFabricante;
            _produtoE.precoVendaAtacado = produto.PrecoVendaAtacado;
            _produtoE.precoVendaVarejo = produto.PrecoVendaVarejo;
            _produtoE.precoRevenda = produto.PrecoRevenda;
            _produtoE.qtdProdutoAtacado = produto.QtdProdutoAtacado;
            _produtoE.quantidadeEmbalagem = produto.QuantidadeEmbalagem;
            _produtoE.referenciaFabricante = produto.ReferenciaFabricante;
            _produtoE.simples = produto.Simples;
            _produtoE.temVencimento = produto.TemVencimento;
            _produtoE.ultimaDataAtualizacao = produto.UltimaDataAtualizacao;
            _produtoE.ultimoPrecoCompra = produto.UltimoPrecoCompra;
            _produtoE.unidade = produto.Unidade;
            _produtoE.unidadeCompra = produto.UnidadeCompra;
            _produtoE.emPromocao = produto.EmPromocao;
        }

    }
}