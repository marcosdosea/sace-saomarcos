using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class FormaPagamento
    {
        public const Int32 FORMA_PGTO_DINHEIRO = 1;
        public const Int32 FORMA_PGTO_CREDIARIO = 2;
        public const Int32 FORMA_PGTO_VISA = 3;

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
    }
}
