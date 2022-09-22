using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class TbContum
    {
        public long CodConta { get; set; }
        public long CodPlanoConta { get; set; }
        public long CodPessoa { get; set; }
        public string CodSituacao { get; set; }
        public long? CodEntrada { get; set; }
        public long? CodSaida { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal Valor { get; set; }
        public string Observacao { get; set; }
        public long? CodPagamento { get; set; }
        public decimal Desconto { get; set; }
        public string FormatoConta { get; set; }
        public string NumeroDocumento { get; set; }
    }
}
