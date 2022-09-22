using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class TbImprimirDocumentoSaidum
    {
        public long CodImprimir { get; set; }
        public long CodSaida { get; set; }

        public virtual TbImprimirDocumento CodImprimirNavigation { get; set; }
        public virtual TbSaidum CodSaidaNavigation { get; set; }
    }
}
