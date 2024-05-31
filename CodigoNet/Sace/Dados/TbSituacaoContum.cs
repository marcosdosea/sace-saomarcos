using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbSituacaoContum
    {
        public TbSituacaoContum()
        {
            TbConta = new HashSet<TbContum>();
        }

        public string CodSituacao { get; set; } = null!;
        public string? DescricaoSituacao { get; set; }

        public virtual ICollection<TbContum> TbConta { get; set; }
    }
}
