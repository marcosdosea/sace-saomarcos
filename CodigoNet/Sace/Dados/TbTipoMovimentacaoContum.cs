using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbTipoMovimentacaoContum
    {
        public TbTipoMovimentacaoContum()
        {
            TbMovimentacaoConta = new HashSet<TbMovimentacaoContum>();
        }

        public int CodTipoMovimentacao { get; set; }
        public string? Descricao { get; set; }
        public bool SomaSaldo { get; set; }

        public virtual ICollection<TbMovimentacaoContum> TbMovimentacaoConta { get; set; }
    }
}
