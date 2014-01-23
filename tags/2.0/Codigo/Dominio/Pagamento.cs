using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Pagamento
    {
        private long codPagamento;

        public long CodPagamento
        {
            get { return codPagamento; }
            set { codPagamento = value; }
        }
        private int codFormaPagamento;

        public int CodFormaPagamento
        {
            get { return codFormaPagamento; }
            set { codFormaPagamento = value; }
        }
        private long codConta;

        public long CodConta
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
        private int codContaBanco;

        public int CodContaBanco
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
