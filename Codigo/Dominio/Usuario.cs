using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Usuario
    {
        private long codPessoa;

        public long CodPessoa
        {
            get { return codPessoa; }
            set { codPessoa = value; }
        }
        private string nomePessoa;

        public string NomePessoa
        {
            get { return nomePessoa; }
            set { nomePessoa = value; }
        }
        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        private string senha;

        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }
        private int codPerfil;

        public int CodPerfil
        {
            get { return codPerfil; }
            set { codPerfil = value; }
        }
        private string nomePerfil;

        public string NomePerfil
        {
            get { return nomePerfil; }
            set { nomePerfil = value; }
        }
    }
}
