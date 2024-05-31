using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbMovimentacaoContum
    {
        public long CodMovimentacao { get; set; }
        public int CodContaBanco { get; set; }
        public long CodResponsavel { get; set; }
        public int CodTipoMovimentacao { get; set; }
        public long? CodConta { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHora { get; set; }

        public virtual TbContaBanco CodContaBancoNavigation { get; set; } = null!;
        public virtual TbContum? CodContaNavigation { get; set; }
        public virtual TbPessoa CodResponsavelNavigation { get; set; } = null!;
        public virtual TbTipoMovimentacaoContum CodTipoMovimentacaoNavigation { get; set; } = null!;
    }
}
