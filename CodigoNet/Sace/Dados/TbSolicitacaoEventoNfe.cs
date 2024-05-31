using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbSolicitacaoEventoNfe
    {
        public uint IdSolicitacaoEvento { get; set; }
        public string TipoSolicitacao { get; set; } = null!;
        public int CodNfe { get; set; }

        public virtual TbNfe CodNfeNavigation { get; set; } = null!;
    }
}
