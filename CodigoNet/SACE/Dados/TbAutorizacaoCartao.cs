using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class TbAutorizacaoCartao
    {
        public TbAutorizacaoCartao()
        {
            TbAutorizacaoCartaoSaida = new HashSet<TbAutorizacaoCartaoSaidum>();
        }

        public long CodAutorizacao { get; set; }
        public long CodIdentificacao { get; set; }
        public string Header { get; set; }
        public string CupomFiscal { get; set; }
        public string TipoDocumentoFiscal { get; set; }
        public decimal Valor { get; set; }
        public string StatusTransacao { get; set; }
        public int TipoTransacao { get; set; }
        public long NsuTransacao { get; set; }
        public string AutorizacaoTransacao { get; set; }
        public DateTime? DataHoraAutorizacao { get; set; }
        public int? TipoParcelamento { get; set; }
        public int? QuantidadeParcelas { get; set; }
        public string NomeBandeiraCartao { get; set; }
        public bool Processado { get; set; }

        public virtual ICollection<TbAutorizacaoCartaoSaidum> TbAutorizacaoCartaoSaida { get; set; }
    }
}
