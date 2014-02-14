using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class ProdutoNome
    {
        public long CodProduto { get; set; }
        public string Nome { get; set; }

        // override object.Equals
        public override bool Equals(object obj)
        {
            return this.CodProduto == ((ProdutoNome)obj).CodProduto;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.CodProduto.GetHashCode();
        }
    }
}
