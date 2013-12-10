using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class PontaEstoque
    {
        public long CodPontaEstoque { get; set; }
        public long CodProduto { get; set; }
        public string NomeProduto { get; set; }
        public decimal Quantidade { get; set; }
        public string Caracteristica { get; set; }
        
    }
}
