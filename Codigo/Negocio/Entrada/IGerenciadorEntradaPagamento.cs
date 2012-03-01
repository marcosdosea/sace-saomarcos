using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;


namespace Negocio
{
    public interface IGerenciadorEntradaPagamento: IGerenciadorNegocio<EntradaPagamento, Int64>
    {
        decimal totalPagamentos(Int64 codEntrada);

        Int64 inserir(EntradaPagamento entradaPagamento, Entrada entrada);

        List<EntradaPagamento> obterEntradaPagamentos(Int64 codEntrada);

    }
}