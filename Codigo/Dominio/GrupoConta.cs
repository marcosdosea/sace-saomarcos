using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class GrupoConta
    {
        private int codGrupoConta;

        public int CodGrupoConta
        {
            get { return codGrupoConta; }
            set { codGrupoConta = value; }
        }

        private string descricao;

        public string Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }
    }
}
