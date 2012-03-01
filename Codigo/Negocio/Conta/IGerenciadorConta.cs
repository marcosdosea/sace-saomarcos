using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;


namespace Negocio
{
    public interface IGerenciadorConta: IGerenciadorNegocio<Conta, Int64>
    {

        List<Conta> obterContasPorEntada(Int64 codEntrada);
        List<Conta> obterContasPorSaida(Int64 codSaida);
    }
}
