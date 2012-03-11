using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;


namespace Negocio
{
    public interface IGerenciadorSaidaProduto : IGerenciadorNegocio<SaidaProduto, SaidaProduto>
    {
        List<SaidaProduto> obterSaidaProdutos(Int64 codSaida);
        List<SaidaProduto> obterSaidaProdutosSemCST(Int64 codSaida, String codCST);
    }
}