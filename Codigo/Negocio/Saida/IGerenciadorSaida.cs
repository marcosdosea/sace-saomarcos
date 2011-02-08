using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;


namespace Negocio
{
    public interface IGerenciadorSaida: IGerenciadorNegocio<Saida, Int32>
    {
        Saida obterSaida(Int64 codSaida);
    }
}
