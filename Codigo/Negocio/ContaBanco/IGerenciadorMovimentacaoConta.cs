using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;


namespace Negocio
{
    public interface IGerenciadorMovimentacaoConta : IGerenciadorNegocio<MovimentacaoConta, Int64>
    {

        MovimentacaoConta obterMovimentacaoConta(Int64 codMovimentacaoConta);
    }
}
