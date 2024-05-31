using System;
using System.Collections.Generic;

namespace Dados
{
    public partial class TbProdutoLoja
    {
        public int CodLoja { get; set; }
        public long CodProduto { get; set; }
        public decimal QtdEstoque { get; set; }
        public decimal QtdEstoqueAux { get; set; }
        public string? Localizacao { get; set; }
        public string? Localizacao2 { get; set; }
        public decimal EstoqueMaximo { get; set; }

        public virtual TbLoja CodLojaNavigation { get; set; } = null!;
        public virtual TbProduto CodProdutoNavigation { get; set; } = null!;
    }
}
