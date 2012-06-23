using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;


namespace Negocio
{
    public interface IGerenciadorLoja: IGerenciadorNegocio<Loja, Int32>
    {
        Loja obter(int codLoja);
        Loja obterByCodPessoa(long codPessoa);
    }
}
