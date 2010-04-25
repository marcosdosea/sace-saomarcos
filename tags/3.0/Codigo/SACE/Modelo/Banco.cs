using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SACE.Modelo
{
    
    public class Banco
    {
        private Int32 codBanco;

        public Int32 CodBanco
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
