using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class ContatoPessoa
    {
        private Int64 codPessoa;

        public Int64 CodPessoa
        {
            get { return codPessoa; }
            set { codPessoa = value; }
        }
        private Int64 codPessoaContato;

        public Int64 CodPessoaContato
        {
            get { return codPessoaContato; }
            set { codPessoaContato = value; }
        }
    }
}
