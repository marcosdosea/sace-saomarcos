using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbTipoContum
    {
        public TbTipoContum()
        {
            TbPlanoConta = new HashSet<TbPlanoContum>();
        }

        public string CodTipoConta { get; set; } = null!;
        public string? DescricaoTipoConta { get; set; }

        public virtual ICollection<TbPlanoContum> TbPlanoConta { get; set; }
    }
}
