﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;


namespace Negocio
{
    public interface IGerenciadorEntradaProduto : IGerenciadorNegocio<EntradaProduto, Int64>
    {
        EntradaProduto obter(Int64 codEntradaProduto);
        
        decimal baixaItensVendidosEstoque(Produto produto, DateTime dataValidade, Decimal quantidadeVendida);
        DateTime getDataProdutoMaisAntigoEstoque(Produto produto);
        
        List<EntradaProduto> ObterEntradasPrincipais(long codProduto);
        List<EntradaProduto> ObterEntradasAuxiliar(long codProduto);

        decimal ObterEstoquePrincipalDisponivel(long codProduto);
        decimal ObterEstoqueAuxDisponivel(long codProduto);
    }
}