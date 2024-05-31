using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbSolicitacaoSaidum
    {
        public long CodSolicitacao { get; set; }
        public long CodSaida { get; set; }
        public decimal ValorTotal { get; set; }

        public virtual TbSaidum CodSaidaNavigation { get; set; } = null!;
        public virtual TbSolicitacaoDocumento CodSolicitacaoNavigation { get; set; } = null!;
    }
}
