using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class SolicitacaoPagamento
    {
        public enum TCartao {CREDITO, DEBITO};

        public long CodSolicitacao { get; set; }
        public long CodSolicitacaoPagamento {get; set; }
        public int CodFormaPagamento { get; set; }
        public int CodCartaoCredito { get; set; }
        public string NomeCartaoCredito { get; set; }
        public decimal Valor { get; set; }
        public int Parcelas { get; set; }
        public int QtdDiasPagar { get; set; }
        public TCartao TipoCartao { 
            get { 
                if (QtdDiasPagar > 5)        
                    return TCartao.CREDITO;
                return TCartao.DEBITO;
            } 
        }
        
     }    
}