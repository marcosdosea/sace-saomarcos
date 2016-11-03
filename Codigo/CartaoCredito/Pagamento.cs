using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cartao
{
    public enum TipoCartao { DEBITO, CREDITO, CREDIARIO };
    public enum TipoParcelamento { ADMINISTRADORA = 1, LOJA = 2, INDEFINIDO = 0 };
    //public enum TipoProcessamento { PAGAMENTO, CANCELAMENTO, REIMPRESSAO, CREDITO } 
        
    public class Pagamento
    {
        public enum SituacaoPagamento { AUTORIZADA, SOLICITADA };
        public string NomeCartao { get; set; }
        public TipoCartao TipoCartao { get; set; }
        public TipoParcelamento TipoParcelamento { get; set; }     
        public double Valor { get; set; }
        public int QuantidadeParcelas { get; set; }
        public long CodSolicitacaoPagamento { get; set; }
        public long CodSolicitacao { get; set; }
        public SituacaoPagamento Situacao { get; set; }
    }
}
