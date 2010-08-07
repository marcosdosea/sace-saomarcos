using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;


namespace Negocio
{
    public interface IGerenciadorProduto: IGerenciadorNegocio<Produto, Int32>
    {
        void atualizarPrecos(Produto produto);
        decimal calculaPrecoCustoNormal(decimal precoCompra, decimal diferencialICMS, decimal simples, decimal ipi, decimal frete, decimal manutencao);
        decimal calculaPrecoCustoSubstituicao(decimal precoCompra, decimal ICMSSubstituicao, decimal simples, decimal ipi, decimal frete, decimal manutencao);
        decimal calculaPrecoVenda(decimal precoCusto, decimal lucro);
    }
}
