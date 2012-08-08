using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class ProdutoLoja
    {
        public Int32 CodLoja { get; set; }
        public Int32 CodProduto { get; set; }
        public decimal QtdEstoque { get; set; }
        public decimal QtdEstoqueAux { get; set; }
        public String Localizacao { get; set; }
        public String Localizacao2 { get; set; }
        
    }
}
