using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbCst
    {
        public TbCst()
        {
            TbEntradaProdutos = new HashSet<TbEntradaProduto>();
            TbProdutos = new HashSet<TbProduto>();
            TbSaidaProdutos = new HashSet<TbSaidaProduto>();
        }

        public string CodCst { get; set; } = null!;
        public string? DescricaoCst { get; set; }

        public virtual ICollection<TbEntradaProduto> TbEntradaProdutos { get; set; }
        public virtual ICollection<TbProduto> TbProdutos { get; set; }
        public virtual ICollection<TbSaidaProduto> TbSaidaProdutos { get; set; }
    }
}
