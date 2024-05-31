using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbSituacaoProduto
    {
        public TbSituacaoProduto()
        {
            TbProdutos = new HashSet<TbProduto>();
        }

        public sbyte CodSituacaoProduto { get; set; }
        public string DescricaoSituacao { get; set; } = null!;

        public virtual ICollection<TbProduto> TbProdutos { get; set; }
    }
}
