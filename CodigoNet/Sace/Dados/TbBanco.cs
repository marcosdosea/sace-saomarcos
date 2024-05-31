using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbBanco
    {
        public TbBanco()
        {
            TbContaBancos = new HashSet<TbContaBanco>();
        }

        public int CodBanco { get; set; }
        public string Nome { get; set; } = null!;

        public virtual ICollection<TbContaBanco> TbContaBancos { get; set; }
    }
}
