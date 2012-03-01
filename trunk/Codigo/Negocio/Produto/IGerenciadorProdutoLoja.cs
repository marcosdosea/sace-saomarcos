using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;


namespace Negocio
{
    public interface IGerenciadorProdutoLoja: IGerenciadorNegocio<ProdutoLoja, ProdutoLojaPK>
    {
        ProdutoLoja obterProdutoLoja(ProdutoLojaPK produtoLojaPK);
        void adicionaQuantidade(decimal quantidade, decimal quantidadeAux, Int32 codLoja, Int32 codProduto);
    }
}