using System;
using System.Collections.Generic;

#nullable disable

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
    }
}
