using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class TbImprimirDocumento
    {
        public TbImprimirDocumento()
        {
            TbImprimirDocumentoSaida = new HashSet<TbImprimirDocumentoSaidum>();
        }

        public long CodImprimir { get; set; }
        public string TipoDocumento { get; set; }
        public long CodDocumento { get; set; }
        public string HostSolicitante { get; set; }
        public decimal? Total { get; set; }
        public decimal? TotalAvista { get; set; }
        public decimal? Desconto { get; set; }

        public virtual ICollection<TbImprimirDocumentoSaidum> TbImprimirDocumentoSaida { get; set; }
    }
}
