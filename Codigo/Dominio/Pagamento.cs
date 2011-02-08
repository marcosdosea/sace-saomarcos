using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Pagamento
    {
        private Int64 codPagamento;

        public Int64 CodPagamento
        {
            get { return codPagamento; }
            set { codPagamento = value; }
        }
        private Int32 codFormaPagamento;

        public Int32 CodFormaPagamento
        {
            get { return codFormaPagamento; }
            set { codFormaPagamento = value; }
        }
        private Int64 codConta;

        public Int64 CodConta
        {
            get { return codConta; }
            set { codConta = value; }
        }
        private decimal valorPago;

        public decimal ValorPago
        {
            get { return valorPago; }
            set { valorPago = value; }
        }
        private decimal valorDiferenca;

        public decimal ValorDiferenca
        {
            get { return valorDiferenca; }
            set { valorDiferenca = value; }
        }
        private Int32 codContaBanco;

        public Int32 CodContaBanco
        {
            get { return codContaBanco; }
            set { codContaBanco = value; }
        }
        private DateTime dataBaixa;

        public DateTime DataBaixa
        {
            get { return dataBaixa; }
            set { dataBaixa = value; }
        }
    }
}
