using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbImprimirDocumento
    {
        public TbImprimirDocumento()
        {
            CodSaida = new HashSet<TbSaidum>();
        }

        public long CodImprimir { get; set; }
        public string TipoDocumento { get; set; } = null!;
        public long CodDocumento { get; set; }
        public string HostSolicitante { get; set; } = null!;
        public decimal? Total { get; set; }
        public decimal? TotalAvista { get; set; }
        public decimal? Desconto { get; set; }

        public virtual ICollection<TbSaidum> CodSaida { get; set; }
    }
}
