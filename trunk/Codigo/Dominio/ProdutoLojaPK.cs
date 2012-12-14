using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class ProdutoLojaPK
    {
        private int codLoja;

        public int CodLoja
        {
            get { return codLoja; }
            set { codLoja = value; }
        }
        private int codProduto;

        public int CodProduto
        {
            get { return codProduto; }
            set { codProduto = value; }
        }
     }
}
