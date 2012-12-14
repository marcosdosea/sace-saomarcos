using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Loja
    {
        private int codLoja;

        public int CodLoja
        {
            get { return codLoja; }
            set { codLoja = value; }
        }
        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private long codPessoa;

        public long CodPessoa
        {
            get { return codPessoa; }
            set { codPessoa = value; }
        }

 
    }
}
