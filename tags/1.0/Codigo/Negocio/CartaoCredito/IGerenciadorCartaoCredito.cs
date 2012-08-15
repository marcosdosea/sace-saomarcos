using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;


namespace Negocio
{
    public interface IGerenciadorCartaoCredito: IGerenciadorNegocio<CartaoCredito, Int32>
    {

        CartaoCredito obterCartaoCredito(Int32 codCartaoCredito);
    }
}
