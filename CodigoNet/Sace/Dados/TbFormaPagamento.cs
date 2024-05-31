using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbFormaPagamento
    {
        public TbFormaPagamento()
        {
            TbEntradaFormaPagamentos = new HashSet<TbEntradaFormaPagamento>();
            TbSaidaFormaPagamentos = new HashSet<TbSaidaFormaPagamento>();
            TbSolicitacaoPagamentos = new HashSet<TbSolicitacaoPagamento>();
        }

        public int CodFormaPagamento { get; set; }
        public string Descricao { get; set; } = null!;
        public int Parcelas { get; set; }
        public decimal DescontoAcrescimo { get; set; }
        public string? Mapeamento { get; set; }

        public virtual ICollection<TbEntradaFormaPagamento> TbEntradaFormaPagamentos { get; set; }
        public virtual ICollection<TbSaidaFormaPagamento> TbSaidaFormaPagamentos { get; set; }
        public virtual ICollection<TbSolicitacaoPagamento> TbSolicitacaoPagamentos { get; set; }
    }
}
