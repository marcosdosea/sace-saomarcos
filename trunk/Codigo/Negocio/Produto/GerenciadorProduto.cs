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
        private static RepositorioGenerico<ProdutoE, SaceEntities> repProduto;

        public static GerenciadorProduto GetInstance()
        {
            if (gProduto == null)
            {
                gProduto = new GerenciadorProduto();
                repProduto = new RepositorioGenerico<ProdutoE, SaceEntities>("chave");
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

                ProdutoE _produtoE = new ProdutoE();
                Atribuir(produto, _produtoE);

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
            if (produto.CodProduto == 1)
                throw new NegocioException("Esse produto não pode ser alterado ou removido.");
            else if (produto.Nome.Trim().Equals(""))
                throw new NegocioException("O nome do produto não pode ficar em branco.");

            try
            {
                ProdutoE _produtoE = repProduto.ObterEntidade(p => p.codProduto == produto.CodProduto);
                // Atualiza data da ultima atualizacao
                if ((produto.PrecoVendaVarejo != _produtoE.precoVendaVarejo) || (produto.PrecoVendaAtacado != _produtoE.precoVendaAtacado))
                    produto.UltimaDataAtualizacao = DateTime.Now;
                
                // Atualiza dados do produto
                Atribuir(produto, _produtoE);
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
                ProdutoE _produtoE = repProduto.ObterEntidade(p => p.codProduto == _produtoPesquisa.CodProduto);
                _produtoE.codigoBarra = ultimoCodigoBarraLido;
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
            var saceEntities = (SaceEntities)repProduto.ObterContexto();
            var query = from produto in saceEntities.ProdutoSet
                        select new Produto
                        {
                            Cfop = (int) produto.cfop,
                            CodCST = produto.codCST,
                            CodFabricante = produto.codFabricante,
                            CodGrupo = (int) produto.codGrupo,
                            CodigoBarra = produto.codigoBarra,
                            CodProduto = produto.codProduto,
                            CodSituacaoProduto = (byte) produto.codSituacaoProduto,
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
                            Ncmsh = produto.ncmsh,
                            Nome = produto.nome,
                            NomeProdutoFabricante = produto.nomeProdutoFabricante,
                            PrecoVendaAtacado = (decimal) produto.precoVendaAtacado,
                            PrecoVendaVarejo = (decimal) produto.precoVendaVarejo,
                            QtdProdutoAtacado = (decimal) produto.qtdProdutoAtacado,
                            QuantidadeEmbalagem = (decimal) produto.quantidadeEmbalagem,
                            ReferenciaFabricante = produto.referenciaFabricante,
                            Simples = (decimal) produto.simples,
                            TemVencimento = (bool) produto.temVencimento,
                            UltimaDataAtualizacao = (DateTime) produto.ultimaDataAtualizacao,
                            UltimoPrecoCompra = (decimal) produto.ultimoPrecoCompra,
                            Unidade = produto.unidade,
                            UnidadeCompra = produto.unidadeCompra
                        };
            return query;
        }

        /// <summary>
        /// Consulta simples para retornar dados da entidade
        /// </summary>
        /// <returns></returns>
        private IQueryable<ProdutoPesquisa> GetQuerySimples()
        {
            var saceEntities = (SaceEntities)repProduto.ObterContexto();
            var query = from produto in saceEntities.ProdutoSet
                        select new ProdutoPesquisa
                        {
                            CodCST = produto.codCST,
                            CodigoBarra = produto.codigoBarra,
                            CodProduto = produto.codProduto,
                            Nome = produto.nome,
                            NomeProdutoFabricante = produto.nomeProdutoFabricante,
                            PrecoVendaAtacado = (decimal)produto.precoVendaAtacado,
                            PrecoVendaVarejo = (decimal)produto.precoVendaVarejo,
                            QtdProdutoAtacado = (decimal)produto.qtdProdutoAtacado,
                            UltimaDataAtualizacao = (DateTime)produto.ultimaDataAtualizacao,
                            Unidade = produto.unidade,
                            TemVencimento = (bool) produto.temVencimento
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
        /// Obter todas as situações de produtos cadastradas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SituacaoProduto> ObterSituacoesProduto()
        {
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
            _produtoE.cfop = produto.Cfop;
            _produtoE.codCST = produto.CodCST;
            _produtoE.codFabricante = produto.CodFabricante;
            _produtoE.codGrupo = produto.CodGrupo;
            _produtoE.codigoBarra = produto.CodigoBarra;
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
            _produtoE.ncmsh = produto.Ncmsh;
            _produtoE.nome = produto.Nome;
            _produtoE.nomeProdutoFabricante = produto.NomeProdutoFabricante;
            _produtoE.precoVendaAtacado = produto.PrecoVendaAtacado;
            _produtoE.precoVendaVarejo = produto.PrecoVendaVarejo;
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