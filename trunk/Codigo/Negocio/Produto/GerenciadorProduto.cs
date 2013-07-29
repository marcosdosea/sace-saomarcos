using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Dominio;
using Dados.saceDataSetTableAdapters;
using Dados;
using Util;
using System.Data.Common;

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

                ProdutoE _produtoE = new ProdutoE();
                Atribuir(produto, _produtoE);

                var repProduto = new RepositorioGenerico<ProdutoE>();
                repProduto.Inserir(_produtoE);
                repProduto.SaveChanges();

                return _produtoE.codProduto;
            }
            catch (Exception e)
            {
                throw new DadosException("Produto", e.Message, e);
            }
        }

        /// <summary>
        /// Atualiza os dados do produto
        /// </summary>
        /// <param name="produto"></param>
        public void Atualizar(Produto produto)
        {
            var repProduto = new RepositorioGenerico<ProdutoE>();
            SaceEntities contexto = (SaceEntities) repProduto.ObterContexto();

            if (produto.CodProduto == 1)
                throw new NegocioException("Esse produto não pode ser alterado ou removido.");
            else if (produto.Nome.Trim().Equals(""))
                throw new NegocioException("O nome do produto não pode ficar em branco.");
            else if (produto.QuantidadeEmbalagem <= 0)
                throw new NegocioException("A quantidade de produtos na embalagem deve ser maior que zero.");

            try
            {
                var query = from produtoSet in contexto.ProdutoSet
                            where produtoSet.codProduto == produto.CodProduto
                            select produtoSet;
                foreach (ProdutoE _produtoE in query)
                {
                    // Atualiza data da ultima atualizacao
                    if ((produto.PrecoVendaVarejo != _produtoE.precoVendaVarejo) || (produto.PrecoVendaAtacado != _produtoE.precoVendaAtacado))
                        produto.UltimaDataAtualizacao = DateTime.Now;

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
        /// Atualiza ncm e quantidade Atacado
        /// </summary>
        /// <param name="_produtoPesquisa"></param>
        /// <param name="ultimoCodigoBarraLido"></param>
        public void AtualizarNcmshQtdAtacado(long codProduto, string ncsmsh, decimal quantidadeAtacado)
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
                    _produtoE.qtdProdutoAtacado = quantidadeAtacado;
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
                        join fabricante in saceEntities.PessoaSet on produto.codFabricante equals fabricante.codPessoa
                        orderby produto.nome
                        select new Produto
                        {
                            CodCST = produto.codCST,
                            CodFabricante = produto.codFabricante,
                            NomeFabricante = fabricante.nomeFantasia,
                            CodGrupo = (int) produto.codGrupo,
                            CodigoBarra = produto.codigoBarra,
                            CodProduto = produto.codProduto,
                            CodSituacaoProduto = produto.codSituacaoProduto,
                            CodSubgrupo = produto.codSubgrupo,
                            DataUltimoPedido = (DateTime) produto.dataUltimoPedido,
                            Desconto = (decimal) produto.desconto,
                            ExibeNaListagem = (bool) produto.exibeNaListagem,
                            Frete = (decimal) produto.frete,
                            Icms = (decimal) produto.icms,
                            IcmsSubstituto = (decimal) produto.icms_substituto,
                            Ipi = (decimal) produto.ipi,
                            LucroPrecoVendaAtacado = (decimal) produto.lucroPrecoVendaAtacado,
                            LucroPrecoVendaVarejo = (decimal) produto.lucroPrecoVendaVarejo,
                            LucroPrecoRevenda = (decimal) produto.lucroPrecoRevenda,
                            Ncmsh = produto.ncmsh,
                            Nome = produto.nome,
                            NomeProdutoFabricante = produto.nomeProdutoFabricante,
                            PrecoVendaAtacado = (decimal) produto.precoVendaAtacado,
                            PrecoVendaVarejo = (decimal) produto.precoVendaVarejo,
                            PrecoRevenda = (decimal) produto.precoRevenda,
                            QtdProdutoAtacado = (decimal) produto.qtdProdutoAtacado,
                            QuantidadeEmbalagem = (decimal) produto.quantidadeEmbalagem,
                            ReferenciaFabricante = produto.referenciaFabricante,
                            Simples = (decimal) produto.simples,
                            TemVencimento = (bool) produto.temVencimento,
                            Unidade = produto.unidade,
                            UnidadeCompra = produto.unidadeCompra,
                            UltimoPrecoCompra = (decimal)produto.ultimoPrecoCompra,
                            UltimaDataAtualizacao = (DateTime) produto.ultimaDataAtualizacao
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
                            Desconto = (decimal) produto.desconto,
                            ExibeNaListagem = (bool) produto.exibeNaListagem,
                            Frete = (decimal)produto.frete,
                            Icms = (decimal)produto.icms,
                            IcmsSubstituto = (decimal)produto.icms_substituto,
                            Ipi = (decimal)produto.ipi,
                            LucroPrecoVendaAtacado = (decimal)produto.lucroPrecoVendaAtacado,
                            LucroPrecoVendaVarejo = (decimal)produto.lucroPrecoVendaVarejo,
                            LucroPrecoRevenda = (decimal) produto.lucroPrecoRevenda,
                            Ncmsh = produto.ncmsh,
                            Nome = produto.nome,
                            NomeProdutoFabricante = produto.nomeProdutoFabricante,
                            PrecoVendaAtacado = (decimal)produto.precoVendaAtacado,
                            PrecoVendaVarejo = (decimal)produto.precoVendaVarejo,
                            PrecoRevenda = (decimal) produto.precoRevenda,
                            QtdProdutoAtacado = (decimal)produto.qtdProdutoAtacado,
                            QuantidadeEmbalagem = (decimal) produto.quantidadeEmbalagem,
                            ReferenciaFabricante = produto.referenciaFabricante,
                            Simples = (decimal) produto.simples,
                            UltimaDataAtualizacao = (DateTime)produto.ultimaDataAtualizacao,
                            Unidade = produto.unidade,
                            TemVencimento = (bool) produto.temVencimento,
                            UltimoPrecoCompra = (decimal) produto.ultimoPrecoCompra,
                            UnidadeCompra = produto.unidadeCompra
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
            return GetQuerySimples().ToList().Where(p => Convert.ToByte(p.ExibeNaListagem) == 1);
            //return GetQuerySimples();
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
        public IEnumerable<ProdutoPesquisa> ObterPorCodBarra(String codBarra)
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
        /// Obtém produto pela data de atualização
        /// </summary>
        /// <param name="codBarra"></param>
        /// <returns></returns>
        public IEnumerable<ProdutoPesquisa> ObterPorDataAtualizacaoMaiorIgual(DateTime dataAtualizacao)
        {
            return GetQuerySimples().Where(p => p.UltimaDataAtualizacao >= dataAtualizacao).ToList();
        }

        /// <summary>
        /// Obtém produto pelo nome
        /// </summary>
        /// <param name="codBarra"></param>
        /// <returns></returns>
        public IEnumerable<ProdutoPesquisa> ObterPorNome(String nome)
        {
            if ((nome.Length > 0) && (nome[0] == '%'))
            {
                return GetQuerySimples().Where(p => p.Nome.Contains(nome.Remove(0, 1))).ToList();
            }
            else
            {
                return GetQuerySimples().Where(p => p.Nome.StartsWith(nome)).ToList();
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
        }
    }
}