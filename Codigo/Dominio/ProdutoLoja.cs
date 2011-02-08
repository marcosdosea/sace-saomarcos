using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class ProdutoLoja
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
        private decimal qtdEstoque;

        public decimal QtdEstoque
        {
            get { return qtdEstoque; }
            set { qtdEstoque = value; }
        }
        private decimal qtdEstoqueAux;

        public decimal QtdEstoqueAux
        {
            get { return qtdEstoqueAux; }
            set { qtdEstoqueAux = value; }
        }
        private decimal precoCusto;

        public decimal PrecoCusto
        {
            get { return precoCusto; }
            set { precoCusto = value; }
        }
        private String localizacao;

        public String Localizacao
        {
            get { return localizacao; }
            set { localizacao = value; }
        }
    }
}
