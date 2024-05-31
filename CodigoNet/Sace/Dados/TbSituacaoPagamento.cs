using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbSituacaoPagamento
    {
        public TbSituacaoPagamento()
        {
            TbEntrada = new HashSet<TbEntradum>();
            TbSaida = new HashSet<TbSaidum>();
        }

        public int CodSituacaoPagamentos { get; set; }
        public string DescricaoSituacaoPagamentos { get; set; } = null!;

        public virtual ICollection<TbEntradum> TbEntrada { get; set; }
        public virtual ICollection<TbSaidum> TbSaida { get; set; }
    }
}
