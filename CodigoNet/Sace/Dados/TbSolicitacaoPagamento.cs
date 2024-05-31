using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbSolicitacaoPagamento
    {
        public ulong CodSolicitacaoPagamento { get; set; }
        public long CodSolicitacao { get; set; }
        public int CodCartao { get; set; }
        public int CodFormaPagamento { get; set; }
        public decimal Valor { get; set; }
        public uint Parcelas { get; set; }
        public string CupomCliente { get; set; } = null!;
        public string CupomEstabelecimento { get; set; } = null!;
        public string CupomReduzido { get; set; } = null!;

        public virtual TbCartaoCredito CodCartaoNavigation { get; set; } = null!;
        public virtual TbFormaPagamento CodFormaPagamentoNavigation { get; set; } = null!;
        public virtual TbSolicitacaoDocumento CodSolicitacaoNavigation { get; set; } = null!;
    }
}
