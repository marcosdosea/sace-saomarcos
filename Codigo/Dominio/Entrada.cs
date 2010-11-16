using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Entrada
    {
        private Int64 codEntrada;

        public Int64 CodEntrada
        {
            get { return codEntrada; }
            set { codEntrada = value; }
        }
        private Int64 codEmpresaFrete;

        public Int64 CodEmpresaFrete
        {
            get { return codEmpresaFrete; }
            set { codEmpresaFrete = value; }
        }
        private Int64 codFornecedor;

        public Int64 CodFornecedor
        {
            get { return codFornecedor; }
            set { codFornecedor = value; }
        }
        private Decimal valorCustoFrete;

        public Decimal ValorCustoFrete
        {
            get { return valorCustoFrete; }
            set { valorCustoFrete = value; }
        }
        private DateTime dataEntrada;

        public DateTime DataEntrada
        {
            get { return dataEntrada; }
            set { dataEntrada = value; }
        }
        private Decimal valorTotal;

        public Decimal ValorTotal
        {
            get { return valorTotal; }
            set { valorTotal = value; }
        }
        private Char tipoEntrada;

        public Char TipoEntrada
        {
            get { return tipoEntrada; }
            set { tipoEntrada = value; }
        }
        private String numeroNotaFiscal;

        public String NumeroNotaFiscal
        {
            get { return numeroNotaFiscal; }
            set { numeroNotaFiscal = value; }
        }
        
        private Decimal valorICMSSubstituto;

        public Decimal ValorICMSSubstituto
        {
            get { return valorICMSSubstituto; }
            set { valorICMSSubstituto = value; }
        }

        private Decimal icmsPadrao;
        public Decimal ICMSPadrao
        {
            get { return icmsPadrao; }
            set { icmsPadrao = value; }
        }
    }
}
