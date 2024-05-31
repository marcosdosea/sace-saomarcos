using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TpTipoEntradum
    {
        public TpTipoEntradum()
        {
            TbEntrada = new HashSet<TbEntradum>();
        }

        public int CodTipoEntrada { get; set; }
        public string DescricaoTipoEntrada { get; set; } = null!;

        public virtual ICollection<TbEntradum> TbEntrada { get; set; }
    }
}
