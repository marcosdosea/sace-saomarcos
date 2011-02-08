using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class SaidaProduto
    {
        private Int64 codSaidaProduto;

        public Int64 CodSaidaProduto
        {
            get { return codSaidaProduto; }
            set { codSaidaProduto = value; }
        }
        private Int64 codProduto;

        public Int64 CodProduto
        {
            get { return codProduto; }
            set { codProduto = value; }
        }
        private Int64 codSaida;

        public Int64 CodSaida
        {
            get { return codSaida; }
            set { codSaida = value; }
        }
        private decimal quantidade;

        public decimal Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }
        private decimal valorVenda;

        public decimal ValorVenda
        {
            get { return valorVenda; }
            set { valorVenda = value; }
        }
        private decimal desconto;

        public decimal Desconto
        {
            get { return desconto; }
            set { desconto = value; }
        }
        private decimal subtotal;

        public decimal Subtotal
        {
            get { return subtotal; }
            set { subtotal = value; }
        }
    }
}
