using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;


namespace Negocio
{
    public interface IGerenciadorProduto: IGerenciadorNegocio<Produto, Int32>
    {
        Produto obterProduto(Int32 codProduto);
        decimal calculaPrecoCusto(Produto produto);
        decimal calculaPrecoVenda(decimal precoCusto, decimal lucro);
    }
}
