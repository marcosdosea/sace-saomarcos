using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class TbCst
    {
        public TbCst()
        {
            TbSaidaProdutos = new HashSet<TbSaidaProduto>();
        }

        public string CodCst { get; set; }
        public string DescricaoCst { get; set; }

        public virtual ICollection<TbSaidaProduto> TbSaidaProdutos { get; set; }
    }
}
