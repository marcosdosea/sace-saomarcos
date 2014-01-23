using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class ProdutoVendido
    {
        public long CodProduto { get; set; }
        public string Nome { get; set; }
        public decimal QuantidadeVendida { get; set; }
        public string MesAno { get; set; }
    }
}
