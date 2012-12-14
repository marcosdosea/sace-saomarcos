using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class ProdutoLoja
    {
        public int CodLoja { get; set; }
        public int CodProduto { get; set; }
        public decimal QtdEstoque { get; set; }
        public decimal QtdEstoqueAux { get; set; }
        public string Localizacao { get; set; }
        public string Localizacao2 { get; set; }
        public decimal EstoqueMaximo { get; set; }
        
    }
}
