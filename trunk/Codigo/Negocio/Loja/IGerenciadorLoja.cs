using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;


namespace Negocio
{
    public interface IGerenciadorLoja: IGerenciadorNegocio<Loja, Int32>
    {
        Loja obter(Int32 codLoja);
    }
}
