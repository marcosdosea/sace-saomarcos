using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class FormaPagamento
    {
        public const Int32 DINHEIRO = 1;
        public const Int32 CREDIARIO = 2;
        public const Int32 CARTAO = 3;
        public const Int32 BOLETO = 4;
        public const Int32 CHEQUE = 5;
        public const Int32 DEPOSITO = 6;
        public const Int32 PROMISSORIA = 7;

        public const String MAPEAMENTO_DINHEIRO = "1";
        public const String MAPEAMENTO_CHEQUE = "2";
        public const String MAPEAMENTO_TROCA = "4";
        public const String MAPEAMENTO_PRAZO = "5";
        public const String MAPEAMENTO_FINANCEIRA = "6";
        public const String MAPEAMENTO_VISA_MASTER = "7";
        public const String MAPEAMENTO_BANESE = "8";
        public const String MAPEAMENTO_HIPER = "9";


        private Int32 codFormaPagamento;

        public Int32 CodFormaPagamento
        {
            get { return codFormaPagamento; }
            set { codFormaPagamento = value; }
        }
        private String descricao;

        public String Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
        private Int32 parcelas;

        public Int32 Parcelas
        {
            get { return parcelas; }
            set { parcelas = value; }
        }
        private decimal descontoAcrescimo;

        public decimal DescontoAcrescimo
        {
            get { return descontoAcrescimo; }
            set { descontoAcrescimo = value; }
        }

        private string mapeamento;

        public string Mapeamento
        {
            get { return mapeamento; }
            set { mapeamento = value; }
        }

    }
}
