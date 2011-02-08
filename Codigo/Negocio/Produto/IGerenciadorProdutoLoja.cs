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
    }
}
