using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class EntradaPagamento
    {
        private long codEntradaFormaPagamento;
        public long CodEntradaFormaPagamento
        {
            get { return codEntradaFormaPagamento; }
            set { codEntradaFormaPagamento = value; }
        }

        private long codEntrada;

        public long CodEntrada
        {
            get { return codEntrada; }
            set { codEntrada = value; }
        }
        private int codFormaPagamento;

        public int CodFormaPagamento
        {
            get { return codFormaPagamento; }
            set { codFormaPagamento = value; }
        }
        private int codContaBanco;

        public int CodContaBanco
        {
            get { return codContaBanco; }
            set { codContaBanco = value; }
        }
       
        private decimal valor;

        public decimal Valor
        {
            get { return valor; }
            set { valor = value; }
        }
        private DateTime data;

        public DateTime Data
        {
            get { return data; }
            set { data = value; }
        }
        private Boolean pagamentoDoFrete;

        public Boolean PagamentoDoFrete
        {
            get { return pagamentoDoFrete; }
            set { pagamentoDoFrete = value; }
        }
    }
}
