using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Usuario
    {
        private Int32 codPessoa;

        public Int32 CodPessoa
        {
            get { return codPessoa; }
            set { codPessoa = value; }
        }
        private String nomePessoa;

        public String NomePessoa
        {
            get { return nomePessoa; }
            set { nomePessoa = value; }
        }
        private String login;

        public String Login
        {
            get { return login; }
            set { login = value; }
        }
        private String senha;

        public String Senha
        {
            get { return senha; }
            set { senha = value; }
        }
        private Int32 codPerfil;

        public Int32 CodPerfil
        {
            get { return codPerfil; }
            set { codPerfil = value; }
        }
        private String nomePerfil;

        public String NomePerfil
        {
            get { return nomePerfil; }
            set { nomePerfil = value; }
        }
    }
}
