using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbTipoSaidum
    {
        public TbTipoSaidum()
        {
            TbSaida = new HashSet<TbSaidum>();
        }

        public int CodTipoSaida { get; set; }
        public string DescricaoTipoSaida { get; set; } = null!;
        public int Cfop { get; set; }

        public virtual TbCfop CfopNavigation { get; set; } = null!;
        public virtual ICollection<TbSaidum> TbSaida { get; set; }
    }
}
