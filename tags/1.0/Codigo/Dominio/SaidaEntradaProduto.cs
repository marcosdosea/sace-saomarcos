using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    /// <summary>
    /// Para cada saída efetivada é determinada a qual entrada ela se refere
    /// </summary>
    public class SaidaEntradaProduto
    {
        public long CodSaidaProduto { get; set; }
        public long CodEntradaProduto { get; set; }
        public decimal Quantidade { get; set; }
    }
}
