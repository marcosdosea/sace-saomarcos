using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class ProdutoLoja
    {
        public int CodLoja { get; set; }
        public string NomeLoja { get; set; }
        public long CodProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal QtdEstoque { get; set; }
        public decimal QtdEstoqueAux { get; set; }
        public string Localizacao { get; set; }
        public string Localizacao2 { get; set; }
        public decimal EstoqueMaximo { get; set; }
        
    }
}
