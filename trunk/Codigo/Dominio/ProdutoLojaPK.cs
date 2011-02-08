using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class ProdutoLojaPK
    {
        private Int32 codLoja;

        public Int32 CodLoja
        {
            get { return codLoja; }
            set { codLoja = value; }
        }
        private Int32 codProduto;

        public Int32 CodProduto
        {
            get { return codProduto; }
            set { codProduto = value; }
        }
     }
}
