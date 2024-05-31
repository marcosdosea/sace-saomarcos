using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbSaidaFormaPagamento
    {
        public long CodSaidaFormaPagamento { get; set; }
        public long CodSaida { get; set; }
        public int CodFormaPagamento { get; set; }
        public int CodContaBanco { get; set; }
        public int CodCartao { get; set; }
        public decimal? Valor { get; set; }
        public DateTime? Data { get; set; }
        public int? Parcelas { get; set; }
        public int? IntervaloDias { get; set; }
        public string NumeroControle { get; set; } = null!;

        public virtual TbCartaoCredito CodCartaoNavigation { get; set; } = null!;
        public virtual TbContaBanco CodContaBancoNavigation { get; set; } = null!;
        public virtual TbFormaPagamento CodFormaPagamentoNavigation { get; set; } = null!;
        public virtual TbSaidum CodSaidaNavigation { get; set; } = null!;
    }
}
