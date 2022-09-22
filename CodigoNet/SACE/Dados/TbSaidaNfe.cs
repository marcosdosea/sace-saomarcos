using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class TbSaidaNfe
    {
        public long CodSaida { get; set; }
        public int CodNfe { get; set; }

        public virtual TbNfe CodNfeNavigation { get; set; }
        public virtual TbSaidum CodSaidaNavigation { get; set; }
    }
}
