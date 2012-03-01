using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;


namespace Negocio
{
    public interface IGerenciadorEntradaProduto : IGerenciadorNegocio<EntradaProduto, Int64>
    {
        EntradaProduto obter(Int64 codEntradaProduto);

        List<EntradaProduto> obterDisponiveisPorValidade(Int64 codProduto);

        Decimal baixaItensVendidosEstoque(Produto produto, DateTime dataValidade, Decimal quantidadeVendida);

        DateTime getDataProdutoMaisAntigoEstoque(Produto produto);
    }
}
