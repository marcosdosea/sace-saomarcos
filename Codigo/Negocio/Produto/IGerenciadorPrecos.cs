using System;

namespace Negocio
{
    public interface IGerenciadorPrecos
    {
        decimal calculaPrecoCustoNormal(decimal precoCompra, decimal diferencialICMS, decimal simples, decimal ipi, decimal frete, decimal manutencao, decimal desconto);
        decimal calculaPrecoCustoSubstituicao(decimal precoCompra, decimal ICMSSubstituicao, decimal simples, decimal ipi, decimal frete, decimal manutencao, decimal desconto);
        decimal calculaPrecoVenda(decimal precoCusto, decimal lucro);
    }
}
