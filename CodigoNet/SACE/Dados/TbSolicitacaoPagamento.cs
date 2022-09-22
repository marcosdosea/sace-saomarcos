using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class TbSolicitacaoPagamento
    {
        public long CodSolicitacaoPagamento { get; set; }
        public long CodSolicitacao { get; set; }
        public int CodCartao { get; set; }
        public int CodFormaPagamento { get; set; }
        public decimal Valor { get; set; }
        public int Parcelas { get; set; }
        public string CupomCliente { get; set; }
        public string CupomEstabelecimento { get; set; }
        public string CupomReduzido { get; set; }

        public virtual TbSolicitacaoDocumento CodSolicitacaoNavigation { get; set; }
    }
}
