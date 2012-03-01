using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Pessoa
    {
        public const String PESSOA_FISICA = "F";
        public const String PESSOA_JURIDICA = "J";

        private Int64 codPessoa;

        public Int64 CodPessoa
        {
            get { return codPessoa; }
            set { codPessoa = value; }
        }
        private String nome;

        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }
        private String cpfCnpj;

        public String CpfCnpj
        {
            get { return cpfCnpj; }
            set { cpfCnpj = value; }
        }

        private String ieSubstituto;

        public String IeSubstituto
        {
            get { return ieSubstituto; }
            set { ieSubstituto = value; }
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

        private String numero;

        public String Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        private String complemento;

        public String Complemento
        {
            get { return complemento; }
            set { complemento = value; }
        }

        private String cep;

        public String Cep
        {
            get { return cep; }
            set { cep = value; }
        }
        private String bairro;

        public String Bairro
        {
            get { return bairro; }
            set { bairro = value; }
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
        private String email;

        public String Email
        {
            get { return email; }
            set { email = value; }
        }
        private String fone1;

        public String Fone1
        {
            get { return fone1; }
            set { fone1 = value; }
        }
        private String fone2;

        public String Fone2
        {
            get { return fone2; }
            set { fone2 = value; }
        }
        private String fone3;

        public String Fone3
        {
            get { return fone3; }
            set { fone3 = value; }
        }

        private Decimal limiteCompra;

        public Decimal LimiteCompra
        {
            get { return limiteCompra; }
            set { limiteCompra = value; }
        }
        private Decimal valorComissao;

        public Decimal ValorComissao
        {
            get { return valorComissao; }
            set { valorComissao = value; }
        }
        private String observacao;

        public String Observacao
        {
            get { return observacao; }
            set { observacao = value; }
        }
        private Char tipo;

        public Char Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }
    }
}
