using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;


namespace Negocio
{
    public interface IGerenciadorEntrada: IGerenciadorNegocio<Entrada, Int64>
    {

        Entrada obterEntrada(Int64 codEntrada);



        void encerrar(Entrada entrada);
    }
}
