using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SACE.Dominio
{
    public class Banco
    {
        private int codBanco;

        public int CodBanco
        {
            get { return codBanco; }
            set { codBanco = value; }
        }
        private String nome;

        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }
    }
}
