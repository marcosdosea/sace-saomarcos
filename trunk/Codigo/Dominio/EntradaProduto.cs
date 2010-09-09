using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class EntradaProduto
    {
        private Int64 codEntrada;

        public Int64 CodEntrada
        {
            get { return codEntrada; }
            set { codEntrada = value; }
        }
        private Int64 codProduto;

        public Int64 CodProduto
        {
            get { return codProduto; }
            set { codProduto = value; }
        }
        private Decimal quantidade;

        public Decimal Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }
        private Decimal valorCompra;

        public Decimal ValorCompra
        {
            get { return valorCompra; }
            set { valorCompra = value; }
        }
        private Decimal ipi;

        public Decimal Ipi
        {
            get { return ipi; }
            set { ipi = value; }
        }
        private Decimal icms;

        public Decimal Icms
        {
            get { return icms; }
            set { icms = value; }
        }
        private Decimal icmsSubstituto;

        public Decimal IcmsSubstituto
        {
            get { return icmsSubstituto; }
            set { icmsSubstituto = value; }
        }
        private Decimal precoCusto;

        public Decimal PrecoCusto
        {
            get { return precoCusto; }
            set { precoCusto = value; }
        }

    }
}
