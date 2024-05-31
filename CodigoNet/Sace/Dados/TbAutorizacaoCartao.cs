using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbAutorizacaoCartao
    {
        public TbAutorizacaoCartao()
        {
            CodSaida = new HashSet<TbSaidum>();
        }

        public long CodAutorizacao { get; set; }
        public long CodIdentificacao { get; set; }
        public string Header { get; set; } = null!;
        public string CupomFiscal { get; set; } = null!;
        public string TipoDocumentoFiscal { get; set; } = null!;
        public decimal Valor { get; set; }
        public string StatusTransacao { get; set; } = null!;
        public int TipoTransacao { get; set; }
        public long NsuTransacao { get; set; }
        public string? AutorizacaoTransacao { get; set; }
        public DateTime? DataHoraAutorizacao { get; set; }
        public int? TipoParcelamento { get; set; }
        public int? QuantidadeParcelas { get; set; }
        public string? NomeBandeiraCartao { get; set; }
        public bool Processado { get; set; }

        public virtual ICollection<TbSaidum> CodSaida { get; set; }
    }
}
