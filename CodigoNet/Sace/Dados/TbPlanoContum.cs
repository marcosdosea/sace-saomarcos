using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbPlanoContum
    {
        public TbPlanoContum()
        {
            TbConta = new HashSet<TbContum>();
        }

        public long CodPlanoConta { get; set; }
        public int CodGrupoConta { get; set; }
        public string CodTipoConta { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public short? DiaBase { get; set; }

        public virtual TbGrupoContum CodGrupoContaNavigation { get; set; } = null!;
        public virtual TbTipoContum CodTipoContaNavigation { get; set; } = null!;
        public virtual ICollection<TbContum> TbConta { get; set; }
    }
}
