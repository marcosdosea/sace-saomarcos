using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class TbEntradaFormaPagamento
    {
        public long CodEntradaFormaPagamento { get; set; }
        public long CodEntrada { get; set; }
        public int CodFormaPagamento { get; set; }
        public int CodContaBanco { get; set; }
        public decimal? Valor { get; set; }
        public DateTime? Data { get; set; }
        public bool? PagamentoDoFrete { get; set; }
    }
}
