using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbGrupo
    {
        public TbGrupo()
        {
            TbProdutos = new HashSet<TbProduto>();
            TbSubgrupos = new HashSet<TbSubgrupo>();
        }

        public long CodGrupo { get; set; }
        public string Descricao { get; set; } = null!;

        public virtual ICollection<TbProduto> TbProdutos { get; set; }
        public virtual ICollection<TbSubgrupo> TbSubgrupos { get; set; }
    }
}
