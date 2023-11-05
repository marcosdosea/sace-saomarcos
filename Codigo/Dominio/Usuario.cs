using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class Usuario
    {
        public long CodPessoa { get; set; }

        public string NomePessoa { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public int CodPerfil { get; set; }

        public string NomePerfil { get; set; }
    }
}
