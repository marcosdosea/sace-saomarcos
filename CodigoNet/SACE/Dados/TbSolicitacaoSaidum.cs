using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class TbSolicitacaoSaidum
    {
        public long CodSolicitacao { get; set; }
        public long CodSaida { get; set; }
        public decimal ValorTotal { get; set; }

        public virtual TbSolicitacaoDocumento CodSolicitacaoNavigation { get; set; }
    }
}
