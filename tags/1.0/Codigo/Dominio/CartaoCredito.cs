using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class CartaoCredito
    {
        private Int32 codCartao;

        public Int32 CodCartao
        {
            get { return codCartao; }
            set { codCartao = value; }
        }
        private String nome;

        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        private Int32 diaBase;

        public Int32 DiaBase
        {
            get { return diaBase; }
            set { diaBase = value; }
        }

        private Int32 codContaBanco;

        public Int32 CodContaBanco
        {
            get { return codContaBanco; }
            set { codContaBanco = value; }
        }

        private Int64 codPessoa;

        public Int64 CodPessoa
        {
            get { return codPessoa; }
            set { codPessoa = value; }
        }

        private string mapeamento;

        public string Mapeamento
        {
            get { return mapeamento; }
            set { mapeamento = value; }
        }
    }
}
