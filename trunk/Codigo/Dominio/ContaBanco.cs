using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class ContaBanco
    {
        private String codContaBanco;

        public String CodContaBanco
        {
            get { return codContaBanco; }
            set { codContaBanco = value; }
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
