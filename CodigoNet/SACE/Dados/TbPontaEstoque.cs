using System;
using System.Collections.Generic;

#nullable disable

namespace Dados
{
    public partial class TbPontaEstoque
    {
        public long CodPontaEstoque { get; set; }
        public long CodProduto { get; set; }
        public decimal Quantidade { get; set; }
        public string Caracteristica { get; set; }
    }
}
