using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;


namespace Negocio
{
    public interface IGerenciadorTipoMovimentacaoConta: IGerenciadorNegocio<TipoMovimentacaoConta, Int32>
    {

        TipoMovimentacaoConta obterTipoMovimentacaoConta(Int32 codTipoMovimentacaoConta);
    }
}
