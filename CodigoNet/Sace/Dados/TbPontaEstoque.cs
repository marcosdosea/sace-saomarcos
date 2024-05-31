using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbPontaEstoque
    {
        public long CodPontaEstoque { get; set; }
        public long CodProduto { get; set; }
        public decimal Quantidade { get; set; }
        public string? Caracteristica { get; set; }

        public virtual TbProduto CodProdutoNavigation { get; set; } = null!;
    }
}
