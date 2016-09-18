using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class FormaPagamento
    {
        public const int DINHEIRO = 1;
        public const int CREDIARIO = 2;
        public const int CARTAO = 3;
        public const int BOLETO = 4;
        public const int CHEQUE = 5;
        public const int DEPOSITO = 6;
        public const int PROMISSORIA = 7;

        //public const string MAPEAMENTO_DINHEIRO = "1";
        //public const string MAPEAMENTO_CHEQUE = "2";
        //public const string MAPEAMENTO_TROCA = "4";
        //public const string MAPEAMENTO_PRAZO = "5";
        //public const string MAPEAMENTO_FINANCEIRA = "6";
        //public const string MAPEAMENTO_VISA_MASTER = "7";
        //public const string MAPEAMENTO_BANESE = "8";
        //public const string MAPEAMENTO_HIPER = "9";


        private int codFormaPagamento;

        public int CodFormaPagamento
        {
            get { return codFormaPagamento; }
            set { codFormaPagamento = value; }
        }
        private string descricao;

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
        private int parcelas;

        public int Parcelas
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

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            return this.CodFormaPagamento == ((FormaPagamento)obj).CodFormaPagamento;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            return this.CodFormaPagamento.GetHashCode();
        }

    }
}
