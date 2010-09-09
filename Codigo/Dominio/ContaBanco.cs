using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class ContaBanco
    {
        private Int32 codContaBanco;

        public Int32 CodContaBanco
        {
            get { return codContaBanco; }
            set { codContaBanco = value; }
        }

        private String numeroConta;

        public String NumeroConta
        {
            get { return numeroConta; }
            set { numeroConta = value; }
        }

        private String agencia;

        public String Agencia
        {
            get { return agencia; }
            set { agencia = value; }
        }
        private String descricao;

        public String Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
        private Decimal saldo;

        public Decimal Saldo
        {
            get { return saldo; }
            set { saldo = value; }
        }
        private Int32 codBanco;

        public Int32 CodBanco
        {
            get { return codBanco; }
            set { codBanco = value; }
        }
    }
}
