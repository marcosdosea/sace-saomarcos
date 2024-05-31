using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbSubgrupo
    {
        public TbSubgrupo()
        {
            TbProdutos = new HashSet<TbProduto>();
        }

        public int CodSubgrupo { get; set; }
        public string? Descricao { get; set; }
        public long CodGrupo { get; set; }

        public virtual TbGrupo CodGrupoNavigation { get; set; } = null!;
        public virtual ICollection<TbProduto> TbProdutos { get; set; }
    }
}
