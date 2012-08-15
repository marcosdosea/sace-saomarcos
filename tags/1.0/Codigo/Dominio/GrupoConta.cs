using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class GrupoConta
    {
        private Int32 codGrupoConta;

        public Int32 CodGrupoConta
        {
            get { return codGrupoConta; }
            set { codGrupoConta = value; }
        }

        private String descricao;

        public String Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
    }
}
