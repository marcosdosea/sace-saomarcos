using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbGrupoContum
    {
        public TbGrupoContum()
        {
            TbPlanoConta = new HashSet<TbPlanoContum>();
        }

        public int CodGrupoConta { get; set; }
        public string Descricao { get; set; } = null!;

        public virtual ICollection<TbPlanoContum> TbPlanoConta { get; set; }
    }
}
