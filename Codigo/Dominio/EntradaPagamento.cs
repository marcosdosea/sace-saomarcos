using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class EntradaPagamento
    {
        private Int64 codEntradaFormaPagamento;
        public Int64 CodEntradaFormaPagamento
        {
            get { return codEntradaFormaPagamento; }
            set { codEntradaFormaPagamento = value; }
        }

        private Int64 codEntrada;

        public Int64 CodEntrada
        {
            get { return codEntrada; }
            set { codEntrada = value; }
        }
        private Int32 codFormaPagamento;

        public Int32 CodFormaPagamento
        {
            get { return codFormaPagamento; }
            set { codFormaPagamento = value; }
        }
        private Int32 codContaBanco;

        public Int32 CodContaBanco
        {
            get { return codContaBanco; }
            set { codContaBanco = value; }
        }
        private Int64 codDocumentoPagamento;

        public Int64 CodDocumentoPagamento
        {
            get { return codDocumentoPagamento; }
            set { codDocumentoPagamento = value; }
        }
        private Decimal valor;

        public Decimal Valor
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
