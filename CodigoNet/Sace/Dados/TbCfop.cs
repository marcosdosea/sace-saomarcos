using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbCfop
    {
        public TbCfop()
        {
            TbEntradaProdutos = new HashSet<TbEntradaProduto>();
            TbSaidaProdutos = new HashSet<TbSaidaProduto>();
            TbTipoSaida = new HashSet<TbTipoSaidum>();
        }

        public int Cfop { get; set; }
        public string? Descricao { get; set; }
        public decimal? Icms { get; set; }

        public virtual ICollection<TbEntradaProduto> TbEntradaProdutos { get; set; }
        public virtual ICollection<TbSaidaProduto> TbSaidaProdutos { get; set; }
        public virtual ICollection<TbTipoSaidum> TbTipoSaida { get; set; }
    }
}
