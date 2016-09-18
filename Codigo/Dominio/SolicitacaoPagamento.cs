using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class SolicitacaoPagamento
    {
        public long CodSolicitacao { get; set; }
        public long CodSolicitacaoPagamento {get; set; }
        public int CodFormaPagamento { get; set; }
        public int CodCartaoCredito { get; set; }
        public string NomeCartaoCredito { get; set; }
        public decimal Valor { get; set; }
        public long Parcelas { get; set; }
        
     }    
}