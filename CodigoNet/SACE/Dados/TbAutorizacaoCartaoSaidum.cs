using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class TbAutorizacaoCartaoSaidum
    {
        public long CodSaida { get; set; }
        public long CodAutorizacao { get; set; }

        public virtual TbAutorizacaoCartao CodAutorizacaoNavigation { get; set; }
    }
}
