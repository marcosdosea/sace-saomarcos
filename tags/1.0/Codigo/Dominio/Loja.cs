using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Loja
    {
        private Int32 codLoja;

        public Int32 CodLoja
        {
            get { return codLoja; }
            set { codLoja = value; }
        }
        private String nome;

        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private Int64 codPessoa;

        public Int64 CodPessoa
        {
            get { return codPessoa; }
            set { codPessoa = value; }
        }

 
    }
}
