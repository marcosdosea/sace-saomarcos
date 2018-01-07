using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class CartaoCreditoAutorizacao
    {
        public string Header { get; set; }
        public long CodAutorizacao { get; set; }
        public int CodIndentificacao { get; set; }
        public string CupomFiscal { get; set; }
        public string TipoDocumentoFiscal { get; set; }
        public decimal Valor { get; set; }
        public string StatusTransacao { get; set; }
        public int TipoTransacao { get; set; }
        public long NsuTransacao { get; set; }
        public string AutorizacaoTransacao { get; set; }
        public DateTime DataHoraAutorizacao { get; set; }
        public int TipoParcelamento { get; set; }
        public int QuantidadeParcelas { get; set; }
        public string NomeBandeiraCartao { get; set; }
        public bool Processado { get; set; }
    }
}
