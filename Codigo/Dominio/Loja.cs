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
        private String cnpj;

        public String Cnpj
        {
            get { return cnpj; }
            set { cnpj = value; }
        }
        private String ie;

        public String Ie
        {
            get { return ie; }
            set { ie = value; }
        }
        private String endereco;

        public String Endereco
        {
            get { return endereco; }
            set { endereco = value; }
        }
        private String bairro;

        public String Bairro
        {
            get { return bairro; }
            set { bairro = value; }
        }
        private String cep;

        public String Cep
        {
            get { return cep; }
            set { cep = value; }
        }
        private String cidade;

        public String Cidade
        {
            get { return cidade; }
            set { cidade = value; }
        }
        private String uf;

        public String Uf
        {
            get { return uf; }
            set { uf = value; }
        }
        private String fone;

        public String Fone
        {
            get { return fone; }
            set { fone = value; }
        }

    }
}
